namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Projects the location found with Get Location Info to a 2d map using common projections."), ActionCategory(ActionCategory.Device)]
    public class ProjectLocationToMap : FsmStateAction
    {
        public bool everyFrame;
        [Tooltip("Location vector in degrees longitude and latitude. Typically returned by the Get Location Info action.")]
        public FsmVector3 GPSLocation;
        public FsmFloat height;
        [Tooltip("The projection used by the map.")]
        public MapProjection mapProjection;
        [HasFloatSlider(-90f, 90f)]
        public FsmFloat maxLatitude;
        [HasFloatSlider(-180f, 180f)]
        public FsmFloat maxLongitude;
        [HasFloatSlider(-90f, 90f)]
        public FsmFloat minLatitude;
        [HasFloatSlider(-180f, 180f), ActionSection("Map Region")]
        public FsmFloat minLongitude;
        [ActionSection("Screen Region")]
        public FsmFloat minX;
        public FsmFloat minY;
        [Tooltip("If true all coordinates in this action are normalized (0-1); otherwise coordinates are in pixels.")]
        public FsmBool normalized;
        [ActionSection("Projection"), UIHint(UIHint.Variable), Tooltip("Store the projected X coordinate in a Float Variable. Use this to display a marker on the map.")]
        public FsmFloat projectedX;
        [Tooltip("Store the projected Y coordinate in a Float Variable. Use this to display a marker on the map."), UIHint(UIHint.Variable)]
        public FsmFloat projectedY;
        public FsmFloat width;
        private float x;
        private float y;

        private void DoEquidistantCylindrical()
        {
            this.x = (this.x - this.minLongitude.Value) / (this.maxLongitude.Value - this.minLongitude.Value);
            this.y = (this.y - this.minLatitude.Value) / (this.maxLatitude.Value - this.minLatitude.Value);
        }

        private void DoMercatorProjection()
        {
            this.x = (this.x - this.minLongitude.Value) / (this.maxLongitude.Value - this.minLongitude.Value);
            float num = LatitudeToMercator(this.minLatitude.Value);
            float num2 = LatitudeToMercator(this.maxLatitude.Value);
            this.y = (LatitudeToMercator(this.GPSLocation.Value.y) - num) / (num2 - num);
        }

        private void DoProjectGPSLocation()
        {
            this.x = Mathf.Clamp(this.GPSLocation.Value.x, this.minLongitude.Value, this.maxLongitude.Value);
            this.y = Mathf.Clamp(this.GPSLocation.Value.y, this.minLatitude.Value, this.maxLatitude.Value);
            switch (this.mapProjection)
            {
                case MapProjection.EquidistantCylindrical:
                    this.DoEquidistantCylindrical();
                    break;

                case MapProjection.Mercator:
                    this.DoMercatorProjection();
                    goto Label_0097;
            }
        Label_0097:
            this.x *= this.width.Value;
            this.y *= this.height.Value;
            this.projectedX.Value = !this.normalized.Value ? (this.minX.Value + (this.x * Screen.width)) : (this.minX.Value + this.x);
            this.projectedY.Value = !this.normalized.Value ? (this.minY.Value + (this.y * Screen.height)) : (this.minY.Value + this.y);
        }

        private static float LatitudeToMercator(float latitudeInDegrees)
        {
            float num = Mathf.Clamp(latitudeInDegrees, -85f, 85f);
            num = 0.01745329f * num;
            return Mathf.Log(Mathf.Tan((num / 2f) + 0.7853982f));
        }

        public override void OnEnter()
        {
            if (this.GPSLocation.IsNone)
            {
                base.Finish();
            }
            else
            {
                this.DoProjectGPSLocation();
                if (!this.everyFrame)
                {
                    base.Finish();
                }
            }
        }

        public override void OnUpdate()
        {
            this.DoProjectGPSLocation();
        }

        public override void Reset()
        {
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.GPSLocation = vector;
            this.mapProjection = MapProjection.EquidistantCylindrical;
            this.minLongitude = -180f;
            this.maxLongitude = 180f;
            this.minLatitude = -90f;
            this.maxLatitude = 90f;
            this.minX = 0f;
            this.minY = 0f;
            this.width = 1f;
            this.height = 1f;
            this.normalized = 1;
            this.projectedX = null;
            this.projectedY = null;
            this.everyFrame = false;
        }

        public enum MapProjection
        {
            EquidistantCylindrical,
            Mercator
        }
    }
}


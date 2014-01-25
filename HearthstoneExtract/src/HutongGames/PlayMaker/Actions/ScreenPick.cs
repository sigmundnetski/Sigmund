namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Perform a raycast into the scene using screen coordinates and stores the results. Use Ray Distance to set how close the camera must be to pick the object. NOTE: Uses the MainCamera!"), ActionCategory(ActionCategory.Input)]
    public class ScreenPick : FsmStateAction
    {
        public bool everyFrame;
        [Tooltip("Invert the mask, so you pick from all layers except those defined above.")]
        public FsmBool invertMask;
        [Tooltip("Pick only from these layers."), UIHint(UIHint.Layer)]
        public FsmInt[] layerMask;
        [Tooltip("Are the supplied screen coordinates normalized (0-1), or in pixels.")]
        public FsmBool normalized;
        [RequiredField]
        public FsmFloat rayDistance = 100f;
        [Tooltip("A Vector3 screen position. Commonly stored by other actions.")]
        public FsmVector3 screenVector;
        [Tooltip("X position on screen.")]
        public FsmFloat screenX;
        [Tooltip("Y position on screen.")]
        public FsmFloat screenY;
        [UIHint(UIHint.Variable)]
        public FsmBool storeDidPickObject;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeDistance;
        [UIHint(UIHint.Variable)]
        public FsmGameObject storeGameObject;
        [UIHint(UIHint.Variable)]
        public FsmVector3 storeNormal;
        [UIHint(UIHint.Variable)]
        public FsmVector3 storePoint;

        private void DoScreenPick()
        {
            if (Camera.main == null)
            {
                this.LogError("No MainCamera defined!");
                base.Finish();
            }
            else
            {
                RaycastHit hit;
                Vector3 zero = Vector3.zero;
                if (!this.screenVector.IsNone)
                {
                    zero = this.screenVector.Value;
                }
                if (!this.screenX.IsNone)
                {
                    zero.x = this.screenX.Value;
                }
                if (!this.screenY.IsNone)
                {
                    zero.y = this.screenY.Value;
                }
                if (this.normalized.Value)
                {
                    zero.x *= Screen.width;
                    zero.y *= Screen.height;
                }
                Physics.Raycast(Camera.main.ScreenPointToRay(zero), out hit, this.rayDistance.Value, ActionHelpers.LayerArrayToLayerMask(this.layerMask, this.invertMask.Value));
                bool flag = hit.collider != null;
                this.storeDidPickObject.Value = flag;
                if (flag)
                {
                    this.storeGameObject.Value = hit.collider.gameObject;
                    this.storeDistance.Value = hit.distance;
                    this.storePoint.Value = hit.point;
                    this.storeNormal.Value = hit.normal;
                }
                else
                {
                    this.storeGameObject.Value = null;
                    this.storeDistance = (float) 1.0 / (float) 0.0;
                    this.storePoint.Value = Vector3.zero;
                    this.storeNormal.Value = Vector3.zero;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoScreenPick();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoScreenPick();
        }

        public override void Reset()
        {
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.screenVector = vector;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.screenX = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.screenY = num;
            this.normalized = 0;
            this.rayDistance = 100f;
            this.storeDidPickObject = null;
            this.storeGameObject = null;
            this.storePoint = null;
            this.storeNormal = null;
            this.storeDistance = null;
            this.layerMask = new FsmInt[0];
            this.invertMask = 0;
            this.everyFrame = false;
        }
    }
}


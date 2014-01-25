namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Input), Tooltip("Perform a Mouse Pick on the scene and stores the results. Use Ray Distance to set how close the camera must be to pick the object.")]
    public class MousePick : FsmStateAction
    {
        public bool everyFrame;
        [Tooltip("Invert the mask, so you pick from all layers except those defined above.")]
        public FsmBool invertMask;
        [Tooltip("Pick only from these layers."), UIHint(UIHint.Layer)]
        public FsmInt[] layerMask;
        [RequiredField]
        public FsmFloat rayDistance = 100f;
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

        private void DoMousePick()
        {
            RaycastHit hit = ActionHelpers.MousePick(this.rayDistance.Value, ActionHelpers.LayerArrayToLayerMask(this.layerMask, this.invertMask.Value));
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
                this.storeDistance.Value = float.PositiveInfinity;
                this.storePoint.Value = Vector3.zero;
                this.storeNormal.Value = Vector3.zero;
            }
        }

        public override void OnEnter()
        {
            this.DoMousePick();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoMousePick();
        }

        public override void Reset()
        {
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


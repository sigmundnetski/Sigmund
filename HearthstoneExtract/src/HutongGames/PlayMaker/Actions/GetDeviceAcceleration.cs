namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Device), Tooltip("Gets the last measured linear acceleration of a device and stores it in a Vector3 Variable.")]
    public class GetDeviceAcceleration : FsmStateAction
    {
        public bool everyFrame;
        public FsmFloat multiplier;
        [UIHint(UIHint.Variable)]
        public FsmVector3 storeVector;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeX;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeY;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeZ;

        private void DoGetDeviceAcceleration()
        {
            Vector3 vector = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
            if (!this.multiplier.IsNone)
            {
                vector = (Vector3) (vector * this.multiplier.Value);
            }
            this.storeVector.Value = vector;
            this.storeX.Value = vector.x;
            this.storeY.Value = vector.y;
            this.storeZ.Value = vector.z;
        }

        public override void OnEnter()
        {
            this.DoGetDeviceAcceleration();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetDeviceAcceleration();
        }

        public override void Reset()
        {
            this.storeVector = null;
            this.storeX = null;
            this.storeY = null;
            this.storeZ = null;
            this.multiplier = 1f;
            this.everyFrame = false;
        }
    }
}


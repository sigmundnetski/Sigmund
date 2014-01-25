namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Device), Tooltip("Gets the rotation of the device around its z axis (into the screen). For example when you steer with the iPhone in a driving game.")]
    public class GetDeviceRoll : FsmStateAction
    {
        [Tooltip("How the user is expected to hold the device (where angle will be zero).")]
        public BaseOrientation baseOrientation;
        public bool everyFrame;
        private float lastZAngle;
        public FsmFloat limitAngle;
        public FsmFloat smoothing;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeAngle;

        private void DoGetDeviceRoll()
        {
            float x = Input.acceleration.x;
            float y = Input.acceleration.y;
            float b = 0f;
            switch (this.baseOrientation)
            {
                case BaseOrientation.Portrait:
                    b = -Mathf.Atan2(x, -y);
                    break;

                case BaseOrientation.LandscapeLeft:
                    b = Mathf.Atan2(y, -x);
                    break;

                case BaseOrientation.LandscapeRight:
                    b = -Mathf.Atan2(y, x);
                    break;
            }
            if (!this.limitAngle.IsNone)
            {
                b = Mathf.Clamp(57.29578f * b, -this.limitAngle.Value, this.limitAngle.Value);
            }
            if (this.smoothing.Value > 0f)
            {
                b = Mathf.LerpAngle(this.lastZAngle, b, this.smoothing.Value * Time.deltaTime);
            }
            this.lastZAngle = b;
            this.storeAngle.Value = b;
        }

        public override void OnEnter()
        {
            this.DoGetDeviceRoll();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetDeviceRoll();
        }

        public override void Reset()
        {
            this.baseOrientation = BaseOrientation.LandscapeLeft;
            this.storeAngle = null;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.limitAngle = num;
            this.smoothing = 5f;
            this.everyFrame = true;
        }

        public enum BaseOrientation
        {
            Portrait,
            LandscapeLeft,
            LandscapeRight
        }
    }
}


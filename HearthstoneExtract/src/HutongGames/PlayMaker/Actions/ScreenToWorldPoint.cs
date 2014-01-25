namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Transforms position from screen space into world space. NOTE: Uses the MainCamera!"), ActionCategory(ActionCategory.Camera)]
    public class ScreenToWorldPoint : FsmStateAction
    {
        [Tooltip("Repeat every frame")]
        public bool everyFrame;
        [Tooltip("If true, X/Y coordinates are considered normalized (0-1), otherwise they are expected to be in pixels")]
        public FsmBool normalized;
        [UIHint(UIHint.Variable), Tooltip("Screen position as a vector.")]
        public FsmVector3 screenVector;
        [Tooltip("Screen X position in pixels or normalized. See Normalized.")]
        public FsmFloat screenX;
        [Tooltip("Screen X position in pixels or normalized. See Normalized.")]
        public FsmFloat screenY;
        [Tooltip("Distance into the screen in world units.")]
        public FsmFloat screenZ;
        [Tooltip("Store the world position in a vector3 variable."), UIHint(UIHint.Variable)]
        public FsmVector3 storeWorldVector;
        [Tooltip("Store the world X position in a float variable."), UIHint(UIHint.Variable)]
        public FsmFloat storeWorldX;
        [UIHint(UIHint.Variable), Tooltip("Store the world Y position in a float variable.")]
        public FsmFloat storeWorldY;
        [UIHint(UIHint.Variable), Tooltip("Store the world Z position in a float variable.")]
        public FsmFloat storeWorldZ;

        private void DoScreenToWorldPoint()
        {
            if (Camera.main == null)
            {
                this.LogError("No MainCamera defined!");
                base.Finish();
            }
            else
            {
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
                if (!this.screenZ.IsNone)
                {
                    zero.z = this.screenZ.Value;
                }
                if (this.normalized.Value)
                {
                    zero.x *= Screen.width;
                    zero.y *= Screen.height;
                }
                zero = Camera.main.ScreenToWorldPoint(zero);
                this.storeWorldVector.Value = zero;
                this.storeWorldX.Value = zero.x;
                this.storeWorldY.Value = zero.y;
                this.storeWorldZ.Value = zero.z;
            }
        }

        public override void OnEnter()
        {
            this.DoScreenToWorldPoint();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoScreenToWorldPoint();
        }

        public override void Reset()
        {
            this.screenVector = null;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.screenX = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.screenY = num;
            this.screenZ = 1f;
            this.normalized = 0;
            this.storeWorldVector = null;
            this.storeWorldX = null;
            this.storeWorldY = null;
            this.storeWorldZ = null;
            this.everyFrame = false;
        }
    }
}


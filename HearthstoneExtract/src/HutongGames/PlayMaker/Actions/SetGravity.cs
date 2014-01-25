namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the gravity vector, or individual axis."), ActionCategory(ActionCategory.Physics)]
    public class SetGravity : FsmStateAction
    {
        public bool everyFrame;
        public FsmVector3 vector;
        public FsmFloat x;
        public FsmFloat y;
        public FsmFloat z;

        private void DoSetGravity()
        {
            Vector3 vector = this.vector.Value;
            if (!this.x.IsNone)
            {
                vector.x = this.x.Value;
            }
            if (!this.y.IsNone)
            {
                vector.y = this.y.Value;
            }
            if (!this.z.IsNone)
            {
                vector.z = this.z.Value;
            }
            Physics.gravity = vector;
        }

        public override void OnEnter()
        {
            this.DoSetGravity();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetGravity();
        }

        public override void Reset()
        {
            this.vector = null;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.x = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.y = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.z = num;
            this.everyFrame = false;
        }
    }
}


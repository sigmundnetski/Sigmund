namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Physics), Tooltip("Sets the Velocity of a Game Object. To leave any axis unchanged, set variable to 'None'. NOTE: Game object must have a rigidbody.")]
    public class SetVelocity : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField, CheckForComponent(typeof(Rigidbody))]
        public FsmOwnerDefault gameObject;
        public Space space;
        [UIHint(UIHint.Variable)]
        public FsmVector3 vector;
        public FsmFloat x;
        public FsmFloat y;
        public FsmFloat z;

        private void DoSetVelocity()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.rigidbody != null))
            {
                Vector3 vector;
                if (this.vector.IsNone)
                {
                    vector = (this.space != Space.World) ? ownerDefaultTarget.transform.InverseTransformDirection(ownerDefaultTarget.rigidbody.velocity) : ownerDefaultTarget.rigidbody.velocity;
                }
                else
                {
                    vector = this.vector.Value;
                }
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
                ownerDefaultTarget.rigidbody.velocity = (this.space != Space.World) ? ownerDefaultTarget.transform.TransformDirection(vector) : vector;
            }
        }

        public override void OnEnter()
        {
            this.DoSetVelocity();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnFixedUpdate()
        {
            this.DoSetVelocity();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
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
            this.space = Space.Self;
            this.everyFrame = false;
        }
    }
}


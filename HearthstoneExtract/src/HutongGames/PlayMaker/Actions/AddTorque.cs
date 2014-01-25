namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Adds torque (rotational force) to a Game Object."), ActionCategory(ActionCategory.Physics)]
    public class AddTorque : FsmStateAction
    {
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        [Tooltip("The type of force to apply. See Unity Physics docs.")]
        public ForceMode forceMode;
        [Tooltip("The GameObject to add torque to."), RequiredField, CheckForComponent(typeof(Rigidbody))]
        public FsmOwnerDefault gameObject;
        [Tooltip("Apply the force in world or local space.")]
        public Space space;
        [UIHint(UIHint.Variable), Tooltip("A Vector3 torque. Optionally override any axis with the X, Y, Z parameters.")]
        public FsmVector3 vector;
        [Tooltip("Torque around the X axis. To leave unchanged, set to 'None'.")]
        public FsmFloat x;
        [Tooltip("Torque around the Y axis. To leave unchanged, set to 'None'.")]
        public FsmFloat y;
        [Tooltip("Torque around the Z axis. To leave unchanged, set to 'None'.")]
        public FsmFloat z;

        private void DoAddTorque()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                if (ownerDefaultTarget.rigidbody == null)
                {
                    this.LogWarning("Missing rigid body: " + ownerDefaultTarget.name);
                }
                else
                {
                    Vector3 torque = !this.vector.IsNone ? this.vector.Value : new Vector3(this.x.Value, this.y.Value, this.z.Value);
                    if (!this.x.IsNone)
                    {
                        torque.x = this.x.Value;
                    }
                    if (!this.y.IsNone)
                    {
                        torque.y = this.y.Value;
                    }
                    if (!this.z.IsNone)
                    {
                        torque.z = this.z.Value;
                    }
                    if (this.space == Space.World)
                    {
                        ownerDefaultTarget.rigidbody.AddTorque(torque, this.forceMode);
                    }
                    else
                    {
                        ownerDefaultTarget.rigidbody.AddRelativeTorque(torque, this.forceMode);
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoAddTorque();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnFixedUpdate()
        {
            this.DoAddTorque();
        }

        public override void Reset()
        {
            this.gameObject = null;
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
            this.space = Space.World;
            this.forceMode = ForceMode.Force;
            this.everyFrame = false;
        }
    }
}


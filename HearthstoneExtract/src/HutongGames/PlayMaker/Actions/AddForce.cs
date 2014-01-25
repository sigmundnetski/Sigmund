namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Physics), Tooltip("Adds a force to a Game Object. Use Vector3 variable and/or Float variables for each axis.")]
    public class AddForce : FsmStateAction
    {
        [Tooltip("Optionally apply the force at a position on the object. This will also add some torque. The position is often returned from MousePick or GetCollisionInfo actions."), UIHint(UIHint.Variable)]
        public FsmVector3 atPosition;
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        [Tooltip("The type of force to apply. See Unity Physics docs.")]
        public ForceMode forceMode;
        [RequiredField, CheckForComponent(typeof(Rigidbody)), Tooltip("The GameObject to apply the force to.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Apply the force in world or local space.")]
        public Space space;
        [Tooltip("A Vector3 force to add. Optionally override any axis with the X, Y, Z parameters."), UIHint(UIHint.Variable)]
        public FsmVector3 vector;
        [Tooltip("Force along the X axis. To leave unchanged, set to 'None'.")]
        public FsmFloat x;
        [Tooltip("Force along the Y axis. To leave unchanged, set to 'None'.")]
        public FsmFloat y;
        [Tooltip("Force along the Z axis. To leave unchanged, set to 'None'.")]
        public FsmFloat z;

        private void DoAddForce()
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
                    Vector3 force = !this.vector.IsNone ? this.vector.Value : new Vector3(this.x.Value, this.y.Value, this.z.Value);
                    if (!this.x.IsNone)
                    {
                        force.x = this.x.Value;
                    }
                    if (!this.y.IsNone)
                    {
                        force.y = this.y.Value;
                    }
                    if (!this.z.IsNone)
                    {
                        force.z = this.z.Value;
                    }
                    if (this.space == Space.World)
                    {
                        if (!this.atPosition.IsNone)
                        {
                            ownerDefaultTarget.rigidbody.AddForceAtPosition(force, this.atPosition.Value);
                        }
                        else
                        {
                            ownerDefaultTarget.rigidbody.AddForce(force);
                        }
                    }
                    else
                    {
                        ownerDefaultTarget.rigidbody.AddRelativeForce(force);
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoAddForce();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnFixedUpdate()
        {
            this.DoAddForce();
        }

        public override void Reset()
        {
            this.gameObject = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.atPosition = vector;
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
            this.space = Space.World;
            this.forceMode = ForceMode.Force;
            this.everyFrame = false;
        }
    }
}


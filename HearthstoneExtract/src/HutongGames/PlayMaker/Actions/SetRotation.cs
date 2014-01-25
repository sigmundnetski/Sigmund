namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Transform), Tooltip("Sets the Rotation of a Game Object. To leave any axis unchanged, set variable to 'None'.")]
    public class SetRotation : FsmStateAction
    {
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        [RequiredField, Tooltip("The GameObject to rotate.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Perform in LateUpdate. This is useful if you want to override the position of objects that are animated or otherwise positioned in Update.")]
        public bool lateUpdate;
        [UIHint(UIHint.Variable), Tooltip("Use a stored quaternion, or vector angles below.")]
        public FsmQuaternion quaternion;
        [Tooltip("Use local or world space.")]
        public Space space;
        [Title("Euler Angles"), Tooltip("Use euler angles stored in a Vector3 variable, and/or set each axis below."), UIHint(UIHint.Variable)]
        public FsmVector3 vector;
        public FsmFloat xAngle;
        public FsmFloat yAngle;
        public FsmFloat zAngle;

        private void DoSetRotation()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Vector3 eulerAngles;
                if (!this.quaternion.IsNone)
                {
                    eulerAngles = this.quaternion.Value.eulerAngles;
                }
                else if (!this.vector.IsNone)
                {
                    eulerAngles = this.vector.Value;
                }
                else
                {
                    eulerAngles = (this.space != Space.Self) ? ownerDefaultTarget.transform.eulerAngles : ownerDefaultTarget.transform.localEulerAngles;
                }
                if (!this.xAngle.IsNone)
                {
                    eulerAngles.x = this.xAngle.Value;
                }
                if (!this.yAngle.IsNone)
                {
                    eulerAngles.y = this.yAngle.Value;
                }
                if (!this.zAngle.IsNone)
                {
                    eulerAngles.z = this.zAngle.Value;
                }
                if (this.space == Space.Self)
                {
                    ownerDefaultTarget.transform.localEulerAngles = eulerAngles;
                }
                else
                {
                    ownerDefaultTarget.transform.eulerAngles = eulerAngles;
                }
            }
        }

        public override void OnEnter()
        {
            if (!this.everyFrame && !this.lateUpdate)
            {
                this.DoSetRotation();
                base.Finish();
            }
        }

        public override void OnLateUpdate()
        {
            if (this.lateUpdate)
            {
                this.DoSetRotation();
            }
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            if (!this.lateUpdate)
            {
                this.DoSetRotation();
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.quaternion = null;
            this.vector = null;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.xAngle = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.yAngle = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.zAngle = num;
            this.space = Space.World;
            this.everyFrame = false;
            this.lateUpdate = false;
        }
    }
}


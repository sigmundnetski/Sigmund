namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Scale of a Game Object. To leave any axis unchanged, set variable to 'None'."), ActionCategory(ActionCategory.Transform)]
    public class SetScale : FsmStateAction
    {
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        [Tooltip("The GameObject to scale."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("Perform in LateUpdate. This is useful if you want to override the position of objects that are animated or otherwise positioned in Update.")]
        public bool lateUpdate;
        [UIHint(UIHint.Variable), Tooltip("Use stored Vector3 value, and/or set each axis below.")]
        public FsmVector3 vector;
        public FsmFloat x;
        public FsmFloat y;
        public FsmFloat z;

        private void DoSetScale()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Vector3 vector = !this.vector.IsNone ? this.vector.Value : ownerDefaultTarget.transform.localScale;
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
                ownerDefaultTarget.transform.localScale = vector;
            }
        }

        public override void OnEnter()
        {
            this.DoSetScale();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnLateUpdate()
        {
            if (this.lateUpdate)
            {
                this.DoSetScale();
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
                this.DoSetScale();
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
            this.everyFrame = false;
            this.lateUpdate = false;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Transform), Tooltip("Translates a Game Object. Use a Vector3 variable and/or XYZ components. To leave any axis unchanged, set variable to 'None'.")]
    public class Translate : FsmStateAction
    {
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        [Tooltip("Perform the translate in FixedUpdate. This is useful when working with rigid bodies and physics.")]
        public bool fixedUpdate;
        [RequiredField, Tooltip("The game object to translate.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Perform the translate in LateUpdate. This is useful if you want to override the position of objects that are animated or otherwise positioned in Update.")]
        public bool lateUpdate;
        [Tooltip("Translate over one second")]
        public bool perSecond;
        [Tooltip("Translate in local or world space.")]
        public Space space;
        [Tooltip("A translation vector. NOTE: You can override individual axis below."), UIHint(UIHint.Variable)]
        public FsmVector3 vector;
        [Tooltip("Translation along x axis.")]
        public FsmFloat x;
        [Tooltip("Translation along y axis.")]
        public FsmFloat y;
        [Tooltip("Translation along z axis.")]
        public FsmFloat z;

        private void DoTranslate()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Vector3 translation = !this.vector.IsNone ? this.vector.Value : new Vector3(this.x.Value, this.y.Value, this.z.Value);
                if (!this.x.IsNone)
                {
                    translation.x = this.x.Value;
                }
                if (!this.y.IsNone)
                {
                    translation.y = this.y.Value;
                }
                if (!this.z.IsNone)
                {
                    translation.z = this.z.Value;
                }
                if (!this.perSecond)
                {
                    ownerDefaultTarget.transform.Translate(translation, this.space);
                }
                else
                {
                    ownerDefaultTarget.transform.Translate((Vector3) (translation * Time.deltaTime), this.space);
                }
            }
        }

        public override void OnEnter()
        {
            if ((!this.everyFrame && !this.lateUpdate) && !this.fixedUpdate)
            {
                this.DoTranslate();
                base.Finish();
            }
        }

        public override void OnFixedUpdate()
        {
            if (this.fixedUpdate)
            {
                this.DoTranslate();
            }
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnLateUpdate()
        {
            if (this.lateUpdate)
            {
                this.DoTranslate();
            }
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            if (!this.lateUpdate && !this.fixedUpdate)
            {
                this.DoTranslate();
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
            this.perSecond = true;
            this.everyFrame = true;
            this.lateUpdate = false;
            this.fixedUpdate = false;
        }
    }
}


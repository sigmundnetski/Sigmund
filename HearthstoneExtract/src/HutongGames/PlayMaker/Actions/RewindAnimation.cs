namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Animation), Tooltip("Rewinds the named animation.")]
    public class RewindAnimation : FsmStateAction
    {
        [UIHint(UIHint.Animation)]
        public FsmString animName;
        [RequiredField, CheckForComponent(typeof(Animation))]
        public FsmOwnerDefault gameObject;

        private void DoRewindAnimation()
        {
            if (!string.IsNullOrEmpty(this.animName.Value))
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                if (ownerDefaultTarget != null)
                {
                    if (ownerDefaultTarget.animation == null)
                    {
                        this.LogWarning("Missing animation component: " + ownerDefaultTarget.name);
                    }
                    else
                    {
                        ownerDefaultTarget.animation.Rewind(this.animName.Value);
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoRewindAnimation();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.animName = null;
        }
    }
}


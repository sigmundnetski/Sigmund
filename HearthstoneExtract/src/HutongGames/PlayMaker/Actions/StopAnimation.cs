namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Stops all playing Animations on a Game Object. Optionally, specify a single Animation to Stop."), ActionCategory(ActionCategory.Animation)]
    public class StopAnimation : FsmStateAction
    {
        [UIHint(UIHint.Animation), Tooltip("Leave empty to stop all playing animations.")]
        public FsmString animName;
        [CheckForComponent(typeof(Animation)), RequiredField]
        public FsmOwnerDefault gameObject;

        private void DoStopAnimation()
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
                    ownerDefaultTarget.animation.Stop(this.animName.Value);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoStopAnimation();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.animName = null;
        }
    }
}


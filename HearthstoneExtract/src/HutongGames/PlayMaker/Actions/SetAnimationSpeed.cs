namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Speed of an Animation. Check Every Frame to update the animation time continuosly, e.g., if you're manipulating a variable that controls animation speed."), ActionCategory(ActionCategory.Animation)]
    public class SetAnimationSpeed : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Animation)]
        public FsmString animName;
        public bool everyFrame;
        [RequiredField, CheckForComponent(typeof(Animation))]
        public FsmOwnerDefault gameObject;
        public FsmFloat speed = 1f;

        private void DoSetAnimationSpeed(GameObject go)
        {
            if (go != null)
            {
                if (go.animation == null)
                {
                    this.LogWarning("Missing animation component: " + go.name);
                }
                else
                {
                    AnimationState state = go.animation[this.animName.Value];
                    if (state == null)
                    {
                        this.LogWarning("Missing animation: " + this.animName.Value);
                    }
                    else
                    {
                        state.speed = this.speed.Value;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetAnimationSpeed((this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner);
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetAnimationSpeed((this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner);
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.animName = null;
            this.speed = 1f;
            this.everyFrame = false;
        }
    }
}


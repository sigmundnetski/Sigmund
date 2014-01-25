namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Animation), Tooltip("Sets the Blend Weight of an Animation. Check Every Frame to update the weight continuosly, e.g., if you're manipulating a variable that controls the weight.")]
    public class SetAnimationWeight : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Animation)]
        public FsmString animName;
        public bool everyFrame;
        [RequiredField, CheckForComponent(typeof(Animation))]
        public FsmOwnerDefault gameObject;
        public FsmFloat weight = 1f;

        private void DoSetAnimationWeight(GameObject go)
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
                        state.weight = this.weight.Value;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetAnimationWeight((this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner);
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetAnimationWeight((this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner);
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.animName = null;
            this.weight = 1f;
            this.everyFrame = false;
        }
    }
}


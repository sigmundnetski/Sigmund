namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the current Time of an Animation, Normalize time means 0 (start) to 1 (end); useful if you don't care about the exact time. Check Every Frame to update the time continuosly."), ActionCategory(ActionCategory.Animation)]
    public class SetAnimationTime : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Animation)]
        public FsmString animName;
        public bool everyFrame;
        [CheckForComponent(typeof(Animation)), RequiredField]
        public FsmOwnerDefault gameObject;
        public bool normalized;
        public FsmFloat time;

        private void DoSetAnimationTime(GameObject go)
        {
            if (go != null)
            {
                if (go.animation == null)
                {
                    this.LogWarning("Missing animation component: " + go.name);
                }
                else
                {
                    go.animation.Play(this.animName.Value);
                    AnimationState state = go.animation[this.animName.Value];
                    if (state == null)
                    {
                        this.LogWarning("Missing animation: " + this.animName.Value);
                    }
                    else
                    {
                        if (this.normalized)
                        {
                            state.normalizedTime = this.time.Value;
                        }
                        else
                        {
                            state.time = this.time.Value;
                        }
                        if (this.everyFrame)
                        {
                            state.speed = 0f;
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetAnimationTime((this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner);
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetAnimationTime((this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner);
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.animName = null;
            this.time = null;
            this.normalized = false;
            this.everyFrame = false;
        }
    }
}


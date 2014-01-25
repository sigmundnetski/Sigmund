namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Animation), Tooltip("Blends an Animation towards a Target Weight over a specified Time.\nOptionally sends an Event when finished.")]
    public class BlendAnimation : FsmStateAction
    {
        [Tooltip("The name of the animation to blend."), RequiredField, UIHint(UIHint.Animation)]
        public FsmString animName;
        private DelayedEvent delayedFinishEvent;
        [Tooltip("Event to send when the blend has finished.")]
        public FsmEvent finishEvent;
        [RequiredField, CheckForComponent(typeof(Animation)), Tooltip("The GameObject to animate.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Target weight to blend to."), RequiredField, HasFloatSlider(0f, 1f)]
        public FsmFloat targetWeight;
        [RequiredField, HasFloatSlider(0f, 5f), Tooltip("How long should the blend take.")]
        public FsmFloat time;

        private void DoBlendAnimation(GameObject go)
        {
            if (go != null)
            {
                if (go.animation == null)
                {
                    this.LogWarning("Missing Animation component on GameObject: " + go.name);
                    base.Finish();
                }
                else
                {
                    AnimationState state = go.animation[this.animName.Value];
                    if (state == null)
                    {
                        this.LogWarning("Missing animation: " + this.animName.Value);
                        base.Finish();
                    }
                    else
                    {
                        float fadeLength = this.time.Value;
                        go.animation.Blend(this.animName.Value, this.targetWeight.Value, fadeLength);
                        if (this.finishEvent != null)
                        {
                            this.delayedFinishEvent = base.Fsm.DelayedEvent(this.finishEvent, state.length);
                        }
                        else
                        {
                            base.Finish();
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoBlendAnimation((this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner);
        }

        public override void OnUpdate()
        {
            if (DelayedEvent.WasSent(this.delayedFinishEvent))
            {
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.animName = null;
            this.targetWeight = 1f;
            this.time = 0.3f;
            this.finishEvent = null;
        }
    }
}


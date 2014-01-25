namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Plays a Random Animation on a Game Object. You can set the relative weight of each animation to control how often they are selected."), ActionCategory(ActionCategory.Animation)]
    public class PlayRandomAnimation : FsmStateAction
    {
        private AnimationState anim;
        [CompoundArray("Animations", "Animation", "Weight"), UIHint(UIHint.Animation)]
        public FsmString[] animations;
        [HasFloatSlider(0f, 5f), Tooltip("Time taken to blend to this animation.")]
        public FsmFloat blendTime;
        [Tooltip("Event to send when the animation is finished playing. NOTE: Not sent with Loop or PingPong wrap modes!")]
        public FsmEvent finishEvent;
        [RequiredField, CheckForComponent(typeof(Animation)), Tooltip("Game Object to play the animation on.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Event to send when the animation loops. If you want to send this event to another FSM use Set Event Target. NOTE: This event is only sent with Loop and PingPong wrap modes.")]
        public FsmEvent loopEvent;
        [Tooltip("How to treat previously playing animations.")]
        public PlayMode playMode;
        private float prevAnimtTime;
        [Tooltip("Stop playing the animation when this state is exited.")]
        public bool stopOnExit;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat[] weights;

        private void DoPlayAnimation(string animName)
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget == null) || string.IsNullOrEmpty(animName))
            {
                base.Finish();
            }
            else if (string.IsNullOrEmpty(animName))
            {
                this.LogWarning("Missing animName!");
                base.Finish();
            }
            else if (ownerDefaultTarget.animation == null)
            {
                this.LogWarning("Missing animation component!");
                base.Finish();
            }
            else
            {
                this.anim = ownerDefaultTarget.animation[animName];
                if (this.anim == null)
                {
                    this.LogWarning("Missing animation: " + animName);
                    base.Finish();
                }
                else
                {
                    float fadeLength = this.blendTime.Value;
                    if (fadeLength < 0.001f)
                    {
                        ownerDefaultTarget.animation.Play(animName, this.playMode);
                    }
                    else
                    {
                        ownerDefaultTarget.animation.CrossFade(animName, fadeLength, this.playMode);
                    }
                    this.prevAnimtTime = this.anim.time;
                }
            }
        }

        private void DoPlayRandomAnimation()
        {
            if (this.animations.Length > 0)
            {
                int randomWeightedIndex = ActionHelpers.GetRandomWeightedIndex(this.weights);
                if (randomWeightedIndex != -1)
                {
                    this.DoPlayAnimation(this.animations[randomWeightedIndex].Value);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoPlayRandomAnimation();
        }

        public override void OnExit()
        {
            if (this.stopOnExit)
            {
                this.StopAnimation();
            }
        }

        public override void OnUpdate()
        {
            if ((base.Fsm.GetOwnerDefaultTarget(this.gameObject) != null) && (this.anim != null))
            {
                if (!this.anim.enabled || ((this.anim.wrapMode == WrapMode.ClampForever) && (this.anim.time > this.anim.length)))
                {
                    base.Fsm.Event(this.finishEvent);
                    base.Finish();
                }
                if (((this.anim.wrapMode != WrapMode.ClampForever) && (this.anim.time > this.anim.length)) && (this.prevAnimtTime < this.anim.length))
                {
                    base.Fsm.Event(this.loopEvent);
                }
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.animations = new FsmString[0];
            this.weights = new FsmFloat[0];
            this.playMode = PlayMode.StopAll;
            this.blendTime = 0.3f;
            this.finishEvent = null;
            this.loopEvent = null;
            this.stopOnExit = false;
        }

        private void StopAnimation()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.animation != null))
            {
                ownerDefaultTarget.animation.Stop(this.anim.name);
            }
        }
    }
}


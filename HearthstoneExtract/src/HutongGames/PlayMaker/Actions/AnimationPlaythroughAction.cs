namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Plays an Animation on a Game Object. Does not wait for the animation to finish."), ActionCategory(ActionCategory.Animation)]
    public class AnimationPlaythroughAction : FsmStateAction
    {
        [Tooltip("The name of the animation to play."), UIHint(UIHint.Animation)]
        public FsmString m_AnimName;
        [HasFloatSlider(0f, 5f), Tooltip("Time taken to cross fade to this animation.")]
        public FsmFloat m_CrossFadeSec;
        [RequiredField, CheckForComponent(typeof(Animation)), Tooltip("Game Object to play the animation on.")]
        public FsmOwnerDefault m_GameObject;
        [Tooltip("How to treat previously playing animations.")]
        public PlayMode m_PlayMode;

        public override void OnEnter()
        {
            this.StartAnimation();
            base.Finish();
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_AnimName = null;
            this.m_PlayMode = PlayMode.StopAll;
            this.m_CrossFadeSec = 0.3f;
        }

        private void StartAnimation()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                if (string.IsNullOrEmpty(this.m_AnimName.Value))
                {
                    Debug.LogWarning(string.Format("AnimationPlaythroughAction.OnEnter() - GameObject {0} has an animation action with no animation name", ownerDefaultTarget));
                }
                else if (ownerDefaultTarget.animation == null)
                {
                    Debug.LogWarning(string.Format("AnimationPlaythroughAction.OnEnter() - GameObject {0} is missing an animation component", ownerDefaultTarget));
                }
                else
                {
                    AnimationState state = ownerDefaultTarget.animation[this.m_AnimName.Value];
                    if (state == null)
                    {
                        Debug.LogWarning(string.Format("AnimationPlaythroughAction.OnEnter() - GameObject {0} is missing animation {1}", ownerDefaultTarget, this.m_AnimName.Value));
                    }
                    else
                    {
                        float fadeLength = this.m_CrossFadeSec.Value;
                        if (fadeLength <= float.Epsilon)
                        {
                            ownerDefaultTarget.animation.Play(this.m_AnimName.Value, this.m_PlayMode);
                        }
                        else
                        {
                            ownerDefaultTarget.animation.CrossFade(this.m_AnimName.Value, fadeLength, this.m_PlayMode);
                        }
                    }
                }
            }
        }
    }
}


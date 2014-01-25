namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Adds a named Animation Clip to a Game Object. Optionally trims the Animation."), ActionCategory(ActionCategory.Animation)]
    public class AddAnimationClip : FsmStateAction
    {
        [Tooltip("Add an extra looping frame that matches the first frame.")]
        public FsmBool addLoopFrame;
        [RequiredField, ObjectType(typeof(AnimationClip)), Tooltip("The animation clip to add. NOTE: Make sure the clip is compatible with the object's hierarchy.")]
        public FsmObject animationClip;
        [Tooltip("Name the animation. Used by other actions to reference this animation."), RequiredField]
        public FsmString animationName;
        [Tooltip("Optionally trim the animation by specifying a first and last frame.")]
        public FsmInt firstFrame;
        [RequiredField, CheckForComponent(typeof(Animation)), Tooltip("The GameObject to add the Animation Clip to.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Optionally trim the animation by specifying a first and last frame.")]
        public FsmInt lastFrame;

        private void DoAddAnimationClip()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.animation != null))
            {
                AnimationClip clip = this.animationClip.Value as AnimationClip;
                if (clip != null)
                {
                    if ((this.firstFrame.Value == 0) && (this.lastFrame.Value == 0))
                    {
                        ownerDefaultTarget.animation.AddClip(clip, this.animationName.Value);
                    }
                    else
                    {
                        ownerDefaultTarget.animation.AddClip(clip, this.animationName.Value, this.firstFrame.Value, this.lastFrame.Value, this.addLoopFrame.Value);
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoAddAnimationClip();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.animationClip = null;
            this.animationName = string.Empty;
            this.firstFrame = 0;
            this.lastFrame = 0;
            this.addLoopFrame = 0;
        }
    }
}


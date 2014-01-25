namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Animation), Tooltip("Play an animation on a subset of the hierarchy. E.g., A waving animation on the upper body.")]
    public class AddMixingTransform : FsmStateAction
    {
        [Tooltip("The name of the animation to mix. NOTE: The animation should already be added to the Animation Component on the GameObject."), RequiredField]
        public FsmString animationName;
        [RequiredField, CheckForComponent(typeof(Animation)), Tooltip("The GameObject playing the animation.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("If recursive is true all children of the mix transform will also be animated.")]
        public FsmBool recursive;
        [Tooltip("The mixing transform. E.g., root/upper_body/left_shoulder"), RequiredField]
        public FsmString transform;

        private void DoAddMixingTransform()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.animation != null))
            {
                AnimationState state = ownerDefaultTarget.animation[this.animationName.Value];
                if (state != null)
                {
                    Transform mix = ownerDefaultTarget.transform.Find(this.transform.Value);
                    state.AddMixingTransform(mix, this.recursive.Value);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoAddMixingTransform();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.animationName = string.Empty;
            this.transform = string.Empty;
            this.recursive = 1;
        }
    }
}


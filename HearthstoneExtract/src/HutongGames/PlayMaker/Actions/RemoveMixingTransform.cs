namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Removes a mixing transform previously added with Add Mixing Transform. If transform has been added as recursive, then it will be removed as recursive. Once you remove all mixing transforms added to animation state all curves become animated again."), ActionCategory(ActionCategory.Animation)]
    public class RemoveMixingTransform : FsmStateAction
    {
        [Tooltip("The name of the animation."), RequiredField]
        public FsmString animationName;
        [Tooltip("The GameObject playing the animation."), RequiredField, CheckForComponent(typeof(Animation))]
        public FsmOwnerDefault gameObject;
        [Tooltip("The mixing transform to remove. E.g., root/upper_body/left_shoulder"), RequiredField]
        public FsmString transfrom;

        private void DoRemoveMixingTransform()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.animation != null))
            {
                AnimationState state = ownerDefaultTarget.animation[this.animationName.Value];
                if (state != null)
                {
                    Transform mix = ownerDefaultTarget.transform.Find(this.transfrom.Value);
                    state.AddMixingTransform(mix);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoRemoveMixingTransform();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.animationName = string.Empty;
        }
    }
}


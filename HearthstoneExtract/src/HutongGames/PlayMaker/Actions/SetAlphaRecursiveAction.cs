namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the alpha on a game object and its children."), ActionCategory("Pegasus")]
    public class SetAlphaRecursiveAction : FsmStateAction
    {
        [HasFloatSlider(0f, 1f)]
        public FsmFloat m_Alpha;
        public bool m_EveryFrame;
        public FsmOwnerDefault m_GameObject;
        public bool m_IncludeChildren;

        public override void OnEnter()
        {
            if (base.Fsm.GetOwnerDefaultTarget(this.m_GameObject) == null)
            {
                base.Finish();
            }
            else
            {
                this.UpdateAlpha();
                if (!this.m_EveryFrame)
                {
                    base.Finish();
                }
            }
        }

        public override void OnUpdate()
        {
            this.UpdateAlpha();
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_Alpha = 0f;
            this.m_EveryFrame = false;
            this.m_IncludeChildren = false;
        }

        private void UpdateAlpha()
        {
            if (!this.m_Alpha.IsNone)
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
                if (ownerDefaultTarget != null)
                {
                    RenderUtils.SetAlpha(ownerDefaultTarget, this.m_Alpha.Value);
                }
            }
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Gets the global time scale into a variable.")]
    public class GetTimeScaleAction : FsmStateAction
    {
        public bool m_EveryFrame;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmFloat m_Scale;

        public override void OnEnter()
        {
            this.UpdateScale();
            if (!this.m_EveryFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.UpdateScale();
        }

        public override void Reset()
        {
            this.m_Scale = null;
            this.m_EveryFrame = false;
        }

        private void UpdateScale()
        {
            if (!this.m_Scale.IsNone)
            {
                this.m_Scale.Value = Time.timeScale;
            }
        }
    }
}


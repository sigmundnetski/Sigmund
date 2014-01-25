namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the global time scale."), ActionCategory("Pegasus")]
    public class SetTimeScaleAction : FsmStateAction
    {
        public bool m_EveryFrame;
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
            this.m_Scale = 1f;
            this.m_EveryFrame = false;
        }

        private void UpdateScale()
        {
            if (!this.m_Scale.IsNone)
            {
                Time.timeScale = this.m_Scale.Value;
            }
        }
    }
}


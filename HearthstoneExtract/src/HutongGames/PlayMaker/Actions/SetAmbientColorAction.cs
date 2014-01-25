namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Set scene ambient color"), ActionCategory("Pegasus")]
    public class SetAmbientColorAction : FsmStateAction
    {
        public FsmColor m_Color;
        public bool m_EveryFrame;

        public override void OnEnter()
        {
            RenderSettings.ambientLight = this.m_Color.Value;
            if (!this.m_EveryFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            RenderSettings.ambientLight = this.m_Color.Value;
        }

        public override void Reset()
        {
            this.m_Color = null;
            this.m_EveryFrame = false;
        }
    }
}


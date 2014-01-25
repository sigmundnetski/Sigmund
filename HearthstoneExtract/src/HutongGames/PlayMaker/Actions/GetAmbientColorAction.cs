namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Get scene ambient color")]
    public class GetAmbientColorAction : FsmStateAction
    {
        public FsmColor m_Color;
        public bool m_EveryFrame;

        public override void OnEnter()
        {
            this.m_Color.Value = RenderSettings.ambientLight;
            if (!this.m_EveryFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.m_Color.Value = RenderSettings.ambientLight;
        }

        public override void Reset()
        {
            this.m_Color = Color.white;
            this.m_EveryFrame = false;
        }
    }
}


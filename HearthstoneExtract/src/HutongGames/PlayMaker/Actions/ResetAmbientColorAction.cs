namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Set scene ambient color")]
    public class ResetAmbientColorAction : FsmStateAction
    {
        private SetRenderSettings m_renderSettings;

        public override void OnEnter()
        {
            Board board = Board.Get();
            if (board != null)
            {
                this.m_renderSettings = board.gameObject.GetComponent<SetRenderSettings>();
                if (this.m_renderSettings != null)
                {
                    RenderSettings.ambientLight = this.m_renderSettings.m_ambient;
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
        }
    }
}


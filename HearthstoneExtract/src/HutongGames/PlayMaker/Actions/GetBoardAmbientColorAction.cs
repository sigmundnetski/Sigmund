namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Get scene ambient color")]
    public class GetBoardAmbientColorAction : FsmStateAction
    {
        public FsmColor m_Color;

        public override void OnEnter()
        {
            this.m_Color.Value = RenderSettings.ambientLight;
            Board board = Board.Get();
            if (board != null)
            {
                SetRenderSettings component = board.gameObject.GetComponent<SetRenderSettings>();
                if (component != null)
                {
                    this.m_Color.Value = component.m_ambient;
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.m_Color = Color.white;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Used to control the state of the Pegasus Highlight system"), ActionCategory("Pegasus")]
    public class HighlightStateAction : FsmStateAction
    {
        private DelayedEvent delayedEvent;
        [Tooltip("GameObject to send highlight states to"), RequiredField]
        public FsmOwnerDefault m_gameObj;
        [RequiredField, Tooltip("State to send")]
        public ActorStateType m_state = ActorStateType.HIGHLIGHT_OFF;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_gameObj);
            if (ownerDefaultTarget == null)
            {
                base.Finish();
            }
            else
            {
                HighlightState[] componentsInChildren = ownerDefaultTarget.GetComponentsInChildren<HighlightState>();
                if (componentsInChildren == null)
                {
                    base.Finish();
                }
                else
                {
                    foreach (HighlightState state in componentsInChildren)
                    {
                        state.ChangeState(this.m_state);
                    }
                    base.Finish();
                }
            }
        }

        public override void Reset()
        {
            this.m_gameObj = null;
            this.m_state = ActorStateType.HIGHLIGHT_OFF;
        }
    }
}


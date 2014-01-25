namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Note("Stop this FSM. If this FSM was launched by a Run FSM action, it will trigger a Finish event in that state."), Tooltip("Stop this FSM. If this FSM was launched by a Run FSM action, it will trigger a Finish event in that state."), ActionCategory(ActionCategory.StateMachine)]
    public class FinishFSM : FsmStateAction
    {
        public override void OnEnter()
        {
            base.Fsm.Stop();
        }
    }
}


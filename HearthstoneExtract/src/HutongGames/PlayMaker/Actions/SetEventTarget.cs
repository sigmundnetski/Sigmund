namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Sets the target FSM for all subsequent events sent by this state. The default 'Self' sends events to this FSM.")]
    public class SetEventTarget : FsmStateAction
    {
        public FsmEventTarget eventTarget;

        public override void OnEnter()
        {
            base.Fsm.EventTarget = this.eventTarget;
            base.Finish();
        }

        public override void Reset()
        {
        }
    }
}


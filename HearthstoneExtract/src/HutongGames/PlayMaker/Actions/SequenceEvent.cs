namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Sends the next event on the state each time the state is entered.")]
    public class SequenceEvent : FsmStateAction
    {
        [HasFloatSlider(0f, 10f)]
        public FsmFloat delay;
        private DelayedEvent delayedEvent;
        private int eventIndex;

        public override void OnEnter()
        {
            int length = base.State.Transitions.Length;
            if (length > 0)
            {
                FsmEvent fsmEvent = base.State.Transitions[this.eventIndex].FsmEvent;
                if (this.delay.Value < 0.001f)
                {
                    base.Fsm.Event(fsmEvent);
                    base.Finish();
                }
                else
                {
                    this.delayedEvent = base.Fsm.DelayedEvent(fsmEvent, this.delay.Value);
                }
                this.eventIndex++;
                if (this.eventIndex == length)
                {
                    this.eventIndex = 0;
                }
            }
        }

        public override void OnUpdate()
        {
            if (DelayedEvent.WasSent(this.delayedEvent))
            {
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.delay = null;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Forward an event recieved by this FSM to another target."), ActionCategory(ActionCategory.StateMachine)]
    public class ForwardEvent : FsmStateAction
    {
        [Tooltip("Should this action eat the events or pass them on.")]
        public bool eatEvents;
        [Tooltip("The events to forward.")]
        public FsmEvent[] eventsToForward;
        [Tooltip("Forward to this target.")]
        public FsmEventTarget forwardTo;

        public override bool Event(FsmEvent fsmEvent)
        {
            if (this.eventsToForward != null)
            {
                foreach (FsmEvent event2 in this.eventsToForward)
                {
                    if (event2 == fsmEvent)
                    {
                        base.Fsm.Event(this.forwardTo, fsmEvent);
                        return this.eatEvents;
                    }
                }
            }
            return false;
        }

        public override void Reset()
        {
            FsmEventTarget target = new FsmEventTarget {
                target = FsmEventTarget.EventTarget.FSMComponent
            };
            this.forwardTo = target;
            this.eventsToForward = null;
            this.eatEvents = true;
        }
    }
}


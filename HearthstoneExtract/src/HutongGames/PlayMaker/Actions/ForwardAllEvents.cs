namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Forwards all event recieved by this FSM to another target. Optionally specify a list of events to ignore."), ActionCategory(ActionCategory.StateMachine)]
    public class ForwardAllEvents : FsmStateAction
    {
        [Tooltip("Should this action eat the events or pass them on.")]
        public bool eatEvents;
        [Tooltip("Don't forward these events.")]
        public FsmEvent[] exceptThese;
        [Tooltip("Forward to this target.")]
        public FsmEventTarget forwardTo;

        public override bool Event(FsmEvent fsmEvent)
        {
            if (this.exceptThese != null)
            {
                foreach (FsmEvent event2 in this.exceptThese)
                {
                    if (event2 == fsmEvent)
                    {
                        return false;
                    }
                }
            }
            base.Fsm.Event(this.forwardTo, fsmEvent);
            return this.eatEvents;
        }

        public override void Reset()
        {
            FsmEventTarget target = new FsmEventTarget {
                target = FsmEventTarget.EventTarget.FSMComponent
            };
            this.forwardTo = target;
            this.exceptThese = new FsmEvent[] { FsmEvent.Finished };
            this.eatEvents = true;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Sends a Random Event picked from an array of Events. Optionally set the relative weight of each event."), ActionCategory(ActionCategory.StateMachine)]
    public class SendRandomEvent : FsmStateAction
    {
        public FsmFloat delay;
        private DelayedEvent delayedEvent;
        [CompoundArray("Events", "Event", "Weight")]
        public FsmEvent[] events;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat[] weights;

        public override void OnEnter()
        {
            if (this.events.Length > 0)
            {
                int randomWeightedIndex = ActionHelpers.GetRandomWeightedIndex(this.weights);
                if (randomWeightedIndex != -1)
                {
                    if (this.delay.Value < 0.001f)
                    {
                        base.Fsm.Event(this.events[randomWeightedIndex]);
                        base.Finish();
                    }
                    else
                    {
                        this.delayedEvent = base.Fsm.DelayedEvent(this.events[randomWeightedIndex], this.delay.Value);
                    }
                    return;
                }
            }
            base.Finish();
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
            this.events = new FsmEvent[3];
            this.weights = new FsmFloat[] { 1f, 1f, 1f };
            this.delay = null;
        }
    }
}


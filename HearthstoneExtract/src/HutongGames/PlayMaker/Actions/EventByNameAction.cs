namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Trigger Event by name after an optional delay. NOTE: Use this over Send Event if you store events as string variables."), ActionCategory(ActionCategory.StateMachine)]
    public class EventByNameAction : FsmStateAction
    {
        [Tooltip("Optional delay in seconds."), HasFloatSlider(0f, 10f)]
        public FsmFloat delay;
        private DelayedEvent delayedEvent;
        [Tooltip("Repeat every frame. Rarely needed.")]
        public bool everyFrame;
        [RequiredField, Tooltip("The event to send if the send event is not found. NOTE: Events must be marked Global to send between FSMs.")]
        public FsmString fallbackEvent;
        [RequiredField, Tooltip("The event to send. NOTE: Events must be marked Global to send between FSMs.")]
        public FsmString sendEvent;

        public override void OnEnter()
        {
            string fsmEventName = "FINISHED";
            if (this.fallbackEvent != null)
            {
                fsmEventName = this.fallbackEvent.Value;
            }
            FsmState state = base.State;
            if (state != null)
            {
                foreach (FsmTransition transition in state.Transitions)
                {
                    if (transition.EventName == this.sendEvent.Value)
                    {
                        fsmEventName = this.sendEvent.Value;
                    }
                }
            }
            if (this.delay.Value < 0.001f)
            {
                base.Fsm.Event(fsmEventName);
                base.Finish();
            }
            else
            {
                this.delayedEvent = base.Fsm.DelayedEvent(FsmEvent.GetFsmEvent(fsmEventName), this.delay.Value);
            }
        }

        public override void OnUpdate()
        {
            if (!this.everyFrame && DelayedEvent.WasSent(this.delayedEvent))
            {
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.sendEvent = null;
            this.delay = null;
            this.fallbackEvent = null;
            this.everyFrame = false;
        }
    }
}


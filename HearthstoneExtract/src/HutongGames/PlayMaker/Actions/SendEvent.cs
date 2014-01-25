namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Sends an Event after an optional delay. NOTE: To send events between FSMs they must be marked as Global in the Events Browser.")]
    public class SendEvent : FsmStateAction
    {
        [HasFloatSlider(0f, 10f), Tooltip("Optional delay in seconds.")]
        public FsmFloat delay;
        private DelayedEvent delayedEvent;
        [Tooltip("Where to send the event.")]
        public FsmEventTarget eventTarget;
        [Tooltip("Repeat every frame. Rarely needed.")]
        public bool everyFrame;
        [Tooltip("The event to send. NOTE: Events must be marked Global to send between FSMs."), RequiredField]
        public FsmEvent sendEvent;

        public override void OnEnter()
        {
            if (this.delay.Value < 0.001f)
            {
                base.Fsm.Event(this.eventTarget, this.sendEvent);
                base.Finish();
            }
            else
            {
                this.delayedEvent = base.Fsm.DelayedEvent(this.eventTarget, this.sendEvent, this.delay.Value);
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
            this.eventTarget = null;
            this.sendEvent = null;
            this.delay = null;
            this.everyFrame = false;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Sends an Event by name after an optional delay. NOTE: Use this over Send Event if you store events as string variables."), ActionCategory(ActionCategory.StateMachine)]
    public class SendEventByName : FsmStateAction
    {
        [Tooltip("Optional delay in seconds."), HasFloatSlider(0f, 10f)]
        public FsmFloat delay;
        private DelayedEvent delayedEvent;
        [Tooltip("Where to send the event.")]
        public FsmEventTarget eventTarget;
        [Tooltip("Repeat every frame. Rarely needed.")]
        public bool everyFrame;
        [RequiredField, Tooltip("The event to send. NOTE: Events must be marked Global to send between FSMs.")]
        public FsmString sendEvent;

        public override void OnEnter()
        {
            if (this.delay.Value < 0.001f)
            {
                base.Fsm.Event(this.eventTarget, this.sendEvent.Value);
                base.Finish();
            }
            else
            {
                this.delayedEvent = base.Fsm.DelayedEvent(this.eventTarget, FsmEvent.GetFsmEvent(this.sendEvent.Value), this.delay.Value);
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


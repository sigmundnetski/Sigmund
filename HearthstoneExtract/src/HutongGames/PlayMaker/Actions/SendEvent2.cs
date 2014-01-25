namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sends an Event after an optional delay. NOTE: To send events between FSMs they must be marked as Global in the Events Browser."), ActionCategory(ActionCategory.StateMachine)]
    public class SendEvent2 : FsmStateAction
    {
        [HasFloatSlider(0f, 10f)]
        public FsmFloat delay;
        private DelayedEvent delayedEvent;
        public FsmEventTarget eventTarget;
        [RequiredField]
        public FsmString sendEvent;

        public override void OnEnter()
        {
            if (this.delay.Value == 0f)
            {
                Debug.Log("sendEvent.Value " + this.sendEvent.Value);
                base.Fsm.Event(this.eventTarget, this.sendEvent.Value);
                base.Finish();
            }
            else
            {
                this.delayedEvent = new DelayedEvent(base.Fsm, this.eventTarget, this.sendEvent.Value, this.delay.Value);
            }
        }

        public override void OnUpdate()
        {
            this.delayedEvent.Update();
            if (this.delayedEvent.Finished)
            {
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.sendEvent = null;
            this.delay = null;
        }
    }
}


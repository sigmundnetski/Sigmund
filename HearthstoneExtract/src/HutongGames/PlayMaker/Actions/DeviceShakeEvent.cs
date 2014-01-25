namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Device), Tooltip("Sends an Event when the mobile device is shaken.")]
    public class DeviceShakeEvent : FsmStateAction
    {
        [Tooltip("Event to send when Shake Threshold is exceded."), RequiredField]
        public FsmEvent sendEvent;
        [RequiredField, Tooltip("Amount of acceleration required to trigger the event. Higher numbers require a harder shake.")]
        public FsmFloat shakeThreshold;

        public override void OnUpdate()
        {
            if (Input.acceleration.sqrMagnitude > (this.shakeThreshold.Value * this.shakeThreshold.Value))
            {
                base.Fsm.Event(this.sendEvent);
            }
        }

        public override void Reset()
        {
            this.shakeThreshold = 3f;
            this.sendEvent = null;
        }
    }
}


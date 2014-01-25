namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Device), Tooltip("Sends an Event based on the Orientation of the mobile device.")]
    public class DeviceOrientationEvent : FsmStateAction
    {
        [Tooltip("Repeat every frame. Useful if you want to wait for the orientation to be true.")]
        public bool everyFrame;
        [Tooltip("Note: If device is physically situated between discrete positions, as when (for example) rotated diagonally, system will report Unknown orientation.")]
        public DeviceOrientation orientation;
        [Tooltip("The event to send if the device orientation matches Orientation.")]
        public FsmEvent sendEvent;

        private void DoDetectDeviceOrientation()
        {
            if (Input.deviceOrientation == this.orientation)
            {
                base.Fsm.Event(this.sendEvent);
            }
        }

        public override void OnEnter()
        {
            this.DoDetectDeviceOrientation();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoDetectDeviceOrientation();
        }

        public override void Reset()
        {
            this.orientation = DeviceOrientation.Portrait;
            this.sendEvent = null;
            this.everyFrame = false;
        }
    }
}


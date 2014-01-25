namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Starts location service updates. Last location coordinates can be retrieved with GetLocationInfo."), ActionCategory(ActionCategory.Device)]
    public class StartLocationServiceUpdates : FsmStateAction
    {
        public FsmFloat desiredAccuracy;
        [Tooltip("Event to send if the location services fail to start.")]
        public FsmEvent failedEvent;
        [Tooltip("Maximum time to wait in seconds before failing.")]
        public FsmFloat maxWait;
        [Tooltip("Event to send when the location services have started.")]
        public FsmEvent successEvent;
        public FsmFloat updateDistance;

        public override void OnEnter()
        {
            base.Finish();
        }

        public override void OnUpdate()
        {
        }

        public override void Reset()
        {
            this.maxWait = 20f;
            this.desiredAccuracy = 10f;
            this.updateDistance = 10f;
            this.successEvent = null;
            this.failedEvent = null;
        }
    }
}


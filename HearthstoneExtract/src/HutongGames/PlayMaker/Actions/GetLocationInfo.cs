namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Gets Location Info from a mobile device. NOTE: Use StartLocationService before trying to get location info."), ActionCategory(ActionCategory.Device)]
    public class GetLocationInfo : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        public FsmFloat altitude;
        [Tooltip("Event to send if the location cannot be queried.")]
        public FsmEvent errorEvent;
        [UIHint(UIHint.Variable)]
        public FsmFloat horizontalAccuracy;
        [UIHint(UIHint.Variable)]
        public FsmFloat latitude;
        [UIHint(UIHint.Variable)]
        public FsmFloat longitude;
        [UIHint(UIHint.Variable)]
        public FsmVector3 vectorPosition;
        [UIHint(UIHint.Variable)]
        public FsmFloat verticalAccuracy;

        private void DoGetLocationInfo()
        {
        }

        public override void OnEnter()
        {
            this.DoGetLocationInfo();
            base.Finish();
        }

        public override void Reset()
        {
            this.longitude = null;
            this.latitude = null;
            this.altitude = null;
            this.horizontalAccuracy = null;
            this.verticalAccuracy = null;
            this.errorEvent = null;
        }
    }
}


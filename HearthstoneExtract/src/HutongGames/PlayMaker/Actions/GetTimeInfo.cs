namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets various useful Time measurements."), ActionCategory(ActionCategory.Time)]
    public class GetTimeInfo : FsmStateAction
    {
        public bool everyFrame;
        public TimeInfo getInfo;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmFloat storeValue;

        private void DoGetTimeInfo()
        {
            switch (this.getInfo)
            {
                case TimeInfo.DeltaTime:
                    this.storeValue.Value = Time.deltaTime;
                    break;

                case TimeInfo.TimeScale:
                    this.storeValue.Value = Time.timeScale;
                    break;

                case TimeInfo.SmoothDeltaTime:
                    this.storeValue.Value = Time.smoothDeltaTime;
                    break;

                case TimeInfo.TimeInCurrentState:
                    this.storeValue.Value = base.State.StateTime;
                    break;

                case TimeInfo.TimeSinceStartup:
                    this.storeValue.Value = Time.time;
                    break;

                case TimeInfo.TimeSinceLevelLoad:
                    this.storeValue.Value = Time.timeSinceLevelLoad;
                    break;

                case TimeInfo.RealTimeSinceStartup:
                    this.storeValue.Value = FsmTime.RealtimeSinceStartup;
                    break;

                case TimeInfo.RealTimeInCurrentState:
                    this.storeValue.Value = FsmTime.RealtimeSinceStartup - base.State.RealStartTime;
                    break;

                default:
                    this.storeValue.Value = 0f;
                    break;
            }
        }

        public override void OnEnter()
        {
            this.DoGetTimeInfo();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetTimeInfo();
        }

        public override void Reset()
        {
            this.getInfo = TimeInfo.TimeSinceLevelLoad;
            this.storeValue = null;
            this.everyFrame = false;
        }

        public enum TimeInfo
        {
            DeltaTime,
            TimeScale,
            SmoothDeltaTime,
            TimeInCurrentState,
            TimeSinceStartup,
            TimeSinceLevelLoad,
            RealTimeSinceStartup,
            RealTimeInCurrentState
        }
    }
}


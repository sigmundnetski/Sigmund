namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Interpolates between 2 Float values over a specified Time."), ActionCategory(ActionCategory.Math)]
    public class FloatInterpolate : FsmStateAction
    {
        private float currentTime;
        [Tooltip("Event to send when the interpolation is finished.")]
        public FsmEvent finishEvent;
        [Tooltip("Interpolate from this value."), RequiredField]
        public FsmFloat fromFloat;
        [Tooltip("Interpolation mode: Linear or EaseInOut.")]
        public InterpolationType mode;
        [Tooltip("Ignore TimeScale. Useful if the game is paused (Time scaled to 0).")]
        public bool realTime;
        private float startTime;
        [RequiredField, Tooltip("Store the current value in a float variable."), UIHint(UIHint.Variable)]
        public FsmFloat storeResult;
        [Tooltip("Interpolate over this amount of time in seconds."), RequiredField]
        public FsmFloat time;
        [Tooltip("Interpolate to this value."), RequiredField]
        public FsmFloat toFloat;

        public override void OnEnter()
        {
            this.startTime = FsmTime.RealtimeSinceStartup;
            this.currentTime = 0f;
            if (this.storeResult == null)
            {
                base.Finish();
            }
            else
            {
                this.storeResult.Value = this.fromFloat.Value;
            }
        }

        public override void OnUpdate()
        {
            if (this.realTime)
            {
                this.currentTime = FsmTime.RealtimeSinceStartup - this.startTime;
            }
            else
            {
                this.currentTime += Time.deltaTime;
            }
            float t = this.currentTime / this.time.Value;
            switch (this.mode)
            {
                case InterpolationType.Linear:
                    this.storeResult.Value = Mathf.Lerp(this.fromFloat.Value, this.toFloat.Value, t);
                    break;

                case InterpolationType.EaseInOut:
                    this.storeResult.Value = Mathf.SmoothStep(this.fromFloat.Value, this.toFloat.Value, t);
                    goto Label_00B8;
            }
        Label_00B8:
            if (t > 1f)
            {
                if (this.finishEvent != null)
                {
                    base.Fsm.Event(this.finishEvent);
                }
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.mode = InterpolationType.Linear;
            this.fromFloat = null;
            this.toFloat = null;
            this.time = 1f;
            this.storeResult = null;
            this.finishEvent = null;
            this.realTime = false;
        }
    }
}


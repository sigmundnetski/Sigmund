namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Vector3), Tooltip("Interpolates between 2 Vector3 values over a specified Time.")]
    public class Vector3Interpolate : FsmStateAction
    {
        private float currentTime;
        public FsmEvent finishEvent;
        [RequiredField]
        public FsmVector3 fromVector;
        public InterpolationType mode;
        [Tooltip("Ignore TimeScale")]
        public bool realTime;
        private float startTime;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmVector3 storeResult;
        [RequiredField]
        public FsmFloat time;
        [RequiredField]
        public FsmVector3 toVector;

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
                this.storeResult.Value = this.fromVector.Value;
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
            InterpolationType mode = this.mode;
            if ((mode != InterpolationType.Linear) && (mode == InterpolationType.EaseInOut))
            {
                t = Mathf.SmoothStep(0f, 1f, t);
            }
            this.storeResult.Value = Vector3.Lerp(this.fromVector.Value, this.toVector.Value, t);
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
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.fromVector = vector;
            vector = new FsmVector3 {
                UseVariable = true
            };
            this.toVector = vector;
            this.time = 1f;
            this.storeResult = null;
            this.finishEvent = null;
            this.realTime = false;
        }
    }
}


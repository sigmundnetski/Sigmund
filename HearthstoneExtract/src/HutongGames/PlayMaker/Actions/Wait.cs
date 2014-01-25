namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Time), Tooltip("Delays a State from finishing by the specified time. NOTE: Other actions continue, but FINISHED can't happen before Time.")]
    public class Wait : FsmStateAction
    {
        public FsmEvent finishEvent;
        public bool realTime;
        private float startTime;
        [RequiredField]
        public FsmFloat time;
        private float timer;

        public override void OnEnter()
        {
            if (this.time.Value <= 0f)
            {
                base.Fsm.Event(this.finishEvent);
                base.Finish();
            }
            else
            {
                this.startTime = FsmTime.RealtimeSinceStartup;
                this.timer = 0f;
            }
        }

        public override void OnUpdate()
        {
            if (this.realTime)
            {
                this.timer = FsmTime.RealtimeSinceStartup - this.startTime;
            }
            else
            {
                this.timer += Time.deltaTime;
            }
            if (this.timer >= this.time.Value)
            {
                base.Finish();
                if (this.finishEvent != null)
                {
                    base.Fsm.Event(this.finishEvent);
                }
            }
        }

        public override void Reset()
        {
            this.time = 1f;
            this.finishEvent = null;
            this.realTime = false;
        }
    }
}


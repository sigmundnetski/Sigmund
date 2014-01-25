namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Delays a State from finishing by a random time. NOTE: Other actions continue, but FINISHED can't happen before the delay."), ActionCategory(ActionCategory.Time)]
    public class RandomWaitAction : FsmStateAction
    {
        public FsmEvent m_FinishEvent;
        public FsmFloat m_MaxTime;
        public FsmFloat m_MinTime;
        public bool m_RealTime;
        private float m_startTime;
        private float m_updateTime;
        private float m_waitTime;

        public override void OnEnter()
        {
            if ((this.m_MinTime.Value <= 0f) && (this.m_MaxTime.Value <= 0f))
            {
                base.Finish();
                if (this.m_FinishEvent != null)
                {
                    base.Fsm.Event(this.m_FinishEvent);
                }
            }
            else
            {
                this.m_startTime = FsmTime.RealtimeSinceStartup;
                this.m_waitTime = UnityEngine.Random.Range(this.m_MinTime.Value, this.m_MaxTime.Value);
                this.m_updateTime = 0f;
            }
        }

        public override void OnUpdate()
        {
            if (this.m_RealTime)
            {
                this.m_updateTime = FsmTime.RealtimeSinceStartup - this.m_startTime;
            }
            else
            {
                this.m_updateTime += Time.deltaTime;
            }
            if (this.m_updateTime > this.m_waitTime)
            {
                base.Finish();
                if (this.m_FinishEvent != null)
                {
                    base.Fsm.Event(this.m_FinishEvent);
                }
            }
        }

        public override void Reset()
        {
            this.m_MinTime = 1f;
            this.m_MaxTime = 1f;
            this.m_FinishEvent = null;
            this.m_RealTime = false;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Turns a Particle Emitter on and off with optional delay."), ActionCategory(ActionCategory.Effects)]
    public class particleEmitterOnOff : FsmStateAction
    {
        [Tooltip("If 0 it just acts like a switch. Values cause it to Toggle value after delay time (sec).")]
        public FsmFloat delay;
        [Tooltip("Set to True to turn it on and False to turn it off.")]
        public FsmBool emitOnOff;
        public FsmEvent finishEvent;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        private GameObject go;
        public bool realTime;
        private float startTime;
        private float timer;

        public override void OnEnter()
        {
            this.go = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            this.go.particleEmitter.emit = this.emitOnOff.Value;
            if (this.delay.Value <= 0f)
            {
                base.Finish();
            }
            else
            {
                this.startTime = Time.realtimeSinceStartup;
                this.timer = 0f;
            }
        }

        public override void OnUpdate()
        {
            if (this.realTime)
            {
                this.timer = Time.realtimeSinceStartup - this.startTime;
            }
            else
            {
                this.timer += Time.deltaTime;
            }
            if (this.timer > this.delay.Value)
            {
                this.go.particleEmitter.emit = !this.emitOnOff.Value;
                base.Finish();
                if (this.finishEvent != null)
                {
                    base.Fsm.Event(this.finishEvent);
                }
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.emitOnOff = 0;
            this.delay = 0f;
            this.finishEvent = null;
            this.realTime = false;
            this.go = null;
        }
    }
}


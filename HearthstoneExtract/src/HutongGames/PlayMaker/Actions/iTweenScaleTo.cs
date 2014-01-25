namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("iTween"), Tooltip("Changes a GameObject's scale over time.")]
    public class iTweenScaleTo : iTweenFsmAction
    {
        [Tooltip("The time in seconds the animation will wait before beginning.")]
        public FsmFloat delay;
        [Tooltip("The shape of the easing curve applied to the animation.")]
        public iTween.EaseType easeType = iTween.EaseType.linear;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("iTween ID. If set you can use iTween Stop action to stop it by its id.")]
        public FsmString id;
        [Tooltip("The type of loop to apply once the animation has completed.")]
        public iTween.LoopType loopType;
        [Tooltip("Can be used instead of time to allow animation based on speed. When you define speed the time variable is ignored.")]
        public FsmFloat speed;
        [Tooltip("The time in seconds the animation will take to complete.")]
        public FsmFloat time;
        [Tooltip("Scale To a transform scale.")]
        public FsmGameObject transformScale;
        [Tooltip("A scale vector the GameObject will animate To.")]
        public FsmVector3 vectorScale;

        private void DoiTween()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Vector3 vector = !this.vectorScale.IsNone ? this.vectorScale.Value : Vector3.zero;
                if (!this.transformScale.IsNone && (this.transformScale.Value != null))
                {
                    vector = this.transformScale.Value.transform.localScale + vector;
                }
                base.itweenType = "scale";
                object[] args = new object[] { 
                    "scale", vector, "name", !this.id.IsNone ? this.id.Value : string.Empty, !this.speed.IsNone ? "speed" : "time", !this.speed.IsNone ? this.speed.Value : (!this.time.IsNone ? this.time.Value : 1f), "delay", !this.delay.IsNone ? this.delay.Value : 0f, "easetype", this.easeType, "looptype", this.loopType, "oncomplete", "iTweenOnComplete", "oncompleteparams", base.itweenID, 
                    "onstart", "iTweenOnStart", "onstartparams", base.itweenID, "ignoretimescale", !base.realTime.IsNone ? ((object) base.realTime.Value) : ((object) 0)
                 };
                iTween.ScaleTo(ownerDefaultTarget, iTween.Hash(args));
            }
        }

        public override void OnEnter()
        {
            base.OnEnteriTween(this.gameObject);
            if (this.loopType != iTween.LoopType.none)
            {
                base.IsLoop(true);
            }
            this.DoiTween();
        }

        public override void OnExit()
        {
            base.OnExitiTween(this.gameObject);
        }

        public override void Reset()
        {
            base.Reset();
            FsmString str = new FsmString {
                UseVariable = true
            };
            this.id = str;
            FsmGameObject obj2 = new FsmGameObject {
                UseVariable = true
            };
            this.transformScale = obj2;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vectorScale = vector;
            this.time = 1f;
            this.delay = 0f;
            this.loopType = iTween.LoopType.none;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.speed = num;
        }
    }
}


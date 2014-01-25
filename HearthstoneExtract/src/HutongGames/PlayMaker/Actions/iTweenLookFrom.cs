namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("iTween"), Tooltip("Instantly rotates a GameObject to look at the supplied Vector3 then returns it to it's starting rotation over time.")]
    public class iTweenLookFrom : iTweenFsmAction
    {
        [Tooltip("Restricts rotation to the supplied axis only.")]
        public iTweenFsmAction.AxisRestriction axis;
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
        [Tooltip("Look from a transform position.")]
        public FsmGameObject transformTarget;
        [Tooltip("A target position the GameObject will look at. If Transform Target is defined this is used as a local offset.")]
        public FsmVector3 vectorTarget;

        private void DoiTween()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Vector3 vector = !this.vectorTarget.IsNone ? this.vectorTarget.Value : Vector3.zero;
                if (!this.transformTarget.IsNone && (this.transformTarget.Value != null))
                {
                    vector = this.transformTarget.Value.transform.position + vector;
                }
                base.itweenType = "rotate";
                object[] args = new object[] { 
                    "looktarget", vector, "name", !this.id.IsNone ? this.id.Value : string.Empty, !this.speed.IsNone ? "speed" : "time", !this.speed.IsNone ? this.speed.Value : (!this.time.IsNone ? this.time.Value : 1f), "delay", !this.delay.IsNone ? this.delay.Value : 0f, "easetype", this.easeType, "looptype", this.loopType, "oncomplete", "iTweenOnComplete", "oncompleteparams", base.itweenID, 
                    "onstart", "iTweenOnStart", "onstartparams", base.itweenID, "ignoretimescale", !base.realTime.IsNone ? ((object) base.realTime.Value) : ((object) 0), "axis", (this.axis != iTweenFsmAction.AxisRestriction.none) ? Enum.GetName(typeof(iTweenFsmAction.AxisRestriction), this.axis) : string.Empty
                 };
                iTween.LookFrom(ownerDefaultTarget, iTween.Hash(args));
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
            this.transformTarget = obj2;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vectorTarget = vector;
            this.time = 1f;
            this.delay = 0f;
            this.loopType = iTween.LoopType.none;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.speed = num;
            this.axis = iTweenFsmAction.AxisRestriction.none;
        }
    }
}


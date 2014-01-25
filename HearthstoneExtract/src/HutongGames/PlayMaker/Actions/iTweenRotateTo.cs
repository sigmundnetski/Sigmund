namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Rotates a GameObject to the supplied Euler angles in degrees over time."), ActionCategory("iTween")]
    public class iTweenRotateTo : iTweenFsmAction
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
        [Tooltip("Whether to animate in local or world space.")]
        public Space space;
        [Tooltip("Can be used instead of time to allow animation based on speed. When you define speed the time variable is ignored.")]
        public FsmFloat speed;
        [Tooltip("The time in seconds the animation will take to complete.")]
        public FsmFloat time;
        [Tooltip("Rotate to a transform rotation.")]
        public FsmGameObject transformRotation;
        [Tooltip("A rotation the GameObject will animate from.")]
        public FsmVector3 vectorRotation;

        private void DoiTween()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Vector3 vector = !this.vectorRotation.IsNone ? this.vectorRotation.Value : Vector3.zero;
                if (!this.transformRotation.IsNone && (this.transformRotation.Value != null))
                {
                    vector = (this.space != Space.World) ? (this.transformRotation.Value.transform.localEulerAngles + vector) : (this.transformRotation.Value.transform.eulerAngles + vector);
                }
                base.itweenType = "rotate";
                object[] args = new object[] { 
                    "rotation", vector, "name", !this.id.IsNone ? this.id.Value : string.Empty, !this.speed.IsNone ? "speed" : "time", !this.speed.IsNone ? this.speed.Value : (!this.time.IsNone ? this.time.Value : 1f), "delay", !this.delay.IsNone ? this.delay.Value : 0f, "easetype", this.easeType, "looptype", this.loopType, "oncomplete", "iTweenOnComplete", "oncompleteparams", base.itweenID, 
                    "onstart", "iTweenOnStart", "onstartparams", base.itweenID, "ignoretimescale", !base.realTime.IsNone ? ((object) base.realTime.Value) : ((object) 0), "islocal", this.space == Space.Self
                 };
                iTween.RotateTo(ownerDefaultTarget, iTween.Hash(args));
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
            this.transformRotation = obj2;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vectorRotation = vector;
            this.time = 1f;
            this.delay = 0f;
            this.loopType = iTween.LoopType.none;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.speed = num;
            this.space = Space.World;
        }
    }
}


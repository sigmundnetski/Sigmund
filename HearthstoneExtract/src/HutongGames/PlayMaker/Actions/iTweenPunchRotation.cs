namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Applies a jolt of force to a GameObject's rotation and wobbles it back to its initial rotation. NOTE: Due to the way iTween utilizes the Transform.Rotate method, PunchRotation works best with single axis usage rather than punching with a Vector3."), ActionCategory("iTween")]
    public class iTweenPunchRotation : iTweenFsmAction
    {
        [Tooltip("The time in seconds the animation will wait before beginning.")]
        public FsmFloat delay;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("iTween ID. If set you can use iTween Stop action to stop it by its id.")]
        public FsmString id;
        [Tooltip("The type of loop to apply once the animation has completed.")]
        public iTween.LoopType loopType;
        public Space space;
        [Tooltip("The time in seconds the animation will take to complete.")]
        public FsmFloat time;
        [RequiredField, Tooltip("A vector punch range.")]
        public FsmVector3 vector;

        private void DoiTween()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Vector3 zero = Vector3.zero;
                if (!this.vector.IsNone)
                {
                    zero = this.vector.Value;
                }
                base.itweenType = "punch";
                object[] args = new object[] { 
                    "amount", zero, "name", !this.id.IsNone ? this.id.Value : string.Empty, "time", !this.time.IsNone ? this.time.Value : 1f, "delay", !this.delay.IsNone ? this.delay.Value : 0f, "looptype", this.loopType, "oncomplete", "iTweenOnComplete", "oncompleteparams", base.itweenID, "onstart", "iTweenOnStart", 
                    "onstartparams", base.itweenID, "ignoretimescale", !base.realTime.IsNone ? ((object) base.realTime.Value) : ((object) 0), "space", this.space
                 };
                iTween.PunchRotation(ownerDefaultTarget, iTween.Hash(args));
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
            this.time = 1f;
            this.delay = 0f;
            this.loopType = iTween.LoopType.none;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vector = vector;
            this.space = Space.World;
        }
    }
}


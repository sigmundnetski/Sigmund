namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Shakes the Main Camera a specified amount over time."), ActionCategory(ActionCategory.Camera)]
    public class MainCameraShakerAction : iTweenFsmAction
    {
        [Tooltip("Restricts rotation to the supplied axis only. Just put there strinc like 'x' or 'xz'")]
        public iTweenFsmAction.AxisRestriction axis;
        private readonly string DEFAULT_TWEEN_NAME = typeof(MainCameraShakerAction).ToString();
        [Tooltip("The time in seconds the animation will wait before beginning.")]
        public FsmFloat delay;
        [Tooltip("The shape of the easing curve applied to the animation.")]
        public iTween.EaseType easeType = iTween.EaseType.linear;
        private FsmOwnerDefault gameObject;
        [Tooltip("iTween ID. If set you can use iTween Stop action to stop it by its id.")]
        public FsmString id;
        [Tooltip("The type of loop to apply once the animation has completed.")]
        public iTween.LoopType loopType;
        [Tooltip("Make the animation happen in local or world space.")]
        public Space space;
        [Tooltip("The time in seconds the animation will take to complete.")]
        public FsmFloat time;
        [Tooltip("A vector shake range.")]
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
                base.itweenType = "shake";
                object[] args = new object[] { 
                    "amount", zero, "name", !this.id.IsNone ? this.id.Value : this.DEFAULT_TWEEN_NAME, "time", !this.time.IsNone ? this.time.Value : 1f, "delay", !this.delay.IsNone ? this.delay.Value : 0f, "easetype", this.easeType, "looptype", this.loopType, "oncomplete", "iTweenOnComplete", "oncompleteparams", base.itweenID, 
                    "onstart", "iTweenOnStart", "onstartparams", base.itweenID, "ignoretimescale", !base.realTime.IsNone ? ((object) base.realTime.Value) : ((object) 0), "space", this.space, "axis", (this.axis != iTweenFsmAction.AxisRestriction.none) ? Enum.GetName(typeof(iTweenFsmAction.AxisRestriction), this.axis) : string.Empty
                 };
                iTween.ShakePosition(ownerDefaultTarget, iTween.Hash(args));
            }
        }

        public override void OnEnter()
        {
            if (Camera.main == null)
            {
                base.Finish();
            }
            else
            {
                if (this.gameObject == null)
                {
                    GameObject obj2 = ShakeResetter.Get().CreateShaker(Camera.main.gameObject);
                    this.gameObject = new FsmOwnerDefault();
                    this.gameObject.OwnerOption = OwnerDefaultOption.SpecifyGameObject;
                    this.gameObject.GameObject = obj2;
                }
                base.OnEnteriTween(this.gameObject);
                if (this.loopType != iTween.LoopType.none)
                {
                    base.IsLoop(true);
                }
                this.DoiTween();
            }
        }

        public override void OnExit()
        {
            if (this.gameObject != null)
            {
                base.OnExitiTween(this.gameObject);
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                ShakeResetter.Get().DestroyShaker(ownerDefaultTarget);
                this.gameObject = null;
            }
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
            this.easeType = iTween.EaseType.linear;
            this.loopType = iTween.LoopType.none;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vector = vector;
            this.space = Space.World;
            this.axis = iTweenFsmAction.AxisRestriction.none;
        }
    }
}


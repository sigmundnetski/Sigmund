namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using UnityEngine;

    [Tooltip("Instantly changes a GameObject's position to a supplied destination then returns it to it's starting position over time."), ActionCategory("iTween")]
    public class iTweenMoveFrom : iTweenFsmAction
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
        [Tooltip("A target object the GameObject will look at.")]
        public FsmGameObject lookAtObject;
        [Tooltip("A target position the GameObject will look at.")]
        public FsmVector3 lookAtVector;
        [Tooltip("The time in seconds the object will take to look at either the Look At Target or Orient To Path. 0 by default")]
        public FsmFloat lookTime;
        [Tooltip("The type of loop to apply once the animation has completed.")]
        public iTween.LoopType loopType;
        [ActionSection("LookAt"), Tooltip("Whether or not the GameObject will orient to its direction of travel. False by default.")]
        public FsmBool orientToPath;
        [Tooltip("Whether to animate in local or world space.")]
        public Space space;
        [Tooltip("Can be used instead of time to allow animation based on speed. When you define speed the time variable is ignored.")]
        public FsmFloat speed;
        [Tooltip("The time in seconds the animation will take to complete.")]
        public FsmFloat time;
        [Tooltip("Move From a transform rotation.")]
        public FsmGameObject transformPosition;
        [Tooltip("The position the GameObject will animate from. If Transform Position is defined this is used as a local offset.")]
        public FsmVector3 vectorPosition;

        private void DoiTween()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Vector3 vector = !this.vectorPosition.IsNone ? this.vectorPosition.Value : Vector3.zero;
                if (!this.transformPosition.IsNone && (this.transformPosition.Value != null))
                {
                    vector = ((this.space != Space.World) && (ownerDefaultTarget.transform.parent != null)) ? (ownerDefaultTarget.transform.parent.InverseTransformPoint(this.transformPosition.Value.transform.position) + vector) : (this.transformPosition.Value.transform.position + vector);
                }
                Hashtable args = new Hashtable();
                args.Add("position", vector);
                args.Add(!this.speed.IsNone ? "speed" : "time", !this.speed.IsNone ? this.speed.Value : (!this.time.IsNone ? this.time.Value : 1f));
                args.Add("delay", !this.delay.IsNone ? this.delay.Value : 0f);
                args.Add("easetype", this.easeType);
                args.Add("looptype", this.loopType);
                args.Add("oncomplete", "iTweenOnComplete");
                args.Add("oncompleteparams", base.itweenID);
                args.Add("onstart", "iTweenOnStart");
                args.Add("onstartparams", base.itweenID);
                args.Add("ignoretimescale", !base.realTime.IsNone ? ((object) base.realTime.Value) : ((object) 0));
                args.Add("islocal", this.space == Space.Self);
                args.Add("name", !this.id.IsNone ? this.id.Value : string.Empty);
                args.Add("axis", (this.axis != iTweenFsmAction.AxisRestriction.none) ? Enum.GetName(typeof(iTweenFsmAction.AxisRestriction), this.axis) : string.Empty);
                if (!this.orientToPath.IsNone)
                {
                    args.Add("orienttopath", this.orientToPath.Value);
                }
                if (!this.lookAtObject.IsNone)
                {
                    args.Add("looktarget", !this.lookAtVector.IsNone ? (this.lookAtObject.Value.transform.position + this.lookAtVector.Value) : this.lookAtObject.Value.transform.position);
                }
                else if (!this.lookAtVector.IsNone)
                {
                    args.Add("looktarget", this.lookAtVector.Value);
                }
                if (!this.lookAtObject.IsNone || !this.lookAtVector.IsNone)
                {
                    args.Add("looktime", !this.lookTime.IsNone ? this.lookTime.Value : 0f);
                }
                base.itweenType = "move";
                iTween.MoveFrom(ownerDefaultTarget, args);
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
            this.transformPosition = obj2;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vectorPosition = vector;
            this.time = 1f;
            this.delay = 0f;
            this.loopType = iTween.LoopType.none;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.speed = num;
            this.space = Space.World;
            FsmBool @bool = new FsmBool {
                Value = true
            };
            this.orientToPath = @bool;
            obj2 = new FsmGameObject {
                UseVariable = true
            };
            this.lookAtObject = obj2;
            vector = new FsmVector3 {
                UseVariable = true
            };
            this.lookAtVector = vector;
            this.lookTime = 0f;
            this.axis = iTweenFsmAction.AxisRestriction.none;
        }
    }
}


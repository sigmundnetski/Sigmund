namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using UnityEngine;

    [ActionCategory("iTween"), Tooltip("Changes a GameObject's position over time to a supplied destination.")]
    public class iTweenMoveTo : iTweenFsmAction
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
        [Tooltip("How much of a percentage (from 0 to 1) to look ahead on a path to influence how strict Orient To Path is and how much the object will anticipate each curve.")]
        public FsmFloat lookAhead;
        [Tooltip("A target object the GameObject will look at.")]
        public FsmGameObject lookAtObject;
        [Tooltip("A target position the GameObject will look at.")]
        public FsmVector3 lookAtVector;
        [Tooltip("The time in seconds the object will take to look at either the Look Target or Orient To Path. 0 by default")]
        public FsmFloat lookTime;
        [Tooltip("The type of loop to apply once the animation has completed.")]
        public iTween.LoopType loopType;
        [ActionSection("Path"), Tooltip("Whether to automatically generate a curve from the GameObject's current position to the beginning of the path. True by default.")]
        public FsmBool moveToPath;
        [Tooltip("Whether or not the GameObject will orient to its direction of travel. False by default."), ActionSection("LookAt")]
        public FsmBool orientToPath;
        [Tooltip("Reverse the path so object moves from End to Start node.")]
        public FsmBool reverse;
        [Tooltip("Whether to animate in local or world space.")]
        public Space space;
        [Tooltip("Can be used instead of time to allow animation based on speed. When you define speed the time variable is ignored.")]
        public FsmFloat speed;
        private Vector3[] tempVct3;
        [Tooltip("The time in seconds the animation will take to complete.")]
        public FsmFloat time;
        [Tooltip("Move To a transform position.")]
        public FsmGameObject transformPosition;
        [Tooltip("A list of objects to draw a Catmull-Rom spline through for a curved animation path."), CompoundArray("Path Nodes", "Transform", "Vector")]
        public FsmGameObject[] transforms;
        [Tooltip("Position the GameObject will animate to. If Transform Position is defined this is used as a local offset.")]
        public FsmVector3 vectorPosition;
        [Tooltip("A list of positions to draw a Catmull-Rom through for a curved animation path. If Transform is defined, this value is added as a local offset.")]
        public FsmVector3[] vectors;

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
                args.Add("name", !this.id.IsNone ? this.id.Value : string.Empty);
                args.Add("islocal", this.space == Space.Self);
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
                if (this.transforms.Length >= 2)
                {
                    this.tempVct3 = new Vector3[this.transforms.Length];
                    if (!this.reverse.IsNone ? this.reverse.Value : false)
                    {
                        for (int i = 0; i < this.transforms.Length; i++)
                        {
                            if (this.transforms[i].IsNone)
                            {
                                this.tempVct3[(this.tempVct3.Length - 1) - i] = !this.vectors[i].IsNone ? this.vectors[i].Value : Vector3.zero;
                            }
                            else if (this.transforms[i].Value == null)
                            {
                                this.tempVct3[(this.tempVct3.Length - 1) - i] = !this.vectors[i].IsNone ? this.vectors[i].Value : Vector3.zero;
                            }
                            else
                            {
                                this.tempVct3[(this.tempVct3.Length - 1) - i] = ((this.space != Space.World) ? this.transforms[i].Value.transform.localPosition : this.transforms[i].Value.transform.position) + (!this.vectors[i].IsNone ? this.vectors[i].Value : Vector3.zero);
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < this.transforms.Length; j++)
                        {
                            if (this.transforms[j].IsNone)
                            {
                                this.tempVct3[j] = !this.vectors[j].IsNone ? this.vectors[j].Value : Vector3.zero;
                            }
                            else if (this.transforms[j].Value == null)
                            {
                                this.tempVct3[j] = !this.vectors[j].IsNone ? this.vectors[j].Value : Vector3.zero;
                            }
                            else
                            {
                                this.tempVct3[j] = ((this.space != Space.World) ? ownerDefaultTarget.transform.parent.InverseTransformPoint(this.transforms[j].Value.transform.position) : this.transforms[j].Value.transform.position) + (!this.vectors[j].IsNone ? this.vectors[j].Value : Vector3.zero);
                            }
                        }
                    }
                    args.Add("path", this.tempVct3);
                    args.Add("movetopath", !this.moveToPath.IsNone ? ((object) this.moveToPath.Value) : ((object) 1));
                    args.Add("lookahead", !this.lookAhead.IsNone ? this.lookAhead.Value : 1f);
                }
                base.itweenType = "move";
                iTween.MoveTo(ownerDefaultTarget, args);
            }
        }

        public override void OnDrawGizmos()
        {
            if (this.transforms.Length >= 2)
            {
                this.tempVct3 = new Vector3[this.transforms.Length];
                for (int i = 0; i < this.transforms.Length; i++)
                {
                    if (this.transforms[i].IsNone)
                    {
                        this.tempVct3[i] = !this.vectors[i].IsNone ? this.vectors[i].Value : Vector3.zero;
                    }
                    else if (this.transforms[i].Value == null)
                    {
                        this.tempVct3[i] = !this.vectors[i].IsNone ? this.vectors[i].Value : Vector3.zero;
                    }
                    else
                    {
                        this.tempVct3[i] = this.transforms[i].Value.transform.position + (!this.vectors[i].IsNone ? this.vectors[i].Value : Vector3.zero);
                    }
                }
                iTween.DrawPathGizmos(this.tempVct3, Color.yellow);
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
            num = new FsmFloat {
                UseVariable = true
            };
            this.lookTime = num;
            this.moveToPath = 1;
            num = new FsmFloat {
                UseVariable = true
            };
            this.lookAhead = num;
            this.transforms = new FsmGameObject[0];
            this.vectors = new FsmVector3[0];
            this.tempVct3 = new Vector3[0];
            this.axis = iTweenFsmAction.AxisRestriction.none;
            this.reverse = 0;
        }
    }
}


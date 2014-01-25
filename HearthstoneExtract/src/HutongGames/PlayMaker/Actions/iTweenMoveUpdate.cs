namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using UnityEngine;

    [Tooltip("Similar to MoveTo but incredibly less expensive for usage inside the Update function or similar looping situations involving a 'live' set of changing values. Does not utilize an EaseType."), ActionCategory("iTween")]
    public class iTweenMoveUpdate : FsmStateAction
    {
        [Tooltip("Restricts rotation to the supplied axis only.")]
        public iTweenFsmAction.AxisRestriction axis;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        private GameObject go;
        private Hashtable hash;
        [Tooltip("A target object the GameObject will look at.")]
        public FsmGameObject lookAtObject;
        [Tooltip("A target position the GameObject will look at.")]
        public FsmVector3 lookAtVector;
        [Tooltip("The time in seconds the object will take to look at either the Look At Target or Orient To Path. 0 by default")]
        public FsmFloat lookTime;
        [ActionSection("LookAt"), Tooltip("Whether or not the GameObject will orient to its direction of travel. False by default.")]
        public FsmBool orientToPath;
        [Tooltip("Whether to animate in local or world space.")]
        public Space space;
        [Tooltip("The time in seconds the animation will take to complete.")]
        public FsmFloat time;
        [Tooltip("Move From a transform rotation.")]
        public FsmGameObject transformPosition;
        [Tooltip("The position the GameObject will animate from.  If transformPosition is set, this is used as an offset.")]
        public FsmVector3 vectorPosition;

        private void DoiTween()
        {
            iTween.MoveUpdate(this.go, this.hash);
        }

        public override void OnEnter()
        {
            this.hash = new Hashtable();
            this.go = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (this.go == null)
            {
                base.Finish();
            }
            else
            {
                if (this.transformPosition.IsNone)
                {
                    this.hash.Add("position", !this.vectorPosition.IsNone ? this.vectorPosition.Value : Vector3.zero);
                }
                else if (this.vectorPosition.IsNone)
                {
                    this.hash.Add("position", this.transformPosition.Value.transform);
                }
                else if ((this.space == Space.World) || (this.go.transform.parent == null))
                {
                    this.hash.Add("position", this.transformPosition.Value.transform.position + this.vectorPosition.Value);
                }
                else
                {
                    this.hash.Add("position", this.go.transform.parent.InverseTransformPoint(this.transformPosition.Value.transform.position) + this.vectorPosition.Value);
                }
                this.hash.Add("time", !this.time.IsNone ? this.time.Value : 1f);
                this.hash.Add("islocal", this.space == Space.Self);
                this.hash.Add("axis", (this.axis != iTweenFsmAction.AxisRestriction.none) ? Enum.GetName(typeof(iTweenFsmAction.AxisRestriction), this.axis) : string.Empty);
                if (!this.orientToPath.IsNone)
                {
                    this.hash.Add("orienttopath", this.orientToPath.Value);
                }
                if (this.lookAtObject.IsNone)
                {
                    if (!this.lookAtVector.IsNone)
                    {
                        this.hash.Add("looktarget", this.lookAtVector.Value);
                    }
                }
                else
                {
                    this.hash.Add("looktarget", this.lookAtObject.Value.transform);
                }
                if (!this.lookAtObject.IsNone || !this.lookAtVector.IsNone)
                {
                    this.hash.Add("looktime", !this.lookTime.IsNone ? this.lookTime.Value : 0f);
                }
                this.DoiTween();
            }
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            this.hash.Remove("position");
            if (this.transformPosition.IsNone)
            {
                this.hash.Add("position", !this.vectorPosition.IsNone ? this.vectorPosition.Value : Vector3.zero);
            }
            else if (this.vectorPosition.IsNone)
            {
                this.hash.Add("position", this.transformPosition.Value.transform);
            }
            else if (this.space == Space.World)
            {
                this.hash.Add("position", this.transformPosition.Value.transform.position + this.vectorPosition.Value);
            }
            else
            {
                this.hash.Add("position", this.transformPosition.Value.transform.localPosition + this.vectorPosition.Value);
            }
            this.DoiTween();
        }

        public override void Reset()
        {
            FsmGameObject obj2 = new FsmGameObject {
                UseVariable = true
            };
            this.transformPosition = obj2;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vectorPosition = vector;
            this.time = 1f;
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


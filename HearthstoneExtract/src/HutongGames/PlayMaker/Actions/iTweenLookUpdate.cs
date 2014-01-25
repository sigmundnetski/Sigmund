namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using UnityEngine;

    [Tooltip("Rotates a GameObject to look at a supplied Transform or Vector3 over time."), ActionCategory("iTween")]
    public class iTweenLookUpdate : FsmStateAction
    {
        [Tooltip("Restricts rotation to the supplied axis only. Just put there strinc like 'x' or 'xz'")]
        public iTweenFsmAction.AxisRestriction axis;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        private GameObject go;
        private Hashtable hash;
        [Tooltip("The time in seconds the animation will take to complete.")]
        public FsmFloat time;
        [Tooltip("Look at a transform position.")]
        public FsmGameObject transformTarget;
        [Tooltip("A target position the GameObject will look at. If Transform Target is defined this is used as a look offset.")]
        public FsmVector3 vectorTarget;

        private void DoiTween()
        {
            iTween.LookUpdate(this.go, this.hash);
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
                if (this.transformTarget.IsNone)
                {
                    this.hash.Add("looktarget", !this.vectorTarget.IsNone ? this.vectorTarget.Value : Vector3.zero);
                }
                else if (this.vectorTarget.IsNone)
                {
                    this.hash.Add("looktarget", this.transformTarget.Value.transform);
                }
                else
                {
                    this.hash.Add("looktarget", this.transformTarget.Value.transform.position + this.vectorTarget.Value);
                }
                this.hash.Add("time", !this.time.IsNone ? this.time.Value : 1f);
                this.hash.Add("axis", (this.axis != iTweenFsmAction.AxisRestriction.none) ? Enum.GetName(typeof(iTweenFsmAction.AxisRestriction), this.axis) : string.Empty);
                this.DoiTween();
            }
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            this.hash.Remove("looktarget");
            if (this.transformTarget.IsNone)
            {
                this.hash.Add("looktarget", !this.vectorTarget.IsNone ? this.vectorTarget.Value : Vector3.zero);
            }
            else if (this.vectorTarget.IsNone)
            {
                this.hash.Add("looktarget", this.transformTarget.Value.transform);
            }
            else
            {
                this.hash.Add("looktarget", this.transformTarget.Value.transform.position + this.vectorTarget.Value);
            }
            this.DoiTween();
        }

        public override void Reset()
        {
            FsmGameObject obj2 = new FsmGameObject {
                UseVariable = true
            };
            this.transformTarget = obj2;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vectorTarget = vector;
            this.time = 1f;
            this.axis = iTweenFsmAction.AxisRestriction.none;
        }
    }
}


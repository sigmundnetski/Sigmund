namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using UnityEngine;

    [Tooltip("Similar to RotateTo but incredibly less expensive for usage inside the Update function or similar looping situations involving a 'live' set of changing values. Does not utilize an EaseType."), ActionCategory("iTween")]
    public class iTweenRotateUpdate : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;
        private GameObject go;
        private Hashtable hash;
        [Tooltip("Whether to animate in local or world space.")]
        public Space space;
        [Tooltip("The time in seconds the animation will take to complete. If transformRotation is set, this is used as an offset.")]
        public FsmFloat time;
        [Tooltip("Rotate to a transform rotation.")]
        public FsmGameObject transformRotation;
        [Tooltip("A rotation the GameObject will animate from.")]
        public FsmVector3 vectorRotation;

        private void DoiTween()
        {
            iTween.RotateUpdate(this.go, this.hash);
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
                if (this.transformRotation.IsNone)
                {
                    this.hash.Add("rotation", !this.vectorRotation.IsNone ? this.vectorRotation.Value : Vector3.zero);
                }
                else if (this.vectorRotation.IsNone)
                {
                    this.hash.Add("rotation", this.transformRotation.Value.transform);
                }
                else if (this.space == Space.World)
                {
                    this.hash.Add("rotation", this.transformRotation.Value.transform.eulerAngles + this.vectorRotation.Value);
                }
                else
                {
                    this.hash.Add("rotation", this.transformRotation.Value.transform.localEulerAngles + this.vectorRotation.Value);
                }
                this.hash.Add("time", !this.time.IsNone ? this.time.Value : 1f);
                this.hash.Add("islocal", this.space == Space.Self);
                this.DoiTween();
            }
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            this.hash.Remove("rotation");
            if (this.transformRotation.IsNone)
            {
                this.hash.Add("rotation", !this.vectorRotation.IsNone ? this.vectorRotation.Value : Vector3.zero);
            }
            else if (this.vectorRotation.IsNone)
            {
                this.hash.Add("rotation", this.transformRotation.Value.transform);
            }
            else if (this.space == Space.World)
            {
                this.hash.Add("rotation", this.transformRotation.Value.transform.eulerAngles + this.vectorRotation.Value);
            }
            else
            {
                this.hash.Add("rotation", this.transformRotation.Value.transform.localEulerAngles + this.vectorRotation.Value);
            }
            this.DoiTween();
        }

        public override void Reset()
        {
            FsmGameObject obj2 = new FsmGameObject {
                UseVariable = true
            };
            this.transformRotation = obj2;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vectorRotation = vector;
            this.time = 1f;
            this.space = Space.World;
        }
    }
}


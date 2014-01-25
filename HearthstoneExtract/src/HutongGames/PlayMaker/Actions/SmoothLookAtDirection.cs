namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Smoothly Rotates a Game Object so its forward vector points in the specified Direction."), ActionCategory(ActionCategory.Transform)]
    public class SmoothLookAtDirection : FsmStateAction
    {
        private Quaternion desiredRotation;
        [Tooltip("The GameObject to rotate."), RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField, Tooltip("Eliminate any tilt up/down as the GameObject rotates.")]
        public FsmBool keepVertical;
        private Quaternion lastRotation;
        [Tooltip("Perform in LateUpdate. This can help eliminate jitters in some situations.")]
        public bool lateUpdate;
        [Tooltip("Only rotate if Target Direction Vector length is greater than this threshold.")]
        public FsmFloat minMagnitude;
        private GameObject previousGo;
        [RequiredField, Tooltip("How quickly to rotate."), HasFloatSlider(0.5f, 15f)]
        public FsmFloat speed;
        [RequiredField, Tooltip("The direction to smoothly rotate towards.")]
        public FsmVector3 targetDirection;
        [Tooltip("Keep this vector pointing up as the GameObject rotates.")]
        public FsmVector3 upVector;

        private void DoSmoothLookAtDirection()
        {
            if (!this.targetDirection.IsNone)
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                if (ownerDefaultTarget != null)
                {
                    if (this.previousGo != ownerDefaultTarget)
                    {
                        this.lastRotation = ownerDefaultTarget.transform.rotation;
                        this.desiredRotation = this.lastRotation;
                        this.previousGo = ownerDefaultTarget;
                    }
                    Vector3 forward = this.targetDirection.Value;
                    if (this.keepVertical.Value)
                    {
                        forward.y = 0f;
                    }
                    if (forward.sqrMagnitude > this.minMagnitude.Value)
                    {
                        this.desiredRotation = Quaternion.LookRotation(forward, !this.upVector.IsNone ? this.upVector.Value : Vector3.up);
                    }
                    this.lastRotation = Quaternion.Slerp(this.lastRotation, this.desiredRotation, this.speed.Value * Time.deltaTime);
                    ownerDefaultTarget.transform.rotation = this.lastRotation;
                }
            }
        }

        public override void OnEnter()
        {
            this.previousGo = null;
        }

        public override void OnLateUpdate()
        {
            if (this.lateUpdate)
            {
                this.DoSmoothLookAtDirection();
            }
        }

        public override void OnUpdate()
        {
            if (!this.lateUpdate)
            {
                this.DoSmoothLookAtDirection();
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.targetDirection = vector;
            this.minMagnitude = 0.1f;
            vector = new FsmVector3 {
                UseVariable = true
            };
            this.upVector = vector;
            this.keepVertical = 1;
            this.speed = 5f;
            this.lateUpdate = true;
        }
    }
}


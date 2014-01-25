namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Smoothly Rotates a Game Object so its forward vector points at a Target. The target can be defined as a Game Object or a world Position. If you specify both, then the position will be used as a local offset from the object's position."), ActionCategory(ActionCategory.Transform)]
    public class SmoothLookAt : FsmStateAction
    {
        [Tooltip("Draw a line in the Scene View to the look at position.")]
        public FsmBool debug;
        private Quaternion desiredRotation;
        [Tooltip("Event to send if the angle to target is less than the Finish Tolerance.")]
        public FsmEvent finishEvent;
        [Tooltip("If the angle to the target is less than this, send the Finish Event below. Measured in degrees.")]
        public FsmFloat finishTolerance;
        [RequiredField, Tooltip("The GameObject to rotate to face a target.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Force the game object to remain vertical. Useful for characters.")]
        public FsmBool keepVertical;
        private Quaternion lastRotation;
        private GameObject previousGo;
        [HasFloatSlider(0.5f, 15f), Tooltip("How fast the look at moves.")]
        public FsmFloat speed;
        [Tooltip("A target GameObject.")]
        public FsmGameObject targetObject;
        [Tooltip("A target position. If a Target Object is defined, this is used as a local offset.")]
        public FsmVector3 targetPosition;
        [Tooltip("Used to keep the game object generally upright. If left undefined the world y axis is used.")]
        public FsmVector3 upVector;

        private void DoSmoothLookAt()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                GameObject obj3 = this.targetObject.Value;
                if ((obj3 != null) || !this.targetPosition.IsNone)
                {
                    Vector3 vector;
                    if (this.previousGo != ownerDefaultTarget)
                    {
                        this.lastRotation = ownerDefaultTarget.transform.rotation;
                        this.desiredRotation = this.lastRotation;
                        this.previousGo = ownerDefaultTarget;
                    }
                    if (obj3 != null)
                    {
                        vector = this.targetPosition.IsNone ? obj3.transform.position : obj3.transform.TransformPoint(this.targetPosition.Value);
                    }
                    else
                    {
                        vector = this.targetPosition.Value;
                    }
                    if (this.keepVertical.Value)
                    {
                        vector.y = ownerDefaultTarget.transform.position.y;
                    }
                    Vector3 forward = vector - ownerDefaultTarget.transform.position;
                    if (forward.sqrMagnitude > 0f)
                    {
                        this.desiredRotation = Quaternion.LookRotation(forward, !this.upVector.IsNone ? this.upVector.Value : Vector3.up);
                    }
                    this.lastRotation = Quaternion.Slerp(this.lastRotation, this.desiredRotation, this.speed.Value * Time.deltaTime);
                    ownerDefaultTarget.transform.rotation = this.lastRotation;
                    if (this.debug.Value)
                    {
                        Debug.DrawLine(ownerDefaultTarget.transform.position, vector, Color.grey);
                    }
                    if (this.finishEvent != null)
                    {
                        Vector3 from = vector - ownerDefaultTarget.transform.position;
                        if (Mathf.Abs(Vector3.Angle(from, ownerDefaultTarget.transform.forward)) <= this.finishTolerance.Value)
                        {
                            base.Fsm.Event(this.finishEvent);
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.previousGo = null;
        }

        public override void OnLateUpdate()
        {
            this.DoSmoothLookAt();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.targetObject = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.targetPosition = vector;
            vector = new FsmVector3 {
                UseVariable = true
            };
            this.upVector = vector;
            this.keepVertical = 1;
            this.debug = 0;
            this.speed = 5f;
            this.finishTolerance = 1f;
            this.finishEvent = null;
        }
    }
}


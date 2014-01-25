namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Rotates a Game Object so its forward vector points at a Target. The Target can be specified as a GameObject or a world Position. If you specify both, then Position specifies a local offset from the target object's Position."), ActionCategory(ActionCategory.Transform)]
    public class LookAt : FsmStateAction
    {
        [Tooltip("Draw a debug line from the GameObject to the Target."), Title("Draw Debug Line")]
        public FsmBool debug;
        [Tooltip("Color to use for the debug line.")]
        public FsmColor debugLineColor;
        [Tooltip("Repeat every frame.")]
        public bool everyFrame = true;
        [Tooltip("The GameObject to rorate."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("Don't rotate vertically.")]
        public FsmBool keepVertical;
        [Tooltip("The GameObject to Look At.")]
        public FsmGameObject targetObject;
        [Tooltip("World position to look at, or local offset from Target Object if specified.")]
        public FsmVector3 targetPosition;
        [Tooltip("Rotate the GameObject to point its up direction vector in the direction hinted at by the Up Vector. See Unity Look At docs for more details.")]
        public FsmVector3 upVector;

        private void DoLookAt()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                GameObject obj3 = this.targetObject.Value;
                if ((obj3 != null) || !this.targetPosition.IsNone)
                {
                    Vector3 vector;
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
                    ownerDefaultTarget.transform.LookAt(vector, !this.upVector.IsNone ? this.upVector.Value : Vector3.up);
                    if (this.debug.Value)
                    {
                        Debug.DrawLine(ownerDefaultTarget.transform.position, vector, this.debugLineColor.Value);
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoLookAt();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnLateUpdate()
        {
            this.DoLookAt();
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
            this.debugLineColor = Color.yellow;
            this.everyFrame = true;
        }
    }
}


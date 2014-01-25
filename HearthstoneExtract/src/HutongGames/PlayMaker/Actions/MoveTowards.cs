namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Transform), Tooltip("Moves a Game Object towards a Target. Optionally sends an event when successful. The Target can be specified as a Game Object or a world Position. If you specify both, then the Position is used as a local offset from the Object's Position.")]
    public class MoveTowards : FsmStateAction
    {
        [Tooltip("Distance at which the move is considered finished, and the Finish Event is sent."), HasFloatSlider(0f, 5f)]
        public FsmFloat finishDistance;
        [Tooltip("Event to send when the Finish Distance is reached.")]
        public FsmEvent finishEvent;
        [RequiredField, Tooltip("The GameObject to Move")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Ignore any height difference in the target.")]
        public FsmBool ignoreVertical;
        [HasFloatSlider(0f, 20f), Tooltip("The maximum movement speed. HINT: You can make this a variable to change it over time.")]
        public FsmFloat maxSpeed;
        [Tooltip("A target GameObject to move towards. Or use a world Target Position below.")]
        public FsmGameObject targetObject;
        [Tooltip("A world position if no Target Object. Otherwise used as a local offset from the Target Object.")]
        public FsmVector3 targetPosition;

        private void DoMoveTowards()
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
                    if (this.ignoreVertical.Value)
                    {
                        vector.y = ownerDefaultTarget.transform.position.y;
                    }
                    ownerDefaultTarget.transform.position = Vector3.MoveTowards(ownerDefaultTarget.transform.position, vector, this.maxSpeed.Value * Time.deltaTime);
                    Vector3 vector3 = ownerDefaultTarget.transform.position - vector;
                    if (vector3.magnitude < this.finishDistance.Value)
                    {
                        base.Fsm.Event(this.finishEvent);
                        base.Finish();
                    }
                }
            }
        }

        public override void OnUpdate()
        {
            this.DoMoveTowards();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.targetObject = null;
            this.maxSpeed = 10f;
            this.finishDistance = 1f;
            this.finishEvent = null;
        }
    }
}


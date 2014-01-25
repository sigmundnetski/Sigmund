namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Instantly moves an object to a destination object's position or to a specified position vector."), ActionCategory(ActionCategory.Transform)]
    public class MoveToAction : FsmStateAction
    {
        [Tooltip("Move to a destination object's position.")]
        public FsmGameObject m_DestinationObject;
        public FsmOwnerDefault m_GameObject;
        [Tooltip("Whether Vector Position is in local or world space.")]
        public Space m_Space;
        [Tooltip("Move to a specific position vector. If Destination Object is defined, this is used as an offset.")]
        public FsmVector3 m_VectorPosition;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                this.SetPosition(ownerDefaultTarget.transform);
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            FsmGameObject obj2 = new FsmGameObject {
                UseVariable = true
            };
            this.m_DestinationObject = obj2;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.m_VectorPosition = vector;
            this.m_Space = Space.World;
        }

        private void SetPosition(Transform source)
        {
            Vector3 vector = !this.m_VectorPosition.IsNone ? this.m_VectorPosition.Value : Vector3.zero;
            if (!this.m_DestinationObject.IsNone && (this.m_DestinationObject.Value != null))
            {
                Transform transform = this.m_DestinationObject.Value.transform;
                source.position = transform.position;
                if (this.m_Space == Space.World)
                {
                    source.position += vector;
                }
                else
                {
                    source.localPosition += vector;
                }
            }
            else if (this.m_Space == Space.World)
            {
                source.position = vector;
            }
            else
            {
                source.localPosition = vector;
            }
        }
    }
}


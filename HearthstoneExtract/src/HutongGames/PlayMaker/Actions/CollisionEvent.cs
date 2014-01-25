namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Detect collisions between the Owner of this FSM and other Game Objects that have RigidBody components.\nNOTE: The system events, COLLISION ENTER, COLLISION STAY, and COLLISION EXIT are sent automatically on collisions with any object. Use this action to filter collisions by Tag."), ActionCategory(ActionCategory.Physics)]
    public class CollisionEvent : FsmStateAction
    {
        [UIHint(UIHint.Tag), Tooltip("Filter by Tag.")]
        public FsmString collideTag;
        [Tooltip("The type of collision to detect.")]
        public CollisionType collision;
        [Tooltip("Event to send if a collision is detected.")]
        public FsmEvent sendEvent;
        [Tooltip("Store the GameObject that collided with the Owner of this FSM."), UIHint(UIHint.Variable)]
        public FsmGameObject storeCollider;
        [UIHint(UIHint.Variable), Tooltip("Store the force of the collision. NOTE: Use Get Collision Info to get more info about the collision.")]
        public FsmFloat storeForce;

        public override void Awake()
        {
            switch (this.collision)
            {
                case CollisionType.OnCollisionEnter:
                    base.Fsm.HandleCollisionEnter = true;
                    break;

                case CollisionType.OnCollisionStay:
                    base.Fsm.HandleCollisionStay = true;
                    break;

                case CollisionType.OnCollisionExit:
                    base.Fsm.HandleCollisionExit = true;
                    break;
            }
        }

        public override void DoCollisionEnter(Collision collisionInfo)
        {
            if ((this.collision == CollisionType.OnCollisionEnter) && (collisionInfo.collider.gameObject.tag == this.collideTag.Value))
            {
                this.StoreCollisionInfo(collisionInfo);
                base.Fsm.Event(this.sendEvent);
            }
        }

        public override void DoCollisionExit(Collision collisionInfo)
        {
            if ((this.collision == CollisionType.OnCollisionExit) && (collisionInfo.collider.gameObject.tag == this.collideTag.Value))
            {
                this.StoreCollisionInfo(collisionInfo);
                base.Fsm.Event(this.sendEvent);
            }
        }

        public override void DoCollisionStay(Collision collisionInfo)
        {
            if ((this.collision == CollisionType.OnCollisionStay) && (collisionInfo.collider.gameObject.tag == this.collideTag.Value))
            {
                this.StoreCollisionInfo(collisionInfo);
                base.Fsm.Event(this.sendEvent);
            }
        }

        public override void DoControllerColliderHit(ControllerColliderHit collisionInfo)
        {
            if ((this.collision == CollisionType.OnControllerColliderHit) && (collisionInfo.collider.gameObject.tag == this.collideTag.Value))
            {
                if (this.storeCollider != null)
                {
                    this.storeCollider.Value = collisionInfo.gameObject;
                }
                this.storeForce.Value = 0f;
                base.Fsm.Event(this.sendEvent);
            }
        }

        public override string ErrorCheck()
        {
            return ActionHelpers.CheckOwnerPhysicsSetup(base.Owner);
        }

        public override void Reset()
        {
            this.collision = CollisionType.OnCollisionEnter;
            this.collideTag = "Untagged";
            this.sendEvent = null;
            this.storeCollider = null;
            this.storeForce = null;
        }

        private void StoreCollisionInfo(Collision collisionInfo)
        {
            this.storeCollider.Value = collisionInfo.gameObject;
            this.storeForce.Value = collisionInfo.relativeVelocity.magnitude;
        }
    }
}


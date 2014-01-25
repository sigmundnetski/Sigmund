namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Gets info on the last collision event and store in variables. See Unity Physics docs."), ActionCategory(ActionCategory.Physics)]
    public class GetCollisionInfo : FsmStateAction
    {
        [UIHint(UIHint.Variable), Tooltip("Get the collision normal vector. Useful for aligning spawned effects etc.")]
        public FsmVector3 contactNormal;
        [UIHint(UIHint.Variable), Tooltip("Get the world position of the collision contact. Useful for spawning effects etc.")]
        public FsmVector3 contactPoint;
        [UIHint(UIHint.Variable), Tooltip("Get the GameObject hit.")]
        public FsmGameObject gameObjectHit;
        [UIHint(UIHint.Variable), Tooltip("Get the name of the physics material of the colliding GameObject. Useful for triggering different effects. Audio, particles...")]
        public FsmString physicsMaterialName;
        [UIHint(UIHint.Variable), Tooltip("Get the relative speed of the collision. Useful for controlling reactions. E.g., selecting an appropriate sound fx.")]
        public FsmFloat relativeSpeed;
        [Tooltip("Get the relative velocity of the collision."), UIHint(UIHint.Variable)]
        public FsmVector3 relativeVelocity;

        public override void OnEnter()
        {
            this.StoreCollisionInfo();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObjectHit = null;
            this.relativeVelocity = null;
            this.relativeSpeed = null;
            this.contactPoint = null;
            this.contactNormal = null;
            this.physicsMaterialName = null;
        }

        private void StoreCollisionInfo()
        {
            if (base.Fsm.CollisionInfo != null)
            {
                this.gameObjectHit.Value = base.Fsm.CollisionInfo.gameObject;
                this.relativeSpeed.Value = base.Fsm.CollisionInfo.relativeVelocity.magnitude;
                this.relativeVelocity.Value = base.Fsm.CollisionInfo.relativeVelocity;
                this.physicsMaterialName.Value = base.Fsm.CollisionInfo.collider.material.name;
                if ((base.Fsm.CollisionInfo.contacts != null) && (base.Fsm.CollisionInfo.contacts.Length > 0))
                {
                    this.contactPoint.Value = base.Fsm.CollisionInfo.contacts[0].point;
                    this.contactNormal.Value = base.Fsm.CollisionInfo.contacts[0].normal;
                }
            }
        }
    }
}


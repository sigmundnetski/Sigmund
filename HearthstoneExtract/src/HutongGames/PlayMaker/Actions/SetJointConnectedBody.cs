namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Physics), Tooltip("Connect a joint to a game object.")]
    public class SetJointConnectedBody : FsmStateAction
    {
        [CheckForComponent(typeof(Joint)), Tooltip("The joint to connect. Requires a Joint component."), RequiredField]
        public FsmOwnerDefault joint;
        [Tooltip("The game object to connect to the Joint. Set to none to connect the Joint to the world."), CheckForComponent(typeof(Rigidbody))]
        public FsmGameObject rigidBody;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.joint);
            if (ownerDefaultTarget != null)
            {
                Joint component = ownerDefaultTarget.GetComponent<Joint>();
                if (component != null)
                {
                    component.connectedBody = (this.rigidBody.Value != null) ? this.rigidBody.Value.rigidbody : null;
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.joint = null;
            this.rigidBody = null;
        }
    }
}


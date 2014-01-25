namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Sets the Parent of a Game Object.")]
    public class SetParent : FsmStateAction
    {
        [Tooltip("The Game Object to parent."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("The new parent for the Game Object.")]
        public FsmGameObject parent;
        [Tooltip("Set the local position to 0,0,0 after parenting.")]
        public FsmBool resetLocalPosition;
        [Tooltip("Set the local rotation to 0,0,0 after parenting.")]
        public FsmBool resetLocalRotation;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                ownerDefaultTarget.transform.parent = (this.parent.Value != null) ? this.parent.Value.transform : null;
                if (this.resetLocalPosition.Value)
                {
                    ownerDefaultTarget.transform.localPosition = Vector3.zero;
                }
                if (this.resetLocalRotation.Value)
                {
                    ownerDefaultTarget.transform.localRotation = Quaternion.identity;
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.parent = null;
            this.resetLocalPosition = null;
            this.resetLocalRotation = null;
        }
    }
}


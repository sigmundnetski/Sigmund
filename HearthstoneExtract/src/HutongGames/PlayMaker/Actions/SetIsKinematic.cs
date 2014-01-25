namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Controls whether physics affects the Game Object."), ActionCategory(ActionCategory.Physics)]
    public class SetIsKinematic : FsmStateAction
    {
        [CheckForComponent(typeof(Rigidbody)), RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField]
        public FsmBool isKinematic;

        private void DoSetIsKinematic()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.rigidbody != null))
            {
                ownerDefaultTarget.rigidbody.isKinematic = this.isKinematic.Value;
            }
        }

        public override void OnEnter()
        {
            this.DoSetIsKinematic();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.isKinematic = 0;
        }
    }
}


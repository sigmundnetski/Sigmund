namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets whether a Game Object's Rigidy Body is affected by Gravity."), ActionCategory(ActionCategory.Physics)]
    public class UseGravity : FsmStateAction
    {
        [CheckForComponent(typeof(Rigidbody)), RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField]
        public FsmBool useGravity;

        private void DoUseGravity()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.rigidbody != null))
            {
                ownerDefaultTarget.rigidbody.useGravity = this.useGravity.Value;
            }
        }

        public override void OnEnter()
        {
            this.DoUseGravity();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.useGravity = 1;
        }
    }
}


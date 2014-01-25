namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Gets the number of children that a GameObject has.")]
    public class GetChildCount : FsmStateAction
    {
        [RequiredField, Tooltip("The GameObject to test.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Store the number of children in an int variable."), RequiredField, UIHint(UIHint.Variable)]
        public FsmInt storeResult;

        private void DoGetChildCount()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                this.storeResult.Value = ownerDefaultTarget.transform.childCount;
            }
        }

        public override void OnEnter()
        {
            this.DoGetChildCount();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.storeResult = null;
        }
    }
}


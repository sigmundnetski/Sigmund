namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Physics), Tooltip("Gets the Mass of a Game Object's Rigid Body.")]
    public class GetMass : FsmStateAction
    {
        [RequiredField, CheckForComponent(typeof(Rigidbody))]
        public FsmOwnerDefault gameObject;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmFloat storeResult;

        private void DoGetMass()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.rigidbody != null))
            {
                this.storeResult.Value = ownerDefaultTarget.rigidbody.mass;
            }
        }

        public override void OnEnter()
        {
            this.DoGetMass();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.storeResult = null;
        }
    }
}


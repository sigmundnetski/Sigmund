namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Transform), Tooltip("Transforms a Direction from world space to a Game Object's local space. The opposite of TransformDirection.")]
    public class InverseTransformDirection : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmVector3 storeResult;
        [RequiredField]
        public FsmVector3 worldDirection;

        private void DoInverseTransformDirection()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                this.storeResult.Value = ownerDefaultTarget.transform.InverseTransformDirection(this.worldDirection.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoInverseTransformDirection();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoInverseTransformDirection();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.worldDirection = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}


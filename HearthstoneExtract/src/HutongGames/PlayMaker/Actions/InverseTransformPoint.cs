namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Transform), Tooltip("Transforms position from world space to a Game Object's local space. The opposite of TransformPoint.")]
    public class InverseTransformPoint : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmVector3 storeResult;
        [RequiredField]
        public FsmVector3 worldPosition;

        private void DoInverseTransformPoint()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                this.storeResult.Value = ownerDefaultTarget.transform.InverseTransformPoint(this.worldPosition.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoInverseTransformPoint();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoInverseTransformPoint();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.worldPosition = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}


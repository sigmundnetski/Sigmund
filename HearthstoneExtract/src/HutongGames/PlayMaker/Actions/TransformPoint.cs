namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Transforms a Position from a Game Object's local space to world space."), ActionCategory(ActionCategory.Transform)]
    public class TransformPoint : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField]
        public FsmVector3 localPosition;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmVector3 storeResult;

        private void DoTransformPoint()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                this.storeResult.Value = ownerDefaultTarget.transform.TransformPoint(this.localPosition.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoTransformPoint();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoTransformPoint();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.localPosition = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}


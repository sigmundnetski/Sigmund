namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Get the value of an Object Variable from another FSM.")]
    public class GetFsmObject : FsmStateAction
    {
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        protected PlayMakerFSM fsm;
        [UIHint(UIHint.FsmName), Tooltip("Optional name of FSM on Game Object")]
        public FsmString fsmName;
        [RequiredField, Tooltip("The GameObject that owns the FSM.")]
        public FsmOwnerDefault gameObject;
        private GameObject goLastFrame;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmObject storeValue;
        [UIHint(UIHint.FsmObject), RequiredField]
        public FsmString variableName;

        private void DoGetFsmVariable()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                if (ownerDefaultTarget != this.goLastFrame)
                {
                    this.goLastFrame = ownerDefaultTarget;
                    this.fsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, this.fsmName.Value);
                }
                if ((this.fsm != null) && (this.storeValue != null))
                {
                    FsmObject fsmObject = this.fsm.FsmVariables.GetFsmObject(this.variableName.Value);
                    if (fsmObject != null)
                    {
                        this.storeValue.Value = fsmObject.Value;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoGetFsmVariable();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetFsmVariable();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.fsmName = string.Empty;
            this.variableName = string.Empty;
            this.storeValue = null;
            this.everyFrame = false;
        }
    }
}


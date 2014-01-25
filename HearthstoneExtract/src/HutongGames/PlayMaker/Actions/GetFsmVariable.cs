namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Get the value of a variable in another FSM and store it in a variable of the same name in this FSM.")]
    public class GetFsmVariable : FsmStateAction
    {
        private GameObject cachedGO;
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        [UIHint(UIHint.FsmName), Tooltip("Optional name of FSM on Game Object")]
        public FsmString fsmName;
        [RequiredField, Tooltip("The GameObject that owns the FSM")]
        public FsmOwnerDefault gameObject;
        private PlayMakerFSM sourceFsm;
        private INamedVariable sourceVariable;
        [UIHint(UIHint.Variable), RequiredField, HideTypeFilter]
        public FsmVar storeValue;
        private NamedVariable targetVariable;

        private void DoGetFsmVariable()
        {
            if (!this.storeValue.IsNone)
            {
                this.InitFsmVar();
                this.storeValue.GetValueFrom(this.sourceVariable);
                this.storeValue.ApplyValueTo(this.targetVariable);
            }
        }

        private void InitFsmVar()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget != this.cachedGO))
            {
                this.sourceFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, this.fsmName.Value);
                this.sourceVariable = this.sourceFsm.FsmVariables.GetVariable(this.storeValue.variableName);
                this.targetVariable = base.Fsm.Variables.GetVariable(this.storeValue.variableName);
                this.storeValue.Type = FsmUtility.GetVariableType(this.targetVariable);
                if (!string.IsNullOrEmpty(this.storeValue.variableName) && (this.sourceVariable == null))
                {
                    this.LogWarning("Missing Variable: " + this.storeValue.variableName);
                }
                this.cachedGO = ownerDefaultTarget;
            }
        }

        public override void OnEnter()
        {
            this.InitFsmVar();
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
            this.storeValue = new FsmVar();
        }
    }
}


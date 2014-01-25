namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Set the value of a variable in another FSM.")]
    public class SetFsmVariable : FsmStateAction
    {
        private GameObject cachedGO;
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        [UIHint(UIHint.FsmName), Tooltip("Optional name of FSM on Game Object")]
        public FsmString fsmName;
        [Tooltip("The GameObject that owns the FSM"), RequiredField]
        public FsmOwnerDefault gameObject;
        [HideTypeFilter, RequiredField]
        public FsmVar setValue;
        private PlayMakerFSM sourceFsm;
        private INamedVariable sourceVariable;
        private NamedVariable targetVariable;
        public FsmString variableName;

        private void DoGetFsmVariable()
        {
            if (!this.setValue.IsNone)
            {
                this.InitFsmVar();
                this.setValue.GetValueFrom(this.sourceVariable);
                this.setValue.ApplyValueTo(this.targetVariable);
            }
        }

        private void InitFsmVar()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget != this.cachedGO))
            {
                this.sourceFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, this.fsmName.Value);
                this.sourceVariable = this.sourceFsm.FsmVariables.GetVariable(this.setValue.variableName);
                this.targetVariable = base.Fsm.Variables.GetVariable(this.setValue.variableName);
                this.setValue.Type = FsmUtility.GetVariableType(this.targetVariable);
                if (!string.IsNullOrEmpty(this.setValue.variableName) && (this.sourceVariable == null))
                {
                    this.LogWarning("Missing Variable: " + this.setValue.variableName);
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
            this.setValue = new FsmVar();
        }
    }
}


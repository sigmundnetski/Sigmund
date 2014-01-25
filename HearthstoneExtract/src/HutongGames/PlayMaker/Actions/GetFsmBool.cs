namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Get the value of a Bool Variable from another FSM.")]
    public class GetFsmBool : FsmStateAction
    {
        public bool everyFrame;
        private PlayMakerFSM fsm;
        [Tooltip("Optional name of FSM on Game Object"), UIHint(UIHint.FsmName)]
        public FsmString fsmName;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        private GameObject goLastFrame;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmBool storeValue;
        [RequiredField, UIHint(UIHint.FsmBool)]
        public FsmString variableName;

        private void DoGetFsmBool()
        {
            if (this.storeValue != null)
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                if (ownerDefaultTarget != null)
                {
                    if (ownerDefaultTarget != this.goLastFrame)
                    {
                        this.goLastFrame = ownerDefaultTarget;
                        this.fsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, this.fsmName.Value);
                    }
                    if (this.fsm != null)
                    {
                        FsmBool fsmBool = this.fsm.FsmVariables.GetFsmBool(this.variableName.Value);
                        if (fsmBool != null)
                        {
                            this.storeValue.Value = fsmBool.Value;
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoGetFsmBool();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetFsmBool();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.fsmName = string.Empty;
            this.storeValue = null;
        }
    }
}


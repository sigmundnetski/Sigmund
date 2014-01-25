namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Get the value of a Color Variable from another FSM.")]
    public class GetFsmColor : FsmStateAction
    {
        public bool everyFrame;
        private PlayMakerFSM fsm;
        [Tooltip("Optional name of FSM on Game Object"), UIHint(UIHint.FsmName)]
        public FsmString fsmName;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        private GameObject goLastFrame;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmColor storeValue;
        [UIHint(UIHint.FsmColor), RequiredField]
        public FsmString variableName;

        private void DoGetFsmColor()
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
                        FsmColor fsmColor = this.fsm.FsmVariables.GetFsmColor(this.variableName.Value);
                        if (fsmColor != null)
                        {
                            this.storeValue.Value = fsmColor.Value;
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoGetFsmColor();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetFsmColor();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.fsmName = string.Empty;
            this.storeValue = null;
        }
    }
}


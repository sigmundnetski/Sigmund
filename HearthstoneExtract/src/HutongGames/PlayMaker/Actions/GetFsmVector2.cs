namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Get the value of a Vector2 Variable from another FSM.")]
    public class GetFsmVector2 : FsmStateAction
    {
        public bool everyFrame;
        private PlayMakerFSM fsm;
        [Tooltip("Optional name of FSM on Game Object"), UIHint(UIHint.FsmName)]
        public FsmString fsmName;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        private GameObject goLastFrame;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmVector2 storeValue;
        [RequiredField, UIHint(UIHint.FsmVector2)]
        public FsmString variableName;

        private void DoGetFsmVector2()
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
                        FsmVector2 vector = this.fsm.FsmVariables.GetFsmVector2(this.variableName.Value);
                        if (vector != null)
                        {
                            this.storeValue.Value = vector.Value;
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoGetFsmVector2();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetFsmVector2();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.fsmName = string.Empty;
            this.storeValue = null;
        }
    }
}


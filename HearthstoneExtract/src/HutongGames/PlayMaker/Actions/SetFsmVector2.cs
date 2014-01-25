namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Set the value of a Vector2 Variable in another FSM."), ActionCategory(ActionCategory.StateMachine)]
    public class SetFsmVector2 : FsmStateAction
    {
        [Tooltip("Repeat every frame. Useful if the value is changing.")]
        public bool everyFrame;
        private PlayMakerFSM fsm;
        [UIHint(UIHint.FsmName), Tooltip("Optional name of FSM on Game Object")]
        public FsmString fsmName;
        [RequiredField, Tooltip("The GameObject that owns the FSM.")]
        public FsmOwnerDefault gameObject;
        private GameObject goLastFrame;
        [RequiredField, Tooltip("Set the value of the variable.")]
        public FsmVector2 setValue;
        [Tooltip("The name of the FSM variable."), UIHint(UIHint.FsmVector2), RequiredField]
        public FsmString variableName;

        private void DoSetFsmVector2()
        {
            if (this.setValue != null)
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                if (ownerDefaultTarget != null)
                {
                    if (ownerDefaultTarget != this.goLastFrame)
                    {
                        this.goLastFrame = ownerDefaultTarget;
                        this.fsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, this.fsmName.Value);
                    }
                    if (this.fsm == null)
                    {
                        this.LogWarning("Could not find FSM: " + this.fsmName.Value);
                    }
                    else
                    {
                        FsmVector2 vector = this.fsm.FsmVariables.GetFsmVector2(this.variableName.Value);
                        if (vector != null)
                        {
                            vector.Value = this.setValue.Value;
                        }
                        else
                        {
                            this.LogWarning("Could not find variable: " + this.variableName.Value);
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetFsmVector2();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetFsmVector2();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.fsmName = string.Empty;
            this.setValue = null;
        }
    }
}


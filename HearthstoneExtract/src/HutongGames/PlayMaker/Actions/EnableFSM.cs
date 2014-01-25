namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Enables/Disables an FSM component on a GameObject."), ActionCategory(ActionCategory.StateMachine)]
    public class EnableFSM : FsmStateAction
    {
        [Tooltip("Set to True to enable, False to disable.")]
        public FsmBool enable;
        private PlayMakerFSM fsmComponent;
        [Tooltip("Optional name of FSM on GameObject. Useful if you have more than one FSM on a GameObject."), UIHint(UIHint.FsmName)]
        public FsmString fsmName;
        [Tooltip("The GameObject that owns the FSM component."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("Reset the initial enabled state when exiting the state.")]
        public FsmBool resetOnExit;

        private void DoEnableFSM()
        {
            GameObject obj2 = (this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner;
            if (obj2 != null)
            {
                if (!string.IsNullOrEmpty(this.fsmName.Value))
                {
                    foreach (PlayMakerFSM rfsm in obj2.GetComponents<PlayMakerFSM>())
                    {
                        if (rfsm.FsmName == this.fsmName.Value)
                        {
                            this.fsmComponent = rfsm;
                            break;
                        }
                    }
                }
                else
                {
                    this.fsmComponent = obj2.GetComponent<PlayMakerFSM>();
                }
                if (this.fsmComponent == null)
                {
                    this.LogError("Missing FsmComponent!");
                }
                else
                {
                    this.fsmComponent.enabled = this.enable.Value;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoEnableFSM();
            base.Finish();
        }

        public override void OnExit()
        {
            if ((this.fsmComponent != null) && this.resetOnExit.Value)
            {
                this.fsmComponent.enabled = !this.enable.Value;
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.fsmName = string.Empty;
            this.enable = 1;
            this.resetOnExit = 1;
        }
    }
}


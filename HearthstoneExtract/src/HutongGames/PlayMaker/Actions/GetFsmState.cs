namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets the name of the specified FSMs current state. Either reference the fsm component directly, or find it on a game object."), ActionCategory(ActionCategory.StateMachine)]
    public class GetFsmState : FsmStateAction
    {
        public bool everyFrame;
        private PlayMakerFSM fsm;
        public PlayMakerFSM fsmComponent;
        [Tooltip("Optional name of Fsm on Game Object"), UIHint(UIHint.FsmName)]
        public FsmString fsmName;
        public FsmOwnerDefault gameObject;
        [UIHint(UIHint.Variable)]
        public FsmString storeResult;

        private void DoGetFsmState()
        {
            if (this.fsm == null)
            {
                if (this.fsmComponent != null)
                {
                    this.fsm = this.fsmComponent;
                }
                else
                {
                    GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                    if (ownerDefaultTarget != null)
                    {
                        this.fsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, this.fsmName.Value);
                    }
                }
                if (this.fsm == null)
                {
                    this.storeResult.Value = string.Empty;
                    return;
                }
            }
            this.storeResult.Value = this.fsm.ActiveStateName;
        }

        public override void OnEnter()
        {
            this.DoGetFsmState();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetFsmState();
        }

        public override void Reset()
        {
            this.fsmComponent = null;
            this.gameObject = null;
            this.fsmName = string.Empty;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}


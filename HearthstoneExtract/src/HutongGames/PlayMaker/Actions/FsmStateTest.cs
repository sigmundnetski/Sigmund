namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Tests if an FSM is in the specified State."), ActionCategory(ActionCategory.Logic)]
    public class FsmStateTest : FsmStateAction
    {
        [Tooltip("Repeat every frame. Useful if you're waiting for a particular state.")]
        public bool everyFrame;
        [Tooltip("Event to send if the FSM is NOT in the specified state.")]
        public FsmEvent falseEvent;
        private PlayMakerFSM fsm;
        [Tooltip("Optional name of Fsm on Game Object. Useful if there is more than one FSM on the GameObject."), UIHint(UIHint.FsmName)]
        public FsmString fsmName;
        [Tooltip("The GameObject that owns the FSM."), RequiredField]
        public FsmGameObject gameObject;
        private GameObject previousGo;
        [Tooltip("Check to see if the FSM is in this state."), RequiredField]
        public FsmString stateName;
        [UIHint(UIHint.Variable), Tooltip("Store the result of this test in a bool variable. Useful if other actions depend on this test.")]
        public FsmBool storeResult;
        [Tooltip("Event to send if the FSM is in the specified state.")]
        public FsmEvent trueEvent;

        private void DoFsmStateTest()
        {
            GameObject go = this.gameObject.Value;
            if (go != null)
            {
                if (go != this.previousGo)
                {
                    this.fsm = ActionHelpers.GetGameObjectFsm(go, this.fsmName.Value);
                    this.previousGo = go;
                }
                if (this.fsm != null)
                {
                    bool flag = false;
                    if (this.fsm.ActiveStateName == this.stateName.Value)
                    {
                        base.Fsm.Event(this.trueEvent);
                        flag = true;
                    }
                    else
                    {
                        base.Fsm.Event(this.falseEvent);
                    }
                    this.storeResult.Value = flag;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoFsmStateTest();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoFsmStateTest();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.fsmName = null;
            this.stateName = null;
            this.trueEvent = null;
            this.falseEvent = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}


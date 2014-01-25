namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Logic), Tooltip("Sends Events based on the current State of an FSM.")]
    public class FsmStateSwitch : FsmStateAction
    {
        [CompoundArray("State Switches", "Compare State", "Send Event")]
        public FsmString[] compareTo;
        [Tooltip("Repeat every frame. Useful if you're waiting for a particular result.")]
        public bool everyFrame;
        private PlayMakerFSM fsm;
        [Tooltip("Optional name of Fsm on GameObject. Useful if there is more than one FSM on the GameObject."), UIHint(UIHint.FsmName)]
        public FsmString fsmName;
        [RequiredField, Tooltip("The GameObject that owns the FSM.")]
        public FsmGameObject gameObject;
        private GameObject previousGo;
        public FsmEvent[] sendEvent;

        private void DoFsmStateSwitch()
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
                    string activeStateName = this.fsm.ActiveStateName;
                    for (int i = 0; i < this.compareTo.Length; i++)
                    {
                        if (activeStateName == this.compareTo[i].Value)
                        {
                            base.Fsm.Event(this.sendEvent[i]);
                            return;
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoFsmStateSwitch();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoFsmStateSwitch();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.fsmName = null;
            this.compareTo = new FsmString[1];
            this.sendEvent = new FsmEvent[1];
            this.everyFrame = false;
        }
    }
}


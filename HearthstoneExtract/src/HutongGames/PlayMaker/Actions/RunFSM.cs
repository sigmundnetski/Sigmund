namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Creates an FSM from a saved FSM Template.")]
    public class RunFSM : FsmStateAction
    {
        [Tooltip("Event to send when the FSM has finished (usually because it ran a Finish FSM action).")]
        public FsmEvent finishEvent;
        public FsmTemplateControl fsmTemplateControl = new FsmTemplateControl();
        private Fsm runFsm;
        [UIHint(UIHint.Variable)]
        public FsmInt storeID;

        public override void Awake()
        {
            if ((this.fsmTemplateControl.fsmTemplate != null) && Application.isPlaying)
            {
                this.runFsm = base.Fsm.CreateSubFsm(this.fsmTemplateControl);
            }
        }

        private void CheckIfFinished()
        {
            if ((this.runFsm == null) || this.runFsm.Finished)
            {
                base.Fsm.Event(this.finishEvent);
                base.Finish();
            }
        }

        public override bool Event(FsmEvent fsmEvent)
        {
            if ((this.runFsm != null) && (fsmEvent.IsGlobal || fsmEvent.IsSystemEvent))
            {
                this.runFsm.Event(fsmEvent);
            }
            return false;
        }

        public override void OnEnter()
        {
            if (this.runFsm == null)
            {
                base.Finish();
            }
            else
            {
                this.runFsm.OnEnable();
                this.runFsm.Start();
                this.storeID.Value = this.fsmTemplateControl.ID;
                this.CheckIfFinished();
            }
        }

        public override void OnExit()
        {
            if (this.runFsm != null)
            {
                this.runFsm.Stop();
            }
        }

        public override void OnFixedUpdate()
        {
            if (this.runFsm != null)
            {
                this.runFsm.FixedUpdate();
                this.CheckIfFinished();
            }
            else
            {
                base.Finish();
            }
        }

        public override void OnLateUpdate()
        {
            if (this.runFsm != null)
            {
                this.runFsm.LateUpdate();
                this.CheckIfFinished();
            }
            else
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            if (this.runFsm != null)
            {
                this.runFsm.Update();
                this.CheckIfFinished();
            }
            else
            {
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.fsmTemplateControl = new FsmTemplateControl();
            this.storeID = null;
            this.runFsm = null;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Is Editor Running sends Events based on the result."), ActionCategory(ActionCategory.Application)]
    public class IsEditorRunningAction : FsmStateAction
    {
        [Tooltip("Event to use if Editor is NOT running.")]
        public FsmEvent falseEvent;
        [Tooltip("Store the true/false result in a bool variable."), UIHint(UIHint.Variable)]
        public FsmBool storeResult;
        [Tooltip("Event to use if Editor is running."), RequiredField]
        public FsmEvent trueEvent;

        private void IsEditorRunning()
        {
            this.storeResult.Value = GeneralUtils.IsEditorPlaying();
            if (this.storeResult.Value)
            {
                base.Fsm.Event(this.trueEvent);
            }
            else
            {
                base.Fsm.Event(this.falseEvent);
            }
        }

        public override void OnEnter()
        {
            this.IsEditorRunning();
            base.Finish();
        }

        public override void OnUpdate()
        {
            this.IsEditorRunning();
        }

        public override void Reset()
        {
            this.trueEvent = null;
            this.falseEvent = null;
            this.storeResult = null;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Logic), Tooltip("Tests if the value of a Bool Variable has changed. Use this to send an event on change, or store a bool that can be used in other operations.")]
    public class BoolChanged : FsmStateAction
    {
        [RequiredField, Tooltip("The Bool variable to watch for changes."), UIHint(UIHint.Variable)]
        public FsmBool boolVariable;
        [Tooltip("Event to send if the variable changes.")]
        public FsmEvent changedEvent;
        private bool previousValue;
        [Tooltip("Set to True if changed."), UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public override void OnEnter()
        {
            if (this.boolVariable.IsNone)
            {
                base.Finish();
            }
            else
            {
                this.previousValue = this.boolVariable.Value;
            }
        }

        public override void OnUpdate()
        {
            this.storeResult.Value = false;
            if (this.boolVariable.Value != this.previousValue)
            {
                this.storeResult.Value = true;
                base.Fsm.Event(this.changedEvent);
            }
        }

        public override void Reset()
        {
            this.boolVariable = null;
            this.changedEvent = null;
            this.storeResult = null;
        }
    }
}


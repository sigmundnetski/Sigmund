namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Tests if the value of a string variable has changed. Use this to send an event on change, or store a bool that can be used in other operations."), ActionCategory(ActionCategory.Logic)]
    public class StringChanged : FsmStateAction
    {
        public FsmEvent changedEvent;
        private string previousValue;
        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmString stringVariable;

        public override void OnEnter()
        {
            if (this.stringVariable.IsNone)
            {
                base.Finish();
            }
            else
            {
                this.previousValue = this.stringVariable.Value;
            }
        }

        public override void OnUpdate()
        {
            if (this.stringVariable.Value != this.previousValue)
            {
                this.storeResult.Value = true;
                base.Fsm.Event(this.changedEvent);
            }
        }

        public override void Reset()
        {
            this.stringVariable = null;
            this.changedEvent = null;
            this.storeResult = null;
        }
    }
}


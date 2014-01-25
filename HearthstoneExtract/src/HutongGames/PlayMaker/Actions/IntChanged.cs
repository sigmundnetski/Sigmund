namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Logic), Tooltip("Tests if the value of an integer variable changed. Use this to send an event on change, or store a bool that can be used in other operations.")]
    public class IntChanged : FsmStateAction
    {
        public FsmEvent changedEvent;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmInt intVariable;
        private int previousValue;
        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public override void OnEnter()
        {
            if (this.intVariable.IsNone)
            {
                base.Finish();
            }
            else
            {
                this.previousValue = this.intVariable.Value;
            }
        }

        public override void OnUpdate()
        {
            this.storeResult.Value = false;
            if (this.intVariable.Value != this.previousValue)
            {
                this.previousValue = this.intVariable.Value;
                this.storeResult.Value = true;
                base.Fsm.Event(this.changedEvent);
            }
        }

        public override void Reset()
        {
            this.intVariable = null;
            this.changedEvent = null;
            this.storeResult = null;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Compares 2 Strings and sends Events based on the result."), ActionCategory(ActionCategory.Logic)]
    public class StringCompare : FsmStateAction
    {
        public FsmString compareTo;
        public FsmEvent equalEvent;
        [Tooltip("Repeat every frame. Useful if any of the strings are changing over time.")]
        public bool everyFrame;
        public FsmEvent notEqualEvent;
        [UIHint(UIHint.Variable), Tooltip("Store the true/false result in a bool variable.")]
        public FsmBool storeResult;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmString stringVariable;

        private void DoStringCompare()
        {
            if ((this.stringVariable != null) && (this.compareTo != null))
            {
                bool flag = this.stringVariable.Value == this.compareTo.Value;
                if (this.storeResult != null)
                {
                    this.storeResult.Value = flag;
                }
                if (flag && (this.equalEvent != null))
                {
                    base.Fsm.Event(this.equalEvent);
                }
                else if (!flag && (this.notEqualEvent != null))
                {
                    base.Fsm.Event(this.notEqualEvent);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoStringCompare();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoStringCompare();
        }

        public override void Reset()
        {
            this.stringVariable = null;
            this.compareTo = string.Empty;
            this.equalEvent = null;
            this.notEqualEvent = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Tests if a String contains another String."), ActionCategory(ActionCategory.Logic)]
    public class StringContains : FsmStateAction
    {
        [RequiredField, Tooltip("Test if the String variable contains this string.")]
        public FsmString containsString;
        [Tooltip("Repeat every frame. Useful if any of the strings are changing over time.")]
        public bool everyFrame;
        [Tooltip("Event to send if false.")]
        public FsmEvent falseEvent;
        [Tooltip("Store the true/false result in a bool variable."), UIHint(UIHint.Variable)]
        public FsmBool storeResult;
        [RequiredField, Tooltip("The String variable to test."), UIHint(UIHint.Variable)]
        public FsmString stringVariable;
        [Tooltip("Event to send if true.")]
        public FsmEvent trueEvent;

        private void DoStringContains()
        {
            if (!this.stringVariable.IsNone && !this.containsString.IsNone)
            {
                bool flag = this.stringVariable.Value.Contains(this.containsString.Value);
                if (this.storeResult != null)
                {
                    this.storeResult.Value = flag;
                }
                if (flag && (this.trueEvent != null))
                {
                    base.Fsm.Event(this.trueEvent);
                }
                else if (!flag && (this.falseEvent != null))
                {
                    base.Fsm.Event(this.falseEvent);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoStringContains();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoStringContains();
        }

        public override void Reset()
        {
            this.stringVariable = null;
            this.containsString = string.Empty;
            this.trueEvent = null;
            this.falseEvent = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}


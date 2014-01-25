namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Debug), Tooltip("Logs the value of an Integer Variable in the PlayMaker Log Window.")]
    public class DebugInt : FsmStateAction
    {
        [Tooltip("Prints the value of an Int variable in the PlayMaker log window."), UIHint(UIHint.Variable)]
        public FsmInt intVariable;
        [Tooltip("Info, Warning, or Error.")]
        public HutongGames.PlayMaker.LogLevel logLevel;

        public override void OnEnter()
        {
            string text = "None";
            if (!this.intVariable.IsNone)
            {
                text = this.intVariable.Name + ": " + this.intVariable.Value;
            }
            ActionHelpers.DebugLog(base.Fsm, this.logLevel, text);
            base.Finish();
        }

        public override void Reset()
        {
            this.logLevel = HutongGames.PlayMaker.LogLevel.Info;
            this.intVariable = null;
        }
    }
}


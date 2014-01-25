namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Logs the value of an Object Variable in the PlayMaker Log Window."), ActionCategory(ActionCategory.Debug)]
    public class DebugObject : FsmStateAction
    {
        [UIHint(UIHint.Variable), Tooltip("Prints the value of an Object variable in the PlayMaker log window.")]
        public FsmObject fsmObject;
        [Tooltip("Info, Warning, or Error.")]
        public HutongGames.PlayMaker.LogLevel logLevel;

        public override void OnEnter()
        {
            string text = "None";
            if (!this.fsmObject.IsNone)
            {
                text = this.fsmObject.Name + ": " + this.fsmObject;
            }
            ActionHelpers.DebugLog(base.Fsm, this.logLevel, text);
            base.Finish();
        }

        public override void Reset()
        {
            this.logLevel = HutongGames.PlayMaker.LogLevel.Info;
            this.fsmObject = null;
        }
    }
}


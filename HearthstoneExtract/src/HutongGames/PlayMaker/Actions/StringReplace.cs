namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Replace a substring with a new String."), ActionCategory(ActionCategory.String)]
    public class StringReplace : FsmStateAction
    {
        public bool everyFrame;
        public FsmString replace;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmString storeResult;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmString stringVariable;
        public FsmString with;

        private void DoReplace()
        {
            if ((this.stringVariable != null) && (this.storeResult != null))
            {
                this.storeResult.Value = this.stringVariable.Value.Replace(this.replace.Value, this.with.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoReplace();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoReplace();
        }

        public override void Reset()
        {
            this.stringVariable = null;
            this.replace = string.Empty;
            this.with = string.Empty;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}


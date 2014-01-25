namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.String), Tooltip("Gets the Right n characters from a String.")]
    public class GetStringRight : FsmStateAction
    {
        public FsmInt charCount;
        public bool everyFrame;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmString storeResult;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmString stringVariable;

        private void DoGetStringRight()
        {
            if ((this.stringVariable != null) && (this.storeResult != null))
            {
                string str = this.stringVariable.Value;
                this.storeResult.Value = str.Substring(str.Length - this.charCount.Value, this.charCount.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoGetStringRight();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetStringRight();
        }

        public override void Reset()
        {
            this.stringVariable = null;
            this.charCount = 0;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}


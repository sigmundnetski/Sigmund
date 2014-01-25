namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.String), Tooltip("Gets the Left n characters from a String Variable.")]
    public class GetStringLeft : FsmStateAction
    {
        public FsmInt charCount;
        public bool everyFrame;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmString storeResult;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmString stringVariable;

        private void DoGetStringLeft()
        {
            if ((this.stringVariable != null) && (this.storeResult != null))
            {
                this.storeResult.Value = this.stringVariable.Value.Substring(0, this.charCount.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoGetStringLeft();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetStringLeft();
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


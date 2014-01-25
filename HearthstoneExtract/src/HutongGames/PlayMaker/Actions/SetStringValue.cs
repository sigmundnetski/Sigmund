namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.String), Tooltip("Sets the value of a String Variable.")]
    public class SetStringValue : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmString stringValue;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmString stringVariable;

        private void DoSetStringValue()
        {
            if ((this.stringVariable != null) && (this.stringValue != null))
            {
                this.stringVariable.Value = this.stringValue.Value;
            }
        }

        public override void OnEnter()
        {
            this.DoSetStringValue();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetStringValue();
        }

        public override void Reset()
        {
            this.stringVariable = null;
            this.stringValue = null;
            this.everyFrame = false;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Converts a Bool value to a String value."), ActionCategory(ActionCategory.Convert)]
    public class ConvertBoolToString : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Variable), Tooltip("The Bool variable to test.")]
        public FsmBool boolVariable;
        [Tooltip("Repeat every frame. Useful if the Bool variable is changing.")]
        public bool everyFrame;
        [Tooltip("String value if Bool variable is false.")]
        public FsmString falseString;
        [UIHint(UIHint.Variable), Tooltip("The String variable to set based on the Bool variable value."), RequiredField]
        public FsmString stringVariable;
        [Tooltip("String value if Bool variable is true.")]
        public FsmString trueString;

        private void DoConvertBoolToString()
        {
            this.stringVariable.Value = !this.boolVariable.Value ? this.falseString.Value : this.trueString.Value;
        }

        public override void OnEnter()
        {
            this.DoConvertBoolToString();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoConvertBoolToString();
        }

        public override void Reset()
        {
            this.boolVariable = null;
            this.stringVariable = null;
            this.falseString = "False";
            this.trueString = "True";
            this.everyFrame = false;
        }
    }
}


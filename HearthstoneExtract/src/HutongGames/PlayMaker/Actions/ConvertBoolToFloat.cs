namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Converts a Bool value to a Float value."), ActionCategory(ActionCategory.Convert)]
    public class ConvertBoolToFloat : FsmStateAction
    {
        [UIHint(UIHint.Variable), RequiredField, Tooltip("The Bool variable to test.")]
        public FsmBool boolVariable;
        [Tooltip("Repeat every frame. Useful if the Bool variable is changing.")]
        public bool everyFrame;
        [Tooltip("Float value if Bool variable is false.")]
        public FsmFloat falseValue;
        [Tooltip("The Float variable to set based on the Bool variable value."), UIHint(UIHint.Variable), RequiredField]
        public FsmFloat floatVariable;
        [Tooltip("Float value if Bool variable is true.")]
        public FsmFloat trueValue;

        private void DoConvertBoolToFloat()
        {
            this.floatVariable.Value = !this.boolVariable.Value ? this.falseValue.Value : this.trueValue.Value;
        }

        public override void OnEnter()
        {
            this.DoConvertBoolToFloat();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoConvertBoolToFloat();
        }

        public override void Reset()
        {
            this.boolVariable = null;
            this.floatVariable = null;
            this.falseValue = 0f;
            this.trueValue = 1f;
            this.everyFrame = false;
        }
    }
}


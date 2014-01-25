namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Convert), Tooltip("Converts an Integer value to a Float value.")]
    public class ConvertIntToFloat : FsmStateAction
    {
        [Tooltip("Repeat every frame. Useful if the Integer variable is changing.")]
        public bool everyFrame;
        [Tooltip("Store the result in a Float variable."), RequiredField, UIHint(UIHint.Variable)]
        public FsmFloat floatVariable;
        [RequiredField, Tooltip("The Integer variable to convert to a float."), UIHint(UIHint.Variable)]
        public FsmInt intVariable;

        private void DoConvertIntToFloat()
        {
            this.floatVariable.Value = this.intVariable.Value;
        }

        public override void OnEnter()
        {
            this.DoConvertIntToFloat();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoConvertIntToFloat();
        }

        public override void Reset()
        {
            this.intVariable = null;
            this.floatVariable = null;
            this.everyFrame = false;
        }
    }
}


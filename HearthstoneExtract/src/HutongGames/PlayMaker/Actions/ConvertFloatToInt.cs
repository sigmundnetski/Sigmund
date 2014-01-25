namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Converts a Float value to an Integer value."), ActionCategory(ActionCategory.Convert)]
    public class ConvertFloatToInt : FsmStateAction
    {
        public bool everyFrame;
        [UIHint(UIHint.Variable), Tooltip("The Float variable to convert to an integer."), RequiredField]
        public FsmFloat floatVariable;
        [RequiredField, Tooltip("Store the result in an Integer variable."), UIHint(UIHint.Variable)]
        public FsmInt intVariable;
        public FloatRounding rounding;

        private void DoConvertFloatToInt()
        {
            switch (this.rounding)
            {
                case FloatRounding.RoundDown:
                    this.intVariable.Value = Mathf.FloorToInt(this.floatVariable.Value);
                    break;

                case FloatRounding.RoundUp:
                    this.intVariable.Value = Mathf.CeilToInt(this.floatVariable.Value);
                    break;

                case FloatRounding.Nearest:
                    this.intVariable.Value = Mathf.RoundToInt(this.floatVariable.Value);
                    break;
            }
        }

        public override void OnEnter()
        {
            this.DoConvertFloatToInt();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoConvertFloatToInt();
        }

        public override void Reset()
        {
            this.floatVariable = null;
            this.intVariable = null;
            this.rounding = FloatRounding.Nearest;
            this.everyFrame = false;
        }

        public enum FloatRounding
        {
            RoundDown,
            RoundUp,
            Nearest
        }
    }
}


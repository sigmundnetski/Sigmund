namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Convert), Tooltip("Converts a Bool value to a Color.")]
    public class ConvertBoolToColor : FsmStateAction
    {
        [UIHint(UIHint.Variable), Tooltip("The Bool variable to test."), RequiredField]
        public FsmBool boolVariable;
        [RequiredField, UIHint(UIHint.Variable), Tooltip("The Color variable to set based on the bool variable value.")]
        public FsmColor colorVariable;
        [Tooltip("Repeat every frame. Useful if the Bool variable is changing.")]
        public bool everyFrame;
        [Tooltip("Color if Bool variable is false.")]
        public FsmColor falseColor;
        [Tooltip("Color if Bool variable is true.")]
        public FsmColor trueColor;

        private void DoConvertBoolToColor()
        {
            this.colorVariable.Value = !this.boolVariable.Value ? this.falseColor.Value : this.trueColor.Value;
        }

        public override void OnEnter()
        {
            this.DoConvertBoolToColor();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoConvertBoolToColor();
        }

        public override void Reset()
        {
            this.boolVariable = null;
            this.colorVariable = null;
            this.falseColor = Color.black;
            this.trueColor = Color.white;
            this.everyFrame = false;
        }
    }
}


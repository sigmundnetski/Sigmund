namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Clamps the value of Float Variable to a Min/Max range."), ActionCategory(ActionCategory.Math)]
    public class FloatClamp : FsmStateAction
    {
        [Tooltip("Repeate every frame. Useful if the float variable is changing.")]
        public bool everyFrame;
        [UIHint(UIHint.Variable), RequiredField, Tooltip("Float variable to clamp.")]
        public FsmFloat floatVariable;
        [RequiredField, Tooltip("The maximum value.")]
        public FsmFloat maxValue;
        [RequiredField, Tooltip("The minimum value.")]
        public FsmFloat minValue;

        private void DoClamp()
        {
            this.floatVariable.Value = Mathf.Clamp(this.floatVariable.Value, this.minValue.Value, this.maxValue.Value);
        }

        public override void OnEnter()
        {
            this.DoClamp();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoClamp();
        }

        public override void Reset()
        {
            this.floatVariable = null;
            this.minValue = null;
            this.maxValue = null;
            this.everyFrame = false;
        }
    }
}


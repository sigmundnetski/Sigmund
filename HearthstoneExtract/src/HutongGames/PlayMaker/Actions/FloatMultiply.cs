namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Math), Tooltip("Multiplies one Float by another.")]
    public class FloatMultiply : FsmStateAction
    {
        [Tooltip("Repeat every frame. Useful if the variables are changing.")]
        public bool everyFrame;
        [UIHint(UIHint.Variable), Tooltip("The float variable to multiply."), RequiredField]
        public FsmFloat floatVariable;
        [Tooltip("Multiply the float variable by this value."), RequiredField]
        public FsmFloat multiplyBy;

        public override void OnEnter()
        {
            this.floatVariable.Value *= this.multiplyBy.Value;
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.floatVariable.Value *= this.multiplyBy.Value;
        }

        public override void Reset()
        {
            this.floatVariable = null;
            this.multiplyBy = null;
            this.everyFrame = false;
        }
    }
}


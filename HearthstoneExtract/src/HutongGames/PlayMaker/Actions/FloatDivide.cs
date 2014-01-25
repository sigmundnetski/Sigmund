namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Divides one Float by another."), ActionCategory(ActionCategory.Math)]
    public class FloatDivide : FsmStateAction
    {
        [RequiredField, Tooltip("Divide the float variable by this value.")]
        public FsmFloat divideBy;
        [Tooltip("Repeate every frame. Useful if the variables are changing.")]
        public bool everyFrame;
        [RequiredField, Tooltip("The float variable to divide."), UIHint(UIHint.Variable)]
        public FsmFloat floatVariable;

        public override void OnEnter()
        {
            this.floatVariable.Value /= this.divideBy.Value;
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.floatVariable.Value /= this.divideBy.Value;
        }

        public override void Reset()
        {
            this.floatVariable = null;
            this.divideBy = null;
            this.everyFrame = false;
        }
    }
}


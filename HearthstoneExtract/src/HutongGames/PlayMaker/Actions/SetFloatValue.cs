namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Math), Tooltip("Sets the value of a Float Variable.")]
    public class SetFloatValue : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmFloat floatValue;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmFloat floatVariable;

        public override void OnEnter()
        {
            this.floatVariable.Value = this.floatValue.Value;
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.floatVariable.Value = this.floatValue.Value;
        }

        public override void Reset()
        {
            this.floatVariable = null;
            this.floatValue = null;
            this.everyFrame = false;
        }
    }
}


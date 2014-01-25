namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Sets the value of a Rect Variable."), ActionCategory(ActionCategory.Rect)]
    public class SetRectValue : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmRect rectValue;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmRect rectVariable;

        public override void OnEnter()
        {
            this.rectVariable.Value = this.rectValue.Value;
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.rectVariable.Value = this.rectValue.Value;
        }

        public override void Reset()
        {
            this.rectVariable = null;
            this.rectValue = null;
            this.everyFrame = false;
        }
    }
}


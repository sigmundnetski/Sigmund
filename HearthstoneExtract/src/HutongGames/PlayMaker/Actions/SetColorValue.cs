namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Sets the value of a Color Variable."), ActionCategory(ActionCategory.Color)]
    public class SetColorValue : FsmStateAction
    {
        [RequiredField]
        public FsmColor color;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmColor colorVariable;
        public bool everyFrame;

        private void DoSetColorValue()
        {
            if (this.colorVariable != null)
            {
                this.colorVariable.Value = this.color.Value;
            }
        }

        public override void OnEnter()
        {
            this.DoSetColorValue();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetColorValue();
        }

        public override void Reset()
        {
            this.colorVariable = null;
            this.color = null;
            this.everyFrame = false;
        }
    }
}


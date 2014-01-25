namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Get the individual fields of a Rect Variable and store them in Float Variables."), ActionCategory(ActionCategory.Rect)]
    public class GetRectFields : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmRect rectVariable;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeHeight;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeWidth;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeX;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeY;

        private void DoGetRectFields()
        {
            if (!this.rectVariable.IsNone)
            {
                this.storeX.Value = this.rectVariable.Value.x;
                this.storeY.Value = this.rectVariable.Value.y;
                this.storeWidth.Value = this.rectVariable.Value.width;
                this.storeHeight.Value = this.rectVariable.Value.height;
            }
        }

        public override void OnEnter()
        {
            this.DoGetRectFields();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetRectFields();
        }

        public override void Reset()
        {
            this.rectVariable = null;
            this.storeX = null;
            this.storeY = null;
            this.storeWidth = null;
            this.storeHeight = null;
            this.everyFrame = false;
        }
    }
}


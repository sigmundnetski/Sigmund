namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Rect), Tooltip("Sets the individual fields of a Rect Variable. To leave any field unchanged, set variable to 'None'.")]
    public class SetRectFields : FsmStateAction
    {
        public bool everyFrame;
        public FsmFloat height;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmRect rectVariable;
        public FsmFloat width;
        public FsmFloat x;
        public FsmFloat y;

        private void DoSetRectFields()
        {
            if (!this.rectVariable.IsNone)
            {
                Rect rect = this.rectVariable.Value;
                if (!this.x.IsNone)
                {
                    rect.x = this.x.Value;
                }
                if (!this.y.IsNone)
                {
                    rect.y = this.y.Value;
                }
                if (!this.width.IsNone)
                {
                    rect.width = this.width.Value;
                }
                if (!this.height.IsNone)
                {
                    rect.height = this.height.Value;
                }
                this.rectVariable.Value = rect;
            }
        }

        public override void OnEnter()
        {
            this.DoSetRectFields();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetRectFields();
        }

        public override void Reset()
        {
            this.rectVariable = null;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.x = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.y = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.width = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.height = num;
            this.everyFrame = false;
        }
    }
}


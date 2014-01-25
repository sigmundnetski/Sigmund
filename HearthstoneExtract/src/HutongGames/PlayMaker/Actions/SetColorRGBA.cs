namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Color), Tooltip("Sets the RGBA channels of a Color Variable. To leave any channel unchanged, set variable to 'None'.")]
    public class SetColorRGBA : FsmStateAction
    {
        [HasFloatSlider(0f, 1f)]
        public FsmFloat alpha;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat blue;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmColor colorVariable;
        public bool everyFrame;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat green;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat red;

        private void DoSetColorRGBA()
        {
            if (this.colorVariable != null)
            {
                Color color = this.colorVariable.Value;
                if (!this.red.IsNone)
                {
                    color.r = this.red.Value;
                }
                if (!this.green.IsNone)
                {
                    color.g = this.green.Value;
                }
                if (!this.blue.IsNone)
                {
                    color.b = this.blue.Value;
                }
                if (!this.alpha.IsNone)
                {
                    color.a = this.alpha.Value;
                }
                this.colorVariable.Value = color;
            }
        }

        public override void OnEnter()
        {
            this.DoSetColorRGBA();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetColorRGBA();
        }

        public override void Reset()
        {
            this.colorVariable = null;
            this.red = 0f;
            this.green = 0f;
            this.blue = 0f;
            this.alpha = 1f;
            this.everyFrame = false;
        }
    }
}


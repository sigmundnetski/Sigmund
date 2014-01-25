namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUI), Tooltip("GUI Vertical Slider connected to a Float Variable.")]
    public class GUIVerticalSlider : GUIAction
    {
        [RequiredField]
        public FsmFloat bottomValue;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmFloat floatVariable;
        public FsmString sliderStyle;
        public FsmString thumbStyle;
        [RequiredField]
        public FsmFloat topValue;

        public override void OnGUI()
        {
            base.OnGUI();
            if (this.floatVariable != null)
            {
                this.floatVariable.Value = GUI.VerticalSlider(base.rect, this.floatVariable.Value, this.topValue.Value, this.bottomValue.Value, !(this.sliderStyle.Value != string.Empty) ? "verticalslider" : this.sliderStyle.Value, !(this.thumbStyle.Value != string.Empty) ? "verticalsliderthumb" : this.thumbStyle.Value);
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.floatVariable = null;
            this.topValue = 100f;
            this.bottomValue = 0f;
            this.sliderStyle = "verticalslider";
            this.thumbStyle = "verticalsliderthumb";
            base.width = 0.1f;
        }
    }
}


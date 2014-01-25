namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("GUILayout Repeat Button. Sends an Event while pressed. Optionally store the button state in a Bool Variable."), ActionCategory(ActionCategory.GUILayout)]
    public class GUILayoutRepeatButton : GUILayoutAction
    {
        public FsmTexture image;
        public FsmEvent sendEvent;
        [UIHint(UIHint.Variable)]
        public FsmBool storeButtonState;
        public FsmString style;
        public FsmString text;
        public FsmString tooltip;

        public override void OnGUI()
        {
            bool flag;
            if (string.IsNullOrEmpty(this.style.Value))
            {
                flag = GUILayout.RepeatButton(new GUIContent(this.text.Value, this.image.Value, this.tooltip.Value), base.LayoutOptions);
            }
            else
            {
                flag = GUILayout.RepeatButton(new GUIContent(this.text.Value, this.image.Value, this.tooltip.Value), this.style.Value, base.LayoutOptions);
            }
            if (flag)
            {
                base.Fsm.Event(this.sendEvent);
            }
            this.storeButtonState.Value = flag;
        }

        public override void Reset()
        {
            base.Reset();
            this.sendEvent = null;
            this.storeButtonState = null;
            this.text = string.Empty;
            this.image = null;
            this.tooltip = string.Empty;
            this.style = string.Empty;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Makes an on/off Toggle Button and stores the button state in a Bool Variable."), ActionCategory(ActionCategory.GUILayout)]
    public class GUILayoutToggle : GUILayoutAction
    {
        public FsmEvent changedEvent;
        public FsmTexture image;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmBool storeButtonState;
        public FsmString style;
        public FsmString text;
        public FsmString tooltip;

        public override void OnGUI()
        {
            bool changed = GUI.changed;
            GUI.changed = false;
            this.storeButtonState.Value = GUILayout.Toggle(this.storeButtonState.Value, new GUIContent(this.text.Value, this.image.Value, this.tooltip.Value), this.style.Value, base.LayoutOptions);
            if (GUI.changed)
            {
                base.Fsm.Event(this.changedEvent);
                GUIUtility.ExitGUI();
            }
            else
            {
                GUI.changed = changed;
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.storeButtonState = null;
            this.text = string.Empty;
            this.image = null;
            this.tooltip = string.Empty;
            this.style = "Toggle";
            this.changedEvent = null;
        }
    }
}


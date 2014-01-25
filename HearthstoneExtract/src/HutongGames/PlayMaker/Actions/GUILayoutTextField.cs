namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("GUILayout Text Field. Optionally send an event if the text has been edited.")]
    public class GUILayoutTextField : GUILayoutAction
    {
        public FsmEvent changedEvent;
        public FsmInt maxLength;
        public FsmString style;
        [UIHint(UIHint.Variable)]
        public FsmString text;

        public override void OnGUI()
        {
            bool changed = GUI.changed;
            GUI.changed = false;
            this.text.Value = GUILayout.TextField(this.text.Value, this.maxLength.Value, this.style.Value, base.LayoutOptions);
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
            this.text = null;
            this.maxLength = 0x19;
            this.style = "TextField";
            this.changedEvent = null;
        }
    }
}


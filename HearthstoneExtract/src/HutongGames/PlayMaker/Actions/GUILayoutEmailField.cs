namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("GUILayout Password Field. Optionally send an event if the text has been edited.")]
    public class GUILayoutEmailField : GUILayoutAction
    {
        public FsmEvent changedEvent;
        public FsmInt maxLength;
        public FsmString style;
        [UIHint(UIHint.Variable)]
        public FsmString text;
        public FsmBool valid;

        public override void OnGUI()
        {
            bool changed = GUI.changed;
            GUI.changed = false;
            this.text.Value = GUILayout.TextField(this.text.Value, this.style.Value, base.LayoutOptions);
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
            this.text = null;
            this.maxLength = 0x19;
            this.style = "TextField";
            this.valid = 1;
            this.changedEvent = null;
        }
    }
}


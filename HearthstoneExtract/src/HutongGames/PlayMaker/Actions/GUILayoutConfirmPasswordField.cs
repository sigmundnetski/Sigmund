namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("GUILayout Password Field. Optionally send an event if the text has been edited."), ActionCategory(ActionCategory.GUILayout)]
    public class GUILayoutConfirmPasswordField : GUILayoutAction
    {
        public FsmEvent changedEvent;
        public FsmBool confirm;
        public FsmString mask;
        public FsmInt maxLength;
        public FsmString password;
        public FsmString style;
        [UIHint(UIHint.Variable)]
        public FsmString text;

        public override void OnGUI()
        {
            bool changed = GUI.changed;
            GUI.changed = false;
            this.text.Value = GUILayout.PasswordField(this.text.Value, this.mask.Value[0], this.style.Value, base.LayoutOptions);
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
            this.mask = "*";
            this.changedEvent = null;
            this.confirm = 0;
            this.password = null;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Returns true if key exists in the preferences."), ActionCategory("PlayerPrefs")]
    public class PlayerPrefsHasKey : FsmStateAction
    {
        [Tooltip("Event to send if key does not exist.")]
        public FsmEvent falseEvent;
        [RequiredField]
        public FsmString key;
        [Tooltip("Event to send if key exists.")]
        public FsmEvent trueEvent;
        [UIHint(UIHint.Variable), Title("Store Result")]
        public FsmBool variable;

        public override void OnEnter()
        {
            base.Finish();
            if (!this.key.IsNone && !this.key.Value.Equals(string.Empty))
            {
                this.variable.Value = PlayerPrefs.HasKey(this.key.Value);
            }
            base.Fsm.Event(!this.variable.Value ? this.falseEvent : this.trueEvent);
        }

        public override void Reset()
        {
            this.key = string.Empty;
        }
    }
}


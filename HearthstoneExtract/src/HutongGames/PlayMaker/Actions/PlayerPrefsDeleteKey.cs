namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Removes key and its corresponding value from the preferences."), ActionCategory("PlayerPrefs")]
    public class PlayerPrefsDeleteKey : FsmStateAction
    {
        public FsmString key;

        public override void OnEnter()
        {
            if (!this.key.IsNone && !this.key.Value.Equals(string.Empty))
            {
                PlayerPrefs.DeleteKey(this.key.Value);
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.key = string.Empty;
        }
    }
}


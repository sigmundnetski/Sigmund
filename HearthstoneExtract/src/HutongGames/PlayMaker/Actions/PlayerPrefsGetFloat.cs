namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Returns the value corresponding to key in the preference file if it exists."), ActionCategory("PlayerPrefs")]
    public class PlayerPrefsGetFloat : FsmStateAction
    {
        [CompoundArray("Count", "Key", "Variable"), Tooltip("Case sensitive key.")]
        public FsmString[] keys;
        [UIHint(UIHint.Variable)]
        public FsmFloat[] variables;

        public override void OnEnter()
        {
            for (int i = 0; i < this.keys.Length; i++)
            {
                if (!this.keys[i].IsNone || !this.keys[i].Value.Equals(string.Empty))
                {
                    this.variables[i].Value = PlayerPrefs.GetFloat(this.keys[i].Value, !this.variables[i].IsNone ? this.variables[i].Value : 0f);
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.keys = new FsmString[1];
            this.variables = new FsmFloat[1];
        }
    }
}


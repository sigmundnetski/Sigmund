namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("PlayerPrefs"), Tooltip("Sets the value of the preference identified by key.")]
    public class PlayerPrefsSetFloat : FsmStateAction
    {
        [CompoundArray("Count", "Key", "Value"), Tooltip("Case sensitive key.")]
        public FsmString[] keys;
        public FsmFloat[] values;

        public override void OnEnter()
        {
            for (int i = 0; i < this.keys.Length; i++)
            {
                if (!this.keys[i].IsNone || !this.keys[i].Value.Equals(string.Empty))
                {
                    PlayerPrefs.SetFloat(this.keys[i].Value, !this.values[i].IsNone ? this.values[i].Value : 0f);
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.keys = new FsmString[1];
            this.values = new FsmFloat[1];
        }
    }
}


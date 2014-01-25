namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("PlayerPrefs"), Tooltip("Removes all keys and values from the preferences. Use with caution.")]
    public class PlayerPrefsDeleteAll : FsmStateAction
    {
        public override void OnEnter()
        {
            PlayerPrefs.DeleteAll();
            base.Finish();
        }

        public override void Reset()
        {
        }
    }
}


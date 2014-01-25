namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Level), Tooltip("Restarts current level.")]
    public class RestartLevel : FsmStateAction
    {
        public override void OnEnter()
        {
            Application.LoadLevel(Application.loadedLevelName);
            base.Finish();
        }
    }
}


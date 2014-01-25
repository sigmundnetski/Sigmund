namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Application), Tooltip("Quits the player application.")]
    public class ApplicationQuit : FsmStateAction
    {
        public override void OnEnter()
        {
            Application.Quit();
            base.Finish();
        }

        public override void Reset()
        {
        }
    }
}


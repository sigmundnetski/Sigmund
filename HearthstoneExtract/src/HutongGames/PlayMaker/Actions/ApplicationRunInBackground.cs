namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets if the Application should play in the background. Useful for servers or testing network games on one machine."), ActionCategory(ActionCategory.Application)]
    public class ApplicationRunInBackground : FsmStateAction
    {
        public FsmBool runInBackground;

        public override void OnEnter()
        {
            Application.runInBackground = this.runInBackground.Value;
            base.Finish();
        }

        public override void Reset()
        {
            this.runInBackground = 1;
        }
    }
}


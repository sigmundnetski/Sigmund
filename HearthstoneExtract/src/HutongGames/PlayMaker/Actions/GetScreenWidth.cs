namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Application), Tooltip("Gets the Width of the Screen in pixels.")]
    public class GetScreenWidth : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmFloat storeScreenWidth;

        public override void OnEnter()
        {
            this.storeScreenWidth.Value = Screen.width;
            base.Finish();
        }

        public override void Reset()
        {
            this.storeScreenWidth = null;
        }
    }
}


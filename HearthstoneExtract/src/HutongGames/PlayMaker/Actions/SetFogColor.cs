namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.RenderSettings), Tooltip("Sets the color of the Fog in the scene.")]
    public class SetFogColor : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmColor fogColor;

        private void DoSetFogColor()
        {
            RenderSettings.fogColor = this.fogColor.Value;
        }

        public override void OnEnter()
        {
            this.DoSetFogColor();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetFogColor();
        }

        public override void Reset()
        {
            this.fogColor = Color.white;
            this.everyFrame = false;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.RenderSettings), Tooltip("Sets the intensity of all Flares in the scene.")]
    public class SetFlareStrength : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmFloat flareStrength;

        private void DoSetFlareStrength()
        {
            RenderSettings.flareStrength = this.flareStrength.Value;
        }

        public override void OnEnter()
        {
            this.DoSetFlareStrength();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetFlareStrength();
        }

        public override void Reset()
        {
            this.flareStrength = 0.2f;
            this.everyFrame = false;
        }
    }
}


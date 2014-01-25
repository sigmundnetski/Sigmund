namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the density of the Fog in the scene."), ActionCategory(ActionCategory.RenderSettings)]
    public class SetFogDensity : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmFloat fogDensity;

        private void DoSetFogDensity()
        {
            RenderSettings.fogDensity = this.fogDensity.Value;
        }

        public override void OnEnter()
        {
            this.DoSetFogDensity();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetFogDensity();
        }

        public override void Reset()
        {
            this.fogDensity = 0.5f;
            this.everyFrame = false;
        }
    }
}


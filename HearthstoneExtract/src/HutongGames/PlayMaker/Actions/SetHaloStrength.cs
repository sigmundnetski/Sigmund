namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.RenderSettings), Tooltip("Sets the size of light halos.")]
    public class SetHaloStrength : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmFloat haloStrength;

        private void DoSetHaloStrength()
        {
            RenderSettings.haloStrength = this.haloStrength.Value;
        }

        public override void OnEnter()
        {
            this.DoSetHaloStrength();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetHaloStrength();
        }

        public override void Reset()
        {
            this.haloStrength = 0.5f;
            this.everyFrame = false;
        }
    }
}


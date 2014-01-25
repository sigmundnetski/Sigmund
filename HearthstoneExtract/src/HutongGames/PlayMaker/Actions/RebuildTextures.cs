namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Substance"), Tooltip("Rebuilds all dirty textures. By default the rebuild is spread over multiple frames so it won't halt the game. Check Immediately to rebuild all textures in a single frame.")]
    public class RebuildTextures : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmBool immediately;
        [RequiredField]
        public FsmMaterial substanceMaterial;

        private void DoRebuildTextures()
        {
            ProceduralMaterial material = this.substanceMaterial.Value as ProceduralMaterial;
            if (material == null)
            {
                this.LogError("Not a substance material!");
            }
            else if (!this.immediately.Value)
            {
                material.RebuildTextures();
            }
            else
            {
                material.RebuildTexturesImmediately();
            }
        }

        public override void OnEnter()
        {
            this.DoRebuildTextures();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoRebuildTextures();
        }

        public override void Reset()
        {
            this.substanceMaterial = null;
            this.immediately = 0;
            this.everyFrame = false;
        }
    }
}


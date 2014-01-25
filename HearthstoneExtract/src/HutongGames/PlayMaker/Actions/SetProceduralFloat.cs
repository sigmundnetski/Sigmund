namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Set a named float property in a Substance material. NOTE: Use Rebuild Textures after setting Substance properties."), ActionCategory("Substance")]
    public class SetProceduralFloat : FsmStateAction
    {
        [Tooltip("NOTE: Updating procedural materials every frame can be very slow!")]
        public bool everyFrame;
        [RequiredField]
        public FsmString floatProperty;
        [RequiredField]
        public FsmFloat floatValue;
        [RequiredField]
        public FsmMaterial substanceMaterial;

        private void DoSetProceduralFloat()
        {
            ProceduralMaterial material = this.substanceMaterial.Value as ProceduralMaterial;
            if (material == null)
            {
                this.LogError("Not a substance material!");
            }
            else
            {
                material.SetProceduralFloat(this.floatProperty.Value, this.floatValue.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoSetProceduralFloat();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetProceduralFloat();
        }

        public override void Reset()
        {
            this.substanceMaterial = null;
            this.floatProperty = string.Empty;
            this.floatValue = 0f;
            this.everyFrame = false;
        }
    }
}


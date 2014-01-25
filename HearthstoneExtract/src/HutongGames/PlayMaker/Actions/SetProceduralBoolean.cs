namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Set a named bool property in a Substance material. NOTE: Use Rebuild Textures after setting Substance properties."), ActionCategory("Substance")]
    public class SetProceduralBoolean : FsmStateAction
    {
        [RequiredField]
        public FsmString boolProperty;
        [RequiredField]
        public FsmBool boolValue;
        [Tooltip("NOTE: Updating procedural materials every frame can be very slow!")]
        public bool everyFrame;
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
                material.SetProceduralBoolean(this.boolProperty.Value, this.boolValue.Value);
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
            this.boolProperty = string.Empty;
            this.boolValue = 0;
            this.everyFrame = false;
        }
    }
}


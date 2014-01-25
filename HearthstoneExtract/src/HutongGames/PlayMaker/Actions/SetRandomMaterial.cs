namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets a Game Object's material randomly from an array of Materials."), ActionCategory(ActionCategory.Material)]
    public class SetRandomMaterial : FsmStateAction
    {
        [CheckForComponent(typeof(UnityEngine.Renderer)), RequiredField]
        public FsmOwnerDefault gameObject;
        public FsmInt materialIndex;
        public FsmMaterial[] materials;

        private void DoSetRandomMaterial()
        {
            if ((this.materials != null) && (this.materials.Length != 0))
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                if (ownerDefaultTarget != null)
                {
                    if (ownerDefaultTarget.renderer == null)
                    {
                        this.LogError("SetMaterial: Missing Renderer!");
                    }
                    else if (this.materialIndex.Value == 0)
                    {
                        ownerDefaultTarget.renderer.material = this.materials[UnityEngine.Random.Range(0, this.materials.Length)].Value;
                    }
                    else if (ownerDefaultTarget.renderer.materials.Length > this.materialIndex.Value)
                    {
                        Material[] materials = ownerDefaultTarget.renderer.materials;
                        materials[this.materialIndex.Value] = this.materials[UnityEngine.Random.Range(0, this.materials.Length)].Value;
                        ownerDefaultTarget.renderer.materials = materials;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetRandomMaterial();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.materialIndex = 0;
            this.materials = new FsmMaterial[3];
        }
    }
}


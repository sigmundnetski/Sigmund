namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Material), Tooltip("Sets the material on a game object.")]
    public class SetMaterial : FsmStateAction
    {
        [CheckForComponent(typeof(UnityEngine.Renderer)), RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField]
        public FsmMaterial material;
        public FsmInt materialIndex;

        private void DoSetMaterial()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                if (ownerDefaultTarget.renderer == null)
                {
                    this.LogError("Missing Renderer!");
                }
                else if (this.materialIndex.Value == 0)
                {
                    ownerDefaultTarget.renderer.material = this.material.Value;
                }
                else if (ownerDefaultTarget.renderer.materials.Length > this.materialIndex.Value)
                {
                    Material[] materials = ownerDefaultTarget.renderer.materials;
                    materials[this.materialIndex.Value] = this.material.Value;
                    ownerDefaultTarget.renderer.materials = materials;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetMaterial();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.material = null;
            this.materialIndex = 0;
        }
    }
}


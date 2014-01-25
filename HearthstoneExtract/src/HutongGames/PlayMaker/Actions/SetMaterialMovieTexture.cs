namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Material), Tooltip("Sets a named texture in a game object's material to a movie texure.")]
    public class SetMaterialMovieTexture : FsmStateAction
    {
        [CheckForComponent(typeof(UnityEngine.Renderer)), Tooltip("The GameObject that the material is applied to.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Alternatively specify a Material instead of a GameObject and Index.")]
        public FsmMaterial material;
        [Tooltip("GameObjects can have multiple materials. Specify an index to target a specific material.")]
        public FsmInt materialIndex;
        [ObjectType(typeof(MovieTexture)), RequiredField]
        public FsmObject movieTexture;
        [UIHint(UIHint.NamedTexture), Tooltip("A named texture in the shader.")]
        public FsmString namedTexture;

        private void DoSetMaterialTexture()
        {
            MovieTexture texture = this.movieTexture.Value as MovieTexture;
            string propertyName = this.namedTexture.Value;
            if (propertyName == string.Empty)
            {
                propertyName = "_MainTex";
            }
            if (this.material.Value != null)
            {
                this.material.Value.SetTexture(propertyName, texture);
            }
            else
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                if (ownerDefaultTarget != null)
                {
                    if (ownerDefaultTarget.renderer == null)
                    {
                        this.LogError("Missing Renderer!");
                    }
                    else if (ownerDefaultTarget.renderer.material == null)
                    {
                        this.LogError("Missing Material!");
                    }
                    else if (this.materialIndex.Value == 0)
                    {
                        ownerDefaultTarget.renderer.material.SetTexture(propertyName, texture);
                    }
                    else if (ownerDefaultTarget.renderer.materials.Length > this.materialIndex.Value)
                    {
                        Material[] materials = ownerDefaultTarget.renderer.materials;
                        materials[this.materialIndex.Value].SetTexture(propertyName, texture);
                        ownerDefaultTarget.renderer.materials = materials;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetMaterialTexture();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.materialIndex = 0;
            this.material = null;
            this.namedTexture = "_MainTex";
            this.movieTexture = null;
        }
    }
}


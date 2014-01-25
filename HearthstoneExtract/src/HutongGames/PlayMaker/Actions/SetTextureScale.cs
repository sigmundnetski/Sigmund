namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Material), Tooltip("Sets the Scale of a named texture in a Game Object's Material. Useful for special effects.")]
    public class SetTextureScale : FsmStateAction
    {
        public bool everyFrame;
        [CheckForComponent(typeof(UnityEngine.Renderer)), RequiredField]
        public FsmOwnerDefault gameObject;
        public FsmInt materialIndex;
        [UIHint(UIHint.NamedColor)]
        public FsmString namedTexture;
        [RequiredField]
        public FsmFloat scaleX;
        [RequiredField]
        public FsmFloat scaleY;

        private void DoSetTextureScale()
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
                    ownerDefaultTarget.renderer.material.SetTextureScale(this.namedTexture.Value, new Vector2(this.scaleX.Value, this.scaleY.Value));
                }
                else if (ownerDefaultTarget.renderer.materials.Length > this.materialIndex.Value)
                {
                    Material[] materials = ownerDefaultTarget.renderer.materials;
                    materials[this.materialIndex.Value].SetTextureScale(this.namedTexture.Value, new Vector2(this.scaleX.Value, this.scaleY.Value));
                    ownerDefaultTarget.renderer.materials = materials;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetTextureScale();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetTextureScale();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.materialIndex = 0;
            this.namedTexture = "_MainTex";
            this.scaleX = 1f;
            this.scaleY = 1f;
            this.everyFrame = false;
        }
    }
}


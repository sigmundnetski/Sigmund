namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Material), Tooltip("Sets a named color value in a game object's material.")]
    public class SetMaterialColor : FsmStateAction
    {
        [RequiredField, Tooltip("Set the parameter value.")]
        public FsmColor color;
        [Tooltip("Repeat every frame. Useful if the value is animated.")]
        public bool everyFrame;
        [CheckForComponent(typeof(UnityEngine.Renderer)), Tooltip("The GameObject that the material is applied to.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Alternatively specify a Material instead of a GameObject and Index.")]
        public FsmMaterial material;
        [Tooltip("GameObjects can have multiple materials. Specify an index to target a specific material.")]
        public FsmInt materialIndex;
        [UIHint(UIHint.NamedColor), Tooltip("A named color parameter in the shader.")]
        public FsmString namedColor;

        private void DoSetMaterialColor()
        {
            if (!this.color.IsNone)
            {
                string propertyName = this.namedColor.Value;
                if (propertyName == string.Empty)
                {
                    propertyName = "_Color";
                }
                if (this.material.Value != null)
                {
                    this.material.Value.SetColor(propertyName, this.color.Value);
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
                            ownerDefaultTarget.renderer.material.SetColor(propertyName, this.color.Value);
                        }
                        else if (ownerDefaultTarget.renderer.materials.Length > this.materialIndex.Value)
                        {
                            Material[] materials = ownerDefaultTarget.renderer.materials;
                            materials[this.materialIndex.Value].SetColor(propertyName, this.color.Value);
                            ownerDefaultTarget.renderer.materials = materials;
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetMaterialColor();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetMaterialColor();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.materialIndex = 0;
            this.material = null;
            this.namedColor = "_Color";
            this.color = Color.black;
            this.everyFrame = false;
        }
    }
}


namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Material), Tooltip("Gets a named float value from a game object's material.")]
    public class GetMaterialFloatAction : FsmStateAction
    {
        public FsmEvent fail;
        [UIHint(UIHint.Variable), Tooltip("Get the parameter value."), RequiredField]
        public FsmFloat floatValue;
        [CheckForComponent(typeof(UnityEngine.Renderer)), Tooltip("The GameObject that the material is applied to.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Alternatively specify a Material instead of a GameObject and Index.")]
        public FsmMaterial material;
        [Tooltip("GameObjects can have multiple materials. Specify an index to target a specific material.")]
        public FsmInt materialIndex;
        [Tooltip("The named float parameter in the shader."), UIHint(UIHint.FsmFloat)]
        public FsmString namedFloat;

        private void DoGetMaterialfloatValue()
        {
            if (!this.floatValue.IsNone)
            {
                string propertyName = this.namedFloat.Value;
                if (propertyName == string.Empty)
                {
                    propertyName = "_Intensity";
                }
                if (this.material.Value != null)
                {
                    if (!this.material.Value.HasProperty(propertyName))
                    {
                        base.Fsm.Event(this.fail);
                    }
                    else
                    {
                        this.floatValue.Value = this.material.Value.GetFloat(propertyName);
                    }
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
                            if (!ownerDefaultTarget.renderer.material.HasProperty(propertyName))
                            {
                                base.Fsm.Event(this.fail);
                            }
                            else
                            {
                                this.floatValue.Value = ownerDefaultTarget.renderer.material.GetFloat(propertyName);
                            }
                        }
                        else if (ownerDefaultTarget.renderer.materials.Length > this.materialIndex.Value)
                        {
                            Material[] materials = ownerDefaultTarget.renderer.materials;
                            if (!materials[this.materialIndex.Value].HasProperty(propertyName))
                            {
                                base.Fsm.Event(this.fail);
                            }
                            else
                            {
                                this.floatValue.Value = materials[this.materialIndex.Value].GetFloat(propertyName);
                            }
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoGetMaterialfloatValue();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.materialIndex = 0;
            this.material = null;
            this.namedFloat = "_Intensity";
            this.floatValue = null;
            this.fail = null;
        }
    }
}


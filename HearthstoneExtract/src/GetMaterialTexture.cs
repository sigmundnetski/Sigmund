using HutongGames.PlayMaker;
using System;
using UnityEngine;

[Tooltip("Get a texture from a material on a GameObject"), ActionCategory(ActionCategory.Material)]
public class GetMaterialTexture : FsmStateAction
{
    [RequiredField, CheckForComponent(typeof(UnityEngine.Renderer))]
    public FsmOwnerDefault gameObject;
    public bool getFromSharedMaterial;
    public FsmInt materialIndex;
    [UIHint(UIHint.NamedTexture)]
    public FsmString namedTexture;
    [UIHint(UIHint.Variable), RequiredField]
    public FsmTexture storedTexture;

    private void DoGetMaterialTexture()
    {
        GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
        if (ownerDefaultTarget != null)
        {
            if (ownerDefaultTarget.renderer == null)
            {
                this.LogError("Missing Renderer!");
            }
            else
            {
                string propertyName = this.namedTexture.Value;
                if (propertyName == string.Empty)
                {
                    propertyName = "_MainTex";
                }
                if ((this.materialIndex.Value == 0) && !this.getFromSharedMaterial)
                {
                    this.storedTexture.Value = ownerDefaultTarget.renderer.material.GetTexture(propertyName);
                }
                else if ((this.materialIndex.Value == 0) && this.getFromSharedMaterial)
                {
                    this.storedTexture.Value = ownerDefaultTarget.renderer.sharedMaterial.GetTexture(propertyName);
                }
                else if ((ownerDefaultTarget.renderer.materials.Length > this.materialIndex.Value) && !this.getFromSharedMaterial)
                {
                    Material[] materials = ownerDefaultTarget.renderer.materials;
                    this.storedTexture.Value = ownerDefaultTarget.renderer.materials[this.materialIndex.Value].GetTexture(propertyName);
                    ownerDefaultTarget.renderer.materials = materials;
                }
                else if ((ownerDefaultTarget.renderer.materials.Length > this.materialIndex.Value) && this.getFromSharedMaterial)
                {
                    Material[] sharedMaterials = ownerDefaultTarget.renderer.sharedMaterials;
                    this.storedTexture.Value = ownerDefaultTarget.renderer.sharedMaterials[this.materialIndex.Value].GetTexture(propertyName);
                    ownerDefaultTarget.renderer.materials = sharedMaterials;
                }
            }
        }
    }

    public override void OnEnter()
    {
        this.DoGetMaterialTexture();
        base.Finish();
    }

    public override void Reset()
    {
        this.gameObject = null;
        this.materialIndex = 0;
        this.namedTexture = "_MainTex";
        this.storedTexture = null;
        this.getFromSharedMaterial = false;
    }
}


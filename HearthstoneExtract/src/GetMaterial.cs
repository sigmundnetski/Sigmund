using HutongGames.PlayMaker;
using System;
using UnityEngine;

[Tooltip("Get a material at index on a gameObject and store it in a variable"), ActionCategory(ActionCategory.Material)]
public class GetMaterial : FsmStateAction
{
    [CheckForComponent(typeof(UnityEngine.Renderer)), RequiredField]
    public FsmOwnerDefault gameObject;
    [Tooltip("Get the shared material of this object. NOTE: Modifying the shared material will change the appearance of all objects using this material, and change material settings that are stored in the project too.")]
    public bool getSharedMaterial;
    [RequiredField, UIHint(UIHint.Variable)]
    public FsmMaterial material;
    public FsmInt materialIndex;

    private void DoGetMaterial()
    {
        GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
        if (ownerDefaultTarget != null)
        {
            if (ownerDefaultTarget.renderer == null)
            {
                this.LogError("Missing Renderer!");
            }
            else if ((this.materialIndex.Value == 0) && !this.getSharedMaterial)
            {
                this.material.Value = ownerDefaultTarget.renderer.material;
            }
            else if ((this.materialIndex.Value == 0) && this.getSharedMaterial)
            {
                this.material.Value = ownerDefaultTarget.renderer.sharedMaterial;
            }
            else if ((ownerDefaultTarget.renderer.materials.Length > this.materialIndex.Value) && !this.getSharedMaterial)
            {
                Material[] materials = ownerDefaultTarget.renderer.materials;
                this.material.Value = materials[this.materialIndex.Value];
                ownerDefaultTarget.renderer.materials = materials;
            }
            else if ((ownerDefaultTarget.renderer.materials.Length > this.materialIndex.Value) && this.getSharedMaterial)
            {
                Material[] sharedMaterials = ownerDefaultTarget.renderer.sharedMaterials;
                this.material.Value = sharedMaterials[this.materialIndex.Value];
                ownerDefaultTarget.renderer.sharedMaterials = sharedMaterials;
            }
        }
    }

    public override void OnEnter()
    {
        this.DoGetMaterial();
        base.Finish();
    }

    public override void Reset()
    {
        this.gameObject = null;
        this.material = null;
        this.materialIndex = 0;
        this.getSharedMaterial = false;
    }
}


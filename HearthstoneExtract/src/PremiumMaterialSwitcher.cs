using System;
using UnityEngine;

public class PremiumMaterialSwitcher : MonoBehaviour
{
    public Material[] m_PremiumMaterials;
    private Material[] OrgMaterials;

    public void SetToPremium(int premium)
    {
        if (premium < 1)
        {
            if ((base.renderer.materials != null) && (this.OrgMaterials != null))
            {
                Material[] materials = base.renderer.materials;
                for (int i = 0; (i < this.m_PremiumMaterials.Length) && (i < materials.Length); i++)
                {
                    if (this.m_PremiumMaterials[i] != null)
                    {
                        materials[i] = this.OrgMaterials[i];
                    }
                }
                base.renderer.materials = materials;
                this.OrgMaterials = null;
            }
        }
        else if (this.m_PremiumMaterials.Length >= 1)
        {
            if (this.OrgMaterials == null)
            {
                this.OrgMaterials = base.renderer.materials;
            }
            Material[] materialArray2 = base.renderer.materials;
            for (int j = 0; (j < this.m_PremiumMaterials.Length) && (j < materialArray2.Length); j++)
            {
                if (this.m_PremiumMaterials[j] != null)
                {
                    materialArray2[j] = this.m_PremiumMaterials[j];
                }
            }
            base.renderer.materials = materialArray2;
        }
    }

    private void Start()
    {
    }
}


using System;
using UnityEngine;

public class DisableMesh_Intensity : MonoBehaviour
{
    private Material m_material;

    private void Start()
    {
        this.m_material = base.renderer.material;
        if (this.m_material == null)
        {
            base.enabled = false;
        }
        if (!this.m_material.HasProperty("_Intensity"))
        {
            base.enabled = false;
        }
    }

    private void Update()
    {
        if (this.m_material.GetFloat("_Intensity") == 0f)
        {
            base.renderer.enabled = false;
        }
        else
        {
            base.renderer.enabled = true;
        }
    }
}


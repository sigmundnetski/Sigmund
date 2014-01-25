using System;
using UnityEngine;

public class DisableMesh_ColorBlack : MonoBehaviour
{
    private Color m_color = Color.black;
    private Material m_material;
    private bool m_tintColor;

    private void Start()
    {
        this.m_material = base.renderer.material;
        if (this.m_material == null)
        {
            base.enabled = false;
        }
        if (!this.m_material.HasProperty("_Color") && !this.m_material.HasProperty("_TintColor"))
        {
            base.enabled = false;
        }
        if (this.m_material.HasProperty("_TintColor"))
        {
            this.m_tintColor = true;
        }
    }

    private void Update()
    {
        if (this.m_tintColor)
        {
            this.m_color = this.m_material.GetColor("_TintColor");
        }
        else
        {
            this.m_color = this.m_material.color;
        }
        if (((this.m_color.r < 0.01f) && (this.m_color.g < 0.01f)) && (this.m_color.b < 0.01f))
        {
            base.renderer.enabled = false;
        }
        else
        {
            base.renderer.enabled = true;
        }
    }
}


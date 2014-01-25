using System;
using UnityEngine;

public static class RenderUtils
{
    public static Material GetMaterial(Component c, int materialIndex)
    {
        return GetMaterial(c.renderer, materialIndex);
    }

    public static Material GetMaterial(GameObject go, int materialIndex)
    {
        return GetMaterial(go.renderer, materialIndex);
    }

    public static Material GetMaterial(UnityEngine.Renderer renderer, int materialIndex)
    {
        if (materialIndex < 0)
        {
            return null;
        }
        Material[] materials = renderer.materials;
        if (materialIndex >= materials.Length)
        {
            return null;
        }
        Material material = materials[materialIndex];
        material.shaderKeywords = renderer.sharedMaterials[materialIndex].shaderKeywords;
        return material;
    }

    public static Material GetSharedMaterial(Component c, int materialIndex)
    {
        return GetSharedMaterial(c.renderer, materialIndex);
    }

    public static Material GetSharedMaterial(GameObject go, int materialIndex)
    {
        return GetSharedMaterial(go.renderer, materialIndex);
    }

    public static Material GetSharedMaterial(UnityEngine.Renderer renderer, int materialIndex)
    {
        if (materialIndex < 0)
        {
            return null;
        }
        Material[] sharedMaterials = renderer.sharedMaterials;
        if (materialIndex >= sharedMaterials.Length)
        {
            return null;
        }
        return sharedMaterials[materialIndex];
    }

    public static void SetAlpha(Component c, float alpha)
    {
        SetAlpha(c.gameObject, alpha, false);
    }

    public static void SetAlpha(GameObject go, float alpha)
    {
        SetAlpha(go, alpha, false);
    }

    public static void SetAlpha(Component c, float alpha, bool includeInactive)
    {
        SetAlpha(c.gameObject, alpha, includeInactive);
    }

    public static void SetAlpha(GameObject go, float alpha, bool includeInactive)
    {
        foreach (UnityEngine.Renderer renderer in go.GetComponentsInChildren<UnityEngine.Renderer>(includeInactive))
        {
            if (renderer.material.HasProperty("_Color"))
            {
                Color color = renderer.material.color;
                color.a = alpha;
                renderer.material.color = color;
            }
            else if (renderer.light != null)
            {
                Color color2 = renderer.light.color;
                color2.a = alpha;
                renderer.light.color = color2;
            }
        }
        foreach (UberText text in go.GetComponentsInChildren<UberText>(includeInactive))
        {
            Color textColor = text.TextColor;
            text.TextColor = new Color(textColor.r, textColor.g, textColor.b, alpha);
        }
    }

    public static void SetMaterial(Component c, int materialIndex, Material material)
    {
        SetMaterial(c.renderer, materialIndex, material);
    }

    public static void SetMaterial(GameObject go, int materialIndex, Material material)
    {
        SetMaterial(go.renderer, materialIndex, material);
    }

    public static void SetMaterial(UnityEngine.Renderer renderer, int materialIndex, Material material)
    {
        if (materialIndex >= 0)
        {
            Material[] materials = renderer.materials;
            if (materialIndex < materials.Length)
            {
                materials[materialIndex] = material;
                renderer.materials = materials;
                renderer.materials[materialIndex].shaderKeywords = material.shaderKeywords;
            }
        }
    }

    public static void SetSharedMaterial(Component c, int materialIndex, Material material)
    {
        SetSharedMaterial(c.renderer, materialIndex, material);
    }

    public static void SetSharedMaterial(GameObject go, int materialIndex, Material material)
    {
        SetSharedMaterial(go.renderer, materialIndex, material);
    }

    public static void SetSharedMaterial(UnityEngine.Renderer renderer, int materialIndex, Material material)
    {
        if ((material != null) && (materialIndex >= 0))
        {
            Material[] sharedMaterials = renderer.sharedMaterials;
            if (materialIndex < sharedMaterials.Length)
            {
                sharedMaterials[materialIndex] = material;
                sharedMaterials[materialIndex].shaderKeywords = material.shaderKeywords;
                renderer.sharedMaterials = sharedMaterials;
            }
        }
    }
}


using System;
using UnityEngine;

public class AssignActorPortraitToChildren : MonoBehaviour
{
    private Actor m_Actor;

    public void AssignPortraitToAllChildren()
    {
        if ((this.m_Actor != null) && (this.m_Actor.m_portraitMesh != null))
        {
            Material[] materials = this.m_Actor.m_portraitMesh.renderer.materials;
            if ((materials.Length != 0) && (this.m_Actor.m_portraitMatIdx >= 0))
            {
                Texture mainTexture = materials[this.m_Actor.m_portraitMatIdx].mainTexture;
                foreach (UnityEngine.Renderer renderer in base.GetComponentsInChildren<UnityEngine.Renderer>())
                {
                    foreach (Material material in renderer.materials)
                    {
                        if (material.name.Contains("portrait"))
                        {
                            material.mainTexture = mainTexture;
                        }
                    }
                }
            }
        }
    }

    private void Start()
    {
        this.m_Actor = SceneUtils.FindComponentInThisOrParents<Actor>(base.gameObject);
    }
}


using System;
using UnityEngine;

[AddComponentMenu("Effects/SetRenderQueue"), RequireComponent(typeof(UnityEngine.Renderer))]
public class SetRenderQue : MonoBehaviour
{
    public int queue = 1;
    public int[] queues;

    protected void Start()
    {
        if (base.renderer != null)
        {
            this.UpdateMaterialQueue(base.renderer.material, this.queue);
        }
        if (this.queues != null)
        {
            for (int i = 0; (i < this.queues.Length) && (i < base.renderer.materials.Length); i++)
            {
                this.UpdateMaterialQueue(base.renderer.materials[i], this.queues[i]);
            }
        }
    }

    private void UpdateMaterialQueue(Material material, int queueMod)
    {
        if (material != null)
        {
            int num = material.renderQueue + queueMod;
            if (num < 0)
            {
                Debug.LogWarning(string.Format("WARNING: Using negative renderQueue for {0}'s {1} (renderQueue = {2})", base.transform.root.name, base.gameObject.name, num));
            }
            material.renderQueue = num;
        }
    }
}


using System;
using UnityEngine;

public class WeaponUVWorldspace : MonoBehaviour
{
    public float xOffset;
    public float yOffset;

    private void Start()
    {
    }

    private void Update()
    {
        Vector3 vector = (Vector3) (base.transform.position * 0.7f);
        Material material = base.gameObject.renderer.material;
        material.SetFloat("_OffsetX", -vector.z - this.xOffset);
        material.SetFloat("_OffsetY", -vector.x - this.yOffset);
    }
}


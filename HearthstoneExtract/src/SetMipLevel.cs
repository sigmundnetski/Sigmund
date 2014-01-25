using System;
using UnityEngine;

public class SetMipLevel : MonoBehaviour
{
    private void Start()
    {
        base.renderer.material.mainTexture.mipMapBias = 1.5f;
    }

    private void Update()
    {
    }
}


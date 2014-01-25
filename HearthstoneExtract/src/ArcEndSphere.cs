using System;
using UnityEngine;

public class ArcEndSphere : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        Vector2 mainTextureOffset = base.renderer.material.mainTextureOffset;
        mainTextureOffset.x += UnityEngine.Time.deltaTime * 1f;
        base.renderer.material.mainTextureOffset = mainTextureOffset;
    }
}


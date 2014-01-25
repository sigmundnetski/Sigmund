using System;
using UnityEngine;

public class ReticlePerspectiveAdjust : MonoBehaviour
{
    public float m_HorizontalAdjustment = 20f;
    public float m_VertialAdjustment = 20f;

    private void Start()
    {
    }

    private void Update()
    {
        Camera mainCamera = Camera.mainCamera;
        Vector3 vector = mainCamera.WorldToScreenPoint(base.transform.position);
        float num = (vector.x / mainCamera.pixelWidth) - 0.5f;
        float num2 = -((vector.y / mainCamera.pixelHeight) - 0.5f);
        base.transform.rotation = Quaternion.identity;
        base.transform.Rotate(new Vector3(this.m_VertialAdjustment * num2, 0f, this.m_HorizontalAdjustment * num), Space.World);
    }
}


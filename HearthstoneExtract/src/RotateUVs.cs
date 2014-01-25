using System;
using UnityEngine;

public class RotateUVs : MonoBehaviour
{
    public Vector2 pivot = new Vector2(0.5f, 0.5f);
    public float rotateSpeed = 10f;

    protected void Update()
    {
        Matrix4x4 matrixx = Matrix4x4.TRS((Vector3) -this.pivot, Quaternion.identity, Vector3.one);
        Quaternion q = Quaternion.Euler(0f, 0f, UnityEngine.Time.time * this.rotateSpeed);
        Matrix4x4 matrixx2 = Matrix4x4.TRS(Vector3.zero, q, Vector3.one);
        Matrix4x4 matrixx3 = Matrix4x4.TRS((Vector3) this.pivot, Quaternion.identity, Vector3.one);
        base.renderer.material.SetMatrix("_Rotation", (matrixx3 * matrixx2) * matrixx);
    }
}


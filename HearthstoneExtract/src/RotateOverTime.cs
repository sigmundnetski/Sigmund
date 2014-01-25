using System;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    public bool RandomStartX;
    public bool RandomStartY;
    public bool RandomStartZ;
    public float RotateSpeedX;
    public float RotateSpeedY;
    public float RotateSpeedZ;

    private void Start()
    {
        if (this.RandomStartX)
        {
            base.transform.Rotate(Vector3.left, (float) UnityEngine.Random.Range(0, 360));
        }
        if (this.RandomStartY)
        {
            base.transform.Rotate(Vector3.up, (float) UnityEngine.Random.Range(0, 360));
        }
        if (this.RandomStartZ)
        {
            base.transform.Rotate(Vector3.forward, (float) UnityEngine.Random.Range(0, 360));
        }
    }

    private void Update()
    {
        base.transform.Rotate(Vector3.left, UnityEngine.Time.deltaTime * this.RotateSpeedX, Space.Self);
        base.transform.Rotate(Vector3.up, UnityEngine.Time.deltaTime * this.RotateSpeedY, Space.Self);
        base.transform.Rotate(Vector3.forward, UnityEngine.Time.deltaTime * this.RotateSpeedZ, Space.Self);
    }
}


using System;
using UnityEngine;

public class RotateOverTimePingPong : MonoBehaviour
{
    public bool RandomStartX = true;
    public bool RandomStartY = true;
    public bool RandomStartZ = true;
    public float RotateRangeXmax = 10f;
    public float RotateRangeXmin;
    public float RotateRangeYmax = 10f;
    public float RotateRangeYmin;
    public float RotateRangeZmax = 10f;
    public float RotateRangeZmin;
    public float RotateSpeedX;
    public float RotateSpeedY;
    public float RotateSpeedZ;

    private void Start()
    {
        if (this.RandomStartX)
        {
            base.transform.Rotate(Vector3.left, UnityEngine.Random.Range(this.RotateRangeXmin, this.RotateRangeXmax));
        }
        if (this.RandomStartY)
        {
            base.transform.Rotate(Vector3.up, UnityEngine.Random.Range(this.RotateRangeYmin, this.RotateRangeYmax));
        }
        if (this.RandomStartZ)
        {
            base.transform.Rotate(Vector3.forward, UnityEngine.Random.Range(this.RotateRangeZmin, this.RotateRangeZmax));
        }
    }

    private void Update()
    {
        float z = Mathf.Sin(UnityEngine.Time.time) * this.RotateRangeZmax;
        float y = base.gameObject.transform.localRotation.y;
        object[] args = new object[] { "rotation", new Vector3(0f, y, z), "isLocal", true, "time", 0 };
        iTween.RotateUpdate(base.gameObject, iTween.Hash(args));
    }
}


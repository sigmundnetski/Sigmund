using System;
using UnityEngine;

public class ArcEnd : MonoBehaviour
{
    public Light l;
    private Vector3 s;

    private void FixedUpdate()
    {
        Vector3 upwards = Camera.main.transform.position - base.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(Vector3.up, upwards);
        base.transform.rotation = quaternion;
        base.transform.Rotate(Vector3.up, (float) (UnityEngine.Random.value * 360f));
        if (UnityEngine.Random.value > 0.8f)
        {
            base.transform.localScale = (Vector3) (this.s * 1.5f);
            if (this.l != null)
            {
                this.l.range = 100f;
                this.l.intensity = 1.5f;
            }
        }
        else
        {
            base.transform.localScale = this.s;
            if (this.l != null)
            {
                this.l.range = 50f;
                this.l.intensity = 1f;
            }
        }
    }

    private void Start()
    {
        this.s = base.transform.localScale;
    }
}


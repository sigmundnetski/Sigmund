using System;
using UnityEngine;

public class RotateByMovement : MonoBehaviour
{
    private Vector3 m_previousPos;
    public GameObject mParent;

    private void Update()
    {
        Transform transform = this.mParent.transform;
        if (this.m_previousPos != transform.localPosition)
        {
            if (this.m_previousPos == Vector3.zero)
            {
                this.m_previousPos = transform.localPosition;
            }
            else
            {
                Vector3 localPosition = transform.localPosition;
                float f = localPosition.z - this.m_previousPos.z;
                float num2 = localPosition.x - this.m_previousPos.x;
                float num3 = Mathf.Sqrt(Mathf.Pow(num2, 2f) + Mathf.Pow(f, 2f));
                float y = (Mathf.Asin(f / num3) * 180f) / 3.141593f;
                y -= 90f;
                base.transform.localEulerAngles = new Vector3(90f, y, 0f);
                this.m_previousPos = localPosition;
            }
        }
    }
}


using System;
using UnityEngine;

public class UnrealCameraControl : MonoBehaviour
{
    private float mHdg;
    private float mPitch;
    public float sensitivityX = 8f;
    public float sensitivityY = 8f;

    private void ChangeHeading(float aVal)
    {
        this.mHdg += aVal;
        WrapAngle(ref this.mHdg);
        base.transform.localEulerAngles = new Vector3(this.mPitch, this.mHdg, 0f);
    }

    private void ChangeHeight(float aVal)
    {
        Transform transform = base.transform;
        transform.position += (Vector3) (aVal * Vector3.up);
    }

    private void ChangePitch(float aVal)
    {
        this.mPitch += aVal;
        WrapAngle(ref this.mPitch);
        base.transform.localEulerAngles = new Vector3(this.mPitch, this.mHdg, 0f);
    }

    private void MoveForwards(float aVal)
    {
        Vector3 forward = base.transform.forward;
        forward.y = 0f;
        forward.Normalize();
        Transform transform = base.transform;
        transform.position += (Vector3) (aVal * forward);
    }

    private void Start()
    {
    }

    private void Strafe(float aVal)
    {
        Transform transform = base.transform;
        transform.position += (Vector3) (aVal * base.transform.right);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            float aVal = Input.GetAxis("Mouse X") * this.sensitivityX;
            float num2 = Input.GetAxis("Mouse Y") * this.sensitivityY;
            if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
            {
                this.Strafe(aVal);
                this.ChangeHeight(num2);
            }
            else if (Input.GetMouseButton(0))
            {
                this.MoveForwards(num2);
                this.ChangeHeading(aVal);
            }
            else if (Input.GetMouseButton(1))
            {
                this.ChangeHeading(aVal);
                this.ChangePitch(-num2);
            }
        }
    }

    public static void WrapAngle(ref float angle)
    {
        if (angle < -360f)
        {
            angle += 360f;
        }
        if (angle > 360f)
        {
            angle -= 360f;
        }
    }
}


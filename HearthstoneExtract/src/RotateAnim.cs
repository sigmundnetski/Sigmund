using System;
using UnityEngine;

public class RotateAnim : MonoBehaviour
{
    private bool gogogo;
    private float startingAngle;
    private Quaternion targetRotation;
    private float timePassed;
    private float timeValue;

    public void SetTargetRotation(Vector3 target, float timeValueInput)
    {
        this.targetRotation = Quaternion.Euler(target);
        this.gogogo = true;
        this.timeValue = timeValueInput;
        this.startingAngle = Quaternion.Angle(base.transform.rotation, this.targetRotation);
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (this.gogogo)
        {
            this.timePassed += UnityEngine.Time.deltaTime;
            float timePassed = this.timePassed;
            float startingAngle = this.startingAngle;
            float num3 = startingAngle - Quaternion.Angle(base.transform.rotation, this.targetRotation);
            float timeValue = this.timeValue;
            float num5 = (num3 * (-Mathf.Pow(2f, (-10f * timePassed) / timeValue) + 1f)) + startingAngle;
            base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, this.targetRotation, num5 * UnityEngine.Time.deltaTime);
            if (Quaternion.Angle(base.transform.rotation, this.targetRotation) <= float.Epsilon)
            {
                this.gogogo = false;
                UnityEngine.Object.Destroy(this);
            }
        }
    }
}


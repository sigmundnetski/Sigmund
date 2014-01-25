using System;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    private bool m_Animate;
    public bool m_AnimateOnStart;
    private bool m_isDone;
    private Vector3 m_LastTargetPosition;
    private float m_LerpPosition;
    public MoveType m_MoveType;
    public bool m_OrientToPath;
    public float m_SnapDistance = 0.1f;
    public float m_Speed = 1f;
    public Transform m_StartPosition;
    public Transform m_TargetObject;
    public float m_Time = 1f;

    private void MoveSpeed()
    {
        if (this.m_isDone)
        {
            base.transform.position = this.m_TargetObject.position;
        }
        if (this.m_Animate)
        {
            if (Vector3.Distance(base.transform.position, this.m_TargetObject.position) < this.m_SnapDistance)
            {
                this.m_isDone = true;
                base.transform.position = this.m_TargetObject.position;
            }
            else
            {
                Vector3 vector = this.m_TargetObject.position - base.transform.position;
                vector.Normalize();
                float num2 = this.m_Speed * UnityEngine.Time.deltaTime;
                base.transform.position += (Vector3) (vector * num2);
            }
        }
    }

    private void MoveTime()
    {
        if (this.m_isDone)
        {
            base.transform.position = this.m_TargetObject.position;
        }
        if (this.m_Animate)
        {
            Vector3 position = this.m_TargetObject.position;
            float num = 1f / this.m_Time;
            this.m_LerpPosition += num * UnityEngine.Time.deltaTime;
            if (this.m_LerpPosition > 1f)
            {
                this.m_isDone = true;
                base.transform.position = this.m_TargetObject.position;
            }
            else
            {
                Vector3 vector2 = Vector3.Lerp(this.m_StartPosition.position, position, this.m_LerpPosition);
                base.transform.position = vector2;
            }
        }
    }

    private void Start()
    {
        if (this.m_AnimateOnStart)
        {
            this.StartAnimation();
        }
    }

    private void StartAnimation()
    {
        if (this.m_StartPosition != null)
        {
            base.transform.position = this.m_StartPosition.position;
        }
        this.m_Animate = true;
        this.m_LerpPosition = 0f;
    }

    private void Update()
    {
        if (this.m_MoveType == MoveType.MoveByTime)
        {
            this.MoveTime();
        }
        else
        {
            this.MoveSpeed();
        }
    }

    public enum MoveType
    {
        MoveByTime,
        MoveBySpeed
    }
}


using System;
using UnityEngine;

public class DragRotator : MonoBehaviour
{
    private const float EPSILON = 0.0001f;
    private DragRotatorInfo m_info;
    private Vector3 m_originalAngles;
    private float m_pitchDeg;
    private float m_pitchVel;
    private Vector3 m_prevPos;
    private float m_rollDeg;
    private float m_rollVel;
    private const float SMOOTH_DAMP_SEC_FUDGE = 0.1f;

    private void Awake()
    {
        this.m_prevPos = base.transform.position;
        this.m_originalAngles = base.transform.localRotation.eulerAngles;
    }

    public DragRotatorInfo GetInfo()
    {
        return this.m_info;
    }

    public void Reset()
    {
        this.m_prevPos = base.transform.position;
        base.transform.localRotation = Quaternion.Euler(this.m_originalAngles);
        this.m_rollDeg = 0f;
        this.m_rollVel = 0f;
        this.m_pitchDeg = 0f;
        this.m_pitchVel = 0f;
    }

    public void SetInfo(DragRotatorInfo info)
    {
        this.m_info = info;
    }

    private void Update()
    {
        Vector3 position = base.transform.position;
        Vector3 vector2 = position - this.m_prevPos;
        if (vector2.sqrMagnitude > 0.0001f)
        {
            this.m_pitchDeg += vector2.z * this.m_info.m_PitchInfo.m_ForceMultiplier;
            this.m_pitchDeg = Mathf.Clamp(this.m_pitchDeg, this.m_info.m_PitchInfo.m_MinDegrees, this.m_info.m_PitchInfo.m_MaxDegrees);
            this.m_rollDeg -= vector2.x * this.m_info.m_RollInfo.m_ForceMultiplier;
            this.m_rollDeg = Mathf.Clamp(this.m_rollDeg, this.m_info.m_RollInfo.m_MinDegrees, this.m_info.m_RollInfo.m_MaxDegrees);
        }
        this.m_pitchDeg = Mathf.SmoothDamp(this.m_pitchDeg, 0f, ref this.m_pitchVel, this.m_info.m_PitchInfo.m_RestSeconds * 0.1f);
        this.m_rollDeg = Mathf.SmoothDamp(this.m_rollDeg, 0f, ref this.m_rollVel, this.m_info.m_RollInfo.m_RestSeconds * 0.1f);
        base.transform.localRotation = Quaternion.Euler(this.m_originalAngles.x + this.m_pitchDeg, this.m_originalAngles.y, this.m_originalAngles.z + this.m_rollDeg);
        this.m_prevPos = position;
    }
}


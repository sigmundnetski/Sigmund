using System;
using UnityEngine;

[Serializable]
public class TwistingNetherLiftInfo
{
    public float m_DelayMax = 0.3f;
    public float m_DelayMin;
    public float m_DurationMax = 0.3f;
    public float m_DurationMin = 0.1f;
    public iTween.EaseType m_EaseType = iTween.EaseType.easeOutExpo;
    public Vector3 m_OffsetMax = new Vector3(3f, 5.5f, 3f);
    public Vector3 m_OffsetMin = new Vector3(-3f, 3.5f, -3f);
    public float m_RotationMax = 90f;
    public float m_RotationMin;
    public float m_RotDelayMax = 0.3f;
    public float m_RotDelayMin;
    public float m_RotDurationMax = 3f;
    public float m_RotDurationMin = 1f;
}


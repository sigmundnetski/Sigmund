using System;
using UnityEngine;

[Serializable]
public class BoxDoorStateInfo
{
    public float m_ClosedDelaySec;
    public iTween.EaseType m_ClosedRotateEaseType;
    public float m_ClosedRotateSec = 0.35f;
    public Vector3 m_ClosedRotation = Vector3.zero;
    public float m_OpenedDelaySec;
    public iTween.EaseType m_OpenedRotateEaseType;
    public float m_OpenedRotateSec = 0.35f;
    public Vector3 m_OpenedRotation = new Vector3(0f, 0f, 180f);
}


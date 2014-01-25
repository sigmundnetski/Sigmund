using System;
using UnityEngine;

[Serializable]
public class BoxCameraStateInfo
{
    public GameObject m_ClosedBone;
    public float m_ClosedDelaySec;
    public iTween.EaseType m_ClosedMoveEaseType = iTween.EaseType.easeOutCubic;
    public float m_ClosedMoveSec = 0.7f;
    public GameObject m_ClosedWithDrawerBone;
    public float m_ClosedWithDrawerDelaySec;
    public iTween.EaseType m_ClosedWithDrawerMoveEaseType = iTween.EaseType.easeOutCubic;
    public float m_ClosedWithDrawerMoveSec = 0.7f;
    public GameObject m_OpenedBone;
    public float m_OpenedDelaySec;
    public iTween.EaseType m_OpenedMoveEaseType = iTween.EaseType.easeOutCubic;
    public float m_OpenedMoveSec = 0.7f;
}


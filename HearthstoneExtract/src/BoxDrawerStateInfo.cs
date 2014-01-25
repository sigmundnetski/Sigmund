using System;
using UnityEngine;

[Serializable]
public class BoxDrawerStateInfo
{
    public GameObject m_ClosedBone;
    public GameObject m_ClosedBoxOpenedBone;
    public float m_ClosedBoxOpenedDelaySec;
    public iTween.EaseType m_ClosedBoxOpenedMoveEaseType = iTween.EaseType.linear;
    public float m_ClosedBoxOpenedMoveSec = 1f;
    public float m_ClosedDelaySec;
    public iTween.EaseType m_ClosedMoveEaseType = iTween.EaseType.linear;
    public float m_ClosedMoveSec = 1f;
    public GameObject m_OpenedBone;
    public float m_OpenedDelaySec;
    public iTween.EaseType m_OpenedMoveEaseType = iTween.EaseType.easeOutBounce;
    public float m_OpenedMoveSec = 1f;
}


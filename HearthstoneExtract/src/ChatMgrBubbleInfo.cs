using System;
using UnityEngine;

[Serializable]
public class ChatMgrBubbleInfo
{
    public iTween.EaseType m_FadeOutEaseType = iTween.EaseType.linear;
    public float m_FadeOutSec = 2f;
    public float m_HoldSec = 5f;
    public iTween.EaseType m_MoveOverEaseType = iTween.EaseType.easeOutExpo;
    public float m_MoveOverSec = 1f;
    public Transform m_Parent;
    public iTween.EaseType m_ScaleInEaseType = iTween.EaseType.easeOutElastic;
    public float m_ScaleInSec = 1f;
}


using System;

[Serializable]
public class HeroAttackDef
{
    public float m_MoveBackDuration = 0.15f;
    public iTween.EaseType m_MoveBackEaseType = iTween.Defaults.easeType;
    public float m_MoveToTargetDuration = 0.12f;
    public iTween.EaseType m_MoveToTargetEaseType = iTween.EaseType.linear;
    public float m_OrientBackDuration = 0.3f;
    public iTween.EaseType m_OrientBackEaseType = iTween.EaseType.linear;
    public float m_OrientToTargetDuration = 0.3f;
    public iTween.EaseType m_OrientToTargetEaseType = iTween.EaseType.linear;
}


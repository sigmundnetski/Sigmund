using System;

[Serializable]
public class TwistingNetherDrainInfo
{
    public float m_DelayMax;
    public float m_DelayMin;
    public float m_DurationMax = 2f;
    public float m_DurationMin = 1.5f;
    public iTween.EaseType m_EaseType = iTween.EaseType.easeInOutCubic;
}


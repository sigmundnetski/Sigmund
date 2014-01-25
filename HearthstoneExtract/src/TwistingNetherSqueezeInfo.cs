using System;

[Serializable]
public class TwistingNetherSqueezeInfo
{
    public float m_DelayMax;
    public float m_DelayMin;
    public float m_DurationMax = 1.5f;
    public float m_DurationMin = 1f;
    public iTween.EaseType m_EaseType = iTween.EaseType.easeInCubic;
}


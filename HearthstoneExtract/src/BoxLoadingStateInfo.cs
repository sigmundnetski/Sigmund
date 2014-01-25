using System;

[Serializable]
public class BoxLoadingStateInfo
{
    public float m_HiddenAlpha;
    public float m_HiddenDelaySec = 0.2f;
    public iTween.EaseType m_HiddenFadeEaseType = iTween.EaseType.linear;
    public float m_HiddenFadeSec = 0.2f;
    public float m_ShownAlpha = 1f;
    public float m_ShownDelaySec = 0.2f;
    public iTween.EaseType m_ShownFadeEaseType = iTween.EaseType.linear;
    public float m_ShownFadeSec = 0.2f;
}


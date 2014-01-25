using System;

[Serializable]
public class SoundPlaybackLimitClipDef
{
    public float m_ExclusivePlaybackThreshold = 0.1f;
    public string m_Path;
    public int m_Priority;
}


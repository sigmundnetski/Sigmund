using System;
using System.Collections.Generic;

[Serializable]
public class SoundPlaybackLimitDef
{
    public List<SoundPlaybackLimitClipDef> m_ClipDefs;
    public int m_Limit = 1;
}


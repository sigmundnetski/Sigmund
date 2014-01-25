using System;

[Serializable]
public class SoundDuckedCategoryDef
{
    public iTween.EaseType m_BeginEaseType = iTween.EaseType.linear;
    public float m_BeginSec = 0.7f;
    public SoundCategory m_Category;
    public iTween.EaseType m_RestoreEaseType = iTween.EaseType.linear;
    public float m_RestoreSec = 0.7f;
    public float m_Volume = 0.2f;
}


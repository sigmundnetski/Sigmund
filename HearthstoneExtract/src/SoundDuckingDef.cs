using System;
using System.Collections.Generic;

[Serializable]
public class SoundDuckingDef
{
    public List<SoundDuckedCategoryDef> m_DuckedCategoryDefs;
    public SoundCategory m_TriggerCategory;

    public override string ToString()
    {
        return string.Format("[SoundDuckingDef: {0}]", this.m_TriggerCategory);
    }
}


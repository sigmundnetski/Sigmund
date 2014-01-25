using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoxLightState
{
    public Color m_AmbientColor = new Color(0.5058824f, 0.4745098f, 0.4745098f, 1f);
    public float m_DelaySec;
    public List<BoxLightInfo> m_LightInfos;
    public Spell m_Spell;
    public iTween.EaseType m_TransitionEaseType = iTween.EaseType.linear;
    public float m_TransitionSec = 0.5f;
    public BoxLightStateType m_Type;
}


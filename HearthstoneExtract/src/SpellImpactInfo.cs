using System;

[Serializable]
public class SpellImpactInfo
{
    public SpellImpactPrefabs[] m_DamageAmountImpacts;
    public bool m_Enabled = true;
    public float m_GameDelaySecMax = 0.5f;
    public float m_GameDelaySecMin = 0.5f;
    public SpellLocation m_Location = SpellLocation.TARGET;
    public Spell m_Prefab;
    public bool m_SetParentToLocation;
    public float m_SpawnDelaySecMax;
    public float m_SpawnDelaySecMin;
    public bool m_UseSuperSpellLocation;
}


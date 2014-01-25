using System;

[Serializable]
public class SpellAreaEffectInfo
{
    public bool m_Enabled = true;
    public SpellFacing m_Facing;
    public SpellFacingOptions m_FacingOptions;
    public Spell m_Prefab;
    public float m_SpawnDelaySecMax;
    public float m_SpawnDelaySecMin;
    public bool m_UseSuperSpellLocation;
}


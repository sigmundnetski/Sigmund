using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpellTable : MonoBehaviour
{
    public List<SpellTableEntry> m_Table = new List<SpellTableEntry>();

    private void Awake()
    {
        for (int i = 0; i < this.m_Table.Count; i++)
        {
            SpellTableEntry entry = this.m_Table[i];
            if (entry.m_Spell == null)
            {
                Debug.LogWarning(string.Format("SpellTable.Awake() - Entry {0} has a null Spell. Type={1}", i, entry.m_Type));
            }
            else
            {
                entry.m_Spell.SetSpellType(entry.m_Type);
                if (entry.m_Type == SpellType.NONE)
                {
                    entry.m_Spell.Hide();
                }
            }
        }
    }

    public bool FindSpell(SpellType spellType, out Spell spell)
    {
        foreach (SpellTableEntry entry in this.m_Table)
        {
            if (entry.m_Type == spellType)
            {
                spell = entry.m_Spell;
                return true;
            }
        }
        spell = null;
        return false;
    }

    public Spell GetSpell(SpellType spellType)
    {
        foreach (SpellTableEntry entry in this.m_Table)
        {
            if (entry.m_Type == spellType)
            {
                Spell component = ((GameObject) UnityEngine.Object.Instantiate(entry.m_Spell.gameObject)).GetComponent<Spell>();
                component.SetSpellType(spellType);
                return component;
            }
        }
        return null;
    }

    public void Hide()
    {
        foreach (SpellTableEntry entry in this.m_Table)
        {
            if (entry.m_Spell != null)
            {
                entry.m_Spell.Hide();
            }
        }
    }

    public void ReleaseSpell(GameObject spellObject)
    {
        SceneUtils.Destroy(spellObject);
    }

    public void Show()
    {
        foreach (SpellTableEntry entry in this.m_Table)
        {
            if ((entry.m_Spell != null) && (entry.m_Type != SpellType.NONE))
            {
                entry.m_Spell.Show();
            }
        }
    }
}


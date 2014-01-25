using System;
using UnityEngine;

public class BoxMenuButton : PegUIElement
{
    public HighlightState m_HighlightState;
    public Spell m_Spell;
    public TextMesh m_TextMesh;

    public string GetText()
    {
        return this.m_TextMesh.text;
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        if (this.m_Spell != null)
        {
            this.m_Spell.ActivateState(SpellStateType.DEATH);
        }
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        if (this.m_Spell != null)
        {
            this.m_Spell.ActivateState(SpellStateType.BIRTH);
        }
    }

    protected override void OnPress()
    {
        if (this.m_Spell != null)
        {
            this.m_Spell.ActivateState(SpellStateType.ACTION);
        }
    }

    public void SetText(string text)
    {
        this.m_TextMesh.text = text;
        TextUtils.HackAssignOutlineText(this.m_TextMesh, text);
    }
}


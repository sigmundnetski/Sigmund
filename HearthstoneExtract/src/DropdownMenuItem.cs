using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DropdownMenuItem : PegUIElement
{
    [CompilerGenerated]
    private static handleClick <>f__am$cache5;
    public GameObject m_highlight;
    public GameObject m_selected;
    public UberText m_text;
    private object m_value;

    public event handleClick click;

    public DropdownMenuItem()
    {
        if (<>f__am$cache5 == null)
        {
            <>f__am$cache5 = new handleClick(DropdownMenuItem.<click>m__3F);
        }
        this.click = <>f__am$cache5;
    }

    [CompilerGenerated]
    private static void <click>m__3F(DropdownMenuItem)
    {
    }

    public object GetValue()
    {
        return this.m_value;
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        if (this.m_highlight != null)
        {
            this.m_highlight.SetActive(false);
            this.m_text.TextColor = Color.black;
        }
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        if (this.m_highlight != null)
        {
            this.m_highlight.SetActive(true);
            this.m_text.TextColor = Color.white;
        }
    }

    protected override void OnRelease()
    {
        this.click(this);
    }

    public void SetSelected(bool selected)
    {
        if (this.m_selected != null)
        {
            this.m_selected.SetActive(selected);
        }
    }

    public void SetValue(object val, string text)
    {
        this.m_value = val;
        this.m_text.Text = text;
    }

    public delegate void handleClick(DropdownMenuItem item);
}


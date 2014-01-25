using System;
using UnityEngine;

public class FriendListThreeSliceButton : FriendListUIElement
{
    public ThreeSliceElement m_Background;
    public ThreeSliceElement m_Button;
    public TextMesh m_Text;
    public UberText m_uberText;

    public string GetText()
    {
        if (this.m_uberText != null)
        {
            return this.m_uberText.Text;
        }
        return this.m_Text.text;
    }

    private float GetTextWidth()
    {
        if (this.m_uberText != null)
        {
            return this.m_uberText.GetTextBounds().size.x;
        }
        return this.m_Text.renderer.bounds.size.x;
    }

    public void SetText(string text)
    {
        if (this.m_uberText != null)
        {
            if (this.m_uberText.Text != text)
            {
                this.m_uberText.Text = text;
                this.UpdateAll();
            }
        }
        else if (text != this.m_Text.text)
        {
            this.m_Text.text = text;
            this.UpdateAll();
        }
    }

    private void UpdateAll()
    {
        this.UpdateHighlight();
    }

    protected override void UpdateHighlight()
    {
        base.UpdateHighlight();
        if (base.m_Highlight.activeSelf)
        {
        }
    }
}


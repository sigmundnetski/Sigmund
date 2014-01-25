using System;
using UnityEngine;

public class UnrankedPlayToggleButton : PegUIElement
{
    public HighlightState m_highlight;
    private bool m_isRankedMode;
    public GameObject m_xIcon;

    public bool GetIsRanked()
    {
        return this.m_isRankedMode;
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        if (this.m_highlight != null)
        {
            this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_OFF);
        }
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        if (this.m_highlight != null)
        {
            this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_MOUSE_OVER);
        }
    }

    public void SetRankedMode(bool isRankedMode)
    {
        this.m_isRankedMode = isRankedMode;
        if (isRankedMode)
        {
            this.m_xIcon.SetActive(true);
        }
        else
        {
            this.m_xIcon.SetActive(false);
        }
    }
}


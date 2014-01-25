using System;
using System.Collections;
using UnityEngine;

public class ArrowModeButton : PegUIElement
{
    public HighlightState m_highlight;
    private bool m_isHighlighted;
    private int m_numFlips;

    public void Activate(bool activate)
    {
        if (activate != base.IsEnabled())
        {
            base.SetEnabled(activate);
            if (!activate)
            {
                this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_OFF);
            }
            this.m_numFlips++;
            if (base.gameObject.GetComponent<iTween>() == null)
            {
                this.Flip();
            }
        }
    }

    public void ActivateHighlight(bool highlightOn)
    {
        if (this.m_highlight != null)
        {
            this.m_isHighlighted = highlightOn;
            ActorStateType stateType = !this.m_isHighlighted ? ActorStateType.HIGHLIGHT_OFF : ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE;
            this.m_highlight.ChangeState(stateType);
        }
    }

    private void Flip()
    {
        object[] args = new object[] { "amount", new Vector3(180f, 0f, 0f), "time", 0.5f, "easeType", iTween.EaseType.easeOutElastic, "space", Space.Self, "oncomplete", "OnFlipComplete", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateAdd(base.gameObject, hashtable);
    }

    private void OnFlipComplete()
    {
        this.m_numFlips--;
        if (this.m_numFlips > 0)
        {
            this.Flip();
        }
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        if (this.m_highlight != null)
        {
            ActorStateType stateType = !this.m_isHighlighted ? ActorStateType.HIGHLIGHT_OFF : ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE;
            this.m_highlight.ChangeState(stateType);
        }
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        if (this.m_highlight != null)
        {
            ActorStateType stateType = !this.m_isHighlighted ? ActorStateType.HIGHLIGHT_MOUSE_OVER : ActorStateType.HIGHLIGHT_PRIMARY_MOUSE_OVER;
            this.m_highlight.ChangeState(stateType);
        }
    }

    protected override void OnRelease()
    {
        if (this.m_highlight != null)
        {
            this.m_isHighlighted = false;
            this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_OFF);
        }
    }
}


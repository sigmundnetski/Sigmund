using System;
using UnityEngine;

public class BnetBarMenuButton : PegUIElement
{
    public GameObject m_highlight;
    private bool m_selected;

    protected override void Awake()
    {
        base.Awake();
        this.UpdateHighlight();
    }

    public bool IsSelected()
    {
        return this.m_selected;
    }

    public void LockHighlight(bool isLocked)
    {
        this.m_highlight.SetActive(isLocked);
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        this.UpdateHighlight();
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        this.UpdateHighlight();
    }

    public void SetSelected(bool enable)
    {
        if (enable != this.m_selected)
        {
            this.m_selected = enable;
            this.UpdateHighlight();
        }
    }

    private bool ShouldBeHighlighted()
    {
        return (this.m_selected || (base.GetInteractionState() == PegUIElement.InteractionState.Over));
    }

    protected virtual void UpdateHighlight()
    {
        bool flag = this.ShouldBeHighlighted();
        if ((!flag && (GameMenu.Get() != null)) && GameMenu.Get().IsShown())
        {
            flag = true;
        }
        if (this.m_highlight.activeSelf != flag)
        {
            this.m_highlight.SetActive(flag);
        }
    }
}


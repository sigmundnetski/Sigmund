using System;
using UnityEngine;

public class FriendListUIElement : PegUIElement
{
    public GameObject m_Highlight;
    public FriendListUIElement m_ParentElement;
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
        if (!flag)
        {
            foreach (FriendListUIElement element in base.GetComponentsInChildren<FriendListUIElement>(true))
            {
                if (element.ShouldBeHighlighted())
                {
                    flag = true;
                    break;
                }
            }
        }
        if (this.m_Highlight.activeSelf != flag)
        {
            this.m_Highlight.SetActive(flag);
            if (this.m_ParentElement != null)
            {
                this.m_ParentElement.UpdateHighlight();
            }
        }
    }
}


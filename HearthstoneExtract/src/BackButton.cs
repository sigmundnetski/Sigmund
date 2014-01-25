using System;
using UnityEngine;

public class BackButton : PegUIElement
{
    public UberText m_backText;
    public GameObject m_highlight;

    protected override void Awake()
    {
        base.Awake();
        base.SetOriginalLocalPosition();
        this.m_highlight.SetActive(false);
        if (this.m_backText != null)
        {
            this.m_backText.Text = GameStrings.Get("GLOBAL_BACK");
        }
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        object[] args = new object[] { "position", base.GetOriginalLocalPosition(), "isLocal", true, "time", 0.15f };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
        this.m_highlight.SetActive(false);
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        Vector3 originalLocalPosition = base.GetOriginalLocalPosition();
        Vector3 vector2 = new Vector3(originalLocalPosition.x, originalLocalPosition.y + 0.5f, originalLocalPosition.z);
        object[] args = new object[] { "position", vector2, "isLocal", true, "time", 0.15f };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
        this.m_highlight.SetActive(true);
    }

    protected override void OnPress()
    {
        Vector3 originalLocalPosition = base.GetOriginalLocalPosition();
        Vector3 vector2 = new Vector3(originalLocalPosition.x, originalLocalPosition.y - 0.3f, originalLocalPosition.z);
        object[] args = new object[] { "position", vector2, "isLocal", true, "time", 0.15f };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
    }

    protected override void OnRelease()
    {
        object[] args = new object[] { "position", base.GetOriginalLocalPosition(), "isLocal", true, "time", 0.15f };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
    }
}


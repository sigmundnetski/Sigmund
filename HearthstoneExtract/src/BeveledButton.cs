using System;
using UnityEngine;

public class BeveledButton : PegUIElement
{
    public GameObject m_highlight;
    public TextMesh m_label;
    public UberText m_uberLabel;

    protected override void Awake()
    {
        base.Awake();
        base.SetOriginalLocalPosition();
        this.m_highlight.SetActive(false);
    }

    public UberText GetUberText()
    {
        return this.m_uberLabel;
    }

    public void Hide()
    {
        base.gameObject.SetActive(false);
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
        Vector3 vector2 = new Vector3(originalLocalPosition.x, originalLocalPosition.y + (0.5f * base.transform.localScale.y), originalLocalPosition.z);
        object[] args = new object[] { "position", vector2, "isLocal", true, "time", 0.15f };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
        this.m_highlight.SetActive(true);
    }

    protected override void OnPress()
    {
        Vector3 originalLocalPosition = base.GetOriginalLocalPosition();
        Vector3 vector2 = new Vector3(originalLocalPosition.x, originalLocalPosition.y - (0.3f * base.transform.localScale.y), originalLocalPosition.z);
        object[] args = new object[] { "position", vector2, "isLocal", true, "time", 0.15f };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
    }

    protected override void OnRelease()
    {
        object[] args = new object[] { "position", base.GetOriginalLocalPosition(), "isLocal", true, "time", 0.15f };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
    }

    public void SetText(string text)
    {
        if (this.m_uberLabel != null)
        {
            this.m_uberLabel.Text = text;
        }
        else
        {
            this.m_label.text = text;
        }
    }

    public void Show()
    {
        base.gameObject.SetActive(true);
        this.m_highlight.SetActive(false);
    }
}


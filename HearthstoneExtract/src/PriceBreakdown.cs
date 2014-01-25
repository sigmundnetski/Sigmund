using System;
using UnityEngine;

[Serializable]
public class PriceBreakdown
{
    public GameObject m_root;
    public UberText m_text;

    public void SetText(string text)
    {
        this.m_text.Text = text;
    }

    public void Show(bool show)
    {
        this.m_root.SetActive(show);
    }
}


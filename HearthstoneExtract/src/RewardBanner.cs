using System;
using UnityEngine;

public class RewardBanner : MonoBehaviour
{
    public UberText m_detailsText;
    public UberText m_headlineText;
    public UberText m_sourceText;

    public void SetText(string headline, string details, string source)
    {
        this.m_headlineText.Text = headline;
        this.m_detailsText.Text = details;
        this.m_sourceText.Text = source;
    }

    public string DetailsText
    {
        get
        {
            return this.m_detailsText.Text;
        }
    }

    public string HeadlineText
    {
        get
        {
            return this.m_headlineText.Text;
        }
    }

    public string SourceText
    {
        get
        {
            return this.m_sourceText.Text;
        }
    }
}


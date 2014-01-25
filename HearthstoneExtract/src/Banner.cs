using System;
using UnityEngine;

public class Banner : MonoBehaviour
{
    public UberText m_caption;
    public GameObject m_glowObject;
    public UberText m_headline;

    public void MoveGlowForBottomPlacement()
    {
        this.m_glowObject.transform.localPosition = new Vector3(this.m_glowObject.transform.localPosition.x, this.m_glowObject.transform.localPosition.y, 0f);
    }

    public void SetText(string headline)
    {
        this.m_headline.Text = headline;
        this.m_caption.gameObject.SetActive(false);
    }

    public void SetText(string headline, string caption)
    {
        this.m_headline.Text = headline;
        this.m_caption.Text = caption;
    }
}


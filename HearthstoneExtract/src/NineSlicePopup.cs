using System;
using UnityEngine;

public class NineSlicePopup : MonoBehaviour
{
    public NineSliceElement m_background;
    private Vector3 m_contentOffset;
    public ThreeSliceElement m_header;
    public Vector3 m_headerOffset;
    public UberText m_headerUberText;
    private Bounds m_initialBounds;
    private Vector3 m_initialScale;
    public Vector3 m_minDimensions;

    private void Awake()
    {
    }

    public void Hide()
    {
        base.gameObject.SetActive(false);
    }

    public void HideHeader()
    {
        this.m_header.gameObject.SetActive(false);
    }

    public void SetHeaderText(string t)
    {
        this.m_headerUberText.Text = t;
        this.m_headerUberText.UpdateNow();
        this.m_header.SetMiddleWidth(this.m_headerUberText.GetTextWorldSpaceBounds().size.x);
    }

    public void SetSize(float x, float y)
    {
        x = Mathf.Max(x, this.m_minDimensions.x);
        y = Mathf.Max(y, this.m_minDimensions.y);
        this.m_background.SetSize(x, y);
        this.m_header.transform.position = this.m_background.m_top.transform.position + this.m_headerOffset;
    }

    public void Show()
    {
        base.gameObject.SetActive(true);
        this.m_background.m_sizeQuad.SetActive(false);
    }
}


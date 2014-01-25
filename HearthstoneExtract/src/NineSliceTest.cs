using System;
using UnityEngine;

public class NineSliceTest : MonoBehaviour
{
    public float m_height = 1f;
    public NineSlicePopup m_popup;
    public ThreeSliceElement m_threeSlice;
    public float m_ThreeSliceWidth = 1f;
    public float m_width = 1f;

    private void Awake()
    {
    }

    private void Update()
    {
        this.m_popup.SetSize(this.m_width, this.m_height);
        if (this.m_threeSlice != null)
        {
            this.m_threeSlice.SetWidth(this.m_ThreeSliceWidth);
        }
    }
}


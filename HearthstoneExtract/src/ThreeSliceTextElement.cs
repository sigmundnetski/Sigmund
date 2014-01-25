using System;
using UnityEngine;

public class ThreeSliceTextElement : MonoBehaviour
{
    public UberText m_text;
    public ThreeSliceElement m_threeSlice;

    private float GetTextWidth()
    {
        return this.m_text.GetTextBounds().size.x;
    }

    public void Resize()
    {
        this.m_threeSlice.SetMiddleWidth(this.GetTextWidth());
    }

    public void SetText(string text)
    {
        this.m_text.Text = text;
        this.m_text.UpdateNow();
        this.Resize();
    }
}


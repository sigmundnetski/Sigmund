using System;
using UnityEngine;

public class MenuButton : PegUIElement
{
    public TextMesh m_label;

    public void SetText(string s)
    {
        this.m_label.text = s;
    }
}


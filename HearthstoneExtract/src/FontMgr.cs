using System;
using System.Collections.Generic;
using UnityEngine;

public class FontMgr : MonoBehaviour
{
    public List<Font> m_Fonts;
    private static FontMgr s_instance;

    private void Awake()
    {
        s_instance = this;
    }

    public static FontMgr Get()
    {
        return s_instance;
    }

    public Font GetFontByName(string name)
    {
        foreach (Font font in this.m_Fonts)
        {
            if (font.name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return font;
            }
        }
        return null;
    }
}


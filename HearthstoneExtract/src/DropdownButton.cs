using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DropdownButton : PegUIElement
{
    [CompilerGenerated]
    private static HandleClick <>f__am$cache3;
    public GameObject m_downButton;
    public GameObject m_upButton;

    public event HandleClick click;

    public DropdownButton()
    {
        if (<>f__am$cache3 == null)
        {
            <>f__am$cache3 = new HandleClick(DropdownButton.<click>m__3A);
        }
        this.click = <>f__am$cache3;
    }

    [CompilerGenerated]
    private static void <click>m__3A()
    {
    }

    protected override void OnRelease()
    {
        this.click();
    }

    public delegate void HandleClick();
}


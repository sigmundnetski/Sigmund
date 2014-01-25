using System;
using System.Runtime.CompilerServices;

public class DropdownCancelCatcher : PegUIElement
{
    [CompilerGenerated]
    private static HandleClick <>f__am$cache1;

    public event HandleClick click;

    public DropdownCancelCatcher()
    {
        if (<>f__am$cache1 == null)
        {
            <>f__am$cache1 = new HandleClick(DropdownCancelCatcher.<click>m__3B);
        }
        this.click = <>f__am$cache1;
    }

    [CompilerGenerated]
    private static void <click>m__3B()
    {
    }

    protected override void OnRelease()
    {
        this.click();
    }

    public delegate void HandleClick();
}


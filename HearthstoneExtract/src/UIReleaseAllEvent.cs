using System;

public class UIReleaseAllEvent : UIEvent
{
    private bool m_mouseIsOver;

    public UIReleaseAllEvent(bool mouseIsOver, PegUIElement element) : base(UIEventType.RELEASEALL, element)
    {
        this.m_mouseIsOver = mouseIsOver;
    }

    public bool GetMouseIsOver()
    {
        return this.m_mouseIsOver;
    }
}


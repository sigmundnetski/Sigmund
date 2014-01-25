using System;
using System.Runtime.CompilerServices;

public class UIEvent
{
    private PegUIElement m_element;
    private UIEventType m_eventType;

    public UIEvent(UIEventType eventType, PegUIElement element)
    {
        this.m_eventType = eventType;
        this.m_element = element;
    }

    public PegUIElement GetElement()
    {
        return this.m_element;
    }

    public UIEventType GetEventType()
    {
        return this.m_eventType;
    }

    public delegate void Handler(UIEvent e);
}


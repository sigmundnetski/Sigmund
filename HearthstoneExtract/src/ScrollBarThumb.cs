using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ScrollBarThumb : PegUIElement
{
    private bool m_isDragging;
    private List<DelStartDraggingListener> m_startDraggingListeners = new List<DelStartDraggingListener>();

    public bool IsDragging()
    {
        return this.m_isDragging;
    }

    protected override void OnHold()
    {
        this.StartDragging();
    }

    public void RegisterStartDraggingListener(DelStartDraggingListener listener)
    {
        if (!this.m_startDraggingListeners.Contains(listener))
        {
            this.m_startDraggingListeners.Add(listener);
        }
    }

    public bool RemoveStartDraggingListener(DelStartDraggingListener listener)
    {
        return this.m_startDraggingListeners.Remove(listener);
    }

    public void StartDragging()
    {
        this.m_isDragging = true;
        Scrollbar component = base.transform.parent.GetComponent<Scrollbar>();
        foreach (DelStartDraggingListener listener in this.m_startDraggingListeners)
        {
            listener(component);
        }
    }

    public void StopDragging()
    {
        this.m_isDragging = false;
    }

    public delegate void DelStartDraggingListener(Scrollbar scrollbar);
}


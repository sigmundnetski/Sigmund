using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PegUIElement : MonoBehaviour
{
    private Collider m_collider;
    private PegCursor.Mode m_cursorDownOverride = PegCursor.Mode.NONE;
    private PegCursor.Mode m_cursorOverOverride = PegCursor.Mode.NONE;
    private object m_data;
    private bool m_doubleClickEnabled;
    private float m_dragTolerance = 0.7f;
    private bool m_enabled = true;
    private Dictionary<UIEventType, List<UIEvent.Handler>> m_eventListeners = new Dictionary<UIEventType, List<UIEvent.Handler>>();
    private bool m_focused;
    private InteractionState m_interactionState;
    private MeshFilter m_meshFilter;
    private Vector3 m_originalLocalPosition;
    private bool m_receiveOverWithMouseDown;
    private bool m_receiveReleaseWithoutMouseDown;
    private MeshRenderer m_renderer;

    public virtual bool AddEventListener(UIEventType type, UIEvent.Handler handler)
    {
        List<UIEvent.Handler> list;
        if (!this.m_eventListeners.TryGetValue(type, out list))
        {
            list = new List<UIEvent.Handler>();
            this.m_eventListeners.Add(type, list);
            list.Add(handler);
            return true;
        }
        if (list.Contains(handler))
        {
            return false;
        }
        list.Add(handler);
        return true;
    }

    protected virtual void Awake()
    {
        this.m_doubleClickEnabled = this.HasOverriddenDoubleClick();
    }

    private void DispatchEvent(UIEvent e)
    {
        List<UIEvent.Handler> list;
        if (this.m_eventListeners.TryGetValue(e.GetEventType(), out list))
        {
            foreach (UIEvent.Handler handler in list.ToArray())
            {
                handler(e);
            }
        }
    }

    public PegCursor.Mode GetCursorDown()
    {
        return this.m_cursorDownOverride;
    }

    public PegCursor.Mode GetCursorOver()
    {
        return this.m_cursorOverOverride;
    }

    public object GetData()
    {
        return this.m_data;
    }

    public bool GetDoubleClickEnabled()
    {
        return this.m_doubleClickEnabled;
    }

    public float GetDragTolerance()
    {
        return this.m_dragTolerance;
    }

    public InteractionState GetInteractionState()
    {
        return this.m_interactionState;
    }

    public Vector3 GetOriginalLocalPosition()
    {
        return this.m_originalLocalPosition;
    }

    public bool GetReceiveOverWithMouseDown()
    {
        return this.m_receiveOverWithMouseDown;
    }

    public bool GetReceiveReleaseWithoutMouseDown()
    {
        return this.m_receiveReleaseWithoutMouseDown;
    }

    public bool HasEventListener(UIEventType type)
    {
        List<UIEvent.Handler> list;
        if (!this.m_eventListeners.TryGetValue(type, out list))
        {
            return false;
        }
        return (list.Count > 0);
    }

    private bool HasOverriddenDoubleClick()
    {
        System.Type type = base.GetType();
        MethodInfo method = typeof(PegUIElement).GetMethod("OnDoubleClick", BindingFlags.NonPublic | BindingFlags.Instance);
        return GeneralUtils.IsOverriddenMethod(type.GetMethod("OnDoubleClick", BindingFlags.NonPublic | BindingFlags.Instance), method);
    }

    public bool IsEnabled()
    {
        return this.m_enabled;
    }

    protected virtual void OnDoubleClick()
    {
    }

    protected virtual void OnHold()
    {
    }

    protected virtual void OnOut(InteractionState oldState)
    {
    }

    protected virtual void OnOver(InteractionState oldState)
    {
    }

    protected virtual void OnPress()
    {
    }

    protected virtual void OnRelease()
    {
    }

    protected virtual void OnReleaseAll(bool mouseIsOver)
    {
    }

    protected virtual void OnRightClick()
    {
    }

    public virtual bool RemoveEventListener(UIEventType type, UIEvent.Handler handler)
    {
        List<UIEvent.Handler> list;
        if (!this.m_eventListeners.TryGetValue(type, out list))
        {
            return false;
        }
        return list.Remove(handler);
    }

    public void SetCursorDown(PegCursor.Mode mode)
    {
        this.m_cursorDownOverride = mode;
    }

    public void SetCursorOver(PegCursor.Mode mode)
    {
        this.m_cursorOverOverride = mode;
    }

    public void SetData(object data)
    {
        this.m_data = data;
    }

    public void SetDragTolerance(float newTolerance)
    {
        this.m_dragTolerance = newTolerance;
    }

    public void SetEnabled(bool enabled)
    {
        this.m_enabled = enabled;
        if (!this.m_enabled)
        {
            this.m_focused = false;
        }
    }

    public void SetOriginalLocalPosition()
    {
        this.SetOriginalLocalPosition(base.transform.localPosition);
    }

    public void SetOriginalLocalPosition(Vector3 pos)
    {
        this.m_originalLocalPosition = pos;
    }

    public void SetReceiveOverWithMouseDown(bool receiveOverWithMouseDown)
    {
        this.m_receiveOverWithMouseDown = receiveOverWithMouseDown;
    }

    public void SetReceiveReleaseWithoutMouseDown(bool receiveReleaseWithoutMouseDown)
    {
        this.m_receiveReleaseWithoutMouseDown = receiveReleaseWithoutMouseDown;
    }

    public void TriggerDoubleClick()
    {
        if (this.m_enabled)
        {
            this.m_interactionState = InteractionState.Down;
            this.OnDoubleClick();
            this.DispatchEvent(new UIEvent(UIEventType.DOUBLECLICK, this));
        }
    }

    public void TriggerHold()
    {
        if (this.m_enabled)
        {
            this.m_interactionState = InteractionState.Down;
            this.OnHold();
            this.DispatchEvent(new UIEvent(UIEventType.HOLD, this));
        }
    }

    public void TriggerOut()
    {
        if (this.m_enabled)
        {
            this.m_focused = false;
            InteractionState interactionState = this.m_interactionState;
            this.m_interactionState = InteractionState.Out;
            this.OnOut(interactionState);
            this.DispatchEvent(new UIEvent(UIEventType.ROLLOUT, this));
        }
    }

    public void TriggerOver()
    {
        if (this.m_enabled && !this.m_focused)
        {
            this.m_focused = true;
            InteractionState interactionState = this.m_interactionState;
            this.m_interactionState = InteractionState.Over;
            this.OnOver(interactionState);
            this.DispatchEvent(new UIEvent(UIEventType.ROLLOVER, this));
        }
    }

    public void TriggerPress()
    {
        if (this.m_enabled)
        {
            this.m_focused = true;
            this.m_interactionState = InteractionState.Down;
            this.OnPress();
            this.DispatchEvent(new UIEvent(UIEventType.PRESS, this));
        }
    }

    public void TriggerRelease()
    {
        if (this.m_enabled)
        {
            this.m_interactionState = InteractionState.Up;
            this.OnRelease();
            this.DispatchEvent(new UIEvent(UIEventType.RELEASE, this));
        }
    }

    public void TriggerReleaseAll(bool mouseIsOver)
    {
        if (this.m_enabled)
        {
            this.m_interactionState = InteractionState.Up;
            this.OnReleaseAll(mouseIsOver);
            this.DispatchEvent(new UIReleaseAllEvent(mouseIsOver, this));
        }
    }

    public void TriggerRightClick()
    {
        if (this.m_enabled)
        {
            this.OnRightClick();
            this.DispatchEvent(new UIEvent(UIEventType.RIGHTCLICK, this));
        }
    }

    public enum InteractionState
    {
        None,
        Out,
        Over,
        Down,
        Up,
        Disabled
    }
}


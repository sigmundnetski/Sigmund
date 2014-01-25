using System;

public class EventListener<Delegate>
{
    protected Delegate m_callback;
    protected object m_userData;

    public EventListener()
    {
    }

    public EventListener(Delegate callback, object userData)
    {
        this.m_callback = callback;
        this.m_userData = userData;
    }

    public override bool Equals(object obj)
    {
        EventListener<Delegate> listener = obj as EventListener<Delegate>;
        if (listener == null)
        {
            return base.Equals(obj);
        }
        return (this.m_callback.Equals(listener.m_callback) && (this.m_userData == listener.m_userData));
    }

    public Delegate GetCallback()
    {
        return this.m_callback;
    }

    public override int GetHashCode()
    {
        int num = 0x17;
        if (this.m_callback != null)
        {
            num = (num * 0x11) + this.m_callback.GetHashCode();
        }
        if (this.m_userData != null)
        {
            num = (num * 0x11) + this.m_userData.GetHashCode();
        }
        return num;
    }

    public object GetUserData()
    {
        return this.m_userData;
    }

    public void SetCallback(Delegate callback)
    {
        this.m_callback = callback;
    }

    public void SetUserData(object userData)
    {
        this.m_userData = userData;
    }
}


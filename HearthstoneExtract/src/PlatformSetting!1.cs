using System;

public class PlatformSetting<T>
{
    public T Setting;
    public bool WasSet;

    public PlatformSetting()
    {
        this.Setting = default(T);
    }

    public T Get()
    {
        return this.Setting;
    }

    public void Set(T val)
    {
        this.Setting = val;
        this.WasSet = true;
    }
}


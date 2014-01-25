using System;
using UnityEngine;

public class PlatformDependentValue<T>
{
    private PlatformSetting<T> AndroidSetting;
    private T defaultValue;
    private PlatformSetting<T> HighMemorySetting;
    private PlatformSetting<T> iOSSetting;
    private PlatformSetting<T> LowMemorySetting;
    private PlatformSetting<T> MacSetting;
    private PlatformSetting<T> MediumMemorySetting;
    private PlatformSetting<T> MiniTabletSetting;
    private PlatformSetting<T> MouseSetting;
    private PlatformSetting<T> PCSetting;
    private PlatformSetting<T> PhoneSetting;
    private bool resolved;
    private T result;
    private PlatformSetting<T> TabletSetting;
    private PlatformSetting<T> TouchSetting;
    private PlatformCategory type;

    public PlatformDependentValue(PlatformCategory t)
    {
        this.PCSetting = new PlatformSetting<T>();
        this.MacSetting = new PlatformSetting<T>();
        this.iOSSetting = new PlatformSetting<T>();
        this.AndroidSetting = new PlatformSetting<T>();
        this.TabletSetting = new PlatformSetting<T>();
        this.MiniTabletSetting = new PlatformSetting<T>();
        this.PhoneSetting = new PlatformSetting<T>();
        this.MouseSetting = new PlatformSetting<T>();
        this.TouchSetting = new PlatformSetting<T>();
        this.LowMemorySetting = new PlatformSetting<T>();
        this.MediumMemorySetting = new PlatformSetting<T>();
        this.HighMemorySetting = new PlatformSetting<T>();
        this.type = t;
    }

    private T GetInputSetting(InputCategory input)
    {
        switch (input)
        {
            case InputCategory.Mouse:
                if (this.MouseSetting.WasSet)
                {
                    return this.Mouse;
                }
                break;

            case InputCategory.Touch:
                return (!this.TouchSetting.WasSet ? this.GetInputSetting(InputCategory.Mouse) : this.Touch);
        }
        Debug.LogError("Could not find input dependent value");
        return default(T);
    }

    private T GetMemorySetting(MemoryCategory memory)
    {
        switch (memory)
        {
            case MemoryCategory.Low:
                if (!this.LowMemorySetting.WasSet)
                {
                    break;
                }
                return this.LowMemory;

            case MemoryCategory.Medium:
                return (!this.MediumMemorySetting.WasSet ? this.GetMemorySetting(MemoryCategory.Low) : this.MediumMemory);

            case MemoryCategory.High:
                return (!this.HighMemorySetting.WasSet ? this.GetMemorySetting(MemoryCategory.Medium) : this.HighMemory);
        }
        Debug.LogError("Could not find memory dependent value");
        return default(T);
    }

    private T GetOSSetting(OSCategory os)
    {
        switch (os)
        {
            case OSCategory.PC:
                if (!this.PCSetting.WasSet)
                {
                    break;
                }
                return this.PC;

            case OSCategory.Mac:
                return (!this.MacSetting.WasSet ? this.GetOSSetting(OSCategory.PC) : this.Mac);

            case OSCategory.iOS:
                return (!this.iOSSetting.WasSet ? this.GetOSSetting(OSCategory.PC) : this.iOS);

            case OSCategory.Android:
                return (!this.AndroidSetting.WasSet ? this.GetOSSetting(OSCategory.PC) : this.Android);
        }
        Debug.LogError("Could not find OS dependent value");
        return default(T);
    }

    private T GetScreenSetting(ScreenCategory screen)
    {
        switch (screen)
        {
            case ScreenCategory.PC:
                if (!this.PCSetting.WasSet)
                {
                    break;
                }
                return this.PC;

            case ScreenCategory.Tablet:
                return (!this.TabletSetting.WasSet ? this.GetScreenSetting(ScreenCategory.PC) : this.Tablet);

            case ScreenCategory.Phone:
                return (!this.PhoneSetting.WasSet ? this.GetScreenSetting(ScreenCategory.Tablet) : this.Phone);
        }
        Debug.LogError("Could not find screen dependent value");
        return default(T);
    }

    public static implicit operator T(PlatformDependentValue<T> val)
    {
        return val.Value;
    }

    public void Reset()
    {
        this.resolved = false;
    }

    public T Android
    {
        get
        {
            return this.AndroidSetting.Get();
        }
        set
        {
            this.AndroidSetting.Set(value);
        }
    }

    public T HighMemory
    {
        get
        {
            return this.HighMemorySetting.Get();
        }
        set
        {
            this.HighMemorySetting.Set(value);
        }
    }

    public T iOS
    {
        get
        {
            return this.iOSSetting.Get();
        }
        set
        {
            this.iOSSetting.Set(value);
        }
    }

    public T LowMemory
    {
        get
        {
            return this.LowMemorySetting.Get();
        }
        set
        {
            this.LowMemorySetting.Set(value);
        }
    }

    public T Mac
    {
        get
        {
            return this.MacSetting.Get();
        }
        set
        {
            this.MacSetting.Set(value);
        }
    }

    public T MediumMemory
    {
        get
        {
            return this.MediumMemorySetting.Get();
        }
        set
        {
            this.MediumMemorySetting.Set(value);
        }
    }

    public T Mouse
    {
        get
        {
            return this.TouchSetting.Get();
        }
        set
        {
            this.TouchSetting.Set(value);
        }
    }

    public T PC
    {
        get
        {
            return this.PCSetting.Get();
        }
        set
        {
            this.PCSetting.Set(value);
        }
    }

    public T Phone
    {
        get
        {
            return this.MiniTabletSetting.Get();
        }
        set
        {
            this.MiniTabletSetting.Set(value);
        }
    }

    public T Tablet
    {
        get
        {
            return this.TabletSetting.Get();
        }
        set
        {
            this.TabletSetting.Set(value);
        }
    }

    public T Touch
    {
        get
        {
            return this.MouseSetting.Get();
        }
        set
        {
            this.MouseSetting.Set(value);
        }
    }

    private T Value
    {
        get
        {
            if (!this.resolved)
            {
                switch (this.type)
                {
                    case PlatformCategory.OS:
                        this.result = this.GetOSSetting(PlatformSettings.OS);
                        break;

                    case PlatformCategory.Screen:
                        this.result = this.GetScreenSetting(PlatformSettings.Screen);
                        break;

                    case PlatformCategory.Memory:
                        this.result = this.GetMemorySetting(PlatformSettings.Memory);
                        break;

                    case PlatformCategory.Input:
                        this.result = this.GetInputSetting(PlatformSettings.Input);
                        break;
                }
                this.resolved = true;
            }
            return this.result;
        }
    }
}


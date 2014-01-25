using System;

public class DemoMgr
{
    private const bool LOAD_STORED_SETTING = false;
    private DemoMode m_mode;
    private static DemoMgr s_instance;

    public static DemoMgr Get()
    {
        if (s_instance == null)
        {
            s_instance = new DemoMgr();
        }
        return s_instance;
    }

    public DemoMode GetMode()
    {
        return this.m_mode;
    }

    public DemoMode GetModeFromString(string modeString)
    {
        try
        {
            return EnumUtils.GetEnum<DemoMode>(modeString, StringComparison.OrdinalIgnoreCase);
        }
        catch (Exception)
        {
            return DemoMode.NONE;
        }
    }

    private string GetStoredGameMode()
    {
        return null;
    }

    public void Initialize()
    {
        string storedGameMode = this.GetStoredGameMode();
        if (storedGameMode == null)
        {
            storedGameMode = Vars.Key("Demo.Mode").GetStr("NONE");
        }
        this.SetModeFromString(storedGameMode);
    }

    public void SetMode(DemoMode mode)
    {
        this.m_mode = mode;
    }

    public void SetModeFromString(string modeString)
    {
        this.m_mode = this.GetModeFromString(modeString);
    }
}


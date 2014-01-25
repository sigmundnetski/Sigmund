using System;

public class PracticeScene : PlayGameScene
{
    private bool m_practiceTrayIsLoaded;
    private static PracticeScene s_instance;

    protected override void Awake()
    {
        base.Awake();
        s_instance = this;
        CheatMgr.Get().RegisterCheatHandler("replaymissions", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_replaymissions));
        CheatMgr.Get().RegisterCheatHandler("replaymission", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_replaymissions));
    }

    public static PracticeScene Get()
    {
        return s_instance;
    }

    public override string GetScreenName()
    {
        return "Practice";
    }

    protected override bool IsLoaded()
    {
        if (!this.m_practiceTrayIsLoaded)
        {
            return false;
        }
        return base.IsLoaded();
    }

    private bool OnProcessCheat_replaymissions(string func, string[] args, string rawArgs)
    {
        AssetLoader.Get().LoadActor("ReplayMission");
        return true;
    }

    public void PracticeTrayLoaded()
    {
        this.m_practiceTrayIsLoaded = true;
    }

    public override void Unload()
    {
        base.Unload();
        PracticeDisplay.Get().Unload();
        this.m_practiceTrayIsLoaded = false;
        CheatMgr.Get().UnregisterCheatHandler("replaymissions", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_replaymissions));
        CheatMgr.Get().UnregisterCheatHandler("replaymission", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_replaymissions));
    }
}


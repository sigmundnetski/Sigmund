using System;

public class FriendlyScene : PlayGameScene
{
    private static FriendlyScene s_instance;

    protected override void Awake()
    {
        base.Awake();
        s_instance = this;
    }

    public static FriendlyScene Get()
    {
        return s_instance;
    }

    public override string GetScreenName()
    {
        return "Friendly";
    }

    public override void Unload()
    {
        base.Unload();
        FriendlyDisplay.Get().Unload();
    }
}


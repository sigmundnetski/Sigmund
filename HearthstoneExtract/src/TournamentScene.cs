using System;

public class TournamentScene : PlayGameScene
{
    private static TournamentScene s_instance;

    protected override void Awake()
    {
        base.Awake();
        s_instance = this;
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_BUTTON_TOURNAMENT);
    }

    public static TournamentScene Get()
    {
        return s_instance;
    }

    public override string GetScreenName()
    {
        return "Tournament";
    }

    public override void Unload()
    {
        base.Unload();
        TournamentDisplay.Get().Unload();
    }
}


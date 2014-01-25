using System;
using UnityEngine;

public class DeckPickerTray
{
    private bool m_registeredHandlers;
    private static DeckPickerTray s_instance;

    public void CancelMatch()
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CANCEL_MATCHMAKER);
        Network.MakeMatch(0L);
        FriendChallengeMgr.Get().OnLeftMatchmakerQueue();
    }

    public static DeckPickerTray Get()
    {
        if (s_instance == null)
        {
            s_instance = new DeckPickerTray();
        }
        return s_instance;
    }

    private bool OnBnetError(BnetErrorInfo info, object userData)
    {
        if (info.GetFeature() == BnetFeature.Games)
        {
            switch (info.GetError())
            {
                case BnetError.GAME_MASTER_INVALID_FACTORY:
                case BnetError.GAME_MASTER_NO_GAME_SERVER:
                case BnetError.GAME_MASTER_NO_FACTORY:
                    this.OnGameDenied();
                    return true;
            }
        }
        return false;
    }

    private void OnGameCanceled()
    {
        Network.GameCancelInfo gameCancelInfo = Network.GetGameCancelInfo();
        DeckPickerTrayDisplay.Get().OnGameCanceled(gameCancelInfo);
    }

    private void OnGameDenied()
    {
        DeckPickerTrayDisplay.Get().OnGameDenied();
    }

    private void OnGameStarting()
    {
        ConnectAPI.NoGameReply();
        SceneMgr.Get().SetNextMode(SceneMgr.Mode.GAMEPLAY);
        LoadingScreen.Get().SetFreezeFrameCamera(Box.Get().GetCamera());
        LoadingScreen.Get().AddTransitionObject(Box.Get().GetAudioListener());
        DeckPickerTrayDisplay.Get().OnGameStarting();
    }

    private void OnGotoGameServer(BattleNet.GameServerInfo info)
    {
        Network.Get().GotoGameServer(info);
        Version.bobNetAddress = info.Address;
        Version.serverChangelist = info.Version;
        DeckPickerTrayDisplay.Get().OnGotoGameServer();
    }

    private void OnGUI()
    {
        Vector2 vector = new Vector2(100f, 30f);
        Vector2 vector2 = new Vector2(Screen.width - ((Screen.width * 0.02f) + vector.x), Screen.height * 0.05f);
        Vector2 vector3 = vector2;
        if (GUI.Button(new Rect(vector3.x, vector3.y, vector.x, vector.y), "To Hub"))
        {
            Log.Bob.Print("MatchMaker.OnGUI.ToHub");
            Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CANCEL_MATCHMAKER);
            Network.MakeMatch(0L);
            SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
        }
        vector3.y += 1.5f * vector.y;
    }

    private void OnQueueEvent(BattleNet.QueueEvent queueEvent)
    {
        switch (queueEvent.EventType)
        {
            case BattleNet.QueueEvent.Type.QUEUE_ENTER:
            case BattleNet.QueueEvent.Type.QUEUE_DELAY:
                DeckPickerTrayDisplay.Get().ShowMatchingPopup();
                break;

            case BattleNet.QueueEvent.Type.QUEUE_DELAY_ERROR:
            case BattleNet.QueueEvent.Type.QUEUE_AMM_ERROR:
                this.OnGameDenied();
                break;

            case BattleNet.QueueEvent.Type.QUEUE_GAME_STARTED:
                this.OnGotoGameServer(queueEvent.GameServer);
                break;

            case BattleNet.QueueEvent.Type.ABORT_CLIENT_DROPPED:
            {
                object[] args = new object[] { queueEvent.EventType };
                Log.Mike.Print("DeckPickerTray.OnQueueEvent() - ignoring {0}", args);
                break;
            }
        }
    }

    public void RegisterHandlers()
    {
        if (!this.m_registeredHandlers)
        {
            Network network = Network.Get();
            network.RegisterNetHandler(Network.PacketID.GAME_STARTING, new Network.NetHandler(this.OnGameStarting));
            network.RegisterNetHandler(Network.PacketID.GAME_CANCELED, new Network.NetHandler(this.OnGameCanceled));
            network.RegisterGameQueueHandler(new Network.GameQueueHandler(this.OnQueueEvent));
            network.AddBnetErrorListener(BnetFeature.Games, new Network.BnetErrorCallback(this.OnBnetError));
            this.m_registeredHandlers = true;
        }
    }

    public void Unload()
    {
        this.UnregisterHandlers();
        DefLoader.Get().ClearCardDefs();
    }

    public void UnregisterHandlers()
    {
        if (this.m_registeredHandlers)
        {
            Network network = Network.Get();
            network.RemoveNetHandler(Network.PacketID.GAME_STARTING);
            network.RemoveNetHandler(Network.PacketID.GAME_CANCELED);
            network.RemoveGameQueueHandler(new Network.GameQueueHandler(this.OnQueueEvent));
            network.RemoveBnetErrorListener(BnetFeature.Games, new Network.BnetErrorCallback(this.OnBnetError));
            this.m_registeredHandlers = false;
        }
    }
}


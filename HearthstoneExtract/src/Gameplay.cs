using System;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : Scene
{
    private float m_boardProgress;
    private bool m_handledDisconnect;
    private bool m_loadAsync;
    private List<NameBanner> m_nameBanners = new List<NameBanner>();
    private float m_setToAsyncTimer;
    private bool m_unloading;
    private static Gameplay s_instance;
    private const float TIME_TO_SET_ASYNC = 10f;

    private bool AreCriticalAssetsLoaded()
    {
        if (Board.Get() == null)
        {
            return false;
        }
        if (BoardCameras.Get() == null)
        {
            return false;
        }
        if (BoardStandardGame.Get() == null)
        {
            return false;
        }
        if (MissionMgr.Get().IsTutorial() && (BoardTutorial.Get() == null))
        {
            return false;
        }
        if (EndTurnButton.Get() == null)
        {
            return false;
        }
        if (TurnTimer.Get() == null)
        {
            return false;
        }
        if (CardColorSwitcher.Get() == null)
        {
            return false;
        }
        if (GameState.Get().GetAttackSpellControllerPrefab() == null)
        {
            return false;
        }
        if (GameState.Get().GetSecretSpellControllerPrefab() == null)
        {
            return false;
        }
        return true;
    }

    protected override void Awake()
    {
        base.Awake();
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_GAME_START);
        s_instance = this;
        CheatMgr.Get().RegisterCheatHandler("save me", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_saveme));
        GameState.Initialize().RegisterCreateGameListener(new GameState.CreateGameCallback(this.OnGameStateCreateGame));
        AssetLoader.Get().LoadGameObject("AttackSpellController", new AssetLoader.GameObjectCallback(this.OnAttackSpellControllerLoaded));
        AssetLoader.Get().LoadGameObject("SecretSpellController", new AssetLoader.GameObjectCallback(this.OnSecretSpellControllerLoaded));
        AssetLoader.Get().LoadGameObject("ThinkEmoteController");
        AssetLoader.Get().LoadGameObject("NameBanner", new AssetLoader.GameObjectCallback(this.OnPlayerBannerLoaded));
        AssetLoader.Get().LoadGameObject("NameBanner", new AssetLoader.GameObjectCallback(this.OnOpponentBannerLoaded));
        MissionMgr.Get().OnMissionStarted();
        this.m_boardProgress = -1f;
    }

    public static Gameplay Get()
    {
        return s_instance;
    }

    public override bool IsUnloading()
    {
        return this.m_unloading;
    }

    private void LayoutProgressGUI()
    {
        if (this.m_boardProgress >= 0f)
        {
            Vector2 vector = new Vector2(150f, 30f);
            Vector2 vector2 = new Vector2((Screen.width * 0.5f) - (vector.x * 0.5f), (Screen.height * 0.5f) - (vector.y * 0.5f));
            GUI.Box(new Rect(vector2.x, vector2.y, vector.x, vector.y), string.Empty);
            GUI.Box(new Rect(vector2.x, vector2.y, this.m_boardProgress * vector.x, vector.y), string.Empty);
            GUI.TextField(new Rect(vector2.x, vector2.y, vector.x, vector.y), string.Format("{0:0}%", this.m_boardProgress * 100f));
        }
    }

    private void LayoutSpellControllerKillTimeGUI()
    {
        DateTime latestKillTimeForAllSpellControllers = GameState.Get().GetLatestKillTimeForAllSpellControllers();
        if (latestKillTimeForAllSpellControllers != DateTime.FromBinary(0L))
        {
            Vector2 vector = new Vector2(150f, 40f);
            Vector2 vector2 = new Vector2(Screen.width - ((Screen.width * 0.01f) + vector.x), Screen.height - (vector.y + (Screen.height * 0.1f)));
            Vector2 vector3 = vector2;
            Color contentColor = GUI.contentColor;
            GUI.contentColor = Color.red;
            string text = string.Format("Last spell kill:\n{0}", latestKillTimeForAllSpellControllers.ToShortTimeString());
            GUI.Box(new Rect(vector3.x, vector3.y, vector.x, vector.y), text);
            GUI.contentColor = contentColor;
        }
    }

    private void NotifyPlayersOfBoardLoad()
    {
        foreach (Player player in GameState.Get().GetPlayerMap().Values)
        {
            player.OnBoardLoaded();
        }
    }

    private void OnAttackSpellControllerLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("Gameplay.OnAttackSpellControllerLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            AttackSpellController component = go.GetComponent<AttackSpellController>();
            if (component == null)
            {
                Debug.LogError(string.Format("Gameplay.OnAttackSpellControllerLoaded() - ERROR \"{0}\" has no {1} component", name, typeof(AttackSpellController)));
            }
            else
            {
                GameState.Get().SetAttackSpellControllerPrefab(component);
            }
        }
    }

    private void OnBoardCamerasLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("Gameplay.OnBoardCamerasLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            go.transform.parent = Board.Get().transform;
            PegUI.Get().SetInputCamera(Camera.main);
            AssetLoader.Get().LoadActor("CardTypeBanner");
            AssetLoader.Get().LoadActor("BigCard");
        }
    }

    private void OnBoardLoaded(string boardName, GameObject boardObject, object callbackData)
    {
        this.m_boardProgress = -1f;
        if (boardObject == null)
        {
            Debug.LogError(string.Format("Gameplay.OnBoardLoaded() - FAILED to load board \"{0}\"", boardName));
        }
        else
        {
            AssetLoader.Get().LoadGameObject("BoardCameras", new AssetLoader.GameObjectCallback(this.OnBoardCamerasLoaded));
            AssetLoader.Get().LoadGameObject("BoardStandardGame", new AssetLoader.GameObjectCallback(this.OnBoardStandardGameLoaded));
            if (MissionMgr.Get().IsTutorial())
            {
                AssetLoader.Get().LoadGameObject("BoardTutorial", new AssetLoader.GameObjectCallback(this.OnBoardTutorialLoaded));
            }
        }
    }

    private void OnBoardProgressUpdate(string boardName, float progress, object callbackData)
    {
        this.m_boardProgress = progress;
    }

    private void OnBoardStandardGameLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("Gameplay.OnBoardStandardGameLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            go.transform.parent = Board.Get().transform;
            AssetLoader.Get().LoadActor("Button_EndTurn", new AssetLoader.GameObjectCallback(this.OnEndTurnButtonLoaded));
            AssetLoader.Get().LoadActor("TurnTimer", new AssetLoader.GameObjectCallback(this.OnTurnTimerLoaded));
            this.NotifyPlayersOfBoardLoad();
        }
    }

    private void OnBoardTutorialLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("Gameplay.OnBoardTutorialLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            go.transform.parent = Board.Get().transform;
        }
    }

    private void OnEndGameState()
    {
        Network.StartGame();
    }

    private void OnEndTurnButtonLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            Debug.LogError(string.Format("Gameplay.OnEndTurnButtonLoaded() - FAILED to load \"{0}\"", actorName));
        }
        else
        {
            EndTurnButton component = actorObject.GetComponent<EndTurnButton>();
            if (component == null)
            {
                Debug.LogError(string.Format("Gameplay.OnEndTurnButtonLoaded() - ERROR \"{0}\" has no {1} component", actorName, typeof(EndTurnButton)));
            }
            else
            {
                component.transform.position = Board.Get().FindBone("Button_EndTurn_Position").position;
            }
        }
    }

    private void OnGameSetup()
    {
        Network.GameSetup gameSetupInfo = Network.GetGameSetupInfo();
        string board = Cheats.Get().GetBoard();
        if (string.IsNullOrEmpty(board))
        {
            AssetLoader.Get().LoadBoard(gameSetupInfo.Board, new AssetLoader.GameObjectCallback(this.OnBoardLoaded));
        }
        else
        {
            AssetLoader.Get().LoadBoard(board, new AssetLoader.GameObjectCallback(this.OnBoardLoaded));
        }
        GameState.Get().OnGameSetup(gameSetupInfo);
    }

    private void OnGameStarting()
    {
        ConnectAPI.NoGameReply();
        SceneMgr.Get().ReloadMode();
    }

    private void OnGameStateCreateGame(object userData)
    {
        if (BoardStandardGame.Get() != null)
        {
            this.NotifyPlayersOfBoardLoad();
        }
    }

    private void OnGUI()
    {
        this.LayoutProgressGUI();
        if ((GameState.Get() != null) && Options.Get().GetBool(Option.HUD))
        {
            this.LayoutSpellControllerKillTimeGUI();
        }
    }

    private void OnMakeChoice()
    {
        Network.Choice choices = Network.GetChoices();
        GameState.Get().OnMakeChoice(choices);
    }

    private void OnNotification()
    {
        PlayErrors.DisplayNotification(Network.GetNotification());
    }

    private void OnOpponentBannerLoaded(string name, GameObject go, object callbackData)
    {
        NameBanner component = go.GetComponent<NameBanner>();
        component.SetPlayer(false);
        this.m_nameBanners.Add(component);
    }

    private void OnOpponentMouseOver()
    {
        EnemyActionHandler.Get().HandleAction(Network.GetUserUI());
    }

    private void OnOptionRejected()
    {
        int nAckOption = Network.GetNAckOption();
        GameState.Get().OnOptionRejected(nAckOption);
    }

    private void OnPickOption()
    {
        Network.Options options = Network.GetOptions();
        GameState.Get().OnPickOption(options);
    }

    private void OnPlayerBannerLoaded(string name, GameObject go, object callbackData)
    {
        NameBanner component = go.GetComponent<NameBanner>();
        component.SetPlayer(true);
        this.m_nameBanners.Add(component);
    }

    private void OnPowerHistory()
    {
        List<Network.PowerHistory> powerHistory = Network.GetPowerHistory();
        GameState.Get().OnPower(powerHistory);
    }

    private void OnPreload()
    {
        ConnectAPI.NoGameReply();
    }

    private bool OnProcessCheat_saveme(string func, string[] args, string rawArgs)
    {
        GameState.Get().DebugNukeServerBlocks();
        return true;
    }

    private void OnQueueEvent(BattleNet.QueueEvent queueEvent)
    {
        if (queueEvent.EventType == BattleNet.QueueEvent.Type.QUEUE_GAME_STARTED)
        {
            BattleNet.GameServerInfo gameServer = queueEvent.GameServer;
            Network.Get().GotoGameServer(gameServer);
            Version.bobNetAddress = gameServer.Address;
            Version.serverChangelist = gameServer.Version;
        }
    }

    private void OnSecretSpellControllerLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("Gameplay.OnSecretSpellControllerLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            SecretSpellController component = go.GetComponent<SecretSpellController>();
            if (component == null)
            {
                Debug.LogError(string.Format("Gameplay.OnSecretSpellControllerLoaded() - ERROR \"{0}\" has no {1} component", name, typeof(SecretSpellController)));
            }
            else
            {
                GameState.Get().SetSecretSpellControllerPrefab(component);
            }
        }
    }

    private void OnStartGameState()
    {
        ConnectAPI.NoGameReply();
    }

    private void OnTurnTimerLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            Debug.LogError(string.Format("Gameplay.OnTurnTimerLoaded() - FAILED to load \"{0}\"", actorName));
        }
        else
        {
            TurnTimer component = actorObject.GetComponent<TurnTimer>();
            if (component == null)
            {
                Debug.LogError(string.Format("Gameplay.OnTurnTimerLoaded() - ERROR \"{0}\" has no {1} component", actorName, typeof(TurnTimer)));
            }
            else
            {
                component.transform.position = Board.Get().FindBone("TurnTimerBone").position;
            }
        }
    }

    private void OnTurnTimerUpdate()
    {
        Network.TurnTimerInfo timeRemaining = Network.GetTimeRemaining();
        GameState.Get().OnTurnTimerUpdate(timeRemaining.Turn, timeRemaining.Seconds);
    }

    public void RemoveClassNames()
    {
        foreach (NameBanner banner in this.m_nameBanners)
        {
            banner.FadeClass();
        }
    }

    private void Start()
    {
        Network network = Network.Get();
        network.StartCountdown();
        network.RegisterNetHandler(Network.PacketID.START_GAMESTATE, new Network.NetHandler(this.OnStartGameState));
        network.RegisterNetHandler(Network.PacketID.FIN_GAMESTATE, new Network.NetHandler(this.OnEndGameState));
        network.RegisterNetHandler(Network.PacketID.POWER_HISTORY, new Network.NetHandler(this.OnPowerHistory));
        network.RegisterNetHandler(Network.PacketID.ENTITY_CHOICE, new Network.NetHandler(this.OnMakeChoice));
        network.RegisterNetHandler(Network.PacketID.ALL_OPTIONS, new Network.NetHandler(this.OnPickOption));
        network.RegisterNetHandler(Network.PacketID.GAME_SETUP, new Network.NetHandler(this.OnGameSetup));
        network.RegisterNetHandler(Network.PacketID.PRELOAD, new Network.NetHandler(this.OnPreload));
        network.RegisterNetHandler(Network.PacketID.NOTIFICATION, new Network.NetHandler(this.OnNotification));
        network.RegisterNetHandler(Network.PacketID.USER_UI, new Network.NetHandler(this.OnOpponentMouseOver));
        network.RegisterNetHandler(Network.PacketID.NACK_OPTION, new Network.NetHandler(this.OnOptionRejected));
        network.RegisterNetHandler(Network.PacketID.TURN_TIMER, new Network.NetHandler(this.OnTurnTimerUpdate));
        network.RegisterNetHandler(Network.PacketID.GAME_STARTING, new Network.NetHandler(this.OnGameStarting));
        network.RegisterGameQueueHandler(new Network.GameQueueHandler(this.OnQueueEvent));
        network.GetGameState();
        this.m_loadAsync = false;
        this.m_setToAsyncTimer = 0f;
    }

    public override void Unload()
    {
        this.m_unloading = true;
        bool flag = GameState.Get().IsGameOver();
        GameState.Shutdown();
        MissionMgr.Get().SetBusy(false);
        base.StopAllCoroutines();
        Network network = Network.Get();
        network.RemoveNetHandler(Network.PacketID.START_GAMESTATE);
        network.RemoveNetHandler(Network.PacketID.FIN_GAMESTATE);
        network.RemoveNetHandler(Network.PacketID.POWER_HISTORY);
        network.RemoveNetHandler(Network.PacketID.ENTITY_CHOICE);
        network.RemoveNetHandler(Network.PacketID.ALL_OPTIONS);
        network.RemoveNetHandler(Network.PacketID.NOTIFICATION);
        network.RemoveNetHandler(Network.PacketID.GAME_SETUP);
        network.RemoveNetHandler(Network.PacketID.PRELOAD);
        network.RemoveNetHandler(Network.PacketID.USER_UI);
        network.RemoveNetHandler(Network.PacketID.NACK_OPTION);
        network.RemoveNetHandler(Network.PacketID.TURN_TIMER);
        network.RemoveNetHandler(Network.PacketID.GAME_STARTING);
        network.RemoveGameQueueHandler(new Network.GameQueueHandler(this.OnQueueEvent));
        if (!flag)
        {
            Network.EndGame();
        }
        foreach (NameBanner banner in this.m_nameBanners)
        {
            UnityEngine.Object.DestroyImmediate(banner.gameObject);
        }
        DefLoader.Get().ClearCardDefs();
        CheatMgr.Get().UnregisterCheatHandler("save me", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_saveme));
        this.m_unloading = false;
    }

    private void Update()
    {
        Network.Get().ProcessNetwork();
        if (!Network.Get().GameServerActive() && !GameState.Get().IsGameOver())
        {
            if (!this.m_handledDisconnect)
            {
                LoadingScreen.Get().EnableTransition(false);
                SceneMgr.Get().SetNextMode(SceneMgr.Get().GetPrevMode());
                Error.AddWarningLoc("GLOBAL_ERROR_NETWORK_TITLE", "GLOBAL_ERROR_NETWORK_LOST_GAME_CONNECTION", new object[0]);
                this.m_handledDisconnect = true;
            }
        }
        else if (this.AreCriticalAssetsLoaded())
        {
            GameState.Get().Update();
            if (!this.m_loadAsync)
            {
                this.m_setToAsyncTimer += UnityEngine.Time.deltaTime;
                if (this.m_setToAsyncTimer >= 10f)
                {
                    AssetLoader.Get().SetImmediateLoading(false);
                    this.m_loadAsync = true;
                }
            }
        }
    }
}


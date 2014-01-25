using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class Network
{
    private DateTime lastCall = DateTime.Now;
    private DateTime lastCallReport = DateTime.Now;
    private static readonly TimeSpan LOGIN_TIMEOUT = new TimeSpan(0, 0, 5);
    private Dictionary<BnetFeature, List<BnetErrorListener>> m_bnetErrorListeners = new Dictionary<BnetFeature, List<BnetErrorListener>>();
    private ChallengeHandler m_challengeHandler;
    private FriendsHandler m_friendsHandler;
    private GameQueueHandler m_gameQueueHandler;
    private bool m_inDraftQueue;
    private DateTime m_loginStarted;
    private bool m_loginWaiting = true;
    private long m_matchingDeckId;
    private Dictionary<PacketID, NetHandler> m_netHandlers = new Dictionary<PacketID, NetHandler>();
    private PartyHandler m_partyHandler;
    private PresenceHandler m_presenceHandler;
    private WhisperHandler m_whisperHandler;
    public static readonly int NoPosition = 0;
    public static readonly int NoSubOption = -1;
    private static Network s_instance = new Network();
    private static bool s_running;
    private static readonly int TAG_LIST = 0x200;

    public static void AcceptFriendChallenge(BnetEntityId partyId)
    {
        BattleNet.AcceptPartyInvite(ref BnetEntityId.CreateForDll(partyId));
    }

    public static void AcceptFriendInvite(BnetInvitationId inviteId)
    {
        BattleNet.ManageFriendInvite(1, inviteId.GetVal());
    }

    public static AchieveList Achieves()
    {
        return ConnectAPI.GetAchieves();
    }

    public static void AckAchieveProgress(int ID, int ackProgress)
    {
        ConnectAPI.AckAchieveProgress(ID, ackProgress);
    }

    public static void AckCardSeenBefore(int assetID, CardFlair cardFlair)
    {
        ConnectAPI.AckCardSeen(assetID, (int) cardFlair.Premium);
    }

    public static void AckNotice(long ID)
    {
        if (NetCache.Get().RemoveNotice(ID))
        {
            ConnectAPI.AckNotice(ID);
        }
    }

    public void AddBnetErrorListener(BnetFeature feature, BnetErrorCallback callback)
    {
        this.AddBnetErrorListener(feature, callback, null);
    }

    public void AddBnetErrorListener(BnetFeature feature, BnetErrorCallback callback, object userData)
    {
        List<BnetErrorListener> list;
        BnetErrorListener item = new BnetErrorListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (!this.m_bnetErrorListeners.TryGetValue(feature, out list))
        {
            list = new List<BnetErrorListener>();
            this.m_bnetErrorListeners.Add(feature, list);
        }
        else if (list.Contains(item))
        {
            return;
        }
        list.Add(item);
    }

    public void AnswerChallenge(ulong challengeID, string answer)
    {
        IntPtr ptr = DLLUtils.NativeUtf8FromString(answer);
        BattleNet.AnswerChallenge(challengeID, ptr);
        DLLUtils.FreeNativeUtf8(ptr);
    }

    public static void AppAbort()
    {
        if (s_running)
        {
            MakeMatch(0L);
            BattleNet.AppQuit();
            PlayErrors.AppQuit();
            s_running = false;
        }
    }

    public static void AppQuit()
    {
        if (s_running)
        {
            TrackClient(TrackLevel.LEVEL_INFO, TrackWhat.TRACK_LOGOUT_STARTING);
            MakeMatch(0L);
            BattleNet.AppQuit();
            PlayErrors.AppQuit();
            s_running = false;
        }
    }

    public void AutoLogin()
    {
        string userName = GetUserName();
        int @int = Vars.Key("BobNet.Version").GetInt(1);
        ConnectAPI.AutoLogin(userName, @int);
        this.m_loginStarted = DateTime.Now;
    }

    public static BNetState BattleNetStatus()
    {
        return (BNetState) BattleNet.BattleNetStatus();
    }

    public static void BuyCard(int assetID, CardFlair cardFlair)
    {
        ConnectAPI.BuyCard(assetID, (int) cardFlair.Premium);
    }

    public void CancelChallenge(ulong challengeID)
    {
        BattleNet.CancelChallenge(challengeID);
    }

    public static void CancelPurchase(bool isAutoCanceled)
    {
        ConnectAPI.AbortPurchase(isAutoCanceled);
    }

    public static void ChooseFriendChallengeDeck(BnetEntityId partyId, long deckID)
    {
        BattleNet.SetPartyDeck(ref BnetEntityId.CreateForDll(partyId), deckID);
    }

    public static void CloseCardMarket()
    {
    }

    public static void ConfirmPurchase()
    {
        ConnectAPI.ConfirmPurchase();
    }

    public void CreateDeck(string name, int heroDatabaseAssetID)
    {
        Log.Rachelle.Print(string.Format("Network.CreateDeck {0}", name));
        ConnectAPI.CreateDeck(name, heroDatabaseAssetID);
    }

    public static void DeclineFriendChallenge(BnetEntityId partyId)
    {
        BattleNet.DeclinePartyInvite(ref BnetEntityId.CreateForDll(partyId));
    }

    public static void DeclineFriendInvite(BnetInvitationId inviteId)
    {
        BattleNet.ManageFriendInvite(3, inviteId.GetVal());
    }

    public void DefaultBnetErrorHandler(BnetErrorInfo info)
    {
        BnetError error = info.GetError();
        BnetError error2 = error;
        if (error2 != BnetError.OK)
        {
            if (error2 == BnetError.WAITING_FOR_DEPENDENCY)
            {
                return;
            }
            if (error2 == BnetError.TARGET_OFFLINE)
            {
                return;
            }
            if (error2 == BnetError.GAME_UTILITY_SERVER_NO_SERVER)
            {
                return;
            }
        }
        else
        {
            return;
        }
        UnityEngine.Debug.LogError(string.Format("Network.DefaultBnetErrorHandler() - {0}", info));
        switch (error)
        {
            case BnetError.RPC_PEER_DISCONNECTED:
                Error.AddFatalLoc("GLOBAL_ERROR_NETWORK_TITLE", "GLOBAL_ERROR_NETWORK_DISCONNECT", new object[0]);
                break;

            case BnetError.RPC_REQUEST_TIMED_OUT:
                Error.AddFatalLoc("GLOBAL_ERROR_NETWORK_TITLE", "GLOBAL_ERROR_NETWORK_UTIL_TIMEOUT", new object[0]);
                break;

            case BnetError.RPC_CONNECTION_TIMED_OUT:
                Error.AddFatalLoc("GLOBAL_ERROR_NETWORK_TITLE", "GLOBAL_ERROR_NETWORK_DISCONNECT", new object[0]);
                break;

            case BnetError.SESSION_DUPLICATE:
                Error.AddFatalLoc("GLOBAL_ERROR_NETWORK_TITLE", "GLOBAL_ERROR_NETWORK_DUPLICATE_LOGIN", new object[0]);
                break;

            case BnetError.SESSION_DISCONNECTED:
                Error.AddFatalLoc("GLOBAL_ERROR_NETWORK_TITLE", "GLOBAL_ERROR_NETWORK_DISCONNECT", new object[0]);
                break;

            case BnetError.DENIED:
                Error.AddFatalLoc("GLOBAL_ERROR_NETWORK_TITLE", "GLOBAL_ERROR_NETWORK_LOGIN_FAILURE", new object[0]);
                break;

            case BnetError.RPC_QUOTA_EXCEEDED:
                Error.AddFatalLoc("GLOBAL_ERROR_NETWORK_TITLE", "GLOBAL_ERROR_NETWORK_SPAM", new object[0]);
                break;

            default:
            {
                object[] messageArgs = new object[] { info };
                Error.AddDevFatal("Bnet Error", "Unhandled Error: {0}", messageArgs);
                break;
            }
        }
    }

    public void DeleteDeck(long deck)
    {
        Log.Rachelle.Print(string.Format("Network.DeleteDeck {0}", deck));
        ConnectAPI.DeleteDeck(deck);
    }

    public void DisableGameListings()
    {
        ConnectAPI.EnableGameListings(0);
    }

    public void EnableGameListings()
    {
        ConnectAPI.EnableGameListings(1);
    }

    public static void EndGame()
    {
        ConnectAPI.EndGame();
    }

    public static void FindOutCurrentDraftState()
    {
        ConnectAPI.DraftGetPicksAndContents();
    }

    private bool FireErrorListeners(BnetErrorInfo info)
    {
        List<BnetErrorListener> list;
        bool flag = false;
        if (this.m_bnetErrorListeners.TryGetValue(info.GetFeature(), out list))
        {
            if (list.Count == 0)
            {
                return flag;
            }
            foreach (BnetErrorListener listener in list.ToArray())
            {
                flag = listener.Fire(info) || flag;
            }
        }
        return flag;
    }

    public bool GameServerActive()
    {
        return ConnectAPI.GameServerActive();
    }

    public static Network Get()
    {
        if (s_instance == null)
        {
            UnityEngine.Debug.LogError("no Net object");
        }
        return s_instance;
    }

    public static void GetAllClientOptions()
    {
        ConnectAPI.GetAllClientOptions();
    }

    public static BattlePayConfig GetBattlePayConfigResponse()
    {
        return ConnectAPI.GetBattlePayConfigResponse();
    }

    public static BattlePayStatus GetBattlePayStatusResponse()
    {
        return ConnectAPI.GetBattlePayStatusResponse();
    }

    public static CanceledQuest GetCanceledQuest()
    {
        return ConnectAPI.GetCanceledQuest();
    }

    public static CardSaleResult GetCardSaleResult()
    {
        return ConnectAPI.GetCardSaleResult();
    }

    public ChallengeHandler GetChallengeHandler()
    {
        return this.m_challengeHandler;
    }

    public static Choice GetChoices()
    {
        return ConnectAPI.GetEntityChoice();
    }

    public static DraftChosen GetChosenAndNext()
    {
        return ConnectAPI.DraftCardChosen();
    }

    public static void GetClientOptions(List<ServerOption> keys)
    {
        ConnectAPI.GetClientOptions(keys);
    }

    public static NetCache.DeckHeader GetCreatedDeck()
    {
        return ConnectAPI.DeckCreated();
    }

    public static DeckContents GetDeckContents()
    {
        return ConnectAPI.GetDeckContents();
    }

    public void GetDeckContents(long deck)
    {
        Log.Bob.Print(string.Format("Network.GetDeckContents {0}", deck));
        ConnectAPI.GetDeckContents(deck);
    }

    public static DBAction GetDeckResponse()
    {
        return ConnectAPI.DBAction();
    }

    public static long GetDeletedDeckID()
    {
        return ConnectAPI.DeckDeleted();
    }

    public static DraftChoicesAndContents GetDraftChoicesAndContents()
    {
        return ConnectAPI.DraftGetChoicesAndContents();
    }

    public static DraftError GetDraftError()
    {
        return (DraftError) ConnectAPI.DraftGetError();
    }

    public FriendsHandler GetFriendsHandler()
    {
        return this.m_friendsHandler;
    }

    public static GameCancelInfo GetGameCancelInfo()
    {
        return ConnectAPI.GetGameCancelInfo();
    }

    public static GameSetup GetGameSetupInfo()
    {
        GameSetup gameSetup = ConnectAPI.GetGameSetup();
        GameSetup.Client item = new GameSetup.Client {
            CardBack = "TBD",
            UpperLeft = "TBD",
            UpperRight = "TBD",
            LowerLeft = "TBD",
            LowerRight = "TBD"
        };
        gameSetup.Player.Add(item);
        item = new GameSetup.Client {
            CardBack = "TBD",
            UpperLeft = "TBD",
            UpperRight = "TBD",
            LowerLeft = "TBD",
            LowerRight = "TBD"
        };
        gameSetup.Player.Add(item);
        return gameSetup;
    }

    public void GetGameState()
    {
        ConnectAPI.GetGameState();
    }

    public static string GetHeroCard(int heroAssetID)
    {
        CardManifest.Card card = CardManifest.Get().Find(heroAssetID);
        if (card != null)
        {
            return card.CardID;
        }
        UnityEngine.Debug.LogWarning(string.Format("unknown hero card {0}", heroAssetID));
        return "unknown";
    }

    public static string GetHeroPower(int heroAssetID)
    {
        CollectibleHero heroFromAssetID = CollectibleHero.GetHeroFromAssetID(heroAssetID);
        if (heroFromAssetID != null)
        {
            return heroFromAssetID.GetHeroPowerID();
        }
        UnityEngine.Debug.LogWarning(string.Format("unknown hero power {0}", heroAssetID));
        return "unknown";
    }

    public static List<int> GetIntArray(List<int> ints, int size)
    {
        return ints;
    }

    public static List<int> GetIntArray(IntPtr ints, int size)
    {
        List<int> list = new List<int>();
        int[] numArray = IntPtrToIntArray(ints, size);
        for (int i = 0; i < size; i++)
        {
            list.Add(numArray[i]);
        }
        return list;
    }

    public static MassDisenchantResponse GetMassDisenchantResponse()
    {
        return ConnectAPI.GetMassDisenchantResponse();
    }

    public static long GetMatchingDeckId()
    {
        return s_instance.m_matchingDeckId;
    }

    public static int GetNAckOption()
    {
        return ConnectAPI.GetNAckOption();
    }

    public static BeginDraft GetNewDraftDeckID()
    {
        return ConnectAPI.DraftGetBeginning();
    }

    public static Notification GetNotification()
    {
        return new Notification { NotificationType = (Notification.Type) ConnectAPI.GetNotification() };
    }

    public static Options GetOptions()
    {
        return ConnectAPI.GetOptions();
    }

    public PartyHandler GetPartyHandler()
    {
        return this.m_partyHandler;
    }

    public static List<PowerHistory> GetPowerHistory()
    {
        return ConnectAPI.GetPowerHistory();
    }

    public PresenceHandler GetPresenceHandler()
    {
        return this.m_presenceHandler;
    }

    public static PurchaseCanceledResponse GetPurchaseCanceledResponse()
    {
        return ConnectAPI.GetPurchaseCanceledResponse();
    }

    public static void GetPurchaseMethod(int bundleType, int quantity, Currency currency)
    {
        ConnectAPI.RequestPurchaseMethod(bundleType, quantity, (int) currency);
    }

    public static PurchaseMethod GetPurchaseMethodResponse()
    {
        return ConnectAPI.GetPurchaseMethodResponse();
    }

    public static PurchaseResponse GetPurchaseResponse()
    {
        return ConnectAPI.GetPurchaseResponse();
    }

    public static PurchaseViaGoldResponse GetPurchaseWithGoldResponse()
    {
        return ConnectAPI.GetPurchaseWithGoldResponse();
    }

    public static BattleNet.QueueEvent GetQueueEvent()
    {
        return BattleNet.GetQueueEvent();
    }

    public static DeckName GetRenamedDeck()
    {
        return ConnectAPI.DeckRenamed();
    }

    public static long GetRetiredDraftDeckID()
    {
        return ConnectAPI.DraftHandleRetired();
    }

    public static List<Entity.Tag> GetTags(List<Entity.Tag> tags)
    {
        return tags;
    }

    public static List<Entity.Tag> GetTags(IntPtr src, IntPtr flags)
    {
        List<Entity.Tag> list = new List<Entity.Tag>();
        int[] numArray = IntPtrToIntArray(src, TAG_LIST);
        int[] numArray2 = IntPtrToIntArray(flags, TAG_LIST);
        for (int i = 0; i < TAG_LIST; i++)
        {
            if (numArray2[i] == 1)
            {
                Entity.Tag item = new Entity.Tag {
                    Name = i,
                    Value = numArray[i]
                };
                list.Add(item);
            }
        }
        return list;
    }

    public static TurnTimerInfo GetTimeRemaining()
    {
        return ConnectAPI.GetTimeRemaining();
    }

    public static string GetUserName()
    {
        string environmentVariable = Vars.Key("Aurora.UserName").GetStr(string.Empty);
        if (environmentVariable.Length == 0)
        {
            environmentVariable = Environment.GetEnvironmentVariable("USERNAME");
        }
        return environmentVariable;
    }

    public static UserUI GetUserUI()
    {
        return ConnectAPI.GetUserUI();
    }

    public static ValidatedAchieve GetValidatedAchieve()
    {
        return ConnectAPI.GetValidatedAchieve();
    }

    public WhisperHandler GetWhisperHandler()
    {
        return this.m_whisperHandler;
    }

    public static void GiveUp()
    {
        ConnectAPI.GiveUp();
    }

    public void GotoGameServer(BattleNet.GameServerInfo info)
    {
        ConnectAPI.GotoGameServer(info);
    }

    private bool HandleType(PacketID type, string source)
    {
        if (this.m_netHandlers.ContainsKey(type))
        {
            this.m_netHandlers[type]();
            return true;
        }
        return false;
    }

    public static void Heartbeat()
    {
        if (s_running)
        {
            NetCache.Get().Heartbeat();
            ConnectAPI.Heartbeat();
            StoreManager.Get().Heartbeat();
            TimeSpan span = (TimeSpan) (DateTime.Now - Get().lastCall);
            if (span >= new TimeSpan(0, 0, 15))
            {
                TimeSpan span2 = (TimeSpan) (DateTime.Now - Get().lastCallReport);
                if (span2 >= new TimeSpan(0, 0, 1))
                {
                    Get().lastCallReport = DateTime.Now;
                    UnityEngine.Debug.LogWarning(string.Format("Network.ProcessNetwork not called for {0}", span));
                }
            }
        }
    }

    public static void IgnoreFriendInvite(BnetInvitationId inviteId)
    {
        BattleNet.ManageFriendInvite(4, inviteId.GetVal());
    }

    public static void Initialize()
    {
        s_running = true;
        NetCache.Get().InitNetCache();
        BattleNet.Init(ApplicationMgr.IsInternal());
    }

    private static void IntArrayToIntPtr(int[] src, IntPtr dst, int length)
    {
        Marshal.Copy(src, 0, dst, length);
    }

    private static int[] IntPtrToIntArray(IntPtr src, int length)
    {
        int[] destination = new int[length];
        Marshal.Copy(src, destination, 0, length);
        return destination;
    }

    private static long[] IntPtrToLongArray(IntPtr src, int length)
    {
        long[] destination = new long[length];
        Marshal.Copy(src, destination, 0, length);
        return destination;
    }

    public static bool IsInDraftQueue()
    {
        return Get().m_inDraftQueue;
    }

    public static bool IsLoggedIn()
    {
        return (BattleNet.BattleNetStatus() == 4);
    }

    public static bool IsMatching()
    {
        return (GetMatchingDeckId() != 0L);
    }

    public static void JoinDraftQueue()
    {
        BattleNet.DraftQueue(true);
        s_instance.m_inDraftQueue = true;
    }

    public static void LeaveDraftQueue()
    {
        BattleNet.DraftQueue(false);
        s_instance.m_inDraftQueue = false;
    }

    private static void LongArrayToIntPtr(long[] src, IntPtr dst, int length)
    {
        Marshal.Copy(src, 0, dst, length);
    }

    private static List<int> MakeChoicesList(int choice1, int choice2, int choice3)
    {
        List<int> list = new List<int>();
        if (choice1 == 0)
        {
            return null;
        }
        list.Add(choice1);
        if (choice2 != 0)
        {
            list.Add(choice2);
            if (choice3 == 0)
            {
                return list;
            }
            list.Add(choice3);
        }
        return list;
    }

    public static void MakeDraftChoice(long deckID, int slot, int index)
    {
        ConnectAPI.DraftMakePick(deckID, slot, index);
    }

    public static void MakeMatch(long deckID)
    {
        if (deckID == 0)
        {
            Log.Bob.Print(string.Format("MakeMatch CANCEL", new object[0]));
        }
        else
        {
            Log.Bob.Print(string.Format("MakeMatch deck={0}", deckID));
        }
        s_instance.m_matchingDeckId = deckID;
        BattleNet.MakeMatch(deckID);
    }

    public static void MassDisenchant()
    {
        ConnectAPI.MassDisenchant();
    }

    public bool NetHandlerExists(PacketID ID)
    {
        return this.m_netHandlers.ContainsKey(ID);
    }

    public static void OpenBooster(BoosterType type)
    {
        Log.Bob.Print("Network.OpenBooster");
        ConnectAPI.OpenBooster(type);
    }

    public static List<NetCache.BoosterCard> OpenedBooster()
    {
        return ConnectAPI.GetOpenedBooster();
    }

    public static void PlayAI(long deckID, long aiDeckID)
    {
        BattleNet.StartScenarioAI(1, deckID, aiDeckID);
    }

    public void ProcessAurora()
    {
        BattleNet.ProcessAurora();
        if (IsLoggedIn())
        {
            this.ProcessPresence();
            this.ProcessFriends();
            this.ProcessWhispers();
            this.ProcessChallenges();
            this.ProcessParties();
        }
        this.ProcessErrors();
    }

    private bool ProcessBobNet()
    {
        PacketID type = (PacketID) ConnectAPI.NextBobNetType();
        if (type == PacketID.AUTH_RESPONSE)
        {
            this.m_loginWaiting = false;
        }
        if (this.HandleType(type, "bob.net"))
        {
            return true;
        }
        ConnectAPI.NoBobNetReply();
        return false;
    }

    private void ProcessChallenges()
    {
        int num = BattleNet.NumChallenges();
        if ((num != 0) && (this.m_challengeHandler != null))
        {
            BattleNet.DllChallengeInfo[] challenges = new BattleNet.DllChallengeInfo[num];
            BattleNet.GetChallenges(challenges);
            this.m_challengeHandler(challenges);
            BattleNet.ClearChallenges();
        }
    }

    private bool ProcessConsole()
    {
        if (this.HandleType((PacketID) ConnectAPI.NextDebugConsoleType(), "debug console"))
        {
            return true;
        }
        ConnectAPI.NoDebugConsoleReply();
        return false;
    }

    private void ProcessErrors()
    {
        int errorsCount = BattleNet.GetErrorsCount();
        if (errorsCount != 0)
        {
            BattleNet.DllErrorInfo[] errors = new BattleNet.DllErrorInfo[errorsCount];
            BattleNet.GetErrors(errors);
            for (int i = 0; i < errors.Length; i++)
            {
                BattleNet.DllErrorInfo src = errors[i];
                BnetErrorInfo info = BnetErrorInfo.CreateFromDll(src);
                if (!this.FireErrorListeners(info))
                {
                    this.DefaultBnetErrorHandler(info);
                }
            }
            BattleNet.ClearErrors();
        }
    }

    private void ProcessFriends()
    {
        BattleNet.DllFriendsInfo info = new BattleNet.DllFriendsInfo();
        BattleNet.GetFriendsInfo(ref info);
        if ((info.updateSize != 0) && (this.m_friendsHandler != null))
        {
            BattleNet.DllFriendsUpdate[] updates = new BattleNet.DllFriendsUpdate[info.updateSize];
            BattleNet.GetFriendsUpdates(updates);
            this.m_friendsHandler(updates);
            BattleNet.ClearFriendsUpdates();
        }
    }

    private bool ProcessGameQueue()
    {
        BattleNet.QueueEvent queueEvent = BattleNet.GetQueueEvent();
        if (queueEvent == null)
        {
            return false;
        }
        switch (queueEvent.EventType)
        {
            case BattleNet.QueueEvent.Type.QUEUE_LEAVE:
            case BattleNet.QueueEvent.Type.QUEUE_DELAY_ERROR:
            case BattleNet.QueueEvent.Type.QUEUE_AMM_ERROR:
            case BattleNet.QueueEvent.Type.QUEUE_CANCEL:
            case BattleNet.QueueEvent.Type.ABORT_CLIENT_DROPPED:
                this.m_matchingDeckId = 0L;
                this.m_inDraftQueue = false;
                break;
        }
        if (this.m_gameQueueHandler != null)
        {
            this.m_gameQueueHandler(queueEvent);
        }
        return true;
    }

    private bool ProcessGameServer()
    {
        if (this.HandleType((PacketID) ConnectAPI.NextGameType(), "game"))
        {
            return true;
        }
        ConnectAPI.NoGameReply();
        return false;
    }

    public void ProcessNetwork()
    {
        this.lastCall = DateTime.Now;
        if (this.m_loginWaiting && ((this.lastCall - this.m_loginStarted) > LOGIN_TIMEOUT))
        {
            this.m_loginWaiting = false;
        }
        if (BattleNet.Init(ApplicationMgr.IsInternal()))
        {
            this.ProcessAurora();
            if (ConnectAPI.BobNetReady())
            {
                this.ProcessBobNet();
            }
            else if (!this.ProcessGameQueue())
            {
                if (ConnectAPI.GameServerReady())
                {
                    this.ProcessGameServer();
                }
                else if (ConnectAPI.UtilServerReady())
                {
                    this.ProcessUtilServer();
                }
                else if (ConnectAPI.DebugConsoleReady())
                {
                    this.ProcessConsole();
                }
            }
        }
    }

    private void ProcessParties()
    {
        BattleNet.DllPartyInfo info = new BattleNet.DllPartyInfo();
        BattleNet.GetPartyUpdatesInfo(ref info);
        if ((info.size > 0) && (this.m_partyHandler != null))
        {
            BattleNet.DllPartyEvent[] updates = new BattleNet.DllPartyEvent[info.size];
            BattleNet.GetPartyUpdates(updates);
            this.m_partyHandler(updates);
            BattleNet.ClearPartyUpdates();
        }
    }

    private void ProcessPresence()
    {
        int num = BattleNet.PresenceSize();
        if ((num != 0) && (this.m_presenceHandler != null))
        {
            BattleNet.PresenceUpdate[] updates = new BattleNet.PresenceUpdate[num];
            BattleNet.GetPresence(updates);
            this.m_presenceHandler(updates);
            BattleNet.ClearPresence();
        }
    }

    private bool ProcessUtilServer()
    {
        if (this.HandleType((PacketID) ConnectAPI.NextUtilType(), "util"))
        {
            return true;
        }
        ConnectAPI.NoUtilReply();
        return false;
    }

    private void ProcessWhispers()
    {
        BattleNet.DllWhisperInfo info = new BattleNet.DllWhisperInfo();
        BattleNet.GetWhisperInfo(ref info);
        if ((info.whisperSize > 0) && (this.m_whisperHandler != null))
        {
            BattleNet.DllWhisper[] whispers = new BattleNet.DllWhisper[info.whisperSize];
            BattleNet.GetWhispers(whispers);
            this.m_whisperHandler(whispers);
            BattleNet.ClearWhispers();
        }
    }

    public static void PurchaseViaGold(int quantity, ProductType product, int data)
    {
        ConnectAPI.PurchaseViaGold(quantity, product, data);
    }

    public void RegisterGameQueueHandler(GameQueueHandler handler)
    {
        if (this.m_gameQueueHandler != null)
        {
            object[] args = new object[] { handler };
            Log.Net.Print("would bash game queue handler {0}", args);
        }
        else
        {
            this.m_gameQueueHandler = handler;
        }
    }

    public void RegisterNetHandler(PacketID ID, NetHandler handler)
    {
        if (this.NetHandlerExists(ID))
        {
            object[] args = new object[] { (int) ID, this.m_netHandlers[ID] };
            Log.Net.Print("would bash conn handler {0} {1}", args);
        }
        else
        {
            this.m_netHandlers[ID] = handler;
        }
    }

    public bool RemoveBnetErrorListener(BnetFeature feature, BnetErrorCallback callback)
    {
        return this.RemoveBnetErrorListener(feature, callback, null);
    }

    public bool RemoveBnetErrorListener(BnetFeature feature, BnetErrorCallback callback, object userData)
    {
        List<BnetErrorListener> list;
        if (!this.m_bnetErrorListeners.TryGetValue(feature, out list))
        {
            return false;
        }
        BnetErrorListener item = new BnetErrorListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return list.Remove(item);
    }

    public static void RemoveFriend(BnetAccountId id)
    {
        BattleNet.RemoveFriend(ref BnetEntityId.CreateForDll(id));
    }

    public void RemoveGameQueueHandler(GameQueueHandler handler)
    {
        if (this.m_gameQueueHandler != handler)
        {
            object[] args = new object[] { handler };
            Log.Net.Print("Removing game queue handler that is not active {0}", args);
        }
        else
        {
            this.m_gameQueueHandler = null;
        }
    }

    public void RemoveNetHandler(PacketID ID)
    {
        if (this.NetHandlerExists(ID))
        {
            this.m_netHandlers.Remove(ID);
        }
        else
        {
            object[] args = new object[] { (int) ID };
            Log.Net.Print("conn handler does not exist {0}", args);
        }
    }

    public void RenameDeck(long deck, string name)
    {
        Log.Rachelle.Print(string.Format("Network.RenameDeck {0} {1}", deck, name));
        ConnectAPI.RenameDeck(deck, name);
    }

    public static void RequestAchieves(bool activeOnly)
    {
        ConnectAPI.RequestAchieves(activeOnly);
    }

    public static void RequestBattlePayConfig()
    {
        ConnectAPI.RequestBattlePayConfig();
    }

    public static void RequestBattlePayStatus()
    {
        ConnectAPI.RequestBattlePayStatus();
    }

    public static void RequestCancelQuest(int achieveID)
    {
        ConnectAPI.RequestCancelQuest(achieveID);
    }

    public static void RescindFriendChallenge(BnetEntityId partyId)
    {
        BattleNet.RescindPartyInvite(ref BnetEntityId.CreateForDll(partyId));
    }

    public static void RestoreGame()
    {
        Log.Bob.Print("RestoreGame");
        Get().GotoGameServer(NetCache.Get().GetNetObject<NetCache.NetCacheDisconnectedGame>().ServerInfo);
    }

    public static void RetireDraftDeck(long deckID, int slot)
    {
        ConnectAPI.DraftRetire(deckID, slot);
    }

    public static void RevokeFriendInvite(BnetInvitationId inviteId)
    {
        BattleNet.ManageFriendInvite(2, inviteId.GetVal());
    }

    public static void SellCard(int assetID, CardFlair cardFlair)
    {
        ConnectAPI.SellCard(assetID, (int) cardFlair.Premium);
    }

    public void SendChoices(int ID, List<int> picks)
    {
        ConnectAPI.SendChoices(ID, picks);
    }

    public bool SendConsoleCmdToServer(string command)
    {
        if (!Get().GameServerActive())
        {
            Log.Rachelle.Print(string.Format("Cannot send command '{0}' to server; no game server is active.", command));
            return false;
        }
        ConnectAPI.SendIndirectConsoleCommand(command);
        return true;
    }

    public void SendEmote(EmoteType emote)
    {
        ConnectAPI.SendEmote((int) emote);
    }

    public static void SendFriendChallenge(BnetGameAccountId gameAccountId)
    {
        BattleNet.SendPartyInvite(ref BnetEntityId.CreateForDll(gameAccountId));
    }

    private static void SendFriendInvite(string sender, string target, bool byEmail)
    {
        IntPtr inviter = DLLUtils.NativeUtf8FromString(sender);
        IntPtr invitee = DLLUtils.NativeUtf8FromString(target);
        BattleNet.SendFriendInvite(inviter, invitee, byEmail);
        DLLUtils.FreeNativeUtf8(inviter);
        DLLUtils.FreeNativeUtf8(invitee);
    }

    public static void SendFriendInviteByBattleTag(string sender, string target)
    {
        SendFriendInvite(sender, target, false);
    }

    public static void SendFriendInviteByEmail(string sender, string target)
    {
        SendFriendInvite(sender, target, true);
    }

    public void SendOption(int ID, int index, int target, int sub, int pos)
    {
        ConnectAPI.SendOption(ID, index, target, sub, pos);
    }

    public void SendUserUI(int overCard, int heldCard, int arrowOrigin, int x, int y)
    {
        if (NetCache.Get().GetNetObject<NetCache.NetCacheFeatures>().Games.ShowUserUI != 0)
        {
            ConnectAPI.SendUserUI(overCard, heldCard, arrowOrigin, x, y);
        }
    }

    public static void SendWhisper(BnetGameAccountId gameAccount, string message)
    {
        BattleNet.DllEntityId id = BnetEntityId.CreateForDll(gameAccount);
        IntPtr ptr = DLLUtils.NativeUtf8FromString(message);
        BattleNet.SendWhisper(ref id, ptr);
        DLLUtils.FreeNativeUtf8(ptr);
    }

    public static void SetCampaignProgress(MissionMgr.MissionProgress val)
    {
        NetCache.NetCacheProfileProgress netObject = NetCache.Get().GetNetObject<NetCache.NetCacheProfileProgress>();
        netObject.CampaignProgress = (long) val;
        ConnectAPI.SetProgress(netObject.CampaignProgress);
        NetCache.Get().NetCacheChanged<NetCache.NetCacheProfileProgress>();
    }

    public void SetChallengeHandler(ChallengeHandler handler)
    {
        this.m_challengeHandler = handler;
    }

    public void SetDeckContents(long deck, List<CardUserData> cards)
    {
        Log.Bob.Print(string.Format("Network.DeckSetUserData {0}", deck));
        ConnectAPI.SendDeckData(deck, cards);
    }

    public void SetFriendsHandler(FriendsHandler handler)
    {
        this.m_friendsHandler = handler;
    }

    public void SetPartyHandler(PartyHandler handler)
    {
        this.m_partyHandler = handler;
    }

    public void SetPresenceHandler(PresenceHandler handler)
    {
        this.m_presenceHandler = handler;
    }

    private static void SetTags(List<Entity.Tag> dst, IntPtr src)
    {
        int[] numArray = IntPtrToIntArray(src, TAG_LIST);
        for (int i = 0; i < TAG_LIST; i++)
        {
            if (numArray[i] != 0)
            {
                Entity.Tag item = new Entity.Tag {
                    Name = i,
                    Value = numArray[i]
                };
                dst.Add(item);
            }
        }
    }

    public void SetWhisperHandler(WhisperHandler handler)
    {
        this.m_whisperHandler = handler;
    }

    public static void StartANewDraft()
    {
        ConnectAPI.DraftBegin();
    }

    public void StartCountdown()
    {
        ConnectAPI.SignalCountdown();
    }

    public static void StartGame()
    {
        ConnectAPI.NoGameReply();
        ConnectAPI.SignalStart();
    }

    public void StartScenario(int scenarioToStart, long deckID)
    {
        BattleNet.StartScenario(scenarioToStart, deckID);
    }

    public static void SubmitBug(BugReport bugReport)
    {
        ConnectAPI.SubmitBug(bugReport.subject, bugReport.description, bugReport.userName, bugReport.hostName, bugReport.gameCodeVersion, bugReport.gameDataVersion);
    }

    [Conditional("UNITY_EDITOR")]
    private static void Trace(string message)
    {
    }

    public static void TrackClient(TrackLevel level, TrackWhat what)
    {
        switch (what)
        {
            case TrackWhat.TRACK_COLLECTION_MANAGER:
            case TrackWhat.TRACK_BOX_SCREEN_VISIT:
                ConnectAPI.GuardianTrack(what);
                break;
        }
        ConnectAPI.TrackClient((int) level, (int) what, null);
    }

    public static void TrackClientEx(TrackLevel level, TrackWhat what, string message)
    {
        ConnectAPI.TrackClient((int) level, (int) what, message);
    }

    public bool UnhandledPacketsWaiting()
    {
        return (ConnectAPI.UtilServerReady() || (ConnectAPI.GameServerReady() || ConnectAPI.BobNetReady()));
    }

    public static void UnrankedMatch(long deckID)
    {
        BattleNet.UnrankedMatch(deckID);
        s_instance.m_matchingDeckId = deckID;
    }

    public static void ValidateAchieve(int achieveID)
    {
        ConnectAPI.ValidateAchieve(achieveID);
    }

    public class AchieveList
    {
        public AchieveList()
        {
            this.Achieves = new List<Achieve>();
        }

        public List<Achieve> Achieves { get; set; }

        public class Achieve
        {
            public int AckProgress { get; set; }

            public bool Active { get; set; }

            public bool CanAck { get; set; }

            public int CompletionCount { get; set; }

            public long DateCompleted { get; set; }

            public long DateGiven { get; set; }

            public int ID { get; set; }

            public int Progress { get; set; }
        }
    }

    public enum AuthResult
    {
        UNKNOWN,
        ALLOWED,
        INVALID,
        SECOND,
        OFFLINE
    }

    public class BattlePayConfig
    {
        public BattlePayConfig()
        {
            this.Available = false;
            this.Country = string.Empty;
            this.Currency = Currency.UNKNOWN;
            this.Bundles = new List<Network.Bundle>();
            this.SecondsBeforeAutoCancel = StoreManager.DEFAULT_SECONDS_BEFORE_AUTO_CANCEL;
            this.GoldPrices = new List<Network.GoldPrice>();
        }

        public bool Available { get; set; }

        public List<Network.Bundle> Bundles { get; set; }

        public string Country { get; set; }

        public Currency Currency { get; set; }

        public List<Network.GoldPrice> GoldPrices { get; set; }

        public int SecondsBeforeAutoCancel { get; set; }
    }

    public class BattlePayStatus
    {
        public BattlePayStatus()
        {
            this.State = PurchaseState.UNKNOWN;
            this.ProductType = 0;
            this.PurchaseError = new Network.PurchaseErrorInfo();
            this.BattlePayAvailable = false;
        }

        public bool BattlePayAvailable { get; set; }

        public int ProductType { get; set; }

        public Network.PurchaseErrorInfo PurchaseError { get; set; }

        public PurchaseState State { get; set; }

        public enum PurchaseState
        {
            CHECK_RESULTS = 1,
            ERROR = 2,
            READY = 0,
            UNKNOWN = -1
        }
    }

    public class BeginDraft
    {
        public BeginDraft()
        {
            this.Heroes = new List<int>();
        }

        public long DeckID { get; set; }

        public List<int> Heroes { get; set; }
    }

    public delegate bool BnetErrorCallback(BnetErrorInfo info, object userData);

    private class BnetErrorListener : EventListener<Network.BnetErrorCallback>
    {
        public bool Fire(BnetErrorInfo info)
        {
            return base.m_callback(info, base.m_userData);
        }
    }

    public enum BNetState
    {
        BATTLE_NET_UNKNOWN,
        BATTLE_NET_LOGGING_IN,
        BATTLE_NET_TIMEOUT,
        BATTLE_NET_LOGIN_FAILED,
        BATTLE_NET_LOGGED_IN
    }

    public class BugReport
    {
        public string description;
        public int gameCodeVersion;
        public string gameDataVersion;
        public string hostName;
        public string subject;
        public string userName;

        public BugReport(string subject, string description)
        {
            // This item is obfuscated and can not be translated.
            this.subject = subject;
            this.description = description;
            this.userName = Environment.UserName;
            this.hostName = Environment.MachineName;
            this.gameCodeVersion = 0xd3c;
            if (Streaming.LiveManifestHash != null)
            {
                goto Label_0047;
            }
            this.gameDataVersion = "(Unknown)";
        }
    }

    public class Bundle
    {
        public Bundle()
        {
            this.BundleType = 0;
            this.Product = ProductType.UNKNOWN;
            this.ProductData = 0;
            this.Quantity = 0;
            this.Cost = 0.0;
        }

        public int BundleType { get; set; }

        public double Cost { get; set; }

        public ProductType Product { get; set; }

        public int ProductData { get; set; }

        public int Quantity { get; set; }
    }

    public class CanceledQuest
    {
        public CanceledQuest()
        {
            this.AchieveID = 0;
            this.Canceled = false;
        }

        public int AchieveID { get; set; }

        public bool Canceled { get; set; }
    }

    public class CardQuote
    {
        public int AssetID { get; set; }

        public int BuyPrice { get; set; }

        public int SaleValue { get; set; }

        public QuoteState Status { get; set; }

        public enum QuoteState
        {
            SUCCESS,
            UNKNOWN_ERROR
        }
    }

    public class CardSaleResult
    {
        public SaleResult Action { get; set; }

        public int Amount { get; set; }

        public int AssetID { get; set; }

        public string AssetName { get; set; }

        public CardFlair.PremiumType Premium { get; set; }

        public enum SaleResult
        {
            CARD_WAS_BOUGHT = 3,
            CARD_WAS_SOLD = 2,
            FAILED_CANT_SELL_THAT = 4,
            GENERIC_FAILURE = 1
        }
    }

    public class CardUserData
    {
        public int AssetID { get; set; }

        public int Count { get; set; }

        public int Handle { get; set; }

        public CardFlair.PremiumType Premium { get; set; }

        public int Prev { get; set; }
    }

    public delegate void ChallengeHandler(BattleNet.DllChallengeInfo[] challenges);

    public class Choice
    {
        public bool Cancelable { get; set; }

        public int ChoiceType { get; set; }

        public int CountMax { get; set; }

        public int CountMin { get; set; }

        public List<int> Entities { get; set; }

        public int ID { get; set; }

        public int Source { get; set; }
    }

    public class DBAction
    {
        public ActionType Action { get; set; }

        public long MetaData { get; set; }

        public ResultType Result { get; set; }

        public enum ActionType
        {
            UNKNOWN,
            GET_DECK,
            CREATE_DECK,
            RENAME_DECK,
            DELETE_DECK,
            SET_DECK
        }

        public enum ResultType
        {
            UNKNOWN,
            SUCCESS,
            NOT_OWNED,
            CONSTRAINT
        }
    }

    public class DebugConsoleResponse
    {
        public DebugConsoleResponse()
        {
            this.Response = string.Empty;
        }

        public string Response { get; set; }

        public int Type { get; set; }
    }

    public class DeckCard
    {
        public long Card { get; set; }

        public long Deck { get; set; }
    }

    public class DeckContents
    {
        public DeckContents()
        {
            this.Cards = new List<Network.CardUserData>();
        }

        public List<Network.CardUserData> Cards { get; set; }

        public long Deck { get; set; }
    }

    public class DeckName
    {
        public long Deck { get; set; }

        public string Name { get; set; }
    }

    public class DraftChoicesAndContents
    {
        public DraftChoicesAndContents()
        {
            this.Choices = new List<int>();
            this.DeckInfo = new Network.DeckContents();
        }

        public List<int> Choices { get; set; }

        public Network.DeckContents DeckInfo { get; set; }

        public int HeroAssetID { get; set; }

        public int Losses { get; set; }

        public int Slot { get; set; }

        public int Wins { get; set; }
    }

    public class DraftChosen
    {
        public DraftChosen()
        {
            this.NextChoices = new List<int>();
        }

        public int AssetID { get; set; }

        public List<int> NextChoices { get; set; }
    }

    public enum DraftError
    {
        DE_UNKNOWN,
        DE_NO_LICENSE,
        DE_RETIRE_FIRST,
        DE_NOT_IN_DRAFT,
        DE_BAD_DECK,
        DE_BAD_SLOT,
        DE_BAD_INDEX,
        DE_NOT_IN_DRAFT_BUT_COULD_BE,
        DE_FEATURE_DISABLED
    }

    public class Entity
    {
        public Entity()
        {
            this.Tags = new List<Tag>();
        }

        public string CardID { get; set; }

        public int ID { get; set; }

        public List<Tag> Tags { get; set; }

        public class Tag
        {
            public int Name { get; set; }

            public int Value { get; set; }
        }
    }

    public delegate void FriendsHandler(BattleNet.DllFriendsUpdate[] updates);

    public class GameCancelInfo
    {
        public Reason CancelReason { get; set; }

        public enum Reason
        {
            OPPONENT_TIMEOUT = 1
        }
    }

    public class GameEnd
    {
        public GameEnd()
        {
            this.Notices = new List<NetCache.ProfileNotice>();
        }

        public List<NetCache.ProfileNotice> Notices { get; set; }
    }

    public class GameInfo
    {
        public int Handle { get; set; }

        public string Name { get; set; }
    }

    public delegate void GameQueueHandler(BattleNet.QueueEvent queueEvent);

    public class GameServerInfo
    {
        public GameServerInfo()
        {
            this.Addresses = new List<string>();
        }

        public List<string> Addresses { get; set; }

        public string AuroraPassword { get; set; }

        public int BobnetPassword { get; set; }

        public long Client { get; set; }

        public int Game { get; set; }

        public int Port { get; set; }

        public string Version { get; set; }
    }

    public class GameSetup
    {
        public GameSetup()
        {
            this.Player = new List<Client>();
        }

        public string Board { get; set; }

        public int MaxFriendlyMinionsPerPlayer { get; set; }

        public int MaxSecretsPerPlayer { get; set; }

        public List<Client> Player { get; set; }

        public class Client
        {
            public string CardBack { get; set; }

            public string LowerLeft { get; set; }

            public string LowerRight { get; set; }

            public string UpperLeft { get; set; }

            public string UpperRight { get; set; }
        }
    }

    public class GameState
    {
        public GameState()
        {
            this.Players = new List<Player>();
        }

        public Network.Entity Game { get; set; }

        public List<Player> Players { get; set; }

        public class Player
        {
            public Network.Entity Ent { get; set; }

            public int ID { get; set; }

            public string Name { get; set; }

            public bool You { get; set; }
        }
    }

    public class GoldPrice
    {
        public GoldPrice()
        {
            this.Cost = 0L;
            this.Product = ProductType.UNKNOWN;
            this.ProductData = 0;
            this.Quantity = 1;
        }

        public long Cost { get; set; }

        public ProductType Product { get; set; }

        public int ProductData { get; set; }

        public int Quantity { get; set; }
    }

    public class HistActionEnd : Network.PowerHistoryAction
    {
        public HistActionEnd() : base(Network.PowerHistory.PowType.ACTION_END, Network.PowerHistoryAction.PowSubType.ACTION)
        {
        }
    }

    public class HistActionStart : Network.PowerHistoryAction
    {
        public HistActionStart(Network.PowerHistoryAction.PowSubType init) : base(Network.PowerHistory.PowType.ACTION_START, init)
        {
        }

        public int Entity { get; set; }

        public int Index { get; set; }

        public int Target { get; set; }
    }

    public class HistCreateGame : Network.PowerHistory
    {
        public HistCreateGame() : base(Network.PowerHistory.PowType.CREATE_GAME)
        {
            this.Game = new Network.Entity();
            this.Players = new List<PlayerData>();
        }

        public Network.Entity Game { get; set; }

        public List<PlayerData> Players { get; set; }

        public class PlayerData
        {
            private Network.Entity m_player = new Network.Entity();

            public BnetGameAccountId GameAccountId { get; set; }

            public int ID { get; set; }

            public Network.Entity Player
            {
                get
                {
                    return this.m_player;
                }
            }
        }
    }

    public class HistFullEntity : Network.PowerHistory
    {
        public HistFullEntity() : base(Network.PowerHistory.PowType.FULL_ENTITY)
        {
            this.Entity = new Network.Entity();
        }

        public Network.Entity Entity { get; set; }
    }

    public class HistHideEntity : Network.PowerHistory
    {
        public HistHideEntity() : base(Network.PowerHistory.PowType.HIDE_ENTITY)
        {
        }

        public int Entity { get; set; }

        public int Zone { get; set; }
    }

    public class HistMetaData : Network.PowerHistory
    {
        public HistMetaData() : base(Network.PowerHistory.PowType.META_DATA)
        {
            this.Info = new List<int>();
        }

        public int Data { get; set; }

        public int DeprecatedMeta { get; set; }

        public List<int> Info { get; set; }

        public TypeMetaType MetaType { get; set; }

        public enum TypeMetaType
        {
            META_TARGET,
            META_DAMAGE,
            META_HEALING
        }
    }

    public class HistShowEntity : Network.PowerHistory
    {
        public HistShowEntity() : base(Network.PowerHistory.PowType.SHOW_ENTITY)
        {
            this.Entity = new Network.Entity();
        }

        public Network.Entity Entity { get; set; }
    }

    public class HistTagChange : Network.PowerHistory
    {
        public HistTagChange() : base(Network.PowerHistory.PowType.TAG_CHANGE)
        {
        }

        public int Entity { get; set; }

        public int Tag { get; set; }

        public int Value { get; set; }
    }

    public enum InviteAction
    {
        INVITE_ACCEPT = 1,
        INVITE_DECLINE = 3,
        INVITE_IGNORE = 4,
        INVITE_REVOKE = 2
    }

    public class MassDisenchantResponse
    {
        public MassDisenchantResponse()
        {
            this.Amount = 0;
        }

        public int Amount { get; set; }
    }

    public delegate void NetHandler();

    public class Notification
    {
        public Type NotificationType { get; set; }

        public enum Type
        {
            IN_HAND_CARD_CAP = 1,
            MANA_CAP = 2
        }
    }

    public class Options
    {
        public Options()
        {
            this.List = new List<Option>();
        }

        public void CopyFrom(Network.Options options)
        {
            this.ID = options.ID;
            if (options.List == null)
            {
                this.List = null;
            }
            else
            {
                if (this.List != null)
                {
                    this.List.Clear();
                }
                else
                {
                    this.List = new List<Option>();
                }
                for (int i = 0; i < options.List.Count; i++)
                {
                    Option item = new Option();
                    item.CopyFrom(options.List[i]);
                    this.List.Add(item);
                }
            }
        }

        public int ID { get; set; }

        public List<Option> List { get; set; }

        public class Option
        {
            public Option()
            {
                this.Main = new SubOption();
                this.Subs = new List<SubOption>();
            }

            public void CopyFrom(Network.Options.Option option)
            {
                this.Type = option.Type;
                if (this.Main == null)
                {
                    this.Main = new SubOption();
                }
                this.Main.CopyFrom(option.Main);
                if (option.Subs == null)
                {
                    this.Subs = null;
                }
                else
                {
                    if (this.Subs == null)
                    {
                        this.Subs = new List<SubOption>();
                    }
                    else
                    {
                        this.Subs.Clear();
                    }
                    for (int i = 0; i < option.Subs.Count; i++)
                    {
                        SubOption item = new SubOption();
                        item.CopyFrom(option.Subs[i]);
                        this.Subs.Add(item);
                    }
                }
            }

            public SubOption Main { get; set; }

            public List<SubOption> Subs { get; set; }

            public OptionType Type { get; set; }

            public enum OptionType
            {
                END_TURN = 2,
                PASS = 1,
                POWER = 3
            }

            public class SubOption
            {
                public void CopyFrom(Network.Options.Option.SubOption subOption)
                {
                    this.ID = subOption.ID;
                    if (subOption.Targets == null)
                    {
                        this.Targets = null;
                    }
                    else
                    {
                        if (this.Targets == null)
                        {
                            this.Targets = new List<int>();
                        }
                        else
                        {
                            this.Targets.Clear();
                        }
                        for (int i = 0; i < subOption.Targets.Count; i++)
                        {
                            this.Targets.Add(subOption.Targets[i]);
                        }
                    }
                }

                public int ID { get; set; }

                public List<int> Targets { get; set; }
            }
        }
    }

    public enum PacketID
    {
        ACCOUNT_BALANCE = 0x106,
        ACHIEVE = 0xfc,
        ACHIEVE_VALIDATED = 0x11d,
        ALL_HERO_XP = 0x11b,
        ALL_OPTIONS = 14,
        AUTH_RESPONSE = 0x6a,
        BATTLE_PAY_CONFIG_RESPONSE = 0xee,
        BATTLEPAY_STATUS_RESPONSE = 0x109,
        BOOSTER_LIST = 0xe0,
        CARD_QUOTE = 0x100,
        CARD_SALE = 0x102,
        CARD_USAGES = 0xec,
        CARD_VALUES = 260,
        CLIENT_OPTIONS = 0xf1,
        COLLECTION = 0xcf,
        DC_CONSOLE_CMD = 0x7b,
        DC_RESPONSE = 0x7c,
        DEBUG_MESSAGE = 5,
        DECK_ACTION = 0xd8,
        DECK_CONTENTS = 0xd7,
        DECK_CREATED = 0xd9,
        DECK_DELETED = 0xda,
        DECK_GAIN_CARD = 220,
        DECK_LIMIT = 0xe7,
        DECK_LIST = 0xca,
        DECK_LOST_CARD = 0xdd,
        DECK_RENAMED = 0xdb,
        DISCONNECTED_GAME = 170,
        DRAFT_BEGIN = 0xf6,
        DRAFT_CHOICES_AND_CONTENTS = 0xf8,
        DRAFT_CHOSEN = 0xf9,
        DRAFT_ERROR = 0xfb,
        DRAFT_RETIRE = 0xf7,
        ENTITY_CHOICE = 0x11,
        FEATURES_CHANGED = 0x108,
        FIN_GAMESTATE = 8,
        GAME_CANCELED = 12,
        GAME_INFO = 0x6b,
        GAME_SETUP = 0x10,
        GAME_STARTING = 0x72,
        GAMES_INFO = 0xd0,
        GOLD_BALANCE = 0x116,
        GOTO_SERVER = 0x6d,
        GOTO_UTIL = 0x97,
        LAST_LOGIN = 0xe3,
        MASS_DISENCHANT_RESPONSE = 0x10d,
        MEDAL_HISTORY = 0xea,
        MEDAL_INFO = 0xe8,
        MESSAGE = 0x7e,
        NACK_OPTION = 10,
        NOTIFICATION = 0x15,
        OPENED_BOOSTER = 0xe2,
        PLAYER_JOINED = 110,
        PLAYER_LEFT = 0x6f,
        PLAYER_RECORDS = 270,
        POWER_HISTORY = 0x13,
        PRELOAD = 0x12,
        PROFILE_NOTICES = 0xd4,
        PROFILE_PROGRESS = 0xe9,
        PURCHASE_CANCELED_RESPONSE = 0x113,
        PURCHASE_METHOD = 0x110,
        PURCHASE_RESPONSE = 0x100,
        PURCHASE_WITH_GOLD_RESPONSE = 280,
        QUEST_CANCELED = 0x11a,
        QUEUE_EVENT = 0xa1,
        REMOVE_GAME = 0x6c,
        REWARD_PROGRESS = 0x10f,
        START_GAMESTATE = 7,
        TURN_TIMER = 9,
        USER_UI = 15,
        UTIL_AUTH = 0xcc
    }

    public delegate void PartyHandler(BattleNet.DllPartyEvent[] dllEvents);

    public class PowerHistory
    {
        public PowerHistory(PowType init)
        {
            this.Type = init;
        }

        public PowType Type { get; set; }

        public enum PowType
        {
            ACTION_END = 6,
            ACTION_START = 5,
            CREATE_GAME = 7,
            FULL_ENTITY = 1,
            HIDE_ENTITY = 3,
            META_DATA = 8,
            SHOW_ENTITY = 2,
            TAG_CHANGE = 4
        }
    }

    public class PowerHistoryAction : Network.PowerHistory
    {
        public PowerHistoryAction(Network.PowerHistory.PowType tinit, PowSubType stinit) : base(tinit)
        {
            this.SubType = stinit;
        }

        public PowSubType SubType { get; set; }

        public enum PowSubType
        {
            ACTION = 0x63,
            ATTACK = 1,
            CONTINUOUS = 2,
            DEATHS = 6,
            FATIGUE = 8,
            PLAY = 7,
            POWER = 3,
            SCRIPT = 4,
            TRIGGER = 5
        }
    }

    public delegate void PresenceHandler(BattleNet.PresenceUpdate[] updates);

    public class ProfileNotices
    {
        public ProfileNotices()
        {
            this.Notices = new List<NetCache.ProfileNotice>();
        }

        public List<NetCache.ProfileNotice> Notices { get; set; }
    }

    public class PurchaseCanceledResponse
    {
        public CancelResult Result { get; set; }

        public enum CancelResult
        {
            SUCCESS,
            NOT_ALLOWED,
            NOTHING_TO_CANCEL
        }
    }

    public class PurchaseErrorInfo
    {
        public PurchaseErrorInfo()
        {
            this.Error = ErrorType.UNKNOWN;
            this.BundlePurchaseInProgress = 0;
            this.ErrorCode = string.Empty;
        }

        public int BundlePurchaseInProgress { get; set; }

        public ErrorType Error { get; set; }

        public string ErrorCode { get; set; }

        public enum ErrorType
        {
            BP_GENERIC_FAIL = 100,
            BP_INVALID_CC_EXPIRY = 0x65,
            BP_NO_VALID_PAYMENT = 0x67,
            BP_PAYMENT_AUTH = 0x68,
            BP_PROVIDER_DENIED = 0x69,
            BP_RISK_ERROR = 0x66,
            CANCELED = 11,
            DATABASE = 5,
            DUPLICATE_LICENSE = 7,
            FAILED_RISK = 10,
            INVALID_BNET = 2,
            INVALID_QUANTITY = 6,
            NO_ACTIVE_BPAY = 9,
            PRODUCT_NA = 15,
            PURCHASE_IN_PROGRESS = 4,
            REQUEST_NOT_SENT = 8,
            RISK_TIMEOUT = 0x10,
            SERVICE_NA = 3,
            STILL_IN_PROGRESS = 1,
            SUCCESS = 0,
            UNKNOWN = -1,
            WAIT_CONFIRM = 13,
            WAIT_MOP = 12,
            WAIT_RISK = 14
        }
    }

    public class PurchaseMethod
    {
        public PurchaseMethod()
        {
            this.BundleType = 0;
            this.Quantity = 0;
            this.Currency = Currency.UNKNOWN;
            this.WalletName = string.Empty;
            this.UseEBalance = false;
            this.PurchaseError = null;
        }

        public int BundleType { get; set; }

        public Currency Currency { get; set; }

        public Network.PurchaseErrorInfo PurchaseError { get; set; }

        public int Quantity { get; set; }

        public bool UseEBalance { get; set; }

        public string WalletName { get; set; }
    }

    public class PurchaseResponse
    {
        public PurchaseResponse()
        {
            this.PurchaseError = new Network.PurchaseErrorInfo();
        }

        public Network.PurchaseErrorInfo PurchaseError { get; set; }
    }

    public class PurchaseViaGoldResponse
    {
        public PurchaseViaGoldResponse()
        {
            this.Error = ErrorType.UNKNOWN;
            this.GoldUsed = 0L;
        }

        public ErrorType Error { get; set; }

        public long GoldUsed { get; set; }

        public enum ErrorType
        {
            FEATURE_NA = 4,
            INSUFFICIENT_GOLD = 2,
            INVALID_QUANTITY = 5,
            PRODUCT_NA = 3,
            SUCCESS = 1,
            UNKNOWN = -1
        }
    }

    public enum TrackLevel
    {
        LEVEL_ERROR = 3,
        LEVEL_INFO = 1,
        LEVEL_WARN = 2
    }

    public enum TrackWhat
    {
        TRACK_ACCEPT_FRIEND_GAME_WITH_CUSTOM_DECK = 10,
        TRACK_ACCEPT_FRIEND_GAME_WITH_PRECON_DECK = 11,
        TRACK_AUTO_COMPLETE_DECK_CLICKED = 0x24,
        TRACK_BOOSTER_OPENED = 0x1b,
        TRACK_BOX_SCREEN_VISIT = 0x23,
        TRACK_BUTTON_DRAFT = 13,
        TRACK_BUTTON_PRACTICE = 15,
        TRACK_BUTTON_TOURNAMENT = 12,
        TRACK_CANCEL_MATCHMAKER = 0x18,
        TRACK_CHALLENGE_FRIEND_WITH_CUSTOM_DECK = 8,
        TRACK_CHALLENGE_FRIEND_WITH_PRECON_DECK = 9,
        TRACK_CM_CARDS_SEARCHED = 30,
        TRACK_CM_HIDE_PREMIUMS_NOT_OWNED = 0x26,
        TRACK_CM_MANA_FILTER_CLICKED = 0x1c,
        TRACK_CM_MANA_FILTER_OFF = 0x1d,
        TRACK_CM_NEW_DECK_CREATED = 0x21,
        TRACK_CM_PAGE_TURNED = 0x22,
        TRACK_CM_SHOW_CARDS_I_DONT_OWN_TURNED_OFF = 0x20,
        TRACK_CM_SHOW_CARDS_I_DONT_OWN_TURNED_ON = 0x1f,
        TRACK_CM_SHOW_PREMIUMS_NOT_OWNED = 0x25,
        TRACK_COLLECTION_MANAGER = 1,
        TRACK_DISPLAYED_LOSS_SCREEN = 0x12,
        TRACK_DISPLAYED_TIE_SCREEN = 0x13,
        TRACK_DISPLAYED_WIN_SCREEN = 0x11,
        TRACK_GAME_START = 0x17,
        TRACK_LOGIN_FINISHED = 0x15,
        TRACK_LOGOUT_STARTING = 0x16,
        TRACK_PLAY_CASUAL_WITH_CUSTOM_DECK = 4,
        TRACK_PLAY_CASUAL_WITH_PRECON_DECK = 5,
        TRACK_PLAY_FORGE_QUEUE = 0x27,
        TRACK_PLAY_PRACTICE_WITH_CUSTOM_DECK = 2,
        TRACK_PLAY_PRACTICE_WITH_PRECON_DECK = 3,
        TRACK_PLAY_TOURNAMENT_WITH_CUSTOM_DECK = 6,
        TRACK_PLAY_TOURNAMENT_WITH_PRECON_DECK = 7,
        TRACK_RECEIVED_BOOSTER_PACK = 20,
        TRACK_START_TUTORIAL = 0x10,
        TRACK_TOGGLE_DECK_TYPE = 0x1a,
        TRACK_VISIT_PACK_OPEN_SCREEN = 0x19,
        ZZ_DEPRECATED_TRACK_BUTTON_CASUAL = 14
    }

    public class TurnTimerInfo
    {
        public float Seconds { get; set; }

        public int Turn { get; set; }
    }

    public class UserUI
    {
        public EmoteInfo emoteInfo;
        public MouseInfo mouseInfo;

        public class EmoteInfo
        {
            public int Emote { get; set; }
        }

        public class MouseInfo
        {
            public int ArrowOriginID { get; set; }

            public int HeldCardID { get; set; }

            public int OverCardID { get; set; }

            public int X { get; set; }

            public int Y { get; set; }
        }
    }

    public class UtilServerInfo
    {
        public List<string> Addresses { get; set; }

        public int Client { get; set; }

        public int Password { get; set; }

        public int Port { get; set; }
    }

    public class ValidatedAchieve
    {
        public int AchieveID { get; set; }
    }

    public delegate void WhisperHandler(BattleNet.DllWhisper[] dllWhispers);

    public class ZoneAdd
    {
        public List<int> Entities { get; set; }

        public int Player { get; set; }

        public int Zone { get; set; }
    }
}


using PegasusUtil;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class NetCache
{
    private List<NetCacheRequest> m_cacheRequests = new List<NetCacheRequest>();
    private Dictionary<System.Type, int> m_changeRequests = new Dictionary<System.Type, int>();
    private List<DelGoldBalanceListener> m_goldBalanceListeners = new List<DelGoldBalanceListener>();
    private List<System.Type> m_inTransitRequests = new List<System.Type>();
    private Dictionary<System.Type, NetCacheBase> m_netCache = new Dictionary<System.Type, NetCacheBase>();
    private List<DelNewNoticesListener> m_newNoticesListeners = new List<DelNewNoticesListener>();
    private NetCacheHeroLevels m_prevHeroLevels;
    private NetCacheClientOptions m_prevOptions = new NetCacheClientOptions();
    private static Dictionary<System.Type, int> m_typeIDs;
    private readonly TimeSpan MAX_WAIT = new TimeSpan(0, 0, 15);
    private static NetCache s_instance;

    static NetCache()
    {
        Dictionary<System.Type, int> dictionary = new Dictionary<System.Type, int>();
        dictionary.Add(typeof(NetCacheLastLogin), 1);
        dictionary.Add(typeof(NetCacheDecks), 2);
        dictionary.Add(typeof(NetCacheCollection), 3);
        dictionary.Add(typeof(NetCacheMedalInfo), 4);
        dictionary.Add(typeof(NetCacheMedalHistory), 5);
        dictionary.Add(typeof(NetCacheBoosters), 6);
        dictionary.Add(typeof(NetCacheCardUsage), 7);
        dictionary.Add(typeof(NetCachePlayerRecords), 8);
        dictionary.Add(typeof(NetCacheGamesPlayed), 9);
        dictionary.Add(typeof(NetCacheDeckLimit), 10);
        dictionary.Add(typeof(NetCacheProfileProgress), 11);
        dictionary.Add(typeof(NetCacheProfileNotices), 12);
        dictionary.Add(typeof(NetCacheMessageOfTheDay), 13);
        dictionary.Add(typeof(NetCacheClientOptions), 14);
        dictionary.Add(typeof(NetCacheCardValues), 15);
        dictionary.Add(typeof(NetCacheDisconnectedGame), 0x10);
        dictionary.Add(typeof(NetCacheArcaneDustBalance), 0x11);
        dictionary.Add(typeof(NetCacheFeatures), 0x12);
        dictionary.Add(typeof(NetCacheRewardProgress), 0x13);
        dictionary.Add(typeof(NetCacheGoldBalance), 20);
        dictionary.Add(typeof(NetCacheHeroLevels), 0x15);
        m_typeIDs = dictionary;
        s_instance = new NetCache();
    }

    private void AddCollectionManagerToRequest(ref NetCacheRequest request)
    {
        this.NetCacheUse(request, typeof(NetCacheDecks));
        this.NetCacheUse(request, typeof(NetCacheCollection));
        this.NetCacheUse(request, typeof(NetCacheDeckLimit));
        this.NetCacheUse(request, typeof(NetCacheCardValues));
        this.NetCacheUse(request, typeof(NetCacheArcaneDustBalance));
        this.NetCacheUse(request, typeof(NetCacheClientOptions));
    }

    private void AddRandomDeckMakerToRequest(ref NetCacheRequest request)
    {
        this.NetCacheUse(request, typeof(NetCacheCollection));
        this.NetCacheUse(request, typeof(NetCacheCardUsage));
    }

    public bool ClientOptionExists(ServerOption type)
    {
        NetCacheBase base2;
        if (!this.m_netCache.TryGetValue(typeof(NetCacheClientOptions), out base2))
        {
            return false;
        }
        NetCacheClientOptions options = base2 as NetCacheClientOptions;
        if (options == null)
        {
            return false;
        }
        if (!options.ClientOptions.ContainsKey(type))
        {
            return false;
        }
        ClientOptionBase base3 = options.ClientOptions[type];
        return (base3 != null);
    }

    public static void DefaultErrorHandler(ErrorInfo info)
    {
        if (info.Error == ErrorCode.TIMEOUT)
        {
            ShowError(info, "GLOBAL_ERROR_NETWORK_UTIL_TIMEOUT", new object[0]);
        }
        else
        {
            ShowError(info, "GLOBAL_ERROR_NETWORK_GENERIC", new object[0]);
        }
    }

    public void DeleteClientOption(ServerOption type)
    {
        ConnectAPI.DeleteClientOption((int) type);
        this.SetClientOption(type, null);
    }

    public static NetCache Get()
    {
        if (s_instance == null)
        {
            Debug.LogError("no NetCache object");
        }
        return s_instance;
    }

    public bool GetBoolOption(ServerOption type)
    {
        ClientOptionBool ret = null;
        if (!this.GetOption<ClientOptionBool>(type, out ret))
        {
            return false;
        }
        return ret.OptionValue;
    }

    public bool GetBoolOption(ServerOption type, out bool ret)
    {
        ret = false;
        ClientOptionBool @bool = null;
        if (!this.GetOption<ClientOptionBool>(type, out @bool))
        {
            return false;
        }
        ret = @bool.OptionValue;
        return true;
    }

    public float GetFloatOption(ServerOption type)
    {
        ClientOptionFloat ret = null;
        if (!this.GetOption<ClientOptionFloat>(type, out ret))
        {
            return 0f;
        }
        return ret.OptionValue;
    }

    public bool GetFloatOption(ServerOption type, out float ret)
    {
        ret = 0f;
        ClientOptionFloat num = null;
        if (!this.GetOption<ClientOptionFloat>(type, out num))
        {
            return false;
        }
        ret = num.OptionValue;
        return true;
    }

    public static string GetInternalErrorMessage(ErrorInfo info)
    {
        string str = "Debug Information:";
        str = (str + string.Format("\n  ErrorCode={0}", info.Error)) + string.Format("\n  RequestingFunction={0}", info.RequestingFunction.Method.Name) + string.Format("\n  RequestedTypes.Count={0}", info.RequestedTypes.Count);
        for (int i = 0; i < info.RequestedTypes.Count; i++)
        {
            str = str + string.Format("\n    [{0}]={1}", i, info.RequestedTypes[i]);
        }
        return (str + string.Format("\n  StackTrace:\n{0}", info.RequestStackTrace));
    }

    public int GetIntOption(ServerOption type)
    {
        ClientOptionInt ret = null;
        if (!this.GetOption<ClientOptionInt>(type, out ret))
        {
            return 0;
        }
        return ret.OptionValue;
    }

    public bool GetIntOption(ServerOption type, out int ret)
    {
        ret = 0;
        ClientOptionInt num = null;
        if (!this.GetOption<ClientOptionInt>(type, out num))
        {
            return false;
        }
        ret = num.OptionValue;
        return true;
    }

    public long GetLongOption(ServerOption type)
    {
        ClientOptionLong ret = null;
        if (!this.GetOption<ClientOptionLong>(type, out ret))
        {
            return 0L;
        }
        return ret.OptionValue;
    }

    public bool GetLongOption(ServerOption type, out long ret)
    {
        ret = 0L;
        ClientOptionLong @long = null;
        if (!this.GetOption<ClientOptionLong>(type, out @long))
        {
            return false;
        }
        ret = @long.OptionValue;
        return true;
    }

    public T GetNetObject<T>() where T: NetCacheBase
    {
        System.Type key = typeof(T);
        if ((key == typeof(NetCacheBoosters)) && PackOpening.IsFakePackOpeningEnabled())
        {
            NetCacheBoosters boosters = new NetCacheBoosters();
            int fakePackCount = PackOpening.GetFakePackCount();
            BoosterStack stack2 = new BoosterStack {
                Type = BoosterType.EXPERT,
                Count = fakePackCount
            };
            BoosterStack item = stack2;
            boosters.BoosterStacks.Add(item);
            NetCacheBase base2 = boosters;
            return (T) base2;
        }
        if (this.m_netCache.ContainsKey(key))
        {
            return (this.m_netCache[key] as T);
        }
        Debug.LogWarning(string.Format("probably accessing {0} before fully loaded", key));
        return null;
    }

    private bool GetOption<T>(ServerOption type, out T ret) where T: ClientOptionBase
    {
        ret = null;
        NetCacheClientOptions netObject = Get().GetNetObject<NetCacheClientOptions>();
        if (!this.ClientOptionExists(type))
        {
            return false;
        }
        T local = netObject.ClientOptions[type] as T;
        if (local == null)
        {
            return false;
        }
        ret = local;
        return true;
    }

    public void Heartbeat()
    {
        NetCacheRequest[] requestArray = this.m_cacheRequests.ToArray();
        DateTime now = DateTime.Now;
        foreach (NetCacheRequest request in requestArray)
        {
            if (request.m_canTimeout)
            {
                TimeSpan span = (TimeSpan) (now - request.m_timeAdded);
                if ((span >= this.MAX_WAIT) && !Network.Get().UnhandledPacketsWaiting())
                {
                    request.m_canTimeout = false;
                    ErrorInfo info = new ErrorInfo {
                        Error = ErrorCode.TIMEOUT,
                        RequestingFunction = request.m_requestFunc,
                        RequestedTypes = new List<System.Type>(request.m_needs),
                        RequestStackTrace = request.m_requestStackTrace
                    };
                    request.m_errorCallback(info);
                }
            }
        }
    }

    public void InitNetCache()
    {
        this.RegisterNetCacheHandlers();
    }

    private List<ProfileNotice> MergeNotices(List<ProfileNotice> newNotices)
    {
        if (this.m_netCache.ContainsKey(typeof(NetCacheProfileNotices)))
        {
            NetCacheProfileNotices netObject = this.GetNetObject<NetCacheProfileNotices>();
            if (netObject == null)
            {
                return newNotices;
            }
            <MergeNotices>c__AnonStorey13B storeyb = new <MergeNotices>c__AnonStorey13B();
            using (List<ProfileNotice>.Enumerator enumerator = netObject.Notices.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    storeyb.existingNotice = enumerator.Current;
                    if (newNotices.Find(new Predicate<ProfileNotice>(storeyb.<>m__38)) == null)
                    {
                        newNotices.Add(storeyb.existingNotice);
                    }
                }
            }
        }
        return newNotices;
    }

    public void NetCacheChanged<T>() where T: NetCacheBase
    {
        System.Type key = typeof(T);
        int num = 0;
        this.m_changeRequests.TryGetValue(key, out num);
        num++;
        this.m_changeRequests[key] = num;
        if (num <= 1)
        {
            while (this.m_changeRequests[key] > 0)
            {
                this.NetCacheChangedImpl<T>();
                this.m_changeRequests[key] -= 1;
            }
        }
    }

    private void NetCacheChangedImpl<T>() where T: NetCacheBase
    {
        foreach (NetCacheRequest request in this.m_cacheRequests.ToArray())
        {
            foreach (System.Type type in request.m_needs)
            {
                if (type == typeof(T))
                {
                    this.NetCacheCheckRequest(request);
                    break;
                }
            }
        }
    }

    private void NetCacheCheckRequest(NetCacheRequest request)
    {
        foreach (System.Type type in request.m_needs)
        {
            if (!this.m_netCache.ContainsKey(type) || (this.m_netCache[type] == null))
            {
                return;
            }
        }
        request.m_canTimeout = false;
        request.m_callback();
    }

    private void NetCacheReload(NetCacheRequest request, System.Type type)
    {
        this.m_netCache[type] = null;
        this.NetCacheUse(request, type);
    }

    private void NetCacheUse(NetCacheRequest request, System.Type type)
    {
        if (request != null)
        {
            if (request.m_needs.Contains(type))
            {
                return;
            }
            request.m_needs.Add(type);
        }
        if ((!this.m_netCache.ContainsKey(type) || (this.m_netCache[type] == null)) && (!this.m_inTransitRequests.Contains(type) && (type != typeof(NetCacheClientOptions))))
        {
            this.m_inTransitRequests.Add(type);
            ConnectAPI.RequestNetCacheObject(m_typeIDs[type]);
        }
    }

    private void OnAllHeroXP()
    {
        NetCacheHeroLevels allHeroXP = ConnectAPI.GetAllHeroXP();
        if (this.m_prevHeroLevels != null)
        {
            <OnAllHeroXP>c__AnonStorey13A storeya = new <OnAllHeroXP>c__AnonStorey13A();
            using (List<HeroLevel>.Enumerator enumerator = allHeroXP.Levels.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    storeya.newHeroLevel = enumerator.Current;
                    HeroLevel level = this.m_prevHeroLevels.Levels.Find(new Predicate<HeroLevel>(storeya.<>m__37));
                    if (level != null)
                    {
                        storeya.newHeroLevel.PrevLevel = level.CurrentLevel;
                    }
                }
            }
        }
        this.m_prevHeroLevels = allHeroXP;
        this.OnNetCacheObjReceived<NetCacheHeroLevels>(allHeroXP);
    }

    private void OnArcaneDustBalance()
    {
        NetCacheArcaneDustBalance netCacheObject = new NetCacheArcaneDustBalance {
            Balance = ConnectAPI.GetArcaneDustBalance()
        };
        this.OnNetCacheObjReceived<NetCacheArcaneDustBalance>(netCacheObject);
    }

    public void OnArcaneDustBalanceChanged(long balanceChange)
    {
        NetCacheArcaneDustBalance netObject = this.GetNetObject<NetCacheArcaneDustBalance>();
        netObject.Balance += balanceChange;
        this.NetCacheChanged<NetCacheArcaneDustBalance>();
    }

    private void OnBoosters()
    {
        this.OnNetCacheObjReceived<NetCacheBoosters>(ConnectAPI.GetBoosters());
    }

    public void OnBoostersPurchased(BoosterType boosterType, int numNewBoosters)
    {
        NetCacheBoosters netObject = this.GetNetObject<NetCacheBoosters>();
        BoosterStack boosterStack = netObject.GetBoosterStack(boosterType);
        if (boosterStack == null)
        {
            BoosterStack stack2 = new BoosterStack {
                Type = boosterType,
                Count = 0
            };
            boosterStack = stack2;
            netObject.BoosterStacks.Add(boosterStack);
        }
        boosterStack.Count += numNewBoosters;
        this.NetCacheChanged<NetCacheBoosters>();
    }

    private void OnCardUsages()
    {
        this.OnNetCacheObjReceived<NetCacheCardUsage>(ConnectAPI.GetCardUsage());
    }

    private void OnCardValues()
    {
        NetCacheCardValues netCacheObject = new NetCacheCardValues();
        IEnumerator<PegasusUtil.CardValue> enumerator = ConnectAPI.GetCardValues().CardsList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                PegasusUtil.CardValue current = enumerator.Current;
                if (CardManifest.Get().Find(current.Card.Asset) == null)
                {
                    Debug.LogError(string.Format("NetCache.OnCardValues(): Manifest does not contain card asset {0}. Somebody broke the manifest.", current.Card.Asset));
                }
                CardDefinition key = new CardDefinition {
                    Name = CardManifest.Get().Find(current.Card.Asset).CardID,
                    Premium = (CardFlair.PremiumType) current.Card.Premium
                };
                CardValue value3 = new CardValue {
                    Buy = current.Buy,
                    Sell = current.Sell
                };
                netCacheObject.Values.Add(key, value3);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        this.OnNetCacheObjReceived<NetCacheCardValues>(netCacheObject);
    }

    private void OnClientOptions()
    {
        NetCacheClientOptions prevOptions = this.m_prevOptions;
        if (this.m_netCache.ContainsKey(typeof(NetCacheClientOptions)))
        {
            prevOptions = this.m_netCache[typeof(NetCacheClientOptions)] as NetCacheClientOptions;
        }
        if (prevOptions == null)
        {
            prevOptions = new NetCacheClientOptions();
        }
        ConnectAPI.ReadClientOptions(prevOptions.ClientOptions);
        this.OnNetCacheObjReceived<NetCacheClientOptions>(prevOptions);
        this.m_prevOptions = prevOptions;
    }

    private void OnCollection()
    {
        this.OnNetCacheObjReceived<NetCacheCollection>(ConnectAPI.GetCollectionCardStacks());
    }

    private void OnDeckLimit()
    {
        NetCacheDeckLimit netCacheObject = new NetCacheDeckLimit {
            DeckLimit = ConnectAPI.GetDeckLimit()
        };
        this.OnNetCacheObjReceived<NetCacheDeckLimit>(netCacheObject);
    }

    private void OnDecks()
    {
        this.OnNetCacheObjReceived<NetCacheDecks>(ConnectAPI.GetDeckHeaders());
    }

    private void OnFeaturesChanged()
    {
        NetCacheFeatures netCacheObject = ConnectAPI.GetFeatures();
        this.OnNetCacheObjReceived<NetCacheFeatures>(netCacheObject);
    }

    private void OnGamesInfo()
    {
        NetCacheGamesPlayed gamesInfo = ConnectAPI.GetGamesInfo();
        if (gamesInfo == null)
        {
            Debug.LogWarning("error getting games info");
        }
        else
        {
            this.OnNetCacheObjReceived<NetCacheGamesPlayed>(gamesInfo);
        }
    }

    private void OnGoldBalance()
    {
        NetCacheGoldBalance netCacheObject = new NetCacheGoldBalance {
            Balance = ConnectAPI.GetGoldBalance()
        };
        this.OnNetCacheObjReceived<NetCacheGoldBalance>(netCacheObject);
    }

    public void OnGoldBalanceChanged(long balanceChange)
    {
        NetCacheGoldBalance netObject = this.GetNetObject<NetCacheGoldBalance>();
        netObject.Balance += balanceChange;
        this.NetCacheChanged<NetCacheGoldBalance>();
        foreach (DelGoldBalanceListener listener in this.m_goldBalanceListeners)
        {
            listener(netObject);
        }
    }

    public void OnLastGameInfo()
    {
        NetCacheDisconnectedGame netCacheObject = new NetCacheDisconnectedGame {
            ServerInfo = ConnectAPI.GetDisconnectedGameInfo()
        };
        this.OnNetCacheObjReceived<NetCacheDisconnectedGame>(netCacheObject);
    }

    private void OnLastLogin()
    {
        this.OnNetCacheObjReceived<NetCacheLastLogin>(ConnectAPI.GetLastLogin());
    }

    private void OnMedalHistory()
    {
        this.OnNetCacheObjReceived<NetCacheMedalHistory>(ConnectAPI.GetMedalHistory());
    }

    private void OnMedalInfo()
    {
        this.OnNetCacheObjReceived<NetCacheMedalInfo>(ConnectAPI.GetMedalInfo());
    }

    private void OnMessageOfTheDay()
    {
        NetCacheMessageOfTheDay netCacheObject = new NetCacheMessageOfTheDay {
            Text = ConnectAPI.GetMessageOfTheDay()
        };
        this.OnNetCacheObjReceived<NetCacheMessageOfTheDay>(netCacheObject);
    }

    private void OnNetCacheObjReceived<T>(T netCacheObject) where T: NetCacheBase
    {
        System.Type item = typeof(T);
        this.m_netCache[item] = netCacheObject;
        this.m_inTransitRequests.Remove(item);
        this.NetCacheChanged<T>();
    }

    private void OnPlayerRecords()
    {
        this.OnNetCacheObjReceived<NetCachePlayerRecords>(ConnectAPI.GetPlayerRecords());
    }

    private void OnProfileNotices()
    {
        List<ProfileNotice> newNotices = new List<ProfileNotice>();
        foreach (ProfileNotice notice in ConnectAPI.GetProfileNotices())
        {
            newNotices.Add(notice);
        }
        List<ProfileNotice> list3 = this.MergeNotices(newNotices);
        NetCacheProfileNotices netCacheObject = new NetCacheProfileNotices();
        foreach (ProfileNotice notice2 in list3)
        {
            netCacheObject.Notices.Add(notice2);
        }
        this.OnNetCacheObjReceived<NetCacheProfileNotices>(netCacheObject);
        foreach (DelNewNoticesListener listener in this.m_newNoticesListeners)
        {
            listener(newNotices);
        }
    }

    private void OnProfileProgress()
    {
        this.OnNetCacheObjReceived<NetCacheProfileProgress>(ConnectAPI.GetProfileProgress());
    }

    private void OnRewardProgress()
    {
        this.OnNetCacheObjReceived<NetCacheRewardProgress>(ConnectAPI.GetRewardProgress());
    }

    public void RegisterCollectionManager(NetCacheCallback callback)
    {
        this.RegisterCollectionManager(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterCollectionManager(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterCollectionManager));
        this.AddCollectionManagerToRequest(ref request);
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterFeatures(NetCacheCallback callback)
    {
        this.RegisterFeatures(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterFeatures(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterFeatures));
        this.NetCacheUse(request, typeof(NetCacheFeatures));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterFriendChallenge(NetCacheCallback callback)
    {
        this.RegisterFriendChallenge(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterFriendChallenge(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterFriendChallenge));
        this.NetCacheUse(request, typeof(NetCacheProfileProgress));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterGoldBalanceListener(DelGoldBalanceListener listener)
    {
        if (!this.m_goldBalanceListeners.Contains(listener))
        {
            this.m_goldBalanceListeners.Add(listener);
        }
    }

    private void RegisterNetCacheHandlers()
    {
        Network network = Network.Get();
        network.RegisterNetHandler(Network.PacketID.BOOSTER_LIST, new Network.NetHandler(this.OnBoosters));
        network.RegisterNetHandler(Network.PacketID.COLLECTION, new Network.NetHandler(this.OnCollection));
        network.RegisterNetHandler(Network.PacketID.DECK_LIST, new Network.NetHandler(this.OnDecks));
        network.RegisterNetHandler(Network.PacketID.MEDAL_HISTORY, new Network.NetHandler(this.OnMedalHistory));
        network.RegisterNetHandler(Network.PacketID.MEDAL_INFO, new Network.NetHandler(this.OnMedalInfo));
        network.RegisterNetHandler(Network.PacketID.LAST_LOGIN, new Network.NetHandler(this.OnLastLogin));
        network.RegisterNetHandler(Network.PacketID.DECK_LIMIT, new Network.NetHandler(this.OnDeckLimit));
        network.RegisterNetHandler(Network.PacketID.PROFILE_PROGRESS, new Network.NetHandler(this.OnProfileProgress));
        network.RegisterNetHandler(Network.PacketID.GAMES_INFO, new Network.NetHandler(this.OnGamesInfo));
        network.RegisterNetHandler(Network.PacketID.CARD_USAGES, new Network.NetHandler(this.OnCardUsages));
        network.RegisterNetHandler(Network.PacketID.PROFILE_NOTICES, new Network.NetHandler(this.OnProfileNotices));
        network.RegisterNetHandler(Network.PacketID.MESSAGE, new Network.NetHandler(this.OnMessageOfTheDay));
        network.RegisterNetHandler(Network.PacketID.CLIENT_OPTIONS, new Network.NetHandler(this.OnClientOptions));
        network.RegisterNetHandler(Network.PacketID.DISCONNECTED_GAME, new Network.NetHandler(this.OnLastGameInfo));
        network.RegisterNetHandler(Network.PacketID.CARD_VALUES, new Network.NetHandler(this.OnCardValues));
        network.RegisterNetHandler(Network.PacketID.ACCOUNT_BALANCE, new Network.NetHandler(this.OnArcaneDustBalance));
        network.RegisterNetHandler(Network.PacketID.GOLD_BALANCE, new Network.NetHandler(this.OnGoldBalance));
        network.RegisterNetHandler(Network.PacketID.FEATURES_CHANGED, new Network.NetHandler(this.OnFeaturesChanged));
        network.RegisterNetHandler(Network.PacketID.PLAYER_RECORDS, new Network.NetHandler(this.OnPlayerRecords));
        network.RegisterNetHandler(Network.PacketID.REWARD_PROGRESS, new Network.NetHandler(this.OnRewardProgress));
        network.RegisterNetHandler(Network.PacketID.ALL_HERO_XP, new Network.NetHandler(this.OnAllHeroXP));
    }

    public void RegisterNewNoticesListener(DelNewNoticesListener listener)
    {
        if (!this.m_newNoticesListeners.Contains(listener))
        {
            this.m_newNoticesListeners.Add(listener);
        }
    }

    public void RegisterProfileNotices(NetCacheCallback callback)
    {
        this.RegisterProfileNotices(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterProfileNotices(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterProfileNotices));
        this.NetCacheUse(request, typeof(NetCacheProfileNotices));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterScreenBox(NetCacheCallback callback)
    {
        this.RegisterScreenBox(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterScreenBox(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterScreenBox));
        this.NetCacheReload(request, typeof(NetCacheBoosters));
        this.NetCacheUse(request, typeof(NetCacheClientOptions));
        this.NetCacheReload(request, typeof(NetCacheProfileProgress));
        this.NetCacheReload(request, typeof(NetCacheFeatures));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterScreenCollectionManager(NetCacheCallback callback)
    {
        this.RegisterScreenCollectionManager(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterScreenCollectionManager(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterScreenCollectionManager));
        this.AddCollectionManagerToRequest(ref request);
        this.AddRandomDeckMakerToRequest(ref request);
        this.NetCacheUse(request, typeof(NetCacheFeatures));
        this.NetCacheUse(request, typeof(NetCacheHeroLevels));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterScreenEndOfGame(NetCacheCallback callback)
    {
        this.RegisterScreenEndOfGame(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterScreenEndOfGame(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterScreenEndOfGame));
        this.NetCacheUse(request, typeof(NetCacheMedalHistory));
        this.NetCacheUse(request, typeof(NetCacheRewardProgress));
        this.NetCacheReload(request, typeof(NetCacheMedalInfo));
        this.NetCacheReload(request, typeof(NetCacheGamesPlayed));
        this.NetCacheReload(request, typeof(NetCacheProfileNotices));
        this.NetCacheReload(request, typeof(NetCachePlayerRecords));
        this.NetCacheReload(request, typeof(NetCacheHeroLevels));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterScreenForge(NetCacheCallback callback)
    {
        this.RegisterScreenForge(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterScreenForge(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterScreenCollectionManager));
        this.AddCollectionManagerToRequest(ref request);
        this.NetCacheUse(request, typeof(NetCacheFeatures));
        this.NetCacheUse(request, typeof(NetCacheHeroLevels));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterScreenFriendly(NetCacheCallback callback)
    {
        this.RegisterScreenFriendly(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterScreenFriendly(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterScreenFriendly));
        this.NetCacheUse(request, typeof(NetCacheDecks));
        this.NetCacheUse(request, typeof(NetCacheHeroLevels));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterScreenLogin(NetCacheCallback callback)
    {
        this.RegisterScreenLogin(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterScreenLogin(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterScreenLogin));
        this.NetCacheUse(request, typeof(NetCacheProfileNotices));
        this.NetCacheUse(request, typeof(NetCacheProfileProgress));
        this.NetCacheUse(request, typeof(NetCacheRewardProgress));
        this.NetCacheUse(request, typeof(NetCachePlayerRecords));
        this.NetCacheUse(request, typeof(NetCacheDisconnectedGame));
        this.NetCacheUse(request, typeof(NetCacheGoldBalance));
        this.NetCacheReload(request, typeof(NetCacheClientOptions));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
        Network.GetAllClientOptions();
    }

    public void RegisterScreenPackOpening(NetCacheCallback callback)
    {
        this.RegisterScreenPackOpening(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterScreenPackOpening(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterScreenPackOpening));
        this.NetCacheReload(request, typeof(NetCacheBoosters));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterScreenPractice(NetCacheCallback callback)
    {
        this.RegisterScreenPractice(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterScreenPractice(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterScreenPractice));
        this.NetCacheUse(request, typeof(NetCacheDecks));
        this.NetCacheUse(request, typeof(NetCacheFeatures));
        this.NetCacheUse(request, typeof(NetCacheHeroLevels));
        this.NetCacheUse(request, typeof(NetCacheRewardProgress));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterScreenQuestLog(NetCacheCallback callback)
    {
        this.RegisterScreenQuestLog(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterScreenQuestLog(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterScreenQuestLog));
        this.NetCacheUse(request, typeof(NetCacheMedalInfo));
        this.NetCacheUse(request, typeof(NetCacheHeroLevels));
        this.NetCacheUse(request, typeof(NetCachePlayerRecords));
        this.NetCacheUse(request, typeof(NetCacheProfileProgress));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterScreenTourneys(NetCacheCallback callback)
    {
        this.RegisterScreenTourneys(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterScreenTourneys(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterScreenTourneys));
        this.NetCacheUse(request, typeof(NetCacheMedalHistory));
        this.NetCacheReload(request, typeof(NetCacheMedalInfo));
        this.NetCacheUse(request, typeof(NetCacheDecks));
        this.NetCacheUse(request, typeof(NetCacheFeatures));
        this.NetCacheUse(request, typeof(NetCacheHeroLevels));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void RegisterTutorialEndGameScreen(NetCacheCallback callback)
    {
        this.RegisterTutorialEndGameScreen(callback, new ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void RegisterTutorialEndGameScreen(NetCacheCallback callback, ErrorCallback errorCallback)
    {
        NetCacheRequest request = new NetCacheRequest(callback, errorCallback, new RequestFunc(this.RegisterTutorialEndGameScreen));
        this.NetCacheUse(request, typeof(NetCacheProfileProgress));
        this.NetCacheReload(request, typeof(NetCacheProfileNotices));
        this.m_cacheRequests.Add(request);
        this.NetCacheCheckRequest(request);
    }

    public void ReloadNetObject<T>() where T: NetCacheBase
    {
        this.NetCacheReload(null, typeof(T));
    }

    public void RemoveGoldBalanceListener(DelGoldBalanceListener listener)
    {
        this.m_goldBalanceListeners.Remove(listener);
    }

    public void RemoveNewNoticesListener(DelNewNoticesListener listener)
    {
        this.m_newNoticesListeners.Remove(listener);
    }

    public bool RemoveNotice(long ID)
    {
        <RemoveNotice>c__AnonStorey139 storey = new <RemoveNotice>c__AnonStorey139 {
            ID = ID
        };
        NetCacheProfileNotices notices = this.m_netCache[typeof(NetCacheProfileNotices)] as NetCacheProfileNotices;
        if (notices == null)
        {
            Debug.LogWarning(string.Format("NetCache.RemoveNotice({0}) - profileNotices is null", storey.ID));
            return false;
        }
        if (notices.Notices == null)
        {
            Debug.LogWarning(string.Format("NetCache.RemoveNotice({0}) - profileNotices.Notices is null", storey.ID));
            return false;
        }
        ProfileNotice item = notices.Notices.Find(new Predicate<ProfileNotice>(storey.<>m__36));
        if (item == null)
        {
            return false;
        }
        notices.Notices.Remove(item);
        return true;
    }

    public void SetBoolOption(ServerOption type, bool val)
    {
        ConnectAPI.SetClientOptionBool((int) type, val);
        this.SetClientOption(type, new ClientOptionBool(val));
    }

    private void SetClientOption(ServerOption type, ClientOptionBase newVal)
    {
        NetCacheClientOptions options = this.m_netCache[typeof(NetCacheClientOptions)] as NetCacheClientOptions;
        options.ClientOptions[type] = newVal;
        this.m_prevOptions.ClientOptions[type] = newVal;
        this.NetCacheChanged<NetCacheClientOptions>();
    }

    public void SetFloatOption(ServerOption type, float val)
    {
        ConnectAPI.SetClientOptionFloat((int) type, val);
        this.SetClientOption(type, new ClientOptionFloat(val));
    }

    public void SetIntOption(ServerOption type, int val)
    {
        ConnectAPI.SetClientOptionInt((int) type, val);
        this.SetClientOption(type, new ClientOptionInt(val));
    }

    public void SetLongOption(ServerOption type, long val)
    {
        ConnectAPI.SetClientOptionLong((int) type, val);
        this.SetClientOption(type, new ClientOptionLong(val));
    }

    public static void ShowError(ErrorInfo info, string localizationKey, params object[] localizationArgs)
    {
        string header = GameStrings.Get("GLOBAL_ERROR_NETWORK_TITLE");
        string message = GameStrings.Format(localizationKey, localizationArgs);
        Error.AddFatal(header, message);
        Debug.LogError(GetInternalErrorMessage(info));
    }

    public void UnloadNetObject<T>() where T: NetCacheBase
    {
        System.Type type = typeof(T);
        this.m_netCache[type] = null;
    }

    public void UnregisterNetCacheHandler(NetCacheCallback handler)
    {
        foreach (NetCacheRequest request in this.m_cacheRequests)
        {
            if (request.m_callback == handler)
            {
                this.m_cacheRequests.Remove(request);
                break;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <MergeNotices>c__AnonStorey13B
    {
        internal NetCache.ProfileNotice existingNotice;

        internal bool <>m__38(NetCache.ProfileNotice obj)
        {
            return (obj.NoticeID == this.existingNotice.NoticeID);
        }
    }

    [CompilerGenerated]
    private sealed class <OnAllHeroXP>c__AnonStorey13A
    {
        internal NetCache.HeroLevel newHeroLevel;

        internal bool <>m__37(NetCache.HeroLevel obj)
        {
            return (obj.Class == this.newHeroLevel.Class);
        }
    }

    [CompilerGenerated]
    private sealed class <RemoveNotice>c__AnonStorey139
    {
        internal long ID;

        internal bool <>m__36(NetCache.ProfileNotice obj)
        {
            return (obj.NoticeID == this.ID);
        }
    }

    public class BoosterCard
    {
        public BoosterCard()
        {
            this.Def = new NetCache.CardDefinition();
        }

        public long Date { get; set; }

        public NetCache.CardDefinition Def { get; set; }
    }

    public class BoosterStack
    {
        public int Count { get; set; }

        public BoosterType Type { get; set; }
    }

    public class CardDefinition
    {
        public override bool Equals(object obj)
        {
            NetCache.CardDefinition definition = obj as NetCache.CardDefinition;
            return (((definition != null) && (this.Premium == definition.Premium)) && this.Name.Equals(definition.Name));
        }

        public override int GetHashCode()
        {
            return (this.Name.GetHashCode() + this.Premium);
        }

        public override string ToString()
        {
            return string.Format("[CardDefinition: Name={0}, Premium={1}]", this.Name, this.Premium);
        }

        public string Name { get; set; }

        public CardFlair.PremiumType Premium { get; set; }
    }

    public class CardStack
    {
        public CardStack()
        {
            this.Def = new NetCache.CardDefinition();
        }

        public int Count { get; set; }

        public long Date { get; set; }

        public NetCache.CardDefinition Def { get; set; }

        public int NumSeen { get; set; }
    }

    public class CardUseInfo
    {
        public int Count { get; set; }

        public int ID { get; set; }
    }

    public class CardValue
    {
        public int Buy { get; set; }

        public int Sell { get; set; }
    }

    public class ClientOptionBase
    {
    }

    public class ClientOptionBool : NetCache.ClientOptionBase
    {
        public ClientOptionBool(bool val)
        {
            this.OptionValue = val;
        }

        public bool OptionValue { get; set; }
    }

    public class ClientOptionFloat : NetCache.ClientOptionBase
    {
        public ClientOptionFloat(float val)
        {
            this.OptionValue = val;
        }

        public float OptionValue { get; set; }
    }

    public class ClientOptionInt : NetCache.ClientOptionBase
    {
        public ClientOptionInt(int val)
        {
            this.OptionValue = val;
        }

        public int OptionValue { get; set; }
    }

    public class ClientOptionLong : NetCache.ClientOptionBase
    {
        public ClientOptionLong(long val)
        {
            this.OptionValue = val;
        }

        public long OptionValue { get; set; }
    }

    public enum DeckFlags
    {
        CORRECT_CLASS = 0x10,
        CORRECT_COUNTS = 8,
        DECK_HAS_30_CARDS = 4,
        PLAYER_OWNS_CARDS = 2,
        PLAYER_OWNS_HERO = 1,
        VALID_TOURNEY_DECK = 0x1f
    }

    public class DeckHeader
    {
        public override string ToString()
        {
            object[] args = new object[] { this.ID, this.Name, this.Hero, this.HeroPower, this.IsTourneyValid, this.Type };
            return string.Format("[DeckHeader: ID={0}, Name={1}, Hero={2}, HeroPower={3}, IsTourneyValid={4}, DeckType={5}]", args);
        }

        public string Hero { get; set; }

        public string HeroPower { get; set; }

        public long ID { get; set; }

        public bool IsTourneyValid { get; set; }

        public string Name { get; set; }

        public DeckType Type { get; set; }

        public enum DeckType
        {
            NORMAL_DECK = 1,
            PRECON_DECK = 5
        }
    }

    public delegate void DelGoldBalanceListener(NetCache.NetCacheGoldBalance balance);

    public delegate void DelNewNoticesListener(List<NetCache.ProfileNotice> newNotices);

    public delegate void ErrorCallback(NetCache.ErrorInfo info);

    public enum ErrorCode
    {
        NONE,
        TIMEOUT
    }

    public class ErrorInfo
    {
        public NetCache.ErrorCode Error { get; set; }

        public List<System.Type> RequestedTypes { get; set; }

        public NetCache.RequestFunc RequestingFunction { get; set; }

        public string RequestStackTrace { get; set; }
    }

    public class HeroLevel
    {
        public HeroLevel()
        {
            this.Class = TAG_CLASS.NONE;
            this.PrevLevel = null;
            this.CurrentLevel = new LevelInfo();
            this.NextReward = null;
        }

        public override string ToString()
        {
            object[] args = new object[] { this.Class, this.PrevLevel, this.CurrentLevel, this.NextReward };
            return string.Format("[HeroLevel: Class={0}, PrevLevel={1}, CurrentLevel={2}, NextReward={3}]", args);
        }

        public TAG_CLASS Class { get; set; }

        public LevelInfo CurrentLevel { get; set; }

        public NextLevelReward NextReward { get; set; }

        public LevelInfo PrevLevel { get; set; }

        public class LevelInfo
        {
            public LevelInfo()
            {
                this.Level = 0;
                this.XP = 0L;
                this.MaxXP = 0L;
            }

            public override string ToString()
            {
                return string.Format("[LevelInfo: Level={0}, XP={1}, MaxXP={2}]", this.Level, this.XP, this.MaxXP);
            }

            public int Level { get; set; }

            public long MaxXP { get; set; }

            public long XP { get; set; }
        }

        public class NextLevelReward
        {
            public NextLevelReward()
            {
                this.Level = 0;
                this.Reward = null;
            }

            public override string ToString()
            {
                return string.Format("[NextLevelReward: Level={0}, Reward={1}]", this.Level, this.Reward);
            }

            public int Level { get; set; }

            public RewardData Reward { get; set; }
        }
    }

    public class MedalHistory
    {
        public long Gained { get; set; }

        public int GrandMaster { get; set; }

        public Medal Medal { get; set; }
    }

    public class NetCacheArcaneDustBalance : NetCache.NetCacheBase
    {
        public long Balance { get; set; }
    }

    public class NetCacheBase
    {
        public DateTime m_timeAdded;
    }

    public class NetCacheBoosters : NetCache.NetCacheBase
    {
        public NetCacheBoosters()
        {
            this.BoosterStacks = new List<NetCache.BoosterStack>();
        }

        public NetCache.BoosterStack GetBoosterStack(BoosterType type)
        {
            <GetBoosterStack>c__AnonStorey13C storeyc = new <GetBoosterStack>c__AnonStorey13C {
                type = type
            };
            return this.BoosterStacks.Find(new Predicate<NetCache.BoosterStack>(storeyc.<>m__39));
        }

        public int GetTotalNumBoosters()
        {
            int num = 0;
            foreach (NetCache.BoosterStack stack in this.BoosterStacks)
            {
                num += stack.Count;
            }
            return num;
        }

        public List<NetCache.BoosterStack> BoosterStacks { get; set; }

        [CompilerGenerated]
        private sealed class <GetBoosterStack>c__AnonStorey13C
        {
            internal BoosterType type;

            internal bool <>m__39(NetCache.BoosterStack obj)
            {
                return (obj.Type == this.type);
            }
        }
    }

    public delegate void NetCacheCallback();

    public class NetCacheCardUsage : NetCache.NetCacheBase
    {
        public NetCacheCardUsage()
        {
            this.Cards = new List<NetCache.CardUseInfo>();
        }

        public List<NetCache.CardUseInfo> Cards { get; set; }
    }

    public class NetCacheCardValues : NetCache.NetCacheBase
    {
        public NetCacheCardValues()
        {
            this.Values = new Dictionary<NetCache.CardDefinition, NetCache.CardValue>();
        }

        public Dictionary<NetCache.CardDefinition, NetCache.CardValue> Values { get; set; }
    }

    public class NetCacheClientOptions : NetCache.NetCacheBase
    {
        public NetCacheClientOptions()
        {
            this.ClientOptions = new Dictionary<ServerOption, NetCache.ClientOptionBase>();
        }

        public Dictionary<ServerOption, NetCache.ClientOptionBase> ClientOptions { get; set; }
    }

    public class NetCacheCollection : NetCache.NetCacheBase
    {
        public NetCacheCollection()
        {
            this.Stacks = new List<NetCache.CardStack>();
        }

        public List<NetCache.CardStack> Stacks { get; set; }
    }

    public class NetCacheDeckLimit : NetCache.NetCacheBase
    {
        public int DeckLimit { get; set; }
    }

    public class NetCacheDecks : NetCache.NetCacheBase
    {
        public NetCacheDecks()
        {
            this.Decks = new List<NetCache.DeckHeader>();
        }

        public List<NetCache.DeckHeader> Decks { get; set; }
    }

    public class NetCacheDisconnectedGame : NetCache.NetCacheBase
    {
        public BattleNet.GameServerInfo ServerInfo { get; set; }
    }

    public class NetCacheFeatures : NetCache.NetCacheBase
    {
        public NetCacheFeatures()
        {
            this.Games = new CacheGames();
            this.Collection = new CacheCollection();
            this.Store = new CacheStore();
            this.Heroes = new CacheHeroes();
        }

        public CacheCollection Collection { get; set; }

        public CacheGames Games { get; set; }

        public CacheHeroes Heroes { get; set; }

        public CacheStore Store { get; set; }

        public class CacheCollection
        {
            public bool Crafting { get; set; }

            public bool Manager { get; set; }
        }

        public class CacheGames
        {
            public bool Casual { get; set; }

            public bool Forge { get; set; }

            public bool Friendly { get; set; }

            public bool Practice { get; set; }

            public int ShowUserUI { get; set; }

            public bool Tournament { get; set; }
        }

        public class CacheHeroes
        {
            public bool Hunter { get; set; }

            public bool Mage { get; set; }

            public bool Paladin { get; set; }

            public bool Priest { get; set; }

            public bool Rogue { get; set; }

            public bool Shaman { get; set; }

            public bool Warlock { get; set; }

            public bool Warrior { get; set; }
        }

        public class CacheStore
        {
            public bool BattlePay { get; set; }

            public bool BuyWithGold { get; set; }

            public bool Store { get; set; }
        }
    }

    public class NetCacheGamesPlayed : NetCache.NetCacheBase
    {
        public int GamesLost { get; set; }

        public int GamesStarted { get; set; }

        public int GamesWon { get; set; }
    }

    public class NetCacheGoldBalance : NetCache.NetCacheBase
    {
        public long Balance { get; set; }
    }

    public class NetCacheHeroLevels : NetCache.NetCacheBase
    {
        public NetCacheHeroLevels()
        {
            this.Levels = new List<NetCache.HeroLevel>();
        }

        public override string ToString()
        {
            string str = "[START NetCacheHeroLevels]\n";
            foreach (NetCache.HeroLevel level in this.Levels)
            {
                str = str + string.Format("{0}\n", level);
            }
            return (str + "[END NetCacheHeroLevels]");
        }

        public List<NetCache.HeroLevel> Levels { get; set; }
    }

    public class NetCacheLastLogin : NetCache.NetCacheBase
    {
        public long LastLogin { get; set; }
    }

    public class NetCacheMedalHistory : NetCache.NetCacheBase
    {
        public NetCacheMedalHistory()
        {
            this.Medals = new List<NetCache.MedalHistory>();
        }

        public List<NetCache.MedalHistory> Medals { get; set; }
    }

    public class NetCacheMedalInfo : NetCache.NetCacheBase
    {
        public Medal CurrMedal { get; set; }

        public float CurrXP { get; set; }

        public Medal PrevMedal { get; set; }

        public float PrevXP { get; set; }

        public int SeasonWins { get; set; }
    }

    public class NetCacheMessageOfTheDay : NetCache.NetCacheBase
    {
        public string Text { get; set; }
    }

    public class NetCachePlayerRecords : NetCache.NetCacheBase
    {
        public NetCachePlayerRecords()
        {
            this.Records = new List<NetCache.PlayerRecord>();
        }

        public List<NetCache.PlayerRecord> Records { get; set; }
    }

    public class NetCacheProfileNotices : NetCache.NetCacheBase
    {
        public NetCacheProfileNotices()
        {
            this.Notices = new List<NetCache.ProfileNotice>();
        }

        public List<NetCache.ProfileNotice> Notices { get; set; }
    }

    public class NetCacheProfileProgress : NetCache.NetCacheBase
    {
        public int BestForgeWins { get; set; }

        public long CampaignProgress { get; set; }

        public long LastForgeDate { get; set; }
    }

    private class NetCacheRequest
    {
        public NetCache.NetCacheCallback m_callback;
        public bool m_canTimeout = true;
        public NetCache.ErrorCallback m_errorCallback;
        public List<System.Type> m_needs = new List<System.Type>();
        public NetCache.RequestFunc m_requestFunc;
        public string m_requestStackTrace;
        public DateTime m_timeAdded = DateTime.Now;

        public NetCacheRequest(NetCache.NetCacheCallback reply, NetCache.ErrorCallback errorCallback, NetCache.RequestFunc requestFunc)
        {
            this.m_callback = reply;
            this.m_errorCallback = errorCallback;
            this.m_requestFunc = requestFunc;
            this.m_requestStackTrace = Environment.StackTrace;
        }
    }

    public class NetCacheRewardProgress : NetCache.NetCacheBase
    {
        public int DustPerReward { get; set; }

        public int MaxDustRewards { get; set; }

        public int MaxHeroLevel { get; set; }

        public int MaxPackRewards { get; set; }

        public BoosterType PackRewardType { get; set; }

        public int PacksPerReward { get; set; }

        public long SeasonEndDate { get; set; }

        public int WinsPerDust { get; set; }

        public int WinsPerPack { get; set; }

        public int XPSoloLimit { get; set; }
    }

    public class PlayerRecord
    {
        public int Data { get; set; }

        public int Losses { get; set; }

        public Type RecordType { get; set; }

        public int Ties { get; set; }

        public int Wins { get; set; }

        public enum Type
        {
            RECORD_DRAFT = 5,
            RECORD_MATCH_MAKER = 3,
            RECORD_RANKED = 7,
            RECORD_TUTORIAL = 4,
            RECORD_UNRANKED = 8,
            RECORD_VS_AI = 1,
            RECORD_VS_FRIEND = 2
        }
    }

    public abstract class ProfileNotice
    {
        private NoticeType m_type;

        protected ProfileNotice(NoticeType init)
        {
            this.m_type = init;
            this.NoticeID = 0L;
            this.Origin = NoticeOrigin.UNKNOWN;
            this.OriginData = 0L;
        }

        public long NoticeID { get; set; }

        public NoticeOrigin Origin { get; set; }

        public long OriginData { get; set; }

        public NoticeType Type
        {
            get
            {
                return this.m_type;
            }
        }

        public enum NoticeOrigin
        {
            ACHIEVEMENT = 7,
            ACK = 6,
            FORGE = 3,
            LEVEL_UP = 8,
            PRECON_DECK = 5,
            SEASON = 1,
            TOURNEY = 4,
            UNKNOWN = -1
        }

        public enum NoticeType
        {
            GAINED_MEDAL = 1,
            PRECON_DECK = 5,
            REWARD_BOOSTER = 2,
            REWARD_CARD = 3,
            REWARD_DUST = 6,
            REWARD_FORGE = 8,
            REWARD_GOLD = 9,
            REWARD_MOUNT = 7
        }
    }

    public class ProfileNoticeMedal : NetCache.ProfileNotice
    {
        public ProfileNoticeMedal() : base(NetCache.ProfileNotice.NoticeType.GAINED_MEDAL)
        {
        }

        public Medal Medal { get; set; }
    }

    public class ProfileNoticePreconDeck : NetCache.ProfileNotice
    {
        public ProfileNoticePreconDeck() : base(NetCache.ProfileNotice.NoticeType.PRECON_DECK)
        {
        }

        public long DeckID { get; set; }

        public int HeroAsset { get; set; }
    }

    public class ProfileNoticeRewardBooster : NetCache.ProfileNotice
    {
        public ProfileNoticeRewardBooster() : base(NetCache.ProfileNotice.NoticeType.REWARD_BOOSTER)
        {
            this.BoosterType = BoosterType.UNKNOWN;
            this.Count = 0;
        }

        public BoosterType BoosterType { get; set; }

        public int Count { get; set; }
    }

    public class ProfileNoticeRewardCard : NetCache.ProfileNotice
    {
        public ProfileNoticeRewardCard() : base(NetCache.ProfileNotice.NoticeType.REWARD_CARD)
        {
        }

        public string CardID { get; set; }

        public CardFlair.PremiumType Premium { get; set; }
    }

    public class ProfileNoticeRewardDust : NetCache.ProfileNotice
    {
        public ProfileNoticeRewardDust() : base(NetCache.ProfileNotice.NoticeType.REWARD_DUST)
        {
        }

        public int Amount { get; set; }
    }

    public class ProfileNoticeRewardForge : NetCache.ProfileNotice
    {
        public ProfileNoticeRewardForge() : base(NetCache.ProfileNotice.NoticeType.REWARD_FORGE)
        {
        }

        public int Quantity { get; set; }
    }

    public class ProfileNoticeRewardGold : NetCache.ProfileNotice
    {
        public ProfileNoticeRewardGold() : base(NetCache.ProfileNotice.NoticeType.REWARD_GOLD)
        {
        }

        public int Amount { get; set; }
    }

    public class ProfileNoticeRewardMount : NetCache.ProfileNotice
    {
        public ProfileNoticeRewardMount() : base(NetCache.ProfileNotice.NoticeType.REWARD_MOUNT)
        {
        }

        public int MountID { get; set; }
    }

    public delegate void RequestFunc(NetCache.NetCacheCallback callback, NetCache.ErrorCallback errorCallback);
}


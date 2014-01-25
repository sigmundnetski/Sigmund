using bnet.protocol;
using bnet.protocol.attribute;
using bnet.protocol.authentication;
using bnet.protocol.channel;
using bnet.protocol.connection;
using bnet.protocol.game_master;
using bnet.protocol.game_utilities;
using bnet.protocol.notification;
using bnet.protocol.presence;
using Google.ProtocolBuffers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

internal class BattleNetCSharp : IBattleNet
{
    private static string DEFAULT_ENV = "bn11-01-site01.battle.net";
    private static int DEFAULT_PORT = 0x2b6f;
    private const uint ERROR_GAME_MASTER_INVALID_GAME = 0x61a9;
    private const uint ERROR_OK = 0;
    private const int NO_AI_DECK = 0;
    private const bool RANK_NA = true;
    private const bool RANKED = false;
    private static bnet.protocol.EntityId s_accountEntity;
    private static bool s_auroraVersionAsInt = true;
    private static int s_auroraVersionInt = 0;
    private static string s_auroraVersionName = "front_no_auth.4e0db8a394_release/610 (Jan 14 2013 11:15:27)";
    private static string s_auroraVersionString = "undefined";
    private static ConnectionState s_connectionState = ConnectionState.Disconnected;
    private static uint[] s_exportedServices;
    private static bnet.protocol.EntityId s_gameAccount;
    private static List<bnet.protocol.EntityId> s_gameAccounts;
    private static ulong s_gameRequest;
    private static uint[] s_importedServices;
    private static bool s_initialized = false;
    private static string s_localeName = "enUS";
    private static ulong s_nextObjectId = 1L;
    private static Dictionary<string, NotificationHandler> s_notificationHandlers;
    private static string s_platformName = "Win";
    private static Dictionary<ulong, bnet.protocol.EntityId> s_presenceObjectMapLink;
    private static Dictionary<bnet.protocol.EntityId, PresenceRefCountObject> s_presenceSubscriptions;
    private static List<BattleNet.PresenceUpdate> s_presenceUpdates;
    private static string s_programName = "WTCG";
    private static Queue<BattleNet.QueueEvent> s_queueEvents = new Queue<BattleNet.QueueEvent>();
    private static RPCContext s_rpcBindRequest;
    private static RPCConnection s_rpcConnection = null;
    private static RPCContext s_rpcConnectRequest;
    private static RPCContext s_selectGameAccountRequest;
    private static Dictionary<ConnectionState, AuroraStateHandler> s_stateHandlers;
    private static Queue<PegasusPacket> s_utilPackets = new Queue<PegasusPacket>();
    private const bool UNRANKED = true;

    static BattleNetCSharp()
    {
        Dictionary<ConnectionState, AuroraStateHandler> dictionary = new Dictionary<ConnectionState, AuroraStateHandler>();
        dictionary.Add(ConnectionState.Connect, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_Connect));
        dictionary.Add(ConnectionState.InitRPC, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_InitRPC));
        dictionary.Add(ConnectionState.WaitForInitRPC, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_WaitForInitRPC));
        dictionary.Add(ConnectionState.Bind, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_Bind));
        dictionary.Add(ConnectionState.WaitForBind, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_WaitForBind));
        dictionary.Add(ConnectionState.Logon, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_Logon));
        dictionary.Add(ConnectionState.WaitForLogon, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_WaitForLogon));
        dictionary.Add(ConnectionState.SelectGameAccount, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_SelectGameAccount));
        dictionary.Add(ConnectionState.WaitForSelectGameAccount, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_WaitForSelectGameAccount));
        dictionary.Add(ConnectionState.Ready, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_Ready));
        dictionary.Add(ConnectionState.Disconnected, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_Unhandled));
        dictionary.Add(ConnectionState.Error, new AuroraStateHandler(BattleNetCSharp.AuroraStateHandler_Unhandled));
        s_stateHandlers = dictionary;
        s_importedServices = new uint[] { 1, 9, 8, 10, 4, 3 };
        s_exportedServices = new uint[] { 2, 4, 7, 5, 6 };
        Dictionary<string, NotificationHandler> dictionary2 = new Dictionary<string, NotificationHandler>();
        dictionary2.Add("MM_START", new NotificationHandler(BattleNetCSharp.MatchMakerStartHandler));
        dictionary2.Add("MM_END", new NotificationHandler(BattleNetCSharp.MatchMakerEndHandler));
        dictionary2.Add("GAME_ENTRY", new NotificationHandler(BattleNetCSharp.GameEntryHandler));
        s_notificationHandlers = dictionary2;
        s_presenceSubscriptions = new Dictionary<bnet.protocol.EntityId, PresenceRefCountObject>();
        s_presenceObjectMapLink = new Dictionary<ulong, bnet.protocol.EntityId>();
        s_presenceUpdates = new List<BattleNet.PresenceUpdate>();
    }

    public void AcceptPartyInvite(ref BattleNet.DllEntityId partyId)
    {
    }

    private static void AddQueueEvent(BattleNet.QueueEvent queueEvent)
    {
        Queue<BattleNet.QueueEvent> queue = s_queueEvents;
        lock (queue)
        {
            s_queueEvents.Enqueue(queueEvent);
        }
    }

    public void AnswerChallenge(ulong challengeID, IntPtr answer)
    {
    }

    public void AppQuit()
    {
        ConnectAPI.CloseAll();
        this.CloseAurora();
    }

    public static void AuroraStateHandler_Bind()
    {
        Debug.Log("RPC Bind");
        BindRequest message = CreateBindRequest(s_importedServices, s_exportedServices);
        s_rpcBindRequest = s_rpcConnection.QueueRequest(0, 2, message, null);
        s_connectionState = ConnectionState.WaitForBind;
    }

    public static void AuroraStateHandler_Connect()
    {
    }

    public static void AuroraStateHandler_InitRPC()
    {
        Debug.Log("Connect RPC");
        ConnectRequest message = ConnectRequest.CreateBuilder().BuildPartial();
        s_rpcConnectRequest = s_rpcConnection.QueueRequest(0, 1, message, null);
        s_connectionState = ConnectionState.WaitForInitRPC;
    }

    public static void AuroraStateHandler_Logon()
    {
        Debug.Log("Logon");
        LogonRequest message = CreateLogonRequest();
        s_rpcConnection.QueueRequest(1, 1, message, null);
        s_connectionState = ConnectionState.WaitForLogon;
    }

    public static void AuroraStateHandler_Ready()
    {
    }

    public static void AuroraStateHandler_SelectGameAccount()
    {
        Debug.Log("Select Game Account");
        if (s_gameAccount == null)
        {
            Debug.LogError("Did not receive a game account");
            s_connectionState = ConnectionState.Error;
        }
        else
        {
            s_selectGameAccountRequest = s_rpcConnection.QueueRequest(1, 4, s_gameAccount, null);
            s_connectionState = ConnectionState.WaitForSelectGameAccount;
        }
    }

    public static void AuroraStateHandler_Unhandled()
    {
        Debug.LogError("Unhandled Aurora State");
    }

    public static void AuroraStateHandler_WaitForBind()
    {
        if (s_rpcBindRequest.ResponseReceived)
        {
            Debug.Log("RPC Bind Response");
            PrintBindServiceResponse(BindResponse.CreateBuilder().MergeFrom(s_rpcBindRequest.Payload).BuildPartial());
            s_connectionState = ConnectionState.Logon;
        }
    }

    public static void AuroraStateHandler_WaitForInitRPC()
    {
        if (s_rpcConnectRequest.ResponseReceived)
        {
            Debug.Log("RPC Connected");
            s_connectionState = ConnectionState.Bind;
        }
    }

    public static void AuroraStateHandler_WaitForLogon()
    {
    }

    public static void AuroraStateHandler_WaitForSelectGameAccount()
    {
        if (s_selectGameAccountRequest.ResponseReceived)
        {
            Debug.Log("Select Game Account Response");
            s_connectionState = ConnectionState.Ready;
            PresenceSubscribe(s_accountEntity);
            PresenceSubscribe(s_gameAccount);
        }
    }

    public int BattleNetStatus()
    {
        switch (s_connectionState)
        {
            case ConnectionState.Disconnected:
                return 0;

            case ConnectionState.Connect:
            case ConnectionState.InitRPC:
            case ConnectionState.WaitForInitRPC:
            case ConnectionState.Bind:
            case ConnectionState.WaitForBind:
            case ConnectionState.Logon:
            case ConnectionState.WaitForLogon:
            case ConnectionState.SelectGameAccount:
            case ConnectionState.WaitForSelectGameAccount:
                return 1;

            case ConnectionState.Ready:
                return 4;

            case ConnectionState.Error:
                return 3;
        }
        Debug.LogError("Unknown Battle.Net Status");
        return 0;
    }

    public void CancelChallenge(ulong challengeID)
    {
    }

    private void CancelGame(ulong gameRequestId)
    {
        CancelGameEntryRequest.Builder builder = CancelGameEntryRequest.CreateBuilder();
        builder.RequestId = gameRequestId;
        bnet.protocol.game_master.Player.Builder builderForValue = bnet.protocol.game_master.Player.CreateBuilder();
        bnet.protocol.game_master.Identity.Builder builder3 = bnet.protocol.game_master.Identity.CreateBuilder();
        builder3.SetGameAccountId(CreateGameEntityId(s_gameAccount.High, s_gameAccount.Low));
        builderForValue.SetIdentity(builder3);
        builder.AddPlayer(builderForValue);
        s_rpcConnection.QueueRequest(8, 4, builder.BuildPartial(), new RPCContextDelegate(BattleNetCSharp.CancelGameCallback));
    }

    private static void CancelGameCallback(RPCContext context)
    {
        uint status = context.Header.Status;
        if (status != 0)
        {
            if (status != 0x61a9)
            {
                Debug.LogError("Error on cancel game: " + status);
            }
        }
        else
        {
            Debug.Log("Cancel Game Callback, status=" + status);
            s_gameRequest = 0L;
        }
    }

    public void ClearChallenges()
    {
    }

    public void ClearErrors()
    {
    }

    public void ClearFriendsUpdates()
    {
    }

    public void ClearPartyUpdates()
    {
    }

    public void ClearPresence()
    {
        s_presenceUpdates.Clear();
    }

    public void ClearWhispers()
    {
    }

    private static void ClientRequestCallback(RPCContext context)
    {
        if (context.Header.Status != 0)
        {
            Debug.LogError("Client Request failed: " + context.Header.Status);
        }
        else
        {
            ClientResponse response = ClientResponse.CreateBuilder().MergeFrom(context.Payload).BuildPartial();
            if (response.AttributeCount >= 2)
            {
                bnet.protocol.game_utilities.Attribute attribute = response.AttributeList[0];
                bnet.protocol.game_utilities.Attribute attribute2 = response.AttributeList[1];
                if (!attribute.Value.HasIntValue || !attribute2.Value.HasBlobValue)
                {
                    Debug.LogError("Malformed Attribute in Util Packet: incorrect values");
                }
                int intValue = (int) attribute.Value.IntValue;
                byte[] body = attribute2.Value.BlobValue.ToByteArray();
                PegasusPacket item = new PegasusPacket(intValue, body.Length, body);
                s_utilPackets.Enqueue(item);
            }
            else
            {
                Debug.LogError("Malformed Attribute in Util Packet: missing values");
            }
        }
    }

    public void CloseAurora()
    {
        s_rpcConnection.Disconnect();
        s_connectionState = ConnectionState.Disconnected;
    }

    public void ConnectAurora(bool fromEditor, string username, string address, int port)
    {
        Debug.Log("ConnectAurora " + username + " " + (!s_auroraVersionAsInt ? s_auroraVersionString : s_auroraVersionInt.ToString()) + " " + address);
        s_rpcConnection = new RPCConnection(username, address, port);
        this.InitRPCListeners();
        s_rpcConnection.Connect();
        s_connectionState = ConnectionState.InitRPC;
    }

    private static BindRequest CreateBindRequest(uint[] imports, uint[] exports)
    {
        BindRequest.Builder builder = BindRequest.CreateBuilder();
        foreach (uint num in imports)
        {
            builder.AddImportedServiceHash(s_rpcConnection.GetServiceNameHash(num));
        }
        foreach (uint num3 in exports)
        {
            BoundService.Builder builderForValue = BoundService.CreateBuilder();
            builderForValue.SetId(num3);
            builderForValue.SetHash(s_rpcConnection.GetListenerServiceNameHash(num3));
            builder.AddExportedService(builderForValue);
        }
        return builder.BuildPartial();
    }

    private static ClientRequest CreateClientRequest(int type, int sys, byte[] bs)
    {
        ClientRequest.Builder builder = ClientRequest.CreateBuilder();
        byte[] dst = new byte[bs.Length + 2];
        dst[0] = (byte) (type & 0xff);
        dst[1] = (byte) ((type & 0xff00) >> 8);
        Buffer.BlockCopy(bs, 0, dst, 2, bs.Length);
        builder.AddAttribute(CreateUtilAttribute("p", dst));
        if (s_auroraVersionAsInt)
        {
            builder.AddAttribute(CreateUtilAttribute("v", (int) ((10 * s_auroraVersionInt) + sys)));
        }
        else
        {
            builder.AddAttribute(CreateUtilAttribute("v", s_auroraVersionString + ((sys != 0) ? "b" : "c")));
        }
        return builder.BuildPartial();
    }

    private static bnet.protocol.game_master.Attribute.Builder CreateCreationAttribute(string name, byte[] val)
    {
        bnet.protocol.game_master.Attribute.Builder builder = bnet.protocol.game_master.Attribute.CreateBuilder();
        bnet.protocol.game_master.Variant.Builder builderForValue = bnet.protocol.game_master.Variant.CreateBuilder();
        builderForValue.SetBlobValue(ByteString.CopyFrom(val, 0, val.Length));
        builder.SetName(name);
        builder.SetValue(builderForValue);
        return builder;
    }

    private static bnet.protocol.game_master.Attribute.Builder CreateGameAttribute(string name, byte[] val)
    {
        bnet.protocol.game_master.Attribute.Builder builder = bnet.protocol.game_master.Attribute.CreateBuilder();
        bnet.protocol.game_master.Variant.Builder builderForValue = bnet.protocol.game_master.Variant.CreateBuilder();
        builderForValue.SetBlobValue(ByteString.CopyFrom(val, 0, val.Length));
        builder.SetName(name);
        builder.SetValue(builderForValue);
        return builder;
    }

    private static bnet.protocol.game_master.Attribute.Builder CreateGameAttribute(string name, bool val)
    {
        bnet.protocol.game_master.Attribute.Builder builder = bnet.protocol.game_master.Attribute.CreateBuilder();
        bnet.protocol.game_master.Variant.Builder builderForValue = bnet.protocol.game_master.Variant.CreateBuilder();
        builderForValue.SetBoolValue(val);
        builder.SetName(name);
        builder.SetValue(builderForValue);
        return builder;
    }

    private static bnet.protocol.game_master.Attribute.Builder CreateGameAttribute(string name, int val)
    {
        bnet.protocol.game_master.Attribute.Builder builder = bnet.protocol.game_master.Attribute.CreateBuilder();
        bnet.protocol.game_master.Variant.Builder builderForValue = bnet.protocol.game_master.Variant.CreateBuilder();
        builderForValue.SetIntValue((long) val);
        builder.SetName(name);
        builder.SetValue(builderForValue);
        return builder;
    }

    private static bnet.protocol.game_master.Attribute.Builder CreateGameAttribute(string name, string val)
    {
        bnet.protocol.game_master.Attribute.Builder builder = bnet.protocol.game_master.Attribute.CreateBuilder();
        bnet.protocol.game_master.Variant.Builder builderForValue = bnet.protocol.game_master.Variant.CreateBuilder();
        builderForValue.SetStringValue(val);
        builder.SetName(name);
        builder.SetValue(builderForValue);
        return builder;
    }

    private static bnet.protocol.game_master.EntityId.Builder CreateGameEntityId(ulong high, ulong low)
    {
        bnet.protocol.game_master.EntityId.Builder builder = bnet.protocol.game_master.EntityId.CreateBuilder();
        builder.SetHigh(high);
        builder.SetLow(low);
        return builder;
    }

    private static LogonRequest CreateLogonRequest()
    {
        LogonRequest.Builder builder = LogonRequest.CreateBuilder();
        builder.SetProgram(s_programName);
        builder.SetEmail(s_rpcConnection.UserName);
        builder.SetLocale(s_localeName);
        builder.SetPlatform(s_platformName);
        builder.SetVersion(s_auroraVersionName);
        builder.SetApplicationVersion(0);
        builder.SetPublicComputer(false);
        return builder.BuildPartial();
    }

    private static bnet.protocol.game_utilities.Attribute.Builder CreateUtilAttribute(string name, string val)
    {
        bnet.protocol.game_utilities.Attribute.Builder builder = bnet.protocol.game_utilities.Attribute.CreateBuilder();
        bnet.protocol.game_utilities.Variant.Builder builderForValue = bnet.protocol.game_utilities.Variant.CreateBuilder();
        builderForValue.SetStringValue(val);
        builder.SetName(name);
        builder.SetValue(builderForValue);
        return builder;
    }

    private static bnet.protocol.game_utilities.Attribute.Builder CreateUtilAttribute(string name, byte[] val)
    {
        bnet.protocol.game_utilities.Attribute.Builder builder = bnet.protocol.game_utilities.Attribute.CreateBuilder();
        bnet.protocol.game_utilities.Variant.Builder builderForValue = bnet.protocol.game_utilities.Variant.CreateBuilder();
        builderForValue.SetBlobValue(ByteString.CopyFrom(val, 0, val.Length));
        builder.SetName(name);
        builder.SetValue(builderForValue);
        return builder;
    }

    private static bnet.protocol.game_utilities.Attribute.Builder CreateUtilAttribute(string name, int val)
    {
        bnet.protocol.game_utilities.Attribute.Builder builder = bnet.protocol.game_utilities.Attribute.CreateBuilder();
        bnet.protocol.game_utilities.Variant.Builder builderForValue = bnet.protocol.game_utilities.Variant.CreateBuilder();
        builderForValue.SetIntValue((long) val);
        builder.SetName(name);
        builder.SetValue(builderForValue);
        return builder;
    }

    public void DeclinePartyInvite(ref BattleNet.DllEntityId partyId)
    {
    }

    public void DraftQueue(bool join)
    {
        if (join)
        {
            this.FindGame(BattleNet.BNetGameType.DRAFT, 2, 0L, 0L, true);
        }
        else
        {
            this.CancelGame(s_gameRequest);
            s_gameRequest = 0L;
        }
    }

    private void FindGame(BattleNet.BNetGameType gameType, int scenario, long deckId, long aiDeckId, bool unranked)
    {
        if (s_gameRequest != 0)
        {
            this.CancelGame(s_gameRequest);
            s_gameRequest = 0L;
        }
        bnet.protocol.game_master.Player.Builder builderForValue = bnet.protocol.game_master.Player.CreateBuilder();
        bnet.protocol.game_master.Identity.Builder builder2 = bnet.protocol.game_master.Identity.CreateBuilder();
        builder2.SetGameAccountId(CreateGameEntityId(s_gameAccount.High, s_gameAccount.Low));
        builderForValue.SetIdentity(builder2);
        builderForValue.AddAttribute(CreateGameAttribute("type", (int) gameType));
        builderForValue.AddAttribute(CreateGameAttribute("scenario", scenario));
        builderForValue.AddAttribute(CreateGameAttribute("ranked", !unranked));
        builderForValue.AddAttribute(CreateGameAttribute("deck", (int) deckId));
        builderForValue.AddAttribute(CreateGameAttribute("aideck", (int) aiDeckId));
        GameProperties.Builder builder3 = GameProperties.CreateBuilder();
        bnet.protocol.game_master.AttributeFilter.Builder builder4 = bnet.protocol.game_master.AttributeFilter.CreateBuilder();
        builder4.SetOp(bnet.protocol.game_master.AttributeFilter.Types.Operation.MATCH_ALL);
        if (s_auroraVersionAsInt)
        {
            builder4.AddAttribute(CreateGameAttribute("version", s_auroraVersionInt));
        }
        else if (s_auroraVersionString == "PAX")
        {
            builder4.AddAttribute(CreateGameAttribute("version", s_auroraVersionString + s_auroraVersionInt.ToString()));
        }
        else
        {
            builder4.AddAttribute(CreateGameAttribute("version", s_auroraVersionString));
        }
        builder4.AddAttribute(CreateGameAttribute("GameType", (int) gameType));
        builder3.SetFilter(builder4);
        builder3.AddCreationAttributes(CreateGameAttribute("type", (int) gameType));
        builder3.AddCreationAttributes(CreateGameAttribute("scenario", scenario));
        FindGameRequest.Builder builder5 = FindGameRequest.CreateBuilder();
        builder5.AddPlayer(builderForValue);
        builder5.SetProperties(builder3);
        FindGameRequest request = builder5.BuildPartial();
        this.PrintFindGameRequest(request);
        s_rpcConnection.QueueRequest(8, 3, request, new RPCContextDelegate(BattleNetCSharp.FindGameCallback));
    }

    private static void FindGameCallback(RPCContext context)
    {
        uint status = context.Header.Status;
        if (status != 0)
        {
            Debug.LogError("Error on cancel game: " + status);
        }
        else
        {
            Debug.Log("Find Game Callback, status=" + status);
            byte[] payload = context.Payload;
            FindGameResponse response = FindGameResponse.CreateBuilder().MergeFrom(payload).BuildPartial();
            if (response.HasRequestId)
            {
                s_gameRequest = response.RequestId;
            }
        }
    }

    private static void GameEntryHandler(bnet.protocol.notification.Notification notification)
    {
        Debug.Log("GAME_ENTRY");
        string host = null;
        int port = 0;
        string stringValue = null;
        int intValue = 0;
        int num3 = 0;
        string str3 = null;
        IEnumerator<bnet.protocol.notification.Attribute> enumerator = notification.AttributeList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                bnet.protocol.notification.Attribute current = enumerator.Current;
                if (current.Name.Equals("connection_info") && current.Value.HasMessageValue)
                {
                    byte[] data = current.Value.MessageValue.ToByteArray();
                    ConnectInfo info = ConnectInfo.CreateBuilder().MergeFrom(data).Build();
                    host = info.Host;
                    port = info.Port;
                    if (info.HasToken)
                    {
                        str3 = info.Token.ToStringUtf8();
                    }
                    IEnumerator<bnet.protocol.game_master.Attribute> enumerator2 = info.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            bnet.protocol.game_master.Attribute attribute2 = enumerator2.Current;
                            if (attribute2.Name.Equals("version") && attribute2.Value.HasStringValue)
                            {
                                stringValue = attribute2.Value.StringValue;
                            }
                            else
                            {
                                if (attribute2.Name.Equals("game") && attribute2.Value.HasIntValue)
                                {
                                    intValue = (int) attribute2.Value.IntValue;
                                    continue;
                                }
                                if ((!attribute2.Name.Equals("player") || !attribute2.Value.HasIntValue) && (attribute2.Name.Equals("id") && attribute2.Value.HasIntValue))
                                {
                                    num3 = (int) attribute2.Value.IntValue;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                }
                else if (current.Name.Equals("game_handle") && current.Value.HasMessageValue)
                {
                    byte[] buffer2 = current.Value.MessageValue.ToByteArray();
                    GameHandle.CreateBuilder().MergeFrom(buffer2).Build();
                }
                else if (current.Name.Equals("sender_id") && current.Value.HasMessageValue)
                {
                    Debug.Log("sender_id");
                }
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        BattleNet.GameServerInfo gameServer = new BattleNet.GameServerInfo {
            Address = host,
            Port = port,
            AuroraPassword = str3,
            Version = stringValue,
            GameHandle = intValue,
            ClientHandle = num3
        };
        AddQueueEvent(new BattleNet.QueueEvent(gameServer));
    }

    public static bnet.protocol.EntityId GetAccountEntity()
    {
        return s_accountEntity;
    }

    public void GetChallenges([Out] BattleNet.DllChallengeInfo[] challenges)
    {
    }

    public void GetErrors([Out] BattleNet.DllErrorInfo[] errors)
    {
    }

    public int GetErrorsCount()
    {
        return 0;
    }

    public void GetFriendsInfo(ref BattleNet.DllFriendsInfo info)
    {
    }

    public void GetFriendsUpdates([Out] BattleNet.DllFriendsUpdate[] updates)
    {
    }

    private bool GetHostAddress(string hostName, out string address)
    {
        IPAddress address2;
        if (IPAddress.TryParse(hostName, out address2))
        {
            address = address2.ToString();
            return true;
        }
        try
        {
            IPAddress[] addressList = Dns.GetHostEntry(hostName).AddressList;
            int index = 0;
            while (index < addressList.Length)
            {
                address = addressList[index].ToString();
                return true;
            }
        }
        catch (Exception exception)
        {
            Debug.LogError("Exception within GetHostAddress: " + exception.Message);
        }
        address = hostName;
        return false;
    }

    public BattleNet.Implementation GetImplementation()
    {
        return BattleNet.Implementation.CSHARP;
    }

    public BattleNet.DllEntityId GetMyGameAccountId()
    {
        return new BattleNet.DllEntityId { hi = s_gameAccount.High, lo = s_gameAccount.Low };
    }

    public void GetPartyUpdates([Out] BattleNet.DllPartyEvent[] updates)
    {
    }

    public void GetPartyUpdatesInfo(ref BattleNet.DllPartyInfo info)
    {
    }

    public void GetPresence([Out] BattleNet.PresenceUpdate[] updates)
    {
        s_presenceUpdates.CopyTo(updates);
    }

    public BattleNet.QueueEvent GetQueueEvent()
    {
        BattleNet.QueueEvent event2 = null;
        Queue<BattleNet.QueueEvent> queue = s_queueEvents;
        lock (queue)
        {
            if (s_queueEvents.Count > 0)
            {
                event2 = s_queueEvents.Dequeue();
            }
        }
        return event2;
    }

    private static string GetStoredBNetIP()
    {
        return null;
    }

    private static string GetStoredUserName()
    {
        return null;
    }

    private static string GetStoredVersion()
    {
        return null;
    }

    public void GetWhisperInfo(ref BattleNet.DllWhisperInfo info)
    {
    }

    public void GetWhispers([Out] BattleNet.DllWhisper[] whispers)
    {
    }

    private static void HandleChannelSubscriber_NotifyAdd(RPCContext context)
    {
    }

    private static void HandleChannelSubscriber_NotifyJoin(RPCContext context)
    {
        Debug.Log("HandleChannelSubscriber_NotifyJoin: " + JoinNotification.CreateBuilder().MergeFrom(context.Payload).Build());
    }

    private static void HandleChannelSubscriber_NotifyLeave(RPCContext context)
    {
        Debug.Log("HandleChannelSubscriber_NotifyLeave: " + LeaveNotification.CreateBuilder().MergeFrom(context.Payload).Build());
    }

    private static void HandleChannelSubscriber_NotifyRemove(RPCContext context)
    {
        Debug.Log("HandleChannelSubscriber_NotifyRemove: " + RemoveNotification.CreateBuilder().MergeFrom(context.Payload).Build());
    }

    private static void HandleChannelSubscriber_NotifySendMessage(RPCContext context)
    {
        Debug.Log("HandleChannelSubscriber_NotifySendMessage: " + SendMessageNotification.CreateBuilder().MergeFrom(context.Payload).Build());
    }

    private static void HandleChannelSubscriber_NotifyUpdateChannelState(RPCContext context)
    {
    }

    private static void HandleChannelSubscriber_NotifyUpdateMemberState(RPCContext context)
    {
        Debug.Log("HandleChannelSubscriber_NotifyUpdateMemberState: " + UpdateMemberStateNotification.CreateBuilder().MergeFrom(context.Payload).Build());
    }

    private static void HandleEchoRequest(RPCContext context)
    {
        Debug.Log("RPC Called: Echo");
        EchoRequest request = EchoRequest.CreateBuilder().MergeFrom(context.Payload).BuildPartial();
        EchoResponse.Builder builder = EchoResponse.CreateBuilder();
        if (request.HasTime)
        {
            builder.SetTime(request.Time);
        }
        if (request.HasPayload)
        {
            builder.SetPayload(request.Payload);
        }
        EchoResponse message = builder.BuildPartial();
        s_rpcConnection.QueueResponse(context, message);
        Console.WriteLine(string.Empty);
        Console.WriteLine("[*]send echo response");
    }

    private static void HandleForceDisconnectRequest(RPCContext context)
    {
        DisconnectNotification notification = DisconnectNotification.CreateBuilder().MergeFrom(context.Payload).BuildPartial();
        Debug.Log("RPC Called: ForceDisconnect : " + notification.ErrorCode);
    }

    private static void HandleGameUtilityServerRequest(RPCContext context)
    {
        Debug.Log("RPC Called: GameUtilityServer");
    }

    private static void HandleLoadModuleRequest(RPCContext context)
    {
        Debug.Log("RPC Called: LoadModule");
    }

    private static void HandleLogonCompleteRequest(RPCContext context)
    {
        byte[] payload = context.Payload;
        LogonResult result = LogonResult.CreateBuilder().MergeFrom(payload).BuildPartial();
        s_accountEntity = result.Account;
        s_gameAccounts = new List<bnet.protocol.EntityId>();
        IEnumerator<bnet.protocol.EntityId> enumerator = result.GameAccountList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                bnet.protocol.EntityId current = enumerator.Current;
                s_gameAccounts.Add(current);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        if (s_gameAccounts.Count > 0)
        {
            s_gameAccount = result.GameAccountList[0];
        }
        s_connectionState = ConnectionState.SelectGameAccount;
    }

    private static void HandleLogonUpdateRequest(RPCContext context)
    {
        Debug.Log("RPC Called: LogonUpdate");
    }

    private static void HandleNotificationReceived(RPCContext context)
    {
        NotificationHandler handler;
        bnet.protocol.notification.Notification notification = bnet.protocol.notification.Notification.CreateBuilder().MergeFrom(context.Payload).Build();
        Debug.Log("Notification: " + notification);
        if (s_notificationHandlers.TryGetValue(notification.Type, out handler))
        {
            handler(notification);
        }
        else
        {
            Debug.LogWarning("unhandled battle net notification: " + notification.Type);
        }
    }

    private static void HandleNotifyGameFoundRequest(RPCContext context)
    {
        Debug.Log("RPC Called: NotifyGameFound");
    }

    private static void HandlePresenceUpdates(bnet.protocol.presence.ChannelState channelState, ulong objectId)
    {
        if (s_presenceObjectMapLink.ContainsKey(objectId))
        {
            BattleNet.DllEntityId id2;
            bnet.protocol.EntityId id = s_presenceObjectMapLink[objectId];
            id2.hi = id.High;
            id2.lo = id.Low;
            IEnumerator<FieldOperation> enumerator = channelState.FieldOperationList.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    FieldOperation current = enumerator.Current;
                    BattleNet.PresenceUpdate item = new BattleNet.PresenceUpdate {
                        entityId = id2,
                        programId = new BnetProgramId(current.Field.Key.Program),
                        groupId = (int) current.Field.Key.Group,
                        fieldId = (int) current.Field.Key.Field,
                        index = (int) current.Field.Key.Index,
                        newBool = false,
                        newInt = 0L,
                        newString = string.Empty
                    };
                    if (current.Operation != FieldOperation.Types.OperationType.CLEAR)
                    {
                        if (current.Field.Value.HasBoolValue)
                        {
                            item.newBool = current.Field.Value.BoolValue;
                        }
                        else if (current.Field.Value.HasIntValue)
                        {
                            item.newInt = current.Field.Value.IntValue;
                        }
                        else if (current.Field.Value.HasStringValue)
                        {
                            item.newString = current.Field.Value.StringValue;
                        }
                        else if (current.Field.Value.HasFourccValue)
                        {
                            item.newString = new BnetProgramId(current.Field.Value.FourccValue).ToString();
                        }
                        else if (current.Field.Value.HasEntityidValue)
                        {
                            item.newEntity.hi = current.Field.Value.EntityidValue.High;
                            item.newEntity.lo = current.Field.Value.EntityidValue.Low;
                        }
                    }
                    s_presenceUpdates.Add(item);
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
        }
    }

    public bool Init(bool fromEditor)
    {
        string str5;
        if (s_initialized)
        {
            return true;
        }
        string username = null;
        string storedVersion = null;
        string hostName = null;
        int port = 0;
        try
        {
            username = GetStoredUserName();
            storedVersion = GetStoredVersion();
            hostName = GetStoredBNetIP();
        }
        catch (Exception exception)
        {
            Debug.LogError("Exception while loading settings: " + exception.Message);
        }
        if (storedVersion != null)
        {
            int num2 = -1;
            try
            {
                num2 = Convert.ToInt32(storedVersion);
            }
            catch (Exception)
            {
            }
            if (num2 >= 0)
            {
                s_auroraVersionAsInt = true;
                s_auroraVersionInt = num2;
            }
            else
            {
                s_auroraVersionAsInt = false;
                s_auroraVersionString = storedVersion;
            }
        }
        else
        {
            string str = Vars.Key("Aurora.Version.Source").GetStr("undefined");
            if (str == "product")
            {
                s_auroraVersionAsInt = true;
                s_auroraVersionInt = 2;
            }
            else if (str == "int")
            {
                s_auroraVersionAsInt = true;
                s_auroraVersionInt = Vars.Key("Aurora.Version.Int").GetInt(0);
                if (s_auroraVersionInt == 0)
                {
                    Debug.LogError("Aurora.Version.Int undefined");
                }
            }
            else if (str == "string")
            {
                s_auroraVersionAsInt = false;
                s_auroraVersionString = Vars.Key("Aurora.Version.String").GetStr("undefined");
            }
            else if (str == "PAX")
            {
                s_auroraVersionAsInt = false;
                s_auroraVersionString = "PAX";
                s_auroraVersionInt = Vars.Key("Aurora.Version.Int").GetInt(0);
                if (s_auroraVersionInt == 0)
                {
                    Debug.LogError("Aurora.Version.Int undefined");
                }
            }
            else
            {
                Debug.LogError("unknown version source: " + str);
                s_auroraVersionAsInt = true;
                s_auroraVersionInt = 0;
            }
        }
        if (username == null)
        {
            username = Vars.Key("Aurora.Username").GetStr("NOT_PROVIDED_PLEASE_PROVIDE_VIA_CONFIG");
        }
        if ((username != null) && (username.IndexOf("@") == -1))
        {
            username = username + "@blizzard.com";
        }
        switch (hostName)
        {
            case null:
                hostName = Vars.Key("Aurora.Env").GetStr(DEFAULT_ENV);
                break;

            case "default":
                hostName = DEFAULT_ENV;
                break;
        }
        if (port == 0)
        {
            port = Vars.Key("Aurora.Port").GetInt(DEFAULT_PORT);
        }
        if (this.GetHostAddress(hostName, out str5))
        {
            DebugConsole.Get().Init();
            s_initialized = ConnectAPI.ConnectInit();
            this.ConnectAurora(fromEditor, username, str5, port);
        }
        else
        {
            Error.AddDevFatal("Connection Failure", "Environment " + hostName + " could not be resolved!", new object[0]);
        }
        return s_initialized;
    }

    private void InitRPCListeners()
    {
        s_rpcConnection.RegisterServiceMethodListener(0, 4, new RPCContextDelegate(BattleNetCSharp.HandleForceDisconnectRequest));
        s_rpcConnection.RegisterServiceMethodListener(0, 3, new RPCContextDelegate(BattleNetCSharp.HandleEchoRequest));
        s_rpcConnection.RegisterServiceMethodListener(2, 5, new RPCContextDelegate(BattleNetCSharp.HandleLogonCompleteRequest));
        s_rpcConnection.RegisterServiceMethodListener(2, 10, new RPCContextDelegate(BattleNetCSharp.HandleLogonUpdateRequest));
        s_rpcConnection.RegisterServiceMethodListener(2, 1, new RPCContextDelegate(BattleNetCSharp.HandleLoadModuleRequest));
        s_rpcConnection.RegisterServiceMethodListener(9, 6, new RPCContextDelegate(BattleNetCSharp.HandleGameUtilityServerRequest));
        s_rpcConnection.RegisterServiceMethodListener(7, 1, new RPCContextDelegate(BattleNetCSharp.HandleNotifyGameFoundRequest));
        s_rpcConnection.RegisterServiceMethodListener(5, 1, new RPCContextDelegate(BattleNetCSharp.HandleNotificationReceived));
        s_rpcConnection.RegisterServiceMethodListener(6, 1, new RPCContextDelegate(BattleNetCSharp.HandleChannelSubscriber_NotifyAdd));
        s_rpcConnection.RegisterServiceMethodListener(6, 2, new RPCContextDelegate(BattleNetCSharp.HandleChannelSubscriber_NotifyJoin));
        s_rpcConnection.RegisterServiceMethodListener(6, 3, new RPCContextDelegate(BattleNetCSharp.HandleChannelSubscriber_NotifyRemove));
        s_rpcConnection.RegisterServiceMethodListener(6, 4, new RPCContextDelegate(BattleNetCSharp.HandleChannelSubscriber_NotifyLeave));
        s_rpcConnection.RegisterServiceMethodListener(6, 5, new RPCContextDelegate(BattleNetCSharp.HandleChannelSubscriber_NotifySendMessage));
        s_rpcConnection.RegisterServiceMethodListener(6, 6, new RPCContextDelegate(BattleNetCSharp.HandleChannelSubscriber_NotifyUpdateChannelState));
        s_rpcConnection.RegisterServiceMethodListener(6, 7, new RPCContextDelegate(BattleNetCSharp.HandleChannelSubscriber_NotifyUpdateMemberState));
    }

    public void MakeMatch(long deckId)
    {
        if (deckId != 0)
        {
            this.FindGame(BattleNet.BNetGameType.AMM_1V1, 2, deckId, 0L, false);
        }
        else if (s_gameRequest != 0)
        {
            this.CancelGame(s_gameRequest);
            s_gameRequest = 0L;
        }
    }

    public void ManageFriendInvite(int action, ulong inviteId)
    {
    }

    private static void MatchMakerEndHandler(bnet.protocol.notification.Notification notification)
    {
        Debug.Log("MM_END");
        int error = 0;
        IEnumerator<bnet.protocol.notification.Attribute> enumerator = notification.AttributeList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                bnet.protocol.notification.Attribute current = enumerator.Current;
                if (current.Name.Equals("error") && current.Value.HasIntValue)
                {
                    error = (int) current.Value.IntValue;
                }
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        if (error != 0)
        {
            AddQueueEvent(new BattleNet.QueueEvent(BattleNet.QueueEvent.Type.QUEUE_AMM_ERROR, error));
        }
    }

    private static void MatchMakerStartHandler(bnet.protocol.notification.Notification notification)
    {
        Debug.Log("MM_START");
        AddQueueEvent(new BattleNet.QueueEvent(BattleNet.QueueEvent.Type.QUEUE_ENTER));
    }

    public PegasusPacket NextUtilPacket()
    {
        if (s_utilPackets.Count > 0)
        {
            return s_utilPackets.Dequeue();
        }
        return null;
    }

    public int NumChallenges()
    {
        return 0;
    }

    public int PresenceSize()
    {
        return s_presenceUpdates.Count;
    }

    private static void PresenceSubscribe(bnet.protocol.EntityId entityId)
    {
        if (s_presenceSubscriptions.ContainsKey(entityId))
        {
            PresenceRefCountObject local1 = s_presenceSubscriptions[entityId];
            local1.refCount++;
        }
        else
        {
            bnet.protocol.presence.SubscribeRequest.Builder builder = bnet.protocol.presence.SubscribeRequest.CreateBuilder();
            s_nextObjectId += (ulong) 1L;
            builder.SetObjectId(s_nextObjectId);
            builder.SetEntityId(entityId);
            PresenceRefCountObject obj2 = new PresenceRefCountObject {
                objectId = builder.ObjectId,
                refCount = 1
            };
            s_presenceSubscriptions.Add(entityId, obj2);
            s_presenceObjectMapLink.Add(builder.ObjectId, entityId);
            s_rpcConnection.QueueRequest(4, 1, builder.BuildPartial(), new RPCContextDelegate(BattleNetCSharp.PresenceSubscribeCallback));
        }
    }

    private static void PresenceSubscribeCallback(RPCContext context)
    {
        uint status = context.Header.Status;
        if (status != 0)
        {
            Debug.LogError("PresenceSubscribeCallback: " + status);
        }
        else
        {
            Debug.Log("PresenceSubscribeCallback, status=" + status);
        }
    }

    private static void PresenceUnsubscribe(bnet.protocol.EntityId entityId)
    {
        if (s_presenceSubscriptions.ContainsKey(entityId))
        {
            PresenceRefCountObject local1 = s_presenceSubscriptions[entityId];
            local1.refCount--;
            if (s_presenceSubscriptions[entityId].refCount <= 0)
            {
                bnet.protocol.presence.UnsubscribeRequest.Builder builder = bnet.protocol.presence.UnsubscribeRequest.CreateBuilder();
                builder.SetEntityId(entityId);
                s_rpcConnection.QueueRequest(4, 2, builder.BuildPartial(), new RPCContextDelegate(BattleNetCSharp.PresenceUnsubscribeCallback));
                s_presenceObjectMapLink.Remove(s_presenceSubscriptions[entityId].objectId);
                s_presenceSubscriptions.Remove(entityId);
            }
        }
    }

    private static void PresenceUnsubscribeCallback(RPCContext context)
    {
        uint status = context.Header.Status;
        if (status != 0)
        {
            Debug.LogError("PresenceUnsubscribeCallback: " + status);
        }
        else
        {
            Debug.Log("PresenceUnsubscribeCallback, status=" + status);
        }
    }

    private static void PresenceUpdateCallback(RPCContext context)
    {
        uint status = context.Header.Status;
        if (status != 0)
        {
            Debug.LogError("PresenceUpdateCallback: " + status);
        }
        else
        {
            Debug.Log("PresenceUpdateCallback, status=" + status);
        }
    }

    private static void PrintBindServiceResponse(BindResponse response)
    {
        string str = "BindResponse: { ";
        int importedServiceIdCount = response.ImportedServiceIdCount;
        str = (str + "Num Imported Services: " + importedServiceIdCount) + " [";
        for (int i = 0; i < importedServiceIdCount; i++)
        {
            str = str + " Id:" + response.GetImportedServiceId(i);
        }
        Debug.Log(str + " ]" + " }");
    }

    private void PrintFindGameRequest(FindGameRequest request)
    {
        string str2;
        string str = "FindGameRequest: { ";
        int playerCount = request.PlayerCount;
        for (int i = 0; i < playerCount; i++)
        {
            bnet.protocol.game_master.Player player = request.GetPlayer(i);
            str = str + this.PrintPlayer(player);
        }
        if (request.HasFactoryId)
        {
            str2 = str;
            object[] objArray1 = new object[] { str2, "Factory Id: ", request.FactoryId, " " };
            str = string.Concat(objArray1);
        }
        if (request.HasProperties)
        {
            str = str + this.PrintGameProperties(request.Properties);
        }
        if (request.HasFactoryObjectId)
        {
            str2 = str;
            object[] objArray2 = new object[] { str2, "Factory Obj Id: ", request.FactoryObjectId, " " };
            str = string.Concat(objArray2);
        }
        if (request.HasRequestId)
        {
            str2 = str;
            object[] objArray3 = new object[] { str2, "Request Id: ", request.RequestId, " " };
            str = string.Concat(objArray3);
        }
        Debug.Log(str + "}");
    }

    private string PrintGameMasterAttributeFilter(bnet.protocol.game_master.AttributeFilter filter)
    {
        string str2;
        string str = "Attribute Filter: [";
        switch (filter.Op)
        {
            case bnet.protocol.game_master.AttributeFilter.Types.Operation.MATCH_NONE:
                str2 = "MATCH_NONE";
                break;

            case bnet.protocol.game_master.AttributeFilter.Types.Operation.MATCH_ANY:
                str2 = "MATCH_ANY";
                break;

            case bnet.protocol.game_master.AttributeFilter.Types.Operation.MATCH_ALL:
                str2 = "MATCH_ALL";
                break;

            case bnet.protocol.game_master.AttributeFilter.Types.Operation.MATCH_ALL_MOST_SPECIFIC:
                str2 = "MATCH_ALL_MOST_SPECIFIC";
                break;

            default:
                str2 = "UNKNOWN";
                break;
        }
        str = (str + "Operation: " + str2 + " ") + "Attributes: [";
        int attributeCount = filter.AttributeCount;
        for (int i = 0; i < attributeCount; i++)
        {
            bnet.protocol.game_master.Attribute attribute = filter.GetAttribute(i);
            string str3 = str;
            object[] objArray1 = new object[] { str3, "Name: ", attribute.Name, " Value: ", attribute.Value, " " };
            str = string.Concat(objArray1);
        }
        return (str + "] ");
    }

    private string PrintGameMasterIdentity(bnet.protocol.game_master.Identity identity)
    {
        string str2;
        string str = string.Empty + "Identity: [";
        if (identity.HasAccountId)
        {
            str2 = str;
            object[] objArray1 = new object[] { str2, "Acct Id: ", identity.AccountId.High, ":", identity.AccountId.Low, " " };
            str = string.Concat(objArray1);
        }
        if (identity.HasGameAccountId)
        {
            str2 = str;
            object[] objArray2 = new object[] { str2, "Game Acct Id: ", identity.GameAccountId.High, ":", identity.GameAccountId.Low, " " };
            str = string.Concat(objArray2);
        }
        return (str + "] ");
    }

    private string PrintGameProperties(GameProperties properties)
    {
        string str2;
        string str = string.Empty;
        str = "Game Properties: [";
        int creationAttributesCount = properties.CreationAttributesCount;
        str = str + "Creation Attribues: ";
        for (int i = 0; i < creationAttributesCount; i++)
        {
            bnet.protocol.game_master.Attribute creationAttributes = properties.GetCreationAttributes(i);
            str2 = str;
            object[] objArray1 = new object[] { str2, "[Name: ", creationAttributes.Name, " Value: ", creationAttributes.Value, "] " };
            str = string.Concat(objArray1);
        }
        if (properties.HasFilter)
        {
            this.PrintGameMasterAttributeFilter(properties.Filter);
        }
        if (properties.HasCreate)
        {
            str2 = str;
            object[] objArray2 = new object[] { str2, "Create New Game?: ", properties.Create, " " };
            str = string.Concat(objArray2);
        }
        if (properties.HasOpen)
        {
            str2 = str;
            object[] objArray3 = new object[] { str2, "Game Is Open?: ", properties.Open, " " };
            str = string.Concat(objArray3);
        }
        if (properties.HasProgramId)
        {
            str = str + "Program Id(4CC): " + properties.ProgramId;
        }
        return str;
    }

    private string PrintPlayer(bnet.protocol.game_master.Player player)
    {
        string str = string.Empty + "Player: [";
        if (player.HasIdentity)
        {
            this.PrintGameMasterIdentity(player.Identity);
        }
        int attributeCount = player.AttributeCount;
        str = str + "Attributes: ";
        for (int i = 0; i < attributeCount; i++)
        {
            bnet.protocol.game_master.Attribute attribute = player.GetAttribute(i);
            string str2 = str;
            object[] objArray1 = new object[] { str2, "[Name: ", attribute.Name, " Value: ", attribute.Value, "] " };
            str = string.Concat(objArray1);
        }
        return (str + "] ");
    }

    public void ProcessAurora()
    {
        if ((s_connectionState != ConnectionState.Disconnected) && (s_connectionState != ConnectionState.Error))
        {
            AuroraStateHandler handler;
            if (s_rpcConnection != null)
            {
                s_rpcConnection.Update();
            }
            if (s_stateHandlers.TryGetValue(s_connectionState, out handler))
            {
                handler();
            }
            else
            {
                Debug.LogError("Missing state handler");
            }
        }
    }

    private static void PublishField(UpdateRequest updateRequest)
    {
        s_rpcConnection.QueueRequest(4, 3, updateRequest, new RPCContextDelegate(BattleNetCSharp.PresenceUpdateCallback));
    }

    public void QueryAurora()
    {
    }

    public void RemoveFriend(ref BattleNet.DllEntityId account)
    {
    }

    public void RescindPartyInvite(ref BattleNet.DllEntityId partyId)
    {
    }

    public void SendFriendInvite(IntPtr inviter, IntPtr invitee, bool byEmail)
    {
    }

    public void SendPartyInvite(ref BattleNet.DllEntityId gameAccount)
    {
    }

    public void SendUtilPacket(int packetId, int systemId, byte[] bytes, int size, int subID)
    {
        ClientRequest message = CreateClientRequest(packetId, systemId, bytes);
        s_rpcConnection.QueueRequest(9, 1, message, new RPCContextDelegate(BattleNetCSharp.ClientRequestCallback));
    }

    public void SendWhisper(ref BattleNet.DllEntityId gameAccount, IntPtr message)
    {
    }

    public void SetPartyDeck(ref BattleNet.DllEntityId partyId, long deckID)
    {
    }

    public void SetPresenceBool(int field, bool val)
    {
        UpdateRequest.Builder builder = UpdateRequest.CreateBuilder();
        FieldOperation.Builder builderForValue = FieldOperation.CreateBuilder();
        Field.Builder builder3 = Field.CreateBuilder();
        FieldKey.Builder builder4 = FieldKey.CreateBuilder();
        builder4.SetProgram(BnetProgramId.HEARTHSTONE.GetValue());
        builder4.SetGroup(2);
        builder4.SetField((uint) field);
        bnet.protocol.attribute.Variant.Builder builder5 = bnet.protocol.attribute.Variant.CreateBuilder();
        builder5.SetBoolValue(val);
        builder3.SetKey(builder4);
        builder3.SetValue(builder5);
        builderForValue.SetField(builder3);
        builder.SetEntityId(s_gameAccount);
        builder.AddFieldOperation(builderForValue);
        PublishField(builder.BuildPartial());
    }

    public void SetPresenceInt(int field, long val)
    {
        UpdateRequest.Builder builder = UpdateRequest.CreateBuilder();
        builder.EntityId = s_gameAccount;
        FieldOperation.Builder builderForValue = FieldOperation.CreateBuilder();
        Field.Builder builder3 = Field.CreateBuilder();
        FieldKey.Builder builder4 = FieldKey.CreateBuilder();
        builder4.SetProgram(BnetProgramId.HEARTHSTONE.GetValue());
        builder4.SetGroup(2);
        builder4.SetField((uint) field);
        bnet.protocol.attribute.Variant.Builder builder5 = bnet.protocol.attribute.Variant.CreateBuilder();
        builder5.SetIntValue(val);
        builder3.SetKey(builder4);
        builder3.SetValue(builder5);
        builderForValue.SetField(builder3);
        builder.SetEntityId(s_gameAccount);
        builder.AddFieldOperation(builderForValue);
        PublishField(builder.BuildPartial());
    }

    public void StartScenario(int scenario, long deckId)
    {
        BattleNet.BNetGameType tUTORIAL;
        switch (scenario)
        {
            case 3:
            case 4:
            case 0xf8:
            case 0xf9:
            case 0xb5:
            case 0xc9:
                tUTORIAL = BattleNet.BNetGameType.TUTORIAL;
                break;

            case 2:
                Debug.LogError("StartScenario called for invalid scenario" + scenario);
                return;

            default:
                tUTORIAL = BattleNet.BNetGameType.VS_AI;
                break;
        }
        this.FindGame(tUTORIAL, scenario, deckId, 0L, true);
    }

    public void StartScenarioAI(int scenario, long deckId, long aiDeckId)
    {
        if (scenario != 1)
        {
            Debug.LogError("StartScenarioAI called for invalid scenario " + scenario);
        }
        this.FindGame(BattleNet.BNetGameType.VS_AI, scenario, deckId, aiDeckId, true);
    }

    public void UnrankedMatch(long deckId)
    {
        if (deckId != 0)
        {
            this.FindGame(BattleNet.BNetGameType.AMM_1V1, 2, deckId, 0L, true);
        }
        else
        {
            this.CancelGame(s_gameRequest);
            s_gameRequest = 0L;
        }
    }

    public delegate void AuroraStateHandler();

    private enum ConnectionState
    {
        Disconnected,
        Connect,
        InitRPC,
        WaitForInitRPC,
        Bind,
        WaitForBind,
        Logon,
        WaitForLogon,
        SelectGameAccount,
        WaitForSelectGameAccount,
        Ready,
        Error
    }

    private delegate void NotificationHandler(bnet.protocol.notification.Notification notification);

    public class PresenceRefCountObject
    {
        public ulong objectId;
        public int refCount;
    }
}


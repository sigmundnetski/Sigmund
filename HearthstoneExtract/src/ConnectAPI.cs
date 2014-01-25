using BobNetProto;
using Google.ProtocolBuffers;
using PegasusGame;
using PegasusShared;
using PegasusUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class ConnectAPI : IConnectionListener<PegasusPacket>
{
    public const int ACTION_END = 6;
    public const int ACTION_START = 5;
    public const int CREATE_GAME = 7;
    private static int DEBUG_CLIENT_TCP_PORT = 0x4ca;
    private static int DEBUG_CLIENT_UDP_PORT = 0x4c8;
    public const int FULL_ENTITY = 1;
    public const int HIDE_ENTITY = 3;
    private static PegasusUtil.AckCardSeen.Builder m_ackCardSeenPacket = PegasusUtil.AckCardSeen.CreateBuilder();
    private static ClientTracking.Builder m_trackingPacket = ClientTracking.CreateBuilder();
    private const int MAX_SERVERS = 3;
    public const int META_DATA = 8;
    private static BobNetProto.AutoLogin.Builder s_autoLogin;
    private static Queue<PegasusPacket> s_bobnetPackets = new Queue<PegasusPacket>();
    private static ConnectAPI s_connectAPI;
    private static ClientConnection<PegasusPacket> s_debugConsole;
    private static DebugConsoleBroadcaster s_debugConsoleBroadcaster;
    private static ServerConnection<PegasusPacket> s_debugListener;
    private static Queue<PegasusPacket> s_debugPackets = new Queue<PegasusPacket>();
    private static Queue<PegasusPacket> s_gamePackets = new Queue<PegasusPacket>();
    private static ClientConnection<PegasusPacket> s_gameServer;
    private static bool s_initialized = false;
    private static int s_lastFrameQueueSize = 0;
    private static int s_messageBlockedCount = 0;
    private static SortedDictionary<int, PacketDecoder> s_packetDecoders = new SortedDictionary<int, PacketDecoder>();
    private static Queue<QueuedPacket> s_queuedPackets = new Queue<QueuedPacket>();
    private static Queue<PegasusPacket> s_utilPackets = new Queue<PegasusPacket>();
    public const int SHOW_ENTITY = 2;
    public const int TAG_CHANGE = 4;
    private static string UDP_BROADCAST_PREFIX = "B2RC:";
    public const int UNKNOWN_HISTORY = 0;

    public static void AbortPurchase(bool isAutoCanceled)
    {
        CancelPurchase.Builder body = CancelPurchase.CreateBuilder();
        body.SetIsAutoCancel(isAutoCanceled);
        UtilOutbound(0x112, 1, body, 0);
    }

    public static void AckAchieveProgress(int ID, int ackProgress)
    {
        PegasusUtil.AckAchieveProgress.Builder body = PegasusUtil.AckAchieveProgress.CreateBuilder();
        body.SetId(ID);
        body.SetAckProgress(ackProgress);
        UtilOutbound(0xf3, 0, body, 0);
    }

    public static void AckCardSeen(int assetID, int premium)
    {
        PegasusShared.CardDef.Builder builderForValue = PegasusShared.CardDef.CreateBuilder();
        builderForValue.SetAsset(assetID);
        if (premium != 0)
        {
            builderForValue.SetPremium(premium);
        }
        m_ackCardSeenPacket.AddCardDefs(builderForValue);
        if (m_ackCardSeenPacket.CardDefsCount > 10)
        {
            UtilOutbound(0xdf, 0, m_ackCardSeenPacket, 0);
            m_ackCardSeenPacket.ClearCardDefs();
        }
    }

    public static void AckNotice(long ID)
    {
        PegasusUtil.AckNotice.Builder body = PegasusUtil.AckNotice.CreateBuilder();
        body.SetEntry(ID);
        UtilOutbound(0xd5, 0, body, 0);
    }

    private static void AutoLogin()
    {
    }

    public static bool AutoLogin(string name, int buildId)
    {
        s_debugConsoleBroadcaster.BeginListening(DEBUG_CLIENT_UDP_PORT, UDP_BROADCAST_PREFIX + name);
        return false;
    }

    public static bool BobNetReady()
    {
        return (s_bobnetPackets.Count > 0);
    }

    public static void BuyCard(int id, int premium)
    {
        BuySellCard.Builder body = BuySellCard.CreateBuilder();
        PegasusShared.CardDef.Builder builderForValue = PegasusShared.CardDef.CreateBuilder();
        builderForValue.SetAsset(id);
        if (premium != 0)
        {
            builderForValue.SetPremium(premium);
        }
        body.SetDef(builderForValue);
        body.SetBuying(true);
        UtilOutbound(0x101, 0, body, 0);
    }

    private static bool CheckType(PegasusPacket p, int packetId)
    {
        bool flag = (p == null) || (p.Type != packetId);
        if (flag)
        {
            UnityEngine.Debug.LogError("ERROR: invalid type " + p);
        }
        return !flag;
    }

    public static void CloseAll()
    {
        UtilOutbound(0xe4, 0, m_trackingPacket, 0);
        m_trackingPacket.ClearInfo();
        UtilOutbound(0xdf, 0, m_ackCardSeenPacket, 0);
        m_ackCardSeenPacket.ClearCardDefs();
        if (s_gameServer != null)
        {
            s_gameServer.Disconnect();
        }
        if (s_debugConsoleBroadcaster != null)
        {
            s_debugConsoleBroadcaster.StopListening();
        }
        if (s_debugConsole != null)
        {
            s_debugConsole.Disconnect();
        }
        if (s_debugListener != null)
        {
            s_debugListener.Disconnect();
        }
    }

    public static void CloseCardMarket()
    {
        PegasusUtil.CloseCardMarket.Builder body = PegasusUtil.CloseCardMarket.CreateBuilder();
        UtilOutbound(0x107, 0, body, 0);
    }

    public static void ConfirmPurchase()
    {
        DoPurchase.Builder body = DoPurchase.CreateBuilder();
        UtilOutbound(0x111, 1, body, 0);
    }

    public static bool ConnectDebugConsole()
    {
        if ((s_debugConsole == null) || !s_debugConsole.Active)
        {
            ClientConnection<PegasusPacket> nextAcceptedConnection = s_debugListener.GetNextAcceptedConnection();
            if (nextAcceptedConnection == null)
            {
                return false;
            }
            s_debugConsole = nextAcceptedConnection;
            nextAcceptedConnection.AddListener(s_connectAPI, s_debugPackets);
            nextAcceptedConnection.StartReceiving();
        }
        return true;
    }

    public static bool ConnectInit()
    {
        if (!s_initialized)
        {
            s_connectAPI = new ConnectAPI();
            s_gameServer = new ClientConnection<PegasusPacket>();
            s_gameServer.AddListener(s_connectAPI, s_gamePackets);
            s_debugConsoleBroadcaster = new DebugConsoleBroadcaster();
            s_debugListener = new ServerConnection<PegasusPacket>();
            s_debugListener.Open(DEBUG_CLIENT_TCP_PORT);
            s_packetDecoders.Add(0x6b, new DefaultProtobufPacketDecoder<BobNetProto.GameInfo, BobNetProto.GameInfo.Builder>());
            s_packetDecoders.Add(0x72, new DefaultProtobufPacketDecoder<GameStarting, GameStarting.Builder>());
            s_packetDecoders.Add(0x6d, new DefaultProtobufPacketDecoder<GotoServer, GotoServer.Builder>());
            s_packetDecoders.Add(0x7e, new DefaultProtobufPacketDecoder<Message, Message.Builder>());
            s_packetDecoders.Add(0x6c, new DefaultProtobufPacketDecoder<RemoveHostedGame, RemoveHostedGame.Builder>());
            s_packetDecoders.Add(0x9d, new DeprecatedPacketDecoder());
            s_packetDecoders.Add(0x9f, new DeprecatedPacketDecoder());
            s_packetDecoders.Add(0xa1, new DefaultProtobufPacketDecoder<QueueStatus, QueueStatus.Builder>());
            s_packetDecoders.Add(0xa3, new DeprecatedPacketDecoder());
            s_packetDecoders.Add(170, new DefaultProtobufPacketDecoder<Disconnected, Disconnected.Builder>());
            s_packetDecoders.Add(14, new DefaultProtobufPacketDecoder<AllOptions, AllOptions.Builder>());
            s_packetDecoders.Add(5, new DefaultProtobufPacketDecoder<DebugMessage, DebugMessage.Builder>());
            s_packetDecoders.Add(0x11, new DefaultProtobufPacketDecoder<EntityChoice, EntityChoice.Builder>());
            s_packetDecoders.Add(8, new DefaultProtobufPacketDecoder<FinishGameState, FinishGameState.Builder>());
            s_packetDecoders.Add(0x10, new DefaultProtobufPacketDecoder<PegasusGame.GameSetup, PegasusGame.GameSetup.Builder>());
            s_packetDecoders.Add(0x15, new DefaultProtobufPacketDecoder<PegasusGame.Notification, PegasusGame.Notification.Builder>());
            s_packetDecoders.Add(0x13, new DefaultProtobufPacketDecoder<PegasusGame.PowerHistory, PegasusGame.PowerHistory.Builder>());
            s_packetDecoders.Add(0x12, new DefaultProtobufPacketDecoder<PreLoad, PreLoad.Builder>());
            s_packetDecoders.Add(7, new DefaultProtobufPacketDecoder<StartGameState, StartGameState.Builder>());
            s_packetDecoders.Add(15, new DefaultProtobufPacketDecoder<PegasusGame.UserUI, PegasusGame.UserUI.Builder>());
            s_packetDecoders.Add(9, new DefaultProtobufPacketDecoder<PegasusGame.TurnTimer, PegasusGame.TurnTimer.Builder>());
            s_packetDecoders.Add(10, new DefaultProtobufPacketDecoder<NAckOption, NAckOption.Builder>());
            s_packetDecoders.Add(12, new DefaultProtobufPacketDecoder<GameCanceled, GameCanceled.Builder>());
            s_packetDecoders.Add(0xca, new DefaultProtobufPacketDecoder<DeckList, DeckList.Builder>());
            s_packetDecoders.Add(0xcf, new DefaultProtobufPacketDecoder<Collection, Collection.Builder>());
            s_packetDecoders.Add(0xd7, new DefaultProtobufPacketDecoder<PegasusUtil.DeckContents, PegasusUtil.DeckContents.Builder>());
            s_packetDecoders.Add(0xd8, new DefaultProtobufPacketDecoder<PegasusUtil.DBAction, PegasusUtil.DBAction.Builder>());
            s_packetDecoders.Add(0xd9, new DefaultProtobufPacketDecoder<PegasusUtil.DeckCreated, PegasusUtil.DeckCreated.Builder>());
            s_packetDecoders.Add(0xda, new DefaultProtobufPacketDecoder<PegasusUtil.DeckDeleted, PegasusUtil.DeckDeleted.Builder>());
            s_packetDecoders.Add(0xdb, new DefaultProtobufPacketDecoder<PegasusUtil.DeckRenamed, PegasusUtil.DeckRenamed.Builder>());
            s_packetDecoders.Add(0xd4, new DefaultProtobufPacketDecoder<PegasusUtil.ProfileNotices, PegasusUtil.ProfileNotices.Builder>());
            s_packetDecoders.Add(0xe0, new DefaultProtobufPacketDecoder<BoosterList, BoosterList.Builder>());
            s_packetDecoders.Add(0xe2, new DefaultProtobufPacketDecoder<BoosterContent, BoosterContent.Builder>());
            s_packetDecoders.Add(0xe3, new DefaultProtobufPacketDecoder<ProfileLastLogin, ProfileLastLogin.Builder>());
            s_packetDecoders.Add(0xd0, new DefaultProtobufPacketDecoder<GamesInfo, GamesInfo.Builder>());
            s_packetDecoders.Add(0xe7, new DefaultProtobufPacketDecoder<ProfileDeckLimit, ProfileDeckLimit.Builder>());
            s_packetDecoders.Add(0x106, new DefaultProtobufPacketDecoder<ArcaneDustBalance, ArcaneDustBalance.Builder>());
            s_packetDecoders.Add(0x116, new DefaultProtobufPacketDecoder<GoldBalance, GoldBalance.Builder>());
            s_packetDecoders.Add(0xe9, new DefaultProtobufPacketDecoder<ProfileProgress, ProfileProgress.Builder>());
            s_packetDecoders.Add(270, new DefaultProtobufPacketDecoder<PlayerRecords, PlayerRecords.Builder>());
            s_packetDecoders.Add(0x10f, new DefaultProtobufPacketDecoder<RewardProgress, RewardProgress.Builder>());
            s_packetDecoders.Add(0xe8, new DefaultProtobufPacketDecoder<MedalInfo, MedalInfo.Builder>());
            s_packetDecoders.Add(0xea, new DefaultProtobufPacketDecoder<PegasusUtil.MedalHistory, PegasusUtil.MedalHistory.Builder>());
            s_packetDecoders.Add(0xec, new DefaultProtobufPacketDecoder<CardUsage, CardUsage.Builder>());
            s_packetDecoders.Add(0xf1, new DefaultProtobufPacketDecoder<ClientOptions, ClientOptions.Builder>());
            s_packetDecoders.Add(0xf6, new DefaultProtobufPacketDecoder<DraftBeginning, DraftBeginning.Builder>());
            s_packetDecoders.Add(0xf7, new DefaultProtobufPacketDecoder<DraftRetired, DraftRetired.Builder>());
            s_packetDecoders.Add(0xf8, new DefaultProtobufPacketDecoder<PegasusUtil.DraftChoicesAndContents, PegasusUtil.DraftChoicesAndContents.Builder>());
            s_packetDecoders.Add(0xf9, new DefaultProtobufPacketDecoder<PegasusUtil.DraftChosen, PegasusUtil.DraftChosen.Builder>());
            s_packetDecoders.Add(0xfb, new DefaultProtobufPacketDecoder<PegasusUtil.DraftError, PegasusUtil.DraftError.Builder>());
            s_packetDecoders.Add(0xfc, new DefaultProtobufPacketDecoder<Achieves, Achieves.Builder>());
            s_packetDecoders.Add(0x11d, new DefaultProtobufPacketDecoder<ValidateAchieveResponse, ValidateAchieveResponse.Builder>());
            s_packetDecoders.Add(0x11a, new DefaultProtobufPacketDecoder<CancelQuestResponse, CancelQuestResponse.Builder>());
            s_packetDecoders.Add(0x108, new DefaultProtobufPacketDecoder<GuardianVars, GuardianVars.Builder>());
            s_packetDecoders.Add(260, new DefaultProtobufPacketDecoder<CardValues, CardValues.Builder>());
            s_packetDecoders.Add(0x102, new DefaultProtobufPacketDecoder<BoughtSoldCard, BoughtSoldCard.Builder>());
            s_packetDecoders.Add(0x10d, new DefaultProtobufPacketDecoder<PegasusUtil.MassDisenchantResponse, PegasusUtil.MassDisenchantResponse.Builder>());
            s_packetDecoders.Add(0x109, new DefaultProtobufPacketDecoder<BattlePayStatusResponse, BattlePayStatusResponse.Builder>());
            s_packetDecoders.Add(0x110, new DefaultProtobufPacketDecoder<PegasusUtil.PurchaseMethod, PegasusUtil.PurchaseMethod.Builder>());
            s_packetDecoders.Add(0x113, new DefaultProtobufPacketDecoder<CancelPurchaseResponse, CancelPurchaseResponse.Builder>());
            s_packetDecoders.Add(0x100, new DefaultProtobufPacketDecoder<PegasusUtil.PurchaseResponse, PegasusUtil.PurchaseResponse.Builder>());
            s_packetDecoders.Add(0xee, new DefaultProtobufPacketDecoder<BattlePayConfigResponse, BattlePayConfigResponse.Builder>());
            s_packetDecoders.Add(280, new DefaultProtobufPacketDecoder<PurchaseWithGoldResponse, PurchaseWithGoldResponse.Builder>());
            s_packetDecoders.Add(0x11b, new DefaultProtobufPacketDecoder<HeroXP, HeroXP.Builder>());
            s_packetDecoders.Add(0xfe, new NoOpPacketDecoder());
            s_packetDecoders.Add(0x7b, new DefaultProtobufPacketDecoder<DebugConsoleCommand, DebugConsoleCommand.Builder>());
            s_packetDecoders.Add(0x7c, new DefaultProtobufPacketDecoder<BobNetProto.DebugConsoleResponse, BobNetProto.DebugConsoleResponse.Builder>());
            s_initialized = true;
        }
        return true;
    }

    public static bool ConnectsWithAurora()
    {
        return true;
    }

    public static bool ConnectsWithBobnet()
    {
        return false;
    }

    private static Network.PurchaseErrorInfo ConvertPurchaseError(PurchaseError purchaseError)
    {
        Network.PurchaseErrorInfo info = new Network.PurchaseErrorInfo {
            Error = (Network.PurchaseErrorInfo.ErrorType) purchaseError.Error
        };
        if (purchaseError.HasPurchaseInProgress)
        {
            info.BundlePurchaseInProgress = purchaseError.PurchaseInProgress;
        }
        if (purchaseError.HasErrorCode)
        {
            info.ErrorCode = purchaseError.ErrorCode;
        }
        return info;
    }

    private static List<int> CopyIntList(IList<int> intList)
    {
        int[] array = new int[intList.Count];
        intList.CopyTo(array, 0);
        return new List<int>(array);
    }

    public static void CreateDeck(string name, int hero)
    {
        PegasusUtil.CreateDeck.Builder body = PegasusUtil.CreateDeck.CreateBuilder();
        body.SetName(name);
        body.SetHero(hero);
        UtilOutbound(0xd1, 0, body, 0);
    }

    public static long DateToUTC(Date date)
    {
        DateTime time = new DateTime(date.Year, date.Month, date.Day, date.Hours, date.Min, date.Sec);
        return time.ToFileTimeUtc();
    }

    public static Network.DBAction DBAction()
    {
        PegasusUtil.DBAction action = Unpack<PegasusUtil.DBAction>(NextUtil(), 0xd8);
        if (action == null)
        {
            return null;
        }
        Network.DBAction action2 = new Network.DBAction {
            Action = (Network.DBAction.ActionType) action.Action,
            Result = (Network.DBAction.ResultType) action.Result,
            MetaData = action.MetaData
        };
        DropUtilPacket();
        return action2;
    }

    public static bool DebugConsoleReady()
    {
        return (s_debugPackets.Count > 0);
    }

    public static NetCache.DeckHeader DeckCreated()
    {
        PegasusUtil.DeckCreated created = Unpack<PegasusUtil.DeckCreated>(NextUtil(), 0xd9);
        if (created == null)
        {
            return null;
        }
        DeckInfo info = created.Info;
        NetCache.DeckHeader header = new NetCache.DeckHeader {
            ID = info.Id,
            Name = info.Name,
            Hero = Network.GetHeroCard(info.Hero),
            HeroPower = Network.GetHeroPower(info.Hero),
            Type = (NetCache.DeckHeader.DeckType) info.DeckType
        };
        DropUtilPacket();
        return header;
    }

    public static long DeckDeleted()
    {
        PegasusUtil.DeckDeleted deleted = Unpack<PegasusUtil.DeckDeleted>(NextUtil(), 0xda);
        if (deleted == null)
        {
            return 0L;
        }
        DropUtilPacket();
        return deleted.Deck;
    }

    public static Network.DeckName DeckRenamed()
    {
        PegasusUtil.DeckRenamed renamed = Unpack<PegasusUtil.DeckRenamed>(NextUtil(), 0xdb);
        if (renamed == null)
        {
            return null;
        }
        Network.DeckName name = new Network.DeckName {
            Deck = renamed.Deck,
            Name = renamed.Name
        };
        DropUtilPacket();
        return name;
    }

    public static void DeleteClientOption(int key)
    {
        SetOptions.Builder body = SetOptions.CreateBuilder();
        PegasusUtil.ClientOption.Builder builderForValue = PegasusUtil.ClientOption.CreateBuilder();
        builderForValue.SetIndex(key);
        body.AddOptions(builderForValue);
        UtilOutbound(0xef, 0, body, 0);
    }

    public static void DeleteDeck(long deckID)
    {
        PegasusUtil.DeleteDeck.Builder body = PegasusUtil.DeleteDeck.CreateBuilder();
        body.SetDeck(deckID);
        UtilOutbound(210, 0, body, 0);
    }

    public static void DraftBegin()
    {
        PegasusUtil.DraftBegin.Builder body = new PegasusUtil.DraftBegin.Builder();
        UtilOutbound(0xeb, 0, body, 0);
    }

    public static Network.DraftChosen DraftCardChosen()
    {
        PegasusUtil.DraftChosen chosen = Unpack<PegasusUtil.DraftChosen>(NextUtil(), 0xf9);
        if (chosen == null)
        {
            return null;
        }
        Network.DraftChosen chosen2 = new Network.DraftChosen {
            AssetID = chosen.Asset
        };
        IEnumerator<int> enumerator = chosen.NextChoicesList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                int current = enumerator.Current;
                chosen2.NextChoices.Add(current);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return chosen2;
    }

    public static Network.BeginDraft DraftGetBeginning()
    {
        DraftBeginning beginning = Unpack<DraftBeginning>(NextUtil(), 0xf6);
        if (beginning == null)
        {
            return null;
        }
        Network.BeginDraft draft = new Network.BeginDraft {
            DeckID = beginning.DeckId
        };
        IEnumerator<int> enumerator = beginning.ChoicesList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                int current = enumerator.Current;
                draft.Heroes.Add(current);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return draft;
    }

    public static Network.DraftChoicesAndContents DraftGetChoicesAndContents()
    {
        PegasusUtil.DraftChoicesAndContents contents = Unpack<PegasusUtil.DraftChoicesAndContents>(NextUtil(), 0xf8);
        if (contents == null)
        {
            return null;
        }
        Network.DraftChoicesAndContents contents2 = new Network.DraftChoicesAndContents {
            DeckInfo = { Deck = contents.DeckId },
            Slot = contents.Slot,
            HeroAssetID = contents.Hero,
            Wins = contents.Wins,
            Losses = contents.Losses
        };
        IEnumerator<int> enumerator = contents.ChoicesList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                int current = enumerator.Current;
                if (current != 0)
                {
                    contents2.Choices.Add(current);
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
        IEnumerator<DeckCardData> enumerator2 = contents.CardsList.GetEnumerator();
        try
        {
            while (enumerator2.MoveNext())
            {
                DeckCardData data = enumerator2.Current;
                Network.CardUserData item = new Network.CardUserData {
                    AssetID = data.Def.Asset,
                    Handle = data.Handle,
                    Prev = data.Prev,
                    Count = 1,
                    Premium = !data.Def.HasPremium ? CardFlair.PremiumType.STANDARD : ((CardFlair.PremiumType) data.Def.Premium)
                };
                contents2.DeckInfo.Cards.Add(item);
            }
        }
        finally
        {
            if (enumerator2 == null)
            {
            }
            enumerator2.Dispose();
        }
        DropUtilPacket();
        return contents2;
    }

    public static int DraftGetError()
    {
        PegasusUtil.DraftError error = Unpack<PegasusUtil.DraftError>(NextUtil(), 0xfb);
        if (error == null)
        {
            return 0;
        }
        PegasusUtil.DraftError.Types.ErrorCode errorCode = error.ErrorCode;
        DropUtilPacket();
        return (int) errorCode;
    }

    public static void DraftGetPicksAndContents()
    {
        PegasusUtil.DraftGetPicksAndContents.Builder body = PegasusUtil.DraftGetPicksAndContents.CreateBuilder();
        UtilOutbound(0xf4, 0, body, 0);
    }

    public static long DraftHandleRetired()
    {
        DraftRetired retired = Unpack<DraftRetired>(NextUtil(), 0xf7);
        if (retired == null)
        {
            return 0L;
        }
        long deckId = retired.DeckId;
        DropUtilPacket();
        return deckId;
    }

    public static void DraftMakePick(long deckID, int slot, int index)
    {
        PegasusUtil.DraftMakePick.Builder body = new PegasusUtil.DraftMakePick.Builder();
        body.SetDeckId(deckID);
        body.SetSlot(slot);
        body.SetIndex(index);
        UtilOutbound(0xf5, 0, body, 0);
    }

    public static void DraftRetire(long deckID, int slot)
    {
        PegasusUtil.DraftRetire.Builder body = new PegasusUtil.DraftRetire.Builder();
        body.SetDeckId(deckID);
        body.SetSlot(slot);
        UtilOutbound(0xf2, 0, body, 0);
    }

    public static void DropBobNetPacket()
    {
        DropPacket(ServerType.BOBNET);
    }

    public static void DropDebugPacket()
    {
        DropPacket(ServerType.DEBUG_CONSOLE);
    }

    public static void DropGamePacket()
    {
        DropPacket(ServerType.GAME_SERVER);
    }

    public static void DropPacket(ServerType type)
    {
        Queue<PegasusPacket> queue = null;
        switch (type)
        {
            case ServerType.BOBNET:
                queue = s_bobnetPackets;
                break;

            case ServerType.GAME_SERVER:
                queue = s_gamePackets;
                break;

            case ServerType.UTIL_SERVER:
                queue = s_utilPackets;
                break;

            case ServerType.DEBUG_CONSOLE:
                queue = s_debugPackets;
                break;
        }
        if ((queue != null) && (queue.Count > 0))
        {
            queue.Dequeue();
        }
    }

    public static void DropPacket(int list)
    {
        Queue<PegasusPacket> queue = null;
        switch (list)
        {
            case 1:
                queue = s_bobnetPackets;
                break;

            case 2:
                queue = s_gamePackets;
                break;

            case 3:
                queue = s_utilPackets;
                break;
        }
        if ((queue != null) && (queue.Count > 0))
        {
            queue.Dequeue();
        }
        else
        {
            UnityEngine.Debug.LogWarning("packet was empty!");
        }
    }

    public static void DropUtilPacket()
    {
        DropPacket(ServerType.UTIL_SERVER);
    }

    public static void EnableGameListings(int state)
    {
    }

    public static void EndGame()
    {
        s_gameServer.Disconnect();
    }

    public static bool GameServerActive()
    {
        return s_gameServer.Active;
    }

    public static bool GameServerReady()
    {
        return (s_gamePackets.Count > 0);
    }

    public static Network.AchieveList GetAchieves()
    {
        Achieves achieves = Unpack<Achieves>(NextUtil(), 0xfc);
        if (achieves == null)
        {
            return null;
        }
        Network.AchieveList list = new Network.AchieveList();
        IEnumerator<PegasusUtil.Achieve> enumerator = achieves.ListList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                PegasusUtil.Achieve current = enumerator.Current;
                Network.AchieveList.Achieve item = new Network.AchieveList.Achieve {
                    ID = current.Id,
                    Progress = current.Progress,
                    AckProgress = current.AckProgress,
                    CompletionCount = !current.HasCompletionCount ? 0 : current.CompletionCount,
                    Active = current.HasActive && current.Active,
                    DateGiven = !current.HasDateGiven ? 0L : DateToUTC(current.DateGiven),
                    DateCompleted = !current.HasDateCompleted ? 0L : DateToUTC(current.DateCompleted),
                    CanAck = !current.HasDoNotAck || !current.DoNotAck
                };
                list.Achieves.Add(item);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return list;
    }

    public static void GetAllClientOptions()
    {
        PegasusUtil.GetOptions.Builder body = PegasusUtil.GetOptions.CreateBuilder();
        UtilOutbound(240, 0, body, 0);
    }

    public static NetCache.NetCacheHeroLevels GetAllHeroXP()
    {
        HeroXP oxp = Unpack<HeroXP>(NextUtil(), 0x11b);
        if (oxp == null)
        {
            return null;
        }
        NetCache.NetCacheHeroLevels levels = new NetCache.NetCacheHeroLevels();
        IEnumerator<HeroXPInfo> enumerator = oxp.XpInfosList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                HeroXPInfo current = enumerator.Current;
                NetCache.HeroLevel item = new NetCache.HeroLevel {
                    Class = (TAG_CLASS) current.ClassId
                };
                item.CurrentLevel.Level = current.Level;
                item.CurrentLevel.XP = current.CurrXp;
                item.CurrentLevel.MaxXP = current.MaxXp;
                levels.Levels.Add(item);
                if (current.HasNextReward)
                {
                    item.NextReward = new NetCache.HeroLevel.NextLevelReward();
                    item.NextReward.Level = current.NextReward.Level;
                    if (current.NextReward.HasRewardBooster)
                    {
                        BoosterType boosterType = (BoosterType) current.NextReward.RewardBooster.BoosterType;
                        item.NextReward.Reward = new BoosterPackRewardData(boosterType, current.NextReward.RewardBooster.BoosterCount);
                    }
                    else
                    {
                        if (current.NextReward.HasRewardCard)
                        {
                            int num;
                            string cardID = CardManifest.Get().Find(current.NextReward.RewardCard.Card.Asset).CardID;
                            CardFlair.PremiumType premium = !current.NextReward.RewardCard.Card.HasPremium ? CardFlair.PremiumType.STANDARD : ((CardFlair.PremiumType) current.NextReward.RewardCard.Card.Premium);
                            EntityDef entityDef = DefLoader.Get().GetEntityDef(cardID);
                            if (entityDef.IsHero())
                            {
                                num = 1;
                            }
                            else if (premium == CardFlair.PremiumType.STANDARD)
                            {
                                num = !entityDef.IsElite() ? 2 : 1;
                            }
                            else
                            {
                                num = 1;
                            }
                            item.NextReward.Reward = new CardRewardData(cardID, premium, num);
                            continue;
                        }
                        if (current.NextReward.HasRewardDust)
                        {
                            item.NextReward.Reward = new ArcaneDustRewardData(current.NextReward.RewardDust.Amount);
                        }
                        else
                        {
                            if (current.NextReward.HasRewardGold)
                            {
                                item.NextReward.Reward = new GoldRewardData((long) current.NextReward.RewardGold.Amount);
                                continue;
                            }
                            if (current.NextReward.HasRewardMount)
                            {
                                item.NextReward.Reward = new MountRewardData((MountRewardData.MountType) current.NextReward.RewardMount.MountId);
                                continue;
                            }
                            if (current.NextReward.HasRewardForge)
                            {
                                item.NextReward.Reward = new ForgeTicketRewardData(current.NextReward.RewardForge.Quantity);
                                continue;
                            }
                            UnityEngine.Debug.LogWarning(string.Format("ConnectAPI.GetAllHeroXP(): next reward for hero {0} is at level {1} but has no recognized reward type in packet", item.Class, item.NextReward.Level));
                        }
                    }
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
        DropUtilPacket();
        return levels;
    }

    public static long GetArcaneDustBalance()
    {
        ArcaneDustBalance balance = Unpack<ArcaneDustBalance>(NextUtil(), 0x106);
        if (balance == null)
        {
            return 0L;
        }
        DropUtilPacket();
        return balance.Balance;
    }

    public static void GetBattleNetPackets()
    {
        PegasusPacket packet;
        while ((packet = BattleNet.NextUtilPacket()) != null)
        {
            s_connectAPI.PacketReceived(packet, s_utilPackets);
        }
    }

    public static Network.BattlePayConfig GetBattlePayConfigResponse()
    {
        BattlePayConfigResponse response = Unpack<BattlePayConfigResponse>(NextUtil(), 0xee);
        if (response == null)
        {
            return null;
        }
        Network.BattlePayConfig config = new Network.BattlePayConfig {
            Available = !response.HasUnavailable || !response.Unavailable,
            Country = !response.HasCountry ? string.Empty : response.Country,
            Currency = !response.HasCurrency ? Currency.UNKNOWN : ((Currency) response.Currency),
            SecondsBeforeAutoCancel = !response.HasSecsBeforeAutoCancel ? StoreManager.DEFAULT_SECONDS_BEFORE_AUTO_CANCEL : response.SecsBeforeAutoCancel
        };
        IEnumerator<PegasusUtil.Bundle> enumerator = response.BundlesList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                PegasusUtil.Bundle current = enumerator.Current;
                Network.Bundle bundle3 = new Network.Bundle {
                    BundleType = current.Type,
                    Product = (ProductType) current.Product,
                    ProductData = current.Data,
                    Quantity = current.Quantity,
                    Cost = current.Cost
                };
                Network.Bundle item = bundle3;
                config.Bundles.Add(item);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        IEnumerator<PegasusUtil.GoldPrice> enumerator2 = response.GoldPricesList.GetEnumerator();
        try
        {
            while (enumerator2.MoveNext())
            {
                PegasusUtil.GoldPrice price = enumerator2.Current;
                Network.GoldPrice price3 = new Network.GoldPrice {
                    Cost = price.Cost,
                    Product = (ProductType) price.Product,
                    ProductData = !price.HasData ? 0 : price.Data
                };
                Network.GoldPrice price2 = price3;
                config.GoldPrices.Add(price2);
            }
        }
        finally
        {
            if (enumerator2 == null)
            {
            }
            enumerator2.Dispose();
        }
        DropUtilPacket();
        return config;
    }

    public static Network.BattlePayStatus GetBattlePayStatusResponse()
    {
        BattlePayStatusResponse response = Unpack<BattlePayStatusResponse>(NextUtil(), 0x109);
        if (response == null)
        {
            return null;
        }
        Network.BattlePayStatus status = new Network.BattlePayStatus {
            State = (Network.BattlePayStatus.PurchaseState) response.Status,
            BattlePayAvailable = response.BattlePayAvailable
        };
        if (response.HasProductType)
        {
            status.ProductType = response.ProductType;
        }
        if (response.HasPurchaseError)
        {
            status.PurchaseError = ConvertPurchaseError(response.PurchaseError);
        }
        DropUtilPacket();
        return status;
    }

    public static NetCache.NetCacheBoosters GetBoosters()
    {
        BoosterList list = Unpack<BoosterList>(NextUtil(), 0xe0);
        if (list == null)
        {
            return null;
        }
        NetCache.NetCacheBoosters boosters = new NetCache.NetCacheBoosters();
        IEnumerator<BoosterInfo> enumerator = list.ListList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                BoosterInfo current = enumerator.Current;
                NetCache.BoosterStack stack2 = new NetCache.BoosterStack {
                    Type = (BoosterType) current.Type,
                    Count = current.Count
                };
                NetCache.BoosterStack item = stack2;
                boosters.BoosterStacks.Add(item);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return boosters;
    }

    public static Network.CanceledQuest GetCanceledQuest()
    {
        CancelQuestResponse response = Unpack<CancelQuestResponse>(NextUtil(), 0x11a);
        if (response == null)
        {
            return null;
        }
        Network.CanceledQuest quest = new Network.CanceledQuest {
            AchieveID = response.QuestId,
            Canceled = response.Success
        };
        DropUtilPacket();
        return quest;
    }

    public static string GetCardName(int assetId)
    {
        CardManifest.Card card = CardManifest.Get().Find(assetId);
        if (card != null)
        {
            return card.CardID;
        }
        UnityEngine.Debug.LogWarning("can't find guid for " + assetId);
        return "ERROR";
    }

    public static Network.CardSaleResult GetCardSaleResult()
    {
        BoughtSoldCard card = Unpack<BoughtSoldCard>(NextUtil(), 0x102);
        if (card == null)
        {
            return null;
        }
        Network.CardSaleResult result = new Network.CardSaleResult {
            AssetID = card.Def.Asset,
            AssetName = GetCardName(card.Def.Asset),
            Premium = !card.Def.HasPremium ? CardFlair.PremiumType.STANDARD : ((CardFlair.PremiumType) card.Def.Premium),
            Action = (Network.CardSaleResult.SaleResult) card.Result,
            Amount = card.Amount
        };
        DropUtilPacket();
        return result;
    }

    public static NetCache.NetCacheCardUsage GetCardUsage()
    {
        CardUsage usage = Unpack<CardUsage>(NextUtil(), 0xec);
        if (usage == null)
        {
            return null;
        }
        NetCache.NetCacheCardUsage usage2 = new NetCache.NetCacheCardUsage();
        IEnumerator<CardUseCount> enumerator = usage.ListList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                CardUseCount current = enumerator.Current;
                NetCache.CardUseInfo item = new NetCache.CardUseInfo {
                    ID = current.Asset,
                    Count = current.Count
                };
                usage2.Cards.Add(item);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return usage2;
    }

    public static CardValues GetCardValues()
    {
        CardValues values = Unpack<CardValues>(NextUtil(), 260);
        DropUtilPacket();
        return values;
    }

    public static void GetClientOptions(List<ServerOption> keys)
    {
        PegasusUtil.GetOptions.Builder body = PegasusUtil.GetOptions.CreateBuilder();
        foreach (ServerOption option in keys)
        {
            body.AddKeys((int) option);
        }
        UtilOutbound(240, 0, body, 0);
    }

    public static NetCache.NetCacheCollection GetCollectionCardStacks()
    {
        Collection collection = Unpack<Collection>(NextUtil(), 0xcf);
        if (collection == null)
        {
            return null;
        }
        NetCache.NetCacheCollection caches = new NetCache.NetCacheCollection();
        IEnumerator<PegasusShared.CardStack> enumerator = collection.StacksList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                PegasusShared.CardStack current = enumerator.Current;
                NetCache.CardStack item = new NetCache.CardStack {
                    Def = { Name = GetCardName(current.CardDef.Asset), Premium = current.CardDef.Premium },
                    Date = DateToUTC(current.LatestInsertDate),
                    Count = current.Count,
                    NumSeen = current.NumSeen
                };
                caches.Stacks.Add(item);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return caches;
    }

    public static Network.HistCreateGame GetCreateGame(PowerHistoryData data)
    {
        PowerHistoryCreateGame createGame = data.CreateGame;
        if (createGame.PlayersCount != 2)
        {
            UnityEngine.Debug.LogError("History Create Game, players != 2");
            return null;
        }
        PegasusGame.Player player = createGame.PlayersList[0];
        PegasusGame.Player player2 = createGame.PlayersList[1];
        Network.HistCreateGame game2 = new Network.HistCreateGame {
            Game = { ID = createGame.GameEntity.Id, CardID = string.Empty, Tags = ReadTags(createGame.GameEntity.TagsList) }
        };
        Network.HistCreateGame.PlayerData item = new Network.HistCreateGame.PlayerData {
            ID = player.Id,
            GameAccountId = BnetGameAccountId.CreateFromNet(player.GameAccountId)
        };
        item.Player.ID = player.Entity.Id;
        item.Player.CardID = string.Empty;
        item.Player.Tags = ReadTags(player.Entity.TagsList);
        game2.Players.Add(item);
        Network.HistCreateGame.PlayerData data3 = new Network.HistCreateGame.PlayerData {
            ID = player2.Id,
            GameAccountId = BnetGameAccountId.CreateFromNet(player2.GameAccountId)
        };
        data3.Player.CardID = string.Empty;
        data3.Player.Tags = ReadTags(player2.Entity.TagsList);
        game2.Players.Add(data3);
        return game2;
    }

    public static string GetDebugConsoleCommand()
    {
        DebugConsoleCommand command = Unpack<DebugConsoleCommand>(NextDebug(), 0x7b);
        if (command == null)
        {
            return string.Empty;
        }
        DropDebugPacket();
        return command.Command;
    }

    public static Network.DebugConsoleResponse GetDebugConsoleResponse()
    {
        BobNetProto.DebugConsoleResponse response = Unpack<BobNetProto.DebugConsoleResponse>(NextGame(), 0x7c);
        if (response == null)
        {
            return null;
        }
        Network.DebugConsoleResponse response2 = new Network.DebugConsoleResponse {
            Type = (int) response.ResponseType,
            Response = response.Response
        };
        DropGamePacket();
        return response2;
    }

    public static Network.DeckContents GetDeckContents()
    {
        PegasusUtil.DeckContents contents = Unpack<PegasusUtil.DeckContents>(NextUtil(), 0xd7);
        if (contents == null)
        {
            return null;
        }
        Network.DeckContents contents2 = new Network.DeckContents {
            Deck = contents.Deck
        };
        IEnumerator<DeckCardData> enumerator = contents.CardsList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                DeckCardData current = enumerator.Current;
                Network.CardUserData item = new Network.CardUserData {
                    AssetID = current.Def.Asset,
                    Handle = current.Handle,
                    Prev = current.Prev,
                    Count = !current.HasQty ? 1 : current.Qty,
                    Premium = !current.Def.HasPremium ? CardFlair.PremiumType.STANDARD : ((CardFlair.PremiumType) current.Def.Premium)
                };
                contents2.Cards.Add(item);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return contents2;
    }

    public static void GetDeckContents(long deckID)
    {
        GetDeck.Builder body = GetDeck.CreateBuilder();
        body.SetDeck(deckID);
        UtilOutbound(0xd6, 0, body, 0);
    }

    public static NetCache.NetCacheDecks GetDeckHeaders()
    {
        DeckList list = Unpack<DeckList>(NextUtil(), 0xca);
        if (list == null)
        {
            return null;
        }
        NetCache.NetCacheDecks decks = new NetCache.NetCacheDecks();
        IEnumerator<DeckInfo> enumerator = list.DecksList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                NetCache.DeckHeader header;
                DeckInfo current = enumerator.Current;
                header = new NetCache.DeckHeader {
                    ID = current.Id,
                    Name = current.Name,
                    Hero = Network.GetHeroCard(current.Hero),
                    HeroPower = header.Hero,
                    IsTourneyValid = (current.Validity & 0x1fL) == 0x1fL,
                    Type = (NetCache.DeckHeader.DeckType) current.DeckType
                };
                decks.Decks.Add(header);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return decks;
    }

    public static int GetDeckLimit()
    {
        ProfileDeckLimit limit = Unpack<ProfileDeckLimit>(NextUtil(), 0xe7);
        if (limit == null)
        {
            return 0;
        }
        DropUtilPacket();
        return limit.DeckLimit;
    }

    public static BattleNet.GameServerInfo GetDisconnectedGameInfo()
    {
        Disconnected disconnected = Unpack<Disconnected>(NextUtil(), 170);
        if (disconnected == null)
        {
            return null;
        }
        if (!disconnected.HasInfo)
        {
            DropUtilPacket();
            return null;
        }
        BattleNet.GameServerInfo info = new BattleNet.GameServerInfo {
            Address = disconnected.Info.Address,
            GameHandle = disconnected.Info.GameHandle,
            ClientHandle = disconnected.Info.ClientHandle,
            AuroraPassword = disconnected.Info.AuroraPassword,
            Port = disconnected.Info.Port,
            Version = disconnected.Info.Version
        };
        DropUtilPacket();
        return info;
    }

    public static Network.Choice GetEntityChoice()
    {
        EntityChoice choice = Unpack<EntityChoice>(NextGame(), 0x11);
        if (choice == null)
        {
            return null;
        }
        Network.Choice choice2 = new Network.Choice {
            ID = choice.Id,
            ChoiceType = choice.ChoiceType,
            Cancelable = choice.Cancelable,
            CountMax = choice.CountMax,
            CountMin = choice.CountMin,
            Entities = CopyIntList(choice.EntitiesList),
            Source = choice.Source
        };
        DropGamePacket();
        return choice2;
    }

    public static NetCache.NetCacheFeatures GetFeatures()
    {
        GuardianVars vars = Unpack<GuardianVars>(NextUtil(), 0x108);
        if (vars == null)
        {
            return null;
        }
        NetCache.NetCacheFeatures features = new NetCache.NetCacheFeatures {
            Games = { Tournament = !vars.HasTourney ? true : vars.Tourney, Practice = !vars.HasPractice ? true : vars.Practice, Casual = !vars.HasCasual ? true : vars.Casual, Forge = !vars.HasForge ? true : vars.Forge, Friendly = !vars.HasFriendly ? true : vars.Friendly, ShowUserUI = !vars.HasShowUserUI ? 0 : vars.ShowUserUI },
            Collection = { Manager = !vars.HasManager ? true : vars.Manager, Crafting = !vars.HasCrafting ? true : vars.Crafting },
            Store = { Store = !vars.HasStore ? true : vars.Store, BattlePay = !vars.HasBattlePay ? true : vars.BattlePay, BuyWithGold = !vars.HasBuyWithGold ? true : vars.BuyWithGold },
            Heroes = { Hunter = !vars.HasHunter ? true : vars.Hunter, Mage = !vars.HasMage ? true : vars.Mage, Paladin = !vars.HasPaladin ? true : vars.Paladin, Priest = !vars.HasPriest ? true : vars.Priest, Rogue = !vars.HasRogue ? true : vars.Rogue, Shaman = !vars.HasShaman ? true : vars.Shaman, Warlock = !vars.HasWarlock ? true : vars.Warlock, Warrior = !vars.HasWarrior ? true : vars.Warrior }
        };
        DropUtilPacket();
        return features;
    }

    public static Network.HistFullEntity GetFullEntity(PowerHistoryData data)
    {
        Network.HistFullEntity entity = new Network.HistFullEntity();
        PowerHistoryEntity fullEntity = data.FullEntity;
        entity.Entity.ID = fullEntity.Entity;
        entity.Entity.CardID = fullEntity.Name;
        entity.Entity.Tags = ReadTags(fullEntity.TagsList);
        return entity;
    }

    public static Network.GameCancelInfo GetGameCancelInfo()
    {
        GameCanceled canceled = Unpack<GameCanceled>(NextGame(), 12);
        if (canceled == null)
        {
            return null;
        }
        Network.GameCancelInfo info = new Network.GameCancelInfo {
            CancelReason = (Network.GameCancelInfo.Reason) canceled.Reason
        };
        DropGamePacket();
        return info;
    }

    public static Network.GameSetup GetGameSetup()
    {
        PegasusGame.GameSetup setup = Unpack<PegasusGame.GameSetup>(NextGame(), 0x10);
        if (setup == null)
        {
            return null;
        }
        Network.GameSetup setup2 = new Network.GameSetup {
            Board = setup.Board,
            MaxSecretsPerPlayer = setup.MaxSecretsPerPlayer,
            MaxFriendlyMinionsPerPlayer = setup.MaxFriendlyMinionsPerPlayer
        };
        DropGamePacket();
        return setup2;
    }

    public static NetCache.NetCacheGamesPlayed GetGamesInfo()
    {
        GamesInfo info = Unpack<GamesInfo>(NextUtil(), 0xd0);
        if (info == null)
        {
            return null;
        }
        NetCache.NetCacheGamesPlayed played = new NetCache.NetCacheGamesPlayed {
            GamesStarted = info.GamesStarted,
            GamesWon = info.GamesWon,
            GamesLost = info.GamesLost
        };
        DropUtilPacket();
        return played;
    }

    public static void GetGameState()
    {
        PegasusGame.GetGameState.Builder body = PegasusGame.GetGameState.CreateBuilder();
        QueueGamePacket(1, body);
    }

    public static long GetGoldBalance()
    {
        GoldBalance balance = Unpack<GoldBalance>(NextUtil(), 0x116);
        if (balance == null)
        {
            return 0L;
        }
        DropUtilPacket();
        return balance.Balance;
    }

    public static Network.HistHideEntity GetHideEntity(PowerHistoryData data)
    {
        Network.HistHideEntity entity = new Network.HistHideEntity();
        PowerHistoryHide hideEntity = data.HideEntity;
        entity.Entity = hideEntity.Entity;
        entity.Zone = hideEntity.Zone;
        return entity;
    }

    public static int GetHistoryType(PowerHistoryData history)
    {
        if (history == null)
        {
            return -2;
        }
        if (history.HasTagChange)
        {
            return 4;
        }
        if (history.HasMetaData)
        {
            return 8;
        }
        if (history.HasPowerStart)
        {
            return 5;
        }
        if (history.HasPowerEnd)
        {
            return 6;
        }
        if (history.HasFullEntity)
        {
            return 1;
        }
        if (history.HasShowEntity)
        {
            return 2;
        }
        if (history.HasHideEntity)
        {
            return 3;
        }
        if (history.HasCreateGame)
        {
            return 7;
        }
        return -3;
    }

    public static NetCache.NetCacheLastLogin GetLastLogin()
    {
        ProfileLastLogin login = Unpack<ProfileLastLogin>(NextUtil(), 0xe3);
        if (login == null)
        {
            return null;
        }
        NetCache.NetCacheLastLogin login2 = new NetCache.NetCacheLastLogin {
            LastLogin = DateToUTC(login.LastLogin)
        };
        DropUtilPacket();
        return login2;
    }

    public static Network.MassDisenchantResponse GetMassDisenchantResponse()
    {
        PegasusUtil.MassDisenchantResponse response = Unpack<PegasusUtil.MassDisenchantResponse>(NextUtil(), 0x10d);
        if (response == null)
        {
            return null;
        }
        Network.MassDisenchantResponse response2 = new Network.MassDisenchantResponse {
            Amount = response.Amount
        };
        DropUtilPacket();
        return response2;
    }

    public static NetCache.NetCacheMedalHistory GetMedalHistory()
    {
        PegasusUtil.MedalHistory history = Unpack<PegasusUtil.MedalHistory>(NextUtil(), 0xea);
        if (history == null)
        {
            return null;
        }
        NetCache.NetCacheMedalHistory history2 = new NetCache.NetCacheMedalHistory();
        IEnumerator<MedalHistoryInfo> enumerator = history.MedalsList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                MedalHistoryInfo current = enumerator.Current;
                NetCache.MedalHistory item = new NetCache.MedalHistory {
                    Medal = new Medal((Medal.Type) current.Medal),
                    GrandMaster = !current.HasRank ? 0 : current.Rank,
                    Gained = DateToUTC(current.When)
                };
                history2.Medals.Add(item);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return history2;
    }

    public static NetCache.NetCacheMedalInfo GetMedalInfo()
    {
        MedalInfo info = Unpack<MedalInfo>(NextUtil(), 0xe8);
        if (info == null)
        {
            return null;
        }
        NetCache.NetCacheMedalInfo info2 = new NetCache.NetCacheMedalInfo {
            CurrMedal = new Medal((Medal.Type) info.CurrMedal),
            CurrXP = ((float) info.CurrXp) / 250f,
            PrevMedal = new Medal((Medal.Type) info.PrevMedal),
            PrevXP = ((float) info.PrevXp) / 250f,
            SeasonWins = info.SeasonWins
        };
        DropUtilPacket();
        return info2;
    }

    public static string GetMessageOfTheDay()
    {
        return string.Empty;
    }

    public static Network.HistMetaData GetMetaData(PowerHistoryData data)
    {
        Network.HistMetaData data2 = new Network.HistMetaData();
        PowerHistoryMetaData metaData = data.MetaData;
        data2.DeprecatedMeta = !metaData.HasType ? 0 : metaData.Type;
        data2.MetaType = !metaData.HasMetaType ? Network.HistMetaData.TypeMetaType.META_TARGET : ((Network.HistMetaData.TypeMetaType) metaData.MetaType);
        data2.Data = !metaData.HasData ? 0 : metaData.Data;
        IEnumerator<int> enumerator = metaData.InfoList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                int current = enumerator.Current;
                data2.Info.Add(current);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        return data2;
    }

    public static int GetNAckOption()
    {
        NAckOption option = Unpack<NAckOption>(NextGame(), 10);
        if (option == null)
        {
            return 0;
        }
        DropGamePacket();
        return option.Id;
    }

    public static int GetNotification()
    {
        PegasusGame.Notification notification = Unpack<PegasusGame.Notification>(NextGame(), 0x15);
        if (notification == null)
        {
            return 0;
        }
        DropGamePacket();
        return (int) notification.Type;
    }

    public static List<NetCache.BoosterCard> GetOpenedBooster()
    {
        BoosterContent content = Unpack<BoosterContent>(NextUtil(), 0xe2);
        if (content == null)
        {
            return null;
        }
        List<NetCache.BoosterCard> list = new List<NetCache.BoosterCard>();
        IEnumerator<PegasusUtil.BoosterCard> enumerator = content.ListList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                PegasusUtil.BoosterCard current = enumerator.Current;
                NetCache.BoosterCard item = new NetCache.BoosterCard {
                    Def = { Name = GetCardName(current.CardDef.Asset), Premium = current.CardDef.Premium },
                    Date = DateToUTC(current.InsertDate)
                };
                list.Add(item);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return list;
    }

    public static Network.Options GetOptions()
    {
        AllOptions options = Unpack<AllOptions>(NextGame(), 14);
        Network.Options options2 = new Network.Options {
            ID = options.Id
        };
        IEnumerator<PegasusGame.Option> enumerator = options.OptionsList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                PegasusGame.Option current = enumerator.Current;
                Network.Options.Option item = new Network.Options.Option {
                    Type = (Network.Options.Option.OptionType) current.Type
                };
                if (current.HasMainOption)
                {
                    item.Main.ID = current.MainOption.Id;
                    item.Main.Targets = CopyIntList(current.MainOption.TargetsList);
                }
                IEnumerator<PegasusGame.SubOption> enumerator2 = current.SubOptionsList.GetEnumerator();
                try
                {
                    while (enumerator2.MoveNext())
                    {
                        PegasusGame.SubOption option3 = enumerator2.Current;
                        Network.Options.Option.SubOption option4 = new Network.Options.Option.SubOption {
                            ID = option3.Id,
                            Targets = CopyIntList(option3.TargetsList)
                        };
                        item.Subs.Add(option4);
                    }
                }
                finally
                {
                    if (enumerator2 == null)
                    {
                    }
                    enumerator2.Dispose();
                }
                options2.List.Add(item);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropGamePacket();
        return options2;
    }

    public static NetCache.NetCachePlayerRecords GetPlayerRecords()
    {
        PlayerRecords records = Unpack<PlayerRecords>(NextUtil(), 270);
        if (records == null)
        {
            return null;
        }
        NetCache.NetCachePlayerRecords records2 = new NetCache.NetCachePlayerRecords();
        IEnumerator<PegasusUtil.PlayerRecord> enumerator = records.RecordsList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                PegasusUtil.PlayerRecord current = enumerator.Current;
                NetCache.PlayerRecord item = new NetCache.PlayerRecord {
                    RecordType = (NetCache.PlayerRecord.Type) current.Type,
                    Data = !current.HasData ? 0 : current.Data,
                    Wins = current.Wins,
                    Losses = current.Losses,
                    Ties = current.Ties
                };
                records2.Records.Add(item);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
        DropUtilPacket();
        return records2;
    }

    public static Network.HistActionEnd GetPowerEnd(PowerHistoryData data)
    {
        return new Network.HistActionEnd();
    }

    public static List<Network.PowerHistory> GetPowerHistory()
    {
        PegasusGame.PowerHistory history = Unpack<PegasusGame.PowerHistory>(NextGame(), 0x13);
        if (history == null)
        {
            return null;
        }
        List<Network.PowerHistory> list = new List<Network.PowerHistory>();
        IEnumerator<PowerHistoryData> enumerator = history.ListList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                PowerHistoryData current = enumerator.Current;
                int historyType = GetHistoryType(current);
                Network.PowerHistory item = null;
                switch (historyType)
                {
                    case 1:
                        item = GetFullEntity(current);
                        break;

                    case 2:
                        item = GetShowEntity(current);
                        break;

                    case 3:
                        item = GetHideEntity(current);
                        break;

                    case 4:
                        item = GetTagChange(current);
                        break;

                    case 5:
                        item = GetPowerStart(current);
                        break;

                    case 6:
                        item = GetPowerEnd(current);
                        break;

                    case 7:
                        item = GetCreateGame(current);
                        break;

                    case 8:
                        item = GetMetaData(current);
                        break;

                    default:
                        UnityEngine.Debug.LogError("Network.GetPowerHistory unknown type");
                        break;
                }
                if (item != null)
                {
                    list.Add(item);
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
        DropGamePacket();
        return list;
    }

    public static Network.HistActionStart GetPowerStart(PowerHistoryData data)
    {
        PowerHistoryStart powerStart = data.PowerStart;
        return new Network.HistActionStart((Network.PowerHistoryAction.PowSubType) powerStart.Type) { Index = powerStart.Index, Entity = powerStart.Source, Target = powerStart.Target };
    }

    public static List<NetCache.ProfileNotice> GetProfileNotices()
    {
        List<NetCache.ProfileNotice> list = new List<NetCache.ProfileNotice>();
        IEnumerator<PegasusUtil.ProfileNotice> enumerator = Unpack<PegasusUtil.ProfileNotices>(NextUtil(), 0xd4).ListList.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                PegasusUtil.ProfileNotice current = enumerator.Current;
                NetCache.ProfileNotice item = null;
                if (current.HasMedal)
                {
                    NetCache.ProfileNoticeMedal medal = new NetCache.ProfileNoticeMedal {
                        Medal = new Medal((Medal.Type) current.Medal.Medal)
                    };
                    item = medal;
                }
                else if (current.HasRewardBooster)
                {
                    NetCache.ProfileNoticeRewardBooster booster = new NetCache.ProfileNoticeRewardBooster {
                        BoosterType = (BoosterType) current.RewardBooster.BoosterType,
                        Count = current.RewardBooster.BoosterCount
                    };
                    item = booster;
                }
                else if (current.HasRewardCard)
                {
                    NetCache.ProfileNoticeRewardCard card = new NetCache.ProfileNoticeRewardCard {
                        CardID = CardManifest.Get().Find(current.RewardCard.Card.Asset).CardID,
                        Premium = !current.RewardCard.Card.HasPremium ? CardFlair.PremiumType.STANDARD : ((CardFlair.PremiumType) current.RewardCard.Card.Premium)
                    };
                    item = card;
                }
                else if (current.HasPreconDeck)
                {
                    NetCache.ProfileNoticePreconDeck deck = new NetCache.ProfileNoticePreconDeck {
                        DeckID = current.PreconDeck.Deck,
                        HeroAsset = current.PreconDeck.Hero
                    };
                    item = deck;
                }
                else if (current.HasRewardDust)
                {
                    NetCache.ProfileNoticeRewardDust dust = new NetCache.ProfileNoticeRewardDust {
                        Amount = current.RewardDust.Amount
                    };
                    item = dust;
                }
                else if (current.HasRewardMount)
                {
                    NetCache.ProfileNoticeRewardMount mount = new NetCache.ProfileNoticeRewardMount {
                        MountID = current.RewardMount.MountId
                    };
                    item = mount;
                }
                else if (current.HasRewardForge)
                {
                    NetCache.ProfileNoticeRewardForge forge = new NetCache.ProfileNoticeRewardForge {
                        Quantity = current.RewardForge.Quantity
                    };
                    item = forge;
                }
                else if (current.HasRewardGold)
                {
                    NetCache.ProfileNoticeRewardGold gold = new NetCache.ProfileNoticeRewardGold {
                        Amount = current.RewardGold.Amount
                    };
                    item = gold;
                }
                else
                {
                    UnityEngine.Debug.LogError("ConnectAPI.GetProfileNotices(): Unrecognized profile notice");
                }
                if (item != null)
                {
                    item.NoticeID = current.Entry;
                    item.Origin = (NetCache.ProfileNotice.NoticeOrigin) current.Origin;
                    item.OriginData = !current.HasOriginData ? 0L : current.OriginData;
                    list.Add(item);
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
        DropUtilPacket();
        return list;
    }

    public static NetCache.NetCacheProfileProgress GetProfileProgress()
    {
        ProfileProgress progress = Unpack<ProfileProgress>(NextUtil(), 0xe9);
        if (progress == null)
        {
            return null;
        }
        NetCache.NetCacheProfileProgress progress2 = new NetCache.NetCacheProfileProgress {
            CampaignProgress = progress.Progress,
            BestForgeWins = progress.BestForge,
            LastForgeDate = !progress.HasLastForge ? 0L : DateToUTC(progress.LastForge)
        };
        DropUtilPacket();
        return progress2;
    }

    public static Network.PurchaseCanceledResponse GetPurchaseCanceledResponse()
    {
        CancelPurchaseResponse response = Unpack<CancelPurchaseResponse>(NextUtil(), 0x113);
        if (response == null)
        {
            return null;
        }
        Network.PurchaseCanceledResponse response2 = new Network.PurchaseCanceledResponse();
        switch (response.Result)
        {
            case CancelPurchaseResponse.Types.CancelResult.CR_SUCCESS:
                response2.Result = Network.PurchaseCanceledResponse.CancelResult.SUCCESS;
                break;

            case CancelPurchaseResponse.Types.CancelResult.CR_NOT_ALLOWED:
                response2.Result = Network.PurchaseCanceledResponse.CancelResult.NOT_ALLOWED;
                break;

            case CancelPurchaseResponse.Types.CancelResult.CR_NOTHING_TO_CANCEL:
                response2.Result = Network.PurchaseCanceledResponse.CancelResult.NOTHING_TO_CANCEL;
                break;
        }
        DropUtilPacket();
        return response2;
    }

    public static Network.PurchaseMethod GetPurchaseMethodResponse()
    {
        PegasusUtil.PurchaseMethod method = Unpack<PegasusUtil.PurchaseMethod>(NextUtil(), 0x110);
        if (method == null)
        {
            return null;
        }
        Network.PurchaseMethod method2 = new Network.PurchaseMethod();
        if (method.HasProduct)
        {
            method2.BundleType = method.Product;
        }
        if (method.HasQuantity)
        {
            method2.Quantity = method.Quantity;
        }
        if (method.HasCurrency)
        {
            method2.Currency = (Currency) method.Currency;
        }
        if (method.HasWalletName)
        {
            method2.WalletName = method.WalletName;
        }
        if (method.HasUseEbalance)
        {
            method2.UseEBalance = method.UseEbalance;
        }
        if (method.HasError)
        {
            method2.PurchaseError = ConvertPurchaseError(method.Error);
        }
        DropUtilPacket();
        return method2;
    }

    public static Network.PurchaseResponse GetPurchaseResponse()
    {
        PegasusUtil.PurchaseResponse response = Unpack<PegasusUtil.PurchaseResponse>(NextUtil(), 0x100);
        if (response == null)
        {
            return null;
        }
        Network.PurchaseResponse response2 = new Network.PurchaseResponse {
            PurchaseError = ConvertPurchaseError(response.Error)
        };
        DropUtilPacket();
        return response2;
    }

    public static Network.PurchaseViaGoldResponse GetPurchaseWithGoldResponse()
    {
        PurchaseWithGoldResponse response = Unpack<PurchaseWithGoldResponse>(NextUtil(), 280);
        if (response == null)
        {
            return null;
        }
        Network.PurchaseViaGoldResponse response2 = new Network.PurchaseViaGoldResponse {
            Error = (Network.PurchaseViaGoldResponse.ErrorType) response.Result
        };
        if (response.HasGoldUsed)
        {
            response2.GoldUsed = response.GoldUsed;
        }
        DropUtilPacket();
        return response2;
    }

    public static NetCache.NetCacheRewardProgress GetRewardProgress()
    {
        RewardProgress progress = Unpack<RewardProgress>(NextUtil(), 0x10f);
        if (progress == null)
        {
            return null;
        }
        NetCache.NetCacheRewardProgress progress2 = new NetCache.NetCacheRewardProgress {
            SeasonEndDate = DateToUTC(progress.SeasonEnd),
            WinsPerPack = progress.WinsPerPack,
            WinsPerDust = !progress.HasWinsPerDust ? progress.WinsPerPack : progress.WinsPerDust,
            MaxPackRewards = progress.MaxPackRewards,
            MaxDustRewards = !progress.HasMaxDustRewards ? 0 : progress.MaxDustRewards,
            PacksPerReward = !progress.HasPacksPerReward ? 1 : progress.PacksPerReward,
            DustPerReward = progress.DustPerReward,
            PackRewardType = !progress.HasPackId ? BoosterType.EXPERT : ((BoosterType) progress.PackId),
            XPSoloLimit = progress.XpSoloLimit,
            MaxHeroLevel = progress.MaxHeroLevel
        };
        DropUtilPacket();
        return progress2;
    }

    public static Network.HistShowEntity GetShowEntity(PowerHistoryData data)
    {
        Network.HistShowEntity entity = new Network.HistShowEntity();
        PowerHistoryEntity showEntity = data.ShowEntity;
        entity.Entity.ID = showEntity.Entity;
        entity.Entity.CardID = showEntity.Name;
        entity.Entity.Tags = ReadTags(showEntity.TagsList);
        return entity;
    }

    public static Network.HistTagChange GetTagChange(PowerHistoryData data)
    {
        Network.HistTagChange change = new Network.HistTagChange();
        PowerHistoryTagChange tagChange = data.TagChange;
        change.Entity = tagChange.Entity;
        change.Tag = tagChange.Tag;
        change.Value = tagChange.Value;
        return change;
    }

    public static Network.TurnTimerInfo GetTimeRemaining()
    {
        PegasusGame.TurnTimer timer = Unpack<PegasusGame.TurnTimer>(NextGame(), 9);
        if (timer == null)
        {
            return null;
        }
        Network.TurnTimerInfo info = new Network.TurnTimerInfo {
            Seconds = timer.Seconds,
            Turn = timer.Turn
        };
        DropGamePacket();
        return info;
    }

    public static Network.UserUI GetUserUI()
    {
        PegasusGame.UserUI rui = Unpack<PegasusGame.UserUI>(NextGame(), 15);
        if (rui == null)
        {
            return null;
        }
        Network.UserUI rui2 = new Network.UserUI();
        if (rui.HasMouseInfo)
        {
            PegasusGame.MouseInfo mouseInfo = rui.MouseInfo;
            rui2.mouseInfo = new Network.UserUI.MouseInfo();
            rui2.mouseInfo.ArrowOriginID = mouseInfo.ArrowOrigin;
            rui2.mouseInfo.HeldCardID = mouseInfo.HeldCard;
            rui2.mouseInfo.OverCardID = mouseInfo.OverCard;
            rui2.mouseInfo.X = mouseInfo.X;
            rui2.mouseInfo.Y = mouseInfo.Y;
        }
        else if (rui.HasEmote)
        {
            rui2.emoteInfo = new Network.UserUI.EmoteInfo();
            rui2.emoteInfo.Emote = rui.Emote;
        }
        DropGamePacket();
        return rui2;
    }

    public static Network.ValidatedAchieve GetValidatedAchieve()
    {
        ValidateAchieveResponse response = Unpack<ValidateAchieveResponse>(NextUtil(), 0x11d);
        if (response == null)
        {
            return null;
        }
        Network.ValidatedAchieve achieve = new Network.ValidatedAchieve {
            AchieveID = response.Achieve
        };
        DropUtilPacket();
        return achieve;
    }

    public static void GiveUp()
    {
        PegasusGame.GiveUp.Builder body = PegasusGame.GiveUp.CreateBuilder();
        QueueGamePacket(11, body);
    }

    public static void GotoGameServer(BattleNet.GameServerInfo info)
    {
        string address = info.Address;
        int port = info.Port;
        Log.Net.Print(string.Concat(new object[] { "ConnectAPI.GotoGameServer -- address= ", address, ":", port, ", game=", info.GameHandle, ", client=", info.ClientHandle }));
        if (address != null)
        {
            s_gameServer.Connect(address, port);
            AuroraHandshake.Builder body = AuroraHandshake.CreateBuilder();
            body.Password = info.AuroraPassword;
            body.GameHandle = info.GameHandle;
            body.ClientHandle = (int) info.ClientHandle;
            QueueGamePacket(0xa8, body);
        }
    }

    public static void GuardianTrack(Network.TrackWhat what)
    {
        PegasusUtil.GuardianTrack.Builder body = PegasusUtil.GuardianTrack.CreateBuilder();
        body.SetWhat((int) what);
        UtilOutbound(0x105, 0, body, 0);
    }

    public static void Heartbeat()
    {
        Queue<QueuedPacket> queue = s_queuedPackets;
        lock (queue)
        {
            GetBattleNetPackets();
            while (s_queuedPackets.Count > 0)
            {
                QueuedPacket packet = s_queuedPackets.Dequeue();
                if (packet == null)
                {
                    UnityEngine.Debug.LogError("null packet! " + s_queuedPackets.Count);
                }
                else
                {
                    PacketDecoder decoder;
                    PegasusPacket p = packet.packet;
                    Queue<PegasusPacket> targetQueue = packet.targetQueue;
                    if (s_packetDecoders.TryGetValue(p.Type, out decoder))
                    {
                        PegasusPacket item = decoder.HandlePacket(p);
                        if (item != null)
                        {
                            targetQueue.Enqueue(item);
                        }
                        continue;
                    }
                    UnityEngine.Debug.LogError("Could not find a packet decoder for a packet of type " + p.Type);
                }
            }
        }
        int num = (s_gamePackets.Count + s_bobnetPackets.Count) + s_utilPackets.Count;
        if ((num > 0) && (num == s_lastFrameQueueSize))
        {
            s_messageBlockedCount++;
            if (s_messageBlockedCount > 30)
            {
                UnityEngine.Debug.LogWarning(string.Concat(new object[] { "Connect queue has not been emptied for 30 frames: ", s_gamePackets.Count, " ", s_bobnetPackets.Count, " ", s_utilPackets.Count }));
                s_messageBlockedCount = 0;
            }
        }
        else
        {
            s_lastFrameQueueSize = num;
            s_messageBlockedCount = 0;
        }
        s_gameServer.Update();
        if (ConnectDebugConsole())
        {
            s_debugConsole.Update();
        }
    }

    public static void JoinGame(int handle, long deckID)
    {
    }

    public static void MassDisenchant()
    {
        MassDisenchantRequest.Builder body = MassDisenchantRequest.CreateBuilder();
        UtilOutbound(0x10c, 0, body, 0);
    }

    public static PegasusPacket Next(Queue<PegasusPacket> packets, bool pop)
    {
        if ((packets == null) || (packets.Count == 0))
        {
            return null;
        }
        if (pop)
        {
            return packets.Dequeue();
        }
        return packets.Peek();
    }

    public static PegasusPacket NextBobNet()
    {
        return NextBobNet(false);
    }

    public static PegasusPacket NextBobNet(bool pop)
    {
        return Next(s_bobnetPackets, pop);
    }

    public static int NextBobNetType()
    {
        return NextType(s_bobnetPackets);
    }

    public static PegasusPacket NextDebug()
    {
        return NextDebug(false);
    }

    public static PegasusPacket NextDebug(bool pop)
    {
        return Next(s_debugPackets, pop);
    }

    public static int NextDebugConsoleType()
    {
        return NextType(s_debugPackets);
    }

    public static PegasusPacket NextGame()
    {
        return NextGame(false);
    }

    public static PegasusPacket NextGame(bool pop)
    {
        return Next(s_gamePackets, pop);
    }

    public static int NextGameType()
    {
        return NextType(s_gamePackets);
    }

    private static int NextType(Queue<PegasusPacket> packets)
    {
        if ((packets != null) && (packets.Count != 0))
        {
            return packets.Peek().Type;
        }
        return 0;
    }

    public static PegasusPacket NextUtil()
    {
        return NextUtil(false);
    }

    public static PegasusPacket NextUtil(bool pop)
    {
        return Next(s_utilPackets, pop);
    }

    public static int NextUtilType()
    {
        return NextType(s_utilPackets);
    }

    public static void NoBobNetReply()
    {
        DropPacket(1);
    }

    public static void NoDebugConsoleReply()
    {
        DropPacket(4);
    }

    public static void NoGameReply()
    {
        DropPacket(2);
    }

    public static void NoUtilReply()
    {
        DropPacket(3);
    }

    public static void OpenBooster(BoosterType type)
    {
        PegasusUtil.OpenBooster.Builder body = PegasusUtil.OpenBooster.CreateBuilder();
        body.SetBoosterType((int) type);
        UtilOutbound(0xe1, 0, body, 0);
    }

    public void PacketReceived(PegasusPacket p, object state)
    {
        Queue<QueuedPacket> queue = s_queuedPackets;
        lock (queue)
        {
            s_queuedPackets.Enqueue(new QueuedPacket(p, (Queue<PegasusPacket>) state));
        }
    }

    public static void ProtoWorkAround()
    {
        ProtoWorkAroundHelper<Auth.Types.Result>();
        ProtoWorkAroundHelper<FriendChange.Types.FriendAction>();
        ProtoWorkAroundHelper<InviteFailed.Types.Reason>();
        ProtoWorkAroundHelper<QueueStatus.Types.QueueEvent>();
        ProtoWorkAroundHelper<BeginPlaying.Types.Mode>();
        ProtoWorkAroundHelper<ReportGame.Types.Type>();
        ProtoWorkAroundHelper<ServerControl.Types.ControlType>();
        ProtoWorkAroundHelper<BobNetProto.DebugConsoleResponse.Types.ResponseType>();
        ProtoWorkAroundHelper<DatabaseCommand.Types.TCommand>();
        ProtoWorkAroundHelper<FriendStatus.Types.Status>();
        ProtoWorkAroundHelper<DatabaseInfo.Types.TInfo>();
        ProtoWorkAroundHelper<PegasusGame.Option.Types.Type>();
        ProtoWorkAroundHelper<PowerHistoryStart.Types.Type>();
        ProtoWorkAroundHelper<PegasusGame.Notification.Types.Type>();
        ProtoWorkAroundHelper<PowerHistoryMetaData.Types.MetaType>();
        ProtoWorkAroundHelper<GetAccountInfo.Types.Request>();
        ProtoWorkAroundHelper<OneClientTracking.Types.Level>();
        ProtoWorkAroundHelper<UtilAuth.Types.Result>();
        ProtoWorkAroundHelper<DebugAuth.Types.Result>();
        ProtoWorkAroundHelper<PegasusUtil.DBAction.Types.Action>();
        ProtoWorkAroundHelper<PegasusUtil.DBAction.Types.Result>();
        ProtoWorkAroundHelper<DeckInfo.Types.DeckType>();
        ProtoWorkAroundHelper<BattlePayStatusResponse.Types.PurchaseState>();
        ProtoWorkAroundHelper<BoughtSoldCard.Types.Result>();
        ProtoWorkAroundHelper<PurchaseError.Types.Error>();
    }

    public static void ProtoWorkAroundHelper<T>()
    {
        CodedInputStream stream = CodedInputStream.CreateInstance((Stream) null);
        T local = default(T);
        object unknown = null;
        stream.ReadEnum<T>(ref local, out unknown);
    }

    public static void PurchaseViaGold(int quantity, ProductType product, int data)
    {
        PurchaseWithGold.Builder body = PurchaseWithGold.CreateBuilder();
        body.Product = (int) product;
        body.Data = data;
        body.Quantity = quantity;
        UtilOutbound(0x117, 0, body, 0);
    }

    public static void QueueDebugPacket(int packetId, IBuilderLite body)
    {
        QueueDebugPacket(packetId, body.WeakBuild());
    }

    public static void QueueDebugPacket(int packetId, IMessageLite body)
    {
        s_debugConsole.QueuePacket(new PegasusPacket(packetId, body));
    }

    public static void QueueGamePacket(int packetId, IBuilderLite body)
    {
        QueueGamePacket(packetId, body.WeakBuild());
    }

    public static void QueueGamePacket(int packetId, IMessageLite body)
    {
        s_gameServer.QueuePacket(new PegasusPacket(packetId, body));
    }

    public static void ReadClientOptions(Dictionary<ServerOption, NetCache.ClientOptionBase> options)
    {
        ClientOptions options2 = Unpack<ClientOptions>(NextUtil(), 0xf1);
        if (options2 != null)
        {
            IEnumerator<PegasusUtil.ClientOption> enumerator = options2.OptionsList.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    PegasusUtil.ClientOption current = enumerator.Current;
                    ServerOption index = (ServerOption) current.Index;
                    if (current.HasAsBool)
                    {
                        options[index] = new NetCache.ClientOptionBool(current.AsBool);
                    }
                    else
                    {
                        if (current.HasAsInt32)
                        {
                            options[index] = new NetCache.ClientOptionInt(current.AsInt32);
                            continue;
                        }
                        if (current.HasAsInt64)
                        {
                            options[index] = new NetCache.ClientOptionLong(current.AsInt64);
                            continue;
                        }
                        if (current.HasAsFloat)
                        {
                            options[index] = new NetCache.ClientOptionFloat(current.AsFloat);
                        }
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
            DropUtilPacket();
        }
    }

    public static List<Network.Entity.Tag> ReadTags(IList<PegasusGame.Tag> tagList)
    {
        List<Network.Entity.Tag> list = new List<Network.Entity.Tag>();
        for (int i = 0; i < tagList.Count; i++)
        {
            PegasusGame.Tag tag = tagList[i];
            Network.Entity.Tag item = new Network.Entity.Tag {
                Name = tag.Name,
                Value = tag.Value
            };
            list.Add(item);
        }
        return list;
    }

    public static void RenameDeck(long deckID, string name)
    {
        PegasusUtil.RenameDeck.Builder body = PegasusUtil.RenameDeck.CreateBuilder();
        body.SetDeck(deckID);
        body.SetName(name);
        UtilOutbound(0xd3, 0, body, 0);
    }

    public static void RequestAchieves(bool activeOnly)
    {
        PegasusUtil.GetAchieves.Builder body = PegasusUtil.GetAchieves.CreateBuilder();
        if (activeOnly)
        {
            body.OnlyActive = activeOnly;
        }
        UtilOutbound(0xfd, 0, body, 0);
    }

    public static void RequestBattlePayConfig()
    {
        GetBattlePayConfig.Builder body = GetBattlePayConfig.CreateBuilder();
        UtilOutbound(0xed, 1, body, 0);
    }

    public static void RequestBattlePayStatus()
    {
        GetBattlePayStatus.Builder body = GetBattlePayStatus.CreateBuilder();
        UtilOutbound(0xff, 1, body, 0);
    }

    public static void RequestCancelQuest(int achieveID)
    {
        CancelQuest.Builder body = CancelQuest.CreateBuilder();
        body.QuestId = achieveID;
        UtilOutbound(0x119, 0, body, 0);
    }

    public static void RequestNetCacheObject(int type)
    {
        GetAccountInfo.Builder body = GetAccountInfo.CreateBuilder();
        body.SetRequest((GetAccountInfo.Types.Request) type);
        UtilOutbound(0xc9, 0, body, type);
    }

    public static void RequestPurchaseMethod(int productType, int quantity, int currency)
    {
        GetPurchaseMethod.Builder body = GetPurchaseMethod.CreateBuilder();
        body.SetProduct(productType);
        body.SetQuantity(quantity);
        body.SetCurrency(currency);
        UtilOutbound(250, 1, body, 0);
    }

    public static void SellCard(int id, int premium)
    {
        BuySellCard.Builder body = BuySellCard.CreateBuilder();
        PegasusShared.CardDef.Builder builderForValue = PegasusShared.CardDef.CreateBuilder();
        builderForValue.SetAsset(id);
        if (premium != 0)
        {
            builderForValue.SetPremium(premium);
        }
        body.SetDef(builderForValue);
        body.SetBuying(false);
        UtilOutbound(0x101, 0, body, 0);
    }

    public static void SendChoices(int id, List<int> picks)
    {
        ChooseEntities.Builder body = ChooseEntities.CreateBuilder();
        body.SetId(id);
        for (int i = 0; i < picks.Count; i++)
        {
            body.AddEntities(picks[i]);
        }
        QueueGamePacket(3, body);
    }

    public static void SendDebugConsoleResponse(int responseType, string message)
    {
        if (message != null)
        {
            if (!s_debugConsole.Active)
            {
                UnityEngine.Debug.LogWarning("Cannont send console response " + message + "; no debug console is active.");
            }
            else
            {
                BobNetProto.DebugConsoleResponse.Builder body = BobNetProto.DebugConsoleResponse.CreateBuilder();
                body.SetResponseType((BobNetProto.DebugConsoleResponse.Types.ResponseType) responseType);
                body.SetResponse(message);
                QueueDebugPacket(0x7c, body);
            }
        }
    }

    public static void SendDeckData(long deck, List<Network.CardUserData> cards)
    {
        DeckSetData.Builder body = DeckSetData.CreateBuilder();
        body.SetDeck(deck);
        foreach (Network.CardUserData data in cards)
        {
            DeckCardData.Builder builderForValue = DeckCardData.CreateBuilder();
            PegasusShared.CardDef.Builder builder3 = PegasusShared.CardDef.CreateBuilder();
            builder3.SetAsset(data.AssetID);
            if (data.Premium != CardFlair.PremiumType.STANDARD)
            {
                builder3.SetPremium((int) data.Premium);
            }
            builderForValue.SetDef(builder3);
            builderForValue.SetHandle(data.Handle);
            builderForValue.SetPrev(data.Prev);
            builderForValue.SetQty(data.Count);
            body.AddCards(builderForValue);
        }
        UtilOutbound(0xde, 0, body, 0);
    }

    public static void SendEmote(int emote)
    {
        PegasusGame.UserUI.Builder body = PegasusGame.UserUI.CreateBuilder();
        body.SetEmote(emote);
        QueueGamePacket(15, body);
    }

    public static void SendIndirectConsoleCommand(string command)
    {
        if (command != null)
        {
            if (!s_gameServer.Active)
            {
                UnityEngine.Debug.LogWarning("Cannot send an indirect console command '" + command + "' to server; no game server is active.");
            }
            else
            {
                DebugConsoleCommand.Builder body = DebugConsoleCommand.CreateBuilder();
                body.SetCommand(command);
                QueueGamePacket(0x7b, body);
            }
        }
    }

    public static void SendOption(int ID, int index, int target, int sub, int pos)
    {
        ChooseOption.Builder body = ChooseOption.CreateBuilder();
        body.SetId(ID);
        body.SetIndex(index);
        body.SetTarget(target);
        body.SetSubOption(sub);
        body.SetPosition(pos);
        QueueGamePacket(2, body);
    }

    public static void SendUserUI(int overCard, int heldCard, int arrowOrigin, int x, int y)
    {
        PegasusGame.UserUI.Builder body = PegasusGame.UserUI.CreateBuilder();
        PegasusGame.MouseInfo.Builder builderForValue = PegasusGame.MouseInfo.CreateBuilder();
        builderForValue.SetArrowOrigin(arrowOrigin);
        builderForValue.SetOverCard(overCard);
        builderForValue.SetHeldCard(heldCard);
        builderForValue.SetX(x);
        builderForValue.SetY(y);
        body.SetMouseInfo(builderForValue);
        QueueGamePacket(15, body);
    }

    public static void SetClientOptionBool(int key, bool value)
    {
        SetOptions.Builder body = SetOptions.CreateBuilder();
        PegasusUtil.ClientOption.Builder builderForValue = PegasusUtil.ClientOption.CreateBuilder();
        builderForValue.SetIndex(key);
        builderForValue.SetAsBool(value);
        body.AddOptions(builderForValue);
        UtilOutbound(0xef, 0, body, 0);
    }

    public static void SetClientOptionFloat(int key, float value)
    {
        SetOptions.Builder body = SetOptions.CreateBuilder();
        PegasusUtil.ClientOption.Builder builderForValue = PegasusUtil.ClientOption.CreateBuilder();
        builderForValue.SetIndex(key);
        builderForValue.SetAsFloat(value);
        body.AddOptions(builderForValue);
        UtilOutbound(0xef, 0, body, 0);
    }

    public static void SetClientOptionInt(int key, int value)
    {
        SetOptions.Builder body = SetOptions.CreateBuilder();
        PegasusUtil.ClientOption.Builder builderForValue = PegasusUtil.ClientOption.CreateBuilder();
        builderForValue.SetIndex(key);
        builderForValue.SetAsInt32(value);
        body.AddOptions(builderForValue);
        UtilOutbound(0xef, 0, body, 0);
    }

    public static void SetClientOptionLong(int key, long value)
    {
        SetOptions.Builder body = SetOptions.CreateBuilder();
        PegasusUtil.ClientOption.Builder builderForValue = PegasusUtil.ClientOption.CreateBuilder();
        builderForValue.SetIndex(key);
        builderForValue.SetAsInt64(value);
        body.AddOptions(builderForValue);
        UtilOutbound(0xef, 0, body, 0);
    }

    public static void SetLastLogin()
    {
        UpdateLogin.Builder body = UpdateLogin.CreateBuilder();
        UtilOutbound(0xcd, 0, body, 0);
    }

    public static void SetProgress(long value)
    {
        PegasusUtil.SetProgress.Builder body = PegasusUtil.SetProgress.CreateBuilder();
        body.SetValue(value);
        UtilOutbound(230, 0, body, 0);
    }

    public static void SignalCountdown()
    {
        BeginPlaying.Builder body = BeginPlaying.CreateBuilder();
        body.Mode = BeginPlaying.Types.Mode.COUNTDOWN;
        QueueGamePacket(0x71, body);
    }

    public static void SignalStart()
    {
        BeginPlaying.Builder body = BeginPlaying.CreateBuilder();
        body.Mode = BeginPlaying.Types.Mode.READY;
        QueueGamePacket(0x71, body);
    }

    public static void SubmitBug(string subject, string desc, string userName, string hostName, int gameCodeVersion, string gameDataVersion)
    {
        PegasusUtil.SubmitBug.Builder body = PegasusUtil.SubmitBug.CreateBuilder();
        body.SetSubject(subject);
        if ((desc != null) && (desc.Length > 0))
        {
            body.SetDesc(desc);
        }
        else
        {
            body.SetDesc(string.Empty);
        }
        body.SetUsername(userName);
        body.SetHostname(hostName);
        body.SetGameCodeVersion(gameCodeVersion);
        body.SetGameDataVersion(gameDataVersion);
        UtilOutbound(0xe5, 0, body, 0);
    }

    public static void TrackClient(int level, int what, string message)
    {
        OneClientTracking.Builder builderForValue = OneClientTracking.CreateBuilder();
        builderForValue.SetLevel((OneClientTracking.Types.Level) level);
        builderForValue.SetWhat(what);
        builderForValue.SetTimestamp((ulong) DateTime.Now.Ticks);
        if ((message != null) && (message.Length > 0))
        {
            builderForValue.SetMessage(message);
        }
        m_trackingPacket.AddInfo(builderForValue);
        if (m_trackingPacket.InfoCount > 10)
        {
            UtilOutbound(0xe4, 0, m_trackingPacket, 0);
            m_trackingPacket.ClearInfo();
        }
    }

    private static T Unpack<T>(PegasusPacket p)
    {
        if ((p != null) && (p.Body is T))
        {
            return (T) p.Body;
        }
        return default(T);
    }

    private static T Unpack<T>(PegasusPacket p, int packetId)
    {
        if (((p != null) && (p.Type == packetId)) && (p.Body is T))
        {
            return (T) p.Body;
        }
        return default(T);
    }

    private static void UtilOutbound(int type, int system, IBuilderLite body, int subID = 0)
    {
        byte[] bytes = body.WeakBuild().ToByteArray();
        BattleNet.SendUtilPacket(type, system, bytes, bytes.Length, subID);
    }

    public static bool UtilServerReady()
    {
        return (s_utilPackets.Count > 0);
    }

    public static void ValidateAchieve(int achieveID)
    {
        PegasusUtil.ValidateAchieve.Builder body = PegasusUtil.ValidateAchieve.CreateBuilder();
        body.Achieve = achieveID;
        UtilOutbound(0x11c, 0, body, 0);
    }

    public class DefaultProtobufPacketDecoder<TMessage, TBuilder> : ConnectAPI.PacketDecoder where TMessage: IMessageLite<TMessage, TBuilder> where TBuilder: IBuilderLite<TMessage, TBuilder>, new()
    {
        public override PegasusPacket HandlePacket(PegasusPacket p)
        {
            return ConnectAPI.PacketDecoder.HandleProtoBuf<TMessage, TBuilder>(p);
        }
    }

    public class DeprecatedPacketDecoder : ConnectAPI.PacketDecoder
    {
        public override PegasusPacket HandlePacket(PegasusPacket p)
        {
            UnityEngine.Debug.LogWarning("Dropping deprecated packet of type: " + p.Type);
            return null;
        }
    }

    public class NoOpPacketDecoder : ConnectAPI.PacketDecoder
    {
        public override PegasusPacket HandlePacket(PegasusPacket p)
        {
            return null;
        }
    }

    public abstract class PacketDecoder
    {
        public abstract PegasusPacket HandlePacket(PegasusPacket p);
        public static PegasusPacket HandleProtoBuf<TMessage, TBuilder>(PegasusPacket p) where TMessage: IMessageLite<TMessage, TBuilder> where TBuilder: IBuilderLite<TMessage, TBuilder>, new()
        {
            byte[] body = (byte[]) p.Body;
            TBuilder local2 = default(TBuilder);
            TBuilder local = (local2 == null) ? Activator.CreateInstance<TBuilder>() : default(TBuilder);
            p.Body = local.MergeFrom(body).Build();
            return p;
        }
    }

    private class QueuedPacket
    {
        public PegasusPacket packet;
        public Queue<PegasusPacket> targetQueue;

        public QueuedPacket(PegasusPacket p, Queue<PegasusPacket> t)
        {
            this.packet = p;
            this.targetQueue = t;
        }
    }

    public enum ServerType
    {
        BOBNET = 1,
        DEBUG_CONSOLE = 4,
        GAME_SERVER = 2,
        UTIL_SERVER = 3
    }
}


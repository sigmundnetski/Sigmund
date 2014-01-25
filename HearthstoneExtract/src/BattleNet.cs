using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class BattleNet
{
    private static IBattleNet s_impl = new BattleNetDll();

    public static void AcceptPartyInvite(ref DllEntityId partyId)
    {
        s_impl.AcceptPartyInvite(ref partyId);
    }

    public static void AnswerChallenge(ulong challengeID, IntPtr answer)
    {
        s_impl.AnswerChallenge(challengeID, answer);
    }

    public static void AppQuit()
    {
        s_impl.AppQuit();
    }

    public static int BattleNetStatus()
    {
        return s_impl.BattleNetStatus();
    }

    public static void CancelChallenge(ulong challengeID)
    {
        s_impl.CancelChallenge(challengeID);
    }

    public static void ClearChallenges()
    {
        s_impl.ClearChallenges();
    }

    public static void ClearErrors()
    {
        s_impl.ClearErrors();
    }

    public static void ClearFriendsUpdates()
    {
        s_impl.ClearFriendsUpdates();
    }

    public static void ClearPartyUpdates()
    {
        s_impl.ClearPartyUpdates();
    }

    public static void ClearPresence()
    {
        s_impl.ClearPresence();
    }

    public static void ClearWhispers()
    {
        s_impl.ClearWhispers();
    }

    public static void CloseAurora()
    {
        s_impl.CloseAurora();
    }

    public static void DeclinePartyInvite(ref DllEntityId partyId)
    {
        s_impl.DeclinePartyInvite(ref partyId);
    }

    public static void DraftQueue(bool join)
    {
        s_impl.DraftQueue(join);
    }

    public static void GetChallenges([Out] DllChallengeInfo[] challenges)
    {
        s_impl.GetChallenges(challenges);
    }

    public static void GetErrors([Out] DllErrorInfo[] errors)
    {
        s_impl.GetErrors(errors);
    }

    public static int GetErrorsCount()
    {
        return s_impl.GetErrorsCount();
    }

    public static void GetFriendsInfo(ref DllFriendsInfo info)
    {
        s_impl.GetFriendsInfo(ref info);
    }

    public static void GetFriendsUpdates([Out] DllFriendsUpdate[] updates)
    {
        s_impl.GetFriendsUpdates(updates);
    }

    public static Implementation GetImplementation()
    {
        return s_impl.GetImplementation();
    }

    public static DllEntityId GetMyGameAccountId()
    {
        return s_impl.GetMyGameAccountId();
    }

    public static void GetPartyUpdates([Out] DllPartyEvent[] updates)
    {
        s_impl.GetPartyUpdates(updates);
    }

    public static void GetPartyUpdatesInfo(ref DllPartyInfo info)
    {
        s_impl.GetPartyUpdatesInfo(ref info);
    }

    public static void GetPresence([Out] PresenceUpdate[] updates)
    {
        s_impl.GetPresence(updates);
    }

    public static QueueEvent GetQueueEvent()
    {
        return s_impl.GetQueueEvent();
    }

    public static void GetWhisperInfo(ref DllWhisperInfo info)
    {
        s_impl.GetWhisperInfo(ref info);
    }

    public static void GetWhispers([Out] DllWhisper[] whispers)
    {
        s_impl.GetWhispers(whispers);
    }

    public static bool Init(bool fromEditor)
    {
        return s_impl.Init(fromEditor);
    }

    public static void Log(string str)
    {
        Debug.Log(str);
    }

    public static void LogError(string str)
    {
        Debug.LogError(str);
    }

    public static void LogWarning(string str)
    {
        Debug.LogWarning(str);
    }

    public static void MakeMatch(long deckID)
    {
        s_impl.MakeMatch(deckID);
    }

    public static void ManageFriendInvite(int action, ulong inviteId)
    {
        s_impl.ManageFriendInvite(action, inviteId);
    }

    public static PegasusPacket NextUtilPacket()
    {
        return s_impl.NextUtilPacket();
    }

    public static int NumChallenges()
    {
        return s_impl.NumChallenges();
    }

    public static int PresenceSize()
    {
        return s_impl.PresenceSize();
    }

    public static void ProcessAurora()
    {
        s_impl.ProcessAurora();
    }

    public static void QueryAurora()
    {
        s_impl.QueryAurora();
    }

    public static void RemoveFriend(ref DllEntityId account)
    {
        s_impl.RemoveFriend(ref account);
    }

    public static void RescindPartyInvite(ref DllEntityId partyId)
    {
        s_impl.RescindPartyInvite(ref partyId);
    }

    public static void SendFriendInvite(IntPtr inviter, IntPtr invitee, bool byEmail)
    {
        s_impl.SendFriendInvite(inviter, invitee, byEmail);
    }

    public static void SendPartyInvite(ref DllEntityId gameAccount)
    {
        s_impl.SendPartyInvite(ref gameAccount);
    }

    public static void SendUtilPacket(int packetId, int systemId, byte[] bytes, int size, int subID)
    {
        s_impl.SendUtilPacket(packetId, systemId, bytes, size, subID);
    }

    public static void SendWhisper(ref DllEntityId gameAccount, IntPtr message)
    {
        s_impl.SendWhisper(ref gameAccount, message);
    }

    public static void SetPartyDeck(ref DllEntityId partyId, long deckID)
    {
        s_impl.SetPartyDeck(ref partyId, deckID);
    }

    public static void SetPresenceBool(int field, bool val)
    {
        s_impl.SetPresenceBool(field, val);
    }

    public static void SetPresenceInt(int field, long val)
    {
        s_impl.SetPresenceInt(field, val);
    }

    public static void StartScenario(int scenario, long deckID)
    {
        s_impl.StartScenario(scenario, deckID);
    }

    public static void StartScenarioAI(int scenario, long deckID, long aiDeckID)
    {
        s_impl.StartScenarioAI(scenario, deckID, aiDeckID);
    }

    public static void UnrankedMatch(long deckID)
    {
        s_impl.UnrankedMatch(deckID);
    }

    public enum BNetGameType
    {
        UNKNOWN,
        FRIEND_1V1,
        AMM_1V1,
        DRAFT,
        VS_AI,
        TUTORIAL,
        ASYNC
    }

    public enum BNetState
    {
        BATTLE_NET_UNKNOWN,
        BATTLE_NET_LOGGING_IN,
        BATTLE_NET_TIMEOUT,
        BATTLE_NET_LOGIN_FAILED,
        BATTLE_NET_LOGGED_IN
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllChallengeInfo
    {
        public ulong challengeId;
        public bool isRetry;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllEntityId
    {
        public ulong hi;
        public ulong lo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllErrorInfo
    {
        public int feature;
        public int featureEvent;
        public uint code;
        public IntPtr name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllFriendsInfo
    {
        public int maxFriends;
        public int maxRecvInvites;
        public int maxSentInvites;
        public int friendsSize;
        public int updateSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllFriendsUpdate
    {
        public int action;
        public BattleNet.DllEntityId entity1;
        public BattleNet.DllEntityId entity2;
        public int int1;
        public IntPtr string1;
        public IntPtr string2;
        public IntPtr string3;
        public ulong long1;
        public ulong long2;
        public ulong long3;
        public bool bool1;
        public enum Action
        {
            UNKNOWN,
            FRIEND_ADDED,
            FRIEND_REMOVED,
            FRIEND_INVITE,
            FRIEND_INVITE_REMOVED,
            FRIEND_SENT_INVITE,
            FRIEND_SENT_INVITE_REMOVED,
            FRIEND_ROLE_CHANGE,
            FRIEND_ATTR_CHANGE,
            FRIEND_GAME_ADDED,
            FRIEND_GAME_REMOVED
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllGameServerInfo
    {
        public IntPtr Address;
        public int Port;
        public int GameHandle;
        public long ClientHandle;
        public IntPtr AuroraPassword;
        public IntPtr Version;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllInvitation
    {
        public BattleNet.DllInvitationId id;
        public BattleNet.DllEntityId inviterId;
        public IntPtr inviterName;
        public BattleNet.DllEntityId inviteeId;
        public IntPtr inviteeName;
        public IntPtr message;
        public ulong creationTimeMicrosec;
        public ulong expirationTimeMicrosec;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllInvitationId
    {
        public ulong val;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllPartyEvent
    {
        public IntPtr eventName;
        public IntPtr eventData;
        public BattleNet.DllEntityId partyId;
        public BattleNet.DllEntityId otherMemberId;
        public BattleNet.DllErrorInfo errorInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllPartyInfo
    {
        public int size;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllPresenceUpdate
    {
        public BattleNet.DllEntityId entityId;
        public IntPtr programId;
        public int groupId;
        public int fieldId;
        public long index;
        public bool newBool;
        public long newInt;
        public IntPtr newString;
        public BattleNet.DllEntityId newEntity;
        public bool m_valueCleared;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllQueueEvent
    {
        public int EventType;
        public int MinSeconds;
        public int MaxSeconds;
        public int BnetError;
        public BattleNet.DllGameServerInfo GameServer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllWhisper
    {
        public BattleNet.DllEntityId speakerId;
        public BattleNet.DllEntityId receiverId;
        public IntPtr message;
        public ulong timestampMicrosec;
        public BattleNet.DllErrorInfo errorInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DllWhisperInfo
    {
        public int whisperSize;
        public int sendResultsSize;
    }

    public class GameServerInfo
    {
        public string Address { get; set; }

        public string AuroraPassword { get; set; }

        public long ClientHandle { get; set; }

        public int GameHandle { get; set; }

        public int Port { get; set; }

        public string Version { get; set; }
    }

    public enum Implementation
    {
        DLL,
        CSHARP
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PresenceUpdate
    {
        public BattleNet.DllEntityId entityId;
        public BnetProgramId programId;
        public int groupId;
        public int fieldId;
        public long index;
        public bool newBool;
        public long newInt;
        public string newString;
        public BattleNet.DllEntityId newEntity;
        public void CopyFrom(BattleNet.DllPresenceUpdate update)
        {
            this.entityId = update.entityId;
            string stringVal = Marshal.PtrToStringAnsi(update.programId);
            this.programId = new BnetProgramId(stringVal);
            this.groupId = update.groupId;
            this.fieldId = update.fieldId;
            this.index = update.index;
            this.newBool = update.newBool;
            this.newInt = update.newInt;
            this.newString = DLLUtils.StringFromNativeUtf8(update.newString);
            this.newEntity = update.newEntity;
        }
    }

    public class QueueEvent
    {
        public QueueEvent(BattleNet.DllQueueEvent queueEvent)
        {
            this.EventType = (Type) queueEvent.EventType;
            this.MinSeconds = queueEvent.MinSeconds;
            this.MaxSeconds = queueEvent.MaxSeconds;
            this.BnetError = queueEvent.BnetError;
            if (this.EventType == Type.QUEUE_GAME_STARTED)
            {
                this.GameServer = new BattleNet.GameServerInfo();
                if (queueEvent.GameServer.Address != IntPtr.Zero)
                {
                    this.GameServer.Address = Marshal.PtrToStringAnsi(queueEvent.GameServer.Address);
                }
                if (queueEvent.GameServer.AuroraPassword != IntPtr.Zero)
                {
                    this.GameServer.AuroraPassword = Marshal.PtrToStringAnsi(queueEvent.GameServer.AuroraPassword);
                }
                this.GameServer.ClientHandle = queueEvent.GameServer.ClientHandle;
                this.GameServer.GameHandle = queueEvent.GameServer.GameHandle;
                this.GameServer.Port = queueEvent.GameServer.Port;
                if (queueEvent.GameServer.Version != IntPtr.Zero)
                {
                    this.GameServer.Version = Marshal.PtrToStringAnsi(queueEvent.GameServer.Version);
                }
            }
            else
            {
                this.GameServer = null;
            }
        }

        public QueueEvent(BattleNet.GameServerInfo gameServer)
        {
            this.EventType = Type.QUEUE_GAME_STARTED;
            this.MinSeconds = 0;
            this.MaxSeconds = 0;
            this.BnetError = 0;
            this.GameServer = gameServer;
        }

        public QueueEvent(Type t)
        {
            this.EventType = t;
            this.MinSeconds = 0;
            this.MaxSeconds = 0;
            this.BnetError = 0;
            this.GameServer = null;
        }

        public QueueEvent(Type t, int error)
        {
            this.EventType = t;
            this.MinSeconds = 0;
            this.MaxSeconds = 0;
            this.BnetError = error;
            this.GameServer = null;
        }

        public int BnetError { get; set; }

        public Type EventType { get; set; }

        public BattleNet.GameServerInfo GameServer { get; set; }

        public int MaxSeconds { get; set; }

        public int MinSeconds { get; set; }

        public enum Type
        {
            UNKNOWN,
            QUEUE_ENTER,
            QUEUE_LEAVE,
            QUEUE_DELAY,
            QUEUE_UPDATE,
            QUEUE_DELAY_ERROR,
            QUEUE_AMM_ERROR,
            QUEUE_WAIT_END,
            QUEUE_CANCEL,
            QUEUE_GAME_STARTED,
            ABORT_CLIENT_DROPPED
        }
    }

    public enum Version
    {
        Major = 0,
        Minor = 0,
        Patch = 0,
        Sku = 2
    }
}


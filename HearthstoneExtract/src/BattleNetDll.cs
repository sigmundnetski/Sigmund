using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class BattleNetDll : IBattleNet
{
    public static DelDllAcceptPartyInvite DllAcceptPartyInvite;
    public static DelDllAnswerChallenge DllAnswerChallenge;
    public static DelBattleNetStatus DllBattleNetStatus;
    public static DelDllCancelChallenge DllCancelChallenge;
    public static DelDllClearChallenges DllClearChallenges;
    public static DelClearErrors DllClearErrors;
    public static DelDllClearFriendsUpdates DllClearFriendsUpdates;
    public static DelDllClearPartyUpdates DllClearPartyUpdates;
    public static DelDllClearPresence DllClearPresence;
    public static DelDllClearWhispers DllClearWhispers;
    public static DelCloseAurora DllCloseAurora;
    public static DelConnectAurora DllConnectAurora;
    public static DelDllDeclinePartyInvite DllDeclinePartyInvite;
    public static DelDraftQueue DllDraftQueue;
    public static DelDllGetChallenges DllGetChallenges;
    public static DelGetErrors DllGetErrors;
    public static DelGetErrorsCount DllGetErrorsCount;
    public static DelDllGetFriendsInfo DllGetFriendsInfo;
    public static DelDllGetFriendsUpdates DllGetFriendsUpdates;
    public static DelGetMyGameAccountId DllGetMyGameAccountId;
    public static DelDllGetPartyUpdates DllGetPartyUpdates;
    public static DelDllGetPartyUpdatesInfo DllGetPartyUpdatesInfo;
    public static DelDllGetPresence DllGetPresence;
    public static DelGetQueueEvent DllGetQueueEvent;
    public static DelDllGetWhisperInfo DllGetWhisperInfo;
    public static DelDllGetWhispers DllGetWhispers;
    public static DelMakeMatch DllMakeMatch;
    public static DelDllManageFriendInvite DllManageFriendInvite;
    public static DelNextUtilPacket DllNextUtilPacket;
    public static DelDllNumChallenges DllNumChallenges;
    public static DelDllPresenceSize DllPresenceSize;
    public static DelProcessAurora DllProcessAurora;
    public static DelQueryAurora DllQueryAurora;
    public static DelDllRemoveFriend DllRemoveFriend;
    public static DelDllRescindPartyInvite DllRescindPartyInvite;
    public static DelDllSendFriendInvite DllSendFriendInvite;
    public static DelDllSendPartyInvite DllSendPartyInvite;
    public static DelSendUtilPacket DllSendUtilPacket;
    public static DelDllSendWhisper DllSendWhisper;
    public static DelDllSetPartyDeck DllSetPartyDeck;
    public static DelDllSetPresenceBool DllSetPresenceBool;
    public static DelDllSetPresenceInt DllSetPresenceInt;
    public static DelStartScenario DllStartScenario;
    public static DelStartScenarioAI DllStartScenarioAI;
    private IntPtr s_DLL = IntPtr.Zero;
    private bool s_initialized;

    public void AcceptPartyInvite(ref BattleNet.DllEntityId partyId)
    {
        DllAcceptPartyInvite(ref partyId);
    }

    public void AnswerChallenge(ulong challengeID, IntPtr answer)
    {
        DllAnswerChallenge(challengeID, answer);
    }

    public void AppQuit()
    {
        ConnectAPI.CloseAll();
        if (this.s_DLL != IntPtr.Zero)
        {
            if (DllCloseAurora != null)
            {
                this.CloseAurora();
            }
            if (!DLLUtils.FreeLibrary(this.s_DLL))
            {
                BattleNet.LogError("error unloading Connect.DLL");
            }
            this.s_DLL = IntPtr.Zero;
        }
    }

    public int BattleNetStatus()
    {
        return DllBattleNetStatus();
    }

    public void CancelChallenge(ulong challengeID)
    {
        DllCancelChallenge(challengeID);
    }

    public void ClearChallenges()
    {
        DllClearChallenges();
    }

    public void ClearErrors()
    {
        DllClearErrors();
    }

    public void ClearFriendsUpdates()
    {
        DllClearFriendsUpdates();
    }

    public void ClearPartyUpdates()
    {
        DllClearPartyUpdates();
    }

    public void ClearPresence()
    {
        DllClearPresence();
    }

    public void ClearWhispers()
    {
        DllClearWhispers();
    }

    public void CloseAurora()
    {
        DllCloseAurora();
    }

    public void ConnectAurora(bool fromEditor)
    {
        DllConnectAurora(fromEditor);
    }

    public void DeclinePartyInvite(ref BattleNet.DllEntityId partyId)
    {
        DllDeclinePartyInvite(ref partyId);
    }

    public void DraftQueue(bool join)
    {
        DllDraftQueue(join);
    }

    public void GetChallenges([Out] BattleNet.DllChallengeInfo[] challenges)
    {
        DllGetChallenges(challenges);
    }

    public void GetErrors([Out] BattleNet.DllErrorInfo[] errors)
    {
        DllGetErrors(errors);
    }

    public int GetErrorsCount()
    {
        return DllGetErrorsCount();
    }

    public void GetFriendsInfo(ref BattleNet.DllFriendsInfo info)
    {
        DllGetFriendsInfo(ref info);
    }

    public void GetFriendsUpdates([Out] BattleNet.DllFriendsUpdate[] updates)
    {
        DllGetFriendsUpdates(updates);
    }

    private IntPtr GetFunction(string name)
    {
        IntPtr procAddress = DLLUtils.GetProcAddress(this.s_DLL, name);
        if (procAddress == IntPtr.Zero)
        {
            BattleNet.LogError("could not load Connection." + name + "()");
            this.AppQuit();
        }
        return procAddress;
    }

    public BattleNet.Implementation GetImplementation()
    {
        return BattleNet.Implementation.DLL;
    }

    public BattleNet.DllEntityId GetMyGameAccountId()
    {
        return DllGetMyGameAccountId();
    }

    public void GetPartyUpdates([Out] BattleNet.DllPartyEvent[] updates)
    {
        DllGetPartyUpdates(updates);
    }

    public void GetPartyUpdatesInfo(ref BattleNet.DllPartyInfo info)
    {
        DllGetPartyUpdatesInfo(ref info);
    }

    public void GetPresence([Out] BattleNet.PresenceUpdate[] updates)
    {
        BattleNet.DllPresenceUpdate[] updateArray = new BattleNet.DllPresenceUpdate[updates.Length];
        DllGetPresence(updateArray);
        for (int i = 0; i < updates.Length; i++)
        {
            updates[i].CopyFrom(updateArray[i]);
        }
    }

    public BattleNet.QueueEvent GetQueueEvent()
    {
        BattleNet.DllQueueEvent queueEvent = new BattleNet.DllQueueEvent();
        if (DllGetQueueEvent(ref queueEvent))
        {
            return new BattleNet.QueueEvent(queueEvent);
        }
        return null;
    }

    public void GetWhisperInfo(ref BattleNet.DllWhisperInfo info)
    {
        DllGetWhisperInfo(ref info);
    }

    public void GetWhispers([Out] BattleNet.DllWhisper[] whispers)
    {
        DllGetWhispers(whispers);
    }

    public bool Init(bool fromEditor)
    {
        if (this.s_initialized)
        {
            return true;
        }
        if (this.s_DLL == IntPtr.Zero)
        {
            this.s_DLL = FileUtils.LoadPlugin("Connect");
            if (this.s_DLL == IntPtr.Zero)
            {
                BattleNet.LogError("could not load Connect.dll");
                return false;
            }
            DllConnectAurora = (DelConnectAurora) Marshal.GetDelegateForFunctionPointer(this.GetFunction("ConnectAurora"), typeof(DelConnectAurora));
            DllQueryAurora = (DelQueryAurora) Marshal.GetDelegateForFunctionPointer(this.GetFunction("QueryAurora"), typeof(DelQueryAurora));
            DllCloseAurora = (DelCloseAurora) Marshal.GetDelegateForFunctionPointer(this.GetFunction("CloseAurora"), typeof(DelCloseAurora));
            DllProcessAurora = (DelProcessAurora) Marshal.GetDelegateForFunctionPointer(this.GetFunction("ProcessAurora"), typeof(DelProcessAurora));
            DllSendUtilPacket = (DelSendUtilPacket) Marshal.GetDelegateForFunctionPointer(this.GetFunction("SendUtilPacket"), typeof(DelSendUtilPacket));
            DllBattleNetStatus = (DelBattleNetStatus) Marshal.GetDelegateForFunctionPointer(this.GetFunction("BattleNetStatus"), typeof(DelBattleNetStatus));
            DllNextUtilPacket = (DelNextUtilPacket) Marshal.GetDelegateForFunctionPointer(this.GetFunction("NextUtilPacket"), typeof(DelNextUtilPacket));
            DllGetErrorsCount = (DelGetErrorsCount) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetErrorsCount"), typeof(DelGetErrorsCount));
            DllGetErrors = (DelGetErrors) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetErrors"), typeof(DelGetErrors));
            DllClearErrors = (DelClearErrors) Marshal.GetDelegateForFunctionPointer(this.GetFunction("ClearErrors"), typeof(DelClearErrors));
            DllGetMyGameAccountId = (DelGetMyGameAccountId) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetMyGameAccountId"), typeof(DelGetMyGameAccountId));
            DllMakeMatch = (DelMakeMatch) Marshal.GetDelegateForFunctionPointer(this.GetFunction("MakeMatch"), typeof(DelMakeMatch));
            DllStartScenario = (DelStartScenario) Marshal.GetDelegateForFunctionPointer(this.GetFunction("StartScenario"), typeof(DelStartScenario));
            DllStartScenarioAI = (DelStartScenarioAI) Marshal.GetDelegateForFunctionPointer(this.GetFunction("StartScenarioAI"), typeof(DelStartScenarioAI));
            DllDraftQueue = (DelDraftQueue) Marshal.GetDelegateForFunctionPointer(this.GetFunction("DraftQueue"), typeof(DelDraftQueue));
            DllGetQueueEvent = (DelGetQueueEvent) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetQueueEvent"), typeof(DelGetQueueEvent));
            DllGetFriendsInfo = (DelDllGetFriendsInfo) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetFriendInfo"), typeof(DelDllGetFriendsInfo));
            DllClearFriendsUpdates = (DelDllClearFriendsUpdates) Marshal.GetDelegateForFunctionPointer(this.GetFunction("ClearFriendUpdates"), typeof(DelDllClearFriendsUpdates));
            DllGetFriendsUpdates = (DelDllGetFriendsUpdates) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetFriendUpdates"), typeof(DelDllGetFriendsUpdates));
            DllSendFriendInvite = (DelDllSendFriendInvite) Marshal.GetDelegateForFunctionPointer(this.GetFunction("SendInvite"), typeof(DelDllSendFriendInvite));
            DllManageFriendInvite = (DelDllManageFriendInvite) Marshal.GetDelegateForFunctionPointer(this.GetFunction("ManageInvite"), typeof(DelDllManageFriendInvite));
            DllRemoveFriend = (DelDllRemoveFriend) Marshal.GetDelegateForFunctionPointer(this.GetFunction("RemoveFriend"), typeof(DelDllRemoveFriend));
            DllPresenceSize = (DelDllPresenceSize) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetPresenceUpdatesSize"), typeof(DelDllPresenceSize));
            DllClearPresence = (DelDllClearPresence) Marshal.GetDelegateForFunctionPointer(this.GetFunction("ClearPresenceUpdates"), typeof(DelDllClearPresence));
            DllGetPresence = (DelDllGetPresence) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetPresenceUpdates"), typeof(DelDllGetPresence));
            DllSetPresenceBool = (DelDllSetPresenceBool) Marshal.GetDelegateForFunctionPointer(this.GetFunction("PublishPresenceBool"), typeof(DelDllSetPresenceBool));
            DllSetPresenceInt = (DelDllSetPresenceInt) Marshal.GetDelegateForFunctionPointer(this.GetFunction("PublishPresenceInt"), typeof(DelDllSetPresenceInt));
            DllNumChallenges = (DelDllNumChallenges) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetNumPasswordChallenges"), typeof(DelDllNumChallenges));
            DllClearChallenges = (DelDllClearChallenges) Marshal.GetDelegateForFunctionPointer(this.GetFunction("ClearPasswordChallenges"), typeof(DelDllClearChallenges));
            DllGetChallenges = (DelDllGetChallenges) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetChallenges"), typeof(DelDllGetChallenges));
            DllAnswerChallenge = (DelDllAnswerChallenge) Marshal.GetDelegateForFunctionPointer(this.GetFunction("AnswerChallenge"), typeof(DelDllAnswerChallenge));
            DllCancelChallenge = (DelDllCancelChallenge) Marshal.GetDelegateForFunctionPointer(this.GetFunction("CancelChallenge"), typeof(DelDllCancelChallenge));
            DllSendPartyInvite = (DelDllSendPartyInvite) Marshal.GetDelegateForFunctionPointer(this.GetFunction("SendPartyInvite"), typeof(DelDllSendPartyInvite));
            DllSetPartyDeck = (DelDllSetPartyDeck) Marshal.GetDelegateForFunctionPointer(this.GetFunction("SetPartyDeck"), typeof(DelDllSetPartyDeck));
            DllGetPartyUpdatesInfo = (DelDllGetPartyUpdatesInfo) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetPartyUpdatesInfo"), typeof(DelDllGetPartyUpdatesInfo));
            DllGetPartyUpdates = (DelDllGetPartyUpdates) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetPartyUpdates"), typeof(DelDllGetPartyUpdates));
            DllClearPartyUpdates = (DelDllClearPartyUpdates) Marshal.GetDelegateForFunctionPointer(this.GetFunction("ClearPartyUpdates"), typeof(DelDllClearPartyUpdates));
            DllDeclinePartyInvite = (DelDllDeclinePartyInvite) Marshal.GetDelegateForFunctionPointer(this.GetFunction("DeclinePartyInvite"), typeof(DelDllDeclinePartyInvite));
            DllAcceptPartyInvite = (DelDllAcceptPartyInvite) Marshal.GetDelegateForFunctionPointer(this.GetFunction("AcceptPartyInvite"), typeof(DelDllAcceptPartyInvite));
            DllRescindPartyInvite = (DelDllRescindPartyInvite) Marshal.GetDelegateForFunctionPointer(this.GetFunction("RescindPartyInvite"), typeof(DelDllRescindPartyInvite));
            DllSendWhisper = (DelDllSendWhisper) Marshal.GetDelegateForFunctionPointer(this.GetFunction("SendWhisper"), typeof(DelDllSendWhisper));
            DllGetWhisperInfo = (DelDllGetWhisperInfo) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetWhisperInfo"), typeof(DelDllGetWhisperInfo));
            DllGetWhispers = (DelDllGetWhispers) Marshal.GetDelegateForFunctionPointer(this.GetFunction("GetWhispers"), typeof(DelDllGetWhispers));
            DllClearWhispers = (DelDllClearWhispers) Marshal.GetDelegateForFunctionPointer(this.GetFunction("ClearWhispers"), typeof(DelDllClearWhispers));
        }
        DebugConsole.Get().Init();
        DllConnectAurora(fromEditor);
        this.s_initialized = ConnectAPI.ConnectInit();
        return this.s_initialized;
    }

    public void MakeMatch(long deckID)
    {
        DllMakeMatch(deckID, false);
    }

    public void ManageFriendInvite(int action, ulong inviteId)
    {
        DllManageFriendInvite(action, inviteId);
    }

    public PegasusPacket NextUtilPacket()
    {
        AuroraPacket packet = new AuroraPacket();
        if (DllNextUtilPacket(ref packet))
        {
            int size = packet.size;
            byte[] destination = new byte[size];
            Marshal.Copy(packet.payload, destination, 0, size);
            return new PegasusPacket(packet.packetId, size, destination);
        }
        return null;
    }

    public int NumChallenges()
    {
        return DllNumChallenges();
    }

    public int PresenceSize()
    {
        return DllPresenceSize();
    }

    public void ProcessAurora()
    {
        DllProcessAurora();
    }

    public void QueryAurora()
    {
        DllQueryAurora();
    }

    public void RemoveFriend(ref BattleNet.DllEntityId account)
    {
        DllRemoveFriend(ref account);
    }

    public void RescindPartyInvite(ref BattleNet.DllEntityId partyId)
    {
        DllRescindPartyInvite(ref partyId);
    }

    public void SendFriendInvite(IntPtr intiver, IntPtr invitee, bool byEmail)
    {
        DllSendFriendInvite(intiver, invitee, byEmail);
    }

    public void SendPartyInvite(ref BattleNet.DllEntityId gameAccount)
    {
        DllSendPartyInvite(ref gameAccount);
    }

    public void SendUtilPacket(int packetId, int systemId, byte[] bytes, int size, int subID)
    {
        DllSendUtilPacket(packetId, systemId, bytes, size, subID);
    }

    public void SendWhisper(ref BattleNet.DllEntityId gameAccount, IntPtr message)
    {
        DllSendWhisper(ref gameAccount, message);
    }

    public void SetPartyDeck(ref BattleNet.DllEntityId partyId, long deckID)
    {
        DllSetPartyDeck(ref partyId, deckID);
    }

    public void SetPresenceBool(int field, bool val)
    {
        DllSetPresenceBool(field, val);
    }

    public void SetPresenceInt(int field, long val)
    {
        DllSetPresenceInt(field, val);
    }

    public void StartScenario(int scenario, long deckID)
    {
        DllStartScenario(scenario, deckID);
    }

    public void StartScenarioAI(int scenario, long deckID, long aiDeckID)
    {
        DllStartScenarioAI(scenario, deckID, aiDeckID);
    }

    public void UnrankedMatch(long deckID)
    {
        DllMakeMatch(deckID, true);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AuroraPacket
    {
        public int packetId;
        public IntPtr payload;
        public int size;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int DelBattleNetStatus();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelClearErrors();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelCloseAurora();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool DelConnectAurora(bool fromEditor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllAcceptPartyInvite(ref BattleNet.DllEntityId partyId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllAnswerChallenge(ulong challengeID, IntPtr answer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllCancelChallenge(ulong challengeID);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllClearChallenges();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllClearFriendsUpdates();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllClearPartyUpdates();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllClearPresence();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllClearWhispers();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllDeclinePartyInvite(ref BattleNet.DllEntityId partyId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllGetChallenges([Out] BattleNet.DllChallengeInfo[] challenges);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllGetFriendsInfo(ref BattleNet.DllFriendsInfo info);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllGetFriendsUpdates([Out] BattleNet.DllFriendsUpdate[] updates);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllGetPartyUpdates([Out] BattleNet.DllPartyEvent[] updates);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllGetPartyUpdatesInfo(ref BattleNet.DllPartyInfo info);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllGetPresence([Out] BattleNet.DllPresenceUpdate[] updates);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllGetWhisperInfo(ref BattleNet.DllWhisperInfo info);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllGetWhispers([Out] BattleNet.DllWhisper[] whispers);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllManageFriendInvite(int action, ulong inviteId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int DelDllNumChallenges();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int DelDllPresenceSize();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllRemoveFriend(ref BattleNet.DllEntityId account);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllRescindPartyInvite(ref BattleNet.DllEntityId partyId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllSendFriendInvite(IntPtr intiver, IntPtr invitee, bool byEmail);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllSendPartyInvite(ref BattleNet.DllEntityId gameAccount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllSendWhisper(ref BattleNet.DllEntityId gameAccount, IntPtr message);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllSetPartyDeck(ref BattleNet.DllEntityId partyId, long deckID);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllSetPresenceBool(int field, bool val);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDllSetPresenceInt(int field, long val);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelDraftQueue(bool join);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelGetErrors([Out] BattleNet.DllErrorInfo[] errors);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int DelGetErrorsCount();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate BattleNet.DllEntityId DelGetMyGameAccountId();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool DelGetQueueEvent(ref BattleNet.DllQueueEvent queueEvent);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelMakeMatch(long deckID, bool unranked);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool DelNextUtilPacket(ref BattleNetDll.AuroraPacket packet);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelProcessAurora();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool DelQueryAurora();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelSendUtilPacket(int packetId, int systemId, byte[] bytes, int size, int subID);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelStartScenario(int scenario, long deckID);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DelStartScenarioAI(int scenario, long deckID, long aiDeckID);
}


using System;
using System.Runtime.InteropServices;

public interface IBattleNet
{
    void AcceptPartyInvite(ref BattleNet.DllEntityId partyId);
    void AnswerChallenge(ulong challengeID, IntPtr answer);
    void AppQuit();
    int BattleNetStatus();
    void CancelChallenge(ulong challengeID);
    void ClearChallenges();
    void ClearErrors();
    void ClearFriendsUpdates();
    void ClearPartyUpdates();
    void ClearPresence();
    void ClearWhispers();
    void CloseAurora();
    void DeclinePartyInvite(ref BattleNet.DllEntityId partyId);
    void DraftQueue(bool join);
    void GetChallenges([Out] BattleNet.DllChallengeInfo[] challenges);
    void GetErrors([Out] BattleNet.DllErrorInfo[] errors);
    int GetErrorsCount();
    void GetFriendsInfo(ref BattleNet.DllFriendsInfo info);
    void GetFriendsUpdates([Out] BattleNet.DllFriendsUpdate[] updates);
    BattleNet.Implementation GetImplementation();
    BattleNet.DllEntityId GetMyGameAccountId();
    void GetPartyUpdates([Out] BattleNet.DllPartyEvent[] updates);
    void GetPartyUpdatesInfo(ref BattleNet.DllPartyInfo info);
    void GetPresence([Out] BattleNet.PresenceUpdate[] updates);
    BattleNet.QueueEvent GetQueueEvent();
    void GetWhisperInfo(ref BattleNet.DllWhisperInfo info);
    void GetWhispers([Out] BattleNet.DllWhisper[] whispers);
    bool Init(bool fromEditor);
    void MakeMatch(long deckID);
    void ManageFriendInvite(int action, ulong inviteId);
    PegasusPacket NextUtilPacket();
    int NumChallenges();
    int PresenceSize();
    void ProcessAurora();
    void QueryAurora();
    void RemoveFriend(ref BattleNet.DllEntityId account);
    void RescindPartyInvite(ref BattleNet.DllEntityId partyId);
    void SendFriendInvite(IntPtr inviter, IntPtr invitee, bool byEmail);
    void SendPartyInvite(ref BattleNet.DllEntityId gameAccount);
    void SendUtilPacket(int packetId, int systemId, byte[] bytes, int size, int subID);
    void SendWhisper(ref BattleNet.DllEntityId gameAccount, IntPtr message);
    void SetPartyDeck(ref BattleNet.DllEntityId partyId, long deckID);
    void SetPresenceBool(int field, bool val);
    void SetPresenceInt(int field, long val);
    void StartScenario(int scenario, long deckID);
    void StartScenarioAI(int scenario, long deckID, long aiDeckID);
    void UnrankedMatch(long deckID);
}


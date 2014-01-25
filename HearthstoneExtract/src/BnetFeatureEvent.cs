using System;

public enum BnetFeatureEvent
{
    Auth_Logon,
    Auth_OnFinish,
    Friends_Created,
    Friends_OnCreated,
    Friends_OnAcceptInvitation,
    Friends_OnRevokeInvitation,
    Friends_OnDeclineInvitation,
    Friends_OnIgnoreInvitation,
    Friends_OnSendInvitation,
    Friends_OnRemoveFriend,
    Games_Created,
    Games_OnCreated,
    Games_OnQueueLeft,
    Games_OnMatchmakerEnd,
    Games_OnEnteredGame,
    Games_OnFindGame,
    Games_OnCancelGame,
    Games_OnClientRequest,
    LocalStore_Created,
    LocalStore_OnCreated,
    Party_Created,
    Party_OnCreated,
    Party_OnCreateParty,
    Presence_Created,
    Presence_OnCreated,
    Presence_OnRegisterConsumer,
    Whisper_Created,
    Whisper_OnCreated,
    Whisper_OnSend,
    Bnet_OnConnected,
    Bnet_OnDisconnected,
    Challenge_Created,
    Challenge_OnCreated
}


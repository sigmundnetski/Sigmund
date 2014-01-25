using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FriendChallengeMgr : MonoBehaviour
{
    private AlertPopup m_challengeDialog;
    private BnetPlayer m_challengee;
    private bool m_challengeeAccepted;
    private bool m_challengeeDeckSelected;
    private BnetPlayer m_challenger;
    private bool m_challengerDeckSelected;
    private BnetGameAccountId m_challengerId;
    private bool m_challengerPending;
    private List<ChangedListener> m_changedListeners = new List<ChangedListener>();
    private bool m_myPlayerReady;
    private bool m_netCacheReady;
    private BnetEntityId m_partyId;
    private static FriendChallengeMgr s_instance;

    public void AcceptChallenge()
    {
        if (this.DidReceiveChallenge())
        {
            this.m_challengeeAccepted = true;
            Network.AcceptFriendChallenge(this.m_partyId);
            this.FireChangedEvent(FriendChallengeEvent.I_ACCEPTED_CHALLENGE, this.m_challenger);
        }
    }

    public bool AddChangedListener(ChangedCallback callback)
    {
        return this.AddChangedListener(callback, null);
    }

    public bool AddChangedListener(ChangedCallback callback, object userData)
    {
        ChangedListener item = new ChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_changedListeners.Contains(item))
        {
            return false;
        }
        this.m_changedListeners.Add(item);
        return true;
    }

    public bool AmIAvailable()
    {
        if (!this.m_netCacheReady)
        {
            return false;
        }
        if (!this.m_myPlayerReady)
        {
            return false;
        }
        BnetGameAccount hearthstoneGameAccount = BnetPresenceMgr.Get().GetMyPlayer().GetHearthstoneGameAccount();
        if (hearthstoneGameAccount == null)
        {
            return false;
        }
        return hearthstoneGameAccount.CanBeInvitedToGame();
    }

    private void Awake()
    {
        s_instance = this;
    }

    public void CancelChallenge()
    {
        if (this.HasChallenge())
        {
            if (this.DidSendChallenge())
            {
                this.RescindChallenge();
            }
            else if (this.DidReceiveChallenge())
            {
                this.DeclineChallenge();
            }
        }
    }

    public bool CanChallenge(BnetPlayer player)
    {
        if (player == BnetPresenceMgr.Get().GetMyPlayer())
        {
            return false;
        }
        if (!this.AmIAvailable())
        {
            return false;
        }
        BnetGameAccount hearthstoneGameAccount = player.GetHearthstoneGameAccount();
        if (hearthstoneGameAccount == null)
        {
            return false;
        }
        if (!hearthstoneGameAccount.IsOnline())
        {
            return false;
        }
        if (!hearthstoneGameAccount.CanBeInvitedToGame())
        {
            return false;
        }
        return true;
    }

    private void CleanUpChallengeData()
    {
        this.m_partyId = null;
        this.m_challengerId = null;
        this.m_challengerPending = false;
        this.m_challenger = null;
        this.m_challengerDeckSelected = false;
        this.m_challengee = null;
        this.m_challengeeAccepted = false;
        this.m_challengeeDeckSelected = false;
        this.UpdateMyAvailability();
    }

    public void DeclineChallenge()
    {
        if (this.DidReceiveChallenge())
        {
            Network.DeclineFriendChallenge(this.m_partyId);
            BnetPlayer challenger = this.m_challenger;
            this.CleanUpChallengeData();
            this.FireChangedEvent(FriendChallengeEvent.I_DECLINED_CHALLENGE, challenger);
        }
    }

    public void DeselectDeck()
    {
        if (this.DidSendChallenge() && this.m_challengerDeckSelected)
        {
            this.m_challengerDeckSelected = false;
        }
        else if (this.DidReceiveChallenge() && this.m_challengeeDeckSelected)
        {
            this.m_challengeeDeckSelected = false;
        }
        else
        {
            return;
        }
        Network.ChooseFriendChallengeDeck(this.m_partyId, 0L);
        this.FireChangedEvent(FriendChallengeEvent.DESELECTED_DECK, BnetPresenceMgr.Get().GetMyPlayer());
    }

    public bool DidISelectDeck()
    {
        if (this.DidSendChallenge())
        {
            return this.m_challengerDeckSelected;
        }
        if (this.DidReceiveChallenge())
        {
            return this.m_challengeeDeckSelected;
        }
        return true;
    }

    public bool DidOpponentSelectDeck()
    {
        if (this.DidSendChallenge())
        {
            return this.m_challengeeDeckSelected;
        }
        if (this.DidReceiveChallenge())
        {
            return this.m_challengerDeckSelected;
        }
        return true;
    }

    public bool DidReceiveChallenge()
    {
        return (this.m_challengerPending || ((this.m_challenger != null) && (this.m_challengee == BnetPresenceMgr.Get().GetMyPlayer())));
    }

    public bool DidSendChallenge()
    {
        return ((this.m_challengee != null) && (this.m_challenger == BnetPresenceMgr.Get().GetMyPlayer()));
    }

    private void FireChangedEvent(FriendChallengeEvent challengeEvent, BnetPlayer player)
    {
        foreach (ChangedListener listener in this.m_changedListeners.ToArray())
        {
            listener.Fire(challengeEvent, player);
        }
    }

    public static FriendChallengeMgr Get()
    {
        return s_instance;
    }

    public BnetPlayer GetChallengee()
    {
        return this.m_challengee;
    }

    public BnetPlayer GetChallenger()
    {
        return this.m_challenger;
    }

    public BnetPlayer GetMyOpponent()
    {
        BnetPlayer myPlayer = BnetPresenceMgr.Get().GetMyPlayer();
        return this.GetOpponent(myPlayer);
    }

    public BnetPlayer GetOpponent(BnetPlayer player)
    {
        if (player == this.m_challenger)
        {
            return this.m_challengee;
        }
        if (player == this.m_challengee)
        {
            return this.m_challenger;
        }
        return null;
    }

    private bool HasAvailabilityBlocker()
    {
        if (!this.m_netCacheReady)
        {
            return true;
        }
        if (!this.m_myPlayerReady)
        {
            return true;
        }
        if (this.HasChallenge())
        {
            return true;
        }
        if (Network.IsMatching())
        {
            return true;
        }
        if (Network.IsInDraftQueue())
        {
            return true;
        }
        if (SceneMgr.Get().IsModeRequested(SceneMgr.Mode.FATAL_ERROR))
        {
            return true;
        }
        if (SceneMgr.Get().IsModeRequested(SceneMgr.Mode.LOGIN))
        {
            return true;
        }
        if (SceneMgr.Get().GetMode() == SceneMgr.Mode.STARTUP)
        {
            return true;
        }
        if (SceneMgr.Get().IsModeRequested(SceneMgr.Mode.GAMEPLAY) && !MissionMgr.Get().IsPlayingAI())
        {
            return true;
        }
        NetCache.NetCacheProfileProgress netObject = NetCache.Get().GetNetObject<NetCache.NetCacheProfileProgress>();
        return ((netObject == null) || !MissionMgr.Get().AreAllMissionsComplete(netObject.CampaignProgress));
    }

    public bool HasChallenge()
    {
        return (this.DidSendChallenge() || this.DidReceiveChallenge());
    }

    private void OnChallengeChanged(FriendChallengeEvent challengeEvent, BnetPlayer player, object userData)
    {
        switch (challengeEvent)
        {
            case FriendChallengeEvent.I_SENT_CHALLENGE:
                this.ShowISentChallengeDialog(player);
                break;

            case FriendChallengeEvent.OPPONENT_ACCEPTED_CHALLENGE:
                this.StartDeckSelection();
                break;

            case FriendChallengeEvent.OPPONENT_DECLINED_CHALLENGE:
                this.ShowOpponentDeclinedChallengeDialog(player);
                break;

            case FriendChallengeEvent.I_RECEIVED_CHALLENGE:
                this.ShowIReceivedChallengeDialog(player);
                break;

            case FriendChallengeEvent.I_ACCEPTED_CHALLENGE:
                this.StartDeckSelection();
                break;

            case FriendChallengeEvent.OPPONENT_RESCINDED_CHALLENGE:
                this.ShowOpponentCanceledChallengeDialog(player);
                break;

            case FriendChallengeEvent.OPPONENT_CANCELED_CHALLENGE:
                this.ShowOpponentCanceledChallengeDialog(player);
                break;

            case FriendChallengeEvent.OPPONENT_WENT_OFFLINE:
                this.ShowOpponentCanceledChallengeDialog(player);
                break;

            case FriendChallengeEvent.OPPONENT_REMOVED_FROM_FRIENDS:
                this.ShowOpponentRemovedFromFriendsDialog(player);
                break;
        }
    }

    private bool OnChallengeReceivedDialogProcessed(DialogBase dialog, object userData)
    {
        if (!this.HasChallenge())
        {
            return false;
        }
        this.m_challengeDialog = (AlertPopup) dialog;
        return true;
    }

    private void OnChallengeReceivedDialogResponse(AlertPopup.Response response, object userData)
    {
        this.m_challengeDialog = null;
        if (response == AlertPopup.Response.CANCEL)
        {
            this.DeclineChallenge();
        }
        else
        {
            this.AcceptChallenge();
        }
    }

    private bool OnChallengeSentDialogProcessed(DialogBase dialog, object userData)
    {
        if (!this.HasChallenge())
        {
            return false;
        }
        this.m_challengeDialog = (AlertPopup) dialog;
        return true;
    }

    private void OnChallengeSentDialogResponse(AlertPopup.Response response, object userData)
    {
        this.m_challengeDialog = null;
        this.RescindChallenge();
    }

    public void OnEnteredDraftQueue()
    {
        this.UpdateMyAvailability();
    }

    public void OnEnteredMatchmakerQueue()
    {
        this.UpdateMyAvailability();
    }

    private void OnFriendsChanged(BnetFriendChangelist changelist, object userData)
    {
        if (this.HasChallenge())
        {
            List<BnetPlayer> removedFriends = changelist.GetRemovedFriends();
            if (removedFriends != null)
            {
                BnetPlayer opponent = this.GetOpponent(BnetPresenceMgr.Get().GetMyPlayer());
                if (opponent != null)
                {
                    foreach (BnetPlayer player2 in removedFriends)
                    {
                        if (player2 == opponent)
                        {
                            this.CleanUpChallengeData();
                            this.FireChangedEvent(FriendChallengeEvent.OPPONENT_REMOVED_FROM_FRIENDS, opponent);
                            break;
                        }
                    }
                }
            }
        }
    }

    public void OnLeftDraftQueue()
    {
        this.UpdateMyAvailability();
    }

    public void OnLeftMatchmakerQueue()
    {
        this.UpdateMyAvailability();
    }

    public void OnLoggedIn()
    {
        Network.Get().SetPartyHandler(new Network.PartyHandler(this.OnPartyUpdate));
        NetCache.Get().RegisterFriendChallenge(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        SceneMgr.Get().RegisterSceneUnloadedEvent(new SceneMgr.SceneUnloadedCallback(this.OnSceneUnloaded));
        SceneMgr.Get().RegisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
        BnetPresenceMgr.Get().AddPlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
        BnetFriendMgr.Get().AddChangeListener(new BnetFriendMgr.ChangeCallback(this.OnFriendsChanged));
        this.AddChangedListener(new ChangedCallback(this.OnChallengeChanged));
    }

    private void OnNetCacheReady()
    {
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        this.m_netCacheReady = true;
        if (SceneMgr.Get().GetMode() != SceneMgr.Mode.FATAL_ERROR)
        {
            this.UpdateMyAvailability();
        }
    }

    private void OnPartyUpdate(BattleNet.DllPartyEvent[] dllEvents)
    {
        for (int i = 0; i < dllEvents.Length; i++)
        {
            BattleNet.DllPartyEvent event2 = dllEvents[i];
            string str = DLLUtils.StringFromNativeUtf8(event2.eventName);
            string str2 = DLLUtils.StringFromNativeUtf8(event2.eventData);
            BnetEntityId partyId = BnetEntityId.CreateFromDll(event2.partyId);
            BnetGameAccountId otherMemberId = BnetGameAccountId.CreateFromDll(event2.otherMemberId);
            if (str == "s1")
            {
                switch (str2)
                {
                    case "wait":
                        this.m_partyId = partyId;
                        break;

                    case "deck":
                        if (this.DidReceiveChallenge() && this.m_challengerDeckSelected)
                        {
                            this.m_challengerDeckSelected = false;
                            this.FireChangedEvent(FriendChallengeEvent.DESELECTED_DECK, this.m_challenger);
                        }
                        break;

                    case "game":
                        if (this.DidReceiveChallenge())
                        {
                            this.m_challengerDeckSelected = true;
                            this.FireChangedEvent(FriendChallengeEvent.SELECTED_DECK, this.m_challenger);
                        }
                        break;

                    case "goto":
                        this.m_challengerDeckSelected = false;
                        break;
                }
            }
            else if (str == "s2")
            {
                switch (str2)
                {
                    case "wait":
                        this.OnPartyUpdate_JoinedParty(partyId, otherMemberId);
                        goto Label_027B;

                    case "deck":
                        if (this.DidSendChallenge())
                        {
                            if (this.m_challengeeAccepted)
                            {
                                this.m_challengeeDeckSelected = false;
                                this.FireChangedEvent(FriendChallengeEvent.DESELECTED_DECK, this.m_challengee);
                            }
                            else
                            {
                                this.m_challengeeAccepted = true;
                                this.FireChangedEvent(FriendChallengeEvent.OPPONENT_ACCEPTED_CHALLENGE, this.m_challengee);
                            }
                        }
                        goto Label_027B;

                    case "game":
                        if (this.DidSendChallenge())
                        {
                            this.m_challengeeDeckSelected = true;
                            this.FireChangedEvent(FriendChallengeEvent.SELECTED_DECK, this.m_challengee);
                        }
                        break;

                    case "goto":
                        this.m_challengeeDeckSelected = false;
                        break;
                }
            Label_027B:;
            }
            else if (str == "left")
            {
                if (this.DidSendChallenge())
                {
                    BnetPlayer challengee = this.m_challengee;
                    bool challengeeAccepted = this.m_challengeeAccepted;
                    this.CleanUpChallengeData();
                    if (challengeeAccepted)
                    {
                        this.FireChangedEvent(FriendChallengeEvent.OPPONENT_CANCELED_CHALLENGE, challengee);
                    }
                    else
                    {
                        this.FireChangedEvent(FriendChallengeEvent.OPPONENT_DECLINED_CHALLENGE, challengee);
                    }
                }
                else if (this.DidReceiveChallenge())
                {
                    BnetPlayer challenger = this.m_challenger;
                    bool flag2 = this.m_challengeeAccepted;
                    this.CleanUpChallengeData();
                    if (challenger != null)
                    {
                        if (flag2)
                        {
                            this.FireChangedEvent(FriendChallengeEvent.OPPONENT_CANCELED_CHALLENGE, challenger);
                        }
                        else
                        {
                            this.FireChangedEvent(FriendChallengeEvent.OPPONENT_RESCINDED_CHALLENGE, challenger);
                        }
                    }
                }
            }
        }
    }

    private void OnPartyUpdate_JoinedParty(BnetEntityId partyId, BnetGameAccountId otherMemberId)
    {
        if (!this.DidSendChallenge() || (this.m_challengee.GetHearthstoneGameAccount().GetId() != otherMemberId))
        {
            if (!this.AmIAvailable())
            {
                Network.DeclineFriendChallenge(partyId);
            }
            else
            {
                this.m_partyId = partyId;
                this.m_challengerId = otherMemberId;
                this.m_challenger = BnetPresenceMgr.Get().GetPlayer(this.m_challengerId);
                this.m_challengee = BnetPresenceMgr.Get().GetMyPlayer();
                if ((this.m_challenger == null) || !this.m_challenger.IsDisplayable())
                {
                    this.m_challengerPending = true;
                    this.UpdateMyAvailability();
                }
                else
                {
                    this.UpdateMyAvailability();
                    this.FireChangedEvent(FriendChallengeEvent.I_RECEIVED_CHALLENGE, this.m_challenger);
                }
            }
        }
    }

    private void OnPlayersChanged(BnetPlayerChangelist changelist, object userData)
    {
        BnetPlayer myPlayer = BnetPresenceMgr.Get().GetMyPlayer();
        if (changelist.FindChange(myPlayer) != null)
        {
            if ((myPlayer.GetHearthstoneGameAccount() != null) && !this.m_myPlayerReady)
            {
                this.m_myPlayerReady = true;
                this.UpdateMyAvailability();
            }
            if (!this.AmIAvailable() && this.m_challengerPending)
            {
                Network.DeclineFriendChallenge(this.m_partyId);
                this.CleanUpChallengeData();
            }
        }
        if (this.m_challengerPending)
        {
            BnetPlayerChange change = changelist.FindChange(this.m_challengerId);
            if (change != null)
            {
                BnetPlayer player = change.GetPlayer();
                if (!player.IsOnline())
                {
                    this.CleanUpChallengeData();
                }
                else if (player.IsDisplayable())
                {
                    this.m_challenger = player;
                    this.m_challengerPending = false;
                    this.FireChangedEvent(FriendChallengeEvent.I_RECEIVED_CHALLENGE, this.m_challenger);
                }
            }
        }
        else if (this.HasChallenge())
        {
            BnetPlayer myOpponent = this.GetMyOpponent();
            if ((changelist.FindChange(myOpponent) != null) && !myOpponent.IsOnline())
            {
                this.CleanUpChallengeData();
                this.FireChangedEvent(FriendChallengeEvent.OPPONENT_WENT_OFFLINE, myOpponent);
            }
        }
    }

    private void OnSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
        SceneMgr.Mode prevMode = SceneMgr.Get().GetPrevMode();
        if ((mode != SceneMgr.Mode.GAMEPLAY) && (prevMode == SceneMgr.Mode.GAMEPLAY))
        {
            this.m_netCacheReady = false;
            if (mode == SceneMgr.Mode.FRIENDLY)
            {
                this.UpdateMyAvailability();
            }
            else
            {
                this.CleanUpChallengeData();
            }
            NetCache.Get().RegisterFriendChallenge(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        }
    }

    private void OnSceneUnloaded(SceneMgr.Mode prevMode, Scene prevScene, object userData)
    {
        if (Network.IsLoggedIn() && (prevMode != SceneMgr.Mode.GAMEPLAY))
        {
            this.UpdateMyAvailability();
        }
        if (SceneMgr.Get().GetMode() == SceneMgr.Mode.FATAL_ERROR)
        {
            SceneMgr.Get().UnregisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
        }
    }

    public bool RemoveChangedListener(ChangedCallback callback)
    {
        return this.RemoveChangedListener(callback, null);
    }

    public bool RemoveChangedListener(ChangedCallback callback, object userData)
    {
        ChangedListener item = new ChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_changedListeners.Remove(item);
    }

    public void RescindChallenge()
    {
        if (this.DidSendChallenge())
        {
            Network.RescindFriendChallenge(this.m_partyId);
            BnetPlayer challengee = this.m_challengee;
            this.CleanUpChallengeData();
            this.FireChangedEvent(FriendChallengeEvent.I_RESCINDED_CHALLENGE, challengee);
        }
    }

    public void SelectDeck(long deckId)
    {
        if (this.DidSendChallenge())
        {
            this.m_challengerDeckSelected = true;
        }
        else if (this.DidReceiveChallenge())
        {
            this.m_challengeeDeckSelected = true;
        }
        else
        {
            return;
        }
        Network.ChooseFriendChallengeDeck(this.m_partyId, deckId);
        this.FireChangedEvent(FriendChallengeEvent.SELECTED_DECK, BnetPresenceMgr.Get().GetMyPlayer());
    }

    public void SendChallenge(BnetPlayer player)
    {
        if (this.CanChallenge(player))
        {
            this.m_challenger = BnetPresenceMgr.Get().GetMyPlayer();
            this.m_challengerId = this.m_challenger.GetHearthstoneGameAccount().GetId();
            this.m_challengee = player;
            Network.SendFriendChallenge(player.GetHearthstoneGameAccount().GetId());
            this.UpdateMyAvailability();
            this.FireChangedEvent(FriendChallengeEvent.I_SENT_CHALLENGE, player);
        }
    }

    private void ShowIReceivedChallengeDialog(BnetPlayer challenger)
    {
        AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
            m_headerText = GameStrings.Get("GLOBAL_FRIEND_CHALLENGE_HEADER")
        };
        object[] args = new object[] { FriendUtils.GetUniqueName(challenger) };
        info.m_text = GameStrings.Format("GLOBAL_FRIEND_CHALLENGE_RECEIVED", args);
        info.m_confirmText = GameStrings.Get("GLOBAL_FRIEND_CHALLENGE_ACCEPT");
        info.m_cancelText = GameStrings.Get("GLOBAL_FRIEND_CHALLENGE_DECLINE");
        info.m_showAlertIcon = false;
        info.m_responseDisplay = AlertPopup.ResponseDisplay.CONFIRM_CANCEL;
        info.m_responseCallback = new AlertPopup.ResponseCallback(this.OnChallengeReceivedDialogResponse);
        DialogManager.Get().ShowPopup(info, new DialogManager.DialogProcessCallback(this.OnChallengeReceivedDialogProcessed));
    }

    private void ShowISentChallengeDialog(BnetPlayer challengee)
    {
        AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
            m_headerText = GameStrings.Get("GLOBAL_FRIEND_CHALLENGE_HEADER")
        };
        object[] args = new object[] { FriendUtils.GetUniqueName(challengee) };
        info.m_text = GameStrings.Format("GLOBAL_FRIEND_CHALLENGE_OPPONENT_WAITING_RESPONSE", args);
        info.m_showAlertIcon = false;
        info.m_responseDisplay = AlertPopup.ResponseDisplay.CANCEL;
        info.m_responseCallback = new AlertPopup.ResponseCallback(this.OnChallengeSentDialogResponse);
        DialogManager.Get().ShowPopup(info, new DialogManager.DialogProcessCallback(this.OnChallengeSentDialogProcessed));
    }

    private void ShowOpponentCanceledChallengeDialog(BnetPlayer otherPlayer)
    {
        if (this.m_challengeDialog != null)
        {
            this.m_challengeDialog.Hide();
            this.m_challengeDialog = null;
        }
        AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
            m_headerText = GameStrings.Get("GLOBAL_FRIEND_CHALLENGE_HEADER")
        };
        object[] args = new object[] { FriendUtils.GetUniqueName(otherPlayer) };
        info.m_text = GameStrings.Format("GLOBAL_FRIEND_CHALLENGE_OPPONENT_CANCELED", args);
        info.m_showAlertIcon = false;
        info.m_responseDisplay = AlertPopup.ResponseDisplay.OK;
        DialogManager.Get().ShowPopup(info);
    }

    private void ShowOpponentDeclinedChallengeDialog(BnetPlayer challengee)
    {
        this.m_challengeDialog.Hide();
        this.m_challengeDialog = null;
        AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
            m_headerText = GameStrings.Get("GLOBAL_FRIEND_CHALLENGE_HEADER")
        };
        object[] args = new object[] { FriendUtils.GetUniqueName(challengee) };
        info.m_text = GameStrings.Format("GLOBAL_FRIEND_CHALLENGE_OPPONENT_DECLINED", args);
        info.m_showAlertIcon = false;
        info.m_responseDisplay = AlertPopup.ResponseDisplay.OK;
        DialogManager.Get().ShowPopup(info);
    }

    private void ShowOpponentRemovedFromFriendsDialog(BnetPlayer otherPlayer)
    {
        if (this.m_challengeDialog != null)
        {
            this.m_challengeDialog.Hide();
            this.m_challengeDialog = null;
        }
        AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
            m_headerText = GameStrings.Get("GLOBAL_FRIEND_CHALLENGE_HEADER")
        };
        object[] args = new object[] { FriendUtils.GetUniqueName(otherPlayer) };
        info.m_text = GameStrings.Format("GLOBAL_FRIEND_CHALLENGE_OPPONENT_FRIEND_REMOVED", args);
        info.m_showAlertIcon = false;
        info.m_responseDisplay = AlertPopup.ResponseDisplay.OK;
        DialogManager.Get().ShowPopup(info);
    }

    private void StartDeckSelection()
    {
        if (this.m_challengeDialog != null)
        {
            this.m_challengeDialog.Hide();
            this.m_challengeDialog = null;
        }
        if ((BoardCameras.Get() != null) && (EndGameScreen.Get() == null))
        {
            LoadingScreen.Get().SetFreezeFrameCamera(Camera.main);
            LoadingScreen.Get().AddTransitionObject(BoardCameras.Get().GetAudioListener());
        }
        SceneMgr.Get().SetNextMode(SceneMgr.Mode.FRIENDLY);
    }

    private void UpdateMyAvailability()
    {
        bool val = !this.HasAvailabilityBlocker();
        BnetPresenceMgr.Get().SetGameField(1, val);
    }

    public delegate void ChangedCallback(FriendChallengeEvent challengeEvent, BnetPlayer player, object userData);

    private class ChangedListener : EventListener<FriendChallengeMgr.ChangedCallback>
    {
        public void Fire(FriendChallengeEvent challengeEvent, BnetPlayer player)
        {
            base.m_callback(challengeEvent, player, base.m_userData);
        }
    }
}


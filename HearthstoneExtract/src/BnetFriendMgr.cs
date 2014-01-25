using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class BnetFriendMgr
{
    private List<ChangeListener> m_changeListeners = new List<ChangeListener>();
    private List<BnetPlayer> m_friends = new List<BnetPlayer>();
    private int m_maxFriends;
    private int m_maxReceivedInvites;
    private int m_maxSentInvites;
    private PendingBnetFriendChangelist m_pendingChangelist = new PendingBnetFriendChangelist();
    private List<BnetInvitation> m_receivedInvites = new List<BnetInvitation>();
    private BnetPlayer m_selectedFriend;
    private List<BnetInvitation> m_sentInvites = new List<BnetInvitation>();
    private static BnetFriendMgr s_instance;

    public void AcceptInvite(BnetInvitationId inviteId)
    {
        Network.AcceptFriendInvite(inviteId);
    }

    public bool AddChangeListener(ChangeCallback callback)
    {
        return this.AddChangeListener(callback, null);
    }

    public bool AddChangeListener(ChangeCallback callback, object userData)
    {
        ChangeListener item = new ChangeListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_changeListeners.Contains(item))
        {
            return false;
        }
        this.m_changeListeners.Add(item);
        return true;
    }

    private void AddPendingFriend(BnetPlayer friend)
    {
        if (this.m_pendingChangelist.AddFriend(friend) && (this.m_pendingChangelist.GetCount() == 1))
        {
            BnetPresenceMgr.Get().AddPlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPendingPlayersChanged));
        }
    }

    public void DeclineInvite(BnetInvitationId inviteId)
    {
        Network.DeclineFriendInvite(inviteId);
    }

    public BnetPlayer FindFriend(BnetAccountId id)
    {
        foreach (BnetPlayer player in this.m_friends)
        {
            if (player.GetAccountId() == id)
            {
                return player;
            }
        }
        return null;
    }

    public BnetPlayer FindFriend(BnetGameAccountId id)
    {
        foreach (BnetPlayer player in this.m_friends)
        {
            if (player.HasGameAccount(id))
            {
                return player;
            }
        }
        return null;
    }

    private void FireChangeEvent(BnetFriendChangelist changelist)
    {
        foreach (ChangeListener listener in this.m_changeListeners.ToArray())
        {
            listener.Fire(changelist);
        }
    }

    private void FirePendingFriendsChangedEvent()
    {
        this.FireChangeEvent(this.m_pendingChangelist.GetChangelist());
        this.m_pendingChangelist.Clear();
        BnetPresenceMgr.Get().RemovePlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPendingPlayersChanged));
    }

    public static BnetFriendMgr Get()
    {
        if (s_instance == null)
        {
            s_instance = new BnetFriendMgr();
        }
        return s_instance;
    }

    public int GetFriendCount()
    {
        return this.m_friends.Count;
    }

    public List<BnetPlayer> GetFriends()
    {
        return this.m_friends;
    }

    public int GetMaxFriends()
    {
        return this.m_maxFriends;
    }

    public int GetMaxReceivedInvites()
    {
        return this.m_maxReceivedInvites;
    }

    public int GetMaxSentInvites()
    {
        return this.m_maxSentInvites;
    }

    public int GetOnlineFriendCount()
    {
        int num = 0;
        foreach (BnetPlayer player in this.m_friends)
        {
            if (player.IsOnline())
            {
                num++;
            }
        }
        return num;
    }

    public List<BnetInvitation> GetReceivedInvites()
    {
        return this.m_receivedInvites;
    }

    public BnetPlayer GetSelectedFriend()
    {
        return this.m_selectedFriend;
    }

    public List<BnetInvitation> GetSentInvites()
    {
        return this.m_sentInvites;
    }

    public void IgnoreInvite(BnetInvitationId inviteId)
    {
        Network.IgnoreFriendInvite(inviteId);
    }

    public void Initialize()
    {
        Network.Get().SetFriendsHandler(new Network.FriendsHandler(this.OnFriendsUpdate));
        Network.Get().AddBnetErrorListener(BnetFeature.Friends, new Network.BnetErrorCallback(this.OnBnetError));
        this.InitMaximums();
    }

    private void InitMaximums()
    {
        BattleNet.DllFriendsInfo info = new BattleNet.DllFriendsInfo();
        BattleNet.GetFriendsInfo(ref info);
        this.m_maxFriends = info.maxFriends;
        this.m_maxReceivedInvites = info.maxRecvInvites;
        this.m_maxSentInvites = info.maxSentInvites;
    }

    public bool IsFriend(BnetAccountId id)
    {
        return (this.FindFriend(id) != null);
    }

    public bool IsFriend(BnetGameAccountId id)
    {
        return (this.FindFriend(id) != null);
    }

    public bool IsFriend(BnetPlayer player)
    {
        return this.m_friends.Contains(player);
    }

    private bool OnBnetError(BnetErrorInfo info, object userData)
    {
        object[] args = new object[] { info.GetFeatureEvent(), info.GetError() };
        Log.Mike.Print("BnetFriendMgr.OnBnetError() - event={0} error={1}", args);
        return true;
    }

    private void OnFriendsUpdate(BattleNet.DllFriendsUpdate[] updates)
    {
        BnetFriendChangelist changelist = new BnetFriendChangelist();
        foreach (BattleNet.DllFriendsUpdate update in updates)
        {
            switch (((BattleNet.DllFriendsUpdate.Action) update.action))
            {
                case BattleNet.DllFriendsUpdate.Action.FRIEND_REMOVED:
                {
                    BnetAccountId id2 = BnetAccountId.CreateFromDll(update.entity1);
                    BnetPlayer item = BnetPresenceMgr.Get().GetPlayer(id2);
                    this.m_friends.Remove(item);
                    changelist.AddRemovedFriend(item);
                    this.RemovePendingFriend(item);
                    if (this.m_selectedFriend == item)
                    {
                        this.m_selectedFriend = null;
                    }
                    break;
                }
                case BattleNet.DllFriendsUpdate.Action.FRIEND_INVITE:
                {
                    BnetInvitation invitation = BnetInvitation.CreateFromDll(update);
                    this.m_receivedInvites.Add(invitation);
                    changelist.AddAddedReceivedInvite(invitation);
                    break;
                }
                case BattleNet.DllFriendsUpdate.Action.FRIEND_INVITE_REMOVED:
                {
                    BnetInvitation invitation2 = BnetInvitation.CreateFromDll(update);
                    this.m_receivedInvites.Remove(invitation2);
                    changelist.AddRemovedReceivedInvite(invitation2);
                    break;
                }
                case BattleNet.DllFriendsUpdate.Action.FRIEND_SENT_INVITE:
                {
                    BnetInvitation invitation3 = BnetInvitation.CreateFromDll(update);
                    this.m_sentInvites.Add(invitation3);
                    changelist.AddAddedSentInvite(invitation3);
                    break;
                }
                case BattleNet.DllFriendsUpdate.Action.FRIEND_SENT_INVITE_REMOVED:
                {
                    BnetInvitation invitation4 = BnetInvitation.CreateFromDll(update);
                    this.m_sentInvites.Remove(invitation4);
                    changelist.AddRemovedSentInvite(invitation4);
                    break;
                }
                case BattleNet.DllFriendsUpdate.Action.FRIEND_ADDED:
                {
                    BnetAccountId id = BnetAccountId.CreateFromDll(update.entity1);
                    BnetPlayer player = BnetPresenceMgr.Get().RegisterPlayer(id);
                    this.m_friends.Add(player);
                    if (player.IsDisplayable())
                    {
                        changelist.AddAddedFriend(player);
                    }
                    else
                    {
                        this.AddPendingFriend(player);
                    }
                    break;
                }
            }
        }
        if (!changelist.IsEmpty())
        {
            this.FireChangeEvent(changelist);
        }
    }

    private void OnPendingPlayersChanged(BnetPlayerChangelist changelist, object userData)
    {
        if (this.m_pendingChangelist.AreAllPlayersDisplayable())
        {
            this.FirePendingFriendsChangedEvent();
        }
    }

    public bool RemoveChangeListener(ChangeCallback callback)
    {
        return this.RemoveChangeListener(callback, null);
    }

    public bool RemoveChangeListener(ChangeCallback callback, object userData)
    {
        ChangeListener item = new ChangeListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_changeListeners.Remove(item);
    }

    public bool RemoveFriend(BnetPlayer friend)
    {
        if (!this.m_friends.Contains(friend))
        {
            return false;
        }
        if (this.m_selectedFriend == friend)
        {
            this.m_selectedFriend = null;
        }
        Network.RemoveFriend(friend.GetAccountId());
        return true;
    }

    private void RemovePendingFriend(BnetPlayer friend)
    {
        if (this.m_pendingChangelist.RemoveFriend(friend) && (this.m_pendingChangelist.GetCount() == 0))
        {
            BnetPresenceMgr.Get().RemovePlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPendingPlayersChanged));
        }
    }

    public void RevokeInvite(BnetInvitationId inviteId)
    {
        Network.RevokeFriendInvite(inviteId);
    }

    public void SendInvite(string name)
    {
        if (name.Contains("@"))
        {
            this.SendInviteByEmail(name);
        }
        else
        {
            this.SendInviteByBattleTag(name);
        }
    }

    public void SendInviteByBattleTag(string battleTagString)
    {
        Network.SendFriendInviteByBattleTag(BnetPresenceMgr.Get().GetMyPlayer().GetBattleTag().GetString(), battleTagString);
    }

    public void SendInviteByEmail(string email)
    {
        Network.SendFriendInviteByEmail(BnetPresenceMgr.Get().GetMyPlayer().GetFullName(), email);
    }

    public void SetSelectedFriend(BnetPlayer friend)
    {
        this.m_selectedFriend = friend;
    }

    public void Shutdown()
    {
        Network.Get().RemoveBnetErrorListener(BnetFeature.Friends, new Network.BnetErrorCallback(this.OnBnetError));
        Network.Get().SetFriendsHandler(null);
    }

    public delegate void ChangeCallback(BnetFriendChangelist changelist, object userData);

    private class ChangeListener : EventListener<BnetFriendMgr.ChangeCallback>
    {
        public void Fire(BnetFriendChangelist changelist)
        {
            base.m_callback(changelist, base.m_userData);
        }
    }
}


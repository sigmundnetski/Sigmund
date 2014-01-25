using System;

public class BnetBarFriendButton : FriendListUIElement
{
    public UberText m_OnlineCountText;
    private static BnetBarFriendButton s_instance;

    protected override void Awake()
    {
        s_instance = this;
        base.Awake();
        this.UpdateOnlineCount();
        BnetFriendMgr.Get().AddChangeListener(new BnetFriendMgr.ChangeCallback(this.OnFriendsChanged));
        BnetPresenceMgr.Get().AddPlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
    }

    public static BnetBarFriendButton Get()
    {
        return s_instance;
    }

    private void OnDestroy()
    {
        BnetFriendMgr.Get().RemoveChangeListener(new BnetFriendMgr.ChangeCallback(this.OnFriendsChanged));
        BnetPresenceMgr.Get().RemovePlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
    }

    private void OnFriendsChanged(BnetFriendChangelist changelist, object userData)
    {
        this.UpdateOnlineCount();
    }

    private void OnPlayersChanged(BnetPlayerChangelist changelist, object userData)
    {
        this.UpdateOnlineCount();
    }

    private void UpdateOnlineCount()
    {
        this.m_OnlineCountText.Text = BnetFriendMgr.Get().GetOnlineFriendCount().ToString();
    }
}


using System;
using UnityEngine;

public class FriendListRequestFrame : MonoBehaviour
{
    public FriendListUIElement m_AcceptButton;
    public GameObject m_Background;
    public FriendListUIElement m_DeclineButton;
    private BnetInvitation m_invite;
    public UberText m_PlayerNameText;
    public UberText m_TimeText;

    private void Awake()
    {
        this.m_AcceptButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnAcceptButtonPressed));
        this.m_DeclineButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnDeclineButtonPressed));
    }

    public BnetInvitation GetInvite()
    {
        return this.m_invite;
    }

    private void OnAcceptButtonPressed(UIEvent e)
    {
        BnetFriendMgr.Get().AcceptInvite(this.m_invite.GetId());
    }

    private void OnDeclineButtonPressed(UIEvent e)
    {
        BnetFriendMgr.Get().DeclineInvite(this.m_invite.GetId());
    }

    public void SetInvite(BnetInvitation invite)
    {
        if (this.m_invite != invite)
        {
            this.m_invite = invite;
            this.UpdateInvite();
        }
    }

    private void Update()
    {
        this.UpdateTimeText();
    }

    public void UpdateInvite()
    {
        this.m_PlayerNameText.Text = this.m_invite.GetInviterName();
        this.UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        string bnetElapsedTimeString = TimeUtils.GetBnetElapsedTimeString(this.m_invite.GetCreationTimeMicrosec());
        object[] args = new object[] { bnetElapsedTimeString };
        this.m_TimeText.Text = GameStrings.Format("GLOBAL_FRIENDLIST_REQUEST_SENT_TIME", args);
    }
}


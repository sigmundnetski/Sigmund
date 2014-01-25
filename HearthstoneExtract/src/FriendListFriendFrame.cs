using System;

public class FriendListFriendFrame : FriendListBaseFriendFrame
{
    public PegUIElement m_ChallengeButton;

    private void Awake()
    {
        this.m_ChallengeButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnChallengeButtonPressed));
    }

    private void OnChallengeButtonPressed(UIEvent e)
    {
        FriendChallengeMgr.Get().SendChallenge(base.m_player);
    }

    public override void UpdateFriend()
    {
        if (base.m_player.IsOnline())
        {
            BnetProgramId bestProgramId = base.m_player.GetBestProgramId();
            if (bestProgramId == null)
            {
                base.m_GameIcon.gameObject.SetActive(false);
                base.m_GameNameText.Text = GameStrings.Get("GLOBAL_OFFLINE");
            }
            else
            {
                base.m_GameIcon.gameObject.SetActive(true);
                base.m_GameIcon.SetProgramId(bestProgramId);
                base.m_GameNameText.Text = BnetProgramId.GetName(bestProgramId);
            }
            base.m_PlayerNameText.Text = FriendUtils.GetUniqueNameWithColor(base.m_player);
        }
        else
        {
            base.m_GameIcon.gameObject.SetActive(false);
            base.m_GameNameText.Text = GameStrings.Get("GLOBAL_OFFLINE");
            base.m_PlayerNameText.Text = FriendUtils.GetUniqueNameWithColor(base.m_player);
        }
        if (FriendChallengeMgr.Get().CanChallenge(base.m_player))
        {
            this.m_ChallengeButton.gameObject.SetActive(true);
        }
        else
        {
            this.m_ChallengeButton.gameObject.SetActive(false);
        }
    }
}


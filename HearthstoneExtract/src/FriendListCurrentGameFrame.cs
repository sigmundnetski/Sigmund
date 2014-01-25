using System;
using UnityEngine;

public class FriendListCurrentGameFrame : FriendListBaseFriendFrame
{
    public GameObject m_Background;
    public FriendListThreeSliceButton m_PlayButton;

    private void Awake()
    {
        this.m_PlayButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnPlayButtonPressed));
    }

    private void OnPlayButtonPressed(UIEvent e)
    {
    }

    public override void UpdateFriend()
    {
        base.m_GameIcon.SetProgramId(BnetProgramId.HEARTHSTONE);
        base.m_PlayerNameText.Text = FriendUtils.GetUniqueNameWithColor(base.m_player);
        base.m_GameNameText.Text = BnetProgramId.GetName(BnetProgramId.HEARTHSTONE);
    }
}


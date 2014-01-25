using System;
using UnityEngine;

public class FriendListBaseFriendFrame : MonoBehaviour
{
    public FriendListGameIcon m_GameIcon;
    public UberText m_GameNameText;
    protected BnetPlayer m_player;
    public UberText m_PlayerNameText;

    public BnetPlayer GetFriend()
    {
        return this.m_player;
    }

    public void SetFriend(BnetPlayer player)
    {
        if (this.m_player != player)
        {
            this.m_player = player;
            this.UpdateFriend();
        }
    }

    public virtual void UpdateFriend()
    {
    }
}


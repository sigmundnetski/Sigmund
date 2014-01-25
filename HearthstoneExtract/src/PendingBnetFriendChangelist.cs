using System;
using System.Collections.Generic;

public class PendingBnetFriendChangelist
{
    private BnetFriendChangelist m_changelist = new BnetFriendChangelist();

    public bool AddFriend(BnetPlayer friend)
    {
        return this.m_changelist.AddAddedFriend(friend);
    }

    public bool AreAllPlayersDisplayable()
    {
        if (this.GetCount() == 0)
        {
            return false;
        }
        List<BnetPlayer> addedFriends = this.m_changelist.GetAddedFriends();
        if (addedFriends != null)
        {
            foreach (BnetPlayer player in addedFriends)
            {
                if (!player.IsDisplayable())
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void Clear()
    {
        this.m_changelist.ClearAddedFriends();
    }

    public BnetFriendChangelist GetChangelist()
    {
        return this.m_changelist;
    }

    public int GetCount()
    {
        int num = 0;
        List<BnetPlayer> addedFriends = this.m_changelist.GetAddedFriends();
        return (num + ((addedFriends != null) ? addedFriends.Count : 0));
    }

    public bool RemoveFriend(BnetPlayer friend)
    {
        return this.m_changelist.RemoveAddedFriend(friend);
    }
}


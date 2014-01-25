using System;
using System.Collections.Generic;

public class BnetFriendChangelist
{
    private List<BnetPlayer> m_friendsAdded;
    private List<BnetPlayer> m_friendsRemoved;
    private List<BnetInvitation> m_receivedInvitesAdded;
    private List<BnetInvitation> m_receivedInvitesRemoved;
    private List<BnetInvitation> m_sentInvitesAdded;
    private List<BnetInvitation> m_sentInvitesRemoved;

    public bool AddAddedFriend(BnetPlayer friend)
    {
        if (this.m_friendsAdded == null)
        {
            this.m_friendsAdded = new List<BnetPlayer>();
        }
        else if (this.m_friendsAdded.Contains(friend))
        {
            return false;
        }
        this.m_friendsAdded.Add(friend);
        return true;
    }

    public bool AddAddedReceivedInvite(BnetInvitation invite)
    {
        if (this.m_receivedInvitesAdded == null)
        {
            this.m_receivedInvitesAdded = new List<BnetInvitation>();
        }
        else if (this.m_receivedInvitesAdded.Contains(invite))
        {
            return false;
        }
        this.m_receivedInvitesAdded.Add(invite);
        return true;
    }

    public bool AddAddedSentInvite(BnetInvitation invite)
    {
        if (this.m_sentInvitesAdded == null)
        {
            this.m_sentInvitesAdded = new List<BnetInvitation>();
        }
        else if (this.m_sentInvitesAdded.Contains(invite))
        {
            return false;
        }
        this.m_sentInvitesAdded.Add(invite);
        return true;
    }

    public bool AddRemovedFriend(BnetPlayer friend)
    {
        if (this.m_friendsRemoved == null)
        {
            this.m_friendsRemoved = new List<BnetPlayer>();
        }
        else if (this.m_friendsRemoved.Contains(friend))
        {
            return false;
        }
        this.m_friendsRemoved.Add(friend);
        return true;
    }

    public bool AddRemovedReceivedInvite(BnetInvitation invite)
    {
        if (this.m_receivedInvitesRemoved == null)
        {
            this.m_receivedInvitesRemoved = new List<BnetInvitation>();
        }
        else if (this.m_receivedInvitesRemoved.Contains(invite))
        {
            return false;
        }
        this.m_receivedInvitesRemoved.Add(invite);
        return true;
    }

    public bool AddRemovedSentInvite(BnetInvitation invite)
    {
        if (this.m_sentInvitesRemoved == null)
        {
            this.m_sentInvitesRemoved = new List<BnetInvitation>();
        }
        else if (this.m_sentInvitesRemoved.Contains(invite))
        {
            return false;
        }
        this.m_sentInvitesRemoved.Add(invite);
        return true;
    }

    public void Clear()
    {
        this.ClearAddedFriends();
        this.ClearRemovedFriends();
        this.ClearAddedReceivedInvites();
        this.ClearRemovedReceivedInvites();
        this.ClearAddedSentInvites();
        this.ClearRemovedSentInvites();
    }

    public void ClearAddedFriends()
    {
        this.m_friendsAdded = null;
    }

    public void ClearAddedReceivedInvites()
    {
        this.m_receivedInvitesAdded = null;
    }

    public void ClearAddedSentInvites()
    {
        this.m_sentInvitesAdded = null;
    }

    public void ClearRemovedFriends()
    {
        this.m_friendsRemoved = null;
    }

    public void ClearRemovedReceivedInvites()
    {
        this.m_receivedInvitesRemoved = null;
    }

    public void ClearRemovedSentInvites()
    {
        this.m_sentInvitesRemoved = null;
    }

    public List<BnetPlayer> GetAddedFriends()
    {
        return this.m_friendsAdded;
    }

    public List<BnetInvitation> GetAddedReceivedInvites()
    {
        return this.m_receivedInvitesAdded;
    }

    public List<BnetInvitation> GetAddedSentInvites()
    {
        return this.m_sentInvitesAdded;
    }

    public List<BnetPlayer> GetRemovedFriends()
    {
        return this.m_friendsRemoved;
    }

    public List<BnetInvitation> GetRemovedReceivedInvites()
    {
        return this.m_receivedInvitesRemoved;
    }

    public List<BnetInvitation> GetRemovedSentInvites()
    {
        return this.m_sentInvitesRemoved;
    }

    public bool IsEmpty()
    {
        if ((this.m_friendsAdded != null) && (this.m_friendsAdded.Count > 0))
        {
            return false;
        }
        if ((this.m_friendsRemoved != null) && (this.m_friendsRemoved.Count > 0))
        {
            return false;
        }
        if ((this.m_receivedInvitesAdded != null) && (this.m_receivedInvitesAdded.Count > 0))
        {
            return false;
        }
        if ((this.m_receivedInvitesRemoved != null) && (this.m_receivedInvitesRemoved.Count > 0))
        {
            return false;
        }
        if ((this.m_sentInvitesAdded != null) && (this.m_sentInvitesAdded.Count > 0))
        {
            return false;
        }
        if ((this.m_sentInvitesRemoved != null) && (this.m_sentInvitesRemoved.Count > 0))
        {
            return false;
        }
        return true;
    }

    public bool RemoveAddedFriend(BnetPlayer friend)
    {
        if (this.m_friendsAdded == null)
        {
            return false;
        }
        return this.m_friendsAdded.Remove(friend);
    }

    public bool RemoveAddedReceivedInvite(BnetInvitation invite)
    {
        if (this.m_receivedInvitesAdded == null)
        {
            return false;
        }
        return this.m_receivedInvitesAdded.Remove(invite);
    }

    public bool RemoveAddedSentInvite(BnetInvitation invite)
    {
        if (this.m_sentInvitesAdded == null)
        {
            return false;
        }
        return this.m_sentInvitesAdded.Remove(invite);
    }

    public bool RemoveRemovedFriend(BnetPlayer friend)
    {
        if (this.m_friendsRemoved == null)
        {
            return false;
        }
        return this.m_friendsRemoved.Remove(friend);
    }

    public bool RemoveRemovedReceivedInvite(BnetInvitation invite)
    {
        if (this.m_receivedInvitesRemoved == null)
        {
            return false;
        }
        return this.m_receivedInvitesRemoved.Remove(invite);
    }

    public bool RemoveRemovedSentInvite(BnetInvitation invite)
    {
        if (this.m_sentInvitesRemoved == null)
        {
            return false;
        }
        return this.m_sentInvitesRemoved.Remove(invite);
    }
}


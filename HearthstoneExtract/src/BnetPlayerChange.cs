using System;

public class BnetPlayerChange
{
    private BnetPlayer m_newPlayer;
    private BnetPlayer m_oldPlayer;

    public BnetPlayer GetNewPlayer()
    {
        return this.m_newPlayer;
    }

    public BnetPlayer GetOldPlayer()
    {
        return this.m_oldPlayer;
    }

    public BnetPlayer GetPlayer()
    {
        return this.m_newPlayer;
    }

    public void SetNewPlayer(BnetPlayer player)
    {
        this.m_newPlayer = player;
    }

    public void SetOldPlayer(BnetPlayer player)
    {
        this.m_oldPlayer = player;
    }
}


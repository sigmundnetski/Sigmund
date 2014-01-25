using System;

public class BnetWhisper
{
    private BnetErrorInfo m_errorInfo;
    private string m_message;
    private BnetGameAccountId m_receiverId;
    private BnetGameAccountId m_speakerId;
    private ulong m_timestampMicrosec;

    public static BnetWhisper CreateFromDll(BattleNet.DllWhisper src)
    {
        return new BnetWhisper { m_speakerId = BnetGameAccountId.CreateFromDll(src.speakerId), m_receiverId = BnetGameAccountId.CreateFromDll(src.receiverId), m_message = DLLUtils.StringFromNativeUtf8(src.message), m_timestampMicrosec = src.timestampMicrosec, m_errorInfo = BnetErrorInfo.CreateFromDll(src.errorInfo) };
    }

    public BnetErrorInfo GetErrorInfo()
    {
        return this.m_errorInfo;
    }

    public string GetMessage()
    {
        return this.m_message;
    }

    public BnetPlayer GetReceiver()
    {
        return BnetPresenceMgr.Get().GetPlayer(this.m_receiverId);
    }

    public BnetGameAccountId GetReceiverId()
    {
        return this.m_receiverId;
    }

    public BnetPlayer GetSpeaker()
    {
        return BnetPresenceMgr.Get().GetPlayer(this.m_speakerId);
    }

    public BnetGameAccountId GetSpeakerId()
    {
        return this.m_speakerId;
    }

    public BnetGameAccountId GetTheirGameAccountId()
    {
        BnetPlayer myPlayer = BnetPresenceMgr.Get().GetMyPlayer();
        if (myPlayer.HasGameAccount(this.m_speakerId))
        {
            return this.m_receiverId;
        }
        if (myPlayer.HasGameAccount(this.m_receiverId))
        {
            return this.m_speakerId;
        }
        return null;
    }

    public BnetPlayer GetTheirPlayer()
    {
        BnetPlayer myPlayer = BnetPresenceMgr.Get().GetMyPlayer();
        BnetPlayer speaker = this.GetSpeaker();
        BnetPlayer receiver = this.GetReceiver();
        if (myPlayer == speaker)
        {
            return receiver;
        }
        if (myPlayer == receiver)
        {
            return speaker;
        }
        return null;
    }

    public ulong GetTimestampMicrosec()
    {
        return this.m_timestampMicrosec;
    }

    public bool IsDisplayable()
    {
        BnetPlayer player = BnetPresenceMgr.Get().GetPlayer(this.m_speakerId);
        BnetPlayer player2 = BnetPresenceMgr.Get().GetPlayer(this.m_receiverId);
        if (player == null)
        {
            return false;
        }
        if (!player.IsDisplayable())
        {
            return false;
        }
        if (player2 == null)
        {
            return false;
        }
        if (!player2.IsDisplayable())
        {
            return false;
        }
        return true;
    }

    public bool IsReceiver(BnetPlayer player)
    {
        if (player == null)
        {
            return false;
        }
        return player.HasGameAccount(this.m_receiverId);
    }

    public bool IsSpeaker(BnetPlayer player)
    {
        if (player == null)
        {
            return false;
        }
        return player.HasGameAccount(this.m_speakerId);
    }

    public bool IsSpeakerOrReceiver(BnetPlayer player)
    {
        if (player == null)
        {
            return false;
        }
        return (player.HasGameAccount(this.m_speakerId) || player.HasGameAccount(this.m_receiverId));
    }

    public void SetErrorInfo(BnetErrorInfo errorInfo)
    {
        this.m_errorInfo = errorInfo;
    }

    public void SetMessage(string message)
    {
        this.m_message = message;
    }

    public void SetReceiverId(BnetGameAccountId id)
    {
        this.m_receiverId = id;
    }

    public void SetSpeakerId(BnetGameAccountId id)
    {
        this.m_speakerId = id;
    }

    public void SetTimestampMicrosec(ulong microsec)
    {
        this.m_timestampMicrosec = microsec;
    }
}


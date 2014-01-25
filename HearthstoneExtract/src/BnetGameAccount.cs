using System;
using System.Collections.Generic;

public class BnetGameAccount
{
    private BnetBattleTag m_battleTag;
    private Dictionary<int, object> m_gameFields = new Dictionary<int, object>();
    private BnetGameAccountId m_id;
    private long m_lastOnlineMicrosec;
    private bool m_online;
    private BnetAccountId m_ownerId;
    private BnetProgramId m_programId;

    public bool CanBeInvitedToGame()
    {
        return this.GetGameFieldBool(1);
    }

    public BnetGameAccount Clone()
    {
        BnetGameAccount account = new BnetGameAccount();
        if (this.m_id != null)
        {
            account.m_id = this.m_id.Clone();
        }
        if (this.m_ownerId != null)
        {
            account.m_ownerId = this.m_ownerId.Clone();
        }
        if (this.m_programId != null)
        {
            account.m_programId = this.m_programId.Clone();
        }
        if (this.m_battleTag != null)
        {
            account.m_battleTag = this.m_battleTag.Clone();
        }
        account.m_online = this.m_online;
        account.m_lastOnlineMicrosec = this.m_lastOnlineMicrosec;
        foreach (KeyValuePair<int, object> pair in this.m_gameFields)
        {
            account.m_gameFields.Add(pair.Key, pair.Value);
        }
        return account;
    }

    public bool Equals(BnetGameAccountId other)
    {
        if (other == null)
        {
            return false;
        }
        return this.m_id.Equals((BnetEntityId) other);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        BnetGameAccount account = obj as BnetGameAccount;
        if (account == null)
        {
            return false;
        }
        return this.m_id.Equals((BnetEntityId) account.m_id);
    }

    public BnetBattleTag GetBattleTag()
    {
        return this.m_battleTag;
    }

    public object GetGameField(int fieldId)
    {
        object obj2 = null;
        this.m_gameFields.TryGetValue(fieldId, out obj2);
        return obj2;
    }

    public bool GetGameFieldBool(int fieldId)
    {
        object obj2 = null;
        return (this.m_gameFields.TryGetValue(fieldId, out obj2) && ((bool) obj2));
    }

    public int GetGameFieldInt(int fieldId)
    {
        object obj2 = null;
        if (this.m_gameFields.TryGetValue(fieldId, out obj2))
        {
            return (int) obj2;
        }
        return 0;
    }

    public Dictionary<int, object> GetGameFields()
    {
        return this.m_gameFields;
    }

    public override int GetHashCode()
    {
        return this.m_id.GetHashCode();
    }

    public BnetGameAccountId GetId()
    {
        return this.m_id;
    }

    public long GetLastOnlineMicrosec()
    {
        return this.m_lastOnlineMicrosec;
    }

    public BnetAccountId GetOwnerId()
    {
        return this.m_ownerId;
    }

    public int GetPlayingClass()
    {
        return this.GetGameFieldInt(2);
    }

    public int GetPlayMode()
    {
        return this.GetGameFieldInt(3);
    }

    public BnetProgramId GetProgramId()
    {
        return this.m_programId;
    }

    public bool HasGameField(int fieldId)
    {
        return this.m_gameFields.ContainsKey(fieldId);
    }

    public bool IsOnline()
    {
        return this.m_online;
    }

    public static bool operator ==(BnetGameAccount a, BnetGameAccount b)
    {
        return (object.ReferenceEquals(a, b) || (((a != null) && (b != null)) && (a.m_id == b.m_id)));
    }

    public static bool operator !=(BnetGameAccount a, BnetGameAccount b)
    {
        return !(a == b);
    }

    public void SetBattleTag(BnetBattleTag battleTag)
    {
        this.m_battleTag = battleTag;
    }

    public void SetCanBeInvitedToGame(bool canBeInvitedToGame)
    {
        this.m_gameFields[1] = canBeInvitedToGame;
    }

    public void SetGameField(int fieldId, object val)
    {
        this.m_gameFields[fieldId] = val;
    }

    public void SetId(BnetGameAccountId id)
    {
        this.m_id = id;
    }

    public void SetLastOnlineMicrosec(long microsec)
    {
        this.m_lastOnlineMicrosec = microsec;
    }

    public void SetOnline(bool online)
    {
        this.m_online = online;
    }

    public void SetOwnerId(BnetAccountId id)
    {
        this.m_ownerId = id;
    }

    public void SetPlayingClass(int playingClass)
    {
        this.m_gameFields[2] = playingClass;
    }

    public void SetPlayMode(int playMode)
    {
        this.m_gameFields[3] = playMode;
    }

    public void SetProgramId(BnetProgramId programId)
    {
        this.m_programId = programId;
    }

    public override string ToString()
    {
        if (this.m_id == null)
        {
            return "UNKNOWN GAME ACCOUNT";
        }
        object[] args = new object[] { this.m_id, this.m_programId, this.m_battleTag, this.m_online };
        return string.Format("[id={0} programId={1} battleTag={2} online={3}]", args);
    }
}


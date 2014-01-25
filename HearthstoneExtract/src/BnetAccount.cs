using System;

public class BnetAccount
{
    private BnetBattleTag m_battleTag;
    private string m_fullName;
    private BnetAccountId m_id;
    private ulong m_lastOnlineMicrosec;

    public BnetAccount Clone()
    {
        BnetAccount account = new BnetAccount();
        if (this.m_id != null)
        {
            account.m_id = this.m_id.Clone();
        }
        account.m_fullName = this.m_fullName;
        if (this.m_battleTag != null)
        {
            account.m_battleTag = this.m_battleTag.Clone();
        }
        account.m_lastOnlineMicrosec = this.m_lastOnlineMicrosec;
        return account;
    }

    public bool Equals(BnetAccountId other)
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
        BnetAccount account = obj as BnetAccount;
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

    public string GetFullName()
    {
        return this.m_fullName;
    }

    public override int GetHashCode()
    {
        return this.m_id.GetHashCode();
    }

    public BnetAccountId GetId()
    {
        return this.m_id;
    }

    public ulong GetLastOnlineMicrosec()
    {
        return this.m_lastOnlineMicrosec;
    }

    public static bool operator ==(BnetAccount a, BnetAccount b)
    {
        return (object.ReferenceEquals(a, b) || (((a != null) && (b != null)) && (a.m_id == b.m_id)));
    }

    public static bool operator !=(BnetAccount a, BnetAccount b)
    {
        return !(a == b);
    }

    public void SetBattleTag(BnetBattleTag battleTag)
    {
        this.m_battleTag = battleTag;
    }

    public void SetFullName(string fullName)
    {
        this.m_fullName = fullName;
    }

    public void SetId(BnetAccountId id)
    {
        this.m_id = id;
    }

    public void SetLastOnlineMicrosec(ulong microsec)
    {
        this.m_lastOnlineMicrosec = microsec;
    }

    public override string ToString()
    {
        if (this.m_id == null)
        {
            return "UNKNOWN ACCOUNT";
        }
        object[] args = new object[] { this.m_id, this.m_fullName, this.m_battleTag, TimeUtils.ConvertEpochMicrosecToDateTime(this.m_lastOnlineMicrosec) };
        return string.Format("[id={0} m_fullName={1} battleTag={2} lastOnline={3}]", args);
    }
}


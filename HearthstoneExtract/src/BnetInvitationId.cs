using System;

public class BnetInvitationId
{
    private ulong m_val;

    public BnetInvitationId(ulong val)
    {
        this.m_val = val;
    }

    public static BattleNet.DllInvitationId CreateForDll(BnetInvitationId src)
    {
        return new BattleNet.DllInvitationId { val = src.m_val };
    }

    public static BnetInvitationId CreateFromDll(BattleNet.DllInvitationId src)
    {
        return new BnetInvitationId(src.val);
    }

    public bool Equals(BattleNet.DllInvitationId dllOther)
    {
        return (this.m_val == dllOther.val);
    }

    public bool Equals(BnetInvitationId other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.m_val == other.m_val);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        BnetInvitationId id = obj as BnetInvitationId;
        if (id == null)
        {
            return false;
        }
        return (this.m_val == id.m_val);
    }

    public override int GetHashCode()
    {
        return this.m_val.GetHashCode();
    }

    public ulong GetVal()
    {
        return this.m_val;
    }

    public static bool operator ==(BattleNet.DllInvitationId a, BnetInvitationId b)
    {
        if (b == null)
        {
            return false;
        }
        return (a.val == b.m_val);
    }

    public static bool operator ==(BnetInvitationId a, BattleNet.DllInvitationId b)
    {
        if (a == null)
        {
            return false;
        }
        return (a.m_val == b.val);
    }

    public static bool operator ==(BnetInvitationId a, BnetInvitationId b)
    {
        return (object.ReferenceEquals(a, b) || (((a != null) && (b != null)) && (a.m_val == b.m_val)));
    }

    public static bool operator !=(BattleNet.DllInvitationId a, BnetInvitationId b)
    {
        return (a != b);
    }

    public static bool operator !=(BnetInvitationId a, BattleNet.DllInvitationId b)
    {
        return (a != b);
    }

    public static bool operator !=(BnetInvitationId a, BnetInvitationId b)
    {
        return !(a == b);
    }

    public void SetVal(ulong val)
    {
        this.m_val = val;
    }

    public override string ToString()
    {
        return this.m_val.ToString();
    }
}


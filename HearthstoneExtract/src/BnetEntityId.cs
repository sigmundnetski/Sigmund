using PegasusShared;
using System;

public class BnetEntityId
{
    protected ulong m_hi;
    protected ulong m_lo;

    public BnetEntityId Clone()
    {
        BnetEntityId id = new BnetEntityId();
        id.CopyFrom(this);
        return id;
    }

    public void CopyFrom(BattleNet.DllEntityId id)
    {
        this.m_hi = id.hi;
        this.m_lo = id.lo;
    }

    public void CopyFrom(BnetEntityId id)
    {
        this.m_hi = id.m_hi;
        this.m_lo = id.m_lo;
    }

    public void CopyFrom(BnetId id)
    {
        this.m_hi = id.Hi;
        this.m_lo = id.Lo;
    }

    public static BattleNet.DllEntityId CreateForDll(BnetEntityId src)
    {
        return new BattleNet.DllEntityId { hi = src.m_hi, lo = src.m_lo };
    }

    public static BnetEntityId CreateFromDll(BattleNet.DllEntityId src)
    {
        BnetEntityId id = new BnetEntityId();
        id.CopyFrom(src);
        return id;
    }

    public static BnetEntityId CreateFromNet(BnetId src)
    {
        BnetEntityId id = new BnetEntityId();
        id.CopyFrom(src);
        return id;
    }

    public bool Equals(BnetEntityId other)
    {
        if (other == null)
        {
            return false;
        }
        return ((this.m_hi == other.m_hi) && (this.m_lo == other.m_lo));
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        BnetEntityId id = obj as BnetEntityId;
        if (id == null)
        {
            return false;
        }
        return ((this.m_hi == id.m_hi) && (this.m_lo == id.m_lo));
    }

    public override int GetHashCode()
    {
        int num = 0x11;
        num = (num * 11) + this.m_hi.GetHashCode();
        return ((num * 11) + this.m_lo.GetHashCode());
    }

    public ulong GetHi()
    {
        return this.m_hi;
    }

    public ulong GetLo()
    {
        return this.m_lo;
    }

    public bool IsEmpty()
    {
        return ((this.m_hi | this.m_lo) == 0L);
    }

    public bool IsValid()
    {
        return (this.m_lo != 0L);
    }

    public static bool operator ==(BnetEntityId a, BnetEntityId b)
    {
        if (object.ReferenceEquals(a, b))
        {
            return true;
        }
        if ((a == null) || (b == null))
        {
            return false;
        }
        return ((a.m_hi == b.m_hi) && (a.m_lo == b.m_lo));
    }

    public static bool operator !=(BnetEntityId a, BnetEntityId b)
    {
        return !(a == b);
    }

    public void SetHi(ulong hi)
    {
        this.m_hi = hi;
    }

    public void SetLo(ulong lo)
    {
        this.m_lo = lo;
    }

    public override string ToString()
    {
        return string.Format("[hi={0} lo={1}]", this.m_hi, this.m_lo);
    }
}


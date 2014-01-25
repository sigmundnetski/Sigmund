using System;

public class BnetBattleTag
{
    private string m_name;
    private int m_number;

    public BnetBattleTag Clone()
    {
        return new BnetBattleTag { m_name = this.m_name, m_number = this.m_number };
    }

    public static BnetBattleTag CreateFromDll(IntPtr src)
    {
        BnetBattleTag tag = new BnetBattleTag();
        string composite = DLLUtils.StringFromNativeUtf8(src);
        if (composite == null)
        {
            object[] messageArgs = new object[] { src };
            Error.AddDevFatal("Bnet Error", "BnetBattleTag.CreateFromDll() - Failed to convert {0} to native string.", messageArgs);
            return null;
        }
        if (!tag.SetString(composite))
        {
            return null;
        }
        return tag;
    }

    public static BnetBattleTag CreateFromString(string src)
    {
        BnetBattleTag tag = new BnetBattleTag();
        if (!tag.SetString(src))
        {
            return null;
        }
        return tag;
    }

    public bool Equals(BnetBattleTag other)
    {
        if (other == null)
        {
            return false;
        }
        return ((this.m_name == other.m_name) && (this.m_number == other.m_number));
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        BnetBattleTag tag = obj as BnetBattleTag;
        if (tag == null)
        {
            return false;
        }
        return ((this.m_name == tag.m_name) && (this.m_number == tag.m_number));
    }

    public override int GetHashCode()
    {
        int num = 0x11;
        num = (num * 11) + this.m_name.GetHashCode();
        return ((num * 11) + this.m_number.GetHashCode());
    }

    public string GetName()
    {
        return this.m_name;
    }

    public int GetNumber()
    {
        return this.m_number;
    }

    public string GetString()
    {
        return string.Format("{0}#{1}", this.m_name, this.m_number);
    }

    public static bool operator ==(BnetBattleTag a, BnetBattleTag b)
    {
        if (object.ReferenceEquals(a, b))
        {
            return true;
        }
        if ((a == null) || (b == null))
        {
            return false;
        }
        return ((a.m_name == b.m_name) && (a.m_number == b.m_number));
    }

    public static bool operator !=(BnetBattleTag a, BnetBattleTag b)
    {
        return !(a == b);
    }

    public void SetName(string name)
    {
        this.m_name = name;
    }

    public void SetNumber(int number)
    {
        this.m_number = number;
    }

    public bool SetString(string composite)
    {
        if (composite == null)
        {
            Error.AddDevFatal("Bnet Error", "BnetBattleTag.SetString() - Given null string.", new object[0]);
            return false;
        }
        char[] separator = new char[] { '#' };
        string[] strArray = composite.Split(separator);
        if (strArray.Length < 2)
        {
            object[] messageArgs = new object[] { composite, 2 };
            Error.AddDevFatal("Bnet Error", "BnetBattleTag.SetString() - Failed to split \"{0}\" into {1} parts.", messageArgs);
            return false;
        }
        if (!int.TryParse(strArray[1], out this.m_number))
        {
            object[] objArray2 = new object[] { strArray[1], composite };
            Error.AddDevFatal("Bnet Error", "BnetBattleTag.SetString() - Failed to parse \"{0}\" into a number. Original string: \"{1}\"", objArray2);
            return false;
        }
        this.m_name = strArray[0];
        return true;
    }

    public override string ToString()
    {
        return string.Format("{0}#{1}", this.m_name, this.m_number);
    }
}


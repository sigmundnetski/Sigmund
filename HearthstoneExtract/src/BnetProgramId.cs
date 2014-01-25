using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public class BnetProgramId
{
    public static readonly BnetProgramId BNET = new BnetProgramId("BN");
    public static readonly BnetProgramId DIABLO3 = new BnetProgramId("D3");
    public static readonly BnetProgramId HEARTHSTONE = new BnetProgramId("WTCG");
    private uint m_value;
    public static readonly BnetProgramId PHOENIX = new BnetProgramId("App");
    public static readonly BnetProgramId PHOENIX_OLD = new BnetProgramId("CLNT");
    private static readonly Dictionary<BnetProgramId, string> s_nameStringTagMap;
    private static readonly Dictionary<BnetProgramId, string> s_textureNameMap;
    public static readonly BnetProgramId STARCRAFT2 = new BnetProgramId("S2");
    public static readonly BnetProgramId WOW = new BnetProgramId("WoW");

    static BnetProgramId()
    {
        Dictionary<BnetProgramId, string> dictionary = new Dictionary<BnetProgramId, string>();
        dictionary.Add(HEARTHSTONE, "HS");
        dictionary.Add(WOW, "WOW");
        dictionary.Add(DIABLO3, "D3");
        dictionary.Add(STARCRAFT2, "SC2");
        dictionary.Add(PHOENIX, "BN");
        dictionary.Add(PHOENIX_OLD, "BN");
        s_textureNameMap = dictionary;
        dictionary = new Dictionary<BnetProgramId, string>();
        dictionary.Add(HEARTHSTONE, "GLOBAL_PROGRAMNAME_HEARTHSTONE");
        dictionary.Add(WOW, "GLOBAL_PROGRAMNAME_WOW");
        dictionary.Add(DIABLO3, "GLOBAL_PROGRAMNAME_DIABLO3");
        dictionary.Add(STARCRAFT2, "GLOBAL_PROGRAMNAME_STARCRAFT2");
        dictionary.Add(PHOENIX, "GLOBAL_PROGRAMNAME_PHOENIX");
        dictionary.Add(PHOENIX_OLD, "GLOBAL_PROGRAMNAME_PHOENIX");
        s_nameStringTagMap = dictionary;
    }

    public BnetProgramId()
    {
    }

    public BnetProgramId(string stringVal)
    {
        this.SetString(stringVal);
    }

    public BnetProgramId(uint value)
    {
        this.m_value = value;
    }

    public BnetProgramId Clone()
    {
        return new BnetProgramId { m_value = this.m_value };
    }

    public static BnetProgramId CreateFromDll(IntPtr src)
    {
        return new BnetProgramId(Marshal.PtrToStringAnsi(src));
    }

    public bool Equals(BnetProgramId other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.m_value == other.m_value);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        BnetProgramId id = obj as BnetProgramId;
        if (id == null)
        {
            return false;
        }
        return (this.m_value == id.m_value);
    }

    public override int GetHashCode()
    {
        return this.m_value.GetHashCode();
    }

    public static string GetName(BnetProgramId programId)
    {
        string str = null;
        if (s_nameStringTagMap.TryGetValue(programId, out str))
        {
            return GameStrings.Get(str);
        }
        return null;
    }

    public static string GetNameTag(BnetProgramId programId)
    {
        string str = null;
        s_nameStringTagMap.TryGetValue(programId, out str);
        return str;
    }

    public string GetString()
    {
        StringBuilder builder = new StringBuilder(4);
        for (int i = 0x18; i >= 0; i -= 8)
        {
            char ch = (char) ((this.m_value >> i) & 0xff);
            if (ch != '\0')
            {
                builder.Append(ch);
            }
        }
        return builder.ToString();
    }

    public static string GetTextureName(BnetProgramId programId)
    {
        string str = null;
        s_textureNameMap.TryGetValue(programId, out str);
        return str;
    }

    public uint GetValue()
    {
        return this.m_value;
    }

    public bool IsGame()
    {
        return ((this != PHOENIX) && (this != PHOENIX_OLD));
    }

    public bool IsPhoenix()
    {
        return ((this == PHOENIX) || (this == PHOENIX_OLD));
    }

    public static bool operator ==(BnetProgramId a, BnetProgramId b)
    {
        return (object.ReferenceEquals(a, b) || (((a != null) && (b != null)) && (a.m_value == b.m_value)));
    }

    public static bool operator !=(BnetProgramId a, BnetProgramId b)
    {
        return !(a == b);
    }

    public void SetString(string str)
    {
        this.m_value = 0;
        for (int i = 0; (i < str.Length) && (i < 4); i++)
        {
            this.m_value = (this.m_value << 8) | ((byte) str[i]);
        }
    }

    public void SetValue(uint val)
    {
        this.m_value = val;
    }

    public override string ToString()
    {
        return this.GetString();
    }
}


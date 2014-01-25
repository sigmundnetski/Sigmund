using System;

public class VarKey
{
    private string m_key;

    public VarKey(string key)
    {
        this.m_key = key;
    }

    public VarKey(string key, string subKey)
    {
        this.m_key = key + "." + subKey;
    }

    public int GetInt(int def)
    {
        if (VarsInternal.Get().Contains(this.m_key))
        {
            return Convert.ToInt32(VarsInternal.Get().Value(this.m_key));
        }
        return def;
    }

    public string GetStr(string def)
    {
        if (VarsInternal.Get().Contains(this.m_key))
        {
            return VarsInternal.Get().Value(this.m_key);
        }
        return def;
    }

    public VarKey Key(string subKey)
    {
        return new VarKey(this.m_key, subKey);
    }
}


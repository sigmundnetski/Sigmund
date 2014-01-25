using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

internal class TypedDictionary<T>
{
    private Dictionary<string, T> m_dict;

    public TypedDictionary()
    {
        this.m_dict = new Dictionary<string, T>();
    }

    public void Clear()
    {
        this.m_dict = new Dictionary<string, T>();
        this.Dirty = true;
    }

    public void Delete(string key)
    {
        this.m_dict.Remove(key);
        this.Dirty = true;
    }

    public T Get(string key)
    {
        T local;
        return (!this.m_dict.TryGetValue(key, out local) ? default(T) : local);
    }

    public bool HasKey(string key)
    {
        return this.m_dict.ContainsKey(key);
    }

    public void Set(string key, T value)
    {
        this.m_dict[key] = value;
        this.Dirty = true;
    }

    public bool Dirty
    {
        [CompilerGenerated]
        get
        {
            return this.<Dirty>k__BackingField;
        }
        [CompilerGenerated]
        set
        {
            this.<Dirty>k__BackingField = value;
        }
    }

    public T this[string key]
    {
        get
        {
            return this.Get(key);
        }
        set
        {
            this.Set(key, value);
        }
    }

    public Dictionary<string, T>.KeyCollection Keys
    {
        get
        {
            return this.m_dict.Keys;
        }
    }
}


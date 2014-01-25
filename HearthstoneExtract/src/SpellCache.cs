using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellCache : MonoBehaviour
{
    private Dictionary<string, LoadState> m_loadStates = new Dictionary<string, LoadState>();
    private Dictionary<string, SpellTable> m_spellTableCache = new Dictionary<string, SpellTable>();
    public List<SpellTableInfo> m_spellTableInfo = new List<SpellTableInfo>();
    private int m_tablesToLoad = -1;
    private static SpellCache s_instance;

    private void Awake()
    {
        s_instance = this;
        foreach (SpellTableInfo info in this.m_spellTableInfo)
        {
            this.m_loadStates.Add(info.m_name, LoadState.UNLOADED);
        }
    }

    public static SpellCache Get()
    {
        if (s_instance == null)
        {
            Debug.LogError("Attempting to access null SpellCache");
            return null;
        }
        return s_instance;
    }

    public SpellTable GetSpellTable(string tableName)
    {
        if (!this.m_spellTableCache.ContainsKey(tableName))
        {
            return null;
        }
        if (this.m_spellTableCache[tableName] == null)
        {
            Debug.LogError("Spell table was stored as null.");
        }
        return this.m_spellTableCache[tableName];
    }

    public bool IsLoaded()
    {
        return (this.m_tablesToLoad <= 0);
    }

    public void LoadMode(SceneMgr.Mode mode)
    {
        foreach (SpellTableInfo info in this.m_spellTableInfo)
        {
            SpellCache cache = this;
            lock (cache)
            {
                if (info.m_requiredForModes.Contains(mode) && (((LoadState) this.m_loadStates[info.m_name]) == LoadState.UNLOADED))
                {
                    this.m_loadStates[info.m_name] = LoadState.LOADING;
                    AssetLoader.Get().LoadSpellTable(info.m_name, new AssetLoader.GameObjectCallback(this.OnSpellTableLoaded), info.m_name);
                    this.m_tablesToLoad++;
                }
                continue;
            }
        }
    }

    public void OnSpellTableLoaded(string name, GameObject go, object callbackData)
    {
        if (go.activeSelf)
        {
            Debug.LogError("SpellTable \"" + name + "\" has not been deactivated.  Deactivate the SpellTable in the Editor.");
        }
        string key = (string) callbackData;
        SpellTable component = go.GetComponent<SpellTable>();
        if (go == null)
        {
            Debug.LogError("spell table loaded as null: " + key);
        }
        SpellCache cache = this;
        lock (cache)
        {
            if (((LoadState) this.m_loadStates[key]) != LoadState.LOADED)
            {
                this.m_loadStates[key] = LoadState.LOADED;
                this.m_spellTableCache.Add(key, component);
                go.transform.parent = base.transform;
                this.m_tablesToLoad--;
            }
            else
            {
                Debug.LogError("loaded spell table twice: " + key);
            }
        }
    }

    public void PreLoad()
    {
        foreach (SpellTableInfo info in this.m_spellTableInfo)
        {
            SpellCache cache = this;
            lock (cache)
            {
                if (((LoadState) this.m_loadStates[info.m_name]) == LoadState.UNLOADED)
                {
                    this.m_loadStates[info.m_name] = LoadState.LOADING;
                    AssetLoader.Get().LoadSpellTable(info.m_name, new AssetLoader.GameObjectCallback(this.OnSpellTableLoaded), info.m_name);
                    this.m_tablesToLoad++;
                }
                continue;
            }
        }
    }

    private void Start()
    {
    }

    public enum LoadState
    {
        UNLOADED,
        LOADING,
        LOADED
    }

    [Serializable]
    public class SpellTableInfo
    {
        public string m_name;
        public List<SceneMgr.Mode> m_requiredForModes;
    }
}


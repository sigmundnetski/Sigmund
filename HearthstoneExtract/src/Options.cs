using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class Options
{
    private const int FLAG_BIT_COUNT = 0x40;
    private Dictionary<Option, List<ChangedListener>> m_changedListeners = new Dictionary<Option, List<ChangedListener>>();
    private Dictionary<Option, ClientOption> m_clientOptionMap;
    private List<ChangedListener> m_globalChangedListeners = new List<ChangedListener>();
    private Dictionary<Option, ServerOptionFlag> m_serverOptionFlagMap;
    private Dictionary<Option, ServerOption> m_serverOptionMap;
    private const float RCP_FLAG_BIT_COUNT = 0.015625f;
    private static Options s_instance;
    public static readonly List<ServerOption> s_serverFlagContainers = new List<ServerOption> { 1, 2, 3, 4, 5, 13, 14, 15, 0x10, 0x11 };

    private void BuildClientOptionMap(Dictionary<string, Option> options)
    {
        this.m_clientOptionMap = new Dictionary<Option, ClientOption>();
        IEnumerator enumerator = Enum.GetValues(typeof(ClientOption)).GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                ClientOption current = (ClientOption) ((int) enumerator.Current);
                if ((current != ClientOption.INVALID) && !current.ToString().StartsWith("DEPRECATED_"))
                {
                    Option option2;
                    if (options.TryGetValue(current.ToString(), out option2))
                    {
                        this.m_clientOptionMap.Add(option2, current);
                    }
                    else
                    {
                        Debug.LogError(string.Format("Options.BuildClientOptionMap() - ClientOption {0} is not mirrored in the Option enum", current));
                    }
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    private void BuildServerOptionFlagMap(Dictionary<string, Option> options)
    {
        this.m_serverOptionFlagMap = new Dictionary<Option, ServerOptionFlag>();
        IEnumerator enumerator = Enum.GetValues(typeof(ServerOptionFlag)).GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                ServerOptionFlag current = (ServerOptionFlag) ((int) enumerator.Current);
                if ((current != ServerOptionFlag.LIMIT) && !current.ToString().StartsWith("DEPRECATED_"))
                {
                    Option option;
                    if (options.TryGetValue(current.ToString(), out option))
                    {
                        this.m_serverOptionFlagMap.Add(option, current);
                    }
                    else
                    {
                        Debug.LogError(string.Format("Options.BuildServerOptionFlagMap() - ServerOptionFlag {0} is not mirrored in the Option enum", current));
                    }
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    private void BuildServerOptionMap(Dictionary<string, Option> options)
    {
        this.m_serverOptionMap = new Dictionary<Option, ServerOption>();
        IEnumerator enumerator = Enum.GetValues(typeof(ServerOption)).GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                ServerOption current = (ServerOption) ((int) enumerator.Current);
                switch (current)
                {
                    case ServerOption.INVALID:
                    case ServerOption.LIMIT:
                    {
                        continue;
                    }
                }
                string str = current.ToString();
                if (!str.StartsWith("DEPRECATED_") && !str.StartsWith("FLAG"))
                {
                    Option option2;
                    if (options.TryGetValue(current.ToString(), out option2))
                    {
                        System.Type type = OptionDataTables.s_typeMap[option2];
                        if (type == typeof(bool))
                        {
                            Debug.LogError(string.Format("Options.BuildServerOptionMap() - ServerOption {0} is a bool", current));
                        }
                        else
                        {
                            this.m_serverOptionMap.Add(option2, current);
                        }
                    }
                    else
                    {
                        Debug.LogError(string.Format("Options.BuildServerOptionMap() - ServerOption {0} is not mirrored in the Option enum", current));
                    }
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    private void DeleteClientOption(Option option)
    {
        if (LocalOptions.HasOption(option))
        {
            object clientOption = this.GetClientOption(option);
            LocalOptions.Delete(option);
            this.RemoveListeners(option, clientOption);
        }
    }

    public void DeleteOption(Option option)
    {
        ClientOption option2;
        if (this.m_clientOptionMap.TryGetValue(option, out option2))
        {
            this.DeleteClientOption(option);
        }
        else
        {
            ServerOption option3;
            if (this.m_serverOptionMap.TryGetValue(option, out option3))
            {
                this.DeleteServerOption(option, option3);
            }
            else
            {
                ServerOptionFlag flag;
                if (this.m_serverOptionFlagMap.TryGetValue(option, out flag))
                {
                    this.DeleteServerOptionFlag(option, flag);
                }
            }
        }
    }

    private void DeleteServerOption(Option option, ServerOption serverOption)
    {
        if (NetCache.Get().ClientOptionExists(serverOption))
        {
            object prevVal = this.GetServerOption(option, serverOption);
            NetCache.Get().DeleteClientOption(serverOption);
            this.RemoveListeners(option, prevVal);
        }
    }

    private void DeleteServerOptionFlag(Option option, ServerOptionFlag serverOptionFlag)
    {
        ServerOption option2;
        ulong num;
        ulong num2;
        this.GetServerOptionFlagInfo(serverOptionFlag, out option2, out num, out num2);
        ulong longOption = (ulong) NetCache.Get().GetLongOption(option2);
        if ((longOption & num2) != 0L)
        {
            bool prevVal = (longOption & num) != 0L;
            longOption &= ~num2;
            NetCache.Get().SetLongOption(option2, (long) longOption);
            this.RemoveListeners(option, prevVal);
        }
    }

    private void FireChangedEvent(Option option, object prevVal, bool existed)
    {
        List<ChangedListener> list;
        if (this.m_changedListeners.TryGetValue(option, out list))
        {
            ChangedListener[] listenerArray = list.ToArray();
            for (int j = 0; j < listenerArray.Length; j++)
            {
                listenerArray[j].Fire(option, prevVal, existed);
            }
        }
        ChangedListener[] listenerArray2 = this.m_globalChangedListeners.ToArray();
        for (int i = 0; i < listenerArray2.Length; i++)
        {
            listenerArray2[i].Fire(option, prevVal, existed);
        }
    }

    public static Options Get()
    {
        if (s_instance == null)
        {
            s_instance = new Options();
            s_instance.Initialize();
        }
        return s_instance;
    }

    public bool GetBool(Option option)
    {
        bool flag;
        object obj2;
        if (this.GetBoolImpl(option, out flag))
        {
            return flag;
        }
        return (OptionDataTables.s_defaultsMap.TryGetValue(option, out obj2) && ((bool) obj2));
    }

    public bool GetBool(Option option, bool defaultVal)
    {
        bool flag;
        if (this.GetBoolImpl(option, out flag))
        {
            return flag;
        }
        return defaultVal;
    }

    private bool GetBoolImpl(Option option, out bool val)
    {
        object obj2;
        val = false;
        if (this.GetOptionImpl(option, out obj2))
        {
            val = (bool) obj2;
            return true;
        }
        return false;
    }

    private object GetClientOption(Option option)
    {
        System.Type optionType = this.GetOptionType(option);
        if (optionType == typeof(bool))
        {
            return LocalOptions.GetBool(option);
        }
        if (optionType == typeof(int))
        {
            return LocalOptions.GetInt(option);
        }
        if (optionType == typeof(float))
        {
            return LocalOptions.GetFloat(option);
        }
        if (optionType == typeof(string))
        {
            return LocalOptions.GetString(option);
        }
        return null;
    }

    public Dictionary<Option, ClientOption> GetClientOptions()
    {
        return this.m_clientOptionMap;
    }

    public float GetFloat(Option option)
    {
        float num;
        object obj2;
        if (this.GetFloatImpl(option, out num))
        {
            return num;
        }
        if (OptionDataTables.s_defaultsMap.TryGetValue(option, out obj2))
        {
            return (float) obj2;
        }
        return 0f;
    }

    public float GetFloat(Option option, float defaultVal)
    {
        float num;
        if (this.GetFloatImpl(option, out num))
        {
            return num;
        }
        return defaultVal;
    }

    private bool GetFloatImpl(Option option, out float val)
    {
        object obj2;
        val = 0f;
        if (this.GetOptionImpl(option, out obj2))
        {
            val = (float) obj2;
            return true;
        }
        return false;
    }

    public int GetInt(Option option)
    {
        int num;
        object obj2;
        if (this.GetIntImpl(option, out num))
        {
            return num;
        }
        if (OptionDataTables.s_defaultsMap.TryGetValue(option, out obj2))
        {
            return (int) obj2;
        }
        return 0;
    }

    public int GetInt(Option option, int defaultVal)
    {
        int num;
        if (this.GetIntImpl(option, out num))
        {
            return num;
        }
        return defaultVal;
    }

    private bool GetIntImpl(Option option, out int val)
    {
        object obj2;
        val = 0;
        if (this.GetOptionImpl(option, out obj2))
        {
            val = (int) obj2;
            return true;
        }
        return false;
    }

    public long GetLong(Option option)
    {
        long num;
        object obj2;
        if (this.GetLongImpl(option, out num))
        {
            return num;
        }
        if (OptionDataTables.s_defaultsMap.TryGetValue(option, out obj2))
        {
            return (long) obj2;
        }
        return 0L;
    }

    public long GetLong(Option option, long defaultVal)
    {
        long num;
        if (this.GetLongImpl(option, out num))
        {
            return num;
        }
        return defaultVal;
    }

    private bool GetLongImpl(Option option, out long val)
    {
        object obj2;
        val = 0L;
        if (this.GetOptionImpl(option, out obj2))
        {
            val = (long) obj2;
            return true;
        }
        return false;
    }

    public object GetOption(Option option)
    {
        object obj2;
        object obj3;
        if (this.GetOptionImpl(option, out obj2))
        {
            return obj2;
        }
        if (OptionDataTables.s_defaultsMap.TryGetValue(option, out obj3))
        {
            return obj3;
        }
        return null;
    }

    public object GetOption(Option option, object defaultVal)
    {
        object obj2;
        if (this.GetOptionImpl(option, out obj2))
        {
            return obj2;
        }
        return defaultVal;
    }

    private bool GetOptionImpl(Option option, out object val)
    {
        ClientOption option2;
        val = null;
        if (this.m_clientOptionMap.TryGetValue(option, out option2))
        {
            if (LocalOptions.HasOption(option))
            {
                val = this.GetClientOption(option);
            }
        }
        else
        {
            ServerOption option3;
            if (this.m_serverOptionMap.TryGetValue(option, out option3))
            {
                if (NetCache.Get().ClientOptionExists(option3))
                {
                    val = this.GetServerOption(option, option3);
                }
            }
            else
            {
                ServerOptionFlag flag;
                if (this.m_serverOptionFlagMap.TryGetValue(option, out flag))
                {
                    ulong num;
                    ulong num2;
                    this.GetServerOptionFlagInfo(flag, out option3, out num, out num2);
                    ulong longOption = (ulong) NetCache.Get().GetLongOption(option3);
                    if ((longOption & num2) != 0L)
                    {
                        val = (longOption & num) != 0L;
                    }
                }
            }
        }
        return (val != null);
    }

    public System.Type GetOptionType(Option option)
    {
        System.Type type;
        if (OptionDataTables.s_typeMap.TryGetValue(option, out type))
        {
            return type;
        }
        if (this.m_serverOptionFlagMap.ContainsKey(option))
        {
            return typeof(bool);
        }
        Debug.LogError(string.Format("Options.GetOptionType() - {0} does not have an option type!", option));
        return null;
    }

    private object GetServerOption(Option option, ServerOption serverOption)
    {
        System.Type optionType = this.GetOptionType(option);
        if (optionType == typeof(int))
        {
            return NetCache.Get().GetIntOption(serverOption);
        }
        if (optionType == typeof(long))
        {
            return NetCache.Get().GetLongOption(serverOption);
        }
        if (optionType == typeof(float))
        {
            return NetCache.Get().GetFloatOption(serverOption);
        }
        return null;
    }

    private void GetServerOptionFlagInfo(ServerOptionFlag flag, out ServerOption container, out ulong flagBit, out ulong existenceBit)
    {
        int num = (int) (ServerOptionFlag.HAS_SEEN_TOURNAMENT * flag);
        int num2 = Mathf.FloorToInt(num * 0.015625f);
        int num3 = num % 0x40;
        int num4 = 1 + num3;
        container = s_serverFlagContainers[num2];
        flagBit = ((ulong) 1L) << num3;
        existenceBit = ((ulong) 1L) << num4;
    }

    public Dictionary<Option, ServerOption> GetServerOptions()
    {
        return this.m_serverOptionMap;
    }

    public string GetString(Option option)
    {
        string str;
        object obj2;
        if (this.GetStringImpl(option, out str))
        {
            return str;
        }
        if (OptionDataTables.s_defaultsMap.TryGetValue(option, out obj2))
        {
            return (string) obj2;
        }
        return string.Empty;
    }

    public string GetString(Option option, string defaultVal)
    {
        string str;
        if (this.GetStringImpl(option, out str))
        {
            return str;
        }
        return defaultVal;
    }

    private bool GetStringImpl(Option option, out string val)
    {
        object obj2;
        val = string.Empty;
        if (this.GetOptionImpl(option, out obj2))
        {
            val = (string) obj2;
            return true;
        }
        return false;
    }

    public bool HasOption(Option option)
    {
        ClientOption option2;
        ServerOption option3;
        ServerOptionFlag flag;
        if (this.m_clientOptionMap.TryGetValue(option, out option2))
        {
            return LocalOptions.HasOption(option);
        }
        if (this.m_serverOptionMap.TryGetValue(option, out option3))
        {
            return NetCache.Get().ClientOptionExists(option3);
        }
        return (this.m_serverOptionFlagMap.TryGetValue(option, out flag) && this.HasServerOptionFlag(flag));
    }

    private bool HasServerOptionFlag(ServerOptionFlag serverOptionFlag)
    {
        ServerOption option;
        ulong num;
        ulong num2;
        this.GetServerOptionFlagInfo(serverOptionFlag, out option, out num, out num2);
        return ((((ulong) NetCache.Get().GetLongOption(option)) & num2) != 0L);
    }

    private void Initialize()
    {
        Array values = Enum.GetValues(typeof(Option));
        Dictionary<string, Option> options = new Dictionary<string, Option>();
        IEnumerator enumerator = values.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                Option current = (Option) ((int) enumerator.Current);
                if (current != Option.INVALID)
                {
                    string key = current.ToString();
                    if (!key.StartsWith("DEPRECATED_"))
                    {
                        options.Add(key, current);
                    }
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
        this.BuildClientOptionMap(options);
        this.BuildServerOptionMap(options);
        this.BuildServerOptionFlagMap(options);
    }

    public bool IsClientOption(Option option)
    {
        return this.m_clientOptionMap.ContainsKey(option);
    }

    public bool IsServerOption(Option option)
    {
        return this.m_serverOptionMap.ContainsKey(option);
    }

    public bool RegisterChangedListener(Option option, ChangedCallback callback)
    {
        return this.RegisterChangedListener(option, callback, null);
    }

    public bool RegisterChangedListener(Option option, ChangedCallback callback, object userData)
    {
        List<ChangedListener> list;
        ChangedListener item = new ChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (!this.m_changedListeners.TryGetValue(option, out list))
        {
            list = new List<ChangedListener>();
            this.m_changedListeners.Add(option, list);
        }
        else if (list.Contains(item))
        {
            return false;
        }
        list.Add(item);
        return true;
    }

    public bool RegisterGlobalChangedListener(ChangedCallback callback)
    {
        return this.RegisterGlobalChangedListener(callback, null);
    }

    public bool RegisterGlobalChangedListener(ChangedCallback callback, object userData)
    {
        ChangedListener item = new ChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_globalChangedListeners.Contains(item))
        {
            return false;
        }
        this.m_globalChangedListeners.Add(item);
        return true;
    }

    private void RemoveListeners(Option option, object prevVal)
    {
        this.FireChangedEvent(option, prevVal, true);
        this.m_changedListeners.Remove(option);
    }

    public void SetBool(Option option, bool val)
    {
        if (this.m_clientOptionMap.ContainsKey(option))
        {
            bool existed = LocalOptions.HasOption(option);
            bool @bool = LocalOptions.GetBool(option);
            if (!existed || (@bool != val))
            {
                LocalOptions.Set(option, val);
                this.FireChangedEvent(option, @bool, existed);
            }
        }
        else
        {
            ServerOptionFlag flag3;
            if (this.m_serverOptionFlagMap.TryGetValue(option, out flag3))
            {
                ServerOption option2;
                ulong num;
                ulong num2;
                this.GetServerOptionFlagInfo(flag3, out option2, out num, out num2);
                ulong longOption = (ulong) NetCache.Get().GetLongOption(option2);
                bool prevVal = (longOption & num) != 0L;
                bool flag5 = (longOption & num2) != 0L;
                if (!flag5 || (prevVal != val))
                {
                    ulong num4 = !val ? (longOption & ~num) : (longOption | num);
                    num4 |= num2;
                    NetCache.Get().SetLongOption(option2, (long) num4);
                    this.FireChangedEvent(option, prevVal, flag5);
                }
            }
        }
    }

    public void SetFloat(Option option, float val)
    {
        if (this.m_clientOptionMap.ContainsKey(option))
        {
            bool existed = LocalOptions.HasOption(option);
            float @float = LocalOptions.GetFloat(option);
            if (!existed || (@float != val))
            {
                LocalOptions.Set(option, (double) val);
                this.FireChangedEvent(option, @float, existed);
            }
        }
        else
        {
            ServerOption option2;
            if (this.m_serverOptionMap.TryGetValue(option, out option2))
            {
                float num2;
                bool floatOption = NetCache.Get().GetFloatOption(option2, out num2);
                if (!floatOption || (num2 != val))
                {
                    NetCache.Get().SetFloatOption(option2, val);
                    this.FireChangedEvent(option, num2, floatOption);
                }
            }
        }
    }

    public void SetInt(Option option, int val)
    {
        if (this.m_clientOptionMap.ContainsKey(option))
        {
            bool existed = LocalOptions.HasOption(option);
            int @int = LocalOptions.GetInt(option);
            if (!existed || (@int != val))
            {
                LocalOptions.Set(option, val);
                this.FireChangedEvent(option, @int, existed);
            }
        }
        else
        {
            ServerOption option2;
            if (this.m_serverOptionMap.TryGetValue(option, out option2))
            {
                int num2;
                bool intOption = NetCache.Get().GetIntOption(option2, out num2);
                if (!intOption || (num2 != val))
                {
                    NetCache.Get().SetIntOption(option2, val);
                    this.FireChangedEvent(option, num2, intOption);
                }
            }
        }
    }

    public void SetLong(Option option, long val)
    {
        ServerOption option2;
        if (this.m_serverOptionMap.TryGetValue(option, out option2))
        {
            long num;
            bool longOption = NetCache.Get().GetLongOption(option2, out num);
            if (!longOption || (num != val))
            {
                NetCache.Get().SetLongOption(option2, val);
                this.FireChangedEvent(option, num, longOption);
            }
        }
    }

    public void SetOption(Option option, object val)
    {
        System.Type optionType = this.GetOptionType(option);
        if (optionType == typeof(bool))
        {
            this.SetBool(option, (bool) val);
        }
        else if (optionType == typeof(int))
        {
            this.SetInt(option, (int) val);
        }
        else if (optionType == typeof(long))
        {
            this.SetLong(option, (long) val);
        }
        else if (optionType == typeof(float))
        {
            this.SetFloat(option, (float) val);
        }
        else if (optionType == typeof(string))
        {
            this.SetString(option, (string) val);
        }
    }

    public void SetString(Option option, string val)
    {
        if (this.m_clientOptionMap.ContainsKey(option))
        {
            bool existed = LocalOptions.HasOption(option);
            string prevVal = LocalOptions.GetString(option);
            if (!existed || (prevVal != val))
            {
                LocalOptions.Set(option, val);
                this.FireChangedEvent(option, prevVal, existed);
            }
        }
    }

    public bool UnregisterChangedListener(Option option, ChangedCallback callback)
    {
        return this.UnregisterChangedListener(option, callback, null);
    }

    public bool UnregisterChangedListener(Option option, ChangedCallback callback, object userData)
    {
        List<ChangedListener> list;
        ChangedListener item = new ChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (!this.m_changedListeners.TryGetValue(option, out list))
        {
            return false;
        }
        if (!list.Remove(item))
        {
            return false;
        }
        if (list.Count == 0)
        {
            this.m_changedListeners.Remove(option);
        }
        return true;
    }

    public bool UnregisterGlobalChangedListener(ChangedCallback callback)
    {
        return this.UnregisterGlobalChangedListener(callback, null);
    }

    public bool UnregisterGlobalChangedListener(ChangedCallback callback, object userData)
    {
        ChangedListener item = new ChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_globalChangedListeners.Remove(item);
    }

    public delegate void ChangedCallback(Option option, object prevValue, bool existed, object userData);

    private class ChangedListener : EventListener<Options.ChangedCallback>
    {
        public void Fire(Option option, object prevValue, bool didExist)
        {
            base.m_callback(option, prevValue, didExist, base.m_userData);
        }
    }
}


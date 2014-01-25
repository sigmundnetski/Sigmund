using System;
using System.Collections.Generic;
using System.IO;

internal class VarsInternal
{
    private static string s_clientConfig = "client.config";
    private static VarsInternal s_instance = new VarsInternal();
    private Dictionary<string, string> s_vars = new Dictionary<string, string>();

    private VarsInternal()
    {
        if (!FileUtils.ParseConfigFile(s_clientConfig, new FileUtils.ConfigFileEntryParseCallback(this.OnConfigFileEntryParsed)))
        {
            System.IO.File.OpenWrite(s_clientConfig);
        }
    }

    public bool Contains(string key)
    {
        return this.s_vars.ContainsKey(key);
    }

    public static VarsInternal Get()
    {
        return s_instance;
    }

    private void OnConfigFileEntryParsed(string baseKey, string subKey, string val, object userData)
    {
        string str = string.Format("{0}.{1}", baseKey, subKey);
        this.s_vars[str] = val;
    }

    public string Value(string key)
    {
        return this.s_vars[key];
    }
}


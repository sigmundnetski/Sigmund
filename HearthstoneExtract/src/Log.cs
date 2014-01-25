using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Log
{
    public static Logger Asset = new Logger("Asset");
    public static Logger Ben = new Logger("Ben");
    public static Logger Bob = new Logger("Bob");
    public static Logger Brian = new Logger("Brian");
    private const string CONFIG_FILE_NAME = "log.config";
    public static Logger Derek = new Logger("Derek");
    public static Logger Jay = new Logger("Jay");
    public static Logger Kyle = new Logger("Kyle");
    private Dictionary<string, LogInfo> m_logInfos = new Dictionary<string, LogInfo>();
    public static Logger Mike = new Logger("Mike");
    public static Logger Net = new Logger("Net");
    public static Logger Packets = new Logger("Packet");
    public static Logger Power = new Logger("Power");
    public static Logger Rachelle = new Logger("Rachelle");
    private static Log s_instance;
    public static Logger Sound = new Logger("Sound");
    public static Logger Zone = new Logger("Zone");

    public static Log Get()
    {
        if (s_instance == null)
        {
            s_instance = new Log();
            s_instance.Initialize();
        }
        return s_instance;
    }

    private void Initialize()
    {
        this.Load();
    }

    public bool IsConsolePrintingEnabled(string name)
    {
        LogInfo info;
        if (!this.m_logInfos.TryGetValue(name, out info))
        {
            return false;
        }
        return info.IsConsolePrintingEnabled();
    }

    public bool IsPrintingEnabled(string name)
    {
        LogInfo info;
        if (!this.m_logInfos.TryGetValue(name, out info))
        {
            return false;
        }
        return info.IsPrintingEnabled();
    }

    public bool IsScreenPrintingEnabled(string name)
    {
        LogInfo info;
        if (!this.m_logInfos.TryGetValue(name, out info))
        {
            return false;
        }
        return info.IsScreenPrintingEnabled();
    }

    public bool Load()
    {
        string path = string.Format("{0}/{1}", FileUtils.GetPersistentDataPath(), "log.config");
        if (!System.IO.File.Exists(path))
        {
            return false;
        }
        this.m_logInfos.Clear();
        FileUtils.ParseConfigFile(path, new FileUtils.ConfigFileEntryParseCallback(this.OnConfigFileEntryParsed));
        return true;
    }

    private void OnConfigFileEntryParsed(string baseKey, string subKey, string val, object userData)
    {
        LogInfo info;
        if (!this.m_logInfos.TryGetValue(baseKey, out info))
        {
            info = new LogInfo(baseKey);
            this.m_logInfos.Add(info.GetName(), info);
        }
        if (subKey.Equals("ConsolePrinting", StringComparison.OrdinalIgnoreCase))
        {
            info.SetConsolePrintingEnabled(GeneralUtils.ForceBool(val));
        }
        else if (subKey.Equals("ScreenPrinting", StringComparison.OrdinalIgnoreCase))
        {
            info.SetScreenPrintingEnabled(GeneralUtils.ForceBool(val));
        }
    }

    public void Print(string name, string message)
    {
        LogInfo info;
        if (this.m_logInfos.TryGetValue(name, out info) && info.IsConsolePrintingEnabled())
        {
            Debug.Log(string.Format("[{0}] {1}", name, message));
        }
    }

    public void ScreenPrint(string name, string message)
    {
        LogInfo info;
        if ((((SceneDebugger.Get() != null) && ApplicationMgr.IsInternal()) && this.m_logInfos.TryGetValue(name, out info)) && info.IsScreenPrintingEnabled())
        {
            string str = string.Format("[{0}] {1}", name, message);
            Debug.Log(str);
            SceneDebugger.Get().AddMessage(str);
        }
    }
}


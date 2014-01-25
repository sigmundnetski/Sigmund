using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Cheats
{
    private string m_board;
    private static Cheats s_instance;

    public static Cheats Get()
    {
        return s_instance;
    }

    public string GetBoard()
    {
        return this.m_board;
    }

    public static void Initialize()
    {
        s_instance = new Cheats();
        s_instance.InitializeImpl();
    }

    private void InitializeImpl()
    {
        CheatMgr mgr = CheatMgr.Get();
        if (ApplicationMgr.IsInternal())
        {
            mgr.RegisterCheatHandler("has", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_HasOption));
            mgr.RegisterCheatHandler("get", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_GetOption));
            mgr.RegisterCheatHandler("set", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_SetOption));
            mgr.RegisterCheatHandler("del", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_DeleteOption));
            mgr.RegisterCheatHandler("delete", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_DeleteOption));
            mgr.RegisterCheatHandler("collectionfirstxp", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_collectionfirstxp));
            mgr.RegisterCheatHandler("missioncomplete", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_missioncomplete));
            mgr.RegisterCheatHandler("board", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_board));
            mgr.RegisterCheatHandler("resettips", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_resettips));
            mgr.RegisterCheatHandler("questcomplete", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_questcomplete));
        }
        mgr.RegisterCheatHandler("warning", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_warning));
        mgr.RegisterCheatHandler("fatal", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_fatal));
        mgr.RegisterCheatHandler("suicide", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_suicide));
        mgr.RegisterCheatHandler("exit", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_exit));
        mgr.RegisterCheatHandler("quit", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_exit));
        mgr.RegisterCheatHandler("log", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_log));
    }

    private bool OnProcessCheat_board(string func, string[] args, string rawArgs)
    {
        this.m_board = args[0].ToUpperInvariant();
        return true;
    }

    private bool OnProcessCheat_collectionfirstxp(string func, string[] args, string rawArgs)
    {
        Options.Get().SetInt(Option.COVER_MOUSE_OVERS, 0);
        Options.Get().SetInt(Option.PAGE_MOUSE_OVERS, 0);
        return true;
    }

    private bool OnProcessCheat_DeleteOption(string func, string[] args, string rawArgs)
    {
        Option option;
        string str = args[0];
        try
        {
            option = EnumUtils.GetEnum<Option>(str, StringComparison.OrdinalIgnoreCase);
        }
        catch (ArgumentException)
        {
            return false;
        }
        Options.Get().DeleteOption(option);
        Debug.Log(string.Format("DeleteOption: {0}. HasOption = {1}.", EnumUtils.GetString<Option>(option), Options.Get().HasOption(option)));
        return true;
    }

    private bool OnProcessCheat_exit(string func, string[] args, string rawArgs)
    {
        GeneralUtils.ExitApplication();
        return true;
    }

    private bool OnProcessCheat_fatal(string func, string[] args, string rawArgs)
    {
        string str;
        string str2;
        ParseErrorText(args, rawArgs, out str, out str2);
        Error.AddFatal(str, str2);
        return true;
    }

    private bool OnProcessCheat_GetOption(string func, string[] args, string rawArgs)
    {
        Option option;
        string str = args[0];
        try
        {
            option = EnumUtils.GetEnum<Option>(str, StringComparison.OrdinalIgnoreCase);
        }
        catch (ArgumentException)
        {
            return false;
        }
        Debug.Log(string.Format("GetOption: {0} = {1}", EnumUtils.GetString<Option>(option), Options.Get().GetOption(option)));
        return true;
    }

    private bool OnProcessCheat_HasOption(string func, string[] args, string rawArgs)
    {
        Option option;
        string str = args[0];
        try
        {
            option = EnumUtils.GetEnum<Option>(str, StringComparison.OrdinalIgnoreCase);
        }
        catch (ArgumentException)
        {
            return false;
        }
        Debug.Log(string.Format("HasOption: {0} = {1}", EnumUtils.GetString<Option>(option), Options.Get().HasOption(option)));
        return true;
    }

    private bool OnProcessCheat_log(string func, string[] args, string rawArgs)
    {
        string str = args[0].ToLowerInvariant();
        if (!(str == "load") && !(str == "reload"))
        {
            return false;
        }
        Log.Get().Load();
        return true;
    }

    private bool OnProcessCheat_missioncomplete(string func, string[] args, string rawArgs)
    {
        string str = args[0].ToLowerInvariant();
        MissionMgr.MissionProgress val = MissionMgr.MissionProgress.NOTHING_COMPLETE;
        switch (str)
        {
            case "all":
            case "everything":
                val = MissionMgr.MissionProgress.ALL_TUTORIALS_COMPLETE;
                break;

            case "none":
            case "nothing":
                val = MissionMgr.MissionProgress.NOTHING_COMPLETE;
                break;

            default:
                try
                {
                    val = EnumUtils.GetEnum<MissionMgr.MissionProgress>(str);
                }
                catch (Exception)
                {
                    return true;
                }
                break;
        }
        Network.SetCampaignProgress(val);
        return true;
    }

    private bool OnProcessCheat_questcomplete(string func, string[] args, string rawArgs)
    {
        QuestToast.ShowQuestToast(null, AchieveManager.Get().GetAchievement(int.Parse(rawArgs)));
        return true;
    }

    private bool OnProcessCheat_resettips(string func, string[] args, string rawArgs)
    {
        Options.Get().SetBool(Option.HAS_DISENCHANTED, false);
        Options.Get().SetBool(Option.HAS_SEEN_SHOW_ALL_CARDS_REMINDER, false);
        Options.Get().SetBool(Option.HAS_CRAFTED, false);
        return true;
    }

    private bool OnProcessCheat_SetOption(string func, string[] args, string rawArgs)
    {
        Option option;
        string str = args[0];
        try
        {
            option = EnumUtils.GetEnum<Option>(str, StringComparison.OrdinalIgnoreCase);
        }
        catch (ArgumentException)
        {
            return false;
        }
        string strVal = args[1];
        System.Type optionType = Options.Get().GetOptionType(option);
        if (optionType == typeof(bool))
        {
            bool flag;
            if (!GeneralUtils.TryParseBool(strVal, out flag))
            {
                return false;
            }
            Options.Get().SetBool(option, flag);
        }
        else if (optionType == typeof(int))
        {
            int num;
            if (!int.TryParse(strVal, out num))
            {
                return false;
            }
            Options.Get().SetInt(option, num);
        }
        else if (optionType == typeof(long))
        {
            long num2;
            if (!long.TryParse(strVal, out num2))
            {
                return false;
            }
            Options.Get().SetLong(option, num2);
        }
        else if (optionType == typeof(float))
        {
            float num3;
            if (!float.TryParse(strVal, out num3))
            {
                return false;
            }
            Options.Get().SetFloat(option, num3);
        }
        else if (optionType == typeof(string))
        {
            Options.Get().SetString(option, strVal);
        }
        switch (option)
        {
            case Option.CURSOR:
                Screen.showCursor = Options.Get().GetBool(Option.CURSOR);
                break;

            case Option.FAKE_PACK_OPENING:
                NetCache.Get().ReloadNetObject<NetCache.NetCacheBoosters>();
                break;

            default:
                if ((option == Option.FAKE_PACK_COUNT) && PackOpening.IsFakePackOpeningEnabled())
                {
                    NetCache.Get().ReloadNetObject<NetCache.NetCacheBoosters>();
                }
                break;
        }
        Debug.Log(string.Format("SetOption: {0} to {1}. GetOption = {2}", EnumUtils.GetString<Option>(option), strVal, Options.Get().GetOption(option)));
        return true;
    }

    private bool OnProcessCheat_suicide(string func, string[] args, string rawArgs)
    {
        string s = args[0].ToLowerInvariant();
        int result = 0;
        int.TryParse(s, out result);
        Application.CommitSuicide(result);
        return true;
    }

    private bool OnProcessCheat_warning(string func, string[] args, string rawArgs)
    {
        string str;
        string str2;
        ParseErrorText(args, rawArgs, out str, out str2);
        object[] messageArgs = new object[] { str2 };
        Error.AddWarning(str, str, messageArgs);
        return true;
    }

    private static void ParseErrorText(string[] args, string rawArgs, out string header, out string message)
    {
        header = (args.Length != 0) ? args[0] : "[PH] Header";
        if (args.Length <= 1)
        {
            message = "[PH] Message";
        }
        else
        {
            int startIndex = 0;
            bool flag = false;
            for (int i = 0; i < rawArgs.Length; i++)
            {
                char c = rawArgs[i];
                if (char.IsWhiteSpace(c))
                {
                    if (!flag)
                    {
                        continue;
                    }
                    startIndex = i;
                    break;
                }
                flag = true;
            }
            message = rawArgs.Substring(startIndex).Trim();
        }
    }

    public static void Shutdown()
    {
        if (s_instance != null)
        {
            s_instance.ShutdownImpl();
        }
    }

    private void ShutdownImpl()
    {
        CheatMgr mgr = CheatMgr.Get();
        if (ApplicationMgr.IsInternal())
        {
            mgr.UnregisterCheatHandler("has", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_HasOption));
            mgr.UnregisterCheatHandler("get", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_GetOption));
            mgr.UnregisterCheatHandler("set", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_SetOption));
            mgr.UnregisterCheatHandler("del", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_DeleteOption));
            mgr.UnregisterCheatHandler("delete", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_DeleteOption));
            mgr.UnregisterCheatHandler("collectionfirstxp", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_collectionfirstxp));
            mgr.UnregisterCheatHandler("missioncomplete", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_missioncomplete));
            mgr.UnregisterCheatHandler("board", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_board));
            mgr.UnregisterCheatHandler("resettips", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_resettips));
            mgr.UnregisterCheatHandler("questcomplete", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_questcomplete));
        }
        mgr.UnregisterCheatHandler("warning", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_warning));
        mgr.UnregisterCheatHandler("fatal", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_fatal));
        mgr.UnregisterCheatHandler("suicide", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_suicide));
        mgr.UnregisterCheatHandler("exit", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_exit));
        mgr.UnregisterCheatHandler("quit", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_exit));
        mgr.UnregisterCheatHandler("log", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_log));
    }
}


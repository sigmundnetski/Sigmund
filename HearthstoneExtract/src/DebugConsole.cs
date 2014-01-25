using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class DebugConsole
{
    private bool m_initialized;
    private static Dictionary<string, ConsoleCallbackInfo> s_clientConsoleCallbackMap;
    private static DebugConsole s_instance;
    private static Dictionary<string, ConsoleCallbackInfo> s_serverConsoleCallbackMap;

    private static List<CommandParamDecl> CreateParamDeclList(params CommandParamDecl[] paramDecls)
    {
        List<CommandParamDecl> list = new List<CommandParamDecl>();
        foreach (CommandParamDecl decl in paramDecls)
        {
            list.Add(decl);
        }
        return list;
    }

    public static DebugConsole Get()
    {
        if (s_instance == null)
        {
            s_instance = new DebugConsole();
        }
        return s_instance;
    }

    public void Init()
    {
        if (!this.m_initialized)
        {
            this.InitConsoleCallbackMaps();
            Network network = Network.Get();
            if (network.NetHandlerExists(Network.PacketID.DC_CONSOLE_CMD))
            {
                network.RemoveNetHandler(Network.PacketID.DC_CONSOLE_CMD);
            }
            if (network.NetHandlerExists(Network.PacketID.DC_RESPONSE))
            {
                network.RemoveNetHandler(Network.PacketID.DC_RESPONSE);
            }
            network.RegisterNetHandler(Network.PacketID.DC_CONSOLE_CMD, new Network.NetHandler(this.OnCommandReceived));
            network.RegisterNetHandler(Network.PacketID.DC_RESPONSE, new Network.NetHandler(this.OnCommandResponseReceived));
            this.m_initialized = true;
        }
    }

    private void InitClientConsoleCallbackMap()
    {
        if (s_clientConsoleCallbackMap == null)
        {
            s_clientConsoleCallbackMap = new Dictionary<string, ConsoleCallbackInfo>();
        }
    }

    private void InitConsoleCallbackMaps()
    {
        this.InitClientConsoleCallbackMap();
        this.InitServerConsoleCallbackMap();
    }

    private void InitServerConsoleCallbackMap()
    {
        if (s_serverConsoleCallbackMap == null)
        {
            s_serverConsoleCallbackMap = new Dictionary<string, ConsoleCallbackInfo>();
            CommandParamDecl[] paramDecls = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.STR, "cardGUID"), new CommandParamDecl(CommandParamDecl.ParamType.I32, "playerID"), new CommandParamDecl(CommandParamDecl.ParamType.STR, "zoneName"), new CommandParamDecl(CommandParamDecl.ParamType.I32, "premium") };
            s_serverConsoleCallbackMap.Add("spawncard", new ConsoleCallbackInfo(true, null, CreateParamDeclList(paramDecls)));
            CommandParamDecl[] declArray2 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "playerID") };
            s_serverConsoleCallbackMap.Add("drawcard", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray2)));
            CommandParamDecl[] declArray3 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "playerID") };
            s_serverConsoleCallbackMap.Add("shuffle", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray3)));
            CommandParamDecl[] declArray4 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "playerID") };
            s_serverConsoleCallbackMap.Add("cyclehand", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray4)));
            CommandParamDecl[] declArray5 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "playerID") };
            s_serverConsoleCallbackMap.Add("nuke", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray5)));
            CommandParamDecl[] declArray6 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "entityID"), new CommandParamDecl(CommandParamDecl.ParamType.I32, "damage") };
            s_serverConsoleCallbackMap.Add("damage", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray6)));
            CommandParamDecl[] declArray7 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "playerID") };
            s_serverConsoleCallbackMap.Add("addmana", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray7)));
            CommandParamDecl[] declArray8 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "playerID") };
            s_serverConsoleCallbackMap.Add("readymana", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray8)));
            CommandParamDecl[] declArray9 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "playerID") };
            s_serverConsoleCallbackMap.Add("maxmana", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray9)));
            s_serverConsoleCallbackMap.Add("nocosts", new ConsoleCallbackInfo(true, null, CreateParamDeclList(new CommandParamDecl[0])));
            CommandParamDecl[] declArray10 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "playerID") };
            s_serverConsoleCallbackMap.Add("healhero", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray10)));
            CommandParamDecl[] declArray11 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "entityID") };
            s_serverConsoleCallbackMap.Add("healentity", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray11)));
            CommandParamDecl[] declArray12 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "entityID") };
            s_serverConsoleCallbackMap.Add("ready", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray12)));
            CommandParamDecl[] declArray13 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "entityID") };
            s_serverConsoleCallbackMap.Add("exhaust", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray13)));
            CommandParamDecl[] declArray14 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "entityID") };
            s_serverConsoleCallbackMap.Add("freeze", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray14)));
            CommandParamDecl[] declArray15 = new CommandParamDecl[] { new CommandParamDecl(CommandParamDecl.ParamType.I32, "entityID"), new CommandParamDecl(CommandParamDecl.ParamType.I32, "zoneID") };
            s_serverConsoleCallbackMap.Add("move", new ConsoleCallbackInfo(true, null, CreateParamDeclList(declArray15)));
        }
    }

    private void OnCommandReceived()
    {
        char[] separator = new char[] { ' ' };
        string[] strArray = ConnectAPI.GetDebugConsoleCommand().Split(separator);
        if (strArray.Length == 0)
        {
            Log.Rachelle.Print("Received empty command from debug console!");
        }
        else
        {
            string key = strArray[0];
            List<string> commandParams = new List<string>();
            for (int i = 1; i < strArray.Length; i++)
            {
                commandParams.Add(strArray[i]);
            }
            if (s_serverConsoleCallbackMap.ContainsKey(key))
            {
                this.SendConsoleCmdToServer(key, commandParams);
            }
            else if (!s_clientConsoleCallbackMap.ContainsKey(key))
            {
                this.SendDebugConsoleResponse(DebugConsoleResponseType.CONSOLE_OUTPUT, string.Format("Unknown command '{0}'.", key));
            }
            else
            {
                ConsoleCallbackInfo info = s_clientConsoleCallbackMap[key];
                if (info.GetNumParams() != commandParams.Count)
                {
                    this.SendDebugConsoleResponse(DebugConsoleResponseType.CONSOLE_OUTPUT, string.Format("Invalid params for command '{0}'.", key));
                }
                else
                {
                    Log.Rachelle.Print(string.Format("Processing command '{0}' from debug console.", key));
                    info.Callback(commandParams);
                }
            }
        }
    }

    private void OnCommandResponseReceived()
    {
        Network.DebugConsoleResponse debugConsoleResponse = ConnectAPI.GetDebugConsoleResponse();
        if (debugConsoleResponse != null)
        {
            this.SendDebugConsoleResponse((DebugConsoleResponseType) debugConsoleResponse.Type, debugConsoleResponse.Response);
        }
    }

    private void SendConsoleCmdToServer(string commandName, List<string> commandParams)
    {
        if (s_serverConsoleCallbackMap.ContainsKey(commandName))
        {
            string command = commandName;
            foreach (string str2 in commandParams)
            {
                command = command + " " + str2;
            }
            if (!Network.Get().SendConsoleCmdToServer(command))
            {
                this.SendDebugConsoleResponse(DebugConsoleResponseType.CONSOLE_OUTPUT, string.Format("Cannot send command '{0}'; not currently connected to a game server.", commandName));
            }
        }
    }

    private void SendDebugConsoleResponse(DebugConsoleResponseType type, string message)
    {
        ConnectAPI.SendDebugConsoleResponse((int) type, message);
    }

    private class CommandParamDecl
    {
        public string Name;
        public ParamType Type;

        public CommandParamDecl(ParamType type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public enum ParamType
        {
            [Description("bool")]
            BOOL = 3,
            [Description("float32")]
            F32 = 2,
            [Description("int32")]
            I32 = 1,
            [Description("string")]
            STR = 0
        }
    }

    private delegate void ConsoleCallback(List<string> commandParams);

    private class ConsoleCallbackInfo
    {
        public DebugConsole.ConsoleCallback Callback;
        public bool DisplayInCommandList;
        public List<DebugConsole.CommandParamDecl> ParamList;

        public ConsoleCallbackInfo(bool displayInCmdList, DebugConsole.ConsoleCallback callback, DebugConsole.CommandParamDecl[] commandParams)
        {
            this.DisplayInCommandList = displayInCmdList;
            this.ParamList = new List<DebugConsole.CommandParamDecl>(commandParams);
            this.Callback = callback;
        }

        public ConsoleCallbackInfo(bool displayInCmdList, DebugConsole.ConsoleCallback callback, List<DebugConsole.CommandParamDecl> commandParams) : this(displayInCmdList, callback, commandParams.ToArray())
        {
        }

        public int GetNumParams()
        {
            return this.ParamList.Count;
        }
    }

    private enum DebugConsoleResponseType
    {
        CONSOLE_OUTPUT,
        LOG_MESSAGE
    }
}


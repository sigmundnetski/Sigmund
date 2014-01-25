using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

public class CheatMgr
{
    private Dictionary<string, List<ProcessCheatCallback>> m_funcMap = new Dictionary<string, List<ProcessCheatCallback>>();
    private static CheatMgr s_instance;

    private int ComputeLongestFuncIndex(List<string> funcs)
    {
        int num = 0;
        for (int i = 1; i < funcs.Count; i++)
        {
            string str = funcs[i];
            if (str.Length > funcs[num].Length)
            {
                num = i;
            }
        }
        return num;
    }

    private string ExtractFunc(string inputCommand)
    {
        inputCommand = inputCommand.Trim();
        int num = 0;
        List<string> funcs = new List<string>();
        foreach (string str in this.m_funcMap.Keys)
        {
            funcs.Add(str);
            if (str.Length > funcs[num].Length)
            {
                num = funcs.Count - 1;
            }
        }
        int num2 = 0;
        while (num2 < inputCommand.Length)
        {
            char c = inputCommand[num2];
            int index = 0;
            while (index < funcs.Count)
            {
                string str2 = funcs[index];
                if (num2 == str2.Length)
                {
                    if (char.IsWhiteSpace(c))
                    {
                        return str2;
                    }
                    funcs.RemoveAt(index);
                    if (index <= num)
                    {
                        num = this.ComputeLongestFuncIndex(funcs);
                    }
                }
                else if (str2[num2] != c)
                {
                    funcs.RemoveAt(index);
                    if (index <= num)
                    {
                        num = this.ComputeLongestFuncIndex(funcs);
                    }
                }
                else
                {
                    index++;
                }
            }
            if (funcs.Count == 0)
            {
                return null;
            }
            num2++;
        }
        if (funcs.Count > 1)
        {
            foreach (string str3 in funcs)
            {
                if (inputCommand == str3)
                {
                    return str3;
                }
            }
            return null;
        }
        string str4 = funcs[0];
        if (num2 < str4.Length)
        {
            return null;
        }
        return str4;
    }

    public static CheatMgr Get()
    {
        if (s_instance == null)
        {
            s_instance = new CheatMgr();
        }
        return s_instance;
    }

    public bool HandleKeyboardInput()
    {
        if (!Input.GetKeyUp(KeyCode.Return))
        {
            return false;
        }
        if ((!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl)) && (!Input.GetKey(KeyCode.LeftCommand) && !Input.GetKey(KeyCode.RightCommand)))
        {
            return false;
        }
        Rect rect = new Rect(0.25f, 0.9114583f, 0.5566406f, 0.02604167f);
        UniversalInputManager.Get().UseTextInputBox(SceneMgr.Get().gameObject, rect, new UniversalInputManager.InputCompletedCallback(this.ProcessInputCommand));
        return true;
    }

    private bool ProcessCheat(string inputCommand)
    {
        string str2;
        string[] strArray;
        string func = this.ExtractFunc(inputCommand);
        if (func == null)
        {
            return false;
        }
        int length = func.Length;
        if (length == inputCommand.Length)
        {
            str2 = string.Empty;
            strArray = new string[] { string.Empty };
        }
        else
        {
            str2 = inputCommand.Remove(0, length + 1);
            MatchCollection matchs = Regex.Matches(str2, @"\S+");
            if (matchs.Count == 0)
            {
                strArray = new string[] { string.Empty };
            }
            else
            {
                strArray = new string[matchs.Count];
                for (int j = 0; j < matchs.Count; j++)
                {
                    strArray[j] = matchs[j].Value;
                }
            }
        }
        bool flag = false;
        List<ProcessCheatCallback> list = this.m_funcMap[func];
        for (int i = 0; i < list.Count; i++)
        {
            ProcessCheatCallback callback = list[i];
            flag = callback(func, strArray, str2) || flag;
        }
        return flag;
    }

    private void ProcessInputCommand(string inputCommand)
    {
        inputCommand = inputCommand.TrimStart(new char[0]);
        if (!string.IsNullOrEmpty(inputCommand))
        {
            this.ProcessCheat(inputCommand);
        }
    }

    public void RegisterCheatHandler(string func, ProcessCheatCallback callback)
    {
        this.RegisterCheatHandler_(func, callback);
        this.RegisterCheatHandler_("/" + func, callback);
    }

    private void RegisterCheatHandler_(string func, ProcessCheatCallback callback)
    {
        if (string.IsNullOrEmpty(func.Trim()))
        {
            Debug.LogError("CheatMgr.RegisterCheatHandler() - FAILED to register a null, empty, or all-whitespace function name");
        }
        else
        {
            List<ProcessCheatCallback> list;
            if (this.m_funcMap.TryGetValue(func, out list))
            {
                if (!list.Contains(callback))
                {
                    list.Add(callback);
                }
            }
            else
            {
                list = new List<ProcessCheatCallback>();
                this.m_funcMap.Add(func, list);
                list.Add(callback);
            }
        }
    }

    public void UnregisterCheatHandler(string func, ProcessCheatCallback callback)
    {
        this.UnregisterCheatHandler_(func, callback);
        this.UnregisterCheatHandler_("/" + func, callback);
    }

    private void UnregisterCheatHandler_(string func, ProcessCheatCallback callback)
    {
        List<ProcessCheatCallback> list;
        if (this.m_funcMap.TryGetValue(func, out list))
        {
            list.Remove(callback);
        }
    }

    public delegate bool ProcessCheatCallback(string func, string[] args, string rawArgs);
}


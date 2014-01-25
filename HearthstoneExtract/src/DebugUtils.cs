using System;
using System.Diagnostics;
using UnityEngine;

public class DebugUtils
{
    [Conditional("UNITY_EDITOR")]
    public static void Assert(bool test)
    {
        if (!test)
        {
            UnityEngine.Debug.Break();
        }
    }

    [Conditional("UNITY_EDITOR")]
    public static void Assert(bool test, string message)
    {
        if (!test)
        {
            UnityEngine.Debug.LogWarning(message);
            UnityEngine.Debug.Break();
        }
    }
}


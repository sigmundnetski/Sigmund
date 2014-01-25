using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public static class GeneralUtils
{
    public const float DEVELOPMENT_BUILD_TEXT_WIDTH = 115f;

    public static void ExitApplication()
    {
        Application.Quit();
    }

    public static bool ForceBool(string strVal)
    {
        string str = strVal.ToLowerInvariant().Trim();
        if ((!(str == "on") && !(str == "1")) && !(str == "true"))
        {
            return false;
        }
        return true;
    }

    public static bool IsDevelopmentBuildTextVisible()
    {
        return Debug.isDebugBuild;
    }

    public static bool IsEditorPlaying()
    {
        return false;
    }

    public static bool IsOverriddenMethod(MethodInfo childMethod, MethodInfo ancestorMethod)
    {
        if (childMethod == null)
        {
            return false;
        }
        if (ancestorMethod == null)
        {
            return false;
        }
        if (childMethod.Equals(ancestorMethod))
        {
            return false;
        }
        MethodInfo baseDefinition = childMethod.GetBaseDefinition();
        while (!baseDefinition.Equals(childMethod) && !baseDefinition.Equals(ancestorMethod))
        {
            MethodInfo info2 = baseDefinition;
            baseDefinition = baseDefinition.GetBaseDefinition();
            if (baseDefinition.Equals(info2))
            {
                return false;
            }
        }
        return baseDefinition.Equals(ancestorMethod);
    }

    public static void ListSwap<T>(IList<T> list, int indexA, int indexB)
    {
        T local = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = local;
    }

    public static T[] Slice<T>(this T[] arr)
    {
        return arr.Slice<T>(0, arr.Length);
    }

    public static string Slice<T>(this string str)
    {
        return str.Slice(0, str.Length);
    }

    public static T[] Slice<T>(this T[] arr, int start)
    {
        return arr.Slice<T>(start, arr.Length);
    }

    public static string Slice(this string str, int start)
    {
        return str.Slice(start, str.Length);
    }

    public static string Slice(this string str, int start, int end)
    {
        int length = str.Length;
        if (start < 0)
        {
            start = length + start;
        }
        if (end < 0)
        {
            end = length + end;
        }
        int num2 = end - start;
        if (num2 <= 0)
        {
            return string.Empty;
        }
        int num3 = length - start;
        if (num2 > num3)
        {
            num2 = num3;
        }
        return str.Substring(start, num2);
    }

    public static T[] Slice<T>(this T[] arr, int start, int end)
    {
        int length = arr.Length;
        if (start < 0)
        {
            start = length + start;
        }
        if (end < 0)
        {
            end = length + end;
        }
        int num2 = end - start;
        if (num2 <= 0)
        {
            return new T[0];
        }
        int num3 = length - start;
        if (num2 > num3)
        {
            num2 = num3;
        }
        T[] destinationArray = new T[num2];
        Array.Copy(arr, start, destinationArray, 0, num2);
        return destinationArray;
    }

    public static void Swap<T>(ref T a, ref T b)
    {
        T local = a;
        a = b;
        b = local;
    }

    public static bool TryParseBool(string strVal, out bool boolVal)
    {
        switch (strVal.ToLowerInvariant().Trim())
        {
            case "off":
            case "0":
            case "false":
                boolVal = false;
                return true;

            case "on":
            case "1":
            case "true":
                boolVal = true;
                return true;
        }
        boolVal = false;
        return false;
    }
}


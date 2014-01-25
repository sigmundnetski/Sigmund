using System;
using UnityEngine;

public class PlatformSettings
{
    public static InputCategory s_input;
    public static bool s_isDeviceSupported = true;
    public static MemoryCategory s_memory = MemoryCategory.High;
    public static OSCategory s_os = OSCategory.PC;
    public static ScreenCategory s_screen;

    static PlatformSettings()
    {
        int systemMemorySize = SystemInfo.systemMemorySize;
        if (systemMemorySize < 500)
        {
            Debug.LogWarning("Low Memory Warning: Device has only " + systemMemorySize + "MBs of system memory");
            s_memory = MemoryCategory.Low;
        }
        else if (systemMemorySize < 0x3e8)
        {
            s_memory = MemoryCategory.Low;
        }
        else if (systemMemorySize < 0x5dc)
        {
            s_memory = MemoryCategory.Medium;
        }
        else
        {
            s_memory = MemoryCategory.High;
        }
    }

    public static InputCategory Input
    {
        get
        {
            return s_input;
        }
    }

    public static MemoryCategory Memory
    {
        get
        {
            return s_memory;
        }
    }

    public static OSCategory OS
    {
        get
        {
            return s_os;
        }
    }

    public static ScreenCategory Screen
    {
        get
        {
            return s_screen;
        }
    }
}


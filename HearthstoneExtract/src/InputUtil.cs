using System;
using UnityEngine;

public class InputUtil
{
    public static InputScheme GetInputScheme()
    {
        RuntimePlatform platform = Application.platform;
        switch (platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                return InputScheme.TOUCH;
        }
        if (((platform != RuntimePlatform.PS3) && (platform != RuntimePlatform.XBOX360)) && (platform != RuntimePlatform.WiiPlayer))
        {
            return InputScheme.KEYBOARD_MOUSE;
        }
        return InputScheme.GAMEPAD;
    }

    public static bool IsMouseOnScreen()
    {
        return ((((Input.mousePosition.x >= 0f) && (Input.mousePosition.x <= Screen.width)) && (Input.mousePosition.y >= 0f)) && (Input.mousePosition.y <= Screen.height));
    }
}


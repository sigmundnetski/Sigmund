using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ApplicationMgr : MonoBehaviour
{
    private const ApplicationMode DEFAULT_MODE = ApplicationMode.INTERNAL;
    private bool m_exiting;
    private List<FocusChangedListener> m_focusChangedListeners = new List<FocusChangedListener>();
    private bool m_focused = true;
    private bool m_manuallyTrackingFocus;
    private ApplicationMode m_mode;
    private string m_workingDir;
    private static ApplicationMgr s_instance;

    public bool AddFocusChangedListener(FocusChangedCallback callback)
    {
        return this.AddFocusChangedListener(callback, null);
    }

    public bool AddFocusChangedListener(FocusChangedCallback callback, object userData)
    {
        FocusChangedListener item = new FocusChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_focusChangedListeners.Contains(item))
        {
            return false;
        }
        this.m_focusChangedListeners.Add(item);
        return true;
    }

    private void Awake()
    {
        s_instance = this;
        this.Initialize();
    }

    public void Exit()
    {
        this.m_exiting = true;
        GeneralUtils.ExitApplication();
    }

    private void FireFocusChangedEvent()
    {
        FocusChangedListener[] listenerArray = this.m_focusChangedListeners.ToArray();
        for (int i = 0; i < listenerArray.Length; i++)
        {
            listenerArray[i].Fire(this.m_focused);
        }
    }

    public static ApplicationMgr Get()
    {
        return s_instance;
    }

    public static ApplicationMode GetMode()
    {
        return ((s_instance != null) ? s_instance.m_mode : ApplicationMode.INTERNAL);
    }

    public string GetWorkingDir()
    {
        return this.m_workingDir;
    }

    public bool HasFocus()
    {
        return this.m_focused;
    }

    private void Initialize()
    {
        this.m_workingDir = Directory.GetCurrentDirectory().Replace(@"\", "/");
        this.InitializeUnity();
        this.InitializeMode();
        this.InitializeGame();
    }

    private void InitializeGame()
    {
        if (!FileUtils.CreatePersistentDataPath())
        {
            Error.AddFatalLoc("GLOBAL_ERROR_ASSET_TITLE", "GLOBAL_ERROR_ASSET_CREATE_PERSISTENT_DATA_PATH", new object[0]);
        }
        DemoMgr.Get().Initialize();
        Localization.Initialize();
        GameStrings.Initialize();
        LocalOptions.Initialize();
        if (!PlayErrors.Init())
        {
            Debug.LogError(string.Format("{0}.DLL failed to load!", "PlayErrors32"));
        }
        Network.Initialize();
        Cheats.Initialize();
    }

    private void InitializeMode()
    {
        string def = EnumUtils.GetString<ApplicationMode>(ApplicationMode.INTERNAL);
        string str = Vars.Key("Application.Mode").GetStr(def);
        try
        {
            this.m_mode = EnumUtils.GetEnum<ApplicationMode>(str);
        }
        catch (Exception)
        {
            this.m_mode = ApplicationMode.INTERNAL;
        }
    }

    private void InitializeUnity()
    {
        Application.runInBackground = true;
        Application.targetFrameRate = 60;
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        Shader.WarmupAllShaders();
    }

    public bool IsExiting()
    {
        return this.m_exiting;
    }

    public static bool IsInternal()
    {
        return (GetMode() == ApplicationMode.INTERNAL);
    }

    public static bool IsPublic()
    {
        return (GetMode() == ApplicationMode.PUBLIC);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (this.m_focused != focus)
        {
            this.m_focused = focus;
            this.FireFocusChangedEvent();
        }
    }

    private void OnApplicationQuit()
    {
        this.Shutdown();
    }

    private void OnFullScreenOptionChanged(Option option, object prevValue, bool existed, object userData)
    {
        this.UpdateFocusTracking();
    }

    private void OnGUI()
    {
        Debug.developerConsoleVisible = false;
    }

    private void OnMouseOnOrOffScreen(bool onScreen)
    {
        this.m_focused = onScreen;
    }

    public bool RemoveFocusChangedListener(FocusChangedCallback callback)
    {
        return this.RemoveFocusChangedListener(callback, null);
    }

    public bool RemoveFocusChangedListener(FocusChangedCallback callback, object userData)
    {
        FocusChangedListener item = new FocusChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_focusChangedListeners.Remove(item);
    }

    private void Shutdown()
    {
        Network.AppQuit();
        Resources.UnloadUnusedAssets();
    }

    private void Start()
    {
        Options.Get().RegisterChangedListener(Option.GFX_FULLSCREEN, new Options.ChangedCallback(this.OnFullScreenOptionChanged));
        this.UpdateFocusTracking();
    }

    private void UpdateFocusTracking()
    {
        this.m_manuallyTrackingFocus = Screen.fullScreen;
        if (this.m_manuallyTrackingFocus)
        {
            this.m_focused = UniversalInputManager.Get().IsMouseOnScreen();
            UniversalInputManager.Get().RegisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
        }
        else
        {
            this.m_focused = true;
            UniversalInputManager.Get().UnregisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
        }
    }

    public delegate void FocusChangedCallback(bool focused, object userData);

    private class FocusChangedListener : EventListener<ApplicationMgr.FocusChangedCallback>
    {
        public void Fire(bool focused)
        {
            base.m_callback(focused, base.m_userData);
        }
    }
}


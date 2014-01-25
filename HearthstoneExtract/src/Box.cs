using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Box : MonoBehaviour
{
    public AudioListener m_AudioListener;
    public BoxSpinner m_BottomSpinner;
    private List<ButtonPressListener> m_buttonPressListeners = new List<ButtonPressListener>();
    public BoxCamera m_Camera;
    public BoxMenuButton m_CollectionButton;
    public Material m_DisabledMaterial;
    public BoxDisk m_Disk;
    public BoxDrawer m_Drawer;
    public Material m_EnabledMaterial;
    public BoxErrorHeader m_ErrorHeader;
    public BoxEventMgr m_EventMgr;
    public BoxMenuButton m_ForgeButton;
    public BoxDoor m_LeftDoor;
    public BoxLightMgr m_LightMgr;
    public BoxLoading m_Loading;
    public BoxLogo m_Logo;
    public Camera m_NoFxCamera;
    public BoxMenuButton m_OpenPacksButton;
    private int m_pendingEffects;
    public BoxMenuButton m_PracticeButton;
    public QuestLogButton m_QuestLogButton;
    public BoxDoor m_RightDoor;
    public BoxStartButton m_StartButton;
    private State m_state = State.STARTUP;
    private BoxStateConfig[] m_stateConfigs;
    public BoxStateInfoList m_StateInfoList;
    private Queue<State> m_stateQueue = new Queue<State>();
    public StoreButton m_StoreButton;
    public BoxSpinner m_TopSpinner;
    public BoxMenuButton m_TournamentButton;
    private List<TransitionFinishedListener> m_transitionFinishedListeners = new List<TransitionFinishedListener>();
    private bool m_transitioningToSceneMode;
    private bool m_waitingForNetData;
    private static readonly Vector3 QUEST_LOG_POS = new Vector3(9.238646f, 36.98974f, 0.094203f);
    private static readonly Vector3 QUEST_LOG_SCALE = new Vector3(60f, 60f, 60f);
    private static Box s_instance;
    private static readonly Vector3 STORE_POS = new Vector3(-30.50472f, 44.85855f, 1.710987f);
    private static readonly Vector3 STORE_SCALE = new Vector3(68.56598f, 68.56598f, 68.56598f);

    public void AddButtonPressListener(ButtonPressCallback callback)
    {
        this.AddButtonPressListener(callback, null);
    }

    public void AddButtonPressListener(ButtonPressCallback callback, object userData)
    {
        ButtonPressListener item = new ButtonPressListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (!this.m_buttonPressListeners.Contains(item))
        {
            this.m_buttonPressListeners.Add(item);
        }
    }

    public void AddTransitionFinishedListener(TransitionFinishedCallback callback)
    {
        this.AddTransitionFinishedListener(callback, null);
    }

    public void AddTransitionFinishedListener(TransitionFinishedCallback callback, object userData)
    {
        TransitionFinishedListener item = new TransitionFinishedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (!this.m_transitionFinishedListeners.Contains(item))
        {
            this.m_transitionFinishedListeners.Add(item);
        }
    }

    private void Awake()
    {
        s_instance = this;
        UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
        this.InitializeStateConfigs();
        if (LoadingScreen.Get() != null)
        {
            LoadingScreen.Get().NotifyMainSceneObjectAwoke(base.gameObject);
        }
    }

    private bool CanEnableUIEvents()
    {
        if (this.HasPendingEffects())
        {
            return false;
        }
        if (this.m_stateQueue.Count > 0)
        {
            return false;
        }
        if (this.m_state == State.INVALID)
        {
            return false;
        }
        if (this.m_state == State.STARTUP)
        {
            return false;
        }
        if (this.m_state == State.LOADING)
        {
            return false;
        }
        if (this.m_state == State.OPEN)
        {
            return false;
        }
        return true;
    }

    public void ChangeLightState(BoxLightStateType stateType)
    {
        this.m_LightMgr.ChangeState(stateType);
    }

    public bool ChangeState(State state)
    {
        if (state == State.INVALID)
        {
            return false;
        }
        if (this.m_state == state)
        {
            return false;
        }
        if (this.HasPendingEffects())
        {
            this.QueueStateChange(state);
        }
        else
        {
            this.ChangeStateNow(state);
        }
        return true;
    }

    private void ChangeState_Closed()
    {
        this.m_state = State.CLOSED;
        this.ChangeStateUsingConfig();
    }

    private void ChangeState_Error()
    {
        this.m_state = State.ERROR;
        this.ChangeStateUsingConfig();
    }

    private void ChangeState_Hub()
    {
        this.m_state = State.HUB;
        this.HackRequestNetFeatures();
        this.ChangeStateUsingConfig();
    }

    private void ChangeState_HubWithDrawer()
    {
        this.m_state = State.HUB_WITH_DRAWER;
        this.HackRequestNetData();
        this.ChangeStateUsingConfig();
    }

    private void ChangeState_Loading()
    {
        this.m_state = State.LOADING;
        this.ChangeStateUsingConfig();
    }

    private void ChangeState_Open()
    {
        this.m_state = State.OPEN;
        this.ChangeStateUsingConfig();
    }

    private void ChangeState_PressStart()
    {
        this.m_state = State.PRESS_START;
        this.ChangeStateUsingConfig();
    }

    private void ChangeState_Startup()
    {
        this.m_state = State.STARTUP;
        this.ChangeStateUsingConfig();
    }

    private void ChangeStateNow(State state)
    {
        this.m_state = state;
        if (state == State.STARTUP)
        {
            this.ChangeState_Startup();
        }
        else if (state == State.PRESS_START)
        {
            this.ChangeState_PressStart();
        }
        else if (state == State.LOADING)
        {
            this.ChangeState_Loading();
        }
        else if (state == State.HUB)
        {
            this.ChangeState_Hub();
        }
        else if (state == State.HUB_WITH_DRAWER)
        {
            this.ChangeState_HubWithDrawer();
        }
        else if (state == State.OPEN)
        {
            this.ChangeState_Open();
        }
        else if (state == State.CLOSED)
        {
            this.ChangeState_Closed();
        }
        else if (state == State.ERROR)
        {
            this.ChangeState_Error();
        }
        else
        {
            Debug.LogError(string.Format("Box.ChangeStateNow() - unhandled state {0}", state));
        }
        this.UpdateUIEvents();
    }

    private void ChangeStateQueued()
    {
        State state = this.m_stateQueue.Dequeue();
        this.ChangeStateNow(state);
    }

    private void ChangeStateToReflectSceneMode(SceneMgr.Mode mode)
    {
        State state = this.TranslateSceneModeToBoxState(mode);
        if (this.ChangeState(state))
        {
            this.m_transitioningToSceneMode = true;
        }
        BoxLightStateType stateType = this.TranslateSceneModeToLightState(mode);
        this.m_LightMgr.ChangeState(stateType);
    }

    private void ChangeStateUsingConfig()
    {
        BoxStateConfig config = this.m_stateConfigs[(int) this.m_state];
        if (!config.m_logoState.m_ignore)
        {
            this.m_Logo.ChangeState(config.m_logoState.m_state);
        }
        if (!config.m_startButtonState.m_ignore)
        {
            this.m_StartButton.ChangeState(config.m_startButtonState.m_state);
        }
        if (!config.m_loadingState.m_ignore)
        {
            this.m_Loading.ChangeState(config.m_loadingState.m_state);
        }
        if (!config.m_doorState.m_ignore)
        {
            this.m_LeftDoor.ChangeState(config.m_doorState.m_state);
            this.m_RightDoor.ChangeState(config.m_doorState.m_state);
        }
        if (!config.m_diskState.m_ignore)
        {
            this.m_Disk.ChangeState(config.m_diskState.m_state);
        }
        if (!config.m_drawerState.m_ignore)
        {
            this.m_Drawer.ChangeState(config.m_drawerState.m_state);
        }
        if (!config.m_camState.m_ignore)
        {
            this.m_Camera.ChangeState(config.m_camState.m_state);
        }
        if (!config.m_errorHeaderState.m_ignore)
        {
            this.m_ErrorHeader.ChangeState(config.m_errorHeaderState.m_state);
        }
        if (!config.m_fullScreenBlackState.m_ignore)
        {
            this.FullScreenBlack_ChangeState(config.m_fullScreenBlackState.m_state);
        }
    }

    private int ComputeBoosterCount()
    {
        return NetCache.Get().GetNetObject<NetCache.NetCacheBoosters>().GetTotalNumBoosters();
    }

    private void DisableButton(PegUIElement button)
    {
        button.SetEnabled(false);
        TooltipZone component = button.GetComponent<TooltipZone>();
        if (component != null)
        {
            component.HideTooltip();
        }
    }

    private void EnableButton(PegUIElement button)
    {
        button.SetEnabled(true);
    }

    private void FireButtonPressEvent(ButtonType buttonType)
    {
        foreach (ButtonPressListener listener in this.m_buttonPressListeners.ToArray())
        {
            listener.Fire(buttonType);
        }
    }

    private void FireTransitionFinishedEvent()
    {
        foreach (TransitionFinishedListener listener in this.m_transitionFinishedListeners.ToArray())
        {
            listener.Fire();
        }
    }

    private void FullScreenBlack_ChangeState(bool enable)
    {
        this.FullScreenBlack_UpdateState(enable);
    }

    private void FullScreenBlack_UpdateState(bool enable)
    {
        FullScreenEffects component = this.m_Camera.GetComponent<FullScreenEffects>();
        component.BlendToColorEnable = enable;
        if (enable)
        {
            component.BlendToColor = Color.black;
            component.BlendToColorAmount = 1f;
        }
    }

    public static Box Get()
    {
        return s_instance;
    }

    public AudioListener GetAudioListener()
    {
        return this.m_AudioListener;
    }

    public BoxCamera GetBoxCamera()
    {
        return this.m_Camera;
    }

    public Camera GetCamera()
    {
        return this.m_Camera.camera;
    }

    public BoxEventMgr GetEventMgr()
    {
        return this.m_EventMgr;
    }

    public Spell GetEventSpell(BoxEventType eventType)
    {
        return this.m_EventMgr.GetEventSpell(eventType);
    }

    public BoxLightMgr GetLightMgr()
    {
        return this.m_LightMgr;
    }

    public BoxLightStateType GetLightState()
    {
        return this.m_LightMgr.GetActiveState();
    }

    public Camera GetNoFxCamera()
    {
        return this.m_NoFxCamera;
    }

    public State GetState()
    {
        return this.m_state;
    }

    private void HackRequestNetData()
    {
        this.m_waitingForNetData = true;
        this.UpdateUI();
        NetCache.Get().ReloadNetObject<NetCache.NetCacheBoosters>();
        NetCache.Get().ReloadNetObject<NetCache.NetCacheFeatures>();
    }

    private void HackRequestNetFeatures()
    {
        this.m_waitingForNetData = true;
        this.UpdateUI();
        NetCache.Get().ReloadNetObject<NetCache.NetCacheFeatures>();
    }

    public bool HasPendingEffects()
    {
        return (this.m_pendingEffects > 0);
    }

    private void HighlightButton(BoxMenuButton button, bool highlightOn)
    {
        if (button.m_HighlightState == null)
        {
            Debug.LogWarning(string.Format("Box.HighlighButton {0} - highlight state is null", button));
        }
        else
        {
            ActorStateType stateType = !highlightOn ? ActorStateType.HIGHLIGHT_OFF : ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE;
            button.m_HighlightState.ChangeState(stateType);
        }
    }

    private void InitializeComponents()
    {
        this.m_StoreButton.SetStorePosAndScale(STORE_POS, STORE_SCALE);
        this.m_QuestLogButton.SetQuestLogPosAndScale(QUEST_LOG_POS, QUEST_LOG_SCALE);
        this.m_Logo.SetParent(this);
        this.m_Logo.SetInfo(this.m_StateInfoList.m_LogoInfo);
        this.m_StartButton.SetParent(this);
        this.m_StartButton.SetInfo(this.m_StateInfoList.m_StartButtonInfo);
        this.m_Loading.SetParent(this);
        this.m_Loading.SetInfo(this.m_StateInfoList.m_LoadingInfo);
        this.m_LeftDoor.SetParent(this);
        this.m_LeftDoor.SetInfo(this.m_StateInfoList.m_LeftDoorInfo);
        this.m_RightDoor.SetParent(this);
        this.m_RightDoor.SetInfo(this.m_StateInfoList.m_RightDoorInfo);
        this.m_RightDoor.EnableMaster(true);
        this.m_Disk.SetParent(this);
        this.m_Disk.SetInfo(this.m_StateInfoList.m_DiskInfo);
        this.m_TopSpinner.SetParent(this);
        this.m_TopSpinner.SetInfo(this.m_StateInfoList.m_SpinnerInfo);
        this.m_BottomSpinner.SetParent(this);
        this.m_BottomSpinner.SetInfo(this.m_StateInfoList.m_SpinnerInfo);
        this.m_Drawer.SetParent(this);
        this.m_Drawer.SetInfo(this.m_StateInfoList.m_DrawerInfo);
        this.m_Camera.SetParent(this);
        this.m_Camera.SetInfo(this.m_StateInfoList.m_CameraInfo);
        this.m_Camera.GetComponent<FullScreenEffects>().BlendToColorEnable = false;
    }

    public void InitializeNet()
    {
        if (SceneMgr.Get() != null)
        {
            this.m_waitingForNetData = true;
            if (SceneMgr.Get().GetMode() != SceneMgr.Mode.STARTUP)
            {
                NetCache.Get().RegisterScreenBox(new NetCache.NetCacheCallback(this.OnNetCacheReady));
                NetCache.Get().RegisterProfileNotices(new NetCache.NetCacheCallback(this.OnProfileNoticesReady));
            }
        }
    }

    private void InitializeState()
    {
        this.m_state = State.STARTUP;
        bool flag = MissionMgr.Get().CameFromTutorial();
        SceneMgr mgr = SceneMgr.Get();
        if (mgr != null)
        {
            if (flag)
            {
                this.m_state = State.LOADING;
            }
            else
            {
                mgr.RegisterScenePreUnloadEvent(new SceneMgr.ScenePreUnloadCallback(this.OnScenePreUnload));
                mgr.RegisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
                this.m_state = this.TranslateSceneModeToBoxState(mgr.GetMode());
            }
        }
        this.UpdateState();
        this.m_TopSpinner.Spin();
        this.m_BottomSpinner.Spin();
        if (flag)
        {
            LoadingScreen.Get().RegisterPreviousSceneDestroyedListener(new LoadingScreen.PreviousSceneDestroyedCallback(this.OnTutorialSceneDestroyed));
        }
    }

    private void InitializeStateConfigs()
    {
        int length = Enum.GetValues(typeof(State)).Length;
        this.m_stateConfigs = new BoxStateConfig[length];
        this.m_stateConfigs[1] = new BoxStateConfig { m_logoState = { m_state = BoxLogo.State.HIDDEN }, m_startButtonState = { m_state = BoxStartButton.State.HIDDEN }, m_loadingState = { m_state = BoxLoading.State.HIDDEN }, m_errorHeaderState = { m_state = BoxErrorHeader.State.HIDDEN }, m_fullScreenBlackState = { m_state = true } };
        this.m_stateConfigs[2] = new BoxStateConfig { m_loadingState = { m_state = BoxLoading.State.HIDDEN }, m_errorHeaderState = { m_state = BoxErrorHeader.State.HIDDEN }, m_fullScreenBlackState = { m_ignore = true } };
        this.m_stateConfigs[3] = new BoxStateConfig { m_logoState = { m_state = BoxLogo.State.HIDDEN }, m_startButtonState = { m_state = BoxStartButton.State.HIDDEN }, m_loadingState = { m_state = BoxLoading.State.HIDDEN }, m_drawerState = { m_state = BoxDrawer.State.OPENED }, m_camState = { m_state = BoxCamera.State.CLOSED_WITH_DRAWER }, m_errorHeaderState = { m_state = BoxErrorHeader.State.HIDDEN }, m_fullScreenBlackState = { m_ignore = true } };
        this.m_stateConfigs[4] = new BoxStateConfig { m_logoState = { m_state = BoxLogo.State.HIDDEN }, m_startButtonState = { m_state = BoxStartButton.State.HIDDEN }, m_loadingState = { m_state = BoxLoading.State.HIDDEN }, m_diskState = { m_state = BoxDisk.State.MAINMENU }, m_errorHeaderState = { m_state = BoxErrorHeader.State.HIDDEN }, m_fullScreenBlackState = { m_ignore = true } };
        this.m_stateConfigs[5] = new BoxStateConfig { m_logoState = { m_state = BoxLogo.State.HIDDEN }, m_startButtonState = { m_state = BoxStartButton.State.HIDDEN }, m_loadingState = { m_state = BoxLoading.State.HIDDEN }, m_diskState = { m_state = BoxDisk.State.MAINMENU }, m_drawerState = { m_state = BoxDrawer.State.OPENED }, m_camState = { m_state = BoxCamera.State.CLOSED_WITH_DRAWER }, m_errorHeaderState = { m_state = BoxErrorHeader.State.HIDDEN }, m_fullScreenBlackState = { m_ignore = true } };
        this.m_stateConfigs[6] = new BoxStateConfig { m_logoState = { m_state = BoxLogo.State.HIDDEN }, m_startButtonState = { m_state = BoxStartButton.State.HIDDEN }, m_loadingState = { m_state = BoxLoading.State.HIDDEN }, m_doorState = { m_state = BoxDoor.State.OPENED }, m_drawerState = { m_state = BoxDrawer.State.OPENED }, m_camState = { m_state = BoxCamera.State.OPENED }, m_errorHeaderState = { m_state = BoxErrorHeader.State.HIDDEN }, m_fullScreenBlackState = { m_ignore = true } };
        this.m_stateConfigs[7] = new BoxStateConfig { m_logoState = { m_state = BoxLogo.State.HIDDEN }, m_startButtonState = { m_state = BoxStartButton.State.HIDDEN }, m_loadingState = { m_state = BoxLoading.State.HIDDEN }, m_errorHeaderState = { m_state = BoxErrorHeader.State.HIDDEN } };
        this.m_stateConfigs[8] = new BoxStateConfig { m_logoState = { m_state = BoxLogo.State.HIDDEN }, m_startButtonState = { m_state = BoxStartButton.State.HIDDEN }, m_loadingState = { m_state = BoxLoading.State.HIDDEN } };
    }

    private void InitializeUI()
    {
        PegUI.Get().SetInputCamera(this.m_Camera.camera);
        this.m_StartButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnStartButtonPressed));
        switch (InputUtil.GetInputScheme())
        {
            case InputScheme.TOUCH:
                this.m_StartButton.SetText(GameStrings.Get("GLUE_START_TOUCH"));
                break;

            case InputScheme.GAMEPAD:
                this.m_StartButton.SetText(GameStrings.Get("GLUE_START_PRESS"));
                break;

            case InputScheme.KEYBOARD_MOUSE:
                this.m_StartButton.SetText(GameStrings.Get("GLUE_START_CLICK"));
                break;
        }
        this.m_TournamentButton.SetText(GameStrings.Get("GLUE_TOURNAMENT"));
        this.m_PracticeButton.SetText(GameStrings.Get("GLUE_PRACTICE"));
        this.m_ForgeButton.SetText(GameStrings.Get("GLUE_FORGE"));
        this.m_CollectionButton.SetText(GameStrings.Get("GLUE_MY_COLLECTION"));
        this.RegisterButtonEvents(this.m_TournamentButton);
        this.RegisterButtonEvents(this.m_PracticeButton);
        this.RegisterButtonEvents(this.m_ForgeButton);
        this.RegisterButtonEvents(this.m_OpenPacksButton);
        this.RegisterButtonEvents(this.m_CollectionButton);
        this.UpdateUI();
    }

    public bool IsBusy()
    {
        return (this.HasPendingEffects() || (this.m_stateQueue.Count > 0));
    }

    public void OnAnimFinished()
    {
        this.m_pendingEffects--;
        if (!this.HasPendingEffects())
        {
            if (this.m_stateQueue.Count == 0)
            {
                this.UpdateUIEvents();
                if (this.m_transitioningToSceneMode)
                {
                    this.FireTransitionFinishedEvent();
                    this.m_transitioningToSceneMode = false;
                }
            }
            else
            {
                this.ChangeStateQueued();
            }
        }
    }

    public void OnAnimStarted()
    {
        this.m_pendingEffects++;
    }

    private void OnButtonMouseOut(UIEvent e)
    {
        TooltipZone component = e.GetElement().gameObject.GetComponent<TooltipZone>();
        if (component != null)
        {
            component.HideTooltip();
        }
    }

    private void OnButtonMouseOver(UIEvent e)
    {
        TooltipZone component = e.GetElement().gameObject.GetComponent<TooltipZone>();
        if (component != null)
        {
            bool flag = (AchieveManager.Get() != null) && AchieveManager.Get().HasUnlockedFeature(Achievement.UnlockableFeature.FORGE);
            string bodytext = GameStrings.Get("GLUE_TOOLTIP_BUTTON_DISABLED_DESC");
            NetCache.NetCacheFeatures netObject = NetCache.Get().GetNetObject<NetCache.NetCacheFeatures>();
            bool tournament = netObject.Games.Tournament;
            bool practice = netObject.Games.Practice;
            bool flag4 = netObject.Games.Forge && flag;
            bool manager = netObject.Collection.Manager;
            if ((component.targetObject == this.m_TournamentButton.gameObject) && tournament)
            {
                bodytext = GameStrings.Get("GLUE_TOOLTIP_BUTTON_TOURNAMENT_DESC");
            }
            else if ((component.targetObject == this.m_PracticeButton.gameObject) && practice)
            {
                bodytext = GameStrings.Get("GLUE_TOOLTIP_BUTTON_PRACTICE_DESC");
            }
            else if (component.targetObject == this.m_ForgeButton.gameObject)
            {
                if (flag4)
                {
                    bodytext = GameStrings.Get("GLUE_TOOLTIP_BUTTON_FORGE_DESC");
                }
                else if (!flag)
                {
                    object[] args = new object[] { 20 };
                    bodytext = GameStrings.Format("GLUE_TOOLTIP_BUTTON_FORGE_NOT_UNLOCKED", args);
                }
            }
            else if (component.targetObject == this.m_OpenPacksButton.gameObject)
            {
                bodytext = GameStrings.Get("GLUE_TOOLTIP_BUTTON_PACKOPEN_DESC");
            }
            else if ((component.targetObject == this.m_CollectionButton.gameObject) && manager)
            {
                bodytext = GameStrings.Get("GLUE_TOOLTIP_BUTTON_COLLECTION_DESC");
            }
            if (component.targetObject == this.m_TournamentButton.gameObject)
            {
                component.ShowBoxTooltip(GameStrings.Get("GLUE_TOOLTIP_BUTTON_TOURNAMENT_HEADLINE"), bodytext);
            }
            else if (component.targetObject == this.m_PracticeButton.gameObject)
            {
                component.ShowBoxTooltip(GameStrings.Get("GLUE_TOOLTIP_BUTTON_PRACTICE_HEADLINE"), bodytext);
            }
            else if (component.targetObject == this.m_ForgeButton.gameObject)
            {
                component.ShowBoxTooltip(GameStrings.Get("GLUE_TOOLTIP_BUTTON_FORGE_HEADLINE"), bodytext);
            }
            else if (component.targetObject == this.m_OpenPacksButton.gameObject)
            {
                component.ShowBoxTooltip(GameStrings.Get("GLUE_TOOLTIP_BUTTON_PACKOPEN_HEADLINE"), bodytext);
            }
            else if (component.targetObject == this.m_CollectionButton.gameObject)
            {
                component.ShowBoxTooltip(GameStrings.Get("GLUE_TOOLTIP_BUTTON_COLLECTION_HEADLINE"), bodytext);
            }
        }
    }

    private void OnButtonPressed(UIEvent e)
    {
        PegUIElement element = e.GetElement();
        NetCache.NetCacheFeatures netObject = NetCache.Get().GetNetObject<NetCache.NetCacheFeatures>();
        bool tournament = netObject.Games.Tournament;
        bool practice = netObject.Games.Practice;
        bool flag3 = (netObject.Games.Forge && (AchieveManager.Get() != null)) && AchieveManager.Get().HasUnlockedFeature(Achievement.UnlockableFeature.FORGE);
        bool manager = netObject.Collection.Manager;
        BoxMenuButton button = (BoxMenuButton) element;
        if (button == this.m_StartButton)
        {
            this.OnStartButtonPressed(e);
        }
        else if ((button == this.m_TournamentButton) && tournament)
        {
            this.OnTournamentButtonPressed(e);
        }
        else if ((button == this.m_PracticeButton) && practice)
        {
            this.OnPracticeButtonPressed(e);
        }
        else if ((button == this.m_ForgeButton) && flag3)
        {
            this.OnForgeButtonPressed(e);
        }
        else if (button == this.m_OpenPacksButton)
        {
            this.OnOpenPacksButtonPressed(e);
        }
        else if ((button == this.m_CollectionButton) && manager)
        {
            this.OnCollectionButtonPressed(e);
        }
    }

    private void OnCollectionButtonPressed(UIEvent e)
    {
        if (SceneMgr.Get() == null)
        {
            this.ChangeState(State.OPEN);
        }
        else
        {
            this.FireButtonPressEvent(ButtonType.COLLECTION);
        }
    }

    private void OnDestroy()
    {
        if (!ApplicationMgr.Get().IsExiting())
        {
            this.ShutdownState();
            this.ShutdownNet();
        }
    }

    private void OnForgeButtonPressed(UIEvent e)
    {
        if (SceneMgr.Get() == null)
        {
            this.ChangeState(State.OPEN);
        }
        else
        {
            this.FireButtonPressEvent(ButtonType.FORGE);
        }
    }

    public void OnLoggedIn()
    {
        this.InitializeNet();
    }

    private void OnNetCacheReady()
    {
        this.m_waitingForNetData = false;
        this.UpdateUI();
    }

    private void OnOpenPacksButtonPressed(UIEvent e)
    {
        if (SceneMgr.Get() == null)
        {
            this.ChangeState(State.OPEN);
        }
        else
        {
            this.FireButtonPressEvent(ButtonType.OPEN_PACKS);
        }
    }

    private void OnPracticeButtonPressed(UIEvent e)
    {
        if (SceneMgr.Get() == null)
        {
            this.ChangeState(State.OPEN);
        }
        else
        {
            this.FireButtonPressEvent(ButtonType.PRACTICE);
        }
    }

    private void OnProfileNoticesReady()
    {
        NetCache.NetCacheProfileNotices netObject = NetCache.Get().GetNetObject<NetCache.NetCacheProfileNotices>();
        DialogManager.Get().ShowProfileNotices(netObject.Notices);
    }

    private void OnSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
        this.ChangeStateToReflectSceneMode(mode);
    }

    private void OnScenePreUnload(SceneMgr.Mode prevMode, Scene prevScene, object userData)
    {
        SceneMgr.Mode mode = SceneMgr.Get().GetMode();
        if (mode != SceneMgr.Mode.GAMEPLAY)
        {
            if (prevMode == SceneMgr.Mode.HUB)
            {
                this.ChangeState(State.LOADING);
                this.m_StoreButton.Unload();
                this.m_QuestLogButton.Unload();
            }
            else if (mode == SceneMgr.Mode.HUB)
            {
                this.ChangeState(this.TranslateSceneModeToBoxState(mode));
            }
            this.UpdateUIEvents();
        }
    }

    private void OnStartButtonPressed(UIEvent e)
    {
        if (SceneMgr.Get() == null)
        {
            this.ChangeState(State.HUB);
        }
        else
        {
            this.FireButtonPressEvent(ButtonType.START);
        }
    }

    private void OnTournamentButtonPressed(UIEvent e)
    {
        if (SceneMgr.Get() == null)
        {
            this.ChangeState(State.OPEN);
        }
        else
        {
            if (!Options.Get().HasOption(Option.HAS_CLICKED_TOURNAMENT))
            {
                Options.Get().SetBool(Option.HAS_CLICKED_TOURNAMENT, true);
            }
            AchieveManager.Get().NotifyOfClick(Achievement.ClickTriggerType.BUTTON_PLAY);
            this.FireButtonPressEvent(ButtonType.TOURNAMENT);
        }
    }

    private void OnTutorialPlaySpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            SceneMgr mgr = SceneMgr.Get();
            mgr.RegisterScenePreUnloadEvent(new SceneMgr.ScenePreUnloadCallback(this.OnScenePreUnload));
            mgr.RegisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
            this.ChangeStateToReflectSceneMode(SceneMgr.Get().GetMode());
        }
    }

    private void OnTutorialSceneDestroyed(object userData)
    {
        LoadingScreen.Get().UnregisterPreviousSceneDestroyedListener(new LoadingScreen.PreviousSceneDestroyedCallback(this.OnTutorialSceneDestroyed));
        Spell eventSpell = this.GetEventSpell(BoxEventType.TUTORIAL_PLAY);
        eventSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnTutorialPlaySpellStateFinished));
        eventSpell.ActivateState(SpellStateType.DEATH);
    }

    private void QueueStateChange(State state)
    {
        this.m_stateQueue.Enqueue(state);
    }

    private void RegisterButtonEvents(PegUIElement button)
    {
        button.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnButtonPressed));
        button.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnButtonMouseOver));
        button.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.OnButtonMouseOut));
    }

    public bool RemoveButtonPressListener(ButtonPressCallback callback)
    {
        return this.RemoveButtonPressListener(callback, null);
    }

    public bool RemoveButtonPressListener(ButtonPressCallback callback, object userData)
    {
        ButtonPressListener item = new ButtonPressListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_buttonPressListeners.Remove(item);
    }

    public bool RemoveTransitionFinishedListener(TransitionFinishedCallback callback)
    {
        return this.RemoveTransitionFinishedListener(callback, null);
    }

    public bool RemoveTransitionFinishedListener(TransitionFinishedCallback callback, object userData)
    {
        TransitionFinishedListener item = new TransitionFinishedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_transitionFinishedListeners.Remove(item);
    }

    public void ResetLayers()
    {
        SceneUtils.ReplaceLayer(this.m_LeftDoor.gameObject, GameLayer.Default, GameLayer.IgnoreFullScreenEffects);
        SceneUtils.ReplaceLayer(this.m_RightDoor.gameObject, GameLayer.Default, GameLayer.IgnoreFullScreenEffects);
    }

    public void SetLightState(BoxLightStateType stateType)
    {
        this.m_LightMgr.SetState(stateType);
    }

    public void SetToIgnoreFullScreenEffects()
    {
        SceneUtils.ReplaceLayer(this.m_LeftDoor.gameObject, GameLayer.IgnoreFullScreenEffects, GameLayer.Default);
        SceneUtils.ReplaceLayer(this.m_RightDoor.gameObject, GameLayer.IgnoreFullScreenEffects, GameLayer.Default);
    }

    private void ShutdownNet()
    {
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnProfileNoticesReady));
    }

    private void ShutdownState()
    {
        if (this.m_StoreButton != null)
        {
            this.m_StoreButton.Unload();
        }
        if (this.m_QuestLogButton != null)
        {
            this.m_QuestLogButton.Unload();
        }
        SceneMgr mgr = SceneMgr.Get();
        if (mgr != null)
        {
            mgr.UnregisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
            mgr.UnregisterScenePreUnloadEvent(new SceneMgr.ScenePreUnloadCallback(this.OnScenePreUnload));
        }
    }

    private void Start()
    {
        SceneMgr.Get().DisableCamera();
        this.InitializeNet();
        this.InitializeComponents();
        this.InitializeState();
        this.InitializeUI();
        if (DemoMgr.Get().GetMode() == DemoMode.PAX_EAST_2013)
        {
            this.m_StoreButton.gameObject.SetActive(false);
            this.m_Drawer.gameObject.SetActive(false);
        }
    }

    private void ToggleButtonTextureState(bool enabled, BoxMenuButton button)
    {
        if (enabled)
        {
            button.m_TextMesh.renderer.material = this.m_EnabledMaterial;
        }
        else
        {
            button.m_TextMesh.renderer.material = this.m_DisabledMaterial;
        }
    }

    private State TranslateSceneModeToBoxState(SceneMgr.Mode mode)
    {
        if (mode == SceneMgr.Mode.STARTUP)
        {
            return State.STARTUP;
        }
        if (mode == SceneMgr.Mode.LOGIN)
        {
            return State.INVALID;
        }
        if (mode == SceneMgr.Mode.HUB)
        {
            return State.HUB_WITH_DRAWER;
        }
        if (mode != SceneMgr.Mode.TOURNAMENT)
        {
            if (mode == SceneMgr.Mode.PRACTICE)
            {
                return State.OPEN;
            }
            if (mode == SceneMgr.Mode.FRIENDLY)
            {
                return State.OPEN;
            }
            if (mode == SceneMgr.Mode.DRAFT)
            {
                return State.OPEN;
            }
            if (mode == SceneMgr.Mode.COLLECTIONMANAGER)
            {
                return State.OPEN;
            }
            if (mode == SceneMgr.Mode.GAMEPLAY)
            {
                return State.INVALID;
            }
            if (mode == SceneMgr.Mode.FATAL_ERROR)
            {
                return State.ERROR;
            }
        }
        return State.OPEN;
    }

    private BoxLightStateType TranslateSceneModeToLightState(SceneMgr.Mode mode)
    {
        if (mode == SceneMgr.Mode.LOGIN)
        {
            return BoxLightStateType.INVALID;
        }
        if (mode == SceneMgr.Mode.TOURNAMENT)
        {
            return BoxLightStateType.TOURNAMENT;
        }
        if (mode == SceneMgr.Mode.COLLECTIONMANAGER)
        {
            return BoxLightStateType.INVALID;
        }
        if (mode == SceneMgr.Mode.GAMEPLAY)
        {
            return BoxLightStateType.INVALID;
        }
        if (mode == SceneMgr.Mode.DRAFT)
        {
            return BoxLightStateType.FORGE;
        }
        if (mode == SceneMgr.Mode.PRACTICE)
        {
            return BoxLightStateType.PRACTICE;
        }
        if (mode == SceneMgr.Mode.FRIENDLY)
        {
            return BoxLightStateType.PRACTICE;
        }
        return BoxLightStateType.DEFAULT;
    }

    public void UpdateState()
    {
        if (this.m_state == State.STARTUP)
        {
            this.UpdateState_Startup();
        }
        else if (this.m_state == State.PRESS_START)
        {
            this.UpdateState_PressStart();
        }
        else if (this.m_state == State.LOADING)
        {
            this.UpdateState_Loading();
        }
        else if (this.m_state == State.HUB)
        {
            this.UpdateState_Hub();
        }
        else if (this.m_state == State.HUB_WITH_DRAWER)
        {
            this.UpdateState_HubWithDrawer();
        }
        else if (this.m_state == State.OPEN)
        {
            this.UpdateState_Open();
        }
        else if (this.m_state == State.CLOSED)
        {
            this.UpdateState_Closed();
        }
        else if (this.m_state == State.ERROR)
        {
            this.UpdateState_Error();
        }
        else
        {
            Debug.LogError(string.Format("Box.UpdateState() - unhandled state {0}", this.m_state));
        }
    }

    private void UpdateState_Closed()
    {
        this.m_state = State.CLOSED;
        this.UpdateStateUsingConfig();
    }

    private void UpdateState_Error()
    {
        this.m_state = State.ERROR;
        this.UpdateStateUsingConfig();
    }

    private void UpdateState_Hub()
    {
        this.m_state = State.HUB;
        this.HackRequestNetFeatures();
        this.UpdateStateUsingConfig();
    }

    private void UpdateState_HubWithDrawer()
    {
        this.m_state = State.HUB_WITH_DRAWER;
        this.HackRequestNetData();
        this.UpdateStateUsingConfig();
    }

    private void UpdateState_Loading()
    {
        this.m_state = State.LOADING;
        this.UpdateStateUsingConfig();
    }

    private void UpdateState_Open()
    {
        this.m_state = State.OPEN;
        this.UpdateStateUsingConfig();
    }

    private void UpdateState_PressStart()
    {
        this.m_state = State.PRESS_START;
        this.UpdateStateUsingConfig();
    }

    private void UpdateState_Startup()
    {
        this.m_state = State.STARTUP;
        this.UpdateStateUsingConfig();
    }

    private void UpdateStateUsingConfig()
    {
        BoxStateConfig config = this.m_stateConfigs[(int) this.m_state];
        if (!config.m_logoState.m_ignore)
        {
            this.m_Logo.UpdateState(config.m_logoState.m_state);
        }
        if (!config.m_startButtonState.m_ignore)
        {
            this.m_StartButton.UpdateState(config.m_startButtonState.m_state);
        }
        if (!config.m_loadingState.m_ignore)
        {
            this.m_Loading.UpdateState(config.m_loadingState.m_state);
        }
        if (!config.m_doorState.m_ignore)
        {
            this.m_LeftDoor.ChangeState(config.m_doorState.m_state);
            this.m_RightDoor.ChangeState(config.m_doorState.m_state);
        }
        if (!config.m_diskState.m_ignore)
        {
            this.m_Disk.UpdateState(config.m_diskState.m_state);
        }
        this.m_TopSpinner.Reset();
        this.m_BottomSpinner.Reset();
        if (!config.m_drawerState.m_ignore)
        {
            this.m_Drawer.UpdateState(config.m_drawerState.m_state);
        }
        if (!config.m_camState.m_ignore)
        {
            this.m_Camera.UpdateState(config.m_camState.m_state);
        }
        if (!config.m_errorHeaderState.m_ignore)
        {
            this.m_ErrorHeader.UpdateState(config.m_errorHeaderState.m_state);
        }
        if (!config.m_fullScreenBlackState.m_ignore)
        {
            this.FullScreenBlack_UpdateState(config.m_fullScreenBlackState.m_state);
        }
    }

    private void UpdateUI()
    {
        this.UpdateUIState();
        this.UpdateUIEvents();
    }

    private void UpdateUIEvents()
    {
        if (this.CanEnableUIEvents() && (this.m_state == State.PRESS_START))
        {
            this.EnableButton(this.m_StartButton);
        }
        else
        {
            this.DisableButton(this.m_StartButton);
        }
        if (this.CanEnableUIEvents() && ((this.m_state == State.HUB) || (this.m_state == State.HUB_WITH_DRAWER)))
        {
            if (this.m_waitingForNetData)
            {
                this.DisableButton(this.m_TournamentButton);
                this.DisableButton(this.m_PracticeButton);
                this.DisableButton(this.m_ForgeButton);
                this.DisableButton(this.m_QuestLogButton);
                this.DisableButton(this.m_StoreButton);
            }
            else
            {
                this.EnableButton(this.m_TournamentButton);
                this.EnableButton(this.m_PracticeButton);
                this.EnableButton(this.m_ForgeButton);
                this.EnableButton(this.m_QuestLogButton);
                this.EnableButton(this.m_StoreButton);
            }
            if (this.m_state == State.HUB_WITH_DRAWER)
            {
                if (this.m_waitingForNetData)
                {
                    this.DisableButton(this.m_OpenPacksButton);
                    this.DisableButton(this.m_CollectionButton);
                }
                else
                {
                    this.EnableButton(this.m_OpenPacksButton);
                    this.EnableButton(this.m_CollectionButton);
                }
            }
            else
            {
                this.DisableButton(this.m_OpenPacksButton);
                this.DisableButton(this.m_CollectionButton);
            }
        }
        else
        {
            this.DisableButton(this.m_TournamentButton);
            this.DisableButton(this.m_PracticeButton);
            this.DisableButton(this.m_ForgeButton);
            this.DisableButton(this.m_OpenPacksButton);
            this.DisableButton(this.m_CollectionButton);
            this.DisableButton(this.m_QuestLogButton);
            this.DisableButton(this.m_StoreButton);
        }
    }

    private void UpdateUIState()
    {
        if (this.m_waitingForNetData)
        {
            this.m_OpenPacksButton.SetText(string.Empty);
            this.HighlightButton(this.m_OpenPacksButton, false);
            this.HighlightButton(this.m_TournamentButton, false);
            this.HighlightButton(this.m_PracticeButton, false);
            this.HighlightButton(this.m_CollectionButton, false);
            this.HighlightButton(this.m_ForgeButton, false);
        }
        else
        {
            NetCache.NetCacheFeatures netObject = NetCache.Get().GetNetObject<NetCache.NetCacheFeatures>();
            int num = this.ComputeBoosterCount();
            object[] args = new object[] { num };
            this.m_OpenPacksButton.SetText(GameStrings.Format("GLUE_PACK_OPENING_BOOSTER_COUNT", args));
            bool highlightOn = (num > 0) && !Options.Get().GetBool(Option.HAS_SEEN_PACK_OPENING, false);
            this.HighlightButton(this.m_OpenPacksButton, highlightOn);
            bool flag2 = netObject.Games.Practice && !Options.Get().GetBool(Option.HAS_SEEN_PRACTICE_MODE, false);
            this.HighlightButton(this.m_PracticeButton, flag2);
            this.ToggleButtonTextureState(netObject.Games.Practice, this.m_PracticeButton);
            bool flag3 = (!flag2 && netObject.Games.Tournament) && !Options.Get().GetBool(Option.HAS_SEEN_TOURNAMENT, false);
            this.HighlightButton(this.m_TournamentButton, flag3);
            this.ToggleButtonTextureState(netObject.Games.Tournament, this.m_TournamentButton);
            bool flag4 = (!flag2 && netObject.Collection.Manager) && !Options.Get().GetBool(Option.HAS_SEEN_COLLECTIONMANAGER, false);
            this.HighlightButton(this.m_CollectionButton, flag4);
            this.ToggleButtonTextureState(netObject.Collection.Manager, this.m_CollectionButton);
            bool enabled = (netObject.Games.Forge && (AchieveManager.Get() != null)) && AchieveManager.Get().HasUnlockedFeature(Achievement.UnlockableFeature.FORGE);
            bool flag6 = (!flag2 && enabled) && !Options.Get().GetBool(Option.HAS_SEEN_FORGE, false);
            this.HighlightButton(this.m_ForgeButton, flag6);
            this.ToggleButtonTextureState(enabled, this.m_ForgeButton);
        }
    }

    private class BoxStateConfig
    {
        public Part<BoxCamera.State> m_camState = new Part<BoxCamera.State>();
        public Part<BoxDisk.State> m_diskState = new Part<BoxDisk.State>();
        public Part<BoxDoor.State> m_doorState = new Part<BoxDoor.State>();
        public Part<BoxDrawer.State> m_drawerState = new Part<BoxDrawer.State>();
        public Part<BoxErrorHeader.State> m_errorHeaderState = new Part<BoxErrorHeader.State>();
        public Part<bool> m_fullScreenBlackState = new Part<bool>();
        public Part<BoxLoading.State> m_loadingState = new Part<BoxLoading.State>();
        public Part<BoxLogo.State> m_logoState = new Part<BoxLogo.State>();
        public Part<BoxStartButton.State> m_startButtonState = new Part<BoxStartButton.State>();

        public class Part<T>
        {
            public bool m_ignore;
            public T m_state;
        }
    }

    public delegate void ButtonPressCallback(Box.ButtonType buttonType, object userData);

    private class ButtonPressListener : EventListener<Box.ButtonPressCallback>
    {
        public void Fire(Box.ButtonType buttonType)
        {
            base.m_callback(buttonType, base.m_userData);
        }
    }

    public enum ButtonType
    {
        START,
        TOURNAMENT,
        PRACTICE,
        FORGE,
        OPEN_PACKS,
        COLLECTION
    }

    public enum State
    {
        INVALID,
        STARTUP,
        PRESS_START,
        LOADING,
        HUB,
        HUB_WITH_DRAWER,
        OPEN,
        CLOSED,
        ERROR
    }

    public delegate void TransitionFinishedCallback(object userData);

    private class TransitionFinishedListener : EventListener<Box.TransitionFinishedCallback>
    {
        public void Fire()
        {
            base.m_callback(base.m_userData);
        }
    }
}


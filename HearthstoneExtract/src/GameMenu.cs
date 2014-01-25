using System;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private static readonly Vector3 BUTTON_PADDING = new Vector3(0f, 10f, 0f);
    private StandardPegButton[] m_allButtons;
    public StandardPegButton m_concedeButton;
    public GameObject m_contents;
    private StandardPegButton[] m_inGame;
    private StandardPegButton[] m_inGlues;
    private bool m_isShown;
    public StandardPegButton m_optionsButton;
    private OptionsMenu m_optionsMenu;
    private bool m_optionsMenuBusy;
    public NineSlicePopup m_popup;
    public Vector2 m_popupDimensions;
    public StandardPegButton m_quitButton;
    public StandardPegButton m_resumeButton;
    private const string OPTIONS_MENU_NAME = "OptionsMenu";
    private static GameMenu s_instance;

    private void Awake()
    {
        s_instance = this;
        this.m_inGame = new StandardPegButton[] { this.m_concedeButton, this.m_quitButton, this.m_resumeButton, this.m_optionsButton };
        this.m_inGlues = new StandardPegButton[] { this.m_quitButton, this.m_resumeButton, this.m_optionsButton };
        this.m_allButtons = new StandardPegButton[] { this.m_concedeButton, this.m_quitButton, this.m_resumeButton, this.m_optionsButton };
        GameObject obj2 = CameraUtils.CreateInputBlocker(BaseUI.Get().GetBnetCamera());
        obj2.name = "GameMenuInputBlocker";
        obj2.transform.parent = base.transform;
        obj2.transform.localPosition = new Vector3(0f, -0.6f, 0f);
        ((PegUIElement) obj2.AddComponent(typeof(PegUIElement))).AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnBlockerRelease));
    }

    private void ConcedeButtonPressed(UIEvent e)
    {
        Network.GiveUp();
        this.Hide();
    }

    public static GameMenu Get()
    {
        return s_instance;
    }

    public void Hide()
    {
        base.gameObject.SetActive(false);
        UniversalInputManager.Get().SetGameDialogActive(false);
        this.m_isShown = false;
        BnetBar.Get().m_menuButton.SetSelected(false);
    }

    private void HideAllButtons()
    {
        for (int i = 0; i < this.m_allButtons.Length; i++)
        {
            this.m_allButtons[i].Hide();
        }
    }

    private bool IsInGameMenu()
    {
        if (!SceneMgr.Get().IsInGame())
        {
            return false;
        }
        if (GameState.Get() == null)
        {
            return false;
        }
        if (!GameState.Get().IsConcedingAllowed())
        {
            return false;
        }
        if (GameState.Get().IsGameOver())
        {
            return false;
        }
        if ((TutorialProgress.Get() != null) && TutorialProgress.Get().gameObject.activeInHierarchy)
        {
            return false;
        }
        return true;
    }

    public bool IsShown()
    {
        return this.m_isShown;
    }

    private void OnBlockerRelease(UIEvent e)
    {
        this.Hide();
    }

    private void OnOptionsMenuHidden()
    {
        UnityEngine.Object.Destroy(this.m_optionsMenu.gameObject);
        this.m_optionsMenu = null;
        AssetCache.ClearGameObject("OptionsMenu");
    }

    private void OptionsButtonPressed(UIEvent e)
    {
        if (!this.m_optionsMenuBusy)
        {
            if (this.m_optionsMenu == null)
            {
                this.m_optionsMenuBusy = true;
                AssetLoader.Get().LoadGameObject("OptionsMenu", new AssetLoader.GameObjectCallback(this.OptionsMenuLoaded), null, true, null);
            }
            else
            {
                this.SwitchToOptionsMenu();
            }
        }
    }

    private void OptionsMenuLoaded(string name, GameObject go, object callbackData)
    {
        this.m_optionsMenuBusy = false;
        this.m_optionsMenu = go.GetComponent<OptionsMenu>();
        if (this.m_optionsMenu != null)
        {
            this.SwitchToOptionsMenu();
        }
    }

    private void QuitButtonPressed(UIEvent e)
    {
        ApplicationMgr.Get().Exit();
        this.Hide();
    }

    private void ResumeButtonPressed(UIEvent e)
    {
        this.Hide();
    }

    private void SetupButtons(StandardPegButton[] buttons)
    {
        GameObject gameObject = this.m_popup.m_background.m_top.gameObject;
        for (int i = 0; i < buttons.Length; i++)
        {
            StandardPegButton self = buttons[i];
            self.Show();
            if (i == 0)
            {
                TransformUtil.SetPoint(self, new Vector3(0.5f, 1f, 1f), gameObject, new Vector3(0.5f, 0f, 1f));
            }
            else
            {
                TransformUtil.SetPoint(self, Anchor.TOP, gameObject, Anchor.BOTTOM, -BUTTON_PADDING);
            }
            gameObject = self.gameObject;
        }
    }

    public void Show()
    {
        if ((DemoMgr.Get().GetMode() != DemoMode.PAX_EAST_2013) || this.IsInGameMenu())
        {
            base.gameObject.SetActive(true);
            UniversalInputManager.Get().SetGameDialogActive(true);
            this.HideAllButtons();
            if (DemoMgr.Get().GetMode() == DemoMode.PAX_EAST_2013)
            {
                this.m_popup.SetSize(0.76f, 0.62f);
                StandardPegButton[] buttons = new StandardPegButton[] { this.m_concedeButton, this.m_resumeButton };
                this.SetupButtons(buttons);
            }
            else if (this.IsInGameMenu())
            {
                this.m_popup.SetSize(0.76f, 0.82f);
                this.SetupButtons(this.m_inGame);
            }
            else
            {
                this.m_popup.SetSize(this.m_popupDimensions.x, this.m_popupDimensions.y);
                this.SetupButtons(this.m_inGlues);
            }
            BnetBar.Get().m_menuButton.SetSelected(true);
            this.m_isShown = true;
        }
    }

    private void Start()
    {
        base.transform.parent = BaseUI.Get().transform;
        TransformUtil.CopyLocal((Component) base.transform, (Component) BaseUI.Get().GetGameMenuBone());
        this.m_popup.SetHeaderText(GameStrings.Get("GLOBAL_GAME_MENU"));
        this.m_quitButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.QuitButtonPressed));
        this.m_concedeButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ConcedeButtonPressed));
        this.m_resumeButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ResumeButtonPressed));
        this.m_optionsButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OptionsButtonPressed));
        this.m_resumeButton.SetText(GameStrings.Get("GLOBAL_RESUME_GAME"));
        this.m_quitButton.SetText(GameStrings.Get("GLOBAL_QUIT"));
        this.m_concedeButton.SetText(GameStrings.Get("GLOBAL_CONCEDE"));
        this.m_optionsButton.SetText(GameStrings.Get("GLOBAL_OPTIONS"));
        base.gameObject.SetActive(false);
    }

    private void SwitchToOptionsMenu()
    {
        this.Hide();
        this.m_optionsMenu.setHideHandler(new OptionsMenu.hideHandler(this.OnOptionsMenuHidden));
        this.m_optionsMenu.show();
    }
}


using System;
using UnityEngine;

public class BnetBar : MonoBehaviour
{
    public CurrencyFrame m_currencyFrame;
    public TextMesh m_currentTime;
    public BnetBarFriendButton m_friendButton;
    private FriendListFrame m_friendListFrame;
    public FriendListFrame m_friendListFramePrefab;
    private GameMenu m_gameMenu;
    private bool m_gameMenuLoading;
    private float m_initialFriendButtonScaleX;
    private float m_initialMenuButtonScaleX;
    private float m_initialWidth;
    private bool m_isInitting = true;
    public BnetBarMenuButton m_menuButton;
    private static BnetBar s_instance;

    private void Awake()
    {
        s_instance = this;
        this.m_initialWidth = base.renderer.bounds.size.x;
        this.m_initialFriendButtonScaleX = this.m_friendButton.transform.localScale.x;
        this.m_initialMenuButtonScaleX = this.m_menuButton.transform.localScale.x;
        this.m_menuButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ToggleGameMenu));
        this.m_friendButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnFriendButtonReleased));
        FatalErrorMgr.Get().AddMessageListener(new FatalErrorMgr.MessageCallback(this.OnFatalErrorMessage));
        SceneMgr.Get().RegisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
    }

    public static BnetBar Get()
    {
        return s_instance;
    }

    public bool HandleKeyboardInput()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            this.HandleKeyboardInput_Escape();
            return true;
        }
        ChatMgr mgr = ChatMgr.Get();
        return ((mgr != null) && mgr.HandleKeyboardInput());
    }

    private void HandleKeyboardInput_Escape()
    {
        if ((this.m_gameMenu != null) && this.m_gameMenu.IsShown())
        {
            this.ToggleGameMenu();
        }
        else
        {
            ChatMgr mgr = ChatMgr.Get();
            if ((mgr == null) || !mgr.HandleKeyboardInput())
            {
                if (this.m_friendListFrame != null)
                {
                    UnityEngine.Object.Destroy(this.m_friendListFrame.gameObject);
                    this.m_friendListFrame = null;
                }
                else
                {
                    this.ToggleGameMenu();
                }
            }
        }
    }

    private void OnFatalErrorMessage(FatalErrorMessage message, object userData)
    {
        this.m_friendButton.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnFriendButtonReleased));
        if (this.m_friendListFrame != null)
        {
            UnityEngine.Object.Destroy(this.m_friendListFrame.gameObject);
            this.m_friendListFrame = null;
        }
    }

    private void OnFriendButtonReleased(UIEvent e)
    {
        if (this.m_friendListFrame == null)
        {
            if (Network.IsLoggedIn() && !SceneMgr.Get().IsModeRequested(SceneMgr.Mode.FATAL_ERROR))
            {
                this.m_friendListFrame = (FriendListFrame) UnityEngine.Object.Instantiate(this.m_friendListFramePrefab);
            }
        }
        else
        {
            UnityEngine.Object.Destroy(this.m_friendListFrame.gameObject);
            this.m_friendListFrame = null;
        }
    }

    public void OnLoggedIn()
    {
        this.m_friendButton.gameObject.SetActive(true);
        this.UpdateLayout();
    }

    private void OnSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
        this.m_currencyFrame.RefreshContents();
    }

    private void ShowGameMenu(string name, GameObject go, object callbackData)
    {
        this.m_gameMenu = go.GetComponent<GameMenu>();
        this.m_gameMenu.GetComponent<GameMenu>().Show();
        this.m_gameMenuLoading = false;
    }

    private void Start()
    {
        this.m_friendButton.gameObject.SetActive(false);
    }

    public void ToggleGameMenu()
    {
        if (this.m_gameMenu == null)
        {
            if (!this.m_gameMenuLoading)
            {
                this.m_gameMenuLoading = true;
                AssetLoader.Get().LoadGameObject("GameMenu", new AssetLoader.GameObjectCallback(this.ShowGameMenu));
            }
        }
        else if (this.m_gameMenu.IsShown())
        {
            this.m_gameMenu.Hide();
        }
        else
        {
            this.m_gameMenu.Show();
        }
    }

    private void ToggleGameMenu(UIEvent e)
    {
        this.ToggleGameMenu();
    }

    private void Update()
    {
        this.m_currentTime.text = DateTime.Now.ToShortTimeString();
    }

    public void UpdateLayout()
    {
        float num = 0.5f;
        Bounds nearClipBounds = CameraUtils.GetNearClipBounds(PegUI.Get().orthographicUICam);
        float x = (nearClipBounds.size.x + num) / this.m_initialWidth;
        TransformUtil.SetLocalPosX(base.gameObject, (nearClipBounds.min.x - base.transform.parent.localPosition.x) - num);
        TransformUtil.SetLocalScaleX(base.gameObject, x);
        float num3 = -0.03f * x;
        if (GeneralUtils.IsDevelopmentBuildTextVisible())
        {
            num3 -= CameraUtils.ScreenToWorldDist(PegUI.Get().orthographicUICam, 115f);
        }
        float y = 1f * base.transform.localScale.y;
        TransformUtil.SetLocalScaleX(this.m_menuButton, this.m_initialMenuButtonScaleX / x);
        TransformUtil.SetPoint(this.m_menuButton, Anchor.RIGHT, base.gameObject, Anchor.RIGHT, new Vector3(num3, y, 0f));
        TransformUtil.SetLocalScaleX(this.m_currencyFrame, 1f / x);
        TransformUtil.SetPoint((Component) this.m_currencyFrame, Anchor.RIGHT, (Component) this.m_menuButton, Anchor.LEFT, new Vector3(-25f, -3f, 0f));
        if (this.m_friendButton.gameObject.activeInHierarchy)
        {
            TransformUtil.SetLocalScaleX(this.m_friendButton, this.m_initialFriendButtonScaleX / x);
            TransformUtil.SetPoint(this.m_friendButton, Anchor.LEFT, base.gameObject, Anchor.LEFT, new Vector3(6f, 5f, 0f));
            TransformUtil.SetLocalScaleX(this.m_currentTime, 1f / x);
            TransformUtil.SetPoint((Component) this.m_currentTime, Anchor.LEFT, (Component) this.m_friendButton, Anchor.RIGHT, new Vector3(25f, -6f, 0f));
        }
        else
        {
            TransformUtil.SetLocalScaleX(this.m_currentTime, 1f / x);
            TransformUtil.SetPoint(this.m_currentTime, Anchor.LEFT, base.gameObject, Anchor.LEFT, new Vector3(6f, 5f, 0f));
        }
        if (this.m_isInitting)
        {
            this.m_currencyFrame.DeactivateCurrencyFrame();
            this.m_isInitting = false;
        }
    }
}


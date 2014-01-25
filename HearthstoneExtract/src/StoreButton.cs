using System;
using UnityEngine;

public class StoreButton : PegUIElement
{
    public HighlightState m_highlightState;
    public GameObject m_storeClosed;
    public UberText m_storeClosedText;
    private Vector3 m_storePosition = Vector3.zero;
    private Vector3 m_storeScale = Vector3.one;
    public UberText m_storeText;
    private GameObject m_tempInputBlocker;

    protected override void Awake()
    {
        base.Awake();
        this.m_storeText.Text = GameStrings.Get("GLUE_STORE_OPEN_BUTTON_TEXT");
        this.m_storeClosedText.Text = GameStrings.Get("GLUE_STORE_CLOSED_BUTTON_TEXT");
    }

    public void DestroyTempInputBlocker()
    {
        StoreManager.Get().RemoveStoreShownListener(new StoreManager.StoreShownListener(this.DestroyTempInputBlocker));
        UnityEngine.Object.Destroy(this.m_tempInputBlocker);
    }

    private void OnButtonOut(UIEvent e)
    {
        this.m_highlightState.ChangeState(ActorStateType.HIGHLIGHT_OFF);
    }

    private void OnButtonOver(UIEvent e)
    {
        this.m_highlightState.ChangeState(ActorStateType.HIGHLIGHT_MOUSE_OVER);
    }

    private void OnStoreButtonReleased(UIEvent e)
    {
        if (StoreManager.Get().IsOpen())
        {
            this.m_tempInputBlocker = CameraUtils.CreateInputBlocker(Box.Get().GetCamera());
            SceneUtils.SetLayer(this.m_tempInputBlocker, GameLayer.IgnoreFullScreenEffects);
            this.m_tempInputBlocker.name = "StoreInputBlocker";
            this.m_tempInputBlocker.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
            this.m_tempInputBlocker.AddComponent<PegUIElement>();
            StoreManager.Get().RegisterStoreShownListener(new StoreManager.StoreShownListener(this.DestroyTempInputBlocker));
            StoreManager.Get().StartGeneralTransaction(this.m_storePosition, this.m_storeScale);
        }
    }

    private void OnStoreStatusChanged(bool isOpen)
    {
        this.m_storeClosed.SetActive(!isOpen);
    }

    public void SetStorePosAndScale(Vector3 storePosition, Vector3 storeScale)
    {
        this.m_storePosition = storePosition;
        this.m_storeScale = storeScale;
    }

    private void Start()
    {
        this.m_storeClosed.SetActive(!StoreManager.Get().IsOpen());
        StoreManager.Get().RegisterStatusChangedListener(new StoreManager.StatusChangedListener(this.OnStoreStatusChanged));
        this.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnStoreButtonReleased));
        this.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnButtonOver));
        this.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.OnButtonOut));
    }

    public void Unload()
    {
        base.SetEnabled(false);
        StoreManager.Get().RemoveStatusChangedListener(new StoreManager.StatusChangedListener(this.OnStoreStatusChanged));
    }
}


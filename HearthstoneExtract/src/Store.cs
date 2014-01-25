using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class Store : MonoBehaviour
{
    protected bool m_buyButtonsEnabled = true;
    public NormalButton m_buyWithGoldButton;
    private List<BuyWithGoldListener> m_buyWithGoldListeners = new List<BuyWithGoldListener>();
    public NormalButton m_buyWithMoneyButton;
    private List<BuyWithMoneyListener> m_buyWithMoneyListeners = new List<BuyWithMoneyListener>();
    public GameObject m_cover;
    public Material m_disabledGoldButtonMaterial;
    public Material m_disabledMoneyButtonMaterial;
    private StoreDisclaimer m_disclaimer;
    public Material m_enabledGoldButtonMaterial;
    public Material m_enabledMoneyButtonMaterial;
    private List<ExitListener> m_exitListeners = new List<ExitListener>();
    private BuyButtonState m_goldButtonState;
    public NormalButton m_infoButton;
    private List<InfoListener> m_infoListeners = new List<InfoListener>();
    private BuyButtonState m_moneyButtonState;
    private List<ReadyListener> m_readyListeners = new List<ReadyListener>();
    public GameObject m_root;
    protected bool m_shown = true;

    public void ActivateCover(bool coverActive)
    {
        this.m_cover.SetActive(coverActive);
        this.OnCoverStateChanged(coverActive);
        this.EnableBuyButtons(!coverActive);
    }

    protected bool AllowBuyingWithGold()
    {
        return (this.m_buyButtonsEnabled && (BuyButtonState.ENABLED == this.m_goldButtonState));
    }

    protected bool AllowBuyingWithMoney()
    {
        return (this.m_buyButtonsEnabled && (BuyButtonState.ENABLED == this.m_moneyButtonState));
    }

    protected virtual void Awake()
    {
        AssetLoader.Get().LoadGameObject("StoreDisclaimer", new AssetLoader.GameObjectCallback(this.OnDisclaimerLoaded));
        this.m_root.transform.localPosition = this.GetDisclaimerRootLocalOffset();
        this.m_infoButton.SetText(GameStrings.Get("GLUE_STORE_INFO_BUTTON_TEXT"));
    }

    protected virtual void BuyWithGold(UIEvent e)
    {
    }

    protected virtual void BuyWithMoney(UIEvent e)
    {
    }

    private void EnableBuyButtons(bool buyButtonsEnabled)
    {
        if (buyButtonsEnabled != this.m_buyButtonsEnabled)
        {
            this.m_buyButtonsEnabled = buyButtonsEnabled;
            this.UpdateBuyButtonsState();
        }
    }

    protected void EnableFullScreenEffects(bool enable)
    {
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.BlurDesaturation = 0f;
        component.BlurBrightness = !enable ? 0f : 1f;
        component.BlurBlend = !enable ? 0f : 1f;
    }

    protected void FireBuyWithGoldEvent(ProductType product, int data, int quantity)
    {
        foreach (BuyWithGoldListener listener in this.m_buyWithGoldListeners)
        {
            listener(product, data, quantity);
        }
    }

    protected void FireBuyWithMoneyEvent(int bundleType, int quantity)
    {
        foreach (BuyWithMoneyListener listener in this.m_buyWithMoneyListeners)
        {
            listener(bundleType, quantity);
        }
    }

    protected void FireExitEvent()
    {
        foreach (ExitListener listener in this.m_exitListeners)
        {
            listener();
        }
    }

    public virtual Vector3 GetAuthPosition()
    {
        return Vector3.zero;
    }

    public virtual Vector3 GetAuthScale()
    {
        return Vector3.one;
    }

    public virtual Vector3 GetBAMPopupPosition()
    {
        return Vector3.zero;
    }

    public virtual Vector3 GetBAMPopupScale()
    {
        return Vector3.one;
    }

    protected virtual void GetDisclaimerDetails(out string detailsText1, out string detailsText2, out string detailsText3)
    {
        detailsText1 = string.Empty;
        detailsText2 = string.Empty;
        detailsText3 = string.Empty;
    }

    protected virtual Vector3 GetDisclaimerLocalPos()
    {
        return Vector3.zero;
    }

    protected virtual Vector3 GetDisclaimerRootLocalOffset()
    {
        return Vector3.zero;
    }

    protected virtual Vector3 GetDisclaimerScale()
    {
        return Vector3.one;
    }

    public virtual Vector3 GetPasswordPromptPosition()
    {
        return Vector3.zero;
    }

    public virtual Vector3 GetPasswordPromptScale()
    {
        return Vector3.one;
    }

    public virtual Vector3 GetSummaryPosition()
    {
        return Vector3.zero;
    }

    public virtual Vector3 GetSummaryScale()
    {
        return Vector3.one;
    }

    private string GetTooltipMessage(BuyButtonState state)
    {
        switch (state)
        {
            case BuyButtonState.DISABLED_NOT_ENOUGH_GOLD:
                return GameStrings.Get("GLUE_STORE_FAIL_NOT_ENOUGH_GOLD");

            case BuyButtonState.DISABLED_FEATURE:
                return GameStrings.Get("GLUE_STORE_DISABLED");

            case BuyButtonState.DISABLED:
                return GameStrings.Get("GLUE_TOOLTIP_BUTTON_DISABLED_DESC");
        }
        return string.Empty;
    }

    protected virtual float GetTooltipScale()
    {
        return 1f;
    }

    public virtual void Hide()
    {
    }

    protected bool IsDisclaimerReady()
    {
        return (this.m_disclaimer != null);
    }

    public bool IsReady()
    {
        if (!this.IsDisclaimerReady())
        {
            return false;
        }
        return true;
    }

    public bool IsShown()
    {
        return this.m_shown;
    }

    [DebuggerHidden]
    private IEnumerator NotifyListenersWhenReady()
    {
        return new <NotifyListenersWhenReady>c__IteratorB3 { <>f__this = this };
    }

    private void OnButtonMouseOut(UIEvent e)
    {
        NormalButton element = (NormalButton) e.GetElement();
        TooltipZone component = element.gameObject.GetComponent<TooltipZone>();
        if (component != null)
        {
            component.HideTooltip();
        }
    }

    private void OnBuyWithGoldButtonOver(UIEvent e)
    {
        if (this.m_goldButtonState != BuyButtonState.ENABLED)
        {
            NormalButton element = (NormalButton) e.GetElement();
            TooltipZone component = element.gameObject.GetComponent<TooltipZone>();
            if (component != null)
            {
                component.ShowStoreTooltip(GameStrings.Get("GLUE_STORE_GOLD_BUTTON_TOOLTIP_HEADLINE"), this.GetTooltipMessage(this.m_goldButtonState), this.GetTooltipScale());
            }
        }
    }

    private void OnBuyWithGoldPressed(UIEvent e)
    {
        if (this.AllowBuyingWithGold())
        {
            this.BuyWithGold(e);
        }
    }

    private void OnBuyWithMoneyButtonOver(UIEvent e)
    {
        if (this.m_moneyButtonState != BuyButtonState.ENABLED)
        {
            NormalButton element = (NormalButton) e.GetElement();
            TooltipZone component = element.gameObject.GetComponent<TooltipZone>();
            if (component != null)
            {
                component.ShowStoreTooltip(GameStrings.Get("GLUE_STORE_MONEY_BUTTON_TOOLTIP_HEADLINE"), this.GetTooltipMessage(this.m_moneyButtonState), this.GetTooltipScale());
            }
        }
    }

    private void OnBuyWithMoneyPressed(UIEvent e)
    {
        if (this.AllowBuyingWithMoney())
        {
            this.BuyWithMoney(e);
        }
    }

    protected virtual void OnCoverStateChanged(bool enabled)
    {
    }

    private void OnDisclaimerLoaded(string name, GameObject go, object userData)
    {
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("Store.OnDisclaimerLoaded() - FAILED to load {0}", name));
        }
        else
        {
            this.m_disclaimer = go.GetComponent<StoreDisclaimer>();
            if (this.m_disclaimer == null)
            {
                UnityEngine.Debug.LogError(string.Format("Store.OnDisclaimerLoaded() - asset {0} did not have a {1} script on it", name, typeof(StoreDisclaimer)));
            }
            else
            {
                string str;
                string str2;
                string str3;
                this.m_disclaimer.transform.parent = this.m_root.transform;
                this.m_disclaimer.transform.localPosition = this.GetDisclaimerLocalPos();
                this.m_disclaimer.transform.localScale = this.GetDisclaimerScale();
                this.GetDisclaimerDetails(out str, out str2, out str3);
                this.m_disclaimer.SetDetailsText(str, str2, str3);
            }
        }
    }

    public virtual void OnGoldSpent()
    {
    }

    private void OnInfoPressed(UIEvent e)
    {
        foreach (InfoListener listener in this.m_infoListeners)
        {
            listener();
        }
    }

    public virtual void OnMoneySpent()
    {
    }

    public void RegisterBuyWithGoldListener(BuyWithGoldListener listener)
    {
        if (!this.m_buyWithGoldListeners.Contains(listener))
        {
            this.m_buyWithGoldListeners.Add(listener);
        }
    }

    public void RegisterBuyWithMoneyListener(BuyWithMoneyListener listener)
    {
        if (!this.m_buyWithMoneyListeners.Contains(listener))
        {
            this.m_buyWithMoneyListeners.Add(listener);
        }
    }

    public void RegisterExitListener(ExitListener listener)
    {
        if (!this.m_exitListeners.Contains(listener))
        {
            this.m_exitListeners.Add(listener);
        }
    }

    public void RegisterInfoListener(InfoListener listener)
    {
        if (!this.m_infoListeners.Contains(listener))
        {
            this.m_infoListeners.Add(listener);
        }
    }

    public void RegisterReadyListener(ReadyListener listener)
    {
        if (!this.m_readyListeners.Contains(listener))
        {
            this.m_readyListeners.Add(listener);
        }
    }

    public void RemoveBuyWithGoldListener(BuyWithGoldListener listener)
    {
        this.m_buyWithGoldListeners.Remove(listener);
    }

    public void RemoveBuyWithMoneyListener(BuyWithMoneyListener listener)
    {
        this.m_buyWithMoneyListeners.Remove(listener);
    }

    public void RemoveExitListener(ExitListener listener)
    {
        this.m_exitListeners.Remove(listener);
    }

    public void RemoveInfoListener(InfoListener listener)
    {
        this.m_infoListeners.Remove(listener);
    }

    public void RemoveReadyListener(ReadyListener listener)
    {
        this.m_readyListeners.Remove(listener);
    }

    protected void SetGoldButtonState(BuyButtonState state)
    {
        if (this.m_goldButtonState != state)
        {
            this.m_goldButtonState = state;
            this.UpdateBuyButtonsState();
        }
    }

    protected void SetMoneyButtonState(BuyButtonState state)
    {
        if (this.m_moneyButtonState != state)
        {
            this.m_moneyButtonState = state;
            this.UpdateBuyButtonsState();
        }
    }

    public virtual void Show(Vector3 position, Vector3 targetScale, DelOnStoreShown onStoreShownCB)
    {
    }

    protected virtual void Start()
    {
        this.m_buyWithGoldButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnBuyWithGoldPressed));
        this.m_buyWithGoldButton.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnBuyWithGoldButtonOver));
        this.m_buyWithGoldButton.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.OnButtonMouseOut));
        this.m_buyWithMoneyButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnBuyWithMoneyPressed));
        this.m_buyWithMoneyButton.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnBuyWithMoneyButtonOver));
        this.m_buyWithMoneyButton.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.OnButtonMouseOut));
        this.m_infoButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnInfoPressed));
        base.StartCoroutine(this.NotifyListenersWhenReady());
    }

    private void UpdateBuyButtonsState()
    {
        bool flag = this.AllowBuyingWithMoney();
        bool flag2 = this.AllowBuyingWithGold();
        Material material = !flag ? this.m_disabledMoneyButtonMaterial : this.m_enabledMoneyButtonMaterial;
        foreach (MeshRenderer renderer in this.m_buyWithMoneyButton.m_button.GetComponentsInChildren<MeshRenderer>())
        {
            renderer.material = material;
        }
        Material material2 = !flag2 ? this.m_disabledGoldButtonMaterial : this.m_enabledGoldButtonMaterial;
        foreach (MeshRenderer renderer2 in this.m_buyWithGoldButton.m_button.GetComponentsInChildren<MeshRenderer>())
        {
            renderer2.material = material2;
        }
    }

    protected void UpdateDisclaimerTextNow()
    {
        if (this.m_disclaimer == null)
        {
            UnityEngine.Debug.LogWarning("Store.UpdateDisclaimerTextNow(): m_disclaimer is null!");
        }
        else
        {
            this.m_disclaimer.UpdateTextSize();
        }
    }

    [CompilerGenerated]
    private sealed class <NotifyListenersWhenReady>c__IteratorB3 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<Store.ReadyListener>.Enumerator <$s_834>__0;
        internal Store <>f__this;
        internal Store.ReadyListener <listener>__1;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                case 1:
                    if (!this.<>f__this.IsReady())
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<$s_834>__0 = this.<>f__this.m_readyListeners.GetEnumerator();
                    try
                    {
                        while (this.<$s_834>__0.MoveNext())
                        {
                            this.<listener>__1 = this.<$s_834>__0.Current;
                            this.<listener>__1();
                        }
                    }
                    finally
                    {
                        this.<$s_834>__0.Dispose();
                    }
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    protected enum BuyButtonState
    {
        ENABLED,
        DISABLED_NOT_ENOUGH_GOLD,
        DISABLED_FEATURE,
        DISABLED
    }

    public delegate void BuyWithGoldListener(ProductType product, int data, int quantity);

    public delegate void BuyWithMoneyListener(int bundleType, int quantity);

    public delegate void DelOnStoreShown();

    public delegate void ExitListener();

    public delegate void InfoListener();

    public delegate void ReadyListener();
}


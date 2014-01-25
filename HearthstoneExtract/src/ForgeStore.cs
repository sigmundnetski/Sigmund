using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ForgeStore : Store
{
    private static readonly Vector3 DISCLAIMER_LOCAL_POS = new Vector3(0.332257f, 0f, 0.6346401f);
    private static readonly Vector3 DISCLAIMER_SCALE = new Vector3(0.0092f, 0.0092f, 0.0092f);
    public UberText m_admissionText;
    public NormalButton m_backButton;
    private Network.Bundle m_bundle;
    public UberText m_detailsText1;
    public UberText m_detailsText2;
    private Network.GoldPrice m_goldPrice;
    public UberText m_headline;
    private static readonly Vector3 ROOT_LOCAL_OFFSET_FOR_DISCLAIMER = new Vector3(0f, 0f, -0.01581997f);
    private static readonly Vector3 STORE_AUTH_POS = new Vector3(-0.006218712f, 0.02195244f, -0.01651361f);
    private static readonly Vector3 STORE_AUTH_SCALE = new Vector3(1.2f, 1.2f, 1.2f);
    private static readonly Vector3 STORE_BAM_POPUP_POS = new Vector3(-0.006218712f, 0.02195244f, 0.03780009f);
    private static readonly Vector3 STORE_BAM_POPUP_SCALE = new Vector3(0.78f, 0.78f, 0.78f);
    private static readonly Vector3 STORE_PASSWORD_PROMPT_POS = new Vector3(-0.006218712f, 0.02195244f, 0.03780009f);
    private static readonly Vector3 STORE_PASSWORD_PROMPT_SCALE = new Vector3(0.7f, 0.7f, 0.7f);
    private static readonly Vector3 STORE_SUMMARY_POS = new Vector3(-0.006218712f, 0.02195244f, 0.03780009f);
    private static readonly Vector3 STORE_SUMMARY_SCALE = new Vector3(0.78f, 0.78f, 0.78f);
    private static readonly float TOOLTIP_SCALE = 4.5f;

    protected override void Awake()
    {
        base.Awake();
        this.m_detailsText1.Text = GameStrings.Get("GLUE_FORGE_STORE_DETAILS1");
        this.m_detailsText2.Text = GameStrings.Get("GLUE_FORGE_STORE_DETAILS2");
        this.m_headline.Text = GameStrings.Get("GLUE_FORGE_STORE_HEADLINE");
        this.m_admissionText.Text = GameStrings.Get("GLUE_FORGE_STORE_ADMISSION");
        this.m_backButton.SetText(GameStrings.Get("GLOBAL_BACK"));
    }

    protected override void BuyWithGold(UIEvent e)
    {
        if (this.m_goldPrice != null)
        {
            base.FireBuyWithGoldEvent(this.m_goldPrice.Product, this.m_goldPrice.ProductData, this.m_goldPrice.Quantity);
        }
    }

    protected override void BuyWithMoney(UIEvent e)
    {
        if (this.m_bundle != null)
        {
            base.FireBuyWithMoneyEvent(this.m_bundle.BundleType, 1);
        }
    }

    public override Vector3 GetAuthPosition()
    {
        return base.m_root.transform.TransformPoint(STORE_AUTH_POS);
    }

    public override Vector3 GetAuthScale()
    {
        Vector3 vector = STORE_AUTH_SCALE;
        vector.Scale(base.transform.lossyScale);
        return vector;
    }

    public override Vector3 GetBAMPopupPosition()
    {
        return base.m_root.transform.TransformPoint(STORE_BAM_POPUP_POS);
    }

    public override Vector3 GetBAMPopupScale()
    {
        Vector3 vector = STORE_BAM_POPUP_SCALE;
        vector.Scale(base.transform.lossyScale);
        return vector;
    }

    protected override void GetDisclaimerDetails(out string detailsText1, out string detailsText2, out string detailsText3)
    {
        detailsText1 = GameStrings.Get("GLUE_FORGE_STORE_DISCLAIMER_DETAILS_1");
        detailsText2 = GameStrings.Get("GLUE_FORGE_STORE_DISCLAIMER_DETAILS_2");
        detailsText3 = GameStrings.Get("GLUE_FORGE_STORE_DISCLAIMER_DETAILS_3");
    }

    protected override Vector3 GetDisclaimerLocalPos()
    {
        return DISCLAIMER_LOCAL_POS;
    }

    protected override Vector3 GetDisclaimerRootLocalOffset()
    {
        return ROOT_LOCAL_OFFSET_FOR_DISCLAIMER;
    }

    protected override Vector3 GetDisclaimerScale()
    {
        return DISCLAIMER_SCALE;
    }

    public override Vector3 GetPasswordPromptPosition()
    {
        return base.m_root.transform.TransformPoint(STORE_PASSWORD_PROMPT_POS);
    }

    public override Vector3 GetPasswordPromptScale()
    {
        Vector3 vector = STORE_PASSWORD_PROMPT_SCALE;
        vector.Scale(base.transform.lossyScale);
        return vector;
    }

    public override Vector3 GetSummaryPosition()
    {
        return base.m_root.transform.TransformPoint(STORE_SUMMARY_POS);
    }

    public override Vector3 GetSummaryScale()
    {
        Vector3 vector = STORE_SUMMARY_SCALE;
        vector.Scale(base.transform.lossyScale);
        return vector;
    }

    protected override float GetTooltipScale()
    {
        return TOOLTIP_SCALE;
    }

    public override void Hide()
    {
        base.m_shown = false;
        base.EnableFullScreenEffects(false);
        base.m_root.SetActive(false);
    }

    private void OnBackPressed(UIEvent e)
    {
        base.ActivateCover(false);
        SceneUtils.SetLayer(base.gameObject, GameLayer.Default);
        base.EnableFullScreenEffects(false);
        base.FireExitEvent();
    }

    public override void OnGoldSpent()
    {
        this.SetUpBuyWithGoldButton();
    }

    public override void OnMoneySpent()
    {
        this.SetUpBuyWithMoneyButton();
    }

    private void SetUpBuyButtons()
    {
        this.SetUpBuyWithGoldButton();
        this.SetUpBuyWithMoneyButton();
    }

    private void SetUpBuyWithGoldButton()
    {
        List<Network.GoldPrice> goldPricesForProduct = StoreManager.Get().GetGoldPricesForProduct(ProductType.DRAFT_TICKET);
        Store.BuyButtonState eNABLED = Store.BuyButtonState.ENABLED;
        string t = string.Empty;
        if (goldPricesForProduct.Count == 1)
        {
            this.m_goldPrice = goldPricesForProduct[0];
            long num = this.m_goldPrice.Cost * this.m_goldPrice.Quantity;
            t = num.ToString();
            NetCache.NetCacheGoldBalance netObject = NetCache.Get().GetNetObject<NetCache.NetCacheGoldBalance>();
            if (!StoreManager.Get().IsOpen())
            {
                eNABLED = Store.BuyButtonState.DISABLED;
            }
            else if (!StoreManager.Get().IsBuyWithGoldFeatureEnabled())
            {
                eNABLED = Store.BuyButtonState.DISABLED_FEATURE;
            }
            else if (netObject == null)
            {
                eNABLED = Store.BuyButtonState.DISABLED;
            }
            else if (netObject.Balance < num)
            {
                eNABLED = Store.BuyButtonState.DISABLED_NOT_ENOUGH_GOLD;
            }
        }
        else
        {
            Debug.LogWarning(string.Format("ForgeStore.SetUpBuyWithGoldButton(): expecting 1 gold price for purchasing Forge, found {0}", goldPricesForProduct.Count));
            eNABLED = Store.BuyButtonState.DISABLED;
            t = GameStrings.Get("GLUE_STORE_PRODUCT_PRICE_NA");
        }
        base.SetGoldButtonState(eNABLED);
        base.m_buyWithGoldButton.SetText(t);
    }

    private void SetUpBuyWithMoneyButton()
    {
        List<Network.Bundle> bundlesForProduct = StoreManager.Get().GetBundlesForProduct(ProductType.DRAFT_TICKET);
        Store.BuyButtonState eNABLED = Store.BuyButtonState.ENABLED;
        string t = string.Empty;
        if (bundlesForProduct.Count == 1)
        {
            this.m_bundle = bundlesForProduct[0];
            t = StoreManager.Get().FormatCostText(this.m_bundle.Cost);
            if (!StoreManager.Get().IsOpen())
            {
                eNABLED = Store.BuyButtonState.DISABLED;
            }
            else if (!StoreManager.Get().IsBattlePayFeatureEnabled())
            {
                eNABLED = Store.BuyButtonState.DISABLED_FEATURE;
            }
        }
        else
        {
            Debug.LogWarning(string.Format("ForgeStore.SetUpBuyWithMoneyButton(): expecting 1 bundle for purchasing Forge, found {0}", bundlesForProduct.Count));
            eNABLED = Store.BuyButtonState.DISABLED;
            t = GameStrings.Get("GLUE_STORE_PRODUCT_PRICE_NA");
        }
        base.SetMoneyButtonState(eNABLED);
        base.m_buyWithMoneyButton.SetText(t);
    }

    public override void Show(Vector3 position, Vector3 scale, Store.DelOnStoreShown onStoreShownCB)
    {
        base.m_shown = true;
        SceneUtils.SetLayer(base.gameObject, GameLayer.IgnoreFullScreenEffects);
        base.EnableFullScreenEffects(true);
        base.m_root.SetActive(true);
        base.transform.position = position;
        base.transform.localScale = scale;
        this.SetUpBuyButtons();
        if (onStoreShownCB != null)
        {
            onStoreShownCB();
        }
    }

    protected override void Start()
    {
        base.Start();
        this.m_backButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnBackPressed));
    }
}


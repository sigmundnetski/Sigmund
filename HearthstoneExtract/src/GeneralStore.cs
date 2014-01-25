using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class GeneralStore : Store
{
    private static readonly string ANIMATE_PACKS_COROUTINE = "AnimatePackDisplay";
    private static readonly Vector3 BUY_PANE_GOLD_ANGLES = new Vector3(0f, 180f, 180f);
    private static readonly Vector3 BUY_PANE_MONEY_ANGLES = new Vector3(0f, 180f, 0f);
    private static readonly Vector3 DISCLAIMER_LOCAL_POS = new Vector3(0.2373487f, 0f, 0.9253455f);
    private static readonly Vector3 DISCLAIMER_SCALE = new Vector3(0.012f, 0.012f, 0.012f);
    private static readonly float FLIP_BUY_PANE_ANIM_TIME = 0.1f;
    private static readonly Vector3 HIDDEN_SCALE = new Vector3(0.001f, 0.001f, 0.001f);
    private static readonly float HIDE_ANIM_TIME = 0.1f;
    public GameObject m_bonusRoot;
    public GameObject m_buyPanePivot;
    private BuyPaneState m_buyPaneState = BuyPaneState.SHOWING_BUY_MONEY;
    public NormalButton m_closeButton;
    public UberText m_goldCostText;
    public UberText m_headlineText;
    public GameObject m_itemsRoot;
    private int m_maxNumFlyingPacks;
    public UberText m_moneyCostText;
    public PegUIElement m_offClicker;
    private Vector3 m_originalLocalRotation = Vector3.zero;
    public GameObject m_packContainer;
    public AnimatedLowPolyPack m_packPrefab;
    private List<AnimatedLowPolyPack> m_packs = new List<AnimatedLowPolyPack>();
    public List<PackStack> m_packStacks;
    public UberText m_productDetailsHeadlineText;
    public UberText m_productDetailsText;
    public ThreeSliceTextElement m_productName;
    public RadioButtonGroup m_radioButtonGroup;
    private Network.Bundle m_selectedBundle;
    private Network.GoldPrice m_selectedGoldPrice;
    private bool m_staticTextResized;
    private Vector3 m_targetScale = Vector3.one;
    private static readonly float MAX_FLY_IN_X_ROTATION = -20f;
    private static readonly float MAX_FLY_OUT_X_ROTATION = -15f;
    public float PACK_FLY_IN_ANIM_TIME = 0.2f;
    public float PACK_FLY_IN_DELAY_SECS = 0.01f;
    public float PACK_FLY_OUT_ANIM_TIME = 0.1f;
    public float PACK_FLY_OUT_DELAY_SECS = 0.005f;
    private static readonly float PACK_FLY_OUT_X_DEG_VARIATION_MAG = 10f;
    private static readonly float PACK_FLY_OUT_Z_DEG_VARIATION_MAG = 10f;
    private static readonly Vector3 PACK_SCALE = new Vector3(0.1f, 0.1f, 0.1f);
    private static readonly int PACK_STACK_SEED = 2;
    private static readonly float PACK_X_VARIATION_MAG = 0.02f;
    private static readonly float PACK_Y_DEGREE_VARIATON_MAG = 4f;
    private static readonly float PACK_Y_OFFSET = 0.064f;
    private static readonly float PACK_Z_VARIATION_MAG = 0.01f;
    private static readonly float ROCK_ANIMATION_SECS = 2f;
    private static readonly string ROCK_COMPLETE_TWEEN_NAME = "StoreRockComplete";
    private static readonly string ROCK_TWEEN_NAME = "StoreRock";
    public float ROCK_WAIT_PERCENT = 0.7f;
    private static readonly Vector3 ROOT_LOCAL_OFFSET_FOR_DISCLAIMER = new Vector3(-0.22f, 0f, 0f);
    private static readonly float SHOW_ANIM_TIME = 0.5f;
    private static readonly Vector3 STORE_AUTH_POS = new Vector3(-0.2236923f, 1f, 0.01951079f);
    private static readonly Vector3 STORE_AUTH_SCALE = new Vector3(1f, 1f, 1f);
    private static readonly Vector3 STORE_BAM_POPUP_POS = new Vector3(-0.2166563f, 1.073886f, 0.05468057f);
    private static readonly Vector3 STORE_BAM_POPUP_SCALE = new Vector3(0.6f, 0.6f, 0.6f);
    private static readonly Vector3 STORE_PASSWORD_PROMPT_POS = new Vector3(-0.2166563f, 1.073886f, 0.05468057f);
    private static readonly Vector3 STORE_PASSWORD_PROMPT_SCALE = new Vector3(0.55f, 0.55f, 0.55f);
    private static readonly string STORE_SCALE_TWEEN_NAME = "StoreScale";
    private static readonly Vector3 STORE_SUMMARY_POS = new Vector3(-0.2166563f, 1.073886f, 0.05468057f);
    private static readonly Vector3 STORE_SUMMARY_SCALE = new Vector3(0.55f, 0.55f, 0.55f);
    private static readonly float TOOLTIP_SCALE = 8f;

    [DebuggerHidden]
    private IEnumerator AnimatePackDisplay(int numVisiblePacks)
    {
        return new <AnimatePackDisplay>c__IteratorB4 { numVisiblePacks = numVisiblePacks, <$>numVisiblePacks = numVisiblePacks, <>f__this = this };
    }

    protected override void Awake()
    {
        base.Awake();
        base.m_root.transform.localPosition = ROOT_LOCAL_OFFSET_FOR_DISCLAIMER;
        this.m_originalLocalRotation = base.transform.localEulerAngles;
        this.m_buyPanePivot.transform.localEulerAngles = BUY_PANE_GOLD_ANGLES;
        base.m_buyWithMoneyButton.SetEnabled(false);
        base.m_buyWithGoldButton.SetEnabled(true);
        this.m_bonusRoot.SetActive(false);
        this.m_itemsRoot.SetActive(false);
        base.m_buyWithMoneyButton.SetText(GameStrings.Get("GLUE_STORE_BUY_TEXT"));
        base.m_buyWithGoldButton.SetText(GameStrings.Get("GLUE_STORE_BUY_TEXT"));
        this.m_headlineText.Text = GameStrings.Get("GLUE_STORE_HEADLINE");
    }

    protected override void BuyWithGold(UIEvent e)
    {
        if (this.SelectedGoldPrice == null)
        {
            UnityEngine.Debug.LogWarning("GeneralStore.OnBuyWithGoldPressed(): SelectedGoldPrice is null");
        }
        else
        {
            base.FireBuyWithGoldEvent(this.SelectedGoldPrice.Product, this.SelectedGoldPrice.ProductData, this.SelectedGoldPrice.Quantity);
        }
    }

    protected override void BuyWithMoney(UIEvent e)
    {
        if (this.SelectedBundle == null)
        {
            UnityEngine.Debug.LogWarning("GeneralStore.OnBuyWithMoneyPressed(): SelectedBundle is null");
        }
        else
        {
            base.FireBuyWithMoneyEvent(this.SelectedBundle.BundleType, 1);
        }
    }

    public void Close()
    {
        this.Hide(true);
        base.EnableFullScreenEffects(false);
        base.FireExitEvent();
    }

    private int DeterminePackColumn(int packNumber)
    {
        double num = new System.Random(PACK_STACK_SEED + packNumber).NextDouble();
        double num3 = 0.0;
        int num2 = 0;
        while (num2 < (this.m_packStacks.Count - 1))
        {
            num3 += this.m_packStacks[num2].m_stackProbability;
            if (num <= num3)
            {
                return num2;
            }
            num2++;
        }
        return num2;
    }

    private Vector3 DeterminePackLocalPos(int column)
    {
        <DeterminePackLocalPos>c__AnonStorey140 storey = new <DeterminePackLocalPos>c__AnonStorey140 {
            column = column
        };
        List<AnimatedLowPolyPack> list = this.m_packs.FindAll(new Predicate<AnimatedLowPolyPack>(storey.<>m__46));
        Vector3 zero = Vector3.zero;
        zero.x = UnityEngine.Random.Range(-PACK_X_VARIATION_MAG, PACK_X_VARIATION_MAG);
        zero.y = PACK_Y_OFFSET * list.Count;
        zero.z = UnityEngine.Random.Range(-PACK_Z_VARIATION_MAG, PACK_Z_VARIATION_MAG);
        return zero;
    }

    private void FlipBuyPane(bool targetIsGold)
    {
        this.m_buyPaneState = !targetIsGold ? BuyPaneState.FLIPPING_TO_MONEY : BuyPaneState.FLIPPING_TO_GOLD;
        base.m_buyWithGoldButton.SetEnabled(false);
        base.m_buyWithMoneyButton.SetEnabled(false);
        object[] args = new object[] { "rotation", !targetIsGold ? BUY_PANE_MONEY_ANGLES : BUY_PANE_GOLD_ANGLES, "isLocal", true, "time", FLIP_BUY_PANE_ANIM_TIME, "easeType", iTween.EaseType.linear, "oncomplete", "OnBuyPaneFlipped", "oncompletetarget", base.gameObject, "oncompleteparams", targetIsGold, "name", "rotation" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_buyPanePivot.gameObject, "rotation");
        iTween.RotateTo(this.m_buyPanePivot.gameObject, hashtable);
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
        detailsText1 = GameStrings.Get("GLUE_STORE_DISCLAIMER_DETAILS_1");
        detailsText2 = GameStrings.Get("GLUE_STORE_DISCLAIMER_DETAILS_2");
        detailsText3 = GameStrings.Get("GLUE_STORE_DISCLAIMER_DETAILS_3");
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

    private void GetProductDetails(ProductType product, int productData, out string headline, out string details)
    {
        headline = string.Empty;
        details = string.Empty;
        if (product == ProductType.BOOSTER)
        {
            BoosterType type = (BoosterType) productData;
            if (type == BoosterType.EXPERT)
            {
                headline = GameStrings.Get("GLUE_STORE_PRODUCT_DETAILS_HEADLINE_EXPERT_PACK");
                details = GameStrings.Get("GLUE_STORE_PRODUCT_DETAILS_EXPERT_PACK");
            }
            else
            {
                UnityEngine.Debug.LogWarning(string.Format("Store.GetProductDetails(): don't know how to format details/headline for booster type {0}", type));
            }
        }
        else
        {
            UnityEngine.Debug.LogWarning(string.Format("Store.GetProductDetails(): don't know how to format details/headline for product {0}", product));
        }
    }

    private List<RadioButtonGroup.ButtonData> GetRadioButtonChoices(ProductType product)
    {
        StoreRadioButton.Data data3;
        List<RadioButtonGroup.ButtonData> list = new List<RadioButtonGroup.ButtonData>();
        bool selected = true;
        int num = 1;
        foreach (Network.GoldPrice price in StoreManager.Get().GetGoldPricesForProduct(product))
        {
            data3 = new StoreRadioButton.Data {
                m_goldPrice = price
            };
            StoreRadioButton.Data userData = data3;
            string text = StoreManager.Get().GetProductQuantityText(price.Product, price.ProductData, price.Quantity);
            list.Add(new RadioButtonGroup.ButtonData(num++, text, userData, selected));
            selected = false;
        }
        foreach (Network.Bundle bundle in StoreManager.Get().GetBundlesForProduct(product))
        {
            data3 = new StoreRadioButton.Data {
                m_bundle = bundle
            };
            StoreRadioButton.Data data2 = data3;
            string str2 = StoreManager.Get().GetProductQuantityText(bundle.Product, bundle.ProductData, bundle.Quantity);
            list.Add(new RadioButtonGroup.ButtonData(num++, str2, data2, selected));
            selected = false;
        }
        return list;
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
        this.Hide(false);
    }

    private void Hide(bool animate)
    {
        iTween.StopByName(base.gameObject, STORE_SCALE_TWEEN_NAME);
        base.StopCoroutine(ANIMATE_PACKS_COROUTINE);
        if (!animate)
        {
            this.OnHidden();
        }
        else
        {
            object[] args = new object[] { "scale", HIDDEN_SCALE, "time", HIDE_ANIM_TIME, "easetype", iTween.EaseType.linear, "name", STORE_SCALE_TWEEN_NAME, "oncomplete", "OnHidden", "oncompletetarget", base.gameObject };
            Hashtable hashtable = iTween.Hash(args);
            iTween.ScaleTo(base.gameObject, hashtable);
        }
    }

    private void OnBuyPaneFlipped(bool targetIsGold)
    {
        if (targetIsGold)
        {
            this.m_buyPaneState = BuyPaneState.SHOWING_BUY_GOLD;
            base.m_buyWithGoldButton.SetEnabled(true);
        }
        else
        {
            this.m_buyPaneState = BuyPaneState.SHOWING_BUY_MONEY;
            base.m_buyWithMoneyButton.SetEnabled(true);
        }
    }

    private void OnClosePressed(UIEvent e)
    {
        this.Close();
    }

    protected override void OnCoverStateChanged(bool coverActive)
    {
        foreach (AnimatedLowPolyPack pack in this.m_packs)
        {
            pack.Dim(coverActive);
        }
    }

    public override void OnGoldSpent()
    {
        NetCache.Get().ReloadNetObject<NetCache.NetCacheBoosters>();
        this.UpdateGoldButtonState();
    }

    private void OnHidden()
    {
        base.m_shown = false;
        base.m_root.SetActive(false);
        this.PositionOffScreen();
        this.PreRender();
    }

    public override void OnMoneySpent()
    {
        NetCache.Get().ReloadNetObject<NetCache.NetCacheBoosters>();
        this.UpdateMoneyButtonState();
    }

    private void OnRockComplete()
    {
        object[] args = new object[] { "name", ROCK_COMPLETE_TWEEN_NAME, "rotation", this.m_originalLocalRotation, "isLocal", true, "time", 0.1f };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(base.gameObject, hashtable);
    }

    private void OnStoreRadioButtonSelected(int buttonID, object userData)
    {
        StoreRadioButton.Data data = userData as StoreRadioButton.Data;
        if (data == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("GeneralStore.OnStoreRadioButtonSelected(): storeRadioButtonData is null for button ID {0}", buttonID));
        }
        else if (data.m_bundle != null)
        {
            this.SelectedBundle = data.m_bundle;
        }
        else if (data.m_goldPrice != null)
        {
            this.SelectedGoldPrice = data.m_goldPrice;
        }
        else
        {
            UnityEngine.Debug.LogWarning(string.Format("GeneralStore.OnStoreRadioButtonSelected(): storeRadioButtonData has neither bundle nor gold price data for button ID {0}", buttonID));
        }
    }

    private void OnStoreShown(Store.DelOnStoreShown onStoreShownCB)
    {
        base.m_shown = true;
        if (onStoreShownCB != null)
        {
            onStoreShownCB();
        }
    }

    private void PositionOffScreen()
    {
        base.gameObject.transform.position = (Vector3) (Vector3.left * 1000f);
        base.gameObject.transform.localScale = this.m_targetScale;
        base.m_root.SetActive(true);
    }

    private void PreRender()
    {
        base.gameObject.transform.localScale = this.m_targetScale;
        if (!this.m_staticTextResized)
        {
            this.m_headlineText.UpdateNow();
            base.m_buyWithMoneyButton.m_buttonUberText.UpdateNow();
            base.m_buyWithGoldButton.m_buttonUberText.UpdateNow();
            base.UpdateDisclaimerTextNow();
            this.m_staticTextResized = true;
        }
        this.Reset();
    }

    private void Reset()
    {
        this.SetProduct(ProductType.BOOSTER);
        base.ActivateCover(StoreManager.Get().TransactionInProgress());
    }

    private void SetProduct(ProductType product)
    {
        string str;
        string str2;
        Network.GoldPrice lowestCostGoldPrice = StoreManager.Get().GetLowestCostGoldPrice(product);
        Network.Bundle lowestCostBundle = StoreManager.Get().GetLowestCostBundle(product);
        int productData = 0;
        if (lowestCostGoldPrice != null)
        {
            this.SelectedGoldPrice = lowestCostGoldPrice;
            productData = this.SelectedGoldPrice.ProductData;
        }
        else if (lowestCostBundle != null)
        {
            this.SelectedBundle = lowestCostBundle;
            productData = this.SelectedBundle.ProductData;
        }
        this.GetProductDetails(product, productData, out str, out str2);
        this.m_productDetailsHeadlineText.Text = str;
        this.m_productDetailsHeadlineText.UpdateNow();
        this.m_productDetailsText.Text = str2;
        this.m_productDetailsText.UpdateNow();
        List<RadioButtonGroup.ButtonData> radioButtonChoices = this.GetRadioButtonChoices(product);
        if (radioButtonChoices.Count == 0)
        {
            this.m_radioButtonGroup.Hide();
        }
        else
        {
            this.m_radioButtonGroup.ShowButtons(radioButtonChoices, new RadioButtonGroup.DelButtonSelected(this.OnStoreRadioButtonSelected));
        }
    }

    public override void Show(Vector3 position, Vector3 targetScale, Store.DelOnStoreShown onStoreShownCB)
    {
        if (this.m_maxNumFlyingPacks == 0)
        {
            int quantity = 0;
            int num2 = 0;
            List<Network.Bundle> bundlesForProduct = StoreManager.Get().GetBundlesForProduct(ProductType.BOOSTER);
            if (bundlesForProduct.Count > 0)
            {
                quantity = num2 = bundlesForProduct[0].Quantity;
            }
            foreach (Network.Bundle bundle in bundlesForProduct)
            {
                if (bundle.Quantity < quantity)
                {
                    quantity = bundle.Quantity;
                }
                if (bundle.Quantity > num2)
                {
                    num2 = bundle.Quantity;
                }
            }
            this.m_maxNumFlyingPacks = num2 - quantity;
        }
        this.m_targetScale = targetScale;
        object[] args = new object[] { "scale", targetScale, "time", SHOW_ANIM_TIME, "easetype", iTween.EaseType.easeOutBounce, "name", STORE_SCALE_TWEEN_NAME, "oncomplete", "OnStoreShown", "oncompletetarget", base.gameObject, "oncompleteparams", onStoreShownCB };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(base.gameObject, STORE_SCALE_TWEEN_NAME);
        base.transform.localScale = HIDDEN_SCALE;
        base.transform.position = position;
        base.EnableFullScreenEffects(true);
        iTween.ScaleTo(base.gameObject, hashtable);
    }

    protected override void Start()
    {
        base.Start();
        this.m_closeButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnClosePressed));
        this.m_offClicker.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnClosePressed));
    }

    private void UpdateCostDisplay(bool isGold, string costText)
    {
        if (isGold)
        {
            this.m_goldCostText.Text = costText;
            this.m_goldCostText.UpdateNow();
            if (this.m_buyPaneState == BuyPaneState.FLIPPING_TO_GOLD)
            {
                return;
            }
            if (this.m_buyPaneState == BuyPaneState.SHOWING_BUY_GOLD)
            {
                return;
            }
        }
        else
        {
            this.m_moneyCostText.Text = costText;
            this.m_moneyCostText.UpdateNow();
            if (this.m_buyPaneState == BuyPaneState.FLIPPING_TO_MONEY)
            {
                return;
            }
            if (this.m_buyPaneState == BuyPaneState.SHOWING_BUY_MONEY)
            {
                return;
            }
        }
        this.FlipBuyPane(isGold);
    }

    private void UpdateGoldButtonState()
    {
        if (this.SelectedGoldPrice != null)
        {
            long num = this.SelectedGoldPrice.Cost * this.SelectedGoldPrice.Quantity;
            NetCache.NetCacheGoldBalance netObject = NetCache.Get().GetNetObject<NetCache.NetCacheGoldBalance>();
            Store.BuyButtonState eNABLED = Store.BuyButtonState.ENABLED;
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
            base.SetGoldButtonState(eNABLED);
        }
    }

    private void UpdateMoneyButtonState()
    {
        Store.BuyButtonState eNABLED = Store.BuyButtonState.ENABLED;
        if (!StoreManager.Get().IsOpen())
        {
            eNABLED = Store.BuyButtonState.DISABLED;
        }
        else if (!StoreManager.Get().IsBattlePayFeatureEnabled())
        {
            eNABLED = Store.BuyButtonState.DISABLED_FEATURE;
        }
        base.SetMoneyButtonState(eNABLED);
    }

    private void UpdateProductOverviewDisplay(ProductType product, int productData, int quantity)
    {
        this.m_productName.SetText(StoreManager.Get().GetProductName(product, productData, quantity));
        base.StopCoroutine(ANIMATE_PACKS_COROUTINE);
        if (product != ProductType.BOOSTER)
        {
            this.m_packContainer.SetActive(false);
        }
        else
        {
            base.StartCoroutine(ANIMATE_PACKS_COROUTINE, quantity);
        }
    }

    private Network.Bundle SelectedBundle
    {
        get
        {
            return this.m_selectedBundle;
        }
        set
        {
            this.m_selectedGoldPrice = null;
            if (this.m_selectedBundle != value)
            {
                this.m_selectedBundle = value;
                this.UpdateProductOverviewDisplay(this.m_selectedBundle.Product, this.m_selectedBundle.ProductData, this.m_selectedBundle.Quantity);
                string costText = StoreManager.Get().FormatCostText(this.m_selectedBundle.Cost);
                this.UpdateCostDisplay(false, costText);
                this.UpdateMoneyButtonState();
            }
        }
    }

    private Network.GoldPrice SelectedGoldPrice
    {
        get
        {
            return this.m_selectedGoldPrice;
        }
        set
        {
            this.m_selectedBundle = null;
            if (this.m_selectedGoldPrice != value)
            {
                this.m_selectedGoldPrice = value;
                this.UpdateProductOverviewDisplay(this.m_selectedGoldPrice.Product, this.m_selectedGoldPrice.ProductData, this.m_selectedGoldPrice.Quantity);
                string costText = (this.m_selectedGoldPrice.Cost * this.m_selectedGoldPrice.Quantity).ToString();
                this.UpdateCostDisplay(true, costText);
                this.UpdateGoldButtonState();
            }
        }
    }

    [CompilerGenerated]
    private sealed class <AnimatePackDisplay>c__IteratorB4 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>numVisiblePacks;
        internal GeneralStore <>f__this;
        internal int <column>__9;
        internal Vector3 <flyInLocalRotation>__11;
        internal Hashtable <flyInRotateArgs>__17;
        internal Vector3 <flyInRotationAmount>__16;
        internal float <flyInRotDeg>__15;
        internal float <flyInYRotation>__10;
        internal Vector3 <flyOutLocalRotation>__14;
        internal Hashtable <flyOutRotateArgs>__5;
        internal Vector3 <flyOutRotationAmount>__4;
        internal float <flyOutRotDeg>__3;
        internal float <flyOutXRotation>__12;
        internal float <flyOutZRotation>__13;
        internal int <i>__1;
        internal int <i>__7;
        internal int <numPacksFlyingIn>__6;
        internal int <numPacksFlyingOut>__0;
        internal AnimatedLowPolyPack <pack>__2;
        internal AnimatedLowPolyPack <pack>__8;
        internal int numVisiblePacks;

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
                    this.<>f__this.m_packContainer.SetActive(true);
                    if ((this.<>f__this.m_packs.Count - this.numVisiblePacks) > 0)
                    {
                        this.<numPacksFlyingOut>__0 = 0;
                        this.<i>__1 = this.<>f__this.m_packs.Count - 1;
                        while (this.<i>__1 >= this.numVisiblePacks)
                        {
                            this.<pack>__2 = this.<>f__this.m_packs[this.<i>__1];
                            if (!this.<>f__this.m_shown)
                            {
                                this.<pack>__2.FlyOutImmediate();
                            }
                            else if (this.<pack>__2.FlyOut(this.<>f__this.PACK_FLY_OUT_ANIM_TIME, this.<>f__this.PACK_FLY_OUT_DELAY_SECS * this.<numPacksFlyingOut>__0))
                            {
                                this.<numPacksFlyingOut>__0++;
                            }
                            this.<i>__1--;
                        }
                        if ((this.<>f__this.m_maxNumFlyingPacks > 0) && (this.<numPacksFlyingOut>__0 > 0))
                        {
                            this.<flyOutRotDeg>__3 = (((float) this.<numPacksFlyingOut>__0) / ((float) this.<>f__this.m_maxNumFlyingPacks)) * GeneralStore.MAX_FLY_OUT_X_ROTATION;
                            this.<flyOutRotationAmount>__4 = new Vector3(this.<flyOutRotDeg>__3, 0f, 0f);
                            object[] args = new object[] { "name", GeneralStore.ROCK_TWEEN_NAME, "amount", this.<flyOutRotationAmount>__4, "time", GeneralStore.ROCK_ANIMATION_SECS, "oncomplete", "OnRockComplete", "oncompletetarget", this.<>f__this.gameObject };
                            this.<flyOutRotateArgs>__5 = iTween.Hash(args);
                            iTween.StopByName(this.<>f__this.gameObject, GeneralStore.ROCK_COMPLETE_TWEEN_NAME);
                            iTween.StopByName(this.<>f__this.gameObject, GeneralStore.ROCK_TWEEN_NAME);
                            iTween.PunchRotation(this.<>f__this.gameObject, this.<flyOutRotateArgs>__5);
                        }
                    }
                    break;

                case 1:
                {
                    this.<flyInRotDeg>__15 = (((float) this.<numPacksFlyingIn>__6) / ((float) this.<>f__this.m_maxNumFlyingPacks)) * GeneralStore.MAX_FLY_IN_X_ROTATION;
                    this.<flyInRotationAmount>__16 = new Vector3(this.<flyInRotDeg>__15, 0f, 0f);
                    object[] objArray2 = new object[] { "name", GeneralStore.ROCK_TWEEN_NAME, "amount", this.<flyInRotationAmount>__16, "time", GeneralStore.ROCK_ANIMATION_SECS, "oncomplete", "OnRockComplete", "oncompletetarget", this.<>f__this.gameObject };
                    this.<flyInRotateArgs>__17 = iTween.Hash(objArray2);
                    iTween.StopByName(this.<>f__this.gameObject, GeneralStore.ROCK_COMPLETE_TWEEN_NAME);
                    iTween.StopByName(this.<>f__this.gameObject, GeneralStore.ROCK_TWEEN_NAME);
                    iTween.PunchRotation(this.<>f__this.gameObject, this.<flyInRotateArgs>__17);
                    this.$PC = -1;
                    goto Label_058B;
                }
                default:
                    goto Label_058B;
            }
            this.<numPacksFlyingIn>__6 = 0;
            this.<i>__7 = 0;
            while (this.<i>__7 < this.numVisiblePacks)
            {
                this.<pack>__8 = null;
                if (this.<>f__this.m_packs.Count <= this.<i>__7)
                {
                    this.<column>__9 = this.<>f__this.DeterminePackColumn(this.<i>__7);
                    this.<pack>__8 = (AnimatedLowPolyPack) UnityEngine.Object.Instantiate(this.<>f__this.m_packPrefab);
                    this.<pack>__8.transform.parent = this.<>f__this.m_packStacks[this.<column>__9].m_packStackContainer.transform;
                    this.<pack>__8.transform.localScale = GeneralStore.PACK_SCALE;
                    this.<pack>__8.Init(this.<column>__9, this.<>f__this.DeterminePackLocalPos(this.<column>__9), new Vector3(0f, 3.5f, 0f));
                    this.<flyInYRotation>__10 = UnityEngine.Random.Range(-GeneralStore.PACK_Y_DEGREE_VARIATON_MAG, GeneralStore.PACK_Y_DEGREE_VARIATON_MAG);
                    this.<flyInLocalRotation>__11 = new Vector3(0f, this.<flyInYRotation>__10, 0f);
                    this.<flyOutXRotation>__12 = UnityEngine.Random.Range(-GeneralStore.PACK_FLY_OUT_X_DEG_VARIATION_MAG, GeneralStore.PACK_FLY_OUT_X_DEG_VARIATION_MAG);
                    this.<flyOutZRotation>__13 = UnityEngine.Random.Range(-GeneralStore.PACK_FLY_OUT_Z_DEG_VARIATION_MAG, GeneralStore.PACK_FLY_OUT_Z_DEG_VARIATION_MAG);
                    this.<flyOutLocalRotation>__14 = new Vector3(this.<flyOutXRotation>__12, 0f, this.<flyOutZRotation>__13);
                    this.<pack>__8.SetFlyingLocalRotations(this.<flyInLocalRotation>__11, this.<flyOutLocalRotation>__14);
                    this.<>f__this.m_packs.Add(this.<pack>__8);
                }
                else
                {
                    this.<pack>__8 = this.<>f__this.m_packs[this.<i>__7];
                }
                if (!this.<>f__this.m_shown)
                {
                    this.<pack>__8.FlyInImmediate();
                }
                else if (this.<pack>__8.FlyIn(this.<>f__this.PACK_FLY_IN_ANIM_TIME, this.<>f__this.PACK_FLY_IN_DELAY_SECS * this.<numPacksFlyingIn>__6))
                {
                    this.<numPacksFlyingIn>__6++;
                }
                this.<i>__7++;
            }
            if ((this.<>f__this.m_maxNumFlyingPacks != 0) && (this.<numPacksFlyingIn>__6 != 0))
            {
                this.$current = new WaitForSeconds((this.<numPacksFlyingIn>__6 * this.<>f__this.PACK_FLY_IN_DELAY_SECS) * this.<>f__this.ROCK_WAIT_PERCENT);
                this.$PC = 1;
                return true;
            }
        Label_058B:
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

    [CompilerGenerated]
    private sealed class <DeterminePackLocalPos>c__AnonStorey140
    {
        internal int column;

        internal bool <>m__46(AnimatedLowPolyPack obj)
        {
            return (obj.Column == this.column);
        }
    }

    private enum BuyPaneState
    {
        SHOWING_BUY_GOLD,
        SHOWING_BUY_MONEY,
        FLIPPING_TO_GOLD,
        FLIPPING_TO_MONEY
    }
}


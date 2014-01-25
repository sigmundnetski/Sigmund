using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class StoreManager
{
    private static readonly long CONFIG_REQUEST_DELAY_TICKS = 0x23c34600L;
    public static readonly int DEFAULT_SECONDS_BEFORE_AUTO_CANCEL = 600;
    private bool m_battlePayAvailable;
    private Dictionary<int, Network.Bundle> m_bundles = new Dictionary<int, Network.Bundle>();
    private bool m_configLoaded;
    private Currency m_currency;
    private bool m_featuresReady;
    private Dictionary<GoldPriceKey, Network.GoldPrice> m_goldPrices = new Dictionary<GoldPriceKey, Network.GoldPrice>();
    private bool m_initComplete;
    private long m_lastConfigRequestTime;
    private long m_lastStatusRequestTime;
    private bool m_openWhenLastEventFired;
    private ShowStoreData m_showStoreData;
    private TransactionStatus m_status;
    private List<StatusChangedListener> m_statusChangedListeners = new List<StatusChangedListener>();
    private Store m_store;
    private StoreDoneWithBAM m_storeDoneWithBAM;
    private List<StoreHiddenListener> m_storeHiddenListeners = new List<StoreHiddenListener>();
    private StorePasswordPrompt m_storePasswordPrompt;
    private StorePurchaseAuth m_storePurchaseAuth;
    private StoreSendToBAM m_storeSendToBAM;
    private List<StoreShownListener> m_storeShownListeners = new List<StoreShownListener>();
    private StoreSummary m_storeSummary;
    private List<SuccessfulPurchaseListener> m_successfulPurchaseListeners = new List<SuccessfulPurchaseListener>();
    private long m_ticksBeforeAutoCancel = (DEFAULT_SECONDS_BEFORE_AUTO_CANCEL * 0x989680L);
    private long m_timeBeganWaitingForPurchase;
    private bool m_waitingToShowStore;
    private static StoreManager s_instance;
    private static readonly long STATUS_REQUEST_DELAY_TICKS = 0x2faf080L;

    private void AutoCancelPurchaseIfNeeded(long now)
    {
        if (this.CanAutoCancel() && ((now - this.m_timeBeganWaitingForPurchase) >= this.m_ticksBeforeAutoCancel))
        {
            Log.Rachelle.Print("StoreManager.AutoCancelPurchaseIfNeeded(): canceling purchase.");
            this.m_timeBeganWaitingForPurchase = now;
            this.CancelPurchase(true);
        }
    }

    private bool CanAutoCancel()
    {
        switch (this.Status)
        {
            case TransactionStatus.IN_PROGRESS_MONEY:
            case TransactionStatus.WAIT_METHOD_OF_PAYMENT:
                return true;
        }
        return false;
    }

    private void CancelPurchase(bool isAutoCancel)
    {
        Log.Rachelle.Print(string.Format("StoreManager.CancelPurchase(): isAutoCancel={0}", isAutoCancel));
        this.Status = !isAutoCancel ? TransactionStatus.USER_CANCELING : TransactionStatus.AUTO_CANCELING;
        Network.CancelPurchase(isAutoCancel);
    }

    private void CompletePurchaseFailure(string failDetails, bool errorFromPaymentMethod)
    {
        if (this.IsLoaded())
        {
            if (errorFromPaymentMethod)
            {
                if (!this.m_store.IsShown())
                {
                    Debug.LogWarning(string.Format("StoreManager.CompletePurchaseFailure(): get payment method failed ({0}) but the store has been closed.", failDetails));
                }
                else
                {
                    AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
                        m_headerText = GameStrings.Get("GLUE_STORE_ERROR_POPUP_TITLE"),
                        m_text = failDetails,
                        m_showAlertIcon = false,
                        m_responseDisplay = AlertPopup.ResponseDisplay.OK,
                        m_responseCallback = new AlertPopup.ResponseCallback(this.OnPurchaseMethodErrorAcknowledged)
                    };
                    DialogManager.Get().ShowPopup(info);
                }
            }
            else if (!this.m_storePurchaseAuth.CompletePurchaseFailure(failDetails))
            {
                Debug.LogWarning(string.Format("StoreManager.CompletePurchaseFailure(): purchased failed ({0}) but the store authorization window has been closed.", failDetails));
                this.DeactivateStoreCover();
            }
        }
    }

    private void DeactivateStoreCover()
    {
        this.m_store.ActivateCover(false);
    }

    private void FireStatusChangedEventIfNeeded()
    {
        bool isOpen = this.IsOpen();
        if (this.m_openWhenLastEventFired != isOpen)
        {
            foreach (StatusChangedListener listener in this.m_statusChangedListeners.ToArray())
            {
                listener(isOpen);
            }
            this.m_openWhenLastEventFired = isOpen;
        }
    }

    public string FormatCostText(double cost)
    {
        return string.Format("{0:C2}", cost);
    }

    public static StoreManager Get()
    {
        if (s_instance == null)
        {
            s_instance = new StoreManager();
        }
        return s_instance;
    }

    public Network.Bundle GetBundle(int bundleType)
    {
        if (this.m_bundles.ContainsKey(bundleType))
        {
            return this.m_bundles[bundleType];
        }
        Debug.LogWarning(string.Format("StoreManager.GetBundle(): don't have a bundle for type {0}", bundleType));
        return null;
    }

    public List<Network.Bundle> GetBundlesForProduct(ProductType product)
    {
        List<Network.Bundle> list = new List<Network.Bundle>();
        foreach (Network.Bundle bundle in this.m_bundles.Values)
        {
            if (bundle.Product == product)
            {
                list.Add(bundle);
            }
        }
        return list;
    }

    public Network.GoldPrice GetGoldPrice(ProductType product, int productData = 0)
    {
        GoldPriceKey key = new GoldPriceKey(product, productData);
        if (this.m_goldPrices.ContainsKey(key))
        {
            return this.m_goldPrices[key];
        }
        Debug.LogWarning(string.Format("StoreManager.GetGoldPrice(): don't have a gold price for {0}", key));
        return null;
    }

    public List<Network.GoldPrice> GetGoldPricesForProduct(ProductType product)
    {
        List<Network.GoldPrice> list = new List<Network.GoldPrice>();
        foreach (Network.GoldPrice price in this.m_goldPrices.Values)
        {
            if (price.Product == product)
            {
                list.Add(price);
            }
        }
        return list;
    }

    public Network.Bundle GetLowestCostBundle(ProductType product)
    {
        List<Network.Bundle> bundlesForProduct = Get().GetBundlesForProduct(product);
        Network.Bundle bundle = null;
        foreach (Network.Bundle bundle2 in bundlesForProduct)
        {
            if (bundle == null)
            {
                bundle = bundle2;
            }
            else if (bundle.Cost > bundle2.Cost)
            {
                bundle = bundle2;
            }
        }
        return bundle;
    }

    public Network.GoldPrice GetLowestCostGoldPrice(ProductType product)
    {
        List<Network.GoldPrice> goldPricesForProduct = Get().GetGoldPricesForProduct(product);
        Network.GoldPrice price = null;
        foreach (Network.GoldPrice price2 in goldPricesForProduct)
        {
            if (price == null)
            {
                price = price2;
            }
            else if (price.Cost > price2.Cost)
            {
                price = price2;
            }
        }
        return price;
    }

    private NetCache.NetCacheFeatures GetNetCacheFeatures()
    {
        if (!this.FeaturesReady)
        {
            return null;
        }
        NetCache.NetCacheFeatures netObject = NetCache.Get().GetNetObject<NetCache.NetCacheFeatures>();
        if (netObject == null)
        {
            this.FeaturesReady = false;
        }
        return netObject;
    }

    public string GetProductName(ProductType product, int productData, int quantity)
    {
        string str = string.Empty;
        switch (product)
        {
            case ProductType.BOOSTER:
            {
                BoosterType type = (BoosterType) productData;
                switch (type)
                {
                    case BoosterType.EXPERT:
                        return ((quantity != 1) ? GameStrings.Format("GLUE_STORE_MULTI_EXPERT_PACK", new object[] { quantity }) : GameStrings.Get("GLUE_STORE_SINGLE_EXPERT_PACK"));
                }
                Debug.LogWarning(string.Format("StoreManager.GetProductName(): don't know how to format name for booster type {0}", type));
                return str;
            }
            case ProductType.DRAFT_TICKET:
                return GameStrings.Get("GLUE_STORE_PRODUCT_NAME_FORGE_TICKET");
        }
        Debug.LogWarning(string.Format("StoreManager.GetProductName(): don't know how to format name for bundle product {0}", product));
        return str;
    }

    public string GetProductQuantityText(ProductType product, int productData, int quantity)
    {
        string str = string.Empty;
        ProductType type = product;
        if (type != ProductType.BOOSTER)
        {
            if (type == ProductType.DRAFT_TICKET)
            {
                object[] args = new object[] { quantity, GameStrings.Get("GLUE_STORE_PRODUCT_NAME_FORGE_TICKET") };
                return GameStrings.Format("GLUE_STORE_SUMMARY_ITEM_ORDERED", args);
            }
            Debug.LogWarning(string.Format("StoreManager.GetProductQuantityText(): don't know how to format quantity for product {0} (data {1})", product, productData));
            return str;
        }
        return ((quantity != 1) ? GameStrings.Format("GLUE_STORE_MULTI_PACK", new object[] { quantity }) : GameStrings.Get("GLUE_STORE_SINGLE_PACK"));
    }

    private void HandleFailedRiskError()
    {
        bool flag = TransactionStatus.USER_CANCELING == this.Status;
        this.Status = TransactionStatus.READY;
        if ((!flag && this.IsLoaded()) && this.m_store.IsShown())
        {
            this.m_storePurchaseAuth.Hide();
            this.PrepForBAMPopups();
            this.m_storeSendToBAM.Show(StoreSendToBAM.BAMReason.NEED_PASSWORD_RESET);
        }
    }

    public bool HandleKeyboardInput()
    {
        if (this.m_storePasswordPrompt == null)
        {
            return false;
        }
        return this.m_storePasswordPrompt.HandleKeyboardInput();
    }

    private void HandleNoValidPaymentError()
    {
        this.Status = TransactionStatus.READY;
        if (this.IsLoaded() && this.m_store.IsShown())
        {
            this.m_storePurchaseAuth.Hide();
            this.PrepForBAMPopups();
            this.m_storeSendToBAM.Show(StoreSendToBAM.BAMReason.NO_VALID_PAYMENT_METHOD);
        }
    }

    private void HandlePurchaseError(Network.PurchaseErrorInfo purchaseError, bool errorFromPaymentMethod)
    {
        bool flag;
        string failDetails = string.Empty;
        this.BattlePayAvailable = true;
        switch (purchaseError.Error)
        {
            case Network.PurchaseErrorInfo.ErrorType.SUCCESS:
                if (!errorFromPaymentMethod)
                {
                    this.HandlePurchaseSuccess(false);
                    break;
                }
                Debug.LogWarning("StoreManager.HandlePurchaseError(): received SUCCESS from payment method purchase error.");
                break;

            case Network.PurchaseErrorInfo.ErrorType.STILL_IN_PROGRESS:
                if (!errorFromPaymentMethod)
                {
                    this.Status = TransactionStatus.IN_PROGRESS_MONEY;
                    return;
                }
                Debug.LogWarning("StoreManager.HandlePurchaseError(): received STILL_IN_PROGRESS from payment method purchase error.");
                return;

            case Network.PurchaseErrorInfo.ErrorType.INVALID_BNET:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_BNET_ID");
                goto Label_02BC;

            case Network.PurchaseErrorInfo.ErrorType.SERVICE_NA:
                if (this.Status != TransactionStatus.UNKNOWN)
                {
                    this.BattlePayAvailable = false;
                }
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_NO_BATTLEPAY");
                this.CompletePurchaseFailure(failDetails, errorFromPaymentMethod);
                return;

            case Network.PurchaseErrorInfo.ErrorType.PURCHASE_IN_PROGRESS:
                this.Status = TransactionStatus.IN_PROGRESS_MONEY;
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_IN_PROGRESS");
                this.CompletePurchaseFailure(failDetails, errorFromPaymentMethod);
                return;

            case Network.PurchaseErrorInfo.ErrorType.DATABASE:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_DATABASE");
                goto Label_02BC;

            case Network.PurchaseErrorInfo.ErrorType.INVALID_QUANTITY:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_QUANTITY");
                goto Label_02BC;

            case Network.PurchaseErrorInfo.ErrorType.DUPLICATE_LICENSE:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_LICENSE");
                goto Label_02BC;

            case Network.PurchaseErrorInfo.ErrorType.REQUEST_NOT_SENT:
                if (this.Status != TransactionStatus.UNKNOWN)
                {
                    this.BattlePayAvailable = false;
                }
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_NO_BATTLEPAY");
                goto Label_02BC;

            case Network.PurchaseErrorInfo.ErrorType.NO_ACTIVE_BPAY:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_NO_ACTIVE_BPAY");
                goto Label_02BC;

            case Network.PurchaseErrorInfo.ErrorType.FAILED_RISK:
                this.HandleFailedRiskError();
                return;

            case Network.PurchaseErrorInfo.ErrorType.CANCELED:
                this.Status = TransactionStatus.READY;
                return;

            case Network.PurchaseErrorInfo.ErrorType.WAIT_MOP:
                Log.Rachelle.Print("StoreManager.OnBattlePayStatusResponse(): Status is WAIT_MOP... this probably shouldn't be happening.");
                if (this.Status != TransactionStatus.UNKNOWN)
                {
                    this.Status = TransactionStatus.WAIT_METHOD_OF_PAYMENT;
                    return;
                }
                this.CancelPurchase(true);
                return;

            case Network.PurchaseErrorInfo.ErrorType.WAIT_CONFIRM:
                if (this.Status == TransactionStatus.UNKNOWN)
                {
                    this.CancelPurchase(true);
                }
                return;

            case Network.PurchaseErrorInfo.ErrorType.WAIT_RISK:
                Log.Rachelle.Print("StoreManager.OnBattlePayStatusResponse(): Waiting for client to respond to Risk challenge");
                if (this.Status != TransactionStatus.UNKNOWN)
                {
                    if ((this.Status == TransactionStatus.PASSWORD_SUBMITTED) || (this.Status == TransactionStatus.USER_CANCELING))
                    {
                        Log.Rachelle.Print(string.Format("StoreManager.OnBattlePayStatusResponse(): Status = {0}; ignoring WAIT_RISK purchase error info", this.Status));
                    }
                    else
                    {
                        this.Status = TransactionStatus.WAIT_RISK;
                    }
                    return;
                }
                this.CancelPurchase(true);
                return;

            case Network.PurchaseErrorInfo.ErrorType.PRODUCT_NA:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_PRODUCT_NA");
                goto Label_02BC;

            case Network.PurchaseErrorInfo.ErrorType.RISK_TIMEOUT:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_PASSWORD_TIMEOUT");
                goto Label_02BC;

            case Network.PurchaseErrorInfo.ErrorType.BP_GENERIC_FAIL:
            {
                object[] args = new object[] { purchaseError.ErrorCode };
                failDetails = GameStrings.Format("GLUE_STORE_FAIL_ERROR_CODE", args);
                goto Label_02BC;
            }
            case Network.PurchaseErrorInfo.ErrorType.BP_INVALID_CC_EXPIRY:
                failDetails = GameStrings.Format("GLUE_STORE_FAIL_CC_EXPIRY", new object[0]);
                goto Label_02BC;

            case Network.PurchaseErrorInfo.ErrorType.BP_NO_VALID_PAYMENT:
                if (!errorFromPaymentMethod)
                {
                    this.HandleNoValidPaymentError();
                    return;
                }
                Debug.LogWarning("StoreManager.HandlePurchaseError(): received BP_NO_VALID_PAYMENT from payment method purchase error.");
                return;

            case Network.PurchaseErrorInfo.ErrorType.BP_PROVIDER_DENIED:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_PROVIDER_DENIED");
                goto Label_02BC;

            default:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_GENERAL");
                goto Label_02BC;
        }
        return;
    Label_02BC:
        flag = TransactionStatus.UNKNOWN == this.Status;
        this.Status = TransactionStatus.READY;
        if (!flag)
        {
            this.CompletePurchaseFailure(failDetails, errorFromPaymentMethod);
        }
    }

    private void HandlePurchaseSuccess(bool boughtWithGold)
    {
        this.Status = TransactionStatus.READY;
        if (this.IsLoaded())
        {
            if (boughtWithGold)
            {
                this.m_store.OnGoldSpent();
            }
            else
            {
                this.m_store.OnMoneySpent();
            }
            if (!this.m_storePurchaseAuth.CompletePurchaseSuccess(new StorePurchaseAuth.DelOnAuthFaded(this.OnPurchaseSuccessHidden), boughtWithGold))
            {
                this.OnPurchaseSuccessHidden(boughtWithGold);
            }
        }
    }

    private bool HaveProductsToSell()
    {
        return ((this.m_bundles.Count > 0) || (this.m_goldPrices.Count > 0));
    }

    public void Heartbeat()
    {
        if (this.m_initComplete)
        {
            long ticks = DateTime.Now.Ticks;
            this.RequestStatusIfNeeded(ticks);
            this.RequestConfigIfNeeded(ticks);
            this.AutoCancelPurchaseIfNeeded(ticks);
        }
    }

    public void HideForgeStore()
    {
        if (this.m_store is ForgeStore)
        {
            this.m_store.Hide();
        }
    }

    public void Init()
    {
        if (this.m_initComplete)
        {
            Debug.LogError("StoreManager.Init(): duplicate call!");
        }
        SceneMgr.Get().RegisterSceneUnloadedEvent(new SceneMgr.SceneUnloadedCallback(this.OnSceneUnloaded));
        BnetChallengeMgr.Get().AddChallengeListener(new BnetChallengeMgr.ChallengeCallback(this.OnChallengeReceived));
        Network network = Network.Get();
        network.RegisterNetHandler(Network.PacketID.BATTLEPAY_STATUS_RESPONSE, new Network.NetHandler(this.OnBattlePayStatusResponse));
        network.RegisterNetHandler(Network.PacketID.BATTLE_PAY_CONFIG_RESPONSE, new Network.NetHandler(this.OnBattlePayConfigResponse));
        network.RegisterNetHandler(Network.PacketID.PURCHASE_METHOD, new Network.NetHandler(this.OnPurchaseMethod));
        network.RegisterNetHandler(Network.PacketID.CARD_QUOTE, new Network.NetHandler(this.OnPurchaseResponse));
        network.RegisterNetHandler(Network.PacketID.PURCHASE_CANCELED_RESPONSE, new Network.NetHandler(this.OnPurchaseCanceledResponse));
        network.RegisterNetHandler(Network.PacketID.PURCHASE_WITH_GOLD_RESPONSE, new Network.NetHandler(this.OnPurchaseViaGoldResponse));
        NetCache.Get().RegisterFeatures(new NetCache.NetCacheCallback(this.OnNetCacheFeaturesReady));
        this.m_initComplete = true;
    }

    public bool IsBattlePayFeatureEnabled()
    {
        NetCache.NetCacheFeatures netCacheFeatures = this.GetNetCacheFeatures();
        if (netCacheFeatures == null)
        {
            return false;
        }
        return (netCacheFeatures.Store.Store && netCacheFeatures.Store.BattlePay);
    }

    public bool IsBuyWithGoldFeatureEnabled()
    {
        NetCache.NetCacheFeatures netCacheFeatures = this.GetNetCacheFeatures();
        if (netCacheFeatures == null)
        {
            return false;
        }
        return (netCacheFeatures.Store.Store && netCacheFeatures.Store.BuyWithGold);
    }

    private bool IsLoaded()
    {
        if (this.m_store == null)
        {
            return false;
        }
        if (!this.m_store.IsReady())
        {
            return false;
        }
        if (this.m_storePurchaseAuth == null)
        {
            return false;
        }
        if (this.m_storeSummary == null)
        {
            return false;
        }
        if (this.m_storeSendToBAM == null)
        {
            return false;
        }
        if (this.m_storeDoneWithBAM == null)
        {
            return false;
        }
        if (this.m_storePasswordPrompt == null)
        {
            return false;
        }
        return true;
    }

    public bool IsOpen()
    {
        if (!this.IsStoreFeatureEnabled())
        {
            return false;
        }
        if (!this.BattlePayAvailable)
        {
            return false;
        }
        if (!this.ConfigLoaded)
        {
            return false;
        }
        if (!this.HaveProductsToSell())
        {
            return false;
        }
        return (TransactionStatus.UNKNOWN != this.Status);
    }

    public bool IsShown()
    {
        return ((this.m_store != null) && this.m_store.IsShown());
    }

    public bool IsShownOrWaitingToShow()
    {
        return (this.IsWaitingToShow() || this.IsShown());
    }

    public bool IsStoreFeatureEnabled()
    {
        NetCache.NetCacheFeatures netCacheFeatures = this.GetNetCacheFeatures();
        if (netCacheFeatures == null)
        {
            return false;
        }
        return netCacheFeatures.Store.Store;
    }

    public bool IsWaitingToShow()
    {
        return this.m_waitingToShowStore;
    }

    private void Load(bool useForgeStore)
    {
        if (useForgeStore)
        {
            AssetLoader.Get().LoadActor("ForgePreInfo", new AssetLoader.GameObjectCallback(this.OnForgeStoreLoaded));
        }
        else
        {
            AssetLoader.Get().LoadGameObject("GeneralStore", new AssetLoader.GameObjectCallback(this.OnGeneralStoreLoaded));
        }
        AssetLoader.Get().LoadGameObject("StorePurchaseAuth", new AssetLoader.GameObjectCallback(this.OnStorePurchaseAuthLoaded));
        AssetLoader.Get().LoadGameObject("StoreSummary", new AssetLoader.GameObjectCallback(this.OnStoreSummaryLoaded));
        AssetLoader.Get().LoadGameObject("StoreSendToBAM", new AssetLoader.GameObjectCallback(this.OnStoreSendToBAMLoaded));
        AssetLoader.Get().LoadGameObject("StoreDoneWithBAM", new AssetLoader.GameObjectCallback(this.OnStoreDoneWithBAMLoaded));
        AssetLoader.Get().LoadGameObject("StorePasswordPrompt", new AssetLoader.GameObjectCallback(this.OnStorePasswordPromptLoaded));
    }

    private void OnBattlePayConfigResponse()
    {
        Network.BattlePayConfig battlePayConfigResponse = Network.GetBattlePayConfigResponse();
        if (!battlePayConfigResponse.Available)
        {
            this.BattlePayAvailable = false;
        }
        else
        {
            this.BattlePayAvailable = true;
            this.m_currency = battlePayConfigResponse.Currency;
            this.m_ticksBeforeAutoCancel = battlePayConfigResponse.SecondsBeforeAutoCancel * 0x989680L;
            this.m_bundles.Clear();
            foreach (Network.Bundle bundle in battlePayConfigResponse.Bundles)
            {
                this.m_bundles.Add(bundle.BundleType, bundle);
            }
            this.m_goldPrices.Clear();
            foreach (Network.GoldPrice price in battlePayConfigResponse.GoldPrices)
            {
                this.m_goldPrices.Add(new GoldPriceKey(price.Product, price.ProductData), price);
            }
            this.ConfigLoaded = true;
        }
    }

    private void OnBattlePayStatusResponse()
    {
        Network.BattlePayStatus battlePayStatusResponse = Network.GetBattlePayStatusResponse();
        this.BattlePayAvailable = battlePayStatusResponse.BattlePayAvailable;
        switch (battlePayStatusResponse.State)
        {
            case Network.BattlePayStatus.PurchaseState.READY:
                this.Status = TransactionStatus.READY;
                break;

            case Network.BattlePayStatus.PurchaseState.CHECK_RESULTS:
                this.HandlePurchaseError(battlePayStatusResponse.PurchaseError, false);
                break;

            case Network.BattlePayStatus.PurchaseState.ERROR:
                Debug.LogWarning("StoreManager.OnBattlePayStatusResponse(): Error getting status. Check with Rachelle.");
                break;

            default:
                Debug.LogError(string.Format("StoreManager.OnBattlePayStatusResponse(): unknown state {0}", battlePayStatusResponse.State));
                break;
        }
    }

    private void OnChallengeReceived(BnetChallengeMgr.ChallengeInfo challengeInfo, object userData)
    {
        this.m_store.ActivateCover(true);
        this.m_storePasswordPrompt.SetTargetPosAndScale(this.m_store.GetPasswordPromptPosition(), this.m_store.GetPasswordPromptScale());
        if (this.m_storePasswordPrompt.Show(challengeInfo.ID, challengeInfo.IsRetry))
        {
            this.m_storePurchaseAuth.Hide();
        }
        else
        {
            Debug.LogWarning(string.Format("StoreManager.OnChallengeReceived(): received challenge {0} while we have an active challenge; auto-canceling", challengeInfo.ID));
            Network.Get().CancelChallenge(challengeInfo.ID);
        }
    }

    private void OnDoneWithBAM()
    {
        this.DeactivateStoreCover();
    }

    private void OnForgeStoreLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError("StoreManager.OnForgeStoreLoaded(): go is null!");
        }
        else
        {
            ForgeStore component = go.GetComponent<ForgeStore>();
            if (component == null)
            {
                Debug.LogError("StoreManager.OnForgeStoreLoaded(): go has no ForgeStore component");
            }
            else
            {
                this.OnStoreLoaded(component);
            }
        }
    }

    private void OnGeneralStoreLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError("StoreManager.OnStoreLoaded(): go is null!");
        }
        else
        {
            GeneralStore component = go.GetComponent<GeneralStore>();
            if (component == null)
            {
                Debug.LogError("StoreManager.OnGeneralStoreLoaded(): go has no GeneralStore component");
            }
            else
            {
                this.OnStoreLoaded(component);
            }
        }
    }

    private void OnNetCacheFeaturesReady()
    {
        this.FeaturesReady = true;
    }

    private void OnPasswordCancel(ulong challengeID)
    {
        this.Status = TransactionStatus.USER_CANCELING;
        Network.Get().CancelChallenge(challengeID);
        this.DeactivateStoreCover();
    }

    private void OnPasswordSubmit(ulong challengeID, string password)
    {
        this.m_storePurchaseAuth.Show();
        this.m_lastStatusRequestTime = DateTime.Now.Ticks;
        this.Status = TransactionStatus.PASSWORD_SUBMITTED;
        Network.Get().AnswerChallenge(challengeID, password);
    }

    private void OnPurchaseCanceledResponse()
    {
        if (Network.GetPurchaseCanceledResponse().Result == Network.PurchaseCanceledResponse.CancelResult.NOT_ALLOWED)
        {
            Debug.LogWarning("StoreManager.OnPurchaseCanceledResponse(): cancel purchase is not allowed right now.");
            this.Status = TransactionStatus.IN_PROGRESS_MONEY;
        }
        else
        {
            Log.Rachelle.Print("StoreManager.OnPurchaseCanceledResponse(): purchase successfully canceled.");
            this.m_lastStatusRequestTime = DateTime.Now.Ticks;
            this.Status = TransactionStatus.READY;
        }
    }

    private void OnPurchaseFailureAcknowledged()
    {
        this.DeactivateStoreCover();
        if (!this.BattlePayAvailable && (this.m_store is GeneralStore))
        {
            ((GeneralStore) this.m_store).Close();
        }
    }

    private void OnPurchaseMethod()
    {
        Network.PurchaseMethod purchaseMethodResponse = Network.GetPurchaseMethodResponse();
        bool flag = false;
        if (purchaseMethodResponse.PurchaseError != null)
        {
            if (purchaseMethodResponse.PurchaseError.Error != Network.PurchaseErrorInfo.ErrorType.BP_NO_VALID_PAYMENT)
            {
                this.HandlePurchaseError(purchaseMethodResponse.PurchaseError, true);
                return;
            }
            flag = true;
        }
        string paymentMethodName = !(flag || purchaseMethodResponse.UseEBalance) ? purchaseMethodResponse.WalletName : GameStrings.Get("GLUE_STORE_BNET_BALANCE");
        this.Status = TransactionStatus.WAIT_CONFIRM;
        this.PrepForSummaryAndAuth();
        this.m_storeSummary.Show(purchaseMethodResponse.BundleType, purchaseMethodResponse.Quantity, paymentMethodName);
    }

    private void OnPurchaseMethodErrorAcknowledged(AlertPopup.Response response, object userData)
    {
        if (this.m_store is GeneralStore)
        {
            ((GeneralStore) this.m_store).Close();
        }
    }

    private void OnPurchaseResponse()
    {
        Network.PurchaseResponse purchaseResponse = Network.GetPurchaseResponse();
        this.HandlePurchaseError(purchaseResponse.PurchaseError, false);
    }

    private void OnPurchaseSuccessHidden(object userData)
    {
        this.DeactivateStoreCover();
        bool boughtWithGold = (bool) userData;
        foreach (SuccessfulPurchaseListener listener in this.m_successfulPurchaseListeners.ToArray())
        {
            listener(boughtWithGold);
        }
    }

    private void OnPurchaseViaGoldResponse()
    {
        Network.PurchaseViaGoldResponse purchaseWithGoldResponse = Network.GetPurchaseWithGoldResponse();
        string failDetails = string.Empty;
        switch (purchaseWithGoldResponse.Error)
        {
            case Network.PurchaseViaGoldResponse.ErrorType.SUCCESS:
                NetCache.Get().OnGoldBalanceChanged(-purchaseWithGoldResponse.GoldUsed);
                this.HandlePurchaseSuccess(true);
                return;

            case Network.PurchaseViaGoldResponse.ErrorType.INSUFFICIENT_GOLD:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_NOT_ENOUGH_GOLD");
                break;

            case Network.PurchaseViaGoldResponse.ErrorType.PRODUCT_NA:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_PRODUCT_NA");
                break;

            case Network.PurchaseViaGoldResponse.ErrorType.FEATURE_NA:
                failDetails = GameStrings.Get("GLUE_TOOLTIP_BUTTON_DISABLED_DESC");
                break;

            case Network.PurchaseViaGoldResponse.ErrorType.INVALID_QUANTITY:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_QUANTITY");
                break;

            default:
                failDetails = GameStrings.Get("GLUE_STORE_FAIL_GENERAL");
                break;
        }
        this.Status = TransactionStatus.READY;
        this.m_storePurchaseAuth.CompletePurchaseFailure(failDetails);
    }

    private void OnSceneUnloaded(SceneMgr.Mode prevMode, Scene prevScene, object userData)
    {
        this.Unload();
    }

    private void OnSendToBAMOkay(StoreSendToBAM.BAMReason reason)
    {
        if (reason != StoreSendToBAM.BAMReason.NO_VALID_PAYMENT_METHOD)
        {
            this.OnDoneWithBAM();
        }
        else
        {
            this.m_storeDoneWithBAM.Show();
        }
    }

    private void OnStoreBuyWithGold(ProductType product, int data, int quantity)
    {
        this.m_store.ActivateCover(true);
        this.PrepForSummaryAndAuth();
        this.m_storePurchaseAuth.Show();
        this.Status = TransactionStatus.IN_PROGRESS_GOLD;
        Network.PurchaseViaGold(quantity, product, data);
    }

    private void OnStoreBuyWithMoney(int bundleType, int quantity)
    {
        this.m_store.ActivateCover(true);
        this.Status = TransactionStatus.WAIT_METHOD_OF_PAYMENT;
        Network.GetPurchaseMethod(bundleType, quantity, this.m_currency);
    }

    private void OnStoreComponentReady()
    {
        if (this.m_waitingToShowStore && this.IsLoaded())
        {
            this.ShowStore();
        }
    }

    private void OnStoreDoneWithBAMLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError("StoreManager.OnStoreDoneWithBAMLoaded(): go is null!");
        }
        else
        {
            this.m_storeDoneWithBAM = go.GetComponent<StoreDoneWithBAM>();
            if (this.m_storeDoneWithBAM == null)
            {
                Debug.LogError("StoreManager.OnStoreDoneWithBAMLoaded(): go has no StoreDoneWithBAM component");
            }
            else
            {
                this.m_storeDoneWithBAM.Hide();
                this.m_storeDoneWithBAM.RegisterOkayListener(new StoreDoneWithBAM.ButtonPressedListener(this.OnDoneWithBAM));
                this.m_storeDoneWithBAM.RegisterCancelListener(new StoreDoneWithBAM.ButtonPressedListener(this.OnDoneWithBAM));
                this.OnStoreComponentReady();
            }
        }
    }

    private void OnStoreExit()
    {
        foreach (StoreHiddenListener listener in this.m_storeHiddenListeners.ToArray())
        {
            listener();
        }
        if (((this.Status == TransactionStatus.WAIT_CONFIRM) || (this.Status == TransactionStatus.WAIT_METHOD_OF_PAYMENT)) || (this.Status == TransactionStatus.WAIT_RISK))
        {
            this.CancelPurchase(true);
        }
        this.m_storeSummary.Hide();
        this.m_storePurchaseAuth.Hide();
        this.m_storeSendToBAM.Hide();
        this.m_storeDoneWithBAM.Hide();
        ulong challengeID = this.m_storePasswordPrompt.Hide();
        if (challengeID != 0)
        {
            Network.Get().CancelChallenge(challengeID);
        }
    }

    private void OnStoreInfo()
    {
        this.m_store.ActivateCover(true);
        this.PrepForBAMPopups();
        this.m_storeSendToBAM.Show(StoreSendToBAM.BAMReason.PAYMENT_INFO);
    }

    private void OnStoreLoaded(Store store)
    {
        if (store != null)
        {
            store.Hide();
            this.m_store = store;
            this.m_store.RegisterBuyWithMoneyListener(new Store.BuyWithMoneyListener(this.OnStoreBuyWithMoney));
            this.m_store.RegisterBuyWithGoldListener(new Store.BuyWithGoldListener(this.OnStoreBuyWithGold));
            this.m_store.RegisterExitListener(new Store.ExitListener(this.OnStoreExit));
            this.m_store.RegisterInfoListener(new Store.InfoListener(this.OnStoreInfo));
            this.m_store.RegisterReadyListener(new Store.ReadyListener(this.OnStoreComponentReady));
            this.OnStoreComponentReady();
        }
    }

    private void OnStorePasswordPromptLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError("StoreManager.OnStorePasswordPromptLoaded(): go is null!");
        }
        else
        {
            this.m_storePasswordPrompt = go.GetComponent<StorePasswordPrompt>();
            if (this.m_storePasswordPrompt == null)
            {
                Debug.LogError("StoreManager.OnStorePasswordPromptLoaded(): go has no StorePasswordPrompt component");
            }
            else
            {
                this.m_storePasswordPrompt.Hide();
                this.m_storePasswordPrompt.RegisterSubmitListener(new StorePasswordPrompt.SubmitListener(this.OnPasswordSubmit));
                this.m_storePasswordPrompt.RegisterCancelListener(new StorePasswordPrompt.CancelListener(this.OnPasswordCancel));
                this.OnStoreComponentReady();
            }
        }
    }

    private void OnStorePurchaseAuthLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError("StoreManager.OnStorePurchaseAuthLoaded(): go is null!");
        }
        else
        {
            this.m_storePurchaseAuth = go.GetComponent<StorePurchaseAuth>();
            if (this.m_storePurchaseAuth == null)
            {
                Debug.LogError("StoreManager.OnStorePurchaseAuthLoaded(): go has no StorePurchaseAuth component");
            }
            else
            {
                this.m_storePurchaseAuth.Hide();
                this.m_storePurchaseAuth.RegisterAckPurchaseFailListener(new StorePurchaseAuth.AckPurchaseFailListener(this.OnPurchaseFailureAcknowledged));
                this.OnStoreComponentReady();
            }
        }
    }

    private void OnStoreSendToBAMLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError("StoreManager.OnStoreSendToBAMLoaded(): go is null!");
        }
        else
        {
            this.m_storeSendToBAM = go.GetComponent<StoreSendToBAM>();
            if (this.m_storeSendToBAM == null)
            {
                Debug.LogError("StoreManager.OnStoreSendToBAMLoaded(): go has no StoreSendToBAM component");
            }
            else
            {
                this.m_storeSendToBAM.Hide();
                this.m_storeSendToBAM.RegisterOkayListener(new StoreSendToBAM.DelOKListener(this.OnSendToBAMOkay));
                this.m_storeSendToBAM.RegisterCancelListener(new StoreSendToBAM.DelCancelListener(this.OnDoneWithBAM));
                this.OnStoreComponentReady();
            }
        }
    }

    private void OnStoreShown()
    {
        foreach (StoreShownListener listener in this.m_storeShownListeners.ToArray())
        {
            listener();
        }
        if (this.TransactionInProgress())
        {
            this.PrepForSummaryAndAuth();
            this.m_storePurchaseAuth.Show();
        }
    }

    private void OnStoreSummaryLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError("StoreManager.OnStoreSummaryLoaded(): go is null!");
        }
        else
        {
            this.m_storeSummary = go.GetComponent<StoreSummary>();
            if (this.m_storeSummary == null)
            {
                Debug.LogError("StoreManager.OnStoreSummaryLoaded(): go has no StoreSummary component");
            }
            else
            {
                this.m_storeSummary.Hide();
                this.m_storeSummary.RegisterConfirmListener(new StoreSummary.ConfirmListener(this.OnSummaryConfirm));
                this.m_storeSummary.RegisterCancelListener(new StoreSummary.CancelListener(this.OnSummaryCancel));
                this.OnStoreComponentReady();
            }
        }
    }

    private void OnSummaryCancel()
    {
        this.CancelPurchase(false);
        this.DeactivateStoreCover();
    }

    private void OnSummaryConfirm(int bundleType, int quantity)
    {
        this.m_storePurchaseAuth.Show();
        this.m_lastStatusRequestTime = DateTime.Now.Ticks;
        this.Status = TransactionStatus.IN_PROGRESS_MONEY;
        Network.ConfirmPurchase();
    }

    private void PrepForBAMPopups()
    {
        Vector3 bAMPopupPosition = this.m_store.GetBAMPopupPosition();
        Vector3 bAMPopupScale = this.m_store.GetBAMPopupScale();
        this.m_storeSendToBAM.SetTargetPosAndScale(bAMPopupPosition, bAMPopupScale);
        this.m_storeDoneWithBAM.SetTargetPosAndScale(bAMPopupPosition, bAMPopupScale);
    }

    private void PrepForSummaryAndAuth()
    {
        this.m_storeSummary.SetTargetPosAndScale(this.m_store.GetSummaryPosition(), this.m_store.GetSummaryScale());
        this.m_storePurchaseAuth.transform.position = this.m_store.GetAuthPosition();
        this.m_storePurchaseAuth.transform.localScale = this.m_store.GetAuthScale();
        this.m_store.ActivateCover(true);
    }

    public void RegisterStatusChangedListener(StatusChangedListener listener)
    {
        if (!this.m_statusChangedListeners.Contains(listener))
        {
            this.m_statusChangedListeners.Add(listener);
        }
    }

    public void RegisterStoreHiddenListener(StoreHiddenListener listener)
    {
        if (!this.m_storeHiddenListeners.Contains(listener))
        {
            this.m_storeHiddenListeners.Add(listener);
        }
    }

    public void RegisterStoreShownListener(StoreShownListener listener)
    {
        if (!this.m_storeShownListeners.Contains(listener))
        {
            this.m_storeShownListeners.Add(listener);
        }
    }

    public void RegisterSuccessfulPurchaseListener(SuccessfulPurchaseListener listener)
    {
        if (!this.m_successfulPurchaseListeners.Contains(listener))
        {
            this.m_successfulPurchaseListeners.Add(listener);
        }
    }

    public void RemoveStatusChangedListener(StatusChangedListener listener)
    {
        this.m_statusChangedListeners.Remove(listener);
    }

    public void RemoveStoreHiddenListener(StoreHiddenListener listener)
    {
        this.m_storeHiddenListeners.Remove(listener);
    }

    public void RemoveStoreShownListener(StoreShownListener listener)
    {
        this.m_storeShownListeners.Remove(listener);
    }

    public void RemoveSuccessfulPurchaseListener(SuccessfulPurchaseListener listener)
    {
        this.m_successfulPurchaseListeners.Remove(listener);
    }

    private void RequestConfigIfNeeded(long now)
    {
        if (!this.ConfigLoaded && ((now - this.m_lastConfigRequestTime) >= CONFIG_REQUEST_DELAY_TICKS))
        {
            this.m_lastConfigRequestTime = now;
            Network.RequestBattlePayConfig();
        }
    }

    private void RequestStatusIfNeeded(long now)
    {
        if (this.ConfigLoaded)
        {
            bool flag = ((this.Status == TransactionStatus.UNKNOWN) || (this.Status == TransactionStatus.IN_PROGRESS_MONEY)) || (TransactionStatus.PASSWORD_SUBMITTED == this.Status);
            if ((!this.BattlePayAvailable || flag) && ((now - this.m_lastStatusRequestTime) >= STATUS_REQUEST_DELAY_TICKS))
            {
                this.m_lastStatusRequestTime = now;
                Network.RequestBattlePayStatus();
            }
        }
    }

    private void ShowStore()
    {
        if (this.m_showStoreData.m_isForgeStore)
        {
            this.m_store.RegisterExitListener(this.m_showStoreData.m_exitListener);
            this.m_store.Show(this.m_showStoreData.m_storePos, this.m_showStoreData.m_storeScale, null);
        }
        else if (this.IsOpen())
        {
            this.m_store.Show(this.m_showStoreData.m_storePos, this.m_showStoreData.m_storeScale, new Store.DelOnStoreShown(this.OnStoreShown));
        }
        else
        {
            Debug.LogWarning("StoreManager.ShowStore(): Cannot show general store... Store is not open");
        }
        this.m_waitingToShowStore = false;
    }

    private void ShowStoreWhenLoaded()
    {
        this.m_waitingToShowStore = true;
        if (!this.IsLoaded())
        {
            this.Load(this.m_showStoreData.m_isForgeStore);
        }
        else
        {
            this.ShowStore();
        }
    }

    public void StartForgeTransaction(Vector3 storePos, Vector3 storeScale, Store.ExitListener exitListener)
    {
        if (this.m_waitingToShowStore)
        {
            Log.Rachelle.Print("StoreManager.StartForgeTransaction(): already waiting to show store");
        }
        else
        {
            this.m_showStoreData.m_storePos = storePos;
            this.m_showStoreData.m_storeScale = storeScale;
            this.m_showStoreData.m_isForgeStore = true;
            this.m_showStoreData.m_exitListener = exitListener;
            this.ShowStoreWhenLoaded();
        }
    }

    public void StartGeneralTransaction(Vector3 storePos, Vector3 storeScale)
    {
        if (this.m_waitingToShowStore)
        {
            Log.Rachelle.Print("StoreManager.StartGeneralTransaction(): already waiting to show store");
        }
        else
        {
            this.m_showStoreData.m_storePos = storePos;
            this.m_showStoreData.m_storeScale = storeScale;
            this.m_showStoreData.m_isForgeStore = false;
            this.m_showStoreData.m_exitListener = null;
            this.ShowStoreWhenLoaded();
        }
    }

    public bool TransactionInProgress()
    {
        return ((this.Status == TransactionStatus.IN_PROGRESS_MONEY) || (TransactionStatus.IN_PROGRESS_GOLD == this.Status));
    }

    private void Unload()
    {
        if (this.m_store != null)
        {
            UnityEngine.Object.Destroy(this.m_store.gameObject);
            this.m_store = null;
        }
        if (this.m_storePurchaseAuth != null)
        {
            UnityEngine.Object.Destroy(this.m_storePurchaseAuth.gameObject);
            this.m_storePurchaseAuth = null;
        }
        if (this.m_storeSummary != null)
        {
            UnityEngine.Object.Destroy(this.m_storeSummary.gameObject);
            this.m_storeSummary = null;
        }
        if (this.m_storeSendToBAM != null)
        {
            UnityEngine.Object.Destroy(this.m_storeSendToBAM.gameObject);
            this.m_storeSendToBAM = null;
        }
        if (this.m_storeDoneWithBAM != null)
        {
            UnityEngine.Object.Destroy(this.m_storeDoneWithBAM.gameObject);
            this.m_storeDoneWithBAM = null;
        }
        if (this.m_storePasswordPrompt != null)
        {
            UnityEngine.Object.Destroy(this.m_storePasswordPrompt.gameObject);
            this.m_storePasswordPrompt = null;
        }
    }

    private bool BattlePayAvailable
    {
        get
        {
            return this.m_battlePayAvailable;
        }
        set
        {
            this.m_battlePayAvailable = value;
            this.FireStatusChangedEventIfNeeded();
        }
    }

    private bool ConfigLoaded
    {
        get
        {
            return this.m_configLoaded;
        }
        set
        {
            this.m_configLoaded = value;
            this.FireStatusChangedEventIfNeeded();
        }
    }

    private bool FeaturesReady
    {
        get
        {
            return this.m_featuresReady;
        }
        set
        {
            this.m_featuresReady = value;
            this.FireStatusChangedEventIfNeeded();
        }
    }

    private TransactionStatus Status
    {
        get
        {
            return this.m_status;
        }
        set
        {
            this.m_status = value;
            if (this.CanAutoCancel())
            {
                this.m_timeBeganWaitingForPurchase = DateTime.Now.Ticks;
            }
            this.FireStatusChangedEventIfNeeded();
        }
    }

    private class GoldPriceKey
    {
        public GoldPriceKey(ProductType product, int productData)
        {
            this.Product = product;
            this.ProductData = productData;
        }

        public override string ToString()
        {
            return string.Format("[GoldPriceKey: Product={0} Data={1}]", this.Product, this.ProductData);
        }

        public ProductType Product { get; private set; }

        public int ProductData { get; private set; }
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct ShowStoreData
    {
        public bool m_isForgeStore;
        public Vector3 m_storePos;
        public Vector3 m_storeScale;
        public Store.ExitListener m_exitListener;
    }

    public delegate void StatusChangedListener(bool isOpen);

    public delegate void StoreHiddenListener();

    public delegate void StoreShownListener();

    public delegate void SuccessfulPurchaseListener(bool boughtWithGold);

    private enum TransactionStatus
    {
        UNKNOWN,
        IN_PROGRESS_MONEY,
        IN_PROGRESS_GOLD,
        READY,
        WAIT_METHOD_OF_PAYMENT,
        WAIT_CONFIRM,
        WAIT_RISK,
        PASSWORD_SUBMITTED,
        USER_CANCELING,
        AUTO_CANCELING
    }
}


using System;
using System.Collections;
using UnityEngine;

public class CurrencyFrame : MonoBehaviour
{
    public UberText m_amount;
    public GameObject m_background;
    public PegUIElement m_dustJar;
    public PegUIElement m_goldCoin;
    private CurrencyType m_showingCurrency;
    private State m_state = State.SHOWN;

    private void ActivateCurrencyFrame()
    {
        this.m_state = State.SHOWN;
    }

    private void Awake()
    {
        NetCache.Get().RegisterGoldBalanceListener(new NetCache.DelGoldBalanceListener(this.OnGoldBalanceChanged));
        this.m_dustJar.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnDustJarMouseOver));
        this.m_dustJar.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.OnDustJarMouseOut));
    }

    public void DeactivateCurrencyFrame()
    {
        base.gameObject.SetActive(false);
        this.m_state = State.HIDDEN;
    }

    private void FadeBackground(bool isFaded)
    {
        Hashtable hashtable;
        if (isFaded)
        {
            object[] args = new object[] { "amount", 0.5f, "time", 0.25f, "easeType", iTween.EaseType.easeOutCubic };
            hashtable = iTween.Hash(args);
        }
        else
        {
            object[] objArray2 = new object[] { "amount", 1f, "time", 0.25f, "easeType", iTween.EaseType.easeOutCubic };
            hashtable = iTween.Hash(objArray2);
        }
        iTween.FadeTo(this.m_background, hashtable);
    }

    private CurrencyType GetCurrencyToShow()
    {
        SceneMgr.Mode mode = SceneMgr.Get().GetMode();
        switch (mode)
        {
            case SceneMgr.Mode.HUB:
            case SceneMgr.Mode.DRAFT:
                return CurrencyType.GOLD;

            case SceneMgr.Mode.COLLECTIONMANAGER:
                if ((CollectionManagerDisplay.Get() != null) && CollectionManagerDisplay.Get().IsShowingPackOpening())
                {
                    return CurrencyType.GOLD;
                }
                return CurrencyType.ARCANE_DUST;
        }
        return CurrencyType.NONE;
    }

    private void OnDustJarMouseOut(UIEvent e)
    {
        base.GetComponent<TooltipZone>().HideTooltip();
    }

    private void OnDustJarMouseOver(UIEvent e)
    {
        KeywordHelpPanel panel = base.GetComponent<TooltipZone>().ShowTooltip(GameStrings.Get("GLUE_CRAFTING_ARCANEDUST"), GameStrings.Get("GLUE_CRAFTING_ARCANEDUST_DESCRIPTION"), 0.7f);
        SceneUtils.SetLayer(panel.gameObject, GameLayer.BattleNet);
        panel.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        panel.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        panel.transform.localPosition = new Vector3(0f, 0f, -0.55f);
    }

    private void OnGoldBalanceChanged(NetCache.NetCacheGoldBalance balance)
    {
        if (this.m_showingCurrency == CurrencyType.GOLD)
        {
            this.SetAmount(balance.Balance);
        }
    }

    public void RefreshContents()
    {
        CurrencyType currencyToShow = this.GetCurrencyToShow();
        this.UpdateAmount(currencyToShow);
        this.Show(currencyToShow);
    }

    private void SetAmount(long amount)
    {
        this.m_amount.Text = amount.ToString();
    }

    private void Show(CurrencyType currencyType)
    {
        if (currencyType != CurrencyType.NONE)
        {
            if ((this.m_state == State.SHOWN) || (this.m_state == State.ANIMATE_IN))
            {
                this.ShowCurrencyType(currencyType);
            }
            else
            {
                this.m_state = State.ANIMATE_IN;
                base.gameObject.SetActive(true);
                object[] args = new object[] { "amount", 1f, "delay", 0f, "time", 0.25f, "easeType", iTween.EaseType.easeOutCubic, "oncomplete", "ActivateCurrencyFrame", "oncompletetarget", base.gameObject };
                Hashtable hashtable = iTween.Hash(args);
                iTween.FadeTo(base.gameObject, hashtable);
                this.ShowCurrencyType(currencyType);
            }
        }
        else if ((this.m_state == State.HIDDEN) || (this.m_state == State.ANIMATE_OUT))
        {
            this.ShowCurrencyType(currencyType);
        }
        else
        {
            this.m_state = State.ANIMATE_OUT;
            object[] objArray2 = new object[] { "amount", 0f, "delay", 0f, "time", 0.25f, "easeType", iTween.EaseType.easeOutCubic, "oncomplete", "DeactivateCurrencyFrame", "oncompletetarget", base.gameObject };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.FadeTo(base.gameObject, hashtable2);
            this.ShowCurrencyType(currencyType);
        }
    }

    private void ShowCurrencyType(CurrencyType currencyType)
    {
        if (this.m_showingCurrency != currencyType)
        {
            this.m_showingCurrency = currencyType;
            switch (this.m_showingCurrency)
            {
                case CurrencyType.GOLD:
                    iTween.FadeTo(this.m_dustJar.gameObject, 0f, 0.25f);
                    iTween.FadeTo(this.m_goldCoin.gameObject, 1f, 0.25f);
                    this.FadeBackground(false);
                    return;

                case CurrencyType.ARCANE_DUST:
                    iTween.FadeTo(this.m_dustJar.gameObject, 1f, 0.25f);
                    iTween.FadeTo(this.m_goldCoin.gameObject, 0f, 0.25f);
                    this.FadeBackground(true);
                    return;
            }
            iTween.FadeTo(this.m_dustJar.gameObject, 0f, 0.25f);
            iTween.FadeTo(this.m_goldCoin.gameObject, 0f, 0.25f);
        }
    }

    private void UpdateAmount(CurrencyType currencyType)
    {
        long amount = 0L;
        switch (currencyType)
        {
            case CurrencyType.GOLD:
                amount = NetCache.Get().GetNetObject<NetCache.NetCacheGoldBalance>().Balance;
                break;

            case CurrencyType.ARCANE_DUST:
                if (CraftingManager.Get() == null)
                {
                    Debug.LogWarning("CurrencyFrame.UpdateAmount(): cannot update currency amount for dust -- CraftingManager is null");
                    break;
                }
                amount = CraftingManager.Get().GetLocalArcaneDustBalance();
                break;
        }
        this.SetAmount(amount);
    }

    public enum CurrencyType
    {
        NONE,
        GOLD,
        ARCANE_DUST
    }

    public enum State
    {
        ANIMATE_IN,
        ANIMATE_OUT,
        HIDDEN,
        SHOWN
    }
}


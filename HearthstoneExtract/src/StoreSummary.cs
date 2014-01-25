using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StoreSummary : MonoBehaviour
{
    private static readonly Vector3 HIDDEN_SCALE = new Vector3(0.001f, 0.001f, 0.001f);
    private static readonly float HIDE_ANIM_TIME = 0.1f;
    private Network.Bundle m_bundle;
    public NormalButton m_cancelButton;
    private List<CancelListener> m_cancelListeners = new List<CancelListener>();
    public UberText m_chargeDetailsText;
    public NormalButton m_closeButton;
    public NormalButton m_confirmButton;
    private List<ConfirmListener> m_confirmListeners = new List<ConfirmListener>();
    public UberText m_headlineText;
    public UberText m_itemsHeadlineText;
    public UberText m_itemsText;
    public UberText m_priceHeadlineText;
    public UberText m_priceText;
    private int m_quantity;
    private bool m_shown = true;
    private bool m_staticTextResized;
    private Vector3 m_targetPos = Vector3.zero;
    private Vector3 m_targetScale = Vector3.one;
    public UberText m_taxDisclaimerText;
    private static readonly float SHOW_ANIM_TIME = 0.5f;

    private void Awake()
    {
        this.m_headlineText.Text = GameStrings.Get("GLUE_STORE_SUMMARY_HEADLINE");
        this.m_itemsHeadlineText.Text = GameStrings.Get("GLUE_STORE_SUMMARY_ITEMS_ORDERED_HEADLINE");
        this.m_priceHeadlineText.Text = GameStrings.Get("GLUE_STORE_SUMMARY_PRICE_HEADLINE");
        this.m_confirmButton.SetText(GameStrings.Get("GLUE_STORE_BUY_TEXT"));
        this.m_cancelButton.SetText(GameStrings.Get("GLOBAL_CANCEL"));
    }

    private string GetItemsText()
    {
        string str = StoreManager.Get().GetProductName(this.m_bundle.Product, this.m_bundle.ProductData, this.m_bundle.Quantity);
        object[] args = new object[] { this.m_quantity, str };
        return GameStrings.Format("GLUE_STORE_SUMMARY_ITEM_ORDERED", args);
    }

    private string GetPriceText()
    {
        double cost = this.m_bundle.Cost * this.m_quantity;
        return StoreManager.Get().FormatCostText(cost);
    }

    public void Hide()
    {
        this.Hide(false);
    }

    private void Hide(bool animate)
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            if (!animate)
            {
                this.OnHidden();
            }
            else
            {
                object[] args = new object[] { "scale", HIDDEN_SCALE, "isLocal", true, "time", HIDE_ANIM_TIME, "easetype", iTween.EaseType.linear, "name", "summaryScale", "oncomplete", "OnHidden", "oncompletetarget", base.gameObject };
                Hashtable hashtable = iTween.Hash(args);
                iTween.StopByName(base.gameObject, "summaryScale");
                iTween.ScaleTo(base.gameObject, hashtable);
            }
        }
    }

    public bool IsShown()
    {
        return this.m_shown;
    }

    private void OnCancelPressed(UIEvent e)
    {
        this.Hide(true);
        foreach (CancelListener listener in this.m_cancelListeners)
        {
            listener();
        }
    }

    private void OnConfirmPressed(UIEvent e)
    {
        this.Hide(true);
        foreach (ConfirmListener listener in this.m_confirmListeners)
        {
            listener(this.m_bundle.BundleType, this.m_quantity);
        }
    }

    private void OnHidden()
    {
        base.gameObject.SetActive(false);
        this.PositionOffScreen();
    }

    private void PositionOffScreen()
    {
        base.gameObject.transform.position = (Vector3) (Vector3.left * 1000f);
        base.gameObject.transform.localScale = this.m_targetScale;
        base.gameObject.SetActive(true);
    }

    private void PreRender()
    {
        this.m_itemsText.UpdateNow();
        this.m_priceText.UpdateNow();
        if (!this.m_staticTextResized)
        {
            this.m_headlineText.UpdateNow();
            this.m_itemsHeadlineText.UpdateNow();
            this.m_priceHeadlineText.UpdateNow();
            this.m_taxDisclaimerText.UpdateNow();
            this.m_staticTextResized = true;
        }
    }

    public void RegisterCancelListener(CancelListener listener)
    {
        if (!this.m_cancelListeners.Contains(listener))
        {
            this.m_cancelListeners.Add(listener);
        }
    }

    public void RegisterConfirmListener(ConfirmListener listener)
    {
        if (!this.m_confirmListeners.Contains(listener))
        {
            this.m_confirmListeners.Add(listener);
        }
    }

    public void RemoveConfirmListener(CancelListener listener)
    {
        this.m_cancelListeners.Remove(listener);
    }

    public void RemoveConfirmListener(ConfirmListener listener)
    {
        this.m_confirmListeners.Remove(listener);
    }

    private void SetDetails(int bundleType, int quantity, string paymenMethodName)
    {
        this.m_bundle = StoreManager.Get().GetBundle(bundleType);
        this.m_quantity = quantity;
        this.m_itemsText.Text = this.GetItemsText();
        this.m_priceText.Text = this.GetPriceText();
        this.m_taxDisclaimerText.Text = GameStrings.Get("GLUE_STORE_SUMMARY_TAX_DISCLAIMER");
        object[] args = new object[] { paymenMethodName };
        this.m_chargeDetailsText.Text = GameStrings.Format("GLUE_STORE_SUMMARY_CHARGE_DETAILS", args);
    }

    public void SetTargetPosAndScale(Vector3 targetPos, Vector3 targetScale)
    {
        this.m_targetPos = targetPos;
        this.m_targetScale = targetScale;
    }

    private void Show()
    {
        if (!this.m_shown)
        {
            this.PreRender();
            base.gameObject.transform.position = this.m_targetPos;
            this.m_shown = true;
            object[] args = new object[] { "scale", this.m_targetScale, "isLocal", false, "time", SHOW_ANIM_TIME, "easetype", iTween.EaseType.easeOutBounce, "name", "summaryScale" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(base.gameObject, "summaryScale");
            base.transform.localScale = HIDDEN_SCALE;
            iTween.ScaleTo(base.gameObject, hashtable);
        }
    }

    public void Show(int bundleType, int quantity, string paymentMethodName)
    {
        this.SetDetails(bundleType, quantity, paymentMethodName);
        this.Show();
    }

    private void Start()
    {
        this.m_confirmButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnConfirmPressed));
        this.m_cancelButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnCancelPressed));
        this.m_closeButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnCancelPressed));
    }

    public delegate void CancelListener();

    public delegate void ConfirmListener(int bundleType, int quantity);
}


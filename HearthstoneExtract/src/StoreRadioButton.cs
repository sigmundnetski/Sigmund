using System;
using UnityEngine;

public class StoreRadioButton : FramedRadioButton
{
    public GameObject m_bonusFrame;
    public UberText m_bonusText;
    public UberText m_cost;
    public UberText m_goldButtonText;
    public UberText m_goldCostText;
    public GameObject m_goldRoot;
    public GameObject m_realMoneyTextRoot;
    public SaleBanner m_saleBanner;
    private static readonly Color NO_SALE_TEXT_COLOR = new Color(0.239f, 0.184f, 0.098f);
    private static readonly Color ON_SALE_TEXT_COLOR = new Color(0.702f, 0.114f, 0.153f);

    public void ActivateSale(bool active)
    {
        this.m_saleBanner.m_root.SetActive(active);
        base.m_text.TextColor = !active ? NO_SALE_TEXT_COLOR : ON_SALE_TEXT_COLOR;
    }

    private void Awake()
    {
        this.ActivateSale(false);
    }

    public override void Init(FramedRadioButton.FrameType frameType, string text, int buttonID, object userData)
    {
        base.Init(frameType, text, buttonID, userData);
        Data data = userData as Data;
        if (data == null)
        {
            Debug.LogWarning(string.Format("StoreRadioButton.Init(): storeRadioButtonData is null (frameType={0}, text={1}, buttonID={2)", frameType, text, buttonID));
        }
        else if (data.m_bundle != null)
        {
            this.InitMoneyOption(data.m_bundle);
        }
        else if (data.m_goldPrice != null)
        {
            this.InitGoldOption(data.m_goldPrice);
        }
        else
        {
            Debug.LogWarning(string.Format("StoreRadioButton.Init(): storeRadioButtonData has neither gold price nor bundle data! (frameType={0}, text={1}, buttonID={2)", frameType, text, buttonID));
        }
    }

    private void InitGoldOption(Network.GoldPrice goldPrice)
    {
        this.m_goldRoot.SetActive(true);
        this.m_realMoneyTextRoot.SetActive(false);
        this.m_goldButtonText.Text = base.m_text.Text;
        this.m_goldCostText.Text = goldPrice.Cost.ToString();
    }

    private void InitMoneyOption(Network.Bundle bundle)
    {
        this.m_goldRoot.SetActive(false);
        this.m_realMoneyTextRoot.SetActive(true);
        Network.Bundle lowestCostBundle = StoreManager.Get().GetLowestCostBundle(bundle.Product);
        if (bundle != lowestCostBundle)
        {
            double num = lowestCostBundle.Cost / ((double) lowestCostBundle.Quantity);
            double num2 = bundle.Cost / num;
            int num3 = Mathf.FloorToInt((float) (bundle.Quantity - num2));
            if (num3 <= 0)
            {
                this.m_bonusFrame.SetActive(false);
            }
            else
            {
                this.m_bonusFrame.SetActive(true);
                this.m_bonusText.Text = string.Format(GameStrings.Get("GLUE_STORE_BONUS_PACKS"), num3);
            }
        }
        else
        {
            this.m_bonusFrame.SetActive(false);
        }
        this.m_cost.Text = string.Format(GameStrings.Get("GLUE_STORE_PRODUCT_PRICE"), StoreManager.Get().FormatCostText(bundle.Cost));
    }

    public class Data
    {
        public Network.Bundle m_bundle;
        public Network.GoldPrice m_goldPrice;
    }
}


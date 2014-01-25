using System;
using UnityEngine;

[Serializable]
public class DisenchantBar
{
    private int m_amount;
    public GameObject m_amountBar;
    public UberText m_amountText;
    private int m_numCards;
    public UberText m_numCardsText;
    public CardFlair.PremiumType m_premiumType;
    public TAG_RARITY m_rarity;
    public UberText m_typeText;

    public void AddCards(int count, int sellAmount)
    {
        this.m_numCards += count;
        this.m_amount += sellAmount;
    }

    public void Init()
    {
        string rarityText = GameStrings.GetRarityText(this.m_rarity);
        this.m_typeText.Text = (this.m_premiumType != CardFlair.PremiumType.FOIL) ? rarityText : GameStrings.Format("GLUE_MASS_DISENCHANT_PREMIUM_TITLE", new object[] { rarityText });
    }

    public void Reset()
    {
        this.m_numCards = 0;
        this.m_amount = 0;
    }

    public void UpdateVisuals(int totalNumCards)
    {
        this.m_numCardsText.Text = this.m_numCards.ToString();
        this.m_amountText.Text = this.m_amount.ToString();
        float num = ((float) this.m_numCards) / ((float) totalNumCards);
        this.m_amountBar.renderer.material.SetFloat("_Percent", num);
    }
}


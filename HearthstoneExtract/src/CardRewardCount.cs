using System;
using UnityEngine;

public class CardRewardCount : MonoBehaviour
{
    public UberText m_countText;
    public UberText m_multiplierText;

    private void Awake()
    {
        this.m_multiplierText.Text = GameStrings.Get("GLOBAL_REWARD_CARD_COUNT_MULTIPLIER");
    }

    public void Hide()
    {
        base.gameObject.SetActive(false);
    }

    public void SetCount(int count)
    {
        this.m_countText.Text = count.ToString();
    }

    public void Show()
    {
        base.gameObject.SetActive(true);
    }
}


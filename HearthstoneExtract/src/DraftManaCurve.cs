using System;
using System.Collections.Generic;
using UnityEngine;

public class DraftManaCurve : MonoBehaviour
{
    public List<ManaCostBar> m_bars;
    private List<int> m_manaCosts;
    private const int MAX_CARDS = 10;
    private const float SIZE_PER_CARD = 0.1f;

    public void AddCardOfCost(int cost)
    {
        List<int> list;
        int num;
        cost = Mathf.Clamp(cost, 0, 7);
        num = list[num];
        (list = this.m_manaCosts)[num = cost] = num + 1;
        this.UpdateBars();
    }

    private void Awake()
    {
        this.ResetBars();
    }

    public void ResetBars()
    {
        this.m_manaCosts = new List<int>();
        for (int i = 0; i < this.m_bars.Count; i++)
        {
            this.m_manaCosts.Add(0);
        }
        this.UpdateBars();
    }

    public void UpdateBars()
    {
        int num = 0;
        foreach (int num2 in this.m_manaCosts)
        {
            if (num2 > num)
            {
                num = num2;
            }
        }
        if (num < 10)
        {
            num = 10;
        }
        for (int i = 0; i < this.m_bars.Count; i++)
        {
            this.m_bars[i].m_maxValue = num;
            this.m_bars[i].AnimateBar((float) this.m_manaCosts[i]);
        }
    }
}


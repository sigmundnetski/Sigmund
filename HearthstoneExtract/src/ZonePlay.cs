using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ZonePlay : Zone
{
    private List<Vector3> m_currentSlotPositions = new List<Vector3>();
    public int m_MaxSlots = 7;
    public float m_slotWidth;
    public int slotMousedOver = -1;
    public bool visuallyActivated;

    private void Awake()
    {
        this.m_slotWidth = base.collider.bounds.size.x / ((float) this.m_MaxSlots);
    }

    public override bool CanAcceptTags(int controllerId, TAG_ZONE zoneTag, TAG_CARDTYPE cardType)
    {
        if (!base.CanAcceptTags(controllerId, zoneTag, cardType))
        {
            return false;
        }
        return ((cardType == TAG_CARDTYPE.MINION) || (cardType == TAG_CARDTYPE.ENCHANTMENT));
    }

    protected bool CanAnimateCard(Card card)
    {
        if (card.IsDoNotSort())
        {
            return false;
        }
        return true;
    }

    public bool GetPositionForSlot(int slot, out Vector3 position)
    {
        position = Vector3.zero;
        if ((slot < 0) || (slot >= this.m_currentSlotPositions.Count))
        {
            return false;
        }
        position = this.m_currentSlotPositions[slot];
        return true;
    }

    public void HighlightBattlefield()
    {
        this.visuallyActivated = true;
    }

    public void SortWithSpotForHeldCard(int slot)
    {
        this.slotMousedOver = slot;
        this.UpdateLayout();
    }

    public void UnHighlightBattlefield()
    {
        this.visuallyActivated = false;
    }

    public override void UpdateLayout()
    {
        if ((InputManager.Get() != null) && (InputManager.Get().heldObject == null))
        {
            this.slotMousedOver = -1;
        }
        base.m_updatingLayout = true;
        int num = 0;
        base.m_cards.Sort(new Comparison<Card>(this.CardSortComparison));
        Vector3 center = base.collider.bounds.center;
        int count = base.m_cards.Count;
        if (this.slotMousedOver >= 0)
        {
            count++;
        }
        float num3 = (count * this.m_slotWidth) * 0.5f;
        float num4 = this.m_slotWidth * 0.5f;
        float x = (center.x - num3) + num4;
        this.m_currentSlotPositions.Clear();
        for (int i = 0; i < base.m_cards.Count; i++)
        {
            Card card = base.m_cards[i];
            if (i == this.slotMousedOver)
            {
                x += this.m_slotWidth;
            }
            Vector3 item = new Vector3(x, center.y, center.z);
            this.m_currentSlotPositions.Add(item);
            if (!this.CanAnimateCard(card))
            {
                x += this.m_slotWidth;
            }
            else
            {
                num++;
                card.EnableTransitioningZones(true);
                iTween.MoveTo(card.gameObject, item, 1f);
                iTween.RotateTo(card.gameObject, base.transform.eulerAngles, 1f);
                iTween.ScaleTo(card.gameObject, base.transform.localScale, 1f);
                x += this.m_slotWidth;
            }
        }
        if (num > 0)
        {
            base.StartFinishLayoutTimer(1f);
        }
        else
        {
            base.UpdateLayoutFinished();
        }
    }
}


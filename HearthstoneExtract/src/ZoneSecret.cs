using System;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSecret : Zone
{
    private const float LAYOUT_ANIM_SEC = 1f;
    private List<Card> m_newCards = new List<Card>();
    private const float MAX_LAYOUT_PYRAMID_LEVEL = 2f;

    public override bool AddCard(Card card)
    {
        bool flag = base.AddCard(card);
        if (flag)
        {
            this.m_newCards.Add(card);
        }
        return flag;
    }

    private void Awake()
    {
    }

    public override bool InsertCard(int index, Card card)
    {
        bool flag = base.InsertCard(index, card);
        if (flag)
        {
            this.m_newCards.Add(card);
        }
        return flag;
    }

    private void PlaySecretBirth(Card card)
    {
        Actor actor = card.GetActor();
        Spell component = actor.GetComponent<Spell>();
        if (component == null)
        {
            Log.Mike.Print(string.Format("{0}.PlaySecretBirth() - actor {1} for card {2} has no Spell component", this, actor, card));
        }
        else
        {
            component.ActivateState(SpellStateType.BIRTH);
        }
    }

    public override int RemoveCard(Card card)
    {
        int num = base.RemoveCard(card);
        if (num >= 0)
        {
            this.m_newCards.Remove(card);
        }
        return num;
    }

    public override void UpdateLayout()
    {
        base.m_updatingLayout = true;
        Vector2 vector = new Vector2(1f, 2f);
        if (base.m_player != null)
        {
            Card heroCard = base.m_player.GetHeroCard();
            if (heroCard != null)
            {
                Bounds bounds = heroCard.GetActor().GetMeshRenderer().bounds;
                vector.x = bounds.extents.x;
                vector.y = bounds.extents.z * 0.9f;
            }
        }
        float num = 0.6f * vector.y;
        for (int i = 0; i < base.m_cards.Count; i++)
        {
            float num5;
            Card item = base.m_cards[i];
            item.ShowCard();
            Vector3 position = base.transform.position;
            float objA = (i + 1) >> 1;
            int num4 = i & 1;
            if (objA > 2f)
            {
                num5 = 1f;
            }
            else if (object.Equals(objA, 1f))
            {
                num5 = 0.6f;
            }
            else
            {
                num5 = objA / 2f;
            }
            if (num4 == 0)
            {
                position.x += vector.x * num5;
            }
            else
            {
                position.x -= vector.x * num5;
            }
            position.z -= vector.y * (num5 * num5);
            if (objA > 2f)
            {
                position.z -= num * (objA - 2f);
            }
            item.EnableTransitioningZones(true);
            if (this.m_newCards.Contains(item))
            {
                item.transform.position = position;
                iTween.Stop(item.gameObject);
            }
            else
            {
                iTween.MoveTo(item.gameObject, position, 1f);
            }
            iTween.RotateTo(item.gameObject, base.transform.localEulerAngles, 1f);
            iTween.ScaleTo(item.gameObject, base.transform.localScale, 1f);
        }
        foreach (Card card3 in this.m_newCards)
        {
            this.PlaySecretBirth(card3);
        }
        this.m_newCards.Clear();
        base.StartFinishLayoutTimer(1f);
    }
}


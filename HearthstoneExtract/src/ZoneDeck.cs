using System;
using UnityEngine;

public class ZoneDeck : Zone
{
    private Spell m_deckFatigueGlow;
    private GameObject m_thickness1;
    private GameObject m_thickness25;
    private GameObject m_thickness50;
    private GameObject m_thickness75;
    private GameObject m_thicknessFull;
    private bool m_warnedAboutLastCard;
    private bool m_warnedAboutNoCards;
    private const int MAX_THICKNESS_CARD_COUNT = 0x1a;
    private bool wasFatigued;

    private void Awake()
    {
        this.m_thicknessFull = SceneUtils.FindChildBySubstring(base.gameObject, "Deck_Full");
        this.m_thickness75 = SceneUtils.FindChildBySubstring(base.gameObject, "Deck_75");
        this.m_thickness50 = SceneUtils.FindChildBySubstring(base.gameObject, "Deck_50");
        this.m_thickness25 = SceneUtils.FindChildBySubstring(base.gameObject, "Deck_25");
        this.m_thickness1 = SceneUtils.FindChildBySubstring(base.gameObject, "Deck_1");
        GameObject obj2 = SceneUtils.FindChildBySubstring(base.gameObject, "Fatigue_DeckGlow");
        if (obj2 != null)
        {
            this.m_deckFatigueGlow = obj2.GetComponent<Spell>();
        }
    }

    public void DoFatigueGlow()
    {
        if (this.m_deckFatigueGlow != null)
        {
            this.m_deckFatigueGlow.ActivateState(SpellStateType.ACTION);
        }
    }

    public bool IsFatigued()
    {
        return (base.m_cards.Count == 0);
    }

    private void PlayDeckStateEmotes()
    {
        int count = base.m_cards.Count;
        if ((count <= 0) && !this.m_warnedAboutNoCards)
        {
            this.m_warnedAboutNoCards = true;
            this.m_warnedAboutLastCard = true;
            base.GetPlayer().GetHeroCard().PlayEmote(EmoteType.NO_CARDS);
        }
        else if ((count == 1) && !this.m_warnedAboutLastCard)
        {
            this.m_warnedAboutLastCard = true;
            base.GetPlayer().GetHeroCard().PlayEmote(EmoteType.LOW_CARDS);
        }
    }

    public void SetCardToInDeckState(Card card)
    {
        card.transform.localEulerAngles = new Vector3(270f, 270f, 0f);
        card.transform.position = base.transform.position;
        card.transform.localScale = new Vector3(0.88f, 0.88f, 0.88f);
        card.EnableTransitioningZones(false);
    }

    public override void UpdateLayout()
    {
        this.UpdateThickness();
        this.PlayDeckStateEmotes();
        for (int i = 0; i < base.m_cards.Count; i++)
        {
            Card card = base.m_cards[i];
            if (!card.IsDoNotSort())
            {
                card.HideCard();
                this.SetCardToInDeckState(card);
            }
        }
        base.UpdateLayoutFinished();
    }

    private void UpdateThickness()
    {
        this.m_thicknessFull.renderer.enabled = false;
        this.m_thickness75.renderer.enabled = false;
        this.m_thickness50.renderer.enabled = false;
        this.m_thickness25.renderer.enabled = false;
        this.m_thickness1.renderer.enabled = false;
        int count = base.m_cards.Count;
        switch (count)
        {
            case 1:
                this.m_thickness1.renderer.enabled = true;
                return;

            case 0:
                if (this.m_deckFatigueGlow != null)
                {
                    this.m_deckFatigueGlow.ActivateState(SpellStateType.BIRTH);
                    this.wasFatigued = true;
                }
                return;
        }
        if (this.wasFatigued && (this.m_deckFatigueGlow != null))
        {
            this.m_deckFatigueGlow.ActivateState(SpellStateType.DEATH);
            this.wasFatigued = false;
        }
        float num2 = ((float) count) / 26f;
        if (num2 > 0.75f)
        {
            this.m_thicknessFull.renderer.enabled = true;
        }
        else if (num2 > 0.5f)
        {
            this.m_thickness75.renderer.enabled = true;
        }
        else if (num2 > 0.25f)
        {
            this.m_thickness50.renderer.enabled = true;
        }
        else if (num2 > 0f)
        {
            this.m_thickness25.renderer.enabled = true;
        }
    }
}


using System;

public class ZoneGraveyard : Zone
{
    public override bool CanAcceptTags(int controllerId, TAG_ZONE zoneTag, TAG_CARDTYPE cardType)
    {
        if (!base.CanAcceptTags(controllerId, zoneTag, cardType))
        {
            return false;
        }
        return ((cardType == TAG_CARDTYPE.MINION) || ((cardType == TAG_CARDTYPE.WEAPON) || ((cardType == TAG_CARDTYPE.ABILITY) || (cardType == TAG_CARDTYPE.HERO))));
    }

    public override void UpdateLayout()
    {
        for (int i = 0; i < base.m_cards.Count; i++)
        {
            Card card = base.m_cards[i];
            if (!card.IsDoNotSort())
            {
                card.HideCard();
                card.EnableTransitioningZones(false);
            }
        }
        base.UpdateLayoutFinished();
    }
}


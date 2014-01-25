using System;

public class HiddenCard : CardDef
{
    public override string DetermineActorNameForZone(Entity entity, TAG_ZONE zoneTag)
    {
        if (((zoneTag == TAG_ZONE.DECK) || (zoneTag == TAG_ZONE.GRAVEYARD)) || ((zoneTag == TAG_ZONE.REMOVEDFROMGAME) || (zoneTag == TAG_ZONE.SETASIDE)))
        {
            return "Card_Invisible";
        }
        if (zoneTag == TAG_ZONE.SECRET)
        {
            return base.DetermineActorNameForZone(entity, zoneTag);
        }
        return "Card_Hidden";
    }
}


using System;

public class ZoneHero : Zone
{
    public override bool CanAcceptTags(int controllerId, TAG_ZONE zoneTag, TAG_CARDTYPE cardType)
    {
        if (!base.CanAcceptTags(controllerId, zoneTag, cardType))
        {
            return false;
        }
        if (cardType != TAG_CARDTYPE.HERO)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return string.Format("{0} (Hero)", base.ToString());
    }
}


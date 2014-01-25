using System;

public class ZoneHeroPower : Zone
{
    private void Awake()
    {
    }

    public override bool CanAcceptTags(int controllerId, TAG_ZONE zoneTag, TAG_CARDTYPE cardType)
    {
        if (!base.CanAcceptTags(controllerId, zoneTag, cardType))
        {
            return false;
        }
        if (cardType != TAG_CARDTYPE.HERO_POWER)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return string.Format("{0} (Hero Power)", base.ToString());
    }
}


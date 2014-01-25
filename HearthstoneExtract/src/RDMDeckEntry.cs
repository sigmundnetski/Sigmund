using System;

public class RDMDeckEntry
{
    private CardFlair m_cardFlair;
    private EntityDef m_entityDef;

    public RDMDeckEntry(EntityDef entityDef, CardFlair cardFlair)
    {
        this.m_entityDef = entityDef;
        this.m_cardFlair = cardFlair;
    }

    public EntityDef EntityDef
    {
        get
        {
            return this.m_entityDef;
        }
    }

    public CardFlair Flair
    {
        get
        {
            return this.m_cardFlair;
        }
    }
}


using System;

public class FullDef
{
    private CardDef m_cardDef;
    private EntityDef m_entityDef;

    public CardDef GetCardDef()
    {
        return this.m_cardDef;
    }

    public EntityDef GetEntityDef()
    {
        return this.m_entityDef;
    }

    public bool IsEmpty()
    {
        if (this.m_entityDef != null)
        {
            return false;
        }
        if (this.m_cardDef != null)
        {
            return false;
        }
        return true;
    }

    public void SetCardDef(CardDef cardDef)
    {
        this.m_cardDef = cardDef;
    }

    public void SetEntityDef(EntityDef entityDef)
    {
        this.m_entityDef = entityDef;
    }
}


using System;

public class CollectionDeckViolation
{
    private long m_deckId;
    private CollectionDeckViolationType m_type;

    public long DeckID
    {
        get
        {
            return this.m_deckId;
        }
        set
        {
            this.m_deckId = value;
        }
    }

    public CollectionDeckViolationType ViolationType
    {
        get
        {
            return this.m_type;
        }
        set
        {
            this.m_type = value;
        }
    }
}


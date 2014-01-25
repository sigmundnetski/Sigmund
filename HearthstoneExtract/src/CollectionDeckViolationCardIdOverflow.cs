using System;

public class CollectionDeckViolationCardIdOverflow : CollectionDeckViolation
{
    private string m_cardId;
    private int m_count;

    public string CardID
    {
        get
        {
            return this.m_cardId;
        }
        set
        {
            this.m_cardId = value;
        }
    }

    public int Count
    {
        get
        {
            return this.m_count;
        }
        set
        {
            this.m_count = value;
        }
    }
}


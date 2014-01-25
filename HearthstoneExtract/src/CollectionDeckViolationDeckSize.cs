using System;

public class CollectionDeckViolationDeckSize : CollectionDeckViolation
{
    private int m_totalCardCount;

    public int TotalCardCount
    {
        get
        {
            return this.m_totalCardCount;
        }
        set
        {
            this.m_totalCardCount = value;
        }
    }
}


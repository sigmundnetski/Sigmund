using System;
using System.Runtime.CompilerServices;

public class CollectionDeckSlot
{
    private string m_cardId;
    private int m_count;
    private int m_handle;
    private int m_index;
    private CardFlair.PremiumType m_premium;
    private int m_prevSlotHandle;
    public DelOnSlotEmptied OnSlotEmptied;

    public bool ContentsDiffer(CollectionDeckSlot otherSlot)
    {
        return (!this.CardID.Equals(otherSlot.CardID) || ((this.Count != otherSlot.Count) || (this.Premium != otherSlot.Premium)));
    }

    public void CopyFrom(CollectionDeckSlot otherSlot)
    {
        this.Handle = otherSlot.Handle;
        this.Index = otherSlot.Index;
        this.PrevSlotHandle = otherSlot.PrevSlotHandle;
        this.Count = otherSlot.Count;
        this.CardID = otherSlot.CardID;
        this.Premium = otherSlot.Premium;
    }

    public override string ToString()
    {
        object[] args = new object[] { this.Handle, this.Index, this.PrevSlotHandle, this.Premium, this.Count, this.CardID };
        return string.Format("[CollectionDeckSlot: Handle={0}, Index={1}, PrevSlotHandle={2}, Premium={3}, Count={4}, CardID={5}]", args);
    }

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
            if ((this.m_count <= 0) && (this.OnSlotEmptied != null))
            {
                this.OnSlotEmptied(this);
            }
        }
    }

    public int Handle
    {
        get
        {
            return this.m_handle;
        }
        set
        {
            this.m_handle = value;
        }
    }

    public int Index
    {
        get
        {
            return this.m_index;
        }
        set
        {
            this.m_index = value;
        }
    }

    public CardFlair.PremiumType Premium
    {
        get
        {
            return this.m_premium;
        }
        set
        {
            this.m_premium = value;
        }
    }

    public int PrevSlotHandle
    {
        get
        {
            return this.m_prevSlotHandle;
        }
        set
        {
            this.m_prevSlotHandle = value;
        }
    }

    public delegate void DelOnSlotEmptied(CollectionDeckSlot slot);
}


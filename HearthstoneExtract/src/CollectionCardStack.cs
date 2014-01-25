using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectionCardStack
{
    private Dictionary<CardFlair, ArtStack> m_artStacks = new Dictionary<CardFlair, ArtStack>();
    private string m_cardID = string.Empty;

    public CollectionCardStack(string cardID)
    {
        this.m_cardID = cardID;
    }

    public ArtStack AddCards(CardFlair cardFlair, DateTime newestInsertDate, int count, int numSeen)
    {
        ArtStack artStack;
        if (this.ContainsArtStack(cardFlair))
        {
            artStack = this.GetArtStack(cardFlair);
            artStack.AddCards(newestInsertDate, count, numSeen);
            return artStack;
        }
        artStack = new ArtStack(this.CardID, cardFlair, newestInsertDate, count, numSeen);
        this.m_artStacks.Add(cardFlair, artStack);
        return artStack;
    }

    public bool ContainsArtStack(CardFlair cardFlair)
    {
        return this.m_artStacks.ContainsKey(cardFlair);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is CollectionCardStack))
        {
            return false;
        }
        CollectionCardStack stack = obj as CollectionCardStack;
        return this.CardID.Equals(stack.CardID);
    }

    public ArtStack GetArtStack(CardFlair cardFlair)
    {
        ArtStack stack;
        if (this.m_artStacks.TryGetValue(cardFlair, out stack))
        {
            return stack;
        }
        return new ArtStack(this.CardID, cardFlair, new DateTime(), 0, 0);
    }

    public Dictionary<CardFlair, ArtStack> GetArtStacks()
    {
        return this.m_artStacks;
    }

    public override int GetHashCode()
    {
        return this.CardID.GetHashCode();
    }

    public DateTime GetNewestInsertDate()
    {
        DateTime newestInsertDate = new DateTime();
        if (this.m_artStacks.Count == 0)
        {
            Debug.LogWarning("CollectionCardStack.GetNewestInsertDate(): getting newest insert date on an empty stack!!!");
        }
        foreach (ArtStack stack in this.m_artStacks.Values)
        {
            if (stack.NewestInsertDate > newestInsertDate)
            {
                newestInsertDate = stack.NewestInsertDate;
            }
        }
        return newestInsertDate;
    }

    public int GetTotalCount()
    {
        int num = 0;
        foreach (ArtStack stack in this.m_artStacks.Values)
        {
            num += stack.Count;
        }
        return num;
    }

    public int GetTotalNumSeen()
    {
        int num = 0;
        foreach (ArtStack stack in this.m_artStacks.Values)
        {
            num += stack.NumSeen;
        }
        return num;
    }

    public ArtStack RemoveCards(CardFlair cardFlair, int count)
    {
        ArtStack artStack = this.GetArtStack(cardFlair);
        if (artStack == null)
        {
            Debug.LogWarning(string.Format("CollectionCardStack.RemoveCards() - cannot remove {0} copies of {1} with card flair {2} - art stack does not exist.", count, this.CardID, cardFlair));
            return artStack;
        }
        artStack.RemoveCards(count);
        if (artStack.Count == 0)
        {
            this.m_artStacks.Remove(cardFlair);
            artStack = new ArtStack(this.CardID, cardFlair, new DateTime(), 0, 0);
        }
        return artStack;
    }

    public string CardID
    {
        get
        {
            return this.m_cardID;
        }
    }

    public class ArtStack
    {
        private CardFlair m_cardFlair;
        private string m_cardID;
        private int m_count;
        private DateTime m_newestInsertDate;
        private int m_numSeen;

        public ArtStack(string cardID, CardFlair cardFlair, DateTime newestInsertDate, int count, int numSeen)
        {
            this.m_cardID = cardID;
            this.m_cardFlair = cardFlair;
            this.m_newestInsertDate = newestInsertDate;
            this.m_count = count;
            this.m_numSeen = numSeen;
        }

        public void AddCards(DateTime newestInsertDate, int count, int numSeen)
        {
            if (newestInsertDate > this.NewestInsertDate)
            {
                this.m_newestInsertDate = newestInsertDate;
            }
            this.m_count += count;
            this.m_numSeen += numSeen;
        }

        public CollectionCardStack.ArtStack Clone()
        {
            return new CollectionCardStack.ArtStack(this.CardID, this.Flair, this.NewestInsertDate, this.Count, this.NumSeen);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is CollectionCardStack.ArtStack))
            {
                throw new ArgumentException("Object is not an ArtStack.");
            }
            CollectionCardStack.ArtStack stack = obj as CollectionCardStack.ArtStack;
            EntityDef entityDef = DefLoader.Get().GetEntityDef(this.CardID);
            EntityDef def2 = DefLoader.Get().GetEntityDef(stack.CardID);
            if (!entityDef.Equals(def2))
            {
                return entityDef.CompareTo(def2);
            }
            if (!this.Flair.Equals(stack.Flair))
            {
                return this.Flair.CompareTo(stack.Flair);
            }
            if (!this.NewestInsertDate.Equals(stack.NewestInsertDate))
            {
                return this.NewestInsertDate.CompareTo(stack.NewestInsertDate);
            }
            if (this.Count != stack.Count)
            {
                return (this.Count - stack.Count);
            }
            return (this.NumSeen - stack.NumSeen);
        }

        public void MarkStackAsSeen()
        {
            this.m_numSeen = this.Count;
        }

        public bool MergeWithArtStack(CollectionCardStack.ArtStack other)
        {
            if (!this.CardID.Equals(other.CardID))
            {
                return false;
            }
            if (!this.Flair.Equals(other.Flair))
            {
                return false;
            }
            this.m_count += other.Count;
            this.m_numSeen += other.NumSeen;
            if (this.NewestInsertDate < other.NewestInsertDate)
            {
                this.m_newestInsertDate = other.NewestInsertDate;
            }
            return true;
        }

        public void RemoveCards(int count)
        {
            if (count > this.Count)
            {
                Debug.LogWarning(string.Format("CollectionCardStack.ArtStack.RemoveCards() - cannot remove {0} cards from stack {1}; emptying stack.", count, this));
                count = this.Count;
            }
            this.m_count -= count;
            this.m_numSeen = Math.Max(0, this.NumSeen - count);
        }

        public override string ToString()
        {
            object[] args = new object[] { this.CardID, this.Flair, this.NewestInsertDate, this.Count, this.NumSeen };
            return string.Format("[SubStack: CardID={0}, Flair={1}, NewestInsertDate={2}, Count={3}, NumSeen={4}]", args);
        }

        public string CardID
        {
            get
            {
                return this.m_cardID;
            }
        }

        public int Count
        {
            get
            {
                return this.m_count;
            }
        }

        public CardFlair Flair
        {
            get
            {
                return this.m_cardFlair;
            }
        }

        public DateTime NewestInsertDate
        {
            get
            {
                return this.m_newestInsertDate;
            }
        }

        public int NumSeen
        {
            get
            {
                return this.m_numSeen;
            }
        }
    }
}


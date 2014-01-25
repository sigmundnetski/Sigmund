using System;

public class FilteredArtStack : IComparable
{
    private CollectionCardStack.ArtStack m_artStack;

    public FilteredArtStack(CollectionCardStack.ArtStack artStack)
    {
        this.m_artStack = artStack.Clone();
    }

    public FilteredArtStack Clone()
    {
        return new FilteredArtStack(this.m_artStack);
    }

    public int CompareTo(object obj)
    {
        if (!(obj is FilteredArtStack))
        {
            throw new ArgumentException("CollectionFilteredArtStack.CompareTo(): obj is not a CollectionFilteredArtStack");
        }
        FilteredArtStack stack = obj as FilteredArtStack;
        return this.m_artStack.CompareTo(stack.m_artStack);
    }

    public NetCache.CardDefinition GetCardDefinition()
    {
        return new NetCache.CardDefinition { Name = this.CardID, Premium = this.Flair.Premium };
    }

    public bool MergeWithArtStack(FilteredArtStack other)
    {
        return this.m_artStack.MergeWithArtStack(other.m_artStack);
    }

    public override string ToString()
    {
        return string.Format("[FilteredArtStack: CardID={0}, Flair={1}, Count={2}]", this.CardID, this.Flair, this.Count);
    }

    public string CardID
    {
        get
        {
            return this.m_artStack.CardID;
        }
    }

    public int Count
    {
        get
        {
            return this.m_artStack.Count;
        }
    }

    public CardFlair Flair
    {
        get
        {
            return this.m_artStack.Flair;
        }
    }
}


using System;

public class CardFlair
{
    public const PremiumType DEFAULT_PREMIUM_TYPE = PremiumType.STANDARD;
    private PremiumType m_premium;

    public CardFlair(PremiumType premium)
    {
        this.Premium = premium;
    }

    public int CompareTo(object obj)
    {
        if (!(obj is CardFlair))
        {
            throw new ArgumentException("CardFlair.CompareTo(): obj is not a CardFlair");
        }
        CardFlair flair = obj as CardFlair;
        return (int) (this.Premium - flair.Premium);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is CardFlair))
        {
            return false;
        }
        CardFlair flair = obj as CardFlair;
        return (this.Premium == flair.Premium);
    }

    public override int GetHashCode()
    {
        int num = 0x17;
        return ((num * 13) + this.Premium.GetHashCode());
    }

    public static PremiumType GetPremiumType(CardFlair flair)
    {
        if (flair == null)
        {
            return PremiumType.STANDARD;
        }
        return flair.Premium;
    }

    public override string ToString()
    {
        return string.Format("[CardFlair: Premium={0}]", this.Premium);
    }

    public PremiumType Premium
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

    public enum PremiumType
    {
        STANDARD,
        FOIL
    }
}


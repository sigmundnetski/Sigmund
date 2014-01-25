using System;
using System.Runtime.CompilerServices;

public class CardRewardData : RewardData
{
    public CardRewardData() : this(string.Empty, CardFlair.PremiumType.STANDARD, 0)
    {
    }

    public CardRewardData(string cardID, CardFlair.PremiumType premium, int count) : base(Reward.Type.CARD)
    {
        this.CardID = cardID;
        this.Count = count;
        this.Premium = premium;
        this.InnKeeperLine = InnKeeperTrigger.NONE;
    }

    protected override string GetGameObjectName()
    {
        return "CardReward";
    }

    public bool Merge(CardRewardData other)
    {
        if (!this.CardID.Equals(other.CardID))
        {
            return false;
        }
        if (!this.Premium.Equals(other.Premium))
        {
            return false;
        }
        this.Count += other.Count;
        foreach (long num in other.m_noticeIDs)
        {
            base.AddNoticeID(num);
        }
        return true;
    }

    public override string ToString()
    {
        object[] args = new object[] { this.CardID, this.Premium, this.Count, base.Origin, base.OriginData };
        return string.Format("[CardRewardData: CardID={0}, Premium={1} Count={2} Origin={3} OriginData={4}]", args);
    }

    public string CardID { get; set; }

    public int Count { get; set; }

    public InnKeeperTrigger InnKeeperLine { get; set; }

    public CardFlair.PremiumType Premium { get; set; }

    public enum InnKeeperTrigger
    {
        NONE,
        CORE_CLASS_SET_COMPLETE,
        SECOND_REWARD_EVER
    }
}


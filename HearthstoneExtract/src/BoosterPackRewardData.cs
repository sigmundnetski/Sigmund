using System;
using System.Runtime.CompilerServices;

public class BoosterPackRewardData : RewardData
{
    public BoosterPackRewardData() : this(BoosterType.UNKNOWN, 0)
    {
    }

    public BoosterPackRewardData(BoosterType boosterType, int boosterCount) : base(Reward.Type.BOOSTER_PACK)
    {
        this.BoosterType = boosterType;
        this.Count = boosterCount;
    }

    protected override string GetGameObjectName()
    {
        return "BoosterPackReward";
    }

    public override string ToString()
    {
        object[] args = new object[] { this.BoosterType, this.Count, base.Origin, base.OriginData };
        return string.Format("[BoosterPackRewardData: BoosterType={0} Count={1} Origin={2} OriginData={3}]", args);
    }

    public BoosterType BoosterType { get; set; }

    public int Count { get; set; }
}


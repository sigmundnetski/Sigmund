using System;
using System.Runtime.CompilerServices;

public class ArcaneDustRewardData : RewardData
{
    public ArcaneDustRewardData() : this(0)
    {
    }

    public ArcaneDustRewardData(int amount) : base(Reward.Type.ARCANE_DUST)
    {
        this.Amount = amount;
    }

    protected override string GetGameObjectName()
    {
        return "ArcaneDustReward";
    }

    public override string ToString()
    {
        return string.Format("[ArcaneDustRewardData: Amount={0} Origin={1} OriginData={2}]", this.Amount, base.Origin, base.OriginData);
    }

    public int Amount { get; set; }
}


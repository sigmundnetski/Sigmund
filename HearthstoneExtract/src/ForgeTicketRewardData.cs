using System;
using System.Runtime.CompilerServices;

public class ForgeTicketRewardData : RewardData
{
    public ForgeTicketRewardData() : this(0)
    {
    }

    public ForgeTicketRewardData(int quantity) : base(Reward.Type.FORGE_TICKET)
    {
        this.Quantity = quantity;
    }

    protected override string GetGameObjectName()
    {
        return string.Empty;
    }

    public override string ToString()
    {
        return string.Format("[ForgeTicketRewardData: Quantity={0} Origin={1} OriginData={2}]", this.Quantity, base.Origin, base.OriginData);
    }

    public int Quantity { get; set; }
}


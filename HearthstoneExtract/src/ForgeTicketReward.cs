using System;

public class ForgeTicketReward : Reward
{
    protected override void InitData()
    {
        base.SetData(new ForgeTicketRewardData(), false);
    }
}


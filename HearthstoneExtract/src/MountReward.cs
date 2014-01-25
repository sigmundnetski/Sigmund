using System;

public class MountReward : Reward
{
    protected override void InitData()
    {
        base.SetData(new ForgeTicketRewardData(), false);
    }
}


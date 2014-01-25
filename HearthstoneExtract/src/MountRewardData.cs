using System;
using System.Runtime.CompilerServices;

public class MountRewardData : RewardData
{
    public MountRewardData() : this(MountType.UNKNOWN)
    {
    }

    public MountRewardData(MountType mount) : base(Reward.Type.MOUNT)
    {
        this.Mount = mount;
    }

    protected override string GetGameObjectName()
    {
        return string.Empty;
    }

    public override string ToString()
    {
        return string.Format("[MountRewardData Mount={0} Origin={1} OriginData={2}]", this.Mount, base.Origin, base.OriginData);
    }

    public MountType Mount { get; set; }

    public enum MountType
    {
        UNKNOWN,
        HEARTHSTEED
    }
}


using PegasusShared;

public class BnetGameAccountId : BnetEntityId
{
    public BnetGameAccountId Clone()
    {
        BnetGameAccountId id = new BnetGameAccountId();
        id.CopyFrom(this);
        return id;
    }

    public static BnetGameAccountId CreateFromDll(BattleNet.DllEntityId src)
    {
        BnetGameAccountId id = new BnetGameAccountId();
        id.CopyFrom(src);
        return id;
    }

    public static BnetGameAccountId CreateFromNet(BnetId src)
    {
        BnetGameAccountId id = new BnetGameAccountId();
        id.CopyFrom(src);
        return id;
    }
}


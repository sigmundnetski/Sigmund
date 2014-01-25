using PegasusShared;

public class BnetAccountId : BnetEntityId
{
    public BnetAccountId Clone()
    {
        BnetAccountId id = new BnetAccountId();
        id.CopyFrom(this);
        return id;
    }

    public static BnetAccountId CreateFromDll(BattleNet.DllEntityId src)
    {
        BnetAccountId id = new BnetAccountId();
        id.CopyFrom(src);
        return id;
    }

    public static BnetAccountId CreateFromNet(BnetId src)
    {
        BnetAccountId id = new BnetAccountId();
        id.CopyFrom(src);
        return id;
    }
}


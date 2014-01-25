using System;
using System.Runtime.InteropServices;

public class FriendUtils
{
    public static string GetUniqueName(BnetPlayer friend)
    {
        BnetBattleTag tag;
        string str;
        if (GetUniqueName(friend, out tag, out str))
        {
            return string.Format("{0}#{1}", tag.GetName(), tag.GetNumber());
        }
        return str;
    }

    private static bool GetUniqueName(BnetPlayer friend, out BnetBattleTag battleTag, out string name)
    {
        battleTag = friend.GetBattleTag();
        name = friend.GetBestName();
        foreach (BnetPlayer player in BnetFriendMgr.Get().GetFriends())
        {
            if (player != friend)
            {
                string bestName = player.GetBestName();
                if (string.Compare(name, bestName, true) == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static string GetUniqueNameWithColor(BnetPlayer friend)
    {
        BnetBattleTag tag;
        string str2;
        string str = !friend.IsOnline() ? "999999ff" : "5ecaf0ff";
        if (GetUniqueName(friend, out tag, out str2))
        {
            object[] args = new object[] { str, tag.GetName(), "a1a1a1ff", tag.GetNumber() };
            return string.Format("<color=#{0}>{1}</color><color=#{2}>#{3}</color>", args);
        }
        return string.Format("<color=#{0}>{1}</color>", str, str2);
    }
}


using System;

public class Tags
{
    public const int MAX = 0x200;

    public static string DebugTag(int tag, int val)
    {
        string str = tag.ToString();
        try
        {
            str = Enum.Parse(typeof(GAME_TAG), tag.ToString()).ToString();
        }
        catch (Exception)
        {
        }
        string str2 = val.ToString();
        switch (((GAME_TAG) tag))
        {
            case GAME_TAG.NEXT_STEP:
            case GAME_TAG.STEP:
                try
                {
                    str2 = Enum.Parse(typeof(TAG_STEP), val.ToString()).ToString();
                }
                catch (Exception)
                {
                }
                break;

            case GAME_TAG.CLASS:
                try
                {
                    str2 = Enum.Parse(typeof(TAG_CLASS), val.ToString()).ToString();
                }
                catch (Exception)
                {
                }
                break;

            case GAME_TAG.CARDRACE:
                try
                {
                    str2 = Enum.Parse(typeof(TAG_RACE), val.ToString()).ToString();
                }
                catch (Exception)
                {
                }
                break;

            case GAME_TAG.FACTION:
                try
                {
                    str2 = Enum.Parse(typeof(TAG_FACTION), val.ToString()).ToString();
                }
                catch (Exception)
                {
                }
                break;

            case GAME_TAG.CARDTYPE:
                try
                {
                    str2 = Enum.Parse(typeof(TAG_CARDTYPE), val.ToString()).ToString();
                }
                catch (Exception)
                {
                }
                break;

            case GAME_TAG.RARITY:
                try
                {
                    str2 = Enum.Parse(typeof(TAG_RARITY), val.ToString()).ToString();
                }
                catch (Exception)
                {
                }
                break;

            case GAME_TAG.STATE:
                try
                {
                    str2 = Enum.Parse(typeof(TAG_STATE_ENUM), val.ToString()).ToString();
                }
                catch (Exception)
                {
                }
                break;

            case GAME_TAG.PLAYSTATE:
                try
                {
                    str2 = Enum.Parse(typeof(TAG_PLAYSTATE), val.ToString()).ToString();
                }
                catch (Exception)
                {
                }
                break;

            case GAME_TAG.ZONE:
                try
                {
                    str2 = Enum.Parse(typeof(TAG_ZONE), val.ToString()).ToString();
                }
                catch (Exception)
                {
                }
                break;

            case GAME_TAG.MULLIGAN_STATE:
                try
                {
                    str2 = Enum.Parse(typeof(TAG_MULLIGAN), val.ToString()).ToString();
                }
                catch (Exception)
                {
                }
                break;
        }
        return string.Format("tag={0} value={1}", str, str2);
    }
}


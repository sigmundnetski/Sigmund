using System;
using System.Collections.Generic;
using UnityEngine;

public class Medal
{
    private int m_grandMasterRank;
    private Type m_medalType;
    private static readonly Dictionary<Type, string> s_medalNameKey;

    static Medal()
    {
        Dictionary<Type, string> dictionary = new Dictionary<Type, string>();
        dictionary.Add(Type.MEDAL_NOVICE, "GLOBAL_MEDAL_NOVICE");
        dictionary.Add(Type.MEDAL_JOURNEYMAN, "GLOBAL_MEDAL_JOURNEYMAN");
        dictionary.Add(Type.MEDAL_COPPER_A, "GLOBAL_MEDAL_COPPER");
        dictionary.Add(Type.MEDAL_COPPER_B, "GLOBAL_MEDAL_COPPER");
        dictionary.Add(Type.MEDAL_COPPER_C, "GLOBAL_MEDAL_COPPER");
        dictionary.Add(Type.MEDAL_SILVER_A, "GLOBAL_MEDAL_SILVER");
        dictionary.Add(Type.MEDAL_SILVER_B, "GLOBAL_MEDAL_SILVER");
        dictionary.Add(Type.MEDAL_SILVER_C, "GLOBAL_MEDAL_SILVER");
        dictionary.Add(Type.MEDAL_GOLD_A, "GLOBAL_MEDAL_GOLD");
        dictionary.Add(Type.MEDAL_GOLD_B, "GLOBAL_MEDAL_GOLD");
        dictionary.Add(Type.MEDAL_GOLD_C, "GLOBAL_MEDAL_GOLD");
        dictionary.Add(Type.MEDAL_PLATINUM_A, "GLOBAL_MEDAL_PLATINUM");
        dictionary.Add(Type.MEDAL_PLATINUM_B, "GLOBAL_MEDAL_PLATINUM");
        dictionary.Add(Type.MEDAL_PLATINUM_C, "GLOBAL_MEDAL_PLATINUM");
        dictionary.Add(Type.MEDAL_DIAMOND_A, "GLOBAL_MEDAL_DIAMOND");
        dictionary.Add(Type.MEDAL_DIAMOND_B, "GLOBAL_MEDAL_DIAMOND");
        dictionary.Add(Type.MEDAL_DIAMOND_C, "GLOBAL_MEDAL_DIAMOND");
        dictionary.Add(Type.MEDAL_MASTER_A, "GLOBAL_MEDAL_MASTER");
        dictionary.Add(Type.MEDAL_MASTER_B, "GLOBAL_MEDAL_MASTER");
        dictionary.Add(Type.MEDAL_MASTER_C, "GLOBAL_MEDAL_MASTER");
        s_medalNameKey = dictionary;
    }

    public Medal(Type medalType) : this(medalType, 0)
    {
    }

    public Medal(int grandMasterRank) : this(Type.MEDAL_MASTER_C, grandMasterRank)
    {
    }

    private Medal(Type medalType, int grandMasterRank)
    {
        this.m_medalType = medalType;
        this.m_grandMasterRank = grandMasterRank;
    }

    public string GetBaseMedalName()
    {
        if (this.IsGrandMaster())
        {
            return GameStrings.Get("GLOBAL_MEDAL_GRANDMASTER");
        }
        if (s_medalNameKey.ContainsKey(this.MedalType))
        {
            return GameStrings.Get(s_medalNameKey[this.MedalType]);
        }
        Debug.LogWarning(string.Format("Medal.GetMedalName(): don't have a medal name key for {0}", this));
        return GameStrings.Get("GLOBAL_MEDAL_NO_NAME");
    }

    public string GetMedalName()
    {
        if (this.IsGrandMaster())
        {
            return GameStrings.Get("GLOBAL_MEDAL_GRANDMASTER");
        }
        string baseMedalName = this.GetBaseMedalName();
        string starString = this.GetStarString();
        if (string.IsNullOrEmpty(starString))
        {
            return baseMedalName;
        }
        object[] args = new object[] { starString, baseMedalName };
        return GameStrings.Format("GLOBAL_MEDAL_STARRED_FORMAT", args);
    }

    public string GetNextMedalName()
    {
        Medal medal;
        int num2 = ((int) this.MedalType) + 1;
        if (num2 >= Enum.GetValues(typeof(Type)).Length)
        {
            medal = new Medal(1);
        }
        else
        {
            medal = new Medal((Type) num2);
        }
        return medal.GetMedalName();
    }

    public int GetNumStars()
    {
        if (!this.IsGrandMaster())
        {
            switch (this.MedalType)
            {
                case Type.MEDAL_NOVICE:
                case Type.MEDAL_JOURNEYMAN:
                    return 0;

                case Type.MEDAL_COPPER_A:
                case Type.MEDAL_SILVER_A:
                case Type.MEDAL_GOLD_A:
                case Type.MEDAL_PLATINUM_A:
                case Type.MEDAL_DIAMOND_A:
                case Type.MEDAL_MASTER_A:
                    return 1;

                case Type.MEDAL_COPPER_B:
                case Type.MEDAL_SILVER_B:
                case Type.MEDAL_GOLD_B:
                case Type.MEDAL_PLATINUM_B:
                case Type.MEDAL_DIAMOND_B:
                case Type.MEDAL_MASTER_B:
                    return 2;

                case Type.MEDAL_COPPER_C:
                case Type.MEDAL_SILVER_C:
                case Type.MEDAL_GOLD_C:
                case Type.MEDAL_PLATINUM_C:
                case Type.MEDAL_DIAMOND_C:
                case Type.MEDAL_MASTER_C:
                    return 3;
            }
            Debug.LogWarning(string.Format("Medal.GetNumStars(): Don't know how many stars are in medal {0}", this));
        }
        return 0;
    }

    private string GetStarString()
    {
        int numStars = this.GetNumStars();
        switch (numStars)
        {
            case 0:
                return string.Empty;

            case 1:
                return GameStrings.Get("GLOBAL_MEDAL_ONE_STAR");

            case 2:
                return GameStrings.Get("GLOBAL_MEDAL_TWO_STAR");

            case 3:
                return GameStrings.Get("GLOBAL_MEDAL_THREE_STAR");
        }
        Debug.LogWarning(string.Format("Medal.GetStarString(): don't have a star string for {0} stars", numStars));
        return string.Empty;
    }

    public bool IsGrandMaster()
    {
        return ((this.MedalType == Type.MEDAL_MASTER_C) && (this.GrandMasterRank > 0));
    }

    public override string ToString()
    {
        return string.Format("[Medal: MedalType={0}, GrandMasterRank={1}]", this.MedalType, this.GrandMasterRank);
    }

    public int GrandMasterRank
    {
        get
        {
            return this.m_grandMasterRank;
        }
    }

    public Type MedalType
    {
        get
        {
            return this.m_medalType;
        }
    }

    public enum Type
    {
        MEDAL_NOVICE,
        MEDAL_JOURNEYMAN,
        MEDAL_COPPER_A,
        MEDAL_COPPER_B,
        MEDAL_COPPER_C,
        MEDAL_SILVER_A,
        MEDAL_SILVER_B,
        MEDAL_SILVER_C,
        MEDAL_GOLD_A,
        MEDAL_GOLD_B,
        MEDAL_GOLD_C,
        MEDAL_PLATINUM_A,
        MEDAL_PLATINUM_B,
        MEDAL_PLATINUM_C,
        MEDAL_DIAMOND_A,
        MEDAL_DIAMOND_B,
        MEDAL_DIAMOND_C,
        MEDAL_MASTER_A,
        MEDAL_MASTER_B,
        MEDAL_MASTER_C
    }
}


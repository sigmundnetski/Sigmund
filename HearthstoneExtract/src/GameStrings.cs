using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameStrings
{
    private static Dictionary<TAG_CARD_SET, string> s_cardSetNames;
    private static Dictionary<TAG_CARDTYPE, string> s_cardTypeNames;
    private static Dictionary<TAG_CLASS, string> s_classDescriptions;
    private static Dictionary<TAG_CLASS, string> s_classNames;
    private static Dictionary<GAME_TAG, string[]> s_keywordText;
    private static Dictionary<TAG_RACE, string> s_raceNames;
    private static Dictionary<TAG_RARITY, string> s_rarityNames;
    private static Dictionary<GAME_TAG, string[]> s_refKeywordText;
    private static Dictionary<GameStringCategory, GameStringTable> s_tables = new Dictionary<GameStringCategory, GameStringTable>();

    static GameStrings()
    {
        Dictionary<TAG_CLASS, string> dictionary = new Dictionary<TAG_CLASS, string>();
        dictionary.Add(TAG_CLASS.DEATHKNIGHT, "GLOBAL_CLASS_DEATHKNIGHT");
        dictionary.Add(TAG_CLASS.DRUID, "GLOBAL_CLASS_DRUID");
        dictionary.Add(TAG_CLASS.HUNTER, "GLOBAL_CLASS_HUNTER");
        dictionary.Add(TAG_CLASS.MAGE, "GLOBAL_CLASS_MAGE");
        dictionary.Add(TAG_CLASS.PALADIN, "GLOBAL_CLASS_PALADIN");
        dictionary.Add(TAG_CLASS.PRIEST, "GLOBAL_CLASS_PRIEST");
        dictionary.Add(TAG_CLASS.ROGUE, "GLOBAL_CLASS_ROGUE");
        dictionary.Add(TAG_CLASS.SHAMAN, "GLOBAL_CLASS_SHAMAN");
        dictionary.Add(TAG_CLASS.WARLOCK, "GLOBAL_CLASS_WARLOCK");
        dictionary.Add(TAG_CLASS.WARRIOR, "GLOBAL_CLASS_WARRIOR");
        dictionary.Add(TAG_CLASS.NONE, "GLOBAL_CLASS_NEUTRAL");
        s_classNames = dictionary;
        dictionary = new Dictionary<TAG_CLASS, string>();
        dictionary.Add(TAG_CLASS.DEATHKNIGHT, "GLOBAL_CLASS_DESCRIPTION_DEATHKNIGHT");
        dictionary.Add(TAG_CLASS.DRUID, "GLOBAL_CLASS_DESCRIPTION_DRUID");
        dictionary.Add(TAG_CLASS.HUNTER, "GLOBAL_CLASS_DESCRIPTION_HUNTER");
        dictionary.Add(TAG_CLASS.MAGE, "GLOBAL_CLASS_DESCRIPTION_MAGE");
        dictionary.Add(TAG_CLASS.PALADIN, "GLOBAL_CLASS_DESCRIPTION_PALADIN");
        dictionary.Add(TAG_CLASS.PRIEST, "GLOBAL_CLASS_DESCRIPTION_PRIEST");
        dictionary.Add(TAG_CLASS.ROGUE, "GLOBAL_CLASS_DESCRIPTION_ROGUE");
        dictionary.Add(TAG_CLASS.SHAMAN, "GLOBAL_CLASS_DESCRIPTION_SHAMAN");
        dictionary.Add(TAG_CLASS.WARLOCK, "GLOBAL_CLASS_DESCRIPTION_WARLOCK");
        dictionary.Add(TAG_CLASS.WARRIOR, "GLOBAL_CLASS_DESCRIPTION_WARRIOR");
        s_classDescriptions = dictionary;
        Dictionary<TAG_RACE, string> dictionary2 = new Dictionary<TAG_RACE, string>();
        dictionary2.Add(TAG_RACE.BLOODELF, "GLOBAL_RACE_BLOODELF");
        dictionary2.Add(TAG_RACE.DRAENEI, "GLOBAL_RACE_DRAENEI");
        dictionary2.Add(TAG_RACE.DWARF, "GLOBAL_RACE_DWARF");
        dictionary2.Add(TAG_RACE.GNOME, "GLOBAL_RACE_GNOME");
        dictionary2.Add(TAG_RACE.GOBLIN, "GLOBAL_RACE_GOBLIN");
        dictionary2.Add(TAG_RACE.HUMAN, "GLOBAL_RACE_HUMAN");
        dictionary2.Add(TAG_RACE.NIGHTELF, "GLOBAL_RACE_NIGHTELF");
        dictionary2.Add(TAG_RACE.ORC, "GLOBAL_RACE_ORC");
        dictionary2.Add(TAG_RACE.TAUREN, "GLOBAL_RACE_TAUREN");
        dictionary2.Add(TAG_RACE.TROLL, "GLOBAL_RACE_TROLL");
        dictionary2.Add(TAG_RACE.UNDEAD, "GLOBAL_RACE_UNDEAD");
        dictionary2.Add(TAG_RACE.WORGEN, "GLOBAL_RACE_WORGEN");
        dictionary2.Add(TAG_RACE.MURLOC, "GLOBAL_RACE_MURLOC");
        dictionary2.Add(TAG_RACE.DEMON, "GLOBAL_RACE_DEMON");
        dictionary2.Add(TAG_RACE.SCOURGE, "GLOBAL_RACE_SCOURGE");
        dictionary2.Add(TAG_RACE.MECHANICAL, "GLOBAL_RACE_MECHANICAL");
        dictionary2.Add(TAG_RACE.ELEMENTAL, "GLOBAL_RACE_ELEMENTAL");
        dictionary2.Add(TAG_RACE.OGRE, "GLOBAL_RACE_OGRE");
        dictionary2.Add(TAG_RACE.PET, "GLOBAL_RACE_PET");
        dictionary2.Add(TAG_RACE.TOTEM, "GLOBAL_RACE_TOTEM");
        dictionary2.Add(TAG_RACE.NERUBIAN, "GLOBAL_RACE_NERUBIAN");
        dictionary2.Add(TAG_RACE.PIRATE, "GLOBAL_RACE_PIRATE");
        dictionary2.Add(TAG_RACE.DRAGON, "GLOBAL_RACE_DRAGON");
        s_raceNames = dictionary2;
        Dictionary<TAG_RARITY, string> dictionary3 = new Dictionary<TAG_RARITY, string>();
        dictionary3.Add(TAG_RARITY.COMMON, "GLOBAL_RARITY_COMMON");
        dictionary3.Add(TAG_RARITY.EPIC, "GLOBAL_RARITY_EPIC");
        dictionary3.Add(TAG_RARITY.LEGENDARY, "GLOBAL_RARITY_LEGENDARY");
        dictionary3.Add(TAG_RARITY.RARE, "GLOBAL_RARITY_RARE");
        dictionary3.Add(TAG_RARITY.FREE, "GLOBAL_RARITY_FREE");
        s_rarityNames = dictionary3;
        Dictionary<TAG_CARD_SET, string> dictionary4 = new Dictionary<TAG_CARD_SET, string>();
        dictionary4.Add(TAG_CARD_SET.CORE, "GLOBAL_CARD_SET_CORE");
        dictionary4.Add(TAG_CARD_SET.EXPERT1, "GLOBAL_CARD_SET_EXPERT1");
        dictionary4.Add(TAG_CARD_SET.REWARD, "GLOBAL_CARD_SET_REWARD");
        s_cardSetNames = dictionary4;
        Dictionary<TAG_CARDTYPE, string> dictionary5 = new Dictionary<TAG_CARDTYPE, string>();
        dictionary5.Add(TAG_CARDTYPE.HERO, "GLOBAL_CARDTYPE_HERO");
        dictionary5.Add(TAG_CARDTYPE.MINION, "GLOBAL_CARDTYPE_MINION");
        dictionary5.Add(TAG_CARDTYPE.ABILITY, "GLOBAL_CARDTYPE_SPELL");
        dictionary5.Add(TAG_CARDTYPE.ENCHANTMENT, "GLOBAL_CARDTYPE_ENCHANTMENT");
        dictionary5.Add(TAG_CARDTYPE.WEAPON, "GLOBAL_CARDTYPE_WEAPON");
        dictionary5.Add(TAG_CARDTYPE.ITEM, "GLOBAL_CARDTYPE_ITEM");
        dictionary5.Add(TAG_CARDTYPE.TOKEN, "GLOBAL_CARDTYPE_TOKEN");
        dictionary5.Add(TAG_CARDTYPE.HERO_POWER, "GLOBAL_CARDTYPE_HEROPOWER");
        s_cardTypeNames = dictionary5;
        Dictionary<GAME_TAG, string[]> dictionary6 = new Dictionary<GAME_TAG, string[]>();
        string[] textArray1 = new string[] { "GLOBAL_KEYWORD_TAUNT", "GLOBAL_KEYWORD_TAUNT_TEXT" };
        dictionary6.Add(GAME_TAG.TAUNT, textArray1);
        string[] textArray2 = new string[] { "GLOBAL_KEYWORD_SPELLPOWER", "GLOBAL_KEYWORD_SPELLPOWER_TEXT" };
        dictionary6.Add(GAME_TAG.SPELLPOWER, textArray2);
        string[] textArray3 = new string[] { "GLOBAL_KEYWORD_DIVINE_SHIELD", "GLOBAL_KEYWORD_DIVINE_SHIELD_TEXT" };
        dictionary6.Add(GAME_TAG.DIVINE_SHIELD, textArray3);
        string[] textArray4 = new string[] { "GLOBAL_KEYWORD_CHARGE", "GLOBAL_KEYWORD_CHARGE_TEXT" };
        dictionary6.Add(GAME_TAG.CHARGE, textArray4);
        string[] textArray5 = new string[] { "GLOBAL_KEYWORD_SECRET", "GLOBAL_KEYWORD_SECRET_TEXT" };
        dictionary6.Add(GAME_TAG.SECRET, textArray5);
        string[] textArray6 = new string[] { "GLOBAL_KEYWORD_STEALTH", "GLOBAL_KEYWORD_STEALTH_TEXT" };
        dictionary6.Add(GAME_TAG.STEALTH, textArray6);
        string[] textArray7 = new string[] { "GLOBAL_KEYWORD_ENRAGED", "GLOBAL_KEYWORD_ENRAGED_TEXT" };
        dictionary6.Add(GAME_TAG.ENRAGED, textArray7);
        string[] textArray8 = new string[] { "GLOBAL_KEYWORD_BATTLECRY", "GLOBAL_KEYWORD_BATTLECRY_TEXT" };
        dictionary6.Add(GAME_TAG.BATTLECRY, textArray8);
        string[] textArray9 = new string[] { "GLOBAL_KEYWORD_FROZEN", "GLOBAL_KEYWORD_FROZEN_TEXT" };
        dictionary6.Add(GAME_TAG.FROZEN, textArray9);
        string[] textArray10 = new string[] { "GLOBAL_KEYWORD_FREEZE", "GLOBAL_KEYWORD_FREEZE_TEXT" };
        dictionary6.Add(GAME_TAG.FREEZE, textArray10);
        string[] textArray11 = new string[] { "GLOBAL_KEYWORD_WINDFURY", "GLOBAL_KEYWORD_WINDFURY_TEXT" };
        dictionary6.Add(GAME_TAG.WINDFURY, textArray11);
        string[] textArray12 = new string[] { "GLOBAL_KEYWORD_DEATHRATTLE", "GLOBAL_KEYWORD_DEATHRATTLE_TEXT" };
        dictionary6.Add(GAME_TAG.DEATH_RATTLE, textArray12);
        string[] textArray13 = new string[] { "GLOBAL_KEYWORD_COMBO", "GLOBAL_KEYWORD_COMBO_TEXT" };
        dictionary6.Add(GAME_TAG.COMBO, textArray13);
        string[] textArray14 = new string[] { "GLOBAL_KEYWORD_RECALL", "GLOBAL_KEYWORD_RECALL_TEXT" };
        dictionary6.Add(GAME_TAG.RECALL, textArray14);
        string[] textArray15 = new string[] { "GLOBAL_KEYWORD_SILENCE", "GLOBAL_KEYWORD_SILENCE_TEXT" };
        dictionary6.Add(GAME_TAG.SILENCE, textArray15);
        string[] textArray16 = new string[] { "GLOBAL_KEYWORD_COUNTER", "GLOBAL_KEYWORD_COUNTER_TEXT" };
        dictionary6.Add(GAME_TAG.COUNTER, textArray16);
        string[] textArray17 = new string[] { "GLOBAL_KEYWORD_IMMUNE", "GLOBAL_KEYWORD_IMMUNE_TEXT" };
        dictionary6.Add(GAME_TAG.CANT_BE_DAMAGED, textArray17);
        s_keywordText = dictionary6;
        dictionary6 = new Dictionary<GAME_TAG, string[]>();
        string[] textArray18 = new string[] { "GLOBAL_KEYWORD_TAUNT", "GLOBAL_KEYWORD_TAUNT_REF_TEXT" };
        dictionary6.Add(GAME_TAG.TAUNT, textArray18);
        string[] textArray19 = new string[] { "GLOBAL_KEYWORD_SPELLPOWER", "GLOBAL_KEYWORD_SPELLPOWER_TEXT" };
        dictionary6.Add(GAME_TAG.SPELLPOWER, textArray19);
        string[] textArray20 = new string[] { "GLOBAL_KEYWORD_DIVINE_SHIELD", "GLOBAL_KEYWORD_DIVINE_SHIELD_REF_TEXT" };
        dictionary6.Add(GAME_TAG.DIVINE_SHIELD, textArray20);
        string[] textArray21 = new string[] { "GLOBAL_KEYWORD_CHARGE", "GLOBAL_KEYWORD_CHARGE_TEXT" };
        dictionary6.Add(GAME_TAG.CHARGE, textArray21);
        string[] textArray22 = new string[] { "GLOBAL_KEYWORD_SECRET", "GLOBAL_KEYWORD_SECRET_TEXT" };
        dictionary6.Add(GAME_TAG.SECRET, textArray22);
        string[] textArray23 = new string[] { "GLOBAL_KEYWORD_STEALTH", "GLOBAL_KEYWORD_STEALTH_REF_TEXT" };
        dictionary6.Add(GAME_TAG.STEALTH, textArray23);
        string[] textArray24 = new string[] { "GLOBAL_KEYWORD_ENRAGED", "GLOBAL_KEYWORD_ENRAGED_TEXT" };
        dictionary6.Add(GAME_TAG.ENRAGED, textArray24);
        string[] textArray25 = new string[] { "GLOBAL_KEYWORD_BATTLECRY", "GLOBAL_KEYWORD_BATTLECRY_TEXT" };
        dictionary6.Add(GAME_TAG.BATTLECRY, textArray25);
        string[] textArray26 = new string[] { "GLOBAL_KEYWORD_FROZEN", "GLOBAL_KEYWORD_FROZEN_TEXT" };
        dictionary6.Add(GAME_TAG.FROZEN, textArray26);
        string[] textArray27 = new string[] { "GLOBAL_KEYWORD_FREEZE", "GLOBAL_KEYWORD_FREEZE_TEXT" };
        dictionary6.Add(GAME_TAG.FREEZE, textArray27);
        string[] textArray28 = new string[] { "GLOBAL_KEYWORD_WINDFURY", "GLOBAL_KEYWORD_WINDFURY_TEXT" };
        dictionary6.Add(GAME_TAG.WINDFURY, textArray28);
        string[] textArray29 = new string[] { "GLOBAL_KEYWORD_DEATHRATTLE", "GLOBAL_KEYWORD_DEATHRATTLE_TEXT" };
        dictionary6.Add(GAME_TAG.DEATH_RATTLE, textArray29);
        string[] textArray30 = new string[] { "GLOBAL_KEYWORD_COMBO", "GLOBAL_KEYWORD_COMBO_TEXT" };
        dictionary6.Add(GAME_TAG.COMBO, textArray30);
        string[] textArray31 = new string[] { "GLOBAL_KEYWORD_RECALL", "GLOBAL_KEYWORD_RECALL_TEXT" };
        dictionary6.Add(GAME_TAG.RECALL, textArray31);
        string[] textArray32 = new string[] { "GLOBAL_KEYWORD_SILENCE", "GLOBAL_KEYWORD_SILENCE_TEXT" };
        dictionary6.Add(GAME_TAG.SILENCE, textArray32);
        string[] textArray33 = new string[] { "GLOBAL_KEYWORD_COUNTER", "GLOBAL_KEYWORD_COUNTER_TEXT" };
        dictionary6.Add(GAME_TAG.COUNTER, textArray33);
        string[] textArray34 = new string[] { "GLOBAL_KEYWORD_IMMUNE", "GLOBAL_KEYWORD_IMMUNE_REF_TEXT" };
        dictionary6.Add(GAME_TAG.CANT_BE_DAMAGED, textArray34);
        s_refKeywordText = dictionary6;
    }

    private static void CheckConflicts(GameStringTable table)
    {
        Dictionary<string, string>.KeyCollection keys = table.GetAll().Keys;
        GameStringCategory category = table.GetCategory();
        foreach (GameStringTable table2 in s_tables.Values)
        {
            foreach (string str in keys)
            {
                if (table2.Get(str) != null)
                {
                    string message = string.Format("GameStrings.CheckConflicts() - Tag {0} is used in {1} and {2}. All tags must be unique.", str, category, table2.GetCategory());
                    Error.AddDevWarning("GameStrings Error", message, new object[0]);
                }
            }
        }
    }

    private static string Find(string key)
    {
        foreach (GameStringTable table in s_tables.Values)
        {
            string str = table.Get(key);
            if (str != null)
            {
                return str;
            }
        }
        return null;
    }

    public static string Format(string key, params object[] args)
    {
        string format = Find(key);
        return ((format != null) ? string.Format(format, args) : key);
    }

    public static string Get(string key)
    {
        string str = Find(key);
        return ((str != null) ? str : key);
    }

    public static string GetCardSetName(TAG_CARD_SET tag)
    {
        string str = null;
        return (!s_cardSetNames.TryGetValue(tag, out str) ? "UNKNOWN" : Get(str));
    }

    public static string GetCardTypeName(TAG_CARDTYPE tag)
    {
        string str = null;
        return (!s_cardTypeNames.TryGetValue(tag, out str) ? "UNKNOWN" : Get(str));
    }

    public static string GetClassDescription(TAG_CLASS tag)
    {
        string str = null;
        return (!s_classDescriptions.TryGetValue(tag, out str) ? "UNKNOWN" : Get(str));
    }

    public static string GetClassName(TAG_CLASS tag)
    {
        string str = null;
        return (!s_classNames.TryGetValue(tag, out str) ? "UNKNOWN" : Get(str));
    }

    public static string GetKeywordFilterText(GAME_TAG tag)
    {
        return GetKeywordText(tag);
    }

    public static string GetKeywordName(GAME_TAG tag)
    {
        string[] strArray = null;
        return (!s_keywordText.TryGetValue(tag, out strArray) ? "UNKNOWN" : Get(strArray[0]));
    }

    public static string GetKeywordText(GAME_TAG tag)
    {
        string[] strArray = null;
        return (!s_keywordText.TryGetValue(tag, out strArray) ? "UNKNOWN" : Get(strArray[1]));
    }

    public static string GetRaceName(TAG_RACE tag)
    {
        string str = null;
        return (!s_raceNames.TryGetValue(tag, out str) ? "UNKNOWN" : Get(str));
    }

    public static string GetRandomTip(TipCategory tipCategory)
    {
        int num = 0;
        List<string> list = new List<string>();
        while (true)
        {
            string key = string.Format("GLUE_TIP_{0}_{1}", tipCategory, num);
            string item = Get(key);
            if (item.Equals(key))
            {
                break;
            }
            list.Add(item);
            num++;
        }
        if (list.Count == 0)
        {
            Debug.LogError(string.Format("GameStrings.GetRandomTip() - no tips in category {0}", tipCategory));
            return "UNKNOWN";
        }
        int num2 = UnityEngine.Random.Range(0, list.Count);
        return list[num2];
    }

    public static string GetRarityText(TAG_RARITY tag)
    {
        string str = null;
        return (!s_rarityNames.TryGetValue(tag, out str) ? "UNKNOWN" : Get(str));
    }

    public static string GetRefKeywordText(GAME_TAG tag)
    {
        string[] strArray = null;
        return (!s_refKeywordText.TryGetValue(tag, out strArray) ? "UNKNOWN" : Get(strArray[1]));
    }

    public static string GetTip(TipCategory tipCategory, int progress, TipCategory randomTipCategory = 4)
    {
        int num = 0;
        List<string> list = new List<string>();
        while (true)
        {
            string key = string.Format("GLUE_TIP_{0}_{1}", tipCategory, num);
            string item = Get(key);
            if (item.Equals(key))
            {
                break;
            }
            list.Add(item);
            num++;
        }
        if (progress < list.Count)
        {
            return list[progress];
        }
        return GetRandomTip(randomTipCategory);
    }

    public static void Initialize()
    {
        LoadCategory(GameStringCategory.GLOBAL);
    }

    public static bool LoadCategory(GameStringCategory cat)
    {
        if (s_tables.ContainsKey(cat))
        {
            Debug.LogWarning(string.Format("GameStrings.LoadCategory() - {0} is already loaded", cat));
            return false;
        }
        GameStringTable table = new GameStringTable();
        if (!table.Load(cat))
        {
            Debug.LogError(string.Format("GameStrings.LoadCategory() - {0} failed to load", cat));
            return false;
        }
        if (ApplicationMgr.IsInternal())
        {
            CheckConflicts(table);
        }
        s_tables.Add(cat, table);
        return true;
    }

    public static bool UnloadCategory(GameStringCategory cat)
    {
        if (!s_tables.Remove(cat))
        {
            Debug.LogWarning(string.Format("GameStrings.UnloadCategory() - {0} was never loaded", cat));
            return false;
        }
        return true;
    }

    public static string UnsafeFormat(string key, params object[] args)
    {
        string format = Find(key);
        return ((format != null) ? string.Format(format, args) : null);
    }

    public static string UnsafeGet(string key)
    {
        return Find(key);
    }
}


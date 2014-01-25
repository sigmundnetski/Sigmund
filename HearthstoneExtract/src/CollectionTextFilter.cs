using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionTextFilter
{
    private static readonly GAME_TAG[] FILTERABLE_KEYWORDS = new GAME_TAG[] { GAME_TAG.TAUNT, GAME_TAG.STEALTH, GAME_TAG.DIVINE_SHIELD, GAME_TAG.ENRAGED, GAME_TAG.CHARGE, GAME_TAG.SPELLPOWER, GAME_TAG.WINDFURY, GAME_TAG.BATTLECRY, GAME_TAG.DEATH_RATTLE };
    private List<CollectionFilter<GAME_TAG>> m_deducedFilters;
    private Dictionary<string, CollectionFilter<GAME_TAG>> m_namedFilters = new Dictionary<string, CollectionFilter<GAME_TAG>>();
    private List<string> m_stringTokens = new List<string>();

    public CollectionTextFilter()
    {
        this.m_namedFilters = new Dictionary<string, CollectionFilter<GAME_TAG>>();
        this.AddNamedFiltersForArray(FILTERABLE_KEYWORDS, new FilterNamingFunction<GAME_TAG>(GameStrings.GetKeywordName));
        this.AddNamedFiltersForEnum<TAG_RARITY>(GAME_TAG.RARITY, new FilterNamingFunction<TAG_RARITY>(GameStrings.GetRarityText));
        this.AddNamedFiltersForEnum<TAG_RACE>(GAME_TAG.CARDRACE, new FilterNamingFunction<TAG_RACE>(GameStrings.GetRaceName));
    }

    private void AddNamedFilter(string name, CollectionFilter<GAME_TAG> filter)
    {
        string key = name.ToLower();
        if (!this.m_namedFilters.ContainsKey(key))
        {
            this.m_namedFilters.Add(key, filter);
        }
        else
        {
            Debug.LogWarning(string.Format("CollectionFilter.AddNamedFilter() trying to add duplicate tag '{0}'. Did a tag get added on the server that the client doesn't know about?", key));
        }
    }

    private void AddNamedFiltersForArray(GAME_TAG[] flaggableKeys, FilterNamingFunction<GAME_TAG> namingFunction)
    {
        foreach (GAME_TAG game_tag in flaggableKeys)
        {
            string str = namingFunction(game_tag);
            if (!string.IsNullOrEmpty(str))
            {
                CollectionFilter<GAME_TAG> filter = new CollectionFilter<GAME_TAG>();
                filter.SetKey(game_tag);
                filter.SetValue(1);
                filter.SetFunc(CollectionFilterFunc.EQUAL);
                this.AddNamedFilter(str, filter);
            }
        }
    }

    private void AddNamedFiltersForEnum<T>(GAME_TAG key, FilterNamingFunction<T> namingFunction)
    {
        IEnumerator enumerator = Enum.GetValues(typeof(T)).GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                T current = (T) enumerator.Current;
                string str = namingFunction(current);
                if (!string.IsNullOrEmpty(str))
                {
                    CollectionFilter<GAME_TAG> filter = new CollectionFilter<GAME_TAG>();
                    filter.SetKey(key);
                    filter.SetValue(current);
                    filter.SetFunc(CollectionFilterFunc.EQUAL);
                    this.AddNamedFilter(str, filter);
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    public void ClearFilter()
    {
        this.m_stringTokens.Clear();
    }

    public bool DoesValueMatch(EntityDef entityDef)
    {
        if (this.m_stringTokens.Count == 0)
        {
            return false;
        }
        string stringTag = entityDef.GetStringTag(GAME_TAG.CARDNAME);
        string str2 = entityDef.GetStringTag(GAME_TAG.CARDTEXT_INHAND);
        string str3 = (stringTag != null) ? stringTag.ToLower() : null;
        string str4 = (str2 != null) ? str2.ToLower() : null;
        foreach (string str5 in this.m_stringTokens)
        {
            if (this.m_namedFilters.ContainsKey(str5))
            {
                CollectionFilter<GAME_TAG> filter = this.m_namedFilters[str5];
                if (filter.DoesValueMatch(entityDef.GetTag(filter.GetKey())))
                {
                    continue;
                }
            }
            if (((str3 == null) || !str3.Contains(str5)) && ((str4 == null) || !str4.Contains(str5)))
            {
                return false;
            }
        }
        return true;
    }

    public bool IsEmpty()
    {
        return (this.m_stringTokens.Count == 0);
    }

    public void SetTextFilterValue(string val)
    {
        this.ClearFilter();
        char[] separator = new char[] { ' ' };
        foreach (string str in val.Split(separator))
        {
            if (str.Length != 0)
            {
                string item = str.ToLower();
                this.m_stringTokens.Add(item);
            }
        }
    }

    public bool ShouldRunFilter()
    {
        return ((this.m_stringTokens != null) && (this.m_stringTokens.Count > 0));
    }

    private delegate string FilterNamingFunction<T>(T param);
}


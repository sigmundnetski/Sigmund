using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHero : IComparable
{
    public static readonly string JAINA_CARD_ID = "HERO_08";
    private EntityDef m_entityDef;
    private static List<CollectibleHero> s_collectibleHeroes;

    private CollectibleHero(EntityDef entityDef)
    {
        this.m_entityDef = entityDef;
    }

    public int CompareTo(object obj)
    {
        if (!(obj is CollectibleHero))
        {
            throw new ArgumentException("Object is not a CollectibleHero.");
        }
        CollectibleHero hero = obj as CollectibleHero;
        return this.EntityDefinition.GetName().CompareTo(hero.EntityDefinition.GetName());
    }

    public static List<CollectibleHero> GetCollectibleHeroes()
    {
        if (s_collectibleHeroes == null)
        {
            s_collectibleHeroes = new List<CollectibleHero>();
            foreach (CardManifest.Card card in CardManifest.Get().CollectibleHeroes())
            {
                EntityDef entityDef = DefLoader.Get().GetEntityDef(card.CardID);
                if (entityDef == null)
                {
                    Log.Rachelle.Print(string.Format("Collection manager doesn't have an entity def for {0}!", card.CardID));
                }
                else
                {
                    s_collectibleHeroes.Add(new CollectibleHero(entityDef));
                }
            }
            s_collectibleHeroes.Sort();
        }
        return s_collectibleHeroes;
    }

    public string GetHeroBio()
    {
        switch (this.CardClass)
        {
            case TAG_CLASS.DRUID:
                return "The Druid is extremely flexible and always keeps his options open until he finds an opening and tears his opponent apart.";

            case TAG_CLASS.HUNTER:
                return "The Hunter leaves traps for those who try and catch him off guard and then uses his pets and tracking skills to finish off his foe.";

            case TAG_CLASS.MAGE:
                return "The Mage wields frost and fire to blast groups of foes apart.   When that fails, his arcane secrets take him to safety.";

            case TAG_CLASS.PALADIN:
                return "The Paladin punishes his opponent for attacking his good hearted allies and deals out deadly justice on the battlefield.";

            case TAG_CLASS.PRIEST:
                return "The priest looks into the future and into the heart of his foe and uses what he finds there to achieve dominance.";

            case TAG_CLASS.ROGUE:
                return "The shadowy rogue is deadly against exhausted characters and launches combination attacks that defeat his foes in a blink.";

            case TAG_CLASS.SHAMAN:
                return "While the elemental spells of the shaman are initially cheap, the elements extract the full price of his spells shortly thereafter.";

            case TAG_CLASS.WARLOCK:
                return "The Warlock is a master of dark magics and is willing to sacrifice anything include his allies and his own life to gain victory.";

            case TAG_CLASS.WARRIOR:
                return "He swings his weapon into the fray becoming more and more powerful as he and his allies become wounded.";
        }
        Debug.LogWarning(string.Format("Trying to retrieve a hero bio for unsupported class {0}", this.CardClass));
        return string.Empty;
    }

    public static CollectibleHero GetHeroFromAssetID(int heroAssetID)
    {
        CardManifest.Card card = CardManifest.Get().Find(heroAssetID);
        if (card == null)
        {
            return null;
        }
        return GetHeroFromCardID(card.CardID);
    }

    public static CollectibleHero GetHeroFromCardID(string cardID)
    {
        foreach (CollectibleHero hero in GetCollectibleHeroes())
        {
            if (hero.CardID.Equals(cardID))
            {
                return hero;
            }
        }
        return null;
    }

    public static string GetHeroIDFromClass(TAG_CLASS cardClass)
    {
        foreach (CollectibleHero hero in GetCollectibleHeroes())
        {
            if (hero.CardClass == cardClass)
            {
                return hero.CardID;
            }
        }
        return null;
    }

    public string GetHeroPowerID()
    {
        return GetHeroPowerID(this.CardClass);
    }

    public static string GetHeroPowerID(TAG_CLASS tagClass)
    {
        switch (tagClass)
        {
            case TAG_CLASS.DRUID:
                return "CS2_017";

            case TAG_CLASS.HUNTER:
                return "DS1h_292";

            case TAG_CLASS.MAGE:
                return "CS2_034";

            case TAG_CLASS.PALADIN:
                return "CS2_101";

            case TAG_CLASS.PRIEST:
                return "CS1h_001";

            case TAG_CLASS.ROGUE:
                return "CS2_083b";

            case TAG_CLASS.SHAMAN:
                return "CS2_049";

            case TAG_CLASS.WARLOCK:
                return "CS2_056";

            case TAG_CLASS.WARRIOR:
                return "CS2_102";
        }
        Debug.LogWarning(string.Format("Trying to retrieve a hero power for unsupported class {0}", tagClass));
        return string.Empty;
    }

    public TAG_CLASS CardClass
    {
        get
        {
            return this.EntityDefinition.GetClass();
        }
    }

    public string CardID
    {
        get
        {
            return this.EntityDefinition.GetCardId();
        }
    }

    public EntityDef EntityDefinition
    {
        get
        {
            return this.m_entityDef;
        }
    }
}


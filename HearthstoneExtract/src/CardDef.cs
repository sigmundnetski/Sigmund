using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDef : MonoBehaviour
{
    protected const int LARGE_MINION_COST = 7;
    public string m_AnnouncerLinePath;
    public string m_AttackSpellPath;
    public string m_BattlecrySpellPath;
    public string m_DeathSpellPath;
    public Material m_DeckCardBarPortrait;
    public List<EmoteEntryDef> m_EmoteDefs;
    public Material m_EnchantmentPortrait;
    public Material m_HistoryTileFullPortrait;
    public Material m_HistoryTileHalfPortrait;
    public string m_PlaySpellPath;
    public Texture m_PortraitTexture;
    public Material m_PremiumPortraitMaterial;
    public List<string> m_SubOptionSpellPaths;
    public List<string> m_TriggerSpellPaths;
    protected const int MEDIUM_MINION_COST = 4;

    public virtual string DetermineActorNameForZone(Entity entity, TAG_ZONE zoneTag)
    {
        return ActorNames.GetZoneActor(entity, zoneTag);
    }

    public virtual SpellType DetermineSummonInSpell_HandToPlay(Card card)
    {
        Entity entity = card.GetEntity();
        int cost = entity.GetEntityDef().GetCost();
        CardFlair.PremiumType premiumType = CardFlair.GetPremiumType(entity.GetCardFlair());
        bool flag = entity.GetController().IsLocal();
        if (cost < 7)
        {
            if (cost < 4)
            {
                switch (premiumType)
                {
                    case CardFlair.PremiumType.STANDARD:
                        goto Label_00F6;

                    case CardFlair.PremiumType.FOIL:
                        if (flag)
                        {
                            return SpellType.SUMMON_IN_PREMIUM;
                        }
                        return SpellType.SUMMON_IN_OPPONENT_PREMIUM;
                }
                Debug.LogWarning(string.Format("CardDef.DetermineSummonInSpell_HandToPlay() - unexpected premium type {0}", premiumType));
                goto Label_00F6;
            }
            switch (premiumType)
            {
                case CardFlair.PremiumType.STANDARD:
                    goto Label_00AB;

                case CardFlair.PremiumType.FOIL:
                    if (flag)
                    {
                        return SpellType.SUMMON_IN_MEDIUM_PREMIUM;
                    }
                    return SpellType.SUMMON_IN_OPPONENT_MEDIUM_PREMIUM;
            }
            Debug.LogWarning(string.Format("CardDef.DetermineSummonInSpell_HandToPlay() - unexpected premium type {0}", premiumType));
        }
        else
        {
            switch (premiumType)
            {
                case CardFlair.PremiumType.STANDARD:
                    break;

                case CardFlair.PremiumType.FOIL:
                    if (flag)
                    {
                        return SpellType.SUMMON_IN_LARGE_PREMIUM;
                    }
                    return SpellType.SUMMON_IN_OPPONENT_LARGE_PREMIUM;

                default:
                    Debug.LogWarning(string.Format("CardDef.DetermineSummonInSpell_HandToPlay() - unexpected premium type {0}", premiumType));
                    break;
            }
            if (flag)
            {
                return SpellType.SUMMON_IN_LARGE;
            }
            return SpellType.SUMMON_IN_OPPONENT_LARGE;
        }
    Label_00AB:
        if (flag)
        {
            return SpellType.SUMMON_IN_MEDIUM;
        }
        return SpellType.SUMMON_IN_OPPONENT_MEDIUM;
    Label_00F6:
        if (flag)
        {
            return SpellType.SUMMON_IN;
        }
        return SpellType.SUMMON_IN_OPPONENT;
    }

    public virtual SpellType DetermineSummonOutSpell_HandToPlay(Card card)
    {
        Entity entity = card.GetEntity();
        if (!entity.GetController().IsLocal())
        {
            return SpellType.SUMMON_OUT;
        }
        int cost = entity.GetEntityDef().GetCost();
        CardFlair.PremiumType premiumType = CardFlair.GetPremiumType(entity.GetCardFlair());
        if (cost < 7)
        {
            if (cost < 4)
            {
                switch (premiumType)
                {
                    case CardFlair.PremiumType.STANDARD:
                        goto Label_00C9;

                    case CardFlair.PremiumType.FOIL:
                        return SpellType.SUMMON_OUT_PREMIUM;
                }
                Debug.LogWarning(string.Format("CardDef.DetermineSummonOutSpell_HandToPlay(): unexpected premium type {0}", premiumType));
                goto Label_00C9;
            }
            switch (premiumType)
            {
                case CardFlair.PremiumType.STANDARD:
                    goto Label_0092;

                case CardFlair.PremiumType.FOIL:
                    return SpellType.SUMMON_OUT_PREMIUM;
            }
            Debug.LogWarning(string.Format("CardDef.DetermineSummonOutSpell_HandToPlay(): unexpected premium type {0}", premiumType));
        }
        else
        {
            switch (premiumType)
            {
                case CardFlair.PremiumType.STANDARD:
                    break;

                case CardFlair.PremiumType.FOIL:
                    return SpellType.SUMMON_OUT_PREMIUM;

                default:
                    Debug.LogWarning(string.Format("CardDef.DetermineSummonOutSpell_HandToPlay(): unexpected premium type {0}", premiumType));
                    break;
            }
            return SpellType.SUMMON_OUT_LARGE;
        }
    Label_0092:
        return SpellType.SUMMON_OUT_MEDIUM;
    Label_00C9:
        return SpellType.SUMMON_OUT;
    }
}


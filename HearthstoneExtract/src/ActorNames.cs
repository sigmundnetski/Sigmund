using System;
using UnityEngine;

public class ActorNames
{
    public const string COLLECTION_DECK_TILE = "DeckCardBar";
    public const string HAND_ABILITY = "Card_Hand_Ability";
    public const string HAND_FATIGUE = "Card_Hand_Fatigue";
    public const string HAND_MINION = "Card_Hand_Ally";
    public const string HAND_WEAPON = "Card_Hand_Weapon";
    public const string HEROPICKER_HERO = "HeroPicker_Hero";
    public const string HIDDEN = "Card_Hidden";
    public const string HISTORY_HERO = "History_Hero";
    public const string HISTORY_HERO_OPPONENT = "History_Hero_Opponent";
    public const string HISTORY_HERO_POWER = "History_HeroPower";
    public const string HISTORY_HERO_POWER_OPPONENT = "History_HeroPower_Opponent";
    public const string HISTORY_SECRET_HUNTER = "History_Secret_Hunter";
    public const string HISTORY_SECRET_MAGE = "History_Secret_Mage";
    public const string HISTORY_SECRET_PALADIN = "History_Secret_Paladin";
    public const string INVISIBLE = "Card_Invisible";
    public const string PLAY_ENCHANTMENT = "Card_Play_Enchantment";
    public const string PLAY_HERO = "Card_Play_Hero";
    public const string PLAY_HERO_POWER = "Card_Play_HeroPower";
    public const string PLAY_MINION = "Card_Play_Ally";
    public const string PLAY_WEAPON = "Card_Play_Weapon";
    public const string SECRET = "Card_Play_Secret_Mage";
    public const string SECRET_HUNTER = "Card_Play_Secret_Hunter";
    public const string SECRET_MAGE = "Card_Play_Secret_Mage";
    public const string SECRET_PALADIN = "Card_Play_Secret_Paladin";
    public const string TOOLTIP = "CardTooltip";

    public static string GetBigCardActor(Entity entity)
    {
        return GetHistoryActor(entity);
    }

    public static string GetHandActor(Entity entity)
    {
        return GetHandActor(entity.GetCardType(), entity.GetPremiumType());
    }

    public static string GetHandActor(EntityDef entityDef)
    {
        return GetHandActor(entityDef.GetCardType(), CardFlair.PremiumType.STANDARD);
    }

    public static string GetHandActor(TAG_CARDTYPE cardType)
    {
        return GetHandActor(cardType, CardFlair.PremiumType.STANDARD);
    }

    public static string GetHandActor(EntityDef entityDef, CardFlair flair)
    {
        return GetHandActor(entityDef.GetCardType(), CardFlair.GetPremiumType(flair));
    }

    public static string GetHandActor(EntityDef entityDef, CardFlair.PremiumType premiumType)
    {
        return GetHandActor(entityDef.GetCardType(), premiumType);
    }

    public static string GetHandActor(TAG_CARDTYPE cardType, CardFlair.PremiumType premiumType)
    {
        switch (cardType)
        {
            case TAG_CARDTYPE.HERO:
                return "History_Hero";

            case TAG_CARDTYPE.MINION:
                return GetNameWithPremiumType("Card_Hand_Ally", premiumType);

            case TAG_CARDTYPE.ABILITY:
                return GetNameWithPremiumType("Card_Hand_Ability", premiumType);

            case TAG_CARDTYPE.WEAPON:
                return GetNameWithPremiumType("Card_Hand_Weapon", premiumType);
        }
        Debug.LogError(string.Format("ActorNames.GetHandActor() - there is no actor for cardType {0}", cardType));
        return null;
    }

    public static string GetHistoryActor(Entity entity)
    {
        if (entity.IsSecret() && entity.IsHidden())
        {
            return GetHistorySecretActor(entity);
        }
        TAG_CARDTYPE cardType = entity.GetCardType();
        if (cardType != TAG_CARDTYPE.HERO)
        {
            if (cardType != TAG_CARDTYPE.HERO_POWER)
            {
                return GetHandActor(entity);
            }
            if (entity.GetController().IsLocal())
            {
                return "History_HeroPower";
            }
            return "History_HeroPower_Opponent";
        }
        if (entity.GetController().IsLocal())
        {
            return "History_Hero";
        }
        return "History_Hero_Opponent";
    }

    public static string GetHistorySecretActor(Entity entity)
    {
        TAG_CLASS tag_class = entity.GetClass();
        switch (tag_class)
        {
            case TAG_CLASS.HUNTER:
                return "History_Secret_Hunter";

            case TAG_CLASS.MAGE:
                return "History_Secret_Mage";

            case TAG_CLASS.PALADIN:
                return "History_Secret_Paladin";
        }
        Debug.LogWarning(string.Format("ActorNames.GetHistorySecretActor() - No actor for class {0}. Returning {1} instead.", tag_class, "History_Secret_Mage"));
        return "History_Secret_Mage";
    }

    public static string GetNameWithFlair(string actorName, CardFlair flair)
    {
        if (flair == null)
        {
            return actorName;
        }
        return GetNameWithPremiumType(actorName, flair.Premium);
    }

    public static string GetNameWithPremiumType(string actorName, CardFlair.PremiumType premiumType)
    {
        if (premiumType == CardFlair.PremiumType.FOIL)
        {
            return string.Format("{0}_Premium", actorName);
        }
        return actorName;
    }

    public static string GetZoneActor(Entity entity, TAG_ZONE zoneTag)
    {
        return GetZoneActor(entity.GetCardType(), entity.GetClass(), zoneTag, entity.GetController(), entity.GetCardFlair());
    }

    public static string GetZoneActor(EntityDef entityDef, TAG_ZONE zoneTag)
    {
        return GetZoneActor(entityDef.GetCardType(), entityDef.GetClass(), zoneTag, null, null);
    }

    public static string GetZoneActor(EntityDef entityDef, TAG_ZONE zoneTag, CardFlair flair)
    {
        return GetZoneActor(entityDef.GetCardType(), entityDef.GetClass(), zoneTag, null, flair);
    }

    public static string GetZoneActor(TAG_CARDTYPE cardType, TAG_CLASS classTag, TAG_ZONE zoneTag, Player controller, CardFlair flair)
    {
        switch (zoneTag)
        {
            case TAG_ZONE.PLAY:
                if (cardType != TAG_CARDTYPE.MINION)
                {
                    if (cardType == TAG_CARDTYPE.WEAPON)
                    {
                        return GetNameWithFlair("Card_Play_Weapon", flair);
                    }
                    if (cardType == TAG_CARDTYPE.HERO)
                    {
                        return "Card_Play_Hero";
                    }
                    if (cardType == TAG_CARDTYPE.HERO_POWER)
                    {
                        return "Card_Play_HeroPower";
                    }
                    if (cardType != TAG_CARDTYPE.ENCHANTMENT)
                    {
                        break;
                    }
                    return "Card_Play_Enchantment";
                }
                return GetNameWithFlair("Card_Play_Ally", flair);

            case TAG_ZONE.DECK:
            case TAG_ZONE.REMOVEDFROMGAME:
            case TAG_ZONE.SETASIDE:
                return "Card_Invisible";

            case TAG_ZONE.HAND:
                if ((controller == null) || (!controller.IsLocal() && !controller.HasTag(GAME_TAG.HAND_REVEALED)))
                {
                    return "Card_Hidden";
                }
                if (cardType == TAG_CARDTYPE.MINION)
                {
                    return GetNameWithFlair("Card_Hand_Ally", flair);
                }
                if (cardType == TAG_CARDTYPE.WEAPON)
                {
                    return GetNameWithFlair("Card_Hand_Weapon", flair);
                }
                if (cardType != TAG_CARDTYPE.ABILITY)
                {
                    break;
                }
                return GetNameWithFlair("Card_Hand_Ability", flair);

            case TAG_ZONE.GRAVEYARD:
                if (cardType != TAG_CARDTYPE.MINION)
                {
                    if (cardType == TAG_CARDTYPE.WEAPON)
                    {
                        return GetNameWithFlair("Card_Hand_Weapon", flair);
                    }
                    if (cardType == TAG_CARDTYPE.ABILITY)
                    {
                        return GetNameWithFlair("Card_Hand_Ability", flair);
                    }
                    if (cardType == TAG_CARDTYPE.HERO)
                    {
                        return "Card_Play_Hero";
                    }
                    break;
                }
                return GetNameWithFlair("Card_Hand_Ally", flair);

            case TAG_ZONE.SECRET:
                if (classTag != TAG_CLASS.HUNTER)
                {
                    if ((classTag != TAG_CLASS.MAGE) && (classTag == TAG_CLASS.PALADIN))
                    {
                        return "Card_Play_Secret_Paladin";
                    }
                    return "Card_Play_Secret_Mage";
                }
                return "Card_Play_Secret_Hunter";
        }
        Debug.LogWarning(string.Format("ActorNames.GetZoneActor() - Can't determine actor for {0}. Returning {1} instead.", cardType, "Card_Hand_Ally"));
        return "Card_Hand_Ally";
    }
}


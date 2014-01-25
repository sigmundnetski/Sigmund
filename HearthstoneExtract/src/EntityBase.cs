using System;
using System.Collections.Generic;

public abstract class EntityBase
{
    protected static readonly int[] HACK_MAX_CHARS_FOR_HERO_POWER = new int[] { 0x16, 0x16, 20 };
    protected static readonly int[] HACK_MAX_CHARS_FOR_MINION = new int[] { 0x1c, 30, 30, 0x17 };
    protected static readonly int[] HACK_MAX_CHARS_FOR_SPELL = new int[] { 0x17, 0x17, 0x17, 0x17 };
    protected const int HACK_MAX_CHARS_FOR_TARGETING_ARROW = 0x19;
    protected TagSet m_referenceTags = new TagSet();
    protected Dictionary<int, string> m_stringTags = new Dictionary<int, string>();
    protected TagSet m_tags = new TagSet();

    protected EntityBase()
    {
    }

    public bool CanAttack()
    {
        return !this.HasTag(GAME_TAG.CANT_ATTACK);
    }

    public bool CanBeAttacked()
    {
        return !this.HasTag(GAME_TAG.CANT_BE_ATTACKED);
    }

    public bool CanBeDamaged()
    {
        return ((!this.HasDivineShield() && !this.IsImmune()) && !this.HasTag(GAME_TAG.CANT_BE_DAMAGED));
    }

    public bool CanBeTargetedByAbilities()
    {
        return !this.HasTag(GAME_TAG.CANT_BE_TARGETED_BY_ABILITIES);
    }

    public bool CanBeTargetedByHeroPowers()
    {
        return !this.HasTag(GAME_TAG.CANT_BE_TARGETED_BY_HERO_POWERS);
    }

    public bool CanBeTargetedByOpponents()
    {
        return !this.HasTag(GAME_TAG.CANT_BE_TARGETED_BY_OPPONENTS);
    }

    public int GetArmor()
    {
        return this.GetTag(GAME_TAG.ARMOR);
    }

    public int GetATK()
    {
        return this.GetTag(GAME_TAG.ATK);
    }

    public int GetAttached()
    {
        return this.GetTag(GAME_TAG.ATTACHED);
    }

    public TAG_CARD_SET GetCardSet()
    {
        return this.GetTag<TAG_CARD_SET>(GAME_TAG.CARD_SET);
    }

    public TAG_CARDTYPE GetCardType()
    {
        return this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE);
    }

    public int GetControllerId()
    {
        return this.GetTag(GAME_TAG.CONTROLLER);
    }

    public int GetCost()
    {
        return this.GetTag(GAME_TAG.COST);
    }

    public int GetCreatorId()
    {
        return this.GetTag(GAME_TAG.CREATOR);
    }

    public int GetDamage()
    {
        return this.GetTag(GAME_TAG.DAMAGE);
    }

    public int GetDurability()
    {
        return this.GetTag(GAME_TAG.DURABILITY);
    }

    public int GetEntityId()
    {
        return this.GetTag(GAME_TAG.ENTITY_ID);
    }

    public int GetFatigue()
    {
        return this.GetTag(GAME_TAG.FATIGUE);
    }

    public int GetHealth()
    {
        if (this.IsWeapon())
        {
            return this.GetTag(GAME_TAG.DURABILITY);
        }
        return this.GetTag(GAME_TAG.HEALTH);
    }

    public int GetNumAttacksThisTurn()
    {
        return this.GetTag(GAME_TAG.NUM_ATTACKS_THIS_TURN);
    }

    public int GetNumTurnsInPlay()
    {
        return this.GetTag(GAME_TAG.NUM_TURNS_IN_PLAY);
    }

    public int GetReferencedTag(GAME_TAG enumTag)
    {
        return this.GetReferencedTag((int) enumTag);
    }

    public abstract int GetReferencedTag(int tag);
    public TagSet GetReferencedTagSet()
    {
        return this.m_referenceTags;
    }

    public int GetRemainingHP()
    {
        return (this.GetHealth() - this.GetDamage());
    }

    public int GetSpellPower()
    {
        return this.GetTag(GAME_TAG.SPELLPOWER);
    }

    public string GetStringTag(GAME_TAG enumTag)
    {
        return this.GetStringTag((int) enumTag);
    }

    public abstract string GetStringTag(int tag);
    public TagEnum GetTag<TagEnum>(GAME_TAG enumTag)
    {
        int tag = this.GetTag(enumTag);
        return (TagEnum) Enum.ToObject(typeof(TagEnum), tag);
    }

    public int GetTag(GAME_TAG enumTag)
    {
        int tag = Convert.ToInt32(enumTag);
        return this.m_tags.GetTag(tag);
    }

    public int GetTag(int tag)
    {
        return this.m_tags.GetTag(tag);
    }

    public TagSet GetTagSet()
    {
        return this.m_tags;
    }

    public TAG_ZONE GetZone()
    {
        return this.GetTag<TAG_ZONE>(GAME_TAG.ZONE);
    }

    public int GetZonePosition()
    {
        return this.GetTag(GAME_TAG.ZONE_POSITION);
    }

    public bool HasBattlecry()
    {
        return this.HasTag(GAME_TAG.BATTLECRY);
    }

    public bool HasCharge()
    {
        return this.HasTag(GAME_TAG.CHARGE);
    }

    public bool HasCombo()
    {
        return this.HasTag(GAME_TAG.COMBO);
    }

    public bool HasDeathrattle()
    {
        return this.HasTag(GAME_TAG.DEATH_RATTLE);
    }

    public bool HasDivineShield()
    {
        return (this.HasTag(GAME_TAG.DIVINE_SHIELD) || this.HasTag(GAME_TAG.DIVINE_SHIELD_READY));
    }

    public bool HasHealthMin()
    {
        return (this.GetTag(GAME_TAG.HEALTH_MINIMUM) > 0);
    }

    public bool HasRecall()
    {
        return this.HasTag(GAME_TAG.RECALL);
    }

    public bool HasReferencedTag(GAME_TAG enumTag)
    {
        return (this.GetReferencedTag(enumTag) > 0);
    }

    public bool HasSpellPower()
    {
        return this.HasTag(GAME_TAG.SPELLPOWER);
    }

    public bool HasStringTag(GAME_TAG enumTag)
    {
        return (this.GetStringTag(enumTag) != null);
    }

    public bool HasStringTag(int tag)
    {
        return (this.GetStringTag(tag) != null);
    }

    public bool HasTag(GAME_TAG tag)
    {
        return (this.GetTag(tag) > 0);
    }

    public bool HasTaunt()
    {
        return this.HasTag(GAME_TAG.TAUNT);
    }

    public bool HasTriggerVisual()
    {
        return this.HasTag(GAME_TAG.TRIGGER_VISUAL);
    }

    public bool HasWindfury()
    {
        return this.HasTag(GAME_TAG.WINDFURY);
    }

    public bool IsAbility()
    {
        return this.IsSpell();
    }

    public bool IsAsleep()
    {
        return ((this.GetNumTurnsInPlay() == 0) && !this.HasCharge());
    }

    public bool IsAttached()
    {
        return this.HasTag(GAME_TAG.ATTACHED);
    }

    public bool IsCard()
    {
        return ((!this.IsGame() && !this.IsPlayer()) && !this.IsHero());
    }

    public bool IsCharacter()
    {
        return (this.IsHero() || this.IsMinion());
    }

    public bool IsDamaged()
    {
        return (this.GetDamage() > 0);
    }

    public bool IsElite()
    {
        return (this.GetTag(GAME_TAG.ELITE) > 0);
    }

    public bool IsEnchantment()
    {
        return (((TAG_CARDTYPE) this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE)) == TAG_CARDTYPE.ENCHANTMENT);
    }

    public bool IsEnraged()
    {
        return (this.HasTag(GAME_TAG.ENRAGED) && (this.GetDamage() > 0));
    }

    public bool IsExhausted()
    {
        return this.HasTag(GAME_TAG.EXHAUSTED);
    }

    public bool IsFreeze()
    {
        return this.HasTag(GAME_TAG.FREEZE);
    }

    public bool IsFrozen()
    {
        return this.HasTag(GAME_TAG.FROZEN);
    }

    public bool IsGame()
    {
        return (((TAG_CARDTYPE) this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE)) == TAG_CARDTYPE.GAME);
    }

    public bool IsHero()
    {
        return (((TAG_CARDTYPE) this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE)) == TAG_CARDTYPE.HERO);
    }

    public bool IsHeroPower()
    {
        return (((TAG_CARDTYPE) this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE)) == TAG_CARDTYPE.HERO_POWER);
    }

    public bool IsImmune()
    {
        return this.HasTag(GAME_TAG.CANT_BE_DAMAGED);
    }

    public bool IsItem()
    {
        return (((TAG_CARDTYPE) this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE)) == TAG_CARDTYPE.ITEM);
    }

    public bool IsMagnet()
    {
        return this.HasTag(GAME_TAG.MAGNET);
    }

    public bool IsMinion()
    {
        return (((TAG_CARDTYPE) this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE)) == TAG_CARDTYPE.MINION);
    }

    public bool IsPlayer()
    {
        return (((TAG_CARDTYPE) this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE)) == TAG_CARDTYPE.PLAYER);
    }

    public bool IsPower()
    {
        return (this.IsAbility() || this.IsEnchantment());
    }

    public bool IsRecentlyArrived()
    {
        return this.HasTag(GAME_TAG.RECENTLY_ARRIVED);
    }

    public bool IsSecret()
    {
        return this.HasTag(GAME_TAG.SECRET);
    }

    public bool IsSilenced()
    {
        return this.HasTag(GAME_TAG.SILENCED);
    }

    public bool IsSpell()
    {
        return (((TAG_CARDTYPE) this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE)) == TAG_CARDTYPE.ABILITY);
    }

    public bool IsStealthed()
    {
        return this.HasTag(GAME_TAG.STEALTH);
    }

    public bool IsToken()
    {
        return (((TAG_CARDTYPE) this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE)) == TAG_CARDTYPE.TOKEN);
    }

    public bool IsWeapon()
    {
        return (((TAG_CARDTYPE) this.GetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE)) == TAG_CARDTYPE.WEAPON);
    }

    public bool ReferencesBattlecry()
    {
        return this.HasReferencedTag(GAME_TAG.BATTLECRY);
    }

    public bool ReferencesCharge()
    {
        return this.HasReferencedTag(GAME_TAG.CHARGE);
    }

    public bool ReferencesDeathrattle()
    {
        return this.HasReferencedTag(GAME_TAG.DEATH_RATTLE);
    }

    public bool ReferencesDivineShield()
    {
        return (this.HasReferencedTag(GAME_TAG.DIVINE_SHIELD) || this.HasReferencedTag(GAME_TAG.DIVINE_SHIELD_READY));
    }

    public bool ReferencesImmune()
    {
        return this.HasReferencedTag(GAME_TAG.CANT_BE_DAMAGED);
    }

    public bool ReferencesSecret()
    {
        return this.HasReferencedTag(GAME_TAG.SECRET);
    }

    public bool ReferencesSpellPower()
    {
        return this.HasReferencedTag(GAME_TAG.SPELLPOWER);
    }

    public bool ReferencesStealth()
    {
        return this.HasReferencedTag(GAME_TAG.STEALTH);
    }

    public bool ReferencesTaunt()
    {
        return this.HasReferencedTag(GAME_TAG.TAUNT);
    }

    public bool ReferencesWindfury()
    {
        return this.HasReferencedTag(GAME_TAG.WINDFURY);
    }

    public void SetReferencedTag(GAME_TAG enumTag, int val)
    {
        this.SetReferencedTag((int) enumTag, val);
    }

    public void SetReferencedTag(int tag, int val)
    {
        this.m_referenceTags.SetTag(tag, val);
    }

    public void SetStringTag(GAME_TAG enumTag, string val)
    {
        this.SetStringTag((int) enumTag, val);
    }

    public void SetStringTag(int tag, string val)
    {
        this.m_stringTags[tag] = val;
    }

    public void SetTag(GAME_TAG tag, int tagValue)
    {
        this.SetTag((int) tag, tagValue);
    }

    public void SetTag<TagEnum>(GAME_TAG tag, TagEnum tagValue)
    {
        this.SetTag((int) tag, Convert.ToInt32(tagValue));
    }

    public void SetTag(int tag, int tagValue)
    {
        this.m_tags.SetTag(tag, tagValue);
    }
}


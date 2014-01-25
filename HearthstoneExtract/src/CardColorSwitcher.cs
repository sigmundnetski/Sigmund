using System;
using UnityEngine;

public class CardColorSwitcher : MonoBehaviour
{
    public Texture[] minionCardTextures;
    public Texture[] premiumMinionCardTextures;
    private static CardColorSwitcher s_instance;
    public Texture[] spellCardTextures;
    public Texture[] weaponCardTextures;

    private void Awake()
    {
        s_instance = this;
    }

    public static CardColorSwitcher Get()
    {
        return s_instance;
    }

    public Texture GetMinionTexture(CardColorType colorType)
    {
        int index = (int) colorType;
        if (this.minionCardTextures.Length <= index)
        {
            return null;
        }
        if (this.minionCardTextures[index] == null)
        {
            return null;
        }
        return this.minionCardTextures[index];
    }

    public Texture GetPremiumMinionTexture(CardColorType colorType)
    {
        int index = (int) colorType;
        if (this.premiumMinionCardTextures.Length <= index)
        {
            return null;
        }
        if (this.premiumMinionCardTextures[index] == null)
        {
            return null;
        }
        return this.premiumMinionCardTextures[index];
    }

    public Texture GetSpellTexture(CardColorType colorType)
    {
        int index = (int) colorType;
        if (this.spellCardTextures.Length <= index)
        {
            return null;
        }
        if (this.spellCardTextures[index] == null)
        {
            return null;
        }
        return this.spellCardTextures[index];
    }

    public Texture GetWeaponTexture(CardColorType colorType)
    {
        int index = (int) colorType;
        if (this.weaponCardTextures.Length <= index)
        {
            return null;
        }
        if (this.weaponCardTextures[index] == null)
        {
            return null;
        }
        return this.weaponCardTextures[index];
    }

    public enum CardColorType
    {
        TYPE_GENERIC,
        TYPE_WARLOCK,
        TYPE_ROGUE,
        TYPE_DRUID,
        TYPE_SHAMAN,
        TYPE_HUNTER,
        TYPE_MAGE,
        TYPE_PALADIN,
        TYPE_PRIEST,
        TYPE_WARRIOR
    }
}


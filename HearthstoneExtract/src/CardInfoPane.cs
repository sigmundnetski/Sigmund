using System;
using UnityEngine;

public class CardInfoPane : MonoBehaviour
{
    public UberText m_artistName;
    public Material m_basicMaterial;
    public Material m_commonMaterial;
    public Material m_epicMaterial;
    public UberText m_flavorText;
    public Material m_legendaryMaterial;
    public Material m_rareMaterial;
    public RarityGem m_rarityGem;
    public TextMesh m_rarityLabel;
    public TextMesh m_setName;

    private void AssignRarityColors(TAG_RARITY rarity, TAG_CARD_SET cardSet)
    {
        if (cardSet == TAG_CARD_SET.CORE)
        {
            this.m_rarityLabel.renderer.material = this.m_basicMaterial;
        }
        else
        {
            switch (rarity)
            {
                case TAG_RARITY.RARE:
                    this.m_rarityLabel.renderer.material = this.m_rareMaterial;
                    return;

                case TAG_RARITY.EPIC:
                    this.m_rarityLabel.renderer.material = this.m_epicMaterial;
                    return;

                case TAG_RARITY.LEGENDARY:
                    this.m_rarityLabel.renderer.material = this.m_legendaryMaterial;
                    return;
            }
            this.m_rarityLabel.renderer.material = this.m_commonMaterial;
        }
    }

    public void UpdateText()
    {
        EntityDef def;
        CardFlair flair;
        if (CraftingManager.Get().GetShownCardInfo(out def, out flair))
        {
            TAG_RARITY rarity = def.GetRarity();
            TAG_CARD_SET cardSet = def.GetCardSet();
            if (cardSet == TAG_CARD_SET.CORE)
            {
                this.m_rarityLabel.text = string.Empty;
            }
            else
            {
                this.m_rarityLabel.text = GameStrings.Get("GLOBAL_RARITY_" + rarity.ToString());
            }
            this.AssignRarityColors(rarity, cardSet);
            this.m_rarityGem.SetRarityGem(rarity, cardSet);
            this.m_setName.text = GameStrings.Get("GLOBAL_SET_" + cardSet.ToString());
            this.m_artistName.Text = GameStrings.Get("GLUE_COLLECTION_ARTIST") + ": " + def.GetArtistName();
            this.m_flavorText.Text = def.GetFlavorText();
        }
    }
}


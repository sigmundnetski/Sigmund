using System;
using UnityEngine;

public class HistoryInfo
{
    public int armorChangeAmount;
    private Card baseCard;
    public int damageChangeAmount;
    public bool died;
    public HistoryInfoType infoType;
    public Material m_bigCardGoldenMaterial;
    public Texture m_bigCardPortraitTexture;
    private Entity m_duplicatedEntity;
    private Entity m_originalEntity;
    public string replacementText;

    public bool CanLoadInfo()
    {
        if (this.infoType != HistoryInfoType.FATIGUE)
        {
            if (!this.m_originalEntity.IsCardReady())
            {
                return false;
            }
            if (!this.m_originalEntity.IsSecret() && this.m_originalEntity.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public Card GetCard()
    {
        return this.baseCard;
    }

    public Entity GetDuplicatedEntity()
    {
        return this.m_duplicatedEntity;
    }

    public Entity GetOriginalEntity()
    {
        return this.m_originalEntity;
    }

    public int GetSplatAmount()
    {
        return (this.damageChangeAmount + this.armorChangeAmount);
    }

    public void LoadInfo()
    {
        if (this.m_duplicatedEntity == null)
        {
            this.baseCard = this.m_originalEntity.GetCard();
            if (this.baseCard != null)
            {
                this.m_bigCardPortraitTexture = this.baseCard.GetPortraitTexture();
                this.m_bigCardGoldenMaterial = this.baseCard.GetGoldenMaterial();
            }
            this.m_duplicatedEntity = this.m_originalEntity.CloneForHistory();
            if (this.replacementText != null)
            {
                this.m_duplicatedEntity.SetStringTag(GAME_TAG.CARDTEXT_INHAND, this.replacementText);
            }
        }
    }

    public void SetOriginalEntity(Entity entity)
    {
        this.m_originalEntity = entity;
    }
}


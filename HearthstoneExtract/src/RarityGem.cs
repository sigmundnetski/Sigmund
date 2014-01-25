using System;
using UnityEngine;

public class RarityGem : MonoBehaviour
{
    public void SetRarityGem(TAG_RARITY rarity, TAG_CARD_SET cardSet)
    {
        if (cardSet == TAG_CARD_SET.CORE)
        {
            base.renderer.enabled = false;
        }
        else
        {
            base.renderer.enabled = true;
            switch (rarity)
            {
                case TAG_RARITY.RARE:
                    base.renderer.material.mainTextureOffset = new Vector2(0.118f, 0f);
                    return;

                case TAG_RARITY.EPIC:
                    base.renderer.material.mainTextureOffset = new Vector2(0.239f, 0f);
                    return;

                case TAG_RARITY.LEGENDARY:
                    base.renderer.material.mainTextureOffset = new Vector2(0.3575f, 0f);
                    return;
            }
            base.renderer.material.mainTextureOffset = new Vector2(0f, 0f);
        }
    }
}


using System;
using UnityEngine;

public class BigCardEnchantmentPanel : MonoBehaviour
{
    public Actor m_Actor;
    public GameObject m_Background;
    public UberText m_BodyText;
    private Entity m_enchantment;
    public UberText m_HeaderText;
    private float m_initialBackgroundHeight;
    private Vector3 m_initialBackgroundScale;
    private Vector3 m_initialScale;
    private bool m_shown;

    private void Awake()
    {
        this.m_initialScale = base.transform.localScale;
        this.m_initialBackgroundHeight = this.m_Background.GetComponentInChildren<MeshRenderer>().bounds.size.z;
        this.m_initialBackgroundScale = this.m_Background.transform.localScale;
    }

    public float GetHeight()
    {
        return this.m_Background.GetComponentInChildren<MeshRenderer>().bounds.size.z;
    }

    public void Hide()
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            base.gameObject.SetActive(false);
        }
    }

    public bool IsShown()
    {
        return this.m_shown;
    }

    private void OnCardDefLoaded(string cardId, CardDef cardDef, object callbackData)
    {
        if (cardDef != null)
        {
            if (cardDef.m_EnchantmentPortrait != null)
            {
                this.m_Actor.GetMeshRenderer().material = cardDef.m_EnchantmentPortrait;
            }
            else
            {
                this.m_Actor.SetPortraitTexture(cardDef.m_PortraitTexture);
            }
        }
        this.m_HeaderText.Text = this.m_enchantment.GetName();
        this.m_BodyText.Text = this.m_enchantment.GetRawCardTextInHand();
    }

    public void SetEnchantment(Entity enchantment)
    {
        this.m_enchantment = enchantment;
        string cardId = this.m_enchantment.GetCardId();
        DefLoader.Get().LoadCardDef(cardId, new DefLoader.LoadDefCallback<CardDef>(this.OnCardDefLoaded));
    }

    public void Show()
    {
        if (!this.m_shown)
        {
            this.m_shown = true;
            base.gameObject.SetActive(true);
            this.UpdateLayout();
        }
    }

    private void UpdateLayout()
    {
        this.m_HeaderText.UpdateNow();
        this.m_BodyText.UpdateNow();
        Bounds bounds = this.m_Actor.GetMeshRenderer().bounds;
        Bounds textWorldSpaceBounds = this.m_HeaderText.GetTextWorldSpaceBounds();
        Bounds bounds3 = this.m_BodyText.GetTextWorldSpaceBounds();
        float z = bounds.min.z;
        float a = bounds.max.z;
        float b = textWorldSpaceBounds.min.z;
        float num5 = textWorldSpaceBounds.max.z;
        float num6 = bounds3.min.z;
        float num7 = bounds3.max.z;
        float num8 = Mathf.Min(Mathf.Min(z, b), num6);
        float num10 = (Mathf.Max(Mathf.Max(a, num5), num7) - num8) + 0.1f;
        base.transform.localScale = this.m_initialScale;
        TransformUtil.SetLocalScaleZ(this.m_Background, this.m_initialBackgroundScale.z * (num10 / this.m_initialBackgroundHeight));
    }
}


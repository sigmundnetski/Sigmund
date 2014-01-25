using System;
using UnityEngine;

public class CardTypeBanner : MonoBehaviour
{
    public GameObject m_minionBanner;
    public GameObject m_root;
    public GameObject m_spellBanner;
    public TextMesh m_text;
    public GameObject m_weaponBanner;
    private readonly Color MINION_COLOR = new Color(0.1529412f, 0.1254902f, 0.03529412f);
    private static Actor s_actor;
    private static CardTypeBanner s_instance;
    private static bool s_isShown;
    private readonly Color SPELL_COLOR = new Color(0.8745098f, 0.7882353f, 0.5254902f);
    private readonly Color WEAPON_COLOR = new Color(0.8745098f, 0.7882353f, 0.5254902f);

    private void Awake()
    {
        s_instance = this;
        if (s_isShown)
        {
            this.ShowImpl();
        }
        else
        {
            this.HideImpl();
        }
    }

    public static CardTypeBanner Get()
    {
        return s_instance;
    }

    public static void Hide()
    {
        s_isShown = false;
        s_actor = null;
        if (s_instance != null)
        {
            s_instance.HideImpl();
        }
    }

    private void HideImpl()
    {
        this.m_root.gameObject.SetActive(false);
    }

    public static void Show(Actor a)
    {
        s_isShown = true;
        s_actor = a;
        if (s_instance != null)
        {
            s_instance.ShowImpl();
        }
    }

    private void ShowImpl()
    {
        this.m_root.gameObject.SetActive(true);
        TAG_CARDTYPE cardType = s_actor.GetEntity().GetCardType();
        this.m_text.gameObject.SetActive(true);
        this.m_text.text = GameStrings.GetCardTypeName(cardType);
        switch (cardType)
        {
            case TAG_CARDTYPE.MINION:
                this.m_text.renderer.material.color = this.MINION_COLOR;
                this.m_minionBanner.SetActive(true);
                break;

            case TAG_CARDTYPE.ABILITY:
                this.m_text.renderer.material.color = this.SPELL_COLOR;
                this.m_spellBanner.SetActive(true);
                break;

            case TAG_CARDTYPE.WEAPON:
                this.m_text.renderer.material.color = this.WEAPON_COLOR;
                this.m_weaponBanner.SetActive(true);
                break;
        }
        this.UpdatePosition();
    }

    private void Update()
    {
        if (s_actor != null)
        {
            this.UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        GameObject cardTypeBannerAnchor = s_actor.GetCardTypeBannerAnchor();
        this.m_root.transform.position = cardTypeBannerAnchor.transform.position;
    }
}


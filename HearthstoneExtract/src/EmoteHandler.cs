using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EmoteHandler : MonoBehaviour
{
    public Material blackTextMatieral;
    private int chainedEmotes;
    private bool emotesDisplayed;
    public Material greyTextMaterial;
    public List<EmoteOption> m_emotes;
    private const float MIN_TIME_BETWEEN_EMOTES = 4f;
    private EmoteOption mousedOverEmote;
    private const int NUM_CHAIN_EMOTES_BEFORE_CONSIDERED_SPAM = 2;
    private const int NUM_EMOTES_BEFORE_CONSIDERED_A_SPAMMER = 20;
    private const int NUM_EMOTES_BEFORE_CONSIDERED_UBER_SPAMMER = 0x19;
    private static EmoteHandler s_instance;
    private int shownAt;
    private const float SPAMMER_MIN_TIME_BETWEEN_EMOTES = 15f;
    private const float TIME_BEFORE_EMOTES_APPEAR = 1.5f;
    private const float TIME_WINDOW_TO_BE_CONSIDERED_A_CHAIN = 5f;
    private float timeSinceLastEmote = 4f;
    private int totalEmotes;
    private const float UBER_SPAMMER_MIN_TIME_BETWEEN_EMOTES = 45f;

    public bool AreEmotesActive()
    {
        return this.emotesDisplayed;
    }

    private void Awake()
    {
        s_instance = this;
        base.collider.enabled = false;
    }

    public bool EmoteSpamBlocked()
    {
        if (this.totalEmotes >= 0x19)
        {
            return (this.timeSinceLastEmote < 45f);
        }
        if (this.totalEmotes >= 20)
        {
            return (this.timeSinceLastEmote < 15f);
        }
        if (this.chainedEmotes >= 2)
        {
            return (this.timeSinceLastEmote < 15f);
        }
        return (this.timeSinceLastEmote < 4f);
    }

    public static EmoteHandler Get()
    {
        return s_instance;
    }

    public void HandleInput()
    {
        RaycastHit hit;
        if (!this.HitTestEmotes(out hit))
        {
            this.HideEmotes();
        }
        else
        {
            EmoteOption component = hit.transform.gameObject.GetComponent<EmoteOption>();
            if (component == null)
            {
                if (this.mousedOverEmote != null)
                {
                    this.mousedOverEmote.HandleMouseOut();
                    this.mousedOverEmote = null;
                }
            }
            else if (this.mousedOverEmote == null)
            {
                this.mousedOverEmote = component;
                this.mousedOverEmote.HandleMouseOver();
            }
            else if (this.mousedOverEmote != component)
            {
                this.mousedOverEmote.HandleMouseOut();
                this.mousedOverEmote = component;
                component.HandleMouseOver();
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (this.mousedOverEmote != null)
                {
                    if (!this.EmoteSpamBlocked())
                    {
                        this.totalEmotes++;
                        this.mousedOverEmote.DoClick();
                    }
                }
                else if ((UniversalInputManager.IsTouchDevice != null) && (UnityEngine.Time.frameCount != this.shownAt))
                {
                    this.HideEmotes();
                }
            }
        }
    }

    public void HideEmotes()
    {
        if (this.emotesDisplayed)
        {
            this.mousedOverEmote = null;
            this.emotesDisplayed = false;
            base.collider.enabled = false;
            foreach (EmoteOption option in this.m_emotes)
            {
                option.Disable();
            }
        }
    }

    private bool HitTestEmotes(out RaycastHit hitInfo)
    {
        if (!UniversalInputManager.Get().GetInputHitInfo(GameLayer.CardRaycast.LayerBit(), out hitInfo))
        {
            return false;
        }
        return (this.IsMousedOverHero(hitInfo) || (this.IsMousedOverSelf(hitInfo) || this.IsMousedOverEmote(hitInfo)));
    }

    private bool IsMousedOverEmote(RaycastHit cardHitInfo)
    {
        foreach (EmoteOption option in this.m_emotes)
        {
            if (cardHitInfo.transform == option.transform)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsMousedOverHero(RaycastHit cardHitInfo)
    {
        Actor actor = SceneUtils.FindComponentInParents<Actor>(cardHitInfo.transform);
        if (actor == null)
        {
            return false;
        }
        Card card = actor.GetCard();
        if (card == null)
        {
            return false;
        }
        return card.GetEntity().IsHero();
    }

    private bool IsMousedOverSelf(RaycastHit cardHitInfo)
    {
        return (base.collider == cardHitInfo.collider);
    }

    public bool IsMouseOverEmoteOption()
    {
        RaycastHit hit;
        return (UniversalInputManager.Get().GetInputHitInfo(GameLayer.GeneralUI.LayerBit(), out hit) && (hit.transform.gameObject.GetComponent<EmoteOption>() != null));
    }

    public void ResetTimeSinceLastEmote()
    {
        if (this.timeSinceLastEmote < 9f)
        {
            this.chainedEmotes++;
        }
        else
        {
            this.chainedEmotes = 0;
        }
        this.timeSinceLastEmote = 0f;
    }

    public void ShowEmotes()
    {
        if (!this.emotesDisplayed)
        {
            this.shownAt = UnityEngine.Time.frameCount;
            this.emotesDisplayed = true;
            base.collider.enabled = true;
            foreach (EmoteOption option in this.m_emotes)
            {
                option.Enable();
            }
        }
    }

    private void Update()
    {
        this.timeSinceLastEmote += UnityEngine.Time.deltaTime;
    }
}


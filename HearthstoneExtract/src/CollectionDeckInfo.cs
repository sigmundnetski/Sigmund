using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionDeckInfo : MonoBehaviour
{
    private long m_deckID;
    private Actor m_heroPowerActor;
    public UberText m_heroPowerDescription;
    private string m_heroPowerID = string.Empty;
    public UberText m_heroPowerName;
    public GameObject m_heroPowerParent;
    public List<DeckInfoManaBar> m_manaBars;
    public UberText m_manaCurveTooltipText;
    public GameObject m_root;
    private readonly float MANA_COST_TEXT_MAX_LOCAL_Z = 5.167298f;
    private readonly float MANA_COST_TEXT_MIN_LOCAL_Z;
    private readonly int MAX_MANA_COST_ID = 7;
    private readonly int MIN_MANA_COST_ID;

    private void Awake()
    {
        this.m_manaCurveTooltipText.Text = GameStrings.Get("GLUE_COLLECTION_DECK_INFO_MANA_TOOLTIP");
        foreach (DeckInfoManaBar bar in this.m_manaBars)
        {
            bar.m_costText.Text = this.GetTextForManaCost(bar.m_manaCostID);
        }
        AssetLoader.Get().LoadActor("Card_Play_HeroPower", new AssetLoader.GameObjectCallback(this.OnHeroPowerActorLoaded));
    }

    private string GetTextForManaCost(int manaCostID)
    {
        if ((manaCostID < this.MIN_MANA_COST_ID) || (manaCostID > this.MAX_MANA_COST_ID))
        {
            UnityEngine.Debug.LogWarning(string.Format("CollectionDeckInfo.GetTextForManaCost(): don't know how to handle mana cost ID {0}", manaCostID));
            return string.Empty;
        }
        string str = Convert.ToString(manaCostID);
        if (manaCostID == this.MAX_MANA_COST_ID)
        {
            str = str + GameStrings.Get("GLUE_COLLECTION_PLUS");
        }
        return str;
    }

    public void Hide()
    {
        this.m_root.SetActive(false);
    }

    private void OnHeroPowerActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("CollectionDeckInfo.OnHeroPowerActorLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            this.m_heroPowerActor = actorObject.GetComponent<Actor>();
            if (this.m_heroPowerActor == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("CollectionDeckInfo.OnHeroPowerActorLoaded() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                this.m_heroPowerActor.transform.parent = this.m_heroPowerParent.transform;
                this.m_heroPowerActor.transform.localScale = Vector3.one;
                this.m_heroPowerActor.transform.localPosition = Vector3.zero;
            }
        }
    }

    private void OnHeroPowerFullDefLoaded(string cardID, FullDef def, object userData)
    {
        if (this.m_heroPowerActor != null)
        {
            this.SetHeroPowerInfo(cardID, def);
        }
        else
        {
            base.StartCoroutine(this.SetHeroPowerInfoWhenReady(cardID, def));
        }
    }

    public void SetDeckID(long deckID)
    {
        if (this.m_deckID != deckID)
        {
            this.m_deckID = deckID;
            CollectionDeck deck = CollectionManager.Get().GetDeck(this.m_deckID);
            if (deck == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("CollectionDeckInfo.SetDeckID(): deck is null for deck ID {0}", this.m_deckID));
            }
            else
            {
                this.UpdateManaCurve();
                string heroPowerID = CollectibleHero.GetHeroPowerID(DefLoader.Get().GetEntityDef(deck.HeroCardID).GetClass());
                if (string.IsNullOrEmpty(heroPowerID))
                {
                    UnityEngine.Debug.LogWarning("CollectionDeckInfo.UpdateInfo(): invalid hero power ID");
                    this.m_heroPowerID = string.Empty;
                }
                else if (!heroPowerID.Equals(this.m_heroPowerID))
                {
                    this.m_heroPowerID = heroPowerID;
                    DefLoader.Get().LoadFullDef(this.m_heroPowerID, new DefLoader.LoadDefCallback<FullDef>(this.OnHeroPowerFullDefLoaded));
                }
            }
        }
    }

    private void SetHeroPowerInfo(string heroPowerCardID, FullDef def)
    {
        if (heroPowerCardID.Equals(this.m_heroPowerID))
        {
            EntityDef entityDef = def.GetEntityDef();
            this.m_heroPowerActor.SetEntityDef(def.GetEntityDef());
            this.m_heroPowerActor.SetCardDef(def.GetCardDef());
            this.m_heroPowerActor.UpdateAllComponents();
            string name = entityDef.GetName();
            this.m_heroPowerName.Text = name;
            string cardTextInHand = entityDef.GetCardTextInHand();
            this.m_heroPowerDescription.Text = cardTextInHand;
        }
    }

    [DebuggerHidden]
    private IEnumerator SetHeroPowerInfoWhenReady(string heroPowerCardID, FullDef def)
    {
        return new <SetHeroPowerInfoWhenReady>c__Iterator3 { heroPowerCardID = heroPowerCardID, def = def, <$>heroPowerCardID = heroPowerCardID, <$>def = def, <>f__this = this };
    }

    public void Show()
    {
        this.m_root.SetActive(true);
    }

    public void UpdateManaCurve()
    {
        CollectionDeck deck = CollectionManager.Get().GetDeck(this.m_deckID);
        if (deck == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("CollectionDeckInfo.UpdateManaCurve(): deck is null for deck ID {0}", this.m_deckID));
        }
        else
        {
            foreach (DeckInfoManaBar bar in this.m_manaBars)
            {
                bar.m_numCards = 0;
            }
            int numCards = 0;
            foreach (CollectionDeckSlot slot in deck.GetSlots())
            {
                <UpdateManaCurve>c__AnonStorey128 storey = new <UpdateManaCurve>c__AnonStorey128();
                EntityDef entityDef = DefLoader.Get().GetEntityDef(slot.CardID);
                storey.manaCost = entityDef.GetCost();
                if (storey.manaCost > this.MAX_MANA_COST_ID)
                {
                    storey.manaCost = this.MAX_MANA_COST_ID;
                }
                DeckInfoManaBar bar2 = this.m_manaBars.Find(new Predicate<DeckInfoManaBar>(storey.<>m__17));
                if (bar2 == null)
                {
                    UnityEngine.Debug.LogWarning(string.Format("CollectionDeckInfo.UpdateManaCurve(): Cannot update curve. Could not find mana bar for {0} (cost {1})", entityDef, storey.manaCost));
                    return;
                }
                bar2.m_numCards += slot.Count;
                if (bar2.m_numCards > numCards)
                {
                    numCards = bar2.m_numCards;
                }
            }
            foreach (DeckInfoManaBar bar3 in this.m_manaBars)
            {
                bar3.m_numCardsText.Text = Convert.ToString(bar3.m_numCards);
                float t = (numCards != 0) ? (((float) bar3.m_numCards) / ((float) numCards)) : 0f;
                Vector3 localPosition = bar3.m_numCardsText.transform.localPosition;
                localPosition.z = Mathf.Lerp(this.MANA_COST_TEXT_MIN_LOCAL_Z, this.MANA_COST_TEXT_MAX_LOCAL_Z, t);
                bar3.m_numCardsText.transform.localPosition = localPosition;
                bar3.m_barFill.renderer.material.SetFloat("_Percent", t);
            }
        }
    }

    [CompilerGenerated]
    private sealed class <SetHeroPowerInfoWhenReady>c__Iterator3 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal FullDef <$>def;
        internal string <$>heroPowerCardID;
        internal CollectionDeckInfo <>f__this;
        internal FullDef def;
        internal string heroPowerCardID;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                case 1:
                    if (this.<>f__this.m_heroPowerActor == null)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<>f__this.SetHeroPowerInfo(this.heroPowerCardID, this.def);
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <UpdateManaCurve>c__AnonStorey128
    {
        internal int manaCost;

        internal bool <>m__17(DeckInfoManaBar obj)
        {
            return (obj.m_manaCostID == this.manaCost);
        }
    }
}


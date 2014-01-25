using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DraftDeckTray : MonoBehaviour
{
    private List<DraftDeckTileVisual> m_deckTiles = new List<DraftDeckTileVisual>();
    private DeckTray m_deckTray;
    private Mode m_mode;
    private static DraftDeckTray s_instance;

    private void Awake()
    {
        s_instance = this;
        AssetLoader.Get().LoadGameObject("DeckTray", new AssetLoader.GameObjectCallback(this.OnDeckTrayLoaded));
    }

    private void ClearAllDeckTiles()
    {
        foreach (DraftDeckTileVisual visual in this.m_deckTiles)
        {
            UnityEngine.Object.Destroy(visual.gameObject);
        }
        this.m_deckTiles.Clear();
        this.m_deckTray.m_scrollbar.Hide();
    }

    [DebuggerHidden]
    private IEnumerator DeckEffects()
    {
        return new <DeckEffects>c__Iterator25 { <>f__this = this };
    }

    public void DoDeckCompleteEffects()
    {
        base.StartCoroutine(this.DeckEffects());
    }

    public static DraftDeckTray Get()
    {
        return s_instance;
    }

    public DeckBigCard GetDeckBigCard()
    {
        return this.m_deckTray.GetDeckBigCard();
    }

    private DraftDeckTileVisual GetDeckTileVisual(int index)
    {
        if (index == this.m_deckTiles.Count)
        {
            DraftDeckTileVisual item = new GameObject("DeckTileVisual" + index) { transform = { parent = this.m_deckTray.m_cardContainer.transform, localScale = new Vector3(0.01f, 0.02f, 0.01f) } }.AddComponent<DraftDeckTileVisual>();
            this.m_deckTiles.Insert(index, item);
            return item;
        }
        return this.m_deckTiles[index];
    }

    public DraftDeckTileVisual GetDeckTileVisual(string cardID)
    {
        foreach (DraftDeckTileVisual visual in this.m_deckTiles)
        {
            if ((((visual != null) && (visual.GetActor() != null)) && (visual.GetActor().GetEntityDef() != null)) && (visual.GetActor().GetEntityDef().GetCardId() == cardID))
            {
                return visual;
            }
        }
        return null;
    }

    public void InitDeckTrayContents()
    {
        CollectionDeck draftDeck = DraftManager.Get().GetDraftDeck();
        if (draftDeck == null)
        {
            Log.Rachelle.Print("DraftDeckTray.OnDeckContentsReceived() - draftDeck is null!");
        }
        else if (!string.IsNullOrEmpty(draftDeck.HeroCardID))
        {
            this.UpdateCardList(string.Empty);
        }
    }

    public bool IsLoaded()
    {
        return (this.m_deckTray != null);
    }

    public bool MouseIsOver()
    {
        if (!this.IsLoaded())
        {
            return false;
        }
        return this.m_deckTray.MouseIsOver();
    }

    public void OnCardAdded(string cardID)
    {
        this.UpdateCardList(cardID);
    }

    private void OnDeckTrayLoaded(string actorName, GameObject gameObject, object callbackData)
    {
        if (gameObject == null)
        {
            UnityEngine.Debug.LogError("DraftDeckTray.OnDeckTrayLoaded(): gameObject is null");
        }
        else
        {
            this.m_deckTray = gameObject.GetComponent<DeckTray>();
            if (this.m_deckTray == null)
            {
                UnityEngine.Debug.LogError("DraftDeckTray.OnDeckTrayLoadeD(): gameObject does not contain DeckTray component");
            }
            else
            {
                this.m_deckTray.transform.parent = base.transform;
                this.m_deckTray.transform.localPosition = Vector3.zero;
                this.m_deckTray.m_cardContainer.transform.localPosition = this.m_deckTray.m_topCardPositionBone.transform.localPosition;
                Vector3 localPosition = this.m_deckTray.m_deckBigCard.transform.localPosition;
                localPosition.z = -0.04603473f;
                this.m_deckTray.m_deckBigCard.transform.localPosition = localPosition;
                this.m_deckTray.m_scrollbar.Hide();
                this.m_deckTray.m_scrollbar.Init(this.m_deckTray.m_cardContainer, true);
                this.m_deckTray.m_scrollbar.m_thumb.RegisterStartDraggingListener(new ScrollBarThumb.DelStartDraggingListener(DraftInputManager.Get().SetScrollbar));
                this.m_deckTray.m_doneButton.gameObject.SetActive(false);
                this.m_deckTray.m_deckContainer.gameObject.SetActive(false);
                this.m_deckTray.AllowInput(true);
                this.m_deckTray.SetMyDecksLabelText(GameStrings.Get("GLUE_DRAFT_NO_DECK_LABEL"));
            }
        }
    }

    public void SetMode(Mode mode)
    {
        bool flag = this.m_mode != mode;
        this.m_mode = mode;
        this.UpdateCardCount();
        if (flag)
        {
            string str;
            Mode mode2 = this.m_mode;
            if (mode2 == Mode.NO_DRAFT_DECK)
            {
                str = GameStrings.Get("GLUE_DRAFT_NO_DECK_LABEL");
            }
            else if (mode2 == Mode.DRAFT_DECK_CHOOSE_HERO)
            {
                str = GameStrings.Get("GLUE_DRAFT_CHOOSE_HERO_LABEL");
            }
            else
            {
                str = string.Empty;
            }
            this.m_deckTray.SetMyDecksLabelText(str);
            if (this.m_mode == Mode.NO_DRAFT_DECK)
            {
                this.ClearAllDeckTiles();
            }
        }
    }

    public void Unload()
    {
        this.m_deckTray.m_scrollbar.m_thumb.RemoveStartDraggingListener(new ScrollBarThumb.DelStartDraggingListener(DraftInputManager.Get().SetScrollbar));
    }

    private void UpdateCardCount()
    {
        if (this.IsLoaded())
        {
            switch (this.m_mode)
            {
                case Mode.DRAFT_DECK_BUILDING:
                case Mode.DRAFT_DECK_COMPLETE:
                    this.m_deckTray.SetCardCount(DraftManager.Get().GetDraftDeck().GetTotalCardCount());
                    break;

                default:
                    this.m_deckTray.ClearCountLabels();
                    break;
            }
        }
    }

    private void UpdateCardList(string justChangedCardID)
    {
        foreach (DraftDeckTileVisual visual in this.m_deckTiles)
        {
            visual.MarkAsUnused();
        }
        CollectionDeck draftDeck = DraftManager.Get().GetDraftDeck();
        if (draftDeck == null)
        {
            Log.Rachelle.Print("DraftDeckTray.UpdateCardList() - draftDeck == null");
        }
        else
        {
            List<CollectionDeckSlot> slots = draftDeck.GetSlots();
            for (int i = 0; i < slots.Count; i++)
            {
                CollectionDeckSlot s = slots[i];
                if (s.Count == 0)
                {
                    Log.Rachelle.Print(string.Format("DraftDeckTray.UpdateCardList(): Slot {0} of deck is empty! Skipping...", i));
                }
                else
                {
                    DraftDeckTileVisual deckTileVisual = this.GetDeckTileVisual(i);
                    deckTileVisual.gameObject.transform.localPosition = new Vector3(0f, -s.Index * DeckTray.DECK_SLOT_HEIGHT, 0f);
                    deckTileVisual.MarkAsUsed();
                    deckTileVisual.Show();
                    deckTileVisual.SetSlot(s, justChangedCardID.Equals(s.CardID));
                }
            }
            foreach (DraftDeckTileVisual visual3 in this.m_deckTiles)
            {
                if (!visual3.IsInUse())
                {
                    visual3.Hide();
                }
            }
            this.m_deckTray.m_scrollbar.UpdateScrollAreaBounds();
        }
    }

    [CompilerGenerated]
    private sealed class <DeckEffects>c__Iterator25 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<DraftDeckTileVisual>.Enumerator <$s_204>__0;
        internal DraftDeckTray <>f__this;
        internal DraftDeckTileVisual <tile>__1;

        [DebuggerHidden]
        public void Dispose()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 1:
                    try
                    {
                    }
                    finally
                    {
                        this.<$s_204>__0.Dispose();
                    }
                    break;
            }
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            bool flag = false;
            switch (num)
            {
                case 0:
                    this.<$s_204>__0 = this.<>f__this.m_deckTiles.GetEnumerator();
                    num = 0xfffffffd;
                    break;

                case 1:
                    break;

                default:
                    goto Label_00DB;
            }
            try
            {
                while (this.<$s_204>__0.MoveNext())
                {
                    this.<tile>__1 = this.<$s_204>__0.Current;
                    if (this.<tile>__1 != null)
                    {
                        this.<tile>__1.GetActor().ActivateSpell(SpellType.SUMMON_IN_FORGE);
                        this.$current = new WaitForSeconds(DraftDisplay.Get().m_DeckCardBarFlareUpDelay);
                        this.$PC = 1;
                        flag = true;
                        return true;
                    }
                }
            }
            finally
            {
                if (!flag)
                {
                }
                this.<$s_204>__0.Dispose();
            }
            this.$PC = -1;
        Label_00DB:
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

    public enum Mode
    {
        NO_DRAFT_DECK,
        DRAFT_DECK_CHOOSE_HERO,
        DRAFT_DECK_BUILDING,
        DRAFT_DECK_COMPLETE
    }
}


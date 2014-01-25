using System;
using UnityEngine;

public class CollectionDraggableCardVisual : PegUIElement
{
    private static readonly Vector3 CARD_ACTOR_LOCAL_SCALE = new Vector3(8f, 1f, 8f);
    private static readonly Vector3 DECK_TILE_LOCAL_SCALE = new Vector3(0.8f, 0.8f, 0.8f);
    private Actor m_activeActor;
    private HandActorCache m_actorCache = new HandActorCache();
    private Actor m_cardActor;
    private string m_cardActorName;
    private CardDef m_cardDef;
    private CardFlair m_cardFlair;
    private CollectionDeckTileActor m_deckTile;
    private CollectionDeckTileVisual m_deckTileToRemove;
    private EntityDef m_entityDef;
    private CollectionDeckSlot m_slot;

    protected override void Awake()
    {
        base.gameObject.SetActive(false);
        AssetLoader.Get().LoadActor("DeckCardBar", new AssetLoader.GameObjectCallback(this.OnDeckTileActorLoaded));
        this.m_actorCache.AddActorLoadedListener(new HandActorCache.ActorLoadedCallback(this.OnCardActorLoaded));
        this.m_actorCache.Initialize();
        if (base.gameObject.audio == null)
        {
            base.gameObject.AddComponent("AudioSource");
        }
        base.SetReceiveReleaseWithoutMouseDown(true);
    }

    public bool ChangeActor(Actor actor)
    {
        if (this.m_actorCache.IsInitializing())
        {
            return false;
        }
        EntityDef entityDef = actor.GetEntityDef();
        CardFlair cardFlair = actor.GetCardFlair();
        bool flag = entityDef != this.m_entityDef;
        bool flag2 = !cardFlair.Equals(this.m_cardFlair);
        if (flag || flag2)
        {
            this.m_entityDef = entityDef;
            this.m_cardFlair = cardFlair;
            this.m_cardActor = this.m_actorCache.GetActor(entityDef, cardFlair);
            if (this.m_cardActor == null)
            {
                return false;
            }
            if (flag)
            {
                CollectionCardCache.Get().LoadCardDef(this.m_entityDef.GetCardId(), new CollectionCardCache.LoadCardDefCallback(this.OnCardDefLoaded));
            }
            else
            {
                this.InitActor(this.m_deckTile);
                this.InitActor(this.m_cardActor);
            }
        }
        return true;
    }

    public CardFlair GetCardFlair()
    {
        return this.m_cardFlair;
    }

    public string GetCardID()
    {
        return this.m_entityDef.GetCardId();
    }

    public CollectionDeckSlot GetSlot()
    {
        return this.m_slot;
    }

    public void Hide()
    {
        base.gameObject.SetActive(false);
        if (this.m_activeActor != null)
        {
            this.m_activeActor.Hide();
            this.m_activeActor = null;
        }
    }

    private void InitActor(Actor actor)
    {
        if (actor != null)
        {
            actor.SetEntityDef(this.m_entityDef);
            actor.SetCardDef(this.m_cardDef);
            actor.SetCardFlair(this.m_cardFlair);
            actor.UpdateAllComponents();
        }
    }

    public bool IsShown()
    {
        return base.gameObject.activeSelf;
    }

    private void OnCardActorLoaded(string name, Actor actor, object callbackData)
    {
        if (actor == null)
        {
            Debug.LogWarning(string.Format("CollectionDraggableCardVisual.OnCardActorLoaded() - FAILED to load {0}", name));
        }
        else
        {
            actor.TurnOffCollider();
            actor.Hide();
            actor.transform.parent = base.transform;
            actor.transform.localPosition = Vector3.zero;
            actor.transform.localScale = CARD_ACTOR_LOCAL_SCALE;
            actor.transform.localRotation = Quaternion.identity;
        }
    }

    private void OnCardDefLoaded(string cardID, CardDef cardDef, object callbackData)
    {
        if ((this.m_entityDef != null) && (this.m_entityDef.GetCardId() == cardID))
        {
            this.m_cardDef = cardDef;
            this.InitActor(this.m_deckTile);
            this.InitActor(this.m_cardActor);
        }
    }

    private void OnDeckTileActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            Debug.LogWarning(string.Format("CollectionDraggableCardVisual.OnDeckTileActorLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            this.m_deckTile = actorObject.GetComponent<CollectionDeckTileActor>();
            if (this.m_deckTile == null)
            {
                Debug.LogWarning(string.Format("CollectionDraggableCardVisual.OnDeckTileActorLoaded() - ERROR game object \"{0}\" has no CollectionDeckTileActor component", actorName));
            }
            else
            {
                this.m_deckTile.Hide();
                this.m_deckTile.transform.parent = base.transform;
                this.m_deckTile.transform.localPosition = new Vector3(2.194931f, 0f, 0f);
                this.m_deckTile.transform.localScale = DECK_TILE_LOCAL_SCALE;
                this.m_deckTile.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
    }

    protected override void OnRelease()
    {
        if (this.m_deckTileToRemove != null)
        {
            this.m_deckTileToRemove.HideDeckBigCard();
        }
        CollectionInputMgr.Get().DropCard(this.m_deckTileToRemove);
        this.m_deckTileToRemove = null;
    }

    public void SetSlot(CollectionDeckSlot slot)
    {
        this.m_slot = slot;
    }

    public void Show(bool isOverDeck)
    {
        base.gameObject.SetActive(true);
        this.UpdateVisual(isOverDeck);
    }

    private void Update()
    {
        RaycastHit hit;
        if (((this.m_activeActor == this.m_deckTile) && (CollectionManager.Get().GetDeck(CollectionDeckTray.Get().GetCurrentlyViewedDeckID()).GetTotalCardCount() == 30)) && UniversalInputManager.Get().GetInputHitInfo(CollectionDeckTileVisual.LAYER.LayerBit(), out hit))
        {
            CollectionDeckTileVisual component = hit.collider.gameObject.GetComponent<CollectionDeckTileVisual>();
            if ((component != null) && (component != this.m_deckTileToRemove))
            {
                this.m_deckTileToRemove = component;
                this.m_deckTileToRemove.ShowDeckBigCard();
            }
        }
    }

    public void UpdateVisual(bool isOverDeck)
    {
        Actor activeActor = this.m_activeActor;
        SpellType nONE = SpellType.NONE;
        if (isOverDeck)
        {
            this.m_activeActor = this.m_deckTile;
            nONE = SpellType.SUMMON_IN;
        }
        else
        {
            this.m_activeActor = this.m_cardActor;
            nONE = SpellType.DEATHREVERSE;
        }
        if (activeActor != this.m_activeActor)
        {
            if (activeActor != null)
            {
                activeActor.Hide();
            }
            if (this.m_activeActor != null)
            {
                this.m_activeActor.Show();
                Spell spell = this.m_activeActor.GetSpell(nONE);
                if (spell != null)
                {
                    spell.ActivateState(SpellStateType.BIRTH);
                }
            }
        }
    }
}


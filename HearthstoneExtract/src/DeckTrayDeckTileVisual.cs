using System;
using UnityEngine;

public class DeckTrayDeckTileVisual : PegUIElement
{
    private readonly Vector3 BOX_COLLIDER_CENTER = new Vector3(-1.4f, 0f, 0f);
    private readonly Vector3 BOX_COLLIDER_SIZE = new Vector3(25.34f, 2.14f, 3.68f);
    protected CollectionDeckTileActor m_actor;
    protected BoxCollider m_collider;
    protected bool m_isInUse;
    protected CollectionDeckSlot m_slot;
    protected bool m_useSliderAnimations;

    protected override void Awake()
    {
        base.Awake();
        AssetLoader.Get().LoadActor("DeckCardBar", new AssetLoader.GameObjectCallback(this.OnDeckTileActorLoaded));
        if (base.gameObject.GetComponent<BoxCollider>() == null)
        {
            this.m_collider = base.gameObject.AddComponent<BoxCollider>();
            this.m_collider.size = this.BOX_COLLIDER_SIZE;
            this.m_collider.center = this.BOX_COLLIDER_CENTER;
        }
        this.Hide();
    }

    public CollectionDeckTileActor GetActor()
    {
        return this.m_actor;
    }

    public Bounds GetBounds()
    {
        return this.m_collider.bounds;
    }

    public CollectionDeckSlot GetSlot()
    {
        return this.m_slot;
    }

    public void Hide()
    {
        base.gameObject.SetActive(false);
    }

    public bool IsInUse()
    {
        return this.m_isInUse;
    }

    protected virtual void LoadCardDef(string cardID)
    {
        DefLoader.Get().LoadCardDef(cardID, new DefLoader.LoadDefCallback<CardDef>(this.OnCardDefLoaded));
    }

    public void MarkAsUnused()
    {
        this.m_isInUse = false;
        if (this.m_actor != null)
        {
            this.m_actor.UpdateDeckCardProperties(false, 1, false);
        }
    }

    public void MarkAsUsed()
    {
        this.m_isInUse = true;
    }

    protected virtual void OnCardDefLoaded(string cardID, CardDef cardDef, object callbackData)
    {
        if ((this.m_actor != null) && cardID.Equals(this.m_actor.GetEntityDef().GetCardId()))
        {
            this.m_actor.SetCardDef(cardDef);
            this.m_actor.UpdateAllComponents();
            if (cardDef.m_DeckCardBarPortrait != null)
            {
                this.m_actor.UpdateMaterialForGolden(cardDef.m_DeckCardBarPortrait);
            }
        }
    }

    private void OnDeckTileActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            Debug.LogWarning(string.Format("DeckTrayDeckTileVisual.OnDeckTileActorLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            this.m_actor = actorObject.GetComponent<CollectionDeckTileActor>();
            if (this.m_actor == null)
            {
                Debug.LogWarning(string.Format("DeckTrayDeckTileVisual.OnDeckTileActorLoaded() - ERROR game object \"{0}\" has no CollectionDeckTileActor component", actorName));
            }
            else
            {
                this.m_actor.transform.parent = base.transform;
                this.m_actor.transform.localPosition = Vector3.zero;
                this.m_actor.transform.localScale = Vector3.one;
                this.m_actor.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                this.SetUpActor();
            }
        }
    }

    public void SetSlot(CollectionDeckSlot s, bool useSliderAnimations)
    {
        this.m_slot = s;
        this.m_useSliderAnimations = useSliderAnimations;
        this.SetUpActor();
    }

    private void SetUpActor()
    {
        if (((this.m_actor != null) && (this.m_slot != null)) && !string.IsNullOrEmpty(this.m_slot.CardID))
        {
            EntityDef entityDef = DefLoader.Get().GetEntityDef(this.m_slot.CardID);
            this.m_actor.SetEntityDef(entityDef);
            this.m_actor.SetCardFlair(new CardFlair(this.m_slot.Premium));
            bool cardIsUnique = (entityDef != null) ? entityDef.IsElite() : false;
            this.m_actor.UpdateDeckCardProperties(cardIsUnique, this.m_slot.Count, this.m_useSliderAnimations);
            this.LoadCardDef(entityDef.GetCardId());
        }
    }

    public void Show()
    {
        base.gameObject.SetActive(true);
    }
}


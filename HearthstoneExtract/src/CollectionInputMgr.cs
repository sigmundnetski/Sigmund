using System;
using UnityEngine;

public class CollectionInputMgr : MonoBehaviour
{
    private bool m_cardsDraggable;
    private Vector3 m_heldCardScreenSpace;
    public CollectionDraggableCardVisual m_heldCardVisual;
    private bool m_mouseIsOverDeck;
    private Scrollbar m_scrollBar;
    private bool m_showingDeckTile;
    private static CollectionInputMgr s_instance;
    public Collider TooltipPlane;

    private void Awake()
    {
        s_instance = this;
        UniversalInputManager.Get().RegisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
    }

    private bool CanGrabItem(Actor actor)
    {
        if (this.IsDraggingScrollbar())
        {
            return false;
        }
        if (this.m_heldCardVisual.IsShown())
        {
            return false;
        }
        if (actor == null)
        {
            return false;
        }
        return true;
    }

    public void DropCard(CollectionDeckTileVisual deckTileToRemove)
    {
        this.DropCard(false, deckTileToRemove);
    }

    private void DropCard(bool dragCanceled, CollectionDeckTileVisual deckTileToRemove)
    {
        PegCursor.Get().SetMode(PegCursor.Mode.STOPDRAG);
        if (!dragCanceled)
        {
            if (this.m_mouseIsOverDeck)
            {
                CollectionDeckTray.Get().AddCard(this.m_heldCardVisual.GetCardID(), this.m_heldCardVisual.GetCardFlair(), deckTileToRemove);
            }
            else
            {
                SoundManager.Get().LoadAndPlay("collection_manager_drop_card", this.m_heldCardVisual.gameObject);
            }
        }
        this.m_heldCardVisual.Hide();
    }

    public static CollectionInputMgr Get()
    {
        return s_instance;
    }

    public void GrabCard(CollectionCardVisual cardVisual)
    {
        Actor actor = cardVisual.GetActor();
        if (this.CanGrabItem(actor) && this.m_heldCardVisual.ChangeActor(actor))
        {
            PegCursor.Get().SetMode(PegCursor.Mode.DRAG);
            this.m_heldCardVisual.SetSlot(null);
            this.m_heldCardVisual.transform.position = actor.transform.position;
            this.m_heldCardVisual.Show(this.m_mouseIsOverDeck);
            SoundManager.Get().LoadAndPlay("collection_manager_pick_up_card", this.m_heldCardVisual.gameObject);
        }
    }

    public void GrabCard(CollectionDeckTileVisual deckTileVisual)
    {
        Actor actor = deckTileVisual.GetActor();
        if (this.CanGrabItem(actor) && this.m_heldCardVisual.ChangeActor(actor))
        {
            PegCursor.Get().SetMode(PegCursor.Mode.DRAG);
            this.m_heldCardVisual.SetSlot(deckTileVisual.GetSlot());
            this.m_heldCardVisual.transform.position = actor.transform.position;
            this.m_heldCardVisual.Show(this.m_mouseIsOverDeck);
            SoundManager.Get().LoadAndPlay("collection_manager_pick_up_card", this.m_heldCardVisual.gameObject);
            CollectionDeckTray.Get().RemoveCard(this.m_heldCardVisual.GetCardID(), this.m_heldCardVisual.GetCardFlair());
        }
    }

    public bool HandleKeyboardInput()
    {
        if (CollectionManagerDisplay.Get().m_search.HandleKeyboardInput())
        {
            return true;
        }
        if ((Input.GetKeyUp(KeyCode.Escape) && (CraftingManager.Get() != null)) && CraftingManager.Get().IsCardShowing())
        {
            CraftingManager.Get().CancelCraftMode();
            return true;
        }
        return false;
    }

    public bool IsDraggingScrollbar()
    {
        return (this.m_scrollBar != null);
    }

    private void OnMouseOnOrOffScreen(bool onScreen)
    {
        if (!onScreen && this.m_heldCardVisual.IsShown())
        {
            this.DropCard(true, null);
            CollectionDeckTray.Get().GetDeckBigCard().ForceHide();
        }
    }

    public void SetScrollbar(Scrollbar scrollbar)
    {
        this.m_scrollBar = scrollbar;
    }

    private void Start()
    {
    }

    public void Unload()
    {
        UniversalInputManager.Get().UnregisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
    }

    private void Update()
    {
        this.UpdateHeldCardPosition();
        this.UpdateScrollbarDrag();
    }

    private void UpdateHeldCard()
    {
        this.m_mouseIsOverDeck = CollectionDeckTray.Get().MouseIsOver();
        this.m_heldCardVisual.UpdateVisual(this.m_mouseIsOverDeck);
    }

    private void UpdateHeldCardPosition()
    {
        RaycastHit hit;
        if (this.m_heldCardVisual.IsShown() && UniversalInputManager.Get().GetInputHitInfo(GameLayer.DragPlane.LayerBit(), out hit))
        {
            this.m_heldCardVisual.transform.position = hit.point;
            this.UpdateHeldCard();
        }
    }

    private void UpdateScrollbarDrag()
    {
        if ((this.m_scrollBar != null) && Input.GetMouseButtonUp(0))
        {
            this.m_scrollBar.m_thumb.StopDragging();
            this.m_scrollBar = null;
        }
    }
}


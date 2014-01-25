using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionCardVisual : PegUIElement
{
    public static readonly Vector3 ACTOR_LOCAL_POS = Vector3.zero;
    private static readonly Vector3 BOX_COLLIDER_CARD_CENTER = new Vector3(0f, 0.14f, 0f);
    private static readonly Vector3 BOX_COLLIDER_CARD_SIZE = new Vector3(2f, 0.21f, 2.7f);
    private Actor m_actor;
    private CollectionCardCount m_cardCount;
    private BoxCollider m_collider;
    private LockType m_lockType;
    private CollectionCardLock m_maxDeckCopiesLock;
    private Actor m_movingDeckTile;
    private GameObject m_newCardCallout;
    private CollectionCardLock m_noMoreInstancesLock;
    private Vector3 m_originalPosition;
    private bool m_shown;

    protected override void Awake()
    {
        base.Awake();
        if (base.gameObject.GetComponent<BoxCollider>() == null)
        {
            this.m_collider = base.gameObject.AddComponent<BoxCollider>();
            this.m_collider.size = BOX_COLLIDER_CARD_SIZE;
            this.m_collider.center = BOX_COLLIDER_CARD_CENTER;
        }
        if (base.gameObject.audio == null)
        {
            base.gameObject.AddComponent("AudioSource");
        }
        AssetLoader.Get().LoadGameObject("CollectionCardCount", new AssetLoader.GameObjectCallback(this.OnCardCountLoaded));
        AssetLoader.Get().LoadGameObject("NewCardText", new AssetLoader.GameObjectCallback(this.OnNewCardCalloutLoaded));
        this.SetUpLocks();
        base.SetDragTolerance(5f);
    }

    private bool CanPickUpCard()
    {
        if (this.ShouldIgnoreAllInput())
        {
            return false;
        }
        if (!this.IsInCollection())
        {
            return false;
        }
        if (!this.IsUnlocked())
        {
            return false;
        }
        if (!CollectionDeckTray.Get().IsShowingDeckContents())
        {
            return false;
        }
        return true;
    }

    public Actor GetActor()
    {
        return this.m_actor;
    }

    public CollectionCardCount GetCardCountObject()
    {
        return this.m_cardCount;
    }

    public void Hide()
    {
        this.m_shown = false;
        base.SetEnabled(false);
        if (this.m_cardCount != null)
        {
            this.m_cardCount.Hide();
        }
        this.ShowLock(LockType.NONE);
        this.ShowNewCardCallout(false);
        if (this.m_actor != null)
        {
            this.m_actor.Hide();
        }
    }

    private bool IsInCollection()
    {
        if (this.m_cardCount == null)
        {
            return false;
        }
        return (this.m_cardCount.GetCount() > 0);
    }

    public bool IsShown()
    {
        return this.m_shown;
    }

    private bool IsUnlocked()
    {
        return (this.m_lockType == LockType.NONE);
    }

    [DebuggerHidden]
    private IEnumerator MoveDeckTileAfterTrayLoads(Actor choiceActor)
    {
        return new <MoveDeckTileAfterTrayLoads>c__Iterator0 { choiceActor = choiceActor, <$>choiceActor = choiceActor, <>f__this = this };
    }

    private void MoveDeckTileToDeckTray(Actor choiceActor)
    {
        if (this.m_movingDeckTile != null)
        {
            iTween.Stop(this.m_movingDeckTile.gameObject);
            UnityEngine.Object.Destroy(this.m_movingDeckTile.gameObject);
        }
        base.StartCoroutine(this.MoveDeckTileAfterTrayLoads(choiceActor));
    }

    private void OnCardCountLoaded(string name, GameObject go, object callbackData)
    {
        this.m_cardCount = go.GetComponent<CollectionCardCount>();
        if (this.m_cardCount == null)
        {
            UnityEngine.Debug.LogError(string.Format("CollectionCardVisual.OnCardCountLoaded(): asset {0} failed to load", name));
        }
        else
        {
            this.m_cardCount.transform.parent = base.transform;
            this.m_cardCount.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            this.m_cardCount.transform.localPosition = new Vector3(0f, 0f, -1.628853f);
            this.m_cardCount.transform.localScale = new Vector3(5f, 5f, 5f);
            this.UpdateCardCount();
        }
    }

    public void OnDoneCrafting()
    {
        this.UpdateCardCount();
    }

    protected override void OnHold()
    {
        if (this.CanPickUpCard())
        {
            CollectionInputMgr.Get().GrabCard(this);
        }
    }

    private void OnNewCardCalloutLoaded(string name, GameObject go, object callbackData)
    {
        this.m_newCardCallout = go;
        if (this.m_newCardCallout == null)
        {
            UnityEngine.Debug.LogError(string.Format("CollectionCardVisual.OnNewCardCalloutLoaded(): asset {0} failed to load", name));
        }
        else
        {
            this.m_newCardCallout.transform.parent = base.transform;
            this.m_newCardCallout.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            this.m_newCardCallout.transform.localPosition = new Vector3(-0.8765373f, 0.2395657f, -0.7062247f);
            bool show = false;
            if (this.m_actor != null)
            {
                show = this.m_actor.GetActorStateMgr().GetActiveStateType() == ActorStateType.CARD_RECENTLY_ACQUIRED;
            }
            this.ShowNewCardCallout(show);
        }
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        KeywordHelpPanelManager.Get().HideKeywordHelp();
        if (!this.ShouldIgnoreAllInput() && this.IsInCollection())
        {
            this.m_actor.SetActorState(ActorStateType.CARD_IDLE);
            this.ShowNewCardCallout(false);
        }
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        if (!this.ShouldIgnoreAllInput())
        {
            EntityDef entityDef = this.m_actor.GetEntityDef();
            if (entityDef != null)
            {
                KeywordHelpPanelManager.Get().UpdateKeywordHelpForCollectionManager(entityDef, this.m_actor);
            }
            SoundManager.Get().LoadAndPlay("collection_manager_card_mouse_over", base.gameObject);
            if (this.IsInCollection())
            {
                ActorStateType stateType = ActorStateType.CARD_MOUSE_OVER;
                if (this.m_actor.GetActorStateMgr().GetActiveStateType() == ActorStateType.CARD_RECENTLY_ACQUIRED)
                {
                    stateType = ActorStateType.CARD_RECENTLY_ACQUIRED_MOUSE_OVER;
                    if (entityDef != null)
                    {
                        CollectionManager.Get().MarkAllInstancesAsSeen(entityDef.GetCardId(), this.m_actor.GetCardFlair());
                    }
                }
                this.m_actor.SetActorState(stateType);
            }
        }
    }

    protected override void OnRelease()
    {
        if (UniversalInputManager.IsTouchDevice != null)
        {
            this.m_actor.SetActorState(ActorStateType.CARD_IDLE);
            CraftingManager.Get().EnterCraftMode(this);
        }
        else if (!this.CanPickUpCard())
        {
            this.m_actor.GetSpell(SpellType.DEATHREVERSE).ActivateState(SpellStateType.BIRTH);
            CollectionManagerDisplay.Get().ShowInnkeeeprLClickHelp();
        }
        else
        {
            EntityDef entityDef = this.m_actor.GetEntityDef();
            if (entityDef != null)
            {
                this.m_actor.GetSpell(SpellType.DEATHREVERSE).ActivateState(SpellStateType.BIRTH);
                if (CollectionDeckTray.Get().AddCard(entityDef.GetCardId(), this.m_actor.GetCardFlair(), null))
                {
                    this.MoveDeckTileToDeckTray(this.m_actor);
                }
            }
        }
    }

    protected override void OnRightClick()
    {
        this.m_actor.SetActorState(ActorStateType.CARD_IDLE);
        CraftingManager.Get().EnterCraftMode(this);
    }

    public void SetActor(Actor actor)
    {
        if ((this.m_actor != null) && (this.m_actor.transform.parent == base.transform))
        {
            this.m_actor.Hide();
        }
        this.m_actor = actor;
        this.UpdateCardCount();
        if (this.m_actor != null)
        {
            EntityDef entityDef = actor.GetEntityDef();
            if (entityDef != null)
            {
                actor.transform.parent = base.transform;
                actor.transform.localScale = Vector3.one;
                actor.transform.localPosition = ACTOR_LOCAL_POS;
                actor.transform.localEulerAngles = Vector3.zero;
                int num = !entityDef.IsElite() ? 2 : 1;
                object[] args = new object[] { num };
                this.m_maxDeckCopiesLock.SetLockText(GameStrings.Format("GLUE_COLLECTION_LOCK_MAX_DECK_COPIES", args));
            }
        }
    }

    private void SetUpLocks()
    {
        this.m_lockType = LockType.NONE;
        this.m_maxDeckCopiesLock = (CollectionCardLock) UnityEngine.Object.Instantiate(CollectionManagerDisplay.Get().GetMaxDeckCopiesLockPrefab());
        this.m_maxDeckCopiesLock.transform.parent = base.transform;
        this.m_maxDeckCopiesLock.transform.localScale = Vector3.one;
        this.m_maxDeckCopiesLock.transform.localPosition = Vector3.zero;
        object[] args = new object[] { 2 };
        this.m_maxDeckCopiesLock.SetLockText(GameStrings.Format("GLUE_COLLECTION_LOCK_MAX_DECK_COPIES", args));
        this.m_maxDeckCopiesLock.gameObject.SetActive(false);
        this.m_noMoreInstancesLock = (CollectionCardLock) UnityEngine.Object.Instantiate(CollectionManagerDisplay.Get().GetNoMoreInstancesLockPrefab());
        this.m_noMoreInstancesLock.transform.parent = base.transform;
        this.m_noMoreInstancesLock.transform.localScale = Vector3.one;
        this.m_noMoreInstancesLock.transform.localPosition = Vector3.zero;
        this.m_noMoreInstancesLock.SetLockText(GameStrings.Get("GLUE_COLLECTION_LOCK_NO_MORE_INSTANCES"));
        this.m_noMoreInstancesLock.gameObject.SetActive(false);
    }

    private bool ShouldIgnoreAllInput()
    {
        return (CollectionInputMgr.Get().IsDraggingScrollbar() || ((CraftingManager.Get() != null) && CraftingManager.Get().IsCardShowing()));
    }

    public void Show(bool showNewCardGlow)
    {
        this.m_shown = true;
        base.SetEnabled(true);
        if (this.m_cardCount != null)
        {
            this.m_cardCount.Show();
        }
        this.ShowNewCardCallout(showNewCardGlow);
        if (this.m_actor != null)
        {
            this.m_actor.Show();
            ActorStateType stateType = !showNewCardGlow ? ActorStateType.CARD_IDLE : ActorStateType.CARD_RECENTLY_ACQUIRED;
            this.m_actor.SetActorState(stateType);
            UnityEngine.Renderer[] componentsInChildren = this.m_actor.gameObject.GetComponentsInChildren<UnityEngine.Renderer>();
            if (componentsInChildren != null)
            {
                foreach (UnityEngine.Renderer renderer in componentsInChildren)
                {
                    renderer.castShadows = false;
                }
            }
            EntityDef entityDef = this.m_actor.GetEntityDef();
            if (entityDef != null)
            {
                string tag = "FakeShadow";
                string str2 = "FakeShadowUnique";
                GameObject obj2 = SceneUtils.FindChildByTag(this.m_actor.gameObject, tag);
                GameObject obj3 = SceneUtils.FindChildByTag(this.m_actor.gameObject, str2);
                if (CollectionManager.Get().IsCardInCollection(entityDef.GetCardId(), this.m_actor.GetCardFlair()))
                {
                    if (entityDef.IsElite())
                    {
                        if (obj2 != null)
                        {
                            obj2.renderer.enabled = false;
                        }
                        if (obj3 != null)
                        {
                            obj3.renderer.enabled = true;
                        }
                    }
                    else
                    {
                        if (obj2 != null)
                        {
                            obj2.renderer.enabled = true;
                        }
                        if (obj3 != null)
                        {
                            obj3.renderer.enabled = false;
                        }
                    }
                }
                else
                {
                    if (obj2 != null)
                    {
                        obj2.renderer.enabled = false;
                    }
                    if (obj3 != null)
                    {
                        obj3.renderer.enabled = false;
                    }
                }
            }
        }
    }

    public void ShowLock(LockType type)
    {
        if (this.m_lockType != type)
        {
            this.m_lockType = type;
            CollectionCardLock maxDeckCopiesLock = null;
            List<CollectionCardLock> list = new List<CollectionCardLock>();
            switch (this.m_lockType)
            {
                case LockType.NONE:
                    list.Add(this.m_maxDeckCopiesLock);
                    list.Add(this.m_noMoreInstancesLock);
                    break;

                case LockType.MAX_COPIES_IN_DECK:
                    maxDeckCopiesLock = this.m_maxDeckCopiesLock;
                    list.Add(this.m_noMoreInstancesLock);
                    break;

                case LockType.NO_MORE_INSTANCES:
                    maxDeckCopiesLock = this.m_noMoreInstancesLock;
                    list.Add(this.m_maxDeckCopiesLock);
                    break;
            }
            if (maxDeckCopiesLock != null)
            {
                maxDeckCopiesLock.gameObject.SetActive(true);
            }
            foreach (CollectionCardLock lock2 in list)
            {
                lock2.gameObject.SetActive(false);
            }
        }
    }

    public void ShowNewCardCallout(bool show)
    {
        if (this.m_newCardCallout != null)
        {
            this.m_newCardCallout.SetActive(show);
        }
    }

    private void UpdateCardCount()
    {
        if (this.m_cardCount != null)
        {
            int cardCount = 0;
            if (this.m_actor != null)
            {
                EntityDef entityDef = this.m_actor.GetEntityDef();
                if (entityDef != null)
                {
                    cardCount = CollectionManager.Get().GetCollectionArtStack(entityDef.GetCardId(), this.m_actor.GetCardFlair()).Count;
                }
            }
            this.m_cardCount.SetCount(cardCount);
        }
    }

    [CompilerGenerated]
    private sealed class <MoveDeckTileAfterTrayLoads>c__Iterator0 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Actor <$>choiceActor;
        internal CollectionCardVisual <>f__this;
        internal string <cardID>__0;
        internal Vector3 <currentSpot>__5;
        internal GameObject <deckTileObject>__3;
        internal Vector3[] <newPath>__4;
        internal Vector3 <newSpot>__2;
        internal CollectionDeckTileVisual <tile>__1;
        internal Actor choiceActor;

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
                    this.<cardID>__0 = this.choiceActor.GetEntityDef().GetCardId();
                    this.<tile>__1 = CollectionDeckTray.Get().GetDeckTileVisual(this.<cardID>__0);
                    break;

                case 1:
                    break;

                default:
                    goto Label_0343;
            }
            if (this.<tile>__1 == null)
            {
                this.<tile>__1 = CollectionDeckTray.Get().GetDeckTileVisual(this.<cardID>__0);
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<newSpot>__2 = this.<tile>__1.transform.position;
            this.<deckTileObject>__3 = (GameObject) UnityEngine.Object.Instantiate(this.<tile>__1.GetActor().gameObject);
            this.<>f__this.m_movingDeckTile = this.<deckTileObject>__3.GetComponent<Actor>();
            if (CollectionManager.Get().GetDeck(CollectionDeckTray.Get().GetCurrentlyViewedDeckID()).GetCardIdCount(this.<cardID>__0) == 1)
            {
                this.<tile>__1.Hide();
            }
            else
            {
                this.<tile>__1.Show();
            }
            this.<>f__this.m_movingDeckTile.transform.position = new Vector3(this.choiceActor.transform.position.x, this.choiceActor.transform.position.y + 2.5f, this.choiceActor.transform.position.z);
            this.<>f__this.m_movingDeckTile.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            this.<>f__this.m_movingDeckTile.DeactivateAllSpells();
            this.<>f__this.m_movingDeckTile.ActivateSpell(SpellType.SUMMON_IN_LARGE);
            this.<newPath>__4 = new Vector3[3];
            this.<currentSpot>__5 = this.<>f__this.m_movingDeckTile.transform.position;
            this.<newPath>__4[0] = this.<currentSpot>__5;
            this.<newPath>__4[1] = new Vector3((this.<currentSpot>__5.x + this.<newSpot>__2.x) / 2f, ((this.<currentSpot>__5.y + this.<newSpot>__2.y) / 2f) + 60f, (this.<currentSpot>__5.z + this.<newSpot>__2.z) / 2f);
            this.<newPath>__4[2] = this.<newSpot>__2;
            this.<tile>__1.AssignMovingActor(this.<>f__this.m_movingDeckTile);
            object[] args = new object[] { "path", this.<newPath>__4, "time", 0.75f, "easetype", iTween.EaseType.easeOutCirc, "oncomplete", "FinishDeckTileMove", "oncompletetarget", CollectionManagerDisplay.Get().gameObject, "oncompleteparams", this.<tile>__1 };
            iTween.MoveTo(this.<>f__this.m_movingDeckTile.gameObject, iTween.Hash(args));
            this.$PC = -1;
        Label_0343:
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

    public enum LockType
    {
        NONE,
        MAX_COPIES_IN_DECK,
        NO_MORE_INSTANCES
    }
}


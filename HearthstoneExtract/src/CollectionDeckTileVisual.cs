using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionDeckTileVisual : DeckTrayDeckTileVisual
{
    public static readonly GameLayer LAYER = GameLayer.CardRaycast;
    private Actor m_movingEffectActor;

    public void AssignMovingActor(Actor movingActor)
    {
        if (this.m_movingEffectActor != null)
        {
            UnityEngine.Object.Destroy(this.m_movingEffectActor.gameObject);
        }
        this.m_movingEffectActor = movingActor;
    }

    protected override void Awake()
    {
        base.Awake();
        SceneUtils.SetLayer(base.gameObject, LAYER);
        base.SetDragTolerance(5f);
    }

    [DebuggerHidden]
    private IEnumerator DestroyAfterSeconds(GameObject go)
    {
        return new <DestroyAfterSeconds>c__Iterator4 { go = go, <$>go = go };
    }

    public CardFlair GetCardFlair()
    {
        return base.m_actor.GetCardFlair();
    }

    public string GetCardID()
    {
        return base.m_actor.GetEntityDef().GetCardId();
    }

    public Actor GetMovingActor()
    {
        return this.m_movingEffectActor;
    }

    public void HideDeckBigCard()
    {
        CollectionDeckTray.Get().GetDeckBigCard().Hide(base.m_actor.GetEntityDef(), base.m_actor.GetCardFlair());
    }

    protected override void LoadCardDef(string cardID)
    {
        CollectionCardCache.Get().LoadCardDef(cardID, new CollectionCardCache.LoadCardDefCallback(this.OnCardDefLoaded));
    }

    protected override void OnHold()
    {
        if (UniversalInputManager.IsTouchDevice != null)
        {
            this.HideDeckBigCard();
        }
        CollectionInputMgr.Get().GrabCard(this);
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        this.HideDeckBigCard();
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        this.ShowDeckBigCard();
    }

    protected override void OnPress()
    {
        if (UniversalInputManager.IsTouchDevice != null)
        {
            this.ShowDeckBigCard();
        }
        else
        {
            this.HideDeckBigCard();
        }
    }

    protected override void OnRelease()
    {
        if (UniversalInputManager.IsTouchDevice != null)
        {
            this.HideDeckBigCard();
        }
        else
        {
            GameObject go = (GameObject) UnityEngine.Object.Instantiate(base.m_actor.GetSpell(SpellType.SUMMON_IN).gameObject);
            go.transform.position = base.m_actor.transform.position + new Vector3(-2f, 0f, 0f);
            go.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            go.GetComponent<Spell>().ActivateState(SpellStateType.BIRTH);
            CollectionManagerDisplay.Get().StartCoroutine(this.DestroyAfterSeconds(go));
            CollectionDeckTray.Get().RemoveCard(this.GetCardID(), this.GetCardFlair());
            iTween.MoveTo(go, new Vector3(go.transform.position.x - 10f, go.transform.position.y + 10f, go.transform.position.z), 4f);
        }
    }

    protected override void OnRightClick()
    {
        CollectionManagerDisplay.Get().GoToPageWithCard(this.GetCardID(), this.GetCardFlair());
    }

    public void ShowDeckBigCard()
    {
        EntityDef entityDef = base.m_actor.GetEntityDef();
        CardDef cardDef = CollectionCardCache.Get().GetCardDef(entityDef.GetCardId());
        CollectionDeckTray.Get().GetDeckBigCard().Show(entityDef, base.m_actor.GetCardFlair(), cardDef, base.gameObject.transform.position);
    }

    [CompilerGenerated]
    private sealed class <DestroyAfterSeconds>c__Iterator4 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GameObject <$>go;
        internal GameObject go;

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
                    this.$current = new WaitForSeconds(5f);
                    this.$PC = 1;
                    return true;

                case 1:
                    UnityEngine.Object.Destroy(this.go);
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
}


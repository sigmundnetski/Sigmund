using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeckHelperVisual : PegUIElement
{
    private Actor m_actor;
    private bool m_chosen;
    private Actor m_movingDeckTile;

    public void ChooseThisCard()
    {
        this.m_chosen = true;
        this.m_actor.GetSpell(SpellType.DEATHREVERSE).ActivateState(SpellStateType.BIRTH);
        CollectionDeckTray.Get().AddCard(this.m_actor.GetEntityDef().GetCardId(), this.m_actor.GetCardFlair(), null);
        this.MoveDeckTileToDeckTray(this.m_actor);
        DeckHelper.Get().UpdateChoices();
    }

    public Actor GetActor()
    {
        return this.m_actor;
    }

    public bool IsChosen()
    {
        return this.m_chosen;
    }

    [DebuggerHidden]
    private IEnumerator MoveDeckTileAfterTrayLoads(Actor choiceActor)
    {
        return new <MoveDeckTileAfterTrayLoads>c__Iterator1D { choiceActor = choiceActor, <$>choiceActor = choiceActor, <>f__this = this };
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

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        this.m_actor.SetActorState(ActorStateType.CARD_IDLE);
        KeywordHelpPanelManager.Get().HideKeywordHelp();
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        this.m_actor.SetActorState(ActorStateType.CARD_MOUSE_OVER);
        KeywordHelpPanelManager.Get().UpdateKeywordHelpForDeckHelper(this.m_actor.GetEntityDef(), this.m_actor);
    }

    protected override void OnRelease()
    {
        this.ChooseThisCard();
    }

    public void SetActor(Actor actor)
    {
        this.m_actor = actor;
    }

    [CompilerGenerated]
    private sealed class <MoveDeckTileAfterTrayLoads>c__Iterator1D : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Actor <$>choiceActor;
        internal DeckHelperVisual <>f__this;
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
            this.<tile>__1.AssignMovingActor(this.<>f__this.m_movingDeckTile);
            this.<newPath>__4 = new Vector3[3];
            this.<currentSpot>__5 = this.<>f__this.m_movingDeckTile.transform.position;
            this.<newPath>__4[0] = this.<currentSpot>__5;
            this.<newPath>__4[1] = new Vector3((this.<currentSpot>__5.x + this.<newSpot>__2.x) / 2f, ((this.<currentSpot>__5.y + this.<newSpot>__2.y) / 2f) + 60f, (this.<currentSpot>__5.z + this.<newSpot>__2.z) / 2f);
            this.<newPath>__4[2] = this.<newSpot>__2;
            object[] args = new object[] { "path", this.<newPath>__4, "time", 0.75f, "easetype", iTween.EaseType.easeOutCirc, "oncomplete", "FinishDeckTileMove", "oncompletetarget", DeckHelper.Get().gameObject, "oncompleteparams", this.<tile>__1 };
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
}


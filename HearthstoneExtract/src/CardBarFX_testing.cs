using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CardBarFX_testing : MonoBehaviour
{
    public float ANIM_DELAY = 0.1f;
    private List<CollectionDeckTileActor> m_deckTiles = new List<CollectionDeckTileActor>();
    public int NUM_TILES = 30;
    public float Z_OFFSET = 4f;

    private void OnDeckTileActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("DeckTrayDeckTileVisual.OnDeckTileActorLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            CollectionDeckTileActor component = actorObject.GetComponent<CollectionDeckTileActor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("DeckTrayDeckTileVisual.OnDeckTileActorLoaded() - ERROR game object \"{0}\" has no CollectionDeckTileActor component", actorName));
            }
            else
            {
                this.SetUpActor(component);
                component.transform.localPosition = Vector3.zero;
                this.m_deckTiles.Add(component);
                for (int i = 1; i < this.NUM_TILES; i++)
                {
                    CollectionDeckTileActor deckTileActor = (CollectionDeckTileActor) UnityEngine.Object.Instantiate(component);
                    this.SetUpActor(deckTileActor);
                    Vector3 zero = Vector3.zero;
                    zero.z += i * this.Z_OFFSET;
                    deckTileActor.transform.localPosition = zero;
                    this.m_deckTiles.Add(deckTileActor);
                }
            }
        }
    }

    private void PlayFuseAnimations()
    {
        base.StartCoroutine(this.PlayFuseAnimationsWithTiming());
    }

    [DebuggerHidden]
    private IEnumerator PlayFuseAnimationsWithTiming()
    {
        return new <PlayFuseAnimationsWithTiming>c__Iterator112 { <>f__this = this };
    }

    private void SetUpActor(CollectionDeckTileActor deckTileActor)
    {
        deckTileActor.transform.parent = base.transform;
        deckTileActor.transform.localScale = Vector3.one;
        deckTileActor.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }

    private void Start()
    {
        AssetLoader.Get().LoadActor("DeckCardBar", new AssetLoader.GameObjectCallback(this.OnDeckTileActorLoaded));
    }

    private void Update()
    {
    }

    [CompilerGenerated]
    private sealed class <PlayFuseAnimationsWithTiming>c__Iterator112 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CardBarFX_testing <>f__this;
        internal CollectionDeckTileActor <deckTile>__1;
        internal int <i>__0;

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
                    this.<i>__0 = 0;
                    break;

                case 1:
                    this.<i>__0++;
                    break;

                default:
                    goto Label_00A9;
            }
            if (this.<i>__0 < this.<>f__this.m_deckTiles.Count)
            {
                this.<deckTile>__1 = this.<>f__this.m_deckTiles[this.<i>__0];
                this.<deckTile>__1.ActivateSpell(SpellType.SUMMON_IN_FORGE);
                this.$current = new WaitForSeconds(this.<>f__this.ANIM_DELAY);
                this.$PC = 1;
                return true;
            }
            this.$PC = -1;
        Label_00A9:
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


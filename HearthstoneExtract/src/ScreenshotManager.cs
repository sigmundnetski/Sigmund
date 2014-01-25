using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScreenshotManager : MonoBehaviour
{
    public Transform actorBone;
    public List<string> cardIDs;
    private GameObject currentActor;
    private int currentShot;
    public bool dontClearAfterScreenshot;
    private FullDef fullDef;
    public bool premium;
    public bool screenshotAllCollectibleCards;
    public int sizeFactor;

    [DebuggerHidden]
    private IEnumerator Capture()
    {
        return new <Capture>c__Iterator114 { <>f__this = this };
    }

    private void IterateThroughScreenshots()
    {
        if (this.currentShot < this.cardIDs.Count)
        {
            DefLoader.Get().LoadFullDef(this.cardIDs[this.currentShot], new DefLoader.LoadDefCallback<FullDef>(this.OnFullDefLoaded));
        }
    }

    private void OnActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("ScreenshotManager.OnActorLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("ScreenshotManager.OnActorLoaded() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                EntityDef entityDef = this.fullDef.GetEntityDef();
                CardDef cardDef = this.fullDef.GetCardDef();
                if (this.premium)
                {
                    component.SetCardFlair(new CardFlair(CardFlair.PremiumType.FOIL));
                }
                component.SetEntityDef(entityDef);
                component.SetCardDef(cardDef);
                component.UpdateAllComponents();
                component.transform.position = this.actorBone.position;
                component.transform.localScale = this.actorBone.localScale;
                this.currentActor = component.gameObject;
                base.StartCoroutine(this.Capture());
            }
        }
    }

    private void OnFullDefLoaded(string cardID, FullDef def, object userData)
    {
        this.fullDef = def;
        CardFlair flair = new CardFlair(CardFlair.PremiumType.STANDARD);
        if (this.premium)
        {
            flair.Premium = CardFlair.PremiumType.FOIL;
        }
        AssetLoader.Get().LoadActor(ActorNames.GetHandActor(def.GetEntityDef(), flair), new AssetLoader.GameObjectCallback(this.OnActorLoaded));
    }

    private void Start()
    {
        GameStrings.LoadCategory(GameStringCategory.GLOBAL);
        GameStrings.LoadCategory(GameStringCategory.GAMEPLAY);
        if (this.screenshotAllCollectibleCards)
        {
            this.cardIDs = new List<string>();
            foreach (CardManifest.Card card in CardManifest.Get().CollectibleCards())
            {
                this.cardIDs.Add(card.CardID);
            }
        }
        this.IterateThroughScreenshots();
    }

    [CompilerGenerated]
    private sealed class <Capture>c__Iterator114 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ScreenshotManager <>f__this;
        internal int <size>__0;

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
                    this.$current = null;
                    this.$PC = 1;
                    goto Label_01AB;

                case 1:
                    this.$current = null;
                    this.$PC = 2;
                    goto Label_01AB;

                case 2:
                    this.$current = null;
                    this.$PC = 3;
                    goto Label_01AB;

                case 3:
                    this.$current = null;
                    this.$PC = 4;
                    goto Label_01AB;

                case 4:
                    this.$current = null;
                    this.$PC = 5;
                    goto Label_01AB;

                case 5:
                    this.$current = null;
                    this.$PC = 6;
                    goto Label_01AB;

                case 6:
                    this.$current = null;
                    this.$PC = 7;
                    goto Label_01AB;

                case 7:
                    this.$current = null;
                    this.$PC = 8;
                    goto Label_01AB;

                case 8:
                    this.<size>__0 = Mathf.Clamp(this.<>f__this.sizeFactor, 1, 5);
                    Application.CaptureScreenshot(this.<>f__this.cardIDs[this.<>f__this.currentShot] + ".png", this.<size>__0);
                    UnityEngine.Debug.Log("Screenshot Captured as " + this.<>f__this.cardIDs[this.<>f__this.currentShot] + ".png");
                    this.$current = null;
                    this.$PC = 9;
                    goto Label_01AB;

                case 9:
                    this.<>f__this.currentShot++;
                    if (!this.<>f__this.dontClearAfterScreenshot)
                    {
                        UnityEngine.Object.DestroyImmediate(this.<>f__this.currentActor);
                    }
                    this.<>f__this.IterateThroughScreenshots();
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_01AB:
            return true;
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


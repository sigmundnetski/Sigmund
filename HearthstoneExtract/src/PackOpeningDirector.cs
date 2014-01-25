using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PackOpeningDirector : MonoBehaviour
{
    private int m_cardsPendingReveal;
    private List<Achievement> m_completeAchievesToDisplay = new List<Achievement>();
    private NormalButton m_doneButton;
    public PackOpeningDoneButtonInfo m_DoneButtonInfo;
    private bool m_doneButtonShown;
    private int m_effectsPendingDestroy;
    private int m_effectsPendingFinish;
    private List<FinishedListener> m_finishedListeners = new List<FinishedListener>();
    public List<PackOpeningCard> m_HiddenCards;
    private bool m_loadingDoneButton;
    private bool m_playing;
    public PackOpeningSocket m_Socket;
    private Spell m_spell;

    public void AddFinishedListener(FinishedCallback callback)
    {
        this.AddFinishedListener(callback, null);
    }

    public void AddFinishedListener(FinishedCallback callback, object userData)
    {
        FinishedListener item = new FinishedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        this.m_finishedListeners.Add(item);
    }

    private void Awake()
    {
        this.m_spell = base.GetComponent<Spell>();
        this.InitializeCards();
        this.InitializeUI();
    }

    private void CameraBlurOn()
    {
        Box.Get().GetBoxCamera().GetEventTable().m_BlurSpell.ActivateState(SpellStateType.BIRTH);
    }

    private void EnableCardInput(bool enable)
    {
        foreach (PackOpeningCard card in this.m_HiddenCards)
        {
            card.EnableInput(enable);
        }
    }

    public bool FinishPackOpen()
    {
        if (!this.m_doneButtonShown)
        {
            return false;
        }
        this.m_spell.ActivateState(SpellStateType.DEATH);
        Box.Get().GetBoxCamera().GetEventTable().m_BlurSpell.ActivateState(SpellStateType.DEATH);
        this.m_effectsPendingFinish = 1 + (2 * this.m_HiddenCards.Count);
        this.m_effectsPendingDestroy = this.m_effectsPendingFinish;
        this.HideDoneButton();
        foreach (PackOpeningCard card in this.m_HiddenCards)
        {
            Spell classNameSpell = card.m_ClassNameSpell;
            classNameSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnHiddenCardSpellFinished));
            classNameSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnHiddenCardSpellStateFinished));
            classNameSpell.ActivateState(SpellStateType.DEATH);
            Spell spell = card.GetActor().GetSpell(SpellType.DEATH);
            spell.AddFinishedCallback(new Spell.FinishedCallback(this.OnHiddenCardSpellFinished));
            spell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnHiddenCardSpellStateFinished));
            spell.Activate();
        }
        return true;
    }

    private void FireFinishedEvent()
    {
        CollectionManager.Get().RemoveAchievesCompletedListener(new CollectionManager.DelOnAchievesCompleted(this.OnCollectionAchievesCompleted));
        FinishedListener[] listenerArray = this.m_finishedListeners.ToArray();
        for (int i = 0; i < listenerArray.Length; i++)
        {
            listenerArray[i].Fire();
        }
    }

    private void HideDoneButton()
    {
        this.m_doneButtonShown = false;
        SceneUtils.EnableColliders(this.m_doneButton.gameObject, false);
        this.m_doneButton.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnDoneButtonPressed));
        Spell component = this.m_doneButton.m_button.GetComponent<Spell>();
        component.AddFinishedCallback(new Spell.FinishedCallback(this.OnDoneButtonHidden));
        component.ActivateState(SpellStateType.DEATH);
    }

    private void InitializeCards()
    {
        foreach (PackOpeningCard card in this.m_HiddenCards)
        {
            card.EnableInput(false);
            card.AddRevealedListener(new PackOpeningCard.RevealedCallback(this.OnCardRevealed));
        }
    }

    private void InitializeUI()
    {
        this.m_loadingDoneButton = true;
        AssetLoader.Get().LoadActor("PackOpeningDoneButton", new AssetLoader.GameObjectCallback(this.OnDoneButtonLoaded));
    }

    public bool IsPlaying()
    {
        return this.m_playing;
    }

    public void OnBoosterOpened(List<NetCache.BoosterCard> cards)
    {
        if (cards.Count > this.m_HiddenCards.Count)
        {
            UnityEngine.Debug.LogError(string.Format("PackOpeningDirector.OnBoosterOpened() - Not enough PackOpeningCards! Received {0} cards. There are only {1} hidden cards.", cards.Count, this.m_HiddenCards.Count));
        }
        else
        {
            int num = Mathf.Min(cards.Count, this.m_HiddenCards.Count);
            this.m_cardsPendingReveal = num;
            for (int i = 0; i < num; i++)
            {
                NetCache.BoosterCard boosterCard = cards[i];
                this.m_HiddenCards[i].AttachBoosterCard(boosterCard);
            }
            CollectionManager.Get().OnBoosterOpened(cards);
        }
    }

    private void OnCardRevealed(object userData)
    {
        this.m_cardsPendingReveal--;
        if (this.m_cardsPendingReveal <= 0)
        {
            this.ShowDoneButton();
        }
    }

    private void OnCollectionAchievesCompleted(List<Achievement> achievements)
    {
        this.m_completeAchievesToDisplay.AddRange(achievements);
    }

    private void OnDoneButtonHidden(Spell spell, object userData)
    {
        this.OnEffectFinished();
        this.OnEffectDone();
    }

    private void OnDoneButtonLoaded(string name, GameObject actorObject, object userData)
    {
        this.m_loadingDoneButton = false;
        if (actorObject == null)
        {
            UnityEngine.Debug.LogError(string.Format("PackOpeningDirector.OnDoneButtonLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            this.m_doneButton = actorObject.GetComponent<NormalButton>();
            if (this.m_doneButton == null)
            {
                UnityEngine.Debug.LogError(string.Format("PackOpeningDirector.OnDoneButtonLoaded() - ERROR \"{0}\" has no {1} component", name, typeof(NormalButton)));
            }
            else
            {
                SceneUtils.SetLayer(this.m_doneButton.gameObject, GameLayer.IgnoreFullScreenEffects);
                this.m_doneButton.SetText(GameStrings.Get("GLOBAL_DONE"));
                this.m_doneButton.transform.parent = base.transform;
                this.m_doneButton.transform.position = this.m_DoneButtonInfo.m_Bone.position;
                this.m_doneButton.transform.localScale = this.m_DoneButtonInfo.m_Bone.localScale;
                SceneUtils.EnableRenderersAndColliders(this.m_doneButton.gameObject, false);
            }
        }
    }

    private void OnDoneButtonPressed(UIEvent e)
    {
        if (this.m_completeAchievesToDisplay.Count > 0)
        {
            this.ShowCompleteAchieve();
        }
        else
        {
            this.FinishPackOpen();
        }
    }

    private void OnDoneButtonShown(Spell spell, object userData)
    {
        this.m_doneButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnDoneButtonPressed));
    }

    private void OnEffectDone()
    {
        this.m_effectsPendingDestroy--;
        if (this.m_effectsPendingDestroy <= 0)
        {
            UnityEngine.Object.Destroy(base.gameObject);
        }
    }

    private void OnEffectFinished()
    {
        this.m_effectsPendingFinish--;
        if (this.m_effectsPendingFinish <= 0)
        {
            this.FireFinishedEvent();
        }
    }

    private void OnHiddenCardSpellFinished(Spell spell, object userData)
    {
        this.OnEffectFinished();
    }

    private void OnHiddenCardSpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            this.OnEffectDone();
        }
    }

    public void OnPackHeld()
    {
        this.m_Socket.OnPackHeld();
    }

    public bool OnPackReleased(UnopenedPack pack)
    {
        return this.m_Socket.OnPackReleased(pack);
    }

    private void OnSpellFinished(Spell spell, object userData)
    {
        foreach (PackOpeningCard card in this.m_HiddenCards)
        {
            card.EnableInput(true);
            card.EnableReveal(true);
        }
    }

    public void Play()
    {
        if (!this.m_playing)
        {
            this.m_playing = true;
            this.EnableCardInput(false);
            CollectionManager.Get().RegisterAchievesCompletedListener(new CollectionManager.DelOnAchievesCompleted(this.OnCollectionAchievesCompleted));
            base.StartCoroutine(this.PlayWhenReady());
        }
    }

    [DebuggerHidden]
    private IEnumerator PlayWhenReady()
    {
        return new <PlayWhenReady>c__Iterator96 { <>f__this = this };
    }

    public void RemoveFinishedListener(FinishedCallback callback)
    {
        this.RemoveFinishedListener(callback, null);
    }

    public void RemoveFinishedListener(FinishedCallback callback, object userData)
    {
        FinishedListener item = new FinishedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        this.m_finishedListeners.Remove(item);
    }

    private void ShowCompleteAchieve()
    {
        if (this.m_completeAchievesToDisplay.Count == 0)
        {
            this.FinishPackOpen();
        }
        else
        {
            Achievement quest = this.m_completeAchievesToDisplay[0];
            this.m_completeAchievesToDisplay.RemoveAt(0);
            QuestToast.ShowQuestToast(new QuestToast.DelOnCloseQuestToast(this.ShowCompleteAchieve), quest);
        }
    }

    private void ShowDoneButton()
    {
        this.m_doneButtonShown = true;
        SceneUtils.EnableRenderersAndColliders(this.m_doneButton.gameObject, true);
        Spell component = this.m_doneButton.m_button.GetComponent<Spell>();
        component.AddFinishedCallback(new Spell.FinishedCallback(this.OnDoneButtonShown));
        component.ActivateState(SpellStateType.BIRTH);
    }

    [CompilerGenerated]
    private sealed class <PlayWhenReady>c__Iterator96 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal PackOpeningDirector <>f__this;

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
                    if (this.<>f__this.m_loadingDoneButton)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    if (this.<>f__this.m_doneButton == null)
                    {
                        this.<>f__this.FireFinishedEvent();
                    }
                    else
                    {
                        this.<>f__this.m_spell.AddFinishedCallback(new Spell.FinishedCallback(this.<>f__this.OnSpellFinished));
                        this.<>f__this.m_spell.ActivateState(SpellStateType.ACTION);
                        this.$PC = -1;
                    }
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

    public delegate void FinishedCallback(object userData);

    private class FinishedListener : EventListener<PackOpeningDirector.FinishedCallback>
    {
        public void Fire()
        {
            base.m_callback(base.m_userData);
        }
    }
}


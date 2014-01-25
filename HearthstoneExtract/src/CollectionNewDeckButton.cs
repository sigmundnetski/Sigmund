using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionNewDeckButton : PegUIElement
{
    private const float BUTTON_POP_SPEED = 2.5f;
    private readonly string DECKBOX_POPDOWN_ANIM_NAME = "NewDeck_PopDown";
    private readonly string DECKBOX_POPUP_ANIM_NAME = "NewDeck_PopUp";
    public HighlightState m_highlightState;
    private bool m_isPoppedUp;

    protected override void Awake()
    {
        base.Awake();
        base.SetEnabled(false);
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        this.m_highlightState.ChangeState(ActorStateType.NONE);
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        this.m_highlightState.ChangeState(ActorStateType.HIGHLIGHT_MOUSE_OVER);
    }

    private void PlayAnimation(string animationName)
    {
        this.PlayAnimation(animationName, null, null);
    }

    private void PlayAnimation(string animationName, DelOnAnimationFinished callback, object callbackData)
    {
        base.animation.Play(animationName);
        OnPopAnimationFinishedCallbackData data2 = new OnPopAnimationFinishedCallbackData {
            m_callback = callback,
            m_callbackData = callbackData,
            m_animationName = animationName
        };
        OnPopAnimationFinishedCallbackData data = data2;
        base.StopCoroutine("WaitThenCallAnimationCallback");
        base.StartCoroutine("WaitThenCallAnimationCallback", data);
    }

    public void PlayPopDownAnimation()
    {
        this.PlayPopDownAnimation(null);
    }

    public void PlayPopDownAnimation(DelOnAnimationFinished callback)
    {
        this.PlayPopDownAnimation(callback, null);
    }

    public void PlayPopDownAnimation(DelOnAnimationFinished callback, object callbackData)
    {
        if (!this.m_isPoppedUp)
        {
            if (callback != null)
            {
                callback(callbackData);
            }
        }
        else
        {
            this.m_isPoppedUp = false;
            base.animation[this.DECKBOX_POPDOWN_ANIM_NAME].time = 0f;
            base.animation[this.DECKBOX_POPDOWN_ANIM_NAME].speed = 2.5f;
            this.PlayAnimation(this.DECKBOX_POPDOWN_ANIM_NAME, callback, callbackData);
        }
    }

    public void PlayPopUpAnimation()
    {
        this.PlayPopUpAnimation(null);
    }

    public void PlayPopUpAnimation(DelOnAnimationFinished callback)
    {
        this.PlayPopUpAnimation(callback, null);
    }

    public void PlayPopUpAnimation(DelOnAnimationFinished callback, object callbackData)
    {
        if (this.m_isPoppedUp)
        {
            if (callback != null)
            {
                callback(callbackData);
            }
        }
        else
        {
            this.m_isPoppedUp = true;
            base.animation[this.DECKBOX_POPUP_ANIM_NAME].time = 0f;
            base.animation[this.DECKBOX_POPUP_ANIM_NAME].speed = 2.5f;
            this.PlayAnimation(this.DECKBOX_POPUP_ANIM_NAME, callback, callbackData);
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    [DebuggerHidden]
    private IEnumerator WaitThenCallAnimationCallback(OnPopAnimationFinishedCallbackData callbackData)
    {
        return new <WaitThenCallAnimationCallback>c__Iterator12 { callbackData = callbackData, <$>callbackData = callbackData, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenCallAnimationCallback>c__Iterator12 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionNewDeckButton.OnPopAnimationFinishedCallbackData <$>callbackData;
        internal CollectionNewDeckButton <>f__this;
        internal bool <enableInput>__0;
        internal CollectionNewDeckButton.OnPopAnimationFinishedCallbackData callbackData;

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
                    this.$current = new WaitForSeconds(this.<>f__this.animation[this.callbackData.m_animationName].length / this.<>f__this.animation[this.callbackData.m_animationName].speed);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<enableInput>__0 = this.callbackData.m_animationName.Equals(this.<>f__this.DECKBOX_POPUP_ANIM_NAME);
                    this.<>f__this.SetEnabled(this.<enableInput>__0);
                    if (this.callbackData.m_callback != null)
                    {
                        this.callbackData.m_callback(this.callbackData.m_callbackData);
                        this.$PC = -1;
                        break;
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

    public delegate void DelOnAnimationFinished(object callbackData);

    private class OnPopAnimationFinishedCallbackData
    {
        public string m_animationName;
        public CollectionNewDeckButton.DelOnAnimationFinished m_callback;
        public object m_callbackData;
    }
}


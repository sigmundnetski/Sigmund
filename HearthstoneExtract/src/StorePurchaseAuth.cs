using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StorePurchaseAuth : MonoBehaviour
{
    private static readonly string FADE_OUT_COROUTINE = "WaitThenFadeOut";
    public NormalButton m_ackPurchaseFailButton;
    private List<AckPurchaseFailListener> m_ackPurchaseFailListeners = new List<AckPurchaseFailListener>();
    public UberText m_failDetailsText;
    public UberText m_failHeadlineText;
    private bool m_shown = true;
    public Spell m_spell;
    public UberText m_successHeadlineText;
    public UberText m_waitingForAuthText;
    private static readonly float TIME_UNTIL_AUTO_FADE = 1.75f;

    private void Awake()
    {
        this.m_waitingForAuthText.Text = GameStrings.Get("GLUE_STORE_AUTH_WAITING");
        this.m_successHeadlineText.Text = GameStrings.Get("GLUE_STORE_AUTH_SUCCESS_HEADLINE");
        this.m_failHeadlineText.Text = GameStrings.Get("GLUE_STORE_AUTH_FAIL_HEADLINE");
        this.m_ackPurchaseFailButton.SetText(GameStrings.Get("GLOBAL_BUTTON_OK"));
    }

    public bool CompletePurchaseFailure(string failDetails)
    {
        if (!base.gameObject.activeInHierarchy)
        {
            return false;
        }
        this.m_ackPurchaseFailButton.gameObject.SetActive(true);
        this.m_failDetailsText.Text = failDetails;
        this.m_waitingForAuthText.gameObject.SetActive(false);
        this.m_successHeadlineText.gameObject.SetActive(false);
        this.m_failHeadlineText.gameObject.SetActive(true);
        this.m_failDetailsText.gameObject.SetActive(true);
        this.m_spell.ActivateState(SpellStateType.DEATH);
        return true;
    }

    public bool CompletePurchaseSuccess(DelOnAuthFaded callback, object userData)
    {
        if (!base.gameObject.activeInHierarchy)
        {
            return false;
        }
        this.m_waitingForAuthText.gameObject.SetActive(false);
        this.m_successHeadlineText.gameObject.SetActive(true);
        this.m_failHeadlineText.gameObject.SetActive(false);
        this.m_failDetailsText.gameObject.SetActive(false);
        this.m_spell.ActivateState(SpellStateType.ACTION);
        AuthFadedCallbackData data2 = new AuthFadedCallbackData {
            m_callback = callback,
            m_userData = userData
        };
        AuthFadedCallbackData data = data2;
        base.StopCoroutine(FADE_OUT_COROUTINE);
        base.StartCoroutine(FADE_OUT_COROUTINE, data);
        return true;
    }

    public void Hide()
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            base.StopCoroutine(FADE_OUT_COROUTINE);
            this.m_ackPurchaseFailButton.gameObject.SetActive(false);
            this.m_spell.ActivateState(SpellStateType.NONE);
            base.gameObject.SetActive(false);
        }
    }

    private void OnAckPurchaseFailPressed(UIEvent e)
    {
        this.Hide();
        foreach (AckPurchaseFailListener listener in this.m_ackPurchaseFailListeners)
        {
            listener();
        }
    }

    public void RegisterAckPurchaseFailListener(AckPurchaseFailListener listener)
    {
        if (!this.m_ackPurchaseFailListeners.Contains(listener))
        {
            this.m_ackPurchaseFailListeners.Add(listener);
        }
    }

    public void RemoveAckPurchaseFailListener(AckPurchaseFailListener listener)
    {
        this.m_ackPurchaseFailListeners.Remove(listener);
    }

    public void Show()
    {
        if (!this.m_shown)
        {
            this.m_shown = true;
            base.StopCoroutine(FADE_OUT_COROUTINE);
            this.m_waitingForAuthText.gameObject.SetActive(true);
            this.m_successHeadlineText.gameObject.SetActive(false);
            this.m_failHeadlineText.gameObject.SetActive(false);
            this.m_failDetailsText.gameObject.SetActive(false);
            base.gameObject.SetActive(true);
            this.m_spell.ActivateState(SpellStateType.BIRTH);
        }
    }

    private void Start()
    {
        this.m_ackPurchaseFailButton.gameObject.SetActive(false);
        this.m_ackPurchaseFailButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnAckPurchaseFailPressed));
    }

    [DebuggerHidden]
    private IEnumerator WaitThenFadeOut(AuthFadedCallbackData callbackData)
    {
        return new <WaitThenFadeOut>c__IteratorB6 { callbackData = callbackData, <$>callbackData = callbackData, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenFadeOut>c__IteratorB6 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal StorePurchaseAuth.AuthFadedCallbackData <$>callbackData;
        internal StorePurchaseAuth <>f__this;
        internal StorePurchaseAuth.AuthFadedCallbackData callbackData;

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
                    this.$current = new WaitForSeconds(StorePurchaseAuth.TIME_UNTIL_AUTO_FADE);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (this.callbackData.m_callback != null)
                    {
                        this.callbackData.m_callback(this.callbackData.m_userData);
                    }
                    this.<>f__this.Hide();
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

    public delegate void AckPurchaseFailListener();

    private class AuthFadedCallbackData
    {
        public StorePurchaseAuth.DelOnAuthFaded m_callback;
        public object m_userData;
    }

    public delegate void DelOnAuthFaded(object userData);
}


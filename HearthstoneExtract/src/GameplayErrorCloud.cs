using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameplayErrorCloud : MonoBehaviour
{
    private const float ERROR_MESSAGE_DURATION = 2f;
    private const float ERROR_MESSAGE_FADEIN = 0.15f;
    private const float ERROR_MESSAGE_FADEOUT = 0.5f;
    public float initTime;
    private Coroutine m_coroutine;
    public ParticleEmitter m_emitter;
    public UberText m_errorText;
    private float m_holdDuration;
    private readonly string START_COROUTINE_NAME = "StartHideMessageDelay";

    public void Hide()
    {
        this.m_coroutine = null;
        this.m_emitter.gameObject.SetActive(false);
    }

    public void HideMessage()
    {
        object[] args = new object[] { "alpha", 0f, "time", 0.5f, "oncomplete", "Hide" };
        iTween.FadeTo(base.gameObject, iTween.Hash(args));
    }

    public void Show()
    {
        this.m_emitter.gameObject.SetActive(true);
    }

    public void ShowMessage(string message, float timeToDisplay)
    {
        if (this.m_coroutine != null)
        {
            base.StopCoroutine(this.START_COROUTINE_NAME);
            this.Hide();
        }
        this.m_holdDuration = Mathf.Max(2f, timeToDisplay);
        float num = (0.15f + (this.m_holdDuration * 1.4f)) + 0.5f;
        this.m_emitter.minEnergy = num;
        this.m_emitter.maxEnergy = num;
        this.Show();
        this.m_errorText.Text = message;
        object[] args = new object[] { "alpha", 1f, "time", 0.15f };
        iTween.FadeTo(base.gameObject, iTween.Hash(args));
        this.m_coroutine = base.StartCoroutine(this.START_COROUTINE_NAME);
    }

    private void Start()
    {
        RenderUtils.SetAlpha(base.gameObject, 0f);
        this.Hide();
    }

    [DebuggerHidden]
    public IEnumerator StartHideMessageDelay()
    {
        return new <StartHideMessageDelay>c__Iterator3B { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <StartHideMessageDelay>c__Iterator3B : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GameplayErrorCloud <>f__this;

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
                    this.$current = new WaitForSeconds(0.15f + this.<>f__this.m_holdDuration);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.HideMessage();
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


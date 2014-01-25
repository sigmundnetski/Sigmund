using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TutorialKeywordTooltip : MonoBehaviour
{
    public UberText m_body;
    public UberText m_name;
    public PlayMakerFSM playMakerComponent;

    public float GetHeight()
    {
        return base.renderer.bounds.size.z;
    }

    public float GetWidth()
    {
        return base.renderer.bounds.size.x;
    }

    public void Initialize(string keywordName, string keywordText)
    {
        this.SetName(keywordName);
        this.SetBodyText(keywordText);
        base.StartCoroutine(this.WaitAFrameBeforeSendingEvent());
    }

    public void SetBodyText(string s)
    {
        this.m_body.Text = s;
    }

    public void SetName(string s)
    {
        this.m_name.Text = s;
    }

    [DebuggerHidden]
    private IEnumerator WaitAFrameBeforeSendingEvent()
    {
        return new <WaitAFrameBeforeSendingEvent>c__Iterator75 { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitAFrameBeforeSendingEvent>c__Iterator75 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal TutorialKeywordTooltip <>f__this;

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
                    RenderUtils.SetAlpha(this.<>f__this.gameObject, 0f);
                    this.$current = null;
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.playMakerComponent.SendEvent("Birth");
                    iTween.FadeTo(this.<>f__this.gameObject, 1f, 0.5f);
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


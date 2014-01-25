using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroLabel : MonoBehaviour
{
    public UberText m_classText;
    public UberText m_nameText;

    public void FadeOut()
    {
        iTween.FadeTo(this.m_nameText.gameObject, 0f, 0.5f);
        iTween.FadeTo(this.m_classText.gameObject, 0f, 0.5f);
        base.StartCoroutine(this.FinishFade());
    }

    [DebuggerHidden]
    private IEnumerator FinishFade()
    {
        return new <FinishFade>c__IteratorDA { <>f__this = this };
    }

    public void UpdateText(string nameText, string classText)
    {
        this.m_nameText.Text = nameText;
        this.m_classText.Text = classText;
    }

    [CompilerGenerated]
    private sealed class <FinishFade>c__IteratorDA : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HeroLabel <>f__this;

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
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 1;
                    return true;

                case 1:
                    UnityEngine.Object.Destroy(this.<>f__this.gameObject);
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


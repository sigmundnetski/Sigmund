using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ParticleKillTimer : MonoBehaviour
{
    public float impactwaitTimer = 1f;

    [DebuggerHidden]
    private IEnumerator impactwait()
    {
        return new <impactwait>c__IteratorFD { <>f__this = this };
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (base.gameObject.particleEmitter.emit)
        {
            base.StartCoroutine(this.impactwait());
        }
    }

    [CompilerGenerated]
    private sealed class <impactwait>c__IteratorFD : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ParticleKillTimer <>f__this;

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
                    this.$current = new WaitForSeconds(this.<>f__this.impactwaitTimer);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.gameObject.particleEmitter.emit = false;
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


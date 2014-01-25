using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroWeld : MonoBehaviour
{
    [DebuggerHidden]
    private IEnumerator DestroyWhenFinished()
    {
        return new <DestroyWhenFinished>c__IteratorFA { <>f__this = this };
    }

    public void DoAnim()
    {
        base.gameObject.SetActive(true);
        string name = "HeroWeldIn";
        base.gameObject.animation.Stop(name);
        base.gameObject.animation.Play(name);
        base.StartCoroutine(this.DestroyWhenFinished());
    }

    [CompilerGenerated]
    private sealed class <DestroyWhenFinished>c__IteratorFA : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HeroWeld <>f__this;

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
                    this.$current = new WaitForSeconds(5f);
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


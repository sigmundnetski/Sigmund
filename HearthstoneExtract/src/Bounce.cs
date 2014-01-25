using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float m_BounceAmount = 3f;
    private float m_BounceAmountOverTime;
    public int m_BounceCount = 3;
    public float m_Bounceness = 0.2f;
    public float m_BounceSpeed = 3.5f;
    public float m_Delay;
    public bool m_PlayOnStart;
    private Vector3 m_StartingPosition;

    [DebuggerHidden]
    private IEnumerator BounceAnimation()
    {
        return new <BounceAnimation>c__IteratorEB { <>f__this = this };
    }

    private void Start()
    {
        if (this.m_PlayOnStart)
        {
            this.StartAnimation();
        }
    }

    public void StartAnimation()
    {
        this.m_BounceAmountOverTime = this.m_BounceAmount;
        this.m_StartingPosition = base.transform.position;
        base.StartCoroutine("BounceAnimation");
    }

    private void Update()
    {
    }

    [CompilerGenerated]
    private sealed class <BounceAnimation>c__IteratorEB : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Bounce <>f__this;
        internal float <bounce>__4;
        internal int <c>__0;
        internal float <i>__2;
        internal Vector3 <pos>__3;
        internal float <time>__1;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_Delay);
                    this.$PC = 1;
                    goto Label_01D4;

                case 1:
                    this.<c>__0 = 0;
                    goto Label_0195;

                case 2:
                    goto Label_0129;

                case 3:
                    this.<c>__0++;
                    goto Label_0195;

                default:
                    goto Label_01D2;
            }
        Label_0157:
            this.<>f__this.m_BounceAmountOverTime *= this.<>f__this.m_Bounceness;
            this.$current = null;
            this.$PC = 3;
            goto Label_01D4;
        Label_0195:
            if (this.<c>__0 < this.<>f__this.m_BounceCount)
            {
                this.<time>__1 = 0f;
                this.<i>__2 = 0f;
                while (this.<i>__2 < 1f)
                {
                    this.<time>__1 += UnityEngine.Time.deltaTime * this.<>f__this.m_BounceSpeed;
                    this.<pos>__3 = this.<>f__this.m_StartingPosition;
                    this.<bounce>__4 = Mathf.Sin(this.<time>__1 * 3.141593f);
                    if (this.<bounce>__4 < 0f)
                    {
                        break;
                    }
                    this.<>f__this.transform.position = new Vector3(this.<pos>__3.x, this.<pos>__3.y + (this.<bounce>__4 * this.<>f__this.m_BounceAmountOverTime), this.<pos>__3.z);
                    this.$current = null;
                    this.$PC = 2;
                    goto Label_01D4;
                Label_0129:
                    this.<i>__2 += UnityEngine.Time.deltaTime * this.<>f__this.m_BounceSpeed;
                }
                goto Label_0157;
            }
            this.<>f__this.transform.position = this.<>f__this.m_StartingPosition;
        Label_01D2:
            return false;
        Label_01D4:
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


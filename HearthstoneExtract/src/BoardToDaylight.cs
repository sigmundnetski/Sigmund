using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoardToDaylight : MonoBehaviour
{
    public string m_AnimationName = "STW_GameOpen";
    public float m_PlaybackSpeed = 20f;

    [DebuggerHidden]
    private IEnumerator PlayAnimation()
    {
        return new <PlayAnimation>c__Iterator110 { <>f__this = this };
    }

    private void Start()
    {
        base.StartCoroutine(this.PlayAnimation());
    }

    [CompilerGenerated]
    private sealed class <PlayAnimation>c__Iterator110 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal BoardToDaylight <>f__this;
        internal Animation <anim>__1;
        internal AnimationState <animState>__2;
        internal Board <board>__0;

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
                    this.$current = new WaitForEndOfFrame();
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<board>__0 = Board.Get();
                    if (this.<board>__0 != null)
                    {
                        this.<anim>__1 = this.<board>__0.gameObject.GetComponent<Animation>();
                        if ((this.<anim>__1 != null) && (this.<anim>__1.GetClipCount() >= 1))
                        {
                            this.<animState>__2 = this.<anim>__1[this.<>f__this.m_AnimationName];
                            this.<animState>__2.speed = this.<>f__this.m_PlaybackSpeed;
                            this.<anim>__1.Play(this.<>f__this.m_AnimationName, PlayMode.StopAll);
                        }
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
}


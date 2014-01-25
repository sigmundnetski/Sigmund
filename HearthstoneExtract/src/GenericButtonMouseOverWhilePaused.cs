using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class GenericButtonMouseOverWhilePaused : MonoBehaviour
{
    private float LastRealTime;
    public string MouseOverAnim = "MouseOver";
    public string NormalAnim = "Normal";
    private float RealDeltaTime;
    private AnimationState TargetState;

    private IEnumerator MouseOutTimeout()
    {
        return this.TimedInvoke("OnOut", this.RealDeltaTime * 3f);
    }

    private void OnEnable()
    {
        this.LastRealTime = UnityEngine.Time.realtimeSinceStartup;
        base.animation.enabled = false;
        IEnumerator enumerator = base.animation.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                AnimationState current = (AnimationState) enumerator.Current;
                current.enabled = false;
                current.weight = 0f;
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
        base.animation.enabled = false;
        base.animation.Play(this.NormalAnim);
        AnimationState state2 = base.animation[this.NormalAnim];
        state2.enabled = true;
        state2.weight = 1f;
        state2.normalizedTime = 1f;
        base.animation.Sample();
        state2.enabled = false;
        state2.weight = 0f;
    }

    private void OnOut()
    {
        this.PlayAnim(this.NormalAnim);
    }

    private void OnOver()
    {
        this.PlayAnim(this.MouseOverAnim);
        base.StopCoroutine("MouseOutTimeout");
        base.StartCoroutine("MouseOutTimeout");
    }

    private void PlayAnim(string toAnim)
    {
        AnimationState state = base.animation[toAnim];
        if (state != this.TargetState)
        {
            this.TargetState = state;
            this.TargetState.weight = 0f;
            this.TargetState.enabled = true;
            this.TargetState.speed = 0f;
            this.TargetState.time = 0f;
        }
    }

    [DebuggerHidden]
    private IEnumerator TimedInvoke(string MethodToInvoke, float TimeLeft)
    {
        return new <TimedInvoke>c__IteratorF8 { MethodToInvoke = MethodToInvoke, TimeLeft = TimeLeft, <$>MethodToInvoke = MethodToInvoke, <$>TimeLeft = TimeLeft, <>f__this = this };
    }

    private void Update()
    {
        this.RealDeltaTime = UnityEngine.Time.realtimeSinceStartup - this.LastRealTime;
        this.LastRealTime = UnityEngine.Time.realtimeSinceStartup;
        if (this.TargetState != null)
        {
            this.TargetState.time += this.RealDeltaTime;
            if (this.TargetState.weight < 1f)
            {
                this.TargetState.weight = Mathf.Min((float) (this.TargetState.weight + (this.RealDeltaTime * 10f)), (float) 1f);
            }
            IEnumerator enumerator = base.animation.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AnimationState current = (AnimationState) enumerator.Current;
                    if ((current != this.TargetState) && current.enabled)
                    {
                        current.speed = 0f;
                        current.weight = Mathf.Max((float) (current.weight - (this.RealDeltaTime * 10f)), (float) 0f);
                        if (current.weight <= 0f)
                        {
                            current.enabled = false;
                        }
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
            base.animation.Sample();
        }
    }

    [CompilerGenerated]
    private sealed class <TimedInvoke>c__IteratorF8 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal string <$>MethodToInvoke;
        internal float <$>TimeLeft;
        internal GenericButtonMouseOverWhilePaused <>f__this;
        internal string MethodToInvoke;
        internal float TimeLeft;

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
                    this.<>f__this.Invoke(this.MethodToInvoke, float.PositiveInfinity);
                    break;

                case 1:
                    break;

                default:
                    goto Label_00DA;
            }
            if ((this.TimeLeft > 0f) && this.<>f__this.IsInvoking(this.MethodToInvoke))
            {
                this.TimeLeft -= this.<>f__this.RealDeltaTime;
                this.$current = new WaitForEndOfFrame();
                this.$PC = 1;
                return true;
            }
            if (this.<>f__this.IsInvoking(this.MethodToInvoke))
            {
                this.<>f__this.CancelInvoke(this.MethodToInvoke);
                this.<>f__this.Invoke(this.MethodToInvoke, float.Epsilon);
            }
        Label_00DA:
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


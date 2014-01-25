using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimPositionResetter : MonoBehaviour
{
    private float m_delay;
    private float m_endTimestamp;
    private Vector3 m_initialPosition;

    private void Awake()
    {
        this.m_initialPosition = base.transform.position;
    }

    public float GetDelay()
    {
        return this.m_delay;
    }

    public float GetEndTimestamp()
    {
        return this.m_endTimestamp;
    }

    public Vector3 GetInitialPosition()
    {
        return this.m_initialPosition;
    }

    private void OnAnimStarted(float animTime)
    {
        float num2 = UnityEngine.Time.realtimeSinceStartup + animTime;
        float a = num2 - this.m_endTimestamp;
        if (a > 0f)
        {
            this.m_delay = Mathf.Min(a, animTime);
            this.m_endTimestamp = num2;
            base.StopCoroutine("ResetPosition");
            base.StartCoroutine("ResetPosition");
        }
    }

    public static AnimPositionResetter OnAnimStarted(GameObject go, float animTime)
    {
        if (animTime <= 0f)
        {
            return null;
        }
        AnimPositionResetter resetter = RegisterResetter(go);
        resetter.OnAnimStarted(animTime);
        return resetter;
    }

    private static AnimPositionResetter RegisterResetter(GameObject go)
    {
        if (go == null)
        {
            return null;
        }
        AnimPositionResetter component = go.GetComponent<AnimPositionResetter>();
        if (component != null)
        {
            return component;
        }
        return go.AddComponent<AnimPositionResetter>();
    }

    [DebuggerHidden]
    private IEnumerator ResetPosition()
    {
        return new <ResetPosition>c__IteratorEA { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <ResetPosition>c__IteratorEA : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal AnimPositionResetter <>f__this;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_delay);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.transform.position = this.<>f__this.m_initialPosition;
                    UnityEngine.Object.Destroy(this.<>f__this);
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


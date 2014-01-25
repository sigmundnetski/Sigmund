using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpellState : MonoBehaviour
{
    public List<SpellStateAudioSource> m_AudioSources;
    public List<SpellStateAnimObject> m_ExternalAnimatedObjects;
    private bool m_initialized;
    private bool m_playing;
    private bool m_shown = true;
    private Spell m_spell;
    public float m_StartDelaySec;
    public SpellStateType m_StateType;

    [DebuggerHidden]
    private IEnumerator DelayedPlay()
    {
        return new <DelayedPlay>c__IteratorE8 { <>f__this = this };
    }

    public void HideState()
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            if (this.m_initialized && this.m_playing)
            {
                this.StopImpl(null);
            }
        }
    }

    private void OnChangeState(SpellStateType stateType)
    {
        this.m_spell.ChangeState(stateType);
    }

    public void OnLoad()
    {
        base.gameObject.SetActive(true);
        foreach (SpellStateAnimObject obj2 in this.m_ExternalAnimatedObjects)
        {
            obj2.OnLoad(this);
        }
    }

    private void OnSpellFinished()
    {
        this.m_spell.OnSpellFinished();
    }

    private void OnStateFinished()
    {
        this.m_spell.OnStateFinished();
    }

    public void Play()
    {
        if (!this.m_playing && this.m_shown)
        {
            this.m_playing = true;
            if (this.m_initialized)
            {
                this.PlayImpl();
            }
        }
    }

    private void PlayImpl()
    {
        base.gameObject.SetActive(true);
        if (object.Equals(this.m_StartDelaySec, 0f))
        {
            this.PlayNow();
        }
        else
        {
            base.StartCoroutine(this.DelayedPlay());
        }
    }

    private void PlayNow()
    {
        foreach (SpellStateAnimObject obj2 in this.m_ExternalAnimatedObjects)
        {
            obj2.Play();
        }
        foreach (SpellStateAudioSource source in this.m_AudioSources)
        {
            source.Play(this);
        }
    }

    public void ShowState()
    {
        if (!this.m_shown)
        {
            this.m_shown = true;
            if (this.m_initialized && this.m_playing)
            {
                this.PlayImpl();
            }
        }
    }

    private void Start()
    {
        this.m_spell = SceneUtils.FindComponentInParents<Spell>(base.gameObject);
        for (int i = 0; i < this.m_ExternalAnimatedObjects.Count; i++)
        {
            this.m_ExternalAnimatedObjects[i].Init();
        }
        for (int j = 0; j < this.m_AudioSources.Count; j++)
        {
            this.m_AudioSources[j].Init();
        }
        this.m_initialized = true;
        if (this.m_shown && this.m_playing)
        {
            this.PlayImpl();
        }
        else
        {
            this.StopImpl(null);
        }
    }

    public void Stop(List<SpellState> nextStateList)
    {
        if (this.m_playing)
        {
            this.m_playing = false;
            if (this.m_initialized)
            {
                this.StopImpl(nextStateList);
            }
        }
    }

    private void StopImpl(List<SpellState> nextStateList)
    {
        if (nextStateList == null)
        {
            foreach (SpellStateAnimObject obj2 in this.m_ExternalAnimatedObjects)
            {
                obj2.Stop();
            }
        }
        else
        {
            foreach (SpellStateAnimObject obj3 in this.m_ExternalAnimatedObjects)
            {
                obj3.Stop(nextStateList);
            }
        }
        foreach (SpellStateAudioSource source in this.m_AudioSources)
        {
            source.Stop();
        }
        base.gameObject.SetActive(false);
    }

    [CompilerGenerated]
    private sealed class <DelayedPlay>c__IteratorE8 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SpellState <>f__this;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_StartDelaySec);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.PlayNow();
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


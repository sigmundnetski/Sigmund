using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    private const string CINEMATIC_ENUS_FILE_NAME = "Cinematic_EnUS";
    private bool m_isMovieLoaded;
    private bool m_isPlaying;
    private MovieTexture m_MovieTexture;
    private const float MOVIE_LOAD_TIMEOUT = 10f;

    public bool isPlaying()
    {
        return this.m_isPlaying;
    }

    private void MovieLoaded(string name, UnityEngine.Object obj, object callbackData)
    {
        if (obj == null)
        {
            UnityEngine.Debug.LogError("Failed to load Cinematic movie!");
        }
        else
        {
            this.m_isMovieLoaded = true;
            this.m_MovieTexture = obj as MovieTexture;
        }
    }

    private void OnGUI()
    {
        if (this.m_isPlaying)
        {
            GUI.DrawTexture(new Rect(0f, 0f, (float) Screen.width, (float) Screen.height), this.m_MovieTexture, ScaleMode.ScaleToFit, false, 0f);
        }
    }

    public void Play(MovieCallback callback)
    {
        PlayOptions options = new PlayOptions {
            callback = callback
        };
        string methodName = string.Empty;
        methodName = "PlayPC";
        if (methodName != string.Empty)
        {
            base.StartCoroutine(methodName, options);
        }
    }

    [DebuggerHidden]
    private IEnumerator PlayMobile(PlayOptions options)
    {
        return new <PlayMobile>c__IteratorEC { options = options, <$>options = options, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator PlayPC(PlayOptions options)
    {
        return new <PlayPC>c__IteratorED { options = options, <$>options = options, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <PlayMobile>c__IteratorEC : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Cinematic.PlayOptions <$>options;
        internal Cinematic <>f__this;
        internal Cinematic.PlayOptions options;

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
                    this.$current = null;
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_isPlaying = true;
                    Options.Get().SetBool(Option.HAS_SEEN_CINEMATIC, true);
                    this.<>f__this.m_isPlaying = false;
                    this.options.callback();
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

    [CompilerGenerated]
    private sealed class <PlayPC>c__IteratorED : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Cinematic.PlayOptions <$>options;
        internal Cinematic <>f__this;
        internal AudioSource <movieSound>__1;
        internal float <timeOut>__0;
        internal Cinematic.PlayOptions options;

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
                    AssetLoader.Get().LoadMovie("Cinematic_EnUS", new AssetLoader.ObjectCallback(this.<>f__this.MovieLoaded));
                    this.<timeOut>__0 = UnityEngine.Time.time + 10f;
                    break;

                case 1:
                    break;

                case 2:
                case 3:
                    if (!this.<>f__this.m_MovieTexture.isReadyToPlay)
                    {
                        this.$current = null;
                        this.$PC = 3;
                        goto Label_023B;
                    }
                    Options.Get().SetBool(Option.HAS_SEEN_CINEMATIC, true);
                    BnetBar.Get().gameObject.SetActive(false);
                    this.<>f__this.m_isPlaying = true;
                    this.<>f__this.m_MovieTexture.filterMode = FilterMode.Bilinear;
                    this.<>f__this.m_MovieTexture.loop = false;
                    this.<>f__this.m_MovieTexture.Play();
                    this.<movieSound>__1 = SoundManager.Get().PlayClip(this.<>f__this.m_MovieTexture.audioClip, 1f, 1f, SoundCategory.FX, this.<>f__this.gameObject);
                    SoundManager.Get().Set3d(this.<movieSound>__1, false);
                    goto Label_01AC;

                case 4:
                    goto Label_01AC;

                default:
                    goto Label_0239;
            }
            if (!this.<>f__this.m_isMovieLoaded && (UnityEngine.Time.time < this.<timeOut>__0))
            {
                this.$current = null;
                this.$PC = 1;
            }
            else
            {
                if (this.<>f__this.m_MovieTexture == null)
                {
                    goto Label_0239;
                }
                this.$current = null;
                this.$PC = 2;
            }
            goto Label_023B;
        Label_01AC:
            while (this.<>f__this.m_MovieTexture.isPlaying && !Input.anyKey)
            {
                this.$current = null;
                this.$PC = 4;
                goto Label_023B;
            }
            if (this.<>f__this.m_MovieTexture.isPlaying)
            {
                this.<>f__this.m_MovieTexture.Stop();
                SoundManager.Get().Stop(this.<movieSound>__1);
            }
            BnetBar.Get().gameObject.SetActive(true);
            this.<>f__this.m_isPlaying = false;
            this.options.callback();
        Label_0239:
            return false;
        Label_023B:
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

    public delegate void MovieCallback();

    private class PlayOptions
    {
        public Cinematic.MovieCallback callback;
    }
}


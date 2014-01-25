using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionCoverDisplay : PegUIElement
{
    private readonly float BOOK_COVER_FULL_ANIM_TIME = 0.75f;
    private readonly float BOOK_COVER_FULLY_CLOSED_Z_ROTATION;
    private readonly float BOOK_COVER_FULLY_OPEN_Z_ROTATION = 280f;
    private readonly string CRACK_LATCH_OPEN_ANIM_COROUTINE = "AnimateLatchCrackOpen";
    private readonly float LATCH_FADE_DELAY = 0.15f;
    private readonly float LATCH_FADE_TIME = 0.1f;
    private readonly string LATCH_OPEN_ANIM_NAME = "CollectionManagerCoverV2_Lock_edit";
    private readonly float LATCH_OPEN_ANIM_SPEED = 4f;
    public GameObject m_bookCover;
    public GameObject m_bookCoverLatch;
    public GameObject m_bookCoverLatchJoint;
    private BoxCollider m_boxCollider;
    private bool m_isAnimating;
    public Material m_latchFadeMaterial;
    public Material m_latchOpaqueMaterial;

    private void AnimateCoverClosing()
    {
        Vector3 localEulerAngles = this.m_bookCover.transform.localEulerAngles;
        localEulerAngles.z = this.BOOK_COVER_FULLY_CLOSED_Z_ROTATION;
        object[] args = new object[] { "rotation", localEulerAngles, "isLocal", true, "time", this.BOOK_COVER_FULL_ANIM_TIME, "easeType", iTween.EaseType.easeInCubic, "oncomplete", "AnimateLatchClosing", "oncompletetarget", base.gameObject, "name", "rotation" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_bookCover.gameObject, "rotation");
        iTween.RotateTo(this.m_bookCover.gameObject, hashtable);
    }

    private void AnimateCoverOpening(DelOnOpened callback)
    {
        this.m_bookCoverLatchJoint.renderer.material = this.m_latchFadeMaterial;
        Vector3 localEulerAngles = this.m_bookCover.transform.localEulerAngles;
        localEulerAngles.z = this.BOOK_COVER_FULLY_OPEN_Z_ROTATION;
        object[] args = new object[] { "rotation", localEulerAngles, "isLocal", true, "time", this.BOOK_COVER_FULL_ANIM_TIME, "easeType", iTween.EaseType.easeInCubic, "oncomplete", "OnCoverOpened", "oncompletetarget", base.gameObject, "oncompleteparams", callback, "name", "rotation" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_bookCover.gameObject, "rotation");
        iTween.RotateTo(this.m_bookCover.gameObject, hashtable);
    }

    private void AnimateLatchClosing()
    {
        this.m_bookCoverLatchJoint.renderer.enabled = true;
        this.m_bookCoverLatchJoint.renderer.material = this.m_latchFadeMaterial;
        this.m_bookCoverLatch.animation[this.LATCH_OPEN_ANIM_NAME].time = this.m_bookCoverLatch.animation[this.LATCH_OPEN_ANIM_NAME].length;
        this.m_bookCoverLatch.animation[this.LATCH_OPEN_ANIM_NAME].speed = -this.LATCH_OPEN_ANIM_SPEED * 2f;
        object[] args = new object[] { "amount", 1, "time", this.LATCH_FADE_TIME, "easeType", iTween.EaseType.linear, "oncomplete", "OnLatchClosed", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        this.m_bookCoverLatch.animation.Play(this.LATCH_OPEN_ANIM_NAME);
        iTween.FadeTo(this.m_bookCoverLatchJoint, hashtable);
    }

    [DebuggerHidden]
    private IEnumerator AnimateLatchCrackOpen()
    {
        return new <AnimateLatchCrackOpen>c__Iterator1 { <>f__this = this };
    }

    private void AnimateLatchOpening()
    {
        this.m_bookCoverLatch.animation[this.LATCH_OPEN_ANIM_NAME].speed = this.LATCH_OPEN_ANIM_SPEED;
        if (this.m_bookCoverLatch.animation.IsPlaying(this.LATCH_OPEN_ANIM_NAME))
        {
            base.StopCoroutine(this.CRACK_LATCH_OPEN_ANIM_COROUTINE);
        }
        else
        {
            this.m_bookCoverLatch.animation[this.LATCH_OPEN_ANIM_NAME].time = 0f;
            this.m_bookCoverLatch.animation.Play(this.LATCH_OPEN_ANIM_NAME);
        }
        object[] args = new object[] { "amount", 0, "delay", this.LATCH_FADE_DELAY, "time", this.LATCH_FADE_TIME, "easeType", iTween.EaseType.linear, "oncomplete", "OnLatchOpened", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.FadeTo(this.m_bookCoverLatchJoint, hashtable);
    }

    protected override void Awake()
    {
        base.Awake();
        this.m_boxCollider = base.transform.GetComponent<BoxCollider>();
    }

    public void Close()
    {
        this.m_bookCover.SetActive(true);
        if (this.m_bookCover.transform.localEulerAngles.z != this.BOOK_COVER_FULLY_CLOSED_Z_ROTATION)
        {
            this.SetIsAnimating(true);
            this.AnimateCoverClosing();
            SoundManager.Get().LoadAndPlay("collection_manager_book_close");
        }
    }

    private void CrackClose()
    {
        if (!this.IsAnimating() && this.m_bookCoverLatch.animation.IsPlaying(this.LATCH_OPEN_ANIM_NAME))
        {
            base.StopCoroutine(this.CRACK_LATCH_OPEN_ANIM_COROUTINE);
            this.m_bookCoverLatch.animation[this.LATCH_OPEN_ANIM_NAME].speed = -this.LATCH_OPEN_ANIM_SPEED;
        }
    }

    private void CrackOpen()
    {
        if (!this.IsAnimating())
        {
            base.StopCoroutine(this.CRACK_LATCH_OPEN_ANIM_COROUTINE);
            base.StartCoroutine(this.CRACK_LATCH_OPEN_ANIM_COROUTINE);
        }
    }

    private void EnableCollider(bool enabled)
    {
        base.SetEnabled(enabled);
        this.m_boxCollider.enabled = enabled;
    }

    public bool IsAnimating()
    {
        return this.m_isAnimating;
    }

    private void OnCoverOpened(DelOnOpened callback)
    {
        this.m_bookCover.SetActive(false);
        this.SetIsAnimating(false);
        if (callback != null)
        {
            callback();
        }
    }

    private void OnLatchClosed()
    {
        this.EnableCollider(true);
        this.SetIsAnimating(false);
    }

    private void OnLatchOpened()
    {
        this.m_bookCoverLatchJoint.renderer.enabled = false;
    }

    public void Open(DelOnOpened callback)
    {
        if (this.m_bookCover.transform.localEulerAngles.z != this.BOOK_COVER_FULLY_OPEN_Z_ROTATION)
        {
            this.EnableCollider(false);
            this.SetIsAnimating(true);
            this.AnimateLatchOpening();
            this.AnimateCoverOpening(callback);
            SoundManager.Get().LoadAndPlay("collection_manager_book_open");
        }
    }

    private void SetIsAnimating(bool animating)
    {
        this.m_isAnimating = animating;
    }

    public void SetOpenState()
    {
        if (this.m_bookCover.activeSelf)
        {
            this.EnableCollider(false);
            this.SetIsAnimating(false);
            this.m_bookCover.SetActive(false);
            this.m_bookCoverLatchJoint.renderer.enabled = false;
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    [CompilerGenerated]
    private sealed class <AnimateLatchCrackOpen>c__Iterator1 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionCoverDisplay <>f__this;

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
                    this.<>f__this.m_bookCoverLatchJoint.renderer.material = this.<>f__this.m_latchOpaqueMaterial;
                    this.<>f__this.m_bookCoverLatch.animation[this.<>f__this.LATCH_OPEN_ANIM_NAME].time = 0f;
                    this.<>f__this.m_bookCoverLatch.animation[this.<>f__this.LATCH_OPEN_ANIM_NAME].speed = this.<>f__this.LATCH_OPEN_ANIM_SPEED;
                    SoundManager.Get().LoadAndPlay("collection_manager_book_latch_jiggle");
                    this.<>f__this.m_bookCoverLatch.animation.Play(this.<>f__this.LATCH_OPEN_ANIM_NAME);
                    break;

                case 1:
                    break;

                default:
                    goto Label_0143;
            }
            if (this.<>f__this.m_bookCoverLatch.animation[this.<>f__this.LATCH_OPEN_ANIM_NAME].time < 0.75f)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<>f__this.m_bookCoverLatch.animation[this.<>f__this.LATCH_OPEN_ANIM_NAME].speed = 0f;
            this.$PC = -1;
        Label_0143:
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

    public delegate void DelOnOpened();
}


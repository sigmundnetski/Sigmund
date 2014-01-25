using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PracticeAIButton : PegUIElement
{
    private readonly string FLIP_COROUTINE = "WaitThenFlip";
    private const float FLIPPED_X_ROTATION = 180f;
    private readonly Vector3 GLOW_QUAD_FLIPPED_LOCAL_POS = new Vector3(-0.1953466f, -1.336676f, 0.00721521f);
    private readonly Vector3 GLOW_QUAD_NORMAL_LOCAL_POS = new Vector3(-0.1953466f, 1.336676f, 0.00721521f);
    public GameObject m_backsideCover;
    public TextMesh m_backsideName;
    private TAG_CLASS m_class;
    private bool m_covered;
    public long m_deckID;
    public GameObject m_frontCover;
    public HighlightState m_highlight;
    private bool m_infoSet;
    private bool m_locked;
    public MissionMgr.MissionID m_missionID;
    public TextMesh m_name;
    public GameObject m_questBang;
    public GameObject m_unlockEffect;
    private bool m_usingBackside;
    private const float NORMAL_X_ROTATION = 0f;
    private const long NULL_ID = -999L;

    public void CoverUp(bool flip)
    {
        this.m_covered = true;
        if (flip)
        {
            this.GetHiddenNameMesh().text = string.Empty;
            this.GetHiddenCover().renderer.enabled = true;
            this.Flip();
        }
        else
        {
            this.GetShowingNameMesh().text = string.Empty;
            this.GetShowingCover().renderer.enabled = true;
        }
        object[] args = new object[] { "position", base.GetOriginalLocalPosition() + new Vector3(0f, -0.9f, 0f), "time", 0.25f, "isLocal", true, "easeType", iTween.EaseType.linear };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(base.gameObject, hashtable);
        base.SetEnabled(false);
    }

    private void Depress()
    {
        Vector3 originalLocalPosition = base.GetOriginalLocalPosition();
        originalLocalPosition.y -= 0.7f;
        object[] args = new object[] { "position", originalLocalPosition, "time", 0.1f, "easeType", iTween.EaseType.linear, "isLocal", true };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(base.gameObject, hashtable);
    }

    public void Deselect()
    {
        this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_OFF);
        if (!this.m_covered)
        {
            this.Raise();
            if (!this.m_locked)
            {
                base.SetEnabled(true);
            }
        }
    }

    private void Flip()
    {
        base.StopCoroutine(this.FLIP_COROUTINE);
        this.m_usingBackside = !this.m_usingBackside;
        base.StartCoroutine(this.FLIP_COROUTINE, this.m_usingBackside);
    }

    public TAG_CLASS GetClass()
    {
        return this.m_class;
    }

    private GameObject GetHiddenCover()
    {
        return (!this.m_usingBackside ? this.m_backsideCover : this.m_frontCover);
    }

    private Material GetHiddenMaterial()
    {
        int index = !this.m_usingBackside ? 2 : 1;
        return base.gameObject.renderer.materials[index];
    }

    private TextMesh GetHiddenNameMesh()
    {
        return (!this.m_usingBackside ? this.m_backsideName : this.m_name);
    }

    private GameObject GetShowingCover()
    {
        return (!this.m_usingBackside ? this.m_frontCover : this.m_backsideCover);
    }

    private Material GetShowingMaterial()
    {
        int index = !this.m_usingBackside ? 1 : 2;
        return base.gameObject.renderer.materials[index];
    }

    private TextMesh GetShowingNameMesh()
    {
        return (!this.m_usingBackside ? this.m_name : this.m_backsideName);
    }

    public void Lock(bool locked)
    {
        this.m_locked = locked;
        float num = !this.m_locked ? ((float) 0) : ((float) 1);
        bool enabled = !this.m_locked;
        base.SetEnabled(enabled);
        this.GetShowingMaterial().SetFloat("_Desaturate", num);
        base.gameObject.renderer.materials[0].SetFloat("_Desaturate", num);
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_OFF);
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_MOUSE_OVER);
    }

    public void PlayUnlockGlow()
    {
        this.m_unlockEffect.animation.Play("AITileGlow");
    }

    public void Raise()
    {
        this.Raise(0.1f);
    }

    private void Raise(float time)
    {
        object[] args = new object[] { "position", base.GetOriginalLocalPosition(), "time", time, "easeType", iTween.EaseType.linear, "isLocal", true };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(base.gameObject, hashtable);
    }

    public void Select()
    {
        SoundManager.Get().LoadAndPlay("select_AI_opponent", base.gameObject);
        this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE);
        base.SetEnabled(false);
        this.Depress();
    }

    private void SetButtonClass(TAG_CLASS buttonClass)
    {
        this.m_class = buttonClass;
    }

    private void SetDeckID(long deckID)
    {
        this.m_deckID = deckID;
    }

    public void SetInfo(string name, TAG_CLASS buttonClass, Texture texture, MissionMgr.MissionID missionID, bool flip)
    {
        this.SetInfo(name, buttonClass, texture, missionID, -999L, flip);
    }

    public void SetInfo(string name, TAG_CLASS buttonClass, Texture texture, long deckID, bool flip)
    {
        this.SetInfo(name, buttonClass, texture, MissionMgr.MissionID.INVALID, deckID, flip);
    }

    private void SetInfo(string name, TAG_CLASS buttonClass, Texture texture, MissionMgr.MissionID missionID, long deckID, bool flip)
    {
        this.SetMissionID(missionID);
        this.SetDeckID(deckID);
        this.SetButtonClass(buttonClass);
        if (flip)
        {
            this.GetHiddenNameMesh().text = name;
            this.GetHiddenMaterial().mainTexture = texture;
            this.Flip();
        }
        else
        {
            if (this.m_infoSet)
            {
                UnityEngine.Debug.LogWarning("PracticeAIButton.SetInfo() - button is being re-initialized!");
            }
            this.m_infoSet = true;
            this.GetShowingMaterial().mainTexture = texture;
            this.GetShowingNameMesh().text = name;
            base.SetOriginalLocalPosition();
        }
        this.m_covered = false;
        this.GetShowingCover().renderer.enabled = false;
    }

    private void SetMissionID(MissionMgr.MissionID missionID)
    {
        this.m_missionID = missionID;
    }

    public void ShowQuestBang(bool shown)
    {
        this.m_questBang.SetActive(shown);
    }

    [DebuggerHidden]
    private IEnumerator WaitThenFlip(bool flipToBackside)
    {
        return new <WaitThenFlip>c__Iterator97 { flipToBackside = flipToBackside, <$>flipToBackside = flipToBackside, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenFlip>c__Iterator97 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal bool <$>flipToBackside;
        internal PracticeAIButton <>f__this;
        internal Hashtable <args>__1;
        internal float <highlightTargetXRotation>__2;
        internal float <startXRotation>__0;
        internal bool flipToBackside;

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
                    iTween.StopByName(this.<>f__this.gameObject, "flip");
                    this.$current = new WaitForEndOfFrame();
                    this.$PC = 1;
                    return true;

                case 1:
                {
                    this.<startXRotation>__0 = !this.flipToBackside ? 180f : 0f;
                    this.<>f__this.transform.localEulerAngles = new Vector3(this.<startXRotation>__0, 180f, 0f);
                    object[] args = new object[] { "amount", new Vector3(180f, 0f, 0f), "time", 0.25f, "easeType", iTween.EaseType.easeOutElastic, "space", Space.Self, "name", "flip" };
                    this.<args>__1 = iTween.Hash(args);
                    iTween.RotateAdd(this.<>f__this.gameObject, this.<args>__1);
                    this.<highlightTargetXRotation>__2 = !this.flipToBackside ? 0f : 180f;
                    this.<>f__this.m_highlight.transform.localEulerAngles = new Vector3(this.<highlightTargetXRotation>__2, 0f, 0f);
                    this.<>f__this.m_unlockEffect.transform.localPosition = !this.flipToBackside ? this.<>f__this.GLOW_QUAD_NORMAL_LOCAL_POS : this.<>f__this.GLOW_QUAD_FLIPPED_LOCAL_POS;
                    this.$PC = -1;
                    break;
                }
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


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroPickerButton : PegUIElement
{
    public UberText m_classLabel;
    private float m_currProgress;
    private FullDef m_fullDef;
    public GameObject m_heroClassIcon;
    private HighlightState m_highlightState;
    private bool m_isSelected;
    public GameObject m_keyholeEffect;
    private bool m_locked;
    private long m_preconDeckID;
    private float m_prevProgress;
    public ProgressBar m_progressBar;
    public GameObject m_questBang;

    public void Activate(bool enable)
    {
        if (!this.m_locked)
        {
            base.SetEnabled(enable);
        }
    }

    [DebuggerHidden]
    private IEnumerator DoFlip()
    {
        return new <DoFlip>c__Iterator109 { <>f__this = this };
    }

    public FullDef GetFullDef()
    {
        return this.m_fullDef;
    }

    public long GetPreconDeckID()
    {
        return this.m_preconDeckID;
    }

    public bool IsLocked()
    {
        return this.m_locked;
    }

    public void Lock()
    {
        base.transform.parent.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
        this.m_locked = true;
    }

    public void Lower()
    {
        float num;
        this.Activate(false);
        if (this.m_locked)
        {
            num = 0.7f;
        }
        else
        {
            num = -0.7f;
        }
        object[] args = new object[] { "position", new Vector3(base.GetOriginalLocalPosition().x, base.GetOriginalLocalPosition().y + num, base.GetOriginalLocalPosition().z), "time", 0.1f, "easeType", iTween.EaseType.linear, "isLocal", true };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(base.gameObject, hashtable);
    }

    protected override void OnRelease()
    {
        this.Lower();
    }

    public void Raise()
    {
        if (!this.m_isSelected)
        {
            this.Activate(true);
            object[] args = new object[] { "position", new Vector3(base.GetOriginalLocalPosition().x, base.GetOriginalLocalPosition().y, base.GetOriginalLocalPosition().z), "time", 0.1f, "easeType", iTween.EaseType.linear, "isLocal", true };
            Hashtable hashtable = iTween.Hash(args);
            iTween.MoveTo(base.gameObject, hashtable);
        }
    }

    public void SetClassIcon(Material mat)
    {
        this.m_heroClassIcon.renderer.material = mat;
        this.m_heroClassIcon.renderer.material.renderQueue = 0xbbf;
    }

    public void SetClassname(string s)
    {
        this.m_classLabel.Text = s;
        this.m_progressBar.SetLabel(s);
    }

    public void SetFullDef(FullDef def)
    {
        this.m_fullDef = def;
    }

    public void SetHeroPortrait(Texture t)
    {
        base.transform.FindChild("HeroPremade_portrait_mesh").renderer.material.mainTexture = t;
    }

    public void SetHighlightState(ActorStateType stateType)
    {
        if (this.m_highlightState == null)
        {
            this.m_highlightState = base.gameObject.transform.parent.GetComponentInChildren<HighlightState>();
        }
        if (this.m_highlightState != null)
        {
            this.m_highlightState.ChangeState(stateType);
        }
    }

    public void SetPreconDeckID(long preconDeckID)
    {
        this.m_preconDeckID = preconDeckID;
    }

    public void SetProgress(int acknowledgedProgress, int currProgress, int maxProgress)
    {
        this.m_prevProgress = ((float) acknowledgedProgress) / ((float) maxProgress);
        this.m_currProgress = ((float) currProgress) / ((float) maxProgress);
        bool flag = acknowledgedProgress == currProgress;
        if (currProgress == maxProgress)
        {
            this.Unlock(!flag);
        }
        else if (flag)
        {
            this.m_progressBar.SetProgressBar(this.m_currProgress);
        }
        else
        {
            this.m_progressBar.AnimateProgress(this.m_prevProgress, this.m_currProgress);
        }
    }

    public void SetSelected(bool isSelected)
    {
        this.m_isSelected = isSelected;
        if (isSelected)
        {
            this.Lower();
        }
        else
        {
            this.Raise();
        }
    }

    public void ShowQuestBang(bool shown)
    {
        this.m_questBang.SetActive(shown);
    }

    private void Unlock(bool animate)
    {
        if (!animate)
        {
            base.transform.parent.localEulerAngles = new Vector3(0f, 180f, 0f);
            this.UnlockAfterAnimate();
        }
        else
        {
            base.StartCoroutine(this.DoFlip());
        }
    }

    private void UnlockAfterAnimate()
    {
        base.SetEnabled(true);
        this.m_locked = false;
    }

    [CompilerGenerated]
    private sealed class <DoFlip>c__Iterator109 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HeroPickerButton <>f__this;
        internal Hashtable <rotateArgs>__0;

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
                    this.$current = new WaitForSeconds(1.5f);
                    this.$PC = 1;
                    goto Label_0199;

                case 1:
                    this.<>f__this.m_progressBar.AnimateProgress(this.<>f__this.m_prevProgress, this.<>f__this.m_currProgress);
                    this.$current = new WaitForSeconds(this.<>f__this.m_progressBar.GetAnimationTime());
                    this.$PC = 2;
                    goto Label_0199;

                case 2:
                    this.<>f__this.m_keyholeEffect.animation.Play();
                    this.$current = new WaitForSeconds(this.<>f__this.m_keyholeEffect.animation.clip.length);
                    this.$PC = 3;
                    goto Label_0199;

                case 3:
                {
                    object[] args = new object[] { "amount", new Vector3(0f, 0f, 180f), "time", 1f, "easeType", iTween.EaseType.easeOutElastic, "space", Space.Self, "oncomplete", "UnlockAfterAnimate", "oncompletetarget", this.<>f__this.gameObject };
                    this.<rotateArgs>__0 = iTween.Hash(args);
                    iTween.RotateAdd(this.<>f__this.transform.parent.gameObject, this.<rotateArgs>__0);
                    this.$PC = -1;
                    break;
                }
            }
            return false;
        Label_0199:
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


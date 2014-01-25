using System;
using System.Collections;
using UnityEngine;

public class BoxStartButton : PegUIElement
{
    private BoxStartButtonStateInfo m_info;
    private Box m_parent;
    private State m_state;
    public TextMesh m_TextMesh;

    public bool ChangeState(State state)
    {
        if (this.m_state == state)
        {
            return false;
        }
        this.m_state = state;
        if (state == State.SHOWN)
        {
            this.m_parent.OnAnimStarted();
            base.gameObject.SetActive(true);
            object[] args = new object[] { "amount", this.m_info.m_ShownAlpha, "delay", this.m_info.m_ShownDelaySec, "time", this.m_info.m_ShownFadeSec, "easeType", this.m_info.m_ShownFadeEaseType, "oncomplete", "OnShownAnimFinished", "oncompletetarget", base.gameObject };
            Hashtable hashtable = iTween.Hash(args);
            iTween.FadeTo(base.gameObject, hashtable);
        }
        else if (state == State.HIDDEN)
        {
            this.m_parent.OnAnimStarted();
            object[] objArray2 = new object[] { "amount", this.m_info.m_HiddenAlpha, "delay", this.m_info.m_HiddenDelaySec, "time", this.m_info.m_HiddenFadeSec, "easeType", this.m_info.m_HiddenFadeEaseType, "oncomplete", "OnHiddenAnimFinished", "oncompletetarget", base.gameObject };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.FadeTo(base.gameObject, hashtable2);
        }
        return true;
    }

    public BoxStartButtonStateInfo GetInfo()
    {
        return this.m_info;
    }

    public Box GetParent()
    {
        return this.m_parent;
    }

    public string GetText()
    {
        return this.m_TextMesh.text;
    }

    private void OnHiddenAnimFinished()
    {
        base.gameObject.SetActive(false);
        this.m_parent.OnAnimFinished();
    }

    private void OnShownAnimFinished()
    {
        this.m_parent.OnAnimFinished();
    }

    public void SetInfo(BoxStartButtonStateInfo info)
    {
        this.m_info = info;
    }

    public void SetParent(Box parent)
    {
        this.m_parent = parent;
    }

    public void SetText(string text)
    {
        this.m_TextMesh.text = text;
        TextUtils.HackAssignOutlineText(this.m_TextMesh, text);
    }

    public void UpdateState(State state)
    {
        this.m_state = state;
        if (state == State.SHOWN)
        {
            RenderUtils.SetAlpha(base.gameObject, this.m_info.m_ShownAlpha);
            base.gameObject.SetActive(true);
        }
        else if (state == State.HIDDEN)
        {
            RenderUtils.SetAlpha(base.gameObject, this.m_info.m_HiddenAlpha);
            base.gameObject.SetActive(false);
        }
    }

    public enum State
    {
        SHOWN,
        HIDDEN
    }
}


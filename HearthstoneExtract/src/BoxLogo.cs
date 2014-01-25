using System;
using System.Collections;
using UnityEngine;

public class BoxLogo : MonoBehaviour
{
    private BoxLogoStateInfo m_info;
    private Box m_parent;
    private State m_state;

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
            object[] args = new object[] { "amount", this.m_info.m_ShownAlpha, "delay", this.m_info.m_ShownDelaySec, "time", this.m_info.m_ShownFadeSec, "easeType", this.m_info.m_ShownFadeEaseType, "oncomplete", "OnAnimFinished", "oncompletetarget", this.m_parent.gameObject };
            Hashtable hashtable = iTween.Hash(args);
            iTween.FadeTo(base.gameObject, hashtable);
        }
        else if (state == State.HIDDEN)
        {
            this.m_parent.OnAnimStarted();
            object[] objArray2 = new object[] { "amount", this.m_info.m_HiddenAlpha, "delay", this.m_info.m_HiddenDelaySec, "time", this.m_info.m_HiddenFadeSec, "easeType", this.m_info.m_HiddenFadeEaseType, "oncomplete", "OnAnimFinished", "oncompletetarget", this.m_parent.gameObject };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.FadeTo(base.gameObject, hashtable2);
        }
        return true;
    }

    public BoxLogoStateInfo GetInfo()
    {
        return this.m_info;
    }

    public Box GetParent()
    {
        return this.m_parent;
    }

    public void SetInfo(BoxLogoStateInfo info)
    {
        this.m_info = info;
    }

    public void SetParent(Box parent)
    {
        this.m_parent = parent;
    }

    public void UpdateState(State state)
    {
        this.m_state = state;
        if (state == State.SHOWN)
        {
            RenderUtils.SetAlpha(base.gameObject, this.m_info.m_ShownAlpha);
        }
        else if (state == State.HIDDEN)
        {
            RenderUtils.SetAlpha(base.gameObject, this.m_info.m_HiddenAlpha);
        }
    }

    public enum State
    {
        SHOWN,
        HIDDEN
    }
}


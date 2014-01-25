using System;
using System.Collections;
using UnityEngine;

public class BoxLoading : PegUIElement
{
    private const float DOT_MASK_SPEED = 3f;
    private const float DOT_MASK_WIDTH = 3f;
    private float m_dotMaskPos = -3f;
    public float m_HiddenAlpha;
    public float m_HiddenDelaySec;
    public iTween.EaseType m_HiddenFadeEaseType = iTween.EaseType.linear;
    public float m_HiddenFadeSec = 0.3f;
    private BoxLoadingStateInfo m_info;
    private Box m_parent;
    public float m_ShownAlpha = 1f;
    public float m_ShownDelaySec;
    public iTween.EaseType m_ShownFadeEaseType = iTween.EaseType.linear;
    public float m_ShownFadeSec = 0.3f;
    private State m_state;
    public TextMesh m_TextMesh;
    private const int MAX_DOTS = 3;
    private const float MAX_DOTS_VISIBLE = 3f;

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

    public BoxLoadingStateInfo GetInfo()
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

    public void SetInfo(BoxLoadingStateInfo info)
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

    private void Update()
    {
        this.m_dotMaskPos += 3f * UnityEngine.Time.deltaTime;
        if (this.m_dotMaskPos >= 3f)
        {
            this.m_dotMaskPos = -3f;
        }
        int num = Mathf.FloorToInt(this.m_dotMaskPos);
        int num2 = num + Mathf.FloorToInt(3f);
        string str = string.Empty;
        for (int i = 0; i < 3; i++)
        {
            if ((i >= num) && (i < num2))
            {
                str = str + ".";
            }
            else
            {
                str = str + " ";
            }
        }
        string textToApply = string.Format(GameStrings.Get("GLUE_LOADING"), str);
        this.m_TextMesh.text = textToApply;
        TextUtils.HackAssignOutlineText(this.m_TextMesh, textToApply);
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


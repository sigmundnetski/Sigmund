using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StoreDoneWithBAM : MonoBehaviour
{
    private static readonly Vector3 HIDDEN_SCALE = new Vector3(0.001f, 0.001f, 0.001f);
    private static readonly float HIDE_ANIM_TIME = 0.1f;
    private List<ButtonPressedListener> m_cancelListeners = new List<ButtonPressedListener>();
    public NormalButton m_closeButton;
    public UberText m_headlineText;
    public UberText m_messageText;
    public NormalButton m_okayButton;
    private List<ButtonPressedListener> m_okayListeners = new List<ButtonPressedListener>();
    private bool m_shown = true;
    private Vector3 m_targetPos = Vector3.zero;
    private Vector3 m_targetScale = Vector3.one;
    private static readonly float SHOW_ANIM_TIME = 0.5f;

    private void Awake()
    {
        this.m_headlineText.Text = GameStrings.Get("GLUE_STORE_DONE_WITH_BAM_HEADLINE");
        this.m_messageText.Text = GameStrings.Get("GLUE_STORE_DONE_WITH_BAM_MESSAGE");
        this.m_okayButton.SetText(GameStrings.Get("GLOBAL_OKAY"));
    }

    public void Hide()
    {
        this.Hide(false);
    }

    private void Hide(bool animate)
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            if (!animate)
            {
                this.OnHidden();
            }
            else
            {
                object[] args = new object[] { "scale", HIDDEN_SCALE, "isLocal", true, "time", HIDE_ANIM_TIME, "easetype", iTween.EaseType.linear, "name", "summaryScale", "oncomplete", "OnHidden", "oncompletetarget", base.gameObject };
                Hashtable hashtable = iTween.Hash(args);
                iTween.StopByName(base.gameObject, "summaryScale");
                iTween.ScaleTo(base.gameObject, hashtable);
            }
        }
    }

    private void OnCancelPressed(UIEvent e)
    {
        this.Hide(true);
        foreach (ButtonPressedListener listener in this.m_cancelListeners)
        {
            listener();
        }
    }

    private void OnHidden()
    {
        base.gameObject.SetActive(false);
    }

    private void OnOkayPressed(UIEvent e)
    {
        this.Hide(true);
        foreach (ButtonPressedListener listener in this.m_okayListeners)
        {
            listener();
        }
    }

    public void RegisterCancelListener(ButtonPressedListener listener)
    {
        if (!this.m_cancelListeners.Contains(listener))
        {
            this.m_cancelListeners.Add(listener);
        }
    }

    public void RegisterOkayListener(ButtonPressedListener listener)
    {
        if (!this.m_okayListeners.Contains(listener))
        {
            this.m_okayListeners.Add(listener);
        }
    }

    public void RemoveCancelListener(ButtonPressedListener listener)
    {
        this.m_cancelListeners.Remove(listener);
    }

    public void RemoveOkayListener(ButtonPressedListener listener)
    {
        this.m_okayListeners.Remove(listener);
    }

    public void SetTargetPosAndScale(Vector3 targetPos, Vector3 targetScale)
    {
        this.m_targetPos = targetPos;
        this.m_targetScale = targetScale;
    }

    public void Show()
    {
        if (!this.m_shown)
        {
            base.gameObject.transform.position = this.m_targetPos;
            this.m_shown = true;
            base.gameObject.SetActive(true);
            object[] args = new object[] { "scale", this.m_targetScale, "isLocal", false, "time", SHOW_ANIM_TIME, "easetype", iTween.EaseType.easeOutBounce, "name", "summaryScale" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(base.gameObject, "summaryScale");
            base.transform.localScale = HIDDEN_SCALE;
            iTween.ScaleTo(base.gameObject, hashtable);
        }
    }

    private void Start()
    {
        this.m_okayButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnOkayPressed));
        this.m_closeButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnCancelPressed));
    }

    public delegate void ButtonPressedListener();
}


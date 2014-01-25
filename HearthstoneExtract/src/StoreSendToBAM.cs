using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StoreSendToBAM : MonoBehaviour
{
    private static readonly string ADD_PAYMENT_URL = "https://battle.net/account/management/add-payment-method.html";
    private static readonly Vector3 HIDDEN_SCALE = new Vector3(0.001f, 0.001f, 0.001f);
    private static readonly float HIDE_ANIM_TIME = 0.1f;
    public NormalButton m_cancelButton;
    private List<DelCancelListener> m_cancelListeners = new List<DelCancelListener>();
    public NormalButton m_closeButton;
    public UberText m_headlineText;
    public UberText m_messageText;
    public NormalButton m_okayButton;
    private List<DelOKListener> m_okayListeners = new List<DelOKListener>();
    private BAMReason m_sendToBAMReason;
    private bool m_shown = true;
    private Vector3 m_targetPos = Vector3.zero;
    private Vector3 m_targetScale = Vector3.one;
    private static readonly string PAYMENT_INFO_URL = "https://battle.net/support/article/6742";
    private static readonly string RESET_PASSWORD_URL = "https://battle.net/account/support/password-reset.html";
    private static readonly string SEND_TO_BAM_THEN_HIDE_COROUTINE = "SendToBAMThenHide";
    private static readonly float SHOW_ANIM_TIME = 0.5f;

    private void Awake()
    {
        this.m_okayButton.SetText(GameStrings.Get("GLOBAL_OKAY"));
        this.m_cancelButton.SetText(GameStrings.Get("GLOBAL_CANCEL"));
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
        base.StopCoroutine(SEND_TO_BAM_THEN_HIDE_COROUTINE);
        this.Hide(true);
        foreach (DelCancelListener listener in this.m_cancelListeners)
        {
            listener();
        }
    }

    private void OnHidden()
    {
        base.gameObject.SetActive(false);
        this.m_okayButton.SetEnabled(true);
    }

    private void OnOkayPressed(UIEvent e)
    {
        base.StopCoroutine(SEND_TO_BAM_THEN_HIDE_COROUTINE);
        base.StartCoroutine(SEND_TO_BAM_THEN_HIDE_COROUTINE);
    }

    public void RegisterCancelListener(DelCancelListener listener)
    {
        if (!this.m_cancelListeners.Contains(listener))
        {
            this.m_cancelListeners.Add(listener);
        }
    }

    public void RegisterOkayListener(DelOKListener listener)
    {
        if (!this.m_okayListeners.Contains(listener))
        {
            this.m_okayListeners.Add(listener);
        }
    }

    public void RemoveCancelListener(DelCancelListener listener)
    {
        this.m_cancelListeners.Remove(listener);
    }

    public void RemoveOkayListener(DelOKListener listener)
    {
        this.m_okayListeners.Remove(listener);
    }

    [DebuggerHidden]
    private IEnumerator SendToBAMThenHide()
    {
        return new <SendToBAMThenHide>c__IteratorB7 { <>f__this = this };
    }

    public void SetTargetPosAndScale(Vector3 targetPos, Vector3 targetScale)
    {
        this.m_targetPos = targetPos;
        this.m_targetScale = targetScale;
    }

    public void Show(BAMReason reason)
    {
        this.m_sendToBAMReason = reason;
        this.UpdateText();
        if (!this.m_shown)
        {
            base.gameObject.transform.position = this.m_targetPos;
            this.m_shown = true;
            base.gameObject.SetActive(true);
            this.m_headlineText.UpdateNow();
            this.m_messageText.UpdateNow();
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
        this.m_cancelButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnCancelPressed));
        this.m_closeButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnCancelPressed));
    }

    private void UpdateText()
    {
        string str = string.Empty;
        string str2 = string.Empty;
        switch (this.m_sendToBAMReason)
        {
            case BAMReason.PAYMENT_INFO:
            {
                str = GameStrings.Get("GLUE_STORE_PAYMENT_FLOW_HEADLINE");
                object[] args = new object[] { GameStrings.Get("GLOBAL_OKAY") };
                str2 = GameStrings.Get("GLUE_STORE_PAYMENT_FLOW_EXPLANATION_1") + "\n\n" + GameStrings.Format("GLUE_STORE_PAYMENT_FLOW_EXPLANATION_2", args);
                break;
            }
            case BAMReason.NO_VALID_PAYMENT_METHOD:
            {
                str = GameStrings.Get("GLUE_STORE_SEND_TO_BAM_HEADLINE");
                object[] objArray2 = new object[] { GameStrings.Get("GLOBAL_OKAY") };
                str2 = GameStrings.Get("GLUE_STORE_SEND_TO_BAM_MESSAGE_1") + "\n\n" + GameStrings.Format("GLUE_STORE_SEND_TO_BAM_MESSAGE_2", objArray2);
                break;
            }
            case BAMReason.NEED_PASSWORD_RESET:
            {
                str = GameStrings.Get("GLUE_STORE_FORGOT_PASSWORD_HEADLINE");
                object[] objArray3 = new object[] { GameStrings.Get("GLOBAL_OKAY") };
                str2 = GameStrings.Get("GLUE_STORE_FORGOT_PASSWORD_MESSAGE_1") + "\n\n" + GameStrings.Format("GLUE_STORE_FORGOT_PASSWORD_MESSAGE_2", objArray3);
                break;
            }
        }
        this.m_headlineText.Text = str;
        this.m_messageText.Text = str2;
    }

    [CompilerGenerated]
    private sealed class <SendToBAMThenHide>c__IteratorB7 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<StoreSendToBAM.DelOKListener>.Enumerator <$s_859>__1;
        internal StoreSendToBAM <>f__this;
        internal StoreSendToBAM.DelOKListener <listener>__2;
        internal string <url>__0;

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
                    this.<>f__this.m_okayButton.SetEnabled(false);
                    this.<url>__0 = string.Empty;
                    switch (this.<>f__this.m_sendToBAMReason)
                    {
                        case StoreSendToBAM.BAMReason.PAYMENT_INFO:
                            this.<url>__0 = StoreSendToBAM.PAYMENT_INFO_URL;
                            break;

                        case StoreSendToBAM.BAMReason.NO_VALID_PAYMENT_METHOD:
                            this.<url>__0 = StoreSendToBAM.ADD_PAYMENT_URL;
                            break;

                        case StoreSendToBAM.BAMReason.NEED_PASSWORD_RESET:
                            this.<url>__0 = StoreSendToBAM.RESET_PASSWORD_URL;
                            break;
                    }
                    break;

                case 1:
                    this.<>f__this.Hide(true);
                    this.<$s_859>__1 = this.<>f__this.m_okayListeners.GetEnumerator();
                    try
                    {
                        while (this.<$s_859>__1.MoveNext())
                        {
                            this.<listener>__2 = this.<$s_859>__1.Current;
                            this.<listener>__2(this.<>f__this.m_sendToBAMReason);
                        }
                    }
                    finally
                    {
                        this.<$s_859>__1.Dispose();
                    }
                    this.$PC = -1;
                    goto Label_0142;

                default:
                    goto Label_0142;
            }
            if (!string.IsNullOrEmpty(this.<url>__0))
            {
                Application.OpenURL(this.<url>__0);
            }
            this.$current = new WaitForSeconds(2f);
            this.$PC = 1;
            return true;
        Label_0142:
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

    public enum BAMReason
    {
        PAYMENT_INFO,
        NO_VALID_PAYMENT_METHOD,
        NEED_PASSWORD_RESET
    }

    public delegate void DelCancelListener();

    public delegate void DelOKListener(StoreSendToBAM.BAMReason reason);
}


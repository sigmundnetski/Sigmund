using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StorePasswordPrompt : MonoBehaviour
{
    private static readonly Vector3 HIDDEN_SCALE = new Vector3(0.001f, 0.001f, 0.001f);
    private static readonly float HIDE_ANIM_TIME = 0.1f;
    private static readonly string HIDE_PASSWORD_COROUTINE_NAME = "WaitThenHidePassword";
    public NormalButton m_cancelButton;
    private List<CancelListener> m_cancelListeners = new List<CancelListener>();
    private ulong m_challengeID;
    public NormalButton m_closeButton;
    public UberText m_headlineText;
    public UberText m_messageText;
    private string m_password = string.Empty;
    public UberText m_passwordText;
    public GameObject m_root;
    private bool m_shown = true;
    public NormalButton m_submitButton;
    private List<SubmitListener> m_submitListeners = new List<SubmitListener>();
    private Vector3 m_targetPos = Vector3.zero;
    private Vector3 m_targetScale = Vector3.one;
    private static readonly float SHOW_ANIM_TIME = 0.5f;

    private void Awake()
    {
        this.m_headlineText.Text = GameStrings.Get("GLUE_STORE_PASSWORD_HEADLINE");
        this.m_submitButton.SetText(GameStrings.Get("GLUE_STORE_SUBMIT_BUTTON_TEXT"));
        this.m_cancelButton.SetText(GameStrings.Get("GLOBAL_CANCEL"));
    }

    public bool HandleKeyboardInput()
    {
        bool flag;
        if (!this.m_shown)
        {
            return false;
        }
        string keyboardInput = UniversalInputManager.Get().GetKeyboardInput(this.m_passwordText.Text, out flag);
        this.SetPassword(keyboardInput, true);
        if (flag)
        {
            this.OnSubmitPressed(null);
        }
        return true;
    }

    public ulong Hide()
    {
        ulong challengeID = this.m_challengeID;
        this.Hide(false);
        return challengeID;
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
                object[] args = new object[] { "scale", HIDDEN_SCALE, "isLocal", true, "time", HIDE_ANIM_TIME, "easetype", iTween.EaseType.linear, "name", "pwdPromptScale", "oncomplete", "OnHidden", "oncompletetarget", base.gameObject };
                Hashtable hashtable = iTween.Hash(args);
                iTween.StopByName(base.gameObject, "pwdPromptScale");
                iTween.ScaleTo(base.gameObject, hashtable);
            }
        }
    }

    private void HidePassword(int numCharsToHide)
    {
        string str = GameStrings.Get("GLUE_STORE_PASSWORD_HIDE_CHAR");
        char ch = (str.Length <= 0) ? '*' : str.ToCharArray()[0];
        numCharsToHide = Mathf.Min(this.m_password.Length, numCharsToHide);
        char[] chArray = this.m_password.ToCharArray();
        for (int i = 0; i < numCharsToHide; i++)
        {
            chArray[i] = ch;
        }
        this.m_passwordText.Text = new string(chArray);
    }

    private void OnCancelPressed(UIEvent e)
    {
        ulong challengeID = this.m_challengeID;
        this.Hide(true);
        foreach (CancelListener listener in this.m_cancelListeners)
        {
            listener(challengeID);
        }
    }

    private void OnHidden()
    {
        base.gameObject.SetActive(false);
        this.m_challengeID = 0L;
    }

    private void OnSubmitPressed(UIEvent e)
    {
        ulong challengeID = this.m_challengeID;
        this.Hide(true);
        foreach (SubmitListener listener in this.m_submitListeners)
        {
            listener(challengeID, this.m_password);
        }
    }

    public void RegisterCancelListener(CancelListener listener)
    {
        if (!this.m_cancelListeners.Contains(listener))
        {
            this.m_cancelListeners.Add(listener);
        }
    }

    public void RegisterSubmitListener(SubmitListener listener)
    {
        if (!this.m_submitListeners.Contains(listener))
        {
            this.m_submitListeners.Add(listener);
        }
    }

    public void RemoveConfirmListener(CancelListener listener)
    {
        this.m_cancelListeners.Remove(listener);
    }

    public void RemoveSubmitListener(SubmitListener listener)
    {
        this.m_submitListeners.Remove(listener);
    }

    private void SetPassword(string password, bool delayHide)
    {
        if (password.Length < this.m_password.Length)
        {
            this.m_password = this.m_password.Substring(0, password.Length);
            delayHide = false;
        }
        else if (this.m_password.Length < password.Length)
        {
            string str = password.Substring(this.m_password.Length);
            this.m_password = this.m_password + str;
        }
        if (delayHide)
        {
            base.StartCoroutine(HIDE_PASSWORD_COROUTINE_NAME, this.m_password.Length);
        }
        else
        {
            this.HidePassword(this.m_password.Length);
        }
    }

    public void SetTargetPosAndScale(Vector3 targetPos, Vector3 targetScale)
    {
        this.m_targetPos = targetPos;
        this.m_targetScale = targetScale;
    }

    public bool Show(ulong challengeID, bool isRetry)
    {
        if (this.m_shown)
        {
            return false;
        }
        this.m_shown = true;
        this.m_challengeID = challengeID;
        this.m_messageText.Text = !isRetry ? GameStrings.Get("GLUE_STORE_PASSWORD_MESSAGE") : GameStrings.Get("GLUE_STORE_PASSWORD_RETRY_MESSAGE");
        this.SetPassword(string.Empty, false);
        base.gameObject.transform.position = this.m_targetPos;
        base.gameObject.SetActive(true);
        object[] args = new object[] { "scale", this.m_targetScale, "isLocal", false, "time", SHOW_ANIM_TIME, "easetype", iTween.EaseType.easeOutBounce, "name", "pwdPromptScale" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(base.gameObject, "pwdPromptScale");
        base.transform.localScale = HIDDEN_SCALE;
        iTween.ScaleTo(base.gameObject, hashtable);
        return true;
    }

    private void Start()
    {
        this.m_submitButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnSubmitPressed));
        this.m_cancelButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnCancelPressed));
        this.m_closeButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnCancelPressed));
    }

    [DebuggerHidden]
    private IEnumerator WaitThenHidePassword(int numCharsToHide)
    {
        return new <WaitThenHidePassword>c__IteratorB5 { numCharsToHide = numCharsToHide, <$>numCharsToHide = numCharsToHide, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenHidePassword>c__IteratorB5 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>numCharsToHide;
        internal StorePasswordPrompt <>f__this;
        internal int numCharsToHide;

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
                    this.$current = new WaitForSeconds(0.5f);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (this.<>f__this.m_shown)
                    {
                        this.<>f__this.HidePassword(this.numCharsToHide);
                        this.$PC = -1;
                        break;
                    }
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

    public delegate void CancelListener(ulong challengeID);

    public delegate void SubmitListener(ulong challengeID, string password);
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DialogBase : MonoBehaviour
{
    protected readonly Vector3 AFTER_PUNCH_SCALE = new Vector3(500f, 500f, 500f);
    protected readonly Vector3 END_SCALE = new Vector3(520f, 520f, 520f);
    protected List<HideListener> m_hideListeners = new List<HideListener>();
    protected Vector3 m_originalPosition;
    private ShowAnimState m_showAnimState;
    protected bool m_shown;
    protected readonly Vector3 START_SCALE = new Vector3(0.01f, 0.01f, 0.01f);

    public bool AddHideListener(HideCallback callback)
    {
        return this.AddHideListener(callback, null);
    }

    public bool AddHideListener(HideCallback callback, object userData)
    {
        HideListener item = new HideListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_hideListeners.Contains(item))
        {
            return false;
        }
        this.m_hideListeners.Add(item);
        return true;
    }

    protected virtual void Awake()
    {
        this.m_originalPosition = base.transform.position;
        this.SetHiddenPosition();
        base.transform.parent = PegUI.Get().transform;
    }

    protected void DoHideAnimation()
    {
        AnimationUtil.ScaleFade(base.gameObject, this.START_SCALE, "OnHideAnimFinished");
    }

    protected void DoShowAnimation()
    {
        this.m_showAnimState = ShowAnimState.IN_PROGRESS;
        AnimationUtil.ShowWithPunch(base.gameObject, this.START_SCALE, this.END_SCALE, this.AFTER_PUNCH_SCALE, "OnShowAnimComplete");
    }

    protected void FireHideListeners()
    {
        HideListener[] listenerArray = this.m_hideListeners.ToArray();
        for (int i = 0; i < listenerArray.Length; i++)
        {
            listenerArray[i].Fire(this);
        }
    }

    public virtual void Hide()
    {
        this.m_shown = false;
        base.StartCoroutine(this.HideWhenAble());
    }

    [DebuggerHidden]
    private IEnumerator HideWhenAble()
    {
        return new <HideWhenAble>c__Iterator107 { <>f__this = this };
    }

    public virtual bool IsShown()
    {
        return this.m_shown;
    }

    protected virtual void OnHideAnimFinished()
    {
        this.SetHiddenPosition();
        UniversalInputManager.Get().SetSystemDialogActive(false);
        this.FireHideListeners();
    }

    private void OnShowAnimComplete()
    {
        this.m_showAnimState = ShowAnimState.FINISHED;
    }

    public bool RemoveHideListener(HideCallback callback)
    {
        return this.RemoveHideListener(callback, null);
    }

    public bool RemoveHideListener(HideCallback callback, object userData)
    {
        HideListener item = new HideListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_hideListeners.Remove(item);
    }

    protected void SetHiddenPosition()
    {
        base.transform.position = PegUI.Get().orthographicUICam.transform.TransformPoint(0f, 0f, -1000f);
    }

    protected void SetShownPosition()
    {
        base.transform.position = this.m_originalPosition;
    }

    public virtual void Show()
    {
        this.m_shown = true;
        this.SetShownPosition();
    }

    [CompilerGenerated]
    private sealed class <HideWhenAble>c__Iterator107 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal DialogBase <>f__this;

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
                case 1:
                    if (this.<>f__this.m_showAnimState == DialogBase.ShowAnimState.IN_PROGRESS)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<>f__this.DoHideAnimation();
                    this.$PC = -1;
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

    public delegate void HideCallback(DialogBase dialog, object userData);

    protected class HideListener : EventListener<DialogBase.HideCallback>
    {
        public void Fire(DialogBase dialog)
        {
            base.m_callback(dialog, base.m_userData);
        }
    }

    private enum ShowAnimState
    {
        NOT_CALLED,
        IN_PROGRESS,
        FINISHED
    }
}


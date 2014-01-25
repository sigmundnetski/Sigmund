using System;
using System.Collections;
using UnityEngine;

public class BoxDisk : MonoBehaviour
{
    private BoxDiskStateInfo m_info;
    private Box m_parent;
    private State m_state;

    public bool ChangeState(State state)
    {
        if (this.m_state == state)
        {
            return false;
        }
        this.m_state = state;
        if (state == State.LOADING)
        {
            this.m_parent.OnAnimStarted();
            Vector3 vector = this.m_info.m_LoadingRotation - base.transform.localRotation.eulerAngles;
            object[] args = new object[] { "amount", vector, "delay", this.m_info.m_LoadingDelaySec, "time", this.m_info.m_LoadingRotateSec, "easeType", this.m_info.m_LoadingRotateEaseType, "space", Space.Self, "oncomplete", "OnAnimFinished", "oncompletetarget", this.m_parent.gameObject };
            Hashtable hashtable = iTween.Hash(args);
            iTween.RotateAdd(base.gameObject, hashtable);
            this.m_parent.GetEventSpell(BoxEventType.DISK_LOADING).ActivateState(SpellStateType.BIRTH);
        }
        else if (state == State.MAINMENU)
        {
            this.m_parent.OnAnimStarted();
            Vector3 vector2 = this.m_info.m_MainMenuRotation - base.transform.localRotation.eulerAngles;
            object[] objArray2 = new object[] { "amount", vector2, "delay", this.m_info.m_MainMenuDelaySec, "time", this.m_info.m_MainMenuRotateSec, "easeType", this.m_info.m_MainMenuRotateEaseType, "space", Space.Self, "oncomplete", "OnAnimFinished", "oncompletetarget", this.m_parent.gameObject };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.RotateAdd(base.gameObject, hashtable2);
            this.m_parent.GetEventSpell(BoxEventType.DISK_MAIN_MENU).ActivateState(SpellStateType.BIRTH);
        }
        return true;
    }

    public BoxDiskStateInfo GetInfo()
    {
        return this.m_info;
    }

    public Box GetParent()
    {
        return this.m_parent;
    }

    public void SetInfo(BoxDiskStateInfo info)
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
        if (state == State.LOADING)
        {
            base.transform.localRotation = Quaternion.Euler(this.m_info.m_LoadingRotation);
            this.m_parent.GetEventSpell(BoxEventType.DISK_LOADING).ActivateState(SpellStateType.ACTION);
        }
        else if (state == State.MAINMENU)
        {
            base.transform.localRotation = Quaternion.Euler(this.m_info.m_MainMenuRotation);
            this.m_parent.GetEventSpell(BoxEventType.DISK_MAIN_MENU).ActivateState(SpellStateType.ACTION);
        }
    }

    public enum State
    {
        LOADING,
        MAINMENU
    }
}


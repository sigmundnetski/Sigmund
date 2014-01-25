using System;
using System.Collections;
using UnityEngine;

public class BoxCamera : MonoBehaviour
{
    public BoxCameraEventTable m_EventTable;
    private BoxCameraStateInfo m_info;
    private Box m_parent;
    private State m_state;

    public bool ChangeState(State state)
    {
        if (this.m_state == state)
        {
            return false;
        }
        this.m_state = state;
        if (state == State.CLOSED)
        {
            this.m_parent.OnAnimStarted();
            object[] args = new object[] { "position", this.m_info.m_ClosedBone.transform.position, "delay", this.m_info.m_ClosedDelaySec, "time", this.m_info.m_ClosedMoveSec, "easeType", this.m_info.m_ClosedMoveEaseType, "oncomplete", "OnAnimFinished", "oncompletetarget", this.m_parent.gameObject };
            Hashtable hashtable = iTween.Hash(args);
            iTween.MoveTo(base.gameObject, hashtable);
        }
        else if (state == State.CLOSED_WITH_DRAWER)
        {
            this.m_parent.OnAnimStarted();
            object[] objArray2 = new object[] { "position", this.m_info.m_ClosedWithDrawerBone.transform.position, "delay", this.m_info.m_ClosedWithDrawerDelaySec, "time", this.m_info.m_ClosedWithDrawerMoveSec, "easeType", this.m_info.m_ClosedWithDrawerMoveEaseType, "oncomplete", "OnAnimFinished", "oncompletetarget", this.m_parent.gameObject };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.MoveTo(base.gameObject, hashtable2);
        }
        else if (state == State.OPENED)
        {
            this.m_parent.OnAnimStarted();
            object[] objArray3 = new object[] { "position", this.m_info.m_OpenedBone.transform.position, "delay", this.m_info.m_OpenedDelaySec, "time", this.m_info.m_OpenedMoveSec, "easeType", this.m_info.m_OpenedMoveEaseType, "oncomplete", "OnAnimFinished", "oncompletetarget", this.m_parent.gameObject };
            Hashtable hashtable3 = iTween.Hash(objArray3);
            iTween.MoveTo(base.gameObject, hashtable3);
        }
        return true;
    }

    public BoxCameraEventTable GetEventTable()
    {
        return this.m_EventTable;
    }

    public BoxCameraStateInfo GetInfo()
    {
        return this.m_info;
    }

    public Box GetParent()
    {
        return this.m_parent;
    }

    public void SetInfo(BoxCameraStateInfo info)
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
        if (state == State.CLOSED)
        {
            base.transform.position = this.m_info.m_ClosedBone.transform.position;
        }
        else if (state == State.CLOSED_WITH_DRAWER)
        {
            base.transform.position = this.m_info.m_ClosedWithDrawerBone.transform.position;
        }
        else if (state == State.OPENED)
        {
            base.transform.position = this.m_info.m_OpenedBone.transform.position;
        }
    }

    public enum State
    {
        CLOSED,
        CLOSED_WITH_DRAWER,
        OPENED
    }
}


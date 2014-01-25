using System;
using System.Collections;
using UnityEngine;

public class BoxDrawer : MonoBehaviour
{
    private BoxDrawerStateInfo m_info;
    private Box m_parent;
    private State m_state;

    public bool ChangeState(State state)
    {
        if (DemoMgr.Get().GetMode() != DemoMode.PAX_EAST_2013)
        {
            if (this.m_state == state)
            {
                return false;
            }
            State state2 = this.m_state;
            this.m_state = state;
            if (this.IsInactiveState(state2) && this.IsInactiveState(this.m_state))
            {
                return true;
            }
            base.gameObject.SetActive(true);
            if (state == State.CLOSED)
            {
                this.m_parent.OnAnimStarted();
                object[] args = new object[] { "position", this.m_info.m_ClosedBone.transform.position, "delay", this.m_info.m_ClosedDelaySec, "time", this.m_info.m_ClosedMoveSec, "easeType", this.m_info.m_ClosedMoveEaseType, "oncomplete", "OnClosedAnimFinished", "oncompletetarget", base.gameObject };
                Hashtable hashtable = iTween.Hash(args);
                iTween.MoveTo(base.gameObject, hashtable);
                this.m_parent.GetEventSpell(BoxEventType.DRAWER_CLOSE).Activate();
            }
            else if (state == State.CLOSED_BOX_OPENED)
            {
                this.m_parent.OnAnimStarted();
                object[] objArray2 = new object[] { "position", this.m_info.m_ClosedBoxOpenedBone.transform.position, "delay", this.m_info.m_ClosedBoxOpenedDelaySec, "time", this.m_info.m_ClosedBoxOpenedMoveSec, "easeType", this.m_info.m_ClosedBoxOpenedMoveEaseType, "oncomplete", "OnClosedBoxOpenedAnimFinished", "oncompletetarget", base.gameObject };
                Hashtable hashtable2 = iTween.Hash(objArray2);
                iTween.MoveTo(base.gameObject, hashtable2);
                this.m_parent.GetEventSpell(BoxEventType.DRAWER_CLOSE).Activate();
            }
            else if (state == State.OPENED)
            {
                this.m_parent.OnAnimStarted();
                object[] objArray3 = new object[] { "position", this.m_info.m_OpenedBone.transform.position, "delay", this.m_info.m_OpenedDelaySec, "time", this.m_info.m_OpenedMoveSec, "easeType", this.m_info.m_OpenedMoveEaseType, "oncomplete", "OnOpenedAnimFinished", "oncompletetarget", base.gameObject };
                Hashtable hashtable3 = iTween.Hash(objArray3);
                iTween.MoveTo(base.gameObject, hashtable3);
                this.m_parent.GetEventSpell(BoxEventType.DRAWER_OPEN).Activate();
            }
        }
        return true;
    }

    public BoxDrawerStateInfo GetInfo()
    {
        return this.m_info;
    }

    public Box GetParent()
    {
        return this.m_parent;
    }

    private bool IsInactiveState(State state)
    {
        return ((state == State.CLOSED) || (state == State.CLOSED_BOX_OPENED));
    }

    private void OnClosedAnimFinished()
    {
        base.gameObject.SetActive(false);
        this.m_parent.OnAnimFinished();
    }

    private void OnClosedBoxOpenedAnimFinished()
    {
        base.gameObject.SetActive(false);
        this.m_parent.OnAnimFinished();
    }

    private void OnOpenedAnimFinished()
    {
        base.gameObject.SetActive(true);
        this.m_parent.OnAnimFinished();
    }

    public void SetInfo(BoxDrawerStateInfo info)
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
            base.gameObject.SetActive(false);
        }
        else if (state == State.CLOSED_BOX_OPENED)
        {
            base.transform.position = this.m_info.m_ClosedBoxOpenedBone.transform.position;
            base.gameObject.SetActive(false);
        }
        else if (state == State.OPENED)
        {
            base.transform.position = this.m_info.m_OpenedBone.transform.position;
            base.gameObject.SetActive(true);
        }
    }

    public enum State
    {
        CLOSED,
        CLOSED_BOX_OPENED,
        OPENED
    }
}


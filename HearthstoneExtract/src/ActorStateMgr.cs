using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStateMgr : MonoBehaviour
{
    private ActorStateType m_activeStateType;
    private Dictionary<ActorStateType, List<ActorState>> m_actorStateMap = new Dictionary<ActorStateType, List<ActorState>>();
    private HighlightState m_HighlightState;
    public GameObject m_ObjectContainer;
    private bool m_shown = true;

    private void BuildStateMap()
    {
        IEnumerator enumerator = base.transform.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                Transform current = (Transform) enumerator.Current;
                ActorState component = current.gameObject.GetComponent<ActorState>();
                if (component != null)
                {
                    ActorStateType stateType = component.m_StateType;
                    if (stateType != ActorStateType.NONE)
                    {
                        List<ActorState> list;
                        if (!this.m_actorStateMap.TryGetValue(stateType, out list))
                        {
                            list = new List<ActorState>();
                            this.m_actorStateMap.Add(stateType, list);
                        }
                        list.Add(component);
                    }
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    public bool ChangeState(ActorStateType stateType)
    {
        return (this.ChangeState_NewState(stateType) || this.ChangeState_LegacyState(stateType));
    }

    public bool ChangeState_LegacyState(ActorStateType stateType)
    {
        List<ActorState> list = null;
        this.m_actorStateMap.TryGetValue(stateType, out list);
        ActorStateType activeStateType = this.m_activeStateType;
        this.m_activeStateType = stateType;
        if (activeStateType != ActorStateType.NONE)
        {
            List<ActorState> list2;
            if (this.m_actorStateMap.TryGetValue(activeStateType, out list2))
            {
                foreach (ActorState state in list2)
                {
                    state.Stop(list);
                }
            }
        }
        else if ((stateType != ActorStateType.NONE) && (this.m_ObjectContainer != null))
        {
            this.m_ObjectContainer.SetActive(true);
        }
        if (stateType == ActorStateType.NONE)
        {
            if ((activeStateType != ActorStateType.NONE) && (this.m_ObjectContainer != null))
            {
                this.m_ObjectContainer.SetActive(false);
            }
            return true;
        }
        if (list == null)
        {
            return false;
        }
        foreach (ActorState state2 in list)
        {
            state2.Play();
        }
        return true;
    }

    public bool ChangeState_NewState(ActorStateType stateType)
    {
        if (this.m_HighlightState == null)
        {
            return false;
        }
        ActorStateType activeStateType = this.m_activeStateType;
        this.m_activeStateType = stateType;
        if ((activeStateType != ActorStateType.NONE) && (activeStateType != stateType))
        {
            return this.m_HighlightState.ChangeState(stateType);
        }
        return true;
    }

    private HighlightState FindHightlightObject()
    {
        IEnumerator enumerator = base.transform.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                Transform current = (Transform) enumerator.Current;
                HighlightState component = current.gameObject.GetComponent<HighlightState>();
                if (component != null)
                {
                    return component;
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
        return null;
    }

    public void ForceActiveStateTypeWithoutChangingVisual(ActorStateType stateType)
    {
        this.m_activeStateType = stateType;
    }

    public List<ActorState> GetActiveStateList()
    {
        List<ActorState> list = null;
        if (!this.m_actorStateMap.TryGetValue(this.m_activeStateType, out list))
        {
            return null;
        }
        return list;
    }

    public ActorStateType GetActiveStateType()
    {
        return this.m_activeStateType;
    }

    public float GetMaximumAnimationTimeOfActiveStates()
    {
        if (this.GetActiveStateList() == null)
        {
            return 0f;
        }
        float b = 0f;
        foreach (ActorState state in this.GetActiveStateList())
        {
            b = Mathf.Max(state.GetAnimationDuration(), b);
        }
        return b;
    }

    public Dictionary<ActorStateType, List<ActorState>> GetStateMap()
    {
        return this.m_actorStateMap;
    }

    private void HideImpl()
    {
        if (this.m_HighlightState != null)
        {
            this.m_HighlightState.ChangeState(ActorStateType.NONE);
        }
        List<ActorState> activeStateList = this.GetActiveStateList();
        if (activeStateList != null)
        {
            foreach (ActorState state in activeStateList)
            {
                state.HideState();
            }
        }
        if ((this.m_activeStateType != ActorStateType.NONE) && (this.m_ObjectContainer != null))
        {
            this.m_ObjectContainer.SetActive(false);
        }
    }

    public void HideStateMgr()
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            this.HideImpl();
        }
    }

    public void RefreshStateMgr()
    {
        if (this.m_HighlightState != null)
        {
            this.m_HighlightState.SetDirty();
        }
    }

    private void ShowImpl()
    {
        if (this.m_HighlightState != null)
        {
            this.m_HighlightState.ChangeState(this.m_activeStateType);
        }
        if ((this.m_activeStateType != ActorStateType.NONE) && (this.m_ObjectContainer != null))
        {
            this.m_ObjectContainer.SetActive(true);
        }
        List<ActorState> activeStateList = this.GetActiveStateList();
        if (activeStateList != null)
        {
            foreach (ActorState state in activeStateList)
            {
                state.ShowState();
            }
        }
    }

    public void ShowStateMgr()
    {
        if (!this.m_shown)
        {
            this.m_shown = true;
            this.ShowImpl();
        }
    }

    private void Start()
    {
        this.m_HighlightState = this.FindHightlightObject();
        this.BuildStateMap();
        if (this.m_activeStateType == ActorStateType.NONE)
        {
            this.HideImpl();
        }
        else if (this.m_shown)
        {
            this.ShowImpl();
        }
        else
        {
            this.HideImpl();
        }
    }
}


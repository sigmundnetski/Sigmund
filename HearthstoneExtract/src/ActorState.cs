using System;
using System.Collections.Generic;
using UnityEngine;

public class ActorState : MonoBehaviour
{
    public List<ActorStateAnimObject> m_ExternalAnimatedObjects;
    private bool m_initialized;
    private bool m_playing;
    private ActorStateMgr m_stateMgr;
    public ActorStateType m_StateType;

    public float GetAnimationDuration()
    {
        float b = 0f;
        for (int i = 0; i < this.m_ExternalAnimatedObjects.Count; i++)
        {
            if (this.m_ExternalAnimatedObjects[i].m_GameObject != null)
            {
                b = Mathf.Max(this.m_ExternalAnimatedObjects[i].m_AnimClip.length, b);
            }
        }
        return b;
    }

    public void HideState()
    {
        this.Stop(null);
        base.gameObject.SetActive(false);
    }

    private void OnChangeState(ActorStateType stateType)
    {
        this.m_stateMgr.ChangeState(stateType);
    }

    public void Play()
    {
        if (!this.m_playing)
        {
            this.m_playing = true;
            if (this.m_initialized)
            {
                base.gameObject.SetActive(true);
                this.PlayNow();
            }
        }
    }

    private void PlayNow()
    {
        if (base.animation != null)
        {
            base.animation.Play();
        }
        if (base.particleEmitter != null)
        {
            base.particleEmitter.emit = true;
        }
        foreach (ActorStateAnimObject obj2 in this.m_ExternalAnimatedObjects)
        {
            obj2.Play();
        }
    }

    public void ShowState()
    {
        base.gameObject.SetActive(true);
        this.Play();
    }

    private void Start()
    {
        this.m_stateMgr = SceneUtils.FindComponentInParents<ActorStateMgr>(base.gameObject);
        foreach (ActorStateAnimObject obj2 in this.m_ExternalAnimatedObjects)
        {
            obj2.Init();
        }
        this.m_initialized = true;
        if (this.m_playing)
        {
            base.gameObject.SetActive(true);
            this.PlayNow();
        }
    }

    public void Stop(List<ActorState> nextStateList)
    {
        if (this.m_playing)
        {
            this.m_playing = false;
            if (this.m_initialized)
            {
                if (base.animation != null)
                {
                    base.animation.Stop();
                }
                if (base.particleEmitter != null)
                {
                    base.particleEmitter.emit = false;
                }
                if (nextStateList == null)
                {
                    foreach (ActorStateAnimObject obj2 in this.m_ExternalAnimatedObjects)
                    {
                        obj2.Stop();
                    }
                }
                else
                {
                    foreach (ActorStateAnimObject obj3 in this.m_ExternalAnimatedObjects)
                    {
                        obj3.Stop(nextStateList);
                    }
                }
                base.gameObject.SetActive(false);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActorStateAnimObject
{
    public AnimationClip m_AnimClip;
    public int m_AnimLayer;
    public string m_Comment;
    public bool m_ControlParticles;
    public float m_CrossFadeSec;
    public bool m_EmitParticles;
    public bool m_Enabled = true;
    public GameObject m_GameObject;
    private bool m_prevParticleEmitValue;

    public void Init()
    {
        if ((this.m_GameObject != null) && (this.m_AnimClip != null))
        {
            Animation animation;
            string name = this.m_AnimClip.name;
            if (this.m_GameObject.animation == null)
            {
                animation = this.m_GameObject.AddComponent<Animation>();
            }
            else
            {
                animation = this.m_GameObject.animation;
            }
            animation.playAutomatically = false;
            if (animation[name] == null)
            {
                animation.AddClip(this.m_AnimClip, name);
            }
            animation[name].layer = this.m_AnimLayer;
        }
    }

    public void Play()
    {
        if (this.m_Enabled && (this.m_GameObject != null))
        {
            if (this.m_AnimClip != null)
            {
                string name = this.m_AnimClip.name;
                this.m_GameObject.animation[name].enabled = true;
                if (object.Equals(this.m_CrossFadeSec, 0f))
                {
                    if (!this.m_GameObject.animation.Play(name))
                    {
                        Debug.LogWarning(string.Format("ActorStateAnimObject.PlayNow() - FAILED to play clip {0} on {1}", name, this.m_GameObject));
                    }
                }
                else
                {
                    this.m_GameObject.animation.CrossFade(name, this.m_CrossFadeSec);
                }
            }
            if (this.m_ControlParticles && (this.m_GameObject.particleEmitter != null))
            {
                this.m_GameObject.particleEmitter.emit = this.m_EmitParticles;
            }
        }
    }

    public void Stop()
    {
        if (this.m_Enabled && (this.m_GameObject != null))
        {
            if (this.m_AnimClip != null)
            {
                this.m_GameObject.animation[this.m_AnimClip.name].time = 0f;
                this.m_GameObject.animation.Sample();
                this.m_GameObject.animation[this.m_AnimClip.name].enabled = false;
            }
            if (this.m_ControlParticles && (this.m_GameObject.particleEmitter != null))
            {
                this.m_GameObject.particleEmitter.emit = this.m_EmitParticles;
            }
        }
    }

    public void Stop(List<ActorState> nextStateList)
    {
        if (this.m_Enabled && (this.m_GameObject != null))
        {
            if (this.m_AnimClip != null)
            {
                bool flag = false;
                for (int i = 0; !flag && (i < nextStateList.Count); i++)
                {
                    ActorState state = nextStateList[i];
                    for (int j = 0; j < state.m_ExternalAnimatedObjects.Count; j++)
                    {
                        ActorStateAnimObject obj2 = state.m_ExternalAnimatedObjects[j];
                        if ((this.m_GameObject == obj2.m_GameObject) && (this.m_AnimLayer == obj2.m_AnimLayer))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    this.m_GameObject.animation.Stop(this.m_AnimClip.name);
                }
            }
            if (this.m_ControlParticles && (this.m_GameObject.particleEmitter != null))
            {
                this.m_GameObject.particleEmitter.emit = this.m_EmitParticles;
            }
        }
    }
}


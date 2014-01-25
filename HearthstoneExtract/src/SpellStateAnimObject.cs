using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpellStateAnimObject
{
    public AnimationClip m_AnimClip;
    public int m_AnimLayer;
    public float m_AnimSpeed = 1f;
    public string m_Comment;
    public bool m_ControlParticles;
    public float m_CrossFadeSec;
    public bool m_EmitParticles;
    public bool m_Enabled = true;
    public GameObject m_GameObject;
    private bool m_prevParticleEmitValue;
    public Target m_Target;

    public void Hide()
    {
        if (this.m_GameObject != null)
        {
            this.m_GameObject.SetActive(false);
        }
    }

    public void Init()
    {
        if ((this.m_GameObject != null) && (this.m_AnimClip != null))
        {
            this.SetupAnimation();
        }
    }

    public void OnLoad(SpellState state)
    {
        if (this.m_Target == Target.AS_SPECIFIED)
        {
            if (this.m_GameObject == null)
            {
                Debug.LogError("Error: spell state anim target has a null game object after load");
            }
        }
        else if (this.m_Target == Target.ACTOR)
        {
            Actor actor = SceneUtils.FindComponentInParents<Actor>(state.transform);
            if ((actor == null) || (actor.gameObject == null))
            {
                Debug.LogError("Error: spell state anim target has a null game object after load");
            }
            else
            {
                this.m_GameObject = actor.gameObject;
                this.SetupAnimation();
            }
        }
        else if (this.m_Target == Target.ROOT_OBJECT)
        {
            Actor actor2 = SceneUtils.FindComponentInParents<Actor>(state.transform);
            if ((actor2 == null) || (actor2.gameObject == null))
            {
                Debug.LogError("Error: spell state anim target has a null game object after load");
            }
            else
            {
                this.m_GameObject = actor2.GetRootObject();
                this.SetupAnimation();
            }
        }
        else
        {
            Debug.LogWarning("Error: unimplemented spell anim target");
        }
    }

    public void Play()
    {
        if (this.m_Enabled && (this.m_GameObject != null))
        {
            if (this.m_AnimClip != null)
            {
                Animation animation = this.m_GameObject.animation;
                string name = this.m_AnimClip.name;
                AnimationState state = animation[name];
                state.enabled = true;
                state.speed = this.m_AnimSpeed;
                if (object.Equals(this.m_CrossFadeSec, 0f))
                {
                    if (!animation.Play(name))
                    {
                        Debug.LogWarning(string.Format("SpellStateAnimObject.PlayNow() - FAILED to play clip {0} on {1}", name, this.m_GameObject));
                    }
                }
                else
                {
                    animation.CrossFade(name, this.m_CrossFadeSec);
                }
            }
            if (this.m_ControlParticles)
            {
                if (this.m_GameObject.particleEmitter != null)
                {
                    this.m_prevParticleEmitValue = this.m_GameObject.particleEmitter.emit;
                    this.m_GameObject.particleEmitter.emit = this.m_EmitParticles;
                }
                ParticleSystem component = this.m_GameObject.GetComponent<ParticleSystem>();
                if (component != null)
                {
                    component.Play();
                }
            }
        }
    }

    private void SetupAnimation()
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

    public void Show()
    {
        if (this.m_GameObject != null)
        {
            this.m_GameObject.SetActive(true);
        }
    }

    public void Stop()
    {
        if (this.m_GameObject != null)
        {
            if (this.m_AnimClip != null)
            {
                this.m_GameObject.animation.Stop(this.m_AnimClip.name);
            }
            if (this.m_ControlParticles)
            {
                if (this.m_GameObject.particleEmitter != null)
                {
                    this.m_GameObject.particleEmitter.emit = this.m_prevParticleEmitValue;
                }
                ParticleSystem component = this.m_GameObject.GetComponent<ParticleSystem>();
                if (component != null)
                {
                    component.Stop();
                }
            }
        }
    }

    public void Stop(List<SpellState> nextStateList)
    {
        if (this.m_GameObject != null)
        {
            if (this.m_AnimClip != null)
            {
                bool flag = false;
                for (int i = 0; !flag && (i < nextStateList.Count); i++)
                {
                    SpellState state = nextStateList[i];
                    for (int j = 0; j < state.m_ExternalAnimatedObjects.Count; j++)
                    {
                        SpellStateAnimObject obj2 = state.m_ExternalAnimatedObjects[j];
                        if (obj2.m_Enabled && ((this.m_GameObject == obj2.m_GameObject) && (this.m_AnimLayer == obj2.m_AnimLayer)))
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
            if (this.m_ControlParticles)
            {
                if (this.m_GameObject.particleEmitter != null)
                {
                    this.m_GameObject.particleEmitter.emit = this.m_prevParticleEmitValue;
                }
                ParticleSystem component = this.m_GameObject.GetComponent<ParticleSystem>();
                if (component != null)
                {
                    component.Stop();
                }
            }
        }
    }

    public enum Target
    {
        AS_SPECIFIED,
        ACTOR,
        ROOT_OBJECT
    }
}


using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetListAnimUtils2 : MonoBehaviour
{
    public List<GameObject> m_TargetList;

    public void ActivateHierarchyList2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                obj2.SetActive(true);
            }
        }
    }

    public void DeactivateHierarchyList2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                obj2.SetActive(false);
            }
        }
    }

    public void DestroyHierarchyList2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            SceneUtils.Destroy(obj2);
        }
    }

    public void FadeInList2(float FadeSec)
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            iTween.FadeTo(obj2, 1f, FadeSec);
        }
    }

    public void FadeOutList2(float FadeSec)
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            iTween.FadeTo(obj2, 0f, FadeSec);
        }
    }

    public void KillParticlesList2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                obj2.particleEmitter.particles = new UnityEngine.Particle[0];
            }
        }
    }

    public void KillParticlesListInChildren2()
    {
        UnityEngine.Particle[] particleArray = new UnityEngine.Particle[0];
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                foreach (ParticleEmitter emitter in obj2.GetComponentsInChildren<ParticleEmitter>())
                {
                    emitter.emit = false;
                    emitter.particles = particleArray;
                }
            }
        }
    }

    public void PlayAnimationList2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                obj2.animation.Play();
            }
        }
    }

    public void PlayAnimationListInChildren2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                foreach (Animation animation in obj2.GetComponentsInChildren<Animation>())
                {
                    animation.Play();
                }
            }
        }
    }

    public void PlayParticlesList2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                obj2.particleEmitter.emit = true;
            }
        }
    }

    public void PlayParticlesListInChildren2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                foreach (ParticleEmitter emitter in obj2.GetComponentsInChildren<ParticleEmitter>())
                {
                    emitter.emit = true;
                }
            }
        }
    }

    public void SetAlphaHierarchyList2(float alpha)
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                foreach (UnityEngine.Renderer renderer in obj2.GetComponentsInChildren<UnityEngine.Renderer>())
                {
                    if (renderer.material.HasProperty("_Color"))
                    {
                        Color color = renderer.material.color;
                        color.a = alpha;
                        renderer.material.color = color;
                    }
                }
            }
        }
    }

    public void StopAnimationList2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                obj2.animation.Stop();
            }
        }
    }

    public void StopAnimationListInChildren2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                foreach (Animation animation in obj2.GetComponentsInChildren<Animation>())
                {
                    animation.Stop();
                }
            }
        }
    }

    public void StopParticlesList2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                obj2.particleEmitter.emit = false;
            }
        }
    }

    public void StopParticlesListInChildren2()
    {
        foreach (GameObject obj2 in this.m_TargetList)
        {
            if (obj2 != null)
            {
                foreach (ParticleEmitter emitter in obj2.GetComponentsInChildren<ParticleEmitter>())
                {
                    emitter.emit = false;
                }
            }
        }
    }
}


using System;
using UnityEngine;

public class TargetAnimUtils : MonoBehaviour
{
    public GameObject m_Target;

    public void ActivateHierarchy()
    {
        this.m_Target.SetActive(true);
    }

    public void DeactivateHierarchy()
    {
        this.m_Target.SetActive(false);
    }

    public void DestroyHierarchy()
    {
        SceneUtils.Destroy(this.m_Target);
    }

    public void FadeIn(float FadeSec)
    {
        iTween.FadeTo(this.m_Target, 1f, FadeSec);
    }

    public void FadeOut(float FadeSec)
    {
        iTween.FadeTo(this.m_Target, 0f, FadeSec);
    }

    public void KillParticlesInChildren()
    {
        UnityEngine.Particle[] particleArray = new UnityEngine.Particle[0];
        foreach (ParticleEmitter emitter in this.m_Target.GetComponentsInChildren<ParticleEmitter>())
        {
            emitter.emit = false;
            emitter.particles = particleArray;
        }
    }

    public void PlayAnimation()
    {
        if (this.m_Target.animation != null)
        {
            this.m_Target.animation.Play();
        }
    }

    public void PlayAnimationsInChildren()
    {
        foreach (Animation animation in this.m_Target.GetComponentsInChildren<Animation>())
        {
            animation.Play();
        }
    }

    public void PlayDefaultSound()
    {
        if (this.m_Target.audio == null)
        {
            Debug.LogError(string.Format("TargetAnimUtils.PlayDefaultSound() - Tried to play the AudioSource on {0} but it has no AudioSource. You need an AudioSource to use this function.", this.m_Target));
        }
        else if (SoundManager.Get() == null)
        {
            this.m_Target.audio.Play();
        }
        else
        {
            SoundManager.Get().Play(this.m_Target.audio);
        }
    }

    public void PlayParticles()
    {
        if (this.m_Target.particleEmitter != null)
        {
            this.m_Target.particleEmitter.emit = true;
        }
    }

    public void PlayParticlesInChildren()
    {
        foreach (ParticleEmitter emitter in this.m_Target.GetComponentsInChildren<ParticleEmitter>())
        {
            emitter.emit = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogError(string.Format("TargetAnimUtils.PlayDefaultSound() - No clip was given when trying to play the AudioSource on {0}. You need a clip to use this function.", this.m_Target));
        }
        else if (this.m_Target.audio == null)
        {
            Debug.LogError(string.Format("TargetAnimUtils.PlayDefaultSound() - Tried to play clip {0} on {1} but it has no AudioSource. You need an AudioSource to use this function.", clip, this.m_Target));
        }
        else if (SoundManager.Get() == null)
        {
            this.m_Target.audio.PlayOneShot(clip);
        }
        else
        {
            SoundManager.Get().PlayOneShot(this.m_Target.audio, clip);
        }
    }

    public void PrintLog(string message)
    {
        Debug.Log(message);
    }

    public void PrintLogError(string message)
    {
        Debug.LogError(message);
    }

    public void PrintLogWarning(string message)
    {
        Debug.LogWarning(message);
    }

    public void SetAlphaHierarchy(float alpha)
    {
        foreach (UnityEngine.Renderer renderer in this.m_Target.GetComponentsInChildren<UnityEngine.Renderer>())
        {
            if (renderer.material.HasProperty("_Color"))
            {
                Color color = renderer.material.color;
                color.a = alpha;
                renderer.material.color = color;
            }
        }
    }

    public void StopAnimation()
    {
        if (this.m_Target.animation != null)
        {
            this.m_Target.animation.Stop();
        }
    }

    public void StopAnimationsInChildren()
    {
        foreach (Animation animation in this.m_Target.GetComponentsInChildren<Animation>())
        {
            animation.Stop();
        }
    }

    public void StopParticles()
    {
        if (this.m_Target.particleEmitter != null)
        {
            this.m_Target.particleEmitter.emit = false;
        }
    }

    public void StopParticlesInChildren()
    {
        foreach (ParticleEmitter emitter in this.m_Target.GetComponentsInChildren<ParticleEmitter>())
        {
            emitter.emit = false;
        }
    }
}


using System;
using UnityEngine;

public class SelfAnimUtils : MonoBehaviour
{
    public void ActivateHierarchy()
    {
        base.gameObject.SetActive(true);
    }

    public void DeactivateHierarchy()
    {
        base.gameObject.SetActive(false);
    }

    public void DestroyHierarchy()
    {
        SceneUtils.Destroy(base.gameObject);
    }

    public void FadeIn(float FadeSec)
    {
        iTween.FadeTo(base.gameObject, 1f, FadeSec);
    }

    public void FadeOut(float FadeSec)
    {
        iTween.FadeTo(base.gameObject, 0f, FadeSec);
    }

    public void KillParticles()
    {
        if (base.particleEmitter != null)
        {
            base.particleEmitter.emit = false;
            base.particleEmitter.particles = new UnityEngine.Particle[0];
        }
    }

    public void PlayAnimation()
    {
        if (base.animation != null)
        {
            base.animation.Play();
        }
    }

    public void PlayDefaultSound()
    {
        if (base.audio == null)
        {
            Debug.LogError(string.Format("SelfAnimUtils.PlayDefaultSound() - Tried to play the AudioSource on {0} but it has no AudioSource. You need an AudioSource to use this function.", base.gameObject));
        }
        else if (SoundManager.Get() == null)
        {
            base.audio.Play();
        }
        else
        {
            SoundManager.Get().Play(base.audio);
        }
    }

    public void PlayParticles()
    {
        if (base.particleEmitter != null)
        {
            base.particleEmitter.emit = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogError(string.Format("SelfAnimUtils.PlayDefaultSound() - No clip was given when trying to play the AudioSource on {0}. You need a clip to use this function.", base.gameObject));
        }
        else if (base.audio == null)
        {
            Debug.LogError(string.Format("SelfAnimUtils.PlayDefaultSound() - Tried to play clip {0} on {1} but it has no AudioSource. You need an AudioSource to use this function.", clip, base.gameObject));
        }
        else if (SoundManager.Get() == null)
        {
            base.audio.PlayOneShot(clip);
        }
        else
        {
            SoundManager.Get().PlayOneShot(base.audio, clip);
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

    public void RandomRotationX()
    {
        TransformUtil.SetEulerAngleX(base.gameObject, UnityEngine.Random.Range((float) 0f, (float) 360f));
    }

    public void RandomRotationY()
    {
        TransformUtil.SetEulerAngleY(base.gameObject, UnityEngine.Random.Range((float) 0f, (float) 360f));
    }

    public void RandomRotationZ()
    {
        TransformUtil.SetEulerAngleZ(base.gameObject, UnityEngine.Random.Range((float) 0f, (float) 360f));
    }

    public void SetAlphaHierarchy(float alpha)
    {
        foreach (UnityEngine.Renderer renderer in base.GetComponentsInChildren<UnityEngine.Renderer>())
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
        if (base.animation != null)
        {
            base.animation.Stop();
        }
    }

    public void StopParticles()
    {
        if (base.particleEmitter != null)
        {
            base.particleEmitter.emit = false;
        }
    }
}


using System;
using UnityEngine;

public class MageExplosion : MonoBehaviour
{
    public GameObject m_ring;

    private void Awake()
    {
    }

    private void KillExplosion()
    {
        foreach (ParticleEmitter emitter in base.transform.GetComponentsInChildren<ParticleEmitter>())
        {
            ParticleAnimator component = emitter.transform.GetComponent<ParticleAnimator>();
            if (component != null)
            {
                component.autodestruct = true;
            }
            UnityEngine.Particle[] particles = emitter.particles;
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].energy = 0.1f;
            }
            emitter.particles = particles;
        }
        UnityEngine.Object.Destroy(this);
    }

    public void Play()
    {
    }

    private void Start()
    {
    }
}


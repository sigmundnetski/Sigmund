using System;
using UnityEngine;

public class ParticleEmitSelf : MonoBehaviour
{
    public void PlayParticles()
    {
        if (base.particleEmitter != null)
        {
            base.particleEmitter.emit = true;
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


using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParticleEffects : MonoBehaviour
{
    public List<ParticleEffectsAttractor> m_ParticleAttractors;
    public ParticleEffectsOrientation m_ParticleOrientation;
    public List<ParticleEffectsRepulser> m_ParticleRepulsers;
    public List<ParticleSystem> m_ParticleSystems;
    public bool m_WorldSpace;

    private void OnDrawGizmos()
    {
        if (this.m_ParticleAttractors != null)
        {
            foreach (ParticleEffectsAttractor attractor in this.m_ParticleAttractors)
            {
                if (attractor.m_Transform != null)
                {
                    Gizmos.color = Color.green;
                    float radius = attractor.m_Radius * (((attractor.m_Transform.lossyScale.x + attractor.m_Transform.lossyScale.y) + attractor.m_Transform.lossyScale.z) * 0.333f);
                    Gizmos.DrawWireSphere(attractor.m_Transform.position, radius);
                }
            }
        }
        if (this.m_ParticleRepulsers != null)
        {
            foreach (ParticleEffectsRepulser repulser in this.m_ParticleRepulsers)
            {
                if (repulser.m_Transform != null)
                {
                    Gizmos.color = Color.red;
                    float num2 = repulser.m_Radius * (((repulser.m_Transform.lossyScale.x + repulser.m_Transform.lossyScale.y) + repulser.m_Transform.lossyScale.z) * 0.333f);
                    Gizmos.DrawWireSphere(repulser.m_Transform.position, num2);
                }
            }
        }
    }

    private void OrientParticlesToDirection(ParticleSystem particleSystem, ParticleSystem.Particle[] particles, int particleCount)
    {
        for (int i = 0; i < particleCount; i++)
        {
            particles[i].angularVelocity = 0f;
            Vector3 velocity = particles[i].velocity;
            if (!this.m_WorldSpace)
            {
                velocity = particleSystem.transform.TransformDirection(particles[i].velocity);
            }
            if (this.m_ParticleOrientation.m_UpVector == ParticleEffectsOrientUpVectors.Horizontal)
            {
                particles[i].rotation = VectorAngle(Vector3.forward, velocity, Vector3.up);
            }
            else if (this.m_ParticleOrientation.m_UpVector == ParticleEffectsOrientUpVectors.Vertical)
            {
                particles[i].rotation = VectorAngle(Vector3.up, velocity, Vector3.forward);
            }
        }
    }

    private void ParticleAttractor(ParticleSystem particleSystem, ParticleSystem.Particle[] particles, int particleCount)
    {
        for (int i = 0; i < particleCount; i++)
        {
            foreach (ParticleEffectsAttractor attractor in this.m_ParticleAttractors)
            {
                if (((attractor.m_Transform != null) && (attractor.m_Radius > 0f)) && (attractor.m_Power > 0f))
                {
                    Vector3 position = particles[i].position;
                    if (!this.m_WorldSpace)
                    {
                        position = particleSystem.transform.TransformPoint(particles[i].position);
                    }
                    Vector3 vector2 = attractor.m_Transform.position - position;
                    float num2 = attractor.m_Radius * (((attractor.m_Transform.lossyScale.x + attractor.m_Transform.lossyScale.y) + attractor.m_Transform.lossyScale.z) * 0.333f);
                    float num3 = (1f - (vector2.magnitude / num2)) * attractor.m_Power;
                    Vector3 to = (Vector3) (vector2 * particles[i].velocity.magnitude);
                    if (!this.m_WorldSpace)
                    {
                        to = particleSystem.transform.InverseTransformDirection((Vector3) (vector2 * particles[i].velocity.magnitude));
                    }
                    Vector3 vector4 = (Vector3) (Vector3.Lerp(particles[i].velocity, to, num3 * UnityEngine.Time.deltaTime).normalized * particles[i].velocity.magnitude);
                    particles[i].velocity = vector4;
                }
            }
        }
    }

    private void ParticleRepulser(ParticleSystem particleSystem, ParticleSystem.Particle[] particles, int particleCount)
    {
        for (int i = 0; i < particleCount; i++)
        {
            foreach (ParticleEffectsRepulser repulser in this.m_ParticleRepulsers)
            {
                if (((repulser.m_Transform != null) && (repulser.m_Radius > 0f)) && (repulser.m_Power > 0f))
                {
                    Vector3 position = particles[i].position;
                    if (!this.m_WorldSpace)
                    {
                        position = particleSystem.transform.TransformPoint(particles[i].position);
                    }
                    Vector3 vector2 = repulser.m_Transform.position - position;
                    float num2 = repulser.m_Radius * (((repulser.m_Transform.lossyScale.x + repulser.m_Transform.lossyScale.y) + repulser.m_Transform.lossyScale.z) * 0.333f);
                    float num3 = ((1f - (vector2.magnitude / num2)) * repulser.m_Power) + repulser.m_Power;
                    Vector3 to = (Vector3) (-vector2 * particles[i].velocity.magnitude);
                    if (!this.m_WorldSpace)
                    {
                        to = particleSystem.transform.InverseTransformDirection((Vector3) (-vector2 * particles[i].velocity.magnitude));
                    }
                    Vector3 vector4 = (Vector3) (Vector3.Lerp(particles[i].velocity, to, num3 * UnityEngine.Time.deltaTime).normalized * particles[i].velocity.magnitude);
                    particles[i].velocity = vector4;
                }
            }
        }
    }

    private void Update()
    {
        if (this.m_ParticleSystems != null)
        {
            if (this.m_ParticleSystems.Count == 0)
            {
                ParticleSystem component = base.GetComponent<ParticleSystem>();
                if (component == null)
                {
                    base.enabled = false;
                }
                this.m_ParticleSystems.Add(component);
            }
            foreach (ParticleSystem system2 in this.m_ParticleSystems)
            {
                if (system2 != null)
                {
                    int particleCount = system2.particleCount;
                    if (particleCount == 0)
                    {
                        break;
                    }
                    ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleCount];
                    system2.GetParticles(particles);
                    if (this.m_ParticleAttractors != null)
                    {
                        this.ParticleAttractor(system2, particles, particleCount);
                    }
                    if (this.m_ParticleRepulsers != null)
                    {
                        this.ParticleRepulser(system2, particles, particleCount);
                    }
                    if ((this.m_ParticleOrientation != null) && this.m_ParticleOrientation.m_OrientToDirection)
                    {
                        this.OrientParticlesToDirection(system2, particles, particleCount);
                    }
                    system2.SetParticles(particles, particleCount);
                }
            }
        }
    }

    private static float VectorAngle(Vector3 forwardVector, Vector3 targetVector, Vector3 upVector)
    {
        float num = Vector3.Angle(forwardVector, targetVector);
        if (Vector3.Dot(Vector3.Cross(forwardVector, targetVector), upVector) < 0f)
        {
            return (360f - num);
        }
        return num;
    }
}


using System;
using UnityEngine;

public class ParticleSpiralEffect : MonoBehaviour
{
    private SpiralSettings defaultSettings;
    public float fadeValue;
    public const float Max_fade = 1f;
    public const int Max_numArms = 20;
    public const int Max_numPPA = 800;
    public const float Max_originOffset = 10f;
    public const float Max_partSep = 1f;
    public const float Max_size = 0.1f;
    public const float Max_turnDist = 1f;
    public const float Max_turnSpeed = 200f;
    public const float Max_vertDist = 1f;
    public const float Min_fade = 0f;
    public const int Min_numArms = 1;
    public const int Min_numPPA = 1;
    public const float Min_originOffset = -10f;
    public const float Min_partSep = -1f;
    public const float Min_size = -0.1f;
    public const float Min_turnDist = -1f;
    public const float Min_turnSpeed = -200f;
    public const float Min_vertDist = -1f;
    public int numberOfArms = 1;
    public int numberOfSpawns = 0x98967f;
    public float originOffset;
    public Transform particleEffect;
    public float particleSeparation = 0.05f;
    public int particlesPerArm = 200;
    public float sizeValue;
    private int spawnCount;
    public float spawnRate = 5f;
    private float timeOfLastSpawn = -1000f;
    private int totParticles;
    public float turnDistance = 0.5f;
    public float turnSpeed;
    public float verticalTurnDistance;

    public SpiralSettings getSettings()
    {
        SpiralSettings settings;
        settings.numArms = this.numberOfArms;
        settings.numPPA = this.particlesPerArm;
        settings.partSep = this.particleSeparation;
        settings.turnDist = this.turnDistance;
        settings.vertDist = this.verticalTurnDistance;
        settings.originOffset = this.originOffset;
        settings.turnSpeed = this.turnSpeed;
        settings.fade = this.fadeValue;
        settings.size = this.sizeValue;
        return settings;
    }

    private void killCurrentEffects()
    {
        foreach (ParticleEmitter emitter in base.transform.GetComponentsInChildren<ParticleEmitter>())
        {
            Debug.Log("resetEffect killing: " + emitter.name);
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
    }

    private void LateUpdate()
    {
        float num = UnityEngine.Time.time - this.timeOfLastSpawn;
        if ((num >= this.spawnRate) && (this.spawnCount < this.numberOfSpawns))
        {
            this.SpawnEffect();
            this.timeOfLastSpawn = UnityEngine.Time.time;
            this.spawnCount++;
        }
    }

    public SpiralSettings randomizeEffect(bool killCurrent)
    {
        if (killCurrent)
        {
            this.killCurrentEffects();
        }
        this.numberOfArms = UnityEngine.Random.Range(1, 0x15);
        this.particlesPerArm = UnityEngine.Random.Range(1, 0x321);
        this.particleSeparation = UnityEngine.Random.Range((float) -1f, (float) 1f);
        this.turnDistance = UnityEngine.Random.Range((float) -1f, (float) 1f);
        this.verticalTurnDistance = UnityEngine.Random.Range((float) -1f, (float) 1f);
        this.originOffset = UnityEngine.Random.Range((float) -10f, (float) 10f);
        this.turnSpeed = UnityEngine.Random.Range((float) -200f, (float) 200f);
        this.fadeValue = UnityEngine.Random.Range((float) 0f, (float) 1f);
        this.sizeValue = UnityEngine.Random.Range((float) -0.1f, (float) 0.1f);
        this.SpawnEffect();
        this.timeOfLastSpawn = UnityEngine.Time.time;
        this.spawnCount++;
        return this.getSettings();
    }

    public SpiralSettings resetEffect(bool killCurrent, SpiralSettings settings)
    {
        if (killCurrent)
        {
            this.killCurrentEffects();
        }
        this.numberOfArms = settings.numArms;
        this.particlesPerArm = settings.numPPA;
        this.particleSeparation = settings.partSep;
        this.turnDistance = settings.turnDist;
        this.verticalTurnDistance = settings.vertDist;
        this.originOffset = settings.originOffset;
        this.turnSpeed = settings.turnSpeed;
        this.fadeValue = settings.fade;
        this.sizeValue = settings.size;
        this.SpawnEffect();
        this.timeOfLastSpawn = UnityEngine.Time.time;
        this.spawnCount++;
        return this.getSettings();
    }

    public SpiralSettings resetEffectToDefaults(bool killCurrent)
    {
        return this.resetEffect(killCurrent, this.defaultSettings);
    }

    private void SpawnEffect()
    {
        Transform transform = UnityEngine.Object.Instantiate(this.particleEffect, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = base.gameObject.transform;
        ParticleEmitter component = transform.GetComponent<ParticleEmitter>();
        ParticleAnimator animator = component.transform.GetComponent<ParticleAnimator>();
        if (animator != null)
        {
            animator.autodestruct = true;
        }
        component.Emit(this.numberOfArms * this.particlesPerArm);
        UnityEngine.Particle[] particles = component.particles;
        float num = 6.283185f / ((float) this.numberOfArms);
        for (int i = 0; i < this.numberOfArms; i++)
        {
            float num3 = 0f;
            float f = 0f;
            float num5 = i * num;
            for (int j = 0; j < this.particlesPerArm; j++)
            {
                int index = (i * this.particlesPerArm) + j;
                num3 = this.originOffset + (this.turnDistance * f);
                Vector3 localPosition = transform.localPosition;
                localPosition.x += num3 * Mathf.Cos(f);
                localPosition.z += num3 * Mathf.Sin(f);
                float num8 = (localPosition.x * Mathf.Cos(num5)) + (localPosition.z * Mathf.Sin(num5));
                float num9 = (-localPosition.x * Mathf.Sin(num5)) + (localPosition.z * Mathf.Cos(num5));
                localPosition.x = num8;
                localPosition.z = num9;
                localPosition.y += j * this.verticalTurnDistance;
                if (component.useWorldSpace)
                {
                    localPosition = base.transform.TransformPoint(localPosition);
                }
                particles[index].position = localPosition;
                f += this.particleSeparation;
                particles[index].energy -= j * this.fadeValue;
                particles[index].size -= j * this.sizeValue;
            }
        }
        component.particles = particles;
    }

    public void Start()
    {
        this.defaultSettings = this.getSettings();
    }

    private void Update()
    {
        base.transform.Rotate((Vector3) ((base.transform.up * UnityEngine.Time.deltaTime) * -this.turnSpeed), Space.World);
    }
}


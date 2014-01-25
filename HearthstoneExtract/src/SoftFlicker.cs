using System;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class SoftFlicker : MonoBehaviour
{
    public float maxIntensity = 0.5f;
    public float minIntensity = 0.25f;
    private float random;

    private void Start()
    {
        this.random = UnityEngine.Random.Range((float) 0f, (float) 65535f);
    }

    private void Update()
    {
        float t = Mathf.PerlinNoise(this.random, UnityEngine.Time.time);
        base.light.intensity = Mathf.Lerp(this.minIntensity, this.maxIntensity, t);
    }
}


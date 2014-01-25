using System;
using UnityEngine;

public class SparkScript : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;

    private void Awake()
    {
        AudioSource component = base.GetComponent<AudioSource>();
        if (UnityEngine.Random.value >= 0.5f)
        {
            component.clip = this.clip1;
        }
        else
        {
            component.clip = this.clip2;
        }
    }
}


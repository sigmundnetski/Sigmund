using System;
using UnityEngine;

public class PlayEffect : MonoBehaviour
{
    public GameObject fxEmitter1;

    public void PlayEmitter1()
    {
        this.fxEmitter1.particleEmitter.emit = true;
    }

    private void Start()
    {
    }

    public void StopEmitter1()
    {
        this.fxEmitter1.particleEmitter.emit = false;
    }

    private void Update()
    {
    }
}


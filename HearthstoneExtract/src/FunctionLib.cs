using System;
using UnityEngine;

public class FunctionLib : MonoBehaviour
{
    public GameObject destination;
    public LightningCtrl lightningScript;
    public GameObject target;

    private void onAnimaitonEvent()
    {
        this.lightningScript.Spawn(this.target.transform, this.destination.transform);
    }
}


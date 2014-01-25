using System;
using UnityEngine;

public class BranchScript : MonoBehaviour
{
    public float timeSpawned;

    private void Awake()
    {
        this.timeSpawned = UnityEngine.Time.time;
    }

    private void Update()
    {
    }
}


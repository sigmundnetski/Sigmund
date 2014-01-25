using System;
using UnityEngine;

public class TimeDelete : MonoBehaviour
{
    public float m_SecondsToDelete = 10f;
    private float m_StartTime;

    private void Start()
    {
        this.m_StartTime = UnityEngine.Time.time;
    }

    private void Update()
    {
        if (UnityEngine.Time.time > (this.m_StartTime + this.m_SecondsToDelete))
        {
            UnityEngine.Object.Destroy(base.gameObject);
        }
    }
}


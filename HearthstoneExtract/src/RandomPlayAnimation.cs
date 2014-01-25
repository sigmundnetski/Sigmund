using System;
using UnityEngine;

public class RandomPlayAnimation : MonoBehaviour
{
    private Animation m_animation;
    public float m_MaxWaitTime = 10f;
    public float m_MinWaitTime;
    private float m_startTime;
    private float m_waitTime = -1f;

    private void Start()
    {
        this.m_animation = base.gameObject.animation;
    }

    private void Update()
    {
        if (this.m_animation == null)
        {
            base.enabled = false;
        }
        if (this.m_waitTime < 0f)
        {
            if (this.m_MinWaitTime < 0f)
            {
                this.m_MinWaitTime = 0f;
            }
            if (this.m_MaxWaitTime < 0f)
            {
                this.m_MaxWaitTime = 0f;
            }
            if (this.m_MaxWaitTime < this.m_MinWaitTime)
            {
                this.m_MaxWaitTime = this.m_MinWaitTime;
            }
            this.m_waitTime = UnityEngine.Random.Range(this.m_MinWaitTime, this.m_MaxWaitTime);
            this.m_startTime = UnityEngine.Time.time;
        }
        if ((UnityEngine.Time.time - this.m_startTime) > this.m_waitTime)
        {
            this.m_waitTime = -1f;
            this.m_animation.Play();
        }
    }
}


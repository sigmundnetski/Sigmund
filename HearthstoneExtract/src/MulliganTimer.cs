using System;
using UnityEngine;

public class MulliganTimer : MonoBehaviour
{
    private float m_endTimeStamp;
    private bool m_remainingTimeSet;
    public UberText m_timeText;

    private float ComputeCountdownRemainingSec()
    {
        float num = this.m_endTimeStamp - UnityEngine.Time.realtimeSinceStartup;
        if (num < 0f)
        {
            return 0f;
        }
        return num;
    }

    public void SelfDestruct()
    {
        UnityEngine.Object.Destroy(base.gameObject);
    }

    public void SetRemainingTime(float endTimeStamp)
    {
        this.m_endTimeStamp = endTimeStamp;
        this.m_remainingTimeSet = true;
    }

    private void Start()
    {
        if (MulliganManager.Get() != null)
        {
            Vector3 position = MulliganManager.Get().GetMulliganButton().transform.position;
            base.transform.position = new Vector3(position.x, position.y, position.z - 1f);
        }
    }

    private void Update()
    {
        if (this.m_remainingTimeSet)
        {
            float f = this.ComputeCountdownRemainingSec();
            int num2 = Mathf.RoundToInt(f);
            if (num2 < 0)
            {
                num2 = 0;
            }
            this.m_timeText.Text = ":" + num2.ToString("D2");
            if (f <= 0f)
            {
                if (MulliganManager.Get() != null)
                {
                    MulliganManager.Get().AutomaticContinueMulligan();
                }
                else
                {
                    this.SelfDestruct();
                }
            }
        }
    }
}


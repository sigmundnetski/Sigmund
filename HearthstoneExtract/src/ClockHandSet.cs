using System;
using UnityEngine;

public class ClockHandSet : MonoBehaviour
{
    public GameObject m_HourHand;
    public GameObject m_MinuteHand;
    private int m_prevHour;
    private int m_prevMinute;

    private float ComputeHourRotation(int hour)
    {
        return (hour * 30f);
    }

    private float ComputeMinuteRotation(int minute)
    {
        return (minute * 6f);
    }

    private void Update()
    {
        DateTime now = DateTime.Now;
        int minute = now.Minute;
        if (minute != this.m_prevMinute)
        {
            float num2 = this.ComputeMinuteRotation(minute);
            float num3 = this.ComputeMinuteRotation(this.m_prevMinute);
            float angle = num2 - num3;
            this.m_MinuteHand.transform.Rotate(Vector3.up, angle);
            this.m_prevMinute = minute;
        }
        int hour = now.Hour % 12;
        if (hour != this.m_prevHour)
        {
            float num6 = this.ComputeHourRotation(hour);
            float num7 = this.ComputeHourRotation(this.m_prevHour);
            float num8 = num6 - num7;
            this.m_HourHand.transform.Rotate(Vector3.up, num8);
            this.m_prevHour = hour;
        }
    }
}


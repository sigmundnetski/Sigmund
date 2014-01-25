using System;
using UnityEngine;

public class HUDTimer : MonoBehaviour
{
    public float leftPos = 0.5f;
    private float timerheight = 100f;
    private string timerValue = "0:00:00";
    private float timerwidth = 115f;
    public float topPos = 0.5f;

    private void OnGUI()
    {
        GUI.skin = null;
        float left = (Screen.width * this.leftPos) - (this.timerwidth * 0.5f);
        float top = (Screen.height - (this.timerheight * 0.5f)) - this.topPos;
        GUILayout.BeginArea(new Rect(left, top, this.timerwidth, this.timerheight));
        GUILayout.TextField(this.timerValue, new GUILayoutOption[0]);
        GUILayout.EndArea();
    }

    private void StartTimer()
    {
        base.InvokeRepeating("TimerUpdate", 1f, 0.13f);
    }

    private void TimerUpdate()
    {
        float num = Mathf.FloorToInt(UnityEngine.Time.time / 60f);
        float num2 = UnityEngine.Time.time % 60f;
        this.timerValue = string.Format("{0:00}:{1:00.00}", num, num2);
    }
}


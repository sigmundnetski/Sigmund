using System;
using UnityEngine;

public class calcFOV : MonoBehaviour
{
    private void Start()
    {
        float num = 55f;
        float num2 = 19.93862f;
        float message = num2 / (2f * Mathf.Tan((0.5f * num) * 0.01745329f));
        Debug.Log(message);
    }
}


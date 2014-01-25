using System;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioSource m_Source1;
    public AudioSource m_Source2;

    private void OnGUI()
    {
        Vector2 vector = new Vector2(150f, 30f);
        Vector2 vector2 = new Vector2(Screen.width * 0.01f, Screen.height * 0.01f);
        Vector2 vector3 = new Vector2(vector2.x, vector2.y);
        Vector2 vector4 = new Vector2();
        vector4 = vector3;
        if (this.m_Source1 != null)
        {
            if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Sound 1"))
            {
                this.m_Source1.Play();
            }
            vector4.y += 1.5f * vector.y;
        }
        if (this.m_Source2 != null)
        {
            if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Sound 2"))
            {
                this.m_Source2.Play();
            }
            vector4.y += 1.5f * vector.y;
        }
    }

    private void Start()
    {
    }
}


using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameplayErrorCloud m_particles;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10f, 10f, 50f, 50f), "Start/Stop"))
        {
            this.m_particles.ShowMessage("Not enough mana", 2f);
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}


using System;
using UnityEngine;

[Serializable]
public class GamesWonCrown
{
    public GameObject m_crown;

    public void Animate()
    {
        this.Show();
        this.m_crown.GetComponent<PlayMakerFSM>().SendEvent("Birth");
    }

    public void Hide()
    {
        this.m_crown.SetActive(false);
    }

    public void Show()
    {
        this.m_crown.SetActive(true);
    }
}


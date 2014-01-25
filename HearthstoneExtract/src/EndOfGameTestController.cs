using System;
using UnityEngine;

public class EndOfGameTestController : MonoBehaviour
{
    public Camera m_cam;
    public DefeatTwoScoop m_defeat;
    private bool m_defeatShown;
    private bool m_ready;
    public PegUIElement m_showDefeatButton;
    public PegUIElement m_showVictoryButton;
    public VictoryTwoScoop m_victory;
    private bool m_victoryShown;

    private void Awake()
    {
        this.m_showVictoryButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ShowVictory));
        this.m_showDefeatButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ShowDefeat));
    }

    public void ShowDefeat(UIEvent e)
    {
        if (!this.m_defeatShown)
        {
            this.m_defeatShown = true;
            this.m_defeat.Show();
        }
        else
        {
            this.m_defeatShown = false;
            this.m_defeat.Hide();
        }
    }

    public void ShowVictory(UIEvent e)
    {
        if (!this.m_victoryShown)
        {
            this.m_victoryShown = true;
            this.m_victory.Show();
        }
        else
        {
            this.m_victoryShown = false;
            this.m_victory.Hide();
        }
    }

    private void Update()
    {
        if (!this.m_ready && (PegUI.Get() != null))
        {
            this.m_ready = true;
            PegUI.Get().SetInputCamera(this.m_cam);
        }
    }
}


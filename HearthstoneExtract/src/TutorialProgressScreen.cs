using System;
using UnityEngine;

public class TutorialProgressScreen : MonoBehaviour
{
    public TutorialProgress m_tutorialProgress;

    private void Awake()
    {
        base.transform.localPosition = Vector3.zero;
    }

    private void ShowTutorialProgress()
    {
    }

    public void StartTutorialProgress()
    {
        this.m_tutorialProgress.Show();
        GameState.Get().GetRemotePlayer().GetHeroCard().GetActorSpell(SpellType.ENDGAME_WIN).GetComponent<PlayMakerFSM>().SendEvent("Death");
    }

    private void Update()
    {
        Network.Get().ProcessNetwork();
    }
}


using System;
using UnityEngine;

public class ProgressBarMedalBanner : MonoBehaviour
{
    public TournamentMedal m_medal;
    public MedalProgressBar m_progressBar;
    public GameObject m_unrankedMedal;
    public UberText m_unrankedText;
    public UberText m_wins;
    public GameObject m_winsBanner;
    public UberText m_winsLabel;
    public GameObject m_xpBarCover;

    public void AnimateProgressBar(NetCache.NetCacheMedalInfo medalInfo)
    {
        this.m_progressBar.AnimateMedalProgress(medalInfo);
    }

    private void Awake()
    {
        this.m_unrankedText.Text = GameStrings.Get("GLUE_TOURNAMENT_UNRANKED_MODE");
    }

    public void CoverXP(bool cover)
    {
        if (cover)
        {
            iTween.RotateTo(this.m_xpBarCover, Vector3.zero, 0.5f);
        }
        else
        {
            iTween.RotateTo(this.m_xpBarCover, new Vector3(90f, 0f, 0f), 0.5f);
        }
    }

    public void HideWinsText()
    {
        this.m_winsLabel.gameObject.SetActive(false);
        this.m_wins.gameObject.SetActive(false);
    }

    public void SetMedal(Medal medal)
    {
        this.m_medal.SetMedal(medal);
    }

    public void SetMedalProgress(NetCache.NetCacheMedalInfo medalInfo)
    {
        this.m_progressBar.SetMedalProgress(medalInfo);
    }

    public void SetRankedMode(bool isRanked)
    {
        this.SetRankedMode(isRanked, true);
    }

    public void SetRankedMode(bool isRanked, bool isAnimated)
    {
        if (!isAnimated)
        {
            if (isRanked)
            {
                this.m_unrankedMedal.SetActive(false);
                this.m_medal.gameObject.SetActive(true);
            }
            else
            {
                this.m_unrankedMedal.SetActive(true);
                this.m_medal.gameObject.SetActive(false);
            }
        }
        else if (isRanked)
        {
            object[] args = new object[] { "alpha", 0f, "time", 0.25f };
            iTween.FadeTo(this.m_unrankedMedal, iTween.Hash(args));
            object[] objArray2 = new object[] { "alpha", 1f, "time", 0.25f };
            iTween.FadeTo(this.m_medal.gameObject, iTween.Hash(objArray2));
        }
        else
        {
            object[] objArray3 = new object[] { "alpha", 1f, "time", 0.25f };
            iTween.FadeTo(this.m_unrankedMedal, iTween.Hash(objArray3));
            object[] objArray4 = new object[] { "alpha", 0f, "time", 0.25f };
            iTween.FadeTo(this.m_medal.gameObject, iTween.Hash(objArray4));
        }
    }

    public void SetWinsLabel(string t)
    {
        this.m_winsLabel.Text = t;
    }

    public void SetWinsText(string t)
    {
        this.m_wins.Text = t;
    }
}


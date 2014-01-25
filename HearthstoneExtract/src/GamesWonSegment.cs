using System;
using UnityEngine;

[Serializable]
public class GamesWonSegment
{
    public GamesWonCrown m_crown;
    public GameObject m_root;

    public virtual void AnimateReward()
    {
        this.m_crown.Animate();
    }

    public virtual float GetWidth()
    {
        return this.m_root.renderer.bounds.size.x;
    }

    public virtual void Hide()
    {
        this.m_root.SetActive(false);
    }

    public virtual void Init(Reward.Type rewardType, int rewardAmount, bool hideCrown)
    {
        if (hideCrown)
        {
            this.m_crown.Hide();
        }
        else
        {
            this.m_crown.Show();
        }
        this.m_root.SetActive(true);
    }
}


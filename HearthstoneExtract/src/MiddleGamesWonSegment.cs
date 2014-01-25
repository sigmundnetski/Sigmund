using System;
using UnityEngine;

[Serializable]
public class MiddleGamesWonSegment : GamesWonSegment
{
    private GameObject m_activeRoot;
    public GameObject m_root1;
    public GameObject m_root2;

    public override float GetWidth()
    {
        return this.m_activeRoot.renderer.bounds.size.x;
    }

    public override void Init(Reward.Type rewardType, int rewardAmount, bool hideCrown)
    {
        base.Init(rewardType, rewardAmount, hideCrown);
        if (UnityEngine.Random.value < 0.5f)
        {
            this.m_activeRoot = this.m_root1;
            this.m_root2.SetActive(false);
        }
        else
        {
            this.m_activeRoot = this.m_root2;
            this.m_root1.SetActive(false);
        }
        this.m_activeRoot.SetActive(true);
    }
}


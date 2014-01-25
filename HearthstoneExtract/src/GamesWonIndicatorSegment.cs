using System;
using UnityEngine;

public class GamesWonIndicatorSegment : MonoBehaviour
{
    private GamesWonSegment m_activeSegment;
    public GamesWonSegment m_leftSegment;
    public MiddleGamesWonSegment m_middleSegment;
    public RightGamesWonSegment m_rightSegment;

    public void AnimateReward()
    {
        this.m_activeSegment.AnimateReward();
    }

    public float GetWidth()
    {
        return this.m_activeSegment.GetWidth();
    }

    public void Init(Type segmentType, Reward.Type rewardType, int rewardAmount, bool hideCrown)
    {
        switch (segmentType)
        {
            case Type.LEFT:
                this.m_activeSegment = this.m_leftSegment;
                this.m_middleSegment.Hide();
                this.m_rightSegment.Hide();
                break;

            case Type.MIDDLE:
                this.m_activeSegment = this.m_middleSegment;
                this.m_leftSegment.Hide();
                this.m_rightSegment.Hide();
                break;

            case Type.RIGHT:
                this.m_activeSegment = this.m_rightSegment;
                this.m_leftSegment.Hide();
                this.m_middleSegment.Hide();
                break;
        }
        this.m_activeSegment.Init(rewardType, rewardAmount, hideCrown);
    }

    public enum Type
    {
        LEFT,
        MIDDLE,
        RIGHT
    }
}


using System;
using UnityEngine;

public class QuestTile : MonoBehaviour
{
    public GameObject m_completeTag;
    public UberText m_completeText;
    public UberText m_goldAmount;
    public GameObject m_goldBg;
    public GameObject m_nameLine;
    public GameObject m_progress;
    public UberText m_progressText;
    private Achievement m_quest;
    public UberText m_questName;
    public UberText m_requirement;
    public GameObject m_rewardIcon;

    private void LoadCenterImage()
    {
        if (((this.m_quest.Rewards == null) || (this.m_quest.Rewards.Count == 0)) || (this.m_quest.Rewards[0] == null))
        {
            Debug.LogError("QuestTile.LoadCenterImage() - This quest doesn't grant a reward!!!");
        }
        else
        {
            RewardData data = this.m_quest.Rewards[0];
            Vector2 zero = Vector2.zero;
            switch (data.RewardType)
            {
                case Reward.Type.BOOSTER_PACK:
                    zero = new Vector2(0f, 0.75f);
                    break;

                case Reward.Type.CARD:
                    zero = new Vector2(0.5f, 0f);
                    break;

                case Reward.Type.GOLD:
                {
                    zero = new Vector2(0.25f, 0.75f);
                    GoldRewardData data2 = (GoldRewardData) data;
                    this.m_goldAmount.Text = data2.Amount.ToString();
                    this.m_goldBg.SetActive(true);
                    break;
                }
                case Reward.Type.MOUNT:
                    zero = new Vector2(0f, 0.75f);
                    break;
            }
            this.m_rewardIcon.renderer.material.mainTextureOffset = zero;
        }
    }

    public void SetupTile(Achievement quest)
    {
        quest.AckCurrentProgressAndRewardNotices();
        this.m_goldBg.SetActive(false);
        this.m_quest = quest;
        if (quest.MaxProgress > 1)
        {
            this.m_progressText.Text = quest.Progress + "/" + quest.MaxProgress;
            this.m_progress.SetActive(true);
        }
        else
        {
            this.m_progressText.Text = string.Empty;
            this.m_progress.SetActive(false);
        }
        this.m_questName.Text = quest.Name;
        this.m_questName.UpdateNow();
        TransformUtil.SetPoint(this.m_nameLine, Anchor.TOP, this.m_questName, Anchor.BOTTOM);
        this.m_requirement.Text = quest.Description;
        this.LoadCenterImage();
    }
}


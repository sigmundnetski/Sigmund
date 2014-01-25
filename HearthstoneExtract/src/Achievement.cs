using System;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    private int m_ackProgress;
    private bool m_active;
    private bool m_canAck;
    private TAG_CLASS? m_classReq;
    private ClickTriggerType? m_clickType;
    private int m_completionCount;
    private long m_dateCompleted;
    private long m_dateGiven;
    private string m_description = string.Empty;
    private Group m_group;
    private int m_id;
    private int m_maxProgress;
    private string m_name = string.Empty;
    private int m_progress;
    private TAG_RACE? m_raceReq;
    private List<long> m_rewardNoticeIDs = new List<long>();
    private List<RewardData> m_rewards = new List<RewardData>();
    private Trigger m_trigger;
    private UnlockableFeature? m_unlockedFeature;
    private static readonly int NEW_ACHIEVE_ACK_PROGRESS = -1;

    public Achievement(int id, Group achieveGroup, int maxProgress, Trigger trigger, TAG_RACE? raceReq, TAG_CLASS? classReq, ClickTriggerType? clickType, UnlockableFeature? unlockedFeature, List<RewardData> rewards)
    {
        this.m_id = id;
        this.m_group = achieveGroup;
        this.m_maxProgress = maxProgress;
        this.m_trigger = trigger;
        this.m_raceReq = raceReq;
        this.m_classReq = classReq;
        this.m_clickType = clickType;
        this.SetRewards(rewards);
        this.m_unlockedFeature = unlockedFeature;
        this.m_progress = 0;
        this.m_ackProgress = NEW_ACHIEVE_ACK_PROGRESS;
        this.m_completionCount = 0;
        this.m_active = false;
        this.m_dateGiven = 0L;
        this.m_dateCompleted = 0L;
    }

    public void AckCurrentProgressAndRewardNotices()
    {
        long[] numArray = this.m_rewardNoticeIDs.ToArray();
        this.m_rewardNoticeIDs.Clear();
        foreach (long num in numArray)
        {
            Network.AckNotice(num);
        }
        if (this.NeedToAcknowledgeProgress())
        {
            this.m_ackProgress = this.Progress;
            if (this.m_canAck)
            {
                Network.AckAchieveProgress(this.ID, this.AcknowledgedProgress);
            }
        }
    }

    public void AddRewardNoticeID(long noticeID)
    {
        if (!this.m_rewardNoticeIDs.Contains(noticeID))
        {
            if (this.IsCompleted() && !this.NeedToAcknowledgeProgress())
            {
                Network.AckNotice(noticeID);
            }
            this.m_rewardNoticeIDs.Add(noticeID);
        }
    }

    private void AutoAckIfNeeded()
    {
        if (this.AchieveGroup == Group.QUEST_INTERNAL)
        {
            this.AckCurrentProgressAndRewardNotices();
        }
    }

    public bool CanBeCanceled()
    {
        return (Group.QUEST_DAILY == this.m_group);
    }

    public void Complete()
    {
        this.SetProgress(this.MaxProgress);
        this.m_completionCount++;
        this.m_active = false;
        this.m_dateCompleted = DateTime.UtcNow.ToFileTimeUtc();
        this.m_canAck = true;
        this.AutoAckIfNeeded();
        if (this.AchieveGroup == Group.UNLOCK_HERO)
        {
            CollectionManager.Get().OnHeroUnlocked(this.ClassRequirement.Value);
        }
    }

    public bool IsCompleted()
    {
        return (this.Progress >= this.MaxProgress);
    }

    public bool IsNewlyActive()
    {
        return (this.m_ackProgress == NEW_ACHIEVE_ACK_PROGRESS);
    }

    private bool NeedToAcknowledgeProgress()
    {
        if (this.AcknowledgedProgress >= this.MaxProgress)
        {
            return false;
        }
        if (this.AcknowledgedProgress == this.Progress)
        {
            return false;
        }
        return true;
    }

    public void OnAchieveData(int progress, int acknowledgedProgress, int completionCount, bool isActive, long dateGiven, long dateCompleted, bool canAcknowledge)
    {
        this.SetProgress(progress);
        this.SetAcknowledgedProgress(acknowledgedProgress);
        this.m_completionCount = completionCount;
        this.m_active = isActive;
        this.m_dateGiven = dateGiven;
        this.m_dateCompleted = dateCompleted;
        this.m_canAck = canAcknowledge;
        this.AutoAckIfNeeded();
    }

    public void OnCancelSuccess()
    {
        this.m_active = false;
    }

    private void SetAcknowledgedProgress(int acknowledgedProgress)
    {
        this.m_ackProgress = Mathf.Clamp(acknowledgedProgress, NEW_ACHIEVE_ACK_PROGRESS, this.Progress);
    }

    public void SetDescription(string description)
    {
        this.m_description = description;
    }

    public void SetName(string name)
    {
        this.m_name = name;
    }

    private void SetProgress(int progress)
    {
        this.m_progress = Mathf.Clamp(progress, 0, this.MaxProgress);
    }

    private void SetRewards(List<RewardData> rewardDataList)
    {
        this.m_rewards = new List<RewardData>(rewardDataList);
        foreach (RewardData data in this.m_rewards)
        {
            data.SetOrigin(NetCache.ProfileNotice.NoticeOrigin.ACHIEVEMENT, (long) this.ID);
        }
    }

    public override string ToString()
    {
        object[] args = new object[] { this.ID, this.AchieveGroup, this.Name, this.MaxProgress, this.Progress, this.AcknowledgedProgress, this.Active, this.DateGiven, this.DateCompleted, this.Description, this.AchieveTrigger };
        return string.Format("[Achievement: ID={0} AchieveGroup={1} Name='{2}' MaxProgress={3} Progress={4} AckProgress={5} IsActive={6} DateGiven={7} DateCompleted={8} Description='{9}' Trigger={10}]", args);
    }

    public void UpdateActiveAchieve(int progress, int acknowledgedProgress, long dateGiven, bool canAcknowledge)
    {
        this.SetProgress(progress);
        this.SetAcknowledgedProgress(acknowledgedProgress);
        this.m_active = true;
        this.m_dateGiven = dateGiven;
        this.m_canAck = canAcknowledge;
        this.AutoAckIfNeeded();
    }

    public Group AchieveGroup
    {
        get
        {
            return this.m_group;
        }
    }

    public Trigger AchieveTrigger
    {
        get
        {
            return this.m_trigger;
        }
    }

    public int AcknowledgedProgress
    {
        get
        {
            return this.m_ackProgress;
        }
    }

    public bool Active
    {
        get
        {
            return this.m_active;
        }
    }

    public bool CanBeAcknowledged
    {
        get
        {
            return this.m_canAck;
        }
    }

    public TAG_CLASS? ClassRequirement
    {
        get
        {
            return this.m_classReq;
        }
    }

    public ClickTriggerType? ClickType
    {
        get
        {
            return this.m_clickType;
        }
    }

    public int CompletionCount
    {
        get
        {
            return this.m_completionCount;
        }
    }

    public long DateCompleted
    {
        get
        {
            return this.m_dateCompleted;
        }
    }

    public long DateGiven
    {
        get
        {
            return this.m_dateGiven;
        }
    }

    public string Description
    {
        get
        {
            return this.m_description;
        }
    }

    public int ID
    {
        get
        {
            return this.m_id;
        }
    }

    public int MaxProgress
    {
        get
        {
            return this.m_maxProgress;
        }
    }

    public string Name
    {
        get
        {
            return this.m_name;
        }
    }

    public int Progress
    {
        get
        {
            return this.m_progress;
        }
    }

    public TAG_RACE? RaceRequirement
    {
        get
        {
            return this.m_raceReq;
        }
    }

    public List<RewardData> Rewards
    {
        get
        {
            return this.m_rewards;
        }
    }

    public UnlockableFeature? UnlockedFeature
    {
        get
        {
            return this.m_unlockedFeature;
        }
    }

    public enum ClickTriggerType
    {
        BUTTON_PLAY = 1
    }

    public enum Group
    {
        UNLOCK_HERO,
        QUEST_DAILY,
        QUEST_HIDDEN,
        QUEST_STARTER,
        QUEST_INTERNAL
    }

    public enum Trigger
    {
        IGNORE,
        GAIN_CARD,
        GAIN_GOLDEN_CARD,
        CLICK
    }

    public enum UnlockableFeature
    {
        DAILY_QUESTS,
        FORGE
    }
}


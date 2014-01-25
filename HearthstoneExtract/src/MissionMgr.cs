using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MissionMgr
{
    private GameEntity m_currentMission;
    private bool m_isBusy;
    private MissionID m_missionID;
    private MissionID m_nextMissionID;
    private static MissionMgr s_instance = new MissionMgr();

    public bool AreAllMissionsComplete(long campaignProgress)
    {
        MissionProgress progress = (MissionProgress) ((int) campaignProgress);
        return (progress == MissionProgress.ALL_TUTORIALS_COMPLETE);
    }

    public bool CameFromTutorial()
    {
        if (SceneMgr.Get() == null)
        {
            return false;
        }
        if (SceneMgr.Get().GetPrevMode() != SceneMgr.Mode.GAMEPLAY)
        {
            return false;
        }
        if (!this.IsTutorialMission(this.m_missionID))
        {
            return false;
        }
        return true;
    }

    public GameEntity CreateGameEntity()
    {
        switch (this.m_missionID)
        {
            case MissionID.VS_AI:
                return new StandardGameEntity();

            case MissionID.MULTIPLAYER_1v1:
                return new StandardGameEntity();

            case MissionID.TUTORIAL1:
                return new Tutorial_01();

            case MissionID.TUTORIAL2:
                return new Tutorial_02();

            case MissionID.TUTORIAL5:
                return new Tutorial_05();

            case MissionID.TUTORIAL6:
                return new Tutorial_06();

            case MissionID.TUTORIAL3:
                return new Tutorial_03();

            case MissionID.TUTORIAL4:
                return new Tutorial_04();
        }
        return new StandardGameEntity();
    }

    public static MissionMgr Get()
    {
        return s_instance;
    }

    public MissionID GetAIExpertMission(TAG_CLASS heroClass)
    {
        switch (heroClass)
        {
            case TAG_CLASS.DRUID:
                return MissionID.AI_EXPERT_DRUID;

            case TAG_CLASS.HUNTER:
                return MissionID.AI_EXPERT_HUNTER;

            case TAG_CLASS.MAGE:
                return MissionID.AI_EXPERT_MAGE;

            case TAG_CLASS.PALADIN:
                return MissionID.AI_EXPERT_PALADIN;

            case TAG_CLASS.PRIEST:
                return MissionID.AI_EXPERT_PRIEST;

            case TAG_CLASS.ROGUE:
                return MissionID.AI_EXPERT_ROGUE;

            case TAG_CLASS.SHAMAN:
                return MissionID.AI_EXPERT_SHAMAN;

            case TAG_CLASS.WARLOCK:
                return MissionID.AI_EXPERT_WARLOCK;

            case TAG_CLASS.WARRIOR:
                return MissionID.AI_EXPERT_WARRIOR;
        }
        return MissionID.INVALID;
    }

    public MissionID GetAINormalMission(TAG_CLASS heroClass)
    {
        switch (heroClass)
        {
            case TAG_CLASS.DRUID:
                return MissionID.AI_NORMAL_DRUID;

            case TAG_CLASS.HUNTER:
                return MissionID.AI_NORMAL_HUNTER;

            case TAG_CLASS.MAGE:
                return MissionID.AI_NORMAL_MAGE;

            case TAG_CLASS.PALADIN:
                return MissionID.AI_NORMAL_PALADIN;

            case TAG_CLASS.PRIEST:
                return MissionID.AI_NORMAL_PRIEST;

            case TAG_CLASS.ROGUE:
                return MissionID.AI_NORMAL_ROGUE;

            case TAG_CLASS.SHAMAN:
                return MissionID.AI_NORMAL_SHAMAN;

            case TAG_CLASS.WARLOCK:
                return MissionID.AI_NORMAL_WARLOCK;

            case TAG_CLASS.WARRIOR:
                return MissionID.AI_NORMAL_WARRIOR;
        }
        return MissionID.INVALID;
    }

    public MissionID GetNextMission(long campaignProgress)
    {
        switch (((MissionProgress) ((int) campaignProgress)))
        {
            case MissionProgress.NOTHING_COMPLETE:
                return MissionID.TUTORIAL1;

            case MissionProgress.TUTORIAL01_COMPLETE:
                return MissionID.TUTORIAL2;

            case MissionProgress.TUTORIAL02_COMPLETE:
                return MissionID.TUTORIAL6;

            case MissionProgress.TUTORIAL06_COMPLETE:
                return MissionID.TUTORIAL3;

            case MissionProgress.TUTORIAL03_COMPLETE:
                return MissionID.TUTORIAL4;

            case MissionProgress.TUTORIAL04_COMPLETE:
                return MissionID.TUTORIAL5;
        }
        return MissionID.INVALID;
    }

    public string GetTutorialCardRewardDetails()
    {
        MissionID missionID = this.m_missionID;
        if (missionID != MissionID.TUTORIAL1)
        {
            if (missionID == MissionID.TUTORIAL2)
            {
                return GameStrings.Get("GAMEPLAY_REWARD_CARD_DETAILS_TUTORIAL02");
            }
            if (missionID == MissionID.TUTORIAL5)
            {
                return GameStrings.Get("GAMEPLAY_REWARD_CARD_DETAILS_TUTORIAL05");
            }
            if (missionID == MissionID.TUTORIAL6)
            {
                return GameStrings.Get("GAMEPLAY_REWARD_CARD_DETAILS_TUTORIAL06");
            }
            if (missionID == MissionID.TUTORIAL3)
            {
                return GameStrings.Get("GAMEPLAY_REWARD_CARD_DETAILS_TUTORIAL03");
            }
            if (missionID == MissionID.TUTORIAL4)
            {
                return GameStrings.Get("GAMEPLAY_REWARD_CARD_DETAILS_TUTORIAL04");
            }
        }
        else
        {
            return GameStrings.Get("GAMEPLAY_REWARD_CARD_DETAILS_TUTORIAL01");
        }
        UnityEngine.Debug.LogWarning(string.Format("MissionMgr.GetTutorialCardRewardDetails(): no card reward details for mission {0}", this.m_missionID));
        return string.Empty;
    }

    public bool IsAIMission(MissionID mission)
    {
        switch (mission)
        {
            case MissionID.AI_NORMAL_MAGE:
            case MissionID.AI_NORMAL_WARLOCK:
            case MissionID.AI_NORMAL_HUNTER:
            case MissionID.AI_NORMAL_ROGUE:
            case MissionID.AI_NORMAL_PRIEST:
            case MissionID.AI_NORMAL_WARRIOR:
            case MissionID.AI_EXPERT_MAGE:
            case MissionID.AI_NORMAL_DRUID:
            case MissionID.AI_NORMAL_PALADIN:
            case MissionID.AI_NORMAL_SHAMAN:
            case MissionID.AI_EXPERT_WARRIOR:
            case MissionID.AI_EXPERT_PRIEST:
            case MissionID.AI_EXPERT_WARLOCK:
            case MissionID.AI_EXPERT_DRUID:
            case MissionID.AI_EXPERT_ROGUE:
            case MissionID.AI_EXPERT_HUNTER:
            case MissionID.AI_EXPERT_PALADIN:
            case MissionID.AI_EXPERT_SHAMAN:
            case MissionID.VS_AI:
                return true;
        }
        return false;
    }

    public bool IsBusy()
    {
        return this.m_isBusy;
    }

    public bool IsForge()
    {
        if (SceneMgr.Get() == null)
        {
            return false;
        }
        return (SceneMgr.Get().GetPrevMode() == SceneMgr.Mode.DRAFT);
    }

    public bool IsFriendly()
    {
        if (SceneMgr.Get() == null)
        {
            return false;
        }
        return (SceneMgr.Get().GetPrevMode() == SceneMgr.Mode.FRIENDLY);
    }

    public bool IsPlayingAI()
    {
        return (this.IsAIMission(this.m_nextMissionID) || this.IsAIMission(this.m_missionID));
    }

    public bool IsTutorial()
    {
        return (this.IsTutorialMission(this.m_nextMissionID) || this.IsTutorialMission(this.m_missionID));
    }

    public bool IsTutorialMission(MissionID mission)
    {
        MissionID nid = mission;
        if ((((nid != MissionID.TUTORIAL1) && (nid != MissionID.TUTORIAL2)) && ((nid != MissionID.TUTORIAL5) && (nid != MissionID.TUTORIAL6))) && ((nid != MissionID.TUTORIAL3) && (nid != MissionID.TUTORIAL4)))
        {
            return false;
        }
        return true;
    }

    public void OnMissionStarted()
    {
        this.m_missionID = this.m_nextMissionID;
        this.m_nextMissionID = MissionID.INVALID;
    }

    public void RestoreGame()
    {
        Network.RestoreGame();
    }

    public void SetBusy(bool bBusy)
    {
        this.m_isBusy = bBusy;
    }

    public void SetBusyInSeconds(bool bBusy, float seconds)
    {
        SceneMgr.Get().StartCoroutine(this.SetBusyInSecondsRoutine(bBusy, seconds));
    }

    [DebuggerHidden]
    private IEnumerator SetBusyInSecondsRoutine(bool bBusy, float seconds)
    {
        return new <SetBusyInSecondsRoutine>c__Iterator70 { seconds = seconds, bBusy = bBusy, <$>seconds = seconds, <$>bBusy = bBusy, <>f__this = this };
    }

    public void SetNextMission(MissionID mission)
    {
        this.m_nextMissionID = mission;
    }

    public void StartMission(MissionID mission)
    {
        this.StartMission(mission, 0L);
    }

    public void StartMission(MissionID mission, long deckId)
    {
        this.m_nextMissionID = mission;
        if (mission == MissionID.VS_AI)
        {
            Network.PlayAI(deckId, deckId);
        }
        else
        {
            Network.Get().StartScenario((int) mission, deckId);
        }
    }

    [CompilerGenerated]
    private sealed class <SetBusyInSecondsRoutine>c__Iterator70 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal bool <$>bBusy;
        internal float <$>seconds;
        internal MissionMgr <>f__this;
        internal bool bBusy;
        internal float seconds;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.$current = new WaitForSeconds(this.seconds);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.SetBusy(this.bBusy);
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    public enum MissionID
    {
        AI_EXPERT_DRUID = 0x10b,
        AI_EXPERT_HUNTER = 0x10d,
        AI_EXPERT_MAGE = 260,
        AI_EXPERT_PALADIN = 270,
        AI_EXPERT_PRIEST = 0x109,
        AI_EXPERT_ROGUE = 0x10c,
        AI_EXPERT_SHAMAN = 0x10f,
        AI_EXPERT_WARLOCK = 0x10a,
        AI_EXPERT_WARRIOR = 0x108,
        AI_NORMAL_DRUID = 0x105,
        AI_NORMAL_HUNTER = 0x100,
        AI_NORMAL_MAGE = 0xfc,
        AI_NORMAL_PALADIN = 0x106,
        AI_NORMAL_PRIEST = 0x102,
        AI_NORMAL_ROGUE = 0x101,
        AI_NORMAL_SHAMAN = 0x107,
        AI_NORMAL_WARLOCK = 0xfd,
        AI_NORMAL_WARRIOR = 0x103,
        INVALID = 0,
        MULTIPLAYER_1v1 = 2,
        TUTORIAL1 = 3,
        TUTORIAL2 = 4,
        TUTORIAL3 = 0xb5,
        TUTORIAL4 = 0xc9,
        TUTORIAL5 = 0xf8,
        TUTORIAL6 = 0xf9,
        VS_AI = 1
    }

    public enum MissionProgress
    {
        [Description("5")]
        ALL_TUTORIALS_COMPLETE = 6,
        [Description("0")]
        NOTHING_COMPLETE = 0,
        [Description("1")]
        TUTORIAL01_COMPLETE = 1,
        [Description("2")]
        TUTORIAL02_COMPLETE = 2,
        [Description("3")]
        TUTORIAL03_COMPLETE = 4,
        [Description("4")]
        TUTORIAL04_COMPLETE = 5,
        [Description("2.5")]
        TUTORIAL06_COMPLETE = 3
    }
}


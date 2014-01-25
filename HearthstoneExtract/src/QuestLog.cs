using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    [CompilerGenerated]
    private static Predicate<NetCache.PlayerRecord> <>f__am$cache14;
    private static readonly Vector3 HIDDEN_SCALE = new Vector3(0.001f, 0.001f, 0.001f);
    private static readonly float HIDE_ANIM_TIME = 0.1f;
    public List<ClassProgressBar> m_classProgressBars;
    public List<ClassProgressInfo> m_classProgressInfos;
    public ClassProgressBar m_classProgressPrefab;
    public TournamentMedal m_currentMedal;
    private List<QuestTile> m_currentQuests;
    private Data m_data = new Data();
    public UberText m_forgeRecordCountText;
    public UberText m_forgeRecordHeadlineText;
    public UberText m_headlineText;
    public UberText m_innkeeperText;
    public PegUIElement m_offClickCatcher;
    public List<Transform> m_questBones;
    public GameObject m_questTilePrefab;
    public GameObject m_root;
    public UberText m_totalLevelsText;
    public UberText m_winsCountText;
    public UberText m_winsHeadlineText;
    private static readonly float SHOW_ANIM_TIME = 0.5f;

    private bool AllSeasonPacksEarned()
    {
        Reward.Type type;
        int num;
        int num2;
        int num3;
        bool flag;
        if (!RewardUtils.GetWinRewardProgress(out type, out num, out num2, out num3, out flag))
        {
            return false;
        }
        return ((type != Reward.Type.BOOSTER_PACK) || ((num2 == num3) && flag));
    }

    private void Awake()
    {
        this.m_headlineText.Text = GameStrings.Get("GLUE_QUEST_LOG_HEADLINE");
        this.m_winsHeadlineText.Text = GameStrings.Get("GLUE_QUEST_LOG_WINS_HEADLINE");
    }

    private void CancelQuest(Achievement achievement)
    {
        AchieveManager.Get().CancelQuest(achievement.ID, new AchieveManager.DelOnAchieveCanceled(this.OnQuestCanceled));
    }

    private void DeleteQuests()
    {
        if ((this.m_currentQuests != null) && (this.m_currentQuests.Count != 0))
        {
            for (int i = 0; i < this.m_currentQuests.Count; i++)
            {
                if (this.m_currentQuests[i] != null)
                {
                    UnityEngine.Object.Destroy(this.m_currentQuests[i].gameObject);
                }
            }
        }
    }

    private void EnableFullScreenEffects(bool enable)
    {
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.BlurDesaturation = 0f;
        component.BlurBrightness = !enable ? 0f : 1f;
        component.BlurBlend = !enable ? 0f : 1f;
    }

    private bool HasAllBasicCardsForAnyClass()
    {
        foreach (ClassProgressBar bar in this.m_classProgressBars)
        {
            TAG_CLASS tag_class = bar.m_class;
            if (tag_class != TAG_CLASS.NONE)
            {
                TAG_RARITY? cardRarity = null;
                TAG_RACE? cardRace = null;
                int num = CollectionManager.Get().GetNumAvailableCards(2, new TAG_CLASS?(tag_class), cardRarity, cardRace);
                TAG_RARITY? nullable3 = null;
                TAG_RACE? nullable4 = null;
                int num2 = CollectionManager.Get().GetNumCardsIOwn(2, new TAG_CLASS?(tag_class), nullable3, nullable4, new CardFlair(CardFlair.PremiumType.STANDARD));
                if (num == num2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool HasPlayedExpertAI()
    {
        return Options.Get().GetBool(Option.HAS_PLAYED_EXPERT_AI, false);
    }

    private bool HasPlayedInPlayMode()
    {
        if (<>f__am$cache14 == null)
        {
            <>f__am$cache14 = obj => (obj.RecordType == NetCache.PlayerRecord.Type.RECORD_RANKED) || (obj.RecordType == NetCache.PlayerRecord.Type.RECORD_UNRANKED);
        }
        return (NetCache.Get().GetNetObject<NetCache.NetCachePlayerRecords>().Records.FindAll(<>f__am$cache14).Count > 0);
    }

    public void Hide()
    {
        this.Hide(false);
    }

    private void Hide(bool animate)
    {
        iTween.StopByName(base.gameObject, "questLogScale");
        if (!animate)
        {
            this.OnHidden();
        }
        else
        {
            object[] args = new object[] { "scale", HIDDEN_SCALE, "time", HIDE_ANIM_TIME, "easetype", iTween.EaseType.linear, "name", "questLogScale", "oncomplete", "OnHidden", "oncompletetarget", base.gameObject };
            Hashtable hashtable = iTween.Hash(args);
            iTween.ScaleTo(base.gameObject, hashtable);
        }
    }

    private void OnHidden()
    {
        this.m_root.SetActive(false);
        this.DeleteQuests();
        this.EnableFullScreenEffects(false);
    }

    private void OnQuestCanceled(int achieveID, bool canceled)
    {
        Log.Ben.Print(string.Format("QuestLog.OnQuestCanceled() ID={0}, canceled={1}... do something awesome here.", achieveID, canceled));
    }

    private void OnQuestLogCloseEvent(UIEvent e)
    {
        this.Hide(true);
    }

    public void Show(Data questLogData, Vector3 position, Vector3 targetScale)
    {
        this.UpdateData(questLogData);
        object[] args = new object[] { "scale", targetScale, "time", SHOW_ANIM_TIME, "easetype", iTween.EaseType.easeOutBounce, "name", "questLogScale" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(base.gameObject, "questLogScale");
        base.transform.localScale = HIDDEN_SCALE;
        base.transform.position = position;
        this.EnableFullScreenEffects(true);
        this.m_root.SetActive(true);
        iTween.ScaleTo(base.gameObject, hashtable);
    }

    private void Start()
    {
        for (int i = 0; i < this.m_classProgressInfos.Count; i++)
        {
            ClassProgressInfo info = this.m_classProgressInfos[i];
            TAG_CLASS tag_class = info.m_class;
            ClassProgressBar item = (ClassProgressBar) UnityEngine.Object.Instantiate(this.m_classProgressPrefab);
            item.transform.parent = info.m_bone.transform;
            TransformUtil.Identity(item.transform);
            item.m_class = tag_class;
            item.m_classIcon.renderer.material = info.m_iconMaterial;
            item.Init();
            this.m_classProgressBars.Add(item);
        }
        this.m_offClickCatcher.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnQuestLogCloseEvent));
    }

    private void UpdateActiveQuests()
    {
        List<Achievement> activeQuests = AchieveManager.Get().GetActiveQuests(false);
        Log.Ben.Print(string.Format("Found {0} activeQuests! I should do something awesome with them here.", activeQuests.Count));
        this.m_currentQuests = new List<QuestTile>();
        float x = 0.01666667f;
        for (int i = 0; i < activeQuests.Count; i++)
        {
            GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(this.m_questTilePrefab);
            obj2.transform.position = this.m_questBones[i].position;
            obj2.transform.parent = base.transform;
            obj2.transform.localScale = new Vector3(x, x, x);
            QuestTile component = obj2.GetComponent<QuestTile>();
            component.SetupTile(activeQuests[i]);
            this.m_currentQuests.Add(component);
        }
    }

    private void UpdateClassProgress()
    {
        int num = 0;
        List<Achievement> achievesInGroup = AchieveManager.Get().GetAchievesInGroup(Achievement.Group.UNLOCK_HERO, true);
        NetCache.NetCacheHeroLevels netObject = NetCache.Get().GetNetObject<NetCache.NetCacheHeroLevels>();
        <UpdateClassProgress>c__AnonStorey13D storeyd = new <UpdateClassProgress>c__AnonStorey13D();
        using (List<ClassProgressBar>.Enumerator enumerator = this.m_classProgressBars.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                storeyd.classProgress = enumerator.Current;
                if (storeyd.classProgress.m_classLockedGO != null)
                {
                    if (achievesInGroup.Find(new Predicate<Achievement>(storeyd.<>m__42)) != null)
                    {
                        storeyd.classProgress.m_classLockedGO.SetActive(false);
                        NetCache.HeroLevel level = netObject.Levels.Find(new Predicate<NetCache.HeroLevel>(storeyd.<>m__43));
                        storeyd.classProgress.m_levelText.Text = level.CurrentLevel.Level.ToString();
                        storeyd.classProgress.m_progressBar.SetProgressBar(((float) level.CurrentLevel.XP) / ((float) level.CurrentLevel.MaxXP));
                        num += level.CurrentLevel.Level;
                    }
                    else
                    {
                        storeyd.classProgress.m_levelText.Text = string.Empty;
                        storeyd.classProgress.m_classLockedGO.SetActive(true);
                    }
                }
            }
        }
        this.m_totalLevelsText.Text = string.Format(GameStrings.Get("GLUE_QUEST_LOG_TOTAL_LEVELS"), num);
    }

    private void UpdateCurrentMedal()
    {
        NetCache.NetCacheMedalInfo netObject = NetCache.Get().GetNetObject<NetCache.NetCacheMedalInfo>();
        this.m_currentMedal.SetMedal(netObject.CurrMedal);
    }

    private void UpdateData(Data questLogData)
    {
        this.m_data = questLogData;
        this.UpdateClassProgress();
        this.UpdateActiveQuests();
        this.UpdateCurrentMedal();
        this.UpdateForgeRecord();
        this.UpdateTotalWins();
    }

    private void UpdateForgeRecord()
    {
        if (this.m_data.m_currentForge != null)
        {
            this.m_forgeRecordHeadlineText.Text = GameStrings.Get("GLUE_QUEST_LOG_FORGE_RECORD_HEADLINE");
            object[] args = new object[] { this.m_data.m_currentForge.Wins, this.m_data.m_currentForge.Losses };
            this.m_forgeRecordCountText.Text = GameStrings.Format("GLUE_QUEST_LOG_FORGE_RECORD", args);
        }
        else
        {
            NetCache.NetCacheProfileProgress netObject = NetCache.Get().GetNetObject<NetCache.NetCacheProfileProgress>();
            if (netObject.LastForgeDate != 0)
            {
                this.m_forgeRecordHeadlineText.Text = GameStrings.Get("GLUE_QUEST_LOG_BEST_FORGE_RECORD_HEADLINE");
                int bestForgeWins = netObject.BestForgeWins;
                string str = (bestForgeWins != 1) ? GameStrings.Format("GLUE_QUEST_LOG_BEST_FORGE_RECORD", new object[] { bestForgeWins }) : GameStrings.Get("GLUE_QUEST_LOG_BEST_FORGE_RECORD_SINGLE");
                this.m_forgeRecordCountText.Text = str;
            }
            else
            {
                this.m_forgeRecordHeadlineText.Text = GameStrings.Get("GLUE_QUEST_LOG_FORGE_RECORD_HEADLINE");
                this.m_forgeRecordCountText.Text = GameStrings.Get("GLUE_QUEST_LOG_FORGE_RECORD_NA");
            }
        }
    }

    private void UpdateTotalWins()
    {
        int num = 0;
        foreach (NetCache.PlayerRecord record in NetCache.Get().GetNetObject<NetCache.NetCachePlayerRecords>().Records)
        {
            if (record.Data == 0)
            {
                switch (record.RecordType)
                {
                    case NetCache.PlayerRecord.Type.RECORD_VS_FRIEND:
                    case NetCache.PlayerRecord.Type.RECORD_DRAFT:
                    case NetCache.PlayerRecord.Type.RECORD_RANKED:
                    case NetCache.PlayerRecord.Type.RECORD_UNRANKED:
                    {
                        num += record.Wins;
                        continue;
                    }
                    case NetCache.PlayerRecord.Type.RECORD_MATCH_MAKER:
                    case NetCache.PlayerRecord.Type.RECORD_TUTORIAL:
                    case (NetCache.PlayerRecord.Type.RECORD_TUTORIAL | NetCache.PlayerRecord.Type.RECORD_VS_FRIEND):
                    {
                        continue;
                    }
                }
            }
        }
        this.m_winsCountText.Text = num.ToString();
    }

    [CompilerGenerated]
    private sealed class <UpdateClassProgress>c__AnonStorey13D
    {
        internal ClassProgressBar classProgress;

        internal bool <>m__42(Achievement obj)
        {
            return (obj.ClassRequirement.HasValue && (((TAG_CLASS) obj.ClassRequirement.Value) == this.classProgress.m_class));
        }

        internal bool <>m__43(NetCache.HeroLevel obj)
        {
            return (obj.Class == this.classProgress.m_class);
        }
    }

    public class Data
    {
        public ForgeRecord m_currentForge = null;

        public class ForgeRecord
        {
            public ForgeRecord(int wins, int losses)
            {
                this.Wins = wins;
                this.Losses = losses;
            }

            public int Losses { get; private set; }

            public int Wins { get; private set; }
        }
    }

    private enum InnkeeperTip
    {
        INNKEEPER_TIP_UNLOCK_HEROES,
        INNKEEPER_TIP_UNLOCK_BASIC_CARDS,
        INNKEEPER_TIP_PLAY_MODE,
        INNKEEPER_TIP_EXPERT_AI,
        INNKEEPER_TIP_EARN_PACKS,
        INNKEEPER_TIP_ACHIEVEMENTS,
        INNKEEPER_TIP_FORGE
    }
}


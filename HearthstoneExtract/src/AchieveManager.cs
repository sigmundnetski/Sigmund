using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class AchieveManager
{
    [CompilerGenerated]
    private static Predicate<Achievement> <>f__am$cacheA;
    [CompilerGenerated]
    private static Predicate<Achievement> <>f__am$cacheF;
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map0;
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map1;
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map2;
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map3;
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map4;
    private Dictionary<int, List<DelOnAchieveCanceled>> m_achieveCanceledListeners = new Dictionary<int, List<DelOnAchieveCanceled>>();
    private Dictionary<int, Achievement> m_achievements = new Dictionary<int, Achievement>();
    private HashSet<int> m_achieveValidationsRequested = new HashSet<int>();
    private HashSet<int> m_achieveValidationsToRequest = new HashSet<int>();
    private List<DelOnActiveAchievesUpdated> m_activeAchievesUpdatedListeners = new List<DelOnActiveAchievesUpdated>();
    private bool m_allNetAchievesReceived;
    private bool m_waitingForActiveAchieves;
    private static readonly string MANIFEST_FILE_PATH = FileUtils.GetAssetPath("manifest-achieves.csv");
    private static AchieveManager s_instance = null;

    private AchieveManager()
    {
        this.LoadAchievesFromFile();
        GameStringTable table = new GameStringTable();
        table.Load(GameStringCategory.ACHIEVEMENT);
        foreach (KeyValuePair<string, string> pair in table.GetAll())
        {
            char[] separator = new char[] { '*' };
            string[] strArray = pair.Key.Split(separator);
            int achieveID = int.Parse(strArray[0]);
            Achievement achievement = this.GetAchievement(achieveID);
            if (achievement != null)
            {
                string key = strArray[1];
                if (key != null)
                {
                    int num2;
                    if (<>f__switch$map0 == null)
                    {
                        Dictionary<string, int> dictionary2 = new Dictionary<string, int>(2);
                        dictionary2.Add("Name", 0);
                        dictionary2.Add("Description", 1);
                        <>f__switch$map0 = dictionary2;
                    }
                    if (<>f__switch$map0.TryGetValue(key, out num2))
                    {
                        if (num2 == 0)
                        {
                            achievement.SetName(pair.Value);
                            continue;
                        }
                        if (num2 == 1)
                        {
                            achievement.SetDescription(pair.Value);
                            continue;
                        }
                    }
                }
            }
        }
        Network.RequestAchieves(false);
    }

    private void AddActiveAchievesUpdatedListener(DelOnActiveAchievesUpdated listener)
    {
        if ((listener != null) && !this.m_activeAchievesUpdatedListeners.Contains(listener))
        {
            this.m_activeAchievesUpdatedListeners.Add(listener);
        }
    }

    public void CancelQuest(int achieveID, DelOnAchieveCanceled callback)
    {
        Achievement achievement = this.GetAchievement(achieveID);
        if (((achievement == null) || !achievement.CanBeCanceled()) && (callback != null))
        {
            callback(achieveID, false);
        }
        else
        {
            if (!this.m_achieveCanceledListeners[achieveID].Contains(callback))
            {
                this.m_achieveCanceledListeners[achieveID].Add(callback);
            }
            Network.RequestCancelQuest(achieveID);
        }
    }

    public static AchieveManager Get()
    {
        return s_instance;
    }

    public Achievement GetAchievement(int achieveID)
    {
        if (!this.m_achievements.ContainsKey(achieveID))
        {
            return null;
        }
        return this.m_achievements[achieveID];
    }

    public List<Achievement> GetAchievesInGroup(Achievement.Group achieveGroup)
    {
        <GetAchievesInGroup>c__AnonStorey117 storey = new <GetAchievesInGroup>c__AnonStorey117 {
            achieveGroup = achieveGroup
        };
        List<Achievement> list = new List<Achievement>(this.m_achievements.Values);
        return list.FindAll(new Predicate<Achievement>(storey.<>m__3));
    }

    public List<Achievement> GetAchievesInGroup(Achievement.Group achieveGroup, bool isComplete)
    {
        <GetAchievesInGroup>c__AnonStorey118 storey = new <GetAchievesInGroup>c__AnonStorey118 {
            isComplete = isComplete
        };
        return this.GetAchievesInGroup(achieveGroup).FindAll(new Predicate<Achievement>(storey.<>m__4));
    }

    public List<Achievement> GetActiveQuests(bool onlyNewlyActive = false)
    {
        <GetActiveQuests>c__AnonStorey115 storey = new <GetActiveQuests>c__AnonStorey115 {
            onlyNewlyActive = onlyNewlyActive
        };
        return this.m_achievements.Values.ToList<Achievement>().FindAll(new Predicate<Achievement>(storey.<>m__1));
    }

    public List<Achievement> GetNewCompletedAchieves()
    {
        if (<>f__am$cacheA == null)
        {
            <>f__am$cacheA = delegate (Achievement obj) {
                if (!obj.IsCompleted())
                {
                    return false;
                }
                Achievement.Group achieveGroup = obj.AchieveGroup;
                if (achieveGroup == Achievement.Group.UNLOCK_HERO)
                {
                    return false;
                }
                return (achieveGroup != Achievement.Group.QUEST_INTERNAL) && (obj.AcknowledgedProgress < obj.Progress);
            };
        }
        return this.m_achievements.Values.ToList<Achievement>().FindAll(<>f__am$cacheA);
    }

    public int GetNumAchievesInGroup(Achievement.Group achieveGroup)
    {
        return this.GetAchievesInGroup(achieveGroup).Count;
    }

    public bool HasUnlockedFeature(Achievement.UnlockableFeature feature)
    {
        <HasUnlockedFeature>c__AnonStorey116 storey = new <HasUnlockedFeature>c__AnonStorey116 {
            feature = feature
        };
        Achievement achievement = this.m_achievements.Values.ToList<Achievement>().Find(new Predicate<Achievement>(storey.<>m__2));
        if (achievement == null)
        {
            Debug.LogWarning(string.Format("AchieveManager.HasUnlockedFeature(): could not find achieve that unlocks feature {0}", storey.feature));
            return false;
        }
        return achievement.IsCompleted();
    }

    public static void Init()
    {
        if (s_instance != null)
        {
            Debug.LogError("AchieveManager.Init() has already been called!");
        }
        else
        {
            s_instance = new AchieveManager();
            Network network = Network.Get();
            network.RegisterNetHandler(Network.PacketID.ACHIEVE, new Network.NetHandler(s_instance.OnAchieves));
            network.RegisterNetHandler(Network.PacketID.QUEST_CANCELED, new Network.NetHandler(s_instance.OnQuestCanceled));
            network.RegisterNetHandler(Network.PacketID.ACHIEVE_VALIDATED, new Network.NetHandler(s_instance.OnAchieveValidated));
            NetCache.Get().RegisterNewNoticesListener(new NetCache.DelNewNoticesListener(s_instance.OnNewNotices));
        }
    }

    private void InitAchievement(Achievement achievement)
    {
        if (this.m_achievements.ContainsKey(achievement.ID))
        {
            Debug.LogWarning(string.Format("AchieveManager.InitAchievement() - already registered achievement with ID {0}", achievement.ID));
        }
        else
        {
            this.m_achievements.Add(achievement.ID, achievement);
            this.m_achieveCanceledListeners[achievement.ID] = new List<DelOnAchieveCanceled>();
        }
    }

    public bool IsReady()
    {
        if (!this.m_allNetAchievesReceived)
        {
            return false;
        }
        if (this.m_waitingForActiveAchieves)
        {
            return false;
        }
        if (this.m_achieveValidationsToRequest.Count > 0)
        {
            return false;
        }
        if (this.m_achieveValidationsRequested.Count > 0)
        {
            return false;
        }
        return true;
    }

    private void LoadAchievesFromFile()
    {
        string path = MANIFEST_FILE_PATH;
        int num = 0;
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string str2;
                while ((str2 = reader.ReadLine()) != null)
                {
                    string[] strArray;
                    AchieveFromFile file;
                    Achievement achievement;
                    string str4;
                    Dictionary<string, int> dictionary;
                    int num6;
                    num++;
                    if (!string.IsNullOrEmpty(str2))
                    {
                        char[] separator = new char[] { ',' };
                        strArray = str2.Split(separator);
                        file = new AchieveFromFile {
                            ID = int.Parse(strArray[0])
                        };
                        str4 = strArray[1];
                        if (str4 != null)
                        {
                            if (<>f__switch$map1 == null)
                            {
                                dictionary = new Dictionary<string, int>(6);
                                dictionary.Add("hero", 0);
                                dictionary.Add("hidden", 1);
                                dictionary.Add("daily", 2);
                                dictionary.Add("starter", 3);
                                dictionary.Add("child", 4);
                                dictionary.Add("internal", 5);
                                <>f__switch$map1 = dictionary;
                            }
                            if (<>f__switch$map1.TryGetValue(str4, out num6))
                            {
                                switch (num6)
                                {
                                    case 0:
                                        file.Group = Achievement.Group.UNLOCK_HERO;
                                        goto Label_0148;

                                    case 1:
                                        file.Group = Achievement.Group.QUEST_HIDDEN;
                                        goto Label_0148;

                                    case 2:
                                        file.Group = Achievement.Group.QUEST_DAILY;
                                        goto Label_0148;

                                    case 3:
                                        file.Group = Achievement.Group.QUEST_STARTER;
                                        goto Label_0148;

                                    case 4:
                                        goto Label_0148;

                                    case 5:
                                        file.Group = Achievement.Group.QUEST_INTERNAL;
                                        goto Label_0148;
                                }
                            }
                        }
                    }
                    continue;
                Label_0148:
                    file.MaxProgress = int.Parse(strArray[2]);
                    int num2 = int.Parse(strArray[3]);
                    if (num2 != 0)
                    {
                        file.RaceReq = new TAG_RACE?((TAG_RACE) num2);
                    }
                    int boosterCount = int.Parse(strArray[5]);
                    int num4 = int.Parse(strArray[6]);
                    str4 = strArray[4];
                    if (str4 != null)
                    {
                        if (<>f__switch$map2 == null)
                        {
                            dictionary = new Dictionary<string, int>(10);
                            dictionary.Add("pack", 0);
                            dictionary.Add("card", 1);
                            dictionary.Add("dust", 2);
                            dictionary.Add("forge", 3);
                            dictionary.Add("gold", 4);
                            dictionary.Add("hero", 5);
                            dictionary.Add("mount", 6);
                            dictionary.Add("set", 7);
                            dictionary.Add("basic", 7);
                            dictionary.Add("goldhero", 7);
                            <>f__switch$map2 = dictionary;
                        }
                        if (<>f__switch$map2.TryGetValue(str4, out num6))
                        {
                            switch (num6)
                            {
                                case 0:
                                    file.Rewards.Add(new BoosterPackRewardData(BoosterType.EXPERT, boosterCount));
                                    break;

                                case 1:
                                {
                                    CardManifest.Card card = CardManifest.Get().Find(boosterCount);
                                    int count = !DefLoader.Get().GetEntityDef(card.CardID).IsElite() ? 2 : 1;
                                    CardFlair.PremiumType premium = (CardFlair.PremiumType) num4;
                                    file.Rewards.Add(new CardRewardData(card.CardID, premium, count));
                                    break;
                                }
                                case 2:
                                    file.Rewards.Add(new ArcaneDustRewardData(boosterCount));
                                    break;

                                case 3:
                                    file.Rewards.Add(new ForgeTicketRewardData(boosterCount));
                                    break;

                                case 4:
                                    file.Rewards.Add(new GoldRewardData((long) boosterCount));
                                    break;

                                case 5:
                                {
                                    file.ClassReq = new TAG_CLASS?((TAG_CLASS) num4);
                                    string heroIDFromClass = CollectibleHero.GetHeroIDFromClass(file.ClassReq.Value);
                                    if (!string.IsNullOrEmpty(heroIDFromClass))
                                    {
                                        file.Rewards.Add(new CardRewardData(heroIDFromClass, CardFlair.PremiumType.STANDARD, 1));
                                    }
                                    break;
                                }
                                case 6:
                                    file.Rewards.Add(new MountRewardData((MountRewardData.MountType) boosterCount));
                                    if (num4 != 0)
                                    {
                                        file.Rewards.Add(new BoosterPackRewardData(BoosterType.EXPERT, num4));
                                    }
                                    break;

                                case 7:
                                    Debug.LogWarning(string.Format("AchieveManager.LoadAchievesFromFile(): unable to define reward {0} from file for achieve {1}", strArray[4], file.ID));
                                    break;
                            }
                        }
                    }
                    str4 = strArray[7];
                    if (str4 != null)
                    {
                        if (<>f__switch$map3 == null)
                        {
                            dictionary = new Dictionary<string, int>(2);
                            dictionary.Add("daily", 0);
                            dictionary.Add("forge", 1);
                            <>f__switch$map3 = dictionary;
                        }
                        if (<>f__switch$map3.TryGetValue(str4, out num6))
                        {
                            if (num6 == 0)
                            {
                                file.UnlockedFeature = 0;
                            }
                            else if (num6 == 1)
                            {
                                file.UnlockedFeature = 1;
                            }
                        }
                    }
                    file.ParentID = int.Parse(strArray[8]);
                    str4 = strArray[9];
                    if (str4 != null)
                    {
                        if (<>f__switch$map4 == null)
                        {
                            dictionary = new Dictionary<string, int>(3);
                            dictionary.Add("race", 0);
                            dictionary.Add("goldrace", 1);
                            dictionary.Add("click", 2);
                            <>f__switch$map4 = dictionary;
                        }
                        if (<>f__switch$map4.TryGetValue(str4, out num6))
                        {
                            switch (num6)
                            {
                                case 0:
                                    file.Trigger = Achievement.Trigger.GAIN_CARD;
                                    goto Label_052D;

                                case 1:
                                    file.Trigger = Achievement.Trigger.GAIN_GOLDEN_CARD;
                                    goto Label_052D;

                                case 2:
                                    file.Trigger = Achievement.Trigger.CLICK;
                                    file.ClickType = new Achievement.ClickTriggerType?((Achievement.ClickTriggerType) boosterCount);
                                    goto Label_052D;
                            }
                        }
                    }
                    file.Trigger = Achievement.Trigger.IGNORE;
                Label_052D:
                    achievement = new Achievement(file.ID, file.Group, file.MaxProgress, file.Trigger, file.RaceReq, file.ClassReq, file.ClickType, file.UnlockedFeature, file.Rewards);
                    this.InitAchievement(achievement);
                }
            }
        }
        catch (FileNotFoundException exception)
        {
            throw new ApplicationException(string.Format("Failed to find card manifest at '{0}': {1}", path, exception.Message));
        }
        catch (IOException exception2)
        {
            throw new ApplicationException(string.Format("Failed to read card manifest at '{0}': {1}", path, exception2.Message));
        }
        catch (NullReferenceException exception3)
        {
            throw new ApplicationException(string.Format("Failed to read from card manifest '{0}' line {1}: {2}", path, num, exception3.Message));
        }
        catch (Exception exception4)
        {
            throw new ApplicationException(string.Format("An unknown error occurred loading card manifest '{0}' line {1}: {2}", path, num, exception4.Message));
        }
    }

    public void NotifyOfCardGained(EntityDef entityDef, CardFlair flair, int totalCount)
    {
        <NotifyOfCardGained>c__AnonStorey11A storeya = new <NotifyOfCardGained>c__AnonStorey11A {
            entityDef = entityDef,
            raceTrigger = (flair.Premium != CardFlair.PremiumType.FOIL) ? Achievement.Trigger.GAIN_CARD : Achievement.Trigger.GAIN_GOLDEN_CARD
        };
        List<Achievement> list = this.m_achievements.Values.ToList<Achievement>().FindAll(new Predicate<Achievement>(storeya.<>m__6));
        if (list.Count > 0)
        {
            foreach (Achievement achievement in list)
            {
                TAG_CLASS? cardClass = null;
                TAG_RARITY? cardRarity = null;
                if (CollectionManager.Get().AllCardsInSetOwned(2, cardClass, cardRarity, new TAG_RACE?(achievement.RaceRequirement.Value), flair, false))
                {
                    TAG_CLASS? nullable4 = null;
                    TAG_RARITY? nullable5 = null;
                    if (CollectionManager.Get().AllCardsInSetOwned(3, nullable4, nullable5, new TAG_RACE?(achievement.RaceRequirement.Value), flair, false))
                    {
                        this.m_achieveValidationsToRequest.Add(achievement.ID);
                    }
                }
            }
        }
    }

    public void NotifyOfClick(Achievement.ClickTriggerType clickType)
    {
        <NotifyOfClick>c__AnonStorey119 storey = new <NotifyOfClick>c__AnonStorey119 {
            clickType = clickType
        };
        foreach (Achievement achievement in this.m_achievements.Values.ToList<Achievement>().FindAll(new Predicate<Achievement>(storey.<>m__5)))
        {
            this.m_achieveValidationsToRequest.Add(achievement.ID);
        }
        this.ValidateAchievesNow(null);
    }

    private void OnAchieves()
    {
        Network.AchieveList allAchievesList = Network.Achieves();
        if (!this.m_allNetAchievesReceived)
        {
            this.OnAllAchieves(allAchievesList);
        }
        else
        {
            this.OnActiveAchieves(allAchievesList);
        }
    }

    private void OnAchieveValidated()
    {
        Network.ValidatedAchieve validatedAchieve = Network.GetValidatedAchieve();
        this.m_achieveValidationsRequested.Remove(validatedAchieve.AchieveID);
        if (this.m_achieveValidationsRequested.Count <= 0)
        {
            this.UpdateActiveAchieves(null);
            NetCache.Get().ReloadNetObject<NetCache.NetCacheProfileNotices>();
        }
    }

    private void OnActiveAchieves(Network.AchieveList activeAchievesList)
    {
        if (<>f__am$cacheF == null)
        {
            <>f__am$cacheF = obj => obj.Active;
        }
        List<Achievement> list = this.m_achievements.Values.ToList<Achievement>().FindAll(<>f__am$cacheF);
        foreach (Network.AchieveList.Achieve achieve in activeAchievesList.Achieves)
        {
            <OnActiveAchieves>c__AnonStorey11B storeyb = new <OnActiveAchieves>c__AnonStorey11B {
                achievement = this.GetAchievement(achieve.ID)
            };
            if (storeyb.achievement != null)
            {
                storeyb.achievement.UpdateActiveAchieve(achieve.Progress, achieve.AckProgress, achieve.DateGiven, achieve.CanAck);
                Achievement item = list.Find(new Predicate<Achievement>(storeyb.<>m__8));
                if (item != null)
                {
                    list.Remove(item);
                }
            }
        }
        foreach (Achievement achievement2 in list)
        {
            achievement2.Complete();
        }
        DelOnActiveAchievesUpdated[] updatedArray = this.m_activeAchievesUpdatedListeners.ToArray();
        this.m_activeAchievesUpdatedListeners.Clear();
        foreach (DelOnActiveAchievesUpdated updated in updatedArray)
        {
            updated();
        }
        this.m_waitingForActiveAchieves = false;
    }

    private void OnAllAchieves(Network.AchieveList allAchievesList)
    {
        foreach (Network.AchieveList.Achieve achieve in allAchievesList.Achieves)
        {
            Achievement achievement = this.GetAchievement(achieve.ID);
            if (achievement != null)
            {
                achievement.OnAchieveData(achieve.Progress, achieve.AckProgress, achieve.CompletionCount, achieve.Active, achieve.DateGiven, achieve.DateCompleted, achieve.CanAck);
            }
        }
        this.m_allNetAchievesReceived = true;
    }

    private void OnNewNotices(List<NetCache.ProfileNotice> newNotices)
    {
        foreach (NetCache.ProfileNotice notice in newNotices)
        {
            if (notice.Origin == NetCache.ProfileNotice.NoticeOrigin.ACHIEVEMENT)
            {
                Achievement achievement = this.GetAchievement((int) notice.OriginData);
                if (achievement != null)
                {
                    achievement.AddRewardNoticeID(notice.NoticeID);
                }
            }
        }
    }

    private void OnQuestCanceled()
    {
        Network.CanceledQuest canceledQuest = Network.GetCanceledQuest();
        if (canceledQuest.Canceled)
        {
            this.GetAchievement(canceledQuest.AchieveID).OnCancelSuccess();
        }
        DelOnAchieveCanceled[] canceledArray = this.m_achieveCanceledListeners[canceledQuest.AchieveID].ToArray();
        this.m_achieveCanceledListeners[canceledQuest.AchieveID].Clear();
        foreach (DelOnAchieveCanceled canceled in canceledArray)
        {
            canceled(canceledQuest.AchieveID, canceledQuest.Canceled);
        }
    }

    public void UpdateActiveAchieves(DelOnActiveAchievesUpdated listener)
    {
        this.AddActiveAchievesUpdatedListener(listener);
        if (!this.m_waitingForActiveAchieves)
        {
            this.m_waitingForActiveAchieves = true;
            Network.RequestAchieves(true);
        }
    }

    public void ValidateAchievesNow(DelOnActiveAchievesUpdated listener)
    {
        if (this.m_achieveValidationsToRequest.Count == 0)
        {
            if (listener != null)
            {
                listener();
            }
        }
        else
        {
            this.AddActiveAchievesUpdatedListener(listener);
            this.m_achieveValidationsRequested.Union<int>(this.m_achieveValidationsToRequest);
            foreach (int num in this.m_achieveValidationsToRequest)
            {
                Network.ValidateAchieve(num);
            }
            this.m_achieveValidationsToRequest.Clear();
        }
    }

    [CompilerGenerated]
    private sealed class <GetAchievesInGroup>c__AnonStorey117
    {
        internal Achievement.Group achieveGroup;

        internal bool <>m__3(Achievement obj)
        {
            return (obj.AchieveGroup == this.achieveGroup);
        }
    }

    [CompilerGenerated]
    private sealed class <GetAchievesInGroup>c__AnonStorey118
    {
        internal bool isComplete;

        internal bool <>m__4(Achievement obj)
        {
            return (obj.IsCompleted() == this.isComplete);
        }
    }

    [CompilerGenerated]
    private sealed class <GetActiveQuests>c__AnonStorey115
    {
        internal bool onlyNewlyActive;

        internal bool <>m__1(Achievement obj)
        {
            if (!obj.Active)
            {
                return false;
            }
            switch (obj.AchieveGroup)
            {
                case Achievement.Group.UNLOCK_HERO:
                    return false;

                case Achievement.Group.QUEST_HIDDEN:
                    return false;

                case Achievement.Group.QUEST_INTERNAL:
                    return false;
            }
            if (this.onlyNewlyActive)
            {
                return obj.IsNewlyActive();
            }
            return true;
        }
    }

    [CompilerGenerated]
    private sealed class <HasUnlockedFeature>c__AnonStorey116
    {
        internal Achievement.UnlockableFeature feature;

        internal bool <>m__2(Achievement obj)
        {
            if (!obj.UnlockedFeature.HasValue)
            {
                return false;
            }
            return (((Achievement.UnlockableFeature) obj.UnlockedFeature.Value) == this.feature);
        }
    }

    [CompilerGenerated]
    private sealed class <NotifyOfCardGained>c__AnonStorey11A
    {
        internal EntityDef entityDef;
        internal Achievement.Trigger raceTrigger;

        internal bool <>m__6(Achievement obj)
        {
            if (obj.IsCompleted())
            {
                return false;
            }
            if (obj.AchieveTrigger != this.raceTrigger)
            {
                return false;
            }
            if (!obj.RaceRequirement.HasValue)
            {
                return false;
            }
            return (((TAG_RACE) obj.RaceRequirement.Value) == this.entityDef.GetRace());
        }
    }

    [CompilerGenerated]
    private sealed class <NotifyOfClick>c__AnonStorey119
    {
        internal Achievement.ClickTriggerType clickType;

        internal bool <>m__5(Achievement obj)
        {
            if (obj.IsCompleted())
            {
                return false;
            }
            if (obj.AchieveTrigger != Achievement.Trigger.CLICK)
            {
                return false;
            }
            if (!obj.ClickType.HasValue)
            {
                return false;
            }
            return (((Achievement.ClickTriggerType) obj.ClickType.Value) == this.clickType);
        }
    }

    [CompilerGenerated]
    private sealed class <OnActiveAchieves>c__AnonStorey11B
    {
        internal Achievement achievement;

        internal bool <>m__8(Achievement obj)
        {
            return (obj.ID == this.achievement.ID);
        }
    }

    private class AchieveFromFile
    {
        public TAG_CLASS? ClassReq = null;
        public Achievement.ClickTriggerType? ClickType = null;
        public Achievement.Group Group = Achievement.Group.QUEST_HIDDEN;
        public int ID = 0;
        public int MaxProgress = 0;
        public int ParentID = 0;
        public TAG_RACE? RaceReq = null;
        public List<RewardData> Rewards = new List<RewardData>();
        public Achievement.Trigger Trigger = Achievement.Trigger.IGNORE;
        public Achievement.UnlockableFeature? UnlockedFeature = null;

        public override string ToString()
        {
            object[] args = new object[] { this.ID, this.ParentID, this.Group, this.MaxProgress, this.RaceReq, this.Rewards.Count, this.UnlockedFeature, this.Trigger };
            return string.Format("[AchieveFromFile ID={0} ParentID={1} Group={2} MaxProgress={3} RaceReq={4} RewardCount={5} UnlockedFeature={6}, Trigger={7}]", args);
        }
    }

    public delegate void DelOnAchieveCanceled(int achieveID, bool success);

    public delegate void DelOnActiveAchievesUpdated();
}


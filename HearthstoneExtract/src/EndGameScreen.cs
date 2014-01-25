using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    [CompilerGenerated]
    private static Comparison<Reward> <>f__am$cache13;
    protected bool m_achievesReady;
    private bool m_animationReadyToSkip;
    private List<Achievement> m_completedQuests = new List<Achievement>();
    public TextMesh m_continueText;
    private bool m_haveShownForgePostScreen;
    private bool m_haveShownTwoScoop;
    public PegUIElement m_hitbox;
    protected bool m_netCacheReady;
    private int m_numRewardsToLoad;
    private List<Reward> m_rewards = new List<Reward>();
    private bool m_rewardsLoaded;
    private int m_showingRewardIdx = -1;
    protected bool m_shown;
    public EndGameTwoScoop m_twoScoop;
    private static readonly Vector3 REWARD_HIDDEN_SCALE = new Vector3(0.001f, 0.001f, 0.001f);
    private static readonly float REWARD_HIDE_TIME = 0.25f;
    private static readonly Vector3 REWARD_PUNCH_SCALE = new Vector3(1.2f, 1.2f, 1.2f);
    private static readonly Vector3 REWARD_SCALE = Vector3.one;
    private static EndGameScreen s_instance;

    private void AnimateBlurBlendOff()
    {
        object[] args = new object[] { "from", 1, "to", 0, "time", 0.5f, "easetype", iTween.EaseType.easeOutCirc, "onupdate", "OnUpdateBlurVal", "oncomplete", "OnBlurFinished", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(base.gameObject, hashtable);
    }

    private void AnimateBlurBlendOn()
    {
        object[] args = new object[] { "from", 0, "to", 1, "time", 0.5f, "easetype", iTween.EaseType.easeOutCirc, "onupdate", "OnUpdateBlurVal", "oncomplete", "ShowTwoScoop", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(base.gameObject, hashtable);
    }

    protected virtual void Awake()
    {
        s_instance = this;
        LoadingScreen.Get().SetFreezeFrameCamera(Camera.main);
        LoadingScreen.Get().AddTransitionObject(BoardCameras.Get().GetAudioListener());
        LoadingScreen.Get().AddTransitionObject(base.gameObject);
        AchieveManager.Get().UpdateActiveAchieves(new AchieveManager.DelOnActiveAchievesUpdated(this.OnAchievesUpdated));
        this.m_hitbox.gameObject.SetActive(false);
        this.m_continueText.gameObject.SetActive(false);
        PegUI.Get().SetInputCamera(CameraUtils.FindFirstByLayer(GameLayer.IgnoreFullScreenEffects));
        base.transform.localPosition = new Vector3(0f, 0f, 0f);
        SceneUtils.SetLayer(this.m_hitbox.gameObject, GameLayer.IgnoreFullScreenEffects);
        SceneUtils.SetLayer(this.m_continueText.gameObject, GameLayer.IgnoreFullScreenEffects);
        if (DemoMgr.Get().GetMode() == DemoMode.PAX_EAST_2013)
        {
            base.StartCoroutine(this.StartPaxEast2013DemoFlow());
        }
    }

    protected void BackToMode(SceneMgr.Mode mode)
    {
        this.HideTwoScoop();
        base.StartCoroutine(this.ToMode(mode));
    }

    protected void ContinueButtonPress_PrevMode(UIEvent e)
    {
        this.ContinueEvents();
    }

    protected void ContinueButtonPress_TutorialProgress(UIEvent e)
    {
        this.ContinueTutorialEvents();
    }

    private bool ContinueDefaultEvents()
    {
        return (!this.m_haveShownTwoScoop || (!this.m_animationReadyToSkip || (this.ShowNextCompletedQuest() || this.ShowNextReward())));
    }

    public void ContinueEvents()
    {
        if (!this.ContinueDefaultEvents())
        {
            this.m_hitbox.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ContinueButtonPress_PrevMode));
            if (!this.ShowPostForgeScreen())
            {
                this.ReturnToPreviousMode();
            }
        }
    }

    public void ContinueTutorialEvents()
    {
        if (!this.ContinueDefaultEvents())
        {
            this.m_hitbox.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ContinueButtonPress_TutorialProgress));
            this.m_continueText.gameObject.SetActive(false);
            this.ShowTutorialProgress();
        }
    }

    public static EndGameScreen Get()
    {
        return s_instance;
    }

    protected bool HasShownScoops()
    {
        return this.m_haveShownTwoScoop;
    }

    private void HideReward(Reward reward)
    {
        iTween.FadeTo(reward.gameObject, 0f, REWARD_HIDE_TIME);
        object[] args = new object[] { "scale", new Vector3(0.01f, 0.01f, 0.01f), "time", REWARD_HIDE_TIME, "oncomplete", "OnRewardHidden", "oncompletetarget", base.gameObject, "oncompleteparams", reward };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ScaleTo(reward.gameObject, hashtable);
    }

    private void HideTwoScoop()
    {
        this.AnimateBlurBlendOff();
        this.m_twoScoop.Hide();
        this.OnTwoScoopHidden();
        InputManager.Get().EnableInput();
    }

    protected virtual bool InitIfReady()
    {
        if (!this.IsReady())
        {
            return false;
        }
        this.m_continueText.gameObject.SetActive(true);
        return true;
    }

    protected bool IsReady()
    {
        return (((this.m_shown && this.m_netCacheReady) && this.m_achievesReady) && this.m_rewardsLoaded);
    }

    [DebuggerHidden]
    private IEnumerator LoadTutorialProgress()
    {
        return new <LoadTutorialProgress>c__Iterator2C { <>f__this = this };
    }

    private void MaybeUpdateRewards()
    {
        if (this.m_achievesReady && this.m_netCacheReady)
        {
            this.UpdateRewards();
            this.InitIfReady();
        }
    }

    [DebuggerHidden]
    private IEnumerator NotifyEndGameScreenOfAnimComplete()
    {
        return new <NotifyEndGameScreenOfAnimComplete>c__Iterator30();
    }

    public void NotifyOfAnimComplete()
    {
        this.m_animationReadyToSkip = true;
    }

    [DebuggerHidden]
    private IEnumerator NotifyOfExpertPacksNeeded(Notification firstPart)
    {
        return new <NotifyOfExpertPacksNeeded>c__Iterator31 { firstPart = firstPart, <$>firstPart = firstPart };
    }

    public void NotifyOfRewardAnimComplete()
    {
        this.m_animationReadyToSkip = true;
    }

    private void OnAchievesUpdated()
    {
        this.m_achievesReady = true;
        this.MaybeUpdateRewards();
    }

    private void OnBlurFinished()
    {
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.BlurAmount = 1f;
        component.BlurDesaturation = 0f;
        component.BlurBrightness = 1f;
        component.BlurBlend = 1f;
        component.BlurEnabled = false;
    }

    protected virtual void OnNetCacheReady()
    {
        this.m_netCacheReady = true;
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        this.MaybeUpdateRewards();
    }

    private void OnRewardHidden(Reward reward)
    {
        reward.Hide();
    }

    private void OnTutorialProgressScreenCallback(string name, GameObject go, object callbackData)
    {
        go.transform.parent = base.transform;
        go.GetComponent<TutorialProgressScreen>().StartTutorialProgress();
    }

    protected virtual void OnTwoScoopHidden()
    {
    }

    protected virtual void OnTwoScoopShown()
    {
    }

    private void OnUpdateBlurVal(float val)
    {
        Camera.main.GetComponent<FullScreenEffects>().BlurBlend = val;
    }

    private void ReturnToPreviousMode()
    {
        SceneMgr.Mode prevMode = SceneMgr.Get().GetPrevMode();
        if (this.m_haveShownForgePostScreen)
        {
            prevMode = SceneMgr.Mode.HUB;
        }
        if (MissionMgr.Get().IsFriendly() && !FriendChallengeMgr.Get().HasChallenge())
        {
            prevMode = SceneMgr.Mode.HUB;
        }
        this.BackToMode(prevMode);
    }

    private void RewardObjectLoaded(Reward reward, object callbackData)
    {
        reward.Hide();
        reward.transform.parent = base.transform;
        reward.transform.localRotation = Quaternion.identity;
        reward.transform.localPosition = new Vector3(-7.628078f, 8.371922f, -3.883112f);
        this.m_rewards.Add(reward);
        this.m_numRewardsToLoad--;
        if (this.m_numRewardsToLoad <= 0)
        {
            if (<>f__am$cache13 == null)
            {
                <>f__am$cache13 = delegate (Reward r1, Reward r2) {
                    if (r1.RewardType == r2.RewardType)
                    {
                        if (r1.RewardType != Reward.Type.CARD)
                        {
                            return 0;
                        }
                        CardRewardData data = r1.Data as CardRewardData;
                        CardRewardData data2 = r2.Data as CardRewardData;
                        EntityDef entityDef = DefLoader.Get().GetEntityDef(data.CardID);
                        EntityDef def2 = DefLoader.Get().GetEntityDef(data2.CardID);
                        bool flag = TAG_CARDTYPE.HERO == entityDef.GetCardType();
                        bool flag2 = TAG_CARDTYPE.HERO == def2.GetCardType();
                        if (flag == flag2)
                        {
                            return 0;
                        }
                        return !flag ? 1 : -1;
                    }
                    if (r1.RewardType == Reward.Type.CARD)
                    {
                        return -1;
                    }
                    if (r2.RewardType == Reward.Type.CARD)
                    {
                        return 1;
                    }
                    if (r1.RewardType == Reward.Type.BOOSTER_PACK)
                    {
                        return -1;
                    }
                    if (r2.RewardType == Reward.Type.BOOSTER_PACK)
                    {
                        return 1;
                    }
                    return 0;
                };
            }
            this.m_rewards.Sort(<>f__am$cache13);
            this.m_rewardsLoaded = true;
            this.InitIfReady();
        }
    }

    public virtual void Show()
    {
        this.m_shown = true;
        Network.EndGame();
        InputManager.Get().DisableInput();
        this.m_hitbox.gameObject.SetActive(true);
        SoundManager.Get().NukeAmbienceAndStopPlayingCurrentTrack();
        SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_heavy");
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.BlurAmount = 0.3f;
        component.BlurDesaturation = 0.5f;
        component.BlurBrightness = 0.4f;
        component.BlurBlend = 0f;
        this.AnimateBlurBlendOn();
        if ((GameState.Get() != null) && (GameState.Get().GetLocalPlayer() != null))
        {
            GameState.Get().GetLocalPlayer().GetHandZone().UpdateLayout(-1);
        }
        this.InitIfReady();
    }

    private bool ShowNextCompletedQuest()
    {
        if (QuestToast.IsQuestActive())
        {
            QuestToast.GetCurrentToast().CloseQuestToast();
        }
        if (this.m_completedQuests.Count == 0)
        {
            return false;
        }
        Achievement quest = this.m_completedQuests[0];
        this.m_completedQuests.RemoveAt(0);
        if (MissionMgr.Get().IsTutorial())
        {
            QuestToast.ShowQuestToast(null, quest);
        }
        else
        {
            QuestToast.ShowQuestToast(null, quest);
        }
        return true;
    }

    protected bool ShowNextReward()
    {
        if (this.m_rewards.Count == 0)
        {
            return false;
        }
        this.m_animationReadyToSkip = false;
        if (this.m_showingRewardIdx < 0)
        {
            this.m_twoScoop.Hide();
            this.OnTwoScoopHidden();
            this.m_showingRewardIdx = 0;
        }
        else
        {
            Reward reward = this.m_rewards[this.m_showingRewardIdx];
            this.HideReward(reward);
            this.m_showingRewardIdx++;
        }
        if (this.m_showingRewardIdx >= this.m_rewards.Count)
        {
            return false;
        }
        Reward reward2 = this.m_rewards[this.m_showingRewardIdx];
        this.ShowReward(reward2);
        return true;
    }

    private bool ShowPostForgeScreen()
    {
        if (!MissionMgr.Get().IsForge())
        {
            return false;
        }
        if (!DraftManager.Get().ShouldShowPostScreen())
        {
            return false;
        }
        this.m_haveShownForgePostScreen = true;
        ForgePostInfo.ShowForgePostGameScreen(new ForgePostInfo.DelOnCloseForgePostGameScreen(this.ReturnToPreviousMode));
        return true;
    }

    private void ShowReward(Reward reward)
    {
        if (reward.RewardType == Reward.Type.CARD)
        {
            CardRewardData data = reward.Data as CardRewardData;
            switch (data.InnKeeperLine)
            {
                case CardRewardData.InnKeeperTrigger.CORE_CLASS_SET_COMPLETE:
                {
                    Notification firstPart = NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_BASIC_DONE1_11"), "VO_INNKEEPER_BASIC_DONE1_11");
                    if (!Options.Get().GetBool(Option.HAS_SEEN_ALL_BASIC_CLASS_CARDS_COMPLETE, false))
                    {
                        SceneMgr.Get().StartCoroutine(this.NotifyOfExpertPacksNeeded(firstPart));
                    }
                    break;
                }
                case CardRewardData.InnKeeperTrigger.SECOND_REWARD_EVER:
                    if (!Options.Get().GetBool(Option.HAS_BEEN_NUDGED_TO_CM, false))
                    {
                        NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_NUDGE_CM_X"), "VO_INNKEEPER2_NUDGE_COLLECTION_10");
                        Options.Get().SetBool(Option.HAS_BEEN_NUDGED_TO_CM, true);
                    }
                    goto Label_00F4;
            }
        }
        else if (reward.RewardType == Reward.Type.BOOSTER_PACK)
        {
            Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_RECEIVED_BOOSTER_PACK);
        }
    Label_00F4:
        RenderUtils.SetAlpha(reward.gameObject, 0f);
        AnimationUtil.ShowWithPunch(reward.gameObject, REWARD_HIDDEN_SCALE, REWARD_PUNCH_SCALE, REWARD_SCALE, string.Empty);
        reward.Show();
        base.StartCoroutine(this.NotifyEndGameScreenOfAnimComplete());
    }

    private void ShowTutorialProgress()
    {
        this.m_twoScoop.Hide();
        this.HideTwoScoop();
        base.StartCoroutine(this.LoadTutorialProgress());
    }

    private void ShowTwoScoop()
    {
        base.StartCoroutine(this.ShowTwoScoopWhenReady());
    }

    [DebuggerHidden]
    private IEnumerator ShowTwoScoopWhenReady()
    {
        return new <ShowTwoScoopWhenReady>c__Iterator2E { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator StartPaxEast2013DemoFlow()
    {
        return new <StartPaxEast2013DemoFlow>c__Iterator2F { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator ToMode(SceneMgr.Mode mode)
    {
        return new <ToMode>c__Iterator2D { mode = mode, <$>mode = mode };
    }

    private void UpdateRewards()
    {
        List<RewardData> rewards = RewardUtils.GetRewards(NetCache.Get().GetNetObject<NetCache.NetCacheProfileNotices>().Notices);
        List<RewardData> list2 = new List<RewardData>();
        List<RewardData> customRewards = GameState.Get().GetGameEntity().GetCustomRewards();
        if (customRewards != null)
        {
            foreach (RewardData data in customRewards)
            {
                list2.Add(data);
            }
        }
        if ((list2.Count + rewards.Count) == 0)
        {
            this.m_rewardsLoaded = true;
        }
        else
        {
            this.m_numRewardsToLoad = 0;
            foreach (RewardData data2 in rewards)
            {
                object[] args = new object[] { data2 };
                Log.Rachelle.Print("EndGameScreen.UpdateRewards() - received reward {0}", args);
                if (data2.Origin == NetCache.ProfileNotice.NoticeOrigin.ACHIEVEMENT)
                {
                    Achievement item = AchieveManager.Get().GetAchievement((int) data2.OriginData);
                    if (item != null)
                    {
                        this.m_completedQuests.Add(item);
                    }
                    continue;
                }
                bool flag = false;
                switch (data2.RewardType)
                {
                    case Reward.Type.ARCANE_DUST:
                    case Reward.Type.BOOSTER_PACK:
                    case Reward.Type.GOLD:
                        flag = true;
                        break;

                    case Reward.Type.CARD:
                    {
                        CardRewardData data3 = data2 as CardRewardData;
                        bool flag2 = data3.CardID.Equals(CollectibleHero.JAINA_CARD_ID) && data3.Premium.Equals(CardFlair.PremiumType.STANDARD);
                        flag = !flag2;
                        break;
                    }
                }
                if (flag)
                {
                    list2.Add(data2);
                }
            }
            this.m_numRewardsToLoad = list2.Count;
            if (this.m_numRewardsToLoad == 0)
            {
                this.m_rewardsLoaded = true;
            }
            else
            {
                foreach (RewardData data4 in list2)
                {
                    data4.LoadRewardObject(new Reward.DelOnRewardLoaded(this.RewardObjectLoaded));
                }
            }
        }
    }

    [CompilerGenerated]
    private sealed class <LoadTutorialProgress>c__Iterator2C : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal EndGameScreen <>f__this;

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
                    this.$current = new WaitForSeconds(0.25f);
                    this.$PC = 1;
                    return true;

                case 1:
                    AssetLoader.Get().LoadActor("TutorialProgressScreen", new AssetLoader.GameObjectCallback(this.<>f__this.OnTutorialProgressScreenCallback));
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

    [CompilerGenerated]
    private sealed class <NotifyEndGameScreenOfAnimComplete>c__Iterator30 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;

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
                    this.$current = new WaitForSeconds(0.35f);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (EndGameScreen.Get() != null)
                    {
                        EndGameScreen.Get().NotifyOfRewardAnimComplete();
                        this.$PC = -1;
                        break;
                    }
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

    [CompilerGenerated]
    private sealed class <NotifyOfExpertPacksNeeded>c__Iterator31 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Notification <$>firstPart;
        internal Notification firstPart;

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
                case 1:
                    if (this.firstPart.GetAudio() == null)
                    {
                        this.$current = null;
                        this.$PC = 1;
                    }
                    else
                    {
                        this.$current = new WaitForSeconds(this.firstPart.GetAudio().clip.length);
                        this.$PC = 2;
                    }
                    return true;

                case 2:
                    NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_BASIC_DONE2_12"), "VO_INNKEEPER_BASIC_DONE2_12");
                    Options.Get().SetBool(Option.HAS_SEEN_ALL_BASIC_CLASS_CARDS_COMPLETE, true);
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

    [CompilerGenerated]
    private sealed class <ShowTwoScoopWhenReady>c__Iterator2E : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal EndGameScreen <>f__this;

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
                case 1:
                    if (!this.<>f__this.m_netCacheReady)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_0112;
                    }
                    break;

                case 2:
                    break;

                case 3:
                    goto Label_00A5;

                case 4:
                    goto Label_00CD;

                default:
                    goto Label_0110;
            }
            while (!this.<>f__this.m_achievesReady)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_0112;
            }
            this.<>f__this.m_twoScoop.UpdateData();
        Label_00A5:
            while (!this.<>f__this.m_rewardsLoaded)
            {
                this.$current = null;
                this.$PC = 3;
                goto Label_0112;
            }
        Label_00CD:
            while (!this.<>f__this.m_twoScoop.IsLoaded())
            {
                this.$current = null;
                this.$PC = 4;
                goto Label_0112;
            }
            this.<>f__this.m_twoScoop.Show();
            this.<>f__this.OnTwoScoopShown();
            this.<>f__this.m_haveShownTwoScoop = true;
            this.$PC = -1;
        Label_0110:
            return false;
        Label_0112:
            return true;
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

    [CompilerGenerated]
    private sealed class <StartPaxEast2013DemoFlow>c__Iterator2F : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal EndGameScreen <>f__this;
        internal string <message>__0;
        internal SceneMgr.Mode <prevMode>__1;

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
                    this.<>f__this.m_hitbox.gameObject.SetActive(false);
                    this.<>f__this.m_continueText.gameObject.SetActive(false);
                    this.$current = new WaitForSeconds(3.25f);
                    this.$PC = 1;
                    goto Label_0138;

                case 1:
                    this.<message>__0 = "Thanks for playing Hearthstone!";
                    NotificationManager.Get().CreateInnkeeperQuote(new Vector3(620f, -865f, 0f), this.<message>__0, string.Empty, 20f);
                    this.$current = new WaitForSeconds(8f);
                    this.$PC = 2;
                    goto Label_0138;

                case 2:
                    this.<>f__this.m_hitbox.gameObject.SetActive(true);
                    this.$current = new WaitForSeconds(12f);
                    this.$PC = 3;
                    goto Label_0138;

                case 3:
                    this.<prevMode>__1 = SceneMgr.Get().GetPrevMode();
                    if (!SceneMgr.Get().IsModeRequested(this.<prevMode>__1))
                    {
                        this.<>f__this.BackToMode(this.<prevMode>__1);
                    }
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_0138:
            return true;
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

    [CompilerGenerated]
    private sealed class <ToMode>c__Iterator2D : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SceneMgr.Mode <$>mode;
        internal SceneMgr.Mode mode;

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
                    this.$current = new WaitForSeconds(0.5f);
                    this.$PC = 1;
                    return true;

                case 1:
                    SceneMgr.Get().SetNextMode(this.mode);
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
}


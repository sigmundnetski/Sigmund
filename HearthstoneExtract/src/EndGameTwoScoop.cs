using System;
using System.Collections;
using UnityEngine;

public class EndGameTwoScoop : MonoBehaviour
{
    private static readonly float AFTER_PUNCH_SCALE_VAL = 2.3f;
    protected static readonly float BAR_ANIMATION_DELAY = 1f;
    protected static readonly float END_SCALE_VAL = 2.5f;
    public UberText m_bannerLabel;
    protected string m_bannerText;
    public Actor m_heroActor;
    protected bool m_heroActorLoaded;
    public GameObject m_heroBone;
    private bool m_isShown;
    protected ProgressBarMedalBanner m_medalBanner;
    protected NetCache.NetCacheMedalInfo m_medalInfo;
    protected HeroXPBar m_xpBar;
    public HeroXPBar m_xpBarPrefab;
    protected static readonly Vector3 START_POSITION = new Vector3(-7.8f, 8.2f, -5f);
    protected static readonly float START_SCALE_VAL = 0.01f;

    private void Awake()
    {
        base.gameObject.SetActive(false);
        AssetLoader.Get().LoadActor("ProgressBarMedalBanner", new AssetLoader.GameObjectCallback(this.ProgressBarMedalBannerLoaded));
        AssetLoader.Get().LoadActor("Card_Play_Hero", new AssetLoader.GameObjectCallback(this.OnHeroActorLoaded));
    }

    protected bool CanShowMedals()
    {
        if (DemoMgr.Get().GetMode() == DemoMode.PAX_EAST_2013)
        {
            return false;
        }
        if (MissionMgr.Get().IsFriendly())
        {
            return false;
        }
        if (MissionMgr.Get().IsForge())
        {
            return false;
        }
        if (MissionMgr.Get().IsPlayingAI())
        {
            return false;
        }
        if (MissionMgr.Get().IsTutorial())
        {
            return false;
        }
        if (!Options.Get().GetBool(Option.IN_RANKED_PLAY_MODE))
        {
            return false;
        }
        return true;
    }

    protected void EnableBannerLabel(bool enable)
    {
        this.m_bannerLabel.gameObject.SetActive(enable);
    }

    public void Hide()
    {
        this.HideAll();
    }

    private void HideAll()
    {
        object[] args = new object[] { "scale", new Vector3(START_SCALE_VAL, START_SCALE_VAL, START_SCALE_VAL), "time", 0.25f, "oncomplete", "OnAllHidden", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.FadeTo(base.gameObject, 0f, 0.25f);
        iTween.ScaleTo(base.gameObject, hashtable);
        this.m_isShown = false;
    }

    public bool IsLoaded()
    {
        return this.m_heroActorLoaded;
    }

    public bool IsShown()
    {
        return this.m_isShown;
    }

    private void OnAllHidden()
    {
        iTween.FadeTo(base.gameObject, 0f, 0f);
        base.gameObject.SetActive(false);
        this.ResetPositions();
    }

    private void OnHeroActorLoaded(string name, GameObject go, object callbackData)
    {
        go.transform.parent = base.transform;
        go.transform.localPosition = this.m_heroBone.transform.localPosition;
        go.transform.localScale = this.m_heroBone.transform.localScale;
        this.m_heroActor = go.GetComponent<Actor>();
        this.m_heroActor.TurnOffCollider();
        this.m_heroActor.m_healthObject.SetActive(false);
        this.m_heroActorLoaded = true;
    }

    protected virtual void PositionProgressMedalBarBanner()
    {
    }

    private void ProgressBarMedalBannerLoaded(string name, GameObject go, object callbackData)
    {
        SceneUtils.SetLayer(go, GameLayer.IgnoreFullScreenEffects);
        this.m_medalBanner = go.GetComponent<ProgressBarMedalBanner>();
        this.m_medalBanner.HideWinsText();
        this.m_medalBanner.SetRankedMode(true, false);
        this.PositionProgressMedalBarBanner();
    }

    protected void PunchEndGameTwoScoop()
    {
        EndGameScreen.Get().NotifyOfAnimComplete();
        iTween.ScaleTo(base.gameObject, new Vector3(AFTER_PUNCH_SCALE_VAL, AFTER_PUNCH_SCALE_VAL, AFTER_PUNCH_SCALE_VAL), 0.15f);
    }

    protected virtual void ResetPositions()
    {
    }

    protected void SaveBannerText(string bannerText)
    {
        this.m_bannerText = bannerText;
    }

    protected void SetBannerLabel(string label)
    {
        this.m_bannerLabel.Text = label;
    }

    public void Show()
    {
        this.m_isShown = true;
        base.gameObject.SetActive(true);
        if (this.CanShowMedals())
        {
            this.m_medalBanner.AnimateProgressBar(this.m_medalInfo);
        }
        this.ShowImpl();
        if (this.m_xpBar != null)
        {
            NetCache.HeroLevel heroLevel = HeroProgressUtils.GetHeroLevel(GameState.Get().GetLocalPlayer().GetHero().GetEntityDef().GetClass());
            this.m_xpBar.m_soloLevelLimit = NetCache.Get().GetNetObject<NetCache.NetCacheRewardProgress>().XPSoloLimit;
            this.m_xpBar.m_isAnimated = true;
            this.m_xpBar.m_delay = BAR_ANIMATION_DELAY;
            this.m_xpBar.m_isPractice = MissionMgr.Get().IsPlayingAI();
            this.m_xpBar.m_heroLevel = heroLevel;
            this.m_xpBar.UpdateDisplay();
        }
    }

    protected virtual void ShowImpl()
    {
    }

    private void Start()
    {
        SceneUtils.SetLayer(base.gameObject, GameLayer.IgnoreFullScreenEffects);
        this.ResetPositions();
    }

    public void UpdateData()
    {
        if (this.CanShowMedals())
        {
            this.m_medalBanner.gameObject.SetActive(true);
            this.m_medalInfo = NetCache.Get().GetNetObject<NetCache.NetCacheMedalInfo>();
            NetCache.NetCacheGamesPlayed netObject = NetCache.Get().GetNetObject<NetCache.NetCacheGamesPlayed>();
            object[] args = new object[] { netObject.GamesWon };
            this.m_medalBanner.SetWinsText(GameStrings.Format("GLOBAL_MY_NUM_WINS", args));
        }
        else
        {
            this.m_medalBanner.gameObject.SetActive(false);
        }
        if (!MissionMgr.Get().IsFriendly() && !MissionMgr.Get().IsTutorial())
        {
            this.m_xpBar = (HeroXPBar) UnityEngine.Object.Instantiate(this.m_xpBarPrefab);
            this.m_xpBar.transform.parent = this.m_heroActor.transform;
            this.m_xpBar.transform.localScale = new Vector3(0.88f, 0.88f, 0.88f);
            this.m_xpBar.transform.localPosition = new Vector3(-0.1886583f, 0.2122119f, -0.7446293f);
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TournamentDisplay : MonoBehaviour
{
    private static readonly Vector3 DECK_PICKER_POSITION = new Vector3(27.051f, 1.7f, -22.4f);
    private bool m_allInitialized;
    private DeckPickerTrayDisplay m_deckPickerTray;
    private bool m_deckPickerTrayLoaded;
    public float m_maxProgressValue;
    public TournamentMedal m_medal;
    public ProgressBarMedalBanner m_medalBanner;
    public float m_minProgressValue;
    public TextMesh m_modeName;
    private bool m_netCacheReturned;
    public MedalProgressBar m_progressBar;
    private bool m_progressBarMedalBannerLoaded;
    public GameObject m_unrankedMedal;
    private UnrankedPlayToggleButton m_unrankedToggleButton;
    public TextMesh m_wins;
    public GameObject m_winsBanner;
    public TextMesh m_winsLabel;
    public GameObject m_xpBarCover;
    private static TournamentDisplay s_instance;

    private void Awake()
    {
        AssetLoader.Get().LoadActor("DeckPickerTray", new AssetLoader.GameObjectCallback(this.DeckPickerTrayLoaded));
        if (DemoMgr.Get().GetMode() != DemoMode.PAX_EAST_2013)
        {
            AssetLoader.Get().LoadActor("ProgressBarMedalBanner", new AssetLoader.GameObjectCallback(this.ProgressBarMedalBannerLoaded));
        }
        s_instance = this;
    }

    private void DeckPickerTrayLoaded(string name, GameObject go, object callbackData)
    {
        this.m_deckPickerTray = go.GetComponent<DeckPickerTrayDisplay>();
        this.m_deckPickerTray.SetHeaderText(GameStrings.Get("GLUE_TOURNAMENT"));
        this.m_deckPickerTray.transform.parent = base.transform;
        this.m_deckPickerTray.transform.localPosition = DECK_PICKER_POSITION;
        this.m_deckPickerTrayLoaded = true;
    }

    public static TournamentDisplay Get()
    {
        return s_instance;
    }

    private void ProgressBarMedalBannerLoaded(string name, GameObject go, object callbackData)
    {
        SceneUtils.SetLayer(go, GameLayer.Default);
        Transform transform = go.transform;
        transform.parent = base.transform;
        transform.localPosition = new Vector3(9.665f, 1.63f, 30.333f);
        transform.localEulerAngles = Vector3.zero;
        transform.localScale = new Vector3(8.97f, 8.97f, 8.97f);
        this.m_medalBanner = go.GetComponent<ProgressBarMedalBanner>();
        this.m_medalBanner.HideWinsText();
        this.m_progressBarMedalBannerLoaded = true;
    }

    private void Start()
    {
        SoundManager.Get().NukePlaylistsAndStopPlayingCurrentTracks();
        SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_medium");
        NetCache.Get().RegisterScreenTourneys(new NetCache.NetCacheCallback(this.UpdateTourneyPage), new NetCache.ErrorCallback(NetCache.DefaultErrorHandler));
    }

    private void ToggleUnranked(UIEvent e)
    {
        bool val = !Options.Get().GetBool(Option.IN_RANKED_PLAY_MODE);
        Options.Get().SetBool(Option.IN_RANKED_PLAY_MODE, val);
        this.UpdateRankedState(val);
        if (!val && !Options.Get().GetBool(Option.HAS_CLICKED_UNRANKED_PLAY, false))
        {
            Options.Get().SetBool(Option.HAS_CLICKED_UNRANKED_PLAY, true);
        }
    }

    public void Unload()
    {
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.UpdateTourneyPage));
    }

    private void Update()
    {
        if (!this.m_allInitialized && (this.m_netCacheReturned && this.m_deckPickerTrayLoaded))
        {
            NetCache.NetCacheMedalInfo netObject = NetCache.Get().GetNetObject<NetCache.NetCacheMedalInfo>();
            base.StartCoroutine(this.UpdateTourneyPageWhenReady(netObject));
            this.m_deckPickerTray.Init();
            this.m_allInitialized = true;
        }
    }

    private void UpdateRankedState(bool isRanked)
    {
        this.m_unrankedToggleButton.SetRankedMode(isRanked);
        this.m_medalBanner.CoverXP(!isRanked);
        this.m_medalBanner.SetRankedMode(isRanked);
    }

    private void UpdateTourneyPage()
    {
        if (!NetCache.Get().GetNetObject<NetCache.NetCacheFeatures>().Games.Tournament)
        {
            if (!SceneMgr.Get().IsModeRequested(SceneMgr.Mode.HUB))
            {
                SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
                Error.AddWarningLoc("GLOBAL_FEATURE_DISABLED_TITLE", "GLOBAL_FEATURE_DISABLED_MESSAGE_PLAY", new object[0]);
            }
        }
        else
        {
            this.m_netCacheReturned = true;
        }
    }

    [DebuggerHidden]
    private IEnumerator UpdateTourneyPageWhenReady(NetCache.NetCacheMedalInfo medalInfo)
    {
        return new <UpdateTourneyPageWhenReady>c__IteratorB8 { medalInfo = medalInfo, <$>medalInfo = medalInfo, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <UpdateTourneyPageWhenReady>c__IteratorB8 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal NetCache.NetCacheMedalInfo <$>medalInfo;
        internal TournamentDisplay <>f__this;
        internal List<Achievement> <newlyActiveAchieves>__0;
        internal NetCache.NetCacheMedalInfo medalInfo;

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
                    if (!this.<>f__this.m_progressBarMedalBannerLoaded)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_012C;
                    }
                    break;

                case 2:
                    break;

                default:
                    goto Label_012A;
            }
            while (!AchieveManager.Get().IsReady())
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_012C;
            }
            this.<newlyActiveAchieves>__0 = AchieveManager.Get().GetActiveQuests(true);
            if (this.<newlyActiveAchieves>__0.Count > 0)
            {
                WelcomeQuests.Show(false, null);
            }
            this.<>f__this.m_medalBanner.SetMedalProgress(this.medalInfo);
            this.<>f__this.m_medalBanner.SetMedal(this.medalInfo.CurrMedal);
            this.<>f__this.m_unrankedToggleButton = this.<>f__this.m_deckPickerTray.GetRankedPlayToggle();
            this.<>f__this.m_unrankedToggleButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.<>f__this.ToggleUnranked));
            this.<>f__this.UpdateRankedState(Options.Get().GetBool(Option.IN_RANKED_PLAY_MODE));
            this.$PC = -1;
        Label_012A:
            return false;
        Label_012C:
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
}


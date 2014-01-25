using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Login : Scene
{
    private MissionMgr.MissionID m_nextMissionId;
    private bool m_waitingForBattleNet = true;

    private void AutoLogin()
    {
        Network.Get().AutoLogin();
    }

    private void ChangeMode()
    {
        SoundManager.Get().NukePlaylistsAndStopPlayingCurrentTracks();
        SoundManager.Get().AddNewMusicTrack("Main_Title");
        SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_medium");
        if (Options.Get().GetBool(Option.HAS_SEEN_HUB, false))
        {
            SoundManager.Get().LoadAndPlay("VO_INNKEEPER_INTRO_01");
        }
        NetCache.NetCacheDisconnectedGame netObject = NetCache.Get().GetNetObject<NetCache.NetCacheDisconnectedGame>();
        netObject.ServerInfo = null;
        netObject.ServerInfo = null;
        if (netObject.ServerInfo == null)
        {
            this.m_nextMissionId = this.DetermineNextMissionId();
            if (this.m_nextMissionId == MissionMgr.MissionID.INVALID)
            {
                this.ChangeMode_Hub();
            }
            else
            {
                this.ChangeMode_Mission();
            }
        }
    }

    private void ChangeMode_Hub()
    {
        Spell eventSpell = Box.Get().GetEventSpell(BoxEventType.STARTUP_HUB);
        eventSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnStartupHubSpellFinished));
        eventSpell.Activate();
    }

    private void ChangeMode_Mission()
    {
        Box.Get().SetLightState(BoxLightStateType.TUTORIAL);
        Spell eventSpell = Box.Get().GetEventSpell(BoxEventType.STARTUP_TUTORIAL);
        eventSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnStartupTutorialSpellFinished));
        eventSpell.Activate();
    }

    private MissionMgr.MissionID DetermineNextMissionId()
    {
        NetCache.NetCacheProfileProgress netObject = NetCache.Get().GetNetObject<NetCache.NetCacheProfileProgress>();
        if (MissionMgr.Get().AreAllMissionsComplete(netObject.CampaignProgress))
        {
            return MissionMgr.MissionID.INVALID;
        }
        return MissionMgr.Get().GetNextMission(netObject.CampaignProgress);
    }

    private void LoginOk()
    {
        BnetPresenceMgr.Get().Initialize();
        BnetFriendMgr.Get().Initialize();
        BnetChallengeMgr.Get().Initialize();
        BnetWhisperMgr.Get().Initialize();
        Box.Get().OnLoggedIn();
        FriendChallengeMgr.Get().OnLoggedIn();
        BaseUI.Get().OnLoggedIn();
        CollectionManager.Init();
        CollectionManager.Get().LoadAllEntityDefs();
        Tournament.Init();
        StoreManager.Get().Init();
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_LOGIN_FINISHED);
        ConnectAPI.SetLastLogin();
        NetCache.Get().RegisterScreenLogin(new NetCache.NetCacheCallback(this.OnNetCacheReady));
    }

    private void OnGameStarting()
    {
        ConnectAPI.NoGameReply();
        Spell eventSpell = Box.Get().GetEventSpell(BoxEventType.TUTORIAL_PLAY);
        eventSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnTutorialPlaySpellStateFinished));
        eventSpell.ActivateState(SpellStateType.BIRTH);
    }

    private void OnMissionSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
        SceneMgr.Get().UnregisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnMissionSceneLoaded));
        Box.Get().GetEventSpell(BoxEventType.TUTORIAL_PLAY).ActivateState(SpellStateType.ACTION);
    }

    private void OnNetCacheReady()
    {
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        RewardUtils.AcknowledgeAllRewards();
        base.StartCoroutine(this.WaitForAchievesThenInit());
    }

    private void OnNoBobNet()
    {
        DialogManager.Get().ShowMessageOfTheDay("bob.net offline");
    }

    private void OnQueueEvent(BattleNet.QueueEvent queueEvent)
    {
        if (queueEvent.EventType == BattleNet.QueueEvent.Type.QUEUE_GAME_STARTED)
        {
            BattleNet.GameServerInfo gameServer = queueEvent.GameServer;
            Network.Get().GotoGameServer(gameServer);
            Version.bobNetAddress = gameServer.Address;
            Version.serverChangelist = gameServer.Version;
        }
    }

    private void OnStartButtonPressed(Box.ButtonType buttonType, object userData)
    {
        if (buttonType == Box.ButtonType.START)
        {
            Box.Get().RemoveButtonPressListener(new Box.ButtonPressCallback(this.OnStartButtonPressed));
            SoundManager.Get().NukePlaylistsAndStopPlayingCurrentTracks();
            Box.Get().ChangeState(Box.State.CLOSED);
            MissionMgr.Get().StartMission(this.m_nextMissionId);
        }
    }

    private void OnStartupHubSpellFinished(Spell spell, object userData)
    {
        if (DemoMgr.Get().GetMode() == DemoMode.PAX_EAST_2013)
        {
            SceneMgr.Get().SetNextMode(SceneMgr.Mode.TOURNAMENT);
        }
        else if (AchieveManager.Get().GetActiveQuests(false).Count > 0)
        {
            WelcomeQuests.Show(true, new WelcomeQuests.DelOnWelcomeQuestsClosed(this.OnWelcomeQuestsCallback));
        }
        else
        {
            SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
        }
    }

    private void OnStartupTutorialSpellFinished(Spell spell, object userData)
    {
        Box.Get().AddButtonPressListener(new Box.ButtonPressCallback(this.OnStartButtonPressed));
        Box.Get().ChangeState(Box.State.PRESS_START);
    }

    private void OnTutorialPlaySpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        SpellStateType activeState = spell.GetActiveState();
        if (prevStateType == SpellStateType.BIRTH)
        {
            LoadingScreen.Get().SetFadeColor(Color.white);
            LoadingScreen.Get().EnableFadeOut(false);
            LoadingScreen.Get().AddTransitionObject(Box.Get().gameObject);
            LoadingScreen.Get().AddTransitionBlocker();
            SceneMgr.Get().RegisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnMissionSceneLoaded));
            SceneMgr.Get().SetNextMode(SceneMgr.Mode.GAMEPLAY);
        }
        else if (activeState == SpellStateType.NONE)
        {
            LoadingScreen.Get().NotifyTransitionBlockerComplete();
        }
    }

    private void OnWelcomeQuestsCallback()
    {
        SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
    }

    private void Start()
    {
        Network network = Network.Get();
        network.RegisterNetHandler(Network.PacketID.GAME_STARTING, new Network.NetHandler(this.OnGameStarting));
        network.RegisterGameQueueHandler(new Network.GameQueueHandler(this.OnQueueEvent));
        SceneMgr.Get().NotifySceneLoaded();
        this.AutoLogin();
    }

    public override void Unload()
    {
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        Network network = Network.Get();
        network.RemoveNetHandler(Network.PacketID.GAME_STARTING);
        network.RemoveGameQueueHandler(new Network.GameQueueHandler(this.OnQueueEvent));
    }

    private void Update()
    {
        Network.Get().ProcessNetwork();
        if (this.m_waitingForBattleNet)
        {
            switch (Network.BattleNetStatus())
            {
                case Network.BNetState.BATTLE_NET_LOGGED_IN:
                    this.m_waitingForBattleNet = false;
                    this.LoginOk();
                    break;

                case Network.BNetState.BATTLE_NET_LOGIN_FAILED:
                case Network.BNetState.BATTLE_NET_TIMEOUT:
                    this.m_waitingForBattleNet = false;
                    Error.AddFatalLoc("GLOBAL_ERROR_NETWORK_TITLE", "GLOBAL_ERROR_NETWORK_LOGIN_FAILURE", new object[0]);
                    break;
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitForAchievesThenInit()
    {
        return new <WaitForAchievesThenInit>c__Iterator6E { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitForAchievesThenInit>c__Iterator6E : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Login <>f__this;
        internal Cinematic <cine>__0;

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
                    if (AchieveManager.Get() == null)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_00E5;
                    }
                    break;

                case 2:
                    break;

                default:
                    goto Label_00E3;
            }
            while (!AchieveManager.Get().IsReady())
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_00E5;
            }
            if (!Options.Get().GetBool(Option.HAS_SEEN_CINEMATIC, false))
            {
                this.<cine>__0 = SceneMgr.Get().GetComponent<Cinematic>();
                if (this.<cine>__0 != null)
                {
                    this.<cine>__0.Play(new Cinematic.MovieCallback(this.<>f__this.ChangeMode));
                }
                else
                {
                    this.<>f__this.ChangeMode();
                }
            }
            else
            {
                this.<>f__this.ChangeMode();
            }
            this.$PC = -1;
        Label_00E3:
            return false;
        Label_00E5:
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


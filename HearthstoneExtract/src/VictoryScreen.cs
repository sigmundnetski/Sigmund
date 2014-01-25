using System;
using UnityEngine;

public class VictoryScreen : EndGameScreen
{
    protected override void Awake()
    {
        base.Awake();
        if (MissionMgr.Get().IsTutorial())
        {
            NetCache.Get().RegisterTutorialEndGameScreen(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        }
        else
        {
            NetCache.Get().RegisterScreenEndOfGame(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        }
    }

    protected void ContinueButtonPress_FirstTimeHub(UIEvent e)
    {
        if (base.HasShownScoops())
        {
            if (base.ShowNextReward())
            {
                SoundManager.Get().LoadAndPlay("VO_INNKEEPER_TUT_COMPLETE_05");
            }
            else
            {
                base.m_hitbox.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ContinueButtonPress_FirstTimeHub));
                base.BackToMode(SceneMgr.Mode.HUB);
            }
        }
    }

    protected override bool InitIfReady()
    {
        if (!base.InitIfReady())
        {
            return false;
        }
        if (!MissionMgr.Get().IsTutorial())
        {
            base.m_hitbox.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ContinueButtonPress_PrevMode));
            return true;
        }
        NetCache.NetCacheProfileProgress netObject = NetCache.Get().GetNetObject<NetCache.NetCacheProfileProgress>();
        if (MissionMgr.Get().AreAllMissionsComplete(netObject.CampaignProgress))
        {
            LoadingScreen.Get().SetFadeColor(Color.white);
            base.m_hitbox.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ContinueButtonPress_FirstTimeHub));
        }
        else
        {
            base.m_hitbox.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ContinueButtonPress_TutorialProgress));
        }
        return true;
    }
}


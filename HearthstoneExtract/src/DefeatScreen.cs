using System;

public class DefeatScreen : EndGameScreen
{
    protected override void Awake()
    {
        base.Awake();
        NetCache.Get().RegisterScreenEndOfGame(new NetCache.NetCacheCallback(this.OnNetCacheReady));
    }

    protected override bool InitIfReady()
    {
        if (!base.InitIfReady())
        {
            return false;
        }
        if (MissionMgr.Get().IsTutorial())
        {
            base.m_hitbox.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ContinueButtonPress_TutorialProgress));
        }
        else
        {
            base.m_hitbox.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ContinueButtonPress_PrevMode));
        }
        return true;
    }
}


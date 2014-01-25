using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameOpenPack : MonoBehaviour
{
    private bool clickedOnPack;
    private bool fullyLoaded;
    public PlayMakerFSM m_playMakerFSM;

    public void Begin()
    {
        if (GameState.Get() != null)
        {
            GameState.Get().GetGameEntity().NotifyOfGamePackOpened();
        }
    }

    public void Finish()
    {
        if (GameState.Get() != null)
        {
            GameState.Get().GetGameEntity().NotifyOfCustomIntroFinished();
        }
    }

    public void HandleClick()
    {
        if (((this.fullyLoaded && !this.clickedOnPack) && SceneMgr.Get().IsSceneLoaded()) && ((LoadingScreen.Get() == null) || !LoadingScreen.Get().IsTransitioning()))
        {
            this.clickedOnPack = true;
            this.m_playMakerFSM.SendEvent("Action");
        }
    }

    public void NotifyOfFullyLoaded()
    {
        this.fullyLoaded = true;
    }

    public void NotifyOfMouseOff()
    {
        if (this.fullyLoaded && !this.clickedOnPack)
        {
            this.m_playMakerFSM.SendEvent("Cancel");
        }
    }

    public void NotifyOfMouseOver()
    {
        if (this.fullyLoaded && !this.clickedOnPack)
        {
            this.m_playMakerFSM.SendEvent("Birth");
        }
    }

    [DebuggerHidden]
    private IEnumerator PlayHoggerAfterVersus()
    {
        return new <PlayHoggerAfterVersus>c__Iterator76();
    }

    public void PlayHoggerLine()
    {
        if (MulliganManager.Get() == null)
        {
        }
    }

    public void PlayJainaLine()
    {
        GameState.Get().GetGameEntity().SendCustomEvent(0x42);
    }

    public void RaiseBoardLights()
    {
        Board.Get().RaiseTheLights();
    }

    [CompilerGenerated]
    private sealed class <PlayHoggerAfterVersus>c__Iterator76 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <hoggerCard>__0;

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
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<hoggerCard>__0 = GameState.Get().GetRemotePlayer().GetHeroCard();
                    SoundManager.Get().Play(this.<hoggerCard>__0.GetAnnouncerLine());
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


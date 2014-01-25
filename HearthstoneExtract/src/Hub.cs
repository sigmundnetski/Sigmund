using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Hub : Scene
{
    [DebuggerHidden]
    private IEnumerator DoWelcome()
    {
        return new <DoWelcome>c__Iterator6B();
    }

    private void OnBoxButtonPressed(Box.ButtonType buttonType, object userData)
    {
        if (buttonType == Box.ButtonType.TOURNAMENT)
        {
            SceneMgr.Get().SetNextMode(SceneMgr.Mode.TOURNAMENT);
            Tournament.Get().NotifyOfBoxTransitionStart();
        }
        else if (buttonType == Box.ButtonType.FORGE)
        {
            SceneMgr.Get().SetNextMode(SceneMgr.Mode.DRAFT);
        }
        else if (buttonType == Box.ButtonType.PRACTICE)
        {
            SceneMgr.Get().SetNextMode(SceneMgr.Mode.PRACTICE);
        }
        else if (buttonType == Box.ButtonType.COLLECTION)
        {
            CollectionManager.Get().NotifyOfBoxTransitionStart();
            SceneMgr.Get().SetNextMode(SceneMgr.Mode.COLLECTIONMANAGER);
        }
        else if (buttonType == Box.ButtonType.OPEN_PACKS)
        {
            CollectionManager.Get().EnableWaitingToShowPackOpening(true);
            CollectionManager.Get().NotifyOfBoxTransitionStart();
            SceneMgr.Get().SetNextMode(SceneMgr.Mode.COLLECTIONMANAGER);
        }
    }

    private void OnStartGame()
    {
        ConnectAPI.NoGameReply();
        SceneMgr.Get().SetNextMode(SceneMgr.Mode.GAMEPLAY);
    }

    private void Start()
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_BOX_SCREEN_VISIT);
        SceneMgr.Get().NotifySceneLoaded();
        Box.Get().AddButtonPressListener(new Box.ButtonPressCallback(this.OnBoxButtonPressed));
        if (SceneMgr.Get().GetPrevMode() != SceneMgr.Mode.LOGIN)
        {
            SoundManager.Get().NukePlaylistsAndStopPlayingCurrentTracks();
            SoundManager.Get().AddNewMusicTrack("Main_Title");
            SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_medium");
        }
        if (!Options.Get().GetBool(Option.HAS_SEEN_HUB, false))
        {
            base.StartCoroutine(this.DoWelcome());
        }
    }

    public override void Unload()
    {
        Box.Get().RemoveButtonPressListener(new Box.ButtonPressCallback(this.OnBoxButtonPressed));
    }

    private void Update()
    {
        Network.Get().ProcessNetwork();
    }

    [CompilerGenerated]
    private sealed class <DoWelcome>c__Iterator6B : IDisposable, IEnumerator, IEnumerator<object>
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
                    this.$current = new WaitForSeconds(3f);
                    this.$PC = 1;
                    return true;

                case 1:
                    NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_1ST_HUB_06"), "VO_INNKEEPER_1ST_HUB_06", 3f);
                    Options.Get().SetBool(Option.HAS_SEEN_HUB, true);
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


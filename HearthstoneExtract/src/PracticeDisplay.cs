using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PracticeDisplay : MonoBehaviour
{
    private static readonly Vector3 DECK_PICKER_POSITION = new Vector3(27.051f, 1.7f, -22.4f);
    private DeckPickerTrayDisplay m_deckPickerTray;
    public TextMesh m_modeName;
    private PracticePickerTrayDisplay m_practicePickerTray;
    private static PracticeDisplay s_instance;

    private void Awake()
    {
        AssetLoader.Get().LoadActor("DeckPickerTray", new AssetLoader.GameObjectCallback(this.DeckPickerTrayLoaded));
        AssetLoader.Get().LoadActor("PracticePickerTray", new AssetLoader.GameObjectCallback(this.PracticePickerTrayLoaded));
        s_instance = this;
    }

    private void DeckPickerTrayLoaded(string name, GameObject go, object callbackData)
    {
        this.m_deckPickerTray = go.GetComponent<DeckPickerTrayDisplay>();
        this.m_deckPickerTray.SetHeaderText(GameStrings.Get("GLUE_PRACTICE"));
        this.m_deckPickerTray.transform.parent = base.transform;
        this.m_deckPickerTray.transform.localPosition = DECK_PICKER_POSITION;
    }

    public static PracticeDisplay Get()
    {
        return s_instance;
    }

    [DebuggerHidden]
    private IEnumerator InitComponentsWhenReady()
    {
        return new <InitComponentsWhenReady>c__Iterator98 { <>f__this = this };
    }

    private void OnBoxTransitionFinished(object userData)
    {
        this.m_practicePickerTray.transform.localPosition = PracticePickerTrayDisplay.START_POS;
        Box.Get().RemoveTransitionFinishedListener(new Box.TransitionFinishedCallback(this.OnBoxTransitionFinished));
    }

    private void PracticePickerTrayLoaded(string name, GameObject go, object callbackdata)
    {
        this.m_practicePickerTray = go.GetComponent<PracticePickerTrayDisplay>();
        this.m_practicePickerTray.transform.parent = base.transform;
        if (SceneMgr.Get().GetPrevMode() == SceneMgr.Mode.GAMEPLAY)
        {
            this.m_practicePickerTray.transform.localPosition = PracticePickerTrayDisplay.START_POS;
        }
        else
        {
            this.m_practicePickerTray.transform.position = Box.Get().GetBoxCamera().transform.TransformPoint(new Vector3(0f, 0f, -500f));
            Box.Get().AddTransitionFinishedListener(new Box.TransitionFinishedCallback(this.OnBoxTransitionFinished));
        }
    }

    private void Start()
    {
        SoundManager.Get().NukePlaylistsAndStopPlayingCurrentTracks();
        SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_medium");
        NetCache.Get().RegisterScreenPractice(new NetCache.NetCacheCallback(this.UpdatePracticePage), new NetCache.ErrorCallback(NetCache.DefaultErrorHandler));
    }

    public void Unload()
    {
    }

    private void UpdatePracticePage()
    {
        NetCache.NetCacheFeatures netObject = NetCache.Get().GetNetObject<NetCache.NetCacheFeatures>();
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.UpdatePracticePage));
        if (!netObject.Games.Practice)
        {
            if (!SceneMgr.Get().IsModeRequested(SceneMgr.Mode.HUB))
            {
                SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
                Error.AddWarningLoc("GLOBAL_FEATURE_DISABLED_TITLE", "GLOBAL_FEATURE_DISABLED_MESSAGE_PRACTICE", new object[0]);
            }
        }
        else
        {
            base.StartCoroutine(this.InitComponentsWhenReady());
        }
    }

    [CompilerGenerated]
    private sealed class <InitComponentsWhenReady>c__Iterator98 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal PracticeDisplay <>f__this;
        internal List<Achievement> <newlyActiveAchieves>__0;

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
                    if (this.<>f__this.m_deckPickerTray == null)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_00FE;
                    }
                    break;

                case 2:
                    break;

                case 3:
                    goto Label_009D;

                default:
                    goto Label_00FC;
            }
            while (this.<>f__this.m_practicePickerTray == null)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_00FE;
            }
        Label_009D:
            while (!AchieveManager.Get().IsReady())
            {
                this.$current = null;
                this.$PC = 3;
                goto Label_00FE;
            }
            this.<newlyActiveAchieves>__0 = AchieveManager.Get().GetActiveQuests(true);
            if (this.<newlyActiveAchieves>__0.Count > 0)
            {
                WelcomeQuests.Show(false, null);
            }
            this.<>f__this.m_deckPickerTray.Init();
            this.<>f__this.m_practicePickerTray.Init();
            this.$PC = -1;
        Label_00FC:
            return false;
        Label_00FE:
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


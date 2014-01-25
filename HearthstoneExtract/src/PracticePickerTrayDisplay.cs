using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PracticePickerTrayDisplay : MonoBehaviour
{
    public static readonly Vector3 END_POS = new Vector3(10.34293f, 9.078793f, 11.92104f);
    private static readonly List<TAG_CLASS> EXPERT_AI_CLASS_ORDER = new List<TAG_CLASS> { 4, 3, 10, 8, 2, 6, 7, 5, 9 };
    public GameObject m_AIButtonBone;
    public PracticeAIButton m_AIButtonPrefab;
    public BackButton m_backButton;
    private bool m_buttonsCreated;
    private bool m_buttonsReady;
    private Mode m_currentMode;
    private List<NetCache.DeckHeader> m_customDecks;
    public GameObject m_flatTilePrefab;
    private Hashtable m_heroDefs = new Hashtable();
    private int m_heroDefsToLoad;
    private bool m_heroesLoaded;
    public ArrowModeButton m_leftArrow;
    private List<Achievement> m_lockedHeroes;
    public UberText m_modeLabel;
    public GameObject m_modeLabelBg;
    public PlayButton m_playButton;
    private List<PracticeAIButton> m_practiceAIButtons = new List<PracticeAIButton>();
    public ArrowModeButton m_rightArrow;
    private Hashtable m_selectedPracticeAIButtons = new Hashtable();
    private bool m_shown;
    public GameObject m_slotTilePrefab;
    public GameObject m_topFlatTile;
    public UberText m_trayLabel;
    private List<Mode> m_unlockedModes = new List<Mode>();
    private static readonly List<TAG_CLASS> NORMAL_AI_CLASS_ORDER = new List<TAG_CLASS> { 4, 3, 10, 8, 2, 6, 7, 5, 9 };
    private static readonly int NUM_AI_BUTTONS_TO_SHOW = 10;
    private static PracticePickerTrayDisplay s_instance;
    public static readonly Vector3 START_POS = new Vector3(44.93422f, 9.078793f, 11.92104f);
    public iTween.EaseType TRAY_IN_EASE_TYPE = iTween.EaseType.easeOutBounce;
    public float TRAY_IN_TIME = 0.5f;
    public iTween.EaseType TRAY_OUT_EASE_TYPE = iTween.EaseType.easeOutCubic;
    public float TRAY_OUT_TIME = 0.5f;

    private void AIButtonPressed(UIEvent e)
    {
        PracticeAIButton element = (PracticeAIButton) e.GetElement();
        this.SetSelectedButton(element);
        this.m_playButton.Enable();
        element.Select();
    }

    private void Awake()
    {
        s_instance = this;
        foreach (Transform transform in base.gameObject.GetComponents<Transform>())
        {
            transform.gameObject.SetActive(false);
        }
        base.gameObject.SetActive(true);
        this.m_backButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.BackButtonReleased));
        this.m_trayLabel.Text = GameStrings.Get("GLUE_CHOOSE_OPPONENT");
        this.m_playButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.PlayGameButtonRelease));
        this.m_leftArrow.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.PreviousOpponentMode));
        this.m_rightArrow.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.NextOpponentMode));
        for (int i = 0; i < NORMAL_AI_CLASS_ORDER.Count; i++)
        {
            string heroIDFromClass = CollectibleHero.GetHeroIDFromClass(NORMAL_AI_CLASS_ORDER[i]);
            DefLoader.Get().LoadFullDef(heroIDFromClass, new DefLoader.LoadDefCallback<FullDef>(this.OnFullDefLoaded));
            this.m_heroDefsToLoad++;
        }
        this.SetupHeroAchieves();
        base.StartCoroutine(this.NotifySceneWhenLoaded());
    }

    private void BackButtonReleased(UIEvent e)
    {
        this.Hide();
        DeckPickerTrayDisplay.Get().ResetCurrentMode();
    }

    private void DisableAIButtons()
    {
        for (int i = 0; i < this.m_practiceAIButtons.Count; i++)
        {
            this.m_practiceAIButtons[i].SetEnabled(false);
        }
    }

    [DebuggerHidden]
    private IEnumerator DoPickHeroLines()
    {
        return new <DoPickHeroLines>c__Iterator99 { <>f__this = this };
    }

    public static PracticePickerTrayDisplay Get()
    {
        return s_instance;
    }

    public void Hide()
    {
        this.m_shown = false;
        object[] args = new object[] { "position", START_POS, "isLocal", true, "time", this.TRAY_OUT_TIME, "easetype", this.TRAY_OUT_EASE_TYPE };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(base.gameObject, hashtable);
    }

    public void Init()
    {
        this.m_customDecks = NetCache.Get().GetNetObject<NetCache.NetCacheDecks>().Decks;
        int num = Mathf.Min(NUM_AI_BUTTONS_TO_SHOW, Mathf.Max(NORMAL_AI_CLASS_ORDER.Count, EXPERT_AI_CLASS_ORDER.Count));
        PracticeAIButton button = null;
        GameObject obj2 = null;
        for (int i = 0; i < num; i++)
        {
            bool flag = 0 == i;
            PracticeAIButton item = (PracticeAIButton) UnityEngine.Object.Instantiate(this.m_AIButtonPrefab);
            item.transform.parent = base.transform;
            if (flag)
            {
                item.transform.localPosition = this.m_AIButtonBone.transform.localPosition;
            }
            else
            {
                TransformUtil.SetPoint(item.gameObject, new Vector3(0f, 0f, 1f), button.gameObject, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, -0.3f));
            }
            button = item;
            item.SetOriginalLocalPosition();
            item.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.AIButtonPressed));
            this.m_practiceAIButtons.Add(item);
            GameObject obj3 = (GameObject) UnityEngine.Object.Instantiate(this.m_slotTilePrefab);
            obj3.transform.parent = base.transform;
            if (flag)
            {
                TransformUtil.SetPoint(obj3.gameObject, new Vector3(0f, 1f, 1f), this.m_topFlatTile.gameObject, new Vector3(0f, 0f, 0f), Vector3.zero);
            }
            else
            {
                TransformUtil.SetPoint(obj3.gameObject, new Vector3(0f, 0f, 1f), obj2.gameObject, Vector3.zero, Vector3.zero);
            }
            obj2 = obj3;
        }
        if (this.m_practiceAIButtons.Count < NUM_AI_BUTTONS_TO_SHOW)
        {
            int num3 = NUM_AI_BUTTONS_TO_SHOW - this.m_practiceAIButtons.Count;
            for (int j = 0; j < num3; j++)
            {
                GameObject obj4 = (GameObject) UnityEngine.Object.Instantiate(this.m_flatTilePrefab);
                obj4.transform.parent = base.transform;
                TransformUtil.SetPoint(obj4.gameObject, new Vector3(0f, 1f, 1f), obj2.gameObject, new Vector3(0f, 1f, 0f), Vector3.zero);
                obj2 = obj4;
            }
        }
        this.m_buttonsCreated = true;
    }

    [DebuggerHidden]
    private IEnumerator InitButtonsWhenReady()
    {
        return new <InitButtonsWhenReady>c__Iterator9A { <>f__this = this };
    }

    public bool IsShown()
    {
        return this.m_shown;
    }

    private void NextOpponentMode(UIEvent e)
    {
        if (this.m_currentMode == Mode.NORMAL)
        {
            this.UpdateAIButtons(Mode.EXPERT, true);
        }
        else if (this.m_currentMode == Mode.EXPERT)
        {
            this.UpdateAIButtons(Mode.CUSTOM, true);
        }
    }

    [DebuggerHidden]
    private IEnumerator NotifySceneWhenLoaded()
    {
        return new <NotifySceneWhenLoaded>c__Iterator9B { <>f__this = this };
    }

    private void OnFullDefLoaded(string cardId, FullDef def, object userData)
    {
        this.m_heroDefs[cardId] = def;
        this.m_heroDefsToLoad--;
        if (this.m_heroDefsToLoad <= 0)
        {
            this.m_heroesLoaded = true;
        }
    }

    public void OnGameDenied()
    {
        this.UpdateAIButtons(this.m_currentMode, false);
    }

    private void PlayGameButtonRelease(UIEvent e)
    {
        long selectedDeckID = DeckPickerTrayDisplay.Get().GetSelectedDeckID();
        if (selectedDeckID == 0)
        {
            UnityEngine.Debug.LogError("Trying to play practice game with deck ID 0!");
        }
        else
        {
            e.GetElement().SetEnabled(false);
            this.DisableAIButtons();
            PracticeAIButton button = (PracticeAIButton) this.m_selectedPracticeAIButtons[this.m_currentMode];
            DeckPickerTrayDisplay.Get().GetLoadingPopup().Show();
            Network.TrackWhat what = !DeckPickerTrayDisplay.Get().IsShowingCustomDecks() ? Network.TrackWhat.TRACK_PLAY_PRACTICE_WITH_PRECON_DECK : Network.TrackWhat.TRACK_PLAY_PRACTICE_WITH_CUSTOM_DECK;
            Network.TrackClient(Network.TrackLevel.LEVEL_INFO, what);
            if (this.m_currentMode == Mode.CUSTOM)
            {
                Network.PlayAI(selectedDeckID, button.m_deckID);
            }
            else
            {
                if ((this.m_currentMode == Mode.EXPERT) && !Options.Get().GetBool(Option.HAS_PLAYED_EXPERT_AI, false))
                {
                    Options.Get().SetBool(Option.HAS_PLAYED_EXPERT_AI, true);
                }
                MissionMgr.Get().StartMission(button.m_missionID, selectedDeckID);
            }
        }
    }

    private void PreviousOpponentMode(UIEvent e)
    {
        if (this.m_currentMode == Mode.EXPERT)
        {
            this.UpdateAIButtons(Mode.NORMAL, true);
        }
        else if (this.m_currentMode == Mode.CUSTOM)
        {
            this.UpdateAIButtons(Mode.EXPERT, true);
        }
    }

    private void SetSelectedButton(PracticeAIButton button)
    {
        PracticeAIButton button2 = (PracticeAIButton) this.m_selectedPracticeAIButtons[this.m_currentMode];
        if (button2 != null)
        {
            button2.Deselect();
        }
        this.m_selectedPracticeAIButtons[this.m_currentMode] = button;
    }

    private void SetupHeroAchieves()
    {
        this.m_unlockedModes.Add(Mode.NORMAL);
        this.m_lockedHeroes = AchieveManager.Get().GetAchievesInGroup(Achievement.Group.UNLOCK_HERO, false);
        if (this.m_lockedHeroes.Count == 0)
        {
            this.m_unlockedModes.Add(Mode.EXPERT);
            if (!Options.Get().GetBool(Option.HAS_SEEN_EXPERT_AI_UNLOCK, false))
            {
                NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_EXPERT_AI_10"), "VO_INNKEEPER_EXPERT_AI_10");
                Options.Get().SetBool(Option.HAS_SEEN_EXPERT_AI_UNLOCK, true);
            }
        }
        if ((this.m_lockedHeroes.Count <= 5) && !Options.Get().GetBool(Option.HAS_BEEN_NUDGED_TO_PLAY, false))
        {
            Options.Get().SetBool(Option.HAS_BEEN_NUDGED_TO_PLAY, true);
        }
        if ((this.m_lockedHeroes.Count <= 7) && !Options.Get().GetBool(Option.HAS_SEEN_PRACTICE_MODE, false))
        {
            Options.Get().SetBool(Option.HAS_SEEN_PRACTICE_MODE, true);
        }
        base.StartCoroutine(this.InitButtonsWhenReady());
    }

    public void Show()
    {
        this.m_shown = true;
        foreach (Transform transform in base.gameObject.GetComponents<Transform>())
        {
            transform.gameObject.SetActive(true);
        }
        base.gameObject.SetActive(true);
        object[] args = new object[] { "position", END_POS, "isLocal", true, "time", this.TRAY_IN_TIME, "easetype", this.TRAY_IN_EASE_TYPE, "oncompletetarget", base.gameObject, "oncomplete", "AcknowledgeViewedAchieves" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(base.gameObject, hashtable);
        if (!Options.Get().GetBool(Option.HAS_SEEN_PRACTICE_TRAY, false))
        {
            Options.Get().SetBool(Option.HAS_SEEN_PRACTICE_TRAY, true);
            base.StartCoroutine(this.DoPickHeroLines());
        }
    }

    private void Start()
    {
        this.m_playButton.SetText(GameStrings.Get("GLOBAL_PLAY"));
        this.m_playButton.SetOriginalLocalPosition();
        this.m_playButton.Disable();
    }

    private void UpdateAIButtons(Mode mode, bool animate)
    {
        this.m_currentMode = mode;
        Options.Get().SetInt(Option.AI_MODE, (int) this.m_currentMode);
        switch (mode)
        {
            case Mode.NORMAL:
            case Mode.EXPERT:
                this.UpdateAIDeckButtons(animate);
                break;

            case Mode.CUSTOM:
                this.UpdateCustomDeckButtons(animate);
                break;
        }
        if (this.m_selectedPracticeAIButtons[this.m_currentMode] == null)
        {
            this.m_playButton.Disable();
        }
        else
        {
            this.m_playButton.Enable();
        }
    }

    private void UpdateAIDeckButtons(bool animate)
    {
        bool flag = Mode.EXPERT == this.m_currentMode;
        List<TAG_CLASS> list = !flag ? NORMAL_AI_CLASS_ORDER : EXPERT_AI_CLASS_ORDER;
        bool flag2 = this.m_unlockedModes.Contains(Mode.EXPERT);
        bool activate = flag;
        bool flag4 = !flag ? flag2 : this.m_unlockedModes.Contains(Mode.CUSTOM);
        PracticeAIButton button = (PracticeAIButton) this.m_selectedPracticeAIButtons[this.m_currentMode];
        for (int i = 0; i < list.Count; i++)
        {
            TAG_CLASS heroClass = list[i];
            MissionMgr.MissionID missionID = !flag ? MissionMgr.Get().GetAINormalMission(heroClass) : MissionMgr.Get().GetAIExpertMission(heroClass);
            string name = !flag ? GameStrings.GetClassName(heroClass) : string.Format(GameStrings.Get("GLUE_AI_EXPERT_TEMPLATE"), GameStrings.GetClassName(heroClass));
            PracticeAIButton button2 = this.m_practiceAIButtons[i];
            string heroIDFromClass = CollectibleHero.GetHeroIDFromClass(heroClass);
            FullDef def = (FullDef) this.m_heroDefs[heroIDFromClass];
            button2.SetInfo(name, heroClass, def.GetCardDef().m_PortraitTexture, missionID, animate);
            bool locked = flag && !flag2;
            button2.Lock(locked);
            bool shown = false;
            foreach (Achievement achievement in this.m_lockedHeroes)
            {
                if (((TAG_CLASS) achievement.ClassRequirement.Value) == heroClass)
                {
                    shown = true;
                    break;
                }
            }
            button2.ShowQuestBang(shown);
            if (button2 == button)
            {
                button2.Select();
            }
            else
            {
                button2.Deselect();
            }
        }
        bool @bool = Options.Get().GetBool(Option.HAS_SEEN_EXPERT_AI, false);
        if (flag && !@bool)
        {
            Options.Get().SetBool(Option.HAS_SEEN_EXPERT_AI, true);
            @bool = true;
        }
        this.m_modeLabel.Text = !flag ? GameStrings.Get("GLUE_AI_OPPONENT_NORMAL") : GameStrings.Get("GLUE_AI_OPPONENT_EXPERT");
        this.m_leftArrow.Activate(activate);
        this.m_rightArrow.Activate(flag4);
        bool highlightOn = ((this.m_currentMode == Mode.NORMAL) && flag4) && !@bool;
        this.m_rightArrow.ActivateHighlight(highlightOn);
    }

    private void UpdateCustomDeckButtons(bool animate)
    {
        PracticeAIButton button = (PracticeAIButton) this.m_selectedPracticeAIButtons[this.m_currentMode];
        for (int i = 0; i < this.m_practiceAIButtons.Count; i++)
        {
            PracticeAIButton button2 = this.m_practiceAIButtons[i];
            if (i < this.m_customDecks.Count)
            {
                NetCache.DeckHeader header = this.m_customDecks[i];
                FullDef def = (FullDef) this.m_heroDefs[header.Hero];
                button2.SetInfo(header.Name, def.GetEntityDef().GetClass(), def.GetCardDef().m_PortraitTexture, header.ID, animate);
                button2.Lock(false);
            }
            else
            {
                button2.CoverUp(animate);
            }
            if (button2 == button)
            {
                button2.Select();
            }
            else
            {
                button2.Deselect();
            }
        }
        this.m_modeLabel.Text = GameStrings.Get("GLUE_AI_OPPONENT_CUSTOM");
        this.m_leftArrow.Activate(this.m_unlockedModes.Contains(Mode.EXPERT));
        this.m_rightArrow.Activate(false);
    }

    [CompilerGenerated]
    private sealed class <DoPickHeroLines>c__Iterator99 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal PracticePickerTrayDisplay <>f__this;
        internal Notification <firstPart>__0;

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
                    this.<firstPart>__0 = NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_PRACTICE_INST1_07"), string.Empty, 4f);
                    break;

                case 1:
                    break;

                case 2:
                    this.$current = new WaitForSeconds(6f);
                    this.$PC = 3;
                    goto Label_0141;

                case 3:
                    if (!this.<>f__this.m_playButton.IsEnabled() && !DeckPickerTrayDisplay.Get().GetLoadingPopup().IsShown())
                    {
                        NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_PRACTICE_INST2_08"), "VO_INNKEEPER_PRACTICE_INST2_08", 2f);
                        this.$PC = -1;
                    }
                    goto Label_013F;

                default:
                    goto Label_013F;
            }
            if (this.<firstPart>__0.GetAudio() == null)
            {
                this.$current = null;
                this.$PC = 1;
            }
            else
            {
                this.$current = new WaitForSeconds(this.<firstPart>__0.GetAudio().clip.length);
                this.$PC = 2;
            }
            goto Label_0141;
        Label_013F:
            return false;
        Label_0141:
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
    private sealed class <InitButtonsWhenReady>c__Iterator9A : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal PracticePickerTrayDisplay <>f__this;

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
                    if (!this.<>f__this.m_buttonsCreated)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_00A3;
                    }
                    break;

                case 2:
                    break;

                default:
                    goto Label_00A1;
            }
            while (!this.<>f__this.m_heroesLoaded)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_00A3;
            }
            this.<>f__this.UpdateAIButtons((PracticePickerTrayDisplay.Mode) Options.Get().GetInt(Option.AI_MODE, 0), false);
            this.<>f__this.m_buttonsReady = true;
            this.$PC = -1;
        Label_00A1:
            return false;
        Label_00A3:
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
    private sealed class <NotifySceneWhenLoaded>c__Iterator9B : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal PracticePickerTrayDisplay <>f__this;
        internal PracticeScene <scene>__0;

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
                    if (!this.<>f__this.m_buttonsReady)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<scene>__0 = SceneMgr.Get().GetScene() as PracticeScene;
                    if (this.<scene>__0 == null)
                    {
                        UnityEngine.Debug.LogError("PracticePickerTrayDisplay.NotifySceneWhenTrayLoaded() - scene is null!");
                    }
                    else
                    {
                        this.<scene>__0.PracticeTrayLoaded();
                        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_BUTTON_PRACTICE);
                        this.$PC = -1;
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

    public enum Mode
    {
        NORMAL,
        EXPERT,
        CUSTOM,
        DUNGEON
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeckPickerTrayDisplay : MonoBehaviour
{
    public List<Material> CLASS_MATERIALS = new List<Material>();
    private string gameMode;
    public List<string> HERO_CARD_IDS = new List<string>();
    public BackButton m_backButton;
    public BasicSetProgress m_basicSetProgress;
    private bool m_buttonsInitialized;
    public List<CollectionDeckBoxVisual> m_customDecks = new List<CollectionDeckBoxVisual>();
    public GameObject m_customTray;
    private Texture m_customTrayTexture;
    public GameObject m_deckboxCoverPrefab;
    public CollectionDeckBoxVisual m_deckboxPrefab;
    public List<GameObject> m_deckCovers = new List<GameObject>();
    public UberText m_deckTrayLabel;
    private bool m_delayButtonAnims;
    public Texture m_emptyHeroTexture;
    private AlertPopup m_friendChallengeWaitingPopup;
    private bool m_fullDefsLoaded;
    private bool m_gameDenied;
    public PegUIElement m_hero;
    public PegUIElement m_heroBox;
    public List<HeroPickerButton> m_heroButtons = new List<HeroPickerButton>();
    public UberText m_heroName;
    public PegUIElement m_heroPower;
    private Actor m_heroPowerBigCard;
    private Hashtable m_heroPowerDefs = new Hashtable();
    private bool m_heroPowerDefsLoaded;
    private int m_heroPowerLoading;
    public GameObject m_heroPrefab;
    private Vector2 m_keyholeTextureOffset;
    public ArrowModeButton m_leftArrow;
    private int m_loading;
    private LoadingPopupDisplay m_loadingPopup;
    private MatchingPopupDisplay m_matchingPopup;
    public GameObject m_medalRibbon;
    public UberText m_modeLabel;
    public GameObject m_modeLabelBg;
    public UberText m_modeName;
    private int m_numCustomDecks;
    private Notification m_paxEast2013WelcomeNotice;
    public PlayButton m_playButton;
    public GameObject m_randomDeckPickerTray;
    public GameObject m_randomDecksHiddenBone;
    public GameObject m_randomDecksShownBone;
    public GameObject m_randomTray;
    public UberText m_randomTrayLabel;
    public UnrankedPlayToggleButton m_rankedPlayToggle;
    public ArrowModeButton m_rightArrow;
    private CollectionDeckBoxVisual m_selectedCustomDeckBox;
    private string m_selectedDeckName;
    private HeroPickerButton m_selectedHeroButton;
    private string m_selectedHeroName;
    private FullDef m_selectedHeroPowerFullDef;
    private bool m_showingCustomDecks;
    public GameObject m_suckedInRandomDecksBone;
    private KeywordHelpPanel m_tooltip;
    public GameObject m_tooltipPrefab;
    public GameObject m_tray;
    private HeroXPBar m_xpBar;
    public HeroXPBar m_xpBarPrefab;
    private const int MAX_CUSTOM_DECKS_TO_DISPLAY = 9;
    private const int MAX_PRECON_DECKS_TO_DISPLAY = 9;
    private static DeckPickerTrayDisplay s_instance;
    private const float TRAY_SLIDE_TIME = 0.25f;

    [DebuggerHidden]
    private IEnumerator ArrowDelayedActivate(ArrowModeButton arrow, float delay)
    {
        return new <ArrowDelayedActivate>c__Iterator23 { delay = delay, arrow = arrow, <$>delay = delay, <$>arrow = arrow };
    }

    private void Awake()
    {
        if (SceneMgr.Get().GetPrevMode() == SceneMgr.Mode.GAMEPLAY)
        {
            this.m_delayButtonAnims = true;
            LoadingScreen.Get().RegisterFinishedTransitionListener(new LoadingScreen.FinishedTransitionCallback(this.OnTransitionFromGameplayFinished));
        }
        DeckPickerTray.Get().RegisterHandlers();
        s_instance = this;
        this.m_backButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.BackButtonPress));
        this.ShowPreconHero(false);
        this.m_heroPower.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.MouseOverHeroPower));
        this.m_heroPower.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.MouseOutHeroPower));
        this.m_playButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.PlayGameButtonRelease));
        this.m_playButton.Disable();
        this.m_leftArrow.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ShowPreconDecks));
        this.m_rightArrow.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ShowCustomDecks));
        this.m_randomTrayLabel.Text = GameStrings.Get("GLUE_CHOOSE_YOUR_HERO");
        this.m_deckTrayLabel.Text = GameStrings.Get("GLUE_CHOOSE_YOUR_DECK");
        this.m_heroName.Text = string.Empty;
        SceneMgr.Mode mode = SceneMgr.Get().GetMode();
        switch (mode)
        {
            case SceneMgr.Mode.TOURNAMENT:
                AssetLoader.Get().LoadActor("MatchingPopup3D", new AssetLoader.GameObjectCallback(this.MatchingPopupLoaded));
                break;

            case SceneMgr.Mode.FRIENDLY:
            case SceneMgr.Mode.PRACTICE:
                AssetLoader.Get().LoadActor("LoadingPopup", new AssetLoader.GameObjectCallback(this.LoadingPopupLoaded));
                break;
        }
        switch (mode)
        {
            case SceneMgr.Mode.COLLECTIONMANAGER:
            case SceneMgr.Mode.PRACTICE:
                this.m_playButton.SetText(GameStrings.Get("GLUE_CHOOSE"));
                this.m_medalRibbon.SetActive(false);
                this.m_rankedPlayToggle.gameObject.SetActive(false);
                break;

            case SceneMgr.Mode.TOURNAMENT:
                this.m_medalRibbon.SetActive(true);
                this.m_playButton.SetText(GameStrings.Get("GLOBAL_PLAY"));
                this.m_rankedPlayToggle.gameObject.SetActive(true);
                break;

            case SceneMgr.Mode.FRIENDLY:
                this.m_medalRibbon.SetActive(false);
                this.m_playButton.SetText(GameStrings.Get("GLUE_CHOOSE"));
                this.m_rankedPlayToggle.gameObject.SetActive(false);
                break;

            default:
                this.m_medalRibbon.SetActive(false);
                this.m_rankedPlayToggle.gameObject.SetActive(false);
                break;
        }
        switch (mode)
        {
            case SceneMgr.Mode.COLLECTIONMANAGER:
                AssetLoader.Get().LoadTexture("HeroPicker_Custom_Tournament", new AssetLoader.ObjectCallback(this.SetCustomTrayTexture));
                AssetLoader.Get().LoadTexture("HeroPicker_Tournament", new AssetLoader.ObjectCallback(this.SetTrayTexture));
                this.m_keyholeTextureOffset = new Vector2(0f, 0f);
                break;

            case SceneMgr.Mode.TOURNAMENT:
                AssetLoader.Get().LoadTexture("HeroPicker_Custom_Tournament", new AssetLoader.ObjectCallback(this.SetCustomTrayTexture));
                AssetLoader.Get().LoadTexture("HeroPicker_Tournament", new AssetLoader.ObjectCallback(this.SetTrayTexture));
                this.m_keyholeTextureOffset = new Vector2(0f, 0f);
                break;

            case SceneMgr.Mode.FRIENDLY:
                AssetLoader.Get().LoadTexture("HeroPicker_Custom_Friendly", new AssetLoader.ObjectCallback(this.SetCustomTrayTexture));
                AssetLoader.Get().LoadTexture("HeroPicker_Friendly", new AssetLoader.ObjectCallback(this.SetTrayTexture));
                this.m_keyholeTextureOffset = new Vector2(0f, 0.61f);
                break;

            case SceneMgr.Mode.PRACTICE:
                AssetLoader.Get().LoadTexture("HeroPicker_Custom_Practice", new AssetLoader.ObjectCallback(this.SetCustomTrayTexture));
                AssetLoader.Get().LoadTexture("HeroPicker_Practice", new AssetLoader.ObjectCallback(this.SetTrayTexture));
                this.m_keyholeTextureOffset = new Vector2(0.5f, 0f);
                break;
        }
        if (mode == SceneMgr.Mode.FRIENDLY)
        {
            FriendChallengeMgr.Get().AddChangedListener(new FriendChallengeMgr.ChangedCallback(this.OnFriendChallengeChanged));
        }
        this.m_xpBar = (HeroXPBar) UnityEngine.Object.Instantiate(this.m_xpBarPrefab);
        this.m_xpBar.m_soloLevelLimit = NetCache.Get().GetNetObject<NetCache.NetCacheRewardProgress>().XPSoloLimit;
        this.m_xpBar.m_isPractice = SceneMgr.Get().GetMode() == SceneMgr.Mode.PRACTICE;
        base.StartCoroutine(this.NotifySceneWhenLoaded());
    }

    private void BackButtonPress(UIEvent e)
    {
        switch (SceneMgr.Get().GetMode())
        {
            case SceneMgr.Mode.COLLECTIONMANAGER:
                CollectionDeckTray.Get().OnHeroPickerCanceled();
                HeroPickerDisplay.Get().HideTray();
                break;

            case SceneMgr.Mode.TOURNAMENT:
                this.BackOut();
                DeckPickerTray.Get().CancelMatch();
                break;

            case SceneMgr.Mode.FRIENDLY:
                this.BackOut();
                FriendChallengeMgr.Get().CancelChallenge();
                break;

            case SceneMgr.Mode.PRACTICE:
                this.BackOut();
                PracticePickerTrayDisplay.Get().gameObject.SetActive(false);
                Network.MakeMatch(0L);
                break;
        }
    }

    private void BackOut()
    {
        if (!this.IsBackingOut())
        {
            FriendChallengeMgr.Get().RemoveChangedListener(new FriendChallengeMgr.ChangedCallback(this.OnFriendChallengeChanged));
            if (this.m_showingCustomDecks)
            {
                this.SuckInPreconDecks();
            }
            else
            {
                SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
            }
            if (this.m_matchingPopup != null)
            {
                this.m_matchingPopup.Cancel();
                UnityEngine.Object.Destroy(this.m_matchingPopup.gameObject);
            }
            else if (this.m_loadingPopup != null)
            {
                this.m_loadingPopup.Cancel();
                UnityEngine.Object.Destroy(this.m_loadingPopup.gameObject);
            }
            else
            {
                this.m_gameDenied = true;
            }
        }
    }

    private void CancelMatch()
    {
        DeckPickerTray.Get().CancelMatch();
        this.m_playButton.Enable();
        this.EnableBackButton(true);
        this.EnableHeroButtons();
    }

    private void Deselect()
    {
        if ((this.m_selectedHeroButton != null) || (this.m_selectedCustomDeckBox != null))
        {
            this.m_playButton.Disable();
            if (this.m_selectedCustomDeckBox != null)
            {
                this.m_selectedCustomDeckBox.SetHighlightState(ActorStateType.HIGHLIGHT_OFF);
                this.m_selectedCustomDeckBox.SetEnabled(true);
                this.m_selectedCustomDeckBox = null;
            }
            this.m_heroBox.gameObject.SetActive(false);
            Actor component = this.m_hero.GetComponent<Actor>();
            component.SetCardDef(null);
            component.Hide();
            if (this.m_selectedHeroButton != null)
            {
                this.m_selectedHeroButton.SetHighlightState(ActorStateType.HIGHLIGHT_OFF);
                this.m_selectedHeroButton.SetSelected(false);
                this.m_selectedHeroButton = null;
            }
            Actor actor2 = this.m_heroPower.GetComponent<Actor>();
            actor2.SetCardDef(null);
            actor2.SetEntityDef(null);
            actor2.Hide();
            this.m_heroPower.collider.enabled = false;
            this.m_selectedHeroPowerFullDef = null;
            if (this.m_heroPowerBigCard != null)
            {
                iTween.Stop(this.m_heroPowerBigCard.gameObject);
                this.m_heroPowerBigCard.Hide();
            }
            this.m_selectedHeroName = null;
            this.m_selectedDeckName = null;
            this.m_heroName.Text = string.Empty;
        }
    }

    private void DeselectLastSelectedHero()
    {
        if (this.m_selectedHeroButton != null)
        {
            this.m_selectedHeroButton.SetHighlightState(ActorStateType.HIGHLIGHT_OFF);
            this.m_selectedHeroButton.SetSelected(false);
        }
    }

    private void DisableHeroButtons()
    {
        foreach (HeroPickerButton button in this.m_heroButtons)
        {
            if (button.IsLocked())
            {
                button.SetEnabled(false);
            }
            else
            {
                button.SetEnabled(true);
            }
        }
    }

    private void EnableBackButton(bool enabled)
    {
        if (DemoMgr.Get().GetMode() == DemoMode.PAX_EAST_2013)
        {
            if (!enabled)
            {
                this.m_backButton.SetEnabled(false);
            }
        }
        else
        {
            this.m_backButton.SetEnabled(enabled);
        }
    }

    private void EnableHeroButtons()
    {
        foreach (HeroPickerButton button in this.m_heroButtons)
        {
            button.SetEnabled(true);
        }
    }

    public static DeckPickerTrayDisplay Get()
    {
        return s_instance;
    }

    private Material GetClassIconMaterial(TAG_CLASS classTag)
    {
        int num = 0;
        switch (classTag)
        {
            case TAG_CLASS.NONE:
                num = 9;
                break;

            case TAG_CLASS.DRUID:
                num = 5;
                break;

            case TAG_CLASS.HUNTER:
                num = 4;
                break;

            case TAG_CLASS.MAGE:
                num = 7;
                break;

            case TAG_CLASS.PALADIN:
                num = 3;
                break;

            case TAG_CLASS.PRIEST:
                num = 8;
                break;

            case TAG_CLASS.ROGUE:
                num = 2;
                break;

            case TAG_CLASS.SHAMAN:
                num = 1;
                break;

            case TAG_CLASS.WARLOCK:
                num = 6;
                break;

            case TAG_CLASS.WARRIOR:
                num = 0;
                break;
        }
        return this.CLASS_MATERIALS[num];
    }

    public LoadingPopupDisplay GetLoadingPopup()
    {
        return this.m_loadingPopup;
    }

    public MatchingPopupDisplay GetMatchingPopup()
    {
        return this.m_matchingPopup;
    }

    public UnrankedPlayToggleButton GetRankedPlayToggle()
    {
        return this.m_rankedPlayToggle;
    }

    public long GetSelectedDeckID()
    {
        if (this.m_showingCustomDecks)
        {
            return ((this.m_selectedCustomDeckBox != null) ? this.m_selectedCustomDeckBox.GetDeckID() : 0L);
        }
        return ((this.m_selectedHeroButton != null) ? this.m_selectedHeroButton.GetPreconDeckID() : 0L);
    }

    private void HandleGameStartupFailure()
    {
        if (this.m_matchingPopup != null)
        {
            this.m_matchingPopup.OnGameDenied();
        }
        else if (this.m_loadingPopup != null)
        {
            this.m_loadingPopup.OnGameDenied();
        }
        else
        {
            this.m_gameDenied = true;
        }
        SceneMgr.Mode mode = SceneMgr.Get().GetMode();
        switch (mode)
        {
            case SceneMgr.Mode.TOURNAMENT:
            case SceneMgr.Mode.FRIENDLY:
                this.m_playButton.Enable();
                this.EnableBackButton(true);
                this.EnableHeroButtons();
                return;

            case SceneMgr.Mode.PRACTICE:
                PracticePickerTrayDisplay.Get().OnGameDenied();
                return;
        }
        UnityEngine.Debug.LogWarning(string.Format("DeckPickerTrayDisplay.HandleGameStartupFailure(): don't know how to handle mode {0}", mode));
    }

    private void HeroPressed(UIEvent e)
    {
        HeroPickerButton element = (HeroPickerButton) e.GetElement();
        this.SelectHero(element);
        this.HidePaxEast2013WelcomeNotice();
    }

    private void HideAllPreconHighlights()
    {
        foreach (HeroPickerButton button in this.m_heroButtons)
        {
            button.SetHighlightState(ActorStateType.HIGHLIGHT_OFF);
        }
    }

    private void HideFriendChallengeWaitingForOpponentDialog()
    {
        if (this.m_friendChallengeWaitingPopup != null)
        {
            this.m_friendChallengeWaitingPopup.Hide();
            this.m_friendChallengeWaitingPopup = null;
        }
    }

    private void HidePaxEast2013WelcomeNotice()
    {
        if ((DemoMgr.Get().GetMode() == DemoMode.PAX_EAST_2013) && (this.m_paxEast2013WelcomeNotice != null))
        {
            NotificationManager.Get().DestroyNotification(this.m_paxEast2013WelcomeNotice, 0f);
            this.m_paxEast2013WelcomeNotice = null;
        }
    }

    public void Init()
    {
        this.InitHeroPickerButtons();
        base.StartCoroutine("InitCustomDecks");
    }

    [DebuggerHidden]
    private IEnumerator InitButtonAchievements()
    {
        return new <InitButtonAchievements>c__Iterator21 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator InitCustomDecks()
    {
        return new <InitCustomDecks>c__Iterator22 { <>f__this = this };
    }

    private void InitHeroPickerButtons()
    {
        int num = 0;
        Vector3 vector = new Vector3(38.27f, 0.45f, 13.65f);
        float num2 = 14.15f;
        float num3 = 13.6f;
        while (num < 9)
        {
            GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(this.m_heroPrefab);
            obj2.name = "HeroButtonParent" + num;
            obj2.transform.parent = this.m_randomDeckPickerTray.transform;
            obj2.transform.localScale = Vector3.one;
            if (num == 0)
            {
                obj2.transform.localPosition = vector;
            }
            else
            {
                float x = vector.x - ((num % 3) * num2);
                float z = (Mathf.CeilToInt((float) (num / 3)) * num3) + vector.z;
                obj2.transform.localPosition = new Vector3(x, vector.y, z);
            }
            HeroPickerButton component = obj2.transform.FindChild("HeroPremade_Frame").gameObject.GetComponent<HeroPickerButton>();
            component.gameObject.renderer.materials[0].mainTextureOffset = this.m_keyholeTextureOffset;
            this.m_heroButtons.Add(component);
            num++;
        }
        int num6 = 0;
        this.m_loading = this.m_heroButtons.Count;
        this.m_heroPowerLoading = this.m_heroButtons.Count;
        foreach (HeroPickerButton button2 in this.m_heroButtons)
        {
            if (num6 >= this.HERO_CARD_IDS.Count)
            {
                Log.Derek.Print("TournamentDisplay - more buttons than heroes");
                break;
            }
            button2.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.HeroPressed));
            button2.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.MouseOverHero));
            button2.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.MouseOutHero));
            button2.SetOriginalLocalPosition();
            button2.Lock();
            button2.SetProgress(0, 0, 1);
            DefLoader.Get().LoadFullDef(this.HERO_CARD_IDS[num6], new DefLoader.LoadDefCallback<FullDef>(this.OnFullDefLoaded), button2);
            num6++;
        }
    }

    private void InitMode()
    {
        if (DemoMgr.Get().GetMode() != DemoMode.PAX_EAST_2013)
        {
            if (SceneMgr.Get().GetMode() == SceneMgr.Mode.COLLECTIONMANAGER)
            {
                this.ShowPreconDecks();
            }
            else if (Options.Get().GetInt(Option.DECK_PICKER_MODE, 0) == 0)
            {
                this.ShowPreconDecks();
            }
            else
            {
                this.ShowCustomDecks();
            }
        }
    }

    private void InitPaxEast2013Mode()
    {
        this.ShowPreconDecks();
        this.m_leftArrow.Activate(false);
        this.m_rightArrow.Activate(false);
        this.m_modeLabel.gameObject.SetActive(false);
        this.m_medalRibbon.SetActive(false);
        this.m_rankedPlayToggle.gameObject.SetActive(false);
        this.EnableBackButton(false);
        this.m_backButton.transform.Rotate((float) 180f, 0f, (float) 0f);
        string text = "Welcome to Hearthstone! Choose your hero!";
        this.m_paxEast2013WelcomeNotice = NotificationManager.Get().CreateInnkeeperQuote(new Vector3(520f, -865f, 0f), text, string.Empty);
    }

    private bool IsBackingOut()
    {
        return SceneMgr.Get().IsModeRequested(SceneMgr.Mode.HUB);
    }

    public bool IsShowingCustomDecks()
    {
        return this.m_showingCustomDecks;
    }

    private void LoadHeroPowerCallback(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("DeckPickerTrayDisplay.LoadHeroPowerCallback() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("DeckPickerTrayDisplay.LoadHeroPowerCallback() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                component.transform.parent = this.m_heroPower.transform;
                component.TurnOffCollider();
                SceneUtils.SetLayer(component.gameObject, GameLayer.Default);
                UberText powersTextMesh = component.GetPowersTextMesh();
                if (powersTextMesh != null)
                {
                    TransformUtil.SetLocalPosY(powersTextMesh.gameObject, powersTextMesh.transform.localPosition.y + 0.1f);
                }
                this.m_heroPowerBigCard = component;
                this.ShowHeroPowerBigCard();
            }
        }
    }

    private void LoadingPopupLoaded(string name, GameObject go, object callbackData)
    {
        this.m_loadingPopup = go.GetComponent<LoadingPopupDisplay>();
        SceneUtils.SetLayer(go, GameLayer.IgnoreFullScreenEffects);
        if (this.m_gameDenied)
        {
            this.m_loadingPopup.OnGameDenied();
            this.m_gameDenied = false;
        }
    }

    private void LowerHeroButtons()
    {
        foreach (HeroPickerButton button in this.m_heroButtons)
        {
            if (button.gameObject.activeSelf)
            {
                button.Lower();
            }
        }
        this.m_customTray.renderer.enabled = true;
        for (int i = 0; i < this.m_numCustomDecks; i++)
        {
            if (i < this.m_customDecks.Count)
            {
                this.m_customDecks[i].Show();
            }
        }
    }

    private void MatchingPopupLoaded(string name, GameObject go, object callbackData)
    {
        this.m_matchingPopup = go.GetComponent<MatchingPopupDisplay>();
        this.m_matchingPopup.RegisterMatchCanceledEvent(new MatchingPopupDisplay.MatchCanceledEvent(this.CancelMatch));
        SceneUtils.SetLayer(go, GameLayer.IgnoreFullScreenEffects);
        if (this.m_gameDenied)
        {
            this.m_matchingPopup.OnGameDenied();
            this.m_gameDenied = false;
        }
    }

    private void MouseOutHero(UIEvent e)
    {
        ((HeroPickerButton) e.GetElement()).SetHighlightState(ActorStateType.HIGHLIGHT_OFF);
    }

    private void MouseOutHeroPower(UIEvent e)
    {
        if (this.m_heroPowerBigCard != null)
        {
            iTween.Stop(this.m_heroPowerBigCard.gameObject);
            this.m_heroPowerBigCard.Hide();
        }
    }

    private void MouseOverHero(UIEvent e)
    {
        if (e != null)
        {
            ((HeroPickerButton) e.GetElement()).SetHighlightState(ActorStateType.HIGHLIGHT_MOUSE_OVER);
            SoundManager.Get().LoadAndPlay("collection_manager_hero_mouse_over");
        }
    }

    private void MouseOverHeroPower(UIEvent e)
    {
        if (this.m_heroPowerBigCard == null)
        {
            AssetLoader.Get().LoadActor("History_HeroPower", new AssetLoader.GameObjectCallback(this.LoadHeroPowerCallback));
        }
        else
        {
            this.ShowHeroPowerBigCard();
        }
    }

    [DebuggerHidden]
    private IEnumerator NotifySceneWhenLoaded()
    {
        return new <NotifySceneWhenLoaded>c__Iterator24 { <>f__this = this };
    }

    private void OnBoxTransitionFinished(object userData)
    {
        this.m_randomDeckPickerTray.SetActive(true);
        Box.Get().RemoveTransitionFinishedListener(new Box.TransitionFinishedCallback(this.OnBoxTransitionFinished));
    }

    private void OnDeckOptionsChanged()
    {
        if (((SceneMgr.Get().GetMode() == SceneMgr.Mode.PRACTICE) && (this.GetSelectedDeckID() == 0)) && PracticePickerTrayDisplay.Get().IsShown())
        {
            PracticePickerTrayDisplay.Get().Hide();
        }
    }

    private void OnFriendChallengeChanged(FriendChallengeEvent challengeEvent, BnetPlayer player, object userData)
    {
        if (challengeEvent == FriendChallengeEvent.SELECTED_DECK)
        {
            if ((player != BnetPresenceMgr.Get().GetMyPlayer()) && FriendChallengeMgr.Get().DidISelectDeck())
            {
                this.HideFriendChallengeWaitingForOpponentDialog();
                this.WaitForFriendChallengeToStart();
            }
        }
        else if (((challengeEvent == FriendChallengeEvent.OPPONENT_CANCELED_CHALLENGE) || (challengeEvent == FriendChallengeEvent.OPPONENT_WENT_OFFLINE)) || (challengeEvent == FriendChallengeEvent.OPPONENT_REMOVED_FROM_FRIENDS))
        {
            this.HideFriendChallengeWaitingForOpponentDialog();
            this.BackOut();
        }
    }

    private bool OnFriendChallengeWaitingForOpponentDialogProcessed(DialogBase dialog, object userData)
    {
        if (!FriendChallengeMgr.Get().HasChallenge())
        {
            return false;
        }
        if (FriendChallengeMgr.Get().DidOpponentSelectDeck())
        {
            this.WaitForFriendChallengeToStart();
            return false;
        }
        this.m_friendChallengeWaitingPopup = (AlertPopup) dialog;
        return true;
    }

    private void OnFriendChallengeWaitingForOpponentDialogResponse(AlertPopup.Response response, object userData)
    {
        if (response == AlertPopup.Response.CANCEL)
        {
            this.Deselect();
            FriendChallengeMgr.Get().DeselectDeck();
            this.m_friendChallengeWaitingPopup.Hide();
            this.m_friendChallengeWaitingPopup = null;
        }
    }

    private void OnFullDefLoaded(string cardId, FullDef def, object userData)
    {
        HeroPickerButton button = (HeroPickerButton) userData;
        button.SetFullDef(def);
        button.SetHeroPortrait(def.GetCardDef().m_PortraitTexture);
        TAG_CLASS tag = def.GetEntityDef().GetClass();
        button.SetClassname(GameStrings.GetClassName(tag));
        button.SetClassIcon(this.GetClassIconMaterial(tag));
        button.SetOriginalLocalPosition();
        if (SceneMgr.Get().GetMode() == SceneMgr.Mode.PRACTICE)
        {
            int num = CollectionManager.Get().GetNumAvailableCards(2, new TAG_CLASS?(tag), null, null);
            int num2 = CollectionManager.Get().GetNumCardsIOwn(2, new TAG_CLASS?(tag), null, null, new CardFlair(CardFlair.PremiumType.STANDARD));
            button.ShowQuestBang(num != num2);
        }
        else
        {
            button.ShowQuestBang(false);
        }
        string heroPowerID = CollectibleHero.GetHeroPowerID(def.GetEntityDef().GetClass());
        DefLoader.Get().LoadFullDef(heroPowerID, new DefLoader.LoadDefCallback<FullDef>(this.OnHeroPowerFullDefLoaded));
        this.m_loading--;
        if (this.m_loading <= 0)
        {
            this.m_fullDefsLoaded = true;
            base.StartCoroutine(this.InitButtonAchievements());
        }
    }

    public void OnGameCanceled(Network.GameCancelInfo cancelInfo)
    {
        if (SceneMgr.Get().GetMode() != SceneMgr.Mode.FRIENDLY)
        {
            this.HandleGameStartupFailure();
            if (cancelInfo.CancelReason == Network.GameCancelInfo.Reason.OPPONENT_TIMEOUT)
            {
                Error.AddWarningLoc("GLOBAL_ERROR_GENERIC_HEADER", "GLOBAL_ERROR_GAME_OPPONENT_TIMEOUT", new object[0]);
            }
            else
            {
                string message = string.Format("Unhandled GameCanceled error: {0}", cancelInfo.CancelReason);
                Error.AddDevWarning("GAME ERROR", message, new object[0]);
            }
        }
    }

    public void OnGameDenied()
    {
        this.HandleGameStartupFailure();
        Error.AddWarningLoc("GLOBAL_ERROR_GENERIC_HEADER", "GLOBAL_ERROR_GAME_DENIED", new object[0]);
    }

    public void OnGameStarting()
    {
        FriendChallengeMgr.Get().RemoveChangedListener(new FriendChallengeMgr.ChangedCallback(this.OnFriendChallengeChanged));
        if ((this.m_matchingPopup != null) && this.m_matchingPopup.IsShown())
        {
            this.m_matchingPopup.OnGameStarting();
        }
        if ((this.m_loadingPopup != null) && this.m_loadingPopup.IsShown())
        {
            this.m_loadingPopup.OnGameStarting();
        }
    }

    public void OnGotoGameServer()
    {
        if ((this.m_matchingPopup != null) && this.m_matchingPopup.IsShown())
        {
            this.m_matchingPopup.OnGotoGameServer();
        }
    }

    private void OnHeroPowerFullDefLoaded(string cardId, FullDef def, object userData)
    {
        this.m_heroPowerDefs[cardId] = def;
        this.m_heroPowerLoading--;
        if (this.m_heroPowerLoading <= 0)
        {
            this.m_heroPowerDefsLoaded = true;
        }
    }

    private void OnTransitionFromGameplayFinished(object callbackData)
    {
        LoadingScreen.Get().UnregisterFinishedTransitionListener(new LoadingScreen.FinishedTransitionCallback(this.OnTransitionFromGameplayFinished));
        this.m_delayButtonAnims = false;
    }

    private void PlayAIGame(MissionMgr.MissionID missionID)
    {
    }

    private void PlayGame()
    {
        switch (SceneMgr.Get().GetMode())
        {
            case SceneMgr.Mode.COLLECTIONMANAGER:
            {
                HeroPickerDisplay.Get().HideTray();
                FullDef fullDef = this.m_selectedHeroButton.GetFullDef();
                CollectionDeckTray.Get().OnHeroPickerHeroSelected(fullDef.GetEntityDef().GetClass(), fullDef.GetEntityDef().GetCardId());
                break;
            }
            case SceneMgr.Mode.TOURNAMENT:
            {
                long selectedDeckID = this.GetSelectedDeckID();
                if (selectedDeckID != 0)
                {
                    this.EnableBackButton(false);
                    MissionMgr.Get().SetNextMission(MissionMgr.MissionID.MULTIPLAYER_1v1);
                    if (Options.Get().GetBool(Option.IN_RANKED_PLAY_MODE))
                    {
                        Network.TrackWhat what = !this.m_showingCustomDecks ? Network.TrackWhat.TRACK_PLAY_TOURNAMENT_WITH_PRECON_DECK : Network.TrackWhat.TRACK_PLAY_TOURNAMENT_WITH_CUSTOM_DECK;
                        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, what);
                        Network.MakeMatch(selectedDeckID);
                    }
                    else
                    {
                        Network.TrackWhat what2 = !this.m_showingCustomDecks ? Network.TrackWhat.TRACK_PLAY_CASUAL_WITH_PRECON_DECK : Network.TrackWhat.TRACK_PLAY_CASUAL_WITH_CUSTOM_DECK;
                        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, what2);
                        Network.UnrankedMatch(selectedDeckID);
                    }
                    FriendChallengeMgr.Get().OnEnteredMatchmakerQueue();
                    break;
                }
                UnityEngine.Debug.LogError("Trying to play tournament game with deck ID 0!");
                return;
            }
            case SceneMgr.Mode.FRIENDLY:
            {
                MissionMgr.Get().SetNextMission(MissionMgr.MissionID.MULTIPLAYER_1v1);
                long deckId = this.GetSelectedDeckID();
                if (deckId != 0)
                {
                    FriendChallengeMgr.Get().SelectDeck(deckId);
                    if (FriendChallengeMgr.Get().DidOpponentSelectDeck())
                    {
                        this.WaitForFriendChallengeToStart();
                    }
                    else
                    {
                        this.ShowFriendChallengeWaitingForOpponentDialog();
                    }
                    break;
                }
                UnityEngine.Debug.LogError("Trying to play friendly game with deck ID 0!");
                return;
            }
            case SceneMgr.Mode.PRACTICE:
                PracticePickerTrayDisplay.Get().Show();
                this.ShowHeroBox(false);
                this.ShowPreconHero(false);
                break;
        }
    }

    private void PlayGameButtonRelease(UIEvent e)
    {
        this.m_playButton.SetEnabled(false);
        this.DisableHeroButtons();
        this.PlayGame();
    }

    private void RaiseHeroButtons()
    {
        foreach (HeroPickerButton button in this.m_heroButtons)
        {
            if (button.gameObject.activeSelf)
            {
                button.Raise();
            }
        }
        this.m_customTray.renderer.enabled = false;
        for (int i = 0; i < this.m_numCustomDecks; i++)
        {
            if (i < this.m_customDecks.Count)
            {
                this.m_customDecks[i].Hide();
            }
        }
    }

    public void ResetCurrentMode()
    {
        if (this.m_showingCustomDecks)
        {
            if (this.m_selectedCustomDeckBox != null)
            {
                this.m_playButton.Enable();
                this.ShowHeroBox(true);
            }
            else
            {
                this.m_playButton.Disable();
            }
            this.EnableHeroButtons();
        }
        else
        {
            if (this.m_selectedHeroButton != null)
            {
                this.m_playButton.Enable();
                this.ShowPreconHero(true);
            }
            else
            {
                this.m_playButton.Disable();
            }
            this.EnableHeroButtons();
        }
    }

    private void SelectCustomDeck(UIEvent e)
    {
        CollectionDeckBoxVisual element = (CollectionDeckBoxVisual) e.GetElement();
        if (element.IsValid())
        {
            if (this.m_selectedCustomDeckBox == null)
            {
                this.ShowHeroBox(true);
            }
            element.SetHighlightState(ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE);
            element.SetEnabled(false);
            if (this.m_selectedCustomDeckBox != null)
            {
                this.m_selectedCustomDeckBox.SetHighlightState(ActorStateType.HIGHLIGHT_OFF);
                this.m_selectedCustomDeckBox.SetEnabled(true);
            }
            this.m_selectedCustomDeckBox = element;
            this.UpdateHeroBoxInfo(element);
            this.m_playButton.Enable();
        }
    }

    private void SelectHero(HeroPickerButton button)
    {
        if (button != this.m_selectedHeroButton)
        {
            this.DeselectLastSelectedHero();
            if ((PracticePickerTrayDisplay.Get() == null) || !PracticePickerTrayDisplay.Get().IsShown())
            {
                this.ShowPreconHero(true);
            }
            if (button.IsLocked())
            {
                this.m_heroPower.GetComponent<Actor>().Hide();
                this.m_heroPower.collider.enabled = false;
            }
            button.SetHighlightState(ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE);
            SoundManager.Get().LoadAndPlay("tournament_screen_select_hero");
            this.m_selectedHeroButton = button;
            this.UpdateHeroInfo(button);
            button.SetSelected(true);
            if (this.m_tooltip != null)
            {
                UnityEngine.Object.DestroyImmediate(this.m_tooltip.gameObject);
            }
            if (button.IsLocked())
            {
                this.m_playButton.Disable();
                this.m_tooltip = ((GameObject) UnityEngine.Object.Instantiate(this.m_tooltipPrefab)).GetComponent<KeywordHelpPanel>();
                this.m_tooltip.SetScale(5f);
                this.m_tooltip.Reset();
                this.m_tooltip.Initialize(GameStrings.Get("GLUE_HERO_LOCKED_NAME"), GameStrings.Get("GLUE_HERO_LOCKED_DESC"));
                this.m_tooltip.transform.position = this.m_hero.transform.position + new Vector3(-0.4f, 0f, 0f);
                this.m_tooltip.transform.parent = base.transform;
            }
            else
            {
                this.m_playButton.Enable();
            }
        }
    }

    private void SetCustomTrayTexture(string name, UnityEngine.Object go, object callbackData)
    {
        Texture texture = go as Texture;
        this.m_customTray.renderer.materials[0].mainTexture = texture;
        this.m_customTrayTexture = texture;
    }

    public void SetHeaderText(string text)
    {
        this.m_modeName.Text = text;
    }

    private void SetTrayTexture(string name, UnityEngine.Object go, object callbackData)
    {
        Texture texture = go as Texture;
        this.m_tray.renderer.materials[0].mainTexture = texture;
        this.m_randomTray.renderer.materials[0].mainTexture = texture;
    }

    private bool ShouldHandleBoxTransition()
    {
        if (SceneMgr.Get().GetPrevMode() == SceneMgr.Mode.GAMEPLAY)
        {
            return false;
        }
        if (!Box.Get().IsBusy() && (Box.Get().GetState() != Box.State.LOADING))
        {
            return false;
        }
        return true;
    }

    private void ShowCustomDecks()
    {
        this.m_xpBar.transform.parent = this.m_heroBox.transform;
        this.m_xpBar.transform.localScale = new Vector3(8.8f, 8.8f, 8.8f);
        this.m_xpBar.transform.localPosition = new Vector3(1.626545f, 3.192199f, 8.19866f);
        this.m_xpBar.m_isOnDeck = true;
        this.HideAllPreconHighlights();
        this.LowerHeroButtons();
        if (this.ShouldHandleBoxTransition())
        {
            Box.Get().AddTransitionFinishedListener(new Box.TransitionFinishedCallback(this.OnBoxTransitionFinished));
            this.m_randomDeckPickerTray.SetActive(false);
            this.m_randomDeckPickerTray.transform.localPosition = this.m_randomDecksHiddenBone.transform.localPosition;
        }
        else
        {
            object[] args = new object[] { "time", 0.25f, "position", this.m_randomDecksHiddenBone.transform.localPosition, "isLocal", true, "delay", 0.2f };
            iTween.MoveTo(this.m_randomDeckPickerTray, iTween.Hash(args));
        }
        this.m_showingCustomDecks = true;
        if (this.m_selectedCustomDeckBox != null)
        {
            this.ShowHeroBox(true);
        }
        else
        {
            this.ShowHeroBox(false);
        }
        this.ShowPreconHero(false);
        this.m_modeLabel.Text = GameStrings.Get("GLUE_SHOW_CUSTOM_DECKS");
        base.StartCoroutine(this.ArrowDelayedActivate(this.m_leftArrow, 0.25f));
        this.m_rightArrow.Activate(false);
        if (this.m_selectedCustomDeckBox != null)
        {
            this.m_playButton.Enable();
        }
        else
        {
            this.m_playButton.Disable();
        }
        Options.Get().SetInt(Option.DECK_PICKER_MODE, 1);
        Options.Get().SetBool(Option.HAS_SEEN_CUSTOM_DECK_PICKER, true);
        this.OnDeckOptionsChanged();
    }

    public void ShowCustomDecks(UIEvent e)
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_TOGGLE_DECK_TYPE);
        this.ShowCustomDecks();
    }

    private void ShowFriendChallengeWaitingForOpponentDialog()
    {
        BnetPlayer myOpponent = FriendChallengeMgr.Get().GetMyOpponent();
        AlertPopup.PopupInfo info = new AlertPopup.PopupInfo();
        object[] args = new object[] { FriendUtils.GetUniqueName(myOpponent) };
        info.m_text = GameStrings.Format("GLOBAL_FRIEND_CHALLENGE_OPPONENT_WAITING_DECK", args);
        info.m_showAlertIcon = false;
        info.m_responseDisplay = AlertPopup.ResponseDisplay.CANCEL;
        info.m_responseCallback = new AlertPopup.ResponseCallback(this.OnFriendChallengeWaitingForOpponentDialogResponse);
        DialogManager.Get().ShowPopup(info, new DialogManager.DialogProcessCallback(this.OnFriendChallengeWaitingForOpponentDialogProcessed));
    }

    private void ShowHeroBox(bool show)
    {
        if (this.m_selectedDeckName == null)
        {
            this.m_heroName.Text = string.Empty;
        }
        else
        {
            this.m_heroName.Text = this.m_selectedDeckName;
        }
        this.m_heroBox.gameObject.SetActive(show);
    }

    private void ShowHeroPowerBigCard()
    {
        FullDef selectedHeroPowerFullDef = this.m_selectedHeroPowerFullDef;
        this.m_heroPowerBigCard.SetCardDef(selectedHeroPowerFullDef.GetCardDef());
        this.m_heroPowerBigCard.SetEntityDef(selectedHeroPowerFullDef.GetEntityDef());
        this.m_heroPowerBigCard.UpdateAllComponents();
        this.m_heroPowerBigCard.Show();
        float x = 1f;
        float num2 = 1.5f;
        Vector3 vector = new Vector3(0.019f, 0.54f, -1.12f);
        GameObject gameObject = this.m_heroPowerBigCard.gameObject;
        gameObject.transform.localPosition = vector;
        this.m_heroPowerBigCard.transform.localScale = new Vector3(x, x, x);
        iTween.ScaleTo(gameObject, new Vector3(num2, num2, num2), 0.15f);
        object[] args = new object[] { "position", vector + new Vector3(0.1f, 0.1f, 0.1f), "isLocal", true, "time", 10 };
        iTween.MoveTo(gameObject, iTween.Hash(args));
    }

    public void ShowMatchingPopup()
    {
        if (this.m_matchingPopup != null)
        {
            this.m_matchingPopup.Show();
        }
    }

    private void ShowPreconDecks()
    {
        Actor component = this.m_hero.GetComponent<Actor>();
        this.m_xpBar.transform.parent = component.GetRootObject().transform;
        this.m_xpBar.transform.localScale = new Vector3(0.89f, 0.89f, 0.89f);
        this.m_xpBar.transform.localPosition = new Vector3(-0.1776525f, 0.1850464f, -0.7309282f);
        this.m_xpBar.m_isOnDeck = false;
        this.ShowHeroBox(false);
        this.ShowPreconHighlights();
        if (this.m_selectedHeroButton != null)
        {
            this.ShowPreconHero(true);
            this.m_playButton.Enable();
        }
        else
        {
            this.m_playButton.Disable();
        }
        switch (SceneMgr.Get().GetMode())
        {
            case SceneMgr.Mode.COLLECTIONMANAGER:
            {
                this.m_leftArrow.Activate(false);
                this.m_rightArrow.Activate(false);
                this.m_modeLabelBg.transform.localEulerAngles = new Vector3(180f, 0f, 0f);
                object[] objArray1 = new object[] { "time", 0.25f, "position", this.m_randomDecksShownBone.transform.localPosition, "isLocal", true, "oncomplete", "RaiseHeroButtons", "oncompletetarget", base.gameObject };
                iTween.MoveTo(this.m_randomDeckPickerTray, iTween.Hash(objArray1));
                this.m_showingCustomDecks = false;
                goto Label_02B5;
            }
            case SceneMgr.Mode.TOURNAMENT:
            case SceneMgr.Mode.FRIENDLY:
            case SceneMgr.Mode.PRACTICE:
            {
                this.m_modeLabel.Text = GameStrings.Get("GLUE_SHOW_PRECON_DECKS");
                this.m_leftArrow.Activate(false);
                if (this.m_numCustomDecks <= 0)
                {
                    this.m_rightArrow.Activate(false);
                    break;
                }
                base.StartCoroutine(this.ArrowDelayedActivate(this.m_rightArrow, 0.25f));
                bool highlightOn = !Options.Get().GetBool(Option.HAS_SEEN_CUSTOM_DECK_PICKER, false);
                this.m_rightArrow.ActivateHighlight(highlightOn);
                break;
            }
            default:
                goto Label_02B5;
        }
        object[] args = new object[] { "time", 0.25f, "position", this.m_randomDecksShownBone.transform.localPosition, "isLocal", true, "oncomplete", "RaiseHeroButtons", "oncompletetarget", base.gameObject };
        iTween.MoveTo(this.m_randomDeckPickerTray, iTween.Hash(args));
        this.m_showingCustomDecks = false;
    Label_02B5:
        if (SceneMgr.Get().GetMode() != SceneMgr.Mode.COLLECTIONMANAGER)
        {
            Options.Get().SetInt(Option.DECK_PICKER_MODE, 0);
        }
        this.OnDeckOptionsChanged();
    }

    private void ShowPreconDecks(UIEvent e)
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_TOGGLE_DECK_TYPE);
        this.ShowPreconDecks();
    }

    private void ShowPreconHero(bool show)
    {
        if (show)
        {
            this.m_hero.GetComponent<Actor>().Show();
            this.m_heroPower.GetComponent<Actor>().Show();
            this.m_heroPower.collider.enabled = true;
            if (this.m_selectedHeroName == null)
            {
                this.m_heroName.Text = string.Empty;
            }
            else
            {
                this.m_heroName.Text = this.m_selectedHeroName;
            }
        }
        else
        {
            this.m_hero.GetComponent<Actor>().Hide();
            this.m_heroPower.GetComponent<Actor>().Hide();
            this.m_heroPower.collider.enabled = false;
            this.m_heroName.Text = string.Empty;
        }
    }

    private void ShowPreconHighlights()
    {
        foreach (HeroPickerButton button in this.m_heroButtons)
        {
            if (button == this.m_selectedHeroButton)
            {
                button.SetHighlightState(ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE);
            }
        }
    }

    public void SuckInFinished()
    {
        this.m_randomDeckPickerTray.SetActive(false);
        SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
    }

    private void SuckInPreconDecks()
    {
        object[] args = new object[] { "time", 0.25f, "position", this.m_suckedInRandomDecksBone.transform.localPosition, "isLocal", true, "oncomplete", "SuckInFinished", "oncompletetarget", base.gameObject };
        iTween.MoveTo(this.m_randomDeckPickerTray, iTween.Hash(args));
    }

    public void Unload()
    {
    }

    private void Update()
    {
        Network.Get().ProcessNetwork();
    }

    private void UpdateHeroBoxInfo(CollectionDeckBoxVisual deckBox)
    {
        this.m_heroName.Text = deckBox.GetHeroName();
        this.m_selectedDeckName = deckBox.GetHeroName();
        this.m_heroBox.renderer.materials[1].mainTexture = deckBox.GetHeroPortraitTexture();
        NetCache.HeroLevel heroLevel = HeroProgressUtils.GetHeroLevel(deckBox.GetClass());
        this.m_xpBar.m_heroLevel = heroLevel;
        this.m_xpBar.UpdateDisplay();
        if (SceneMgr.Get().GetMode() == SceneMgr.Mode.PRACTICE)
        {
            this.m_basicSetProgress.gameObject.SetActive(true);
            TAG_CLASS classTag = deckBox.GetClass();
            this.m_basicSetProgress.UpdateInfo(classTag);
        }
    }

    private void UpdateHeroInfo(HeroPickerButton button)
    {
        FullDef fullDef = button.GetFullDef();
        this.m_heroName.Text = fullDef.GetEntityDef().GetName();
        this.m_selectedHeroName = fullDef.GetEntityDef().GetName();
        Actor component = this.m_hero.GetComponent<Actor>();
        component.SetCardDef(fullDef.GetCardDef());
        component.UpdateAllComponents();
        if (SceneMgr.Get().GetMode() == SceneMgr.Mode.PRACTICE)
        {
            this.m_basicSetProgress.gameObject.SetActive(true);
            TAG_CLASS classTag = fullDef.GetEntityDef().GetClass();
            this.m_basicSetProgress.UpdateInfo(classTag);
        }
        NetCache.HeroLevel heroLevel = HeroProgressUtils.GetHeroLevel(fullDef.GetEntityDef().GetClass());
        this.m_xpBar.m_heroLevel = heroLevel;
        this.m_xpBar.UpdateDisplay();
        string heroPowerID = CollectibleHero.GetHeroPowerID(fullDef.GetEntityDef().GetClass());
        this.UpdateHeroPowerInfo((FullDef) this.m_heroPowerDefs[heroPowerID]);
    }

    private void UpdateHeroPowerInfo(FullDef def)
    {
        Actor component = this.m_heroPower.GetComponent<Actor>();
        component.SetCardDef(def.GetCardDef());
        component.SetEntityDef(def.GetEntityDef());
        component.UpdateAllComponents();
        this.m_selectedHeroPowerFullDef = def;
    }

    private void WaitForFriendChallengeToStart()
    {
        Network.TrackWhat what = !this.m_showingCustomDecks ? Network.TrackWhat.TRACK_ACCEPT_FRIEND_GAME_WITH_PRECON_DECK : Network.TrackWhat.TRACK_ACCEPT_FRIEND_GAME_WITH_CUSTOM_DECK;
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, what);
        this.m_loadingPopup.Show();
    }

    [CompilerGenerated]
    private sealed class <ArrowDelayedActivate>c__Iterator23 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ArrowModeButton <$>arrow;
        internal float <$>delay;
        internal ArrowModeButton arrow;
        internal float delay;

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
                    this.$current = new WaitForSeconds(this.delay);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.arrow.Activate(true);
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
    private sealed class <InitButtonAchievements>c__Iterator21 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<Achievement>.Enumerator <$s_194>__1;
        internal List<Achievement>.Enumerator <$s_195>__5;
        internal DeckPickerTrayDisplay <>f__this;
        internal Achievement <achievement>__2;
        internal Achievement <achievement>__6;
        internal HeroPickerButton <button>__3;
        internal HeroPickerButton <button>__7;
        internal long <preconDeckID>__4;
        internal List<Achievement> <unlockHeroAchieves>__0;

        internal bool <>m__25(HeroPickerButton obj)
        {
            return (obj.GetFullDef().GetEntityDef().GetClass() == ((TAG_CLASS) this.<achievement>__2.ClassRequirement.Value));
        }

        internal bool <>m__26(HeroPickerButton obj)
        {
            return (obj.GetFullDef().GetEntityDef().GetClass() == ((TAG_CLASS) this.<achievement>__6.ClassRequirement.Value));
        }

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
                    this.<unlockHeroAchieves>__0 = AchieveManager.Get().GetAchievesInGroup(Achievement.Group.UNLOCK_HERO);
                    this.<$s_194>__1 = this.<unlockHeroAchieves>__0.GetEnumerator();
                    try
                    {
                        while (this.<$s_194>__1.MoveNext())
                        {
                            this.<achievement>__2 = this.<$s_194>__1.Current;
                            this.<button>__3 = this.<>f__this.m_heroButtons.Find(new Predicate<HeroPickerButton>(this.<>m__25));
                            if (this.<button>__3 == null)
                            {
                                UnityEngine.Debug.LogWarning(string.Format("DeckPickerTrayDisplay.InitButtonAchievementsWhenReady() - could not find hero picker button matching UnlockHeroAchievement with class {0}", this.<achievement>__2.ClassRequirement.Value));
                            }
                            else
                            {
                                if (((TAG_CLASS) this.<achievement>__2.ClassRequirement.Value) == TAG_CLASS.MAGE)
                                {
                                    this.<achievement>__2.AckCurrentProgressAndRewardNotices();
                                }
                                this.<button>__3.SetProgress(this.<achievement>__2.AcknowledgedProgress, this.<achievement>__2.AcknowledgedProgress, this.<achievement>__2.MaxProgress);
                                this.<preconDeckID>__4 = CollectionManager.Get().GetPreconDeckID(this.<achievement>__2.ClassRequirement.Value);
                                this.<button>__3.SetPreconDeckID(this.<preconDeckID>__4);
                                if (this.<achievement>__2.IsCompleted() && (this.<preconDeckID>__4 == 0))
                                {
                                    UnityEngine.Debug.LogError(string.Format("DeckPickerTrayDisplay.InitButtonAchievementsWhenReady(): preconDeckID = 0 for achievement {0}", this.<achievement>__2));
                                }
                            }
                        }
                    }
                    finally
                    {
                        this.<$s_194>__1.Dispose();
                    }
                    this.<>f__this.m_buttonsInitialized = true;
                    break;

                case 1:
                    break;

                default:
                    goto Label_02B1;
            }
            while (this.<>f__this.m_delayButtonAnims)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<$s_195>__5 = this.<unlockHeroAchieves>__0.GetEnumerator();
            try
            {
                while (this.<$s_195>__5.MoveNext())
                {
                    this.<achievement>__6 = this.<$s_195>__5.Current;
                    this.<button>__7 = this.<>f__this.m_heroButtons.Find(new Predicate<HeroPickerButton>(this.<>m__26));
                    if (this.<button>__7 == null)
                    {
                        UnityEngine.Debug.LogWarning(string.Format("DeckPickerTrayDisplay.InitButtonAchievementsWhenReady() - could not find hero picker button matching UnlockHeroAchievement with class {0}", this.<achievement>__6.ClassRequirement.Value));
                    }
                    else
                    {
                        this.<button>__7.SetProgress(this.<achievement>__6.AcknowledgedProgress, this.<achievement>__6.Progress, this.<achievement>__6.MaxProgress);
                        this.<achievement>__6.AckCurrentProgressAndRewardNotices();
                    }
                }
            }
            finally
            {
                this.<$s_195>__5.Dispose();
            }
            this.$PC = -1;
        Label_02B1:
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
    private sealed class <InitCustomDecks>c__Iterator22 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<NetCache.DeckHeader>.Enumerator <$s_196>__12;
        private static Predicate<NetCache.DeckHeader> <>f__am$cache14;
        internal DeckPickerTrayDisplay <>f__this;
        internal NetCache.NetCacheDecks <allDecks>__10;
        internal CollectionDeckBoxVisual <cd>__14;
        internal GameObject <cover>__15;
        internal GameObject <cover>__16;
        internal List<NetCache.DeckHeader> <customDeckHeaders>__11;
        internal CollectionDeckBoxVisual <deckBox>__7;
        internal int <deckCount>__0;
        internal GameObject <deckCover>__8;
        internal NetCache.DeckHeader <deckHeader>__13;
        internal GameObject <go>__4;
        internal float <horizontalSpacing>__2;
        internal int <index>__9;
        internal Vector3 <start>__1;
        internal float <verticalSpacing>__3;
        internal float <xPos>__5;
        internal float <zPos>__6;

        private static bool <>m__27(NetCache.DeckHeader obj)
        {
            return (obj.Type == NetCache.DeckHeader.DeckType.NORMAL_DECK);
        }

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
                    if (this.<>f__this.m_customTrayTexture == null)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<deckCount>__0 = 0;
                    this.<start>__1 = new Vector3(72.24113f, -2.85f, -45.11f);
                    this.<horizontalSpacing>__2 = 14.65f;
                    this.<verticalSpacing>__3 = 13.6f;
                    while (this.<deckCount>__0 < 9)
                    {
                        this.<go>__4 = new GameObject();
                        this.<go>__4.name = "DeckParent" + this.<deckCount>__0;
                        this.<go>__4.transform.parent = this.<>f__this.transform;
                        if (this.<deckCount>__0 == 0)
                        {
                            this.<go>__4.transform.localPosition = this.<start>__1;
                        }
                        else
                        {
                            this.<xPos>__5 = this.<start>__1.x - ((this.<deckCount>__0 % 3) * this.<horizontalSpacing>__2);
                            this.<zPos>__6 = (Mathf.CeilToInt((float) (this.<deckCount>__0 / 3)) * this.<verticalSpacing>__3) + this.<start>__1.z;
                            this.<go>__4.transform.localPosition = new Vector3(this.<xPos>__5, this.<start>__1.y, this.<zPos>__6);
                        }
                        this.<deckBox>__7 = (CollectionDeckBoxVisual) UnityEngine.Object.Instantiate(this.<>f__this.m_deckboxPrefab);
                        this.<deckBox>__7.name = "CollectionDeck" + this.<deckCount>__0;
                        this.<deckBox>__7.transform.parent = this.<go>__4.transform;
                        this.<deckBox>__7.transform.localPosition = Vector3.zero;
                        this.<deckBox>__7.SetOriginalButtonPosition();
                        this.<go>__4.transform.localScale = new Vector3(1f, 1f, 1f);
                        this.<deckBox>__7.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.<>f__this.SelectCustomDeck));
                        this.<deckBox>__7.SetEnabled(true);
                        this.<>f__this.m_customDecks.Add(this.<deckBox>__7);
                        this.<deckCover>__8 = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.m_deckboxCoverPrefab);
                        this.<deckCover>__8.transform.parent = this.<>f__this.transform;
                        this.<deckCover>__8.transform.position = this.<go>__4.transform.position + new Vector3(-0.04171f, -1.525f, -0.76618f);
                        this.<deckCover>__8.transform.GetChild(0).renderer.materials[0].mainTexture = this.<>f__this.m_customTrayTexture;
                        this.<>f__this.m_deckCovers.Add(this.<deckCover>__8);
                        this.<deckCount>__0++;
                    }
                    this.<index>__9 = 0;
                    this.<allDecks>__10 = NetCache.Get().GetNetObject<NetCache.NetCacheDecks>();
                    if (<>f__am$cache14 == null)
                    {
                        <>f__am$cache14 = new Predicate<NetCache.DeckHeader>(DeckPickerTrayDisplay.<InitCustomDecks>c__Iterator22.<>m__27);
                    }
                    this.<customDeckHeaders>__11 = this.<allDecks>__10.Decks.FindAll(<>f__am$cache14);
                    this.<>f__this.m_numCustomDecks = this.<customDeckHeaders>__11.Count;
                    this.<$s_196>__12 = this.<customDeckHeaders>__11.GetEnumerator();
                    try
                    {
                        while (this.<$s_196>__12.MoveNext())
                        {
                            this.<deckHeader>__13 = this.<$s_196>__12.Current;
                            this.<cd>__14 = this.<>f__this.m_customDecks[this.<index>__9];
                            this.<cd>__14.SetDeckName(this.<deckHeader>__13.Name);
                            this.<cd>__14.SetDeckID(this.<deckHeader>__13.ID);
                            this.<cd>__14.SetHeroCardID(this.<deckHeader>__13.Hero);
                            this.<cd>__14.SetIsValid(this.<deckHeader>__13.IsTourneyValid);
                            this.<cd>__14.Show();
                            this.<cover>__15 = this.<>f__this.m_deckCovers[this.<index>__9];
                            this.<cover>__15.SetActive(false);
                            this.<index>__9++;
                            if (this.<index>__9 >= this.<>f__this.m_customDecks.Count)
                            {
                                break;
                            }
                        }
                    }
                    finally
                    {
                        this.<$s_196>__12.Dispose();
                    }
                    break;

                default:
                    goto Label_0519;
            }
            while (this.<index>__9 < this.<>f__this.m_customDecks.Count)
            {
                this.<>f__this.m_customDecks[this.<index>__9].Hide();
                this.<cover>__16 = this.<>f__this.m_deckCovers[this.<index>__9];
                this.<cover>__16.SetActive(true);
                this.<index>__9++;
            }
            this.<>f__this.InitMode();
            this.$PC = -1;
        Label_0519:
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
    private sealed class <NotifySceneWhenLoaded>c__Iterator24 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal DeckPickerTrayDisplay <>f__this;
        internal PlayGameScene <scene>__0;

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
                    if ((!this.<>f__this.m_fullDefsLoaded || !this.<>f__this.m_buttonsInitialized) || !this.<>f__this.m_heroPowerDefsLoaded)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<scene>__0 = SceneMgr.Get().GetScene() as PlayGameScene;
                    if (this.<scene>__0 != null)
                    {
                        if (DemoMgr.Get().GetMode() == DemoMode.PAX_EAST_2013)
                        {
                            this.<>f__this.InitPaxEast2013Mode();
                        }
                        this.<scene>__0.DeckPickerLoaded();
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

    public enum MODE
    {
        PRECON,
        CUSTOM
    }
}


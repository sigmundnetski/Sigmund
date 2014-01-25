using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DraftDisplay : MonoBehaviour
{
    private static readonly Vector3 CHOICE_ACTOR_LOCAL_SCALE = new Vector3(7.2f, 7.2f, 7.2f);
    private static readonly Vector3 FORGE_STORE_POS = new Vector3(-0.627583f, 4.204719f, 0.07684326f);
    private static readonly Vector3 FORGE_STORE_SCALE = new Vector3(45f, 45f, 45f);
    private static readonly Vector3 HERO_ACTOR_LOCAL_SCALE = new Vector3(8.285825f, 8.285825f, 8.285825f);
    public UberText m_10wins;
    public UberText m_15wins;
    public UberText m_20wins;
    private bool m_animationsComplete = true;
    public BackButton m_backButton;
    public Transform m_bigHeroBone;
    private List<DraftChoice> m_choices = new List<DraftChoice>();
    private Actor m_chosenHero;
    private List<HeroLabel> m_currentLabels = new List<HeroLabel>();
    private DraftMode m_currentMode;
    public float m_DeckCardBarFlareUpDelay;
    public Spell m_DeckCompleteSpell;
    private bool m_deckTrayFirstUpdateComplete;
    public UberText m_forgeLabel;
    private Spell[] m_heroEmotes = new Spell[3];
    public GameObject m_heroLabel;
    public UberText m_instructionText;
    private bool m_isHeroAnimating;
    public TextMesh m_lossesLabel;
    public List<GameObject> m_lossMarkers;
    public DraftManaCurve m_manaCurve;
    private MatchingPopupDisplay m_matchingPopup;
    private Actor m_movingDeckTile;
    private bool m_netCacheReady;
    public Collider m_pickArea;
    public PlayButton m_playButton;
    public GameObject m_playModeScreen;
    public BeveledButton m_retireButton;
    public UberText m_rewardsText;
    public Transform m_socketHeroBone;
    public UberText m_winsAmount;
    public TextMesh m_winsLabel;
    private static DraftDisplay s_instance;

    public void AcceptNewChoices(List<string> cardIDs)
    {
        this.DestroyOldChoices();
        this.UpdateInstructionText();
        base.StartCoroutine(this.WaitForAnimsToFinishAndThenDisplayNewChoices(cardIDs));
    }

    public void AddCardToManaCurve(EntityDef entityDef)
    {
        if (entityDef == null)
        {
            UnityEngine.Debug.LogWarning("DraftDisplay.AddCardToManaCurve() - entityDef is null");
        }
        else if (this.m_manaCurve == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("DraftDisplay.AddCardToManaCurve({0}) - m_manaCurve is null", entityDef));
        }
        else
        {
            this.m_manaCurve.AddCardOfCost(entityDef.GetCost());
        }
    }

    private void Awake()
    {
        s_instance = this;
        AssetLoader.Get().LoadActor("MatchingPopup3D", new AssetLoader.GameObjectCallback(this.OnMatchingPopupLoaded));
        AssetLoader.Get().LoadActor("DeckCardBar", new AssetLoader.GameObjectCallback(this.OnDeckTileLoaded));
        DraftManager.Get().RegisterNetHandlers();
        DraftManager.Get().RegisterMatchmakerHandlers();
        DraftManager.Get().RegisterStoreHandlers();
        this.m_forgeLabel.Text = GameStrings.Get("GLUE_TOOLTIP_BUTTON_FORGE_HEADLINE");
        this.m_pickArea.enabled = false;
    }

    private void BackButtonPress()
    {
        this.m_playButton.Disable();
        Box.Get().ResetLayers();
        SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
    }

    private void BackButtonPress(UIEvent e)
    {
        this.BackButtonPress();
    }

    public void CancelMatch()
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CANCEL_MATCHMAKER);
        Network.LeaveDraftQueue();
        FriendChallengeMgr.Get().OnLeftDraftQueue();
    }

    [DebuggerHidden]
    private IEnumerator CompleteAnims()
    {
        return new <CompleteAnims>c__Iterator2A { <>f__this = this };
    }

    private void DestroyChoiceOnSpellFinish(Spell spell, object actorObject)
    {
        Actor actor = (Actor) actorObject;
        base.StartCoroutine(this.DestroyObjectAfterDelay(actor.gameObject));
    }

    [DebuggerHidden]
    private IEnumerator DestroyObjectAfterDelay(GameObject gameObjectToDestroy)
    {
        return new <DestroyObjectAfterDelay>c__Iterator2B { gameObjectToDestroy = gameObjectToDestroy, <$>gameObjectToDestroy = gameObjectToDestroy };
    }

    private void DestroyOldChoices()
    {
        this.m_animationsComplete = false;
        foreach (DraftChoice choice in this.m_choices)
        {
            Actor userData = choice.m_actor;
            if (userData != null)
            {
                DraftCardVisual component = userData.GetCollider().gameObject.GetComponent<DraftCardVisual>();
                userData.GetCollider().enabled = false;
                Spell spell = userData.GetSpell(this.GetSpellTypeForRarity(userData.GetEntityDef().GetRarity()));
                if (component.IsChosen())
                {
                    if (!userData.GetEntityDef().IsHero())
                    {
                        this.AddCardToManaCurve(userData.GetEntityDef());
                        userData.GetSpell(SpellType.SUMMON_OUT_FORGE).AddFinishedCallback(new Spell.FinishedCallback(this.DestroyChoiceOnSpellFinish), userData);
                        userData.ActivateSpell(SpellType.SUMMON_OUT_FORGE);
                        spell.ActivateState(SpellStateType.DEATH);
                        SoundManager.Get().LoadAndPlay("forge_select_card_1");
                        this.MoveDeckTileToDeckTray(userData);
                    }
                    else
                    {
                        this.DoHeroSelectAnimation(component);
                        foreach (HeroLabel label in this.m_currentLabels)
                        {
                            label.FadeOut();
                        }
                    }
                    continue;
                }
                SoundManager.Get().LoadAndPlay("unselected_cards_dissipate");
                userData.GetSpell(SpellType.BURN).AddFinishedCallback(new Spell.FinishedCallback(this.DestroyChoiceOnSpellFinish), userData);
                userData.ActivateSpell(SpellType.BURN);
                if (spell != null)
                {
                    spell.ActivateState(SpellStateType.DEATH);
                }
            }
        }
        base.StartCoroutine(this.CompleteAnims());
        this.m_choices.Clear();
    }

    public void DoDeckCompleteAnims()
    {
        SoundManager.Get().LoadAndPlay("forge_commit_deck");
        this.m_DeckCompleteSpell.Activate();
        if (DraftDeckTray.Get() != null)
        {
            DraftDeckTray.Get().DoDeckCompleteEffects();
        }
    }

    private void DoHeroSelectAnimation(DraftCardVisual draftCard)
    {
        this.m_isHeroAnimating = true;
        this.m_chosenHero = draftCard.GetActor();
        iTween.MoveTo(this.m_chosenHero.gameObject, this.m_bigHeroBone.position, 0.25f);
        SoundManager.Get().LoadAndPlay("forge_hero_portrait_plate_rises");
        base.StartCoroutine(this.FinishHeroAnimation(draftCard));
    }

    private void FinishDeckTileMove(DraftDeckTileVisual tile)
    {
        tile.Show();
        this.m_movingDeckTile.Hide();
    }

    [DebuggerHidden]
    private IEnumerator FinishHeroAnimation(DraftCardVisual draftCard)
    {
        return new <FinishHeroAnimation>c__Iterator27 { draftCard = draftCard, <$>draftCard = draftCard, <>f__this = this };
    }

    public static DraftDisplay Get()
    {
        return s_instance;
    }

    public List<DraftCardVisual> GetCardVisuals()
    {
        List<DraftCardVisual> list = new List<DraftCardVisual>();
        foreach (DraftChoice choice in this.m_choices)
        {
            if (choice.m_actor == null)
            {
                return null;
            }
            DraftCardVisual component = choice.m_actor.GetCollider().gameObject.GetComponent<DraftCardVisual>();
            if (component == null)
            {
                return null;
            }
            list.Add(component);
        }
        return list;
    }

    public DraftMode GetDraftMode()
    {
        return this.m_currentMode;
    }

    public MatchingPopupDisplay GetMatchingPopup()
    {
        return this.m_matchingPopup;
    }

    private SpellType GetSpellTypeForRarity(TAG_RARITY rarity)
    {
        switch (rarity)
        {
            case TAG_RARITY.RARE:
                return SpellType.BURST_RARE;

            case TAG_RARITY.EPIC:
                return SpellType.BURST_EPIC;

            case TAG_RARITY.LEGENDARY:
                return SpellType.BURST_LEGENDARY;
        }
        return SpellType.BURST_COMMON;
    }

    private void HandleGameStartupFailure()
    {
        this.m_matchingPopup.OnGameDenied();
    }

    private bool HaveActorsForAllChoices()
    {
        foreach (DraftChoice choice in this.m_choices)
        {
            if (choice.m_actor == null)
            {
                return false;
            }
        }
        return true;
    }

    private void InitializeDraftScreen()
    {
        switch (this.m_currentMode)
        {
            case DraftMode.NO_ACTIVE_DRAFT:
                this.ShowPurchaseScreen();
                break;

            case DraftMode.DRAFTING:
                this.ShowCurrentlyDraftingScreen();
                break;

            case DraftMode.ACTIVE_DRAFT_DECK:
                this.ShowActiveDraftScreen();
                break;

            default:
                UnityEngine.Debug.LogError(string.Format("DraftDisplay.InitializeDraftScreen(): don't know how to handle m_currentMode = {0}", this.m_currentMode));
                break;
        }
    }

    private void InitManaCurve()
    {
        CollectionDeck draftDeck = DraftManager.Get().GetDraftDeck();
        if (draftDeck != null)
        {
            foreach (CollectionDeckSlot slot in draftDeck.GetSlots())
            {
                EntityDef entityDef = DefLoader.Get().GetEntityDef(slot.CardID);
                for (int i = 0; i < slot.Count; i++)
                {
                    this.AddCardToManaCurve(entityDef);
                }
            }
        }
    }

    private void LoadAndPositionHeroCard()
    {
        string heroCardID = DraftManager.Get().GetDraftDeck().HeroCardID;
        if ((heroCardID != string.Empty) && (heroCardID != null))
        {
            DefLoader.Get().LoadFullDef(heroCardID, new DefLoader.LoadDefCallback<FullDef>(this.OnFullHeroDefLoaded));
        }
    }

    private void ManaCurveOut(UIEvent e)
    {
        this.m_manaCurve.GetComponent<TooltipZone>().HideTooltip();
    }

    private void ManaCurveOver(UIEvent e)
    {
        this.m_manaCurve.GetComponent<TooltipZone>().ShowTooltip(GameStrings.Get("GLUE_FORGE_MANATIP_HEADER"), GameStrings.Get("GLUE_FORGE_MANATIP_DESC"), 4f);
    }

    [DebuggerHidden]
    private IEnumerator MoveDeckTileAfterTrayLoads(Actor choiceActor)
    {
        return new <MoveDeckTileAfterTrayLoads>c__Iterator29 { choiceActor = choiceActor, <$>choiceActor = choiceActor, <>f__this = this };
    }

    private void MoveDeckTileToDeckTray(Actor choiceActor)
    {
        base.StartCoroutine(this.MoveDeckTileAfterTrayLoads(choiceActor));
    }

    [DebuggerHidden]
    private IEnumerator NotifySceneLoadedWhenReady()
    {
        return new <NotifySceneLoadedWhenReady>c__Iterator28 { <>f__this = this };
    }

    private void OnActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        <OnActorLoaded>c__AnonStorey135 storey = new <OnActorLoaded>c__AnonStorey135();
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("DraftDisplay.OnActorLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("DraftDisplay.OnActorLoaded() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                ChoiceCallback callback = (ChoiceCallback) callbackData;
                FullDef fullDef = callback.fullDef;
                storey.entityDef = fullDef.GetEntityDef();
                CardDef cardDef = fullDef.GetCardDef();
                DraftChoice choice = this.m_choices.Find(new Predicate<DraftChoice>(storey.<>m__28));
                if (choice == null)
                {
                    UnityEngine.Debug.LogWarning(string.Format("DraftDisplay.OnActorLoaded(): Could not find draft choice {0} (cardID = {1}) in m_choices.", storey.entityDef.GetName(), storey.entityDef.GetCardId()));
                    UnityEngine.Object.Destroy(component);
                }
                else
                {
                    choice.m_actor = component;
                    choice.m_actor.SetEntityDef(storey.entityDef);
                    choice.m_actor.SetCardDef(cardDef);
                    choice.m_actor.UpdateAllComponents();
                    choice.m_actor.gameObject.name = cardDef.name + "_actor";
                    DraftCardVisual visual = choice.m_actor.GetCollider().gameObject.AddComponent<DraftCardVisual>();
                    visual.SetActor(choice.m_actor);
                    visual.SetChoiceNum(callback.choiceID);
                    if (this.HaveActorsForAllChoices())
                    {
                        this.PositionAndShowChoices();
                    }
                    else
                    {
                        choice.m_actor.Hide();
                    }
                }
            }
        }
    }

    private void OnCardDefLoaded(string cardID, GameObject cardObject, object callbackData)
    {
        foreach (EmoteEntryDef def2 in cardObject.GetComponent<CardDef>().m_EmoteDefs)
        {
            if (def2.m_emoteType == EmoteType.START)
            {
                AssetLoader.Get().LoadSpell(def2.m_emotePath, new AssetLoader.GameObjectCallback(this.OnStartEmoteLoaded), callbackData);
            }
        }
    }

    private void OnDeckTileLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        this.m_movingDeckTile = actorObject.GetComponent<Actor>();
    }

    private void OnFullDefLoaded(string cardID, FullDef def, object userData)
    {
        ChoiceCallback callbackData = (ChoiceCallback) userData;
        callbackData.fullDef = def;
        if (def.GetEntityDef().IsHero())
        {
            AssetLoader.Get().LoadActor(ActorNames.GetZoneActor(def.GetEntityDef(), TAG_ZONE.PLAY), new AssetLoader.GameObjectCallback(this.OnActorLoaded), callbackData);
            AssetLoader.Get().LoadCardPrefab(def.GetEntityDef().GetCardId(), new AssetLoader.GameObjectCallback(this.OnCardDefLoaded), callbackData.choiceID);
        }
        else
        {
            AssetLoader.Get().LoadActor(ActorNames.GetHandActor(def.GetEntityDef()), new AssetLoader.GameObjectCallback(this.OnActorLoaded), callbackData);
        }
    }

    private void OnFullHeroDefLoaded(string cardID, FullDef def, object userData)
    {
        AssetLoader.Get().LoadActor("Card_Play_Hero", new AssetLoader.GameObjectCallback(this.OnHeroActorLoaded), def);
    }

    public void OnGameCanceled(Network.GameCancelInfo cancelInfo)
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

    public void OnGameDenied()
    {
        this.HandleGameStartupFailure();
        Error.AddWarningLoc("GLOBAL_ERROR_GENERIC_HEADER", "GLOBAL_ERROR_GAME_DENIED", new object[0]);
    }

    public void OnGameStarting()
    {
        if (this.m_matchingPopup.IsShown())
        {
            this.m_matchingPopup.OnGameStarting();
        }
    }

    public void OnGotoGameServer()
    {
        if (this.m_matchingPopup.IsShown())
        {
            this.m_matchingPopup.OnGotoGameServer();
        }
    }

    private void OnHeroActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("DraftDisplay.OnHeroActorLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("DraftDisplay.OnActorLoaded() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                FullDef def = (FullDef) callbackData;
                EntityDef entityDef = def.GetEntityDef();
                CardDef cardDef = def.GetCardDef();
                this.m_chosenHero = component;
                this.m_chosenHero.SetEntityDef(entityDef);
                this.m_chosenHero.SetCardDef(cardDef);
                this.m_chosenHero.UpdateAllComponents();
                this.m_chosenHero.gameObject.name = cardDef.name + "_actor";
                this.m_chosenHero.transform.position = this.m_socketHeroBone.position;
                this.m_chosenHero.transform.localScale = HERO_ACTOR_LOCAL_SCALE;
                this.m_chosenHero.GetHealthObject().Hide();
            }
        }
    }

    private void OnMatchingPopupLoaded(string name, GameObject go, object callbackData)
    {
        this.m_matchingPopup = go.GetComponent<MatchingPopupDisplay>();
        this.m_matchingPopup.RegisterMatchCanceledEvent(new MatchingPopupDisplay.MatchCanceledEvent(this.CancelMatch));
        SceneUtils.SetLayer(go, GameLayer.IgnoreFullScreenEffects);
    }

    private void OnNetCacheReady()
    {
        if (!NetCache.Get().GetNetObject<NetCache.NetCacheFeatures>().Games.Forge)
        {
            if (!SceneMgr.Get().IsModeRequested(SceneMgr.Mode.HUB))
            {
                SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
                Error.AddWarningLoc("GLOBAL_FEATURE_DISABLED_TITLE", "GLOBAL_FEATURE_DISABLED_MESSAGE_FORGE", new object[0]);
            }
        }
        else
        {
            this.m_netCacheReady = true;
        }
    }

    private void OnRetirePopupResponse(AlertPopup.Response response, object userData)
    {
        if (response != AlertPopup.Response.CANCEL)
        {
            DraftManager manager = DraftManager.Get();
            CollectionManager.Get().OnDraftDeckRetired(manager.GetDraftDeck());
            this.BackButtonPress();
            ForgePostInfo.ShowForgePostGameScreen(null);
            Network.RetireDraftDeck(manager.GetDraftDeck().ID, manager.GetSlot());
        }
    }

    private void OnStartEmoteLoaded(string name, GameObject go, object callbackData)
    {
        Spell component = go.GetComponent<Spell>();
        int num = (int) callbackData;
        this.m_heroEmotes[num - 1] = component;
    }

    private void OnStoreBackButtonPressed()
    {
        this.BackButtonPress(null);
    }

    private void PlayButtonPress(UIEvent e)
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_PLAY_FORGE_QUEUE);
        Network.JoinDraftQueue();
        FriendChallengeMgr.Get().OnEnteredDraftQueue();
    }

    private void PositionAndShowChoices()
    {
        this.m_pickArea.enabled = true;
        float num = this.m_pickArea.bounds.center.x - this.m_pickArea.bounds.extents.x;
        float num3 = this.m_pickArea.bounds.size.x / 3f;
        float num4 = (this.m_choices.Count != 2) ? (-num3 / 2f) : 0f;
        for (int i = 0; i < this.m_choices.Count; i++)
        {
            DraftChoice choice = this.m_choices[i];
            if (choice.m_actor == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("DraftDisplay.PositionAndShowChoices(): WARNING found choice with null actor (cardID = {0}). Skipping...", choice.m_cardID));
                continue;
            }
            choice.m_actor.transform.position = new Vector3((num + ((i + 1) * num3)) + num4, this.m_pickArea.transform.position.y, this.m_pickArea.transform.position.z);
            choice.m_actor.Show();
            choice.m_actor.ActivateSpell(SpellType.SUMMON_IN_FORGE);
            TAG_RARITY rarity = choice.m_actor.GetEntityDef().GetRarity();
            choice.m_actor.ActivateSpell(this.GetSpellTypeForRarity(rarity));
            switch (rarity)
            {
                case TAG_RARITY.COMMON:
                case TAG_RARITY.FREE:
                    SoundManager.Get().LoadAndPlay("forge_normal_card_appears");
                    break;

                case TAG_RARITY.RARE:
                case TAG_RARITY.EPIC:
                case TAG_RARITY.LEGENDARY:
                    SoundManager.Get().LoadAndPlay("forge_rarity_card_appears");
                    break;
            }
            if (choice.m_actor.GetEntityDef().IsHero())
            {
                choice.m_actor.transform.localScale = HERO_ACTOR_LOCAL_SCALE;
                choice.m_actor.GetHealthObject().Hide();
                GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(this.m_heroLabel);
                obj2.transform.position = choice.m_actor.GetMeshRenderer().transform.position;
                HeroLabel component = obj2.GetComponent<HeroLabel>();
                obj2.transform.localScale = new Vector3(8f, 8f, 8f);
                component.UpdateText(choice.m_actor.GetEntityDef().GetName(), GameStrings.GetClassName(choice.m_actor.GetEntityDef().GetClass()).ToUpper());
                this.m_currentLabels.Add(component);
            }
            else
            {
                choice.m_actor.transform.localScale = CHOICE_ACTOR_LOCAL_SCALE;
            }
        }
        this.m_pickArea.enabled = false;
    }

    private void RetireButtonPress(UIEvent e)
    {
        AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
            m_headerText = GameStrings.Get("GLUE_FORGE_RETIRE_WARNING_HEADER"),
            m_text = GameStrings.Get("GLUE_FORGE_RETIRE_WARNING_DESC"),
            m_showAlertIcon = false,
            m_responseDisplay = AlertPopup.ResponseDisplay.CONFIRM_CANCEL,
            m_responseCallback = new AlertPopup.ResponseCallback(this.OnRetirePopupResponse)
        };
        DialogManager.Get().ShowPopup(info);
    }

    public void SetDraftMode(DraftMode mode)
    {
        bool flag = this.m_currentMode != mode;
        this.m_currentMode = mode;
        this.UpdateDraftDeckTray();
        if (flag)
        {
            Log.Ben.Print("SetDraftMode - " + this.m_currentMode);
            this.InitializeDraftScreen();
        }
    }

    private void ShowActiveDraftScreen()
    {
        StoreManager.Get().HideForgeStore();
        this.m_playModeScreen.SetActive(true);
        this.m_winsLabel.text = GameStrings.Get("GLOBAL_WINS") + ":";
        this.m_lossesLabel.text = GameStrings.Get("GLOBAL_LOSSES") + ":";
        object[] args = new object[] { DraftManager.Get().GetWins() };
        this.m_winsAmount.Text = GameStrings.Format("GLOBAL_MY_NUM_WINS", args);
        this.m_rewardsText.Text = GameStrings.Get("GLUE_FORGE_PRIZES");
        this.m_10wins.Text = string.Format(GameStrings.Get("GLUE_FORGE_EXTRA_PRIZE_LABEL"), "10");
        this.m_15wins.Text = string.Format(GameStrings.Get("GLUE_FORGE_EXTRA_PRIZE_LABEL"), "15");
        this.m_20wins.Text = string.Format(GameStrings.Get("GLUE_FORGE_EXTRA_PRIZE_LABEL"), "20");
        this.m_lossMarkers[0].SetActive(false);
        this.m_lossMarkers[1].SetActive(false);
        this.m_lossMarkers[2].SetActive(false);
        int num = 0;
        int losses = DraftManager.Get().GetLosses();
        while (num < losses)
        {
            this.m_lossMarkers[num].SetActive(true);
            num++;
        }
        this.DestroyOldChoices();
        this.m_retireButton.Show();
        this.m_playButton.Enable();
        this.UpdateInstructionText();
        this.LoadAndPositionHeroCard();
        if (!Options.Get().GetBool(Option.HAS_SEEN_FORGE_PLAY_MODE, false))
        {
            NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_FORGE_COMPLETE_22"), "VO_INNKEEPER_FORGE_COMPLETE_22", 3f);
            Options.Get().SetBool(Option.HAS_SEEN_FORGE_PLAY_MODE, true);
        }
        else if ((losses == 2) && !Options.Get().GetBool(Option.HAS_SEEN_FORGE_2LOSS, false))
        {
            NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_FORGE_2LOSS_25"), "VO_INNKEEPER_FORGE_2LOSS_25", 3f);
            Options.Get().SetBool(Option.HAS_SEEN_FORGE_2LOSS, true);
        }
        else if ((DraftManager.Get().GetWins() == 1) && !Options.Get().GetBool(Option.HAS_SEEN_FORGE_1WIN, false))
        {
            NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_FORGE_1WIN_23"), "VO_INNKEEPER_FORGE_1WIN_23", 3f);
            Options.Get().SetBool(Option.HAS_SEEN_FORGE_1WIN, true);
        }
        else if ((DraftManager.Get().GetWins() == 5) && !Options.Get().GetBool(Option.HAS_SEEN_FORGE_5WIN, false))
        {
            NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_FORGE_5WIN_24"), "VO_INNKEEPER_FORGE_5WIN_24", 3f);
            Options.Get().SetBool(Option.HAS_SEEN_FORGE_5WIN, true);
        }
    }

    private void ShowCurrentlyDraftingScreen()
    {
        StoreManager.Get().HideForgeStore();
        this.m_playModeScreen.SetActive(false);
        this.UpdateInstructionText();
        this.m_retireButton.Hide();
        this.m_playButton.Disable();
        this.LoadAndPositionHeroCard();
    }

    public void ShowMatchingPopup()
    {
        this.m_matchingPopup.Show();
    }

    private void ShowPurchaseScreen()
    {
        Box.Get().SetToIgnoreFullScreenEffects();
        this.m_playModeScreen.SetActive(false);
        this.m_playButton.Disable();
        this.m_retireButton.Hide();
        if (this.m_manaCurve != null)
        {
            this.m_manaCurve.ResetBars();
        }
        if (!Options.Get().GetBool(Option.HAS_SEEN_FORGE, false))
        {
            NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_FORGE_INTRO_17"), "VO_INNKEEPER_FORGE_INTRO_17");
            Options.Get().SetBool(Option.HAS_SEEN_FORGE, true);
        }
        StoreManager.Get().StartForgeTransaction(FORGE_STORE_POS, FORGE_STORE_SCALE, new Store.ExitListener(this.OnStoreBackButtonPressed));
    }

    private void Start()
    {
        this.m_retireButton.SetText(GameStrings.Get("GLUE_DRAFT_RETIRE_BUTTON"));
        NetCache.Get().RegisterScreenForge(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        this.m_backButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.BackButtonPress));
        this.m_retireButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.RetireButtonPress));
        this.m_playButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.PlayButtonPress));
        this.m_manaCurve.GetComponent<PegUIElement>().AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.ManaCurveOver));
        this.m_manaCurve.GetComponent<PegUIElement>().AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.ManaCurveOut));
        this.m_playButton.SetText(GameStrings.Get("GLOBAL_PLAY"));
        Network.FindOutCurrentDraftState();
        SoundManager.Get().NukePlaylistsAndStopPlayingCurrentTracks();
        SoundManager.Get().AddNewMusicTrack("The_Forge");
        SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_light");
        base.StartCoroutine(this.NotifySceneLoadedWhenReady());
    }

    public void Unload()
    {
        DraftManager.Get().RemoveNetHandlers();
        DraftManager.Get().RemoveMatchmakerHandlers();
        DraftManager.Get().RemoveStoreHandlers();
        DraftDeckTray.Get().Unload();
        DraftInputManager.Get().Unload();
        DefLoader.Get().ClearCardDefs();
    }

    private void Update()
    {
        Network.Get().ProcessNetwork();
    }

    private void UpdateDraftDeckTray()
    {
        DraftDeckTray.Mode mode;
        if (DraftDeckTray.Get().IsLoaded())
        {
            this.m_deckTrayFirstUpdateComplete = true;
            switch (this.m_currentMode)
            {
                case DraftMode.NO_ACTIVE_DRAFT:
                    mode = DraftDeckTray.Mode.NO_DRAFT_DECK;
                    goto Label_007C;

                case DraftMode.DRAFTING:
                    mode = (DraftManager.Get().GetSlot() != 0) ? DraftDeckTray.Mode.DRAFT_DECK_BUILDING : DraftDeckTray.Mode.DRAFT_DECK_CHOOSE_HERO;
                    goto Label_007C;

                case DraftMode.ACTIVE_DRAFT_DECK:
                    mode = DraftDeckTray.Mode.DRAFT_DECK_COMPLETE;
                    goto Label_007C;
            }
            UnityEngine.Debug.LogError(string.Format("DraftDisplay.UpdateDraftDeckTray(): don't know how to handle m_currentMode = {0}", this.m_currentMode));
        }
        return;
    Label_007C:
        DraftDeckTray.Get().SetMode(mode);
    }

    private void UpdateInstructionText()
    {
        if (this.GetDraftMode() == DraftMode.DRAFTING)
        {
            if (DraftManager.Get().GetSlot() == 0)
            {
                if (!Options.Get().GetBool(Option.HAS_SEEN_FORGE_HERO_CHOICE, false))
                {
                    NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_FORGE_INST1_19"), "VO_INNKEEPER_FORGE_INST1_19", 3f);
                    Options.Get().SetBool(Option.HAS_SEEN_FORGE_HERO_CHOICE, true);
                }
            }
            else if (Options.Get().GetBool(Option.HAS_SEEN_FORGE_CARD_CHOICE, false) && !Options.Get().GetBool(Option.HAS_SEEN_FORGE_CARD_CHOICE2, false))
            {
                NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_FORGE_INST3_21"), "VO_INNKEEPER_FORGE_INST3_21", 3f);
                Options.Get().SetBool(Option.HAS_SEEN_FORGE_CARD_CHOICE2, true);
            }
            string str = (DraftManager.Get().GetSlot() != 0) ? GameStrings.Get("GLUE_DRAFT_INSTRUCTIONS") : GameStrings.Get("GLUE_DRAFT_HERO_INSTRUCTIONS");
            this.m_instructionText.Text = str;
        }
        else if (this.GetDraftMode() == DraftMode.ACTIVE_DRAFT_DECK)
        {
            this.m_instructionText.Text = GameStrings.Get("GLUE_DRAFT_MATCH_PROG");
        }
        else
        {
            this.m_instructionText.Text = string.Empty;
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitForAnimsToFinishAndThenDisplayNewChoices(List<string> cardIDs)
    {
        return new <WaitForAnimsToFinishAndThenDisplayNewChoices>c__Iterator26 { cardIDs = cardIDs, <$>cardIDs = cardIDs, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <CompleteAnims>c__Iterator2A : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal DraftDisplay <>f__this;

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
                    this.$current = new WaitForSeconds(0.5f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_animationsComplete = true;
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
    private sealed class <DestroyObjectAfterDelay>c__Iterator2B : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GameObject <$>gameObjectToDestroy;
        internal GameObject gameObjectToDestroy;

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
                    this.$current = new WaitForSeconds(5f);
                    this.$PC = 1;
                    return true;

                case 1:
                    UnityEngine.Object.Destroy(this.gameObjectToDestroy);
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
    private sealed class <FinishHeroAnimation>c__Iterator27 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal DraftCardVisual <$>draftCard;
        internal DraftDisplay <>f__this;
        internal AudioSource <audioSource>__2;
        internal Spell <emote>__1;
        internal int <index>__0;
        internal DraftCardVisual draftCard;

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
                    this.<index>__0 = this.draftCard.GetChoiceNum() - 1;
                    break;

                case 1:
                    break;

                case 2:
                    goto Label_00CA;

                default:
                    goto Label_0161;
            }
            if (this.<>f__this.m_heroEmotes[this.<index>__0] == null)
            {
                this.$current = null;
                this.$PC = 1;
                goto Label_0163;
            }
            this.<emote>__1 = this.<>f__this.m_heroEmotes[this.<index>__0];
            this.<emote>__1.Activate();
            this.<audioSource>__2 = this.<emote>__1.GetFirstSpellState(1).m_AudioSources[0].m_AudioSource;
        Label_00CA:
            while (this.<audioSource>__2.isPlaying)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_0163;
            }
            this.draftCard.GetActor().ActivateSpell(SpellType.CONSTRUCT);
            SoundManager.Get().LoadAndPlay("forge_hero_portrait_plate_descend_and_impact");
            this.<>f__this.m_isHeroAnimating = false;
            if (!Options.Get().GetBool(Option.HAS_SEEN_FORGE_CARD_CHOICE, false))
            {
                NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_FORGE_INST2_20"), "VO_INNKEEPER_FORGE_INST2_20", 3f);
                Options.Get().SetBool(Option.HAS_SEEN_FORGE_CARD_CHOICE, true);
            }
            this.$PC = -1;
        Label_0161:
            return false;
        Label_0163:
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
    private sealed class <MoveDeckTileAfterTrayLoads>c__Iterator29 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Actor <$>choiceActor;
        internal DraftDisplay <>f__this;
        internal string <cardID>__0;
        internal Vector3 <currentSpot>__4;
        internal Vector3[] <newPath>__3;
        internal Vector3 <newSpot>__2;
        internal DraftDeckTileVisual <tile>__1;
        internal Actor choiceActor;

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
                    this.<>f__this.m_movingDeckTile.Show();
                    this.<>f__this.m_movingDeckTile.SetCardDef((CardDef) UnityEngine.Object.Instantiate(this.choiceActor.GetCardDef()));
                    this.<>f__this.m_movingDeckTile.SetEntityDef(this.choiceActor.GetEntityDef());
                    this.<>f__this.m_movingDeckTile.UpdateAllComponents();
                    iTween.Stop(this.<>f__this.m_movingDeckTile.gameObject);
                    this.<>f__this.m_movingDeckTile.transform.position = new Vector3(this.choiceActor.transform.position.x, this.choiceActor.transform.position.y + 2.5f, this.choiceActor.transform.position.z);
                    this.<cardID>__0 = this.choiceActor.GetEntityDef().GetCardId();
                    this.<tile>__1 = DraftDeckTray.Get().GetDeckTileVisual(this.<cardID>__0);
                    break;

                case 1:
                    break;

                default:
                    goto Label_0372;
            }
            if (this.<tile>__1 == null)
            {
                this.<tile>__1 = DraftDeckTray.Get().GetDeckTileVisual(this.<cardID>__0);
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<newSpot>__2 = this.<tile>__1.transform.position;
            if (DraftManager.Get().GetDraftDeck().GetCardIdCount(this.<cardID>__0) == 1)
            {
                this.<tile>__1.Hide();
            }
            this.<>f__this.m_movingDeckTile.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            this.<>f__this.m_movingDeckTile.DeactivateAllSpells();
            this.<>f__this.m_movingDeckTile.ActivateSpell(SpellType.SUMMON_IN_LARGE);
            this.<newPath>__3 = new Vector3[3];
            this.<currentSpot>__4 = this.<>f__this.m_movingDeckTile.transform.position;
            this.<newPath>__3[0] = this.<currentSpot>__4;
            this.<newPath>__3[1] = new Vector3((this.<currentSpot>__4.x + this.<newSpot>__2.x) / 2f, ((this.<currentSpot>__4.y + this.<newSpot>__2.y) / 2f) + 60f, (this.<currentSpot>__4.z + this.<newSpot>__2.z) / 2f);
            this.<newPath>__3[2] = this.<newSpot>__2;
            object[] args = new object[] { "path", this.<newPath>__3, "time", 1f, "easetype", iTween.EaseType.easeOutCirc, "oncomplete", "FinishDeckTileMove", "oncompletetarget", this.<>f__this.gameObject, "oncompleteparams", this.<tile>__1 };
            iTween.MoveTo(this.<>f__this.m_movingDeckTile.gameObject, iTween.Hash(args));
            SoundManager.Get().LoadAndPlay("forge_card_flies_and_drops_into_tray_slot_1", this.<>f__this.m_movingDeckTile.gameObject);
            this.$PC = -1;
        Label_0372:
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
    private sealed class <NotifySceneLoadedWhenReady>c__Iterator28 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal DraftDisplay <>f__this;
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
                    if (this.<>f__this.m_movingDeckTile == null)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_019B;
                    }
                    break;

                case 2:
                    break;

                case 3:
                    goto Label_00A9;

                case 4:
                    goto Label_00D0;

                case 5:
                    goto Label_00F8;

                case 6:
                    goto Label_0120;

                default:
                    goto Label_0199;
            }
            while (this.<>f__this.m_matchingPopup == null)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_019B;
            }
        Label_00A9:
            while (!DraftDeckTray.Get().IsLoaded())
            {
                this.$current = null;
                this.$PC = 3;
                goto Label_019B;
            }
        Label_00D0:
            while (this.<>f__this.m_currentMode == DraftDisplay.DraftMode.INVALID)
            {
                this.$current = null;
                this.$PC = 4;
                goto Label_019B;
            }
        Label_00F8:
            while (!this.<>f__this.m_netCacheReady)
            {
                this.$current = null;
                this.$PC = 5;
                goto Label_019B;
            }
        Label_0120:
            while (!AchieveManager.Get().IsReady())
            {
                this.$current = null;
                this.$PC = 6;
                goto Label_019B;
            }
            if (!this.<>f__this.m_deckTrayFirstUpdateComplete)
            {
                this.<>f__this.UpdateDraftDeckTray();
            }
            this.<>f__this.InitManaCurve();
            DraftDeckTray.Get().InitDeckTrayContents();
            this.<newlyActiveAchieves>__0 = AchieveManager.Get().GetActiveQuests(true);
            if (this.<newlyActiveAchieves>__0.Count > 0)
            {
                WelcomeQuests.Show(false, null);
            }
            SceneMgr.Get().NotifySceneLoaded();
            this.$PC = -1;
        Label_0199:
            return false;
        Label_019B:
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
    private sealed class <OnActorLoaded>c__AnonStorey135
    {
        internal EntityDef entityDef;

        internal bool <>m__28(DraftDisplay.DraftChoice obj)
        {
            return obj.m_cardID.Equals(this.entityDef.GetCardId());
        }
    }

    [CompilerGenerated]
    private sealed class <WaitForAnimsToFinishAndThenDisplayNewChoices>c__Iterator26 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<string> <$>cardIDs;
        internal DraftDisplay <>f__this;
        internal DraftDisplay.ChoiceCallback <callbackInfo>__6;
        internal DraftDisplay.DraftChoice <choice>__5;
        internal int <currentDraftSlot>__3;
        internal int <i>__0;
        internal int <i>__4;
        internal string <newCardID>__1;
        internal DraftDisplay.DraftChoice <newChoice>__2;
        internal List<string> cardIDs;

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
                    if (!this.<>f__this.m_animationsComplete)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_01B0;
                    }
                    break;

                case 2:
                    break;

                default:
                    goto Label_01AE;
            }
            while (this.<>f__this.m_isHeroAnimating)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_01B0;
            }
            this.<i>__0 = 0;
            while (this.<i>__0 < this.cardIDs.Count)
            {
                this.<newCardID>__1 = this.cardIDs[this.<i>__0];
                DraftDisplay.DraftChoice choice = new DraftDisplay.DraftChoice {
                    m_cardID = this.<newCardID>__1
                };
                this.<newChoice>__2 = choice;
                this.<>f__this.m_choices.Add(this.<newChoice>__2);
                this.<i>__0++;
            }
            this.<currentDraftSlot>__3 = DraftManager.Get().GetSlot();
            this.<i>__4 = 0;
            while (this.<i>__4 < this.<>f__this.m_choices.Count)
            {
                this.<choice>__5 = this.<>f__this.m_choices[this.<i>__4];
                this.<callbackInfo>__6 = new DraftDisplay.ChoiceCallback();
                this.<callbackInfo>__6.choiceID = this.<i>__4 + 1;
                this.<callbackInfo>__6.slot = this.<currentDraftSlot>__3;
                DefLoader.Get().LoadFullDef(this.<choice>__5.m_cardID, new DefLoader.LoadDefCallback<FullDef>(this.<>f__this.OnFullDefLoaded), this.<callbackInfo>__6);
                this.<i>__4++;
            }
            this.$PC = -1;
        Label_01AE:
            return false;
        Label_01B0:
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

    private class ChoiceCallback
    {
        public int choiceID;
        public FullDef fullDef;
        public int slot;
    }

    private class DraftChoice
    {
        public Actor m_actor;
        public string m_cardID = string.Empty;
    }

    public enum DraftMode
    {
        INVALID,
        NO_ACTIVE_DRAFT,
        DRAFTING,
        ACTIVE_DRAFT_DECK
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tutorial_01 : TutorialEntity
{
    private bool announcerIsFinishedYapping;
    private KeywordHelpPanel attackHelpPanel;
    private GameObject attackLabel;
    private Notification attackWithYourMinion;
    private GameObject costLabel;
    private Notification crushThisGnoll;
    private Notification endTurnNotifier;
    private bool firstAttackFinished;
    private Card firstMurlocCard;
    private Card firstRaptorCard;
    private Notification freeCardsPopup;
    private Notification handBounceArrow;
    private KeywordHelpPanel healthHelpPanel;
    private GameObject healthLabel;
    private bool m_jainaSpeaking;
    private Card mousedOverCard;
    private Notification noFireballPopup;
    private int numTimesTextSwapStarted;
    private bool packOpened;
    private GameObject startingPack;
    private string textToShowForAttackTip = GameStrings.Get("TUTORIAL01_HELP_02");
    private bool tooltipsDisabled = true;

    public Tutorial_01()
    {
        GameState.Get().MulliganManagerActivate(true);
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_START_TUTORIAL);
    }

    public override bool AreTooltipsDisabled()
    {
        return this.tooltipsDisabled;
    }

    private void AttackLabelLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        Card card = (Card) callbackData;
        GameObject attackTextObject = card.GetActor().GetAttackTextObject();
        if (attackTextObject == null)
        {
            UnityEngine.Object.Destroy(actorObject);
        }
        else
        {
            this.attackLabel = actorObject;
            actorObject.transform.parent = attackTextObject.transform;
            actorObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            actorObject.transform.localPosition = new Vector3(-0.2f, -0.3039344f, 0f);
            actorObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            actorObject.GetComponent<UberText>().Text = GameStrings.Get("GLOBAL_ATTACK");
        }
    }

    [DebuggerHidden]
    private IEnumerator BeginFlashingMinionLoop(Card minionToFlash)
    {
        return new <BeginFlashingMinionLoop>c__Iterator7E { minionToFlash = minionToFlash, <$>minionToFlash = minionToFlash, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator ContinueFinishingCustomIntro()
    {
        return new <ContinueFinishingCustomIntro>c__Iterator81 { <>f__this = this };
    }

    private void DialogLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        base.startingPopup = actorObject.GetComponent<Notification>();
        NotificationManager.Get().CreatePopupDialogFromObject(base.startingPopup, GameStrings.Get("TUTORIAL01_HELP_14"), GameStrings.Get("TUTORIAL01_HELP_15"), GameStrings.Get("TUTORIAL01_HELP_16"));
        base.startingPopup.ButtonStart.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.UserPressedStartButton));
        base.startingPopup.artOverlay.material.mainTextureOffset = new Vector2(0f, 0f);
    }

    [DebuggerHidden]
    private IEnumerator FlashMinionUntilAttackBegins(Card minionToFlash)
    {
        return new <FlashMinionUntilAttackBegins>c__Iterator7D { minionToFlash = minionToFlash, <$>minionToFlash = minionToFlash, <>f__this = this };
    }

    public override List<RewardData> GetCustomRewards()
    {
        List<RewardData> list = new List<RewardData>();
        CardRewardData item = new CardRewardData("CS2_023", CardFlair.PremiumType.STANDARD, 2);
        list.Add(item);
        return list;
    }

    [DebuggerHidden]
    protected override IEnumerator HandleMissionEventWithTiming(int missionEvent)
    {
        return new <HandleMissionEventWithTiming>c__Iterator7B { missionEvent = missionEvent, <$>missionEvent = missionEvent, <>f__this = this };
    }

    [DebuggerHidden]
    protected override IEnumerator HandleStartOfTurnWithTiming(int turn)
    {
        return new <HandleStartOfTurnWithTiming>c__Iterator7A { turn = turn, <$>turn = turn, <>f__this = this };
    }

    private void HealthLabelLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        Card card = (Card) callbackData;
        GameObject healthTextObject = card.GetActor().GetHealthTextObject();
        if (healthTextObject == null)
        {
            UnityEngine.Object.Destroy(actorObject);
        }
        else
        {
            this.healthLabel = actorObject;
            actorObject.transform.parent = healthTextObject.transform;
            actorObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            actorObject.transform.localPosition = new Vector3(0.21f, -0.31f, 0f);
            actorObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            actorObject.GetComponent<UberText>().Text = GameStrings.Get("GLOBAL_HEALTH");
        }
    }

    public override bool IsMouseOverDelayOverriden()
    {
        return true;
    }

    private void ManaLabelLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        Card card = (Card) callbackData;
        GameObject costTextObject = card.GetActor().GetCostTextObject();
        if (costTextObject == null)
        {
            UnityEngine.Object.Destroy(actorObject);
        }
        else
        {
            this.costLabel = actorObject;
            actorObject.transform.parent = costTextObject.transform;
            actorObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            actorObject.transform.localPosition = new Vector3(-0.017f, 0.3512533f, 0f);
            actorObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            actorObject.GetComponent<UberText>().Text = GameStrings.Get("GLOBAL_COST");
        }
    }

    public override bool NotifyOfBattlefieldCardClicked(Entity clickedEntity, bool wasInTargetMode)
    {
        if (base.GetTag(GAME_TAG.TURN) == 4)
        {
            if (clickedEntity.GetCardId() == "CS2_168")
            {
                if (!wasInTargetMode)
                {
                    if (this.crushThisGnoll != null)
                    {
                        NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.crushThisGnoll);
                    }
                    NotificationManager.Get().DestroyAllPopUps();
                    Vector3 position = GameState.Get().GetRemotePlayer().GetBattlefieldZone().GetFirstCard().transform.position;
                    Vector3 vector2 = new Vector3(position.x - 3f, position.y, position.z);
                    this.crushThisGnoll = NotificationManager.Get().CreatePopupText(vector2, new Vector3(1.3f, 1.3f, 1.3f), GameStrings.Get("TUTORIAL01_HELP_03"));
                    this.crushThisGnoll.ShowPopUpArrow(Notification.PopUpArrowDirection.Right);
                    this.numTimesTextSwapStarted++;
                    Gameplay.Get().StartCoroutine(this.WaitAndThenSwapText(this.numTimesTextSwapStarted));
                }
            }
            else if ((clickedEntity.GetCardId() == "TU4a_002") && wasInTargetMode)
            {
                if (this.crushThisGnoll != null)
                {
                    NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.crushThisGnoll);
                }
                NotificationManager.Get().DestroyAllPopUps();
                this.firstAttackFinished = true;
            }
        }
        else if (((base.GetTag(GAME_TAG.TURN) == 6) && (clickedEntity.GetCardId() == "TU4a_001")) && wasInTargetMode)
        {
            NotificationManager.Get().DestroyAllPopUps();
        }
        if ((wasInTargetMode && (InputManager.Get().heldObject != null)) && (InputManager.Get().heldObject.GetComponent<Card>().GetEntity().GetCardId() == "CS2_029"))
        {
            if (clickedEntity.IsControlledByLocalPlayer())
            {
                this.ShowDontFireballYourselfPopup(clickedEntity.GetCard().transform.position);
                return false;
            }
            if ((clickedEntity.GetCardId() == "TU4a_003") && (base.GetTag(GAME_TAG.TURN) >= 8))
            {
                if (this.noFireballPopup != null)
                {
                    NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.noFireballPopup);
                }
                Vector3 vector3 = clickedEntity.GetCard().transform.position;
                Vector3 vector4 = new Vector3(vector3.x - 3f, vector3.y, vector3.z);
                this.noFireballPopup = NotificationManager.Get().CreatePopupText(vector4, GameStrings.Get("TUTORIAL01_HELP_08"));
                NotificationManager.Get().DestroyNotification(this.noFireballPopup, 3f);
                return false;
            }
        }
        return true;
    }

    public override void NotifyOfCardDropped(Entity entity)
    {
        if ((base.GetTag(GAME_TAG.TURN) == 2) || (entity.GetCardId() == "CS2_025"))
        {
            BoardTutorial.Get().EnableHighlight(false);
        }
    }

    public override void NotifyOfCardGrabbed(Entity entity)
    {
        if ((base.GetTag(GAME_TAG.TURN) == 2) || (entity.GetCardId() == "CS2_025"))
        {
            BoardTutorial.Get().EnableHighlight(true);
        }
        this.NukeNumberLabels();
    }

    public override void NotifyOfCardMousedOff(Entity mousedOffEntity)
    {
        if (this.ShouldShowArrowOnCardInHand(mousedOffEntity))
        {
            Gameplay.Get().StartCoroutine(this.ShowArrowInSeconds(0.5f));
        }
        this.NukeNumberLabels();
    }

    public override void NotifyOfCardMousedOver(Entity mousedOverEntity)
    {
        if (this.ShouldShowArrowOnCardInHand(mousedOverEntity))
        {
            NotificationManager.Get().DestroyAllArrows();
        }
        if (mousedOverEntity.GetZone() == TAG_ZONE.HAND)
        {
            this.mousedOverCard = mousedOverEntity.GetCard();
            AssetLoader.Get().LoadActor("NumberLabel", new AssetLoader.GameObjectCallback(this.ManaLabelLoadedCallback), this.mousedOverCard);
            AssetLoader.Get().LoadActor("NumberLabel", new AssetLoader.GameObjectCallback(this.AttackLabelLoadedCallback), this.mousedOverCard);
            AssetLoader.Get().LoadActor("NumberLabel", new AssetLoader.GameObjectCallback(this.HealthLabelLoadedCallback), this.mousedOverCard);
        }
    }

    public override void NotifyOfCardTooltipDisplayHide(Card card)
    {
        if (this.attackHelpPanel != null)
        {
            if (card != null)
            {
                card.GetActor().GetAttackObject().Shrink();
            }
            UnityEngine.Object.Destroy(this.attackHelpPanel.gameObject);
        }
        if (this.healthHelpPanel != null)
        {
            if (card != null)
            {
                card.GetActor().GetHealthObject().Shrink();
            }
            UnityEngine.Object.Destroy(this.healthHelpPanel.gameObject);
        }
    }

    public override bool NotifyOfCardTooltipDisplayShow(Card card)
    {
        Entity entity = card.GetEntity();
        if (entity.IsMinion())
        {
            if (this.attackHelpPanel == null)
            {
                this.ShowAttackTooltip(card);
                Gameplay.Get().StartCoroutine(this.ShowHealthTooltipAfterWait(card));
            }
            return false;
        }
        if (!entity.IsHero())
        {
            return true;
        }
        if (this.healthHelpPanel == null)
        {
            this.ShowHealthTooltip(card);
        }
        return false;
    }

    public override void NotifyOfCustomIntroFinished()
    {
        Card heroCard = GameState.Get().GetLocalPlayer().GetHeroCard();
        Card card2 = GameState.Get().GetRemotePlayer().GetHeroCard();
        heroCard.SetDoNotSort(false);
        card2.GetActor().TurnOnCollider();
        heroCard.GetActor().TurnOnCollider();
        heroCard.transform.parent = null;
        card2.transform.parent = null;
        SceneUtils.SetLayer(heroCard.GetActor().GetRootObject(), GameLayer.CardRaycast);
        Gameplay.Get().StartCoroutine(this.ContinueFinishingCustomIntro());
    }

    public override void NotifyOfDefeatCoinAnimation()
    {
        SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL_01_JAINA_13_10"));
    }

    public override bool NotifyOfEndTurnButtonPushed()
    {
        Network.Options optionsPacket = GameState.Get().GetOptionsPacket();
        if (((optionsPacket != null) && (optionsPacket.List != null)) && (optionsPacket.List.Count == 1))
        {
            NotificationManager.Get().DestroyAllArrows();
            return true;
        }
        if (this.endTurnNotifier != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.endTurnNotifier);
        }
        Vector3 position = EndTurnButton.Get().transform.position;
        Vector3 vector2 = new Vector3(position.x - 3f, position.y, position.z);
        string key = "TUTORIAL_NO_ENDTURN_ATK";
        if (!GameState.Get().GetLocalPlayer().HasReadyAttackers())
        {
            key = "TUTORIAL_NO_ENDTURN";
        }
        this.endTurnNotifier = NotificationManager.Get().CreatePopupText(vector2, GameStrings.Get(key));
        NotificationManager.Get().DestroyNotification(this.endTurnNotifier, 2.5f);
        return false;
    }

    public override void NotifyOfGameOver(TAG_PLAYSTATE gameResult)
    {
        base.NotifyOfGameOver(gameResult);
        if (this.attackHelpPanel != null)
        {
            UnityEngine.Object.Destroy(this.attackHelpPanel.gameObject);
            this.attackHelpPanel = null;
        }
        if (this.healthHelpPanel != null)
        {
            UnityEngine.Object.Destroy(this.healthHelpPanel.gameObject);
            this.healthHelpPanel = null;
        }
        if (gameResult == TAG_PLAYSTATE.WON)
        {
            Network.SetCampaignProgress(MissionMgr.MissionProgress.TUTORIAL01_COMPLETE);
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL_01_HOGGER_11_11"));
        }
        else if (gameResult == TAG_PLAYSTATE.TIED)
        {
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL_01_HOGGER_11_11"));
        }
    }

    public override void NotifyOfGamePackOpened()
    {
        this.packOpened = true;
        if (this.freeCardsPopup != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.freeCardsPopup);
        }
    }

    public override bool NotifyOfPlayError(PlayErrors.ErrorType error, Entity errorSource)
    {
        return ((error == PlayErrors.ErrorType.REQ_ATTACK_GREATER_THAN_0) && (errorSource.GetCardId() == "TU4a_006"));
    }

    public override void NotifyOfTargetModeCancelled()
    {
        if (this.crushThisGnoll != null)
        {
            NotificationManager.Get().DestroyAllPopUps();
            this.ShowAttackWithYourMinionPopup();
        }
    }

    private void NukeNumberLabels()
    {
        this.mousedOverCard = null;
        if (this.costLabel != null)
        {
            UnityEngine.Object.Destroy(this.costLabel);
        }
        if (this.attackLabel != null)
        {
            UnityEngine.Object.Destroy(this.attackLabel);
        }
        if (this.healthLabel != null)
        {
            UnityEngine.Object.Destroy(this.healthLabel);
        }
    }

    private void PackLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        SoundManager.Get().AddNewAmbienceTrack("tavern_crowd_rowdy_loop_1", 0.03f);
        Card heroCard = GameState.Get().GetLocalPlayer().GetHeroCard();
        Card card2 = GameState.Get().GetRemotePlayer().GetHeroCard();
        this.startingPack = actorObject;
        Transform transform = SceneUtils.FindChildBySubstring(this.startingPack, "Hero_Dummy").transform;
        heroCard.transform.parent = transform;
        heroCard.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        heroCard.transform.localPosition = new Vector3(0f, 0f, 0f);
        SceneUtils.SetLayer(heroCard.GetActor().GetRootObject(), GameLayer.IgnoreFullScreenEffects);
        Transform transform2 = SceneUtils.FindChildBySubstring(this.startingPack, "HeroEnemy_Dummy").transform;
        card2.transform.parent = transform2;
        card2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        card2.transform.localPosition = new Vector3(0f, 0f, 0f);
        heroCard.SetDoNotSort(true);
        Transform transform3 = Board.Get().FindBone("Tutorial1HeroStart");
        actorObject.transform.position = transform3.position;
        heroCard.GetActor().GetHealthObject().Hide();
        card2.GetActor().GetHealthObject().Hide();
        card2.GetActor().Hide();
        heroCard.GetActor().Hide();
        SceneMgr.Get().NotifySceneLoaded();
        Gameplay.Get().StartCoroutine(this.ShowPackOpeningArrow(transform3.position));
    }

    public override void PreloadAssets()
    {
        base.PreloadSound("VO_TUTORIAL_01_ANNOUNCER_01");
        base.PreloadSound("VO_TUTORIAL_01_ANNOUNCER_02");
        base.PreloadSound("VO_TUTORIAL_01_ANNOUNCER_03");
        base.PreloadSound("VO_TUTORIAL_01_ANNOUNCER_04");
        base.PreloadSound("VO_TUTORIAL_01_ANNOUNCER_05");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_13_10");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_01_01");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_02_02");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_03_03");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_20_16");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_05_05");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_06_06");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_07_07");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_21_17");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_09_08");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_15_11");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_16_12");
        base.PreloadSound("VO_TUTORIAL_JAINA_02_55_ALT2");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_10_09");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_17_13");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_18_14");
        base.PreloadSound("VO_TUTORIAL_01_JAINA_19_15");
        base.PreloadSound("VO_TUTORIAL_01_HOGGER_01_01");
        base.PreloadSound("VO_TUTORIAL_01_HOGGER_02_02");
        base.PreloadSound("VO_TUTORIAL_01_HOGGER_03_03");
        base.PreloadSound("VO_TUTORIAL_01_HOGGER_04_04");
        base.PreloadSound("VO_TUTORIAL_01_HOGGER_06_06_ALT");
        base.PreloadSound("VO_TUTORIAL_01_HOGGER_08_08_ALT");
        base.PreloadSound("VO_TUTORIAL_01_HOGGER_09_09_ALT");
        base.PreloadSound("VO_TUTORIAL_01_HOGGER_11_11");
    }

    public override bool ShouldDoAlternateMulliganIntro()
    {
        AssetLoader.Get().LoadActor("GameOpen_Pack", new AssetLoader.GameObjectCallback(this.PackLoadedCallback));
        return true;
    }

    private bool ShouldShowArrowOnCardInHand(Entity entity)
    {
        if (entity.GetZone() != TAG_ZONE.HAND)
        {
            return false;
        }
        int tag = base.GetTag(GAME_TAG.TURN);
        return ((tag == 2) || ((tag == 4) && (GameState.Get().GetLocalPlayer().GetBattlefieldZone().GetCards().Count == 0)));
    }

    public override bool ShouldShowBigCard()
    {
        return (base.GetTag(GAME_TAG.TURN) > 8);
    }

    public override bool ShouldShowHeroTooltips()
    {
        return true;
    }

    [DebuggerHidden]
    private IEnumerator ShowArrowInSeconds(float seconds)
    {
        return new <ShowArrowInSeconds>c__Iterator79 { seconds = seconds, <$>seconds = seconds, <>f__this = this };
    }

    private void ShowAttackTooltip(Card card)
    {
        Vector3 position = card.transform.position;
        Vector3 vector2 = new Vector3(position.x - 1.85f, position.y, position.z - 0.62f);
        this.attackHelpPanel = KeywordHelpPanelManager.Get().CreateKeywordPanel(0);
        this.attackHelpPanel.Reset();
        this.attackHelpPanel.Initialize(GameStrings.Get("GLOBAL_ATTACK"), GameStrings.Get("TUTORIAL01_HELP_12"));
        this.attackHelpPanel.transform.position = vector2;
        RenderUtils.SetAlpha(this.attackHelpPanel.gameObject, 0f);
        object[] args = new object[] { "alpha", 1, "time", 0.25f };
        iTween.FadeTo(this.attackHelpPanel.gameObject, iTween.Hash(args));
        card.GetActor().GetAttackObject().Enlarge(1.75f);
    }

    private void ShowAttackWithYourMinionPopup()
    {
        if (this.attackWithYourMinion != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.attackWithYourMinion);
        }
        if (!this.firstAttackFinished)
        {
            this.firstMurlocCard.GetActor().ToggleForceIdle(false);
            this.firstMurlocCard.GetActor().SetActorState(ActorStateType.CARD_PLAYABLE);
            Vector3 position = this.firstMurlocCard.transform.position;
            if (!this.firstMurlocCard.GetEntity().IsExhausted() && (this.firstMurlocCard.GetZone() is ZonePlay))
            {
                Vector3 vector2;
                if (this.firstMurlocCard.GetEntity().GetZonePosition() < this.firstRaptorCard.GetEntity().GetZonePosition())
                {
                    vector2 = new Vector3(position.x - 3f, position.y, position.z);
                    this.attackWithYourMinion = NotificationManager.Get().CreatePopupText(vector2, this.textToShowForAttackTip);
                    this.attackWithYourMinion.ShowPopUpArrow(Notification.PopUpArrowDirection.Right);
                }
                else
                {
                    vector2 = new Vector3(position.x + 3f, position.y, position.z);
                    this.attackWithYourMinion = NotificationManager.Get().CreatePopupText(vector2, this.textToShowForAttackTip);
                    this.attackWithYourMinion.ShowPopUpArrow(Notification.PopUpArrowDirection.Left);
                }
                Gameplay.Get().StartCoroutine(this.SwapHelpTextAndFlashMinion());
            }
        }
    }

    private void ShowDontFireballYourselfPopup(Vector3 origin)
    {
        if (this.noFireballPopup != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.noFireballPopup);
        }
        Vector3 position = new Vector3(origin.x - 3f, origin.y, origin.z);
        this.noFireballPopup = NotificationManager.Get().CreatePopupText(position, GameStrings.Get("TUTORIAL01_HELP_07"));
        NotificationManager.Get().DestroyNotification(this.noFireballPopup, 2.5f);
    }

    private void ShowEndTurnBouncingArrow()
    {
        if (!EndTurnButton.Get().IsInWaitingState())
        {
            Vector3 position = EndTurnButton.Get().transform.position;
            Vector3 vector2 = new Vector3(position.x - 2f, position.y, position.z);
            NotificationManager.Get().CreateBouncingArrow(vector2, new Vector3(0f, -90f, 0f));
        }
    }

    private void ShowHandBouncingArrow()
    {
        if (this.handBounceArrow == null)
        {
            List<Card> cards = GameState.Get().GetLocalPlayer().GetHandZone().GetCards();
            if (cards.Count != 0)
            {
                Card card = cards[0];
                Vector3 position = card.transform.position;
                Vector3 vector2 = new Vector3(position.x, position.y, position.z + 2f);
                this.handBounceArrow = NotificationManager.Get().CreateBouncingArrow(vector2, new Vector3(0f, 0f, 0f));
                this.handBounceArrow.transform.parent = card.transform;
            }
        }
    }

    private void ShowHealthTooltip(Card card)
    {
        Vector3 position = card.transform.position;
        Vector3 vector2 = new Vector3(position.x + 1.75f, position.y, position.z - 0.62f);
        if (card.GetEntity().IsHero())
        {
            vector2 = new Vector3(position.x + 2.2f, position.y + 0.3f, position.z - 0.8f);
        }
        this.healthHelpPanel = KeywordHelpPanelManager.Get().CreateKeywordPanel(0);
        this.healthHelpPanel.Reset();
        this.healthHelpPanel.Initialize(GameStrings.Get("GLOBAL_HEALTH"), GameStrings.Get("TUTORIAL01_HELP_13"));
        this.healthHelpPanel.transform.position = vector2;
        RenderUtils.SetAlpha(this.healthHelpPanel.gameObject, 0f);
        object[] args = new object[] { "alpha", 1, "time", 0.25f };
        iTween.FadeTo(this.healthHelpPanel.gameObject, iTween.Hash(args));
        card.GetActor().GetHealthObject().Enlarge(1.75f);
    }

    [DebuggerHidden]
    private IEnumerator ShowHealthTooltipAfterWait(Card card)
    {
        return new <ShowHealthTooltipAfterWait>c__Iterator78 { card = card, <$>card = card, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator ShowPackOpeningArrow(Vector3 packSpot)
    {
        return new <ShowPackOpeningArrow>c__Iterator80 { packSpot = packSpot, <$>packSpot = packSpot, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator SwapHelpTextAndFlashMinion()
    {
        return new <SwapHelpTextAndFlashMinion>c__Iterator7C { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitAndThenSwapText(int numTimesStarted)
    {
        return new <WaitAndThenSwapText>c__Iterator77 { numTimesStarted = numTimesStarted, <$>numTimesStarted = numTimesStarted, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitForBoardLoadedAndStartMission()
    {
        return new <WaitForBoardLoadedAndStartMission>c__Iterator7F();
    }

    [CompilerGenerated]
    private sealed class <BeginFlashingMinionLoop>c__Iterator7E : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <$>minionToFlash;
        internal Tutorial_01 <>f__this;
        internal Card minionToFlash;

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
                    if (this.minionToFlash != null)
                    {
                        if ((!this.minionToFlash.GetEntity().IsExhausted() && (this.minionToFlash.GetActor().GetActorStateType() != ActorStateType.CARD_IDLE)) && (this.minionToFlash.GetActor().GetActorStateType() != ActorStateType.CARD_MOUSE_OVER))
                        {
                            this.minionToFlash.GetActorSpell(SpellType.WIGGLE).Activate();
                            this.$current = new WaitForSeconds(1.5f);
                            this.$PC = 1;
                            return true;
                        }
                        break;
                    }
                    break;

                case 1:
                    Gameplay.Get().StartCoroutine(this.<>f__this.BeginFlashingMinionLoop(this.minionToFlash));
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
    private sealed class <ContinueFinishingCustomIntro>c__Iterator81 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Tutorial_01 <>f__this;

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
                    UnityEngine.Object.Destroy(this.<>f__this.startingPack);
                    MissionMgr.Get().SetBusy(false);
                    MulliganManager.Get().SkipMulligan();
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
    private sealed class <FlashMinionUntilAttackBegins>c__Iterator7D : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <$>minionToFlash;
        internal Tutorial_01 <>f__this;
        internal Card minionToFlash;

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
                    this.$current = new WaitForSeconds(8f);
                    this.$PC = 1;
                    return true;

                case 1:
                    Gameplay.Get().StartCoroutine(this.<>f__this.BeginFlashingMinionLoop(this.minionToFlash));
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
    private sealed class <HandleMissionEventWithTiming>c__Iterator7B : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>missionEvent;
        internal Tutorial_01 <>f__this;
        internal Collider <dragPlane>__12;
        internal List<Card> <enemyCards>__10;
        internal Vector3 <healthPopUpPosition>__3;
        internal Vector3 <help04Position>__6;
        internal Actor <hoggerActor>__1;
        internal Vector3 <hoggerHealthPopupPosition>__9;
        internal Vector3 <hoggerPosition>__8;
        internal Actor <jainaActor>__0;
        internal Vector3 <jainaPos>__2;
        internal Card <lastCard>__11;
        internal Notification <notification>__4;
        internal Notification <raptorHelp>__7;
        internal Vector3 <raptorPosition>__5;
        internal int missionEvent;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            int missionEvent;
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<jainaActor>__0 = GameState.Get().GetLocalPlayer().GetHero().GetCard().GetActor();
                    this.<hoggerActor>__1 = GameState.Get().GetRemotePlayer().GetHero().GetCard().GetActor();
                    missionEvent = this.missionEvent;
                    switch (missionEvent)
                    {
                        case 1:
                            SceneMgr.Get().StartCoroutine(this.<>f__this.WaitForBoardLoadedAndStartMission());
                            goto Label_0B53;

                        case 2:
                            MissionMgr.Get().SetBusy(true);
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_01_01", "TUTORIAL01_JAINA_01", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                            MissionMgr.Get().SetBusyInSeconds(false, 2.2f);
                            goto Label_0B53;

                        case 3:
                            this.$current = new WaitForSeconds(2f);
                            this.$PC = 1;
                            goto Label_0B5C;

                        case 4:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_20_16", "TUTORIAL01_JAINA_03", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                            this.$PC = 2;
                            goto Label_0B5C;

                        case 5:
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_05_05", "TUTORIAL01_JAINA_05", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                            goto Label_0B53;

                        case 6:
                        case 9:
                        case 10:
                        case 0x15:
                            goto Label_0B53;

                        case 7:
                            NotificationManager.Get().DestroyAllPopUps();
                            this.$current = new WaitForSeconds(1.7f);
                            this.$PC = 4;
                            goto Label_0B5C;

                        case 8:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_HOGGER_03_03", "TUTORIAL01_HOGGER_05", Notification.SpeechBubbleDirection.TopRight, this.<hoggerActor>__1));
                            this.$PC = 7;
                            goto Label_0B5C;

                        case 12:
                            this.$current = new WaitForSeconds(1f);
                            this.$PC = 9;
                            goto Label_0B5C;

                        case 13:
                            goto Label_0677;

                        case 14:
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_HOGGER_08_08_ALT", "TUTORIAL01_HOGGER_08", Notification.SpeechBubbleDirection.TopRight, this.<hoggerActor>__1));
                            this.<hoggerPosition>__8 = this.<hoggerActor>__1.transform.position;
                            this.<hoggerHealthPopupPosition>__9 = new Vector3(this.<hoggerPosition>__8.x + 3.25f, this.<hoggerPosition>__8.y + 0.5f, this.<hoggerPosition>__8.z - 0.92f);
                            this.<notification>__4 = NotificationManager.Get().CreatePopupText(this.<hoggerHealthPopupPosition>__9, new Vector3(1.3f, 1.3f, 1.3f), GameStrings.Get("TUTORIAL01_HELP_09"));
                            this.<notification>__4.ShowPopUpArrow(Notification.PopUpArrowDirection.Left);
                            NotificationManager.Get().DestroyNotification(this.<notification>__4, 5f);
                            if ((this.<>f__this.GetTag(GAME_TAG.TURN) != 6) || !EndTurnButton.Get().IsInNMPState())
                            {
                                goto Label_0B53;
                            }
                            this.$current = new WaitForSeconds(9f);
                            this.$PC = 11;
                            goto Label_0B5C;

                        case 15:
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_JAINA_02_55_ALT2", string.Empty, Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                            goto Label_0B53;

                        case 20:
                            MissionMgr.Get().SetBusy(true);
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_10_09", "TUTORIAL01_JAINA_10", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                            this.$current = new WaitForSeconds(1.5f);
                            this.$PC = 12;
                            goto Label_0B5C;

                        case 0x16:
                            MissionMgr.Get().SetBusy(true);
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_HOGGER_09_09_ALT", "TUTORIAL01_HOGGER_02", Notification.SpeechBubbleDirection.TopRight, this.<hoggerActor>__1));
                            MissionMgr.Get().SetBusyInSeconds(false, 2f);
                            goto Label_0B53;
                    }
                    break;

                case 1:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_03_03", "TUTORIAL01_JAINA_03", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                    if ((this.<>f__this.GetTag(GAME_TAG.TURN) == 2) && !EndTurnButton.Get().IsInWaitingState())
                    {
                        this.<>f__this.ShowEndTurnBouncingArrow();
                    }
                    goto Label_0B53;

                case 2:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_HOGGER_06_06_ALT", "TUTORIAL01_HOGGER_07", Notification.SpeechBubbleDirection.TopRight, this.<hoggerActor>__1));
                    this.$PC = 3;
                    goto Label_0B5C;

                case 3:
                    this.<jainaPos>__2 = this.<jainaActor>__0.transform.position;
                    this.<healthPopUpPosition>__3 = new Vector3(this.<jainaPos>__2.x + 3.3f, this.<jainaPos>__2.y + 0.5f, this.<jainaPos>__2.z - 0.75f);
                    this.<notification>__4 = NotificationManager.Get().CreatePopupText(this.<healthPopUpPosition>__3, new Vector3(1.3f, 1.3f, 1.3f), GameStrings.Get("TUTORIAL01_HELP_01"));
                    this.<notification>__4.ShowPopUpArrow(Notification.PopUpArrowDirection.Left);
                    NotificationManager.Get().DestroyNotification(this.<notification>__4, 5f);
                    MissionMgr.Get().SetBusyInSeconds(false, 5.2f);
                    goto Label_0B53;

                case 4:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_07_07", "TUTORIAL01_JAINA_07", Notification.SpeechBubbleDirection.BottomRight, this.<jainaActor>__0));
                    this.<raptorPosition>__5 = this.<>f__this.firstRaptorCard.transform.position;
                    if (this.<>f__this.firstRaptorCard.GetEntity().GetZonePosition() <= this.<>f__this.firstMurlocCard.GetEntity().GetZonePosition())
                    {
                        this.<help04Position>__6 = new Vector3(this.<raptorPosition>__5.x - 3f, this.<raptorPosition>__5.y, this.<raptorPosition>__5.z);
                        this.<raptorHelp>__7 = NotificationManager.Get().CreatePopupText(this.<help04Position>__6, GameStrings.Get("TUTORIAL01_HELP_04"));
                        this.<raptorHelp>__7.ShowPopUpArrow(Notification.PopUpArrowDirection.Right);
                    }
                    else
                    {
                        this.<help04Position>__6 = new Vector3(this.<raptorPosition>__5.x + 3f, this.<raptorPosition>__5.y, this.<raptorPosition>__5.z);
                        this.<raptorHelp>__7 = NotificationManager.Get().CreatePopupText(this.<help04Position>__6, GameStrings.Get("TUTORIAL01_HELP_04"));
                        this.<raptorHelp>__7.ShowPopUpArrow(Notification.PopUpArrowDirection.Left);
                    }
                    goto Label_04C8;

                case 5:
                    if ((GameState.Get().GetLocalPlayer().GetBattlefieldZone().GetCards().Count > 1) && !GameState.Get().IsInTargetMode())
                    {
                        this.<>f__this.ShowAttackWithYourMinionPopup();
                    }
                    if ((this.<>f__this.GetTag(GAME_TAG.TURN) != 4) || !EndTurnButton.Get().IsInNMPState())
                    {
                        goto Label_0B53;
                    }
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 6;
                    goto Label_0B5C;

                case 6:
                    this.<>f__this.ShowEndTurnBouncingArrow();
                    goto Label_0B53;

                case 7:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_21_17", "TUTORIAL01_JAINA_21", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                    this.$PC = 8;
                    goto Label_0B5C;

                case 8:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_0B53;

                case 9:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_15_11", "TUTORIAL01_JAINA_15", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                    goto Label_0B53;

                case 10:
                    goto Label_0677;

                case 11:
                    this.<>f__this.ShowEndTurnBouncingArrow();
                    goto Label_0B53;

                case 12:
                    MissionMgr.Get().SetBusy(false);
                    this.<enemyCards>__10 = GameState.Get().GetRemotePlayer().GetBattlefieldZone().GetCards();
                    this.<lastCard>__11 = this.<enemyCards>__10[this.<enemyCards>__10.Count - 1];
                    this.<lastCard>__11.GetActor().GetAttackObject().Jiggle();
                    goto Label_0B53;

                case 13:
                    goto Label_093C;

                case 14:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_HOGGER_01_01", "TUTORIAL01_HOGGER_01", Notification.SpeechBubbleDirection.TopRight, this.<hoggerActor>__1));
                    this.$PC = 15;
                    goto Label_0B5C;

                case 15:
                    MissionMgr.Get().SetBusy(false);
                    this.$current = new WaitForSeconds(4f);
                    this.$PC = 0x10;
                    goto Label_0B5C;

                case 0x10:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_HOGGER_04_04", "TUTORIAL01_HOGGER_06", Notification.SpeechBubbleDirection.TopRight, this.<hoggerActor>__1));
                    goto Label_0B53;

                case 0x11:
                    this.$current = new WaitForSeconds(0.5f);
                    this.$PC = 0x12;
                    goto Label_0B5C;

                case 0x12:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_ANNOUNCER_02", string.Empty, Notification.SpeechBubbleDirection.None, null));
                    this.$PC = 0x13;
                    goto Label_0B5C;

                case 0x13:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_HOGGER_02_02", "TUTORIAL01_HOGGER_04", Notification.SpeechBubbleDirection.TopRight, this.<hoggerActor>__1));
                    this.$PC = 20;
                    goto Label_0B5C;

                case 20:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_ANNOUNCER_03", string.Empty, Notification.SpeechBubbleDirection.None, null));
                    this.$PC = 0x15;
                    goto Label_0B5C;

                case 0x15:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_ANNOUNCER_04", string.Empty, Notification.SpeechBubbleDirection.None, null));
                    this.$PC = 0x16;
                    goto Label_0B5C;

                case 0x16:
                    this.<>f__this.announcerIsFinishedYapping = true;
                    goto Label_0B53;

                default:
                    goto Label_0B5A;
            }
            switch (missionEvent)
            {
                case 0x37:
                    this.<>f__this.tooltipsDisabled = false;
                    this.<dragPlane>__12 = Board.Get().FindCollider("DragPlane");
                    this.<dragPlane>__12.enabled = true;
                    goto Label_093C;

                case 0x42:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_ANNOUNCER_01", string.Empty, Notification.SpeechBubbleDirection.None, null));
                    this.$PC = 0x11;
                    goto Label_0B5C;

                default:
                    UnityEngine.Debug.LogWarning("WARNING - Mission fired an event that we are not listening for.");
                    goto Label_0B53;
            }
        Label_04C8:
            NotificationManager.Get().DestroyNotification(this.<raptorHelp>__7, 4f);
            this.$current = new WaitForSeconds(4f);
            this.$PC = 5;
            goto Label_0B5C;
        Label_0677:
            while (this.<>f__this.m_jainaSpeaking)
            {
                this.$current = null;
                this.$PC = 10;
                goto Label_0B5C;
            }
            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_16_12", "TUTORIAL01_JAINA_16", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
            goto Label_0B53;
        Label_093C:
            while (!this.<>f__this.announcerIsFinishedYapping)
            {
                this.$current = null;
                this.$PC = 13;
                goto Label_0B5C;
            }
            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_ANNOUNCER_05", string.Empty, Notification.SpeechBubbleDirection.None, null));
            this.$PC = 14;
            goto Label_0B5C;
        Label_0B53:
            this.$PC = -1;
        Label_0B5A:
            return false;
        Label_0B5C:
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
    private sealed class <HandleStartOfTurnWithTiming>c__Iterator7A : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>turn;
        internal Tutorial_01 <>f__this;
        internal List<Card> <cardsInDeck>__2;
        internal List<Card> <cardsInHand>__4;
        internal Collider <dragPlane>__3;
        internal Actor <hoggerActor>__1;
        internal Actor <jainaActor>__0;
        internal int turn;

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
                    this.<jainaActor>__0 = GameState.Get().GetLocalPlayer().GetHero().GetCard().GetActor();
                    this.<hoggerActor>__1 = GameState.Get().GetRemotePlayer().GetHero().GetCard().GetActor();
                    switch (this.turn)
                    {
                        case 1:
                            this.<cardsInDeck>__2 = GameState.Get().GetLocalPlayer().GetDeckZone().GetCards();
                            this.<>f__this.firstMurlocCard = this.<cardsInDeck>__2[this.<cardsInDeck>__2.Count - 1];
                            this.<>f__this.firstRaptorCard = this.<cardsInDeck>__2[this.<cardsInDeck>__2.Count - 2];
                            MissionMgr.Get().SetBusy(true);
                            this.<dragPlane>__3 = Board.Get().FindCollider("DragPlane");
                            this.<dragPlane>__3.enabled = false;
                            this.$current = new WaitForSeconds(1.25f);
                            this.$PC = 1;
                            goto Label_03B3;

                        case 2:
                            this.$current = new WaitForSeconds(1f);
                            this.$PC = 2;
                            goto Label_03B3;

                        case 4:
                            this.<hoggerActor>__1.TurnOffCollider();
                            this.<hoggerActor>__1.SetActorState(ActorStateType.CARD_IDLE);
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_06_06", "TUTORIAL01_JAINA_06", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                            this.<>f__this.firstMurlocCard.GetActor().ToggleForceIdle(true);
                            this.<>f__this.firstMurlocCard.GetActor().SetActorState(ActorStateType.CARD_IDLE);
                            break;

                        case 5:
                            this.<hoggerActor>__1.TurnOnCollider();
                            break;

                        case 6:
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_17_13", "TUTORIAL01_JAINA_17", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                            break;

                        case 8:
                            this.<>f__this.m_jainaSpeaking = true;
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_18_14", "TUTORIAL01_JAINA_18", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                            this.$PC = 3;
                            goto Label_03B3;

                        case 10:
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_19_15", "TUTORIAL01_JAINA_19", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                            break;
                    }
                    break;

                case 1:
                    AssetLoader.Get().LoadActor("TutorialIntroDialog", new AssetLoader.GameObjectCallback(this.<>f__this.DialogLoadedCallback));
                    break;

                case 2:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_01_JAINA_02_02", "TUTORIAL01_JAINA_02", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__0));
                    this.<cardsInHand>__4 = GameState.Get().GetLocalPlayer().GetHandZone().GetCards();
                    if (((this.<>f__this.GetTag(GAME_TAG.TURN) == 2) && (this.<cardsInHand>__4.Count == 1)) && ((InputManager.Get().heldObject == null) && !this.<cardsInHand>__4[0].IsMousedOver()))
                    {
                        Gameplay.Get().StartCoroutine(this.<>f__this.ShowArrowInSeconds(0f));
                    }
                    break;

                case 3:
                    this.<>f__this.m_jainaSpeaking = false;
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 4;
                    goto Label_03B3;

                case 4:
                    Gameplay.Get().StartCoroutine(this.<>f__this.FlashMinionUntilAttackBegins(this.<>f__this.firstRaptorCard));
                    break;

                default:
                    goto Label_03B1;
            }
            this.$PC = -1;
        Label_03B1:
            return false;
        Label_03B3:
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
    private sealed class <ShowArrowInSeconds>c__Iterator79 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal float <$>seconds;
        internal Tutorial_01 <>f__this;
        internal Card <cardInHand>__1;
        internal List<Card> <handCards>__0;
        internal float seconds;

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
                    this.$current = new WaitForSeconds(this.seconds);
                    this.$PC = 1;
                    goto Label_00FE;

                case 1:
                    this.<handCards>__0 = GameState.Get().GetLocalPlayer().GetHandZone().GetCards();
                    if (this.<handCards>__0.Count != 0)
                    {
                        this.<cardInHand>__1 = this.<handCards>__0[0];
                        break;
                    }
                    goto Label_00FC;

                case 2:
                    break;

                default:
                    goto Label_00FC;
            }
            while (iTween.Count(this.<cardInHand>__1.gameObject) > 0)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_00FE;
            }
            if (!this.<cardInHand>__1.IsMousedOver() && (InputManager.Get().heldObject != this.<cardInHand>__1.gameObject))
            {
                this.<>f__this.ShowHandBouncingArrow();
                this.$PC = -1;
            }
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

    [CompilerGenerated]
    private sealed class <ShowHealthTooltipAfterWait>c__Iterator78 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <$>card;
        internal Tutorial_01 <>f__this;
        internal Card card;

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
                    this.$current = new WaitForSeconds(0.05f);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (InputManager.Get().GetMousedOverCard() == this.card)
                    {
                        this.<>f__this.ShowHealthTooltip(this.card);
                        this.$PC = -1;
                        break;
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

    [CompilerGenerated]
    private sealed class <ShowPackOpeningArrow>c__Iterator80 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Vector3 <$>packSpot;
        internal Tutorial_01 <>f__this;
        internal Vector3 <popUpPosition>__0;
        internal Vector3 packSpot;

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
                    this.$current = new WaitForSeconds(4f);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (!this.<>f__this.packOpened)
                    {
                        this.<popUpPosition>__0 = new Vector3(this.packSpot.x + 4.014574f, this.packSpot.y, this.packSpot.z + 0.2307634f);
                        this.<>f__this.freeCardsPopup = NotificationManager.Get().CreatePopupText(this.<popUpPosition>__0, GameStrings.Get("TUTORIAL01_HELP_18"));
                        this.<>f__this.freeCardsPopup.ShowPopUpArrow(Notification.PopUpArrowDirection.Left);
                        this.$PC = -1;
                        break;
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

    [CompilerGenerated]
    private sealed class <SwapHelpTextAndFlashMinion>c__Iterator7C : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Tutorial_01 <>f__this;
        internal Vector3 <cardInBattlefieldPosition>__0;
        internal Vector3 <help02Position>__1;

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
                    Gameplay.Get().StartCoroutine(this.<>f__this.BeginFlashingMinionLoop(this.<>f__this.firstMurlocCard));
                    this.$current = new WaitForSeconds(4f);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (!(this.<>f__this.textToShowForAttackTip == GameStrings.Get("TUTORIAL01_HELP_10")))
                    {
                        if (((!this.<>f__this.firstMurlocCard.GetEntity().IsExhausted() && (this.<>f__this.firstMurlocCard.GetActor().GetActorStateType() != ActorStateType.CARD_IDLE)) && ((this.<>f__this.firstMurlocCard.GetActor().GetActorStateType() != ActorStateType.CARD_MOUSE_OVER) && (this.<>f__this.firstMurlocCard.GetZone() is ZonePlay))) && !this.<>f__this.firstAttackFinished)
                        {
                            this.<cardInBattlefieldPosition>__0 = this.<>f__this.firstMurlocCard.transform.position;
                            this.<>f__this.textToShowForAttackTip = GameStrings.Get("TUTORIAL01_HELP_10");
                            if (this.<>f__this.attackWithYourMinion != null)
                            {
                                NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.<>f__this.attackWithYourMinion);
                            }
                            if (this.<>f__this.firstMurlocCard.GetEntity().GetZonePosition() < this.<>f__this.firstRaptorCard.GetEntity().GetZonePosition())
                            {
                                this.<help02Position>__1 = new Vector3(this.<cardInBattlefieldPosition>__0.x - 3f, this.<cardInBattlefieldPosition>__0.y, this.<cardInBattlefieldPosition>__0.z);
                                this.<>f__this.attackWithYourMinion = NotificationManager.Get().CreatePopupText(this.<help02Position>__1, this.<>f__this.textToShowForAttackTip);
                                this.<>f__this.attackWithYourMinion.ShowPopUpArrow(Notification.PopUpArrowDirection.Right);
                            }
                            else
                            {
                                this.<help02Position>__1 = new Vector3(this.<cardInBattlefieldPosition>__0.x + 3f, this.<cardInBattlefieldPosition>__0.y, this.<cardInBattlefieldPosition>__0.z);
                                this.<>f__this.attackWithYourMinion = NotificationManager.Get().CreatePopupText(this.<help02Position>__1, this.<>f__this.textToShowForAttackTip);
                                this.<>f__this.attackWithYourMinion.ShowPopUpArrow(Notification.PopUpArrowDirection.Left);
                            }
                            this.$PC = -1;
                        }
                        break;
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

    [CompilerGenerated]
    private sealed class <WaitAndThenSwapText>c__Iterator77 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>numTimesStarted;
        internal Tutorial_01 <>f__this;
        internal Vector3 <cardInBattlefieldPosition>__1;
        internal Card <firstCard>__0;
        internal Vector3 <help03Position>__2;
        internal int numTimesStarted;

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
                    this.$current = new WaitForSeconds(6f);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (this.<>f__this.crushThisGnoll != null)
                    {
                        if (this.numTimesStarted == this.<>f__this.numTimesTextSwapStarted)
                        {
                            this.<firstCard>__0 = GameState.Get().GetRemotePlayer().GetBattlefieldZone().GetFirstCard();
                            if (this.<firstCard>__0 != null)
                            {
                                this.<cardInBattlefieldPosition>__1 = this.<firstCard>__0.transform.position;
                                this.<help03Position>__2 = new Vector3(this.<cardInBattlefieldPosition>__1.x - 3f, this.<cardInBattlefieldPosition>__1.y, this.<cardInBattlefieldPosition>__1.z);
                                NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.<>f__this.crushThisGnoll);
                                this.<>f__this.crushThisGnoll = NotificationManager.Get().CreatePopupText(this.<help03Position>__2, new Vector3(1.3f, 1.3f, 1.3f), GameStrings.Get("TUTORIAL01_HELP_17"));
                                this.<>f__this.crushThisGnoll.ShowPopUpArrow(Notification.PopUpArrowDirection.Right);
                                this.$PC = -1;
                            }
                        }
                        break;
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

    [CompilerGenerated]
    private sealed class <WaitForBoardLoadedAndStartMission>c__Iterator7F : IDisposable, IEnumerator, IEnumerator<object>
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
                case 1:
                    if (ZoneMgr.Get() == null)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    MissionMgr.Get().SetBusy(true);
                    HistoryManager.Get().DisableHistory();
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


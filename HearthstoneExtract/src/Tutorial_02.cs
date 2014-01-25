using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tutorial_02 : TutorialEntity
{
    private GameObject costLabel;
    private Notification endTurnNotifier;
    private Notification handBounceArrow;
    private Notification manaNotifier;
    private Notification manaNotifier2;
    private int numManaThisTurn = 1;

    private void DialogLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        base.startingPopup = actorObject.GetComponent<Notification>();
        NotificationManager.Get().CreatePopupDialogFromObject(base.startingPopup, GameStrings.Get("TUTORIAL02_HELP_06"), GameStrings.Get("TUTORIAL02_HELP_07"), GameStrings.Get("TUTORIAL01_HELP_16"));
        base.startingPopup.ButtonStart.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.UserPressedStartButton));
        base.startingPopup.artOverlay.material.mainTextureOffset = new Vector2(0.5f, 0f);
    }

    private void FadeInManaSpotlight()
    {
        Gameplay.Get().StartCoroutine(this.StartManaSpotFade());
    }

    public override List<RewardData> GetCustomRewards()
    {
        List<RewardData> list = new List<RewardData>();
        CardRewardData item = new CardRewardData("EX1_015", CardFlair.PremiumType.STANDARD, 2);
        list.Add(item);
        return list;
    }

    public override string GetTurnStartReminderText()
    {
        return string.Format(GameStrings.Get("TUTORIAL02_HELP_04"), this.numManaThisTurn);
    }

    [DebuggerHidden]
    private IEnumerator HandleCoinFlip()
    {
        return new <HandleCoinFlip>c__Iterator84 { <>f__this = this };
    }

    [DebuggerHidden]
    protected override IEnumerator HandleMissionEventWithTiming(int missionEvent)
    {
        return new <HandleMissionEventWithTiming>c__Iterator83 { missionEvent = missionEvent, <$>missionEvent = missionEvent, <>f__this = this };
    }

    [DebuggerHidden]
    protected override IEnumerator HandleStartOfTurnWithTiming(int turn)
    {
        return new <HandleStartOfTurnWithTiming>c__Iterator82 { turn = turn, <$>turn = turn, <>f__this = this };
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
            if (this.costLabel != null)
            {
                UnityEngine.Object.Destroy(this.costLabel);
            }
            this.costLabel = actorObject;
            actorObject.transform.parent = costTextObject.transform;
            actorObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            actorObject.transform.localPosition = new Vector3(-0.025f, 0.28f, 0f);
            actorObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            actorObject.GetComponent<UberText>().Text = GameStrings.Get("GLOBAL_COST");
        }
    }

    public override void NotifyOfCardDropped(Entity entity)
    {
        if (entity.GetCardId() == "CS2_023")
        {
            BoardTutorial.Get().EnableFullHighlight(false);
        }
    }

    public override void NotifyOfCardGrabbed(Entity entity)
    {
        if ((entity.GetCardId() == "CS2_023") && (GameState.Get().GetLocalPlayer().GetNumAvailableResources() >= entity.GetCost()))
        {
            BoardTutorial.Get().EnableFullHighlight(true);
        }
        if (this.costLabel != null)
        {
            UnityEngine.Object.Destroy(this.costLabel);
        }
    }

    public override void NotifyOfCardMousedOff(Entity mousedOffEntity)
    {
        if (this.costLabel != null)
        {
            UnityEngine.Object.Destroy(this.costLabel);
        }
    }

    public override void NotifyOfCardMousedOver(Entity mousedOverEntity)
    {
        if ((mousedOverEntity.GetZone() == TAG_ZONE.HAND) && (base.GetTag(GAME_TAG.TURN) <= 7))
        {
            AssetLoader.Get().LoadActor("NumberLabel", new AssetLoader.GameObjectCallback(this.ManaLabelLoadedCallback), mousedOverEntity.GetCard());
        }
    }

    public override void NotifyOfCoinFlipResult()
    {
        Gameplay.Get().StartCoroutine(this.HandleCoinFlip());
    }

    public override void NotifyOfDefeatCoinAnimation()
    {
        SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL02_MILLHOUSE_19_21"));
    }

    public override bool NotifyOfEndTurnButtonPushed()
    {
        Network.Options optionsPacket = GameState.Get().GetOptionsPacket();
        if ((optionsPacket != null) && (optionsPacket.List != null))
        {
            if (optionsPacket.List.Count == 1)
            {
                NotificationManager.Get().DestroyAllArrows();
                return true;
            }
            if (optionsPacket.List.Count == 2)
            {
                for (int i = 0; i < optionsPacket.List.Count; i++)
                {
                    Network.Options.Option option = optionsPacket.List[i];
                    if ((option.Type == Network.Options.Option.OptionType.POWER) && (GameState.Get().GetEntity(option.Main.ID).GetCardId() == "CS2_025"))
                    {
                        return true;
                    }
                }
            }
        }
        if (this.endTurnNotifier != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.endTurnNotifier);
        }
        Vector3 position = EndTurnButton.Get().transform.position;
        Vector3 vector2 = new Vector3(position.x - 3f, position.y, position.z);
        string key = "TUTORIAL_NO_ENDTURN";
        if (GameState.Get().GetLocalPlayer().HasReadyAttackers())
        {
            key = "TUTORIAL_NO_ENDTURN_ATK";
        }
        this.endTurnNotifier = NotificationManager.Get().CreatePopupText(vector2, GameStrings.Get(key));
        NotificationManager.Get().DestroyNotification(this.endTurnNotifier, 2.5f);
        return false;
    }

    public override void NotifyOfEnemyManaCrystalSpawned()
    {
        AssetLoader.Get().LoadActor("plus1", new AssetLoader.GameObjectCallback(this.Plus1ActorLoadedCallbackEnemy));
    }

    public override void NotifyOfGameOver(TAG_PLAYSTATE gameResult)
    {
        base.NotifyOfGameOver(gameResult);
        if (gameResult == TAG_PLAYSTATE.WON)
        {
            Network.SetCampaignProgress(MissionMgr.MissionProgress.TUTORIAL02_COMPLETE);
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL02_MILLHOUSE_20_22_ALT"));
        }
        else if (gameResult == TAG_PLAYSTATE.TIED)
        {
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL02_MILLHOUSE_20_22_ALT"));
        }
    }

    public override string[] NotifyOfKeywordHelpPanelDisplay(Entity entity)
    {
        if (entity.GetCardId() == "CS2_122")
        {
            return new string[] { GameStrings.Get("TUTORIAL_RAID_LEADER_HEADLINE"), GameStrings.Get("TUTORIAL_RAID_LEADER_DESCRIPTION") };
        }
        if (entity.GetCardId() == "CS2_023")
        {
            return new string[] { GameStrings.Get("TUTORIAL_ARCANE_INTELLECT_HEADLINE"), GameStrings.Get("TUTORIAL_ARCANE_INTELLECT_DESCRIPTION") };
        }
        return null;
    }

    public override void NotifyOfManaCrystalSpawned()
    {
        AssetLoader.Get().LoadActor("plus1", new AssetLoader.GameObjectCallback(this.Plus1ActorLoadedCallback));
        if (base.GetTag(GAME_TAG.TURN) == 3)
        {
            Actor actor = GameState.Get().GetLocalPlayer().GetHero().GetCard().GetActor();
            Gameplay.Get().StartCoroutine(base.PlaySoundAndWait("VO_TUTORIAL_02_JAINA_08_22", "TUTORIAL02_JAINA_08", Notification.SpeechBubbleDirection.BottomLeft, actor));
        }
        this.FadeInManaSpotlight();
    }

    protected override void NotifyOfManaError()
    {
        NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.manaNotifier);
        NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.manaNotifier2);
    }

    public override void NotifyOfTooltipZoneMouseOver(TooltipZone tooltip)
    {
        if (tooltip.targetObject.GetComponent<ManaCrystalMgr>() != null)
        {
            if (this.manaNotifier != null)
            {
                UnityEngine.Object.Destroy(this.manaNotifier.gameObject);
            }
            if (this.manaNotifier2 != null)
            {
                UnityEngine.Object.Destroy(this.manaNotifier2.gameObject);
            }
        }
    }

    private void Plus1ActorLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        Vector3 manaCrystalSpawnPosition = ManaCrystalMgr.Get().GetManaCrystalSpawnPosition();
        Vector3 vector2 = new Vector3(manaCrystalSpawnPosition.x - 0.02f, manaCrystalSpawnPosition.y + 0.2f, manaCrystalSpawnPosition.z);
        actorObject.transform.position = vector2;
        actorObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        Vector3 localScale = actorObject.transform.localScale;
        actorObject.transform.localScale = new Vector3(1f, 1f, 1f);
        iTween.MoveTo(actorObject, new Vector3(vector2.x, vector2.y, vector2.z + 2f), 3f);
        float num = 2.5f;
        iTween.ScaleTo(actorObject, new Vector3(localScale.x * num, localScale.y * num, localScale.z * num), 3f);
        iTween.RotateTo(actorObject, new Vector3(0f, 170f, 0f), 3f);
        iTween.FadeTo(actorObject, 0f, 2.75f);
    }

    private void Plus1ActorLoadedCallbackEnemy(string actorName, GameObject actorObject, object callbackData)
    {
        Vector3 position = SceneUtils.FindChildBySubstring(Board.Get().gameObject, "ManaCounter_Opposing").transform.position;
        Vector3 vector2 = new Vector3(position.x, position.y + 0.2f, position.z);
        actorObject.transform.position = vector2;
        actorObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        Vector3 localScale = actorObject.transform.localScale;
        actorObject.transform.localScale = new Vector3(1f, 1f, 1f);
        iTween.MoveTo(actorObject, new Vector3(vector2.x, vector2.y, vector2.z - 2f), 3f);
        float num = 2.5f;
        iTween.ScaleTo(actorObject, new Vector3(localScale.x * num, localScale.y * num, localScale.z * num), 3f);
        iTween.RotateTo(actorObject, new Vector3(0f, 170f, 0f), 3f);
        iTween.FadeTo(actorObject, 0f, 2.75f);
    }

    public override void PreloadAssets()
    {
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_02_05");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_01_04");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_04_07");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_05_08");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_07_10");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_11_14");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_13_16");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_15_17");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_06_09");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_03_06");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_17_19");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_08_11");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_09_12");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_10_13");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_16_18");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_20_22_ALT");
        base.PreloadSound("VO_TUTORIAL_02_JAINA_08_22");
        base.PreloadSound("VO_TUTORIAL_02_JAINA_03_18");
        base.PreloadSound("VO_TUTORIAL02_MILLHOUSE_19_21");
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

    [DebuggerHidden]
    private IEnumerator StartManaSpotFade()
    {
        return new <StartManaSpotFade>c__Iterator85();
    }

    [CompilerGenerated]
    private sealed class <HandleCoinFlip>c__Iterator84 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Tutorial_02 <>f__this;
        internal Actor <millhouseActor>__0;

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
                    MissionMgr.Get().SetBusy(true);
                    this.$current = new WaitForSeconds(3.5f);
                    this.$PC = 1;
                    goto Label_00F9;

                case 1:
                    this.<millhouseActor>__0 = GameState.Get().GetRemotePlayer().GetHero().GetCard().GetActor();
                    this.<>f__this.FadeInHeroActor(this.<millhouseActor>__0);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_01_04", "TUTORIAL02_MILLHOUSE_01", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                    this.$PC = 2;
                    goto Label_00F9;

                case 2:
                    MissionMgr.Get().SetBusy(false);
                    this.$current = new WaitForSeconds(0.175f);
                    this.$PC = 3;
                    goto Label_00F9;

                case 3:
                    this.<>f__this.FadeOutHeroActor(this.<millhouseActor>__0);
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_00F9:
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
    private sealed class <HandleMissionEventWithTiming>c__Iterator83 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>missionEvent;
        internal Tutorial_02 <>f__this;
        internal Actor <jainaActor>__1;
        internal Actor <millhouseActor>__0;
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
                    this.<millhouseActor>__0 = GameState.Get().GetRemotePlayer().GetHero().GetCard().GetActor();
                    this.<jainaActor>__1 = GameState.Get().GetLocalPlayer().GetHero().GetCard().GetActor();
                    missionEvent = this.missionEvent;
                    switch (missionEvent)
                    {
                        case 1:
                            GameState.Get().MulliganManagerActivate(true);
                            GameState.Get().SetMulliganPacketBlocker(true);
                            TurnStartManager.Get().BeginListeningForTurnEvents();
                            MulliganManager.Get().SkipCardChoosing();
                            goto Label_03E7;

                        case 2:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = new WaitForSeconds(1.5f);
                            this.$PC = 1;
                            goto Label_03E9;

                        case 3:
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_17_19", "TUTORIAL02_MILLHOUSE_17", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                            goto Label_03E7;

                        case 4:
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_08_11", "TUTORIAL02_MILLHOUSE_08", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                            this.$PC = 4;
                            goto Label_03E9;

                        case 5:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_10_13", "TUTORIAL02_MILLHOUSE_10", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                            this.$PC = 6;
                            goto Label_03E9;

                        case 6:
                            if (EndTurnButton.Get().IsInNMPState())
                            {
                                Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_16_18", string.Empty, Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                            }
                            goto Label_03E7;

                        case 9:
                            goto Label_03E7;
                    }
                    break;

                case 1:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_03_06", "TUTORIAL02_MILLHOUSE_03", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                    this.$PC = 2;
                    goto Label_03E9;

                case 2:
                    MissionMgr.Get().SetBusy(false);
                    this.$current = new WaitForSeconds(4f);
                    this.$PC = 3;
                    goto Label_03E9;

                case 3:
                    if ((this.<>f__this.GetTag(GAME_TAG.TURN) == 1) && !EndTurnButton.Get().IsInWaitingState())
                    {
                        this.<>f__this.ShowEndTurnBouncingArrow();
                    }
                    goto Label_03E7;

                case 4:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_02_JAINA_03_18", "TUTORIAL02_JAINA_03", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                    this.$PC = 5;
                    goto Label_03E9;

                case 5:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_09_12", "TUTORIAL02_MILLHOUSE_09", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                    goto Label_03E7;

                case 6:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_03E7;

                case 7:
                    AssetLoader.Get().LoadActor("TutorialIntroDialog", new AssetLoader.GameObjectCallback(this.<>f__this.DialogLoadedCallback));
                    goto Label_03E7;

                case 8:
                    HistoryManager.Get().DisableHistory();
                    MulliganManager.Get().BeginMulligan();
                    this.$current = new WaitForSeconds(1.1f);
                    this.$PC = 9;
                    goto Label_03E9;

                case 9:
                    this.<>f__this.FadeOutHeroActor(this.<millhouseActor>__0);
                    goto Label_03E7;

                default:
                    goto Label_03E7;
            }
            switch (missionEvent)
            {
                case 0x36:
                    this.$current = new WaitForSeconds(2f);
                    this.$PC = 7;
                    goto Label_03E9;

                case 0x37:
                    this.<>f__this.FadeInHeroActor(this.<millhouseActor>__0);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_02_05", "TUTORIAL02_MILLHOUSE_02", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                    this.$PC = 8;
                    goto Label_03E9;
            }
        Label_03E7:
            return false;
        Label_03E9:
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
    private sealed class <HandleStartOfTurnWithTiming>c__Iterator82 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>turn;
        internal Tutorial_02 <>f__this;
        internal Vector3 <manaPopupPosition>__2;
        internal Vector3 <manaPopupPosition2>__4;
        internal Vector3 <manaPosition>__1;
        internal Vector3 <manaPosition2>__3;
        internal Actor <millhouseActor>__0;
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
                    if (GameState.Get().IsLocalPlayerTurn())
                    {
                        this.<>f__this.numManaThisTurn++;
                    }
                    this.<millhouseActor>__0 = GameState.Get().GetRemotePlayer().GetHero().GetCard().GetActor();
                    switch (this.turn)
                    {
                        case 1:
                            this.<manaPosition>__1 = ManaCrystalMgr.Get().GetManaCrystalSpawnPosition();
                            this.<manaPopupPosition>__2 = new Vector3(this.<manaPosition>__1.x - 0.02f, this.<manaPosition>__1.y + 0.2f, this.<manaPosition>__1.z + 1.93f);
                            this.<>f__this.manaNotifier = NotificationManager.Get().CreatePopupText(this.<manaPopupPosition>__2, GameStrings.Get("TUTORIAL02_HELP_01"));
                            this.<>f__this.manaNotifier.ShowPopUpArrow(Notification.PopUpArrowDirection.Down);
                            this.$current = new WaitForSeconds(4.5f);
                            this.$PC = 1;
                            goto Label_067E;

                        case 2:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = new WaitForSeconds(0.5f);
                            this.$PC = 4;
                            goto Label_067E;

                        case 3:
                            this.<manaPosition2>__3 = ManaCrystalMgr.Get().GetManaCrystalSpawnPosition();
                            this.<manaPopupPosition2>__4 = new Vector3(this.<manaPosition2>__3.x - 0.02f, this.<manaPosition2>__3.y + 0.2f, this.<manaPosition2>__3.z + 1.7f);
                            this.<>f__this.manaNotifier2 = NotificationManager.Get().CreatePopupText(this.<manaPopupPosition2>__4, GameStrings.Get("TUTORIAL02_HELP_03"));
                            this.<>f__this.manaNotifier2.ShowPopUpArrow(Notification.PopUpArrowDirection.Down);
                            this.$current = new WaitForSeconds(4.5f);
                            this.$PC = 7;
                            goto Label_067E;

                        case 4:
                            NotificationManager.Get().DestroyNotification(this.<>f__this.manaNotifier2, 0f);
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_07_10", "TUTORIAL02_MILLHOUSE_07", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                            this.$PC = 9;
                            goto Label_067E;

                        case 6:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_11_14", "TUTORIAL02_MILLHOUSE_11", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                            this.$PC = 10;
                            goto Label_067E;

                        case 8:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_13_16", "TUTORIAL02_MILLHOUSE_13", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                            this.$PC = 11;
                            goto Label_067E;

                        case 9:
                            this.$current = new WaitForSeconds(0.5f);
                            this.$PC = 12;
                            goto Label_067E;

                        case 10:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_06_09", "TUTORIAL02_MILLHOUSE_06", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                            this.$PC = 13;
                            goto Label_067E;
                    }
                    break;

                case 1:
                {
                    object[] args = new object[] { "amount", new Vector3(1f, 1f, 1f), "time", 1f };
                    iTween.PunchScale(this.<>f__this.manaNotifier.gameObject, iTween.Hash(args));
                    this.$current = new WaitForSeconds(4.5f);
                    this.$PC = 2;
                    goto Label_067E;
                }
                case 2:
                    if (this.<>f__this.manaNotifier != null)
                    {
                        object[] objArray2 = new object[] { "amount", new Vector3(1f, 1f, 1f), "time", 1f };
                        iTween.PunchScale(this.<>f__this.manaNotifier.gameObject, iTween.Hash(objArray2));
                    }
                    this.$current = new WaitForSeconds(4.5f);
                    this.$PC = 3;
                    goto Label_067E;

                case 3:
                    NotificationManager.Get().DestroyNotification(this.<>f__this.manaNotifier, 0f);
                    break;

                case 4:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_04_07", "TUTORIAL02_MILLHOUSE_04", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                    this.$PC = 5;
                    goto Label_067E;

                case 5:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_05_08", "TUTORIAL02_MILLHOUSE_05", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                    this.$PC = 6;
                    goto Label_067E;

                case 6:
                    MissionMgr.Get().SetBusy(false);
                    break;

                case 7:
                {
                    object[] objArray3 = new object[] { "amount", new Vector3(1f, 1f, 1f), "time", 1f };
                    iTween.PunchScale(this.<>f__this.manaNotifier2.gameObject, iTween.Hash(objArray3));
                    this.$current = new WaitForSeconds(4.5f);
                    this.$PC = 8;
                    goto Label_067E;
                }
                case 8:
                    if (this.<>f__this.manaNotifier2 != null)
                    {
                        object[] objArray4 = new object[] { "amount", new Vector3(1f, 1f, 1f), "time", 1f };
                        iTween.PunchScale(this.<>f__this.manaNotifier2.gameObject, iTween.Hash(objArray4));
                    }
                    break;

                case 9:
                    MissionMgr.Get().SetBusy(false);
                    break;

                case 10:
                    MissionMgr.Get().SetBusy(false);
                    break;

                case 11:
                    MissionMgr.Get().SetBusy(false);
                    break;

                case 12:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL02_MILLHOUSE_15_17", "TUTORIAL02_MILLHOUSE_15", Notification.SpeechBubbleDirection.TopRight, this.<millhouseActor>__0));
                    break;

                case 13:
                    MissionMgr.Get().SetBusy(false);
                    break;
            }
            return false;
        Label_067E:
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
    private sealed class <StartManaSpotFade>c__Iterator85 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Light <manaSpot>__0;
        internal float <TARGET_INTENSITY>__1;

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
                    this.<manaSpot>__0 = BoardTutorial.Get().m_ManaSpotlight;
                    this.<manaSpot>__0.enabled = true;
                    this.<manaSpot>__0.spotAngle = 179f;
                    this.<manaSpot>__0.intensity = 0f;
                    this.<TARGET_INTENSITY>__1 = 0.6f;
                    break;

                case 1:
                    break;

                case 2:
                case 3:
                    while (this.<manaSpot>__0.intensity > 0.05f)
                    {
                        this.<manaSpot>__0.intensity = Mathf.Lerp(this.<manaSpot>__0.intensity, 0f, UnityEngine.Time.deltaTime * 10f);
                        this.$current = null;
                        this.$PC = 3;
                        goto Label_0184;
                    }
                    this.<manaSpot>__0.enabled = false;
                    this.$PC = -1;
                    goto Label_0182;

                default:
                    goto Label_0182;
            }
            if (this.<manaSpot>__0.intensity < (this.<TARGET_INTENSITY>__1 * 0.95f))
            {
                this.<manaSpot>__0.intensity = Mathf.Lerp(this.<manaSpot>__0.intensity, this.<TARGET_INTENSITY>__1, UnityEngine.Time.deltaTime * 5f);
                this.<manaSpot>__0.spotAngle = Mathf.Lerp(this.<manaSpot>__0.spotAngle, 80f, UnityEngine.Time.deltaTime * 5f);
                this.$current = null;
                this.$PC = 1;
            }
            else
            {
                this.$current = new WaitForSeconds(2f);
                this.$PC = 2;
            }
            goto Label_0184;
        Label_0182:
            return false;
        Label_0184:
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


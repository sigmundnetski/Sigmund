using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tutorial_04 : TutorialEntity
{
    private Notification endTurnNotifier;
    private Notification heroPowerHelp;
    private KeywordHelpPanel historyTooltip;
    private int numBeastsPlayed;
    private int numComplaintsMade;
    private Notification thatsABadPlayPopup;
    private bool victory;

    private void DialogLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        base.startingPopup = actorObject.GetComponent<Notification>();
        NotificationManager.Get().CreatePopupDialogFromObject(base.startingPopup, GameStrings.Get("TUTORIAL04_HELP_14"), GameStrings.Get("TUTORIAL04_HELP_15"), GameStrings.Get("TUTORIAL01_HELP_16"));
        base.startingPopup.ButtonStart.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.UserPressedStartButton));
        base.startingPopup.artOverlay.material = base.startingPopup.swapMaterial;
        base.startingPopup.artOverlay.material.mainTextureOffset = new Vector2(0f, 0f);
    }

    public override List<RewardData> GetCustomRewards()
    {
        if (!this.victory)
        {
            return null;
        }
        List<RewardData> list = new List<RewardData>();
        CardRewardData item = new CardRewardData("CS2_213", CardFlair.PremiumType.STANDARD, 2);
        list.Add(item);
        return list;
    }

    [DebuggerHidden]
    private IEnumerator HandleCoinFlip()
    {
        return new <HandleCoinFlip>c__Iterator8A { <>f__this = this };
    }

    [DebuggerHidden]
    protected override IEnumerator HandleMissionEventWithTiming(int missionEvent)
    {
        return new <HandleMissionEventWithTiming>c__Iterator89 { missionEvent = missionEvent, <$>missionEvent = missionEvent, <>f__this = this };
    }

    [DebuggerHidden]
    protected override IEnumerator HandleStartOfTurnWithTiming(int turn)
    {
        return new <HandleStartOfTurnWithTiming>c__Iterator88 { turn = turn, <$>turn = turn, <>f__this = this };
    }

    public override bool IsKeywordHelpDelayOverridden()
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
            actorObject.transform.parent = costTextObject.transform;
            actorObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            actorObject.transform.localPosition = new Vector3(-0.02f, 0.38f, 0f);
            actorObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            actorObject.transform.localScale = new Vector3(actorObject.transform.localScale.x, actorObject.transform.localScale.x, actorObject.transform.localScale.x);
            actorObject.GetComponent<UberText>().Text = GameStrings.Get("GLOBAL_COST");
        }
    }

    public override void NotifyOfCoinFlipResult()
    {
        Gameplay.Get().StartCoroutine(this.HandleCoinFlip());
    }

    public override void NotifyOfDefeatCoinAnimation()
    {
        if (this.victory)
        {
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL_04_JAINA_10_44"));
        }
    }

    public override bool NotifyOfEndTurnButtonPushed()
    {
        if (base.GetTag(GAME_TAG.TURN) != 4)
        {
            NotificationManager.Get().DestroyAllArrows();
            return true;
        }
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
        this.endTurnNotifier = NotificationManager.Get().CreatePopupText(vector2, GameStrings.Get("TUTORIAL_NO_ENDTURN_HP"));
        NotificationManager.Get().DestroyNotification(this.endTurnNotifier, 2.5f);
        return false;
    }

    public override void NotifyOfGameOver(TAG_PLAYSTATE gameResult)
    {
        base.NotifyOfGameOver(gameResult);
        if (gameResult == TAG_PLAYSTATE.WON)
        {
            this.victory = true;
            Network.SetCampaignProgress(MissionMgr.MissionProgress.TUTORIAL04_COMPLETE);
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL04_HEMET_23_21"));
        }
        else if (gameResult == TAG_PLAYSTATE.TIED)
        {
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL04_HEMET_23_21"));
        }
    }

    public override void NotifyOfHistoryTokenMousedOff()
    {
        if (this.historyTooltip != null)
        {
            UnityEngine.Object.Destroy(this.historyTooltip.gameObject);
        }
    }

    public override void NotifyOfHistoryTokenMousedOver(GameObject mousedOverTile)
    {
        this.historyTooltip = KeywordHelpPanelManager.Get().CreateKeywordPanel(0);
        this.historyTooltip.Reset();
        this.historyTooltip.Initialize(GameStrings.Get("TUTORIAL_TOOLTIP_HISTORY_HEADLINE"), GameStrings.Get("TUTORIAL_TOOLTIP_HISTORY_DESC"));
        Vector3 position = mousedOverTile.transform.position;
        Vector3 vector2 = new Vector3(position.x + 0.1f, position.y, position.z + 0.874f);
        this.historyTooltip.transform.position = vector2;
    }

    public override void PreloadAssets()
    {
        base.PreloadSound("VO_TUTORIAL04_HEMET_23_21");
        base.PreloadSound("VO_TUTORIAL04_HEMET_15_13");
        base.PreloadSound("VO_TUTORIAL04_HEMET_20_18");
        base.PreloadSound("VO_TUTORIAL04_HEMET_16_14");
        base.PreloadSound("VO_TUTORIAL04_HEMET_13_12");
        base.PreloadSound("VO_TUTORIAL04_HEMET_19_17");
        base.PreloadSound("VO_TUTORIAL_04_JAINA_09_43");
        base.PreloadSound("VO_TUTORIAL_04_JAINA_10_44");
        base.PreloadSound("VO_TUTORIAL04_HEMET_06_05");
        base.PreloadSound("VO_TUTORIAL04_HEMET_07_06_ALT");
        base.PreloadSound("VO_TUTORIAL_04_JAINA_04_40");
        base.PreloadSound("VO_TUTORIAL04_HEMET_08_07");
        base.PreloadSound("VO_TUTORIAL04_HEMET_09_08");
        base.PreloadSound("VO_TUTORIAL04_HEMET_10_09");
        base.PreloadSound("VO_TUTORIAL04_HEMET_11_10");
        base.PreloadSound("VO_TUTORIAL04_HEMET_12_11");
        base.PreloadSound("VO_TUTORIAL04_HEMET_12_11_ALT");
        base.PreloadSound("VO_TUTORIAL_04_JAINA_08_42");
        base.PreloadSound("VO_TUTORIAL04_HEMET_01_01");
        base.PreloadSound("VO_TUTORIAL_04_JAINA_01_37");
        base.PreloadSound("VO_TUTORIAL04_HEMET_02_02");
        base.PreloadSound("VO_TUTORIAL04_HEMET_03_03");
        base.PreloadSound("VO_TUTORIAL_04_JAINA_02_38");
        base.PreloadSound("VO_TUTORIAL04_HEMET_04_04_ALT");
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
    private IEnumerator Wait(float seconds)
    {
        return new <Wait>c__Iterator8B { seconds = seconds, <$>seconds = seconds };
    }

    [CompilerGenerated]
    private sealed class <HandleCoinFlip>c__Iterator8A : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Tutorial_04 <>f__this;
        internal Actor <enemyActor>__0;
        internal Actor <jainaActor>__1;

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
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.Wait(1f));
                    this.$PC = 1;
                    goto Label_0224;

                case 1:
                    this.<enemyActor>__0 = GameState.Get().GetRemotePlayer().GetHero().GetCard().GetActor();
                    this.<jainaActor>__1 = GameState.Get().GetLocalPlayer().GetHero().GetCard().GetActor();
                    this.<>f__this.FadeInHeroActor(this.<enemyActor>__0);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_03_03", "TUTORIAL04_HEMET_03", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    this.$PC = 2;
                    goto Label_0224;

                case 2:
                    this.<>f__this.FadeOutHeroActor(this.<enemyActor>__0);
                    this.$current = new WaitForSeconds(0.3f);
                    this.$PC = 3;
                    goto Label_0224;

                case 3:
                    this.<>f__this.FadeInHeroActor(this.<jainaActor>__1);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_04_JAINA_02_38", "TUTORIAL04_JAINA_02", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                    this.$PC = 4;
                    goto Label_0224;

                case 4:
                    this.<>f__this.FadeOutHeroActor(this.<jainaActor>__1);
                    this.$current = new WaitForSeconds(0.25f);
                    this.$PC = 5;
                    goto Label_0224;

                case 5:
                    this.<>f__this.FadeInHeroActor(this.<enemyActor>__0);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_04_04_ALT", "TUTORIAL04_HEMET_04", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    this.$PC = 6;
                    goto Label_0224;

                case 6:
                    this.<>f__this.FadeOutHeroActor(this.<enemyActor>__0);
                    this.$current = new WaitForSeconds(0.4f);
                    this.$PC = 7;
                    goto Label_0224;

                case 7:
                    MissionMgr.Get().SetBusy(false);
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_0224:
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
    private sealed class <HandleMissionEventWithTiming>c__Iterator89 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>missionEvent;
        internal Tutorial_04 <>f__this;
        internal Actor <enemyActor>__0;
        internal Actor <jainaActor>__1;
        internal int missionEvent;

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
                    this.<enemyActor>__0 = GameState.Get().GetRemotePlayer().GetHero().GetCard().GetActor();
                    this.<jainaActor>__1 = GameState.Get().GetLocalPlayer().GetHero().GetCard().GetActor();
                    switch (this.missionEvent)
                    {
                        case 1:
                            GameState.Get().MulliganManagerActivate(true);
                            GameState.Get().SetMulliganPacketBlocker(true);
                            TurnStartManager.Get().BeginListeningForTurnEvents();
                            MulliganManager.Get().SkipCardChoosing();
                            goto Label_0557;

                        case 2:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_06_05", "TUTORIAL04_HEMET_06", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            this.$PC = 1;
                            goto Label_0559;

                        case 3:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.Wait(2f));
                            this.$PC = 3;
                            goto Label_0559;

                        case 4:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_04_JAINA_04_40", "TUTORIAL04_JAINA_04", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                            this.$PC = 4;
                            goto Label_0559;

                        case 5:
                            switch (this.<>f__this.numBeastsPlayed)
                            {
                                case 0:
                                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_08_07", "TUTORIAL04_HEMET_08", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                                    goto Label_0305;

                                case 1:
                                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_09_08", "TUTORIAL04_HEMET_09", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                                    goto Label_0305;

                                case 2:
                                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_10_09", "TUTORIAL04_HEMET_10", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                                    goto Label_0305;
                            }
                            break;

                        case 6:
                            if (this.<>f__this.numComplaintsMade == 0)
                            {
                                Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_12_11", "TUTORIAL04_HEMET_12a", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                                this.<>f__this.numComplaintsMade++;
                            }
                            else
                            {
                                Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_12_11_ALT", "TUTORIAL04_HEMET_12b", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            }
                            goto Label_0557;

                        case 7:
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_04_JAINA_08_42", "TUTORIAL04_JAINA_08", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                            goto Label_0557;

                        case 0x36:
                            this.$current = new WaitForSeconds(2f);
                            this.$PC = 5;
                            goto Label_0559;

                        case 0x37:
                            this.<>f__this.FadeInHeroActor(this.<enemyActor>__0);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_01_01", "TUTORIAL04_HEMET_01", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            this.$PC = 6;
                            goto Label_0559;
                    }
                    goto Label_0557;

                case 1:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_07_06_ALT", "TUTORIAL04_HEMET_07", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.Wait(1f));
                    this.$PC = 2;
                    goto Label_0559;

                case 2:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_0557;

                case 3:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_0557;

                case 4:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_0557;

                case 5:
                    AssetLoader.Get().LoadActor("TutorialIntroDialog", new AssetLoader.GameObjectCallback(this.<>f__this.DialogLoadedCallback));
                    goto Label_0557;

                case 6:
                    this.<>f__this.FadeOutHeroActor(this.<enemyActor>__0);
                    this.<>f__this.FadeInHeroActor(this.<jainaActor>__1);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_04_JAINA_01_37", "TUTORIAL04_JAINA_01", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                    this.$PC = 7;
                    goto Label_0559;

                case 7:
                    this.<>f__this.FadeOutHeroActor(this.<jainaActor>__1);
                    this.$current = new WaitForSeconds(0.5f);
                    this.$PC = 8;
                    goto Label_0559;

                case 8:
                    this.<>f__this.FadeInHeroActor(this.<enemyActor>__0);
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_02_02", "TUTORIAL04_HEMET_02", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    MulliganManager.Get().BeginMulligan();
                    this.$current = new WaitForSeconds(2.8f);
                    this.$PC = 9;
                    goto Label_0559;

                case 9:
                    this.<>f__this.FadeOutHeroActor(this.<enemyActor>__0);
                    goto Label_0557;

                default:
                    goto Label_0557;
            }
            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_11_10", "TUTORIAL04_HEMET_11", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
        Label_0305:
            this.<>f__this.numBeastsPlayed++;
        Label_0557:
            return false;
        Label_0559:
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
    private sealed class <HandleStartOfTurnWithTiming>c__Iterator88 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>turn;
        internal Tutorial_04 <>f__this;
        internal Actor <enemyActor>__0;
        internal Vector3 <help04Position>__3;
        internal Vector3 <heroPowerPosition>__2;
        internal Actor <jainaActor>__1;
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
                    this.<enemyActor>__0 = GameState.Get().GetRemotePlayer().GetHero().GetCard().GetActor();
                    this.<jainaActor>__1 = GameState.Get().GetLocalPlayer().GetHero().GetCard().GetActor();
                    switch (this.turn)
                    {
                        case 1:
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_15_13", "TUTORIAL04_HEMET_15", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            break;

                        case 4:
                            this.$current = new WaitForSeconds(1f);
                            this.$PC = 1;
                            goto Label_036A;

                        case 5:
                            NotificationManager.Get().DestroyNotification(this.<>f__this.heroPowerHelp, 0f);
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_20_18", "TUTORIAL04_HEMET_20", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            break;

                        case 7:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_16_14", "TUTORIAL04_HEMET_16", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            this.$PC = 2;
                            goto Label_036A;

                        case 9:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_13_12", "TUTORIAL04_HEMET_13", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            this.$PC = 3;
                            goto Label_036A;

                        case 11:
                            MissionMgr.Get().SetBusy(true);
                            MissionMgr.Get().SetBusyInSeconds(false, 3f);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL04_HEMET_19_17", "TUTORIAL04_HEMET_19", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            this.$PC = 4;
                            goto Label_036A;
                    }
                    break;

                case 1:
                    this.<heroPowerPosition>__2 = GameState.Get().GetLocalPlayer().GetHeroPowerCard().transform.position;
                    this.<help04Position>__3 = new Vector3(this.<heroPowerPosition>__2.x + 3f, this.<heroPowerPosition>__2.y, this.<heroPowerPosition>__2.z);
                    this.<>f__this.heroPowerHelp = NotificationManager.Get().CreatePopupText(this.<help04Position>__3, GameStrings.Get("TUTORIAL04_HELP_01"));
                    this.<>f__this.heroPowerHelp.ShowPopUpArrow(Notification.PopUpArrowDirection.Left);
                    AssetLoader.Get().LoadActor("NumberLabel", new AssetLoader.GameObjectCallback(this.<>f__this.ManaLabelLoadedCallback), GameState.Get().GetLocalPlayer().GetHeroPowerCard());
                    break;

                case 2:
                    MissionMgr.Get().SetBusy(false);
                    break;

                case 3:
                    MissionMgr.Get().SetBusy(false);
                    break;

                case 4:
                    this.$current = new WaitForSeconds(0.7f);
                    this.$PC = 5;
                    goto Label_036A;

                case 5:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_04_JAINA_09_43", "TUTORIAL04_JAINA_09", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                    this.$PC = 6;
                    goto Label_036A;
            }
            return false;
        Label_036A:
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
    private sealed class <Wait>c__Iterator8B : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal float <$>seconds;
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
                    return true;

                case 1:
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


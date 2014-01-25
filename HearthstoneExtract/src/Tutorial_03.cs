using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tutorial_03 : TutorialEntity
{
    private bool defenselessVoPlayed;
    private bool enemyPlayedBigBrother;
    private KeywordHelpPanel historyTooltip;
    private bool monkeyLinePlayedOnce;
    private bool needATaunterVOPlayed;
    private int numTauntGorillasPlayed;
    private bool overrideMouseOver;
    private bool seenTheBrother;
    private Notification thatsABadPlayPopup;
    private bool victory;
    private bool warnedAgainstAttackingGorilla;

    private void DialogLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        base.startingPopup = actorObject.GetComponent<Notification>();
        NotificationManager.Get().CreatePopupDialogFromObject(base.startingPopup, GameStrings.Get("TUTORIAL03_HELP_02"), GameStrings.Get("TUTORIAL03_HELP_03"), GameStrings.Get("TUTORIAL01_HELP_16"));
        base.startingPopup.ButtonStart.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.UserPressedStartButton));
        base.startingPopup.artOverlay.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
    }

    public override List<RewardData> GetCustomRewards()
    {
        if (!this.victory)
        {
            return null;
        }
        List<RewardData> list = new List<RewardData>();
        CardRewardData item = new CardRewardData("CS2_022", CardFlair.PremiumType.STANDARD, 2);
        list.Add(item);
        return list;
    }

    [DebuggerHidden]
    protected override IEnumerator HandleMissionEventWithTiming(int missionEvent)
    {
        return new <HandleMissionEventWithTiming>c__Iterator87 { missionEvent = missionEvent, <$>missionEvent = missionEvent, <>f__this = this };
    }

    [DebuggerHidden]
    protected override IEnumerator HandleStartOfTurnWithTiming(int turn)
    {
        return new <HandleStartOfTurnWithTiming>c__Iterator86 { turn = turn, <$>turn = turn, <>f__this = this };
    }

    public override bool IsKeywordHelpDelayOverridden()
    {
        return true;
    }

    public override bool IsMouseOverDelayOverriden()
    {
        return this.overrideMouseOver;
    }

    public override bool NotifyOfBattlefieldCardClicked(Entity clickedEntity, bool wasInTargetMode)
    {
        if (!base.NotifyOfBattlefieldCardClicked(clickedEntity, wasInTargetMode))
        {
            return false;
        }
        if ((wasInTargetMode && (clickedEntity.GetCardId() == "TU4c_007")) && !this.warnedAgainstAttackingGorilla)
        {
            this.warnedAgainstAttackingGorilla = true;
            base.HandleMissionEvent(11);
            return false;
        }
        return true;
    }

    public override void NotifyOfCardMousedOff(Entity mousedOffEntity)
    {
        this.overrideMouseOver = false;
    }

    public override void NotifyOfCardMousedOver(Entity mousedOverEntity)
    {
        if (mousedOverEntity.HasTaunt())
        {
            this.overrideMouseOver = true;
        }
    }

    public override void NotifyOfDefeatCoinAnimation()
    {
        if (this.victory)
        {
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL_03_JAINA_20_36"));
        }
    }

    public override void NotifyOfGameOver(TAG_PLAYSTATE gameResult)
    {
        base.NotifyOfGameOver(gameResult);
        if (gameResult == TAG_PLAYSTATE.WON)
        {
            this.victory = true;
            Network.SetCampaignProgress(MissionMgr.MissionProgress.TUTORIAL03_COMPLETE);
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL_03_MUKLA_07_07"));
        }
        else if (gameResult == TAG_PLAYSTATE.TIED)
        {
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL_03_MUKLA_07_07"));
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
        base.PreloadSound("VO_TUTORIAL_03_JAINA_17_33");
        base.PreloadSound("VO_TUTORIAL_03_JAINA_18_34");
        base.PreloadSound("VO_TUTORIAL_03_JAINA_01_24");
        base.PreloadSound("VO_TUTORIAL_03_JAINA_05_25");
        base.PreloadSound("VO_TUTORIAL_03_JAINA_07_26");
        base.PreloadSound("VO_TUTORIAL_03_JAINA_12_28");
        base.PreloadSound("VO_TUTORIAL_03_JAINA_13_29");
        base.PreloadSound("VO_TUTORIAL_03_JAINA_16_32");
        base.PreloadSound("VO_TUTORIAL_03_JAINA_14_30");
        base.PreloadSound("VO_TUTORIAL_03_JAINA_15_31");
        base.PreloadSound("VO_TUTORIAL_03_JAINA_20_36");
        base.PreloadSound("VO_TUTORIAL_03_MUKLA_01_01");
        base.PreloadSound("VO_TUTORIAL_03_MUKLA_03_03");
        base.PreloadSound("VO_TUTORIAL_03_MUKLA_04_04");
        base.PreloadSound("VO_TUTORIAL_03_MUKLA_05_05");
        base.PreloadSound("VO_TUTORIAL_03_MUKLA_06_06");
        base.PreloadSound("VO_TUTORIAL_03_MUKLA_07_07");
    }

    public override bool ShouldShowCrazyKeywordTooltip()
    {
        return true;
    }

    private void ShowDontFireballYourselfPopup(Vector3 origin)
    {
        if (this.thatsABadPlayPopup != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.thatsABadPlayPopup);
        }
        Vector3 position = new Vector3(origin.x - 3f, origin.y, origin.z);
        this.thatsABadPlayPopup = NotificationManager.Get().CreatePopupText(position, GameStrings.Get("TUTORIAL01_HELP_07"));
        NotificationManager.Get().DestroyNotification(this.thatsABadPlayPopup, 2.5f);
    }

    private void ShowDontPolymorphYourselfPopup(Vector3 origin)
    {
        if (this.thatsABadPlayPopup != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.thatsABadPlayPopup);
        }
        Vector3 position = new Vector3(origin.x - 3f, origin.y, origin.z);
        this.thatsABadPlayPopup = NotificationManager.Get().CreatePopupText(position, GameStrings.Get("TUTORIAL01_HELP_07"));
        NotificationManager.Get().DestroyNotification(this.thatsABadPlayPopup, 2.5f);
    }

    [CompilerGenerated]
    private sealed class <HandleMissionEventWithTiming>c__Iterator87 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>missionEvent;
        internal Tutorial_03 <>f__this;
        internal Actor <enemyActor>__0;
        internal ZonePlay <enemyBattlefield>__5;
        internal Vector3 <gorillaPosition>__2;
        internal Vector3 <help04Position>__3;
        internal Actor <jainaActor>__1;
        internal Vector3 <oldPosition>__6;
        internal Notification <tauntHelp>__4;
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
                    this.<enemyActor>__0 = GameState.Get().GetRemotePlayer().GetHero().GetCard().GetActor();
                    this.<jainaActor>__1 = GameState.Get().GetLocalPlayer().GetHero().GetCard().GetActor();
                    missionEvent = this.missionEvent;
                    switch (missionEvent)
                    {
                        case 1:
                            GameState.Get().MulliganManagerActivate(true);
                            AssetLoader.Get().LoadActor("TutorialKeywordManager");
                            GameState.Get().SetMulliganPacketBlocker(true);
                            TurnStartManager.Get().BeginListeningForTurnEvents();
                            MulliganManager.Get().SkipCardChoosing();
                            goto Label_0495;

                        case 2:
                        case 8:
                        case 9:
                            goto Label_0495;

                        case 4:
                            this.<>f__this.numTauntGorillasPlayed++;
                            if (this.<>f__this.numTauntGorillasPlayed != 1)
                            {
                                if (this.<>f__this.numTauntGorillasPlayed == 2)
                                {
                                    MissionMgr.Get().SetBusy(true);
                                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_MUKLA_06_06", string.Empty, Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                                    this.$PC = 3;
                                    goto Label_0497;
                                }
                                goto Label_0495;
                            }
                            this.$current = new WaitForSeconds(1f);
                            this.$PC = 1;
                            goto Label_0497;

                        case 10:
                            this.<>f__this.enemyPlayedBigBrother = true;
                            this.<enemyBattlefield>__5 = GameState.Get().GetRemotePlayer().GetBattlefieldZone();
                            this.<enemyBattlefield>__5.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                            this.<oldPosition>__6 = this.<enemyBattlefield>__5.transform.position;
                            this.<enemyBattlefield>__5.transform.position = new Vector3(this.<oldPosition>__6.x + 2.393164f, this.<oldPosition>__6.y + 0.314835f, this.<oldPosition>__6.z + 0.7f);
                            goto Label_0495;

                        case 11:
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_JAINA_16_32", "TUTORIAL03_JAINA_16", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                            goto Label_0495;

                        case 12:
                            if (!this.<>f__this.monkeyLinePlayedOnce)
                            {
                                this.<>f__this.monkeyLinePlayedOnce = true;
                                Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_JAINA_14_30", "TUTORIAL03_JAINA_16", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                            }
                            else
                            {
                                Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_JAINA_15_31", "TUTORIAL03_JAINA_15", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                            }
                            goto Label_0495;
                    }
                    break;

                case 1:
                    if (GameState.Get().GetRemotePlayer().GetBattlefieldZone().GetCards().Count != 0)
                    {
                        this.<gorillaPosition>__2 = GameState.Get().GetRemotePlayer().GetBattlefieldZone().GetCards()[0].transform.position;
                        this.<help04Position>__3 = new Vector3(this.<gorillaPosition>__2.x - 3f, this.<gorillaPosition>__2.y, this.<gorillaPosition>__2.z);
                        this.$current = new WaitForSeconds(2f);
                        this.$PC = 2;
                        goto Label_0497;
                    }
                    goto Label_0495;

                case 2:
                    this.<tauntHelp>__4 = NotificationManager.Get().CreatePopupText(this.<help04Position>__3, GameStrings.Get("TUTORIAL03_HELP_01"));
                    this.<tauntHelp>__4.ShowPopUpArrow(Notification.PopUpArrowDirection.Right);
                    NotificationManager.Get().DestroyNotification(this.<tauntHelp>__4, 6f);
                    goto Label_0495;

                case 3:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_0495;

                case 4:
                    AssetLoader.Get().LoadActor("TutorialIntroDialog", new AssetLoader.GameObjectCallback(this.<>f__this.DialogLoadedCallback));
                    goto Label_0495;

                case 5:
                    this.<>f__this.FadeOutHeroActor(this.<enemyActor>__0);
                    goto Label_0495;

                default:
                    goto Label_0495;
            }
            switch (missionEvent)
            {
                case 0x36:
                    this.$current = new WaitForSeconds(2f);
                    this.$PC = 4;
                    goto Label_0497;

                case 0x37:
                    MulliganManager.Get().BeginMulligan();
                    this.<>f__this.FadeInHeroActor(this.<enemyActor>__0);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_MUKLA_01_01", string.Empty, Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    this.$PC = 5;
                    goto Label_0497;
            }
        Label_0495:
            return false;
        Label_0497:
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
    private sealed class <HandleStartOfTurnWithTiming>c__Iterator86 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>turn;
        internal List<Card>.Enumerator <$s_354>__4;
        internal Tutorial_03 <>f__this;
        internal Actor <enemyActor>__0;
        internal Actor <jainaActor>__1;
        internal Card <minion>__5;
        internal List<Card> <myMinions>__3;
        internal bool <noTaunters>__2;
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
                    if (!this.<>f__this.enemyPlayedBigBrother)
                    {
                        break;
                    }
                    if (!GameState.Get().IsLocalPlayerTurn())
                    {
                        if (this.<>f__this.seenTheBrother)
                        {
                            break;
                        }
                        this.<>f__this.seenTheBrother = true;
                        MissionMgr.Get().SetBusy(true);
                        this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_JAINA_12_28", "TUTORIAL03_JAINA_12", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                        this.$PC = 1;
                        goto Label_03FB;
                    }
                    if (this.<>f__this.needATaunterVOPlayed)
                    {
                        if (!this.<>f__this.defenselessVoPlayed)
                        {
                            this.<noTaunters>__2 = true;
                            this.<myMinions>__3 = GameState.Get().GetLocalPlayer().GetBattlefieldZone().GetCards();
                            this.<$s_354>__4 = this.<myMinions>__3.GetEnumerator();
                            try
                            {
                                while (this.<$s_354>__4.MoveNext())
                                {
                                    this.<minion>__5 = this.<$s_354>__4.Current;
                                    if (this.<minion>__5.GetEntity().HasTaunt())
                                    {
                                        this.<noTaunters>__2 = false;
                                    }
                                }
                            }
                            finally
                            {
                                this.<$s_354>__4.Dispose();
                            }
                            if (this.<noTaunters>__2)
                            {
                                this.<>f__this.defenselessVoPlayed = true;
                                Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_JAINA_18_34", "TUTORIAL03_JAINA_18", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                            }
                        }
                        break;
                    }
                    this.<>f__this.needATaunterVOPlayed = true;
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_JAINA_17_33", "TUTORIAL03_JAINA_17", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                    goto Label_03F9;

                case 1:
                    MissionMgr.Get().SetBusy(false);
                    this.$current = new WaitForSeconds(3.2f);
                    this.$PC = 2;
                    goto Label_03FB;

                case 2:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_JAINA_13_29", "TUTORIAL03_JAINA_13", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                    break;

                case 3:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_MUKLA_03_03", string.Empty, Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    goto Label_03F9;

                case 4:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_03F9;

                default:
                    goto Label_03F9;
            }
            switch (this.turn)
            {
                case 1:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_JAINA_01_24", "TUTORIAL03_JAINA_01", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                    goto Label_03F9;

                case 2:
                case 3:
                case 4:
                case 7:
                case 8:
                case 10:
                case 11:
                case 12:
                case 13:
                    goto Label_03F9;

                case 5:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_JAINA_05_25", "TUTORIAL03_JAINA_05", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                    this.$PC = 3;
                    goto Label_03FB;

                case 6:
                    MissionMgr.Get().SetBusy(true);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_MUKLA_04_04", string.Empty, Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    this.$PC = 4;
                    goto Label_03FB;

                case 9:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_JAINA_07_26", "TUTORIAL03_JAINA_07", Notification.SpeechBubbleDirection.BottomLeft, this.<jainaActor>__1));
                    goto Label_03F9;

                case 14:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_03_MUKLA_05_05", string.Empty, Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    goto Label_03F9;
            }
        Label_03F9:
            return false;
        Label_03FB:
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


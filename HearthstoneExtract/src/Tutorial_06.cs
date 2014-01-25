using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tutorial_06 : TutorialEntity
{
    private Notification endTurnNotifier;
    private KeywordHelpPanel historyTooltip;
    private bool m_choSpeaking;
    private bool victory;

    private void DialogLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        base.startingPopup = actorObject.GetComponent<Notification>();
        NotificationManager.Get().CreatePopupDialogFromObject(base.startingPopup, GameStrings.Get("TUTORIAL06_HELP_01"), GameStrings.Get("TUTORIAL06_HELP_02"), GameStrings.Get("TUTORIAL01_HELP_16"));
        base.startingPopup.ButtonStart.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.UserPressedStartButton));
        base.startingPopup.artOverlay.material.mainTextureOffset = new Vector2(0f, 0.5f);
    }

    public override float GetAdditionalTimeToWaitForSpells()
    {
        return 1.5f;
    }

    public override List<RewardData> GetCustomRewards()
    {
        if (!this.victory)
        {
            return null;
        }
        List<RewardData> list = new List<RewardData>();
        CardRewardData item = new CardRewardData("CS2_124", CardFlair.PremiumType.STANDARD, 2);
        list.Add(item);
        return list;
    }

    [DebuggerHidden]
    protected override IEnumerator HandleMissionEventWithTiming(int missionEvent)
    {
        return new <HandleMissionEventWithTiming>c__Iterator90 { missionEvent = missionEvent, <$>missionEvent = missionEvent, <>f__this = this };
    }

    [DebuggerHidden]
    protected override IEnumerator HandleStartOfTurnWithTiming(int turn)
    {
        return new <HandleStartOfTurnWithTiming>c__Iterator8F { turn = turn, <$>turn = turn, <>f__this = this };
    }

    public override bool IsKeywordHelpDelayOverridden()
    {
        return true;
    }

    public override void NotifyOfDefeatCoinAnimation()
    {
        if (this.victory)
        {
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL_06_JAINA_05_53"));
        }
    }

    public override bool NotifyOfEndTurnButtonPushed()
    {
        Network.Options optionsPacket = GameState.Get().GetOptionsPacket();
        if (((optionsPacket != null) && (optionsPacket.List != null)) && (optionsPacket.List.Count != 1))
        {
            for (int i = 0; i < optionsPacket.List.Count; i++)
            {
                Network.Options.Option option = optionsPacket.List[i];
                if ((option.Type == Network.Options.Option.OptionType.POWER) && (GameState.Get().GetEntity(option.Main.ID).GetZone() == TAG_ZONE.PLAY))
                {
                    if (this.endTurnNotifier != null)
                    {
                        NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.endTurnNotifier);
                    }
                    Vector3 position = EndTurnButton.Get().transform.position;
                    Vector3 vector2 = new Vector3(position.x - 3f, position.y, position.z);
                    this.endTurnNotifier = NotificationManager.Get().CreatePopupText(vector2, GameStrings.Get("TUTORIAL_NO_ENDTURN_ATK"));
                    NotificationManager.Get().DestroyNotification(this.endTurnNotifier, 2.5f);
                    return false;
                }
            }
        }
        return true;
    }

    public override void NotifyOfGameOver(TAG_PLAYSTATE gameResult)
    {
        base.NotifyOfGameOver(gameResult);
        if (gameResult == TAG_PLAYSTATE.WON)
        {
            this.victory = true;
            Network.SetCampaignProgress(MissionMgr.MissionProgress.TUTORIAL06_COMPLETE);
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL_06_CHO_22_19"));
        }
        else if (gameResult == TAG_PLAYSTATE.TIED)
        {
            SoundManager.Get().PlayPreloaded(base.GetPreloadedSound("VO_TUTORIAL_06_CHO_22_19"));
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
        base.PreloadSound("VO_TUTORIAL_06_CHO_15_15");
        base.PreloadSound("VO_TUTORIAL_06_CHO_09_13");
        base.PreloadSound("VO_TUTORIAL_06_CHO_17_16");
        base.PreloadSound("VO_TUTORIAL_06_CHO_05_09");
        base.PreloadSound("VO_TUTORIAL_06_JAINA_03_51");
        base.PreloadSound("VO_TUTORIAL_06_CHO_06_10");
        base.PreloadSound("VO_TUTORIAL_06_CHO_21_18");
        base.PreloadSound("VO_TUTORIAL_06_CHO_20_17");
        base.PreloadSound("VO_TUTORIAL_06_CHO_07_11");
        base.PreloadSound("VO_TUTORIAL_06_JAINA_04_52");
        base.PreloadSound("VO_TUTORIAL_06_CHO_04_08");
        base.PreloadSound("VO_TUTORIAL_06_CHO_12_14");
        base.PreloadSound("VO_TUTORIAL_06_CHO_01_05");
        base.PreloadSound("VO_TUTORIAL_06_JAINA_01_49");
        base.PreloadSound("VO_TUTORIAL_06_CHO_02_06");
        base.PreloadSound("VO_TUTORIAL_06_JAINA_02_50");
        base.PreloadSound("VO_TUTORIAL_06_CHO_03_07");
        base.PreloadSound("VO_TUTORIAL_06_CHO_22_19");
        base.PreloadSound("VO_TUTORIAL_06_JAINA_05_53");
    }

    [DebuggerHidden]
    private IEnumerator Wait(float seconds)
    {
        return new <Wait>c__Iterator91 { seconds = seconds, <$>seconds = seconds };
    }

    [CompilerGenerated]
    private sealed class <HandleMissionEventWithTiming>c__Iterator90 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>missionEvent;
        internal Tutorial_06 <>f__this;
        internal Notification <battlecryNotification>__9;
        internal List<Card> <cardsInEnemyField>__6;
        internal Actor <enemyActor>__0;
        internal Spell <enemyAttackSpell>__3;
        internal Spell <enemyAttackSpell2>__5;
        internal Card <enemyHero>__2;
        internal Card <enemyHero2>__4;
        internal Actor <jainaActor>__1;
        internal Card <voodooDoctor>__7;
        internal Vector3 <voodooDoctorLocation>__8;
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
                            GameState.Get().SetMulliganPacketBlocker(true);
                            TurnStartManager.Get().BeginListeningForTurnEvents();
                            MulliganManager.Get().SkipCardChoosing();
                            goto Label_067C;

                        case 2:
                            MissionMgr.Get().SetBusy(true);
                            goto Label_0131;

                        case 6:
                            MissionMgr.Get().SetBusy(true);
                            this.<enemyHero>__2 = GameState.Get().GetRemotePlayer().GetHero().GetCard();
                            this.<enemyAttackSpell>__3 = this.<enemyHero>__2.GetActorSpell(SpellType.FRIENDLY_ATTACK);
                            this.<enemyAttackSpell>__3.ActivateState(SpellStateType.BIRTH);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_07_11", "TUTORIAL06_CHO_07", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            this.$PC = 3;
                            goto Label_067E;

                        case 7:
                            goto Label_067C;

                        case 8:
                            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_04_08", "TUTORIAL06_CHO_04", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            goto Label_067C;

                        case 9:
                            this.<enemyHero2>__4 = GameState.Get().GetRemotePlayer().GetHero().GetCard();
                            this.<enemyAttackSpell2>__5 = this.<enemyHero2>__4.GetActorSpell(SpellType.FRIENDLY_ATTACK);
                            this.<enemyAttackSpell2>__5.ActivateState(SpellStateType.CANCEL);
                            this.<>f__this.m_choSpeaking = true;
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_12_14", "TUTORIAL06_CHO_12", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            this.$PC = 4;
                            goto Label_067E;

                        case 10:
                            this.<cardsInEnemyField>__6 = GameState.Get().GetRemotePlayer().GetBattlefieldZone().GetCards();
                            if (this.<cardsInEnemyField>__6.Count == 0)
                            {
                                goto Label_067C;
                            }
                            MissionMgr.Get().SetBusy(true);
                            this.<voodooDoctor>__7 = this.<cardsInEnemyField>__6[this.<cardsInEnemyField>__6.Count - 1];
                            this.<voodooDoctorLocation>__8 = this.<voodooDoctor>__7.transform.position;
                            this.<battlecryNotification>__9 = NotificationManager.Get().CreatePopupText(new Vector3(this.<voodooDoctorLocation>__8.x + 3f, this.<voodooDoctorLocation>__8.y, this.<voodooDoctorLocation>__8.z), GameStrings.Get("TUTORIAL06_HELP_03"));
                            this.<battlecryNotification>__9.ShowPopUpArrow(Notification.PopUpArrowDirection.Left);
                            NotificationManager.Get().DestroyNotification(this.<battlecryNotification>__9, 5f);
                            this.$current = new WaitForSeconds(5f);
                            this.$PC = 5;
                            goto Label_067E;
                    }
                    break;

                case 1:
                    goto Label_0131;

                case 2:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_067C;

                case 3:
                    MissionMgr.Get().SetBusy(false);
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_JAINA_04_52", "TUTORIAL06_JAINA_04", Notification.SpeechBubbleDirection.BottomRight, this.<jainaActor>__1));
                    goto Label_067C;

                case 4:
                    this.<>f__this.m_choSpeaking = false;
                    goto Label_067C;

                case 5:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_067C;

                case 6:
                    AssetLoader.Get().LoadActor("TutorialIntroDialog", new AssetLoader.GameObjectCallback(this.<>f__this.DialogLoadedCallback));
                    goto Label_067C;

                case 7:
                    this.<>f__this.FadeOutHeroActor(this.<enemyActor>__0);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.Wait(0.5f));
                    this.$PC = 8;
                    goto Label_067E;

                case 8:
                    this.<>f__this.FadeInHeroActor(this.<jainaActor>__1);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_JAINA_01_49", "TUTORIAL06_JAINA_01", Notification.SpeechBubbleDirection.BottomRight, this.<jainaActor>__1));
                    this.$PC = 9;
                    goto Label_067E;

                case 9:
                    this.<>f__this.FadeOutHeroActor(this.<jainaActor>__1);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.Wait(0.5f));
                    this.$PC = 10;
                    goto Label_067E;

                case 10:
                    this.<>f__this.FadeInHeroActor(this.<enemyActor>__0);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_02_06", "TUTORIAL06_CHO_02", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    this.$PC = 11;
                    goto Label_067E;

                case 11:
                    this.<>f__this.FadeOutHeroActor(this.<enemyActor>__0);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.Wait(0.25f));
                    this.$PC = 12;
                    goto Label_067E;

                case 12:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_JAINA_02_50", "TUTORIAL06_JAINA_02", Notification.SpeechBubbleDirection.BottomRight, this.<jainaActor>__1));
                    this.$PC = 13;
                    goto Label_067E;

                case 13:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.Wait(0.25f));
                    this.$PC = 14;
                    goto Label_067E;

                case 14:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_03_07", "TUTORIAL06_CHO_03", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    goto Label_067C;

                default:
                    goto Label_067C;
            }
            switch (missionEvent)
            {
                case 0x36:
                    this.$current = new WaitForSeconds(2f);
                    this.$PC = 6;
                    goto Label_067E;

                case 0x37:
                    MulliganManager.Get().BeginMulligan();
                    this.<>f__this.FadeInHeroActor(this.<enemyActor>__0);
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_01_05", "TUTORIAL06_CHO_01", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    this.$PC = 7;
                    goto Label_067E;

                default:
                    goto Label_067C;
            }
        Label_0131:
            if (this.<>f__this.m_choSpeaking)
            {
                this.$current = null;
                this.$PC = 1;
            }
            else
            {
                this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_17_16", "TUTORIAL06_CHO_17", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                this.$PC = 2;
            }
            goto Label_067E;
        Label_067C:
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
    private sealed class <HandleStartOfTurnWithTiming>c__Iterator8F : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>turn;
        internal Tutorial_06 <>f__this;
        internal Actor <enemyActor>__0;
        internal Actor <jainaActor>__1;
        internal int turn;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            int turn;
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<enemyActor>__0 = GameState.Get().GetRemotePlayer().GetHero().GetCard().GetActor();
                    this.<jainaActor>__1 = GameState.Get().GetLocalPlayer().GetHero().GetCard().GetActor();
                    turn = this.turn;
                    switch (turn)
                    {
                        case 2:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_15_15", "TUTORIAL06_CHO_15", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            this.$PC = 1;
                            goto Label_0289;

                        case 4:
                            MissionMgr.Get().SetBusy(true);
                            this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_09_13", "TUTORIAL06_CHO_09", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                            this.$PC = 2;
                            goto Label_0289;
                    }
                    break;

                case 1:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_0287;

                case 2:
                    MissionMgr.Get().SetBusy(false);
                    goto Label_0287;

                case 3:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_JAINA_03_51", "TUTORIAL06_JAINA_03", Notification.SpeechBubbleDirection.BottomRight, this.<jainaActor>__1));
                    this.$PC = 4;
                    goto Label_0289;

                case 4:
                    Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_06_10", "TUTORIAL06_CHO_06", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    goto Label_0287;

                case 5:
                    goto Label_0202;

                default:
                    goto Label_0287;
            }
            switch (turn)
            {
                case 14:
                    goto Label_0202;

                case 15:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_05_09", "TUTORIAL06_CHO_05", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    this.$PC = 3;
                    goto Label_0289;

                case 0x10:
                    this.$current = Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_20_17", "TUTORIAL06_CHO_20", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
                    this.$PC = 6;
                    goto Label_0289;

                default:
                    goto Label_0287;
            }
        Label_0202:
            if (this.<>f__this.m_choSpeaking)
            {
                this.$current = null;
                this.$PC = 5;
                goto Label_0289;
            }
            Gameplay.Get().StartCoroutine(this.<>f__this.PlaySoundAndWait("VO_TUTORIAL_06_CHO_21_18", "TUTORIAL06_CHO_21", Notification.SpeechBubbleDirection.TopRight, this.<enemyActor>__0));
        Label_0287:
            return false;
        Label_0289:
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
    private sealed class <Wait>c__Iterator91 : IDisposable, IEnumerator, IEnumerator<object>
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


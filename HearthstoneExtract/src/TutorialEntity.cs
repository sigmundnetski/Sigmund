using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TutorialEntity : GameEntity
{
    protected const int HACK_MAX_CHARS_FOR_SPEECH_BUB = 20;
    private Notification manaReminder;
    protected Notification startingPopup;
    private Notification thatsABadPlayPopup;
    private bool userHitStartButton;

    [DebuggerHidden]
    private IEnumerator DisplayManaReminder(string reminderText)
    {
        return new <DisplayManaReminder>c__Iterator71 { reminderText = reminderText, <$>reminderText = reminderText, <>f__this = this };
    }

    protected void HandleMissionEvent(int missionEvent)
    {
        Gameplay.Get().StartCoroutine(this.HandleMissionEventWithTiming(missionEvent));
    }

    [DebuggerHidden]
    protected virtual IEnumerator HandleMissionEventWithTiming(int missionEvent)
    {
        return new <HandleMissionEventWithTiming>c__Iterator73();
    }

    protected void HandleStartOfTurn(int turn)
    {
        Gameplay.Get().StartCoroutine(this.HandleStartOfTurnWithTiming(turn));
    }

    [DebuggerHidden]
    protected virtual IEnumerator HandleStartOfTurnWithTiming(int turn)
    {
        return new <HandleStartOfTurnWithTiming>c__Iterator72();
    }

    public override bool NotifyOfBattlefieldCardClicked(Entity clickedEntity, bool wasInTargetMode)
    {
        if (!clickedEntity.IsControlledByLocalPlayer())
        {
            return true;
        }
        Network.Options.Option selectedNetworkOption = GameState.Get().GetSelectedNetworkOption();
        if ((selectedNetworkOption == null) || (selectedNetworkOption.Main == null))
        {
            return true;
        }
        Entity entity = GameState.Get().GetEntity(selectedNetworkOption.Main.ID);
        if (!wasInTargetMode || (entity == null))
        {
            return true;
        }
        if (clickedEntity == entity)
        {
            return true;
        }
        string cardId = entity.GetCardId();
        if ((!(cardId == "CS2_022") && !(cardId == "CS2_029")) && !(cardId == "CS2_034"))
        {
            return true;
        }
        this.ShowDontHurtYourselfPopup(clickedEntity.GetCard().transform.position);
        return false;
    }

    public override void NotifyOfHeroesFinishedAnimatingInMulligan()
    {
        Board.Get().FindCollider("DragPlane").collider.enabled = false;
        this.HandleMissionEvent(0x36);
    }

    protected virtual void NotifyOfManaError()
    {
    }

    public override bool NotifyOfPlayError(PlayErrors.ErrorType error, Entity errorSource)
    {
        if (error == PlayErrors.ErrorType.REQ_ENOUGH_MANA)
        {
            Actor actor = GameState.Get().GetLocalPlayer().GetHero().GetCard().GetActor();
            if (errorSource.GetCost() > GameState.Get().GetLocalPlayer().GetTag(GAME_TAG.RESOURCES))
            {
                Notification notification = NotificationManager.Get().CreateSpeechBubble(TextUtils.HackAutoLineBreakText(GameStrings.Get("TUTORIAL02_JAINA_05"), 20), Notification.SpeechBubbleDirection.BottomLeft, actor, true);
                SoundManager.Get().LoadAndPlay("VO_TUTORIAL_02_JAINA_05_20");
                NotificationManager.Get().DestroyNotification(notification, 3.5f);
                Gameplay.Get().StartCoroutine(this.DisplayManaReminder(GameStrings.Get("TUTORIAL02_HELP_01")));
            }
            else
            {
                Notification notification2 = NotificationManager.Get().CreateSpeechBubble(TextUtils.HackAutoLineBreakText(GameStrings.Get("TUTORIAL02_JAINA_04"), 20), Notification.SpeechBubbleDirection.BottomLeft, actor, true);
                SoundManager.Get().LoadAndPlay("VO_TUTORIAL_02_JAINA_04_19");
                NotificationManager.Get().DestroyNotification(notification2, 3.5f);
                Gameplay.Get().StartCoroutine(this.DisplayManaReminder(GameStrings.Get("TUTORIAL02_HELP_03")));
            }
            return true;
        }
        return ((error == PlayErrors.ErrorType.REQ_ATTACK_GREATER_THAN_0) && (errorSource.GetCardId() == "TU4a_006"));
    }

    public override void NotifyOfStartOfTurnEventsFinished()
    {
        this.HandleStartOfTurn(base.GetTag(GAME_TAG.TURN));
    }

    public override bool NotifyOfTooltipDisplay(TooltipZone tooltip)
    {
        ZoneDeck component = tooltip.targetObject.GetComponent<ZoneDeck>();
        if (component != null)
        {
            if (component.m_Side == Player.Side.FRIENDLY)
            {
                tooltip.ShowGameplayTooltip(GameStrings.Get("GAMEPLAY_TOOLTIP_DECK_HEADLINE"), GameStrings.Get("TUTORIAL_TOOLTIP_DECK_DESCRIPTION"));
                return true;
            }
            if (component.m_Side == Player.Side.OPPOSING)
            {
                tooltip.ShowGameplayTooltip(GameStrings.Get("GAMEPLAY_TOOLTIP_ENEMYDECK_HEADLINE"), GameStrings.Get("TUTORIAL_TOOLTIP_ENEMYDECK_DESC"));
                return true;
            }
        }
        return false;
    }

    public override void OnTagChanged(TagDelta change)
    {
        GAME_TAG tag = (GAME_TAG) change.tag;
        if (tag != GAME_TAG.MISSION_EVENT)
        {
            if ((tag == GAME_TAG.STEP) && ((change.newValue == 10) && (change.oldValue == 9)))
            {
                if (GameState.Get().IsLocalPlayerTurn())
                {
                    if (!GameState.Get().IsMulliganPhase())
                    {
                        TurnStartManager.Get().BeginPlayingTurnEvents();
                    }
                    else
                    {
                        MulliganManager.Get().NotifyOfTurnBegun();
                    }
                }
                else
                {
                    this.HandleStartOfTurn(base.GetTag(GAME_TAG.TURN));
                }
            }
        }
        else
        {
            this.HandleMissionEvent(change.newValue);
        }
        base.OnTagChanged(change);
    }

    [DebuggerHidden]
    protected IEnumerator PlaySoundAndWait(string audioName, string stringName, Notification.SpeechBubbleDirection direction, Actor actor)
    {
        return new <PlaySoundAndWait>c__Iterator74 { audioName = audioName, direction = direction, stringName = stringName, actor = actor, <$>audioName = audioName, <$>direction = direction, <$>stringName = stringName, <$>actor = actor, <>f__this = this };
    }

    public override void SendCustomEvent(int eventID)
    {
        this.HandleMissionEvent(eventID);
    }

    public override bool ShouldDoOpeningTaunts()
    {
        return false;
    }

    protected void ShowBubble(string textKey, Notification.SpeechBubbleDirection direction, Actor speakingActor, bool destroyOnNewNotification, float duration)
    {
        Notification notification;
        NotificationManager manager = NotificationManager.Get();
        if (SoundUtils.IsVoiceAudible())
        {
            notification = manager.CreateSpeechBubble(string.Empty, direction, speakingActor, destroyOnNewNotification);
            float num = 0.25f;
            Vector3 vector = new Vector3(notification.transform.localScale.x * num, notification.transform.localScale.y * num, notification.transform.localScale.z * num);
            notification.transform.localScale = vector;
        }
        else
        {
            notification = manager.CreateSpeechBubble(GameStrings.Get(textKey), direction, speakingActor, destroyOnNewNotification);
        }
        if (duration > 0f)
        {
            manager.DestroyNotification(notification, duration);
        }
    }

    private void ShowDontHurtYourselfPopup(Vector3 origin)
    {
        if (this.thatsABadPlayPopup != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.thatsABadPlayPopup);
        }
        Vector3 position = new Vector3(origin.x - 3f, origin.y, origin.z);
        this.thatsABadPlayPopup = NotificationManager.Get().CreatePopupText(position, GameStrings.Get("TUTORIAL01_HELP_07"));
        NotificationManager.Get().DestroyNotification(this.thatsABadPlayPopup, 2.5f);
    }

    protected void UserPressedStartButton(UIEvent e)
    {
        if (!this.userHitStartButton)
        {
            this.userHitStartButton = true;
            if (this.startingPopup != null)
            {
                NotificationManager.Get().DestroyNotification(this.startingPopup, 0f);
            }
            this.HandleMissionEvent(0x37);
        }
    }

    [CompilerGenerated]
    private sealed class <DisplayManaReminder>c__Iterator71 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal string <$>reminderText;
        internal TutorialEntity <>f__this;
        internal Vector3 <manaPopupPosition>__1;
        internal Vector3 <manaPosition>__0;
        internal string reminderText;

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
                    if (this.<>f__this.manaReminder != null)
                    {
                        NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.<>f__this.manaReminder);
                    }
                    this.<>f__this.NotifyOfManaError();
                    this.<manaPosition>__0 = ManaCrystalMgr.Get().GetManaCrystalSpawnPosition();
                    this.<manaPopupPosition>__1 = new Vector3(this.<manaPosition>__0.x - 0.02f, this.<manaPosition>__0.y + 0.2f, this.<manaPosition>__0.z + 1.93f);
                    this.<>f__this.manaReminder = NotificationManager.Get().CreatePopupText(this.<manaPopupPosition>__1, this.reminderText);
                    this.<>f__this.manaReminder.ShowPopUpArrow(Notification.PopUpArrowDirection.Down);
                    NotificationManager.Get().DestroyNotification(this.<>f__this.manaReminder, 4f);
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
    private sealed class <HandleMissionEventWithTiming>c__Iterator73 : IDisposable, IEnumerator, IEnumerator<object>
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
            this.$PC = -1;
            if (this.$PC == 0)
            {
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
    private sealed class <HandleStartOfTurnWithTiming>c__Iterator72 : IDisposable, IEnumerator, IEnumerator<object>
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
            this.$PC = -1;
            if (this.$PC == 0)
            {
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
    private sealed class <PlaySoundAndWait>c__Iterator74 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Actor <$>actor;
        internal string <$>audioName;
        internal Notification.SpeechBubbleDirection <$>direction;
        internal string <$>stringName;
        internal TutorialEntity <>f__this;
        internal AudioSource <sound>__0;
        internal float <waitTime>__1;
        internal Actor actor;
        internal string audioName;
        internal Notification.SpeechBubbleDirection direction;
        internal string stringName;

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
                    this.<sound>__0 = this.<>f__this.GetPreloadedSound(this.audioName);
                    if ((this.<sound>__0 != null) && (this.<sound>__0.clip != null))
                    {
                        this.<waitTime>__1 = this.<sound>__0.clip.length;
                        SoundManager.Get().PlayPreloaded(this.<sound>__0);
                        if (this.direction != Notification.SpeechBubbleDirection.None)
                        {
                            this.<>f__this.ShowBubble(this.stringName, this.direction, this.actor, false, this.<waitTime>__1);
                        }
                        break;
                    }
                    UnityEngine.Debug.LogError("TutorialEntity.PlaySoundAndWait() - sound error - " + this.audioName);
                    goto Label_0102;

                case 1:
                    break;

                default:
                    goto Label_0102;
            }
            while (SoundManager.Get().IsActive(this.<sound>__0))
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.$PC = -1;
        Label_0102:
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


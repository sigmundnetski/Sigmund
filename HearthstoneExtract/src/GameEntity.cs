using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameEntity : Entity
{
    private Dictionary<string, AudioSource> m_preloadedSounds = new Dictionary<string, AudioSource>();
    private int m_preloadsNeeded;

    public GameEntity()
    {
        this.PreloadAssets();
    }

    public virtual bool AreTooltipsDisabled()
    {
        return false;
    }

    protected Spell BlowUpHero(Card card, SpellType spellType)
    {
        Spell spell = card.ActivateActorSpell(spellType);
        Gameplay.Get().StartCoroutine(this.HideOtherElements(card));
        return spell;
    }

    public void FadeInHeroActor(Actor actorToFade)
    {
        <FadeInHeroActor>c__AnonStorey138 storey = new <FadeInHeroActor>c__AnonStorey138();
        Gameplay.Get().StartCoroutine(this.ToggleSpotLight(actorToFade.GetHeroSpotlight(), true));
        storey.heroMat = actorToFade.m_portraitMesh.renderer.materials[actorToFade.m_portraitMatIdx];
        storey.heroFrameMat = actorToFade.m_portraitMesh.renderer.materials[actorToFade.m_portraitFrameMatIdx];
        float @float = storey.heroMat.GetFloat("_LightingBlend");
        Action<object> action = new Action<object>(storey.<>m__2C);
        object[] args = new object[] { "time", 0.35f, "from", @float, "to", 0f, "onupdate", action, "onupdatetarget", actorToFade.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(actorToFade.gameObject, hashtable);
    }

    public void FadeOutHeroActor(Actor actorToFade)
    {
        <FadeOutHeroActor>c__AnonStorey137 storey = new <FadeOutHeroActor>c__AnonStorey137();
        Gameplay.Get().StartCoroutine(this.ToggleSpotLight(actorToFade.GetHeroSpotlight(), false));
        storey.heroMat = actorToFade.m_portraitMesh.renderer.materials[actorToFade.m_portraitMatIdx];
        storey.heroFrameMat = actorToFade.m_portraitMesh.renderer.materials[actorToFade.m_portraitFrameMatIdx];
        float @float = storey.heroMat.GetFloat("_LightingBlend");
        Action<object> action = new Action<object>(storey.<>m__2B);
        object[] args = new object[] { "time", 0.35f, "from", @float, "to", 1f, "onupdate", action, "onupdatetarget", actorToFade.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(actorToFade.gameObject, hashtable);
    }

    public virtual float GetAdditionalTimeToWaitForSpells()
    {
        return 0f;
    }

    public virtual List<RewardData> GetCustomRewards()
    {
        return null;
    }

    public override string GetDebugName()
    {
        return "GameEntity";
    }

    public override string GetName()
    {
        return "GameEntity";
    }

    public AudioSource GetPreloadedSound(string name)
    {
        AudioSource source;
        if (this.m_preloadedSounds.TryGetValue(name, out source))
        {
            return source;
        }
        UnityEngine.Debug.LogError(string.Format("GameEntity.GetPreloadedSound() - \"{0}\" was not preloaded", name));
        return null;
    }

    public virtual string GetTurnStartReminderText()
    {
        return string.Empty;
    }

    [DebuggerHidden]
    private IEnumerator HideOtherElements(Card card)
    {
        return new <HideOtherElements>c__Iterator3A { card = card, <$>card = card };
    }

    public virtual bool IsKeywordHelpDelayOverridden()
    {
        return false;
    }

    public virtual bool IsMouseOverDelayOverriden()
    {
        return false;
    }

    public bool IsPreloadingAssets()
    {
        return (this.m_preloadsNeeded > 0);
    }

    public virtual bool NotifyOfBattlefieldCardClicked(Entity clickedEntity, bool wasInTargetMode)
    {
        return true;
    }

    public virtual void NotifyOfCardDropped(Entity entity)
    {
    }

    public virtual void NotifyOfCardGrabbed(Entity entity)
    {
    }

    public virtual void NotifyOfCardMousedOff(Entity mousedOffEntity)
    {
    }

    public virtual void NotifyOfCardMousedOver(Entity mousedOverEntity)
    {
    }

    public virtual void NotifyOfCardTooltipDisplayHide(Card card)
    {
    }

    public virtual bool NotifyOfCardTooltipDisplayShow(Card card)
    {
        return true;
    }

    public virtual void NotifyOfCoinFlipResult()
    {
    }

    public virtual void NotifyOfCustomIntroFinished()
    {
    }

    public virtual void NotifyOfDebugCommand(int command)
    {
    }

    public virtual void NotifyOfDefeatCoinAnimation()
    {
    }

    public virtual bool NotifyOfEndTurnButtonPushed()
    {
        return true;
    }

    public virtual void NotifyOfEnemyManaCrystalSpawned()
    {
    }

    public virtual void NotifyOfGameOver(TAG_PLAYSTATE gameResult)
    {
        Spell spell;
        Spell spell2;
        PegCursor.Get().SetMode(PegCursor.Mode.STOPWAITING);
        SoundManager.Get().NukeMusicAndAmbiencePlaylists();
        SoundManager.Get().StopCurrentMusicTrack();
        this.PlayHeroBlowUpSpells(gameResult, out spell, out spell2);
        this.ShowEndScreen(gameResult, spell, spell2);
    }

    public virtual void NotifyOfGamePackOpened()
    {
    }

    public virtual void NotifyOfHelpPanelDisplay(int numPanels)
    {
    }

    public virtual void NotifyOfHeroesFinishedAnimatingInMulligan()
    {
    }

    public virtual void NotifyOfHistoryTokenMousedOff()
    {
    }

    public virtual void NotifyOfHistoryTokenMousedOver(GameObject mousedOverTile)
    {
    }

    public virtual string[] NotifyOfKeywordHelpPanelDisplay(Entity entity)
    {
        return null;
    }

    public virtual void NotifyOfManaCrystalSpawned()
    {
    }

    public virtual void NotifyOfMulliganEnded()
    {
    }

    public virtual bool NotifyOfPlayError(PlayErrors.ErrorType error, Entity errorSource)
    {
        return false;
    }

    public virtual void NotifyOfStartOfTurnEventsFinished()
    {
    }

    public virtual void NotifyOfTargetModeCancelled()
    {
    }

    public virtual bool NotifyOfTooltipDisplay(TooltipZone tooltip)
    {
        return false;
    }

    public virtual void NotifyOfTooltipZoneMouseOver(TooltipZone tooltip)
    {
    }

    private void OnEndGameScreenCallback(string name, GameObject go, object callbackData)
    {
        EndGameScreen component = go.GetComponent<EndGameScreen>();
        ((EndGameScreenContext) callbackData).ShowScreen(component);
    }

    private void OnSoundLoaded(string name, GameObject go, object callbackData)
    {
        this.m_preloadsNeeded--;
        if (go == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("GameEntity.OnSoundLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            AudioSource component = go.GetComponent<AudioSource>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("GameEntity.OnSoundLoaded() - ERROR \"{0}\" has no Spell component", name));
            }
            else
            {
                this.m_preloadedSounds.Add(name, component);
            }
        }
    }

    public override void OnTagChanged(TagDelta change)
    {
        if (change.tag == 20)
        {
            GameState.Get().OnTurnChanged(change.oldValue, change.newValue);
            GameState.Get().GetLocalPlayer().WipeZzzs();
            GameState.Get().GetRemotePlayer().WipeZzzs();
        }
        base.OnTagChanged(change);
    }

    public override void OnTagsChanged(TagDeltaSet changeSet)
    {
        for (int i = 0; i < changeSet.Size(); i++)
        {
            TagDelta change = changeSet[i];
            this.OnTagChanged(change);
        }
    }

    private void PlayHeroBlowUpSpells(TAG_PLAYSTATE gameResult, out Spell enemyBlowUpSpell, out Spell friendlyBlowUpSpell)
    {
        enemyBlowUpSpell = null;
        friendlyBlowUpSpell = null;
        Card heroCard = GameState.Get().GetRemotePlayer().GetHeroCard();
        Card card = GameState.Get().GetLocalPlayer().GetHeroCard();
        if (gameResult == TAG_PLAYSTATE.WON)
        {
            enemyBlowUpSpell = this.BlowUpHero(heroCard, SpellType.ENDGAME_WIN);
        }
        else if (gameResult == TAG_PLAYSTATE.LOST)
        {
            friendlyBlowUpSpell = this.BlowUpHero(card, SpellType.ENDGAME_LOSE);
        }
        else if (gameResult == TAG_PLAYSTATE.TIED)
        {
            enemyBlowUpSpell = this.BlowUpHero(heroCard, SpellType.ENDGAME_DRAW);
            friendlyBlowUpSpell = this.BlowUpHero(card, SpellType.ENDGAME_LOSE);
        }
    }

    public virtual void PreloadAssets()
    {
    }

    public void PreloadSound(string soundName)
    {
        this.m_preloadsNeeded++;
        AssetLoader.Get().LoadSound(soundName, new AssetLoader.GameObjectCallback(this.OnSoundLoaded));
    }

    public virtual void SendCustomEvent(int eventID)
    {
    }

    public virtual bool ShouldDoAlternateMulliganIntro()
    {
        return false;
    }

    public virtual bool ShouldDoOpeningTaunts()
    {
        return true;
    }

    public virtual bool ShouldShowBigCard()
    {
        return true;
    }

    public virtual bool ShouldShowCrazyKeywordTooltip()
    {
        return false;
    }

    public virtual bool ShouldShowHeroTooltips()
    {
        return false;
    }

    private void ShowEndScreen(TAG_PLAYSTATE gameResult, Spell enemyBlowUpSpell, Spell friendlyBlowUpSpell)
    {
        EndGameScreenContext callbackData = new EndGameScreenContext {
            m_enemyBlowUpSpell = enemyBlowUpSpell,
            m_friendlyBlowUpSpell = friendlyBlowUpSpell
        };
        if (gameResult == TAG_PLAYSTATE.WON)
        {
            SoundManager.Get().LoadAndPlay("victory_jingle");
            if (((SceneMgr.Get().GetPrevMode() == SceneMgr.Mode.DRAFT) && (DraftManager.Get() != null)) && (DraftManager.Get().GetPreviousWins() == 0x13))
            {
                DraftManager.Get().NotifyOfFinalGame(true);
            }
            Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_DISPLAYED_WIN_SCREEN);
            AssetLoader.Get().LoadActor("VictoryTwoScoop", new AssetLoader.GameObjectCallback(this.OnEndGameScreenCallback), callbackData);
        }
        else if (gameResult == TAG_PLAYSTATE.LOST)
        {
            SoundManager.Get().LoadAndPlay("defeat_jingle");
            if (((SceneMgr.Get().GetPrevMode() == SceneMgr.Mode.DRAFT) && (DraftManager.Get() != null)) && (DraftManager.Get().GetPreviousLosses() == 2))
            {
                DraftManager.Get().NotifyOfFinalGame(false);
            }
            Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_DISPLAYED_LOSS_SCREEN);
            AssetLoader.Get().LoadActor("DefeatTwoScoop", new AssetLoader.GameObjectCallback(this.OnEndGameScreenCallback), callbackData);
        }
        else if (gameResult == TAG_PLAYSTATE.TIED)
        {
            SoundManager.Get().LoadAndPlay("defeat_jingle");
            if (((SceneMgr.Get().GetPrevMode() == SceneMgr.Mode.DRAFT) && (DraftManager.Get() != null)) && (DraftManager.Get().GetPreviousLosses() == 2))
            {
                DraftManager.Get().NotifyOfFinalGame(false);
            }
            Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_DISPLAYED_TIE_SCREEN);
            AssetLoader.Get().LoadActor("DefeatTwoScoop", new AssetLoader.GameObjectCallback(this.OnEndGameScreenCallback), callbackData);
        }
    }

    [DebuggerHidden]
    private IEnumerator ToggleSpotLight(Light light, bool bOn)
    {
        return new <ToggleSpotLight>c__Iterator39 { bOn = bOn, light = light, <$>bOn = bOn, <$>light = light };
    }

    [CompilerGenerated]
    private sealed class <FadeInHeroActor>c__AnonStorey138
    {
        internal Material heroFrameMat;
        internal Material heroMat;

        internal void <>m__2C(object amount)
        {
            this.heroMat.SetFloat("_LightingBlend", (float) amount);
            this.heroFrameMat.SetFloat("_LightingBlend", (float) amount);
        }
    }

    [CompilerGenerated]
    private sealed class <FadeOutHeroActor>c__AnonStorey137
    {
        internal Material heroFrameMat;
        internal Material heroMat;

        internal void <>m__2B(object amount)
        {
            this.heroMat.SetFloat("_LightingBlend", (float) amount);
            this.heroFrameMat.SetFloat("_LightingBlend", (float) amount);
        }
    }

    [CompilerGenerated]
    private sealed class <HideOtherElements>c__Iterator3A : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <$>card;
        internal Player <controller>__0;
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
                    this.$current = new WaitForSeconds(0.5f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<controller>__0 = this.card.GetEntity().GetController();
                    if (this.<controller>__0.GetHeroPowerCard() != null)
                    {
                        this.<controller>__0.GetHeroPowerCard().HideCard();
                        this.<controller>__0.GetHeroPowerCard().GetActor().ToggleForceIdle(true);
                        this.<controller>__0.GetHeroPowerCard().GetActor().SetActorState(ActorStateType.CARD_IDLE);
                        this.<controller>__0.GetHeroPowerCard().GetActor().DeactivateAllPreDeathSpells();
                    }
                    if (this.<controller>__0.GetWeaponCard() != null)
                    {
                        this.<controller>__0.GetWeaponCard().HideCard();
                        this.<controller>__0.GetWeaponCard().GetActor().ToggleForceIdle(true);
                        this.<controller>__0.GetWeaponCard().GetActor().SetActorState(ActorStateType.CARD_IDLE);
                        this.<controller>__0.GetWeaponCard().GetActor().DeactivateAllPreDeathSpells();
                    }
                    this.card.GetActor().GetHealthObject().Hide();
                    this.card.GetActor().ToggleForceIdle(true);
                    this.card.GetActor().SetActorState(ActorStateType.CARD_IDLE);
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
    private sealed class <ToggleSpotLight>c__Iterator39 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal bool <$>bOn;
        internal Light <$>light;
        internal float <defaultIntensity>__0;
        internal bool bOn;
        internal Light light;

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
                    if (!this.bOn)
                    {
                        goto Label_00FF;
                    }
                    this.light.enabled = true;
                    this.<defaultIntensity>__0 = 3f;
                    this.light.intensity = 0f;
                    break;

                case 1:
                    break;

                case 2:
                    goto Label_00FF;

                default:
                    goto Label_0127;
            }
            if (this.light.intensity < (this.<defaultIntensity>__0 * 0.95f))
            {
                this.light.intensity = Mathf.Lerp(this.light.intensity, this.<defaultIntensity>__0, UnityEngine.Time.deltaTime * 10f);
                this.$current = null;
                this.$PC = 1;
                goto Label_0129;
            }
            goto Label_0120;
        Label_00FF:
            while (this.light.intensity > 0.01f)
            {
                this.light.intensity = Mathf.Lerp(this.light.intensity, 0f, UnityEngine.Time.deltaTime * 10f);
                this.$current = null;
                this.$PC = 2;
                goto Label_0129;
            }
            this.light.enabled = false;
        Label_0120:
            this.$PC = -1;
        Label_0127:
            return false;
        Label_0129:
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

    private class EndGameScreenContext
    {
        public Spell m_enemyBlowUpSpell;
        public Spell m_friendlyBlowUpSpell;

        private bool AreBlowUpSpellsFinished()
        {
            if ((this.m_enemyBlowUpSpell != null) && !this.m_enemyBlowUpSpell.IsFinished())
            {
                return false;
            }
            if ((this.m_friendlyBlowUpSpell != null) && !this.m_friendlyBlowUpSpell.IsFinished())
            {
                return false;
            }
            return true;
        }

        private void OnBlowUpSpellFinished(Spell spell, object userData)
        {
            EndGameScreen screen = (EndGameScreen) userData;
            if (this.AreBlowUpSpellsFinished())
            {
                screen.Show();
            }
        }

        public void ShowScreen(EndGameScreen screen)
        {
            bool flag = false;
            if ((this.m_enemyBlowUpSpell != null) && !this.m_enemyBlowUpSpell.IsFinished())
            {
                flag = true;
                this.m_enemyBlowUpSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnBlowUpSpellFinished), screen);
            }
            if ((this.m_friendlyBlowUpSpell != null) && !this.m_friendlyBlowUpSpell.IsFinished())
            {
                flag = true;
                this.m_friendlyBlowUpSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnBlowUpSpellFinished), screen);
            }
            if (!flag)
            {
                screen.Show();
            }
        }
    }
}


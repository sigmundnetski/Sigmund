using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int m_activeDeathSpellCount;
    protected Actor m_actor;
    private bool m_actorLoading;
    protected string m_actorName;
    private bool m_actorReady = true;
    protected Actor m_actorWaitingToBeReplaced;
    protected AudioSource m_announcerLine;
    protected bool m_attacking;
    protected Spell m_attackSpell;
    protected Spell m_battlecrySpell;
    protected Actor m_bigCardActor;
    protected CardDef m_cardDef;
    protected Spell m_deathSpell;
    private bool m_doNotSort;
    private bool m_doNotWarpToNewZone;
    protected List<EmoteEntry> m_emotes;
    protected Entity m_entity;
    private bool m_isBattleCrySource;
    protected bool m_mousedOver;
    protected bool m_mousedOverByOpponent;
    protected bool m_overPlayfield;
    protected Spell m_playSpell;
    protected bool m_shouldShowTooltip;
    protected bool m_shown = true;
    protected bool m_showTooltip;
    private bool m_slowTransition;
    protected List<Spell> m_subOptionSpells;
    private bool m_suppressDamageSplat;
    private bool m_transitioningZones;
    protected List<Spell> m_triggerSpells;
    private bool m_verySlowTransition;
    protected Zone m_zone;
    private static Card s_cardBeingDrawn;
    private static Card s_enemyCardBeingDrawn;

    private Spell ActivateActorDeathSpell(Actor actor, bool destroy)
    {
        Spell.StateFinishedCallback stateFinishedCallback = null;
        if (destroy)
        {
            stateFinishedCallback = new Spell.StateFinishedCallback(this.OnSpellStateFinished_DestroyActor);
        }
        Spell spell = this.ActivateActorSpell(actor, SpellType.DEATH, new Spell.FinishedCallback(this.OnSpellFinished_Death), stateFinishedCallback);
        if (spell == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorDeathSpell() - spell IS NULL", this));
            return null;
        }
        this.m_activeDeathSpellCount++;
        return spell;
    }

    public Spell ActivateActorSpell(SpellType spellType)
    {
        return this.ActivateActorSpell(this.m_actor, spellType, null, null);
    }

    private Spell ActivateActorSpell(Actor actor, SpellType spellType)
    {
        return this.ActivateActorSpell(actor, spellType, null, null);
    }

    private void ActivateActorSpell(Spell spell, Spell.FinishedCallback finishedCallback)
    {
        this.ActivateActorSpell(spell, finishedCallback, null, null, null);
    }

    public Spell ActivateActorSpell(SpellType spellType, Spell.FinishedCallback finishedCallback)
    {
        return this.ActivateActorSpell(this.m_actor, spellType, finishedCallback, null);
    }

    private Spell ActivateActorSpell(Actor actor, SpellType spellType, Spell.FinishedCallback finishedCallback)
    {
        return this.ActivateActorSpell(actor, spellType, finishedCallback, null);
    }

    private void ActivateActorSpell(Spell spell, Spell.FinishedCallback finishedCallback, Spell.StateFinishedCallback stateFinishedCallback)
    {
        this.ActivateActorSpell(spell, finishedCallback, null, stateFinishedCallback, null);
    }

    public Spell ActivateActorSpell(SpellType spellType, Spell.FinishedCallback finishedCallback, Spell.StateFinishedCallback stateFinishedCallback)
    {
        return this.ActivateActorSpell(this.m_actor, spellType, finishedCallback, stateFinishedCallback);
    }

    private Spell ActivateActorSpell(Actor actor, SpellType spellType, Spell.FinishedCallback finishedCallback, Spell.StateFinishedCallback stateFinishedCallback)
    {
        if (actor == null)
        {
            Log.Mike.Print(string.Format("{0}.ActivateActorSpell() - actor IS NULL spellType={1}", this, spellType));
            return null;
        }
        Spell spell = actor.GetSpell(spellType);
        if (spell == null)
        {
            Log.Mike.Print(string.Format("{0}.ActivateActorSpell() - spell IS NULL actor={1} spellType={2}", this, actor, spellType));
            return null;
        }
        this.ActivateActorSpell(spell, finishedCallback, stateFinishedCallback);
        return spell;
    }

    private void ActivateActorSpell(Spell spell, Spell.FinishedCallback finishedCallback, object finishedUserData, Spell.StateFinishedCallback stateFinishedCallback)
    {
        this.ActivateActorSpell(spell, finishedCallback, finishedUserData, stateFinishedCallback, null);
    }

    private void ActivateActorSpell(Spell spell, Spell.FinishedCallback finishedCallback, object finishedUserData, Spell.StateFinishedCallback stateFinishedCallback, object stateFinishedUserData)
    {
        if (finishedCallback != null)
        {
            spell.AddFinishedCallback(finishedCallback, finishedUserData);
        }
        if (stateFinishedCallback != null)
        {
            spell.AddStateFinishedCallback(stateFinishedCallback, stateFinishedUserData);
        }
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            spell.Activate();
        }
    }

    private bool ActivateActorSpells_HandToPlay(Actor oldActor)
    {
        if (oldActor == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToPlay() - oldActor=null", this));
            return false;
        }
        if (this.m_cardDef == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToPlay() - m_cardDef=null", this));
            return false;
        }
        if (this.m_actor == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToPlay() - m_actor=null", this));
            return false;
        }
        SpellType spellType = this.m_cardDef.DetermineSummonOutSpell_HandToPlay(this);
        Spell spell = oldActor.LoadSpell(spellType);
        if (spell == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToPlay() - outSpell=null outSpellType={1}", this, spellType));
            return false;
        }
        SpellType type2 = this.m_cardDef.DetermineSummonInSpell_HandToPlay(this);
        Spell finishedUserData = this.m_actor.LoadSpell(type2);
        if (finishedUserData == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToPlay() - inSpell=null inSpellType={1}", this, type2));
            return false;
        }
        this.ActivateActorSpell(spell, new Spell.FinishedCallback(this.OnSpellFinished_HandToPlay_SummonOut), finishedUserData, new Spell.StateFinishedCallback(this.OnSpellStateFinished_DestroyActor));
        return true;
    }

    private bool ActivateActorSpells_HandToWeapon(Actor oldActor)
    {
        if (oldActor == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToWeapon() - oldActor=null", this));
            return false;
        }
        if (this.m_cardDef == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToWeapon() - m_cardDef=null", this));
            return false;
        }
        if (this.m_actor == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToWeapon() - m_actor=null", this));
            return false;
        }
        SpellType spellType = SpellType.SUMMON_OUT_WEAPON;
        Spell spell = oldActor.LoadSpell(spellType);
        if (spell == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToWeapon() - outSpell=null outSpellType={1}", this, spellType));
            return false;
        }
        SpellType type2 = !this.m_entity.IsControlledByLocalPlayer() ? SpellType.SUMMON_IN_OPPONENT : SpellType.SUMMON_IN_FRIENDLY;
        Spell finishedUserData = this.m_actor.LoadSpell(type2);
        if (finishedUserData == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToWeapon() - inSpell=null inSpellType={1}", this, type2));
            return false;
        }
        this.ActivateActorSpell(spell, new Spell.FinishedCallback(this.OnSpellFinished_HandToWeapon_SummonOut), finishedUserData, new Spell.StateFinishedCallback(this.OnSpellStateFinished_DestroyActor));
        return true;
    }

    private bool ActivateActorSpells_PlayToHand(Actor oldActor)
    {
        if (oldActor == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_PlayToHand() - oldActor=null", this));
            return false;
        }
        if (this.m_cardDef == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_PlayToHand() - m_cardDef=null", this));
            return false;
        }
        if (this.m_actor == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_PlayToHand() - m_actor=null", this));
            return false;
        }
        SpellType spellType = SpellType.SUMMON_OUT;
        Spell spell = oldActor.LoadSpell(spellType);
        if (spell == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToWeapon() - outSpell=null outSpellType={1}", this, spellType));
            return false;
        }
        SpellType type2 = SpellType.SUMMON_IN;
        Spell finishedUserData = this.m_actor.LoadSpell(type2);
        if (finishedUserData == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSpells_HandToWeapon() - inSpell=null inSpellType={1}", this, type2));
            return false;
        }
        if (this.m_entity.GetController().IsLocal())
        {
            this.ActivateActorSpell(spell, new Spell.FinishedCallback(this.OnSpellFinished_PlayToHand_SummonOut), finishedUserData, new Spell.StateFinishedCallback(this.OnSpellStateFinished_DestroyActor));
        }
        else
        {
            this.ActivateActorSpell(spell, null, null, new Spell.StateFinishedCallback(this.OnSpellStateFinished_DestroyActor));
            this.ActivateActorSpell(finishedUserData, new Spell.FinishedCallback(this.OnSpellFinished_RefreshActor));
        }
        return true;
    }

    [DebuggerHidden]
    private IEnumerator ActivateBattlecrySpell()
    {
        return new <ActivateBattlecrySpell>c__IteratorD2 { <>f__this = this };
    }

    private void ActivateCardPlaySpell()
    {
        Spell playSpell = this.GetPlaySpell();
        if (playSpell != null)
        {
            playSpell.Deactivate();
            playSpell.ActivateState(SpellStateType.BIRTH);
        }
    }

    private void ActivateCreatorSpawnMinionSpell()
    {
        if (this.m_entity.GetController().IsLocal())
        {
            this.ActivateActorSpell(SpellType.FRIENDLY_SPAWN_MINION);
        }
        else
        {
            this.ActivateActorSpell(SpellType.OPPONENT_SPAWN_MINION);
        }
    }

    [DebuggerHidden]
    private IEnumerator ActivateCreatorSpawnSpell(Entity creator)
    {
        return new <ActivateCreatorSpawnSpell>c__IteratorD0 { creator = creator, <$>creator = creator, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator ActivateReviveSpell()
    {
        return new <ActivateReviveSpell>c__IteratorD1 { <>f__this = this };
    }

    private void ActivateSpawnMinionSpell()
    {
        if (this.m_entity.GetController().IsLocal())
        {
            this.ActivateActorSpell(SpellType.FRIENDLY_SPAWN_MINION, new Spell.FinishedCallback(this.OnSpellFinished_SpawnMinion));
        }
        else
        {
            this.ActivateActorSpell(SpellType.OPPONENT_SPAWN_MINION, new Spell.FinishedCallback(this.OnSpellFinished_SpawnMinion));
        }
        this.ActivateCardPlaySpell();
    }

    private Spell ActivateSpawnWeaponSpell(Actor actor)
    {
        SpellType spellType = !this.m_entity.IsControlledByLocalPlayer() ? SpellType.SUMMON_IN_OPPONENT : SpellType.SUMMON_IN_FRIENDLY;
        Spell spell = this.ActivateActorSpell(actor, spellType, new Spell.FinishedCallback(this.OnSpellFinished_RefreshActor));
        if (spell == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.ActivateActorSummonInSpell_Weapon() - spell=null spellType=", this, spellType));
            return null;
        }
        return spell;
    }

    private void CancelActiveSpell(Spell spell)
    {
        if (spell != null)
        {
            switch (spell.GetActiveState())
            {
                case SpellStateType.NONE:
                    return;

                case SpellStateType.CANCEL:
                    return;
            }
            spell.ActivateState(SpellStateType.CANCEL);
        }
    }

    private void CancelActiveSpellList(List<Spell> spells)
    {
        if (spells != null)
        {
            for (int i = 0; i < spells.Count; i++)
            {
                this.CancelActiveSpell(spells[i]);
            }
        }
    }

    public void CancelActiveSpells()
    {
        this.CancelActiveSpell(this.m_playSpell);
        this.CancelActiveSpellList(this.m_triggerSpells);
    }

    private bool CanShowActorVisuals()
    {
        if (!this.m_entity.IsCardReady())
        {
            return false;
        }
        if (this.m_actor == null)
        {
            return false;
        }
        if (!this.m_actor.IsShown())
        {
            return false;
        }
        return true;
    }

    public void CreateStartingCardStateEffects()
    {
        if (this.m_entity.HasTaunt())
        {
            this.m_actor.ActivateTaunt();
        }
        if (this.m_entity.IsStealthed())
        {
            this.m_actor.ActivateSpell(SpellType.STEALTH);
        }
        else if ((this.m_entity.HasTag(GAME_TAG.CANT_BE_TARGETED_BY_OPPONENTS) || this.m_entity.HasTag(GAME_TAG.CANT_BE_TARGETED_BY_ABILITIES)) || this.m_entity.HasTag(GAME_TAG.CANT_BE_TARGETED_BY_HERO_POWERS))
        {
            this.m_actor.ActivateSpell(SpellType.UNTARGETABLE);
        }
        if (this.m_entity.HasDivineShield())
        {
            this.m_actor.ActivateSpell(SpellType.DIVINE_SHIELD);
        }
        if (this.m_entity.HasSpellPower())
        {
            this.m_actor.ActivateSpell(SpellType.SPELL_POWER);
        }
        if (this.m_entity.IsImmune())
        {
            this.m_actor.ActivateSpell(SpellType.IMMUNE);
        }
        if (this.m_entity.HasHealthMin())
        {
            this.m_actor.ActivateSpell(SpellType.SHOUT_BUFF);
        }
        if (this.m_entity.IsAsleep())
        {
            this.m_actor.ActivateSpell(SpellType.Zzz);
        }
        if (this.m_entity.IsEnraged())
        {
            this.m_actor.ActivateSpell(SpellType.ENRAGE);
        }
        if (this.m_entity.HasWindfury())
        {
            Spell spell = this.m_actor.GetSpell(SpellType.WINDFURY_IDLE);
            if (spell != null)
            {
                spell.ActivateState(SpellStateType.BIRTH);
            }
        }
        if (this.m_entity.HasDeathrattle())
        {
            this.m_actor.ActivateSpell(SpellType.DEATHRATTLE_IDLE);
        }
        if (this.m_entity.IsSilenced())
        {
            this.m_actor.ActivateSpell(SpellType.SILENCE);
        }
        if (this.m_entity.HasTriggerVisual())
        {
            this.m_actor.ActivateSpell(SpellType.TRIGGER);
        }
        if (this.m_entity.IsWeapon())
        {
            if (this.m_entity.IsExhausted())
            {
                this.SheatheWeapon();
            }
            else
            {
                this.UnSheatheWeapon();
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator DelayedActorSetup(string actorName, Actor actor, Zone oldZone)
    {
        return new <DelayedActorSetup>c__IteratorD5 { actorName = actorName, actor = actor, oldZone = oldZone, <$>actorName = actorName, <$>actor = actor, <$>oldZone = oldZone, <>f__this = this };
    }

    public void Destroy()
    {
        if (this.m_actor != null)
        {
            this.m_actor.Destroy();
        }
        this.DestroySpells();
        SceneUtils.Destroy(base.gameObject);
    }

    private void DestroyEmoteList(List<EmoteEntry> emotes)
    {
        if (emotes != null)
        {
            for (int i = 0; i < emotes.Count; i++)
            {
                if (emotes[i].m_emoteSpell != null)
                {
                    this.DestroySpell(emotes[i].m_emoteSpell);
                }
            }
        }
    }

    private void DestroySpell(Spell spell)
    {
        if (spell != null)
        {
            UnityEngine.Object.Destroy(spell.gameObject);
        }
    }

    private void DestroySpellList(List<Spell> spells)
    {
        if (spells != null)
        {
            for (int i = 0; i < spells.Count; i++)
            {
                this.DestroySpell(spells[i]);
            }
        }
    }

    private void DestroySpells()
    {
        this.DestroySpell(this.m_playSpell);
        this.m_playSpell = null;
        this.DestroySpell(this.m_battlecrySpell);
        this.m_battlecrySpell = null;
        this.DestroySpellList(this.m_triggerSpells);
        this.m_triggerSpells = null;
        this.DestroySpellList(this.m_subOptionSpells);
        this.m_subOptionSpells = null;
        this.DestroySpell(this.m_deathSpell);
        this.m_deathSpell = null;
        this.DestroySpell(this.m_attackSpell);
        this.m_attackSpell = null;
        this.DestroyEmoteList(this.m_emotes);
        this.m_emotes = null;
    }

    private void DetermineActorThenTransitionToZone(Zone oldZone)
    {
        string actorName = this.m_cardDef.DetermineActorNameForZone(this.m_entity, this.m_zone.m_ServerTag);
        if ((this.m_actorName == actorName) || (actorName == null))
        {
            this.m_actorName = actorName;
            this.m_actorLoading = false;
            this.OnZoneChanged(oldZone);
            this.OnActorChanged(oldZone, this.m_actor);
            this.UpdateActorState();
            this.UpdateTooltip();
        }
        else
        {
            AssetLoader.Get().LoadActor(actorName, new AssetLoader.GameObjectCallback(this.OnActorLoaded), oldZone);
        }
    }

    public void DoCardDiscardAnimation(Actor actor)
    {
        this.m_doNotSort = true;
        iTween.Stop(base.gameObject);
        float num = 3f;
        if (!this.GetEntity().IsControlledByLocalPlayer())
        {
            num = -num;
        }
        Vector3 position = new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z + num);
        iTween.MoveTo(base.gameObject, position, 3f);
        iTween.ScaleTo(base.gameObject, (Vector3) (base.transform.localScale * 1.5f), 3f);
        base.StartCoroutine(this.PlayDiscardAnimationAfterDelay(actor));
    }

    public void DoCardDrawAnimation()
    {
        base.StartCoroutine(this.DrawCardInSequence());
    }

    private bool DoChoiceHighlight(GameState state)
    {
        if (state.GetChosenEntities().Contains(this.m_entity))
        {
            if (this.m_mousedOver)
            {
                this.m_actor.SetActorState(ActorStateType.CARD_PLAYABLE_MOUSE_OVER);
            }
            else
            {
                this.m_actor.SetActorState(ActorStateType.CARD_SELECTED);
            }
            return true;
        }
        int entityId = this.m_entity.GetEntityId();
        if (!state.GetChoicePacket().Entities.Contains(entityId))
        {
            return false;
        }
        if (GameState.Get().IsMulliganPhase())
        {
            this.m_actor.SetActorState(ActorStateType.CARD_IDLE);
        }
        else
        {
            this.m_actor.SetActorState(ActorStateType.CARD_SELECTABLE);
        }
        return true;
    }

    private void DoEnemyCardDrawAnimation()
    {
        base.StartCoroutine(this.DrawEnemyCardInSequence());
    }

    private bool DoOptionHighlight(GameState state)
    {
        if (!GameState.Get().IsOption(this.m_entity))
        {
            return false;
        }
        bool flag = GameState.Get().GetPlayer(this.m_entity.GetControllerId()).ComboIsActive();
        if (this.m_mousedOver && (this.m_entity.GetZone() != TAG_ZONE.HAND))
        {
            this.m_actor.SetActorState(ActorStateType.CARD_PLAYABLE_MOUSE_OVER);
        }
        else if ((this.m_entity.HasTag(GAME_TAG.COMBO) && flag) && (this.m_entity.GetZone() == TAG_ZONE.HAND))
        {
            this.m_actor.SetActorState(ActorStateType.CARD_COMBO);
        }
        else
        {
            this.m_actor.SetActorState(ActorStateType.CARD_PLAYABLE);
        }
        return true;
    }

    private bool DoOptionTargetHighlight(GameState state)
    {
        Network.Options.Option.SubOption selectedNetworkSubOption = state.GetSelectedNetworkSubOption();
        int entityId = this.m_entity.GetEntityId();
        if (!selectedNetworkSubOption.Targets.Contains(entityId))
        {
            return false;
        }
        if (this.m_mousedOver)
        {
            this.m_actor.SetActorState(ActorStateType.CARD_VALID_TARGET_MOUSE_OVER);
        }
        else
        {
            this.m_actor.SetActorState(ActorStateType.CARD_VALID_TARGET);
        }
        return true;
    }

    private bool DoSubOptionHighlight(GameState state)
    {
        Network.Options.Option selectedNetworkOption = state.GetSelectedNetworkOption();
        int entityId = this.m_entity.GetEntityId();
        foreach (Network.Options.Option.SubOption option2 in selectedNetworkOption.Subs)
        {
            if (entityId != option2.ID)
            {
                continue;
            }
            if (this.m_mousedOver)
            {
                this.m_actor.SetActorState(ActorStateType.CARD_PLAYABLE_MOUSE_OVER);
            }
            else
            {
                this.m_actor.SetActorState(ActorStateType.CARD_PLAYABLE);
            }
            return true;
        }
        return false;
    }

    public void DoTauntNotification()
    {
        iTween.PunchScale(this.GetActor().gameObject, new Vector3(0.2f, 0.2f, 0.2f), 0.5f);
    }

    public void DoVisualUntap(bool tap)
    {
        if (this.m_entity.IsHeroPower())
        {
            base.StopCoroutine("PlayHeroPowerAnimation");
            if (tap)
            {
                base.StartCoroutine("PlayHeroPowerAnimation", "HeroPower_Used");
            }
            else
            {
                base.StartCoroutine("PlayHeroPowerAnimation", "HeroPower_Restore");
            }
        }
        else if (this.m_entity.IsWeapon())
        {
            if (tap)
            {
                this.SheatheWeapon();
            }
            else
            {
                this.UnSheatheWeapon();
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator DrawCardInSequence()
    {
        return new <DrawCardInSequence>c__IteratorD8 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator DrawEnemyCardInSequence()
    {
        return new <DrawEnemyCardInSequence>c__IteratorD7 { <>f__this = this };
    }

    public void EnableAttacking(bool enable)
    {
        this.m_attacking = enable;
    }

    public void EnableTransitioningZones(bool enable)
    {
        this.m_transitioningZones = enable;
    }

    private void FinishChangingActors()
    {
        if (!this.m_actorReady)
        {
            if (this.m_actorWaitingToBeReplaced != null)
            {
                this.m_actorWaitingToBeReplaced.Destroy();
                this.m_actorWaitingToBeReplaced = null;
            }
            this.m_actor.Show();
            this.m_actor.TurnOffCollider();
            this.m_doNotSort = false;
            this.m_actorReady = true;
            this.RefreshActor();
            this.m_zone.UpdateLayout();
            s_cardBeingDrawn = null;
        }
    }

    public void ForceActorLoadForChoiceDisplay()
    {
        string actorName = this.m_cardDef.DetermineActorNameForZone(this.m_entity, TAG_ZONE.HAND);
        if ((this.m_actor != null) && (this.m_actorName == actorName))
        {
            this.RefreshActor();
        }
        else
        {
            this.m_actorReady = false;
            this.m_actorLoading = true;
            AssetLoader.Get().LoadActor(actorName, new AssetLoader.GameObjectCallback(this.OnActorForceLoaded), this.m_zone);
        }
    }

    public void ForceActorLoadForSubOptionDisplay()
    {
        if (this.m_actor != null)
        {
            this.ShowCard();
            this.m_actor.Show();
            this.RefreshActor();
        }
        else
        {
            this.m_actorReady = false;
            this.m_actorLoading = true;
            AssetLoader.Get().LoadActor("Card_Hand_Ability", new AssetLoader.GameObjectCallback(this.OnActorForceLoaded), this.m_zone);
        }
    }

    public Actor GetActor()
    {
        return this.m_actor;
    }

    public Spell GetActorAttackSpellForInput()
    {
        if (this.m_actor == null)
        {
            object[] args = new object[] { this };
            Log.Mike.Print("{0}.GetActorAttackSpellForInput() - m_actor IS NULL", args);
            return null;
        }
        if (this.m_zone == null)
        {
            object[] objArray2 = new object[] { this };
            Log.Mike.Print("{0}.GetActorAttackSpellForInput() - m_zone IS NULL", objArray2);
            return null;
        }
        Spell spell = this.m_actor.GetSpell(SpellType.FRIENDLY_ATTACK);
        if (spell == null)
        {
            object[] objArray3 = new object[] { this, SpellType.FRIENDLY_ATTACK };
            Log.Mike.Print("{0}.GetActorAttackSpellForInput() - {1} spell is null", objArray3);
            return null;
        }
        return spell;
    }

    public string GetActorName()
    {
        return this.m_actorName;
    }

    public Spell GetActorSpell(SpellType spellType)
    {
        if (this.m_actor == null)
        {
            Log.Mike.Print(string.Format("{0}.GetActorSpell() - m_actor IS NULL", this));
            return null;
        }
        Spell spell = this.m_actor.GetSpell(spellType);
        if (spell == null)
        {
            return null;
        }
        return spell;
    }

    public AudioSource GetAnnouncerLine()
    {
        return this.m_announcerLine;
    }

    public Spell GetAttackSpell()
    {
        return this.m_attackSpell;
    }

    public Spell GetBattlecrySpell()
    {
        return this.m_battlecrySpell;
    }

    public CardDef GetCardDef()
    {
        return this.m_cardDef;
    }

    public CardFlair GetCardFlair()
    {
        if (this.m_entity == null)
        {
            return null;
        }
        return this.m_entity.GetCardFlair();
    }

    public Player GetController()
    {
        if (this.m_entity == null)
        {
            return null;
        }
        return this.m_entity.GetController();
    }

    public Spell GetDeathSpell()
    {
        return this.m_deathSpell;
    }

    public Spell GetEmoteSpell(EmoteType emoteType)
    {
        if (this.m_emotes != null)
        {
            foreach (EmoteEntry entry in this.m_emotes)
            {
                if (entry.m_emoteType == emoteType)
                {
                    return entry.m_emoteSpell;
                }
            }
        }
        return null;
    }

    public Entity GetEntity()
    {
        return this.m_entity;
    }

    public Material GetGoldenMaterial()
    {
        return ((this.m_cardDef != null) ? this.m_cardDef.m_PremiumPortraitMaterial : null);
    }

    public Spell GetPlaySpell()
    {
        return this.m_playSpell;
    }

    public Texture GetPortraitTexture()
    {
        return ((this.m_cardDef != null) ? this.m_cardDef.m_PortraitTexture : null);
    }

    public bool GetShouldShowTooltip()
    {
        return this.m_shouldShowTooltip;
    }

    public Spell GetSubOptionSpell(int index)
    {
        if (this.m_subOptionSpells == null)
        {
            return null;
        }
        if (index < 0)
        {
            return null;
        }
        if (index >= this.m_subOptionSpells.Count)
        {
            return null;
        }
        return this.m_subOptionSpells[index];
    }

    public Spell GetTriggerSpell(int index)
    {
        if (this.m_triggerSpells == null)
        {
            return null;
        }
        if (index < 0)
        {
            return null;
        }
        if (index >= this.m_triggerSpells.Count)
        {
            return null;
        }
        return this.m_triggerSpells[index];
    }

    public Zone GetZone()
    {
        return this.m_zone;
    }

    public void HideCard()
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            this.HideImpl();
        }
    }

    private void HideImpl()
    {
        if (this.m_actor != null)
        {
            this.m_actor.Hide();
        }
    }

    public void HideTooltip()
    {
        this.m_shouldShowTooltip = false;
        if (this.m_showTooltip)
        {
            this.m_showTooltip = false;
            this.UpdateTooltip();
            KeywordHelpPanelManager.Get().HideKeywordHelp();
        }
    }

    private void InitActor(string actorName, Actor actor, Zone oldZone)
    {
        Actor oldActor = this.m_actor;
        this.m_actor = actor;
        this.m_actorName = actorName;
        this.m_actor.SetEntity(this.m_entity);
        this.m_actor.SetCard(this);
        this.m_actor.SetCardDef(this.m_cardDef);
        this.m_actor.UpdateAllComponents();
        this.m_actorLoading = false;
        this.OnZoneChanged(oldZone);
        this.OnActorChanged(oldZone, oldActor);
        if (this.m_isBattleCrySource)
        {
            SceneUtils.SetLayer(actor.gameObject, GameLayer.IgnoreFullScreenEffects);
        }
        this.RefreshActor();
    }

    private void InitEmoteList(List<EmoteEntryDef> emoteDefs, ref List<EmoteEntry> emotes)
    {
        if ((emoteDefs != null) && (emoteDefs.Count != 0))
        {
            emotes = new List<EmoteEntry>();
            for (int i = 0; i < emoteDefs.Count; i++)
            {
                EmoteEntry item = new EmoteEntry {
                    m_emoteType = emoteDefs[i].m_emoteType
                };
                emotes.Add(item);
            }
        }
    }

    private void InitSpellList(List<string> spellPaths, ref List<Spell> spells)
    {
        if ((spellPaths != null) && (spellPaths.Count != 0))
        {
            spells = new List<Spell>();
            for (int i = 0; i < spellPaths.Count; i++)
            {
                spells.Add(null);
            }
        }
    }

    private void InitSpells()
    {
        this.DestroySpells();
        this.InitSpellList(this.m_cardDef.m_TriggerSpellPaths, ref this.m_triggerSpells);
        this.InitSpellList(this.m_cardDef.m_SubOptionSpellPaths, ref this.m_subOptionSpells);
        this.InitEmoteList(this.m_cardDef.m_EmoteDefs, ref this.m_emotes);
    }

    public bool IsAbleToShowTooltip()
    {
        if (this.m_entity == null)
        {
            return false;
        }
        if (this.m_actor == null)
        {
            return false;
        }
        if (BigCard.Get() == null)
        {
            return false;
        }
        return true;
    }

    public bool IsActorLoading()
    {
        return this.m_actorLoading;
    }

    public bool IsActorReady()
    {
        return this.m_actorReady;
    }

    public bool IsAllowedToShowTooltip()
    {
        if (this.m_zone == null)
        {
            return false;
        }
        if (((this.m_zone.m_ServerTag != TAG_ZONE.PLAY) && (this.m_zone.m_ServerTag != TAG_ZONE.SECRET)) && ((this.m_zone.m_ServerTag == TAG_ZONE.HAND) && (this.m_zone.m_Side != Player.Side.OPPOSING)))
        {
            return false;
        }
        if (((GameState.Get() != null) && !GameState.Get().GetGameEntity().ShouldShowHeroTooltips()) && this.m_entity.IsHero())
        {
            return false;
        }
        return true;
    }

    public bool IsAttacking()
    {
        return this.m_attacking;
    }

    public bool IsDoNotSort()
    {
        return this.m_doNotSort;
    }

    public bool IsMousedOver()
    {
        return this.m_mousedOver;
    }

    public bool IsShown()
    {
        return this.m_shown;
    }

    public bool IsSlowTransition()
    {
        return this.m_slowTransition;
    }

    public bool IsTransitioningZones()
    {
        return this.m_transitioningZones;
    }

    public bool IsVerySlowTransition()
    {
        return this.m_verySlowTransition;
    }

    public void LoadAnnouncerLine(AudioSource sound)
    {
        this.m_announcerLine = this.SetupSound(sound);
    }

    public void LoadAttackSpell(Spell spell)
    {
        this.m_attackSpell = this.SetupSpell(SpellType.ATTACK, spell);
    }

    public void LoadBattlecrySpell(Spell spell)
    {
        this.m_battlecrySpell = this.SetupSpell(SpellType.BATTLECRY, spell);
    }

    public void LoadCardDef(CardDef cardDef)
    {
        if (this.m_cardDef != cardDef)
        {
            this.m_cardDef = cardDef;
            this.InitSpells();
            if (this.m_actor != null)
            {
                this.m_actor.SetCardDef(this.m_cardDef);
                this.m_actor.UpdateAllComponents();
            }
        }
    }

    public void LoadDeathSpell(Spell spell)
    {
        this.m_deathSpell = this.SetupSpell(SpellType.DEATH, spell);
    }

    public void LoadEmoteSpell(EmoteType emoteType, Spell spell)
    {
        foreach (EmoteEntry entry in this.m_emotes)
        {
            if (entry.m_emoteType == emoteType)
            {
                entry.m_emoteSpell = this.SetupSpell(SpellType.EMOTE, spell);
            }
        }
    }

    public void LoadPlaySpell(Spell spell)
    {
        this.m_playSpell = this.SetupSpell(SpellType.PLAY, spell);
    }

    public void LoadSubOptionSpell(int index, Spell spell)
    {
        if (this.m_entity.IsCharacter())
        {
            this.m_subOptionSpells[index] = this.SetupSpell(SpellType.BATTLECRY, spell);
        }
        else
        {
            this.m_subOptionSpells[index] = this.SetupSpell(SpellType.PLAY, spell);
        }
    }

    public void LoadTriggerSpell(int index, Spell spell)
    {
        this.m_triggerSpells[index] = this.SetupSpell(SpellType.TRIGGER, spell);
    }

    public void NotifyLeftPlayfield()
    {
        this.m_overPlayfield = false;
        this.UpdateActorState();
    }

    public void NotifyMousedOut()
    {
        this.m_mousedOver = false;
        this.UpdateActorState();
        this.UpdateProposedManaUsage();
        if (EnemyActionHandler.Get() != null)
        {
            EnemyActionHandler.Get().NotifyOpponentOfMouseOut();
        }
        if (KeywordHelpPanelManager.Get() != null)
        {
            KeywordHelpPanelManager.Get().HideKeywordHelp();
        }
        if (GameState.Get() != null)
        {
            GameState.Get().GetGameEntity().NotifyOfCardMousedOff(this.GetEntity());
        }
        if ((this.m_entity.HasSpellPower() && this.m_entity.IsControlledByLocalPlayer()) && ((this.m_zone is ZonePlay) && !this.m_transitioningZones))
        {
            ZoneMgr.Get().FindZoneOfType<ZoneHand>(TAG_ZONE.HAND, this.m_zone.m_Side).OnSpellPowerEntityMousedOut();
        }
        if (this.m_entity.IsWeapon() && this.m_entity.IsExhausted())
        {
            this.GetActor().GetAttackObject().ScaleToZero();
        }
    }

    public void NotifyMousedOver()
    {
        this.m_mousedOver = true;
        this.UpdateActorState();
        this.UpdateProposedManaUsage();
        if ((EnemyActionHandler.Get() != null) && (TargetReticleManager.Get() != null))
        {
            EnemyActionHandler.Get().NotifyOpponentOfMouseOverEntity(this.GetEntity().GetCard());
        }
        if (GameState.Get() != null)
        {
            GameState.Get().GetGameEntity().NotifyOfCardMousedOver(this.GetEntity());
        }
        if (this.m_zone is ZoneHand)
        {
            Spell actorSpell = this.GetActorSpell(SpellType.SPELL_POWER_HINT_BURST);
            if (actorSpell != null)
            {
                actorSpell.Deactivate();
            }
            Spell spell2 = this.GetActorSpell(SpellType.SPELL_POWER_HINT_IDLE);
            if (spell2 != null)
            {
                spell2.Deactivate();
            }
            if (GameState.Get().IsMulliganPhase())
            {
                SoundManager.Get().LoadAndPlay("collection_manager_card_mouse_over", base.gameObject);
            }
        }
        if ((this.m_entity.HasSpellPower() && this.m_entity.IsControlledByLocalPlayer()) && ((this.m_zone is ZonePlay) && !this.m_transitioningZones))
        {
            Spell spell3 = this.GetActorSpell(SpellType.SPELL_POWER_HINT_BURST);
            if (spell3 != null)
            {
                spell3.Reactivate();
            }
            ZoneMgr.Get().FindZoneOfType<ZoneHand>(TAG_ZONE.HAND, this.m_zone.m_Side).OnSpellPowerEntityMousedOver();
        }
        if (this.m_entity.IsWeapon() && this.m_entity.IsExhausted())
        {
            this.GetActor().GetAttackObject().Enlarge(1f);
        }
    }

    public void NotifyOpponentMousedOffThisCard()
    {
        this.m_mousedOverByOpponent = false;
        this.UpdateActorState();
    }

    public void NotifyOpponentMousedOverThisCard()
    {
        this.m_mousedOverByOpponent = true;
        this.UpdateActorState();
    }

    public void NotifyOverPlayfield()
    {
        this.m_overPlayfield = true;
        this.UpdateActorState();
    }

    public void NotifyPickedUp()
    {
        this.m_transitioningZones = false;
        this.FinishChangingActors();
    }

    public void NotifyTargetingCanceled()
    {
        SpellStateType activeState;
        if (this.m_entity.IsHeroPower() || this.m_entity.IsAbility())
        {
            Spell playSpell = this.GetPlaySpell();
            if (playSpell != null)
            {
                activeState = playSpell.GetActiveState();
                if ((activeState != SpellStateType.NONE) && (activeState != SpellStateType.CANCEL))
                {
                    playSpell.ActivateState(SpellStateType.CANCEL);
                }
            }
            if (this.m_entity.IsAbility())
            {
                Spell actorSpell = this.GetActorSpell(SpellType.POWER_UP);
                if ((actorSpell != null) && (actorSpell.GetActiveState() != SpellStateType.CANCEL))
                {
                    actorSpell.ActivateState(SpellStateType.CANCEL);
                }
            }
        }
        else if (this.m_entity.IsCharacter() && !this.IsAttacking())
        {
            Spell actorAttackSpellForInput = this.GetActorAttackSpellForInput();
            if (actorAttackSpellForInput != null)
            {
                activeState = actorAttackSpellForInput.GetActiveState();
                if ((activeState != SpellStateType.NONE) && (activeState != SpellStateType.CANCEL))
                {
                    actorAttackSpellForInput.ActivateState(SpellStateType.CANCEL);
                }
            }
        }
    }

    private void OnActorChanged(Zone oldZone, Actor oldActor)
    {
        if (oldActor == this.m_actor)
        {
            this.m_actorReady = true;
        }
        else
        {
            bool flag = false;
            if (oldActor == null)
            {
                if ((this.m_zone is ZoneHand) && GameState.Get().IsMulliganPhase())
                {
                    ZoneMgr.Get().FindZoneOfType<ZoneDeck>(TAG_ZONE.DECK, this.m_zone.m_Side).SetCardToInDeckState(this);
                    this.GetActor().TurnOffCollider();
                    flag = true;
                }
                else if (!this.m_doNotWarpToNewZone)
                {
                    TransformUtil.CopyWorld((Component) base.transform, (Component) this.m_zone.transform);
                }
                if (this.m_zone is ZonePlay)
                {
                    if (oldZone == null)
                    {
                        if (this.m_entity.GetTag(GAME_TAG.LINKEDCARD) > 0)
                        {
                            this.OnSpellFinished_SpawnMinion(null, null);
                        }
                        else
                        {
                            this.m_actor.Hide();
                            Entity creator = this.m_entity.GetCreator();
                            if ((creator == null) || (creator.GetCard() == null))
                            {
                                this.ActivateSpawnMinionSpell();
                            }
                            else
                            {
                                base.StartCoroutine(this.ActivateCreatorSpawnSpell(creator));
                            }
                        }
                        flag = true;
                    }
                }
                else if (((oldZone == null) && (this.m_zone.m_ServerTag == TAG_ZONE.PLAY)) && (GameState.Get().IsMainPhase() && this.IsShown()))
                {
                    if (this.m_entity.IsHeroPower())
                    {
                        this.CreateStartingCardStateEffects();
                        this.ActivateActorSpell(SpellType.SUMMON_IN);
                        flag = true;
                        this.m_actorReady = true;
                    }
                    else if (this.m_entity.IsWeapon())
                    {
                        this.CreateStartingCardStateEffects();
                        this.ActivateSpawnWeaponSpell(this.m_actor);
                        flag = true;
                    }
                }
            }
            else if ((oldZone is ZoneHand) && (this.m_zone is ZonePlay))
            {
                if (this.ActivateActorSpells_HandToPlay(oldActor))
                {
                    this.ActivateCardPlaySpell();
                    this.m_actor.Hide();
                    flag = true;
                }
            }
            else if ((oldZone is ZoneHand) && (this.m_zone is ZoneWeapon))
            {
                if (this.ActivateActorSpells_HandToWeapon(oldActor))
                {
                    this.m_actor.Hide();
                    flag = true;
                }
            }
            else if ((oldZone is ZonePlay) && (this.m_zone is ZoneHand))
            {
                if (this.ActivateActorSpells_PlayToHand(oldActor))
                {
                    this.m_actor.Hide();
                    flag = true;
                }
            }
            else if (((oldZone != null) && (oldZone.m_ServerTag == TAG_ZONE.PLAY)) && (this.m_zone is ZoneGraveyard))
            {
                if (oldActor.IsShown())
                {
                    base.StartCoroutine(this.PrepareForDeathAnimation(oldActor));
                    if (this.m_entity.HasDeathrattle())
                    {
                        this.ActivateActorSpell(oldActor, SpellType.DEATHRATTLE_DEATH);
                    }
                    if ((this.m_mousedOver && this.m_entity.HasSpellPower()) && (this.m_entity.IsControlledByLocalPlayer() && (oldZone is ZonePlay)))
                    {
                        ZoneMgr.Get().FindZoneOfType<ZoneHand>(TAG_ZONE.HAND, oldZone.m_Side).OnSpellPowerEntityMousedOut();
                    }
                    if (this.ActivateActorDeathSpell(oldActor, true) != null)
                    {
                        this.m_actor.Hide();
                        flag = true;
                        this.m_actorReady = true;
                    }
                }
            }
            else if ((oldZone is ZoneDeck) && (this.m_zone is ZoneHand))
            {
                if (this.m_zone.m_Side == Player.Side.FRIENDLY)
                {
                    if (GameState.Get().GameHasBegun())
                    {
                        this.m_actorWaitingToBeReplaced = oldActor;
                        oldActor.Show();
                        if (!TurnStartManager.Get().IsThisCardDrawAlreadyHandledByTurnStartManager(this))
                        {
                            this.DoCardDrawAnimation();
                        }
                        flag = true;
                    }
                    else
                    {
                        this.GetActor().TurnOffCollider();
                        this.GetActor().SetActorState(ActorStateType.CARD_IDLE);
                    }
                }
                else if (GameState.Get().GameHasBegun())
                {
                    this.DoEnemyCardDrawAnimation();
                    flag = true;
                }
            }
            else if ((oldZone is ZoneSecret) && (this.m_zone is ZoneGraveyard))
            {
                if (oldActor.IsShown())
                {
                    Spell component = oldActor.GetComponent<Spell>();
                    if (component != null)
                    {
                        flag = true;
                        this.m_actorReady = true;
                        component.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnSpellStateFinished_DestroyActor));
                        if (component.GetActiveState() != SpellStateType.ACTION)
                        {
                            component.ActivateState(SpellStateType.ACTION);
                        }
                    }
                }
            }
            else if ((oldZone is ZoneGraveyard) && (this.m_zone is ZonePlay))
            {
                this.m_actor.Hide();
                base.StartCoroutine(this.ActivateReviveSpell());
                flag = true;
            }
            if (!flag)
            {
                if (oldActor != null)
                {
                    oldActor.Destroy();
                }
                if (this.IsShown() && (this.m_zone.m_ServerTag == TAG_ZONE.PLAY))
                {
                    this.CreateStartingCardStateEffects();
                }
                this.m_actorReady = true;
                if (this.IsShown())
                {
                    this.ShowImpl();
                }
                else
                {
                    this.HideImpl();
                }
            }
        }
    }

    private void OnActorForceLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("Card.OnActorForceLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("Card.OnActorForceLoaded() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                if (this.m_actor != null)
                {
                    this.m_actor.Destroy();
                }
                this.m_actor = component;
                this.m_actorName = actorName;
                this.m_actor.SetEntity(this.m_entity);
                this.m_actor.SetCard(this);
                this.m_actor.SetCardDef(this.m_cardDef);
                this.m_actor.UpdateAllComponents();
                this.m_actorLoading = false;
                this.m_actorReady = true;
                if (this.m_shown)
                {
                    this.ShowImpl();
                }
                else
                {
                    this.HideImpl();
                }
                this.RefreshActor();
            }
        }
    }

    private void OnActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        Zone oldZone = (Zone) callbackData;
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("Card.OnActorLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("Card.OnActorLoaded() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                this.InitActor(actorName, component, oldZone);
            }
        }
    }

    public void OnEnchantmentAdded(int oldEnchantmentCount, Entity enchantment)
    {
        Spell actorSpell = null;
        switch (enchantment.GetEnchantmentBirthVisual())
        {
            case TAG_ENCHANTMENT_VISUAL.POSITIVE:
                actorSpell = this.GetActorSpell(SpellType.ENCHANT_POSITIVE);
                break;

            case TAG_ENCHANTMENT_VISUAL.NEGATIVE:
                actorSpell = this.GetActorSpell(SpellType.ENCHANT_NEGATIVE);
                break;

            case TAG_ENCHANTMENT_VISUAL.NEUTRAL:
                actorSpell = this.GetActorSpell(SpellType.ENCHANT_NEUTRAL);
                break;
        }
        if (actorSpell == null)
        {
            this.UpdateEnchantments();
            this.UpdateTooltip();
        }
        else
        {
            actorSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnEnchantmentSpellStateFinished));
            actorSpell.ActivateState(SpellStateType.BIRTH);
        }
    }

    public void OnEnchantmentRemoved(int oldEnchantmentCount, Entity enchantment)
    {
        Spell actorSpell = null;
        switch (enchantment.GetEnchantmentBirthVisual())
        {
            case TAG_ENCHANTMENT_VISUAL.POSITIVE:
                actorSpell = this.GetActorSpell(SpellType.ENCHANT_POSITIVE);
                break;

            case TAG_ENCHANTMENT_VISUAL.NEGATIVE:
                actorSpell = this.GetActorSpell(SpellType.ENCHANT_NEGATIVE);
                break;

            case TAG_ENCHANTMENT_VISUAL.NEUTRAL:
                actorSpell = this.GetActorSpell(SpellType.ENCHANT_NEUTRAL);
                break;
        }
        if (actorSpell == null)
        {
            this.UpdateEnchantments();
            this.UpdateTooltip();
        }
        else
        {
            actorSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnEnchantmentSpellStateFinished));
            actorSpell.ActivateState(SpellStateType.DEATH);
        }
    }

    private void OnEnchantmentSpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if ((prevStateType == SpellStateType.BIRTH) || (prevStateType == SpellStateType.DEATH))
        {
            spell.RemoveStateFinishedCallback(new Spell.StateFinishedCallback(this.OnEnchantmentSpellStateFinished));
            this.UpdateEnchantments();
            this.UpdateTooltip();
        }
    }

    private void OnSpellFinished_Death(Spell spell, object userData)
    {
        this.m_activeDeathSpellCount--;
    }

    private void OnSpellFinished_HandToPlay_SummonIn(Spell spell, object userData)
    {
        this.m_actorReady = true;
        this.RefreshActor();
        if (this.m_entity.HasSpellPower() && this.m_entity.IsControlledByLocalPlayer())
        {
            ZoneMgr.Get().FindZoneOfType<ZoneHand>(TAG_ZONE.HAND, this.m_zone.m_Side).OnSpellPowerEntityEnteredPlay();
        }
        if (this.m_entity.HasWindfury())
        {
            this.ActivateActorSpell(SpellType.WINDFURY_BURST);
        }
        base.StartCoroutine(this.ActivateBattlecrySpell());
    }

    private void OnSpellFinished_HandToPlay_SummonOut(Spell spell, object userData)
    {
        this.m_actor.Show();
        this.CreateStartingCardStateEffects();
        Spell spell2 = (Spell) userData;
        this.ActivateActorSpell(spell2, new Spell.FinishedCallback(this.OnSpellFinished_HandToPlay_SummonIn));
    }

    private void OnSpellFinished_HandToWeapon_SummonOut(Spell spell, object userData)
    {
        this.m_actor.Show();
        this.CreateStartingCardStateEffects();
        Spell spell2 = (Spell) userData;
        this.ActivateActorSpell(spell2, new Spell.FinishedCallback(this.OnSpellFinished_RefreshActor));
    }

    private void OnSpellFinished_PlayToHand_SummonOut(Spell spell, object userData)
    {
        Spell spell2 = (Spell) userData;
        this.ActivateActorSpell(spell2, new Spell.FinishedCallback(this.OnSpellFinished_RefreshActor));
    }

    private void OnSpellFinished_RefreshActor(Spell spell, object userData)
    {
        this.m_actorReady = true;
        this.RefreshActor();
    }

    private void OnSpellFinished_SpawnMinion(Spell spell, object userData)
    {
        this.m_actorReady = true;
        this.m_shown = true;
        this.CreateStartingCardStateEffects();
        this.RefreshActor();
    }

    private void OnSpellFinished_UpdateActor(Spell spell, object userData)
    {
        this.UpdateActorComponents();
    }

    private void OnSpellStateFinished_DestroyActor(Spell spell, SpellStateType stateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            Actor actor = SceneUtils.FindComponentInThisOrParents<Actor>(spell.gameObject);
            if (actor == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("Actor.OnSpellStateFinished_DestroyActor() - Spell {0} on Card {1} has no Actor ancestor", spell, this));
            }
            else
            {
                actor.Destroy();
            }
        }
    }

    public void OnTagChanged(TagDelta change)
    {
        GAME_TAG tag = (GAME_TAG) change.tag;
        switch (tag)
        {
            case GAME_TAG.DURABILITY:
            case GAME_TAG.HEALTH:
            case GAME_TAG.ATK:
            case GAME_TAG.COST:
                goto Label_0525;

            case GAME_TAG.SILENCED:
                if (this.CanShowActorVisuals())
                {
                    if (change.newValue == 1)
                    {
                        this.m_actor.ActivateSpell(SpellType.SILENCE);
                    }
                    else
                    {
                        this.m_actor.DeactivateSpell(SpellType.SILENCE);
                    }
                    return;
                }
                return;

            case GAME_TAG.WINDFURY:
                if (this.CanShowActorVisuals())
                {
                    if (change.newValue == 1)
                    {
                        this.m_actor.ActivateSpell(SpellType.WINDFURY_BURST);
                    }
                    Spell spell4 = this.m_actor.GetSpell(SpellType.WINDFURY_IDLE);
                    if (spell4 != null)
                    {
                        if (change.newValue == 1)
                        {
                            spell4.ActivateState(SpellStateType.BIRTH);
                        }
                        else
                        {
                            spell4.ActivateState(SpellStateType.CANCEL);
                        }
                    }
                    return;
                }
                return;

            case GAME_TAG.TAUNT:
                break;

            case GAME_TAG.STEALTH:
                goto Label_03D4;

            case GAME_TAG.SPELLPOWER:
                if (this.CanShowActorVisuals())
                {
                    if (change.newValue == 1)
                    {
                        this.m_actor.ActivateSpell(SpellType.SPELL_POWER);
                    }
                    else
                    {
                        this.m_actor.DeactivateSpell(SpellType.SPELL_POWER);
                    }
                    return;
                }
                return;

            case GAME_TAG.DIVINE_SHIELD:
                goto Label_0285;

            case GAME_TAG.CHARGE:
            {
                Spell actorSpell = this.GetActorSpell(SpellType.Zzz);
                if (actorSpell != null)
                {
                    actorSpell.ActivateState(SpellStateType.DEATH);
                }
                return;
            }
            case GAME_TAG.EXHAUSTED:
                if (this.CanShowActorVisuals())
                {
                    if (change.newValue != change.oldValue)
                    {
                        if (GameState.Get().IsTurnStartManagerActive() && this.m_entity.IsControlledByLocalPlayer())
                        {
                            TurnStartManager.Get().NotifyOfUntap(this.m_entity);
                        }
                        else
                        {
                            bool tap = change.newValue == 1;
                            this.DoVisualUntap(tap);
                        }
                    }
                    return;
                }
                return;

            case GAME_TAG.DAMAGE:
                if (this.CanShowActorVisuals())
                {
                    if (this.m_entity.GetZone() == TAG_ZONE.PLAY)
                    {
                        if (this.m_suppressDamageSplat)
                        {
                            this.UpdateActorComponents();
                            return;
                        }
                        Spell spell = this.GetActorSpell(SpellType.DAMAGE);
                        if (spell == null)
                        {
                            this.UpdateActorComponents();
                        }
                        else
                        {
                            spell.AddFinishedCallback(new Spell.FinishedCallback(this.OnSpellFinished_UpdateActor));
                            if (this.m_entity.IsCharacter())
                            {
                                int damage = change.newValue - change.oldValue;
                                if (damage != 0)
                                {
                                    ((DamageSplatSpell) spell).SetDamage(damage);
                                }
                                spell.ActivateState(SpellStateType.ACTION);
                            }
                            else
                            {
                                spell.Activate();
                            }
                        }
                        if (this.m_entity.IsEnraged())
                        {
                            if (!this.m_actor.GetSpell(SpellType.ENRAGE).IsActive())
                            {
                                this.m_actor.ActivateSpell(SpellType.ENRAGE);
                            }
                        }
                        else
                        {
                            this.m_actor.DeactivateSpell(SpellType.ENRAGE);
                        }
                    }
                    return;
                }
                return;

            case GAME_TAG.ZONE:
                if (((change.newValue == 4) && (change.oldValue == 1)) && this.m_entity.IsWeapon())
                {
                    HistoryManager.Get().CreateWeaponBreakTile(this);
                }
                return;

            default:
                switch (tag)
                {
                    case GAME_TAG.TAUNT_READY:
                        break;

                    case GAME_TAG.STEALTH_READY:
                        goto Label_03D4;

                    case GAME_TAG.IGNORE_DAMAGE:
                    case GAME_TAG.IGNORE_DAMAGE_OFF:
                        this.m_suppressDamageSplat = !this.m_suppressDamageSplat;
                        return;

                    case GAME_TAG.TRIGGER_VISUAL:
                        if (this.CanShowActorVisuals())
                        {
                            this.ToggleTriggerVis(change.newValue == 1);
                        }
                        return;

                    case GAME_TAG.ENRAGED:
                        if (this.CanShowActorVisuals())
                        {
                            if (change.newValue == 1)
                            {
                                this.m_actor.ActivateSpell(SpellType.ENRAGE);
                            }
                            else
                            {
                                this.m_actor.DeactivateSpell(SpellType.ENRAGE);
                            }
                        }
                        return;

                    case GAME_TAG.DEATH_RATTLE:
                        if (this.CanShowActorVisuals())
                        {
                            this.ToggleDeathrattle(change.newValue == 1);
                        }
                        return;

                    case GAME_TAG.CANT_PLAY:
                        this.CancelActiveSpells();
                        return;

                    case GAME_TAG.CANT_BE_DAMAGED:
                        if (this.CanShowActorVisuals())
                        {
                            if (change.newValue == 1)
                            {
                                this.m_actor.ActivateSpell(SpellType.IMMUNE);
                            }
                            else
                            {
                                this.m_actor.DeactivateSpell(SpellType.IMMUNE);
                            }
                        }
                        return;

                    case GAME_TAG.FROZEN:
                        if (this.CanShowActorVisuals())
                        {
                            if (change.newValue == 1)
                            {
                                SoundManager.Get().LoadAndPlay("FrostBoltHit1");
                                this.m_actor.ActivateSpell(SpellType.FROZEN);
                            }
                            else
                            {
                                SoundManager.Get().LoadAndPlay("FrostArmorTarget1");
                                this.m_actor.DeactivateSpell(SpellType.FROZEN);
                            }
                        }
                        return;

                    case GAME_TAG.ARMOR:
                        goto Label_0525;

                    case GAME_TAG.DIVINE_SHIELD_READY:
                        goto Label_0285;

                    case GAME_TAG.CANT_BE_TARGETED_BY_HERO_POWERS:
                        if (this.CanShowActorVisuals())
                        {
                            if (this.m_entity.IsStealthed())
                            {
                                return;
                            }
                            if (change.newValue == 1)
                            {
                                this.m_actor.ActivateSpell(SpellType.UNTARGETABLE);
                            }
                            else
                            {
                                this.m_actor.DeactivateSpell(SpellType.UNTARGETABLE);
                            }
                        }
                        return;

                    case GAME_TAG.HEALTH_MINIMUM:
                        if (this.CanShowActorVisuals())
                        {
                            if (change.newValue > 0)
                            {
                                this.m_actor.ActivateSpell(SpellType.SHOUT_BUFF);
                            }
                            else
                            {
                                this.m_actor.DeactivateSpell(SpellType.SHOUT_BUFF);
                            }
                        }
                        return;

                    default:
                        return;
                }
                break;
        }
        if (this.CanShowActorVisuals())
        {
            if (change.newValue == 1)
            {
                this.m_actor.ActivateTaunt();
            }
            else
            {
                this.m_actor.DeactivateTaunt();
            }
        }
        return;
    Label_0285:
        if (this.CanShowActorVisuals())
        {
            if (change.newValue == 1)
            {
                this.m_actor.ActivateSpell(SpellType.DIVINE_SHIELD);
            }
            else
            {
                this.m_actor.DeactivateSpell(SpellType.DIVINE_SHIELD);
            }
        }
        return;
    Label_03D4:
        if (this.CanShowActorVisuals())
        {
            if (change.newValue == 1)
            {
                this.m_actor.ActivateSpell(SpellType.STEALTH);
                this.m_actor.DeactivateSpell(SpellType.UNTARGETABLE);
            }
            else
            {
                this.m_actor.DeactivateSpell(SpellType.STEALTH);
                if ((this.m_entity.HasTag(GAME_TAG.CANT_BE_TARGETED_BY_OPPONENTS) || this.m_entity.HasTag(GAME_TAG.CANT_BE_TARGETED_BY_ABILITIES)) || this.m_entity.HasTag(GAME_TAG.CANT_BE_TARGETED_BY_HERO_POWERS))
                {
                    this.m_actor.ActivateSpell(SpellType.UNTARGETABLE);
                }
            }
        }
        return;
    Label_0525:
        if (!this.CanShowActorVisuals())
        {
            return;
        }
        this.UpdateActorComponents();
    }

    public void OnTagsChanged(TagDeltaSet changeSet)
    {
        bool flag = false;
        for (int i = 0; i < changeSet.Size(); i++)
        {
            TagDelta change = changeSet[i];
            GAME_TAG tag = (GAME_TAG) change.tag;
            switch (tag)
            {
                case GAME_TAG.HEALTH:
                case GAME_TAG.ATK:
                case GAME_TAG.COST:
                    break;

                default:
                    if ((tag != GAME_TAG.DURABILITY) && (tag != GAME_TAG.ARMOR))
                    {
                        goto Label_0053;
                    }
                    break;
            }
            flag = true;
            continue;
        Label_0053:
            this.OnTagChanged(change);
        }
        if ((flag && this.m_entity.IsCardReady()) && this.IsActorReady())
        {
            this.UpdateActorComponents();
        }
    }

    private void OnZoneChanged(Zone oldZone)
    {
        if (this.m_zone.m_ServerTag == TAG_ZONE.GRAVEYARD)
        {
            if (oldZone is ZoneHand)
            {
                this.DoCardDiscardAnimation(this.m_actor);
            }
            if (this.m_entity.IsHero())
            {
                this.m_doNotSort = true;
            }
            if ((BigCard.Get() != null) && (BigCard.Get().GetCard() == this))
            {
                BigCard.Get().Hide();
            }
        }
        else if (this.m_zone.m_ServerTag == TAG_ZONE.HAND)
        {
            this.ShowCard();
            if ((oldZone is ZoneGraveyard) && this.m_entity.IsAbility())
            {
                this.m_actor.Hide();
                this.ActivateActorSpell(SpellType.SUMMON_IN);
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator PlayDiscardAnimationAfterDelay(Actor actor)
    {
        return new <PlayDiscardAnimationAfterDelay>c__IteratorD3 { actor = actor, <$>actor = actor, <>f__this = this };
    }

    public void PlayEmote(EmoteType emoteType)
    {
        if (this.m_entity.IsHero())
        {
            Spell emoteSpell = this.GetEmoteSpell(emoteType);
            if (emoteSpell != null)
            {
                emoteSpell.Reactivate();
                Notification.SpeechBubbleDirection bottomLeft = Notification.SpeechBubbleDirection.BottomLeft;
                if (!this.GetEntity().IsControlledByLocalPlayer())
                {
                    bottomLeft = Notification.SpeechBubbleDirection.TopRight;
                }
                string cardId = this.GetEntity().GetCardId();
                if (cardId == "TU4a_006")
                {
                    cardId = "HERO_08";
                }
                string key = "GAMEPLAY_EMOTE_" + cardId + "_" + emoteType.ToString();
                string speechText = GameStrings.Get(key);
                if (speechText == key)
                {
                    speechText = string.Empty;
                }
                Notification notification = NotificationManager.Get().CreateSpeechBubble(speechText, bottomLeft, this.GetActor(), true);
                NotificationManager.Get().DestroyNotification(notification, 1.5f);
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator PlayHeroPowerAnimation(string animation)
    {
        return new <PlayHeroPowerAnimation>c__IteratorD4 { animation = animation, <$>animation = animation, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator PrepareForDeathAnimation(Actor dyingActor)
    {
        return new <PrepareForDeathAnimation>c__IteratorD6 { dyingActor = dyingActor, <$>dyingActor = dyingActor };
    }

    public void RefreshActor()
    {
        this.UpdateActorState();
        if (this.m_entity.IsEnchanted())
        {
            this.UpdateEnchantments();
        }
        this.UpdateTooltip();
    }

    public void SetActor(Actor actor)
    {
        this.m_actor = actor;
    }

    public void SetActorName(string actorName)
    {
        this.m_actorName = actorName;
    }

    public void SetBattleCrySource(bool source)
    {
        this.m_isBattleCrySource = source;
        if (this.m_actor != null)
        {
            if (source)
            {
                SceneUtils.SetLayer(this.m_actor.gameObject, GameLayer.IgnoreFullScreenEffects);
            }
            else
            {
                SceneUtils.SetLayer(this.m_actor.gameObject, GameLayer.Default);
                SceneUtils.SetLayer(this.m_actor.GetMeshRenderer().gameObject, GameLayer.CardRaycast);
            }
        }
    }

    public void SetDoNotSort(bool bOn)
    {
        this.m_doNotSort = bOn;
    }

    public void SetDoNotWarpToNewZone(bool bOn)
    {
        this.m_doNotWarpToNewZone = bOn;
    }

    public void SetEntity(Entity entity)
    {
        this.m_entity = entity;
    }

    public void SetSlowTransition(bool bOn)
    {
        this.m_slowTransition = bOn;
    }

    private AudioSource SetupSound(AudioSource sound)
    {
        sound.transform.parent = base.transform;
        TransformUtil.Identity(sound.transform);
        return sound;
    }

    private Spell SetupSpell(SpellType spellType, Spell spell)
    {
        spell.SetSpellType(spellType);
        spell.SetSource(base.gameObject);
        if (this.m_entity.IsMinion() && (spellType == SpellType.PLAY))
        {
            spell.transform.parent = base.transform;
            TransformUtil.Identity(spell.transform);
        }
        return spell;
    }

    public void SetVerySlowTransition(bool bOn)
    {
        this.m_verySlowTransition = bOn;
    }

    public void SetZone(Zone zone)
    {
        this.m_zone = zone;
    }

    private void SheatheWeapon()
    {
        this.GetActor().GetAttackObject().ScaleToZero();
        this.ActivateActorSpell(SpellType.SHEATHE);
    }

    public void ShouldShowTooltip()
    {
        if (this.IsAllowedToShowTooltip() && !this.m_shouldShowTooltip)
        {
            this.m_shouldShowTooltip = true;
        }
    }

    public void ShowCard()
    {
        if (!this.m_shown)
        {
            this.m_shown = true;
            this.ShowImpl();
        }
    }

    private void ShowImpl()
    {
        if (this.m_actor != null)
        {
            this.m_actor.Show();
            this.RefreshActor();
        }
    }

    public void ShowTooltip()
    {
        if (!this.m_showTooltip)
        {
            this.m_showTooltip = true;
            this.UpdateTooltip();
        }
    }

    private void ToggleDeathrattle(bool bOn)
    {
        if (bOn)
        {
            this.m_actor.ActivateSpell(SpellType.DEATHRATTLE_IDLE);
            if (this.m_actor.IsSpellActive(SpellType.TRIGGER))
            {
                this.m_actor.DeactivateSpell(SpellType.TRIGGER);
            }
        }
        else
        {
            this.m_actor.DeactivateSpell(SpellType.DEATHRATTLE_IDLE);
        }
    }

    private void ToggleTriggerVis(bool bOn)
    {
        if (!this.m_actor.IsSpellActive(SpellType.DEATHRATTLE_IDLE) && bOn)
        {
            this.m_actor.ActivateSpell(SpellType.TRIGGER);
        }
        else
        {
            this.m_actor.DeactivateSpell(SpellType.TRIGGER);
        }
    }

    public override string ToString()
    {
        return ((this.m_entity != null) ? this.m_entity.ToString() : "UNKNOWN CARD");
    }

    public void TransitionToZone(Zone zone)
    {
        if (this.m_zone == zone)
        {
            Log.Mike.Print(string.Format("Card.TransitionToZone() - card={0} already in target zone", this));
        }
        else
        {
            this.m_actorLoading = true;
            this.m_actorReady = false;
            if (zone == null)
            {
                this.m_zone.RemoveCard(this);
                this.m_zone = null;
                if (this.m_entity.GetZone() == TAG_ZONE.SETASIDE)
                {
                    base.transform.position = new Vector3(1000f, 1000f, 1000f);
                }
                this.HideCard();
                this.m_actorReady = true;
                this.m_actorLoading = false;
            }
            else
            {
                Zone oldZone = this.m_zone;
                this.m_zone = zone;
                if (oldZone != null)
                {
                    oldZone.RemoveCard(this);
                }
                this.m_zone.AddCard(this);
                this.DetermineActorThenTransitionToZone(oldZone);
            }
        }
    }

    private void UnSheatheWeapon()
    {
        this.GetActor().GetAttackObject().Enlarge(1f);
        this.ActivateActorSpell(SpellType.UNSHEATHE);
    }

    public void UpdateActorComponents()
    {
        if (this.m_actor != null)
        {
            this.m_actor.UpdateAllComponents();
        }
    }

    public void UpdateActorState()
    {
        if ((((this.m_actor != null) && this.m_shown) && !this.m_entity.IsBusy()) && !(this.m_zone is ZoneGraveyard))
        {
            if (this.m_overPlayfield)
            {
                this.m_actor.SetActorState(ActorStateType.CARD_OVER_PLAYFIELD);
            }
            else
            {
                GameState state = GameState.Get();
                GameState.ResponseMode responseMode = state.GetResponseMode();
                if ((EndTurnButton.Get() != null) && (!EndTurnButton.Get().IsInWaitingState() || state.IsMulliganPhase()))
                {
                    switch (responseMode)
                    {
                        case GameState.ResponseMode.OPTION:
                            if (!this.DoOptionHighlight(state))
                            {
                                break;
                            }
                            return;

                        case GameState.ResponseMode.SUB_OPTION:
                            if (!this.DoSubOptionHighlight(state))
                            {
                                break;
                            }
                            return;

                        case GameState.ResponseMode.OPTION_TARGET:
                            if (!this.DoOptionTargetHighlight(state))
                            {
                                break;
                            }
                            return;

                        case GameState.ResponseMode.CHOICE:
                            if (!this.DoChoiceHighlight(state))
                            {
                                break;
                            }
                            return;
                    }
                }
                if (this.m_mousedOver && !(this.m_zone is ZoneHand))
                {
                    this.m_actor.SetActorState(ActorStateType.CARD_MOUSE_OVER);
                }
                else if (this.m_mousedOverByOpponent)
                {
                    this.m_actor.SetActorState(ActorStateType.CARD_OPPONENT_MOUSE_OVER);
                }
                else
                {
                    this.m_actor.SetActorState(ActorStateType.CARD_IDLE);
                }
            }
        }
    }

    public void UpdateEnchantments()
    {
        List<Entity> enchantments = this.m_entity.GetEnchantments();
        Spell actorSpell = this.GetActorSpell(SpellType.ENCHANT_POSITIVE);
        Spell spell2 = this.GetActorSpell(SpellType.ENCHANT_NEGATIVE);
        Spell spell3 = this.GetActorSpell(SpellType.ENCHANT_NEUTRAL);
        Spell spell4 = null;
        if ((actorSpell != null) && (actorSpell.GetActiveState() == SpellStateType.IDLE))
        {
            spell4 = actorSpell;
        }
        else if ((spell2 != null) && (spell2.GetActiveState() == SpellStateType.IDLE))
        {
            spell4 = spell2;
        }
        else if ((spell3 != null) && (spell3.GetActiveState() == SpellStateType.IDLE))
        {
            spell4 = spell3;
        }
        if (enchantments.Count == 0)
        {
            if (spell4 != null)
            {
                spell4.ActivateState(SpellStateType.DEATH);
            }
        }
        else
        {
            int num = 0;
            bool flag = false;
            foreach (Entity entity in enchantments)
            {
                TAG_ENCHANTMENT_VISUAL enchantmentIdleVisual = entity.GetEnchantmentIdleVisual();
                switch (enchantmentIdleVisual)
                {
                    case TAG_ENCHANTMENT_VISUAL.POSITIVE:
                        num++;
                        break;

                    case TAG_ENCHANTMENT_VISUAL.NEGATIVE:
                        num--;
                        break;
                }
                if (enchantmentIdleVisual != TAG_ENCHANTMENT_VISUAL.NONE)
                {
                    flag = true;
                }
            }
            Spell spell5 = null;
            if (num > 0)
            {
                spell5 = actorSpell;
            }
            else if (num < 0)
            {
                spell5 = spell2;
            }
            else if (flag)
            {
                spell5 = spell3;
            }
            if ((spell4 != null) && (spell4 != spell5))
            {
                spell4.Deactivate();
            }
            if (spell5 != null)
            {
                spell5.ActivateState(SpellStateType.IDLE);
            }
        }
    }

    private void UpdateProposedManaUsage()
    {
        if (GameState.Get().GetSelectedOption() == -1)
        {
            Player player = GameState.Get().GetPlayer(this.GetEntity().GetControllerId());
            if (player.IsLocal() && player.HasTag(GAME_TAG.CURRENT_PLAYER))
            {
                if (this.m_mousedOver)
                {
                    bool flag = this.m_entity.GetZone() == TAG_ZONE.HAND;
                    bool flag2 = this.m_entity.IsHeroPower();
                    if ((flag || flag2) && GameState.Get().IsOption(this.m_entity))
                    {
                        player.ProposeManaCrystalUsage(this.m_entity);
                    }
                }
                else
                {
                    player.CancelAllProposedMana(this.m_entity);
                }
            }
        }
    }

    public void UpdateTooltip()
    {
        if (((this.GetShouldShowTooltip() && this.IsAllowedToShowTooltip()) && this.IsAbleToShowTooltip()) && this.m_showTooltip)
        {
            if (BigCard.Get() != null)
            {
                BigCard.Get().Show(this);
            }
        }
        else
        {
            this.m_showTooltip = false;
            this.m_shouldShowTooltip = false;
            if (BigCard.Get() != null)
            {
                BigCard.Get().Hide(this);
            }
        }
    }

    public void UpdateZoneFromTags()
    {
        Zone zone = ZoneMgr.Get().FindZoneForEntity(this.m_entity);
        this.TransitionToZone(zone);
        if (zone != null)
        {
            zone.UpdateLayout();
        }
    }

    [DebuggerHidden]
    private IEnumerator waitForFlipAndThenChangeActor()
    {
        return new <waitForFlipAndThenChangeActor>c__IteratorD9 { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <ActivateBattlecrySpell>c__IteratorD2 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <>f__this;
        internal Spell <battlecrySpell>__0;

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
                    this.<battlecrySpell>__0 = this.<>f__this.GetActorSpell(SpellType.BATTLECRY);
                    if (this.<battlecrySpell>__0 != null)
                    {
                        if ((!(this.<>f__this.m_zone is ZonePlay) || (InputManager.Get() == null)) || (InputManager.Get().GetBattlecrySourceCard() != this.<>f__this))
                        {
                            break;
                        }
                        this.$current = new WaitForSeconds(0.01f);
                        this.$PC = 1;
                        return true;
                    }
                    break;

                case 1:
                    if (InputManager.Get() != null)
                    {
                        if ((InputManager.Get().GetBattlecrySourceCard() == this.<>f__this) && (this.<battlecrySpell>__0.GetActiveState() == SpellStateType.NONE))
                        {
                            this.<battlecrySpell>__0.ActivateState(SpellStateType.BIRTH);
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
    private sealed class <ActivateCreatorSpawnSpell>c__IteratorD0 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Entity <$>creator;
        internal Card <>f__this;
        internal Card <creatorCard>__0;
        internal Entity creator;

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
                    this.<creatorCard>__0 = this.creator.GetCard();
                    this.<creatorCard>__0.ActivateCreatorSpawnMinionSpell();
                    break;

                case 1:
                    break;

                case 2:
                    this.<>f__this.ActivateSpawnMinionSpell();
                    this.$PC = -1;
                    goto Label_00AC;

                default:
                    goto Label_00AC;
            }
            if (!this.creator.IsCardReady() || !this.<creatorCard>__0.IsActorReady())
            {
                this.$current = 0;
                this.$PC = 1;
            }
            else
            {
                this.$current = new WaitForSeconds(0.9f);
                this.$PC = 2;
            }
            return true;
        Label_00AC:
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
    private sealed class <ActivateReviveSpell>c__IteratorD1 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <>f__this;

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
                    if (this.<>f__this.m_activeDeathSpellCount <= 0)
                    {
                        break;
                    }
                    this.$current = new WaitForSeconds(2f);
                    this.$PC = 1;
                    return true;

                case 1:
                    break;

                default:
                    goto Label_0060;
            }
            this.<>f__this.ActivateSpawnMinionSpell();
            this.$PC = -1;
        Label_0060:
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
    private sealed class <DelayedActorSetup>c__IteratorD5 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Actor <$>actor;
        internal string <$>actorName;
        internal Zone <$>oldZone;
        internal Card <>f__this;
        internal Actor actor;
        internal string actorName;
        internal Zone oldZone;

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
                    this.<>f__this.InitActor(this.actorName, this.actor, this.oldZone);
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
    private sealed class <DrawCardInSequence>c__IteratorD8 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <>f__this;
        internal Vector3[] <drawPath>__0;

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
                    this.<>f__this.m_doNotSort = true;
                    this.<>f__this.m_slowTransition = true;
                    this.<>f__this.m_actor.Hide();
                    break;

                case 1:
                    break;

                default:
                    goto Label_02CB;
            }
            if (Card.s_cardBeingDrawn != null)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            Card.s_cardBeingDrawn = this.<>f__this;
            this.<drawPath>__0 = new Vector3[] { this.<>f__this.gameObject.transform.position, new Vector3(this.<>f__this.gameObject.transform.position.x, this.<>f__this.gameObject.transform.position.y + 3.6f, this.<>f__this.gameObject.transform.position.z), Board.Get().FindBone("FriendlyDrawCardPosition").position };
            object[] args = new object[] { "path", this.<drawPath>__0, "time", 1.5f, "easetype", iTween.EaseType.easeInSineOutExpo };
            iTween.MoveTo(this.<>f__this.gameObject, iTween.Hash(args));
            this.<>f__this.gameObject.transform.localEulerAngles = new Vector3(270f, 270f, 0f);
            object[] objArray2 = new object[] { "rotation", new Vector3(0f, 0f, 357f), "time", 1.35f, "delay", 0.15f };
            iTween.RotateTo(this.<>f__this.gameObject, iTween.Hash(objArray2));
            object[] objArray3 = new object[] { "scale", new Vector3(1.4f, 1.4f, 1.4f), "time", 0.75f, "delay", 0.15f };
            iTween.ScaleTo(this.<>f__this.gameObject, iTween.Hash(objArray3));
            SoundManager.Get().LoadAndPlay("draw_card_and_add_to_hand_1", this.<>f__this.gameObject);
            this.<>f__this.StartCoroutine(this.<>f__this.waitForFlipAndThenChangeActor());
            this.$PC = -1;
        Label_02CB:
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
    private sealed class <DrawEnemyCardInSequence>c__IteratorD7 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <>f__this;
        internal Vector3[] <drawPath>__1;
        internal ZoneHand <handZone>__0;

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
                    this.<>f__this.m_doNotSort = true;
                    break;

                case 1:
                    break;

                case 2:
                    this.<>f__this.m_actorReady = true;
                    this.$current = new WaitForSeconds(0.6f);
                    this.$PC = 3;
                    goto Label_03A3;

                case 3:
                    Card.s_enemyCardBeingDrawn = null;
                    goto Label_0352;

                case 4:
                    goto Label_0352;

                default:
                    goto Label_03A1;
            }
            if (Card.s_enemyCardBeingDrawn != null)
            {
                this.$current = null;
                this.$PC = 1;
            }
            else
            {
                Card.s_enemyCardBeingDrawn = this.<>f__this;
                this.<handZone>__0 = GameState.Get().GetRemotePlayer().GetHandZone();
                this.<handZone>__0.UpdateLayout();
                this.<drawPath>__1 = new Vector3[] { this.<>f__this.gameObject.transform.position, new Vector3(this.<>f__this.gameObject.transform.position.x, this.<>f__this.gameObject.transform.position.y + 3.6f, this.<>f__this.gameObject.transform.position.z), Board.Get().FindBone("EnemyDrawCardPosition").position, this.<handZone>__0.GetCardPosition(this.<>f__this) };
                object[] args = new object[] { "path", this.<drawPath>__1, "time", 1.75f, "easetype", iTween.EaseType.easeInOutQuart };
                iTween.MoveTo(this.<>f__this.gameObject, iTween.Hash(args));
                SoundManager.Get().LoadAndPlay("draw_card_and_add_to_hand_opp_1");
                this.<>f__this.gameObject.transform.localEulerAngles = new Vector3(270f, 90f, 0f);
                object[] objArray2 = new object[] { "rotation", this.<handZone>__0.GetCardRotation(this.<>f__this), "time", 0.7f, "delay", 0.8f, "easetype", iTween.EaseType.easeInOutCubic };
                iTween.RotateTo(this.<>f__this.gameObject, iTween.Hash(objArray2));
                object[] objArray3 = new object[] { "scale", this.<handZone>__0.GetCardScale(this.<>f__this), "time", 0.7f, "delay", 0.8f, "easetype", iTween.EaseType.easeInOutQuint };
                iTween.ScaleTo(this.<>f__this.gameObject, iTween.Hash(objArray3));
                this.$current = new WaitForSeconds(0.2f);
                this.$PC = 2;
            }
            goto Label_03A3;
        Label_0352:
            while (iTween.Count(this.<>f__this.gameObject) > 0)
            {
                this.$current = null;
                this.$PC = 4;
                goto Label_03A3;
            }
            this.<>f__this.m_doNotSort = false;
            if (this.<>f__this.m_zone != null)
            {
                this.<>f__this.m_zone.UpdateLayout();
            }
            this.$PC = -1;
        Label_03A1:
            return false;
        Label_03A3:
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
    private sealed class <PlayDiscardAnimationAfterDelay>c__IteratorD3 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Actor <$>actor;
        internal Card <>f__this;
        internal Actor actor;

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
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 1;
                    goto Label_0085;

                case 1:
                    this.<>f__this.ActivateActorDeathSpell(this.actor, false);
                    this.$current = new WaitForSeconds(4f);
                    this.$PC = 2;
                    goto Label_0085;

                case 2:
                    this.<>f__this.m_doNotSort = false;
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_0085:
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
    private sealed class <PlayHeroPowerAnimation>c__IteratorD4 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal string <$>animation;
        internal Card <>f__this;
        internal MinionShake <shake>__0;
        internal string animation;

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
                    this.<shake>__0 = this.<>f__this.m_actor.gameObject.GetComponentInChildren<MinionShake>();
                    if (this.<shake>__0 != null)
                    {
                        break;
                    }
                    goto Label_00A6;

                case 1:
                    break;

                default:
                    goto Label_00A6;
            }
            while (this.<shake>__0.isShaking())
            {
                this.$current = new WaitForEndOfFrame();
                this.$PC = 1;
                return true;
            }
            this.<>f__this.m_actor.animation.Play(this.animation);
        Label_00A6:
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
    private sealed class <PrepareForDeathAnimation>c__IteratorD6 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Actor <$>dyingActor;
        internal Actor dyingActor;

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
                    this.$current = new WaitForSeconds(0.6f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.dyingActor.ToggleForceIdle(true);
                    this.dyingActor.SetActorState(ActorStateType.CARD_IDLE);
                    this.dyingActor.DeactivateAllPreDeathSpells();
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
    private sealed class <waitForFlipAndThenChangeActor>c__IteratorD9 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <>f__this;

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
                    if (this.<>f__this.transform.localEulerAngles.x < 287f)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_0121;
                    }
                    if (this.<>f__this.m_actorWaitingToBeReplaced != null)
                    {
                        this.<>f__this.m_actorWaitingToBeReplaced.Destroy();
                        this.<>f__this.m_actorWaitingToBeReplaced = null;
                    }
                    this.<>f__this.m_actor.Show();
                    this.<>f__this.m_actor.TurnOffCollider();
                    break;

                case 2:
                    break;

                default:
                    goto Label_011F;
            }
            while (iTween.Count(this.<>f__this.gameObject) > 0)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_0121;
            }
            this.<>f__this.m_doNotSort = false;
            this.<>f__this.m_actorReady = true;
            this.<>f__this.RefreshActor();
            this.<>f__this.m_zone.UpdateLayout();
            Card.s_cardBeingDrawn = null;
            this.$PC = -1;
        Label_011F:
            return false;
        Label_0121:
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


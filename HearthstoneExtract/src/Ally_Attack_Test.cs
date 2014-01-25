using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ally_Attack_Test : MonoBehaviour
{
    private bool m_bulletTimeActive;
    public float m_BulletTimeDelay = 0.08f;
    public float m_BulletTimeDuration = 1.5f;
    public iTween.EaseType m_BulletTimeEaseType = iTween.EaseType.easeInExpo;
    public float m_BulletTimeMinTimeScale = 0.01f;
    public Card m_DefaultAttacker;
    public Card m_DefaultDefender;
    public Card m_FriendlyHeroCard;
    private ZoneHero m_friendlyHeroZone;
    public Card m_FriendlyMinionCard;
    private int m_friendlyPlayerId = 1;
    private ZonePlay m_friendlyPlayZone;
    public Actor m_HeroActor;
    private bool m_initialized;
    public Actor m_MinionActor;
    private int m_nextEntityId;
    public Card m_OpponentHeroCard;
    public Card m_OpponentMinionCard;
    private int m_opponentPlayerId = 2;
    private ZoneHero m_opposingHeroZone;
    private ZonePlay m_opposingPlayZone;
    public AttackSpellController m_SpellController;
    private CardDef m_testCardDef;
    private const string TEST_CARD_NAME = "CS1_042";

    private void Awake()
    {
    }

    private bool CanSwitchSourceAndTargets()
    {
        Spell actorSpell;
        if (this.m_SpellController.IsProcessingTaskList())
        {
            return false;
        }
        if (this.m_bulletTimeActive)
        {
            return false;
        }
        Card source = this.m_SpellController.GetSource();
        if (source.GetZone().m_Side == Player.Side.OPPOSING)
        {
            actorSpell = source.GetActorSpell(SpellType.OPPONENT_ATTACK);
        }
        else
        {
            actorSpell = source.GetActorSpell(SpellType.FRIENDLY_ATTACK);
        }
        if ((actorSpell != null) && (actorSpell.GetActiveState() != SpellStateType.NONE))
        {
            return false;
        }
        return true;
    }

    private void ChangeATK(Card card, int atk)
    {
        card.GetEntity().SetTag(GAME_TAG.ATK, atk);
        card.UpdateActorComponents();
    }

    private int GetNextEntityId()
    {
        return ++this.m_nextEntityId;
    }

    private void LaunchAttack()
    {
        this.m_SpellController.AddFinishedCallback(new SpellController.FinishedCallback(this.OnAttackSpellControllerFinished));
        this.m_SpellController.DoPowerTaskList();
    }

    private void LayoutAttackControl(Vector2 controlOffset, float labelWidth, float inputWidth, float height, float horizPadding, Card card, string label)
    {
        int num2;
        GUI.Box(new Rect(controlOffset.x, controlOffset.y, labelWidth, height), label);
        int aTK = card.GetEntity().GetATK();
        if (int.TryParse(GUI.TextField(new Rect((controlOffset.x + labelWidth) + horizPadding, controlOffset.y, inputWidth, height), aTK.ToString()), out num2) && (aTK != num2))
        {
            this.ChangeATK(card, num2);
        }
    }

    private void LayoutAttackControls()
    {
        if (!this.m_SpellController.IsProcessingTaskList())
        {
            float labelWidth = 150f;
            float inputWidth = 50f;
            float height = 23f;
            float horizPadding = Screen.width * 0.01f;
            float num5 = 0.5f * height;
            Vector2 vector = new Vector2(Screen.width * 0.05f, Screen.height * 0.25f);
            Vector2 vector2 = new Vector2(vector.x, vector.y);
            Vector2 controlOffset = vector2;
            this.LayoutAttackControl(controlOffset, labelWidth, inputWidth, height, horizPadding, this.m_OpponentHeroCard, "Opponent Hero ATK: ");
            controlOffset.y += height + num5;
            this.LayoutAttackControl(controlOffset, labelWidth, inputWidth, height, horizPadding, this.m_OpponentMinionCard, "Opponent Minion ATK: ");
            controlOffset.y += height + num5;
            this.LayoutAttackControl(controlOffset, labelWidth, inputWidth, height, horizPadding, this.m_FriendlyMinionCard, "Friendly Minion ATK: ");
            controlOffset.y += height + num5;
            this.LayoutAttackControl(controlOffset, labelWidth, inputWidth, height, horizPadding, this.m_FriendlyHeroCard, "Friendly Hero ATK: ");
            controlOffset.y += height + num5;
        }
    }

    private void LayoutSourceControls()
    {
        Vector2 vector = new Vector2(200f, 30f);
        Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.5f);
        Vector2 vector3 = new Vector2(vector2.x, vector2.y);
        Vector2 vector4 = vector3;
        Card source = this.m_SpellController.GetSource();
        if (source == this.m_OpponentHeroCard)
        {
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Current Source: Opponent Hero");
            vector4.y += 1.5f * vector.y;
            if (this.CanSwitchSourceAndTargets())
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Opponent Minion"))
                {
                    this.m_SpellController.SetSource(this.m_OpponentMinionCard);
                }
                vector4.y += 1.5f * vector.y;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Friendly Minion"))
                {
                    this.m_SpellController.SetSource(this.m_FriendlyMinionCard);
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_OpponentMinionCard);
                }
                vector4.y += 1.5f * vector.y;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Friendly Hero"))
                {
                    this.m_SpellController.SetSource(this.m_FriendlyHeroCard);
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_OpponentMinionCard);
                }
                vector4.y += 1.5f * vector.y;
            }
        }
        else if (source == this.m_OpponentMinionCard)
        {
            if (this.CanSwitchSourceAndTargets())
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Opponent Hero"))
                {
                    this.m_SpellController.SetSource(this.m_OpponentHeroCard);
                }
                vector4.y += 1.5f * vector.y;
            }
            else
            {
                vector4.y += 1.5f * vector.y;
            }
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Current Source: Opponent Minion");
            vector4.y += 1.5f * vector.y;
            if (this.CanSwitchSourceAndTargets())
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Friendly Minion"))
                {
                    this.m_SpellController.SetSource(this.m_FriendlyMinionCard);
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_OpponentMinionCard);
                }
                vector4.y += 1.5f * vector.y;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Friendly Hero"))
                {
                    this.m_SpellController.SetSource(this.m_FriendlyHeroCard);
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_OpponentMinionCard);
                }
                vector4.y += 1.5f * vector.y;
            }
            else
            {
                vector4.y += 1.5f * vector.y;
                vector4.y += 1.5f * vector.y;
            }
        }
        else if (source == this.m_FriendlyMinionCard)
        {
            if (this.CanSwitchSourceAndTargets())
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Opponent Hero"))
                {
                    this.m_SpellController.SetSource(this.m_OpponentHeroCard);
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_FriendlyMinionCard);
                }
                vector4.y += 1.5f * vector.y;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Opponent Minion"))
                {
                    this.m_SpellController.SetSource(this.m_OpponentMinionCard);
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_FriendlyMinionCard);
                }
                vector4.y += 1.5f * vector.y;
            }
            else
            {
                vector4.y += 1.5f * vector.y;
                vector4.y += 1.5f * vector.y;
            }
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Current Source: Friendly Minion");
            vector4.y += 1.5f * vector.y;
            if (this.CanSwitchSourceAndTargets())
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Friendly Hero"))
                {
                    this.m_SpellController.SetSource(this.m_FriendlyHeroCard);
                }
                vector4.y += 1.5f * vector.y;
            }
        }
        else if (source == this.m_FriendlyHeroCard)
        {
            if (this.CanSwitchSourceAndTargets())
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Opponent Hero"))
                {
                    this.m_SpellController.SetSource(this.m_OpponentHeroCard);
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_FriendlyMinionCard);
                }
                vector4.y += 1.5f * vector.y;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Opponent Minion"))
                {
                    this.m_SpellController.SetSource(this.m_OpponentMinionCard);
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_FriendlyMinionCard);
                }
                vector4.y += 1.5f * vector.y;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Source Friendly Minion"))
                {
                    this.m_SpellController.SetSource(this.m_FriendlyMinionCard);
                }
                vector4.y += 1.5f * vector.y;
            }
            else
            {
                vector4.y += 1.5f * vector.y;
                vector4.y += 1.5f * vector.y;
                vector4.y += 1.5f * vector.y;
            }
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Current Source: Friendly Hero");
            vector4.y += 1.5f * vector.y;
        }
    }

    private void LayoutSpellControls()
    {
        if (!this.m_SpellController.IsProcessingTaskList())
        {
            Vector2 vector = new Vector2(200f, 30f);
            Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.05f);
            Vector2 vector3 = new Vector2((Screen.width - vector.x) - vector2.x, vector2.y);
            Vector2 vector4 = vector3;
            Card source = this.m_SpellController.GetSource();
            if (source.GetZone().m_Side == Player.Side.OPPOSING)
            {
                if (source.GetActorSpell(SpellType.OPPONENT_ATTACK).GetActiveState() == SpellStateType.NONE)
                {
                    if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Launch Attack"))
                    {
                        this.LaunchAttack();
                    }
                    vector4.y += 1.5f * vector.y;
                }
            }
            else
            {
                Spell actorSpell = source.GetActorSpell(SpellType.FRIENDLY_ATTACK);
                switch (actorSpell.GetActiveState())
                {
                    case SpellStateType.NONE:
                        if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Prepare Attack"))
                        {
                            actorSpell.ActivateState(SpellStateType.BIRTH);
                        }
                        vector4.y += 1.5f * vector.y;
                        return;

                    case SpellStateType.BIRTH:
                        return;

                    case SpellStateType.IDLE:
                        if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Launch Attack"))
                        {
                            this.LaunchAttack();
                        }
                        vector4.y += 1.5f * vector.y;
                        if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Cancel Attack"))
                        {
                            actorSpell.ActivateState(SpellStateType.CANCEL);
                        }
                        vector4.y += 1.5f * vector.y;
                        return;
                }
            }
        }
    }

    private void LayoutTargetControls()
    {
        Vector2 vector = new Vector2(200f, 30f);
        Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.5f);
        Vector2 vector3 = new Vector2((Screen.width - vector.x) - vector2.x, vector2.y);
        Vector2 vector4 = vector3;
        Card source = this.m_SpellController.GetSource();
        Card target = this.m_SpellController.GetTarget();
        if (target == this.m_OpponentHeroCard)
        {
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Current Target: Opponent Hero");
            vector4.y += 1.5f * vector.y;
            if (this.CanSwitchSourceAndTargets())
            {
                if ((source != this.m_OpponentMinionCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Opponent Minion"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_OpponentMinionCard);
                }
                vector4.y += 1.5f * vector.y;
                if ((source != this.m_FriendlyMinionCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Friendly Minion"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_FriendlyMinionCard);
                }
                vector4.y += 1.5f * vector.y;
                if ((source != this.m_FriendlyHeroCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Friendly Hero"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_FriendlyHeroCard);
                }
                vector4.y += 1.5f * vector.y;
            }
        }
        else if (target == this.m_OpponentMinionCard)
        {
            if (this.CanSwitchSourceAndTargets())
            {
                if ((source != this.m_OpponentHeroCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Opponent Hero"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_OpponentHeroCard);
                }
                vector4.y += 1.5f * vector.y;
            }
            else
            {
                vector4.y += 1.5f * vector.y;
            }
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Current Target: Opponent Minion");
            vector4.y += 1.5f * vector.y;
            if (this.CanSwitchSourceAndTargets())
            {
                if ((source != this.m_FriendlyMinionCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Friendly Minion"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_FriendlyMinionCard);
                }
                vector4.y += 1.5f * vector.y;
                if ((source != this.m_FriendlyHeroCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Friendly Hero"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_FriendlyHeroCard);
                }
                vector4.y += 1.5f * vector.y;
            }
            else
            {
                vector4.y += 1.5f * vector.y;
                vector4.y += 1.5f * vector.y;
            }
        }
        else if (target == this.m_FriendlyMinionCard)
        {
            if (this.CanSwitchSourceAndTargets())
            {
                if ((source != this.m_OpponentHeroCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Opponent Hero"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_OpponentHeroCard);
                }
                vector4.y += 1.5f * vector.y;
                if ((source != this.m_OpponentMinionCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Opponent Minion"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_OpponentMinionCard);
                }
                vector4.y += 1.5f * vector.y;
            }
            else
            {
                vector4.y += 1.5f * vector.y;
                vector4.y += 1.5f * vector.y;
            }
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Current Target: Friendly Minion");
            vector4.y += 1.5f * vector.y;
            if (this.CanSwitchSourceAndTargets())
            {
                if ((source != this.m_FriendlyHeroCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Friendly Hero"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_FriendlyHeroCard);
                }
                vector4.y += 1.5f * vector.y;
            }
        }
        else if (target == this.m_FriendlyHeroCard)
        {
            if (this.CanSwitchSourceAndTargets())
            {
                if ((source != this.m_OpponentHeroCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Opponent Hero"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_OpponentHeroCard);
                }
                vector4.y += 1.5f * vector.y;
                if ((source != this.m_OpponentMinionCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Opponent Minion"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_OpponentMinionCard);
                }
                vector4.y += 1.5f * vector.y;
                if ((source != this.m_FriendlyMinionCard) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Make Target Friendly Minion"))
                {
                    this.m_SpellController.RemoveAllTargets();
                    this.m_SpellController.AddTarget(this.m_FriendlyMinionCard);
                }
                vector4.y += 1.5f * vector.y;
            }
            else
            {
                vector4.y += 1.5f * vector.y;
                vector4.y += 1.5f * vector.y;
                vector4.y += 1.5f * vector.y;
            }
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Current Target: Friendly Hero");
            vector4.y += 1.5f * vector.y;
        }
    }

    private void OnAttackSpellControllerFinished(SpellController spellController)
    {
        this.m_bulletTimeActive = true;
        base.StartCoroutine(this.OnBulletTimeDelayComplete());
    }

    private void OnBulletTimeComplete()
    {
        this.m_bulletTimeActive = false;
    }

    [DebuggerHidden]
    private IEnumerator OnBulletTimeDelayComplete()
    {
        return new <OnBulletTimeDelayComplete>c__Iterator111 { <>f__this = this };
    }

    private void OnBulletTimeUpdate(float currTimeScale)
    {
        UnityEngine.Time.timeScale = currTimeScale;
    }

    private void OnGUI()
    {
        if (this.m_initialized)
        {
            this.LayoutTargetControls();
            this.LayoutSourceControls();
            this.LayoutSpellControls();
            this.LayoutAttackControls();
        }
    }

    private void OnTestCardDefLoaded(string cardName, GameObject cardObject, object callbackData)
    {
        this.m_testCardDef = cardObject.GetComponent<CardDef>();
        GameState state = GameState.Initialize();
        this.SetupGameEntity(state, this.GetNextEntityId());
        Player friendlyPlayer = this.SetupFriendlyPlayer(state, this.GetNextEntityId());
        Player opponentPlayer = this.SetupOpponentPlayer(state, this.GetNextEntityId());
        this.SetupZones(state, friendlyPlayer, opponentPlayer);
        this.SetupFriendlyHeroCard(state, this.GetNextEntityId());
        this.SetupFriendlyMinionCard(state, this.GetNextEntityId());
        this.SetupOpponentHeroCard(state, this.GetNextEntityId());
        this.SetupOpponentMinionCard(state, this.GetNextEntityId());
        this.SetupSpellController();
        this.m_initialized = true;
    }

    private void SetupCard(Entity entity, Card card, string name, Actor actorPrefab, Zone zone)
    {
        entity.SetCard(card);
        card.SetEntity(entity);
        card.LoadCardDef(this.m_testCardDef);
        card.name = name;
        Actor actor = (Actor) UnityEngine.Object.Instantiate(actorPrefab);
        card.SetActor(actor);
        actor.SetCard(card);
        actor.SetEntity(entity);
        card.SetZone(zone);
        zone.AddCard(card);
        zone.UpdateLayout();
        actor.UpdateAllComponents();
    }

    private void SetupFriendlyHeroCard(GameState state, int entityId)
    {
        Entity entity = new Entity();
        entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
        entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.HERO);
        entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.PLAY);
        entity.SetTag(GAME_TAG.HEALTH, 0x1c);
        entity.SetTag(GAME_TAG.CONTROLLER, this.m_friendlyPlayerId);
        state.AddEntity(entity);
        this.SetupCard(entity, this.m_FriendlyHeroCard, "Friendly Minion Card", this.m_HeroActor, this.m_friendlyHeroZone);
    }

    private void SetupFriendlyMinionCard(GameState state, int entityId)
    {
        Entity entity = new Entity();
        entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
        entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.MINION);
        entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.PLAY);
        entity.SetTag(GAME_TAG.HEALTH, 8);
        entity.SetTag(GAME_TAG.ATK, 4);
        entity.SetTag(GAME_TAG.COST, 2);
        entity.SetTag(GAME_TAG.CONTROLLER, this.m_friendlyPlayerId);
        entity.SetTag(GAME_TAG.ZONE_POSITION, this.m_friendlyPlayZone.GetCards().Count + 1);
        state.AddEntity(entity);
        this.SetupCard(entity, this.m_FriendlyMinionCard, "Friendly Minion Card", this.m_MinionActor, this.m_friendlyPlayZone);
    }

    private Player SetupFriendlyPlayer(GameState state, int entityId)
    {
        Player player = new Player();
        player.SetPlayerId(this.m_friendlyPlayerId);
        player.SetName("Friendly Player");
        player.SetLocal(true);
        player.SetTag(GAME_TAG.ENTITY_ID, entityId);
        player.SetTag(GAME_TAG.CONTROLLER, this.m_friendlyPlayerId);
        state.AddPlayer(player);
        return player;
    }

    private GameEntity SetupGameEntity(GameState state, int entityId)
    {
        GameEntity entity = new GameEntity();
        entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
        return entity;
    }

    private void SetupOpponentHeroCard(GameState state, int entityId)
    {
        Entity entity = new Entity();
        entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
        entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.HERO);
        entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.PLAY);
        entity.SetTag(GAME_TAG.HEALTH, 0x1c);
        entity.SetTag(GAME_TAG.CONTROLLER, this.m_opponentPlayerId);
        state.AddEntity(entity);
        this.SetupCard(entity, this.m_OpponentHeroCard, "Opponent Hero Card", this.m_HeroActor, this.m_opposingHeroZone);
    }

    private void SetupOpponentMinionCard(GameState state, int entityId)
    {
        Entity entity = new Entity();
        entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
        entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.MINION);
        entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.PLAY);
        entity.SetTag(GAME_TAG.HEALTH, 8);
        entity.SetTag(GAME_TAG.ATK, 4);
        entity.SetTag(GAME_TAG.COST, 2);
        entity.SetTag(GAME_TAG.CONTROLLER, this.m_opponentPlayerId);
        entity.SetTag(GAME_TAG.ZONE_POSITION, this.m_opposingPlayZone.GetCards().Count + 1);
        state.AddEntity(entity);
        this.SetupCard(entity, this.m_OpponentMinionCard, "Opponent Minion Card", this.m_MinionActor, this.m_opposingPlayZone);
    }

    private Player SetupOpponentPlayer(GameState state, int entityId)
    {
        Player player = new Player();
        player.SetPlayerId(this.m_opponentPlayerId);
        player.SetName("Opponent Player");
        player.SetLocal(false);
        player.SetTag(GAME_TAG.ENTITY_ID, entityId);
        player.SetTag(GAME_TAG.CONTROLLER, this.m_opponentPlayerId);
        state.AddPlayer(player);
        return player;
    }

    private void SetupSpellController()
    {
        PowerTaskList taskList = new PowerTaskList();
        this.m_SpellController.SetPowerTaskList(taskList);
        Card defaultAttacker = this.m_DefaultAttacker;
        if (defaultAttacker == null)
        {
            defaultAttacker = this.m_FriendlyMinionCard;
        }
        Card defaultDefender = this.m_DefaultDefender;
        if (defaultDefender == null)
        {
            defaultDefender = this.m_OpponentMinionCard;
        }
        this.m_SpellController.SetSource(defaultAttacker);
        this.m_SpellController.AddTarget(defaultDefender);
    }

    private void SetupTestCardDef()
    {
        AssetLoader.Get().LoadCardPrefab("CS1_042", new AssetLoader.GameObjectCallback(this.OnTestCardDefLoaded));
    }

    private void SetupZones(GameState state, Player friendlyPlayer, Player opponentPlayer)
    {
        foreach (Zone zone in ZoneMgr.Get().GetZones())
        {
            if ((zone is ZonePlay) && (zone.m_Side == Player.Side.FRIENDLY))
            {
                this.m_friendlyPlayZone = zone as ZonePlay;
                this.m_friendlyPlayZone.SetPlayer(friendlyPlayer);
            }
            else
            {
                if ((zone is ZoneHero) && (zone.m_Side == Player.Side.FRIENDLY))
                {
                    this.m_friendlyHeroZone = zone as ZoneHero;
                    this.m_friendlyHeroZone.SetPlayer(friendlyPlayer);
                    continue;
                }
                if ((zone is ZonePlay) && (zone.m_Side == Player.Side.OPPOSING))
                {
                    this.m_opposingPlayZone = zone as ZonePlay;
                    this.m_opposingPlayZone.SetPlayer(opponentPlayer);
                    continue;
                }
                if ((zone is ZoneHero) && (zone.m_Side == Player.Side.OPPOSING))
                {
                    this.m_opposingHeroZone = zone as ZoneHero;
                    this.m_opposingHeroZone.SetPlayer(opponentPlayer);
                }
            }
        }
    }

    private void Start()
    {
        this.SetupTestCardDef();
    }

    [CompilerGenerated]
    private sealed class <OnBulletTimeDelayComplete>c__Iterator111 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Ally_Attack_Test <>f__this;
        internal Hashtable <args>__0;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_BulletTimeDelay);
                    this.$PC = 1;
                    return true;

                case 1:
                {
                    object[] args = new object[] { 
                        "from", this.<>f__this.m_BulletTimeMinTimeScale, "to", 1f, "time", this.<>f__this.m_BulletTimeDuration, "easetype", this.<>f__this.m_BulletTimeEaseType, "ignoretimescale", true, "onupdate", "OnBulletTimeUpdate", "onupdatetarget", this.<>f__this.gameObject, "oncomplete", "OnBulletTimeComplete", 
                        "oncompletetarget", this.<>f__this.gameObject
                     };
                    this.<args>__0 = iTween.Hash(args);
                    iTween.ValueTo(this.<>f__this.gameObject, this.<args>__0);
                    this.$PC = -1;
                    break;
                }
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


using System;
using UnityEngine;

public class Spell_SourceTarget : MonoBehaviour
{
    private Card m_friendlyHeroCard;
    private ZoneHero m_friendlyHeroZone;
    private Card m_friendlyMinionCard;
    private int m_friendlyPlayerId = 1;
    private ZonePlay m_friendlyPlayZone;
    public Actor m_HeroActor;
    private bool m_initialized;
    public Actor m_MinionActor;
    private int m_nextEntityId;
    private Card m_opponentHeroCard;
    private Card m_opponentMinionCard;
    private int m_opponentPlayerId = 2;
    private ZoneHero m_opposingHeroZone;
    private ZonePlay m_opposingPlayZone;
    public Spell m_Spell;
    private Card m_spellCard;
    private CardDef m_testCardDef;
    private const string TEST_CARD_NAME = "CS1_042";

    private void Awake()
    {
    }

    private int GetNextEntityId()
    {
        return ++this.m_nextEntityId;
    }

    private Vector2 LayoutSourceControls(Vector2 start, Vector2 buttonSize)
    {
        Vector2 vector = start;
        Entity entity = this.m_spellCard.GetEntity();
        Card heroCard = entity.GetHeroCard();
        if (heroCard == this.m_opponentHeroCard)
        {
            GUI.Box(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Current Source: Opponent Hero");
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Make source Friendly Hero"))
            {
                entity.SetTag(GAME_TAG.CONTROLLER, this.m_friendlyPlayerId);
            }
            vector.y += 1.5f * buttonSize.y;
            return vector;
        }
        if (heroCard == this.m_friendlyHeroCard)
        {
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Make source Opponent Hero"))
            {
                entity.SetTag(GAME_TAG.CONTROLLER, this.m_opponentPlayerId);
            }
            vector.y += 1.5f * buttonSize.y;
            GUI.Box(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Current Source: Friendly Hero");
            vector.y += 1.5f * buttonSize.y;
        }
        return vector;
    }

    private void LayoutSourceTargetControls()
    {
        Vector2 buttonSize = new Vector2(200f, 30f);
        Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.25f);
        Vector2 vector3 = new Vector2((Screen.width - buttonSize.x) - vector2.x, vector2.y);
        Vector2 start = vector3;
        start = this.LayoutSourceControls(start, buttonSize);
        start.y += 1.5f * buttonSize.y;
        start = this.LayoutTargetControls(start, buttonSize);
    }

    private void LayoutStateControls()
    {
        Vector2 vector = new Vector2(200f, 30f);
        Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.05f);
        Vector2 vector3 = new Vector2((Screen.width - vector.x) - vector2.x, vector2.y);
        Vector2 vector4 = vector3;
        switch (this.m_Spell.GetActiveState())
        {
            case SpellStateType.NONE:
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Start Spell"))
                {
                    this.m_Spell.AddFinishedCallback(new Spell.FinishedCallback(this.OnSpellFinished));
                    this.m_Spell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnSpellStateFinished));
                    this.m_Spell.Activate();
                }
                vector4.y += 1.5f * vector.y;
                break;

            case SpellStateType.BIRTH:
            case SpellStateType.IDLE:
            {
                string text = string.Format("Go to {0} State", SpellStateType.ACTION);
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), text))
                {
                    this.m_Spell.ChangeState(SpellStateType.ACTION);
                }
                vector4.y += 1.5f * vector.y;
                text = string.Format("Go to {0} State", SpellStateType.CANCEL);
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), text))
                {
                    this.m_Spell.ChangeState(SpellStateType.CANCEL);
                }
                vector4.y += 1.5f * vector.y;
                break;
            }
        }
    }

    private Vector2 LayoutTargetControls(Vector2 start, Vector2 buttonSize)
    {
        Vector2 vector = start;
        Card targetCard = this.m_Spell.GetTargetCard();
        if (targetCard == this.m_opponentHeroCard)
        {
            GUI.Box(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Current Target: Opponent Hero");
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Opponent Minion"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_opponentMinionCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Friendly Minion"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_friendlyMinionCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Friendly Hero"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_friendlyHeroCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            return vector;
        }
        if (targetCard == this.m_opponentMinionCard)
        {
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Opponent Hero"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_opponentHeroCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            GUI.Box(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Current Target: Opponent Minion");
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Friendly Minion"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_friendlyMinionCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Friendly Hero"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_friendlyHeroCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            return vector;
        }
        if (targetCard == this.m_friendlyMinionCard)
        {
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Opponent Hero"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_opponentHeroCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Opponent Minion"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_opponentMinionCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            GUI.Box(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Current Target: Friendly Minion");
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Friendly Hero"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_friendlyHeroCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            return vector;
        }
        if (targetCard == this.m_friendlyHeroCard)
        {
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Opponent Hero"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_opponentHeroCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Opponent Minion"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_opponentMinionCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Target Friendly Minion"))
            {
                this.m_Spell.RemoveAllTargets();
                this.m_Spell.AddTarget(this.m_friendlyMinionCard.gameObject);
            }
            vector.y += 1.5f * buttonSize.y;
            GUI.Box(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Current Target: Friendly Hero");
            vector.y += 1.5f * buttonSize.y;
        }
        return vector;
    }

    private void OnFriendlyHeroUpdateLayoutComplete(Zone zone, object userData)
    {
        this.m_Spell.transform.position = this.m_friendlyHeroCard.transform.position;
    }

    private void OnGUI()
    {
        if (this.m_initialized)
        {
            this.LayoutSourceTargetControls();
            this.LayoutStateControls();
        }
    }

    private void OnSpellFinished(Spell spell, object userData)
    {
    }

    private void OnSpellStateFinished(Spell spell, SpellStateType stateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            Card sourceCard = this.m_Spell.GetSourceCard();
            spell.transform.position = sourceCard.transform.position;
        }
    }

    private void OnTestCardDefLoaded(string cardName, GameObject cardObject, object callbackData)
    {
        this.m_testCardDef = cardObject.GetComponent<CardDef>();
        GameState state = GameState.Initialize();
        Player friendlyPlayer = this.SetupFriendlyPlayer(state, this.GetNextEntityId());
        Player opponentPlayer = this.SetupOpponentPlayer(state, this.GetNextEntityId());
        this.SetupZones(state, friendlyPlayer, opponentPlayer);
        this.SetupFriendlyHeroCard(state, this.GetNextEntityId());
        this.SetupFriendlyMinionCard(state, this.GetNextEntityId());
        this.SetupOpponentHeroCard(state, this.GetNextEntityId());
        this.SetupOpponentMinionCard(state, this.GetNextEntityId());
        this.SetupSpellCard(state, this.GetNextEntityId());
        this.m_initialized = true;
    }

    private void SetupCard(Entity entity, Card card, string name, Actor actorPrefab, Zone zone)
    {
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
        this.m_friendlyHeroZone.AddUpdateLayoutCompleteCallback(new Zone.UpdateLayoutCompleteCallback(this.OnFriendlyHeroUpdateLayoutComplete));
        this.m_friendlyHeroCard = entity.InitCard();
        this.SetupCard(entity, this.m_friendlyHeroCard, "Friendly Hero Card", this.m_HeroActor, this.m_friendlyHeroZone);
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
        this.m_friendlyMinionCard = entity.InitCard();
        this.SetupCard(entity, this.m_friendlyMinionCard, "Friendly Minion Card", this.m_MinionActor, this.m_friendlyPlayZone);
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

    private void SetupOpponentHeroCard(GameState state, int entityId)
    {
        Entity entity = new Entity();
        entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
        entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.HERO);
        entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.PLAY);
        entity.SetTag(GAME_TAG.HEALTH, 0x1c);
        entity.SetTag(GAME_TAG.CONTROLLER, this.m_opponentPlayerId);
        state.AddEntity(entity);
        this.m_opponentHeroCard = entity.InitCard();
        this.SetupCard(entity, this.m_opponentHeroCard, "Opponent Hero Card", this.m_HeroActor, this.m_opposingHeroZone);
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
        this.m_opponentMinionCard = entity.InitCard();
        this.SetupCard(entity, this.m_opponentMinionCard, "Opponent Minion Card", this.m_MinionActor, this.m_opposingPlayZone);
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

    private void SetupSpellCard(GameState state, int entityId)
    {
        if (this.m_Spell != null)
        {
            Entity entity = new Entity();
            entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
            entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.ABILITY);
            entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.PLAY);
            entity.SetTag(GAME_TAG.CONTROLLER, this.m_friendlyPlayerId);
            state.AddEntity(entity);
            this.m_spellCard = entity.InitCard();
            this.m_spellCard.name = this.m_Spell.name;
            this.m_Spell.SetSource(this.m_spellCard.gameObject);
            this.m_Spell.AddTarget(this.m_opponentHeroCard.gameObject);
        }
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
}


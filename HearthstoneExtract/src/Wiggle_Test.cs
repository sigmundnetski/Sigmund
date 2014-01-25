using System;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle_Test : MonoBehaviour
{
    private ZoneHero m_friendlyHeroZone;
    public CardDef m_FriendlyMinionCard;
    private int m_friendlyPlayerId = 1;
    private ZonePlay m_friendlyPlayZone;
    public Actor m_MinionActor;
    private int m_nextEntityId;
    public CardDef m_OpponentMinionCard;
    private int m_opponentPlayerId = 2;
    private ZoneHero m_opposingHeroZone;
    private ZonePlay m_opposingPlayZone;
    private const int MAX_CARDS_PER_ZONE = 7;

    private void AddToChoices(int entityId)
    {
        GameState.Get().GetChoicePacket().Entities.Add(entityId);
    }

    private void Awake()
    {
        GameState.Initialize();
    }

    private void CreateMinionCard(int controllerId, int entityId)
    {
        Entity entity = new Entity();
        entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
        entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.MINION);
        entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.PLAY);
        entity.SetTag(GAME_TAG.HEALTH, 8);
        entity.SetTag(GAME_TAG.ATK, 4);
        entity.SetTag(GAME_TAG.COST, 2);
        entity.SetTag(GAME_TAG.CONTROLLER, controllerId);
        GameState.Get().AddEntity(entity);
        if (controllerId == this.m_friendlyPlayerId)
        {
            this.SetupCard(entity, this.m_FriendlyMinionCard, this.m_MinionActor, this.m_friendlyPlayZone);
        }
        else
        {
            this.SetupCard(entity, this.m_OpponentMinionCard, this.m_MinionActor, this.m_opposingPlayZone);
        }
        this.AddToChoices(entityId);
    }

    private void DestroyMinionCard(Card card, Zone zone)
    {
        Entity entity = card.GetEntity();
        GameState.Get().RemoveEntity(entity);
        zone.RemoveCard(card);
        entity.Destroy();
        this.RemoveFromChoices(entity.GetEntityId());
    }

    private int GetNextEntityId()
    {
        return ++this.m_nextEntityId;
    }

    private void LayoutFriendlyMinionControls()
    {
        Vector2 vector = new Vector2(200f, 30f);
        Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.5f);
        Vector2 vector3 = new Vector2(vector2.x, vector2.y);
        Vector2 vector4 = vector3;
        int count = this.m_friendlyPlayZone.GetCards().Count;
        if (count < 7)
        {
            if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Add Friendly Minion"))
            {
                this.CreateMinionCard(this.m_friendlyPlayerId, this.GetNextEntityId());
            }
        }
        else
        {
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Friendly Play Zone Full");
        }
        vector4.y += 1.5f * vector.y;
        if ((count > 0) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Destroy Friendly Minion"))
        {
            List<Card> cards = this.m_friendlyPlayZone.GetCards();
            int num2 = cards.Count - 1;
            Card card = cards[num2];
            this.DestroyMinionCard(card, this.m_friendlyPlayZone);
        }
        vector4.y += 1.5f * vector.y;
    }

    private void LayoutMinionControls()
    {
        this.LayoutOpposingMinionControls();
        this.LayoutFriendlyMinionControls();
    }

    private void LayoutOpposingMinionControls()
    {
        Vector2 vector = new Vector2(200f, 30f);
        Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.35f);
        Vector2 vector3 = new Vector2(vector2.x, vector2.y);
        Vector2 vector4 = vector3;
        int count = this.m_opposingPlayZone.GetCards().Count;
        if (count < 7)
        {
            if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Add Opposing Minion"))
            {
                this.CreateMinionCard(this.m_opponentPlayerId, this.GetNextEntityId());
            }
        }
        else
        {
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Opposing Play Zone Full");
        }
        vector4.y += 1.5f * vector.y;
        if ((count > 0) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Destroy Opposing Minion"))
        {
            List<Card> cards = this.m_opposingPlayZone.GetCards();
            int num2 = cards.Count - 1;
            Card card = cards[num2];
            this.DestroyMinionCard(card, this.m_opposingPlayZone);
        }
        vector4.y += 1.5f * vector.y;
    }

    private void OnGUI()
    {
        this.LayoutMinionControls();
    }

    private void RemoveFromChoices(int entityId)
    {
        GameState.Get().GetChoicePacket().Entities.Remove(entityId);
    }

    private void SetupCard(Entity entity, CardDef cardDef, Actor actorPrefab, Zone zone)
    {
        entity.SetTag(GAME_TAG.ZONE_POSITION, zone.GetCards().Count + 1);
        Card card = entity.InitCard();
        card.SetEntity(entity);
        card.LoadCardDef(cardDef);
        Actor actor = (Actor) UnityEngine.Object.Instantiate(actorPrefab);
        card.SetActor(actor);
        actor.SetCard(card);
        actor.SetEntity(entity);
        card.SetZone(zone);
        zone.AddCard(card);
        zone.UpdateLayout();
        actor.UpdateAllComponents();
    }

    private void SetupChoicePacket(GameState state)
    {
        Network.Choice choice = new Network.Choice {
            Entities = new List<int>()
        };
        state.OnMakeChoice(choice);
    }

    private Player SetupFriendlyPlayer(GameState state, int entityId)
    {
        Player player = new Player();
        player.SetPlayerId(this.m_friendlyPlayerId);
        player.SetName("Friendly Player");
        player.SetLocal(true);
        player.SetTag(GAME_TAG.ENTITY_ID, entityId);
        player.SetTag(GAME_TAG.CONTROLLER, this.m_friendlyPlayerId);
        player.SetTag(GAME_TAG.CURRENT_PLAYER, 1);
        state.AddPlayer(player);
        return player;
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
        GameState state = GameState.Get();
        Player friendlyPlayer = this.SetupFriendlyPlayer(state, this.GetNextEntityId());
        Player opponentPlayer = this.SetupOpponentPlayer(state, this.GetNextEntityId());
        this.SetupZones(state, friendlyPlayer, opponentPlayer);
        this.SetupChoicePacket(state);
        this.CreateMinionCard(friendlyPlayer.GetPlayerId(), this.GetNextEntityId());
    }
}


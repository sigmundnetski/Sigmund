using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawCard : MonoBehaviour
{
    private const int FAKE_PLAYER_ID = 1;
    private GameState m_state;
    public Player myPlayer;
    public ZoneMgr zoneManager;

    private void Awake()
    {
        this.m_state = GameState.Initialize();
    }

    private void OnMouseDown()
    {
        List<Zone> zones = ZoneMgr.Get().GetZones();
        Zone zone = null;
        foreach (Zone zone2 in zones)
        {
            if ((zone2.m_ServerTag == TAG_ZONE.HAND) && (zone2.m_Side == Player.Side.FRIENDLY))
            {
                zone = zone2;
            }
        }
        if (zone.GetCards().Count < 10)
        {
            Entity entity = new Entity();
            entity.InitCard();
            entity.SetTag(GAME_TAG.ENTITY_ID, this.m_state.GetEntityMap().Values.Count + 1);
            entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.HAND);
            entity.SetTag(GAME_TAG.HEALTH, 3);
            entity.SetTag(GAME_TAG.ATK, 1);
            entity.SetTag(GAME_TAG.COST, 2);
            entity.SetTag(GAME_TAG.CONTROLLER, 1);
            this.m_state.AddEntity(entity);
            entity.LoadCard("EX1_015");
            if (zone == null)
            {
            }
        }
    }

    private void Start()
    {
        GameEntity entity = MissionMgr.Get().CreateGameEntity();
        entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.GAME);
        entity.SetTag<TAG_STATE_ENUM>(GAME_TAG.STATE, TAG_STATE_ENUM.RUNNING);
        entity.SetTag(GAME_TAG.TURN, 1);
        entity.SetTag<TAG_STEP>(GAME_TAG.STEP, TAG_STEP.BEGIN_MULLIGAN);
        entity.SetTag(GAME_TAG.ENTITY_ID, 0);
        this.m_state.AddEntity(entity);
        Player player = new Player();
        player.SetName("Player 1");
        player.SetPlayerId(1);
        player.SetLocal(true);
        player.SetTag(GAME_TAG.ENTITY_ID, this.m_state.GetEntityMap().Values.Count + 1);
        player.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.PLAYER);
        player.SetTag(GAME_TAG.CONTROLLER, 1);
        this.m_state.AddPlayer(player);
        player.OnBoardLoaded();
        this.myPlayer = player;
        Animation animation = Board.Get().animation;
        animation[animation.clip.name].normalizedTime = 0f;
        animation[animation.clip.name].speed = 1f;
        animation.Play(animation.clip.name);
    }

    private void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            Entity entity = new Entity();
            entity.InitCard();
            entity.SetTag(GAME_TAG.ENTITY_ID, this.m_state.GetEntityMap().Values.Count + 1);
            entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.MINION);
            entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.HAND);
            entity.SetTag(GAME_TAG.COST, 2);
            entity.SetTag(GAME_TAG.CONTROLLER, 1);
            this.m_state.AddEntity(entity);
            entity.LoadCard("EX1_015");
        }
        if (Input.GetKeyDown("right"))
        {
            GameState.Get().GetGameEntity().SetTag<TAG_STEP>(GAME_TAG.STEP, TAG_STEP.BEGIN_MULLIGAN);
            if (base.gameObject.GetComponent<MulliganManager>().mulliganMode)
            {
                base.gameObject.GetComponent<MulliganManager>().EndMulligan();
            }
            else
            {
                base.gameObject.GetComponent<MulliganManager>().BeginMulligan();
            }
        }
    }
}


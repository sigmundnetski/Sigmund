using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Hand_Test : MonoBehaviour
{
    private int lastCardSpawned;
    private ZoneHand m_friendlyHandZone;
    private Card m_friendlyHeroCard;
    private ZoneHero m_friendlyHeroZone;
    private int m_friendlyPlayerId = 1;
    private ZonePlay m_friendlyPlayZone;
    private bool m_initialized;
    private int m_nextEntityId;
    private Card m_opponentHeroCard;
    private int m_opponentPlayerId = 2;
    private ZoneHand m_opposingHandZone;
    private ZoneHero m_opposingHeroZone;
    private ZonePlay m_opposingPlayZone;
    private List<CardDef> m_testCardDefs = new List<CardDef>();
    private const int MAX_CARDS_PER_ZONE = 10;
    private string[] TEST_CARD_NAME = new string[] { "CS1_042", "CS2_029" };

    private Card CreateMinionCard(int controllerId, int entityId, Zone zone)
    {
        Entity entity = new Entity();
        entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
        if (this.lastCardSpawned == 0)
        {
            entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.MINION);
        }
        else
        {
            entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.ABILITY);
        }
        entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, zone.m_ServerTag);
        entity.SetTag(GAME_TAG.CONTROLLER, controllerId);
        entity.SetTag(GAME_TAG.ZONE_POSITION, zone.GetCards().Count + 1);
        GameState.Get().AddEntity(entity);
        Card card = entity.InitCard();
        if ((this.m_testCardDefs.Count > 0) && (this.m_testCardDefs[0] != null))
        {
            entity.LoadCard(this.TEST_CARD_NAME[this.lastCardSpawned]);
            card.LoadCardDef(this.m_testCardDefs[this.lastCardSpawned]);
        }
        this.lastCardSpawned++;
        if (this.lastCardSpawned >= this.m_testCardDefs.Count)
        {
            this.lastCardSpawned = 0;
        }
        base.StartCoroutine(this.WaitForDefAndUpdateActor(entity));
        if (controllerId == this.m_friendlyPlayerId)
        {
            card.name = string.Format("Minion Card (Friendly {0})", zone.GetCards().Count);
            return card;
        }
        card.name = string.Format("Minion Card (Opponent {0})", zone.GetCards().Count);
        return card;
    }

    private void DestroyMinionCard(Card card, Zone zone)
    {
        Entity entity = card.GetEntity();
        GameState.Get().RemoveEntity(entity);
        zone.RemoveCard(card);
        zone.UpdateLayout();
        entity.Destroy();
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
        int count = this.m_friendlyHandZone.GetCards().Count;
        if (count < 10)
        {
            if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Add Friendly Minion"))
            {
                this.CreateMinionCard(this.m_friendlyPlayerId, this.GetNextEntityId(), this.m_friendlyHandZone);
            }
        }
        else
        {
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Friendly Play Zone Full");
        }
        vector4.y += 1.5f * vector.y;
        if ((count > 0) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Destroy Friendly Minion"))
        {
            List<Card> cards = this.m_friendlyHandZone.GetCards();
            int num2 = cards.Count - 1;
            Card card = cards[num2];
            this.DestroyMinionCard(card, this.m_friendlyHandZone);
        }
        vector4.y += 1.5f * vector.y;
    }

    private void LayoutMinionControls()
    {
        if (this.m_initialized)
        {
            this.LayoutOpposingMinionControls();
            this.LayoutFriendlyMinionControls();
        }
    }

    private void LayoutOpposingMinionControls()
    {
        Vector2 vector = new Vector2(200f, 30f);
        Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.35f);
        Vector2 vector3 = new Vector2(vector2.x, vector2.y);
        Vector2 vector4 = vector3;
        int count = this.m_opposingHandZone.GetCards().Count;
        if (count < 10)
        {
            if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Add Opposing Minion"))
            {
                this.CreateMinionCard(this.m_opponentPlayerId, this.GetNextEntityId(), this.m_opposingHandZone);
            }
        }
        else
        {
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Opposing Play Zone Full");
        }
        vector4.y += 1.5f * vector.y;
        if ((count > 0) && GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Destroy Opposing Minion"))
        {
            List<Card> cards = this.m_opposingHandZone.GetCards();
            int num2 = cards.Count - 1;
            Card card = cards[num2];
            this.DestroyMinionCard(card, this.m_opposingHandZone);
        }
        vector4.y += 1.5f * vector.y;
    }

    private void OnGUI()
    {
        this.LayoutMinionControls();
    }

    private void OnTestCardDefLoaded(string cardName, GameObject cardObject, object callbackData)
    {
        this.m_testCardDefs.Add(cardObject.GetComponent<CardDef>());
        GameState state = GameState.Initialize();
        Player friendlyPlayer = this.SetupFriendlyPlayer(state, this.GetNextEntityId());
        Player opponentPlayer = this.SetupOpponentPlayer(state, this.GetNextEntityId());
        this.SetupZones(state, friendlyPlayer, opponentPlayer);
        this.SetupFriendlyHeroCard(state, this.GetNextEntityId());
        this.SetupOpponentHeroCard(state, this.GetNextEntityId());
        GameEntity entity = MissionMgr.Get().CreateGameEntity();
        entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.GAME);
        entity.SetTag<TAG_STATE_ENUM>(GAME_TAG.STATE, TAG_STATE_ENUM.RUNNING);
        entity.SetTag(GAME_TAG.TURN, 1);
        entity.SetTag<TAG_STEP>(GAME_TAG.STEP, TAG_STEP.MAIN_ACTION);
        entity.SetTag(GAME_TAG.ENTITY_ID, 0);
        GameState.Get().AddEntity(entity);
        this.m_friendlyHandZone.SetDoNotUpdateLayout(false);
        this.m_opposingHandZone.SetDoNotUpdateLayout(false);
        this.m_initialized = true;
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
        this.m_friendlyHeroCard = entity.InitCard();
        if ((this.m_testCardDefs.Count > 0) && (this.m_testCardDefs[0] != null))
        {
            this.m_friendlyHeroCard.LoadCardDef(this.m_testCardDefs[0]);
        }
        this.m_friendlyHeroCard.UpdateZoneFromTags();
        this.m_friendlyHeroCard.name = "Hero Card (Friendly)";
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
        this.m_opponentHeroCard.name = entity.GetName();
        if ((this.m_testCardDefs.Count > 0) && (this.m_testCardDefs[0] != null))
        {
            this.m_opponentHeroCard.LoadCardDef(this.m_testCardDefs[0]);
        }
        this.m_opponentHeroCard.UpdateZoneFromTags();
        this.m_opponentHeroCard.name = "Hero Card (Opponent)";
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

    private void SetupTestCardDef()
    {
        AssetLoader.Get().LoadCardPrefab(this.TEST_CARD_NAME[0], new AssetLoader.GameObjectCallback(this.OnTestCardDefLoaded));
        AssetLoader.Get().LoadCardPrefab(this.TEST_CARD_NAME[1], new AssetLoader.GameObjectCallback(this.OnTestCardDefLoaded));
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
                if ((zone is ZoneHand) && (zone.m_Side == Player.Side.FRIENDLY))
                {
                    this.m_friendlyHandZone = zone as ZoneHand;
                    this.m_friendlyHandZone.SetPlayer(friendlyPlayer);
                    continue;
                }
                if ((zone is ZoneHand) && (zone.m_Side == Player.Side.OPPOSING))
                {
                    this.m_opposingHandZone = zone as ZoneHand;
                    this.m_opposingHandZone.SetPlayer(opponentPlayer);
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

    private void Update()
    {
        if (!this.m_initialized)
        {
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitForDefAndUpdateActor(Entity entity)
    {
        return new <WaitForDefAndUpdateActor>c__Iterator113 { entity = entity, <$>entity = entity };
    }

    [CompilerGenerated]
    private sealed class <WaitForDefAndUpdateActor>c__Iterator113 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Entity <$>entity;
        internal Entity entity;

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
                    if ((this.entity.IsEntityDefLoading() || this.entity.IsLoading()) || this.entity.IsCardDefLoading())
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.entity.GetCard().UpdateZoneFromTags();
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


using System;
using System.Collections.Generic;
using UnityEngine;

public class Spell_AreaEffect_Test : MonoBehaviour
{
    private Card m_friendlyHeroCard;
    private ZoneHero m_friendlyHeroZone;
    private int m_friendlyPlayerId = 1;
    private ZonePlay m_friendlyPlayZone;
    private bool m_initialized;
    private int m_nextEntityId;
    private Card m_opponentHeroCard;
    private int m_opponentPlayerId = 2;
    private ZoneHero m_opposingHeroZone;
    private ZonePlay m_opposingPlayZone;
    public Spell m_Spell;
    private Card m_spellCard;
    private CardDef m_testCardDef;
    private const int MAX_CARDS_PER_ZONE = 7;
    private const string TEST_CARD_NAME = "CS1_042";

    private void Awake()
    {
    }

    private Card CreateMinionCard(int controllerId, int entityId, Zone zone)
    {
        Entity entity = new Entity();
        entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
        entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.MINION);
        entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.PLAY);
        entity.SetTag(GAME_TAG.HEALTH, 8);
        entity.SetTag(GAME_TAG.ATK, 4);
        entity.SetTag(GAME_TAG.COST, 2);
        entity.SetTag(GAME_TAG.CONTROLLER, controllerId);
        entity.SetTag(GAME_TAG.ZONE_POSITION, zone.GetCards().Count + 1);
        GameState.Get().AddEntity(entity);
        Card card = entity.InitCard();
        if (this.m_testCardDef != null)
        {
            card.LoadCardDef(this.m_testCardDef);
        }
        card.UpdateZoneFromTags();
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
        int count = this.m_friendlyPlayZone.GetCards().Count;
        if (count < 7)
        {
            if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Add Friendly Minion"))
            {
                this.CreateMinionCard(this.m_friendlyPlayerId, this.GetNextEntityId(), this.m_friendlyPlayZone);
                if (this.m_Spell != null)
                {
                    this.UpdateSpellTargets();
                }
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
            if (this.m_Spell != null)
            {
                this.UpdateSpellTargets();
            }
            this.DestroyMinionCard(card, this.m_friendlyPlayZone);
        }
        vector4.y += 1.5f * vector.y;
    }

    private void LayoutMinionControls()
    {
        if (this.m_initialized && ((this.m_Spell == null) || (this.m_Spell.GetActiveState() == SpellStateType.NONE)))
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
        int count = this.m_opposingPlayZone.GetCards().Count;
        if (count < 7)
        {
            if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Add Opposing Minion"))
            {
                this.CreateMinionCard(this.m_opponentPlayerId, this.GetNextEntityId(), this.m_opposingPlayZone);
                if (this.m_Spell != null)
                {
                    this.UpdateSpellTargets();
                }
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
            if (this.m_Spell != null)
            {
                this.UpdateSpellTargets();
            }
            this.DestroyMinionCard(card, this.m_opposingPlayZone);
        }
        vector4.y += 1.5f * vector.y;
    }

    private void LayoutSpellControls()
    {
        if ((this.m_initialized && (this.m_Spell != null)) && (this.m_Spell.GetActiveState() == SpellStateType.NONE))
        {
            Vector2 vector = new Vector2(250f, 30f);
            Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.05f);
            Vector2 vector3 = new Vector2((Screen.width - vector.x) - vector2.x, vector2.y);
            Vector2 vector4 = vector3;
            if (this.m_spellCard.GetEntity().GetHeroCard() == this.m_opponentHeroCard)
            {
                GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Current Spell Cast: Opponent -> Friendly");
                vector4.y += 1.5f * vector.y;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Switch to Friendly -> Opponent"))
                {
                    this.m_spellCard.GetEntity().SetTag(GAME_TAG.CONTROLLER, this.m_friendlyPlayerId);
                    this.UpdateSpellTargets();
                }
                vector4.y += 1.5f * vector.y;
            }
            else
            {
                GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Current Spell Cast: Friendly -> Opponent");
                vector4.y += 1.5f * vector.y;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Switch to Opponent -> Friendly"))
                {
                    this.m_spellCard.GetEntity().SetTag(GAME_TAG.CONTROLLER, this.m_opponentPlayerId);
                    this.UpdateSpellTargets();
                }
                vector4.y += 1.5f * vector.y;
            }
            vector4.y += 1.5f * vector.y;
            if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Start Spell"))
            {
                this.m_Spell.AddFinishedCallback(new Spell.FinishedCallback(this.OnSpellFinished));
                this.m_Spell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnSpellStateFinished));
                this.m_Spell.Activate();
            }
            vector4.y += 1.5f * vector.y;
        }
    }

    private void OnGUI()
    {
        this.LayoutSpellControls();
        this.LayoutMinionControls();
    }

    private void OnSpellFinished(Spell spell, object userData)
    {
    }

    private void OnSpellStateFinished(Spell spell, SpellStateType stateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
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
        this.SetupOpponentHeroCard(state, this.GetNextEntityId());
        this.SetupSpellCard(state, this.GetNextEntityId());
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
        if (this.m_testCardDef != null)
        {
            this.m_friendlyHeroCard.LoadCardDef(this.m_testCardDef);
        }
        this.m_friendlyHeroCard.UpdateZoneFromTags();
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
        if (this.m_testCardDef != null)
        {
            this.m_opponentHeroCard.LoadCardDef(this.m_testCardDef);
        }
        this.m_opponentHeroCard.UpdateZoneFromTags();
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
            this.UpdateSpellTargets();
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

    private void UpdateSpellTargets()
    {
        this.m_Spell.RemoveAllTargets();
        Card heroCard = this.m_spellCard.GetEntity().GetHeroCard();
        List<Card> cards = null;
        if (heroCard == this.m_friendlyHeroCard)
        {
            cards = this.m_opposingPlayZone.GetCards();
            this.m_Spell.AddTarget(this.m_opponentHeroCard.gameObject);
        }
        else if (heroCard == this.m_opponentHeroCard)
        {
            cards = this.m_friendlyPlayZone.GetCards();
            this.m_Spell.AddTarget(this.m_friendlyHeroCard.gameObject);
        }
        else
        {
            return;
        }
        for (int i = 0; i < cards.Count; i++)
        {
            this.m_Spell.AddTarget(cards[i].gameObject);
        }
    }
}


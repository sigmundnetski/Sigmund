using System;
using System.Collections.Generic;
using UnityEngine;

public class SuperSpell_Test : MonoBehaviour
{
    public SpellType m_ActivateSpellOnTargets;
    private Card m_friendlyHeroCard;
    private ZoneHero m_friendlyHeroZone;
    private int m_friendlyPlayerId = 1;
    private ZonePlay m_friendlyPlayZone;
    private int m_healthChangeAmountMax = 10;
    public int m_HealthChangeAmountMax = 10;
    private int m_healthChangeAmountMin = 1;
    public int m_HealthChangeAmountMin = 1;
    private HealthChangeType m_healthChangeType;
    public HealthChangeType m_HealthChangeType;
    private bool m_initialized;
    private int m_nextEntityId;
    private Card m_opponentHeroCard;
    private int m_opponentPlayerId = 2;
    private ZoneHero m_opposingHeroZone;
    private ZonePlay m_opposingPlayZone;
    private Spell m_spell;
    public Spell m_Spell;
    private Card m_spellCard;
    private bool m_targetHeroes = true;
    private CardDef m_testCardDef;
    private const int MAX_CARDS_PER_ZONE = 7;
    private const string TEST_CARD_NAME = "CS1_042";

    private void Awake()
    {
        this.InitCachedEditorData();
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
        if (controllerId == this.m_friendlyPlayerId)
        {
            card.name = string.Format("Minion Card (Friendly {0})", zone.GetCards().Count);
            return card;
        }
        card.name = string.Format("Minion Card (Opponent {0})", zone.GetCards().Count);
        return card;
    }

    private void CreatePowerTaskForTarget(PowerTaskList taskList, Card card)
    {
        if (this.m_HealthChangeType != HealthChangeType.NO_CHANGE)
        {
            Network.HistTagChange netPower = new Network.HistTagChange {
                Entity = card.GetEntity().GetEntityId(),
                Tag = 0x2c,
                Value = this.GetRandomHealthChangeAmount()
            };
            taskList.CreateTask(netPower);
        }
    }

    private void DestroyMinionCard(Card card, Zone zone)
    {
        Entity entity = card.GetEntity();
        GameState.Get().RemoveEntity(entity);
        zone.RemoveCard(card);
        zone.UpdateLayout();
        entity.Destroy();
    }

    private void ForceAddAllTargets()
    {
        if (this.m_targetHeroes)
        {
            Card targetHeroCard = this.GetTargetHeroCard();
            if ((targetHeroCard != null) && !this.m_spell.IsTarget(targetHeroCard.gameObject))
            {
                this.m_spell.AddTarget(targetHeroCard.gameObject);
            }
        }
        List<Card> targetMinionCards = this.GetTargetMinionCards();
        if (targetMinionCards != null)
        {
            for (int i = 0; i < targetMinionCards.Count; i++)
            {
                GameObject gameObject = targetMinionCards[i].gameObject;
                if (!this.m_spell.IsTarget(gameObject))
                {
                    this.m_spell.AddTarget(gameObject);
                }
            }
        }
    }

    private int GetNextEntityId()
    {
        return ++this.m_nextEntityId;
    }

    private int GetRandomHealthChangeAmount()
    {
        HealthChangeType healthChangeType = this.m_HealthChangeType;
        if (healthChangeType != HealthChangeType.DAMAGE)
        {
            if (healthChangeType == HealthChangeType.HEALING)
            {
                return -UnityEngine.Random.Range(this.m_HealthChangeAmountMin, this.m_HealthChangeAmountMax + 1);
            }
            return 0;
        }
        return UnityEngine.Random.Range(this.m_HealthChangeAmountMin, this.m_HealthChangeAmountMax + 1);
    }

    private Card GetTargetHeroCard()
    {
        Card heroCard = this.m_spellCard.GetEntity().GetHeroCard();
        if (heroCard == this.m_friendlyHeroCard)
        {
            return this.m_opponentHeroCard;
        }
        if (heroCard == this.m_opponentHeroCard)
        {
            return this.m_friendlyHeroCard;
        }
        return null;
    }

    private List<Card> GetTargetMinionCards()
    {
        Card heroCard = this.m_spellCard.GetEntity().GetHeroCard();
        if (heroCard == this.m_friendlyHeroCard)
        {
            return this.m_opposingPlayZone.GetCards();
        }
        if (heroCard == this.m_opponentHeroCard)
        {
            return this.m_friendlyPlayZone.GetCards();
        }
        return null;
    }

    private void InitCachedEditorData()
    {
        this.m_spell = this.m_Spell;
        this.m_healthChangeType = this.m_HealthChangeType;
        this.m_healthChangeAmountMin = this.m_HealthChangeAmountMin;
        this.m_healthChangeAmountMax = this.m_HealthChangeAmountMax;
    }

    private bool IsCachedEditorDataStale()
    {
        return ((this.m_spell != this.m_Spell) || ((this.m_healthChangeType != this.m_HealthChangeType) || ((this.m_healthChangeAmountMin != this.m_HealthChangeAmountMin) || (this.m_healthChangeAmountMax != this.m_HealthChangeAmountMax))));
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
                if (this.m_spell != null)
                {
                    this.UpdateSpell();
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
            this.DestroyMinionCard(card, this.m_friendlyPlayZone);
            if (this.m_spell != null)
            {
                this.UpdateSpell();
            }
        }
        vector4.y += 1.5f * vector.y;
    }

    private void LayoutMinionControls()
    {
        if (this.m_initialized && ((this.m_spell == null) || (this.m_spell.GetActiveState() == SpellStateType.NONE)))
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
                if (this.m_spell != null)
                {
                    this.UpdateSpell();
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
            this.DestroyMinionCard(card, this.m_opposingPlayZone);
            if (this.m_spell != null)
            {
                this.UpdateSpell();
            }
        }
        vector4.y += 1.5f * vector.y;
    }

    private void LayoutSpellControls()
    {
        if (this.m_initialized && (this.m_spell != null))
        {
            switch (this.m_spell.GetActiveState())
            {
                case SpellStateType.ACTION:
                case SpellStateType.DEATH:
                case SpellStateType.CANCEL:
                    return;
            }
            Vector2 buttonSize = new Vector2(250f, 30f);
            Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.05f);
            Vector2 vector3 = new Vector2((Screen.width - buttonSize.x) - vector2.x, vector2.y);
            Vector2 start = vector3;
            start = this.LayoutSpellTargetControls(start, buttonSize);
            start.y += 1.5f * buttonSize.y;
            start = this.LayoutSpellStateControls(start, buttonSize);
        }
    }

    private Vector2 LayoutSpellStateControls(Vector2 start, Vector2 buttonSize)
    {
        SpellStateType activeState = this.m_spell.GetActiveState();
        Vector2 vector = start;
        vector.y += 1.5f * buttonSize.y;
        GUI.Box(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), string.Format("Current Spell State: {0}", activeState));
        vector.y += 1.5f * buttonSize.y;
        if ((activeState == SpellStateType.NONE) && GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Do Spell Birth"))
        {
            this.m_spell.ActivateState(SpellStateType.BIRTH);
        }
        vector.y += 1.5f * buttonSize.y;
        if ((((activeState == SpellStateType.NONE) || (activeState == SpellStateType.BIRTH)) || (activeState == SpellStateType.IDLE)) && GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Do Spell Action"))
        {
            this.ResetPowerTasks();
            this.m_spell.ActivateState(SpellStateType.ACTION);
        }
        vector.y += 1.5f * buttonSize.y;
        if (((activeState == SpellStateType.BIRTH) || (activeState == SpellStateType.IDLE)) && GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Do Spell Cancel"))
        {
            this.m_spell.ActivateState(SpellStateType.CANCEL);
        }
        vector.y += 1.5f * buttonSize.y;
        return vector;
    }

    private Vector2 LayoutSpellTargetControls(Vector2 start, Vector2 buttonSize)
    {
        Vector2 vector = start;
        if (this.m_spellCard.GetEntity().GetHeroCard() == this.m_opponentHeroCard)
        {
            GUI.Box(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Current Spell Cast: Opponent -> Friendly");
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Switch to Friendly -> Opponent"))
            {
                this.m_spellCard.GetEntity().SetTag(GAME_TAG.CONTROLLER, this.m_friendlyPlayerId);
                this.UpdateSpell();
            }
            vector.y += 1.5f * buttonSize.y;
        }
        else
        {
            GUI.Box(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Current Spell Cast: Friendly -> Opponent");
            vector.y += 1.5f * buttonSize.y;
            if (GUI.Button(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), "Switch to Opponent -> Friendly"))
            {
                this.m_spellCard.GetEntity().SetTag(GAME_TAG.CONTROLLER, this.m_opponentPlayerId);
                this.UpdateSpell();
            }
            vector.y += 1.5f * buttonSize.y;
        }
        GUI.Box(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), string.Empty);
        bool flag = GUI.Toggle(new Rect(vector.x, vector.y, buttonSize.x, buttonSize.y), this.m_targetHeroes, "Target Heroes");
        if (flag != this.m_targetHeroes)
        {
            this.m_targetHeroes = flag;
            this.UpdateSpell();
        }
        vector.y += 1.5f * buttonSize.y;
        return vector;
    }

    private void OnGUI()
    {
        this.LayoutSpellControls();
        this.LayoutMinionControls();
    }

    private void OnSpellFinished(Spell spell, object userData)
    {
        int num = 0;
        foreach (PowerTask task in spell.GetPowerTaskList().GetTaskList())
        {
            Network.HistTagChange power = task.GetPower() as Network.HistTagChange;
            Card card = GameState.Get().GetEntity(power.Entity).GetCard();
            if (card != null)
            {
                if (!task.IsCompleted())
                {
                    task.DoTask();
                }
                num++;
                if (this.m_ActivateSpellOnTargets != SpellType.NONE)
                {
                    card.ActivateActorSpell(this.m_ActivateSpellOnTargets);
                }
            }
        }
        if ((num == 0) && (this.m_ActivateSpellOnTargets != SpellType.NONE))
        {
            foreach (Card card2 in this.GetTargetMinionCards())
            {
                card2.ActivateActorSpell(this.m_ActivateSpellOnTargets);
            }
        }
        this.m_spell.AddFinishedCallback(new Spell.FinishedCallback(this.OnSpellFinished));
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

    private void ResetPowerTasks()
    {
        PowerTaskList powerTaskList = this.m_spell.GetPowerTaskList();
        if (powerTaskList != null)
        {
            foreach (PowerTask task in powerTaskList.GetTaskList())
            {
                task.SetCompleted(false);
                Network.HistTagChange power = task.GetPower() as Network.HistTagChange;
                if ((power != null) && (power.Tag == 0x2c))
                {
                    Entity entity = GameState.Get().GetEntity(power.Entity);
                    entity.SetTag(GAME_TAG.DAMAGE, 0);
                    Card card = entity.GetCard();
                    if (card != null)
                    {
                        Actor actor = card.GetActor();
                        if (actor != null)
                        {
                            actor.UpdateAllComponents();
                        }
                    }
                    if (this.m_HealthChangeType != HealthChangeType.NO_CHANGE)
                    {
                        power.Value = this.GetRandomHealthChangeAmount();
                    }
                }
            }
        }
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
        if (this.m_testCardDef != null)
        {
            this.m_opponentHeroCard.LoadCardDef(this.m_testCardDef);
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

    private void SetupSpellCard(GameState state, int entityId)
    {
        if (this.m_spell != null)
        {
            Entity entity = new Entity();
            entity.SetTag(GAME_TAG.ENTITY_ID, entityId);
            entity.SetTag<TAG_CARDTYPE>(GAME_TAG.CARDTYPE, TAG_CARDTYPE.ABILITY);
            entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.PLAY);
            entity.SetTag(GAME_TAG.CONTROLLER, this.m_friendlyPlayerId);
            state.AddEntity(entity);
            this.m_spellCard = entity.InitCard();
            this.m_spellCard.name = "Spell Card";
            this.UpdateSpell();
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
        SpellCache.Get().PreLoad();
        this.SetupTestCardDef();
    }

    private void Update()
    {
        if (this.m_initialized)
        {
            this.UpdateCachedEditorData();
        }
    }

    private void UpdateCachedEditorData()
    {
        if (this.IsCachedEditorDataStale())
        {
            if (this.m_spell == null)
            {
                this.InitCachedEditorData();
                this.SetupSpellCard(GameState.Get(), this.GetNextEntityId());
            }
            else if (this.m_spell.GetActiveState() == SpellStateType.NONE)
            {
                this.InitCachedEditorData();
                this.UpdateSpell();
            }
        }
    }

    private void UpdatePowerTaskList()
    {
        PowerTaskList taskList = new PowerTaskList();
        Entity entity = this.m_spellCard.GetEntity();
        Network.HistActionStart startAction = new Network.HistActionStart(Network.PowerHistoryAction.PowSubType.POWER) {
            Entity = entity.GetEntityId()
        };
        taskList.SetSourceAction(startAction);
        if (this.m_targetHeroes)
        {
            Card targetHeroCard = this.GetTargetHeroCard();
            if (targetHeroCard != null)
            {
                startAction.Target = targetHeroCard.GetEntity().GetEntityId();
                this.CreatePowerTaskForTarget(taskList, targetHeroCard);
            }
        }
        List<Card> targetMinionCards = this.GetTargetMinionCards();
        if (targetMinionCards != null)
        {
            for (int i = 0; i < targetMinionCards.Count; i++)
            {
                this.CreatePowerTaskForTarget(taskList, targetMinionCards[i]);
            }
        }
        Network.HistActionEnd endAction = new Network.HistActionEnd();
        taskList.SetEndAction(endAction);
        this.m_spell.AttachPowerTaskList(taskList);
    }

    private void UpdateSpell()
    {
        Card heroCard = this.m_spellCard.GetEntity().GetHeroCard();
        this.m_spell.SetSource(heroCard.gameObject);
        this.UpdatePowerTaskList();
        this.ForceAddAllTargets();
        this.m_spell.AddFinishedCallback(new Spell.FinishedCallback(this.OnSpellFinished));
    }

    public enum HealthChangeType
    {
        NO_CHANGE,
        DAMAGE,
        HEALING
    }
}


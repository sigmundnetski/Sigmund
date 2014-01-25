using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private BnetGameAccountId m_gameAccountId;
    private Entity m_hero;
    private Entity m_heroPower;
    private bool m_local;
    private ManaCounter m_manaCounter;
    private string m_name;
    private int m_queuedSpentMana;
    private Side m_side;

    public void AddManaCrystal(int numCrystals)
    {
        this.AddManaCrystal(numCrystals, false);
    }

    public void AddManaCrystal(int numCrystals, bool isTurnStart)
    {
        if (this.IsLocal())
        {
            ManaCrystalMgr.Get().AddManaCrystals(numCrystals, isTurnStart);
        }
    }

    public void AddTempManaCrystal(int numCrystals)
    {
        if (this.IsLocal())
        {
            ManaCrystalMgr.Get().AddTempManaCrystals(numCrystals);
        }
    }

    private void AssignPlayerBoardObjects()
    {
        foreach (ManaCounter counter in Board.Get().gameObject.GetComponentsInChildren<ManaCounter>(true))
        {
            if (counter.m_Side == this.m_side)
            {
                this.m_manaCounter = counter;
                this.m_manaCounter.SetPlayer(this);
                break;
            }
        }
        foreach (Zone zone in ZoneMgr.Get().GetZones())
        {
            if (zone.m_Side == this.m_side)
            {
                zone.SetPlayer(this);
            }
        }
    }

    public void CancelAllProposedMana(Entity entity)
    {
        if (this.IsLocal())
        {
            ManaCrystalMgr.Get().CancelAllProposedMana(entity);
        }
    }

    public bool ComboIsActive()
    {
        return base.HasTag(GAME_TAG.COMBO_ACTIVE);
    }

    public PlayErrors.PlayerInfo ConvertToPlayerInfo()
    {
        PlayErrors.PlayerInfo info = new PlayErrors.PlayerInfo();
        int numFriendlyMinionsInPlay = this.GetNumFriendlyMinionsInPlay();
        int numEnemyMinionsInPlay = this.GetNumEnemyMinionsInPlay();
        info.isCurrentPlayer = this.IsCurrentPlayer();
        info.id = this.GetPlayerId();
        info.numResources = this.GetNumAvailableResources();
        info.weaponEquipped = this.HasWeapon();
        info.comboActive = this.ComboIsActive();
        info.numTotalMinionsInPlay = numFriendlyMinionsInPlay + numEnemyMinionsInPlay;
        info.numEnemyMinionsInPlay = numEnemyMinionsInPlay;
        info.numOpenFriendlyMinionSlots = GameState.Get().GetMaxFriendlyMinionsPerPlayer() - numFriendlyMinionsInPlay;
        info.numOpenSecretSlots = GameState.Get().GetMaxSecretsPerPlayer() - this.GetSecretDefinitions().Count;
        return info;
    }

    public void DestroyManaCrystal(int numCrystals)
    {
        if (this.IsLocal())
        {
            ManaCrystalMgr.Get().DestroyManaCrystals(numCrystals);
        }
    }

    public void DestroyTempManaCrystal(int numCrystals)
    {
        if (this.IsLocal())
        {
            ManaCrystalMgr.Get().DestroyTempManaCrystals(numCrystals);
        }
    }

    public ZonePlay GetBattlefieldZone()
    {
        return ZoneMgr.Get().FindZoneOfType<ZonePlay>(TAG_ZONE.PLAY, this.GetSide());
    }

    public BnetPlayer GetBnetPlayer()
    {
        return BnetPresenceMgr.Get().GetPlayer(this.m_gameAccountId);
    }

    public int GetCurrentSpellPower()
    {
        return base.GetTag(GAME_TAG.CURRENT_SPELLPOWER);
    }

    public override string GetDebugName()
    {
        if (this.IsAI())
        {
            return GameStrings.Get("GAMEPLAY_AI_OPPONENT_NAME");
        }
        BnetPlayer player = BnetPresenceMgr.Get().GetPlayer(this.m_gameAccountId);
        if (player != null)
        {
            BnetBattleTag battleTag = player.GetGameAccount(this.m_gameAccountId).GetBattleTag();
            if (battleTag != null)
            {
                return battleTag.GetName();
            }
        }
        return "UNKNOWN";
    }

    public ZoneDeck GetDeckZone()
    {
        return ZoneMgr.Get().FindZoneOfType<ZoneDeck>(TAG_ZONE.DECK, this.GetSide());
    }

    public BnetGameAccountId GetGameAccountId()
    {
        return this.m_gameAccountId;
    }

    public ZoneHand GetHandZone()
    {
        return ZoneMgr.Get().FindZoneOfType<ZoneHand>(TAG_ZONE.HAND, this.GetSide());
    }

    public override Entity GetHero()
    {
        return this.m_hero;
    }

    public override Card GetHeroCard()
    {
        if (this.m_hero == null)
        {
            return null;
        }
        return this.m_hero.GetCard();
    }

    public override Entity GetHeroPower()
    {
        return this.m_heroPower;
    }

    public override Card GetHeroPowerCard()
    {
        if (this.m_heroPower == null)
        {
            return null;
        }
        return this.m_heroPower.GetCard();
    }

    public override string GetName()
    {
        return this.m_name;
    }

    public int GetNumAvailableResources()
    {
        int tag = base.GetTag(GAME_TAG.TEMP_RESOURCES);
        int num2 = base.GetTag(GAME_TAG.RESOURCES);
        int num3 = base.GetTag(GAME_TAG.RESOURCES_USED);
        int num4 = ((num2 + tag) - num3) - this.m_queuedSpentMana;
        return ((num4 >= 0) ? num4 : 0);
    }

    public int GetNumEnemyMinionsInPlay()
    {
        int num = 0;
        foreach (Zone zone in ZoneMgr.Get().GetZones())
        {
            if (zone is ZonePlay)
            {
                foreach (Card card in zone.GetCards())
                {
                    Entity entity = card.GetEntity();
                    if ((entity.GetControllerId() != this.GetPlayerId()) && entity.IsMinion())
                    {
                        num++;
                    }
                }
                continue;
            }
        }
        return num;
    }

    public int GetNumFriendlyMinionsInPlay()
    {
        int num = 0;
        foreach (Card card in this.GetBattlefieldZone().GetCards())
        {
            Entity entity = card.GetEntity();
            if ((entity.GetControllerId() == this.GetPlayerId()) && entity.IsMinion())
            {
                num++;
            }
        }
        return num;
    }

    public int GetPlayerId()
    {
        return base.GetTag(GAME_TAG.PLAYER_ID);
    }

    public int GetQueuedSpentMana()
    {
        return this.m_queuedSpentMana;
    }

    public List<string> GetSecretDefinitions()
    {
        List<string> list = new List<string>();
        foreach (Zone zone in ZoneMgr.Get().GetZones())
        {
            if ((zone is ZoneSecret) && (zone.m_Side == Side.FRIENDLY))
            {
                foreach (Card card in zone.GetCards())
                {
                    list.Add(card.GetEntity().GetCardId());
                }
                continue;
            }
        }
        return list;
    }

    public Side GetSide()
    {
        return this.m_side;
    }

    public override Card GetWeaponCard()
    {
        return ZoneMgr.Get().FindZoneOfType<ZoneWeapon>(TAG_ZONE.PLAY, this.GetSide()).GetFirstCard();
    }

    public bool HasReadyAttackers()
    {
        List<Card> cards = this.GetBattlefieldZone().GetCards();
        for (int i = 0; i < cards.Count; i++)
        {
            if (GameState.Get().HasResponse(cards[i].GetEntity()))
            {
                return true;
            }
        }
        return false;
    }

    public bool HasWeapon()
    {
        foreach (Zone zone in ZoneMgr.Get().GetZones())
        {
            if ((zone is ZoneWeapon) && (zone.m_Side == this.m_side))
            {
                return (zone.GetCards().Count > 0);
            }
        }
        return false;
    }

    public bool IsAI()
    {
        if (this.m_gameAccountId == null)
        {
            return false;
        }
        return !this.m_gameAccountId.IsValid();
    }

    public bool IsCurrentPlayer()
    {
        return base.HasTag(GAME_TAG.CURRENT_PLAYER);
    }

    public bool IsLocal()
    {
        return this.m_local;
    }

    public void MarkCrystalsOwedForRecall(int numCrystals)
    {
        if (this.IsLocal())
        {
            ManaCrystalMgr.Get().MarkCrystalsOwedForRecall(numCrystals);
        }
    }

    public void NotifyOfSpentMana(int spentMana)
    {
        this.m_queuedSpentMana += spentMana;
    }

    private void OnBnetPlayerReady()
    {
        this.UpdateName();
        if (this.m_side == Side.OPPOSING)
        {
            BnetPlayer player = BnetPresenceMgr.Get().GetPlayer(this.m_gameAccountId);
            if (BnetFriendMgr.Get().IsFriend(player))
            {
                ChatMgr.Get().AddLowPriorityRecentWhisperPlayer(player);
            }
        }
    }

    private void OnBnetPlayersChanged(BnetPlayerChangelist changelist, object userData)
    {
        BnetPlayerChange change = changelist.FindChange(this.m_gameAccountId);
        if ((change != null) && change.GetPlayer().IsDisplayable())
        {
            BnetPresenceMgr.Get().RemovePlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnBnetPlayersChanged));
            this.OnBnetPlayerReady();
        }
    }

    public void OnBoardLoaded()
    {
        this.AssignPlayerBoardObjects();
    }

    public void OnEnemyPlayerTagChanged(TagDelta change)
    {
        GAME_TAG tag = (GAME_TAG) change.tag;
        switch (tag)
        {
            case GAME_TAG.CURRENT_PLAYER:
                if (change.newValue == 1)
                {
                    this.OnEnemyPlayerTurnStart();
                }
                return;

            case GAME_TAG.RESOURCES:
                if (change.newValue > change.oldValue)
                {
                    GameState.Get().GetGameEntity().NotifyOfEnemyManaCrystalSpawned();
                }
                return;
        }
        if (tag == GAME_TAG.PLAYSTATE)
        {
            switch (change.newValue)
            {
                case 7:
                    NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_ANNOUNCER_DISCONNECT_45"), "VO_ANNOUNCER_DISCONNECT_45");
                    return;

                case 8:
                    GameState.Get().GetRemotePlayer().GetHeroCard().PlayEmote(EmoteType.CONCEDE);
                    break;
            }
        }
    }

    private void OnEnemyPlayerTurnStart()
    {
        if (TurnTimer.Get() != null)
        {
            TurnTimer.Get().OnTurnChanged();
        }
    }

    public void OnLocalPlayerTagChanged(TagDelta change)
    {
        GAME_TAG tag = (GAME_TAG) change.tag;
        switch (tag)
        {
            case GAME_TAG.CURRENT_SPELLPOWER:
            {
                List<Card> cards = this.GetHandZone().GetCards();
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].GetEntity().IsSpell())
                    {
                        cards[i].GetActor().UpdatePowersText();
                    }
                }
                return;
            }
            case GAME_TAG.TEMP_RESOURCES:
                if (change.newValue <= change.oldValue)
                {
                    this.DestroyTempManaCrystal(change.oldValue - change.newValue);
                    return;
                }
                this.AddTempManaCrystal(change.newValue - change.oldValue);
                return;

            case GAME_TAG.RECALL_OWED:
                if (change.newValue > change.oldValue)
                {
                    this.MarkCrystalsOwedForRecall(change.newValue - change.oldValue);
                }
                return;

            case GAME_TAG.CURRENT_PLAYER:
                if (change.newValue == 1)
                {
                    this.OnLocalPlayerTurnStart();
                }
                if (EndTurnButton.Get() != null)
                {
                    if (GameState.Get().IsMainPhase() && (change.newValue == 1))
                    {
                        TurnStartManager.Get().BeginListeningForTurnEvents();
                    }
                    else
                    {
                        EndTurnButton.Get().SetStateToWaiting();
                    }
                }
                return;

            case GAME_TAG.RESOURCES_USED:
            {
                int num = change.oldValue + this.m_queuedSpentMana;
                int num2 = change.newValue - change.oldValue;
                if (num2 > 0)
                {
                    this.m_queuedSpentMana -= num2;
                }
                if (this.m_queuedSpentMana < 0)
                {
                    this.m_queuedSpentMana = 0;
                }
                int shownChangeAmount = (change.newValue - num) + this.m_queuedSpentMana;
                ManaCrystalMgr.Get().UpdateSpentMana(shownChangeAmount);
                return;
            }
            case GAME_TAG.RESOURCES:
                if (change.newValue <= change.oldValue)
                {
                    this.DestroyManaCrystal(change.oldValue - change.newValue);
                    return;
                }
                if (!GameState.Get().IsTurnStartManagerActive() || !this.IsLocal())
                {
                    this.AddManaCrystal(change.newValue - change.oldValue);
                    return;
                }
                TurnStartManager.Get().NotifyOfManaCrystalGained(change.newValue - change.oldValue);
                return;
        }
        if (tag == GAME_TAG.PLAYSTATE)
        {
            TAG_PLAYSTATE newValue = (TAG_PLAYSTATE) change.newValue;
            switch (newValue)
            {
                case TAG_PLAYSTATE.QUIT:
                    GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.CONCEDE);
                    break;

                case TAG_PLAYSTATE.WON:
                case TAG_PLAYSTATE.LOST:
                case TAG_PLAYSTATE.TIED:
                    GameState.Get().OnGameOver(newValue);
                    break;
            }
        }
    }

    private void OnLocalPlayerTurnStart()
    {
        if (TurnTimer.Get() != null)
        {
            TurnTimer.Get().OnTurnChanged();
        }
        if (EndTurnButton.Get() != null)
        {
            EndTurnButton.Get().NotifyOfTurnChange();
        }
        ManaCrystalMgr.Get().NotifyOfTurnChange();
        this.m_queuedSpentMana = 0;
    }

    public override void OnTagChanged(TagDelta change)
    {
        if (this.IsLocal())
        {
            this.OnLocalPlayerTagChanged(change);
        }
        else
        {
            this.OnEnemyPlayerTagChanged(change);
        }
        GAME_TAG tag = (GAME_TAG) change.tag;
        if ((tag != GAME_TAG.RESOURCES_USED) && (tag != GAME_TAG.RESOURCES))
        {
            if (tag == GAME_TAG.COMBO_ACTIVE)
            {
                foreach (Card card2 in this.GetHandZone().GetCards())
                {
                    card2.UpdateActorState();
                }
                return;
            }
            if (tag != GAME_TAG.TEMP_RESOURCES)
            {
                if (tag == GAME_TAG.MULLIGAN_STATE)
                {
                    if (change.newValue == 4)
                    {
                        if (MulliganManager.Get() != null)
                        {
                            MulliganManager.Get().ServerHasDealtReplacementCards(this.IsLocal());
                        }
                        else
                        {
                            foreach (Card card in this.GetHandZone().GetCards())
                            {
                                card.GetActor().TurnOnCollider();
                            }
                        }
                    }
                    return;
                }
                return;
            }
        }
        if (!GameState.Get().IsTurnStartManagerActive() || !this.IsLocal())
        {
            this.UpdateManaCounter();
        }
    }

    public override void OnTagsChanged(TagDeltaSet changeSet)
    {
        for (int i = 0; i < changeSet.Size(); i++)
        {
            TagDelta change = changeSet[i];
            this.OnTagChanged(change);
        }
    }

    public void ProposeManaCrystalUsage(Entity entity)
    {
        if (this.IsLocal())
        {
            ManaCrystalMgr.Get().ProposeManaCrystalUsage(entity);
        }
    }

    public void ReadyManaCrystal(int numCrystals)
    {
        if (this.IsLocal())
        {
            ManaCrystalMgr.Get().ReadyManaCrystals(numCrystals);
        }
    }

    public void SetGameAccountId(BnetGameAccountId id)
    {
        this.m_gameAccountId = id;
        this.UpdateLocal();
        this.UpdateSide();
        if (this.IsAI())
        {
            this.UpdateName();
        }
        else
        {
            BnetPlayer player = BnetPresenceMgr.Get().GetPlayer(this.m_gameAccountId);
            if ((player == null) || !player.IsDisplayable())
            {
                BnetPresenceMgr.Get().AddPlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnBnetPlayersChanged));
            }
            else
            {
                this.OnBnetPlayerReady();
            }
        }
    }

    public void SetHero(Entity hero)
    {
        this.m_hero = hero;
    }

    public void SetHeroPower(Entity heroPower)
    {
        this.m_heroPower = heroPower;
    }

    public void SetLocal(bool local)
    {
        this.m_local = local;
        this.UpdateSide();
    }

    public void SetName(string name)
    {
        this.m_name = name;
    }

    public void SetPlayerId(int playerId)
    {
        base.SetTag(GAME_TAG.PLAYER_ID, playerId);
    }

    public void SetSide(Side side)
    {
        this.m_side = side;
    }

    public void SpendManaCrystal(int numCrystals)
    {
        if (this.IsLocal())
        {
            ManaCrystalMgr.Get().SpendManaCrystals(numCrystals);
        }
    }

    private void UpdateLocal()
    {
        BnetGameAccountId myGameAccountId = BnetPresenceMgr.Get().GetMyGameAccountId();
        this.m_local = myGameAccountId == this.m_gameAccountId;
    }

    public void UpdateManaCounter()
    {
        if (this.m_manaCounter != null)
        {
            this.m_manaCounter.UpdateText();
        }
    }

    private void UpdateName()
    {
        if (this.IsAI())
        {
            this.m_name = GameStrings.Get("GAMEPLAY_AI_OPPONENT_NAME");
        }
        else
        {
            this.m_name = BnetPresenceMgr.Get().GetPlayer(this.m_gameAccountId).GetBestName();
        }
    }

    private void UpdateSide()
    {
        if (this.IsLocal())
        {
            this.m_side = Side.FRIENDLY;
        }
        else
        {
            this.m_side = Side.OPPOSING;
        }
    }

    public void WipeZzzs()
    {
        foreach (Card card in this.GetBattlefieldZone().GetCards())
        {
            Spell actorSpell = card.GetActorSpell(SpellType.Zzz);
            if (actorSpell != null)
            {
                actorSpell.ActivateState(SpellStateType.DEATH);
            }
        }
    }

    public enum Side
    {
        NEUTRAL,
        FRIENDLY,
        OPPOSING
    }
}


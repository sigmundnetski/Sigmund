using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public class Entity : EntityBase
{
    public const string FALLBACK_CARD_ASSET_NAME = "PlaceholderCard";
    public const string HIDDEN_CARD_ASSET_NAME = "HiddenCard";
    private List<Entity> m_attachments = new List<Entity>();
    private Card m_card;
    private int m_cardAssetLoadCount;
    private bool m_cardDefLoading;
    private string m_cardId;
    private bool m_cardReady;
    private EntityDef m_entityDef = new EntityDef();
    private bool m_entityDefLoading;
    private int m_realTimeCost = -1;
    private List<int> m_subCardIDs = new List<int>();
    private bool m_useBattlecryPower;

    public Entity()
    {
        base.m_tags.OnParentCardTagChanged = (TagSet.DelParentCardTagChanged) Delegate.Combine(base.m_tags.OnParentCardTagChanged, new TagSet.DelParentCardTagChanged(this.OnParentCardTagChanged));
    }

    public void AddAttachment(Entity entity)
    {
        int count = this.m_attachments.Count;
        if (this.m_attachments.Contains(entity))
        {
            Log.Mike.Print(string.Format("Entity.AddAttachment() - {0} is already an attachment of {1}", entity, this));
        }
        else
        {
            this.m_attachments.Add(entity);
            if (this.m_card != null)
            {
                this.m_card.OnEnchantmentAdded(count, entity);
            }
        }
    }

    public void AddSubCard(Entity entity)
    {
        if (!this.m_subCardIDs.Contains(entity.GetEntityId()))
        {
            this.m_subCardIDs.Add(entity.GetEntityId());
        }
    }

    public void ClearBattlecryFlag()
    {
        this.m_useBattlecryPower = false;
    }

    public void ClearTags()
    {
        base.m_tags.Clear();
    }

    public Entity CloneForHistory()
    {
        Entity entity = new Entity();
        entity.ReplaceTags(base.m_tags);
        entity.ReplaceRefTags(base.m_referenceTags);
        entity.m_cardId = this.m_cardId;
        entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.HAND);
        entity.m_entityDef = this.m_entityDef.Clone();
        return entity;
    }

    public Entity CloneForZoneMgr()
    {
        Entity entity = new Entity();
        entity.ReplaceTags(base.m_tags);
        entity.ReplaceRefTags(base.m_referenceTags);
        entity.m_entityDef = this.m_entityDef;
        return entity;
    }

    public PlayErrors.SourceEntityInfo ConvertToSourceInfo(PlayErrors.PlayRequirementInfo playRequirementInfo)
    {
        List<string> entourageCardIDs = this.GetEntityDef().GetEntourageCardIDs();
        List<string> list2 = new List<string>();
        ZoneMgr mgr = ZoneMgr.Get();
        if (mgr != null)
        {
            ZonePlay play = mgr.FindZoneOfType<ZonePlay>(TAG_ZONE.PLAY, Player.Side.FRIENDLY);
            if (play != null)
            {
                foreach (Card card in play.GetCards())
                {
                    Entity entity = card.GetEntity();
                    if (entity != null)
                    {
                        list2.Add(entity.GetCardId());
                    }
                }
            }
        }
        PlayErrors.SourceEntityInfo info = new PlayErrors.SourceEntityInfo {
            id = base.GetEntityId(),
            cost = base.GetCost(),
            attack = base.GetATK(),
            minAttackRequirement = playRequirementInfo.paramMinAtk,
            maxAttackRequirement = playRequirementInfo.paramMaxAtk,
            raceRequirement = playRequirementInfo.paramRace,
            numMinionSlotsRequirement = playRequirementInfo.paramNumMinionSlots,
            numMinionSlotsWithTargetRequirement = playRequirementInfo.paramNumMinionSlotsWithTarget,
            minTotalMinionsRequirement = playRequirementInfo.paramMinNumTotalMinions,
            minEnemyMinionsRequirement = playRequirementInfo.paramMinNumEnemyMinions,
            numTurnsInPlay = base.GetNumTurnsInPlay(),
            numAttacksThisTurn = base.GetNumAttacksThisTurn(),
            cardType = base.GetCardType(),
            zone = base.GetZone(),
            isSecret = base.IsSecret(),
            isDuplicateSecret = false
        };
        if (info.isSecret)
        {
            Player player = GameState.Get().GetPlayer(base.GetControllerId());
            if (player != null)
            {
                foreach (string str in player.GetSecretDefinitions())
                {
                    if (this.GetCardId().Equals(str, StringComparison.OrdinalIgnoreCase))
                    {
                        info.isDuplicateSecret = true;
                        break;
                    }
                }
            }
        }
        info.isExhausted = base.IsExhausted();
        info.isMasterPower = (base.GetZone() == TAG_ZONE.HAND) || base.IsHeroPower();
        info.isActionPower = TAG_ZONE.HAND == base.GetZone();
        info.isActivatePower = (base.GetZone() == TAG_ZONE.PLAY) || base.IsHeroPower();
        info.isAttackPower = base.IsHero() || (!base.IsHeroPower() && (TAG_ZONE.PLAY == base.GetZone()));
        info.isFrozen = base.IsFrozen();
        info.canAttack = base.CanAttack();
        info.entireEntourageInPlay = false;
        if (entourageCardIDs.Count > 0)
        {
            info.entireEntourageInPlay = list2.Count > 0;
            <ConvertToSourceInfo>c__AnonStorey136 storey = new <ConvertToSourceInfo>c__AnonStorey136();
            using (List<string>.Enumerator enumerator3 = entourageCardIDs.GetEnumerator())
            {
                while (enumerator3.MoveNext())
                {
                    storey.entourageCardID = enumerator3.Current;
                    if (list2.Find(new Predicate<string>(storey.<>m__2A)) == null)
                    {
                        info.entireEntourageInPlay = false;
                        goto Label_031B;
                    }
                }
            }
        }
    Label_031B:
        info.hasCharge = base.HasCharge();
        info.hasWindfury = base.HasWindfury();
        info.requirementsMap = playRequirementInfo.requirementsMap;
        return info;
    }

    public PlayErrors.TargetEntityInfo ConvertToTargetInfo()
    {
        return new PlayErrors.TargetEntityInfo { 
            id = base.GetEntityId(), owningPlayerID = base.GetControllerId(), damage = base.GetDamage(), attack = base.GetATK(), race = (int) this.m_entityDef.GetRace(), isImmune = base.IsImmune(), canBeAttacked = base.CanBeAttacked(), canBeTargetedByOpponents = base.CanBeTargetedByOpponents(), canBeTargetedBySpells = base.CanBeTargetedByAbilities(), canBeTargetedByHeroPowers = base.CanBeTargetedByHeroPowers(), cardType = base.GetCardType(), isFrozen = base.IsFrozen(), isEnchanted = this.IsEnchanted(), isStealthed = base.IsStealthed(), isTaunter = base.HasTaunt(), isMagnet = base.IsMagnet(), 
            hasCharge = base.HasCharge(), hasAttackedThisTurn = base.GetNumAttacksThisTurn() > 0
         };
    }

    private int CountCardDefAssets(CardDef cardDef)
    {
        int num = 0;
        if (!string.IsNullOrEmpty(cardDef.m_PlaySpellPath))
        {
            num++;
        }
        if (!string.IsNullOrEmpty(cardDef.m_BattlecrySpellPath))
        {
            num++;
        }
        if (cardDef.m_SubOptionSpellPaths != null)
        {
            for (int i = 0; i < cardDef.m_SubOptionSpellPaths.Count; i++)
            {
                if (!string.IsNullOrEmpty(cardDef.m_SubOptionSpellPaths[i]))
                {
                    num++;
                }
            }
        }
        if (cardDef.m_TriggerSpellPaths != null)
        {
            for (int j = 0; j < cardDef.m_TriggerSpellPaths.Count; j++)
            {
                if (!string.IsNullOrEmpty(cardDef.m_TriggerSpellPaths[j]))
                {
                    num++;
                }
            }
        }
        if (!string.IsNullOrEmpty(cardDef.m_DeathSpellPath))
        {
            num++;
        }
        if (!string.IsNullOrEmpty(cardDef.m_AttackSpellPath))
        {
            num++;
        }
        if (!string.IsNullOrEmpty(cardDef.m_AnnouncerLinePath))
        {
            num++;
        }
        if (cardDef.m_EmoteDefs != null)
        {
            for (int k = 0; k < cardDef.m_EmoteDefs.Count; k++)
            {
                if ((cardDef.m_EmoteDefs[k] != null) && !string.IsNullOrEmpty(cardDef.m_EmoteDefs[k].m_emotePath))
                {
                    num++;
                }
            }
        }
        return num;
    }

    public void Destroy()
    {
        if (this.m_card != null)
        {
            this.m_card.Destroy();
        }
    }

    private void FinishCardAssetLoad()
    {
        this.m_cardAssetLoadCount--;
        if (this.m_cardAssetLoadCount <= 0)
        {
            this.FinishCardLoad();
        }
    }

    private void FinishCardLoad()
    {
        this.m_cardDefLoading = false;
        this.m_cardReady = true;
    }

    public List<Entity> GetAttachments()
    {
        return this.m_attachments;
    }

    public Power GetAttackPower()
    {
        return this.m_entityDef.GetAttackPower();
    }

    public Card GetCard()
    {
        return this.m_card;
    }

    public CardFlair GetCardFlair()
    {
        return new CardFlair((CardFlair.PremiumType) base.GetTag(GAME_TAG.PREMIUM));
    }

    public string GetCardId()
    {
        return this.m_cardId;
    }

    public string GetCardTextInHand()
    {
        StringBuilder buf = new StringBuilder();
        TextUtils.TransformCardText(this, GAME_TAG.CARDTEXT_INHAND, ref buf);
        return buf.ToString();
    }

    public TAG_CLASS GetClass()
    {
        if (base.IsSecret())
        {
            return base.GetTag<TAG_CLASS>(GAME_TAG.CLASS);
        }
        return this.m_entityDef.GetClass();
    }

    public Player GetController()
    {
        return GameState.Get().GetPlayer(base.GetControllerId());
    }

    public Entity GetCreator()
    {
        return GameState.Get().GetEntity(base.GetCreatorId());
    }

    public virtual string GetDebugName()
    {
        string stringTag = base.GetStringTag(GAME_TAG.CARDNAME);
        if (stringTag != null)
        {
            object[] args = new object[] { stringTag, base.GetEntityId(), base.GetZone(), base.GetZonePosition(), this.m_cardId, base.GetControllerId() };
            return string.Format("[name={0} id={1} zone={2} zonePos={3} cardId={4} player={5}]", args);
        }
        if (this.m_cardId != null)
        {
            object[] objArray2 = new object[] { base.GetEntityId(), base.GetZone(), base.GetZonePosition(), this.m_cardId, base.GetCardType(), base.GetControllerId() };
            return string.Format("[id={0} zone={1} zonePos={2} cardId={3} type={4} player={5}]", objArray2);
        }
        return string.Format("UNKNOWN ENTITY [id={0} cardType={1} zonePos={2}]", base.GetEntityId(), base.GetCardType(), base.GetZonePosition());
    }

    public TAG_ENCHANTMENT_VISUAL GetEnchantmentBirthVisual()
    {
        return this.m_entityDef.GetEnchantmentBirthVisual();
    }

    public TAG_ENCHANTMENT_VISUAL GetEnchantmentIdleVisual()
    {
        return this.m_entityDef.GetEnchantmentIdleVisual();
    }

    public List<Entity> GetEnchantments()
    {
        return this.GetAttachments();
    }

    public EntityDef GetEntityDef()
    {
        return this.m_entityDef;
    }

    public virtual Entity GetHero()
    {
        if (base.IsHero())
        {
            return this;
        }
        Player controller = this.GetController();
        if (controller == null)
        {
            return null;
        }
        return controller.GetHero();
    }

    public virtual Card GetHeroCard()
    {
        if (base.IsHero())
        {
            return this.GetCard();
        }
        Player controller = this.GetController();
        if (controller == null)
        {
            return null;
        }
        return controller.GetHeroCard();
    }

    public virtual Entity GetHeroPower()
    {
        if (base.IsHeroPower())
        {
            return this;
        }
        Player controller = this.GetController();
        if (controller == null)
        {
            return null;
        }
        return controller.GetHeroPower();
    }

    public virtual Card GetHeroPowerCard()
    {
        if (base.IsHeroPower())
        {
            return this.GetCard();
        }
        Player controller = this.GetController();
        if (controller == null)
        {
            return null;
        }
        return controller.GetHeroPowerCard();
    }

    public Power GetMasterPower()
    {
        return this.m_entityDef.GetMasterPower();
    }

    public virtual string GetName()
    {
        string stringTag = base.GetStringTag(GAME_TAG.CARDNAME);
        if (stringTag != null)
        {
            return stringTag;
        }
        return this.GetDebugName();
    }

    public int GetOriginalATK()
    {
        return this.m_entityDef.GetATK();
    }

    public bool GetOriginalCharge()
    {
        return this.m_entityDef.HasTag(GAME_TAG.CHARGE);
    }

    public int GetOriginalCost()
    {
        return this.m_entityDef.GetCost();
    }

    public int GetOriginalDurability()
    {
        return this.m_entityDef.GetDurability();
    }

    public int GetOriginalHealth()
    {
        return this.m_entityDef.GetHealth();
    }

    public PowerHistoryInfo GetPowerHistoryInfo(int effectIndex)
    {
        return this.m_entityDef.GetPowerHistoryInfo(effectIndex);
    }

    public CardFlair.PremiumType GetPremiumType()
    {
        return (CardFlair.PremiumType) base.GetTag(GAME_TAG.PREMIUM);
    }

    public TAG_RACE GetRace()
    {
        return this.m_entityDef.GetRace();
    }

    public string GetRaceText()
    {
        return this.m_entityDef.GetRaceText();
    }

    public TAG_RARITY GetRarity()
    {
        return this.m_entityDef.GetRarity();
    }

    public string GetRawCardTextInHand()
    {
        StringBuilder buf = new StringBuilder();
        TextUtils.TransformCardText(this, GAME_TAG.CARDTEXT_INHAND, ref buf);
        return buf.ToString();
    }

    public int GetRealTimeCost()
    {
        if (this.m_realTimeCost == -1)
        {
            return base.GetCost();
        }
        return this.m_realTimeCost;
    }

    public override int GetReferencedTag(int tag)
    {
        int num = 0;
        if (base.m_referenceTags.TryGetValue(tag, out num))
        {
            return num;
        }
        return this.m_entityDef.GetReferencedTag(tag);
    }

    public override string GetStringTag(int tag)
    {
        string str;
        if (base.m_stringTags.TryGetValue(tag, out str))
        {
            return str;
        }
        return this.m_entityDef.GetStringTag(tag);
    }

    public List<int> GetSubCardIDs()
    {
        return this.m_subCardIDs;
    }

    public TagSet GetTags()
    {
        return base.m_tags;
    }

    public string GetTargetingArrowText()
    {
        StringBuilder buf = new StringBuilder();
        TextUtils.TransformCardText(this, GAME_TAG.TARGETING_ARROW_TEXT, ref buf);
        TextUtils.HackAutoLineBreakBuffer(ref buf, 0x19);
        return buf.ToString();
    }

    public virtual Card GetWeaponCard()
    {
        if (base.IsWeapon())
        {
            return this.GetCard();
        }
        Player controller = this.GetController();
        if (controller == null)
        {
            return null;
        }
        return controller.GetWeaponCard();
    }

    public Card InitCard()
    {
        this.m_card = new GameObject().AddComponent<Card>();
        this.m_card.SetEntity(this);
        this.m_cardReady = true;
        return this.m_card;
    }

    public bool IsBusy()
    {
        return (!this.IsCardReady() || !this.m_card.IsActorReady());
    }

    public bool IsCardDefLoading()
    {
        return this.m_cardDefLoading;
    }

    public bool IsCardReady()
    {
        return this.m_cardReady;
    }

    public bool IsControlledByLocalPlayer()
    {
        return this.GetController().IsLocal();
    }

    public bool IsEnchanted()
    {
        return (this.m_attachments.Count > 0);
    }

    public bool IsEntityDefLoading()
    {
        return this.m_entityDefLoading;
    }

    public bool IsHidden()
    {
        return string.IsNullOrEmpty(this.m_cardId);
    }

    public bool IsLoading()
    {
        return (this.IsEntityDefLoading() || this.IsCardDefLoading());
    }

    public void LoadCard(string cardId)
    {
        this.LoadCard(cardId, null);
    }

    public void LoadCard(string cardId, TagDeltaSet changeSet)
    {
        if (this.m_cardId != cardId)
        {
            this.m_cardReady = false;
            this.m_cardId = cardId;
            if (string.IsNullOrEmpty(cardId))
            {
                this.UpdateCardName();
                this.m_cardDefLoading = true;
                DefLoader.Get().LoadCardDef("HiddenCard", new DefLoader.LoadDefCallback<CardDef>(this.OnCardDefLoaded));
            }
            else
            {
                if (GameState.Get().IsTurnStartManagerActive() && (base.GetZone() == TAG_ZONE.HAND))
                {
                    TurnStartManager.Get().NotifyOfCardDrawn(this);
                }
                this.m_entityDefLoading = true;
                DefLoader.Get().LoadEntityDef(cardId, new DefLoader.LoadDefCallback<EntityDef>(this.OnEntityDefLoaded), changeSet);
            }
        }
    }

    private void LoadCardDefAssets(CardDef cardDef)
    {
        if (cardDef == null)
        {
            this.FinishCardLoad();
        }
        else
        {
            this.m_cardAssetLoadCount = this.CountCardDefAssets(cardDef);
            if (this.m_cardAssetLoadCount == 0)
            {
                this.FinishCardLoad();
            }
            else
            {
                AssetLoader loader = AssetLoader.Get();
                if (!string.IsNullOrEmpty(cardDef.m_PlaySpellPath))
                {
                    loader.LoadSpell(cardDef.m_PlaySpellPath, new AssetLoader.GameObjectCallback(this.OnPlaySpellLoaded));
                }
                if (!string.IsNullOrEmpty(cardDef.m_BattlecrySpellPath))
                {
                    loader.LoadSpell(cardDef.m_BattlecrySpellPath, new AssetLoader.GameObjectCallback(this.OnBattlecrySpellLoaded));
                }
                if (cardDef.m_SubOptionSpellPaths != null)
                {
                    for (int i = 0; i < cardDef.m_SubOptionSpellPaths.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(cardDef.m_SubOptionSpellPaths[i]))
                        {
                            loader.LoadSpell(cardDef.m_SubOptionSpellPaths[i], new AssetLoader.GameObjectCallback(this.OnSubOptionSpellLoaded), i);
                        }
                    }
                }
                if (cardDef.m_TriggerSpellPaths != null)
                {
                    for (int j = 0; j < cardDef.m_TriggerSpellPaths.Count; j++)
                    {
                        if (!string.IsNullOrEmpty(cardDef.m_TriggerSpellPaths[j]))
                        {
                            loader.LoadSpell(cardDef.m_TriggerSpellPaths[j], new AssetLoader.GameObjectCallback(this.OnTriggerSpellLoaded), j);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(cardDef.m_DeathSpellPath))
                {
                    loader.LoadSpell(cardDef.m_DeathSpellPath, new AssetLoader.GameObjectCallback(this.OnDeathSpellLoaded));
                }
                if (!string.IsNullOrEmpty(cardDef.m_AttackSpellPath))
                {
                    loader.LoadSpell(cardDef.m_AttackSpellPath, new AssetLoader.GameObjectCallback(this.OnAttackSpellLoaded));
                }
                if (!string.IsNullOrEmpty(cardDef.m_AnnouncerLinePath))
                {
                    loader.LoadSound(cardDef.m_AnnouncerLinePath, new AssetLoader.GameObjectCallback(this.OnAnnouncerLineLoaded));
                }
                if (cardDef.m_EmoteDefs != null)
                {
                    for (int k = 0; k < cardDef.m_EmoteDefs.Count; k++)
                    {
                        if ((cardDef.m_EmoteDefs[k] != null) && !string.IsNullOrEmpty(cardDef.m_EmoteDefs[k].m_emotePath))
                        {
                            loader.LoadSpell(cardDef.m_EmoteDefs[k].m_emotePath, new AssetLoader.GameObjectCallback(this.OnEmoteSpellLoaded), (int) cardDef.m_EmoteDefs[k].m_emoteType);
                        }
                    }
                }
            }
        }
    }

    public void LoadEntityDefData(EntityDef entityDef)
    {
    }

    private void OnAnnouncerLineLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("Entity.OnAnnouncerLineLoaded() - FAILED TO LOAD \"{0}\" for card {1}", name, this.m_cardId));
        }
        else
        {
            AudioSource audio = go.audio;
            if (audio == null)
            {
                Debug.LogError(string.Format("Entity.OnAnnouncerLineLoaded() - FAILED TO LOAD \"{0}\" for card {1}", name, this.m_cardId));
            }
            else
            {
                this.m_card.LoadAnnouncerLine(audio);
            }
        }
        this.FinishCardAssetLoad();
    }

    private void OnAttackSpellLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("Entity.OnAttackSpellLoaded() - FAILED TO LOAD \"{0}\" for card {1}", name, this.m_cardId));
        }
        else
        {
            Spell component = go.GetComponent<Spell>();
            if (component == null)
            {
                Debug.LogError(string.Format("Entity.OnAttackSpellLoaded() - FAILED TO LOAD \"{0}\" for card {1}", name, this.m_cardId));
            }
            else
            {
                this.m_card.LoadAttackSpell(component);
            }
        }
        this.FinishCardAssetLoad();
    }

    private void OnBattlecrySpellLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("Entity.OnBattlecrySpellLoaded() - FAILED TO LOAD \"{0}\" for card {1}", name, this.m_cardId));
        }
        else
        {
            Spell component = go.GetComponent<Spell>();
            if (component == null)
            {
                Debug.LogError(string.Format("Entity.OnBattlecrySpellLoaded() - FAILED TO LOAD \"{0}\" for card {1}", name, this.m_cardId));
            }
            else
            {
                this.m_card.LoadBattlecrySpell(component);
            }
        }
        this.FinishCardAssetLoad();
    }

    private void OnCardDefLoaded(string cardId, CardDef cardDef, object callbackData)
    {
        if (cardDef == null)
        {
            if (cardId == "PlaceholderCard")
            {
                Debug.LogError(string.Format("Entity.OnCardDefLoaded() - {0} does not have an asset!", "PlaceholderCard"));
            }
            else
            {
                Debug.LogWarning(string.Format("Entity.OnCardDefLoaded() - MISSING ASSET for card {0}. Falling back to {1}", cardId, "PlaceholderCard"));
                DefLoader.Get().LoadCardDef("PlaceholderCard", new DefLoader.LoadDefCallback<CardDef>(this.OnCardDefLoaded));
            }
        }
        else
        {
            if (this.m_card != null)
            {
                this.m_card.LoadCardDef(cardDef);
            }
            this.UpdateUseBattlecryFlag(false);
            this.LoadCardDefAssets(cardDef);
        }
    }

    private void OnDeathSpellLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("Entity.OnDeathSpellLoaded() - FAILED TO LOAD \"{0}\" for card {1}", name, this.m_cardId));
        }
        else
        {
            Spell component = go.GetComponent<Spell>();
            if (component == null)
            {
                Debug.LogError(string.Format("Entity.OnDeathSpellLoaded() - FAILED TO LOAD \"{0}\" for card {1}", name, this.m_cardId));
            }
            else
            {
                this.m_card.LoadDeathSpell(component);
            }
        }
        this.FinishCardAssetLoad();
    }

    private void OnEmoteSpellLoaded(string name, GameObject go, object callbackData)
    {
        EmoteType type = (EmoteType) ((int) callbackData);
        if (go == null)
        {
            Debug.LogError(string.Format("Entity.OnEmoteSpellLoaded() - FAILED TO LOAD \"{0}\" (emoteType {1}) for card {2}", name, type, this.m_cardId));
        }
        else
        {
            Spell component = go.GetComponent<Spell>();
            if (component == null)
            {
                Debug.LogError(string.Format("Entity.OnEmoteSpellLoaded() - FAILED TO LOAD \"{0}\" (emoteType {1}) for card {2}", name, type, this.m_cardId));
            }
            else
            {
                this.m_card.LoadEmoteSpell(type, component);
            }
        }
        this.FinishCardAssetLoad();
    }

    private void OnEntityDefLoaded(string cardId, EntityDef entityDef, object callbackData)
    {
        if (entityDef == null)
        {
            Debug.LogError(string.Format("Entity.OnEntityDefLoaded() - {0} failed to load entityDef", this));
        }
        else
        {
            this.m_entityDef = entityDef;
            this.UpdateCardName();
            this.m_entityDefLoading = false;
            TagDeltaSet changeSet = callbackData as TagDeltaSet;
            if (changeSet != null)
            {
                this.OnTagsChanged(changeSet);
            }
            DefLoader.Get().LoadCardDef(cardId, new DefLoader.LoadDefCallback<CardDef>(this.OnCardDefLoaded));
        }
    }

    private void OnParentCardTagChanged(int oldParentCardID, int newParentCardID)
    {
        if (oldParentCardID != newParentCardID)
        {
            Entity entity = GameState.Get().GetEntity(oldParentCardID);
            if (entity != null)
            {
                entity.RemoveSubCard(this);
            }
            Entity entity2 = GameState.Get().GetEntity(newParentCardID);
            if (entity2 != null)
            {
                entity2.AddSubCard(this);
            }
        }
    }

    private void OnPlaySpellLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("Entity.OnPlaySpellLoaded() - FAILED TO LOAD \"{0}\" for card {1}", name, this.m_cardId));
        }
        else
        {
            Spell component = go.GetComponent<Spell>();
            if (component == null)
            {
                Debug.LogError(string.Format("Entity.OnPlaySpellLoaded() - FAILED TO LOAD \"{0}\" for card {1}", name, this.m_cardId));
            }
            else
            {
                this.m_card.LoadPlaySpell(component);
            }
        }
        this.FinishCardAssetLoad();
    }

    private void OnSubOptionSpellLoaded(string name, GameObject go, object callbackData)
    {
        int num = (int) callbackData;
        if (go == null)
        {
            Debug.LogError(string.Format("Entity.LoadSubOptionSpell() - FAILED TO LOAD \"{0}\" (index {1}) for card {2}", name, num, this.m_cardId));
        }
        else
        {
            Spell component = go.GetComponent<Spell>();
            if (component == null)
            {
                Debug.LogError(string.Format("Entity.LoadSubOptionSpell() - FAILED TO LOAD \"{0}\" (index {1}) for card {2}", name, num, this.m_cardId));
            }
            else
            {
                this.m_card.LoadSubOptionSpell(num, component);
            }
        }
        this.FinishCardAssetLoad();
    }

    public virtual void OnTagChanged(TagDelta change)
    {
        this.OnTagChanged_UpdateNow(change);
        if (this.m_card != null)
        {
            this.m_card.OnTagChanged(change);
        }
    }

    private void OnTagChanged_UpdateNow(TagDelta change)
    {
        bool flag = false;
        switch (((GAME_TAG) change.tag))
        {
            case GAME_TAG.ATTACHED:
            {
                Entity entity = GameState.Get().GetEntity(change.oldValue);
                if (entity != null)
                {
                    entity.RemoveAttachment(this);
                }
                Entity entity2 = GameState.Get().GetEntity(change.newValue);
                if (entity2 != null)
                {
                    entity2.AddAttachment(this);
                }
                goto Label_0087;
            }
            case GAME_TAG.ZONE:
                this.UpdateUseBattlecryFlag(false);
                flag = true;
                break;

            case GAME_TAG.ENTITY_ID:
            case GAME_TAG.ZONE_POSITION:
                flag = true;
                goto Label_0087;
        }
    Label_0087:
        if (flag)
        {
            this.UpdateCardName();
        }
    }

    public virtual void OnTagsChanged(TagDeltaSet changeSet)
    {
        bool flag = false;
        for (int i = 0; i < changeSet.Size(); i++)
        {
            TagDelta change = changeSet[i];
            GAME_TAG tag = (GAME_TAG) change.tag;
            if (tag != GAME_TAG.ZONE)
            {
                if ((tag == GAME_TAG.ENTITY_ID) || (tag == GAME_TAG.ZONE_POSITION))
                {
                    goto Label_0046;
                }
                goto Label_004D;
            }
            this.UpdateUseBattlecryFlag(false);
            flag = true;
            continue;
        Label_0046:
            flag = true;
            continue;
        Label_004D:
            this.OnTagChanged_UpdateNow(change);
        }
        if (flag)
        {
            this.UpdateCardName();
        }
        if (this.m_card != null)
        {
            this.m_card.OnTagsChanged(changeSet);
        }
    }

    private void OnTriggerSpellLoaded(string name, GameObject go, object callbackData)
    {
        int num = (int) callbackData;
        if (go == null)
        {
            Debug.LogError(string.Format("Entity.OnTriggerSpellLoaded() - FAILED TO LOAD \"{0}\" (index {1}) for card {2}", name, num, this.m_cardId));
        }
        else
        {
            Spell component = go.GetComponent<Spell>();
            if (component == null)
            {
                Debug.LogError(string.Format("Entity.OnTriggerSpellLoaded() - FAILED TO LOAD \"{0}\" (index {1}) for card {2}", name, num, this.m_cardId));
            }
            else
            {
                this.m_card.LoadTriggerSpell(num, component);
            }
        }
        this.FinishCardAssetLoad();
    }

    public void RemoveAttachment(Entity entity)
    {
        int count = this.m_attachments.Count;
        if (!this.m_attachments.Remove(entity))
        {
            Log.Mike.Print(string.Format("Entity.RemoveAttachment() - {0} is not an attachment of {1}", entity, this));
        }
        else if (this.m_card != null)
        {
            this.m_card.OnEnchantmentRemoved(count, entity);
        }
    }

    public void RemoveSubCard(Entity entity)
    {
        this.m_subCardIDs.Remove(entity.GetEntityId());
    }

    public void ReplaceRefTags(TagSet refTags)
    {
        base.m_referenceTags.Replace(refTags);
    }

    public void ReplaceTags(List<Network.Entity.Tag> tags)
    {
        base.m_tags.Replace(tags);
    }

    public void ReplaceTags(TagSet tags)
    {
        base.m_tags.Replace(tags);
    }

    public void ReplaceTagsAndUpdateCard(List<Network.Entity.Tag> netTags)
    {
        TagDeltaSet changeSet = base.m_tags.CreateDeltas(netTags);
        this.ReplaceTags(netTags);
        this.OnTagsChanged(changeSet);
    }

    public void SetCard(Card card)
    {
        this.m_card = card;
        this.m_cardReady = true;
    }

    public void SetRealTimeCost(int newCost)
    {
        this.m_realTimeCost = newCost;
    }

    public void SetTagAndUpdateCard<TagEnum>(GAME_TAG tag, TagEnum tagValue)
    {
        this.SetTagAndUpdateCard((int) tag, Convert.ToInt32(tagValue));
    }

    public TagDelta SetTagAndUpdateCard(int tag, int tagValue)
    {
        int num = base.m_tags.GetTag(tag);
        base.SetTag(tag, tagValue);
        TagDelta change = new TagDelta {
            tag = tag,
            oldValue = num,
            newValue = tagValue
        };
        this.OnTagChanged(change);
        return change;
    }

    public void SetTags(Dictionary<GAME_TAG, int> tagMap)
    {
        base.m_tags.SetTags(tagMap);
    }

    public void SetTagsAndUpdateCard(Dictionary<GAME_TAG, int> tagMap)
    {
        TagDeltaSet changeSet = base.m_tags.CreateDeltas(tagMap);
        base.m_tags.SetTags(tagMap);
        this.OnTagsChanged(changeSet);
    }

    public bool ShouldUseBattlecryPower()
    {
        return this.m_useBattlecryPower;
    }

    public override string ToString()
    {
        return this.GetDebugName();
    }

    public void UpdateCardName()
    {
        if (this.m_card != null)
        {
            string stringTag = base.GetStringTag(GAME_TAG.CARDNAME);
            if (stringTag != null)
            {
                if (string.IsNullOrEmpty(this.m_cardId))
                {
                    object[] args = new object[] { stringTag, base.GetEntityId(), base.GetZone(), base.GetZonePosition() };
                    this.m_card.gameObject.name = string.Format("{0} [id={1} zone={2} zonePos={3}]", args);
                }
                else
                {
                    object[] objArray2 = new object[] { stringTag, base.GetEntityId(), this.GetCardId(), base.GetZone(), base.GetZonePosition() };
                    this.m_card.gameObject.name = string.Format("{0} [id={1} cardId={2} zone={3} zonePos={4}]", objArray2);
                }
            }
            else
            {
                this.m_card.gameObject.name = string.Format("Hidden Entity [id={0} zone={1} zonePos={2}]", base.GetEntityId(), base.GetZone(), base.GetZonePosition());
            }
        }
    }

    public void UpdateTags(List<Network.Entity.Tag> netTags)
    {
        base.m_tags.Update(netTags);
    }

    public void UpdateTagsAndUpdateCard(List<Network.Entity.Tag> netTags)
    {
        TagDeltaSet changeSet = base.m_tags.CreateDeltas(netTags);
        base.m_tags.Update(netTags);
        this.OnTagsChanged(changeSet);
    }

    public void UpdateUseBattlecryFlag(bool fromGameState)
    {
        if (base.GetCardType() == TAG_CARDTYPE.MINION)
        {
            bool flag = fromGameState || GameState.Get().EntityHasTargets(this);
            if ((base.GetZone() == TAG_ZONE.HAND) && flag)
            {
                this.m_useBattlecryPower = true;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <ConvertToSourceInfo>c__AnonStorey136
    {
        internal string entourageCardID;

        internal bool <>m__2A(string otherCardID)
        {
            return otherCardID.Equals(this.entourageCardID, StringComparison.OrdinalIgnoreCase);
        }
    }
}


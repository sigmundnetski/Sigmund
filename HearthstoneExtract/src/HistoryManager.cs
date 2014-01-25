using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HistoryManager : MonoBehaviour
{
    private const float BATTLEFIELD_CARD_DISPLAY_TIME = 3f;
    private Vector3[] bigCardPath;
    private HistoryCard currentBigCard;
    private HistoryCard currentlyMousedOverTile;
    public Texture fatigueTexture;
    private const float HERO_POWER_DISPLAY_TIME = 4f;
    private bool historyDisabled;
    private bool m_animatingDesat;
    private bool m_animatingVignette;
    private List<HistoryCard> m_historyTiles;
    private List<HistoryEntry> m_queuedEntries;
    public SoundDucker m_SoundDucker;
    private static HistoryManager s_instance;
    private const float SECRET_CARD_DISPLAY_TIME = 4f;
    public Texture secretTexture;
    private float sizeOfBigTile;
    private float SPACE_BETWEEN_TILES = 0.15f;
    private const float SPELL_CARD_DISPLAY_TIME = 4f;

    private void AnimateVignetteIn()
    {
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        this.m_animatingVignette = component.VignettingEnable;
        if (this.m_animatingVignette)
        {
            object[] args = new object[] { 
                "from", component.VignettingIntensity, "to", 0.6f, "time", 0.4f, "easetype", iTween.EaseType.easeInOutQuad, "onupdate", "OnUpdateVignetteVal", "onupdatetarget", base.gameObject, "name", "historyVig", "oncomplete", "OnVignetteInFinished", 
                "oncompletetarget", base.gameObject
             };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(Camera.main.gameObject, "historyVig");
            iTween.ValueTo(Camera.main.gameObject, hashtable);
        }
        this.m_animatingDesat = component.DesaturationEnabled;
        if (this.m_animatingDesat)
        {
            object[] objArray2 = new object[] { 
                "from", component.Desaturation, "to", 1f, "time", 0.4f, "easetype", iTween.EaseType.easeInOutQuad, "onupdate", "OnUpdateDesatVal", "onupdatetarget", base.gameObject, "name", "historyDesat", "oncomplete", "OnDesatInFinished", 
                "oncompletetarget", base.gameObject
             };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.StopByName(Camera.main.gameObject, "historyDesat");
            iTween.ValueTo(Camera.main.gameObject, hashtable2);
        }
    }

    private void AnimateVignetteOut()
    {
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        this.m_animatingVignette = component.VignettingEnable;
        if (this.m_animatingVignette)
        {
            object[] args = new object[] { 
                "from", component.VignettingIntensity, "to", 0f, "time", 0.4f, "easetype", iTween.EaseType.easeInOutQuad, "onupdate", "OnUpdateVignetteVal", "onupdatetarget", base.gameObject, "name", "historyVig", "oncomplete", "OnVignetteOutFinished", 
                "oncompletetarget", base.gameObject
             };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(Camera.main.gameObject, "historyVig");
            iTween.ValueTo(Camera.main.gameObject, hashtable);
        }
        this.m_animatingDesat = component.DesaturationEnabled;
        if (this.m_animatingDesat)
        {
            object[] objArray2 = new object[] { 
                "from", component.Desaturation, "to", 0f, "time", 0.4f, "easetype", iTween.EaseType.easeInOutQuad, "onupdate", "OnUpdateDesatVal", "onupdatetarget", base.gameObject, "name", "historyDesat", "oncomplete", "OnDesatOutFinished", 
                "oncompletetarget", base.gameObject
             };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.StopByName(Camera.main.gameObject, "historyDesat");
            iTween.ValueTo(Camera.main.gameObject, hashtable2);
        }
    }

    private void AttackHistoryCardLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        List<HistoryInfo> cards = (List<HistoryInfo>) callbackData;
        HistoryInfo info = cards[0];
        cards.RemoveAt(0);
        HistoryCard component = actorObject.GetComponent<HistoryCard>();
        this.m_historyTiles.Add(component);
        component.SetCardInfo(info.GetDuplicatedEntity(), info.m_bigCardPortraitTexture, info.GetSplatAmount(), info.died, null, false, false, info.m_bigCardGoldenMaterial);
        component.LoadAttackTileActor();
        this.LoadHistoryChildren(component, cards);
    }

    private void Awake()
    {
        s_instance = this;
        this.m_queuedEntries = new List<HistoryEntry>();
        base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.15f, base.transform.position.z);
    }

    private void BigCardLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        BigCardEntry entry = (BigCardEntry) callbackData;
        HistoryInfo cardInfo = entry.cardInfo;
        Entity originalEntity = cardInfo.GetOriginalEntity();
        Card card = cardInfo.GetCard();
        if ((originalEntity.GetCardType() == TAG_CARDTYPE.ABILITY) || (originalEntity.GetCardType() == TAG_CARDTYPE.HERO_POWER))
        {
            actorObject.transform.position = card.transform.position;
            actorObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        else
        {
            actorObject.transform.position = this.GetBigCardPosition();
        }
        HistoryCard component = actorObject.GetComponent<HistoryCard>();
        component.SetCardInfo(cardInfo.GetDuplicatedEntity(), cardInfo.m_bigCardPortraitTexture, 0, false, entry.callbackFunction, entry.wasCountered, entry.waitForSecretSpell, cardInfo.m_bigCardGoldenMaterial);
        component.LoadBigCardActor(true);
    }

    private void CheckForMouseOff()
    {
        if (this.currentlyMousedOverTile != null)
        {
            this.currentlyMousedOverTile.NotifyMousedOut();
            this.currentlyMousedOverTile = null;
            this.m_SoundDucker.StopDucking();
            this.FadeVignetteOut();
        }
    }

    private void ChildLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        HistoryCallbackData data = (HistoryCallbackData) callbackData;
        HistoryCard parentCard = data.parentCard;
        HistoryInfo sourceCard = data.sourceCard;
        HistoryChildCard component = actorObject.GetComponent<HistoryChildCard>();
        component.SetCardInfo(sourceCard.GetDuplicatedEntity(), sourceCard.m_bigCardPortraitTexture, sourceCard.GetSplatAmount(), sourceCard.died, sourceCard.m_bigCardGoldenMaterial);
        component.transform.parent = parentCard.transform;
        parentCard.AddHistoryChild(component);
        component.LoadActor();
    }

    [DebuggerHidden]
    private IEnumerator ClearBigCard()
    {
        return new <ClearBigCard>c__Iterator3D { <>f__this = this };
    }

    public void CreateAttackTile(Entity attacker, Entity defender)
    {
        if (!this.historyDisabled)
        {
            HistoryEntry item = new HistoryEntry();
            this.m_queuedEntries.Add(item);
            item.SetAttacker(attacker);
            item.SetDefender(defender);
        }
    }

    public void CreateCardPlayedTile(Entity cardPlayed, Entity cardTargeted)
    {
        if (!this.historyDisabled)
        {
            HistoryEntry item = new HistoryEntry();
            this.m_queuedEntries.Add(item);
            item.SetCardPlayed(cardPlayed);
            item.SetCardTargeted(cardTargeted);
        }
    }

    public void CreateFatigueTile()
    {
        if (!this.historyDisabled)
        {
            HistoryEntry item = new HistoryEntry();
            this.m_queuedEntries.Add(item);
            item.SetFatigue();
        }
    }

    public void CreatePlayedBigCard(Entity entity, FinishedCallback functionToCall, bool wasCountered)
    {
        if (!GameState.Get().GetGameEntity().ShouldShowBigCard())
        {
            functionToCall();
        }
        else
        {
            base.StopCoroutine("WaitForCardLoadedAndCreateBigCard");
            BigCardEntry entry = new BigCardEntry {
                cardInfo = new HistoryInfo()
            };
            entry.cardInfo.SetOriginalEntity(entity);
            entry.cardInfo.infoType = HistoryInfoType.CARD_PLAYED;
            entry.callbackFunction = functionToCall;
            entry.wasCountered = wasCountered;
            entry.waitForSecretSpell = false;
            base.StartCoroutine("WaitForCardLoadedAndCreateBigCard", entry);
        }
    }

    public void CreateTriggeredBigCard(Entity entity, string replaceTextString, FinishedCallback functionToCall, bool secret)
    {
        base.StopCoroutine("WaitForCardLoadedAndCreateBigCard");
        BigCardEntry entry = new BigCardEntry {
            cardInfo = new HistoryInfo()
        };
        entry.cardInfo.replacementText = replaceTextString;
        entry.cardInfo.SetOriginalEntity(entity);
        entry.cardInfo.infoType = HistoryInfoType.TRIGGER;
        entry.callbackFunction = functionToCall;
        entry.waitForSecretSpell = secret;
        base.StartCoroutine("WaitForCardLoadedAndCreateBigCard", entry);
    }

    public void CreateTriggerTile(Entity triggeringEntity, string replacementText)
    {
        if (!this.historyDisabled)
        {
            HistoryEntry item = new HistoryEntry();
            this.m_queuedEntries.Add(item);
            item.SetCardTriggered(triggeringEntity, replacementText);
        }
    }

    public void CreateWeaponBreakTile(Card brokenWeapon)
    {
    }

    private void DestroyBigCard()
    {
        if ((this.currentBigCard != null) && (this.currentBigCard.m_tileActor == null))
        {
            this.currentBigCard.RunCallbackNow();
            if (this.currentBigCard.m_mainCardActor != null)
            {
                if (this.currentBigCard.WasCountered())
                {
                    this.currentBigCard.m_mainCardActor.ActivateSpell(SpellType.DEATH);
                    this.currentBigCard = null;
                }
                else
                {
                    this.currentBigCard.m_mainCardActor.Hide();
                    UnityEngine.Object.Destroy(this.currentBigCard.gameObject);
                }
            }
        }
    }

    private void DestroyHistoryTilesThatFallOffTheEnd()
    {
        if (this.sizeOfBigTile > 0f)
        {
            float num = 0f;
            float z = base.collider.bounds.size.z;
            for (int i = 0; i < this.m_historyTiles.Count; i++)
            {
                if (this.m_historyTiles[i].GetHalfSize())
                {
                    num += this.sizeOfBigTile / 2f;
                }
                else
                {
                    num += this.sizeOfBigTile;
                }
            }
            num += this.SPACE_BETWEEN_TILES * (this.m_historyTiles.Count - 1);
            while (num > z)
            {
                if (this.m_historyTiles[0].GetHalfSize())
                {
                    num -= this.sizeOfBigTile / 2f;
                }
                else
                {
                    num -= this.sizeOfBigTile;
                }
                num -= this.SPACE_BETWEEN_TILES;
                UnityEngine.Object.Destroy(this.m_historyTiles[0].gameObject);
                this.m_historyTiles.RemoveAt(0);
            }
        }
    }

    public void DisableHistory()
    {
        this.historyDisabled = true;
    }

    private void FadeVignetteIn()
    {
        foreach (HistoryCard card in this.m_historyTiles)
        {
            if (card.m_tileActor != null)
            {
                SceneUtils.SetLayer(card.m_tileActor.gameObject, GameLayer.IgnoreFullScreenEffects);
            }
        }
        SceneUtils.SetLayer(base.gameObject, GameLayer.IgnoreFullScreenEffects);
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.VignettingEnable = true;
        component.DesaturationEnabled = true;
        this.AnimateVignetteIn();
    }

    private void FadeVignetteOut()
    {
        foreach (HistoryCard card in this.m_historyTiles)
        {
            if (card.m_tileActor != null)
            {
                SceneUtils.SetLayer(card.m_tileActor.gameObject, GameLayer.Default);
            }
        }
        SceneUtils.SetLayer(base.gameObject, GameLayer.CardRaycast);
        this.AnimateVignetteOut();
    }

    public static HistoryManager Get()
    {
        return s_instance;
    }

    public Vector3[] GetBigCardPath()
    {
        return this.bigCardPath;
    }

    public Vector3 GetBigCardPosition()
    {
        return Board.Get().FindBone("BigCardPosition").position;
    }

    public HistoryCard GetCurrentBigCard()
    {
        return this.currentBigCard;
    }

    private HistoryEntry GetCurrentHistoryEntry()
    {
        if (this.m_queuedEntries.Count != 0)
        {
            for (int i = this.m_queuedEntries.Count - 1; i >= 0; i--)
            {
                if (!this.m_queuedEntries[i].complete)
                {
                    return this.m_queuedEntries[i];
                }
            }
        }
        return null;
    }

    public int GetIndexForTile(HistoryCard tile)
    {
        for (int i = 0; i < this.m_historyTiles.Count; i++)
        {
            if (this.m_historyTiles[i] == tile)
            {
                return i;
            }
        }
        UnityEngine.Debug.LogWarning("HistoryManager.GetIndexForTile() - that Tile doesn't exist!");
        return -1;
    }

    public int GetNumHistoryTiles()
    {
        return this.m_historyTiles.Count;
    }

    public Vector3 GetTopTilePosition()
    {
        return new Vector3(base.transform.position.x, base.transform.position.y - 0.15f, base.transform.position.z);
    }

    public void HandleClickOnBigCard()
    {
        this.StopTimerAndKillBigCardNow();
    }

    private bool IsEntityTheAffectedCard(Entity entity, int index)
    {
        return ((this.GetCurrentHistoryEntry().affectedCards[index] != null) && (entity == this.GetCurrentHistoryEntry().affectedCards[index].GetOriginalEntity()));
    }

    private bool IsEntityTheLastAttacker(Entity entity)
    {
        return ((this.GetCurrentHistoryEntry().lastAttacker != null) && (entity == this.GetCurrentHistoryEntry().lastAttacker.GetOriginalEntity()));
    }

    private bool IsEntityTheLastCardPlayed(Entity entity)
    {
        return ((this.GetCurrentHistoryEntry().lastCardPlayed != null) && (entity == this.GetCurrentHistoryEntry().lastCardPlayed.GetOriginalEntity()));
    }

    private bool IsEntityTheLastCardTargeted(Entity entity)
    {
        return ((this.GetCurrentHistoryEntry().lastCardTargeted != null) && (entity == this.GetCurrentHistoryEntry().lastCardTargeted.GetOriginalEntity()));
    }

    private bool IsEntityTheLastDefender(Entity entity)
    {
        return ((this.GetCurrentHistoryEntry().lastDefender != null) && (entity == this.GetCurrentHistoryEntry().lastDefender.GetOriginalEntity()));
    }

    private void LoadHistoryChildren(HistoryCard parentCard, List<HistoryInfo> cards)
    {
        if (cards.Count >= 1)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                HistoryCallbackData callbackData = new HistoryCallbackData {
                    parentCard = parentCard,
                    sourceCard = cards[i]
                };
                AssetLoader.Get().LoadActor("HistoryChildCard", new AssetLoader.GameObjectCallback(this.ChildLoadedCallback), callbackData);
            }
        }
    }

    private void LoadNextHistoryEntry()
    {
        if ((this.m_queuedEntries.Count != 0) && this.m_queuedEntries[0].complete)
        {
            base.StartCoroutine(this.LoadNextHistoryEntryWhenLoaded());
        }
    }

    [DebuggerHidden]
    private IEnumerator LoadNextHistoryEntryWhenLoaded()
    {
        return new <LoadNextHistoryEntryWhenLoaded>c__Iterator3F { <>f__this = this };
    }

    public void MarkCurrentHistoryEntryAsCompleted()
    {
        if (!this.historyDisabled)
        {
            this.GetCurrentHistoryEntry().complete = true;
            this.LoadNextHistoryEntry();
        }
    }

    public void NotifyAboutArmorChanged(Entity entity, int newArmor)
    {
        if (!this.historyDisabled)
        {
            int num = entity.GetArmor() - newArmor;
            if ((num > 0) && !this.IsEntityTheLastCardPlayed(entity))
            {
                if (this.IsEntityTheLastAttacker(entity))
                {
                    this.GetCurrentHistoryEntry().lastAttacker.armorChangeAmount = num;
                }
                else if (this.IsEntityTheLastDefender(entity))
                {
                    this.GetCurrentHistoryEntry().lastDefender.armorChangeAmount = num;
                }
                else if (this.IsEntityTheLastCardTargeted(entity))
                {
                    this.GetCurrentHistoryEntry().lastCardTargeted.armorChangeAmount = num;
                }
                else
                {
                    for (int i = 0; i < this.GetCurrentHistoryEntry().affectedCards.Count; i++)
                    {
                        if (this.IsEntityTheAffectedCard(entity, i))
                        {
                            this.GetCurrentHistoryEntry().affectedCards[i].armorChangeAmount = num;
                            return;
                        }
                    }
                    this.NotifyAboutPreDamage(entity);
                    this.NotifyAboutDamageChanged(entity, newArmor);
                }
            }
        }
    }

    public void NotifyAboutCardDeath(Entity entity)
    {
        if (!this.historyDisabled && !this.IsEntityTheLastCardPlayed(entity))
        {
            if (this.IsEntityTheLastAttacker(entity))
            {
                this.GetCurrentHistoryEntry().lastAttacker.died = true;
            }
            else if (this.IsEntityTheLastDefender(entity))
            {
                this.GetCurrentHistoryEntry().lastDefender.died = true;
            }
            else if (this.IsEntityTheLastCardTargeted(entity))
            {
                this.GetCurrentHistoryEntry().lastCardTargeted.died = true;
            }
            else
            {
                for (int i = 0; i < this.GetCurrentHistoryEntry().affectedCards.Count; i++)
                {
                    if (this.IsEntityTheAffectedCard(entity, i))
                    {
                        this.GetCurrentHistoryEntry().affectedCards[i].died = true;
                        return;
                    }
                }
                this.NotifyAboutPreDamage(entity);
                this.NotifyAboutCardDeath(entity);
            }
        }
    }

    public void NotifyAboutDamageChanged(Entity entity, int damage)
    {
        if ((entity != null) && !this.historyDisabled)
        {
            int num = damage - entity.GetDamage();
            if (this.IsEntityTheLastCardPlayed(entity))
            {
                this.GetCurrentHistoryEntry().lastCardPlayed.damageChangeAmount = num;
            }
            else if (this.IsEntityTheLastAttacker(entity))
            {
                this.GetCurrentHistoryEntry().lastAttacker.damageChangeAmount = num;
            }
            else if (this.IsEntityTheLastDefender(entity))
            {
                this.GetCurrentHistoryEntry().lastDefender.damageChangeAmount = num;
            }
            else if (this.IsEntityTheLastCardTargeted(entity))
            {
                this.GetCurrentHistoryEntry().lastCardTargeted.damageChangeAmount = num;
            }
            else
            {
                for (int i = 0; i < this.GetCurrentHistoryEntry().affectedCards.Count; i++)
                {
                    if (this.IsEntityTheAffectedCard(entity, i))
                    {
                        this.GetCurrentHistoryEntry().affectedCards[i].damageChangeAmount = num;
                        return;
                    }
                }
                this.NotifyAboutPreDamage(entity);
                this.NotifyAboutDamageChanged(entity, damage);
            }
        }
    }

    public void NotifyAboutPreDamage(Entity entity)
    {
        if ((((!this.historyDisabled && !this.IsEntityTheLastAttacker(entity)) && !this.IsEntityTheLastDefender(entity)) && ((this.GetCurrentHistoryEntry().lastCardPlayed == null) || (entity != this.GetCurrentHistoryEntry().lastCardPlayed.GetOriginalEntity()))) && !this.IsEntityTheLastCardTargeted(entity))
        {
            for (int i = 0; i < this.GetCurrentHistoryEntry().affectedCards.Count; i++)
            {
                if (this.IsEntityTheAffectedCard(entity, i))
                {
                    return;
                }
            }
            HistoryInfo item = new HistoryInfo();
            item.SetOriginalEntity(entity);
            this.GetCurrentHistoryEntry().affectedCards.Add(item);
        }
    }

    public void NotifyOfInput(float zPosition)
    {
        if (this.m_historyTiles.Count == 0)
        {
            this.CheckForMouseOff();
        }
        else
        {
            float num = 1000f;
            float num2 = -1000f;
            float num3 = 1000f;
            HistoryCard card = null;
            foreach (HistoryCard card2 in this.m_historyTiles)
            {
                if (card2.HasBeenShown())
                {
                    Collider tileCollider = card2.GetTileCollider();
                    if (tileCollider != null)
                    {
                        float num4 = tileCollider.bounds.center.z - tileCollider.bounds.extents.z;
                        float num5 = tileCollider.bounds.center.z + tileCollider.bounds.extents.z;
                        if (num4 < num)
                        {
                            num = num4;
                        }
                        if (num5 > num2)
                        {
                            num2 = num5;
                        }
                        float num6 = Mathf.Abs((float) (zPosition - num4));
                        if (num6 < num3)
                        {
                            num3 = num6;
                            card = card2;
                        }
                        float num7 = Mathf.Abs((float) (zPosition - num5));
                        if (num7 < num3)
                        {
                            num3 = num7;
                            card = card2;
                        }
                    }
                }
            }
            if ((zPosition < num) || (zPosition > num2))
            {
                this.CheckForMouseOff();
            }
            else if (card == null)
            {
                this.CheckForMouseOff();
            }
            else
            {
                this.m_SoundDucker.StartDucking();
                if (card != this.currentlyMousedOverTile)
                {
                    if (this.currentlyMousedOverTile != null)
                    {
                        this.currentlyMousedOverTile.NotifyMousedOut();
                    }
                    else
                    {
                        this.FadeVignetteIn();
                    }
                    this.currentlyMousedOverTile = card;
                    card.NotifyMousedOver();
                }
            }
        }
    }

    public void NotifyOfMouseOff()
    {
        this.CheckForMouseOff();
    }

    public void NotifyOfSecretSpellFinished()
    {
        this.currentBigCard.NotifyOfSecretFinished();
    }

    private void OnDesatInFinished()
    {
        this.m_animatingDesat = false;
    }

    private void OnDesatOutFinished()
    {
        this.m_animatingDesat = false;
        Camera.main.GetComponent<FullScreenEffects>().DesaturationEnabled = false;
        this.OnFullScreenEffectOutFinished();
    }

    private void OnFullScreenEffectOutFinished()
    {
        if (!this.m_animatingDesat && !this.m_animatingVignette)
        {
            Camera.main.GetComponent<FullScreenEffects>().Disable();
        }
    }

    public void OnHistoryTileComplete()
    {
        if (this.m_queuedEntries.Count > 0)
        {
            this.LoadNextHistoryEntry();
        }
    }

    private void OnUpdateDesatVal(float val)
    {
        Camera.main.GetComponent<FullScreenEffects>().Desaturation = val;
    }

    private void OnUpdateVignetteVal(float val)
    {
        Camera.main.GetComponent<FullScreenEffects>().VignettingIntensity = val;
    }

    private void OnVignetteInFinished()
    {
        this.m_animatingVignette = false;
    }

    private void OnVignetteOutFinished()
    {
        this.m_animatingVignette = false;
        Camera.main.GetComponent<FullScreenEffects>().VignettingEnable = false;
        this.OnFullScreenEffectOutFinished();
    }

    public void SetAsideTileAndTryToUpdate(HistoryCard tile)
    {
        Vector3 topTilePosition = this.GetTopTilePosition();
        tile.transform.position = new Vector3(topTilePosition.x - 20f, topTilePosition.y, topTilePosition.z);
        this.UpdateLayout();
    }

    public void SetBigCard(HistoryCard newCard, bool delayTimer)
    {
        this.StopTimerAndKillBigCardNow();
        this.currentBigCard = newCard;
        if (!delayTimer)
        {
            base.StartCoroutine("ClearBigCard");
        }
    }

    public void SetBigTileSize(float size)
    {
        this.sizeOfBigTile = size;
    }

    private void Start()
    {
        this.m_historyTiles = new List<HistoryCard>();
        base.StartCoroutine(this.WaitForBoardLoadedAndSetPaths());
    }

    public void StartBigCardTimer()
    {
        base.StartCoroutine("ClearBigCard");
    }

    private void StopTimerAndKillBigCardNow()
    {
        base.StopCoroutine("ClearBigCard");
        this.DestroyBigCard();
    }

    private void TileHistoryCardLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        List<HistoryInfo> cards = (List<HistoryInfo>) callbackData;
        HistoryInfo sourceCard = cards[0];
        cards.RemoveAt(0);
        HistoryCard component = actorObject.GetComponent<HistoryCard>();
        this.m_historyTiles.Add(component);
        if (sourceCard.infoType == HistoryInfoType.FATIGUE)
        {
            component.SetFatigue(this.fatigueTexture);
            component.LoadCorrectTileActor(sourceCard);
            this.LoadHistoryChildren(component, cards);
        }
        else
        {
            Entity duplicatedEntity = sourceCard.GetDuplicatedEntity();
            if ((duplicatedEntity.IsSecret() && duplicatedEntity.IsHidden()) && !duplicatedEntity.IsControlledByLocalPlayer())
            {
                sourceCard.m_bigCardPortraitTexture = this.secretTexture;
            }
            component.SetCardInfo(duplicatedEntity, sourceCard.m_bigCardPortraitTexture, sourceCard.GetSplatAmount(), sourceCard.died, null, false, false, sourceCard.m_bigCardGoldenMaterial);
            component.AssignMaterials(sourceCard.GetCard().GetCardDef());
            component.LoadCorrectTileActor(sourceCard);
            this.LoadHistoryChildren(component, cards);
        }
    }

    public void UpdateLayout()
    {
        if (!this.UserIsMousedOverAHistoryTile())
        {
            float num = 0f;
            Vector3 topTilePosition = this.GetTopTilePosition();
            for (int i = this.m_historyTiles.Count - 1; i >= 0; i--)
            {
                int num3 = 0;
                if (this.m_historyTiles[i].GetHalfSize())
                {
                    num3 = 1;
                }
                Collider tileCollider = this.m_historyTiles[i].GetTileCollider();
                float num4 = 0f;
                if (tileCollider != null)
                {
                    num4 = tileCollider.bounds.size.z / 2f;
                }
                Vector3 position = new Vector3(topTilePosition.x, topTilePosition.y, (topTilePosition.z - num) + (num3 * num4));
                this.m_historyTiles[i].MarkAsShown();
                iTween.MoveTo(this.m_historyTiles[i].gameObject, position, 1f);
                if (tileCollider != null)
                {
                    num += tileCollider.bounds.size.z + this.SPACE_BETWEEN_TILES;
                }
            }
            this.DestroyHistoryTilesThatFallOffTheEnd();
        }
    }

    private bool UserIsMousedOverAHistoryTile()
    {
        RaycastHit hit;
        if ((UniversalInputManager.Get().GetInputHitInfo(GameLayer.Default.LayerBit(), out hit) && (hit.transform.GetComponentInChildren<HistoryManager>() == null)) && (hit.transform.GetComponentInChildren<HistoryCard>() == null))
        {
            return false;
        }
        float z = hit.point.z;
        float num2 = 1000f;
        float num3 = -1000f;
        foreach (HistoryCard card in this.m_historyTiles)
        {
            if (card.HasBeenShown())
            {
                Collider tileCollider = card.GetTileCollider();
                if (tileCollider != null)
                {
                    float num4 = tileCollider.bounds.center.z - tileCollider.bounds.extents.z;
                    float num5 = tileCollider.bounds.center.z + tileCollider.bounds.extents.z;
                    if (num4 < num2)
                    {
                        num2 = num4;
                    }
                    if (num5 > num3)
                    {
                        num3 = num5;
                    }
                }
            }
        }
        return ((z >= num2) && (z <= num3));
    }

    [DebuggerHidden]
    private IEnumerator WaitForBoardLoadedAndSetPaths()
    {
        return new <WaitForBoardLoadedAndSetPaths>c__Iterator3C { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitForCardLoadedAndCreateBigCard(BigCardEntry bigCardEntry)
    {
        return new <WaitForCardLoadedAndCreateBigCard>c__Iterator3E { bigCardEntry = bigCardEntry, <$>bigCardEntry = bigCardEntry, <>f__this = this };
    }

    private void WeaponBreakHistoryCardLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        HistoryInfo info = (HistoryInfo) callbackData;
        HistoryCard component = actorObject.GetComponent<HistoryCard>();
        this.m_historyTiles.Add(component);
        component.SetCardInfo(info.GetDuplicatedEntity(), info.m_bigCardPortraitTexture, info.GetSplatAmount(), true, null, false, false, info.m_bigCardGoldenMaterial);
        component.LoadWeaponBreakActor();
    }

    [CompilerGenerated]
    private sealed class <ClearBigCard>c__Iterator3D : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HistoryManager <>f__this;
        internal TAG_CARDTYPE <curCardType>__1;
        internal float <timeToWait>__0;

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
                    this.<timeToWait>__0 = 0f;
                    if (this.<>f__this.currentBigCard.GetEntity() == null)
                    {
                        this.<timeToWait>__0 = 4f;
                        break;
                    }
                    this.<curCardType>__1 = this.<>f__this.currentBigCard.GetEntity().GetCardType();
                    if (this.<curCardType>__1 != TAG_CARDTYPE.ABILITY)
                    {
                        if (this.<curCardType>__1 == TAG_CARDTYPE.HERO_POWER)
                        {
                            this.<timeToWait>__0 = 4f + GameState.Get().GetGameEntity().GetAdditionalTimeToWaitForSpells();
                        }
                        else
                        {
                            this.<timeToWait>__0 = 3f;
                        }
                        break;
                    }
                    this.<timeToWait>__0 = 4f + GameState.Get().GetGameEntity().GetAdditionalTimeToWaitForSpells();
                    break;

                case 1:
                    this.<>f__this.DestroyBigCard();
                    this.$PC = -1;
                    goto Label_00FF;

                default:
                    goto Label_00FF;
            }
            this.$current = new WaitForSeconds(this.<timeToWait>__0);
            this.$PC = 1;
            return true;
        Label_00FF:
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
    private sealed class <LoadNextHistoryEntryWhenLoaded>c__Iterator3F : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HistoryManager <>f__this;
        internal List<HistoryInfo> <cards>__1;
        internal HistoryManager.HistoryEntry <currentEntry>__0;
        internal HistoryInfo <targetInfo>__2;

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
                    this.<currentEntry>__0 = this.<>f__this.m_queuedEntries[0];
                    this.<>f__this.m_queuedEntries.RemoveAt(0);
                    break;

                case 1:
                    break;

                default:
                    goto Label_0124;
            }
            if (!this.<currentEntry>__0.CanLoadAllInfos())
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<currentEntry>__0.LoadAllInfos();
            this.<cards>__1 = new List<HistoryInfo>();
            this.<cards>__1.Add(this.<currentEntry>__0.GetSourceForHistoryEntry());
            this.<targetInfo>__2 = this.<currentEntry>__0.GetTargetForHistoryEntry();
            if (this.<targetInfo>__2 != null)
            {
                this.<cards>__1.Add(this.<targetInfo>__2);
            }
            if (this.<currentEntry>__0.affectedCards.Count > 0)
            {
                this.<cards>__1.AddRange(this.<currentEntry>__0.affectedCards);
            }
            AssetLoader.Get().LoadActor("HistoryCard", new AssetLoader.GameObjectCallback(this.<>f__this.TileHistoryCardLoadedCallback), this.<cards>__1);
            this.$PC = -1;
        Label_0124:
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
    private sealed class <WaitForBoardLoadedAndSetPaths>c__Iterator3C : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HistoryManager <>f__this;
        internal Transform <bigCardPathPoint>__0;

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
                    if (ZoneMgr.Get() == null)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<bigCardPathPoint>__0 = Board.Get().FindBone("BigCardPathPoint");
                    if (this.<bigCardPathPoint>__0 != null)
                    {
                        this.<>f__this.bigCardPath = new Vector3[3];
                        this.<>f__this.bigCardPath[1] = this.<bigCardPathPoint>__0.position;
                        this.<>f__this.bigCardPath[2] = this.<>f__this.GetBigCardPosition();
                        this.$PC = -1;
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
    private sealed class <WaitForCardLoadedAndCreateBigCard>c__Iterator3E : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HistoryManager.BigCardEntry <$>bigCardEntry;
        internal HistoryManager <>f__this;
        internal HistoryInfo <lastCardInfo>__0;
        internal HistoryManager.BigCardEntry bigCardEntry;

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
                    this.<lastCardInfo>__0 = this.bigCardEntry.cardInfo;
                    break;

                case 1:
                    break;

                default:
                    goto Label_0093;
            }
            if (!this.<lastCardInfo>__0.CanLoadInfo())
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<lastCardInfo>__0.LoadInfo();
            AssetLoader.Get().LoadActor("HistoryCard", new AssetLoader.GameObjectCallback(this.<>f__this.BigCardLoadedCallback), this.bigCardEntry);
            this.$PC = -1;
        Label_0093:
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

    public class BigCardEntry
    {
        public HistoryManager.FinishedCallback callbackFunction;
        public HistoryInfo cardInfo;
        public bool waitForSecretSpell;
        public bool wasCountered;
    }

    public delegate void FinishedCallback();

    private class HistoryCallbackData
    {
        public HistoryCard parentCard;
        public HistoryInfo sourceCard;
    }

    private class HistoryEntry
    {
        public List<HistoryInfo> affectedCards = new List<HistoryInfo>();
        public HistoryInfo brokenWeapon;
        public bool complete;
        public HistoryInfo fatigueInfo;
        public HistoryInfo lastAttacker;
        public HistoryInfo lastCardPlayed;
        public HistoryInfo lastCardTargeted;
        public HistoryInfo lastCardTriggered;
        public HistoryInfo lastDefender;

        public bool CanLoadAllInfos()
        {
            HistoryInfo sourceForHistoryEntry = this.GetSourceForHistoryEntry();
            if ((sourceForHistoryEntry != null) && !sourceForHistoryEntry.CanLoadInfo())
            {
                return false;
            }
            HistoryInfo targetForHistoryEntry = this.GetTargetForHistoryEntry();
            if ((targetForHistoryEntry != null) && !targetForHistoryEntry.CanLoadInfo())
            {
                return false;
            }
            for (int i = 0; i < this.affectedCards.Count; i++)
            {
                if ((this.affectedCards[i] != null) && !this.affectedCards[i].CanLoadInfo())
                {
                    return false;
                }
            }
            return true;
        }

        public HistoryInfo GetSourceForHistoryEntry()
        {
            if (this.lastCardPlayed != null)
            {
                return this.lastCardPlayed;
            }
            if (this.lastAttacker != null)
            {
                return this.lastAttacker;
            }
            if (this.lastCardTriggered != null)
            {
                return this.lastCardTriggered;
            }
            if (this.fatigueInfo != null)
            {
                return this.fatigueInfo;
            }
            UnityEngine.Debug.LogError("The history is trying to load an entry with no source.");
            return null;
        }

        public HistoryInfo GetTargetForHistoryEntry()
        {
            if ((this.lastCardPlayed != null) && (this.lastCardTargeted != null))
            {
                return this.lastCardTargeted;
            }
            if ((this.lastAttacker != null) && (this.lastDefender != null))
            {
                return this.lastDefender;
            }
            return null;
        }

        public void LoadAllInfos()
        {
            if (this.lastAttacker != null)
            {
                this.lastAttacker.LoadInfo();
            }
            if (this.lastDefender != null)
            {
                this.lastDefender.LoadInfo();
            }
            if (this.lastCardPlayed != null)
            {
                this.lastCardPlayed.LoadInfo();
            }
            if (this.lastCardTriggered != null)
            {
                this.lastCardTriggered.LoadInfo();
            }
            if (this.lastCardTargeted != null)
            {
                this.lastCardTargeted.LoadInfo();
            }
            for (int i = 0; i < this.affectedCards.Count; i++)
            {
                if (this.affectedCards[i] != null)
                {
                    this.affectedCards[i].LoadInfo();
                }
            }
        }

        public void SetAttacker(Entity attacker)
        {
            this.lastAttacker = new HistoryInfo();
            this.lastAttacker.SetOriginalEntity(attacker);
            this.lastAttacker.infoType = HistoryInfoType.ATTACK;
        }

        public void SetBrokenWeapon(Entity entity)
        {
            this.brokenWeapon = new HistoryInfo();
            this.brokenWeapon.SetOriginalEntity(entity);
            this.brokenWeapon.infoType = HistoryInfoType.WEAPON_BREAK;
        }

        public void SetCardPlayed(Entity entity)
        {
            this.lastCardPlayed = new HistoryInfo();
            this.lastCardPlayed.SetOriginalEntity(entity);
            this.lastCardPlayed.infoType = HistoryInfoType.CARD_PLAYED;
        }

        public void SetCardTargeted(Entity entity)
        {
            if (entity != null)
            {
                this.lastCardTargeted = new HistoryInfo();
                this.lastCardTargeted.SetOriginalEntity(entity);
            }
        }

        public void SetCardTriggered(Entity entity, string replaceTextString)
        {
            if (entity.IsCard())
            {
                this.lastCardTriggered = new HistoryInfo();
                this.lastCardTriggered.replacementText = replaceTextString;
                this.lastCardTriggered.SetOriginalEntity(entity);
                this.lastCardTriggered.infoType = HistoryInfoType.TRIGGER;
            }
        }

        public void SetDefender(Entity defender)
        {
            this.lastDefender = new HistoryInfo();
            this.lastDefender.SetOriginalEntity(defender);
        }

        public void SetFatigue()
        {
            this.fatigueInfo = new HistoryInfo();
            this.fatigueInfo.infoType = HistoryInfoType.FATIGUE;
        }
    }
}


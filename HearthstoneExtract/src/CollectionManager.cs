using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionManager
{
    [CompilerGenerated]
    private static Predicate<NetCache.ProfileNotice> <>f__am$cache16;
    private List<DelOnAchievesCompleted> m_achievesCompletedListeners = new List<DelOnAchievesCompleted>();
    private List<DelOnAllDeckContents> m_allDeckContentsListeners = new List<DelOnAllDeckContents>();
    private Dictionary<long, CollectionDeck> m_baseDecks = new Dictionary<long, CollectionDeck>();
    private List<DelOnCardRewardInserted> m_cardRewardListeners = new List<DelOnCardRewardInserted>();
    private bool m_cardStacksRegistered;
    private Dictionary<string, CollectionCardStack> m_collectibleStacks = new Dictionary<string, CollectionCardStack>();
    private List<DelOnCollectionChanged> m_collectionChangedListeners = new List<DelOnCollectionChanged>();
    private List<DelOnCollectionLoaded> m_collectionLoadedListeners = new List<DelOnCollectionLoaded>();
    private int m_currentEntityDefLoadIndex = -1;
    private List<DelOnDeckContents> m_deckContentsListeners = new List<DelOnDeckContents>();
    private List<DelOnDeckCreated> m_deckCreatedListeners = new List<DelOnDeckCreated>();
    private Dictionary<long, CollectionDeck> m_decks = new Dictionary<long, CollectionDeck>();
    private bool m_entityDefsLoaded;
    private bool m_hasVisitedCollection;
    private int m_maxEntityDefLoadIndex;
    private bool m_netCacheReady;
    private List<DelOnNewCardSeen> m_newCardSeenListeners = new List<DelOnNewCardSeen>();
    private Dictionary<TAG_CLASS, long> m_preconDecks = new Dictionary<TAG_CLASS, long>();
    private bool m_unloading;
    private bool m_waitingForBoxTransition;
    private bool m_waitingToShowPackOpening;
    private const int MAX_SIMULTANEOUS_ENTITYDEF_LOADS = 60;
    private const int NUM_CARDS_GRANTED_POST_TUTORIAL = 0x60;
    private const int NUM_CARDS_TO_UNLOCK_ADVANCED_CM = 0x74;
    private const int NUM_EXPERT_CARDS_TO_UNLOCK_CRAFTING = 20;
    public const int NUM_EXPERT_CARDS_TO_UNLOCK_FORGE = 20;
    private static CollectionManager s_instance;

    private void AddCardFromRewardNotice(CardRewardData cardReward)
    {
        DateTime now = DateTime.Now;
        CardFlair cardFlair = new CardFlair(cardReward.Premium);
        this.InsertNewCollectionCard(cardReward.CardID, cardFlair, now, cardReward.Count, false);
        foreach (DelOnCardRewardInserted inserted in this.m_cardRewardListeners)
        {
            inserted(cardReward.CardID, cardFlair);
        }
    }

    private CollectionDeck AddDeck(NetCache.DeckHeader deckHeader)
    {
        return this.AddDeck(deckHeader, true);
    }

    private CollectionDeck AddDeck(NetCache.DeckHeader deckHeader, bool updateNetCache)
    {
        if (deckHeader.Type != NetCache.DeckHeader.DeckType.NORMAL_DECK)
        {
            Debug.LogWarning(string.Format("CollectionManager.AddDeck(): deckHeader {0} is not of type NORMAL_DECK", deckHeader));
            return null;
        }
        CollectionDeck deck3 = new CollectionDeck {
            ID = deckHeader.ID,
            Name = deckHeader.Name,
            HeroCardID = deckHeader.Hero,
            IsTourneyValid = deckHeader.IsTourneyValid
        };
        CollectionDeck deck = deck3;
        this.m_decks.Add(deckHeader.ID, deck);
        deck3 = new CollectionDeck {
            ID = deckHeader.ID,
            Name = deckHeader.Name,
            HeroCardID = deckHeader.Hero,
            IsTourneyValid = deckHeader.IsTourneyValid
        };
        CollectionDeck deck2 = deck3;
        this.m_baseDecks.Add(deckHeader.ID, deck2);
        if (updateNetCache)
        {
            NetCache.Get().GetNetObject<NetCache.NetCacheDecks>().Decks.Add(deckHeader);
        }
        return deck;
    }

    private void AddPreconDeck(TAG_CLASS heroClass, long deckID)
    {
        if (this.m_preconDecks.ContainsKey(heroClass))
        {
            Debug.LogWarning(string.Format("CollectionManager.AddPreconDeck(): Already have a precon deck for class {0}, cannot add deck ID {1}", heroClass, deckID));
        }
        else
        {
            Log.Rachelle.Print(string.Format("CollectionManager.AddPreconDeck({0}, {1})", heroClass, deckID));
            this.m_preconDecks[heroClass] = deckID;
        }
    }

    private void AddPreconDeckFromNotice(NetCache.ProfileNoticePreconDeck preconDeckNotice)
    {
        CollectibleHero heroFromAssetID = CollectibleHero.GetHeroFromAssetID(preconDeckNotice.HeroAsset);
        if (heroFromAssetID == null)
        {
            Debug.LogWarning(string.Format("CollectionManager.AddPreconDeckFromNotice(): could not find collectible hero for asset {0}", preconDeckNotice.HeroAsset));
        }
        else
        {
            this.AddPreconDeck(heroFromAssetID.CardClass, preconDeckNotice.DeckID);
            NetCache.NetCacheDecks netObject = NetCache.Get().GetNetObject<NetCache.NetCacheDecks>();
            NetCache.DeckHeader header2 = new NetCache.DeckHeader {
                ID = preconDeckNotice.DeckID,
                Name = "precon",
                Hero = heroFromAssetID.CardID,
                HeroPower = heroFromAssetID.GetHeroPowerID(),
                IsTourneyValid = true,
                Type = NetCache.DeckHeader.DeckType.PRECON_DECK
            };
            NetCache.DeckHeader item = header2;
            netObject.Decks.Add(item);
        }
    }

    public bool AllCardsInSetOwned(TAG_CARD_SET? cardSet, TAG_CLASS? cardClass, TAG_RARITY? cardRarity, TAG_RACE? cardRace, CardFlair flair, bool allCopiesRequired)
    {
        foreach (string str in this.GetCardIDsInSet(cardSet, cardClass, cardRarity, cardRace))
        {
            int num = 1;
            if (allCopiesRequired)
            {
                num = !DefLoader.Get().GetEntityDef(str).IsElite() ? 2 : 1;
            }
            CollectionCardStack collectionStack = this.GetCollectionStack(str);
            int num2 = (flair != null) ? collectionStack.GetArtStack(flair).Count : collectionStack.GetTotalCount();
            if (num2 < num)
            {
                return false;
            }
        }
        return true;
    }

    public string AutoGenerateDeckName(TAG_CLASS classTag)
    {
        string str2;
        string className = GameStrings.GetClassName(classTag);
        int num = 1;
        do
        {
            str2 = string.Format("{0} {1}", className, num++);
        }
        while (this.IsDeckNameTaken(str2));
        return str2;
    }

    public bool CanDisplayCards()
    {
        return this.m_cardStacksRegistered;
    }

    public void EnableWaitingToShowPackOpening(bool enable)
    {
        this.m_waitingToShowPackOpening = enable;
    }

    private void FinishLoading()
    {
        if ((!this.m_cardStacksRegistered && this.m_netCacheReady) && this.m_entityDefsLoaded)
        {
            Log.Rachelle.Print("CollectionManager.FinishLoading");
            AchieveManager.Init();
            this.RegisterCardStacks();
            foreach (NetCache.DeckHeader header in NetCache.Get().GetNetObject<NetCache.NetCacheDecks>().Decks)
            {
                EntityDef def;
                NetCache.DeckHeader.DeckType type = header.Type;
                if (type != NetCache.DeckHeader.DeckType.NORMAL_DECK)
                {
                    if (type == NetCache.DeckHeader.DeckType.PRECON_DECK)
                    {
                        goto Label_008D;
                    }
                    goto Label_00B5;
                }
                this.AddDeck(header, false);
                continue;
            Label_008D:
                def = DefLoader.Get().GetEntityDef(header.Hero);
                this.AddPreconDeck(def.GetClass(), header.ID);
                continue;
            Label_00B5:
                Debug.LogWarning(string.Format("CollectionManager.OnNetCacheReady(): don't know how to handle deck type {0}", header.Type));
            }
            this.UpdateShowAdvancedCMOption();
            foreach (DelOnCollectionLoaded loaded in this.m_collectionLoadedListeners)
            {
                loaded();
            }
            NetCache.Get().RegisterNewNoticesListener(new NetCache.DelNewNoticesListener(s_instance.OnNewNotices));
        }
    }

    private void FireAllDeckContentsEvent()
    {
        foreach (DelOnAllDeckContents contents in this.m_allDeckContentsListeners)
        {
            contents();
        }
        this.m_allDeckContentsListeners.Clear();
    }

    private void FireDeckContentsEvent(long id)
    {
        foreach (DelOnDeckContents contents in this.m_deckContentsListeners)
        {
            contents(id);
        }
    }

    public static CollectionManager Get()
    {
        if (s_instance == null)
        {
            Debug.LogError("Trying to retrieve the collection manager without calling CollectionManager.Init()!");
        }
        return s_instance;
    }

    public CollectionDeck GetBaseDeck(long id)
    {
        CollectionDeck deck;
        if (this.m_baseDecks.TryGetValue(id, out deck))
        {
            return deck;
        }
        return null;
    }

    private List<string> GetCardIDsInSet(TAG_CARD_SET? cardSet, TAG_CLASS? cardClass, TAG_RARITY? cardRarity, TAG_RACE? cardRace)
    {
        List<CardManifest.Card> list = CardManifest.Get().CollectibleCards();
        List<string> list2 = new List<string>();
        foreach (CardManifest.Card card in list)
        {
            string cardID = card.CardID;
            EntityDef entityDef = DefLoader.Get().GetEntityDef(cardID);
            if (((!cardClass.HasValue || (((TAG_CLASS) cardClass.Value) == entityDef.GetClass())) && (!cardRarity.HasValue || (((TAG_RARITY) cardRarity.Value) == entityDef.GetRarity()))) && ((!cardSet.HasValue || (((TAG_CARD_SET) cardSet.Value) == entityDef.GetCardSet())) && (!cardRace.HasValue || (((TAG_RACE) cardRace.Value) == entityDef.GetRace()))))
            {
                list2.Add(cardID);
            }
        }
        return list2;
    }

    public Dictionary<string, CollectionCardStack> GetCollectibleStacks()
    {
        return this.m_collectibleStacks;
    }

    private CollectionCardStack.ArtStack GetCollectionArtStack(int assetID, CardFlair cardFlair)
    {
        CardManifest.Card card = CardManifest.Get().Find(assetID);
        if (card == null)
        {
            Debug.LogError(string.Format("CollectionManager.GetCollectionArtStack(); Could not find assetID {0} in manifest cards.", assetID));
            return null;
        }
        string cardID = card.CardID;
        return this.GetCollectionArtStack(cardID, cardFlair);
    }

    public CollectionCardStack.ArtStack GetCollectionArtStack(string cardID, CardFlair cardFlair)
    {
        CollectionCardStack collectionStack = this.GetCollectionStack(cardID);
        if (collectionStack == null)
        {
            Debug.LogError(string.Format("CollectionManager.GetCollectionArtStack() - could not find collection stack for card {0}", cardID));
            return null;
        }
        return collectionStack.GetArtStack(cardFlair);
    }

    private CollectionCardStack GetCollectionStack(string cardID)
    {
        CollectionCardStack stack;
        if (this.m_collectibleStacks.TryGetValue(cardID, out stack))
        {
            return stack;
        }
        return null;
    }

    public CollectionDeck GetDeck(long id)
    {
        CollectionDeck deck;
        if (this.m_decks.TryGetValue(id, out deck))
        {
            return deck;
        }
        return null;
    }

    public Dictionary<long, CollectionDeck> GetDecks()
    {
        return this.m_decks;
    }

    public List<CollectionCardStack.ArtStack> GetMassDisenchantArtStacks()
    {
        List<CollectionCardStack.ArtStack> list = new List<CollectionCardStack.ArtStack>();
        foreach (CollectionCardStack stack in this.GetOwnedCardStacks())
        {
            int num = !DefLoader.Get().GetEntityDef(stack.CardID).IsElite() ? 2 : 1;
            foreach (CollectionCardStack.ArtStack stack2 in stack.GetArtStacks().Values)
            {
                int count = stack2.Count - num;
                if (count > 0)
                {
                    list.Add(new CollectionCardStack.ArtStack(stack2.CardID, stack2.Flair, stack2.NewestInsertDate, count, 0));
                }
            }
        }
        return list;
    }

    public int GetMaxNumCustomDecks()
    {
        return NetCache.Get().GetNetObject<NetCache.NetCacheDeckLimit>().DeckLimit;
    }

    public int GetNumAvailableCards(TAG_CARD_SET? cardSet, TAG_CLASS? cardClass, TAG_RARITY? cardRarity, TAG_RACE? cardRace)
    {
        CollectionFilterSet set = new CollectionFilterSet(true);
        if (cardSet.HasValue)
        {
            set.AddGameFilter(GAME_TAG.CARD_SET, cardSet.Value, CollectionFilterFunc.EQUAL);
        }
        if (cardClass.HasValue)
        {
            set.AddGameFilter(GAME_TAG.CLASS, cardClass.Value, CollectionFilterFunc.EQUAL);
        }
        if (cardRarity.HasValue)
        {
            set.AddGameFilter(GAME_TAG.RARITY, cardRarity.Value, CollectionFilterFunc.EQUAL);
        }
        if (cardRace.HasValue)
        {
            set.AddGameFilter(GAME_TAG.CARDRACE, cardRace.Value, CollectionFilterFunc.EQUAL);
        }
        int num = 0;
        List<FilteredArtStack> list = set.GenerateList();
        List<string> list2 = new List<string>();
        foreach (FilteredArtStack stack in list)
        {
            string cardID = stack.CardID;
            if (!list2.Contains(cardID))
            {
                int num2 = !DefLoader.Get().GetEntityDef(cardID).IsElite() ? 2 : 1;
                num += num2;
                list2.Add(cardID);
            }
        }
        return num;
    }

    public int GetNumCardsIOwn(TAG_CARD_SET? cardSet, TAG_CLASS? cardClass, TAG_RARITY? cardRarity, TAG_RACE? cardRace, CardFlair flair)
    {
        CollectionFilterSet set = new CollectionFilterSet(true);
        set.AddAccountFilter(ACCOUNT_TAG.OWNED_COUNT, 1, CollectionFilterFunc.GREATER_EQUAL);
        if (cardSet.HasValue)
        {
            set.AddGameFilter(GAME_TAG.CARD_SET, cardSet.Value, CollectionFilterFunc.EQUAL);
        }
        if (cardClass.HasValue)
        {
            set.AddGameFilter(GAME_TAG.CLASS, cardClass.Value, CollectionFilterFunc.EQUAL);
        }
        if (cardRarity.HasValue)
        {
            set.AddGameFilter(GAME_TAG.RARITY, cardRarity.Value, CollectionFilterFunc.EQUAL);
        }
        if (cardRace.HasValue)
        {
            set.AddGameFilter(GAME_TAG.CARDRACE, cardRace.Value, CollectionFilterFunc.EQUAL);
        }
        List<FilteredArtStack> list = set.GenerateList();
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        foreach (FilteredArtStack stack in list)
        {
            if ((flair != null) && !stack.Flair.Equals(flair))
            {
                continue;
            }
            string cardID = stack.CardID;
            EntityDef entityDef = DefLoader.Get().GetEntityDef(cardID);
            if (dictionary.ContainsKey(cardID))
            {
                Dictionary<string, int> dictionary2;
                string str2;
                int num4 = dictionary2[str2];
                (dictionary2 = dictionary)[str2 = cardID] = num4 + stack.Count;
            }
            else
            {
                dictionary[cardID] = stack.Count;
            }
            int b = !entityDef.IsElite() ? 2 : 1;
            dictionary[cardID] = Mathf.Min(dictionary[cardID], b);
        }
        int num2 = 0;
        foreach (int num3 in dictionary.Values)
        {
            num2 += num3;
        }
        return num2;
    }

    public int GetNumCopiesInCollection(string cardID, CardFlair.PremiumType premium)
    {
        return this.GetCollectionArtStack(cardID, new CardFlair(premium)).Count;
    }

    public List<CollectionCardStack> GetOwnedCardStacks()
    {
        List<CollectionCardStack> list = new List<CollectionCardStack>();
        foreach (CollectionCardStack stack in this.m_collectibleStacks.Values)
        {
            if (stack.GetTotalCount() != 0)
            {
                list.Add(stack);
            }
        }
        return list;
    }

    public long GetPreconDeckID(TAG_CLASS heroClass)
    {
        if (!this.m_preconDecks.ContainsKey(heroClass))
        {
            return 0L;
        }
        return this.m_preconDecks[heroClass];
    }

    private bool HasUnlockedAllHeores()
    {
        return (AchieveManager.Get().GetNumAchievesInGroup(Achievement.Group.UNLOCK_HERO) == this.m_preconDecks.Count);
    }

    public bool HasVisitedCollection()
    {
        return this.m_hasVisitedCollection;
    }

    public static void Init()
    {
        if (s_instance != null)
        {
            Debug.LogError("CollectionManager.Init() has already been called!");
        }
        else
        {
            s_instance = new CollectionManager();
            NetCache.Get().RegisterCollectionManager(new NetCache.NetCacheCallback(s_instance.OnNetCacheReady), new NetCache.ErrorCallback(NetCache.DefaultErrorHandler));
        }
    }

    private void InsertNewCollectionCard(string cardID, CardFlair cardFlair, DateTime insertDate, int count, bool seenBefore)
    {
        EntityDef entityDef = DefLoader.Get().GetEntityDef(cardID);
        if (!entityDef.IsHero())
        {
            CollectionCardStack collectionStack = this.GetCollectionStack(cardID);
            collectionStack.AddCards(cardFlair, insertDate, count, !seenBefore ? 0 : count);
            NetCache.CardDefinition cardDef = new NetCache.CardDefinition {
                Name = cardID,
                Premium = cardFlair.Premium
            };
            this.NotifyNetCacheOfNewCards(cardDef, insertDate.Ticks, count, seenBefore);
            AchieveManager.Get().NotifyOfCardGained(entityDef, cardFlair, collectionStack.GetArtStack(cardFlair).Count);
            this.UpdateShowAdvancedCMOption();
        }
    }

    public bool IsCardInCollection(string cardID, CardFlair cardFlair)
    {
        CollectionCardStack.ArtStack collectionArtStack = this.GetCollectionArtStack(cardID, cardFlair);
        if (collectionArtStack == null)
        {
            Debug.LogError(string.Format("CollectionManager.IsCardInCollection() - could not find collection stack for card {0}", cardID));
            return false;
        }
        return (collectionArtStack.Count > 0);
    }

    private bool IsDeckNameTaken(string name)
    {
        foreach (CollectionDeck deck in this.GetDecks().Values)
        {
            if (deck.Name.Trim().Equals(name, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public bool IsLoadingEntityDefs()
    {
        if (this.m_entityDefsLoaded)
        {
            return false;
        }
        if (this.m_currentEntityDefLoadIndex < 0)
        {
            return false;
        }
        return true;
    }

    public bool IsWaitingForBoxTransition()
    {
        return this.m_waitingForBoxTransition;
    }

    public bool IsWaitingToShowPackOpening()
    {
        return this.m_waitingToShowPackOpening;
    }

    public void LoadAllDeckContents(DelOnAllDeckContents callback)
    {
        bool flag = false;
        foreach (CollectionDeck deck in this.GetDecks().Values)
        {
            if (!deck.NetworkContentsLoaded())
            {
                if (!flag && !this.m_allDeckContentsListeners.Contains(callback))
                {
                    this.m_allDeckContentsListeners.Add(callback);
                }
                this.RequestDeckContents(deck.ID);
                flag = true;
            }
        }
        if (!flag)
        {
            callback();
        }
    }

    public void LoadAllEntityDefs()
    {
        if (!this.m_entityDefsLoaded && !this.IsLoadingEntityDefs())
        {
            this.LoadEntityDefs(0, 60);
        }
    }

    private void LoadEntityDefs(int startIndex, int count)
    {
        List<CardManifest.Card> list = CardManifest.Get().AllCollectibles();
        this.m_currentEntityDefLoadIndex = startIndex;
        this.m_maxEntityDefLoadIndex = Math.Min(this.m_currentEntityDefLoadIndex + count, list.Count);
        for (int i = this.m_currentEntityDefLoadIndex; i < this.m_maxEntityDefLoadIndex; i++)
        {
            CardManifest.Card card = list[i];
            DefLoader.Get().LoadEntityDef(card.CardID, new DefLoader.LoadDefCallback<EntityDef>(this.OnEntityDefLoaded));
        }
    }

    public void MarkAllInstancesAsSeen(string cardID, CardFlair cardFlair)
    {
        <MarkAllInstancesAsSeen>c__AnonStorey12C storeyc = new <MarkAllInstancesAsSeen>c__AnonStorey12C();
        NetCache.NetCacheCollection netObject = NetCache.Get().GetNetObject<NetCache.NetCacheCollection>();
        CardManifest.Card card = CardManifest.Get().Find(cardID);
        storeyc.artStack = this.GetCollectionArtStack(cardID, cardFlair);
        if (storeyc.artStack.NumSeen != storeyc.artStack.Count)
        {
            Network.AckCardSeenBefore(card.DatabaseAssetID, cardFlair);
            storeyc.artStack.MarkStackAsSeen();
            NetCache.CardStack stack = netObject.Stacks.Find(new Predicate<NetCache.CardStack>(storeyc.<>m__1B));
            if (stack != null)
            {
                stack.NumSeen = stack.Count;
            }
            foreach (DelOnNewCardSeen seen in this.m_newCardSeenListeners)
            {
                seen(cardID, cardFlair);
            }
        }
    }

    private void NotifyNetCacheOfNewCards(NetCache.CardDefinition cardDef, long insertDate, int count, bool seenBefore)
    {
        <NotifyNetCacheOfNewCards>c__AnonStorey130 storey = new <NotifyNetCacheOfNewCards>c__AnonStorey130 {
            cardDef = cardDef
        };
        NetCache.NetCacheCollection netObject = NetCache.Get().GetNetObject<NetCache.NetCacheCollection>();
        NetCache.CardStack item = netObject.Stacks.Find(new Predicate<NetCache.CardStack>(storey.<>m__20));
        if (item == null)
        {
            NetCache.CardStack stack2 = new NetCache.CardStack {
                Def = storey.cardDef,
                Date = insertDate,
                Count = count,
                NumSeen = !seenBefore ? 0 : count
            };
            item = stack2;
            netObject.Stacks.Add(item);
        }
        else
        {
            if (insertDate > item.Date)
            {
                item.Date = insertDate;
            }
            item.Count += count;
            if (seenBefore)
            {
                item.NumSeen += count;
            }
        }
    }

    private void NotifyNetCacheOfRemovedCards(NetCache.CardDefinition cardDef, int count)
    {
        <NotifyNetCacheOfRemovedCards>c__AnonStorey12F storeyf = new <NotifyNetCacheOfRemovedCards>c__AnonStorey12F {
            cardDef = cardDef
        };
        NetCache.NetCacheCollection netObject = NetCache.Get().GetNetObject<NetCache.NetCacheCollection>();
        NetCache.CardStack item = netObject.Stacks.Find(new Predicate<NetCache.CardStack>(storeyf.<>m__1F));
        if (item == null)
        {
            Debug.LogError("CollectionManager.NotifyNetCacheOfRemovedCards() - trying to remove a card from an empty stack!");
        }
        else
        {
            item.Count -= count;
            if (item.Count <= 0)
            {
                netObject.Stacks.Remove(item);
            }
        }
    }

    public void NotifyOfBoxTransitionStart()
    {
        Box.Get().AddTransitionFinishedListener(new Box.TransitionFinishedCallback(this.OnBoxTransitionFinished));
        this.m_waitingForBoxTransition = true;
    }

    private int NumCardsOwnedInSet(TAG_CARD_SET cardSet)
    {
        <NumCardsOwnedInSet>c__AnonStorey12D storeyd = new <NumCardsOwnedInSet>c__AnonStorey12D {
            cardSet = cardSet
        };
        List<CollectionCardStack> list2 = this.GetOwnedCardStacks().FindAll(new Predicate<CollectionCardStack>(storeyd.<>m__1C));
        int num = 0;
        foreach (CollectionCardStack stack in list2)
        {
            num += stack.GetTotalCount();
        }
        return num;
    }

    private void OnActiveAchievesUpdated()
    {
        List<Achievement> newCompletedAchieves = AchieveManager.Get().GetNewCompletedAchieves();
        foreach (DelOnAchievesCompleted completed in this.m_achievesCompletedListeners)
        {
            completed(newCompletedAchieves);
        }
    }

    public void OnBoosterOpened(List<NetCache.BoosterCard> cards)
    {
        if (!Options.Get().GetBool(Option.FAKE_PACK_OPENING))
        {
            foreach (NetCache.BoosterCard card in cards)
            {
                this.InsertNewCollectionCard(card.Def.Name, new CardFlair(card.Def.Premium), new DateTime(card.Date), 1, false);
            }
            AchieveManager.Get().ValidateAchievesNow(new AchieveManager.DelOnActiveAchievesUpdated(this.OnActiveAchievesUpdated));
            this.OnCollectionChanged();
        }
    }

    public void OnBoxTransitionFinished(object userData)
    {
        Box.Get().RemoveTransitionFinishedListener(new Box.TransitionFinishedCallback(this.OnBoxTransitionFinished));
        this.m_waitingForBoxTransition = false;
    }

    private void OnCardSale()
    {
        Network.CardSaleResult cardSaleResult = Network.GetCardSaleResult();
        switch (cardSaleResult.Action)
        {
            case Network.CardSaleResult.SaleResult.CARD_WAS_SOLD:
                this.RemoveCollectionCard(cardSaleResult.AssetName, new CardFlair(cardSaleResult.Premium), 1);
                CraftingManager.Get().OnCardDisenchanted(cardSaleResult);
                AchieveManager.Get().UpdateActiveAchieves(new AchieveManager.DelOnActiveAchievesUpdated(this.OnActiveAchievesUpdated));
                NetCache.Get().ReloadNetObject<NetCache.NetCacheProfileNotices>();
                break;

            case Network.CardSaleResult.SaleResult.CARD_WAS_BOUGHT:
                this.InsertNewCollectionCard(cardSaleResult.AssetName, new CardFlair(cardSaleResult.Premium), DateTime.Now, 1, true);
                CraftingManager.Get().OnCardCreated(cardSaleResult);
                AchieveManager.Get().ValidateAchievesNow(new AchieveManager.DelOnActiveAchievesUpdated(this.OnActiveAchievesUpdated));
                break;
        }
        this.OnCollectionChanged();
    }

    private void OnCollectionChanged()
    {
        foreach (DelOnCollectionChanged changed in this.m_collectionChangedListeners)
        {
            changed();
        }
    }

    private void OnDBAction()
    {
        bool flag;
        <OnDBAction>c__AnonStorey12B storeyb = new <OnDBAction>c__AnonStorey12B();
        Network.DBAction deckResponse = Network.GetDeckResponse();
        Log.Rachelle.Print(string.Format("MetaData:{0} DBAction:{1} Result:{2}", deckResponse.MetaData, deckResponse.Action, deckResponse.Result));
        switch (deckResponse.Action)
        {
            case Network.DBAction.ActionType.CREATE_DECK:
                flag = false;
                if ((deckResponse.Result != Network.DBAction.ResultType.SUCCESS) && (CollectionDeckTray.Get() != null))
                {
                    CollectionDeckTray.Get().OnCreateDeckFailed();
                }
                break;

            case Network.DBAction.ActionType.RENAME_DECK:
            case Network.DBAction.ActionType.SET_DECK:
                flag = true;
                break;

            default:
                flag = false;
                break;
        }
        if (flag)
        {
            storeyb.deckID = deckResponse.MetaData;
            CollectionDeck deck = this.GetDeck(storeyb.deckID);
            CollectionDeck baseDeck = this.GetBaseDeck(storeyb.deckID);
            if (deckResponse.Result == Network.DBAction.ResultType.SUCCESS)
            {
                List<CollectionDeckViolation> deckViolations = CollectionDeckValidator.GetDeckViolations(deck);
                deck.IsTourneyValid = deckViolations.Count == 0;
                Log.Rachelle.Print(string.Format("CollectionManager.OnDBAction(): overwriting baseDeck with {0} updated deck ({1}:{2})", !deck.IsTourneyValid ? "INVALID" : "valid", deck.ID, deck.Name));
                baseDeck.CopyFrom(deck);
                NetCache.DeckHeader header = NetCache.Get().GetNetObject<NetCache.NetCacheDecks>().Decks.Find(new Predicate<NetCache.DeckHeader>(storeyb.<>m__1A));
                if (header != null)
                {
                    header.IsTourneyValid = deck.IsTourneyValid;
                }
            }
            else
            {
                Log.Rachelle.Print(string.Format("CollectionManager.OnDBAction(): overwriting deck that failed to update with base deck ({0}:{1})", baseDeck.ID, baseDeck.Name));
                deck.CopyFrom(baseDeck);
            }
        }
    }

    private void OnDeck()
    {
        <OnDeck>c__AnonStorey12A storeya = new <OnDeck>c__AnonStorey12A();
        Network.DeckContents deckContents = Network.GetDeckContents();
        CollectionDeck deck = this.GetDeck(deckContents.Deck);
        CollectionDeck baseDeck = this.GetBaseDeck(deckContents.Deck);
        deck.ClearSlotContents();
        baseDeck.ClearSlotContents();
        storeya.prevHandle = 0;
        while (deckContents.Cards.Count > 0)
        {
            Network.CardUserData item = deckContents.Cards.Find(new Predicate<Network.CardUserData>(storeya.<>m__19));
            if (item == null)
            {
                Debug.LogError(string.Format("CollecitonManager.OnDeck(): Cannot process deck! No card in deck {0} has a previous card handle with value {1}!", deckContents.Deck, storeya.prevHandle));
                break;
            }
            deckContents.Cards.Remove(item);
            storeya.prevHandle = item.Handle;
            CardFlair cardFlair = new CardFlair(item.Premium);
            CollectionCardStack.ArtStack collectionArtStack = this.GetCollectionArtStack(item.AssetID, cardFlair);
            if ((collectionArtStack == null) || (collectionArtStack.Count < item.Count))
            {
                object[] args = new object[] { deck.ID, item.Count, collectionArtStack.CardID, collectionArtStack.Flair, collectionArtStack.Count };
                Debug.LogWarning(string.Format("CollectionManager.OnDeck(): Deck {0} requires {1} instances of card {2} with flair {3}, but you only own {4} copies of that card.", args));
            }
            CardManifest.Card card = CardManifest.Get().Find(item.AssetID);
            if (card == null)
            {
                Debug.LogError(string.Format("CollectionManager.OnDeck(): Could not find card with asset ID {0} in our card manifest", item.AssetID));
            }
            else
            {
                CollectionDeckSlot slot3 = new CollectionDeckSlot {
                    Handle = item.Handle,
                    CardID = card.CardID,
                    Count = item.Count,
                    Premium = item.Premium,
                    PrevSlotHandle = item.Prev
                };
                CollectionDeckSlot otherSlot = slot3;
                CollectionDeckSlot slot = new CollectionDeckSlot();
                slot.CopyFrom(otherSlot);
                deck.InsertSlotByDefaultSort(otherSlot);
                baseDeck.InsertSlotByPrevHandle(slot);
            }
        }
        deck.MarkNetworkContentsLoaded();
        this.FireDeckContentsEvent(deckContents.Deck);
        foreach (CollectionDeck deck3 in this.GetDecks().Values)
        {
            if (!deck3.NetworkContentsLoaded())
            {
                return;
            }
        }
        this.FireAllDeckContentsEvent();
    }

    private void OnDeckCreated()
    {
        NetCache.DeckHeader createdDeck = Network.GetCreatedDeck();
        Log.Rachelle.Print(string.Format("DeckCreated:{0} ID:{1} Hero:{2}", createdDeck.Name, createdDeck.ID, createdDeck.Hero));
        this.AddDeck(createdDeck).MarkNetworkContentsLoaded();
        foreach (DelOnDeckCreated created in this.m_deckCreatedListeners)
        {
            created(createdDeck.ID);
        }
    }

    private void OnDeckDeleted()
    {
        Log.Rachelle.Print("CollectionManager.OnDeckDeleted");
        long deletedDeckID = Network.GetDeletedDeckID();
        Log.Rachelle.Print(string.Format("DeckDeleted:{0}", deletedDeckID));
        this.RemoveDeck(deletedDeckID);
        if (CollectionDeckTray.Get() != null)
        {
            CollectionDeckTray.Get().OnDeckDeleted(deletedDeckID);
        }
    }

    private void OnDeckRenamed()
    {
        Network.DeckName renamedDeck = Network.GetRenamedDeck();
        Log.Rachelle.Print(string.Format("DECK:{0} Name:{1}", renamedDeck.Deck, renamedDeck.Name));
        this.RenameDeck(renamedDeck.Deck, renamedDeck.Name);
        if (CollectionDeckTray.Get() != null)
        {
            CollectionDeckTray.Get().OnDeckRenamed(renamedDeck.Deck, renamedDeck.Name);
        }
    }

    public void OnDraftDeckRetired(CollectionDeck draftDeck)
    {
        if (draftDeck == null)
        {
            Debug.LogError("CollectionManager.OnDraftDeckRetired() - draftDeck is null");
        }
        else
        {
            DateTime now = DateTime.Now;
            foreach (CollectionDeckSlot slot in draftDeck.GetSlots())
            {
                if (DefLoader.Get().GetEntityDef(slot.CardID).GetCardSet() != TAG_CARD_SET.CORE)
                {
                    this.InsertNewCollectionCard(slot.CardID, new CardFlair(CardFlair.PremiumType.STANDARD), now, slot.Count, false);
                }
            }
            this.OnCollectionChanged();
        }
    }

    private void OnEntityDefLoaded(string cardID, EntityDef entityDef, object callbackData)
    {
        if (entityDef == null)
        {
            Debug.LogError(string.Format("CollectionManager.OnEntityDefLoaded() - {0} failed to load", cardID));
        }
        else if (entityDef.GetCardType() != TAG_CARDTYPE.HERO)
        {
            this.RegisterEmptyCardStack(cardID);
        }
        this.m_currentEntityDefLoadIndex++;
        if (this.m_currentEntityDefLoadIndex == this.m_maxEntityDefLoadIndex)
        {
            List<CardManifest.Card> list = CardManifest.Get().AllCollectibles();
            this.m_entityDefsLoaded = this.m_currentEntityDefLoadIndex == list.Count;
            if (!this.m_entityDefsLoaded)
            {
                this.LoadEntityDefs(this.m_currentEntityDefLoadIndex, 60);
            }
            else
            {
                this.FinishLoading();
            }
        }
    }

    public void OnHeroUnlocked(TAG_CLASS heroClass)
    {
        foreach (string str in this.GetCardIDsInSet(2, new TAG_CLASS?(heroClass), 2, null))
        {
            int count = !DefLoader.Get().GetEntityDef(str).IsElite() ? 2 : 1;
            this.InsertNewCollectionCard(str, new CardFlair(CardFlair.PremiumType.STANDARD), DateTime.Now, count, true);
        }
        if (heroClass == TAG_CLASS.MAGE)
        {
            foreach (string str2 in this.GetCardIDsInSet(2, 0, 1, null))
            {
                int num2 = !DefLoader.Get().GetEntityDef(str2).IsElite() ? 2 : 1;
                this.InsertNewCollectionCard(str2, new CardFlair(CardFlair.PremiumType.STANDARD), DateTime.Now, num2, true);
            }
            foreach (string str3 in this.GetCardIDsInSet(2, 0, 2, null))
            {
                int num3 = !DefLoader.Get().GetEntityDef(str3).IsElite() ? 2 : 1;
                this.InsertNewCollectionCard(str3, new CardFlair(CardFlair.PremiumType.STANDARD), DateTime.Now, num3, true);
            }
        }
        this.OnCollectionChanged();
    }

    private void OnMassDisenchantResponse()
    {
        Network.MassDisenchantResponse massDisenchantResponse = Network.GetMassDisenchantResponse();
        if (massDisenchantResponse.Amount == 0)
        {
            Debug.LogError("CollectionManager.OnMassDisenchantResponse(): Amount is 0. This means the backend failed to mass disenchant correctly.");
        }
        else
        {
            NetCache.Get().OnArcaneDustBalanceChanged((long) massDisenchantResponse.Amount);
            if (CraftingManager.Get() != null)
            {
                CraftingManager.Get().OnMassDisenchant(massDisenchantResponse.Amount);
            }
            foreach (CollectionCardStack.ArtStack stack in this.GetMassDisenchantArtStacks())
            {
                this.RemoveCollectionCard(stack.CardID, stack.Flair, stack.Count);
                this.MarkAllInstancesAsSeen(stack.CardID, stack.Flair);
            }
            this.OnCollectionChanged();
        }
    }

    private void OnNetCacheReady()
    {
        this.m_netCacheReady = true;
        this.FinishLoading();
    }

    private void OnNewNotices(List<NetCache.ProfileNotice> newNotices)
    {
        if (<>f__am$cache16 == null)
        {
            <>f__am$cache16 = obj => obj.Type == NetCache.ProfileNotice.NoticeType.PRECON_DECK;
        }
        foreach (NetCache.ProfileNotice notice in newNotices.FindAll(<>f__am$cache16))
        {
            NetCache.ProfileNoticePreconDeck preconDeckNotice = notice as NetCache.ProfileNoticePreconDeck;
            this.AddPreconDeckFromNotice(preconDeckNotice);
        }
        foreach (RewardData data in RewardUtils.GetRewards(newNotices))
        {
            if (data.RewardType == Reward.Type.CARD)
            {
                CardRewardData cardReward = data as CardRewardData;
                this.AddCardFromRewardNotice(cardReward);
                continue;
            }
        }
    }

    public void RegisterAchievesCompletedListener(DelOnAchievesCompleted listener)
    {
        if (!this.m_achievesCompletedListeners.Contains(listener))
        {
            this.m_achievesCompletedListeners.Add(listener);
        }
    }

    public void RegisterCardRewardInsertedListener(DelOnCardRewardInserted listener)
    {
        if (!this.m_cardRewardListeners.Contains(listener))
        {
            this.m_cardRewardListeners.Add(listener);
        }
    }

    private bool RegisterCardStack(NetCache.CardStack netStack)
    {
        CollectionCardStack stack = this.RegisterEmptyCardStack(netStack.Def.Name);
        CardFlair cardFlair = new CardFlair(netStack.Def.Premium);
        if (stack.ContainsArtStack(cardFlair))
        {
            Debug.LogWarning(string.Format("CollectionManager.RegisterCardStack(): Already have a registered art stack for {0} {1}", netStack.Def.Name, netStack.Def.Premium));
            return false;
        }
        if (DefLoader.Get().GetEntityDef(netStack.Def.Name) == null)
        {
            Debug.LogError(string.Format("CollectionManager.RegisterCardStack(): DefLoader failed to get entity def for {0}", netStack.Def.Name));
            return false;
        }
        stack.AddCards(cardFlair, new DateTime(netStack.Date), netStack.Count, netStack.NumSeen);
        return true;
    }

    private void RegisterCardStacks()
    {
        if (!this.m_cardStacksRegistered)
        {
            NetCache.NetCacheCollection netObject = NetCache.Get().GetNetObject<NetCache.NetCacheCollection>();
            CardManifest manifest = CardManifest.Get();
            foreach (NetCache.CardStack stack in netObject.Stacks)
            {
                CardManifest.Card card = manifest.Find(stack.Def.Name);
                if (((card != null) && (card.CardType != TAG_CARDTYPE.HERO)) && card.Collectible)
                {
                    this.RegisterCardStack(stack);
                }
            }
            this.m_cardStacksRegistered = true;
        }
    }

    public void RegisterCollectionChangedListener(DelOnCollectionChanged listener)
    {
        if (!this.m_collectionChangedListeners.Contains(listener))
        {
            this.m_collectionChangedListeners.Add(listener);
        }
    }

    public void RegisterCollectionLoadedListener(DelOnCollectionLoaded listener)
    {
        if (!this.m_collectionLoadedListeners.Contains(listener))
        {
            this.m_collectionLoadedListeners.Add(listener);
        }
    }

    public void RegisterCollectionNetHandlers()
    {
        Network network = Network.Get();
        network.RegisterNetHandler(Network.PacketID.DECK_ACTION, new Network.NetHandler(this.OnDBAction));
        network.RegisterNetHandler(Network.PacketID.DECK_CREATED, new Network.NetHandler(this.OnDeckCreated));
        network.RegisterNetHandler(Network.PacketID.DECK_DELETED, new Network.NetHandler(this.OnDeckDeleted));
        network.RegisterNetHandler(Network.PacketID.DECK_RENAMED, new Network.NetHandler(this.OnDeckRenamed));
        network.RegisterNetHandler(Network.PacketID.DECK_CONTENTS, new Network.NetHandler(this.OnDeck));
        network.RegisterNetHandler(Network.PacketID.CARD_SALE, new Network.NetHandler(this.OnCardSale));
        network.RegisterNetHandler(Network.PacketID.MASS_DISENCHANT_RESPONSE, new Network.NetHandler(this.OnMassDisenchantResponse));
    }

    public void RegisterDeckContentsListener(DelOnDeckContents listener)
    {
        if (!this.m_deckContentsListeners.Contains(listener))
        {
            this.m_deckContentsListeners.Add(listener);
        }
    }

    public void RegisterDeckCreatedListener(DelOnDeckCreated listener)
    {
        if (!this.m_deckCreatedListeners.Contains(listener))
        {
            this.m_deckCreatedListeners.Add(listener);
        }
    }

    private CollectionCardStack RegisterEmptyCardStack(string cardID)
    {
        CollectionCardStack collectionStack = this.GetCollectionStack(cardID);
        if (collectionStack == null)
        {
            collectionStack = new CollectionCardStack(cardID);
            this.m_collectibleStacks.Add(collectionStack.CardID, collectionStack);
        }
        return collectionStack;
    }

    public void RegisterNewCardSeenListener(DelOnNewCardSeen listener)
    {
        if (!this.m_newCardSeenListeners.Contains(listener))
        {
            this.m_newCardSeenListeners.Add(listener);
        }
    }

    public bool RemoveAchievesCompletedListener(DelOnAchievesCompleted listener)
    {
        return this.m_achievesCompletedListeners.Remove(listener);
    }

    public bool RemoveCardRewardInsertedListener(DelOnCardRewardInserted listener)
    {
        return this.m_cardRewardListeners.Remove(listener);
    }

    private void RemoveCollectionCard(string cardID, CardFlair cardFlair, int count)
    {
        CollectionCardStack collectionStack = this.GetCollectionStack(cardID);
        collectionStack.RemoveCards(cardFlair, count);
        int num = collectionStack.GetArtStack(cardFlair).Count;
        foreach (CollectionDeck deck in this.GetDecks().Values)
        {
            int cardCount = deck.GetCardCount(cardID, cardFlair);
            if (cardCount > num)
            {
                int num3 = cardCount - num;
                for (int i = 0; i < num3; i++)
                {
                    deck.RemoveCard(cardID, cardFlair.Premium);
                }
                if (!CollectionDeckTray.Get().HandleDeletedCardDeckUpdate(cardID, cardFlair))
                {
                    deck.SendChanges();
                }
            }
        }
        NetCache.CardDefinition cardDef = new NetCache.CardDefinition {
            Name = cardID,
            Premium = cardFlair.Premium
        };
        this.NotifyNetCacheOfRemovedCards(cardDef, count);
    }

    public bool RemoveCollectionChangedListener(DelOnCollectionChanged listener)
    {
        return this.m_collectionChangedListeners.Remove(listener);
    }

    public bool RemoveCollectionLoadedListener(DelOnCollectionLoaded listener)
    {
        return this.m_collectionLoadedListeners.Remove(listener);
    }

    public void RemoveCollectionNetHandlers()
    {
        Network network = Network.Get();
        network.RemoveNetHandler(Network.PacketID.DECK_ACTION);
        network.RemoveNetHandler(Network.PacketID.DECK_CREATED);
        network.RemoveNetHandler(Network.PacketID.DECK_DELETED);
        network.RemoveNetHandler(Network.PacketID.DECK_RENAMED);
        network.RemoveNetHandler(Network.PacketID.DECK_CONTENTS);
        network.RemoveNetHandler(Network.PacketID.CARD_SALE);
        network.RemoveNetHandler(Network.PacketID.MASS_DISENCHANT_RESPONSE);
    }

    private void RemoveDeck(long id)
    {
        this.m_decks.Remove(id);
        this.m_baseDecks.Remove(id);
        NetCache.NetCacheDecks netObject = NetCache.Get().GetNetObject<NetCache.NetCacheDecks>();
        for (int i = 0; i < netObject.Decks.Count; i++)
        {
            NetCache.DeckHeader header = netObject.Decks[i];
            if (header.ID == id)
            {
                netObject.Decks.RemoveAt(i);
                break;
            }
        }
    }

    public bool RemoveDeckContentsListener(DelOnDeckContents listener)
    {
        return this.m_deckContentsListeners.Remove(listener);
    }

    public bool RemoveDeckCreatedListener(DelOnDeckCreated listener)
    {
        return this.m_deckCreatedListeners.Remove(listener);
    }

    public bool RemoveNewCardSeenListener(DelOnNewCardSeen listener)
    {
        return this.m_newCardSeenListeners.Remove(listener);
    }

    private void RenameDeck(long id, string newName)
    {
        <RenameDeck>c__AnonStorey12E storeye = new <RenameDeck>c__AnonStorey12E {
            id = id
        };
        this.GetDeck(storeye.id).Name = newName;
        NetCache.DeckHeader header = NetCache.Get().GetNetObject<NetCache.NetCacheDecks>().Decks.Find(new Predicate<NetCache.DeckHeader>(storeye.<>m__1D));
        if (header != null)
        {
            header.Name = newName;
        }
    }

    public void RequestDeckContents(long id)
    {
        CollectionDeck deck = this.GetDeck(id);
        if ((deck != null) && deck.NetworkContentsLoaded())
        {
            this.FireDeckContentsEvent(id);
        }
        else
        {
            Network.Get().GetDeckContents(id);
        }
    }

    public void SendCreateDeck(string name, string heroCardID)
    {
        CardManifest.Card card = CardManifest.Get().Find(heroCardID);
        if (card == null)
        {
            Debug.LogWarning(string.Format("CollectionManager.SendCreateDeck(): Unknown hero cardID {0}", heroCardID));
        }
        else
        {
            Network.Get().CreateDeck(name, card.DatabaseAssetID);
        }
    }

    public void SendDeleteDeck(long id)
    {
        Network.Get().DeleteDeck(id);
    }

    public void SetHasVisitedCollection(bool enable)
    {
        this.m_hasVisitedCollection = enable;
    }

    private void UpdateShowAdvancedCMOption()
    {
        if (!Options.Get().GetBool(Option.SHOW_ADVANCED_COLLECTIONMANAGER, false) && (this.GetNumCardsIOwn(null, null, null, null, null) >= 0x74))
        {
            Options.Get().SetBool(Option.SHOW_ADVANCED_COLLECTIONMANAGER, true);
        }
    }

    [CompilerGenerated]
    private sealed class <MarkAllInstancesAsSeen>c__AnonStorey12C
    {
        internal CollectionCardStack.ArtStack artStack;

        internal bool <>m__1B(NetCache.CardStack obj)
        {
            if (!obj.Def.Name.Equals(this.artStack.CardID))
            {
                return false;
            }
            return this.artStack.Flair.Equals(new CardFlair(obj.Def.Premium));
        }
    }

    [CompilerGenerated]
    private sealed class <NotifyNetCacheOfNewCards>c__AnonStorey130
    {
        internal NetCache.CardDefinition cardDef;

        internal bool <>m__20(NetCache.CardStack obj)
        {
            return (obj.Def.Name.Equals(this.cardDef.Name) && (obj.Def.Premium == this.cardDef.Premium));
        }
    }

    [CompilerGenerated]
    private sealed class <NotifyNetCacheOfRemovedCards>c__AnonStorey12F
    {
        internal NetCache.CardDefinition cardDef;

        internal bool <>m__1F(NetCache.CardStack obj)
        {
            return (obj.Def.Name.Equals(this.cardDef.Name) && (obj.Def.Premium == this.cardDef.Premium));
        }
    }

    [CompilerGenerated]
    private sealed class <NumCardsOwnedInSet>c__AnonStorey12D
    {
        internal TAG_CARD_SET cardSet;

        internal bool <>m__1C(CollectionCardStack obj)
        {
            EntityDef entityDef = DefLoader.Get().GetEntityDef(obj.CardID);
            return (this.cardSet == entityDef.GetCardSet());
        }
    }

    [CompilerGenerated]
    private sealed class <OnDBAction>c__AnonStorey12B
    {
        internal long deckID;

        internal bool <>m__1A(NetCache.DeckHeader deckHeader)
        {
            return (deckHeader.ID == this.deckID);
        }
    }

    [CompilerGenerated]
    private sealed class <OnDeck>c__AnonStorey12A
    {
        internal int prevHandle;

        internal bool <>m__19(Network.CardUserData card)
        {
            return (card.Prev == this.prevHandle);
        }
    }

    [CompilerGenerated]
    private sealed class <RenameDeck>c__AnonStorey12E
    {
        internal long id;

        internal bool <>m__1D(NetCache.DeckHeader deckHeader)
        {
            return (deckHeader.ID == this.id);
        }
    }

    public delegate void DelOnAchievesCompleted(List<Achievement> achievements);

    public delegate void DelOnAllDeckContents();

    public delegate void DelOnCardRewardInserted(string cardID, CardFlair flair);

    public delegate void DelOnCollectionChanged();

    public delegate void DelOnCollectionLoaded();

    public delegate void DelOnDeckContents(long id);

    public delegate void DelOnDeckCreated(long id);

    public delegate void DelOnNewCardSeen(string cardID, CardFlair flair);
}


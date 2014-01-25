using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionCardCache
{
    private List<CardCacheItem> m_cardCache = new List<CardCacheItem>();
    private Dictionary<string, CardCacheRequest> m_cardCacheRequests = new Dictionary<string, CardCacheRequest>();
    private const int MAX_CARD_CACHE_SIZE = 60;
    private static CollectionCardCache s_instance;

    private CollectionCardCache()
    {
    }

    private void AddCard(string cardID, CardDef card)
    {
        if (this.GetCardDef(cardID) != null)
        {
            Log.Rachelle.Print(string.Format("CollectionCardCache.AddCard(): somehow the card def for {0} was already in the cache...", cardID));
        }
        else
        {
            CardCacheItem item2 = new CardCacheItem {
                m_cardId = cardID,
                m_cardDef = card
            };
            CardCacheItem item = item2;
            item.m_lastRequestTimestamp = Blizzard.Time.BinaryStamp();
            this.m_cardCache.Add(item);
            this.CleanCache();
        }
    }

    private bool CanClearItem(CardCacheItem item, CollectionDeck currentlyOpenDeck, List<string> deckHelperCardChoices)
    {
        if ((currentlyOpenDeck != null) && (currentlyOpenDeck.GetCardIdCount(item.m_cardId) > 0))
        {
            return false;
        }
        if ((deckHelperCardChoices != null) && deckHelperCardChoices.Contains(item.m_cardId))
        {
            return false;
        }
        return true;
    }

    private void CleanCache()
    {
        int num = this.m_cardCache.Count - 60;
        if (num > 0)
        {
            CollectionDeck currentlyOpenDeck = null;
            if (CollectionDeckTray.Get() != null)
            {
                currentlyOpenDeck = CollectionManager.Get().GetDeck(CollectionDeckTray.Get().GetCurrentlyViewedDeckID());
            }
            List<string> deckHelperCardChoices = (DeckHelper.Get() != null) ? DeckHelper.Get().GetCardIDChoices() : null;
            List<string> names = new List<string>();
            int index = 0;
            while (index < this.m_cardCache.Count)
            {
                CardCacheItem item = this.m_cardCache[index];
                if (!this.CanClearItem(item, currentlyOpenDeck, deckHelperCardChoices))
                {
                    index++;
                }
                else
                {
                    names.Add(item.m_cardId);
                    this.m_cardCache.RemoveAt(index);
                    if (names.Count == num)
                    {
                        break;
                    }
                }
            }
            AssetCache.ClearCardPrefabs(names);
        }
    }

    public static CollectionCardCache Get()
    {
        if (s_instance == null)
        {
            s_instance = new CollectionCardCache();
        }
        return s_instance;
    }

    public CardDef GetCardDef(string cardId)
    {
        for (int i = 0; i < this.m_cardCache.Count; i++)
        {
            CardCacheItem item = this.m_cardCache[i];
            if (item.m_cardId.Equals(cardId))
            {
                item.m_lastRequestTimestamp = Blizzard.Time.BinaryStamp();
                this.m_cardCache.RemoveAt(i);
                this.m_cardCache.Add(item);
                return item.m_cardDef;
            }
        }
        return null;
    }

    public void LoadCardDef(string cardID, LoadCardDefCallback callback)
    {
        this.LoadCardDef(cardID, callback, null);
    }

    public void LoadCardDef(string cardID, LoadCardDefCallback callback, object callbackData)
    {
        CardDef cardDef = this.GetCardDef(cardID);
        if (cardDef != null)
        {
            callback(cardID, cardDef, callbackData);
        }
        else if (this.m_cardCacheRequests.ContainsKey(cardID))
        {
            this.m_cardCacheRequests[cardID].AddRequester(callback, callbackData);
        }
        else
        {
            CardCacheRequest request = new CardCacheRequest();
            request.AddRequester(callback, callbackData);
            this.m_cardCacheRequests.Add(cardID, request);
            AssetLoader.Get().LoadCardPrefab(cardID, new AssetLoader.GameObjectCallback(this.OnCardPrefabLoaded), callbackData);
        }
    }

    private void OnCardPrefabLoaded(string cardID, GameObject cardObject, object callbackData)
    {
        if (cardObject == null)
        {
            if (cardID == "PlaceholderCard")
            {
                Debug.LogError(string.Format("CollectionCardCache.OnCardPrefabLoaded() - {0} does not have an asset!", "PlaceholderCard"));
            }
            else
            {
                Debug.LogWarning(string.Format("CollectionCardCache.OnCardPrefabLoaded() - MISSING ASSET for card {0}. Falling back to {1}", cardID, "PlaceholderCard"));
                AssetLoader.Get().LoadCardPrefab("PlaceholderCard", new AssetLoader.GameObjectCallback(this.OnCardPrefabLoaded), callbackData);
            }
        }
        else
        {
            CardDef component = cardObject.GetComponent<CardDef>();
            if (component == null)
            {
                Debug.LogError(string.Format("CollectionCardCache.OnCardPrefabLoaded() - asset for card {0} has no CardDef!", cardID));
            }
            else
            {
                this.AddCard(cardID, component);
                CardCacheRequest request = this.m_cardCacheRequests[cardID];
                foreach (CardCacheRequest.Requester requester in request.m_requesters)
                {
                    requester.m_callback(cardID, component, requester.m_callbackData);
                }
                this.m_cardCacheRequests.Remove(cardID);
            }
        }
    }

    public void Unload()
    {
        this.m_cardCacheRequests.Clear();
        List<string> names = new List<string>();
        foreach (CardCacheItem item in this.m_cardCache)
        {
            names.Add(item.m_cardId);
        }
        this.m_cardCache.Clear();
        AssetCache.ClearCardPrefabs(names);
    }

    private class CardCacheItem
    {
        public CardDef m_cardDef;
        public string m_cardId;
        public long m_lastRequestTimestamp;
    }

    private class CardCacheRequest
    {
        public List<Requester> m_requesters = new List<Requester>();

        public void AddRequester(CollectionCardCache.LoadCardDefCallback callback, object callbackData)
        {
            if (callback != null)
            {
                Requester requester2 = new Requester {
                    m_callback = callback,
                    m_callbackData = callbackData
                };
                Requester item = requester2;
                this.m_requesters.Add(item);
            }
        }

        public class Requester
        {
            public CollectionCardCache.LoadCardDefCallback m_callback;
            public object m_callbackData;
        }
    }

    public delegate void LoadCardDefCallback(string cardID, CardDef cardDef, object callbackData);
}


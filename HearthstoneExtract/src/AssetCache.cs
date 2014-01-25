using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AssetCache
{
    private static readonly Dictionary<AssetFamily, AssetCache> cacheTable;
    private Dictionary<string, CachedAsset> m_assetMap = new Dictionary<string, CachedAsset>();
    private readonly Dictionary<string, CacheRequest> m_assetRequestMap = new Dictionary<string, CacheRequest>();

    static AssetCache()
    {
        Dictionary<AssetFamily, AssetCache> dictionary = new Dictionary<AssetFamily, AssetCache>();
        dictionary.Add(AssetFamily.Actor, new AssetCache());
        dictionary.Add(AssetFamily.CardXML, new AssetCache());
        dictionary.Add(AssetFamily.CardPrefab, new AssetCache());
        dictionary.Add(AssetFamily.Board, new AssetCache());
        dictionary.Add(AssetFamily.Sound, new AssetCache());
        dictionary.Add(AssetFamily.Screen, new AssetCache());
        dictionary.Add(AssetFamily.Texture, new AssetCache());
        dictionary.Add(AssetFamily.Spell, new AssetCache());
        dictionary.Add(AssetFamily.GameObject, new AssetCache());
        dictionary.Add(AssetFamily.Movie, new AssetCache());
        cacheTable = dictionary;
    }

    public static void Add(Asset asset, CachedAsset item)
    {
        cacheTable[asset.Family].AddItem(asset.Name, item);
    }

    public void AddItem(string name, CachedAsset item)
    {
        this.m_assetMap.Add(name, item);
    }

    public static void AddRequest(Asset asset, CacheRequest request)
    {
        cacheTable[asset.Family].AddRequest(asset.Name, request);
    }

    public void AddRequest(string key, CacheRequest request)
    {
        request.CreatedTimestamp = Blizzard.Time.BinaryStamp();
        this.m_assetRequestMap.Add(key, request);
    }

    private void Clear()
    {
        Dictionary<string, CachedAsset> dictionary = new Dictionary<string, CachedAsset>();
        foreach (KeyValuePair<string, CachedAsset> pair in this.m_assetMap)
        {
            string key = pair.Key;
            CachedAsset asset = pair.Value;
            if (asset.Persistent)
            {
                dictionary.Add(key, asset);
            }
            else
            {
                asset.UnloadAssetObject();
            }
        }
        this.m_assetMap = dictionary;
        this.m_assetRequestMap.Clear();
    }

    public static void ClearActor(string name)
    {
        cacheTable[AssetFamily.Actor].ClearItem(name);
    }

    public static void ClearActors(IEnumerable<string> names)
    {
        if (names != null)
        {
            cacheTable[AssetFamily.Actor].ClearItems(names);
        }
    }

    public static void ClearAllCaches()
    {
        foreach (KeyValuePair<AssetFamily, AssetCache> pair in cacheTable)
        {
            pair.Value.Clear();
        }
    }

    public static void ClearAllCachesBetween(long startTimestamp, long endTimestamp)
    {
        foreach (KeyValuePair<AssetFamily, AssetCache> pair in cacheTable)
        {
            pair.Value.ClearItemsUnusedBetween(startTimestamp, endTimestamp);
        }
    }

    public static void ClearAllCachesSince(long sinceTimestamp)
    {
        foreach (KeyValuePair<AssetFamily, AssetCache> pair in cacheTable)
        {
            pair.Value.ClearItemsUnusedBetween(sinceTimestamp, Blizzard.Time.BinaryStamp());
        }
    }

    public static void ClearCardPrefab(string name)
    {
        cacheTable[AssetFamily.CardPrefab].ClearItem(name);
    }

    public static void ClearCardPrefabs(IEnumerable<string> names)
    {
        if (names != null)
        {
            cacheTable[AssetFamily.CardPrefab].ClearItems(names);
        }
    }

    public static void ClearGameObject(string name)
    {
        cacheTable[AssetFamily.GameObject].ClearItem(name);
    }

    private bool ClearItem(string key)
    {
        CachedAsset asset;
        bool flag = false;
        if (this.m_assetMap.TryGetValue(key, out asset))
        {
            asset.UnloadAssetObject();
            this.m_assetMap.Remove(key);
            flag = true;
        }
        if (this.m_assetRequestMap.Remove(key))
        {
            flag = true;
        }
        if (!flag)
        {
            Log.Asset.Print(string.Format("AssetCache.ClearItem() - there is no loaded asset or request for key {0} in {1}", key, this));
        }
        return flag;
    }

    private void ClearItems(IEnumerable<string> itemsToRemove)
    {
        IEnumerator<string> enumerator = itemsToRemove.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                string current = enumerator.Current;
                this.ClearItem(current);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
    }

    private void ClearItemsUnusedBetween(long startTimestamp, long endTimestamp)
    {
        if (endTimestamp >= startTimestamp)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (KeyValuePair<string, CachedAsset> pair in this.m_assetMap)
            {
                CachedAsset asset = pair.Value;
                if (!asset.Persistent && ((startTimestamp <= asset.LastRequestTimestamp) && (asset.LastRequestTimestamp <= endTimestamp)))
                {
                    set.Add(pair.Key);
                }
            }
            foreach (string str in set)
            {
                this.ClearItem(str);
            }
        }
    }

    public static void ClearSound(string name)
    {
        cacheTable[AssetFamily.Sound].ClearItem(name);
    }

    public static void ClearTexture(string name)
    {
        cacheTable[AssetFamily.Texture].ClearItem(name);
    }

    public static void ClearTextures(IEnumerable<string> names)
    {
        if (names != null)
        {
            cacheTable[AssetFamily.Texture].ClearItems(names);
        }
    }

    public static CachedAsset Find(Asset asset)
    {
        return cacheTable[asset.Family].GetItem(asset.Name);
    }

    private void ForceClear()
    {
        foreach (KeyValuePair<string, CachedAsset> pair in this.m_assetMap)
        {
            pair.Value.UnloadAssetObject();
        }
        this.m_assetMap.Clear();
        this.m_assetRequestMap.Clear();
    }

    public static void ForceClearAllCaches()
    {
        foreach (KeyValuePair<AssetFamily, AssetCache> pair in cacheTable)
        {
            pair.Value.ForceClear();
        }
    }

    public CachedAsset GetItem(string key)
    {
        CachedAsset asset;
        return (!this.m_assetMap.TryGetValue(key, out asset) ? null : asset);
    }

    public static T GetRequest<T>(Asset asset) where T: CacheRequest
    {
        return cacheTable[asset.Family].GetRequest<T>(asset.Name);
    }

    public T GetRequest<T>(string key) where T: CacheRequest
    {
        CacheRequest request;
        if (this.m_assetRequestMap.TryGetValue(key, out request))
        {
            return (request as T);
        }
        return null;
    }

    public static bool HasItem(Asset asset)
    {
        return cacheTable[asset.Family].HasItem(asset.Name);
    }

    public bool HasItem(string key)
    {
        return this.m_assetMap.ContainsKey(key);
    }

    public static bool HasRequest(Asset asset)
    {
        return cacheTable[asset.Family].HasRequest(asset.Name);
    }

    public bool HasRequest(string key)
    {
        return this.m_assetRequestMap.ContainsKey(key);
    }

    public static bool RemoveRequest(Asset asset)
    {
        return cacheTable[asset.Family].RemoveRequest(asset.Name);
    }

    public bool RemoveRequest(string key)
    {
        return this.m_assetRequestMap.Remove(key);
    }

    public class CachedAsset
    {
        private Asset m_asset;
        private UnityEngine.Object m_assetObject;

        public Asset GetAsset()
        {
            return this.m_asset;
        }

        public UnityEngine.Object GetAssetObject()
        {
            return this.m_assetObject;
        }

        public void SetAsset(Asset asset)
        {
            this.m_asset = asset;
        }

        public void SetAssetObject(UnityEngine.Object asset)
        {
            this.m_assetObject = asset;
        }

        public void UnloadAssetObject()
        {
            object[] args = new object[] { this.m_asset.Name, this.m_asset.Family, this.Persistent };
            Log.Asset.Print("CachedAsset.UnloadAssetObject() - unloading name={0} family={1} persistent={2}", args);
            this.m_assetObject = null;
        }

        public long CreatedTimestamp { get; set; }

        public long LastRequestTimestamp { get; set; }

        public bool Persistent { get; set; }
    }

    public abstract class CacheRequest
    {
        protected CacheRequest()
        {
        }

        public bool DidFail()
        {
            return (this.Complete && !this.Success);
        }

        public bool DidSucceed()
        {
            return (this.Complete && this.Success);
        }

        public abstract int GetRequestCount();
        public virtual void OnLoadFailed(string name)
        {
            this.Complete = true;
            this.Success = false;
        }

        public void OnLoadSucceeded()
        {
            this.Complete = true;
            this.Success = true;
        }

        public abstract void OnProgressUpdate(string name, float progress);

        public bool Complete { get; set; }

        public long CreatedTimestamp { get; set; }

        public bool Success { get; set; }
    }

    public class GameObjectCacheRequest : AssetCache.CacheRequest
    {
        private readonly List<AssetCache.GameObjectRequester> m_requesters = new List<AssetCache.GameObjectRequester>();

        public void AddRequester(AssetLoader.GameObjectCallback callback, AssetLoader.ProgressCallback progressCallback, object callbackData)
        {
            AssetCache.GameObjectRequester requester2 = new AssetCache.GameObjectRequester {
                m_callback = callback,
                m_progressCallback = progressCallback,
                m_callbackData = callbackData
            };
            AssetCache.GameObjectRequester item = requester2;
            this.m_requesters.Add(item);
        }

        public override int GetRequestCount()
        {
            return this.m_requesters.Count;
        }

        public List<AssetCache.GameObjectRequester> GetRequesters()
        {
            return this.m_requesters;
        }

        public override void OnLoadFailed(string name)
        {
            base.OnLoadFailed(name);
            foreach (AssetCache.GameObjectRequester requester in this.m_requesters)
            {
                AssetLoader.GameObjectCallback callback = requester.m_callback;
                object callbackData = requester.m_callbackData;
                if (callback != null)
                {
                    callback(name, null, callbackData);
                }
            }
        }

        public override void OnProgressUpdate(string name, float progress)
        {
            foreach (AssetCache.GameObjectRequester requester in this.m_requesters)
            {
                AssetLoader.ProgressCallback progressCallback = requester.m_progressCallback;
                if (progressCallback != null)
                {
                    progressCallback(name, progress, requester.m_callbackData);
                }
            }
        }
    }

    public class GameObjectRequester
    {
        public AssetLoader.GameObjectCallback m_callback;
        public object m_callbackData;
        public AssetLoader.ProgressCallback m_progressCallback;
    }

    public class ObjectCacheRequest : AssetCache.CacheRequest
    {
        private readonly List<AssetCache.ObjectRequester> m_requesters = new List<AssetCache.ObjectRequester>();

        public void AddRequester(AssetLoader.ObjectCallback callback, AssetLoader.ProgressCallback progressCallback, object callbackData)
        {
            AssetCache.ObjectRequester requester2 = new AssetCache.ObjectRequester {
                m_callback = callback,
                m_progressCallback = progressCallback,
                m_callbackData = callbackData
            };
            AssetCache.ObjectRequester item = requester2;
            this.m_requesters.Add(item);
        }

        public override int GetRequestCount()
        {
            return this.m_requesters.Count;
        }

        public List<AssetCache.ObjectRequester> GetRequesters()
        {
            return this.m_requesters;
        }

        public void OnLoadComplete(string name, UnityEngine.Object asset)
        {
            foreach (AssetCache.ObjectRequester requester in this.m_requesters)
            {
                AssetLoader.ObjectCallback callback = requester.m_callback;
                if (callback != null)
                {
                    callback(name, asset, requester.m_callbackData);
                }
            }
        }

        public override void OnLoadFailed(string name)
        {
            base.OnLoadFailed(name);
            this.OnLoadComplete(name, null);
        }

        public override void OnProgressUpdate(string name, float progress)
        {
            foreach (AssetCache.ObjectRequester requester in this.m_requesters)
            {
                AssetLoader.ProgressCallback progressCallback = requester.m_progressCallback;
                if (progressCallback != null)
                {
                    progressCallback(name, progress, requester.m_callbackData);
                }
            }
        }
    }

    public class ObjectRequester
    {
        public AssetLoader.ObjectCallback m_callback;
        public object m_callbackData;
        public AssetLoader.ProgressCallback m_progressCallback;
    }
}


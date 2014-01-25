using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;

public class DefLoader
{
    private DefCache<CardDef> m_cardDefCache = new DefCache<CardDef>();
    private DefCache<EntityDef> m_entityDefCache = new DefCache<EntityDef>();
    private static DefLoader s_instance = new DefLoader();

    public void Clear()
    {
        this.ClearEntityDefs();
        this.ClearCardDefs();
    }

    public void ClearCardDefs()
    {
        this.m_cardDefCache.Clear();
    }

    public void ClearEntityDefs()
    {
        this.m_entityDefCache.Clear();
    }

    private void FullDef_OnCardDefLoaded(string cardId, CardDef cardDef, object userData)
    {
        FullDefContext context = (FullDefContext) userData;
        FullDef fullDef = context.m_fullDef;
        if (cardDef == null)
        {
            Debug.LogError(string.Format("DefLoader.FullDef_OnCardDefLoaded() - FAILED to load {0}", cardId));
        }
        else
        {
            fullDef.SetCardDef(cardDef);
        }
        this.FullDef_OnLoadComplete(context, cardId);
    }

    private void FullDef_OnEntityDefLoaded(string cardId, EntityDef entityDef, object userData)
    {
        FullDefContext context = (FullDefContext) userData;
        FullDef fullDef = context.m_fullDef;
        if (entityDef == null)
        {
            Debug.LogError(string.Format("DefLoader.FullDef_OnEntityDefLoaded() - FAILED to load {0}", cardId));
        }
        else
        {
            fullDef.SetEntityDef(entityDef);
        }
        this.LoadCardDef(cardId, new LoadDefCallback<CardDef>(this.FullDef_OnCardDefLoaded), context);
    }

    private void FullDef_OnLoadComplete(FullDefContext context, string cardId)
    {
        if (context.m_fullDef.IsEmpty())
        {
            context.m_callback(cardId, null, context.m_userData);
        }
        else
        {
            context.m_callback(cardId, context.m_fullDef, context.m_userData);
        }
    }

    public static DefLoader Get()
    {
        return s_instance;
    }

    public CardDef GetCardDef(string cardId)
    {
        return this.m_cardDefCache.GetDef(cardId);
    }

    public Dictionary<string, CardDef> GetCardDefMap()
    {
        return this.m_cardDefCache.GetDefMap();
    }

    public EntityDef GetEntityDef(string cardId)
    {
        return this.m_entityDefCache.GetDef(cardId);
    }

    public Dictionary<string, EntityDef> GetEntityDefMap()
    {
        return this.m_entityDefCache.GetDefMap();
    }

    public bool HasCardDef(GameObject go)
    {
        CardDef def = SceneUtils.FindComponentInThisOrParents<CardDef>(go);
        if (def == null)
        {
            return false;
        }
        return this.m_cardDefCache.HasDef(def);
    }

    public bool HasDef(GameObject go)
    {
        return this.HasCardDef(go);
    }

    public void LoadCardDef(string cardId, LoadDefCallback<CardDef> callback)
    {
        this.LoadCardDef(cardId, callback, null);
    }

    public void LoadCardDef(string cardId, LoadDefCallback<CardDef> callback, object userData)
    {
        if (!this.m_cardDefCache.OnDefRequested(cardId, callback, userData))
        {
            AssetLoader.Get().LoadCardPrefab(cardId, new AssetLoader.GameObjectCallback(this.OnCardDefLoaded));
        }
    }

    public void LoadEntityDef(string cardId, LoadDefCallback<EntityDef> callback)
    {
        this.LoadEntityDef(cardId, callback, null);
    }

    public void LoadEntityDef(string cardId, LoadDefCallback<EntityDef> callback, object userData)
    {
        if (!this.m_entityDefCache.OnDefRequested(cardId, callback, userData))
        {
            AssetLoader.Get().LoadCardXml(cardId, new AssetLoader.ObjectCallback(this.OnCardXmlLoaded));
        }
    }

    public void LoadFullDef(string cardId, LoadDefCallback<FullDef> callback)
    {
        this.LoadFullDef(cardId, callback, null);
    }

    public void LoadFullDef(string cardId, LoadDefCallback<FullDef> callback, object userData)
    {
        FullDefContext context = new FullDefContext {
            m_callback = callback,
            m_userData = userData
        };
        this.LoadEntityDef(cardId, new LoadDefCallback<EntityDef>(this.FullDef_OnEntityDefLoaded), context);
    }

    private void OnCardDefLoaded(string cardId, GameObject cardObject, object userData)
    {
        CardDef component = null;
        if (cardObject == null)
        {
            Debug.LogError(string.Format("DefLoader.OnCardDefLoaded() - FAILED to load {0}", cardId));
        }
        else
        {
            component = cardObject.GetComponent<CardDef>();
        }
        this.m_cardDefCache.OnDefLoaded(cardId, component);
    }

    private void OnCardXmlLoaded(string cardId, UnityEngine.Object asset, object userData)
    {
        EntityDef def = null;
        if (asset == null)
        {
            Debug.LogError(string.Format("DefLoader.OnCardXmlLoaded() - FAILED to load {0}", cardId));
        }
        else
        {
            XmlElement rootElement = EntityDef.LoadCardXmlFromAsset(cardId, asset);
            if (rootElement != null)
            {
                def = new EntityDef();
                def.LoadDataFromCardXml(rootElement);
            }
        }
        this.m_entityDefCache.OnDefLoaded(cardId, def);
    }

    private class DefCache<T>
    {
        private Dictionary<string, T> m_defMap;
        private Dictionary<string, List<Request<T>>> m_defRequestMap;

        public DefCache()
        {
            this.m_defMap = new Dictionary<string, T>();
            this.m_defRequestMap = new Dictionary<string, List<Request<T>>>();
        }

        public void Clear()
        {
            this.m_defMap.Clear();
            this.m_defRequestMap.Clear();
        }

        public T GetDef(string cardId)
        {
            T local;
            this.m_defMap.TryGetValue(cardId, out local);
            return local;
        }

        public Dictionary<string, T> GetDefMap()
        {
            return this.m_defMap;
        }

        public bool HasDef(T def)
        {
            return this.m_defMap.ContainsValue(def);
        }

        public bool HasDef(string cardId)
        {
            return this.m_defMap.ContainsKey(cardId);
        }

        public void OnDefLoaded(string cardId, T def)
        {
            if (this.m_defRequestMap.ContainsKey(cardId))
            {
                this.m_defMap.Add(cardId, def);
                List<Request<T>> list = this.m_defRequestMap[cardId];
                this.m_defRequestMap.Remove(cardId);
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Fire(cardId, def);
                }
            }
        }

        public bool OnDefRequested(string cardId, DefLoader.LoadDefCallback<T> callback, object userData)
        {
            T local;
            List<Request<T>> list;
            if (this.m_defMap.TryGetValue(cardId, out local))
            {
                if (callback != null)
                {
                    callback(cardId, local, userData);
                }
                return true;
            }
            Request<T> item = new Request<T>();
            item.SetCallback(callback);
            item.SetUserData(userData);
            if (this.m_defRequestMap.TryGetValue(cardId, out list))
            {
                list.Add(item);
                return true;
            }
            list = new List<Request<T>> {
                item
            };
            this.m_defRequestMap.Add(cardId, list);
            return false;
        }

        private class Request : EventListener<DefLoader.LoadDefCallback<T>>
        {
            public void Fire(string cardId, T def)
            {
                base.m_callback(cardId, def, base.m_userData);
            }
        }
    }

    private class FullDefContext
    {
        public DefLoader.LoadDefCallback<FullDef> m_callback;
        public FullDef m_fullDef = new FullDef();
        public object m_userData;
    }

    public delegate void LoadDefCallback<T>(string cardId, T def, object userData);
}


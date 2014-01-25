using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HandActorCache
{
    private readonly TAG_CARDTYPE[] ACTOR_CARD_TYPES = new TAG_CARDTYPE[] { TAG_CARDTYPE.MINION, TAG_CARDTYPE.ABILITY, TAG_CARDTYPE.WEAPON };
    private Dictionary<ActorKey, Actor> m_actorMap = new Dictionary<ActorKey, Actor>();
    private List<ActorLoadedListener> m_loadedListeners = new List<ActorLoadedListener>();

    public void AddActorLoadedListener(ActorLoadedCallback callback)
    {
        this.AddActorLoadedListener(callback, null);
    }

    public void AddActorLoadedListener(ActorLoadedCallback callback, object userData)
    {
        ActorLoadedListener item = new ActorLoadedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (!this.m_loadedListeners.Contains(item))
        {
            this.m_loadedListeners.Add(item);
        }
    }

    private void FireActorLoadedListeners(string name, Actor actor)
    {
        ActorLoadedListener[] listenerArray = this.m_loadedListeners.ToArray();
        for (int i = 0; i < listenerArray.Length; i++)
        {
            listenerArray[i].Fire(name, actor);
        }
    }

    public Actor GetActor(EntityDef entityDef, CardFlair cardFlair)
    {
        Actor actor;
        ActorKey key = this.MakeActorKey(entityDef, cardFlair);
        if (!this.m_actorMap.TryGetValue(key, out actor))
        {
            Debug.LogError(string.Format("HandActorCache.GetActor() - FAILED to get actor with cardType={0} premiumType={1}", entityDef.GetCardType(), CardFlair.GetPremiumType(cardFlair)));
            return null;
        }
        return actor;
    }

    public void Initialize()
    {
        foreach (TAG_CARDTYPE tag_cardtype in this.ACTOR_CARD_TYPES)
        {
            IEnumerator enumerator = Enum.GetValues(typeof(CardFlair.PremiumType)).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    CardFlair.PremiumType current = (CardFlair.PremiumType) ((int) enumerator.Current);
                    string handActor = ActorNames.GetHandActor(tag_cardtype, current);
                    ActorKey callbackData = this.MakeActorKey(tag_cardtype, current);
                    AssetLoader.Get().LoadActor(handActor, new AssetLoader.GameObjectCallback(this.OnActorLoaded), callbackData);
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
        }
    }

    public bool IsInitializing()
    {
        foreach (TAG_CARDTYPE tag_cardtype in this.ACTOR_CARD_TYPES)
        {
            IEnumerator enumerator = Enum.GetValues(typeof(CardFlair.PremiumType)).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    CardFlair.PremiumType current = (CardFlair.PremiumType) ((int) enumerator.Current);
                    ActorKey key = this.MakeActorKey(tag_cardtype, current);
                    if (!this.m_actorMap.ContainsKey(key))
                    {
                        return true;
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
        }
        return false;
    }

    private ActorKey MakeActorKey(EntityDef entityDef, CardFlair flair)
    {
        return this.MakeActorKey(entityDef.GetCardType(), CardFlair.GetPremiumType(flair));
    }

    private ActorKey MakeActorKey(TAG_CARDTYPE cardType, CardFlair.PremiumType premiumType)
    {
        return new ActorKey { m_cardType = cardType, m_premiumType = premiumType };
    }

    private void OnActorLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogWarning(string.Format("HandActorCache.OnActorLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            Actor component = go.GetComponent<Actor>();
            if (component == null)
            {
                Debug.LogWarning(string.Format("HandActorCache.OnActorLoaded() - ERROR \"{0}\" has no Actor component", name));
            }
            else
            {
                ActorKey key = (ActorKey) callbackData;
                this.m_actorMap.Add(key, component);
                this.FireActorLoadedListeners(name, component);
            }
        }
    }

    public bool RemoveActorLoadedListener(ActorLoadedCallback callback)
    {
        return this.RemoveActorLoadedListener(callback, null);
    }

    public bool RemoveActorLoadedListener(ActorLoadedCallback callback, object userData)
    {
        ActorLoadedListener item = new ActorLoadedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_loadedListeners.Remove(item);
    }

    private class ActorKey
    {
        public TAG_CARDTYPE m_cardType;
        public CardFlair.PremiumType m_premiumType;

        public bool Equals(HandActorCache.ActorKey other)
        {
            if (other == null)
            {
                return false;
            }
            return ((this.m_cardType == other.m_cardType) && (this.m_premiumType == other.m_premiumType));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            HandActorCache.ActorKey other = obj as HandActorCache.ActorKey;
            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            int num = 0x17;
            num = (num * 0x11) + this.m_cardType.GetHashCode();
            return ((num * 0x11) + this.m_premiumType.GetHashCode());
        }

        public static bool operator ==(HandActorCache.ActorKey a, HandActorCache.ActorKey b)
        {
            return (object.ReferenceEquals(a, b) || (((a != null) && (b != null)) && a.Equals(b)));
        }

        public static bool operator !=(HandActorCache.ActorKey a, HandActorCache.ActorKey b)
        {
            return !(a == b);
        }
    }

    public delegate void ActorLoadedCallback(string name, Actor actor, object userData);

    private class ActorLoadedListener : EventListener<HandActorCache.ActorLoadedCallback>
    {
        public void Fire(string name, Actor actor)
        {
            base.m_callback(name, actor, base.m_userData);
        }
    }
}


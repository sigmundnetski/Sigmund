using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class CollectionActorPool
{
    private readonly TAG_CARDTYPE[] ACTOR_CARD_TYPES = new TAG_CARDTYPE[] { TAG_CARDTYPE.MINION, TAG_CARDTYPE.ABILITY, TAG_CARDTYPE.WEAPON };
    private Dictionary<Actor, ActorKey> m_actorKeyMap = new Dictionary<Actor, ActorKey>();
    private Dictionary<ActorKey, List<Actor>> m_actorMap = new Dictionary<ActorKey, List<Actor>>();

    public bool AcquireActor(EntityDef entityDef, CardFlair flair, AcquireActorCallback callback, object callbackData)
    {
        if (entityDef == null)
        {
            Debug.LogError("Cannot acquire actor; entityDef is null!");
            return false;
        }
        bool owned = CollectionManager.Get().IsCardInCollection(entityDef.GetCardId(), flair);
        ActorKey key = this.MakeActorKey(entityDef, flair, owned);
        List<Actor> list = null;
        if (!this.m_actorMap.TryGetValue(key, out list))
        {
            Debug.LogError(string.Format("CollectionActorPool.AcquireActor() - FAILED to find actorName for entityDef {0}", entityDef));
            return false;
        }
        if (list.Count > 0)
        {
            int index = list.Count - 1;
            Actor actor = list[index];
            list.RemoveAt(index);
            actor.SetEntityDef(entityDef);
            actor.SetCardFlair(flair);
            actor.UpdateAllComponents();
            callback(actor, callbackData);
            return true;
        }
        string handActor = ActorNames.GetHandActor(entityDef, flair);
        ActorLoadCallbackData data2 = new ActorLoadCallbackData {
            m_key = key,
            m_owned = owned,
            m_entityDef = entityDef,
            m_cardFlair = flair,
            m_callback = callback,
            m_callbackData = callbackData
        };
        ActorLoadCallbackData data = data2;
        AssetLoader.Get().LoadActor(handActor, new AssetLoader.GameObjectCallback(this.OnActorLoaded), data);
        return true;
    }

    private ActorKey FindActorKey(Actor actor)
    {
        ActorKey key;
        this.m_actorKeyMap.TryGetValue(actor, out key);
        return key;
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
                    ActorKey key = this.MakeActorKey(tag_cardtype, current, true);
                    this.m_actorMap.Add(key, new List<Actor>());
                    ActorKey key2 = this.MakeActorKey(tag_cardtype, current, false);
                    this.m_actorMap.Add(key2, new List<Actor>());
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

    private ActorKey MakeActorKey(EntityDef entityDef, CardFlair flair, bool owned)
    {
        return this.MakeActorKey(entityDef.GetCardType(), CardFlair.GetPremiumType(flair), owned);
    }

    private ActorKey MakeActorKey(TAG_CARDTYPE cardType, CardFlair.PremiumType premiumType, bool owned)
    {
        return new ActorKey { m_cardType = cardType, m_owned = owned, m_premiumType = premiumType };
    }

    private void OnActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            Debug.LogWarning(string.Format("CollectionActorPool.OnActorLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                Debug.LogWarning(string.Format("CollectionActorPool.OnActorLoaded() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                component.TurnOffCollider();
                ActorLoadCallbackData data = (ActorLoadCallbackData) callbackData;
                this.m_actorKeyMap.Add(component, data.m_key);
                component.SetEntityDef(data.m_entityDef);
                component.SetCardFlair(data.m_cardFlair);
                if (!data.m_owned)
                {
                    CollectionManagerDisplay display = CollectionManagerDisplay.Get();
                    if (!component.MissingCardEffect())
                    {
                        if (data.m_cardFlair.Premium == CardFlair.PremiumType.FOIL)
                        {
                            component.OverrideAllMeshMaterials(display.GetFoilCardNotOwnedMeshMaterial());
                        }
                        else
                        {
                            component.OverrideAllMeshMaterials(display.GetCardNotOwnedMeshMaterial());
                        }
                    }
                }
                data.m_callback(component, data.m_callbackData);
            }
        }
    }

    public void ReleaseActor(Actor actor)
    {
        ActorKey key = this.FindActorKey(actor);
        if (key == null)
        {
            Debug.LogError(string.Format("CollectionActorPool.ReleaseActor(): actor {0} was never Acquired from the pool!", actor));
        }
        else
        {
            List<Actor> list = null;
            if (!this.m_actorMap.TryGetValue(key, out list))
            {
                Debug.LogError(string.Format("CollectionActorPool.ReleaseActor(): actor map does not contain actor {0}!", actor));
            }
            else
            {
                list.Add(actor);
                actor.SetEntityDef(null);
                actor.SetCardFlair(new CardFlair(CardFlair.PremiumType.STANDARD));
            }
        }
    }

    public void Unload()
    {
        List<string> names = new List<string>();
        foreach (TAG_CARDTYPE tag_cardtype in this.ACTOR_CARD_TYPES)
        {
            IEnumerator enumerator = Enum.GetValues(typeof(CardFlair.PremiumType)).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    CardFlair.PremiumType current = (CardFlair.PremiumType) ((int) enumerator.Current);
                    string handActor = ActorNames.GetHandActor(tag_cardtype, current);
                    names.Add(handActor);
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
        AssetCache.ClearActors(names);
    }

    public delegate void AcquireActorCallback(Actor actor, object callbackData);

    private class ActorKey
    {
        public TAG_CARDTYPE m_cardType;
        public bool m_owned;
        public CardFlair.PremiumType m_premiumType;

        public bool Equals(CollectionActorPool.ActorKey other)
        {
            if (other == null)
            {
                return false;
            }
            return (((this.m_cardType == other.m_cardType) && (this.m_owned == other.m_owned)) && (this.m_premiumType == other.m_premiumType));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            CollectionActorPool.ActorKey other = obj as CollectionActorPool.ActorKey;
            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            int num = 0x17;
            num = (num * 0x11) + this.m_cardType.GetHashCode();
            num = (num * 0x11) + this.m_owned.GetHashCode();
            return ((num * 0x11) + this.m_premiumType.GetHashCode());
        }

        public static bool operator ==(CollectionActorPool.ActorKey a, CollectionActorPool.ActorKey b)
        {
            return (object.ReferenceEquals(a, b) || (((a != null) && (b != null)) && a.Equals(b)));
        }

        public static bool operator !=(CollectionActorPool.ActorKey a, CollectionActorPool.ActorKey b)
        {
            return !(a == b);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct ActorLoadCallbackData
    {
        public CollectionActorPool.ActorKey m_key;
        public bool m_owned;
        public EntityDef m_entityDef;
        public CardFlair m_cardFlair;
        public CollectionActorPool.AcquireActorCallback m_callback;
        public object m_callbackData;
    }
}


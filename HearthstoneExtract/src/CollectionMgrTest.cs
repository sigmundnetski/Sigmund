using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class CollectionMgrTest : MonoBehaviour
{
    private const int CARD_PER_PAGE_COUNT = 30;
    private const int INITIAL_CARD_POOL_COUNT = 60;
    private Dictionary<string, List<Actor>> m_actorMap = new Dictionary<string, List<Actor>>();
    private List<Entity> m_entities = new List<Entity>();
    private string[] m_testCardIds = new string[] { "CS1_042", "CS1_069", "CS1_112", "CS2_114" };
    private const int VISIBLE_PAGE_COUNT = 2;

    private bool AreAllActorsLoaded()
    {
        foreach (List<Actor> list in this.m_actorMap.Values)
        {
            if (list.Count != 60)
            {
                return false;
            }
        }
        return true;
    }

    private bool AreAllCardsLoaded()
    {
        MonoBehaviour.print(this.m_entities.Count);
        return (this.m_entities.Count == this.m_testCardIds.Length);
    }

    private void AttachEntitiesToActors()
    {
        if (this.AreAllActorsLoaded())
        {
            MonoBehaviour.print("AreAllActorsLoaded");
            if (this.AreAllCardsLoaded())
            {
                MonoBehaviour.print("AreAllCardsLoaded");
                foreach (Entity entity in this.m_entities)
                {
                    List<Actor> list;
                    Card card = entity.GetCard();
                    if (entity.IsAbility())
                    {
                        list = this.m_actorMap["Card_Hand_Ability"];
                    }
                    else if (entity.IsMinion())
                    {
                        list = this.m_actorMap["Card_Hand_Ally"];
                    }
                    else if (entity.IsWeapon())
                    {
                        list = this.m_actorMap["Card_Hand_Weapon"];
                    }
                    else
                    {
                        Debug.LogWarning(string.Format("CollectionMgrTest.AttachEntitiesToActors() - Unhandled CARDTYPE {0}", entity.GetCardType()));
                        continue;
                    }
                    int index = list.Count - 1;
                    Actor actor = list[index];
                    list.RemoveAt(index);
                    card.SetActor(actor);
                    actor.SetCard(card);
                }
            }
        }
    }

    private void LoadActors(string actorName)
    {
        AssetLoader loader = AssetLoader.Get();
        for (int i = 0; i < 60; i++)
        {
            loader.LoadActor(actorName, new AssetLoader.GameObjectCallback(this.OnActorLoaded));
        }
    }

    private void LoadTestCards()
    {
        AssetLoader loader = AssetLoader.Get();
        for (int i = 0; i < this.m_testCardIds.Length; i++)
        {
            loader.LoadCardXml(this.m_testCardIds[i], new AssetLoader.ObjectCallback(this.OnCardXmlLoaded));
        }
    }

    private void OnActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            Debug.LogWarning(string.Format("CollectionMgrTest.OnActorLoaded() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                Debug.LogWarning(string.Format("CollectionMgrTest.OnActorLoaded() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                List<Actor> list;
                if (!this.m_actorMap.TryGetValue(actorName, out list))
                {
                    list = new List<Actor>();
                    this.m_actorMap[actorName] = list;
                }
                list.Add(component);
                this.AttachEntitiesToActors();
                if (list.Count == 60)
                {
                    if (actorName == "Card_Hand_Ally")
                    {
                        this.LoadActors("Card_Hand_Weapon");
                    }
                    else if (actorName == "Card_Hand_Weapon")
                    {
                        this.LoadActors("Card_Hand_Ability");
                    }
                    else if (actorName == "Card_Hand_Ability")
                    {
                        this.LoadTestCards();
                    }
                }
            }
        }
    }

    private void OnCardPrefabLoaded(Entity entity, string cardId)
    {
        this.m_entities.Add(entity);
        MonoBehaviour.print("OnCardLoaded");
        this.AttachEntitiesToActors();
    }

    private void OnCardXmlLoaded(string cardId, UnityEngine.Object asset, object callbackData)
    {
        if (asset == null)
        {
            Debug.LogError(string.Format("CollectionMgrTest.OnCardXmlLoaded() - {0} does not have an asset!", cardId));
        }
        else
        {
            XmlElement rootElement = EntityDef.LoadCardXmlFromAsset(cardId, asset);
            Entity entity = new Entity();
            entity.GetEntityDef().LoadDataFromCardXml(rootElement);
        }
    }

    private void Start()
    {
        this.LoadActors("Card_Hand_Ally");
    }
}


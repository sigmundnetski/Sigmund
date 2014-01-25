using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPageDisplay : MonoBehaviour
{
    public const float CARD_SCALE_8_CARDS = 0.73f;
    public GameObject m_cardStartPositionEightCards;
    public GameObject m_cardStartPositionFifteenCards;
    public GameObject m_classFlavorCornerLeft;
    public GameObject m_classFlavorCornerRight;
    public GameObject m_classFlavorHeader;
    public UberText m_classNameText;
    private List<CollectionCardVisual> m_collectionCardVisuals = new List<CollectionCardVisual>();
    public UberText m_noMatchesFoundText;
    public UberText m_pageCountText;
    private static bool m_useEightCards = true;
    public static readonly Color TAUPE_COLOR = new Color(0.388f, 0.337f, 0.271f);

    public void ActivatePageCountText(bool active)
    {
        this.m_pageCountText.gameObject.SetActive(active);
    }

    private void Awake()
    {
        this.m_noMatchesFoundText.Text = GameStrings.Get("GLUE_COLLECTION_NO_MATCHES");
    }

    public void DisableCardInput()
    {
        foreach (CollectionCardVisual visual in this.m_collectionCardVisuals)
        {
            visual.SetEnabled(false);
        }
    }

    public void EnableCardInput()
    {
        foreach (CollectionCardVisual visual in this.m_collectionCardVisuals)
        {
            visual.SetEnabled(visual.IsShown());
        }
    }

    public CollectionCardVisual GetCardVisual(string cardID, CardFlair cardFlair)
    {
        foreach (CollectionCardVisual visual in this.m_collectionCardVisuals)
        {
            if (visual.IsShown())
            {
                Actor actor = visual.GetActor();
                if (actor.GetEntityDef().GetCardId().Equals(cardID) && actor.GetCardFlair().Equals(cardFlair))
                {
                    return visual;
                }
            }
        }
        return null;
    }

    private CollectionCardVisual GetCollectionCardVisual(int index)
    {
        float x = !m_useEightCards ? 0.55f : 0.73f;
        float num7 = !m_useEightCards ? 1.325f : 1.65f;
        float num8 = !m_useEightCards ? 1.7f : 2.6f;
        GameObject obj2 = !m_useEightCards ? this.m_cardStartPositionFifteenCards : this.m_cardStartPositionEightCards;
        Vector3 localPosition = obj2.transform.localPosition;
        if (index == this.m_collectionCardVisuals.Count)
        {
            GameObject obj3 = new GameObject("CollectionCardVisual" + index) {
                transform = { parent = base.transform }
            };
            float num9 = localPosition.x + ((index % GetNumColumns()) * num7);
            float y = localPosition.y;
            float z = localPosition.z - (num8 * Mathf.Floor((float) (index / GetNumColumns())));
            Vector3 position = new Vector3(num9, y, z);
            obj3.transform.position = base.transform.TransformPoint(position);
            obj3.transform.localScale = new Vector3(x, x, x);
            CollectionCardVisual item = obj3.AddComponent<CollectionCardVisual>();
            this.m_collectionCardVisuals.Insert(index, item);
            return item;
        }
        return this.m_collectionCardVisuals[index];
    }

    public static int GetMaxNumCards()
    {
        return (GetNumColumns() * GetNumRows());
    }

    private static int GetNumColumns()
    {
        return (!m_useEightCards ? 5 : 4);
    }

    private static int GetNumRows()
    {
        return (!m_useEightCards ? 3 : 2);
    }

    public void PositionCollectionCards(List<Actor> actorList, object callbackData)
    {
        int index = 0;
        while (index < actorList.Count)
        {
            if (index >= GetMaxNumCards())
            {
                break;
            }
            Actor actor = actorList[index];
            CollectionCardVisual collectionCardVisual = this.GetCollectionCardVisual(index);
            collectionCardVisual.SetActor(actor);
            string cardId = actor.GetEntityDef().GetCardId();
            CardFlair cardFlair = actor.GetCardFlair();
            bool showNewCardGlow = CollectionManagerDisplay.Get().ShouldShowNewCardGlow(cardId, cardFlair);
            if (!showNewCardGlow)
            {
                CollectionManager.Get().MarkAllInstancesAsSeen(cardId, cardFlair);
            }
            collectionCardVisual.Show(showNewCardGlow);
            index++;
        }
        for (int i = index; i < GetMaxNumCards(); i++)
        {
            CollectionCardVisual visual2 = this.GetCollectionCardVisual(i);
            visual2.SetActor(null);
            visual2.Hide();
        }
        this.UpdateCurrentPageCardLocks();
        CollectionPageManager.PageAssembledCallbackData data = callbackData as CollectionPageManager.PageAssembledCallbackData;
        data.m_callback(data.m_callbackData);
    }

    public void SetClass(TAG_CLASS? classTag)
    {
        if (!classTag.HasValue)
        {
            this.SetClassNameText(string.Empty);
            this.ShowClassFlavorObjects(false);
        }
        else
        {
            TAG_CLASS tag = classTag.Value;
            this.SetClassNameText(GameStrings.GetClassName(tag));
            this.SetClassFlavorTextures(tag);
        }
    }

    private void SetClassFlavorTextures(TAG_CLASS classTag)
    {
        this.ShowClassFlavorObjects(true);
        Texture mainTexture = this.m_classFlavorCornerLeft.renderer.material.mainTexture;
        this.m_classFlavorCornerLeft.renderer.material.mainTexture = mainTexture;
        this.m_classFlavorCornerRight.renderer.material.mainTexture = mainTexture;
        Texture texture2 = this.m_classFlavorHeader.renderer.material.mainTexture;
        this.m_classFlavorHeader.renderer.material.mainTexture = texture2;
    }

    private void SetClassNameText(string className)
    {
        this.m_classNameText.Text = className;
    }

    public void SetPageCountText(string text)
    {
        this.m_pageCountText.Text = text;
    }

    private void ShowClassFlavorObjects(bool show)
    {
        this.m_classFlavorCornerLeft.SetActive(show);
        this.m_classFlavorCornerRight.SetActive(show);
        this.m_classFlavorHeader.SetActive(show);
    }

    public void ShowNoMatchesFound(bool show)
    {
        this.m_noMatchesFoundText.gameObject.SetActive(show);
    }

    public void UpdateCurrentPageCardLocks()
    {
        CollectionDeck deck = CollectionManager.Get().GetDeck(CollectionDeckTray.Get().GetCurrentlyViewedDeckID());
        if (deck == null)
        {
            foreach (CollectionCardVisual visual in this.m_collectionCardVisuals)
            {
                if (visual.IsShown())
                {
                    visual.ShowLock(CollectionCardVisual.LockType.NONE);
                }
            }
        }
        else
        {
            foreach (CollectionCardVisual visual2 in this.m_collectionCardVisuals)
            {
                if (visual2.IsShown())
                {
                    Actor actor = visual2.GetActor();
                    string cardId = actor.GetEntityDef().GetCardId();
                    CardFlair cardFlair = actor.GetCardFlair();
                    CollectionCardStack.ArtStack collectionArtStack = CollectionManager.Get().GetCollectionArtStack(cardId, cardFlair);
                    if (collectionArtStack.Count <= 0)
                    {
                        visual2.ShowLock(CollectionCardVisual.LockType.NONE);
                    }
                    else
                    {
                        CollectionCardVisual.LockType nONE = CollectionCardVisual.LockType.NONE;
                        if (CollectionDeckValidator.GetDeckViolationCardIdOverflow(deck, cardId, true) != null)
                        {
                            nONE = CollectionCardVisual.LockType.MAX_COPIES_IN_DECK;
                        }
                        if (((nONE == CollectionCardVisual.LockType.NONE) && (collectionArtStack.Count > 0)) && (deck.GetCardCount(cardId, cardFlair) >= collectionArtStack.Count))
                        {
                            nONE = CollectionCardVisual.LockType.NO_MORE_INSTANCES;
                        }
                        visual2.ShowLock(nONE);
                    }
                }
            }
        }
    }
}


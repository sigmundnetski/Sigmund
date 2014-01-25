using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class CollectionDeckValidator
{
    public const int MAX_INSTANCES_PER_CARD_ID = 2;
    public const int MAX_INSTANCES_PER_DECK = 30;
    public const int MAX_INSTANCES_PER_ELITE_CARD_ID = 1;

    public static CollectionDeckViolationDeckSize GetCollectionDeckViolationDeckOverflow(CollectionDeck deck, bool addExtraCard)
    {
        int totalCardCount = deck.GetTotalCardCount();
        if (addExtraCard)
        {
            totalCardCount++;
        }
        CollectionDeckViolationDeckSize size = null;
        if (totalCardCount != 30)
        {
            CollectionDeckViolationDeckSize size2 = new CollectionDeckViolationDeckSize {
                DeckID = deck.ID,
                ViolationType = (totalCardCount >= 30) ? CollectionDeckViolationType.DECK_OVERFLOW : CollectionDeckViolationType.DECK_UNDERFLOW,
                TotalCardCount = totalCardCount
            };
            size = size2;
        }
        return size;
    }

    public static CollectionDeckViolationCardIdOverflow GetDeckViolationCardIdOverflow(CollectionDeck deck, string cardID, bool useExtraCopyOfCard)
    {
        CollectionDeckViolationCardIdOverflow overflow = null;
        CollectionDeckViolationCardIdOverflow overflow2;
        int cardIdCount = deck.GetCardIdCount(cardID);
        if (useExtraCopyOfCard)
        {
            cardIdCount++;
        }
        if (DefLoader.Get().GetEntityDef(cardID).IsElite())
        {
            if (cardIdCount > 1)
            {
                overflow2 = new CollectionDeckViolationCardIdOverflow {
                    DeckID = deck.ID,
                    ViolationType = CollectionDeckViolationType.ELITE_CARD_ID_OVERFLOW,
                    CardID = cardID,
                    Count = cardIdCount
                };
                overflow = overflow2;
            }
            return overflow;
        }
        if (cardIdCount > 2)
        {
            overflow2 = new CollectionDeckViolationCardIdOverflow {
                DeckID = deck.ID,
                ViolationType = CollectionDeckViolationType.CARD_ID_OVERFLOW,
                CardID = cardID,
                Count = cardIdCount
            };
            overflow = overflow2;
        }
        return overflow;
    }

    public static List<CollectionDeckViolation> GetDeckViolations(CollectionDeck deck)
    {
        List<CollectionDeckViolation> list = new List<CollectionDeckViolation>();
        for (int i = 0; i < deck.GetSlotCount(); i++)
        {
            <GetDeckViolations>c__AnonStorey129 storey = new <GetDeckViolations>c__AnonStorey129 {
                slot = deck.GetSlotByIndex(i)
            };
            if (list.Find(new Predicate<CollectionDeckViolation>(storey.<>m__18)) == null)
            {
                CollectionDeckViolationCardIdOverflow item = GetDeckViolationCardIdOverflow(deck, storey.slot.CardID, false);
                if (item != null)
                {
                    list.Add(item);
                }
            }
        }
        CollectionDeckViolationDeckSize collectionDeckViolationDeckOverflow = GetCollectionDeckViolationDeckOverflow(deck, false);
        if (collectionDeckViolationDeckOverflow != null)
        {
            list.Add(collectionDeckViolationDeckOverflow);
        }
        return list;
    }

    [CompilerGenerated]
    private sealed class <GetDeckViolations>c__AnonStorey129
    {
        internal CollectionDeckSlot slot;

        internal bool <>m__18(CollectionDeckViolation v)
        {
            if (v.ViolationType != CollectionDeckViolationType.CARD_ID_OVERFLOW)
            {
                return false;
            }
            CollectionDeckViolationCardIdOverflow overflow = (CollectionDeckViolationCardIdOverflow) v;
            return overflow.CardID.Equals(this.slot.CardID);
        }
    }
}


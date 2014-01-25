using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RandomDeckMaker
{
    private static readonly CostRequirement[] COST_REQUIREMENTS = new CostRequirement[] { new CostRequirement(GAME_STRING_1_COST, 4, 1, CollectionFilterFunc.EQUAL), new CostRequirement(GAME_STRING_2_COST, 4, 2, CollectionFilterFunc.EQUAL), new CostRequirement(GAME_STRING_3_COST, 3, 3, CollectionFilterFunc.EQUAL), new CostRequirement(GAME_STRING_4_COST, 2, 4, CollectionFilterFunc.EQUAL), new CostRequirement(GAME_STRING_5_COST, 2, 5, CollectionFilterFunc.EQUAL), new CostRequirement(GAME_STRING_6_COST, 1, 6, CollectionFilterFunc.EQUAL), new CostRequirement(GAME_STRING_7_COST, 1, 7, CollectionFilterFunc.GREATER_EQUAL) };
    private static readonly string GAME_STRING_1_COST = "GLUE_RDM_1_COST";
    private static readonly string GAME_STRING_2_COST = "GLUE_RDM_2_COST";
    private static readonly string GAME_STRING_3_COST = "GLUE_RDM_3_COST";
    private static readonly string GAME_STRING_4_COST = "GLUE_RDM_4_COST";
    private static readonly string GAME_STRING_5_COST = "GLUE_RDM_5_COST";
    private static readonly string GAME_STRING_6_COST = "GLUE_RDM_6_COST";
    private static readonly string GAME_STRING_7_COST = "GLUE_RDM_7_COST";
    private static readonly string GAME_STRING_CLASS_SPECIFIC = "GLUE_RDM_CLASS_SPECIFIC";
    private static readonly string GAME_STRING_MORE_MINIONS = "GLUE_RDM_MORE_MINIONS";
    private static readonly string GAME_STRING_MORE_SPELLS = "GLUE_RDM_MORE_SPELLS";
    private static readonly string GAME_STRING_NO_SPECIFICS = "GLUE_RDM_NO_SPECIFICS";
    private const int MINIMUM_NUMBER_OF_1_DROPS = 4;
    private const int MINIMUM_NUMBER_OF_2_DROPS = 4;
    private const int MINIMUM_NUMBER_OF_3_DROPS = 3;
    private const int MINIMUM_NUMBER_OF_4_DROPS = 2;
    private const int MINIMUM_NUMBER_OF_5_DROPS = 2;
    private const int MINIMUM_NUMBER_OF_6_DROPS = 1;
    private const int MINIMUM_NUMBER_OF_7_PLUS_DROPS = 1;
    private const int MINIMUM_NUMBER_OF_CLASS_CARDS = 12;
    private const int MINIMUM_NUMBER_OF_MINIONS = 15;
    private const int MINIMUM_NUMBER_OF_SPELLS = 8;

    public static RDM_Deck ConvertCollectionDeckToRDMDeck(CollectionDeck deck)
    {
        RDM_Deck deck2 = new RDM_Deck(DefLoader.Get().GetEntityDef(deck.HeroCardID));
        foreach (CollectionDeckSlot slot in deck.GetSlots())
        {
            EntityDef entityDef = DefLoader.Get().GetEntityDef(slot.CardID);
            CardFlair cardFlair = new CardFlair(slot.Premium);
            for (int i = 0; i < slot.Count; i++)
            {
                RDMDeckEntry item = new RDMDeckEntry(entityDef, cardFlair);
                deck2.deckList.Add(item);
            }
        }
        return deck2;
    }

    public static RDM_Deck FinishMyDeck(RDM_Deck currentDeck)
    {
        Log.Ben.Print("Finishing the Current Deck.");
        int num = 30 - currentDeck.deckList.Count;
        if (num > 0)
        {
            for (int i = 0; i < num; i++)
            {
                RandomDeckChoices choices = GetChoices(currentDeck, 1);
                if (choices.choices.Count <= 0)
                {
                    Debug.LogError("Tried to Finish this deck, but Brode's algorithm broke and couldn't do it.");
                    return currentDeck;
                }
                RDMDeckEntry entry = choices.choices[0];
                Log.Ben.Print(string.Format("{0} - {1} (flair {2})", choices.displayString, entry.EntityDef.GetDebugName(), entry.Flair));
                currentDeck.deckList.Add(choices.choices[0]);
            }
        }
        return currentDeck;
    }

    private static CollectionFilterSet GetCardsIOwnFilterSet()
    {
        CollectionFilterSet set = new CollectionFilterSet(true);
        set.AddAccountFilter(ACCOUNT_TAG.OWNED_COUNT, 1, CollectionFilterFunc.GREATER_EQUAL);
        return set;
    }

    public static RandomDeckChoices GetChoices(RDM_Deck currentDeck, int numChoicesRequired)
    {
        if (currentDeck.deckList.Count >= 30)
        {
            Debug.LogWarning("RandomDeckMaker.GetChoices(): Tried to get choices for a full deck!");
            return null;
        }
        int num = 0;
        foreach (RDMDeckEntry entry in currentDeck.deckList)
        {
            if (entry.EntityDef.GetClass() == currentDeck.classType)
            {
                num++;
            }
        }
        CollectionFilterSet cardsIOwnFilterSet = GetCardsIOwnFilterSet();
        RandomDeckChoices returnChoices = new RandomDeckChoices();
        returnChoices.Clear();
        if (num < 12)
        {
            cardsIOwnFilterSet.RemoveAllGameFilters();
            cardsIOwnFilterSet.AddGameFilter(GAME_TAG.CLASS, currentDeck.classType, CollectionFilterFunc.EQUAL);
            List<FilteredArtStack> newChoiceOptions = cardsIOwnFilterSet.GenerateList();
            returnChoices.displayString = GameStrings.Get(GAME_STRING_CLASS_SPECIFIC);
            for (int k = 0; k < numChoicesRequired; k++)
            {
                RDMDeckEntry item = GetValidChoiceForDeck(newChoiceOptions, returnChoices.choices, currentDeck);
                if (item != null)
                {
                    returnChoices.choices.Add(item);
                }
            }
            if (returnChoices.choices.Count == numChoicesRequired)
            {
                return returnChoices;
            }
        }
        returnChoices.Clear();
        Dictionary<int, List<RDMDeckEntry>> deckCardsByManaCost = new Dictionary<int, List<RDMDeckEntry>>();
        foreach (RDMDeckEntry entry3 in currentDeck.deckList)
        {
            int key = Mathf.Clamp(entry3.EntityDef.GetCost(), 1, 7);
            if (!deckCardsByManaCost.ContainsKey(key))
            {
                deckCardsByManaCost.Add(key, new List<RDMDeckEntry>());
            }
            deckCardsByManaCost[key].Add(entry3);
        }
        for (int i = 0; i < COST_REQUIREMENTS.Length; i++)
        {
            if (GetChoicesByCost(COST_REQUIREMENTS[i], numChoicesRequired, currentDeck, deckCardsByManaCost, ref returnChoices))
            {
                return returnChoices;
            }
        }
        int num5 = 0;
        int num6 = 0;
        foreach (RDMDeckEntry entry4 in currentDeck.deckList)
        {
            if (entry4.EntityDef.IsSpell())
            {
                num5++;
            }
            if (entry4.EntityDef.IsMinion())
            {
                num6++;
            }
        }
        returnChoices.Clear();
        if (num5 < 8)
        {
            cardsIOwnFilterSet.RemoveAllGameFilters();
            cardsIOwnFilterSet.AddGameFilter(GAME_TAG.CARDTYPE, TAG_CARDTYPE.ABILITY, CollectionFilterFunc.EQUAL);
            List<FilteredArtStack> list2 = cardsIOwnFilterSet.GenerateList();
            returnChoices.displayString = GameStrings.Get(GAME_STRING_MORE_SPELLS);
            for (int m = 0; m < numChoicesRequired; m++)
            {
                RDMDeckEntry entry5 = GetValidChoiceForDeck(list2, returnChoices.choices, currentDeck);
                if (entry5 != null)
                {
                    returnChoices.choices.Add(entry5);
                }
            }
            if (returnChoices.choices.Count == numChoicesRequired)
            {
                return returnChoices;
            }
        }
        returnChoices.Clear();
        if (num6 < 15)
        {
            cardsIOwnFilterSet.RemoveAllGameFilters();
            cardsIOwnFilterSet.AddGameFilter(GAME_TAG.CARDTYPE, TAG_CARDTYPE.MINION, CollectionFilterFunc.EQUAL);
            List<FilteredArtStack> list3 = cardsIOwnFilterSet.GenerateList();
            returnChoices.displayString = GameStrings.Get(GAME_STRING_MORE_MINIONS);
            for (int n = 0; n < numChoicesRequired; n++)
            {
                RDMDeckEntry entry6 = GetValidChoiceForDeck(list3, returnChoices.choices, currentDeck);
                if (entry6 != null)
                {
                    returnChoices.choices.Add(entry6);
                }
            }
            if (returnChoices.choices.Count == numChoicesRequired)
            {
                return returnChoices;
            }
        }
        returnChoices.Clear();
        returnChoices.displayString = GameStrings.Get(GAME_STRING_NO_SPECIFICS);
        for (int j = 0; j < numChoicesRequired; j++)
        {
            cardsIOwnFilterSet.RemoveAllGameFilters();
            RDMDeckEntry entry7 = GetValidChoiceForDeck(cardsIOwnFilterSet.GenerateList(), returnChoices.choices, currentDeck);
            if (entry7 != null)
            {
                returnChoices.choices.Add(entry7);
            }
        }
        return returnChoices;
    }

    private static bool GetChoicesByCost(CostRequirement costRequirement, int numChoicesRequired, RDM_Deck currentDeck, Dictionary<int, List<RDMDeckEntry>> deckCardsByManaCost, ref RandomDeckChoices returnChoices)
    {
        int costFilterValue = costRequirement.m_costFilterValue;
        List<RDMDeckEntry> list = !deckCardsByManaCost.ContainsKey(costFilterValue) ? null : deckCardsByManaCost[costFilterValue];
        int num2 = (list != null) ? list.Count : 0;
        if (num2 < costRequirement.m_minNumCards)
        {
            returnChoices.Clear();
            returnChoices.displayString = GameStrings.Get(costRequirement.m_displayStringKey);
            CollectionFilterSet cardsIOwnFilterSet = GetCardsIOwnFilterSet();
            cardsIOwnFilterSet.AddGameFilter(GAME_TAG.COST, costFilterValue, costRequirement.m_costFilterFunc);
            List<FilteredArtStack> newChoiceOptions = cardsIOwnFilterSet.GenerateList();
            for (int i = 0; i < numChoicesRequired; i++)
            {
                RDMDeckEntry item = GetValidChoiceForDeck(newChoiceOptions, returnChoices.choices, currentDeck);
                if (item != null)
                {
                    returnChoices.choices.Add(item);
                }
            }
            if (returnChoices.choices.Count >= numChoicesRequired)
            {
                return true;
            }
            returnChoices.Clear();
        }
        return false;
    }

    private static RDMDeckEntry GetValidChoiceForDeck(List<FilteredArtStack> newChoiceOptions, List<RDMDeckEntry> currentChoices, RDM_Deck currentDeck)
    {
        List<RDMDeckEntry> list = new List<RDMDeckEntry>();
        foreach (FilteredArtStack stack in newChoiceOptions)
        {
            <GetValidChoiceForDeck>c__AnonStorey143 storey = new <GetValidChoiceForDeck>c__AnonStorey143 {
                entityDef = DefLoader.Get().GetEntityDef(stack.CardID)
            };
            TAG_CLASS tag_class = storey.entityDef.GetClass();
            if (((tag_class == currentDeck.classType) || (tag_class == TAG_CLASS.NONE)) && (currentChoices.Find(new Predicate<RDMDeckEntry>(storey.<>m__55)) == null))
            {
                List<RDMDeckEntry> list2 = currentDeck.deckList.FindAll(new Predicate<RDMDeckEntry>(storey.<>m__56));
                int num = !storey.entityDef.IsElite() ? 2 : 1;
                if (list2.Count < num)
                {
                    int num2 = 0;
                    foreach (RDMDeckEntry entry2 in list2)
                    {
                        if (entry2.Flair.Equals(stack.Flair))
                        {
                            num2++;
                        }
                    }
                    if (num2 < stack.Count)
                    {
                        RDMDeckEntry item = new RDMDeckEntry(storey.entityDef, stack.Flair);
                        list.Add(item);
                    }
                }
            }
        }
        if (list.Count == 0)
        {
            return null;
        }
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    [CompilerGenerated]
    private sealed class <GetValidChoiceForDeck>c__AnonStorey143
    {
        internal EntityDef entityDef;

        internal bool <>m__55(RDMDeckEntry otherDeckEntry)
        {
            return otherDeckEntry.EntityDef.GetCardId().Equals(this.entityDef.GetCardId());
        }

        internal bool <>m__56(RDMDeckEntry otherDeckEntry)
        {
            return otherDeckEntry.EntityDef.GetCardId().Equals(this.entityDef.GetCardId());
        }
    }

    private class CostRequirement
    {
        public CollectionFilterFunc m_costFilterFunc;
        public int m_costFilterValue;
        public string m_displayStringKey;
        public int m_minNumCards;

        public CostRequirement(string stringKey, int minNumberOfCards, int costFilterValue, CollectionFilterFunc costFilterFunc)
        {
            this.m_displayStringKey = stringKey;
            this.m_minNumCards = minNumberOfCards;
            this.m_costFilterValue = costFilterValue;
            this.m_costFilterFunc = costFilterFunc;
        }
    }
}


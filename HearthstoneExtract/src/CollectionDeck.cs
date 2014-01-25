using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class CollectionDeck
{
    private string m_heroCardId;
    private long m_id;
    private bool m_isDraftDeck;
    private bool m_isValid;
    private string m_name;
    private bool m_netContentsLoaded;
    private List<CollectionDeckSlot> m_slots = new List<CollectionDeckSlot>();

    public bool AddCard(string cardID, CardFlair.PremiumType premium)
    {
        if (!this.CanInsertCard(cardID))
        {
            return false;
        }
        CollectionDeckSlot slot = this.FindSlotByCardIdAndPremium(cardID, premium);
        if (slot != null)
        {
            slot.Count++;
            return true;
        }
        int firstUnusedHandle = this.GetFirstUnusedHandle();
        CollectionDeckSlot slot2 = new CollectionDeckSlot {
            Handle = firstUnusedHandle,
            CardID = cardID,
            Count = 1,
            Premium = premium
        };
        slot = slot2;
        this.InsertSlotByDefaultSort(slot);
        return true;
    }

    private bool CanInsertCard(string cardID)
    {
        if (this.m_isDraftDeck)
        {
            return true;
        }
        EntityDef entityDef = DefLoader.Get().GetEntityDef(cardID);
        EntityDef def2 = DefLoader.Get().GetEntityDef(this.HeroCardID);
        TAG_CLASS tag_class = entityDef.GetClass();
        TAG_CLASS tag_class2 = def2.GetClass();
        if ((tag_class != TAG_CLASS.NONE) && (tag_class != tag_class2))
        {
            Debug.LogWarning(string.Format("Cannot insert {0} (class {1}) into deck with hero class {2}", entityDef.GetName(), tag_class, tag_class2));
            return false;
        }
        return (this.GetCardIdCount(cardID) < 2);
    }

    public void ClearSlotContents()
    {
        this.m_slots.Clear();
    }

    public void CopyFrom(CollectionDeck otherDeck)
    {
        this.m_id = otherDeck.m_id;
        this.m_name = otherDeck.m_name;
        this.m_heroCardId = otherDeck.m_heroCardId;
        this.m_isValid = otherDeck.m_isValid;
        this.m_slots.Clear();
        for (int i = 0; i < otherDeck.GetSlotCount(); i++)
        {
            CollectionDeckSlot slotByIndex = otherDeck.GetSlotByIndex(i);
            CollectionDeckSlot item = new CollectionDeckSlot();
            item.CopyFrom(slotByIndex);
            this.m_slots.Add(item);
        }
    }

    private CollectionDeckSlot FindSlotByCardIdAndPremium(string cardID, CardFlair.PremiumType premium)
    {
        <FindSlotByCardIdAndPremium>c__AnonStorey127 storey = new <FindSlotByCardIdAndPremium>c__AnonStorey127 {
            cardID = cardID,
            premium = premium
        };
        return this.m_slots.Find(new Predicate<CollectionDeckSlot>(storey.<>m__16));
    }

    private void GenerateAddedAndUpdatedDiff(CollectionDeck baseDeck, out List<Network.CardUserData> addedSlots, out List<Network.CardUserData> updatedSlots)
    {
        addedSlots = new List<Network.CardUserData>();
        updatedSlots = new List<Network.CardUserData>();
        foreach (CollectionDeckSlot slot in this.m_slots)
        {
            CardManifest.Card card = CardManifest.Get().Find(slot.CardID);
            if (card == null)
            {
                Debug.LogError(string.Format("CollectionDeck.GenerateAddedAndUpdatedDiff(): Could not find card with ID {0} in our card manifest", slot.CardID));
            }
            else
            {
                Network.CardUserData data;
                CollectionDeckSlot slotByHandle = baseDeck.GetSlotByHandle(slot.Handle);
                if (slotByHandle == null)
                {
                    data = new Network.CardUserData {
                        AssetID = card.DatabaseAssetID,
                        Handle = slot.Handle,
                        Count = slot.Count,
                        Premium = slot.Premium,
                        Prev = slot.PrevSlotHandle
                    };
                    addedSlots.Add(data);
                    continue;
                }
                if ((slot.PrevSlotHandle != slotByHandle.PrevSlotHandle) || slot.ContentsDiffer(slotByHandle))
                {
                    data = new Network.CardUserData {
                        AssetID = card.DatabaseAssetID,
                        Handle = slot.Handle,
                        Count = slot.Count,
                        Premium = slot.Premium,
                        Prev = slot.PrevSlotHandle
                    };
                    updatedSlots.Add(data);
                }
            }
        }
    }

    private void GenerateNameDiff(CollectionDeck baseDeck, out string deckName)
    {
        deckName = null;
        if (!this.Name.Equals(baseDeck.Name))
        {
            deckName = this.Name;
        }
    }

    private void GenerateRemovedDiff(CollectionDeck baseDeck, out List<Network.CardUserData> deletedSlots)
    {
        deletedSlots = new List<Network.CardUserData>();
        foreach (CollectionDeckSlot slot in baseDeck.GetSlots())
        {
            if (this.GetSlotByHandle(slot.Handle) == null)
            {
                CardManifest.Card card = CardManifest.Get().Find(slot.CardID);
                Network.CardUserData item = new Network.CardUserData {
                    AssetID = card.DatabaseAssetID,
                    Handle = slot.Handle,
                    Count = 0,
                    Premium = slot.Premium
                };
                deletedSlots.Add(item);
            }
        }
    }

    public int GetCardCount(string cardID, CardFlair flair)
    {
        CollectionDeckSlot slot = this.FindSlotByCardIdAndPremium(cardID, flair.Premium);
        return ((slot != null) ? slot.Count : 0);
    }

    public int GetCardIdCount(string cardID)
    {
        int num = 0;
        foreach (CollectionDeckSlot slot in this.m_slots)
        {
            if (slot.CardID.Equals(cardID))
            {
                num += slot.Count;
            }
        }
        return num;
    }

    private int GetFirstUnusedHandle()
    {
        int handle = 1;
        while (this.GetSlotByHandle(handle) != null)
        {
            handle++;
        }
        return handle;
    }

    private int GetInsertionIdxByDefaultSort(CollectionDeckSlot slot)
    {
        EntityDef entityDef = DefLoader.Get().GetEntityDef(slot.CardID);
        if (entityDef == null)
        {
            Log.Rachelle.Print(string.Format("CollectionDeck.GetInsertionIdxByDefaultSort(): could not get entity def for {0}", slot.CardID));
            return -1;
        }
        int slotIndex = 0;
        while (slotIndex < this.GetSlotCount())
        {
            CollectionDeckSlot slotByIndex = this.GetSlotByIndex(slotIndex);
            EntityDef def2 = DefLoader.Get().GetEntityDef(slotByIndex.CardID);
            if (def2 == null)
            {
                Log.Rachelle.Print(string.Format("CollectionDeck.GetInsertionIdxByDefaultSort(): entityDef is null at slot index {0}", slotIndex));
                return slotIndex;
            }
            int num2 = entityDef.CompareTo(def2);
            if (num2 < 0)
            {
                return slotIndex;
            }
            if ((num2 <= 0) && (slot.Premium <= slotByIndex.Premium))
            {
                return slotIndex;
            }
            slotIndex++;
        }
        return slotIndex;
    }

    private int GetInsertionIdxByPrevHandle(CollectionDeckSlot slot)
    {
        int num = 0;
        if (slot.PrevSlotHandle == 0)
        {
            return num;
        }
        CollectionDeckSlot slotByHandle = this.GetSlotByHandle(slot.PrevSlotHandle);
        if (slotByHandle == null)
        {
            Log.Rachelle.Print(string.Format("CollectionDeck.GetInsertionIdxByPrevHandle(): could not find previous slot with handle {0} in  deck {1}!", slot.PrevSlotHandle, this.ID));
            return -1;
        }
        return (slotByHandle.Index + 1);
    }

    public CollectionDeckSlot GetSlotByHandle(int handle)
    {
        <GetSlotByHandle>c__AnonStorey126 storey = new <GetSlotByHandle>c__AnonStorey126 {
            handle = handle
        };
        return this.m_slots.Find(new Predicate<CollectionDeckSlot>(storey.<>m__15));
    }

    public CollectionDeckSlot GetSlotByIndex(int slotIndex)
    {
        if ((slotIndex >= 0) && (slotIndex < this.GetSlotCount()))
        {
            return this.m_slots[slotIndex];
        }
        return null;
    }

    public int GetSlotCount()
    {
        return this.m_slots.Count;
    }

    public List<CollectionDeckSlot> GetSlots()
    {
        return this.m_slots;
    }

    public int GetSortedInsertionIndex(string cardID, CardFlair.PremiumType premium, out bool slotAlreadyExists)
    {
        slotAlreadyExists = false;
        if (!this.CanInsertCard(cardID))
        {
            return -1;
        }
        CollectionDeckSlot slot = this.FindSlotByCardIdAndPremium(cardID, premium);
        if (slot != null)
        {
            slotAlreadyExists = true;
            return slot.Index;
        }
        CollectionDeckSlot slot2 = new CollectionDeckSlot {
            CardID = cardID,
            Premium = premium
        };
        slot = slot2;
        return this.GetInsertionIdxByDefaultSort(slot);
    }

    public int GetTotalCardCount()
    {
        int num = 0;
        foreach (CollectionDeckSlot slot in this.m_slots)
        {
            num += slot.Count;
        }
        return num;
    }

    private bool InsertSlot(int slotIndex, CollectionDeckSlot slot)
    {
        if ((slotIndex < 0) || (slotIndex > this.GetSlotCount()))
        {
            Log.Rachelle.Print(string.Format("CollectionDeck.InsertSlot(): inserting slot {0} failed; invalid slot index {1}.", slot, slotIndex));
            return false;
        }
        if (this.GetSlotByHandle(slot.Handle) != null)
        {
            Log.Rachelle.Print(string.Format("CollectionDeck.InsertSlot(): slot with handle {0} already exists in deck {1}!", slot.Handle, this.ID));
            return false;
        }
        slot.OnSlotEmptied = (CollectionDeckSlot.DelOnSlotEmptied) Delegate.Combine(slot.OnSlotEmptied, new CollectionDeckSlot.DelOnSlotEmptied(this.OnSlotEmptied));
        slot.Index = slotIndex;
        this.m_slots.Insert(slotIndex, slot);
        this.UpdateSlotIndicesAndPrevHandles(slotIndex, this.GetSlotCount() - 1);
        return true;
    }

    public bool InsertSlotByDefaultSort(CollectionDeckSlot slot)
    {
        return this.InsertSlot(this.GetInsertionIdxByDefaultSort(slot), slot);
    }

    public bool InsertSlotByPrevHandle(CollectionDeckSlot slot)
    {
        return this.InsertSlot(this.GetInsertionIdxByPrevHandle(slot), slot);
    }

    public void MarkAsDraftDeck()
    {
        this.m_isDraftDeck = true;
    }

    public void MarkNetworkContentsLoaded()
    {
        this.m_netContentsLoaded = true;
    }

    private void MoveSlot(CollectionDeckSlot slot, int targetSlotIndex)
    {
        int index = slot.Index;
        this.m_slots.RemoveAt(index);
        this.m_slots.Insert(targetSlotIndex, slot);
        this.UpdateSlotIndicesAndPrevHandles(index, targetSlotIndex);
    }

    public bool MoveSlot(int sourceSlotIndex, int targetSlotIndex)
    {
        if ((sourceSlotIndex < 0) || (sourceSlotIndex > this.GetSlotCount()))
        {
            Debug.LogError(string.Format("CollectionDeck.MoveSlot() - source slot {0} is not a valid slot for {1}", sourceSlotIndex, this));
            return false;
        }
        if ((targetSlotIndex < 0) || (targetSlotIndex > this.GetSlotCount()))
        {
            Debug.LogError(string.Format("CollectionDeck.MoveSlot() - target slot {0} is not a valid slot for {1}", targetSlotIndex, this));
            return false;
        }
        CollectionDeckSlot slotByIndex = this.GetSlotByIndex(sourceSlotIndex);
        this.MoveSlot(slotByIndex, targetSlotIndex);
        return true;
    }

    public bool NetworkContentsLoaded()
    {
        return this.m_netContentsLoaded;
    }

    private void OnSlotEmptied(CollectionDeckSlot slot)
    {
        if (this.GetSlotByHandle(slot.Handle) == null)
        {
            Log.Rachelle.Print(string.Format("CollectionDeck.OnSlotCountUpdated(): Trying to remove slot {0}, but it does not exist in deck {1}", slot, this));
        }
        else
        {
            this.RemoveSlot(slot);
        }
    }

    public bool RemoveCard(string cardID, CardFlair.PremiumType premium)
    {
        CollectionDeckSlot slot = this.FindSlotByCardIdAndPremium(cardID, premium);
        if (slot == null)
        {
            return false;
        }
        slot.Count--;
        return true;
    }

    private void RemoveSlot(CollectionDeckSlot slot)
    {
        slot.OnSlotEmptied = (CollectionDeckSlot.DelOnSlotEmptied) Delegate.Remove(slot.OnSlotEmptied, new CollectionDeckSlot.DelOnSlotEmptied(this.OnSlotEmptied));
        int index = slot.Index;
        this.m_slots.RemoveAt(index);
        this.UpdateSlotIndicesAndPrevHandles(index, this.GetSlotCount() - 1);
    }

    public void SendChanges()
    {
        CollectionDeck baseDeck = CollectionManager.Get().GetBaseDeck(this.m_id);
        if (this == baseDeck)
        {
            Debug.LogError(string.Format("CollectionDeck.Send() - {0} is a base deck. You cannot send a base deck to the network.", baseDeck));
        }
        else
        {
            string str;
            List<Network.CardUserData> list;
            List<Network.CardUserData> list2;
            List<Network.CardUserData> list3;
            this.GenerateNameDiff(baseDeck, out str);
            this.GenerateAddedAndUpdatedDiff(baseDeck, out list, out list2);
            this.GenerateRemovedDiff(baseDeck, out list3);
            List<Network.CardUserData> cards = new List<Network.CardUserData>();
            cards.AddRange(list);
            cards.AddRange(list2);
            cards.AddRange(list3);
            Network network = Network.Get();
            if (str != null)
            {
                network.RenameDeck(this.m_id, str);
            }
            if (cards.Count > 0)
            {
                network.SetDeckContents(this.m_id, cards);
            }
        }
    }

    public override string ToString()
    {
        object[] args = new object[] { this.ID, this.Name, this.HeroCardID, this.GetSlotCount() };
        return string.Format("Deck [id={0} name=\"{1}\" heroCardId=\"{2}\" slotCount={3}]", args);
    }

    private void UpdateSlotIndicesAndPrevHandles(int indexA, int indexB)
    {
        if (this.GetSlotCount() != 0)
        {
            int num;
            int num2;
            if (indexA < indexB)
            {
                num = indexA;
                num2 = indexB;
            }
            else
            {
                num = indexB;
                num2 = indexA;
            }
            num = Math.Max(0, num);
            num2 = Math.Min(num2, this.GetSlotCount() - 1);
            int handle = (num <= 0) ? 0 : this.GetSlotByIndex(num - 1).Handle;
            for (int i = num; i <= num2; i++)
            {
                CollectionDeckSlot slotByIndex = this.GetSlotByIndex(i);
                slotByIndex.Index = i;
                slotByIndex.PrevSlotHandle = handle;
                handle = slotByIndex.Handle;
            }
        }
    }

    public string HeroCardID
    {
        get
        {
            return this.m_heroCardId;
        }
        set
        {
            this.m_heroCardId = value;
        }
    }

    public long ID
    {
        get
        {
            return this.m_id;
        }
        set
        {
            this.m_id = value;
        }
    }

    public bool IsTourneyValid
    {
        get
        {
            return this.m_isValid;
        }
        set
        {
            this.m_isValid = value;
        }
    }

    public string Name
    {
        get
        {
            return this.m_name;
        }
        set
        {
            if (value == null)
            {
                Debug.LogError(string.Format("CollectionDeck.SetName() - null name given for deck {0}", this));
            }
            else if (!value.Equals(this.m_name, StringComparison.InvariantCultureIgnoreCase))
            {
                this.m_name = value;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <FindSlotByCardIdAndPremium>c__AnonStorey127
    {
        internal string cardID;
        internal CardFlair.PremiumType premium;

        internal bool <>m__16(CollectionDeckSlot slot)
        {
            return (slot.CardID.Equals(this.cardID) && (slot.Premium == this.premium));
        }
    }

    [CompilerGenerated]
    private sealed class <GetSlotByHandle>c__AnonStorey126
    {
        internal int handle;

        internal bool <>m__15(CollectionDeckSlot slot)
        {
            return (slot.Handle == this.handle);
        }
    }
}


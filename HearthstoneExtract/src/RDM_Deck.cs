using System;
using System.Collections.Generic;

public class RDM_Deck
{
    public TAG_CLASS classType;
    public List<RDMDeckEntry> deckList = new List<RDMDeckEntry>();
    public EntityDef heroCard;

    public RDM_Deck(EntityDef hero)
    {
        this.heroCard = hero;
        this.classType = hero.GetClass();
    }

    public void DebugPrintDeck()
    {
        foreach (RDMDeckEntry entry in this.deckList)
        {
            Log.Ben.Print(string.Format("Choice: {0} (flair {1})", entry.EntityDef.GetDebugName(), entry.Flair));
        }
    }

    public List<int> GetDeckListForServer()
    {
        List<int> list = new List<int>();
        CardManifest.Card card = CardManifest.Get().Find(this.heroCard.GetCardId());
        list.Add(card.DatabaseAssetID);
        foreach (RDMDeckEntry entry in this.deckList)
        {
            CardManifest.Card card2 = CardManifest.Get().Find(entry.EntityDef.GetCardId());
            list.Add(card2.DatabaseAssetID);
        }
        return list;
    }
}


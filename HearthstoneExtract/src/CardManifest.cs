using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

internal class CardManifest
{
    private Dictionary<int, Card> m_assetIdToCardMap = new Dictionary<int, Card>();
    private Dictionary<string, Card> m_cardIdToCardMap = new Dictionary<string, Card>();
    private static CardManifest s_cardManifest;
    private static string s_cardManifestFilePath = FileUtils.GetAssetPath("manifest-cards.csv");

    private CardManifest()
    {
    }

    public List<Card> AllCollectibles()
    {
        List<Card> list = new List<Card>();
        foreach (KeyValuePair<int, Card> pair in this.m_assetIdToCardMap)
        {
            if (pair.Value.Collectible)
            {
                list.Add(pair.Value);
            }
        }
        return list;
    }

    public List<Card> CollectibleCards()
    {
        List<Card> list = new List<Card>();
        foreach (KeyValuePair<int, Card> pair in this.m_assetIdToCardMap)
        {
            if ((pair.Value.CardType != TAG_CARDTYPE.HERO) && pair.Value.Collectible)
            {
                list.Add(pair.Value);
            }
        }
        return list;
    }

    public List<Card> CollectibleHeroes()
    {
        List<Card> list = new List<Card>();
        foreach (KeyValuePair<int, Card> pair in this.m_assetIdToCardMap)
        {
            if ((pair.Value.CardType == TAG_CARDTYPE.HERO) && pair.Value.Collectible)
            {
                list.Add(pair.Value);
            }
        }
        return list;
    }

    public Card Find(int databaseID)
    {
        if (this.m_assetIdToCardMap.ContainsKey(databaseID))
        {
            return this.m_assetIdToCardMap[databaseID];
        }
        return null;
    }

    public Card Find(string cardID)
    {
        if (this.m_cardIdToCardMap.ContainsKey(cardID))
        {
            return this.m_cardIdToCardMap[cardID];
        }
        return null;
    }

    public static CardManifest Get()
    {
        if (s_cardManifest == null)
        {
            s_cardManifest = new CardManifest();
            s_cardManifest.Load();
        }
        return s_cardManifest;
    }

    private void Load()
    {
        string path = s_cardManifestFilePath;
        int num = 0;
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string str2;
                while ((str2 = reader.ReadLine()) != null)
                {
                    num++;
                    if (!string.IsNullOrEmpty(str2))
                    {
                        char[] separator = new char[] { ',' };
                        string[] strArray = str2.Split(separator);
                        Card card2 = new Card {
                            DatabaseAssetID = Convert.ToInt32(strArray[0]),
                            CardID = strArray[1],
                            Collectible = strArray[2].Equals("1"),
                            CardType = (TAG_CARDTYPE) Convert.ToInt32(strArray[3])
                        };
                        Card card = card2;
                        this.m_assetIdToCardMap.Add(card.DatabaseAssetID, card);
                        this.m_cardIdToCardMap.Add(card.CardID, card);
                    }
                }
            }
        }
        catch (FileNotFoundException exception)
        {
            throw new ApplicationException(string.Format("Failed to find card manifest at '{0}': {1}", path, exception.Message));
        }
        catch (IOException exception2)
        {
            throw new ApplicationException(string.Format("Failed to read card manifest at '{0}': {1}", path, exception2.Message));
        }
        catch (NullReferenceException exception3)
        {
            throw new ApplicationException(string.Format("Failed to read from card manifest '{0}' line {1}: {2}", path, num, exception3.Message));
        }
        catch (Exception exception4)
        {
            throw new ApplicationException(string.Format("An unknown error occurred loading card manifest '{0}' line {1}: {2}", path, num, exception4.Message));
        }
    }

    public class Card
    {
        public string CardID { get; set; }

        public TAG_CARDTYPE CardType { get; set; }

        public bool Collectible { get; set; }

        public int DatabaseAssetID { get; set; }
    }
}


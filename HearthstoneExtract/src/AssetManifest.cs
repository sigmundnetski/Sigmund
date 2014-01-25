using System;
using System.Collections.Generic;

public class AssetManifest
{
    private Dictionary<string, CardManifestItem> m_cardMap = new Dictionary<string, CardManifestItem>();
    private static AssetManifest s_instance;

    private void CreateCardItem(string cardId, int latestVersion)
    {
        CardManifestItem item = new CardManifestItem();
        item.SetCardId(cardId);
        item.SetLatestVersion(latestVersion);
        this.m_cardMap.Add(cardId, item);
    }

    public static AssetManifest Get()
    {
        if (s_instance == null)
        {
            s_instance = new AssetManifest();
            s_instance.OnManifestDownloaded();
        }
        return s_instance;
    }

    public Dictionary<string, CardManifestItem> GetAllCardItems()
    {
        return this.m_cardMap;
    }

    public void OnManifestDownloaded()
    {
        this.CreateCardItem("EX1_134", 1);
        this.CreateCardItem("CS2_231", 1);
        this.CreateCardItem("EX1_133", 1);
        this.CreateCardItem("CS2_075", 1);
        this.CreateCardItem("CS2_072", 1);
        this.CreateCardItem("EX1_129", 1);
        this.CreateCardItem("EX1_613", 1);
        this.CreateCardItem("NEW1_030", 1);
        this.CreateCardItem("CS2_080", 1);
        this.CreateCardItem("CS2_077", 1);
        this.CreateCardItem("EX1_522", 1);
        this.CreateCardItem("NEW1_016", 1);
        this.CreateCardItem("CS1_042", 1);
        this.CreateCardItem("CS1_069", 1);
        this.CreateCardItem("CS1_112", 1);
        this.CreateCardItem("CS2_114", 1);
    }
}


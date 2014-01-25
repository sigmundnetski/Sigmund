using System;

public class CardManifestItem
{
    private string m_cardId;
    private int m_latestVersion;

    public string GetCardId()
    {
        return this.m_cardId;
    }

    public int GetLatestVersion()
    {
        return this.m_latestVersion;
    }

    public void SetCardId(string cardId)
    {
        this.m_cardId = cardId;
    }

    public void SetLatestVersion(int version)
    {
        this.m_latestVersion = version;
    }
}


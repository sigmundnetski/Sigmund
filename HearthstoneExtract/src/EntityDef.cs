using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using UnityEngine;

public class EntityDef : EntityBase, IComparable
{
    private string m_cardId;
    private List<string> m_entourageCardIDs = new List<string>();
    private string m_masterPower = string.Empty;
    private List<PowerHistoryInfo> m_powerHistoryInfoList = new List<PowerHistoryInfo>();
    private Dictionary<string, Power> m_powers = new Dictionary<string, Power>();

    public EntityDef Clone()
    {
        EntityDef def = new EntityDef();
        def.GetTagSet().Replace(base.m_tags);
        def.GetReferencedTagSet().Replace(base.m_referenceTags);
        foreach (KeyValuePair<int, string> pair in base.m_stringTags)
        {
            def.m_stringTags.Add(pair.Key, pair.Value);
        }
        foreach (KeyValuePair<string, Power> pair2 in this.m_powers)
        {
            def.m_powers.Add(pair2.Key, pair2.Value);
        }
        def.m_cardId = this.m_cardId;
        def.m_masterPower = this.m_masterPower;
        return def;
    }

    public int CompareTo(object obj)
    {
        if (!(obj is EntityDef))
        {
            throw new ArgumentException("Object is not an EntityDef");
        }
        EntityDef def = obj as EntityDef;
        int cost = base.GetCost();
        int num2 = def.GetCost();
        if (cost != num2)
        {
            return (cost - num2);
        }
        int cardTypeSortOrder = this.GetCardTypeSortOrder();
        int num4 = def.GetCardTypeSortOrder();
        if (cardTypeSortOrder != num4)
        {
            return (cardTypeSortOrder - num4);
        }
        return this.GetName().CompareTo(def.GetName());
    }

    public string GetArtistName()
    {
        string stringTag = base.GetStringTag(GAME_TAG.ARTISTNAME);
        if (stringTag == null)
        {
            return "ERROR: NO ARTIST NAME";
        }
        return stringTag;
    }

    public Power GetAttackPower()
    {
        return Power.GetDefaultAttackPower();
    }

    public string GetCardId()
    {
        return this.m_cardId;
    }

    public string GetCardTextInHand()
    {
        StringBuilder buf = new StringBuilder();
        TextUtils.TransformCardText(this, GAME_TAG.CARDTEXT_INHAND, ref buf);
        return buf.ToString();
    }

    private int GetCardTypeSortOrder()
    {
        switch (base.GetCardType())
        {
            case TAG_CARDTYPE.MINION:
                return 3;

            case TAG_CARDTYPE.ABILITY:
                return 2;

            case TAG_CARDTYPE.WEAPON:
                return 1;
        }
        return 0;
    }

    public TAG_CLASS GetClass()
    {
        return base.GetTag<TAG_CLASS>(GAME_TAG.CLASS);
    }

    public string GetDebugName()
    {
        string stringTag = base.GetStringTag(GAME_TAG.CARDNAME);
        if (stringTag != null)
        {
            return string.Format("[name={0} cardId={1} type={2}]", stringTag, this.m_cardId, base.GetCardType());
        }
        if (this.m_cardId != null)
        {
            return string.Format("[cardId={0} type={1}]", this.m_cardId, base.GetCardType());
        }
        return string.Format("UNKNOWN ENTITY [cardType={0}]", base.GetCardType());
    }

    public TAG_ENCHANTMENT_VISUAL GetEnchantmentBirthVisual()
    {
        return base.GetTag<TAG_ENCHANTMENT_VISUAL>(GAME_TAG.ENCHANTMENT_BIRTH_VISUAL);
    }

    public TAG_ENCHANTMENT_VISUAL GetEnchantmentIdleVisual()
    {
        return base.GetTag<TAG_ENCHANTMENT_VISUAL>(GAME_TAG.ENCHANTMENT_IDLE_VISUAL);
    }

    public List<string> GetEntourageCardIDs()
    {
        return this.m_entourageCardIDs;
    }

    public string GetFlavorText()
    {
        string stringTag = base.GetStringTag(GAME_TAG.FLAVORTEXT);
        if (stringTag == null)
        {
            return string.Empty;
        }
        return stringTag;
    }

    public Power GetMasterPower()
    {
        if (!this.m_masterPower.Equals(string.Empty) && this.m_powers.ContainsKey(this.m_masterPower))
        {
            return this.m_powers[this.m_masterPower];
        }
        return Power.GetDefaultMasterPower();
    }

    public string GetName()
    {
        string stringTag = base.GetStringTag(GAME_TAG.CARDNAME);
        if (stringTag != null)
        {
            return stringTag;
        }
        return this.GetDebugName();
    }

    public PowerHistoryInfo GetPowerHistoryInfo(int effectIndex)
    {
        if (effectIndex < 0)
        {
            return null;
        }
        foreach (PowerHistoryInfo info2 in this.m_powerHistoryInfoList)
        {
            if (info2.GetEffectIndex() == effectIndex)
            {
                return info2;
            }
        }
        return null;
    }

    public TAG_RACE GetRace()
    {
        return base.GetTag<TAG_RACE>(GAME_TAG.CARDRACE);
    }

    public string GetRaceText()
    {
        if (!base.HasTag(GAME_TAG.CARDRACE))
        {
            return string.Empty;
        }
        return GameStrings.GetRaceName(this.GetRace());
    }

    public TAG_RARITY GetRarity()
    {
        return base.GetTag<TAG_RARITY>(GAME_TAG.RARITY);
    }

    public override int GetReferencedTag(int tag)
    {
        return base.m_referenceTags.GetTag(tag);
    }

    public override string GetStringTag(int tag)
    {
        string str;
        base.m_stringTags.TryGetValue(tag, out str);
        return str;
    }

    public static XmlElement LoadCardXmlFromAsset(string cardId, UnityEngine.Object asset)
    {
        if (asset == null)
        {
            Debug.LogWarning(string.Format("EntityDef.LoadCardXmlFromAsset() - null cardAsset given for cardId \"{0}\"", cardId));
            return null;
        }
        TextAsset asset2 = asset as TextAsset;
        if (asset2 == null)
        {
            Debug.LogWarning(string.Format("EntityDef.LoadCardXmlFromAsset() - asset for cardId \"{0}\" was not a card xml", cardId));
            return null;
        }
        return XmlUtils.LoadXmlDocFromTextAsset(asset2)["Entity"];
    }

    public void LoadDataFromCardXml(XmlElement rootElement)
    {
        if (rootElement != null)
        {
            this.LoadTagsFromCardXml(rootElement);
            this.LoadReferenceTagsFromCardXml(rootElement);
            this.LoadPowersFromCardXml(rootElement);
            this.m_powerHistoryInfoList = PowerHistoryInfo.LoadFromXml(rootElement);
            this.LoadEntourageCardIDsFromCardXml(rootElement);
        }
    }

    private void LoadEntourageCardIDsFromCardXml(XmlElement rootElement)
    {
        IEnumerator enumerator = rootElement.GetElementsByTagName("EntourageCard").GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                XmlNode current = (XmlNode) enumerator.Current;
                XmlElement element = (XmlElement) current;
                XmlAttribute attribute = element.Attributes["cardID"];
                this.m_entourageCardIDs.Add(attribute.Value);
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

    private void LoadPowersFromCardXml(XmlElement rootElement)
    {
        XmlNodeList elementsByTagName = rootElement.GetElementsByTagName("MasterPower");
        if (elementsByTagName.Count > 0)
        {
            if (elementsByTagName.Count > 1)
            {
                Log.Rachelle.Print(string.Format("Found multiple master powers ({0}!) for card {1}! Using the first one...", elementsByTagName.Count, this.m_cardId));
            }
            this.m_masterPower = TextUtils.PostProcessText(elementsByTagName[0].InnerText);
        }
        XPathNavigator navigator = rootElement.CreateNavigator();
        XPathExpression expr = navigator.Compile("./Power");
        XPathNodeIterator iterator = navigator.Select(expr);
        while (iterator.MoveNext())
        {
            XmlElement node = (XmlElement) ((IHasXmlNode) iterator.Current).GetNode();
            Power power = Power.LoadFromXml(node);
            if (this.m_powers.ContainsKey(power.GetDefinition()))
            {
                Log.Rachelle.Print(string.Format("Entity {0} already contains power definition {1}", this.GetName(), power.GetDefinition()));
            }
            else
            {
                this.m_powers.Add(power.GetDefinition(), power);
            }
        }
    }

    private void LoadReferenceTagsFromCardXml(XmlElement rootElement)
    {
        if (rootElement != null)
        {
            base.m_referenceTags.Clear();
            IEnumerator enumerator = rootElement.GetElementsByTagName("ReferencedTag").GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    XmlNode current = (XmlNode) enumerator.Current;
                    XmlElement element = (XmlElement) current;
                    XmlAttribute attribute = element.Attributes["enumID"];
                    int tag = Convert.ToInt32(attribute.Value);
                    XmlAttribute attribute2 = element.Attributes["value"];
                    int val = Convert.ToInt32(attribute2.Value);
                    base.SetReferencedTag(tag, val);
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

    private void LoadTagsFromCardXml(XmlElement rootElement)
    {
        if (rootElement != null)
        {
            base.m_tags.Clear();
            base.m_stringTags.Clear();
            XmlAttribute attribute = rootElement.Attributes["CardID"];
            this.m_cardId = attribute.Value;
            IEnumerator enumerator = rootElement.GetElementsByTagName("Tag").GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    XmlNode current = (XmlNode) enumerator.Current;
                    XmlElement element = (XmlElement) current;
                    XmlAttribute attribute2 = element.Attributes["enumID"];
                    int tag = Convert.ToInt32(attribute2.Value);
                    XmlAttribute attribute3 = element.Attributes["type"];
                    if (attribute3.Value.Equals("String"))
                    {
                        XmlElement element2 = current[Localization.GetLocaleName()];
                        if (element2 == null)
                        {
                            element2 = current[Localization.DEFAULT_LOCALE_NAME];
                        }
                        base.m_stringTags[tag] = TextUtils.PostProcessText(element2.InnerText);
                    }
                    else
                    {
                        XmlAttribute attribute4 = element.Attributes["value"];
                        int tagValue = Convert.ToInt32(attribute4.Value);
                        base.SetTag(tag, tagValue);
                    }
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

    public void SetCardId(string cardId)
    {
        this.m_cardId = cardId;
    }

    public override string ToString()
    {
        return this.GetDebugName();
    }
}


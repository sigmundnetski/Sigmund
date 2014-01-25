using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class PowerHistoryInfo
{
    private int mEffectIndex = -1;
    private string mHistoryText;
    private bool mShowInHistory;

    public int GetEffectIndex()
    {
        return this.mEffectIndex;
    }

    public string GetHistoryText()
    {
        return this.mHistoryText;
    }

    public static List<PowerHistoryInfo> LoadFromXml(XmlElement rootElement)
    {
        List<PowerHistoryInfo> list = new List<PowerHistoryInfo>();
        IEnumerator enumerator = rootElement.GetElementsByTagName("TriggeredPowerHistoryInfo").GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                XmlNode current = (XmlNode) enumerator.Current;
                XmlElement element = (XmlElement) current;
                PowerHistoryInfo item = new PowerHistoryInfo();
                XmlAttribute attribute = element.Attributes["effectIndex"];
                item.mEffectIndex = Convert.ToInt32(attribute.Value);
                XmlAttribute attribute2 = element.Attributes["showInHistory"];
                item.mShowInHistory = Convert.ToBoolean(attribute2.Value);
                XmlNode node2 = current[Localization.GetLocaleName()];
                if (node2 != null)
                {
                    item.mHistoryText = TextUtils.PostProcessText(node2.InnerText);
                }
                list.Add(item);
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
        return list;
    }

    public bool ShouldShowInHistory()
    {
        return this.mShowInHistory;
    }
}


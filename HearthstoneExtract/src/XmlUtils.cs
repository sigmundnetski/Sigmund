using System;
using System.IO;
using System.Xml;
using UnityEngine;

public class XmlUtils
{
    public static string GenerateConcatForXPath(string a_xPathQueryString)
    {
        string str = string.Empty;
        string str2 = a_xPathQueryString;
        char[] anyOf = new char[] { '\'', '"' };
        int length = str2.IndexOfAny(anyOf);
        if (length == -1)
        {
            return ("'" + str2 + "'");
        }
        str = "concat(";
        while (length != -1)
        {
            string str3 = str2.Substring(0, length);
            str = str + "'" + str3 + "', ";
            if (str2.Substring(length, 1) == "'")
            {
                str = str + "\"'\", ";
            }
            else
            {
                str = str + "'\"', ";
            }
            str2 = str2.Substring(length + 1, (str2.Length - length) - 1);
            length = str2.IndexOfAny(anyOf);
        }
        return (str + "'" + str2 + "')");
    }

    public static XmlDocument LoadXmlDocFromTextAsset(TextAsset asset)
    {
        XmlDocument document = new XmlDocument();
        document.LoadXml(new StringReader(asset.text).ReadToEnd());
        return document;
    }
}


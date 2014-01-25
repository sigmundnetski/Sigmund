using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TextUtils
{
    private const int DEFAULT_STRING_BUILDER_CAPACITY_FUDGE = 10;

    public static string ComposeLineItemString(List<string> lines)
    {
        if (lines.Count == 0)
        {
            return string.Empty;
        }
        StringBuilder builder = new StringBuilder();
        foreach (string str in lines)
        {
            builder.AppendLine(str);
        }
        builder.Remove(builder.Length - 1, 1);
        return builder.ToString();
    }

    public static void HackAssignOutlineText(TextMesh originalMesh, string textToApply)
    {
        foreach (TextMesh mesh in originalMesh.gameObject.GetComponentsInChildren<TextMesh>(true))
        {
            if (mesh.gameObject.name.Equals("OutlineText", StringComparison.OrdinalIgnoreCase))
            {
                mesh.text = textToApply;
            }
        }
    }

    public static void HackAutoLineBreakBuffer(ref StringBuilder buf, int maxCharsPerLine)
    {
        int[] numArray1 = new int[] { maxCharsPerLine };
        HackAutoLineBreakBuffer(ref buf, numArray1);
    }

    public static void HackAutoLineBreakBuffer(ref StringBuilder buf, int[] maxCharsPerLine)
    {
        if ((((buf != null) && (buf.Length != 0)) && (maxCharsPerLine.Length != 0)) && (buf.Length > maxCharsPerLine[0]))
        {
            int index = 0;
            int num2 = maxCharsPerLine[0];
            int num3 = 0;
            for (int i = 0; i < buf.Length; i++)
            {
                char ch = buf[i];
                num3++;
                if (num3 >= num2)
                {
                    int startIndex = HackFindSafeAutoLineBreakPoint(buf, i);
                    if (buf[startIndex] == ' ')
                    {
                        buf.Remove(startIndex, 1);
                    }
                    buf.Insert(startIndex, '\n');
                    i = startIndex;
                    ch = '\n';
                }
                if (ch == '\n')
                {
                    num3 = 0;
                    index = Mathf.Min((int) (index + 1), (int) (maxCharsPerLine.Length - 1));
                    num2 = maxCharsPerLine[index];
                }
            }
        }
    }

    public static string HackAutoLineBreakText(string text, int maxCharsPerLine)
    {
        int[] numArray1 = new int[] { maxCharsPerLine };
        return HackAutoLineBreakText(text, numArray1);
    }

    public static string HackAutoLineBreakText(string text, int[] maxCharsPerLine)
    {
        StringBuilder buf = new StringBuilder(text, text.Length + 10);
        HackAutoLineBreakBuffer(ref buf, maxCharsPerLine);
        return buf.ToString();
    }

    private static int HackFindSafeAutoLineBreakPoint(StringBuilder buf, int currIndex)
    {
        for (int i = currIndex; i >= 0; i--)
        {
            switch (buf[i])
            {
                case '\n':
                    return currIndex;

                case ' ':
                    return i;
            }
        }
        return currIndex;
    }

    public static string PostProcessText(string text)
    {
        text = text.Replace(@"\n", "\n");
        text = text.Replace(@"\t", "\t");
        return text;
    }

    public static void TransformCardText(Entity entity, GAME_TAG textTag, ref StringBuilder buf)
    {
        TransformCardText(entity.GetController().GetCurrentSpellPower(), entity.GetStringTag(textTag), ref buf);
    }

    public static void TransformCardText(EntityDef entityDef, GAME_TAG textTag, ref StringBuilder buf)
    {
        TransformCardText(0, entityDef.GetStringTag(textTag), ref buf);
    }

    private static void TransformCardText(int spellPower, string powersText, ref StringBuilder buf)
    {
        if ((powersText != null) && (powersText != string.Empty))
        {
            bool flag = spellPower > 0;
            for (int i = 0; i < powersText.Length; i++)
            {
                char ch = powersText[i];
                if (ch != '$')
                {
                    buf.Append(ch);
                }
                else
                {
                    int num2 = ++i;
                    while (num2 < powersText.Length)
                    {
                        char ch2 = powersText[num2];
                        if ((ch2 < '0') || (ch2 > '9'))
                        {
                            break;
                        }
                        num2++;
                    }
                    if (num2 != i)
                    {
                        int num3 = Convert.ToInt32(powersText.Substring(i, num2 - i)) + spellPower;
                        if (flag)
                        {
                            buf.Append('*');
                            buf.Append(num3);
                            buf.Append('*');
                        }
                        else
                        {
                            buf.Append(num3);
                        }
                        i = num2 - 1;
                    }
                }
            }
        }
    }
}


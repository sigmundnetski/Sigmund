using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameStringTable
{
    private const string KEY_FIELD_NAME = "TAG";
    private GameStringCategory m_category;
    private Dictionary<string, string> m_table = new Dictionary<string, string>();
    private const string VALUE_FIELD_NAME = "TEXT";

    private void BuildTable(string path, List<Entry> entries)
    {
        int count = entries.Count;
        this.m_table = new Dictionary<string, string>(count);
        if (count != 0)
        {
            if (ApplicationMgr.IsInternal())
            {
                CheckConflicts(path, entries);
            }
            foreach (Entry entry in entries)
            {
                this.m_table[entry.m_key] = entry.m_value;
            }
        }
    }

    private void BuildTable(string path, List<Entry> entries, string audioPath, List<Entry> audioEntries)
    {
        int capacity = entries.Count + audioEntries.Count;
        this.m_table = new Dictionary<string, string>(capacity);
        if (capacity != 0)
        {
            if (ApplicationMgr.IsInternal())
            {
                CheckConflicts(path, entries, audioPath, audioEntries);
            }
            foreach (Entry entry in entries)
            {
                this.m_table[entry.m_key] = entry.m_value;
            }
            foreach (Entry entry2 in audioEntries)
            {
                this.m_table[entry2.m_key] = entry2.m_value;
            }
        }
    }

    private static void CheckConflicts(string path, List<Entry> entries)
    {
        if (entries.Count != 0)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                string key = entries[i].m_key;
                for (int j = i + 1; j < entries.Count; j++)
                {
                    string str2 = entries[j].m_key;
                    if (key.ToUpper() == str2.ToUpper())
                    {
                        string message = string.Format("GameStringTable.CheckConflicts() - Tag {0} appears more than once in {1}. All tags must be unique.", key, path);
                        Error.AddDevWarning("GameStrings Error", message, new object[0]);
                    }
                }
            }
        }
    }

    private static void CheckConflicts(string path1, List<Entry> entries1, string path2, List<Entry> entries2)
    {
        if (entries1.Count != 0)
        {
            CheckConflicts(path1, entries1);
            if (entries2.Count != 0)
            {
                CheckConflicts(path2, entries2);
                for (int i = 0; i < entries1.Count; i++)
                {
                    string key = entries1[i].m_key;
                    for (int j = 0; j < entries2.Count; j++)
                    {
                        string str2 = entries2[j].m_key;
                        if (key.ToUpper() == str2.ToUpper())
                        {
                            string message = string.Format("GameStringTable.CheckConflicts() - Tag {0} is used in {1} and {2}. All tags must be unique.", key, path1, path2);
                            Error.AddDevWarning("GameStrings Error", message, new object[0]);
                        }
                    }
                }
            }
        }
    }

    public string Get(string key)
    {
        string str;
        this.m_table.TryGetValue(key, out str);
        return str;
    }

    public Dictionary<string, string> GetAll()
    {
        return this.m_table;
    }

    private static string GetAudioFilePathFromCategory(GameStringCategory cat)
    {
        return FileUtils.GetAssetPath(string.Format("Strings/{0}/{1}_AUDIO.txt", Localization.GetLocaleName(), cat));
    }

    public GameStringCategory GetCategory()
    {
        return this.m_category;
    }

    private static string GetFilePathFromCategory(GameStringCategory cat)
    {
        return FileUtils.GetAssetPath(string.Format("Strings/{0}/{1}.txt", Localization.GetLocaleName(), cat));
    }

    public bool Load(GameStringCategory cat)
    {
        this.m_category = GameStringCategory.INVALID;
        this.m_table.Clear();
        string filePathFromCategory = GetFilePathFromCategory(cat);
        List<Entry> entries = LoadFile(filePathFromCategory, cat);
        if (entries == null)
        {
            Debug.LogWarning(string.Format("GameStringTable.Load() - Failed to load category {0}.", cat));
            return false;
        }
        string audioFilePathFromCategory = GetAudioFilePathFromCategory(cat);
        if (System.IO.File.Exists(audioFilePathFromCategory))
        {
            List<Entry> audioEntries = LoadFile(audioFilePathFromCategory, cat);
            if (audioEntries == null)
            {
                Debug.LogWarning(string.Format("GameStringTable.Load() - Failed to load audio lines for category {0}.", cat));
                return false;
            }
            this.BuildTable(filePathFromCategory, entries, audioFilePathFromCategory, audioEntries);
        }
        else
        {
            this.BuildTable(filePathFromCategory, entries);
        }
        this.m_category = cat;
        return true;
    }

    private static List<Entry> LoadFile(string path, GameStringCategory cat)
    {
        string[] lines = null;
        try
        {
            lines = System.IO.File.ReadAllLines(path);
        }
        catch (Exception exception)
        {
            object[] messageArgs = new object[] { path, cat, exception.Message };
            Error.AddDevWarning("GameStrings Error", "GameStringTable.LoadFile() - Failed to read \"{0}\" for category {1}.\n\nException: {2}", messageArgs);
            return null;
        }
        Header header = LoadFileHeader(lines);
        if (header == null)
        {
            object[] objArray2 = new object[] { path, cat };
            Error.AddDevWarning("GameStrings Error", "GameStringTable.LoadFile() - \"{0}\" for category {1} had a malformed header.", objArray2);
            return null;
        }
        return LoadFileEntries(path, header, lines);
    }

    private static List<Entry> LoadFileEntries(string path, Header header, string[] lines)
    {
        List<Entry> list = new List<Entry>(lines.Length);
        int num = Mathf.Max(header.m_keyIndex, header.m_valueIndex);
        for (int i = header.m_entryStartIndex; i < lines.Length; i++)
        {
            string str = lines[i];
            if (str.Length != 0)
            {
                char[] separator = new char[] { '\t' };
                string[] strArray = str.Split(separator);
                if (strArray.Length <= num)
                {
                    object[] messageArgs = new object[] { i + 1, path };
                    Error.AddDevWarning("GameStrings Error", "GameStringTable.LoadFileEntries() - line {0} in \"{1}\" is malformed", messageArgs);
                }
                else
                {
                    Entry item = new Entry {
                        m_key = strArray[header.m_keyIndex],
                        m_value = TextUtils.PostProcessText(strArray[header.m_valueIndex])
                    };
                    list.Add(item);
                }
            }
        }
        return list;
    }

    private static Header LoadFileHeader(string[] lines)
    {
        Header header = new Header();
        for (int i = 0; i < lines.Length; i++)
        {
            string str = lines[i];
            if ((str.Length == 0) || str.StartsWith("#"))
            {
                continue;
            }
            char[] separator = new char[] { '\t' };
            string[] strArray = str.Split(separator);
            for (int j = 0; j < strArray.Length; j++)
            {
                switch (strArray[j])
                {
                    case "TAG":
                        header.m_keyIndex = j;
                        if (header.m_valueIndex < 0)
                        {
                            break;
                        }
                        goto Label_00BF;

                    case "TEXT":
                        header.m_valueIndex = j;
                        if (header.m_keyIndex >= 0)
                        {
                            goto Label_00BF;
                        }
                        break;
                }
            }
        Label_00BF:
            if ((header.m_keyIndex < 0) && (header.m_valueIndex < 0))
            {
                return null;
            }
            header.m_entryStartIndex = i + 1;
            return header;
        }
        return null;
    }

    private class Entry
    {
        public string m_key;
        public string m_value;
    }

    private class Header
    {
        public int m_entryStartIndex = -1;
        public int m_keyIndex = -1;
        public int m_valueIndex = -1;
    }
}


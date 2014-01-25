using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

public class LocalOptions
{
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map7;
    private static readonly TypedDictionary<bool> m_bools = new TypedDictionary<bool>();
    private static readonly TypedDictionary<double> m_doubles = new TypedDictionary<double>();
    private static readonly TypedDictionary<int> m_ints = new TypedDictionary<int>();
    private static readonly TypedDictionary<string> m_strings = new TypedDictionary<string>();

    public static void Clear()
    {
        m_bools.Clear();
        m_ints.Clear();
        m_doubles.Clear();
        m_strings.Clear();
    }

    public static void Delete(Option option)
    {
        Delete(EnumUtils.GetString<Option>(option));
    }

    public static void Delete(string key)
    {
        if (m_bools.HasKey(key))
        {
            m_bools.Delete(key);
        }
        else if (m_ints.HasKey(key))
        {
            m_ints.Delete(key);
        }
        else if (m_doubles.HasKey(key))
        {
            m_doubles.Delete(key);
        }
        else if (m_strings.HasKey(key))
        {
            m_strings.Delete(key);
        }
    }

    public static bool GetBool(Option option)
    {
        return GetBool(EnumUtils.GetString<Option>(option));
    }

    public static bool GetBool(string key)
    {
        return m_bools.Get(key);
    }

    public static double GetDouble(string key)
    {
        return m_doubles.Get(key);
    }

    public static float GetFloat(Option option)
    {
        return (float) GetDouble(EnumUtils.GetString<Option>(option));
    }

    public static int GetInt(Option option)
    {
        return GetInt(EnumUtils.GetString<Option>(option));
    }

    public static int GetInt(string key)
    {
        return m_ints.Get(key);
    }

    public static string GetString(Option option)
    {
        return GetString(EnumUtils.GetString<Option>(option));
    }

    public static string GetString(string key)
    {
        return m_strings.Get(key);
    }

    public static bool HasKey(string key)
    {
        return (((m_bools.HasKey(key) || m_ints.HasKey(key)) || m_doubles.HasKey(key)) || m_strings.HasKey(key));
    }

    public static bool HasOption(Option option)
    {
        return HasKey(EnumUtils.GetString<Option>(option));
    }

    public static void Initialize()
    {
        Load();
    }

    private static bool Load()
    {
        string[] strArray = new string[0];
        try
        {
            strArray = System.IO.File.ReadAllLines(optionsPath);
        }
        catch (IsolatedStorageException)
        {
        }
        catch (ArgumentNullException)
        {
        }
        catch (ArgumentException)
        {
        }
        catch (PathTooLongException)
        {
        }
        catch (DirectoryNotFoundException)
        {
        }
        catch (FileNotFoundException)
        {
        }
        catch (IOException)
        {
            return false;
        }
        catch (NotSupportedException)
        {
        }
        catch (SecurityException)
        {
        }
        Regex regex = new Regex(@"^(?<key>[^\:]+):(?<type>[bids])=(?<value>.*)$");
        Clear();
        foreach (string str in strArray)
        {
            IEnumerator enumerator = regex.Matches(str).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Match current = (Match) enumerator.Current;
                    GroupCollection groups = current.Groups;
                    string key = groups["type"].Value;
                    if (key != null)
                    {
                        int num2;
                        if (<>f__switch$map7 == null)
                        {
                            Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
                            dictionary.Add("b", 0);
                            dictionary.Add("i", 1);
                            dictionary.Add("d", 2);
                            dictionary.Add("s", 3);
                            <>f__switch$map7 = dictionary;
                        }
                        if (<>f__switch$map7.TryGetValue(key, out num2))
                        {
                            switch (num2)
                            {
                                case 0:
                                    m_bools.Set(groups["key"].Value, Convert.ToBoolean(groups["value"].Value));
                                    break;

                                case 1:
                                    m_ints.Set(groups["key"].Value, Convert.ToInt32(groups["value"].Value));
                                    break;

                                case 2:
                                    m_doubles.Set(groups["key"].Value, Convert.ToDouble(groups["value"].Value));
                                    break;

                                case 3:
                                    m_strings.Set(groups["key"].Value, groups["value"].Value);
                                    break;
                            }
                        }
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
        return true;
    }

    private static bool Save()
    {
        if (!dirty)
        {
            return true;
        }
        List<string> list = new List<string>();
        foreach (string str in m_bools.Keys)
        {
            list.Add(string.Format("{0}:b={1}", str, m_bools[str]));
        }
        foreach (string str2 in m_ints.Keys)
        {
            list.Add(string.Format("{0}:i={1}", str2, m_ints[str2]));
        }
        foreach (string str3 in m_doubles.Keys)
        {
            list.Add(string.Format("{0}:d={1}", str3, m_doubles[str3]));
        }
        foreach (string str4 in m_strings.Keys)
        {
            list.Add(string.Format("{0}:s={1}", str4, m_strings[str4]));
        }
        try
        {
            System.IO.File.WriteAllLines(optionsPath, list.ToArray(), new UTF8Encoding());
            dirty = false;
            return true;
        }
        catch (IsolatedStorageException)
        {
        }
        catch (ArgumentNullException)
        {
        }
        catch (ArgumentException)
        {
        }
        catch (PathTooLongException)
        {
        }
        catch (DirectoryNotFoundException)
        {
        }
        catch (FileNotFoundException)
        {
        }
        catch (IOException)
        {
            return false;
        }
        catch (UnauthorizedAccessException)
        {
        }
        catch (NotSupportedException)
        {
        }
        catch (SecurityException)
        {
        }
        return false;
    }

    public static void Set(Option option, bool val)
    {
        Set(EnumUtils.GetString<Option>(option), val);
    }

    public static void Set(Option option, double val)
    {
        Set(EnumUtils.GetString<Option>(option), val);
    }

    public static void Set(Option option, int val)
    {
        Set(EnumUtils.GetString<Option>(option), val);
    }

    public static void Set(Option option, string val)
    {
        Set(EnumUtils.GetString<Option>(option), val);
    }

    public static void Set(string key, bool value)
    {
        m_bools.Set(key, value);
        Save();
    }

    public static void Set(string key, double value)
    {
        m_doubles.Set(key, value);
        Save();
    }

    public static void Set(string key, int value)
    {
        m_ints.Set(key, value);
        Save();
    }

    public static void Set(string key, string value)
    {
        m_strings.Set(key, value);
        Save();
    }

    private static bool dirty
    {
        get
        {
            return (((m_bools.Dirty || m_ints.Dirty) || m_doubles.Dirty) || m_strings.Dirty);
        }
        set
        {
            bool flag = value;
            m_strings.Dirty = flag;
            flag = flag;
            m_doubles.Dirty = flag;
            flag = flag;
            m_ints.Dirty = flag;
            m_bools.Dirty = flag;
        }
    }

    private static string optionsFolder
    {
        get
        {
            return FileUtils.GetPersistentDataPath();
        }
    }

    private static string optionsPath
    {
        get
        {
            object[] args = new object[] { optionsFolder, "options.txt" };
            return Blizzard.Path.combine(args);
        }
    }
}


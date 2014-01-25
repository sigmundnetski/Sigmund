using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

public class StreamingManifest
{
    private readonly Dictionary<string, string> assets = new Dictionary<string, string>(0x7d0);
    public static readonly string BuildPath;
    public const string Name = "manifest.txt";
    public static readonly string Path;

    static StreamingManifest()
    {
        object[] args = new object[] { "Data", "cache", "manifest.txt" };
        Path = Blizzard.Path.combine(args);
        object[] objArray2 = new object[] { "Final", "Data", "cache", "manifest.txt" };
        BuildPath = Blizzard.Path.combine(objArray2);
    }

    private StreamingManifest()
    {
        this.Valid = false;
    }

    public static bool Build(DirectoryInfo root)
    {
        // This item is obfuscated and can not be translated.
        using (Blizzard.Time.ScopedTimer.Create("Creating streaming manifest", "Finished streaming manifest"))
        {
            List<FileInfo> results = new List<FileInfo>();
            Blizzard.File.SearchFoldersForExtension(root, "unity3d", ref results);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (FileInfo info in results)
            {
                try
                {
                    dictionary.Add(info.FullName, Blizzard.Crypto.SHA1.Calc(info.FullName));
                    continue;
                }
                catch (Exception exception)
                {
                    throw new StreamingException(string.Format("Unknown exception hashing '{0}': {1}", info.FullName, exception.Message));
                }
            }
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str = null;
                try
                {
                    string str2 = pair.Value;
                    object[] objArray1 = new object[] { "Final", "Data/cache/", str2[0], str2 };
                    str = Blizzard.Path.combine(objArray1);
                    if (!System.IO.File.Exists(str))
                    {
                        object[] objArray2 = new object[] { pair.Value, pair.Key };
                        Blizzard.Log.Write("Creating blob '{0}' for asset '{1}'", objArray2);
                        Directory.CreateDirectory(System.IO.Path.GetDirectoryName(str));
                        System.IO.File.Copy(pair.Key, str);
                    }
                    continue;
                }
                catch (Exception exception2)
                {
                    if (str == null)
                    {
                        throw new StreamingException(string.Format("Unknown exception caching '{0}' to '{1}': {2}", pair.Key, "--", exception2.Message));
                    }
                    goto Label_0161;
                }
            }
            try
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(BuildPath));
            }
            catch (UnauthorizedAccessException exception3)
            {
                throw new StreamingException(string.Format("Cannot access '{0}': {1}", BuildPath, exception3.Message));
            }
            catch (Exception exception4)
            {
                throw new StreamingException(string.Format("Unknown error creating directory for '{0}': {1}", BuildPath, exception4.Message));
            }
            using (StreamWriter writer = new StreamWriter(BuildPath))
            {
                foreach (KeyValuePair<string, string> pair2 in dictionary)
                {
                    string str3 = ExtractPathBelowFinalFolder(pair2.Key).Replace(@"\", "/");
                    writer.WriteLine(string.Format("{0};{1}", pair2.Value, str3));
                }
            }
            string str4 = Blizzard.Crypto.SHA1.Calc(BuildPath);
            using (StreamWriter writer2 = System.IO.File.AppendText(BuildPath))
            {
                writer2.WriteLine(str4);
            }
            object[] args = new object[] { BuildPath };
            StreamingLog.Say("Wrote manifest to '{0}'", args);
            string path = BuildPath.Replace("manifest.txt", "project-properties.txt");
            using (StreamWriter writer3 = new StreamWriter(path))
            {
                writer3.WriteLine("live=" + str4);
            }
            object[] objArray4 = new object[] { path };
            StreamingLog.Say("Wrote project properties to '{0}'", objArray4);
        }
        return true;
    }

    public static StreamingManifest Create(byte[] contents)
    {
        string str;
        string str2;
        if (contents.Length < 0x2a)
        {
            return null;
        }
        int count = (contents.Length - 40) - 2;
        try
        {
            str = Blizzard.Crypto.SHA1.Calc(contents, 0, count);
            str2 = Encoding.UTF8.GetString(Slice<byte>(contents, count, 40));
        }
        catch (Exception exception)
        {
            object[] args = new object[] { exception.Message };
            StreamingLog.Say("Hashing exception: {0}", args);
            return null;
        }
        if (!str.ToLower().Equals(str2.ToLower()))
        {
            object[] objArray2 = new object[] { str.ToLower(), str2.ToLower() };
            StreamingLog.Say("Invalid manifest hash\n\tComputed={0}\n\tEmbedded={1}", objArray2);
            return null;
        }
        StreamingManifest manifest = new StreamingManifest();
        foreach (string str3 in Regex.Split(Encoding.UTF8.GetString(contents), "\r\n|\r|\n"))
        {
            manifest.ParseAndAdd(str3);
        }
        manifest.Hash = str;
        manifest.Valid = true;
        return manifest;
    }

    private static string ExtractPathBelowFinalFolder(string path)
    {
        int startIndex = path.LastIndexOf("Final", StringComparison.Ordinal);
        if (startIndex == -1)
        {
            throw new ApplicationException("Cannot find Final path in " + path);
        }
        startIndex += "Final".Length;
        startIndex += @"\".Length;
        return path.Substring(startIndex);
    }

    public static StreamingManifest Load(string path)
    {
        byte[] contents = null;
        try
        {
            contents = System.IO.File.ReadAllBytes(path);
        }
        catch (ArgumentException exception)
        {
            object[] args = new object[] { exception.Message };
            StreamingLog.Say("Manifest load failed (1): {0}", args);
            return null;
        }
        catch (PathTooLongException exception2)
        {
            object[] objArray2 = new object[] { exception2.Message };
            StreamingLog.Say("Manifest load failed (2): {0}", objArray2);
            return null;
        }
        catch (FileNotFoundException exception3)
        {
            object[] objArray3 = new object[] { exception3.Message };
            StreamingLog.Say("Manifest load failed (3): {0}", objArray3);
            return null;
        }
        catch (DirectoryNotFoundException exception4)
        {
            object[] objArray4 = new object[] { exception4.Message };
            StreamingLog.Say("Manifest load failed (4): {0}", objArray4);
            return null;
        }
        catch (IOException exception5)
        {
            object[] objArray5 = new object[] { exception5.Message };
            StreamingLog.Say("Manifest load failed (5): {0}", objArray5);
            return null;
        }
        catch (NotSupportedException exception6)
        {
            object[] objArray6 = new object[] { exception6.Message };
            StreamingLog.Say("Manifest load failed (6): {0}", objArray6);
            return null;
        }
        catch (SecurityException exception7)
        {
            object[] objArray7 = new object[] { exception7.Message };
            StreamingLog.Say("Manifest load failed (7): {0}", objArray7);
            return null;
        }
        catch (Exception exception8)
        {
            object[] objArray8 = new object[] { exception8.Message };
            StreamingLog.Say("Manifest load failed (8).  Unknown error: {0}", objArray8);
            return null;
        }
        if (contents == null)
        {
            throw new StreamingException("Unable to read manifest file");
        }
        StreamingManifest manifest = Create(contents);
        if (manifest == null)
        {
            StreamingLog.Say("Invalid local manifest", new object[0]);
        }
        return manifest;
    }

    public string Lookup(string path)
    {
        string str;
        return (!this.assets.TryGetValue(path, out str) ? null : str);
    }

    private bool ParseAndAdd(string line)
    {
        char[] separator = new char[] { ';' };
        string[] strArray = line.Split(separator);
        if (strArray.Length != 2)
        {
            return false;
        }
        string str = strArray[0];
        string key = strArray[1];
        this.assets.Add(key, str);
        return true;
    }

    public void Save()
    {
        string directoryName = System.IO.Path.GetDirectoryName(Path);
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }
        using (StreamWriter writer = new StreamWriter(Path))
        {
            Dictionary<string, string> assets = this.assets;
            lock (assets)
            {
                foreach (KeyValuePair<string, string> pair in this.assets)
                {
                    writer.Write(pair.Value);
                    writer.Write(";");
                    writer.WriteLine(pair.Key);
                }
            }
        }
        string str2 = Blizzard.Crypto.SHA1.Calc(Path);
        using (StreamWriter writer2 = System.IO.File.AppendText(Path))
        {
            writer2.WriteLine(str2);
        }
    }

    private static T[] Slice<T>(T[] source, int start, int count)
    {
        T[] localArray = new T[count];
        for (int i = 0; i < count; i++)
        {
            localArray[i] = source[start + i];
        }
        return localArray;
    }

    public string Hash { get; private set; }

    public bool Valid { get; private set; }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class Asset
{
    private static readonly Dictionary<AssetFamily, AssetFamilyPathInfo> paths;

    static Asset()
    {
        Dictionary<AssetFamily, AssetFamilyPathInfo> dictionary = new Dictionary<AssetFamily, AssetFamilyPathInfo>();
        AssetFamilyPathInfo info = new AssetFamilyPathInfo {
            path = "Data/Actors/{0}.unity3d",
            dir = "Assets/Game/Actors"
        };
        info.exts = new string[] { "prefab" };
        dictionary.Add(AssetFamily.Actor, info);
        info = new AssetFamilyPathInfo {
            path = "Data/Cards/{0}_xml.unity3d",
            dir = "Assets/Game/Cards"
        };
        info.exts = new string[] { "xml" };
        dictionary.Add(AssetFamily.CardXML, info);
        info = new AssetFamilyPathInfo {
            path = "Data/Cards/{0}_prefab.unity3d",
            dir = "Assets/Game/Cards"
        };
        info.exts = new string[] { "prefab" };
        dictionary.Add(AssetFamily.CardPrefab, info);
        info = new AssetFamilyPathInfo {
            path = "Data/Boards/{0}.unity3d",
            dir = "Assets/Game/Boards"
        };
        info.exts = new string[] { "prefab" };
        dictionary.Add(AssetFamily.Board, info);
        info = new AssetFamilyPathInfo {
            path = "Data/Sounds/{0}.unity3d",
            dir = "Assets/Game/Sounds"
        };
        info.exts = new string[] { "prefab" };
        dictionary.Add(AssetFamily.Sound, info);
        info = new AssetFamilyPathInfo {
            path = "Data/Textures/{0}.unity3d",
            dir = "Assets/Game/Textures"
        };
        info.exts = new string[] { "psd" };
        dictionary.Add(AssetFamily.Texture, info);
        info = new AssetFamilyPathInfo {
            path = "Data/UIScreens/{0}.unity3d",
            dir = "Assets/Game/UIScreens"
        };
        info.exts = new string[] { "prefab" };
        dictionary.Add(AssetFamily.Screen, info);
        info = new AssetFamilyPathInfo {
            path = "Data/Spells/{0}.unity3d",
            dir = string.Empty
        };
        info.exts = new string[] { "prefab" };
        dictionary.Add(AssetFamily.Spell, info);
        info = new AssetFamilyPathInfo {
            path = "Data/GameObjects/{0}.unity3d",
            dir = "Assets/Game/GameObjects"
        };
        info.exts = new string[] { "prefab" };
        dictionary.Add(AssetFamily.GameObject, info);
        info = new AssetFamilyPathInfo {
            path = "Data/Movies/{0}.unity3d",
            dir = "Assets/Game/Movies"
        };
        info.exts = new string[] { "ogv" };
        dictionary.Add(AssetFamily.Movie, info);
        paths = dictionary;
    }

    private Asset(string name, AssetFamily family, bool persistent)
    {
        this.Name = name;
        this.Family = family;
        this.Persistent = persistent;
    }

    public static Asset Create(string assetName, AssetFamily family)
    {
        return Create(assetName, family, false);
    }

    public static Asset Create(string assetName, AssetFamily family, bool persistent)
    {
        Asset asset = new Asset(assetName, family, persistent);
        try
        {
            asset.EditorPath = string.Format(paths[family].path, assetName);
        }
        catch (IndexOutOfRangeException exception)
        {
            throw new ApplicationException(string.Format("Unknown asset family {0}: {1}", family, exception.Message));
        }
        return asset;
    }

    [DebuggerHidden]
    public IEnumerator Download()
    {
        return new <Download>c__Iterator10E();
    }

    public IEnumerator Load(out byte[] contents)
    {
        contents = null;
        return null;
    }

    [DebuggerHidden]
    public IEnumerator Save(byte[] bytes)
    {
        return new <Save>c__Iterator10F { bytes = bytes, <$>bytes = bytes, <>f__this = this };
    }

    public string CachePath
    {
        get
        {
            string hash = this.Hash;
            if (hash == null)
            {
                object[] args = new object[] { this.EditorPath };
                Log.Asset.ScreenPrint("StreamingAsset.CachePath() - Streaming.Manifest.Lookup() returned null for EditorPath={0}", args);
                return null;
            }
            return string.Format("{0}/{1}", hash[0], hash);
        }
    }

    public string Directory
    {
        get
        {
            return paths[this.Family].dir;
        }
    }

    public string EditorPath { get; private set; }

    public string[] Extensions
    {
        get
        {
            return paths[this.Family].exts;
        }
    }

    public AssetFamily Family { get; private set; }

    public string FileURL
    {
        get
        {
            string cachePath = this.CachePath;
            if (cachePath == null)
            {
                return null;
            }
            return string.Format("file://{0}/{1}{2}", ApplicationMgr.Get().GetWorkingDir(), "Data/cache/", cachePath);
        }
    }

    public string Hash
    {
        get
        {
            return Streaming.Manifest.Lookup(this.EditorPath);
        }
    }

    public bool IsLocal
    {
        get
        {
            if (!Streaming.Enabled)
            {
                return true;
            }
            try
            {
                return System.IO.File.Exists(System.IO.Path.Combine("Data/cache/", this.CachePath));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public bool IsLocalizedVersionLocal
    {
        get
        {
            if (!Streaming.Enabled)
            {
                return true;
            }
            try
            {
                return System.IO.File.Exists(System.IO.Path.Combine("Data/cache/", this.LocalizedCachePath));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public string LocalizedCachePath
    {
        get
        {
            string localizedEditorPath = this.LocalizedEditorPath;
            string str2 = Streaming.Manifest.Lookup(localizedEditorPath);
            if (str2 == null)
            {
                object[] args = new object[] { this.EditorPath };
                Log.Asset.ScreenPrint("StreamingAsset.CachePath() - Streaming.Manifest.Lookup() returned null for EditorPath={0}", args);
                return null;
            }
            return string.Format("{0}/{1}", str2[0], str2);
        }
    }

    public string LocalizedEditorPath
    {
        get
        {
            return FileUtils.MakeLocalizedPathFromSourcePath(Localization.GetLocale(), this.EditorPath);
        }
    }

    public string LocalizedFileURL
    {
        get
        {
            string localizedCachePath = this.LocalizedCachePath;
            if (localizedCachePath == null)
            {
                return null;
            }
            return string.Format("file://{0}/{1}{2}", ApplicationMgr.Get().GetWorkingDir(), "Data/cache/", localizedCachePath);
        }
    }

    public string LocalizedHash
    {
        get
        {
            return Streaming.Manifest.Lookup(this.LocalizedEditorPath);
        }
    }

    public string LocalizedURL
    {
        get
        {
            string localizedCachePath = this.LocalizedCachePath;
            if (localizedCachePath == null)
            {
                return null;
            }
            return (Streaming.FileServerCacheRoot + localizedCachePath);
        }
    }

    public string Name { get; private set; }

    public bool Persistent { get; private set; }

    public string URL
    {
        get
        {
            string cachePath = this.CachePath;
            if (cachePath == null)
            {
                return null;
            }
            return (Streaming.FileServerCacheRoot + cachePath);
        }
    }

    [CompilerGenerated]
    private sealed class <Download>c__Iterator10E : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if (this.$PC == 0)
            {
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <Save>c__Iterator10F : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal byte[] <$>bytes;
        internal Asset <>f__this;
        internal Exception <ex>__1;
        internal string <targetPath>__0;
        internal byte[] bytes;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if ((this.$PC == 0) && !this.<>f__this.IsLocal)
            {
                this.<targetPath>__0 = "Data/cache/" + this.<>f__this.CachePath;
                try
                {
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(this.<targetPath>__0));
                    System.IO.File.WriteAllBytes(this.<targetPath>__0, this.bytes);
                    StreamingLog.LogAssetSaved(this.<>f__this);
                }
                catch (Exception exception)
                {
                    this.<ex>__1 = exception;
                    StreamingLog.LogAssetSaveFailed(this.<>f__this, this.<ex>__1.Message);
                }
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    private class AssetFamilyPathInfo
    {
        public string dir;
        public string[] exts;
        public string path;
    }
}


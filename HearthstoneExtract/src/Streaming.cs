using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;

public class Streaming : MonoBehaviour
{
    public const string CacheRoot = "Data/cache/";
    private static int inInitializeComplete_;
    private static AsyncState liveManifestHashRequest_;
    private static AsyncState liveManifestRequest_;
    private static AsyncState localManifestRequest_;
    private static StreamingManifest manifest_;
    private static bool reportedLiveManifestHashReady;
    private static bool reportedLiveManifestReady;
    private static bool reportedLocalManifestReady;

    public void Awake()
    {
        Instance = this;
    }

    [DebuggerHidden]
    public static IEnumerator Initialize()
    {
        return new <Initialize>c__Iterator10A();
    }

    private static void InitializeComplete()
    {
        if (!Ready && (Interlocked.CompareExchange(ref inInitializeComplete_, 1, 0) != 1))
        {
            try
            {
                if (localManifestRequest_ == AsyncState.Ready)
                {
                    if (!reportedLocalManifestReady)
                    {
                        StreamingLog.Say("Local manifest READY", new object[0]);
                        reportedLocalManifestReady = true;
                    }
                    if (liveManifestHashRequest_ == AsyncState.Ready)
                    {
                        if (!reportedLiveManifestHashReady)
                        {
                            StreamingLog.Say("Live manifest hash READY", new object[0]);
                            reportedLiveManifestHashReady = true;
                        }
                        if (liveManifestRequest_ == AsyncState.Ready)
                        {
                            if (!reportedLiveManifestReady)
                            {
                                StreamingLog.Say("Live manifest READY", new object[0]);
                                reportedLiveManifestReady = true;
                            }
                            if ((Manifest == null) || !LiveManifestHash.Equals(Manifest.Hash))
                            {
                                localManifestRequest_ = AsyncState.Blocking;
                                RequestLiveManifest(liveManifestURL);
                            }
                            else
                            {
                                Ready = true;
                                StreamingLog.Say("Local manifest is current", new object[0]);
                                AssetLoader.Get().SetReady(true);
                            }
                        }
                    }
                }
            }
            finally
            {
                inInitializeComplete_ = 0;
            }
        }
    }

    private static bool LoadConfig()
    {
        string assetPath = FileUtils.GetAssetPath("streaming.config");
        try
        {
            string str2 = null;
            string str3 = null;
            foreach (string str4 in System.IO.File.ReadAllLines(assetPath))
            {
                if (!str4.StartsWith("#"))
                {
                    if (str4.StartsWith("server="))
                    {
                        char[] separator = new char[] { '=' };
                        str2 = str4.Split(separator)[1];
                    }
                    else if (str4.StartsWith("config="))
                    {
                        char[] chArray2 = new char[] { '=' };
                        str3 = str4.Split(chArray2)[1];
                    }
                }
            }
            FileServerRoot = !string.IsNullOrEmpty(str2) ? str2 : "http://streaming-t5/streaming-t5/pegasus/";
            FileServerCacheRoot = FileServerRoot + (!string.IsNullOrEmpty(str3) ? str3 : "live") + "/cache/";
            ProjectPropertiesURL = System.IO.Path.Combine(FileServerCacheRoot, "project-properties.txt");
            return true;
        }
        catch (Exception exception)
        {
            object[] args = new object[] { Environment.CurrentDirectory, assetPath };
            string message = string.Format("Failed to load streaming configuration from '{0}': {1}", Blizzard.Path.combine(args), exception.Message);
            Error.AddDevFatal("Internal Streaming Error", message, new object[0]);
            StreamingLog.Say(message, new object[0]);
            return false;
        }
    }

    public void OnDestroy()
    {
        StreamingLog.Stop();
    }

    private static void RequestLiveManifest(string url)
    {
        liveManifestRequest_ = AsyncState.Blocking;
        object[] args = new object[] { liveManifestURL };
        StreamingLog.Say("Requesting live manifest from '{0}'", args);
        WWW file = new WWW(url);
        Instance.StartCoroutine(WaitForLiveManifest(file));
    }

    private static void RequestLiveManifestHash(string url)
    {
        liveManifestHashRequest_ = AsyncState.Blocking;
        object[] args = new object[] { url };
        StreamingLog.Say("Requesting live manifest hash from '{0}'", args);
        WWW file = new WWW(url);
        Instance.StartCoroutine(WaitForLiveManifestHash(file));
    }

    [DebuggerHidden]
    public static IEnumerator SaveAsset(Asset asset, byte[] bytes)
    {
        return new <SaveAsset>c__Iterator10D { asset = asset, bytes = bytes, <$>asset = asset, <$>bytes = bytes };
    }

    [DebuggerHidden]
    private static IEnumerator WaitForLiveManifest(WWW file)
    {
        return new <WaitForLiveManifest>c__Iterator10C { file = file, <$>file = file };
    }

    [DebuggerHidden]
    private static IEnumerator WaitForLiveManifestHash(WWW file)
    {
        return new <WaitForLiveManifestHash>c__Iterator10B { file = file, <$>file = file };
    }

    public static bool Enabled
    {
        [CompilerGenerated]
        get
        {
            return <Enabled>k__BackingField;
        }
        [CompilerGenerated]
        set
        {
            <Enabled>k__BackingField = value;
        }
    }

    public static string FileServerCacheRoot
    {
        [CompilerGenerated]
        get
        {
            return <FileServerCacheRoot>k__BackingField;
        }
        [CompilerGenerated]
        private set
        {
            <FileServerCacheRoot>k__BackingField = value;
        }
    }

    public static string FileServerRoot
    {
        [CompilerGenerated]
        get
        {
            return <FileServerRoot>k__BackingField;
        }
        [CompilerGenerated]
        private set
        {
            <FileServerRoot>k__BackingField = value;
        }
    }

    private static Streaming Instance
    {
        [CompilerGenerated]
        get
        {
            return <Instance>k__BackingField;
        }
        [CompilerGenerated]
        set
        {
            <Instance>k__BackingField = value;
        }
    }

    public static string LiveManifestHash
    {
        [CompilerGenerated]
        get
        {
            return <LiveManifestHash>k__BackingField;
        }
        [CompilerGenerated]
        set
        {
            <LiveManifestHash>k__BackingField = value;
        }
    }

    private static string liveManifestURL
    {
        get
        {
            return (FileServerCacheRoot + "manifest.txt");
        }
    }

    public static StreamingManifest Manifest
    {
        get
        {
            if (!Enabled)
            {
                return null;
            }
            if (manifest_ == null)
            {
                localManifestRequest_ = AsyncState.Blocking;
                manifest_ = StreamingManifest.Load(StreamingManifest.Path);
                localManifestRequest_ = AsyncState.Ready;
            }
            return manifest_;
        }
        private set
        {
            if (Enabled)
            {
                manifest_ = value;
            }
        }
    }

    private static string ProjectPropertiesURL
    {
        [CompilerGenerated]
        get
        {
            return <ProjectPropertiesURL>k__BackingField;
        }
        [CompilerGenerated]
        set
        {
            <ProjectPropertiesURL>k__BackingField = value;
        }
    }

    public static bool Ready
    {
        [CompilerGenerated]
        get
        {
            return <Ready>k__BackingField;
        }
        [CompilerGenerated]
        private set
        {
            <Ready>k__BackingField = value;
        }
    }

    [CompilerGenerated]
    private sealed class <Initialize>c__Iterator10A : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal StreamingManifest <localManifest>__0;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                case 1:
                    if (Streaming.Instance == null)
                    {
                        this.$current = 0;
                        this.$PC = 1;
                        return true;
                    }
                    StreamingLog.Start();
                    Streaming.LoadConfig();
                    Streaming.liveManifestRequest_ = Streaming.AsyncState.Ready;
                    Streaming.liveManifestHashRequest_ = Streaming.AsyncState.Blocking;
                    Streaming.localManifestRequest_ = Streaming.AsyncState.Blocking;
                    Streaming.Ready = false;
                    Streaming.RequestLiveManifestHash(Streaming.ProjectPropertiesURL);
                    this.<localManifest>__0 = Streaming.Manifest;
                    if ((this.<localManifest>__0 != null) && this.<localManifest>__0.Valid)
                    {
                        object[] args = new object[] { this.<localManifest>__0.Hash };
                        StreamingLog.Say("Local manifest hash is {0}", args);
                        Streaming.InitializeComplete();
                        this.$PC = -1;
                        break;
                    }
                    Streaming.RequestLiveManifest(Streaming.liveManifestURL);
                    break;
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
    private sealed class <SaveAsset>c__Iterator10D : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Asset <$>asset;
        internal byte[] <$>bytes;
        internal Exception <ex>__1;
        internal string <targetPath>__0;
        internal Asset asset;
        internal byte[] bytes;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if ((this.$PC == 0) && !this.asset.IsLocal)
            {
                this.<targetPath>__0 = "Data/cache/" + this.asset.CachePath;
                try
                {
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(this.<targetPath>__0));
                    System.IO.File.WriteAllBytes(this.<targetPath>__0, this.bytes);
                }
                catch (Exception exception)
                {
                    this.<ex>__1 = exception;
                    StreamingLog.LogAssetSaveFailed(this.asset, this.<ex>__1.Message);
                    goto Label_00A1;
                }
                StreamingLog.LogAssetSaved(this.asset);
            }
        Label_00A1:
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
    private sealed class <WaitForLiveManifest>c__Iterator10C : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal WWW <$>file;
        internal WWW file;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                case 1:
                {
                    if (!this.file.isDone)
                    {
                        this.$current = 0;
                        this.$PC = 1;
                        return true;
                    }
                    object[] args = new object[] { Streaming.liveManifestURL };
                    StreamingLog.Say("Received live manifest from '{0}'", args);
                    Streaming.Manifest = StreamingManifest.Create(this.file.bytes);
                    if (Streaming.Manifest == null)
                    {
                        throw new StreamingException("Downloaded live manifest failed validation");
                    }
                    Streaming.Manifest.Save();
                    Streaming.liveManifestRequest_ = Streaming.AsyncState.Ready;
                    Streaming.localManifestRequest_ = Streaming.AsyncState.Ready;
                    Streaming.InitializeComplete();
                    this.$PC = -1;
                    break;
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

    [CompilerGenerated]
    private sealed class <WaitForLiveManifestHash>c__Iterator10B : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal WWW <$>file;
        internal GroupCollection <groups>__3;
        internal MatchCollection <matches>__2;
        internal string <message>__0;
        internal Regex <regex>__1;
        internal WWW file;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            // This item is obfuscated and can not be translated.
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    StreamingLog.Say("Waiting for live manifest hash", new object[0]);
                    break;

                case 1:
                    break;

                case 2:
                    goto Label_00D1;

                default:
                    goto Label_021A;
            }
            if (!this.file.isDone)
            {
                this.$current = 0;
                this.$PC = 1;
                goto Label_021C;
            }
            if (string.IsNullOrEmpty(this.file.text))
            {
                this.<message>__0 = string.Format("Failed to fetch live manifest hash from '{0}'.  Check the URL and server filesystem permissions.", this.file.url);
                Error.AddDevFatal("Internal Streaming Error", this.<message>__0, new object[0]);
                StreamingLog.Say(this.<message>__0, new object[0]);
                this.$current = 0;
                this.$PC = 2;
                goto Label_021C;
            }
        Label_00D1:
            StreamingLog.Say("Received live manifest hash", new object[0]);
            this.<regex>__1 = new Regex("^live=(?<live>[0-9a-f]{40})", RegexOptions.IgnoreCase);
            this.<matches>__2 = this.<regex>__1.Matches(this.file.text);
            if (this.<matches>__2.Count != 1)
            {
                object[] objArray1 = new object[] { this.file.text };
                StreamingLog.Say("Malformed live manifest hash file (1): {0}", objArray1);
                if (this.file.text == null)
                {
                    throw new StreamingException(string.Format("Malformed project-properties.txt file.  Expected 'live=###'.  Got '{0}'.", "<null>"));
                }
                goto Label_0159;
            }
            this.<groups>__3 = this.<matches>__2[0].Groups;
            if (this.<groups>__3.Count != 2)
            {
                object[] objArray2 = new object[] { this.file.text };
                StreamingLog.Say("Malformed live manifest hash file (2): {0}", objArray2);
                if (this.file.text == null)
                {
                    throw new StreamingException(string.Format("Malformed project-properties.txt file.  Expected 'live=###'.  Got '{0}'.", "<null>"));
                }
                goto Label_01C6;
            }
            Streaming.LiveManifestHash = this.<groups>__3["live"].Value.ToLower();
            Streaming.liveManifestHashRequest_ = Streaming.AsyncState.Ready;
            object[] args = new object[] { Streaming.LiveManifestHash };
            StreamingLog.Say("Live manifest hash is {0}", args);
            Streaming.InitializeComplete();
            this.$PC = -1;
        Label_021A:
            return false;
        Label_021C:
            return true;
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

    private enum AsyncState
    {
        Ready,
        Blocking
    }
}


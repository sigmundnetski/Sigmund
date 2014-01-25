using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{
    private bool m_loadAssetsImmediately;
    private bool m_ready;
    private static readonly Dictionary<AssetFamily, AssetFamilyBundleInfo> s_bundleInfo;
    private static AssetBundle[] s_familyBundles = new AssetBundle[s_nAssetFamilies];
    private static AssetLoader s_instance;
    private static int s_nAssetFamilies = Enum.GetNames(typeof(AssetFamily)).Length;
    private readonly Vector3 SPAWN_POS_CAMERA_OFFSET = new Vector3(0f, 0f, -10f);
    private const float streamingTimeout = 60f;

    static AssetLoader()
    {
        Dictionary<AssetFamily, AssetFamilyBundleInfo> dictionary = new Dictionary<AssetFamily, AssetFamilyBundleInfo>();
        AssetFamilyBundleInfo info = new AssetFamilyBundleInfo {
            TypeOf = typeof(GameObject),
            BundleName = "actors.unity3d"
        };
        dictionary.Add(AssetFamily.Actor, info);
        info = new AssetFamilyBundleInfo {
            TypeOf = typeof(TextAsset),
            BundleName = "cards.unity3d"
        };
        dictionary.Add(AssetFamily.CardXML, info);
        info = new AssetFamilyBundleInfo {
            TypeOf = typeof(GameObject),
            BundleName = "cards.unity3d"
        };
        dictionary.Add(AssetFamily.CardPrefab, info);
        info = new AssetFamilyBundleInfo {
            TypeOf = typeof(GameObject),
            BundleName = "boards.unity3d"
        };
        dictionary.Add(AssetFamily.Board, info);
        info = new AssetFamilyBundleInfo {
            TypeOf = typeof(GameObject),
            BundleName = "sounds.unity3d"
        };
        info.BackupBundles = new AssetFamily[] { AssetFamily.CardPrefab };
        dictionary.Add(AssetFamily.Sound, info);
        info = new AssetFamilyBundleInfo {
            TypeOf = typeof(Texture),
            BundleName = "textures.unity3d"
        };
        dictionary.Add(AssetFamily.Texture, info);
        info = new AssetFamilyBundleInfo {
            TypeOf = typeof(GameObject),
            BundleName = "uiscreens.unity3d"
        };
        dictionary.Add(AssetFamily.Screen, info);
        info = new AssetFamilyBundleInfo {
            TypeOf = typeof(GameObject),
            BundleName = "cards.unity3d"
        };
        dictionary.Add(AssetFamily.Spell, info);
        info = new AssetFamilyBundleInfo {
            TypeOf = typeof(GameObject),
            BundleName = "gameobjects.unity3d"
        };
        dictionary.Add(AssetFamily.GameObject, info);
        info = new AssetFamilyBundleInfo {
            TypeOf = typeof(MovieTexture),
            BundleName = "movies.unity3d"
        };
        dictionary.Add(AssetFamily.Movie, info);
        s_bundleInfo = dictionary;
    }

    private void Awake()
    {
        s_instance = this;
    }

    private void CacheAsset(Asset asset, UnityEngine.Object assetObject)
    {
        long num = Blizzard.Time.BinaryStamp();
        AssetCache.CachedAsset item = new AssetCache.CachedAsset();
        item.SetAsset(asset);
        item.SetAssetObject(assetObject);
        item.CreatedTimestamp = num;
        item.LastRequestTimestamp = num;
        item.Persistent = asset.Persistent;
        AssetCache.Add(asset, item);
    }

    [DebuggerHidden]
    private IEnumerator CreateCachedAsset_FromBundle<RequestType>(RequestType request, Asset asset) where RequestType: AssetCache.CacheRequest
    {
        return new <CreateCachedAsset_FromBundle>c__IteratorCE<RequestType> { asset = asset, request = request, <$>asset = asset, <$>request = request, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator CreateCachedGameObject(AssetCache.GameObjectCacheRequest request, Asset asset, bool usePrefabPosition)
    {
        return new <CreateCachedGameObject>c__IteratorCD { request = request, asset = asset, usePrefabPosition = usePrefabPosition, <$>request = request, <$>asset = asset, <$>usePrefabPosition = usePrefabPosition, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator CreateCachedObject(AssetCache.ObjectCacheRequest request, Asset asset)
    {
        return new <CreateCachedObject>c__IteratorCC { request = request, asset = asset, <$>request = request, <$>asset = asset, <>f__this = this };
    }

    private WWW CreateLocalFile(string absPath)
    {
        return new WWW(string.Format("file://{0}", absPath));
    }

    private string CreateLocalFilePath(string relPath)
    {
        return string.Format("{0}/{1}", ApplicationMgr.Get().GetWorkingDir(), relPath);
    }

    [DebuggerHidden]
    private IEnumerator DownloadFile(string path, FileCallback callback, object callbackData)
    {
        return new <DownloadFile>c__IteratorCA { path = path, callback = callback, callbackData = callbackData, <$>path = path, <$>callback = callback, <$>callbackData = callbackData, <>f__this = this };
    }

    public static AssetLoader Get()
    {
        return s_instance;
    }

    private float GetBundleFileLoadTimeout(WWW file)
    {
        return 90f;
    }

    private AssetBundle GetBundleForAsset(string assetName, Asset asset)
    {
        AssetBundle bundleForFamily = this.GetBundleForFamily(asset.Family);
        if (bundleForFamily == null)
        {
            return null;
        }
        if (!bundleForFamily.Contains(assetName))
        {
            bundleForFamily = null;
            AssetFamily[] backupBundles = s_bundleInfo[asset.Family].BackupBundles;
            if (backupBundles == null)
            {
                return bundleForFamily;
            }
            foreach (AssetFamily family in backupBundles)
            {
                bundleForFamily = this.GetBundleForFamily(family);
                if ((bundleForFamily != null) && bundleForFamily.Contains(assetName))
                {
                    return bundleForFamily;
                }
                bundleForFamily = null;
            }
        }
        return bundleForFamily;
    }

    private AssetBundle GetBundleForFamily(AssetFamily family)
    {
        if ((family == AssetFamily.CardPrefab) || (family == AssetFamily.Spell))
        {
            family = AssetFamily.CardXML;
        }
        int index = (int) family;
        if (s_familyBundles[index] == null)
        {
            string assetPath = FileUtils.GetAssetPath("Data/" + s_bundleInfo[family].BundleName);
            assetPath = string.Format("{0}/{1}", ApplicationMgr.Get().GetWorkingDir(), assetPath);
            s_familyBundles[index] = AssetBundle.CreateFromFile(assetPath);
        }
        return s_familyBundles[index];
    }

    public bool IsReady()
    {
        return this.m_ready;
    }

    public bool LoadActor(string actorName)
    {
        return this.LoadActor(actorName, null);
    }

    public bool LoadActor(string actorName, GameObjectCallback callback)
    {
        return this.LoadActor(actorName, callback, (ProgressCallback) null);
    }

    public bool LoadActor(string cardName, GameObjectCallback callback, ProgressCallback progressCallback)
    {
        return this.LoadActor(cardName, callback, progressCallback, null);
    }

    public bool LoadActor(string actorName, GameObjectCallback callback, object callbackData)
    {
        return this.LoadActor(actorName, callback, null, callbackData);
    }

    public bool LoadActor(string cardName, GameObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        return this.LoadGameObject(cardName, AssetFamily.Actor, false, callback, progressCallback, callbackData);
    }

    public bool LoadBoard(string boardName)
    {
        return this.LoadBoard(boardName, null);
    }

    public bool LoadBoard(string boardName, GameObjectCallback callback)
    {
        return this.LoadBoard(boardName, callback, (ProgressCallback) null);
    }

    public bool LoadBoard(string boardName, GameObjectCallback callback, ProgressCallback progressCallback)
    {
        return this.LoadBoard(boardName, callback, progressCallback, null);
    }

    public bool LoadBoard(string boardName, GameObjectCallback callback, object callbackData)
    {
        return this.LoadBoard(boardName, callback, null, callbackData);
    }

    public bool LoadBoard(string boardName, GameObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        return this.LoadGameObject(boardName, AssetFamily.Board, true, callback, progressCallback, callbackData);
    }

    private void LoadCachedGameObject(Asset asset, bool usePrefabPosition, GameObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        if (asset.Name == null)
        {
            if (callback != null)
            {
                callback(null, null, callbackData);
            }
        }
        else
        {
            AssetCache.CachedAsset asset2 = AssetCache.Find(asset);
            if (asset2 != null)
            {
                asset2.LastRequestTimestamp = Blizzard.Time.BinaryStamp();
                UnityEngine.Object assetObject = asset2.GetAssetObject();
                base.StartCoroutine(this.WaitThenCallGameObjectCallback(asset, assetObject, usePrefabPosition, callback, callbackData));
            }
            else
            {
                AssetCache.GameObjectCacheRequest request = AssetCache.GetRequest<AssetCache.GameObjectCacheRequest>(asset);
                if (request != null)
                {
                    if (request.DidFail())
                    {
                        if (callback != null)
                        {
                            callback(asset.Name, null, callbackData);
                        }
                    }
                    else
                    {
                        request.AddRequester(callback, progressCallback, callbackData);
                    }
                }
                else
                {
                    request = new AssetCache.GameObjectCacheRequest();
                    request.AddRequester(callback, progressCallback, callbackData);
                    AssetCache.AddRequest(asset, request);
                    base.StartCoroutine(this.CreateCachedGameObject(request, asset, usePrefabPosition));
                }
            }
        }
    }

    private void LoadCachedObject(Asset asset, ObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        if (asset.Name == null)
        {
            if (callback != null)
            {
                callback(null, null, callbackData);
            }
        }
        else
        {
            AssetCache.CachedAsset asset2 = AssetCache.Find(asset);
            if (asset2 != null)
            {
                asset2.LastRequestTimestamp = Blizzard.Time.BinaryStamp();
                if (callback != null)
                {
                    callback(asset.Name, asset2.GetAssetObject(), callbackData);
                }
            }
            else
            {
                AssetCache.ObjectCacheRequest request = AssetCache.GetRequest<AssetCache.ObjectCacheRequest>(asset);
                if (request != null)
                {
                    if (request.DidFail())
                    {
                        if (callback != null)
                        {
                            callback(asset.Name, null, callbackData);
                        }
                    }
                    else
                    {
                        request.AddRequester(callback, progressCallback, callbackData);
                    }
                }
                else
                {
                    request = new AssetCache.ObjectCacheRequest();
                    request.AddRequester(callback, progressCallback, callbackData);
                    AssetCache.AddRequest(asset, request);
                    base.StartCoroutine(this.CreateCachedObject(request, asset));
                }
            }
        }
    }

    public bool LoadCardPrefab(string cardName)
    {
        return this.LoadCardPrefab(cardName, null);
    }

    public bool LoadCardPrefab(string cardName, GameObjectCallback callback)
    {
        return this.LoadCardPrefab(cardName, callback, (ProgressCallback) null);
    }

    public bool LoadCardPrefab(string cardName, GameObjectCallback callback, ProgressCallback progressCallback)
    {
        return this.LoadCardPrefab(cardName, callback, progressCallback, null);
    }

    public bool LoadCardPrefab(string cardName, GameObjectCallback callback, object callbackData)
    {
        return this.LoadCardPrefab(cardName, callback, null, callbackData);
    }

    public bool LoadCardPrefab(string cardName, GameObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        return this.LoadGameObject(cardName, AssetFamily.CardPrefab, true, callback, progressCallback, callbackData);
    }

    public bool LoadCardXml(string cardName)
    {
        return this.LoadCardXml(cardName, null);
    }

    public bool LoadCardXml(string cardName, ObjectCallback callback)
    {
        return this.LoadCardXml(cardName, callback, (ProgressCallback) null);
    }

    public bool LoadCardXml(string cardName, ObjectCallback callback, ProgressCallback progressCallback)
    {
        return this.LoadCardXml(cardName, callback, progressCallback, null);
    }

    public bool LoadCardXml(string cardName, ObjectCallback callback, object callbackData)
    {
        return this.LoadCardXml(cardName, callback, null, callbackData);
    }

    public bool LoadCardXml(string cardName, ObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        return this.LoadObject(cardName, AssetFamily.CardXML, callback, progressCallback, callbackData);
    }

    public bool LoadFile(string path, FileCallback callback, object callbackData)
    {
        if (string.IsNullOrEmpty(path))
        {
            UnityEngine.Debug.LogWarning("AssetLoader.LoadFile() - path was null or empty");
            return false;
        }
        base.StartCoroutine(this.DownloadFile(path, callback, callbackData));
        return true;
    }

    public bool LoadGameObject(string name)
    {
        return this.LoadGameObject(name, null);
    }

    public bool LoadGameObject(string name, GameObjectCallback callback)
    {
        return this.LoadGameObject(name, callback, (ProgressCallback) null);
    }

    public bool LoadGameObject(string name, GameObjectCallback callback, ProgressCallback progressCallback)
    {
        return this.LoadGameObject(name, callback, progressCallback, null);
    }

    public bool LoadGameObject(string name, GameObjectCallback callback, object callbackData)
    {
        return this.LoadGameObject(name, callback, null, callbackData);
    }

    public bool LoadGameObject(string name, GameObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        return this.LoadGameObject(name, AssetFamily.GameObject, true, callback, progressCallback, false, callbackData);
    }

    public bool LoadGameObject(string name, GameObjectCallback callback, ProgressCallback progressCallback, bool persistent, object callbackData)
    {
        return this.LoadGameObject(name, AssetFamily.GameObject, true, callback, progressCallback, persistent, callbackData);
    }

    private bool LoadGameObject(string assetName, AssetFamily family, bool usePrefabPosition, GameObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        return this.LoadGameObject(assetName, family, usePrefabPosition, callback, progressCallback, false, callbackData);
    }

    private bool LoadGameObject(string assetName, AssetFamily family, bool usePrefabPosition, GameObjectCallback callback, ProgressCallback progressCallback, bool persistent, object callbackData)
    {
        if (string.IsNullOrEmpty(assetName))
        {
            UnityEngine.Debug.LogWarning("AssetLoader.LoadGameObject() - name was null or empty");
            return false;
        }
        Asset asset = Asset.Create(assetName, family, persistent);
        this.LoadCachedGameObject(asset, usePrefabPosition, callback, progressCallback, callbackData);
        return true;
    }

    private GameObject LoadGameObjectImmediately(Asset asset, bool usePrefabPosition)
    {
        if (asset.Name == null)
        {
            return null;
        }
        UnityEngine.Object assetObject = null;
        AssetCache.CachedAsset asset2 = AssetCache.Find(asset);
        if (asset2 != null)
        {
            asset2.LastRequestTimestamp = Blizzard.Time.BinaryStamp();
            assetObject = asset2.GetAssetObject();
        }
        else
        {
            string assetName = string.Format("Final/{0}", asset.LocalizedEditorPath);
            AssetBundle bundleForAsset = this.GetBundleForAsset(assetName, asset);
            if (bundleForAsset == null)
            {
                assetName = string.Format("Final/{0}", asset.EditorPath);
                bundleForAsset = this.GetBundleForAsset(assetName, asset);
            }
            assetObject = bundleForAsset.Load(assetName);
            if (assetObject != null)
            {
                this.CacheAsset(asset, assetObject);
            }
        }
        if ((assetObject == null) || !(assetObject is GameObject))
        {
            UnityEngine.Debug.LogWarning("Expected a game object and loaded null or something else");
            return null;
        }
        if (usePrefabPosition)
        {
            return (GameObject) UnityEngine.Object.Instantiate(assetObject);
        }
        return (GameObject) UnityEngine.Object.Instantiate(assetObject, this.NewGameObjectSpawnPosition(assetObject), ((GameObject) assetObject).transform.rotation);
    }

    public bool LoadMovie(string name)
    {
        return this.LoadMovie(name, null);
    }

    public bool LoadMovie(string name, ObjectCallback callback)
    {
        return this.LoadMovie(name, callback, (ProgressCallback) null);
    }

    public bool LoadMovie(string name, ObjectCallback callback, ProgressCallback progressCallback)
    {
        return this.LoadMovie(name, callback, progressCallback, false, null);
    }

    public bool LoadMovie(string name, ObjectCallback callback, object callbackData)
    {
        return this.LoadMovie(name, callback, null, false, callbackData);
    }

    public bool LoadMovie(string name, ObjectCallback callback, ProgressCallback progressCallback, bool persistent, object callbackData)
    {
        return this.LoadObject(name, AssetFamily.Movie, callback, progressCallback, persistent, callbackData);
    }

    private bool LoadObject(string assetName, AssetFamily family, ObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        return this.LoadObject(assetName, family, callback, progressCallback, false, callbackData);
    }

    private bool LoadObject(string assetName, AssetFamily family, ObjectCallback callback, ProgressCallback progressCallback, bool persistent, object callbackData)
    {
        if (string.IsNullOrEmpty(assetName))
        {
            Log.Asset.Print("AssetLoader.LoadObject() - name was null or empty");
            return false;
        }
        Asset asset = Asset.Create(assetName, family);
        this.LoadCachedObject(asset, callback, progressCallback, callbackData);
        return true;
    }

    public bool LoadSound(string soundName)
    {
        return this.LoadSound(soundName, null);
    }

    public bool LoadSound(string soundName, GameObjectCallback callback)
    {
        return this.LoadSound(soundName, callback, (ProgressCallback) null);
    }

    public bool LoadSound(string soundName, GameObjectCallback callback, ProgressCallback progressCallback)
    {
        return this.LoadSound(soundName, callback, progressCallback, false, null);
    }

    public bool LoadSound(string soundName, GameObjectCallback callback, object callbackData)
    {
        return this.LoadSound(soundName, callback, null, false, callbackData);
    }

    public bool LoadSound(string soundName, GameObjectCallback callback, ProgressCallback progressCallback, bool persistent, object callbackData)
    {
        return this.LoadGameObject(soundName, AssetFamily.Sound, true, callback, progressCallback, persistent, callbackData);
    }

    public bool LoadSpell(string name)
    {
        return this.LoadSpell(name, null);
    }

    public bool LoadSpell(string name, GameObjectCallback callback)
    {
        return this.LoadSpell(name, callback, (ProgressCallback) null);
    }

    public bool LoadSpell(string name, GameObjectCallback callback, ProgressCallback progressCallback)
    {
        return this.LoadSpell(name, callback, progressCallback, null);
    }

    public bool LoadSpell(string name, GameObjectCallback callback, object callbackData)
    {
        return this.LoadSpell(name, callback, null, callbackData);
    }

    public bool LoadSpell(string name, GameObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        return this.LoadGameObject(name, AssetFamily.Spell, true, callback, progressCallback, callbackData);
    }

    public bool LoadSpellTable(string name, GameObjectCallback callback, object callbackData)
    {
        return this.LoadGameObject(name, AssetFamily.Actor, true, callback, null, true, callbackData);
    }

    public bool LoadTexture(string textureName)
    {
        return this.LoadTexture(textureName, null);
    }

    public bool LoadTexture(string textureName, ObjectCallback callback)
    {
        return this.LoadTexture(textureName, callback, (ProgressCallback) null);
    }

    public bool LoadTexture(string textureName, ObjectCallback callback, ProgressCallback progressCallback)
    {
        return this.LoadTexture(textureName, callback, progressCallback, null);
    }

    public bool LoadTexture(string textureName, ObjectCallback callback, object callbackData)
    {
        return this.LoadTexture(textureName, callback, null, callbackData);
    }

    public bool LoadTexture(string textureName, ObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        return this.LoadObject(textureName, AssetFamily.Texture, callback, progressCallback, callbackData);
    }

    public bool LoadUIScreen(string screenName)
    {
        return this.LoadUIScreen(screenName, null);
    }

    public bool LoadUIScreen(string screenName, GameObjectCallback callback)
    {
        return this.LoadUIScreen(screenName, callback, (ProgressCallback) null);
    }

    public bool LoadUIScreen(string screenName, GameObjectCallback callback, ProgressCallback progressCallback)
    {
        return this.LoadUIScreen(screenName, callback, progressCallback, null);
    }

    public bool LoadUIScreen(string screenName, GameObjectCallback callback, object callbackData)
    {
        return this.LoadUIScreen(screenName, callback, null, callbackData);
    }

    public bool LoadUIScreen(string screenName, GameObjectCallback callback, ProgressCallback progressCallback, object callbackData)
    {
        return this.LoadGameObject(screenName, AssetFamily.Screen, true, callback, progressCallback, callbackData);
    }

    private Vector3 NewGameObjectSpawnPosition(UnityEngine.Object prefab)
    {
        if (Camera.main == null)
        {
            UnityEngine.Debug.LogError(string.Format("AssetLoader.NewGameObjectSpawnPosition() - Camera.main is null. prefab={0}", prefab));
            return Vector3.zero;
        }
        return (Camera.main.transform.position + this.SPAWN_POS_CAMERA_OFFSET);
    }

    private void OnApplicationQuit()
    {
        AssetCache.ForceClearAllCaches();
    }

    public void SetImmediateLoading(bool loadImmediate)
    {
        this.m_loadAssetsImmediately = loadImmediate;
    }

    public void SetReady(bool ready)
    {
        this.m_ready = ready;
    }

    private void Start()
    {
        Streaming.Enabled = false;
        this.SetReady(true);
    }

    [DebuggerHidden]
    private static IEnumerator WaitForDownload(WWW file)
    {
        return new <WaitForDownload>c__IteratorCB { file = file, <$>file = file };
    }

    [DebuggerHidden]
    private IEnumerator WaitThenCallGameObjectCallback(Asset asset, UnityEngine.Object prefab, bool usePrefabPosition, GameObjectCallback callback, object callbackData)
    {
        return new <WaitThenCallGameObjectCallback>c__IteratorCF { prefab = prefab, asset = asset, usePrefabPosition = usePrefabPosition, callback = callback, callbackData = callbackData, <$>prefab = prefab, <$>asset = asset, <$>usePrefabPosition = usePrefabPosition, <$>callback = callback, <$>callbackData = callbackData, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <CreateCachedAsset_FromBundle>c__IteratorCE<RequestType> : IDisposable, IEnumerator, IEnumerator<object> where RequestType: AssetCache.CacheRequest
    {
        internal object $current;
        internal int $PC;
        internal Asset <$>asset;
        internal RequestType <$>request;
        internal AssetLoader <>f__this;
        internal AssetBundleRequest <assetBundleRequest>__5;
        internal string <assetName>__0;
        internal AssetBundle <bundle>__1;
        internal UnityEngine.Object <result>__4;
        internal string <userErrorHeader>__2;
        internal string <userErrorHeader>__6;
        internal string <userErrorMessage>__3;
        internal string <userErrorMessage>__7;
        internal Asset asset;
        internal RequestType request;

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
                    this.<assetName>__0 = string.Format("Final/{0}", this.asset.LocalizedEditorPath);
                    this.<bundle>__1 = this.<>f__this.GetBundleForAsset(this.<assetName>__0, this.asset);
                    if (this.<bundle>__1 == null)
                    {
                        this.<assetName>__0 = string.Format("Final/{0}", this.asset.EditorPath);
                        this.<bundle>__1 = this.<>f__this.GetBundleForAsset(this.<assetName>__0, this.asset);
                    }
                    if (this.<bundle>__1 == null)
                    {
                        UnityEngine.Debug.LogError("Asset not found in family or backup bundles: " + this.<assetName>__0);
                        this.request.OnLoadFailed(this.asset.Name);
                        this.<userErrorHeader>__2 = GameStrings.Get("GLOBAL_ERROR_ASSET_TITLE");
                        this.<userErrorMessage>__3 = string.Format("Failed to load bundle for {0}. Should be in bundle {1}.", this.<assetName>__0, AssetLoader.s_bundleInfo[this.asset.Family].BundleName);
                        Error.AddDevFatal(this.<userErrorHeader>__2, this.<userErrorMessage>__3, new object[0]);
                        goto Label_0304;
                    }
                    this.<result>__4 = null;
                    if ((this.asset.Family != AssetFamily.CardXML) && !this.<>f__this.m_loadAssetsImmediately)
                    {
                        if (this.asset.Family == AssetFamily.CardXML)
                        {
                            this.<result>__4 = this.<bundle>__1.Load(this.<assetName>__0);
                            goto Label_02D5;
                        }
                        this.<assetBundleRequest>__5 = this.<bundle>__1.LoadAsync(this.<assetName>__0, AssetLoader.s_bundleInfo[this.asset.Family].TypeOf);
                        break;
                    }
                    this.<result>__4 = this.<bundle>__1.Load(this.<assetName>__0);
                    goto Label_02D5;

                case 1:
                    break;

                default:
                    goto Label_0304;
            }
            while (!this.<assetBundleRequest>__5.isDone)
            {
                this.request.OnProgressUpdate(this.asset.Name, this.<assetBundleRequest>__5.progress);
                this.$current = 0;
                this.$PC = 1;
                return true;
            }
            if (this.<assetBundleRequest>__5.asset == null)
            {
                this.request.OnLoadFailed(this.asset.Name);
                this.<userErrorHeader>__6 = GameStrings.Get("GLOBAL_ERROR_ASSET_TITLE");
                this.<userErrorMessage>__7 = string.Format("{0} not found in bundle {1}.", this.<assetName>__0, AssetLoader.s_bundleInfo[this.asset.Family].BundleName);
                Error.AddDevFatal(this.<userErrorHeader>__6, this.<userErrorMessage>__7, new object[0]);
                goto Label_0304;
            }
            this.<result>__4 = this.<assetBundleRequest>__5.asset;
        Label_02D5:
            this.<>f__this.CacheAsset(this.asset, this.<result>__4);
            this.request.OnLoadSucceeded();
            this.$PC = -1;
        Label_0304:
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
    private sealed class <CreateCachedGameObject>c__IteratorCD : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Asset <$>asset;
        internal AssetCache.GameObjectCacheRequest <$>request;
        internal bool <$>usePrefabPosition;
        internal List<AssetCache.GameObjectRequester>.Enumerator <$s_962>__2;
        internal AssetLoader <>f__this;
        internal AssetCache.CachedAsset <cachedAsset>__0;
        internal UnityEngine.Object <prefab>__1;
        internal AssetCache.GameObjectRequester <requester>__3;
        internal Asset asset;
        internal AssetCache.GameObjectCacheRequest request;
        internal bool usePrefabPosition;

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
                    this.$current = this.<>f__this.StartCoroutine(this.<>f__this.CreateCachedAsset_FromBundle<AssetCache.GameObjectCacheRequest>(this.request, this.asset));
                    this.$PC = 1;
                    return true;

                case 1:
                    if (this.request.DidSucceed())
                    {
                        this.<cachedAsset>__0 = AssetCache.Find(this.asset);
                        this.<prefab>__1 = this.<cachedAsset>__0.GetAssetObject();
                        this.<$s_962>__2 = this.request.GetRequesters().GetEnumerator();
                        try
                        {
                            while (this.<$s_962>__2.MoveNext())
                            {
                                this.<requester>__3 = this.<$s_962>__2.Current;
                                this.<>f__this.StartCoroutine(this.<>f__this.WaitThenCallGameObjectCallback(this.asset, this.<prefab>__1, this.usePrefabPosition, this.<requester>__3.m_callback, this.<requester>__3.m_callbackData));
                            }
                        }
                        finally
                        {
                            this.<$s_962>__2.Dispose();
                        }
                        this.$PC = -1;
                        break;
                    }
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
    private sealed class <CreateCachedObject>c__IteratorCC : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Asset <$>asset;
        internal AssetCache.ObjectCacheRequest <$>request;
        internal AssetLoader <>f__this;
        internal UnityEngine.Object <assetObject>__1;
        internal AssetCache.CachedAsset <cachedAsset>__0;
        internal Asset asset;
        internal AssetCache.ObjectCacheRequest request;

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
                    this.$current = this.<>f__this.StartCoroutine(this.<>f__this.CreateCachedAsset_FromBundle<AssetCache.ObjectCacheRequest>(this.request, this.asset));
                    this.$PC = 1;
                    return true;

                case 1:
                    if (this.request.DidSucceed())
                    {
                        this.<cachedAsset>__0 = AssetCache.Find(this.asset);
                        this.<assetObject>__1 = this.<cachedAsset>__0.GetAssetObject();
                        this.request.OnLoadComplete(this.asset.Name, this.<assetObject>__1);
                        this.$PC = -1;
                        break;
                    }
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
    private sealed class <DownloadFile>c__IteratorCA : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal AssetLoader.FileCallback <$>callback;
        internal object <$>callbackData;
        internal string <$>path;
        internal AssetLoader <>f__this;
        internal WWW <file>__1;
        internal string <filePath>__0;
        internal string <message>__2;
        internal AssetLoader.FileCallback callback;
        internal object callbackData;
        internal string path;

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
                    if (this.path != null)
                    {
                        this.<filePath>__0 = this.<>f__this.CreateLocalFilePath(this.path);
                        this.<file>__1 = this.<>f__this.CreateLocalFile(this.<filePath>__0);
                        this.$current = this.<>f__this.StartCoroutine(AssetLoader.WaitForDownload(this.<file>__1));
                        this.$PC = 1;
                        return true;
                    }
                    if (this.callback != null)
                    {
                        this.callback(null, null, this.callbackData);
                    }
                    break;

                case 1:
                    if (this.<file>__1.error == null)
                    {
                        if (this.callback != null)
                        {
                            this.callback(this.path, this.<file>__1, this.callbackData);
                        }
                        this.$PC = -1;
                        break;
                    }
                    this.<message>__2 = string.Format("AssetLoader.DownloadFile() - FAILED to load asset '{0}' path '{1}', reason '{2}'", this.path, this.<file>__1.url, this.<file>__1.error);
                    UnityEngine.Debug.LogError(this.<message>__2);
                    if (this.callback != null)
                    {
                        this.callback(this.path, null, this.callbackData);
                    }
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
    private sealed class <WaitForDownload>c__IteratorCB : IDisposable, IEnumerator, IEnumerator<object>
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
                    if (!this.file.isDone)
                    {
                        this.$current = 0;
                        this.$PC = 1;
                        return true;
                    }
                    this.$PC = -1;
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
    private sealed class <WaitThenCallGameObjectCallback>c__IteratorCF : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Asset <$>asset;
        internal AssetLoader.GameObjectCallback <$>callback;
        internal object <$>callbackData;
        internal UnityEngine.Object <$>prefab;
        internal bool <$>usePrefabPosition;
        internal AssetLoader <>f__this;
        internal GameObject <instance>__3;
        internal GameObject <original>__2;
        internal string <userErrorHeader>__0;
        internal string <userErrorMessage>__1;
        internal Asset asset;
        internal AssetLoader.GameObjectCallback callback;
        internal object callbackData;
        internal UnityEngine.Object prefab;
        internal bool usePrefabPosition;

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
                {
                    if (this.prefab is GameObject)
                    {
                        this.<original>__2 = (GameObject) this.prefab;
                        this.<instance>__3 = null;
                        if (this.usePrefabPosition)
                        {
                            this.<instance>__3 = (GameObject) UnityEngine.Object.Instantiate(this.prefab);
                        }
                        else
                        {
                            this.<instance>__3 = (GameObject) UnityEngine.Object.Instantiate(this.prefab, this.<>f__this.NewGameObjectSpawnPosition(this.prefab), this.<original>__2.transform.rotation);
                        }
                        this.$current = new WaitForEndOfFrame();
                        this.$PC = 1;
                        return true;
                    }
                    this.<userErrorHeader>__0 = GameStrings.Get("GLOBAL_ERROR_ASSET_TITLE");
                    object[] objArray1 = new object[4];
                    object[] args = new object[] { this.asset.Name };
                    objArray1[0] = GameStrings.Format("GLOBAL_ERROR_ASSET_INCORRECT_DATA", args);
                    objArray1[1] = " (prefab=";
                    objArray1[2] = this.prefab;
                    objArray1[3] = ")";
                    this.<userErrorMessage>__1 = string.Concat(objArray1);
                    Error.AddFatal(this.<userErrorHeader>__0, this.<userErrorMessage>__1);
                    break;
                }
                case 1:
                    if (AssetCache.HasItem(this.asset))
                    {
                        if (this.callback != null)
                        {
                            this.callback(this.asset.Name, this.<instance>__3, this.callbackData);
                        }
                        this.$PC = -1;
                        break;
                    }
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

    public class AssetFamilyBundleInfo
    {
        public AssetFamily[] BackupBundles;
        private string bundlePath_;
        public System.Type TypeOf;

        public string BundleName
        {
            get
            {
                return this.bundlePath_;
            }
            set
            {
                this.bundlePath_ = this.bundlePath_ + value;
            }
        }
    }

    public delegate void FileCallback(string path, WWW file, object callbackData);

    public delegate void GameObjectCallback(string name, GameObject go, object callbackData);

    public delegate void ObjectCallback(string name, UnityEngine.Object obj, object callbackData);

    public delegate void ProgressCallback(string name, float progress, object callbackData);
}


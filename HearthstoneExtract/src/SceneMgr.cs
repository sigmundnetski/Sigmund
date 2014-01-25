using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class SceneMgr : MonoBehaviour
{
    private long m_boxLoadTimestamp;
    private Mode m_mode = Mode.STARTUP;
    private Mode m_nextMode;
    private Mode m_prevMode;
    private bool m_reloadMode;
    private Scene m_scene;
    private bool m_sceneLoaded;
    private List<SceneLoadedListener> m_sceneLoadedListeners = new List<SceneLoadedListener>();
    private List<ScenePreUnloadListener> m_scenePreUnloadListeners = new List<ScenePreUnloadListener>();
    private List<SceneUnloadedListener> m_sceneUnloadedListeners = new List<SceneUnloadedListener>();
    private int m_startupAssetLoads;
    private static SceneMgr s_instance;
    private const float SCENE_LOADED_DELAY = 0.15f;
    private const float SCENE_UNLOAD_DELAY = 0.15f;

    private void Awake()
    {
        s_instance = this;
        UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
    }

    private void DestroyAllObjectsOnModeSwitch()
    {
        GameObject[] objArray = (GameObject[]) UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
        foreach (GameObject obj2 in objArray)
        {
            if (this.ShouldDestroyOnModeSwitch(obj2))
            {
                UnityEngine.Object.DestroyImmediate(obj2);
            }
        }
    }

    public void DisableCamera()
    {
        base.gameObject.camera.enabled = false;
    }

    [DebuggerHidden]
    private IEnumerable DisableCameraCo()
    {
        return new <DisableCameraCo>c__Iterator9F { <>f__this = this, $PC = -2 };
    }

    private bool DoesModeShowBox(Mode mode)
    {
        if (mode == Mode.GAMEPLAY)
        {
            return false;
        }
        return true;
    }

    private void FireSceneLoadedEvent()
    {
        foreach (SceneLoadedListener listener in this.m_sceneLoadedListeners.ToArray())
        {
            listener.Fire(this.m_mode, this.m_scene);
        }
    }

    private void FireScenePreUnloadEvent(Scene prevScene)
    {
        foreach (ScenePreUnloadListener listener in this.m_scenePreUnloadListeners.ToArray())
        {
            listener.Fire(this.m_prevMode, prevScene);
        }
    }

    private void FireSceneUnloadedEvent(Scene prevScene)
    {
        foreach (SceneUnloadedListener listener in this.m_sceneUnloadedListeners.ToArray())
        {
            listener.Fire(this.m_prevMode, prevScene);
        }
    }

    public static SceneMgr Get()
    {
        return s_instance;
    }

    public Mode GetMode()
    {
        return this.m_mode;
    }

    public Mode GetNextMode()
    {
        return this.m_nextMode;
    }

    public Mode GetPrevMode()
    {
        return this.m_prevMode;
    }

    public Scene GetScene()
    {
        return this.m_scene;
    }

    public bool IsInGame()
    {
        return this.IsModeRequested(Mode.GAMEPLAY);
    }

    public bool IsModeRequested(Mode mode)
    {
        return ((this.m_mode == mode) || (this.m_nextMode == mode));
    }

    public bool IsSceneLoaded()
    {
        return this.m_sceneLoaded;
    }

    private void LoadBox(AssetLoader.GameObjectCallback callback)
    {
        this.m_boxLoadTimestamp = Blizzard.Time.BinaryStamp();
        AssetLoader.Get().LoadUIScreen("TheBox", callback);
    }

    private void LoadMode()
    {
        string sceneName = EnumUtils.GetString<Mode>(this.m_mode);
        SpellCache.Get().LoadMode(this.m_mode);
        base.StartCoroutine(this.LoadScene(sceneName));
    }

    private void LoadModeFromModeSwitch()
    {
        bool flag = this.DoesModeShowBox(this.m_prevMode);
        bool flag2 = this.DoesModeShowBox(this.m_mode);
        if (!flag && flag2)
        {
            GameStrings.LoadCategory(GameStringCategory.GLUE);
            CollectionManager.Get().LoadAllEntityDefs();
            if (this.m_prevMode == Mode.GAMEPLAY)
            {
                this.UnloadStringsWhenPossible(GameStringCategory.GAMEPLAY);
            }
            this.LoadBox(new AssetLoader.GameObjectCallback(this.OnBoxReloaded));
        }
        else
        {
            if (flag && !flag2)
            {
                LoadingScreen.Get().SetAssetLoadStartTimestamp(this.m_boxLoadTimestamp);
                this.m_boxLoadTimestamp = 0L;
                this.UnloadStringsWhenPossible(GameStringCategory.GLUE);
            }
            if ((this.m_prevMode != Mode.GAMEPLAY) && (this.m_mode == Mode.GAMEPLAY))
            {
                GameStrings.LoadCategory(GameStringCategory.GAMEPLAY);
            }
            this.LoadMode();
        }
    }

    [DebuggerHidden]
    private IEnumerator LoadScene(string sceneName)
    {
        return new <LoadScene>c__IteratorA0 { sceneName = sceneName, <$>sceneName = sceneName, <>f__this = this };
    }

    private void LoadStartupAssets()
    {
        GameStrings.LoadCategory(GameStringCategory.GLUE);
        GameStrings.LoadCategory(GameStringCategory.TUTORIAL);
        this.m_startupAssetLoads = 3;
        AssetLoader.Get().LoadUIScreen("BaseUI", new AssetLoader.GameObjectCallback(this.OnBaseUILoaded));
        AssetLoader.Get().LoadGameObject("SoundConfig", new AssetLoader.GameObjectCallback(this.OnSoundConfigLoaded));
        AssetLoader.Get().LoadGameObject("CardColorSwitcher", new AssetLoader.GameObjectCallback(this.OnColorSwitcherLoaded));
        SpellCache.Get().PreLoad();
    }

    public void NotifySceneLoaded()
    {
        this.m_sceneLoaded = true;
        if (this.ShouldUseSceneLoadDelays())
        {
            base.StartCoroutine(this.WaitThenFireSceneLoadedEvent());
        }
        else
        {
            this.FireSceneLoadedEvent();
        }
    }

    private void OnBaseUILoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("SceneMgr.OnBaseUILoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            this.OnStartupAssetFinishedLoading();
        }
    }

    private void OnBoxLoaded(string name, GameObject screen, object callbackData)
    {
        if (screen == null)
        {
            UnityEngine.Debug.LogError(string.Format("SceneMgr.OnBoxLoaded() - failed to load {0}", name));
        }
        else if (!this.IsModeRequested(Mode.FATAL_ERROR))
        {
            this.m_nextMode = Mode.LOGIN;
        }
    }

    private void OnBoxReloaded(string name, GameObject screen, object callbackData)
    {
        if (screen == null)
        {
            UnityEngine.Debug.LogError(string.Format("SceneMgr.OnBoxReloaded() - failed to load {0}", name));
        }
        else
        {
            this.LoadMode();
        }
    }

    private void OnColorSwitcherLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("SceneMgr.OnColorSwitcherLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            go.transform.parent = base.transform;
            this.OnStartupAssetFinishedLoading();
        }
    }

    private void OnSoundConfigLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("SceneMgr.OnSoundConfigLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            SoundConfig component = go.GetComponent<SoundConfig>();
            if (component == null)
            {
                UnityEngine.Debug.LogError(string.Format("SceneMgr.OnSoundConfigLoaded() - ERROR \"{0}\" has no {1} component", name, typeof(SoundConfig)));
            }
            else
            {
                go.transform.parent = base.transform;
                SoundManager.Get().SetConfig(component);
                this.OnStartupAssetFinishedLoading();
            }
        }
    }

    private void OnStartupAssetFinishedLoading()
    {
        if (!this.IsModeRequested(Mode.FATAL_ERROR))
        {
            this.m_startupAssetLoads--;
            if (this.m_startupAssetLoads <= 0)
            {
                this.LoadBox(new AssetLoader.GameObjectCallback(this.OnBoxLoaded));
            }
        }
    }

    private void PostUnloadCleanup()
    {
        this.DestroyAllObjectsOnModeSwitch();
        Resources.UnloadUnusedAssets();
    }

    [Conditional("SCENE_LOAD_TIMING")]
    private void PrintSceneLoadMessage(string format, params object[] formatArgs)
    {
    }

    public void RegisterSceneLoadedEvent(SceneLoadedCallback callback)
    {
        this.RegisterSceneLoadedEvent(callback, null);
    }

    public void RegisterSceneLoadedEvent(SceneLoadedCallback callback, object userData)
    {
        SceneLoadedListener item = new SceneLoadedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        this.m_sceneLoadedListeners.Add(item);
    }

    public void RegisterScenePreUnloadEvent(ScenePreUnloadCallback callback)
    {
        this.RegisterScenePreUnloadEvent(callback, null);
    }

    public void RegisterScenePreUnloadEvent(ScenePreUnloadCallback callback, object userData)
    {
        ScenePreUnloadListener item = new ScenePreUnloadListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        this.m_scenePreUnloadListeners.Add(item);
    }

    public void RegisterSceneUnloadedEvent(SceneUnloadedCallback callback)
    {
        this.RegisterSceneUnloadedEvent(callback, null);
    }

    public void RegisterSceneUnloadedEvent(SceneUnloadedCallback callback, object userData)
    {
        SceneUnloadedListener item = new SceneUnloadedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        this.m_sceneUnloadedListeners.Add(item);
    }

    public void ReloadMode()
    {
        if (!this.IsModeRequested(Mode.FATAL_ERROR))
        {
            this.m_nextMode = this.m_mode;
            this.m_reloadMode = true;
        }
    }

    public void SetNextMode(Mode mode)
    {
        if (!this.IsModeRequested(Mode.FATAL_ERROR))
        {
            this.m_nextMode = mode;
            this.m_reloadMode = false;
        }
    }

    public void SetScene(Scene scene)
    {
        this.m_scene = scene;
    }

    private bool ShouldDestroyOnModeSwitch(GameObject go)
    {
        if (go == null)
        {
            return false;
        }
        if (go.transform.parent != null)
        {
            return false;
        }
        if (go == base.gameObject)
        {
            return false;
        }
        if ((PegUI.Get() != null) && (go == PegUI.Get().gameObject))
        {
            return false;
        }
        if (((Box.Get() != null) && (go == Box.Get().gameObject)) && this.DoesModeShowBox(this.m_mode))
        {
            return false;
        }
        if (DefLoader.Get().HasDef(go))
        {
            return false;
        }
        return true;
    }

    private bool ShouldUseSceneLoadDelays()
    {
        if (this.m_mode == Mode.LOGIN)
        {
            return false;
        }
        if (this.m_mode == Mode.HUB)
        {
            return false;
        }
        if (this.m_mode == Mode.FATAL_ERROR)
        {
            return false;
        }
        return true;
    }

    private bool ShouldUseSceneUnloadDelays()
    {
        return true;
    }

    private void Start()
    {
        if (!this.IsModeRequested(Mode.FATAL_ERROR))
        {
            this.LoadStartupAssets();
        }
    }

    [DebuggerHidden]
    private IEnumerator SwitchMode()
    {
        return new <SwitchMode>c__IteratorA2 { <>f__this = this };
    }

    private void UnloadStringsWhenPossible(GameStringCategory category)
    {
        if (LoadingScreen.Get().IsTransitioning())
        {
            LoadingScreen.Get().AddStringsToUnload(category);
        }
        else
        {
            GameStrings.UnloadCategory(category);
        }
    }

    public bool UnregisterSceneLoadedEvent(SceneLoadedCallback callback)
    {
        return this.UnregisterSceneLoadedEvent(callback, null);
    }

    public bool UnregisterSceneLoadedEvent(SceneLoadedCallback callback, object userData)
    {
        SceneLoadedListener item = new SceneLoadedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_sceneLoadedListeners.Remove(item);
    }

    public bool UnregisterScenePreUnloadEvent(ScenePreUnloadCallback callback)
    {
        return this.UnregisterScenePreUnloadEvent(callback, null);
    }

    public bool UnregisterScenePreUnloadEvent(ScenePreUnloadCallback callback, object userData)
    {
        ScenePreUnloadListener item = new ScenePreUnloadListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_scenePreUnloadListeners.Remove(item);
    }

    public bool UnregisterSceneUnloadedEvent(SceneUnloadedCallback callback)
    {
        return this.UnregisterSceneUnloadedEvent(callback, null);
    }

    public bool UnregisterSceneUnloadedEvent(SceneUnloadedCallback callback, object userData)
    {
        SceneUnloadedListener item = new SceneUnloadedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_sceneUnloadedListeners.Remove(item);
    }

    private void Update()
    {
        Network.Heartbeat();
        if (!this.m_reloadMode)
        {
            if (this.m_nextMode == Mode.INVALID)
            {
                return;
            }
            if (this.m_mode == this.m_nextMode)
            {
                this.m_nextMode = Mode.INVALID;
                return;
            }
        }
        this.m_prevMode = this.m_mode;
        this.m_mode = this.m_nextMode;
        this.m_nextMode = Mode.INVALID;
        this.m_reloadMode = false;
        if (this.m_scene != null)
        {
            base.StopCoroutine("SwitchMode");
            base.StartCoroutine("SwitchMode");
        }
        else
        {
            this.LoadMode();
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitForLevelLoad(UnityEngine.AsyncOperation async)
    {
        return new <WaitForLevelLoad>c__IteratorA1 { async = async, <$>async = async };
    }

    [DebuggerHidden]
    private IEnumerator WaitThenFireSceneLoadedEvent()
    {
        return new <WaitThenFireSceneLoadedEvent>c__Iterator9E { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <DisableCameraCo>c__Iterator9F : IDisposable, IEnumerator, IEnumerable, IEnumerator<object>, IEnumerable<object>
    {
        internal object $current;
        internal int $PC;
        internal SceneMgr <>f__this;
        internal int <i>__0;

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
                    this.<i>__0 = 0;
                    break;

                case 1:
                    this.<i>__0++;
                    break;

                default:
                    goto Label_007B;
            }
            if (this.<i>__0 < 6)
            {
                this.$current = new WaitForEndOfFrame();
                this.$PC = 1;
                return true;
            }
            this.<>f__this.gameObject.camera.enabled = false;
            this.$PC = -1;
        Label_007B:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        [DebuggerHidden]
        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
            {
                return this;
            }
            return new SceneMgr.<DisableCameraCo>c__Iterator9F { <>f__this = this.<>f__this };
        }

        [DebuggerHidden]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
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
    private sealed class <LoadScene>c__IteratorA0 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal string <$>sceneName;
        internal SceneMgr <>f__this;
        internal UnityEngine.AsyncOperation <async>__0;
        internal string sceneName;

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
                    this.<async>__0 = Application.LoadLevelAdditiveAsync(this.sceneName);
                    this.$current = this.<>f__this.StartCoroutine(this.<>f__this.WaitForLevelLoad(this.<async>__0));
                    this.$PC = 1;
                    return true;

                case 1:
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
    private sealed class <SwitchMode>c__IteratorA2 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SceneMgr <>f__this;
        internal Camera <fullScreenEffectsCamera>__1;
        internal Scene <prevScene>__0;

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
                    if (!this.<>f__this.m_scene.IsUnloading())
                    {
                        this.<prevScene>__0 = this.<>f__this.m_scene;
                        this.<>f__this.FireScenePreUnloadEvent(this.<prevScene>__0);
                        this.<fullScreenEffectsCamera>__1 = CameraUtils.FindFullScreenEffectsCamera(true);
                        if (this.<fullScreenEffectsCamera>__1 != null)
                        {
                            this.$current = new WaitForEndOfFrame();
                            this.$PC = 1;
                            goto Label_015E;
                        }
                        break;
                    }
                    goto Label_015C;

                case 1:
                    break;

                case 2:
                    goto Label_00D6;

                case 3:
                    goto Label_0106;

                default:
                    goto Label_015C;
            }
            if (!this.<>f__this.ShouldUseSceneUnloadDelays())
            {
                goto Label_0106;
            }
            if (Box.Get() == null)
            {
                this.$current = new WaitForSeconds(0.15f);
                this.$PC = 3;
                goto Label_015E;
            }
        Label_00D6:
            while (Box.Get().HasPendingEffects())
            {
                this.$current = 0;
                this.$PC = 2;
                goto Label_015E;
            }
        Label_0106:
            this.<>f__this.m_scene.Unload();
            this.<>f__this.m_scene = null;
            this.<>f__this.m_sceneLoaded = false;
            this.<>f__this.FireSceneUnloadedEvent(this.<prevScene>__0);
            this.<>f__this.PostUnloadCleanup();
            this.<>f__this.LoadModeFromModeSwitch();
            this.$PC = -1;
        Label_015C:
            return false;
        Label_015E:
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

    [CompilerGenerated]
    private sealed class <WaitForLevelLoad>c__IteratorA1 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal UnityEngine.AsyncOperation <$>async;
        internal UnityEngine.AsyncOperation async;

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
                    if (!this.async.isDone || !SpellCache.Get().IsLoaded())
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
    private sealed class <WaitThenFireSceneLoadedEvent>c__Iterator9E : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SceneMgr <>f__this;

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
                    this.$current = new WaitForSeconds(0.15f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.FireSceneLoadedEvent();
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

    public enum Mode
    {
        [Description("CollectionManager")]
        COLLECTIONMANAGER = 5,
        [Description("Draft")]
        DRAFT = 9,
        [Description("FatalError")]
        FATAL_ERROR = 8,
        [Description("Friendly")]
        FRIENDLY = 7,
        [Description("Gameplay")]
        GAMEPLAY = 4,
        [Description("Hub")]
        HUB = 3,
        INVALID = 0,
        [Description("Login")]
        LOGIN = 2,
        [Description("Practice")]
        PRACTICE = 10,
        STARTUP = 1,
        [Description("Tournament")]
        TOURNAMENT = 6
    }

    public delegate void SceneLoadedCallback(SceneMgr.Mode mode, Scene scene, object userData);

    private class SceneLoadedListener : EventListener<SceneMgr.SceneLoadedCallback>
    {
        public void Fire(SceneMgr.Mode mode, Scene scene)
        {
            base.m_callback(mode, scene, base.m_userData);
        }
    }

    public delegate void ScenePreUnloadCallback(SceneMgr.Mode prevMode, Scene prevScene, object userData);

    private class ScenePreUnloadListener : EventListener<SceneMgr.ScenePreUnloadCallback>
    {
        public void Fire(SceneMgr.Mode prevMode, Scene prevScene)
        {
            base.m_callback(prevMode, prevScene, base.m_userData);
        }
    }

    public delegate void SceneUnloadedCallback(SceneMgr.Mode prevMode, Scene prevScene, object userData);

    private class SceneUnloadedListener : EventListener<SceneMgr.SceneUnloadedCallback>
    {
        public void Fire(SceneMgr.Mode prevMode, Scene prevScene)
        {
            base.m_callback(prevMode, prevScene, base.m_userData);
        }
    }
}


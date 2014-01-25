using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    private long m_assetLoadEndTimestamp;
    private long m_assetLoadNextStartTimestamp;
    private long m_assetLoadStartTimestamp;
    public iTween.EaseType m_FadeInEaseType = iTween.EaseType.linear;
    public float m_FadeInSec = 1f;
    public iTween.EaseType m_FadeOutEaseType = iTween.EaseType.linear;
    public float m_FadeOutSec = 1f;
    private List<FinishedTransitionListener> m_finishedTransitionListeners = new List<FinishedTransitionListener>();
    private Camera m_fxCamera;
    private float m_originalPosX;
    private bool m_previousSceneActive;
    private List<PreviousSceneDestroyedListener> m_prevSceneDestroyedListeners = new List<PreviousSceneDestroyedListener>();
    private TransitionParams m_prevTransitionParams;
    private List<GameStringCategory> m_stringCategoriesToUnload = new List<GameStringCategory>();
    private bool m_transitioning;
    private TransitionParams m_transitionParams = new TransitionParams();
    private const float MIDDLE_OF_NOWHERE_X = 5000f;
    private static LoadingScreen s_instance;

    public void AddStringsToUnload(GameStringCategory category)
    {
        this.m_stringCategoriesToUnload.Add(category);
    }

    public void AddTransitionBlocker()
    {
        this.m_transitionParams.AddBlocker();
    }

    public void AddTransitionBlocker(int count)
    {
        this.m_transitionParams.AddBlocker(count);
    }

    public void AddTransitionObject(Component c)
    {
        this.m_transitionParams.AddObject(c.gameObject);
    }

    public void AddTransitionObject(GameObject go)
    {
        this.m_transitionParams.AddObject(go);
    }

    private void Awake()
    {
        s_instance = this;
        this.InitializeFxCamera();
    }

    private void ClearAssetCache()
    {
        AssetCache.ClearAllCachesBetween(this.m_assetLoadStartTimestamp, this.m_assetLoadEndTimestamp);
        this.m_assetLoadEndTimestamp = 0L;
        this.m_assetLoadStartTimestamp = this.m_assetLoadNextStartTimestamp;
        this.m_assetLoadNextStartTimestamp = 0L;
    }

    private void ClearUnusedAssets()
    {
        foreach (GameStringCategory category in this.m_stringCategoriesToUnload)
        {
            GameStrings.UnloadCategory(category);
        }
        this.m_stringCategoriesToUnload.Clear();
        this.ClearAssetCache();
        Resources.UnloadUnusedAssets();
    }

    private void CutoffTransition()
    {
        iTween.Stop(base.gameObject);
        this.FinishPreviousScene();
        this.m_prevTransitionParams = null;
        this.m_transitionParams = new TransitionParams();
        this.m_transitioning = false;
        this.FireFinishedTransitionListeners();
    }

    private void DisableTransitionUnfriendlyStuff(GameObject mainObject)
    {
        TransitionUnfriendlyData userData = new TransitionUnfriendlyData();
        AudioListener componentInChildren = base.GetComponentInChildren<AudioListener>();
        if ((componentInChildren != null) && componentInChildren.enabled)
        {
            AudioListener listener = mainObject.GetComponentInChildren<AudioListener>();
            userData.SetAudioListener(listener);
        }
        Light[] componentsInChildren = mainObject.GetComponentsInChildren<Light>();
        userData.AddLights(componentsInChildren);
        this.RegisterPreviousSceneDestroyedListener(new PreviousSceneDestroyedCallback(this.OnPreviousSceneDestroyed), userData);
    }

    public static bool DoesShowLoadingScreen(SceneMgr.Mode prevMode, SceneMgr.Mode nextMode)
    {
        return ((prevMode == SceneMgr.Mode.GAMEPLAY) || (nextMode == SceneMgr.Mode.GAMEPLAY));
    }

    public void EnableFadeIn(bool enable)
    {
        this.m_transitionParams.EnableFadeIn(enable);
    }

    public void EnableFadeOut(bool enable)
    {
        this.m_transitionParams.EnableFadeOut(enable);
    }

    public void EnableTransition(bool enable)
    {
        this.m_transitionParams.Enable(enable);
    }

    private void FadeIn()
    {
        <FadeIn>c__AnonStorey142 storey = new <FadeIn>c__AnonStorey142();
        if (!this.m_prevTransitionParams.IsFadeInEnabled())
        {
            this.OnFadeInComplete();
        }
        else
        {
            this.m_fxCamera.enabled = true;
            storey.fullScreen = this.GetFullScreenEffects(this.m_fxCamera);
            storey.fullScreen.enabled = true;
            storey.fullScreen.BlendToColorEnable = true;
            storey.fullScreen.BlendToColor = this.m_prevTransitionParams.GetFadeColor();
            Action<object> action = new Action<object>(storey.<>m__54);
            action(1f);
            object[] args = new object[] { "time", this.m_FadeOutSec, "from", 1f, "to", 0f, "onupdate", action, "onupdatetarget", base.gameObject, "oncomplete", "OnFadeInComplete", "oncompletetarget", base.gameObject };
            Hashtable hashtable = iTween.Hash(args);
            iTween.ValueTo(base.gameObject, hashtable);
        }
    }

    private void FadeOut()
    {
        <FadeOut>c__AnonStorey141 storey = new <FadeOut>c__AnonStorey141();
        if (!this.m_prevTransitionParams.IsFadeOutEnabled())
        {
            this.OnFadeOutComplete();
        }
        else
        {
            this.m_fxCamera.enabled = true;
            storey.fullScreen = this.GetFullScreenEffects(this.m_fxCamera);
            storey.fullScreen.enabled = true;
            storey.fullScreen.BlendToColorEnable = true;
            storey.fullScreen.BlendToColor = this.m_prevTransitionParams.GetFadeColor();
            Action<object> action = new Action<object>(storey.<>m__53);
            action(0f);
            object[] args = new object[] { "time", this.m_FadeOutSec, "from", 0f, "to", 1f, "onupdate", action, "onupdatetarget", base.gameObject, "oncomplete", "OnFadeOutComplete", "oncompletetarget", base.gameObject };
            Hashtable hashtable = iTween.Hash(args);
            iTween.ValueTo(base.gameObject, hashtable);
        }
    }

    private void FinishPreviousScene()
    {
        if (this.m_prevTransitionParams != null)
        {
            this.m_prevTransitionParams.DestroyObjects();
            TransformUtil.SetPosX(base.gameObject, this.m_originalPosX);
        }
        this.ClearUnusedAssets();
        this.m_previousSceneActive = false;
        this.FirePreviousSceneDestroyedListeners();
    }

    private void FireFinishedTransitionListeners()
    {
        FinishedTransitionListener[] listenerArray = this.m_finishedTransitionListeners.ToArray();
        for (int i = 0; i < listenerArray.Length; i++)
        {
            listenerArray[i].Fire();
        }
    }

    private void FirePreviousSceneDestroyedListeners()
    {
        PreviousSceneDestroyedListener[] listenerArray = this.m_prevSceneDestroyedListeners.ToArray();
        for (int i = 0; i < listenerArray.Length; i++)
        {
            listenerArray[i].Fire();
        }
    }

    public static LoadingScreen Get()
    {
        return s_instance;
    }

    public long GetAssetLoadStartTimestamp()
    {
        return this.m_assetLoadStartTimestamp;
    }

    public Color GetFadeColor()
    {
        return this.m_transitionParams.GetFadeColor();
    }

    public Camera GetFreezeFrameCamera()
    {
        return this.m_transitionParams.GetFreezeFrameCamera();
    }

    private FullScreenEffects GetFullScreenEffects(Camera camera)
    {
        FullScreenEffects component = camera.GetComponent<FullScreenEffects>();
        if (component != null)
        {
            return component;
        }
        return camera.gameObject.AddComponent<FullScreenEffects>();
    }

    [DebuggerHidden]
    private IEnumerator HackWaitThenStartTransitionEffects()
    {
        return new <HackWaitThenStartTransitionEffects>c__IteratorDF { <>f__this = this };
    }

    private void InitializeFxCamera()
    {
        this.m_fxCamera = base.GetComponent<Camera>();
        this.m_fxCamera.depth = 14f;
    }

    public bool IsPreviousSceneActive()
    {
        if (!this.m_transitioning)
        {
            return false;
        }
        return this.m_previousSceneActive;
    }

    public bool IsTransitionEnabled()
    {
        return this.m_transitionParams.IsEnabled();
    }

    public bool IsTransitioning()
    {
        return this.m_transitioning;
    }

    public void NotifyMainSceneObjectAwoke(GameObject mainObject)
    {
        if (this.IsPreviousSceneActive())
        {
            this.DisableTransitionUnfriendlyStuff(mainObject);
        }
    }

    public void NotifyTransitionBlockerComplete()
    {
        if (this.m_prevTransitionParams != null)
        {
            this.m_prevTransitionParams.RemoveBlocker();
            this.TransitionIfPossible();
        }
    }

    public void NotifyTransitionBlockerComplete(int count)
    {
        if (this.m_prevTransitionParams != null)
        {
            this.m_prevTransitionParams.RemoveBlocker(count);
            this.TransitionIfPossible();
        }
    }

    private void OnFadeInComplete()
    {
        this.m_prevTransitionParams = null;
        FullScreenEffects fullScreenEffects = this.GetFullScreenEffects(this.m_fxCamera);
        fullScreenEffects.BlendToColorEnable = false;
        fullScreenEffects.Disable();
        this.m_fxCamera.enabled = false;
        this.m_transitioning = false;
        this.FireFinishedTransitionListeners();
    }

    private void OnFadeOutComplete()
    {
        this.FinishPreviousScene();
        this.FadeIn();
    }

    private void OnFullScreenFadeInComplete(FullScreenEffects fullScreen)
    {
        fullScreen.BlendToColorEnable = false;
        fullScreen.Disable();
    }

    private void OnPreviousSceneDestroyed(object userData)
    {
        TransitionUnfriendlyData data = (TransitionUnfriendlyData) userData;
        this.UnregisterPreviousSceneDestroyedListener(new PreviousSceneDestroyedCallback(this.OnPreviousSceneDestroyed), data);
        data.Restore();
    }

    private void OnSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
        if (SceneMgr.Get().GetPrevMode() == SceneMgr.Mode.STARTUP)
        {
            this.m_assetLoadStartTimestamp = Blizzard.Time.BinaryStamp();
        }
        if (this.IsTransitioning() && !this.TransitionIfPossible())
        {
        }
    }

    private void OnScenePreUnload(SceneMgr.Mode prevMode, Scene prevScene, object userData)
    {
        if (this.IsTransitioning())
        {
            this.CutoffTransition();
        }
        else if (!DoesShowLoadingScreen(prevMode, SceneMgr.Get().GetMode()))
        {
            this.m_transitionParams = new TransitionParams();
        }
        else if (!this.m_transitionParams.IsEnabled())
        {
            this.m_transitionParams = new TransitionParams();
        }
        else
        {
            this.m_transitioning = true;
            this.m_previousSceneActive = true;
            this.ShowFreezeFrame(this.m_transitionParams.GetFreezeFrameCamera());
        }
    }

    private void OnSceneUnloaded(SceneMgr.Mode prevMode, Scene prevScene, object userData)
    {
        this.m_assetLoadNextStartTimestamp = Blizzard.Time.BinaryStamp();
        if (this.IsTransitioning())
        {
            this.m_assetLoadEndTimestamp = this.m_assetLoadNextStartTimestamp;
            this.m_prevTransitionParams = this.m_transitionParams;
            this.m_transitionParams = new TransitionParams();
            this.m_prevTransitionParams.AutoAddObjects();
            this.m_prevTransitionParams.FixupCameras(this.m_fxCamera);
            this.m_prevTransitionParams.PreserveObjects(base.transform);
            this.m_originalPosX = base.transform.position.x;
            TransformUtil.SetPosX(base.gameObject, 5000f);
        }
    }

    public bool RegisterFinishedTransitionListener(FinishedTransitionCallback callback)
    {
        return this.RegisterFinishedTransitionListener(callback, null);
    }

    public bool RegisterFinishedTransitionListener(FinishedTransitionCallback callback, object userData)
    {
        FinishedTransitionListener item = new FinishedTransitionListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_finishedTransitionListeners.Contains(item))
        {
            return false;
        }
        this.m_finishedTransitionListeners.Add(item);
        return true;
    }

    public bool RegisterPreviousSceneDestroyedListener(PreviousSceneDestroyedCallback callback)
    {
        return this.RegisterPreviousSceneDestroyedListener(callback, null);
    }

    public bool RegisterPreviousSceneDestroyedListener(PreviousSceneDestroyedCallback callback, object userData)
    {
        PreviousSceneDestroyedListener item = new PreviousSceneDestroyedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_prevSceneDestroyedListeners.Contains(item))
        {
            return false;
        }
        this.m_prevSceneDestroyedListeners.Add(item);
        return true;
    }

    public void SetAssetLoadStartTimestamp(long timestamp)
    {
        this.m_assetLoadStartTimestamp = Math.Min(this.m_assetLoadStartTimestamp, timestamp);
    }

    public void SetFadeColor(Color color)
    {
        this.m_transitionParams.SetFadeColor(color);
    }

    public void SetFreezeFrameCamera(Camera camera)
    {
        this.m_transitionParams.SetFreezeFrameCamera(camera);
    }

    private void ShowFreezeFrame(Camera camera)
    {
        if (camera != null)
        {
            this.GetFullScreenEffects(camera).Freeze();
        }
    }

    private void Start()
    {
        SceneMgr.Get().RegisterScenePreUnloadEvent(new SceneMgr.ScenePreUnloadCallback(this.OnScenePreUnload));
        SceneMgr.Get().RegisterSceneUnloadedEvent(new SceneMgr.SceneUnloadedCallback(this.OnSceneUnloaded));
        SceneMgr.Get().RegisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
    }

    private bool TransitionIfPossible()
    {
        if (this.m_prevTransitionParams.GetBlockerCount() > 0)
        {
            return false;
        }
        base.StartCoroutine(this.HackWaitThenStartTransitionEffects());
        return true;
    }

    public bool UnregisterFinishedTransitionListener(FinishedTransitionCallback callback)
    {
        return this.UnregisterFinishedTransitionListener(callback, null);
    }

    public bool UnregisterFinishedTransitionListener(FinishedTransitionCallback callback, object userData)
    {
        FinishedTransitionListener item = new FinishedTransitionListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_finishedTransitionListeners.Remove(item);
    }

    public bool UnregisterPreviousSceneDestroyedListener(PreviousSceneDestroyedCallback callback)
    {
        return this.UnregisterPreviousSceneDestroyedListener(callback, null);
    }

    public bool UnregisterPreviousSceneDestroyedListener(PreviousSceneDestroyedCallback callback, object userData)
    {
        PreviousSceneDestroyedListener item = new PreviousSceneDestroyedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_prevSceneDestroyedListeners.Remove(item);
    }

    [CompilerGenerated]
    private sealed class <FadeIn>c__AnonStorey142
    {
        internal FullScreenEffects fullScreen;

        internal void <>m__54(object amount)
        {
            this.fullScreen.BlendToColorAmount = (float) amount;
        }
    }

    [CompilerGenerated]
    private sealed class <FadeOut>c__AnonStorey141
    {
        internal FullScreenEffects fullScreen;

        internal void <>m__53(object amount)
        {
            this.fullScreen.BlendToColorAmount = (float) amount;
        }
    }

    [CompilerGenerated]
    private sealed class <HackWaitThenStartTransitionEffects>c__IteratorDF : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal LoadingScreen <>f__this;

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
                    this.$current = new WaitForEndOfFrame();
                    this.$PC = 1;
                    return true;

                case 1:
                    if (this.<>f__this.IsTransitioning())
                    {
                        this.<>f__this.FadeOut();
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

    public delegate void FinishedTransitionCallback(object userData);

    private class FinishedTransitionListener : EventListener<LoadingScreen.FinishedTransitionCallback>
    {
        public void Fire()
        {
            base.m_callback(base.m_userData);
        }
    }

    public delegate void PreviousSceneDestroyedCallback(object userData);

    private class PreviousSceneDestroyedListener : EventListener<LoadingScreen.PreviousSceneDestroyedCallback>
    {
        public void Fire()
        {
            base.m_callback(base.m_userData);
        }
    }

    private class TransitionParams
    {
        private int m_blockerCount;
        private List<Camera> m_cameras = new List<Camera>();
        private bool m_enabled = true;
        private Color m_fadeColor = Color.black;
        private bool m_fadeIn = true;
        private bool m_fadeOut = true;
        private Camera m_freezeFrameCamera;
        private List<Light> m_lights = new List<Light>();
        private List<GameObject> m_objects = new List<GameObject>();

        public void AddBlocker()
        {
            this.m_blockerCount++;
        }

        public void AddBlocker(int count)
        {
            this.m_blockerCount += count;
        }

        public void AddObject(Component c)
        {
            if (c != null)
            {
                this.AddObject(c.gameObject);
            }
        }

        public void AddObject(GameObject go)
        {
            if (go != null)
            {
                for (Transform transform = go.transform; transform != null; transform = transform.parent)
                {
                    if (this.m_objects.Contains(transform.gameObject))
                    {
                        return;
                    }
                }
                foreach (Camera camera in go.GetComponentsInChildren<Camera>())
                {
                    if (!this.m_cameras.Contains(camera))
                    {
                        this.m_cameras.Add(camera);
                    }
                }
                this.m_objects.Add(go);
            }
        }

        public void AutoAddObjects()
        {
            Light[] lightArray = (Light[]) UnityEngine.Object.FindObjectsOfType(typeof(Light));
            foreach (Light light in lightArray)
            {
                this.AddObject(light.gameObject);
                this.m_lights.Add(light);
            }
        }

        public void DestroyObjects()
        {
            foreach (GameObject obj2 in this.m_objects)
            {
                UnityEngine.Object.DestroyImmediate(obj2);
            }
        }

        public void Enable(bool enable)
        {
            this.m_enabled = enable;
        }

        public void EnableFadeIn(bool enable)
        {
            this.m_fadeIn = enable;
        }

        public void EnableFadeOut(bool enable)
        {
            this.m_fadeOut = enable;
        }

        public void FixupCameras(Camera fxCamera)
        {
            if (this.m_cameras.Count != 0)
            {
                Camera camera = this.m_cameras[0];
                camera.tag = "Untagged";
                float depth = camera.depth;
                for (int i = 1; i < this.m_cameras.Count; i++)
                {
                    Camera camera2 = this.m_cameras[i];
                    camera2.tag = "Untagged";
                    if (camera2.depth > depth)
                    {
                        depth = camera2.depth;
                    }
                }
                float num3 = (fxCamera.depth - 1f) - depth;
                for (int j = 0; j < this.m_cameras.Count; j++)
                {
                    Camera camera3 = this.m_cameras[j];
                    camera3.depth += num3;
                }
            }
        }

        public int GetBlockerCount()
        {
            return this.m_blockerCount;
        }

        public List<Camera> GetCameras()
        {
            return this.m_cameras;
        }

        public Color GetFadeColor()
        {
            return this.m_fadeColor;
        }

        public Camera GetFreezeFrameCamera()
        {
            return this.m_freezeFrameCamera;
        }

        public List<Light> GetLights()
        {
            return this.m_lights;
        }

        public bool IsEnabled()
        {
            return this.m_enabled;
        }

        public bool IsFadeInEnabled()
        {
            return this.m_fadeIn;
        }

        public bool IsFadeOutEnabled()
        {
            return this.m_fadeOut;
        }

        public void PreserveObjects(Transform parent)
        {
            foreach (GameObject obj2 in this.m_objects)
            {
                obj2.transform.parent = parent;
            }
        }

        public void RemoveBlocker()
        {
            this.m_blockerCount--;
        }

        public void RemoveBlocker(int count)
        {
            this.m_blockerCount -= count;
        }

        public void SetFadeColor(Color color)
        {
            this.m_fadeColor = color;
        }

        public void SetFreezeFrameCamera(Camera camera)
        {
            if (camera != null)
            {
                this.m_freezeFrameCamera = camera;
                this.AddObject(camera.gameObject);
            }
        }
    }

    private class TransitionUnfriendlyData
    {
        private AudioListener m_audioListener;
        private List<Light> m_lights = new List<Light>();

        public void AddLights(Light[] lights)
        {
            foreach (Light light in lights)
            {
                if (light.enabled)
                {
                    light.enabled = false;
                    for (Transform transform = light.transform; transform.parent != null; transform = transform.parent)
                    {
                    }
                    this.m_lights.Add(light);
                }
            }
        }

        public AudioListener GetAudioListener()
        {
            return this.m_audioListener;
        }

        public List<Light> GetLights()
        {
            return this.m_lights;
        }

        public void Restore()
        {
            for (int i = 0; i < this.m_lights.Count; i++)
            {
                Light light = this.m_lights[i];
                if (light == null)
                {
                    UnityEngine.Debug.LogError(string.Format("TransitionUnfriendlyData.Restore() - light {0} is null!", i));
                }
                else
                {
                    for (Transform transform = light.transform; transform.parent != null; transform = transform.parent)
                    {
                    }
                    light.enabled = true;
                }
            }
            if (this.m_audioListener != null)
            {
                this.m_audioListener.enabled = true;
            }
        }

        public void SetAudioListener(AudioListener listener)
        {
            if ((listener != null) && listener.enabled)
            {
                this.m_audioListener = listener;
                listener.enabled = false;
            }
        }
    }
}


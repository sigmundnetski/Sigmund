using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private bool m_ambienceIsAboutToPlay;
    private List<Track> m_ambiencePlaylist = new List<Track>();
    private List<AmbienceTrackChangedListener> m_ambienceTrackChangedListeners = new List<AmbienceTrackChangedListener>();
    private Dictionary<string, BundleInfo> m_bundleInfos = new Dictionary<string, BundleInfo>();
    private SoundConfig m_config;
    private AudioSource m_currentAmbienceTrack;
    private AudioSource m_currentMusicTrack;
    private List<AudioSource> m_deadSources = new List<AudioSource>();
    private Dictionary<SoundCategory, List<DuckState>> m_duckStates = new Dictionary<SoundCategory, List<DuckState>>();
    private Dictionary<AudioSource, SourceExtension> m_extensions = new Dictionary<AudioSource, SourceExtension>();
    private List<AudioSource> m_fadingTracks = new List<AudioSource>();
    private uint m_frame;
    private List<AudioSource> m_generatedSources = new List<AudioSource>();
    private List<AudioSource> m_inactiveSources = new List<AudioSource>();
    private bool m_musicIsAboutToPlay;
    private List<Track> m_musicPlaylist = new List<Track>();
    private List<MusicTrackChangedListener> m_musicTrackChangedListeners = new List<MusicTrackChangedListener>();
    private bool m_mute;
    private uint m_nextDuckStateTweenId;
    private int m_nextSourceId;
    private Dictionary<SoundCategory, List<AudioSource>> m_sourcesByCategory = new Dictionary<SoundCategory, List<AudioSource>>();
    private Dictionary<string, List<AudioSource>> m_sourcesByClipName = new Dictionary<string, List<AudioSource>>();
    private static SoundManager s_instance;

    public bool AddAmbienceTrackChangedListener(AmbienceTrackChangedCallback callback)
    {
        return this.AddAmbienceTrackChangedListener(callback, null);
    }

    public bool AddAmbienceTrackChangedListener(AmbienceTrackChangedCallback callback, object userData)
    {
        AmbienceTrackChangedListener item = new AmbienceTrackChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_ambienceTrackChangedListeners.Contains(item))
        {
            return false;
        }
        this.m_ambienceTrackChangedListeners.Add(item);
        return true;
    }

    public bool AddMusicTrackChangedListener(MusicTrackChangedCallback callback)
    {
        return this.AddMusicTrackChangedListener(callback, null);
    }

    public bool AddMusicTrackChangedListener(MusicTrackChangedCallback callback, object userData)
    {
        MusicTrackChangedListener item = new MusicTrackChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_musicTrackChangedListeners.Contains(item))
        {
            return false;
        }
        this.m_musicTrackChangedListeners.Add(item);
        return true;
    }

    public void AddNewAmbienceTrack(string name)
    {
        this.AddNewAmbienceTrack(name, 1f);
    }

    public void AddNewAmbienceTrack(string name, float volume)
    {
        Track item = new Track {
            m_name = name,
            m_volume = volume
        };
        this.m_ambiencePlaylist.Add(item);
    }

    public void AddNewMusicTrack(string name)
    {
        this.AddNewMusicTrack(name, 1f);
    }

    public void AddNewMusicTrack(string name, float volume)
    {
        Track item = new Track {
            m_name = name,
            m_volume = volume
        };
        this.m_musicPlaylist.Add(item);
    }

    private void AttachSourceToParent(AudioSource source, GameObject parentObject)
    {
        source.transform.parent = base.transform;
        if (parentObject == null)
        {
            source.transform.position = Vector3.zero;
        }
        else
        {
            source.transform.position = parentObject.transform.position;
        }
    }

    private void Awake()
    {
        s_instance = this;
        this.InitializeOptions();
    }

    private void BeginDuckState(DuckState state)
    {
        <BeginDuckState>c__AnonStorey144 storey;
        storey = new <BeginDuckState>c__AnonStorey144 {
            state = state,
            <>f__this = this,
            duckedDef = storey.state.m_duckedDef
        };
        if (storey.state.m_tweenName != null)
        {
            iTween.StopByName(base.gameObject, storey.state.m_tweenName);
        }
        storey.state.m_tweenName = string.Format("DuckState Begin id={0}", this.GetNextDuckStateTweenId());
        float volume = storey.state.m_volume;
        float num2 = storey.duckedDef.m_Volume;
        Action<object> action = new Action<object>(storey.<>m__57);
        object[] args = new object[] { 
            "name", storey.state.m_tweenName, "time", storey.duckedDef.m_BeginSec, "easeType", storey.duckedDef.m_BeginEaseType, "from", volume, "to", num2, "onupdate", action, "onupdatetarget", base.gameObject, "oncomplete", "OnBeginDuckStateComplete", 
            "oncompletetarget", base.gameObject, "oncompleteparams", storey.state
         };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(base.gameObject, hashtable);
    }

    private void ChangeCurrentAmbienceTrack(AudioSource source)
    {
        this.m_currentAmbienceTrack = source;
        this.FireAmbienceTrackChangedListeners();
    }

    private void ChangeCurrentMusicTrack(AudioSource source)
    {
        this.m_currentMusicTrack = source;
        this.FireMusicTrackChangedListeners();
    }

    private void CleanDeadDuckStates()
    {
        foreach (List<DuckState> list in this.m_duckStates.Values)
        {
            foreach (DuckState state in list)
            {
                if (state.GetTrigger() == null)
                {
                    this.FinishDuckState(state);
                }
            }
        }
    }

    private void CleanDeadSource(AudioSource source)
    {
        object[] args = new object[] { this.GetSourceId(source), source };
        Log.Sound.ScreenPrint("SoundManager.CleanDeadSource() - id={0} source={1}", args);
        this.UnregisterDeadSourceByCategory(source);
        this.UnregisterDeadSourceByClip(source);
        this.UnregisterDeadSourceBundle(source);
        this.FinishDeadGeneratedSource(source);
        this.m_extensions.Remove(source);
    }

    private void CleanDeadSources()
    {
        foreach (AudioSource source in this.m_deadSources)
        {
            object[] args = new object[] { this.GetSourceId(source), source };
            Log.Sound.ScreenPrint("SoundManager.CleanDeadSources() - id={0} source={1}", args);
            this.CleanDeadSource(source);
        }
        this.m_deadSources.Clear();
    }

    private void CleanInactiveSources()
    {
        foreach (AudioSource source in this.m_inactiveSources)
        {
            object[] args = new object[] { this.GetSourceId(source), source, this.m_frame };
            Log.Sound.ScreenPrint("SoundManager.CleanInactiveSources() - id={0} source={1} frame={2}", args);
            this.FinishSource(source);
        }
        this.m_inactiveSources.Clear();
    }

    [DebuggerHidden]
    private IEnumerator FadeTrack(AudioSource source, float targetVolume)
    {
        return new <FadeTrack>c__IteratorE4 { source = source, targetVolume = targetVolume, <$>source = source, <$>targetVolume = targetVolume, <>f__this = this };
    }

    private void FadeTrackOut(AudioSource source)
    {
        if (!this.IsActive(source))
        {
            object[] args = new object[] { (source != null) ? this.GetSourceId(source) : 0, source, source == null, this.m_frame };
            Log.Sound.ScreenPrint("SoundManager.FadeTrackOut() - id={0} source={1} (null={2}) frame={3}", args);
            this.FinishSource(source);
        }
        else
        {
            base.StartCoroutine(this.FadeTrack(source, 0f));
        }
    }

    private SoundPlaybackLimitClipDef FindClipDefInPlaybackDef(string clipName, SoundPlaybackLimitDef def)
    {
        if (def.m_ClipDefs != null)
        {
            foreach (SoundPlaybackLimitClipDef def2 in def.m_ClipDefs)
            {
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(def2.m_Path);
                if (clipName == fileNameWithoutExtension)
                {
                    return def2;
                }
            }
        }
        return null;
    }

    private SoundDuckingDef FindDuckingDefForCategory(SoundCategory cat)
    {
        if (this.m_config.m_DuckingDefs != null)
        {
            foreach (SoundDuckingDef def in this.m_config.m_DuckingDefs)
            {
                if (cat == def.m_TriggerCategory)
                {
                    return def;
                }
            }
        }
        return null;
    }

    private SoundDuckingDef FindDuckingDefForSource(AudioSource source)
    {
        SoundCategory cat = this.GetCategory(source);
        return this.FindDuckingDefForCategory(cat);
    }

    private bool FindPlaybackLimitDef(AudioClip clip, out SoundPlaybackLimitDef def, out SoundPlaybackLimitClipDef clipDef)
    {
        def = null;
        clipDef = null;
        if (this.m_config != null)
        {
            string name = clip.name;
            foreach (SoundPlaybackLimitDef def2 in this.m_config.m_PlaybackLimitDefs)
            {
                foreach (SoundPlaybackLimitClipDef def3 in def2.m_ClipDefs)
                {
                    if (System.IO.Path.GetFileNameWithoutExtension(def3.m_Path) == name)
                    {
                        def = def2;
                        clipDef = def3;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void FinishDeadGeneratedSource(AudioSource source)
    {
        for (int i = 0; i < this.m_generatedSources.Count; i++)
        {
            AudioSource source2 = this.m_generatedSources[i];
            if (source2 == source)
            {
                this.m_generatedSources.RemoveAt(i);
                return;
            }
        }
    }

    private void FinishDuckState(DuckState state)
    {
        <FinishDuckState>c__AnonStorey145 storey;
        storey = new <FinishDuckState>c__AnonStorey145 {
            state = state,
            <>f__this = this,
            duckedDef = storey.state.m_duckedDef
        };
        if (storey.state.m_tweenName != null)
        {
            iTween.StopByName(base.gameObject, storey.state.m_tweenName);
        }
        storey.state.m_tweenName = string.Format("DuckState Finish id={0}", this.GetNextDuckStateTweenId());
        float volume = storey.state.m_volume;
        float num2 = 1f;
        Action<object> action = new Action<object>(storey.<>m__58);
        object[] args = new object[] { 
            "name", storey.state.m_tweenName, "time", storey.duckedDef.m_RestoreSec, "easeType", storey.duckedDef.m_RestoreEaseType, "from", volume, "to", num2, "onupdate", action, "onupdatetarget", base.gameObject, "oncomplete", "OnFinishDuckStateComplete", 
            "oncompletetarget", base.gameObject, "oncompleteparams", storey.state
         };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(base.gameObject, hashtable);
    }

    private void FinishGeneratedSource(AudioSource source)
    {
        for (int i = 0; i < this.m_generatedSources.Count; i++)
        {
            AudioSource source2 = this.m_generatedSources[i];
            if (source2 == source)
            {
                UnityEngine.Object.DestroyImmediate(source.gameObject);
                this.m_generatedSources.RemoveAt(i);
                return;
            }
        }
    }

    private void FinishSource(AudioSource source)
    {
        object[] args = new object[] { this.GetSourceId(source), source, this.m_frame };
        Log.Sound.ScreenPrint("SoundManager.FinishSource() - id={0} source={1} frame={2}", args);
        this.UnregisterExtension(source);
        if (this.m_currentMusicTrack == source)
        {
            this.ChangeCurrentMusicTrack(null);
        }
        else if (this.m_currentAmbienceTrack == source)
        {
            this.ChangeCurrentAmbienceTrack(null);
        }
        for (int i = 0; i < this.m_fadingTracks.Count; i++)
        {
            AudioSource source2 = this.m_fadingTracks[i];
            if (source2 == source)
            {
                this.m_fadingTracks.RemoveAt(i);
                break;
            }
        }
        this.UnregisterSourceForDucking(source);
        this.UnregisterSourceBundle(source);
        this.FinishGeneratedSource(source);
    }

    private void FireAmbienceTrackChangedListeners()
    {
        foreach (AmbienceTrackChangedListener listener in this.m_ambienceTrackChangedListeners.ToArray())
        {
            listener.Fire(this.m_currentAmbienceTrack);
        }
    }

    private void FireMusicTrackChangedListeners()
    {
        foreach (MusicTrackChangedListener listener in this.m_musicTrackChangedListeners.ToArray())
        {
            listener.Fire(this.m_currentMusicTrack);
        }
    }

    private void GarbageCollectBundles()
    {
        Dictionary<string, BundleInfo> dictionary = new Dictionary<string, BundleInfo>();
        foreach (KeyValuePair<string, BundleInfo> pair in this.m_bundleInfos)
        {
            string key = pair.Key;
            BundleInfo info = pair.Value;
            info.EnableGarbageCollect(true);
            if (info.CanGarbageCollect())
            {
                this.UnloadSoundBundle(key);
            }
            else
            {
                dictionary.Add(key, info);
            }
        }
        this.m_bundleInfos = dictionary;
    }

    private AudioSource GenerateAudioSource(AudioSource templateSource, AudioClip clip, float volume)
    {
        GameObject go = new GameObject(string.Format("Audio Object - {0}", clip.name));
        SoundUtils.AddAudioSourceComponents(go);
        AudioSource component = go.GetComponent<AudioSource>();
        SoundUtils.CopyAudioSource(templateSource, component);
        component.clip = clip;
        component.volume = volume;
        this.AttachSourceToParent(component, templateSource.gameObject);
        this.m_generatedSources.Add(component);
        return component;
    }

    private AudioSource GenerateAudioSource(AudioClip clip, float volume, float pitch, SoundCategory cat, GameObject parentObject)
    {
        GameObject obj2;
        string name = string.Format("Audio Object - {0}", clip.name);
        if (this.m_config.m_PlayClipTemplate == null)
        {
            obj2 = new GameObject(name);
            SoundUtils.AddAudioSourceComponents(obj2);
        }
        else
        {
            obj2 = (GameObject) UnityEngine.Object.Instantiate(this.m_config.m_PlayClipTemplate.gameObject);
            obj2.name = name;
        }
        AudioSource component = obj2.GetComponent<AudioSource>();
        component.clip = clip;
        component.volume = volume;
        component.pitch = pitch;
        obj2.GetComponent<SoundDef>().m_Category = cat;
        this.AttachSourceToParent(component, parentObject);
        this.m_generatedSources.Add(component);
        return component;
    }

    public static SoundManager Get()
    {
        return s_instance;
    }

    public SoundCategory GetCategory(AudioSource source)
    {
        if (source == null)
        {
            return SoundCategory.NONE;
        }
        return SoundUtils.GetDefFromSource(source).m_Category;
    }

    private float GetCategoryVolume(AudioSource source)
    {
        return SoundUtils.GetCategoryVolume(source.GetComponent<SoundDef>().m_Category);
    }

    public SoundConfig GetConfig()
    {
        return this.m_config;
    }

    public AudioSource GetCurrentAmbienceTrack()
    {
        return this.m_currentAmbienceTrack;
    }

    public AudioSource GetCurrentMusicTrack()
    {
        return this.m_currentMusicTrack;
    }

    private float GetDuckingVolume(SoundCategory cat)
    {
        List<DuckState> list;
        if (!this.m_duckStates.TryGetValue(cat, out list))
        {
            return 1f;
        }
        float volume = 1f;
        foreach (DuckState state in list)
        {
            SoundCategory triggerCategory = state.GetTriggerCategory();
            if (((triggerCategory == SoundCategory.NONE) || SoundUtils.IsCategoryAudible(triggerCategory)) && (volume > state.m_volume))
            {
                volume = state.m_volume;
            }
        }
        return volume;
    }

    private float GetDuckingVolume(AudioSource source)
    {
        SoundDef component = source.GetComponent<SoundDef>();
        if (component.m_IgnoreDucking)
        {
            return 1f;
        }
        return this.GetDuckingVolume(component.m_Category);
    }

    private SourceExtension GetExtension(AudioSource source)
    {
        SourceExtension extension = null;
        this.m_extensions.TryGetValue(source, out extension);
        return extension;
    }

    private uint GetNextDuckStateTweenId()
    {
        this.m_nextDuckStateTweenId = (this.m_nextDuckStateTweenId + 1) & uint.MaxValue;
        return this.m_nextDuckStateTweenId;
    }

    private int GetNextSourceId()
    {
        this.m_nextSourceId = (this.m_nextSourceId + 1) & 0x7fffffff;
        return this.m_nextSourceId;
    }

    public float GetPitch(AudioSource source)
    {
        if (source == null)
        {
            return 1f;
        }
        SourceExtension extension = this.RegisterExtension(source);
        if (extension == null)
        {
            return 1f;
        }
        return extension.m_codePitch;
    }

    private int GetSourceId(AudioSource source)
    {
        SourceExtension extension;
        if (!this.m_extensions.TryGetValue(source, out extension))
        {
            return 0;
        }
        return extension.m_id;
    }

    public float GetVolume(AudioSource source)
    {
        if (source == null)
        {
            return 1f;
        }
        SourceExtension extension = this.RegisterExtension(source);
        if (extension == null)
        {
            return 1f;
        }
        return extension.m_codeVolume;
    }

    public void ImmediatelyKillMusicAndAmbience()
    {
        this.NukeMusicAndAmbiencePlaylists();
        foreach (AudioSource source in this.m_fadingTracks.ToArray())
        {
            this.FinishSource(source);
        }
        if (this.m_currentMusicTrack != null)
        {
            this.FinishSource(this.m_currentMusicTrack);
            this.ChangeCurrentMusicTrack(null);
        }
        if (this.m_currentAmbienceTrack != null)
        {
            this.FinishSource(this.m_currentAmbienceTrack);
            this.ChangeCurrentAmbienceTrack(null);
        }
    }

    private void InitializeOptions()
    {
        Options.Get().RegisterChangedListener(Option.SOUND, new Options.ChangedCallback(this.OnEnabledOptionChanged));
        Options.Get().RegisterChangedListener(Option.SOUND_VOLUME, new Options.ChangedCallback(this.OnVolumeOptionChanged));
        Options.Get().RegisterChangedListener(Option.MUSIC, new Options.ChangedCallback(this.OnEnabledOptionChanged));
        Options.Get().RegisterChangedListener(Option.MUSIC_VOLUME, new Options.ChangedCallback(this.OnVolumeOptionChanged));
    }

    public bool Is3d(AudioSource source)
    {
        if (source == null)
        {
            return false;
        }
        return (source.panLevel >= 1f);
    }

    public bool IsActive(AudioSource source)
    {
        if (source == null)
        {
            return false;
        }
        return (this.IsPlaying(source) || this.IsPaused(source));
    }

    private bool IsCategoryEnabled(AudioSource source)
    {
        return SoundUtils.IsCategoryEnabled(source.GetComponent<SoundDef>().m_Category);
    }

    public bool IsIgnoringDucking(AudioSource source)
    {
        if (source == null)
        {
            return true;
        }
        SoundDef component = source.GetComponent<SoundDef>();
        return ((component == null) || component.m_IgnoreDucking);
    }

    public bool IsPaused(AudioSource source)
    {
        SourceExtension extension;
        if (source == null)
        {
            return false;
        }
        if (!this.m_extensions.TryGetValue(source, out extension))
        {
            return false;
        }
        return extension.m_paused;
    }

    public bool IsPlaying(AudioSource source)
    {
        if (source == null)
        {
            return false;
        }
        return source.isPlaying;
    }

    public void LoadAndPlay(string soundName)
    {
        this.LoadAndPlay(soundName, null, 1f, null, null);
    }

    public void LoadAndPlay(string soundName, float volume)
    {
        this.LoadAndPlay(soundName, null, volume, null, null);
    }

    public void LoadAndPlay(string soundName, GameObject parentObject)
    {
        this.LoadAndPlay(soundName, parentObject, 1f, null, null);
    }

    public void LoadAndPlay(string soundName, GameObject parentObject, float volume)
    {
        this.LoadAndPlay(soundName, parentObject, volume, null, null);
    }

    public void LoadAndPlay(string soundName, GameObject parentObject, float volume, LoadedCallback callback)
    {
        this.LoadAndPlay(soundName, parentObject, volume, callback, null);
    }

    public void LoadAndPlay(string soundName, GameObject parentObject, float volume, LoadedCallback callback, object userData)
    {
        SoundLoadedCallbackData callbackData = new SoundLoadedCallbackData {
            m_parentObject = parentObject,
            m_volume = volume,
            m_timestamp = Blizzard.Time.BinaryStamp(),
            m_callback = callback,
            m_userData = userData
        };
        AssetLoader.Get().LoadSound(soundName, new AssetLoader.GameObjectCallback(this.OnLoadAndPlaySoundLoaded), null, true, callbackData);
    }

    public void LoadAndPlayTemplate(AudioSource templateSource, AudioClip clip)
    {
        this.LoadAndPlayTemplate(templateSource, clip, 1f, null, null);
    }

    public void LoadAndPlayTemplate(AudioSource templateSource, AudioClip clip, float volume)
    {
        this.LoadAndPlayTemplate(templateSource, clip, volume, null, null);
    }

    public void LoadAndPlayTemplate(AudioSource templateSource, AudioClip clip, float volume, LoadedCallback callback)
    {
        this.LoadAndPlayTemplate(templateSource, clip, volume, callback, null);
    }

    public void LoadAndPlayTemplate(AudioSource templateSource, AudioClip clip, float volume, LoadedCallback callback, object userData)
    {
        if (clip == null)
        {
            UnityEngine.Debug.LogError(string.Format("SoundManager.LoadAndPlayTemplate() - source {0} attempted to play a null clip", templateSource));
        }
        else
        {
            SoundLoadedCallbackData callbackData = new SoundLoadedCallbackData {
                m_templateSource = templateSource,
                m_parentObject = templateSource.gameObject,
                m_volume = volume,
                m_timestamp = Blizzard.Time.BinaryStamp(),
                m_callback = callback,
                m_userData = userData
            };
            AssetLoader.Get().LoadSound(clip.name, new AssetLoader.GameObjectCallback(this.OnLoadAndPlaySoundLoaded), null, true, callbackData);
        }
    }

    public void NukeAmbienceAndStopPlayingCurrentTrack()
    {
        this.m_ambiencePlaylist.Clear();
        this.StopCurrentAmbienceTrack();
    }

    public void NukeMusicAndAmbiencePlaylists()
    {
        this.m_musicPlaylist.Clear();
        this.m_ambiencePlaylist.Clear();
    }

    public void NukePlaylistsAndStopPlayingCurrentTracks()
    {
        this.NukeMusicAndAmbiencePlaylists();
        this.StopCurrentMusicTrack();
        this.StopCurrentAmbienceTrack();
    }

    private void OnAmbienceLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("SoundManager.OnAmbienceLoaded() - ERROR \"{0}\" failed to load", name));
        }
        else
        {
            AudioSource audio = go.audio;
            if (audio == null)
            {
                UnityEngine.Debug.LogError(string.Format("SoundManager.OnAmbienceLoaded() - ERROR \"{0}\" has no AudioSource", name));
            }
            else
            {
                this.RegisterSourceBundle(audio);
                Track item = (Track) callbackData;
                if (!this.m_ambiencePlaylist.Contains(item))
                {
                    this.UnregisterSourceBundle(audio);
                    UnityEngine.Object.DestroyImmediate(go);
                }
                else
                {
                    this.m_generatedSources.Add(audio);
                    audio.transform.parent = base.transform;
                    audio.volume *= item.m_volume;
                    this.ChangeCurrentAmbienceTrack(audio);
                    this.Play(audio);
                }
                this.m_ambienceIsAboutToPlay = false;
            }
        }
    }

    private void OnAppFocusChanged(bool focus, object userData)
    {
        this.UpdateAppFocus();
    }

    private void OnBeginDuckStateComplete(DuckState state)
    {
        state.m_tweenName = null;
    }

    private void OnEnabledOptionChanged(Option option, object prevValue, bool existed, object userData)
    {
        bool @bool = Options.Get().GetBool(option);
        foreach (KeyValuePair<SoundCategory, Option> pair in SoundDataTables.s_categoryEnabledOptionMap)
        {
            SoundCategory key = pair.Key;
            if (((Option) pair.Value) == option)
            {
                this.UpdateCategoryMute(key, @bool);
            }
        }
    }

    private void OnFinishDuckStateComplete(DuckState state)
    {
        SoundCategory key = state.m_duckedDef.m_Category;
        List<DuckState> list = this.m_duckStates[key];
        for (int i = 0; i < list.Count; i++)
        {
            DuckState state2 = list[i];
            if (state2 == state)
            {
                list.RemoveAt(i);
                if (list.Count == 0)
                {
                    this.m_duckStates.Remove(key);
                }
                break;
            }
        }
    }

    private void OnLoadAndPlaySoundLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("SoundManager.OnLoadAndPlaySoundLoaded() - ERROR \"{0}\" failed to load", name));
        }
        else
        {
            AudioSource audio = go.audio;
            if (audio == null)
            {
                UnityEngine.Object.DestroyImmediate(go);
                UnityEngine.Debug.LogError(string.Format("SoundManager.OnLoadAndPlaySoundLoaded() - ERROR \"{0}\" has no AudioSource", name));
            }
            else
            {
                this.RegisterSourceBundle(audio);
                this.m_generatedSources.Add(audio);
                SoundLoadedCallbackData data = (SoundLoadedCallbackData) callbackData;
                if (data.m_templateSource != null)
                {
                    SoundUtils.CopyAudioSource(data.m_templateSource, audio);
                }
                this.RegisterExtension(audio).m_codeVolume = data.m_volume;
                this.AttachSourceToParent(audio, data.m_parentObject);
                if (data.m_callback != null)
                {
                    data.m_callback(audio, data.m_userData);
                }
                this.Play(audio);
            }
        }
    }

    private void OnMusicLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("SoundManager.OnMusicLoaded() - ERROR \"{0}\" failed to load", name));
        }
        else
        {
            AudioSource audio = go.audio;
            if (audio == null)
            {
                UnityEngine.Debug.LogError(string.Format("SoundManager.OnMusicLoaded() - ERROR \"{0}\" has no AudioSource", name));
            }
            else
            {
                this.RegisterSourceBundle(audio);
                Track item = (Track) callbackData;
                if (!this.m_musicPlaylist.Contains(item))
                {
                    this.UnregisterSourceBundle(audio);
                    UnityEngine.Object.DestroyImmediate(go);
                }
                else
                {
                    this.m_generatedSources.Add(audio);
                    audio.transform.parent = base.transform;
                    audio.volume *= item.m_volume;
                    this.ChangeCurrentMusicTrack(audio);
                    this.Play(audio);
                }
                this.m_musicIsAboutToPlay = false;
            }
        }
    }

    private void OnSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
        this.GarbageCollectBundles();
    }

    private void OnVolumeOptionChanged(Option option, object prevValue, bool existed, object userData)
    {
        float @float = Options.Get().GetFloat(option);
        foreach (KeyValuePair<SoundCategory, Option> pair in SoundDataTables.s_categoryVolumeOptionMap)
        {
            SoundCategory key = pair.Key;
            if (((Option) pair.Value) == option)
            {
                this.UpdateCategoryVolume(key, @float);
            }
        }
    }

    public bool Pause(AudioSource source)
    {
        if (this.IsPaused(source))
        {
            return false;
        }
        SourceExtension ext = this.RegisterExtension(source);
        if (ext == null)
        {
            return false;
        }
        ext.m_paused = true;
        this.UpdateSource(source, ext);
        source.Pause();
        return true;
    }

    public bool Play(AudioSource source)
    {
        if (this.IsPlaying(source))
        {
            source.Play();
            return true;
        }
        bool flag = this.IsActive(source);
        SourceExtension ext = this.RegisterExtension(source, true);
        if (ext == null)
        {
            return false;
        }
        if (!flag)
        {
            this.RegisterSourceForDucking(source);
        }
        this.UpdateSource(source, ext);
        source.Play();
        return true;
    }

    [DebuggerHidden]
    private IEnumerator PlayAmbienceInSeconds(float seconds)
    {
        return new <PlayAmbienceInSeconds>c__IteratorE3 { seconds = seconds, <$>seconds = seconds, <>f__this = this };
    }

    public AudioSource PlayClip(AudioClip clip, float volume, float pitch, SoundCategory cat, GameObject parentObject)
    {
        AudioSource source = this.GenerateAudioSource(clip, volume, pitch, cat, parentObject);
        if (this.Play(source))
        {
            return source;
        }
        this.FinishGeneratedSource(source);
        return null;
    }

    [DebuggerHidden]
    private IEnumerator PlayMusicInSeconds(float seconds)
    {
        return new <PlayMusicInSeconds>c__IteratorE2 { seconds = seconds, <$>seconds = seconds, <>f__this = this };
    }

    public AudioSource PlayOneShot(AudioSource templateSource, AudioClip clip)
    {
        return this.PlayOneShot(templateSource, clip, 1f);
    }

    public AudioSource PlayOneShot(AudioSource templateSource, AudioClip clip, float volume)
    {
        AudioSource source = this.GenerateAudioSource(templateSource, clip, volume);
        if (this.Play(source))
        {
            return source;
        }
        this.FinishGeneratedSource(source);
        return null;
    }

    public void PlayPreloaded(AudioSource source)
    {
        this.PlayPreloaded(source, (GameObject) null);
    }

    public void PlayPreloaded(AudioSource source, float volume)
    {
        this.PlayPreloaded(source, null, volume);
    }

    public void PlayPreloaded(AudioSource source, GameObject parentObject)
    {
        this.PlayPreloaded(source, parentObject, 1f);
    }

    public void PlayPreloaded(AudioSource source, GameObject parentObject, float volume)
    {
        this.RegisterExtension(source).m_codeVolume = volume;
        this.AttachSourceToParent(source, parentObject);
        this.m_generatedSources.Add(source);
        this.Play(source);
    }

    private bool PlayRandomAmbience()
    {
        if (!SoundUtils.IsCategoryEnabled(SoundCategory.MUSIC))
        {
            return false;
        }
        if (this.m_ambiencePlaylist.Count <= 0)
        {
            return false;
        }
        Track callbackData = this.m_ambiencePlaylist[UnityEngine.Random.Range(0, this.m_ambiencePlaylist.Count)];
        if (callbackData == null)
        {
            return false;
        }
        return AssetLoader.Get().LoadSound(callbackData.m_name, new AssetLoader.GameObjectCallback(this.OnAmbienceLoaded), null, true, callbackData);
    }

    private bool PlayRandomMusic()
    {
        if (!SoundUtils.IsCategoryEnabled(SoundCategory.MUSIC))
        {
            return false;
        }
        if (this.m_musicPlaylist.Count <= 0)
        {
            return false;
        }
        Track callbackData = this.m_musicPlaylist[UnityEngine.Random.Range(0, this.m_musicPlaylist.Count)];
        if (callbackData == null)
        {
            return false;
        }
        if (this.m_currentMusicTrack != null)
        {
            this.FadeTrackOut(this.m_currentMusicTrack);
            this.ChangeCurrentMusicTrack(null);
        }
        return AssetLoader.Get().LoadSound(callbackData.m_name, new AssetLoader.GameObjectCallback(this.OnMusicLoaded), null, true, callbackData);
    }

    [Conditional("SOUND_CATEGORY_DEBUG")]
    private void PrintAllCategorySources()
    {
        Log.Sound.Print("SoundManager.PrintAllCategorySources()");
        foreach (KeyValuePair<SoundCategory, List<AudioSource>> pair in this.m_sourcesByCategory)
        {
            SoundCategory key = pair.Key;
            List<AudioSource> list = pair.Value;
            object[] args = new object[] { key };
            Log.Sound.Print("Category {0}:", args);
            for (int i = 0; i < list.Count; i++)
            {
                object[] objArray2 = new object[] { i, list[i] };
                Log.Sound.Print("    {0} = {1}", objArray2);
            }
        }
    }

    private bool ProcessClipLimits(AudioClip clip)
    {
        if (this.m_config.m_PlaybackLimitDefs != null)
        {
            string name = clip.name;
            bool flag = false;
            AudioSource source = null;
            foreach (SoundPlaybackLimitDef def in this.m_config.m_PlaybackLimitDefs)
            {
                SoundPlaybackLimitClipDef def2 = this.FindClipDefInPlaybackDef(name, def);
                if (def2 != null)
                {
                    int priority = def2.m_Priority;
                    float num2 = 2f;
                    int num3 = 0;
                    foreach (SoundPlaybackLimitClipDef def3 in def.m_ClipDefs)
                    {
                        List<AudioSource> list;
                        string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(def3.m_Path);
                        if (this.m_sourcesByClipName.TryGetValue(fileNameWithoutExtension, out list))
                        {
                            int num4 = def3.m_Priority;
                            foreach (AudioSource source2 in list)
                            {
                                if (this.IsPlaying(source2))
                                {
                                    float num5 = source2.time / source2.clip.length;
                                    if (num5 <= def3.m_ExclusivePlaybackThreshold)
                                    {
                                        num3++;
                                        if ((num4 < priority) && (num5 < num2))
                                        {
                                            source = source2;
                                            priority = num4;
                                            num2 = num5;
                                        }
                                    }
                                }
                            }
                            continue;
                        }
                    }
                    if (num3 >= def.m_Limit)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
            {
                if (source == null)
                {
                    return true;
                }
                this.Stop(source);
            }
        }
        return false;
    }

    private SourceExtension RegisterExtension(AudioSource source)
    {
        return this.RegisterExtension(source, false, null);
    }

    private SourceExtension RegisterExtension(AudioSource source, bool aboutToPlay)
    {
        return this.RegisterExtension(source, aboutToPlay, null);
    }

    private SourceExtension RegisterExtension(AudioSource source, AudioClip oneShotClip)
    {
        return this.RegisterExtension(source, false, oneShotClip);
    }

    private SourceExtension RegisterExtension(AudioSource source, bool aboutToPlay, AudioClip oneShotClip)
    {
        SourceExtension extension;
        if (!this.m_extensions.TryGetValue(source, out extension))
        {
            SoundDef defFromSource = SoundUtils.GetDefFromSource(source);
            AudioClip randomClipFromDef = oneShotClip;
            if (randomClipFromDef == null)
            {
                randomClipFromDef = SoundUtils.GetRandomClipFromDef(defFromSource);
                if (randomClipFromDef == null)
                {
                    randomClipFromDef = source.clip;
                    if (randomClipFromDef == null)
                    {
                        object[] messageArgs = new object[] { source, SceneUtils.FindTopParent(source) };
                        Error.AddDevFatal("Sound Asset Error", "{0} has no AudioClip. Top-level parent is {1}.", messageArgs);
                        return null;
                    }
                }
            }
            if (aboutToPlay && this.ProcessClipLimits(randomClipFromDef))
            {
                return null;
            }
            extension = new SourceExtension {
                m_sourceVolume = source.volume,
                m_defVolume = SoundUtils.GetRandomVolumeFromDef(defFromSource),
                m_sourcePitch = source.pitch,
                m_defPitch = SoundUtils.GetRandomPitchFromDef(defFromSource),
                m_sourceClip = source.clip,
                m_id = this.GetNextSourceId()
            };
            source.clip = randomClipFromDef;
            this.m_extensions.Add(source, extension);
            object[] args = new object[] { this.GetSourceId(source), source };
            Log.Sound.ScreenPrint("SoundManager.RegisterExtension() - id={0} source={1}", args);
            this.RegisterSourceByCategory(source, defFromSource.m_Category);
            this.RegisterSourceByClip(source, randomClipFromDef);
            return extension;
        }
        if (aboutToPlay && this.ProcessClipLimits(source.clip))
        {
            this.FinishSource(source);
            return null;
        }
        return extension;
    }

    private bool RegisterForDucking(object trigger, List<SoundDuckedCategoryDef> defs)
    {
        foreach (SoundDuckedCategoryDef def in defs)
        {
            List<DuckState> list;
            SoundCategory key = def.m_Category;
            if (this.m_duckStates.TryGetValue(key, out list))
            {
                foreach (DuckState state in list)
                {
                    if (state.IsTrigger(trigger))
                    {
                        return false;
                    }
                }
            }
            else
            {
                list = new List<DuckState>();
                this.m_duckStates.Add(key, list);
            }
            DuckState item = new DuckState();
            list.Add(item);
            item.SetTrigger(trigger);
            item.m_duckedDef = def;
            this.BeginDuckState(item);
        }
        return true;
    }

    private void RegisterSourceBundle(AudioSource source)
    {
        BundleInfo info;
        string name = source.clip.name;
        if (!this.m_bundleInfos.TryGetValue(name, out info))
        {
            info = new BundleInfo();
            this.m_bundleInfos.Add(name, info);
            object[] args = new object[] { name };
            Log.Sound.ScreenPrint("SoundManager.RegisterSourceBundle() - CREATING {0}", args);
        }
        else
        {
            object[] objArray2 = new object[] { name, info.GetRefCount() };
            Log.Sound.ScreenPrint("SoundManager.RegisterSourceBundle() - name={0} refCount={1}", objArray2);
        }
        info.AddRef(source);
    }

    private void RegisterSourceByCategory(AudioSource source, SoundCategory cat)
    {
        List<AudioSource> list;
        if (!this.m_sourcesByCategory.TryGetValue(cat, out list))
        {
            list = new List<AudioSource>();
            this.m_sourcesByCategory.Add(cat, list);
            object[] args = new object[] { this.GetSourceId(source), source, list.Count, cat, this.m_frame };
            Log.Sound.Print("SoundManager.RegisterSourceByCategory() - id={0} source={1} index={2} cat={3} frame={4}", args);
            list.Add(source);
        }
        else if (!list.Contains(source))
        {
            object[] objArray2 = new object[] { this.GetSourceId(source), source, list.Count, cat, this.m_frame };
            Log.Sound.Print("SoundManager.RegisterSourceByCategory() - id={0} source={1} index={2} cat={3} frame={4}", objArray2);
            list.Add(source);
        }
    }

    private void RegisterSourceByClip(AudioSource source, AudioClip clip)
    {
        List<AudioSource> list;
        object[] args = new object[] { this.GetSourceId(source), source, clip };
        Log.Sound.ScreenPrint("SoundManager.RegisterSourceByClip() - id={0} source={1} clip={2}", args);
        if (!this.m_sourcesByClipName.TryGetValue(clip.name, out list))
        {
            list = new List<AudioSource>();
            this.m_sourcesByClipName.Add(clip.name, list);
            list.Add(source);
        }
        else if (!list.Contains(source))
        {
            list.Add(source);
        }
    }

    private void RegisterSourceForDucking(AudioSource source)
    {
        SoundDuckingDef def = this.FindDuckingDefForSource(source);
        if (def != null)
        {
            this.RegisterForDucking(source, def.m_DuckedCategoryDefs);
        }
    }

    public bool RemoveAmbienceTrackChangedListener(AmbienceTrackChangedCallback callback)
    {
        return this.RemoveAmbienceTrackChangedListener(callback, null);
    }

    public bool RemoveAmbienceTrackChangedListener(AmbienceTrackChangedCallback callback, object userData)
    {
        AmbienceTrackChangedListener item = new AmbienceTrackChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_ambienceTrackChangedListeners.Remove(item);
    }

    private BundleInfo RemoveDeadSourceFromBundleInfo(AudioSource source)
    {
        foreach (BundleInfo info in this.m_bundleInfos.Values)
        {
            List<AudioSource> refs = info.GetRefs();
            for (int i = 0; i < refs.Count; i++)
            {
                if (refs[i] == source)
                {
                    refs.RemoveAt(i);
                    return info;
                }
            }
        }
        return null;
    }

    public bool RemoveMusicTrackChangedListener(MusicTrackChangedCallback callback)
    {
        return this.RemoveMusicTrackChangedListener(callback, null);
    }

    public bool RemoveMusicTrackChangedListener(MusicTrackChangedCallback callback, object userData)
    {
        MusicTrackChangedListener item = new MusicTrackChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_musicTrackChangedListeners.Remove(item);
    }

    public void Set3d(AudioSource source, bool enable)
    {
        if (source != null)
        {
            source.panLevel = !enable ? 0f : 1f;
        }
    }

    public void SetCategory(AudioSource source, SoundCategory cat)
    {
        if (source != null)
        {
            SoundDef component = source.GetComponent<SoundDef>();
            if (component != null)
            {
                if (component.m_Category == cat)
                {
                    return;
                }
            }
            else
            {
                component = source.gameObject.AddComponent<SoundDef>();
            }
            component.m_Category = cat;
            this.UpdateSource(source);
        }
    }

    public void SetConfig(SoundConfig config)
    {
        this.m_config = config;
    }

    public void SetIgnoreDucking(AudioSource source, bool enable)
    {
        if (source != null)
        {
            SoundDef component = source.GetComponent<SoundDef>();
            if (component != null)
            {
                component.m_IgnoreDucking = enable;
            }
        }
    }

    public void SetPitch(AudioSource source, float pitch)
    {
        if (source != null)
        {
            SourceExtension ext = this.RegisterExtension(source);
            if (ext != null)
            {
                ext.m_codePitch = pitch;
                this.UpdatePitch(source, ext);
            }
        }
    }

    public void SetVolume(AudioSource source, float volume)
    {
        if (source != null)
        {
            SourceExtension ext = this.RegisterExtension(source);
            if (ext != null)
            {
                ext.m_codeVolume = volume;
                this.UpdateVolume(source, ext);
            }
        }
    }

    private void Start()
    {
        if (ApplicationMgr.Get() != null)
        {
            this.UpdateAppFocus();
            ApplicationMgr.Get().AddFocusChangedListener(new ApplicationMgr.FocusChangedCallback(this.OnAppFocusChanged));
        }
        if (SceneMgr.Get() == null)
        {
            this.m_config = new GameObject("SoundConfig").AddComponent<SoundConfig>();
        }
        else
        {
            SceneMgr.Get().RegisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
        }
    }

    public bool StartDucking(SoundDucker ducker)
    {
        if (ducker == null)
        {
            return false;
        }
        if (ducker.m_DuckedCategoryDefs == null)
        {
            return false;
        }
        if (ducker.m_DuckedCategoryDefs.Count == 0)
        {
            return false;
        }
        return this.RegisterForDucking(ducker, ducker.GetDuckedCategoryDefs());
    }

    public bool Stop(AudioSource source)
    {
        if (!this.IsActive(source))
        {
            return false;
        }
        source.Stop();
        this.FinishSource(source);
        return true;
    }

    public void StopCurrentAmbienceTrack()
    {
        if (this.m_currentAmbienceTrack != null)
        {
            this.FadeTrackOut(this.m_currentAmbienceTrack);
            this.ChangeCurrentAmbienceTrack(null);
        }
    }

    public void StopCurrentMusicTrack()
    {
        object[] args = new object[] { this.m_currentMusicTrack, this.m_currentMusicTrack == null };
        Log.Sound.ScreenPrint("SoundManager.StopCurrentMusicTrack() - m_currentMusicTrack={0} (null={1})", args);
        object[] objArray2 = new object[] { (this.m_currentMusicTrack != null) ? this.GetSourceId(this.m_currentMusicTrack) : 0 };
        Log.Sound.ScreenPrint("SoundManager.StopCurrentMusicTrack() - m_currentMusicTrack id={0}", objArray2);
        if (this.m_currentMusicTrack != null)
        {
            this.FadeTrackOut(this.m_currentMusicTrack);
            this.ChangeCurrentMusicTrack(null);
        }
    }

    public void StopDucking(SoundDucker ducker)
    {
        if (((ducker != null) && (ducker.m_DuckedCategoryDefs != null)) && (ducker.m_DuckedCategoryDefs.Count != 0))
        {
            this.UnregisterForDucking(ducker, ducker.GetDuckedCategoryDefs());
        }
    }

    private void UnloadSoundBundle(string name)
    {
        object[] args = new object[] { name };
        Log.Sound.Print("SoundManager.UnloadSoundBundle() - CLEARING {0}", args);
        AssetCache.ClearSound(name);
        object[] objArray2 = new object[] { name };
        Log.Sound.ScreenPrint("SoundManager.UnloadSoundBundle() - CLEARED {0}", objArray2);
    }

    private void UnregisterDeadSourceBundle(AudioSource source)
    {
        BundleInfo info = this.RemoveDeadSourceFromBundleInfo(source);
        if (info != null)
        {
            string name = info.GetName();
            if (info.CanGarbageCollect())
            {
                this.m_bundleInfos.Remove(name);
                this.UnloadSoundBundle(name);
                object[] args = new object[] { name };
                Log.Sound.ScreenPrint("SoundManager.UnregisterDeadSourceBundle() - CLEARED {0}", args);
            }
            else
            {
                object[] objArray2 = new object[] { name, info.GetRefCount() };
                Log.Sound.ScreenPrint("SoundManager.UnregisterDeadSourceBundle() - name={0} refCount={1}", objArray2);
            }
        }
    }

    private void UnregisterDeadSourceByCategory(AudioSource source)
    {
        foreach (KeyValuePair<SoundCategory, List<AudioSource>> pair in this.m_sourcesByCategory)
        {
            List<AudioSource> list = pair.Value;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == source)
                {
                    list.RemoveAt(i);
                    return;
                }
            }
        }
    }

    private void UnregisterDeadSourceByClip(AudioSource source)
    {
        foreach (KeyValuePair<string, List<AudioSource>> pair in this.m_sourcesByClipName)
        {
            string key = pair.Key;
            List<AudioSource> list = pair.Value;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == source)
                {
                    list.RemoveAt(i);
                    if (list.Count == 0)
                    {
                        this.m_sourcesByClipName.Remove(key);
                    }
                    return;
                }
            }
        }
    }

    private void UnregisterExtension(AudioSource source)
    {
        SourceExtension extension;
        object[] args = new object[] { this.GetSourceId(source), source, this.m_frame };
        Log.Sound.ScreenPrint("SoundManager.UnregisterExtension() - id={0} source={1} frame={2}", args);
        object[] objArray2 = new object[] { (this.m_currentMusicTrack != null) ? this.GetSourceId(this.m_currentMusicTrack) : 0, this.m_currentMusicTrack };
        Log.Sound.ScreenPrint("SoundManager.UnregisterExtension() - m_currentMusicTrackId={0} m_currentMusicTrack={1}", objArray2);
        this.UnregisterSourceByCategory(source);
        this.UnregisterSourceByClip(source);
        if (this.m_extensions.TryGetValue(source, out extension))
        {
            source.volume = extension.m_sourceVolume;
            source.pitch = extension.m_sourcePitch;
            source.clip = extension.m_sourceClip;
            this.m_extensions.Remove(source);
        }
    }

    private void UnregisterForDucking(object trigger, List<SoundDuckedCategoryDef> defs)
    {
        foreach (SoundDuckedCategoryDef def in defs)
        {
            List<DuckState> list;
            SoundCategory key = def.m_Category;
            if (!this.m_duckStates.TryGetValue(key, out list))
            {
                UnityEngine.Debug.LogError(string.Format("SoundManager.UnregisterForDucking() - {0} ducks {1}, but no DuckStates were found for {1}", trigger, key));
                continue;
            }
            DuckState state = null;
            foreach (DuckState state2 in list)
            {
                if (state2.IsTrigger(trigger))
                {
                    state = state2;
                    break;
                }
            }
            if (state == null)
            {
                UnityEngine.Debug.LogError(string.Format("SoundManager.UnregisterForDucking() - {0} ducks {1}, but there is no {0} DuckState", trigger, key));
            }
            else
            {
                this.FinishDuckState(state);
            }
        }
    }

    private void UnregisterSourceBundle(AudioSource source)
    {
        AudioClip clip = source.clip;
        if (clip != null)
        {
            BundleInfo info;
            string name = clip.name;
            if (this.m_bundleInfos.TryGetValue(name, out info) && info.RemoveRef(source))
            {
                if (info.CanGarbageCollect())
                {
                    this.m_bundleInfos.Remove(name);
                    this.UnloadSoundBundle(name);
                    object[] args = new object[] { name };
                    Log.Sound.ScreenPrint("SoundManager.UnregisterSourceBundle() - CLEARED {0}", args);
                }
                else
                {
                    object[] objArray2 = new object[] { name, info.GetRefCount() };
                    Log.Sound.ScreenPrint("SoundManager.UnregisterSourceBundle() - name={0} refCount={1}", objArray2);
                }
            }
        }
    }

    private void UnregisterSourceByCategory(AudioSource source)
    {
        List<AudioSource> list;
        SoundCategory key = this.GetCategory(source);
        object[] args = new object[] { this.GetSourceId(source), source, key, this.m_frame };
        Log.Sound.Print("SoundManager.UnregisterSourceByCategory() - id={0} source={1} cat={2} frame={3}", args);
        if (!this.m_sourcesByCategory.TryGetValue(key, out list))
        {
            UnityEngine.Debug.LogError(string.Format("SoundManager.UnregisterSourceByCategory() - {0} is untracked. category={1}", this.GetSourceId(source), key));
        }
        else if (list.Remove(source))
        {
            object[] objArray2 = new object[] { this.GetSourceId(source), source, key, list.Count, this.m_frame };
            Log.Sound.Print("SoundManager.UnregisterSourceByCategory() - SUCCESS removed id={0} source={1} cat={2} count={3} frame={4}", objArray2);
        }
        else
        {
            object[] objArray3 = new object[] { this.GetSourceId(source), source, key, list.Count, this.m_frame };
            Log.Sound.Print("SoundManager.UnregisterSourceByCategory() - FAILED to remove id={0} source={1} cat={2} count={3} frame={4}", objArray3);
        }
    }

    private void UnregisterSourceByClip(AudioSource source)
    {
        AudioClip clip = source.clip;
        object[] args = new object[] { this.GetSourceId(source), source, clip, this.m_frame };
        Log.Sound.ScreenPrint("SoundManager.UnregisterSourceByClip() - id={0} source={1} clip={2} frame={3}", args);
        if (clip == null)
        {
            object[] objArray2 = new object[] { this.GetSourceId(source), source };
            Log.Sound.ScreenPrint("SoundManager.UnregisterSourceByClip() - id {0} (source {1}) has no clip. The clip's asset bundle was probably unloaded.", objArray2);
            UnityEngine.Debug.LogError(string.Format("SoundManager.UnregisterSourceByClip() - id {0} (source {1}) is untracked", this.GetSourceId(source), source));
        }
        else
        {
            List<AudioSource> list;
            if (!this.m_sourcesByClipName.TryGetValue(clip.name, out list))
            {
                UnityEngine.Debug.LogError(string.Format("SoundManager.UnregisterSourceByClip() - id {0} (source {1}) is untracked. clip={2}", this.GetSourceId(source), source, clip));
            }
            else
            {
                list.Remove(source);
                if (list.Count == 0)
                {
                    this.m_sourcesByClipName.Remove(clip.name);
                }
            }
        }
    }

    private void UnregisterSourceForDucking(AudioSource source)
    {
        SoundDuckingDef def = this.FindDuckingDefForSource(source);
        if (def != null)
        {
            this.UnregisterForDucking(source, def.m_DuckedCategoryDefs);
        }
    }

    private void Update()
    {
        this.m_frame = (this.m_frame + 1) & uint.MaxValue;
        this.UpdateMusicAndSources();
    }

    private void UpdateAllMute()
    {
        foreach (AudioSource source in this.m_extensions.Keys)
        {
            this.UpdateMute(source);
        }
    }

    private void UpdateAppFocus()
    {
        this.UpdateMusicAndSources();
        this.m_mute = !ApplicationMgr.Get().HasFocus();
        this.UpdateAllMute();
    }

    private void UpdateCategoryMute(SoundCategory cat, bool categoryEnabled)
    {
        List<AudioSource> list;
        if (this.m_sourcesByCategory.TryGetValue(cat, out list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                AudioSource source = list[i];
                this.UpdateMute(source, categoryEnabled);
            }
        }
    }

    private void UpdateCategoryVolume(SoundCategory cat)
    {
        float categoryVolume = SoundUtils.GetCategoryVolume(cat);
        this.UpdateCategoryVolume(cat, categoryVolume);
    }

    private void UpdateCategoryVolume(SoundCategory cat, float categoryVolume)
    {
        List<AudioSource> list;
        if (this.m_sourcesByCategory.TryGetValue(cat, out list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                AudioSource source = list[i];
                this.UpdateCategoryVolume(source, this.GetExtension(source), categoryVolume);
            }
        }
    }

    private void UpdateCategoryVolume(AudioSource source, SourceExtension ext, float categoryVolume)
    {
        float duckingVolume = this.GetDuckingVolume(source);
        this.UpdateVolume(source, ext, categoryVolume, duckingVolume);
    }

    private void UpdateDuckingVolume(SoundCategory cat)
    {
        List<AudioSource> list;
        if (this.m_sourcesByCategory.TryGetValue(cat, out list))
        {
            float categoryVolume = SoundUtils.GetCategoryVolume(cat);
            for (int i = 0; i < list.Count; i++)
            {
                AudioSource source = list[i];
                this.UpdateCategoryVolume(source, this.GetExtension(source), categoryVolume);
            }
        }
    }

    private void UpdateMusicAndAmbience()
    {
        if (SoundUtils.IsCategoryEnabled(SoundCategory.MUSIC))
        {
            if (!this.m_musicIsAboutToPlay)
            {
                if (this.m_currentMusicTrack != null)
                {
                    if (!this.IsPlaying(this.m_currentMusicTrack))
                    {
                        base.StartCoroutine(this.PlayMusicInSeconds(this.m_config.m_SecondsBetweenMusicTracks));
                    }
                }
                else
                {
                    this.m_musicIsAboutToPlay = this.PlayRandomMusic();
                }
            }
            if (!this.m_ambienceIsAboutToPlay)
            {
                if (this.m_currentAmbienceTrack != null)
                {
                    if (!this.IsPlaying(this.m_currentAmbienceTrack))
                    {
                        base.StartCoroutine(this.PlayAmbienceInSeconds(0f));
                    }
                }
                else
                {
                    this.m_ambienceIsAboutToPlay = this.PlayRandomAmbience();
                }
            }
        }
    }

    private void UpdateMusicAndSources()
    {
        this.UpdateMusicAndAmbience();
        this.UpdateSources();
    }

    private void UpdateMute(AudioSource source)
    {
        bool categoryEnabled = this.IsCategoryEnabled(source);
        this.UpdateMute(source, categoryEnabled);
    }

    private void UpdateMute(AudioSource source, bool categoryEnabled)
    {
        source.mute = this.m_mute || !categoryEnabled;
    }

    private void UpdatePitch(AudioSource source, SourceExtension ext)
    {
        source.pitch = (ext.m_codePitch * ext.m_sourcePitch) * ext.m_defPitch;
    }

    private void UpdateSource(AudioSource source)
    {
        SourceExtension ext = this.GetExtension(source);
        this.UpdateSource(source, ext);
    }

    private void UpdateSource(AudioSource source, SourceExtension ext)
    {
        this.UpdateMute(source);
        this.UpdateVolume(source, ext);
        this.UpdatePitch(source, ext);
    }

    private void UpdateSources()
    {
        foreach (AudioSource source in this.m_extensions.Keys)
        {
            if (source == null)
            {
                this.m_deadSources.Add(source);
            }
            else if (!this.IsActive(source))
            {
                this.m_inactiveSources.Add(source);
            }
        }
        this.CleanDeadSources();
        this.CleanInactiveSources();
        this.CleanDeadDuckStates();
    }

    private void UpdateVolume(AudioSource source, SourceExtension ext)
    {
        float categoryVolume = this.GetCategoryVolume(source);
        float duckingVolume = this.GetDuckingVolume(source);
        this.UpdateVolume(source, ext, categoryVolume, duckingVolume);
    }

    private void UpdateVolume(AudioSource source, SourceExtension ext, float categoryVolume, float duckingVolume)
    {
        source.volume = (((ext.m_codeVolume * ext.m_sourceVolume) * ext.m_defVolume) * categoryVolume) * duckingVolume;
    }

    [CompilerGenerated]
    private sealed class <BeginDuckState>c__AnonStorey144
    {
        internal SoundManager <>f__this;
        internal SoundDuckedCategoryDef duckedDef;
        internal SoundManager.DuckState state;

        internal void <>m__57(object amount)
        {
            float num = (float) amount;
            this.state.m_volume = num;
            this.<>f__this.UpdateDuckingVolume(this.duckedDef.m_Category);
        }
    }

    [CompilerGenerated]
    private sealed class <FadeTrack>c__IteratorE4 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal AudioSource <$>source;
        internal float <$>targetVolume;
        internal SoundManager <>f__this;
        internal SoundManager.SourceExtension <ext>__0;
        internal AudioSource source;
        internal float targetVolume;

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
                    this.<>f__this.m_fadingTracks.Add(this.source);
                    this.<ext>__0 = this.<>f__this.GetExtension(this.source);
                    break;

                case 1:
                {
                    if (this.source != null)
                    {
                        if (!this.<>f__this.IsActive(this.source))
                        {
                            object[] objArray2 = new object[] { this.<>f__this.GetSourceId(this.source), this.source, this.<>f__this.GetCategory(this.source) };
                            Log.Sound.ScreenPrint("SoundManager.FadeTrack() - id={0} source={1} cat={2} stopped fading due to inactive source", objArray2);
                            goto Label_01D8;
                        }
                        break;
                    }
                    object[] objArray1 = new object[] { this.<>f__this.GetSourceId(this.source), this.source, this.<>f__this.GetCategory(this.source) };
                    Log.Sound.ScreenPrint("SoundManager.FadeTrack() - id={0} source={1} cat={2} stopped fading due to dead source", objArray1);
                    goto Label_01D8;
                }
                default:
                    goto Label_01D8;
            }
            if (this.<ext>__0.m_codeVolume > 0.0001f)
            {
                this.<ext>__0.m_codeVolume = Mathf.Lerp(this.<ext>__0.m_codeVolume, this.targetVolume, UnityEngine.Time.deltaTime);
                this.<>f__this.UpdateVolume(this.source, this.<ext>__0);
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            object[] args = new object[] { this.<>f__this.GetSourceId(this.source), this.source };
            Log.Sound.ScreenPrint("SoundManager.FadeTrack() - id={0} source={1} is done fading", args);
            this.<>f__this.FinishSource(this.source);
            this.$PC = -1;
        Label_01D8:
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
    private sealed class <FinishDuckState>c__AnonStorey145
    {
        internal SoundManager <>f__this;
        internal SoundDuckedCategoryDef duckedDef;
        internal SoundManager.DuckState state;

        internal void <>m__58(object amount)
        {
            float num = (float) amount;
            this.state.m_volume = num;
            this.<>f__this.UpdateDuckingVolume(this.duckedDef.m_Category);
        }
    }

    [CompilerGenerated]
    private sealed class <PlayAmbienceInSeconds>c__IteratorE3 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal float <$>seconds;
        internal SoundManager <>f__this;
        internal float seconds;

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
                    this.<>f__this.m_ambienceIsAboutToPlay = true;
                    this.$current = new WaitForSeconds(this.seconds);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_ambienceIsAboutToPlay = this.<>f__this.PlayRandomAmbience();
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
    private sealed class <PlayMusicInSeconds>c__IteratorE2 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal float <$>seconds;
        internal SoundManager <>f__this;
        internal float seconds;

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
                    this.<>f__this.m_musicIsAboutToPlay = true;
                    this.$current = new WaitForSeconds(this.seconds);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_musicIsAboutToPlay = this.<>f__this.PlayRandomMusic();
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

    public delegate void AmbienceTrackChangedCallback(AudioSource track, object userData);

    private class AmbienceTrackChangedListener : EventListener<SoundManager.AmbienceTrackChangedCallback>
    {
        public void Fire(AudioSource source)
        {
            base.m_callback(source, base.m_userData);
        }
    }

    private class BundleInfo
    {
        private bool m_garbageCollect;
        private string m_name;
        private List<AudioSource> m_refs = new List<AudioSource>();

        public void AddRef(AudioSource source)
        {
            this.m_garbageCollect = false;
            this.m_refs.Add(source);
        }

        public bool CanGarbageCollect()
        {
            return (this.m_garbageCollect && (this.m_refs.Count == 0));
        }

        public void EnableGarbageCollect(bool enable)
        {
            this.m_garbageCollect = enable;
        }

        public string GetName()
        {
            return this.m_name;
        }

        public int GetRefCount()
        {
            return this.m_refs.Count;
        }

        public List<AudioSource> GetRefs()
        {
            return this.m_refs;
        }

        public bool IsGarbageCollectEnabled()
        {
            return this.m_garbageCollect;
        }

        public bool RemoveRef(AudioSource source)
        {
            return this.m_refs.Remove(source);
        }

        public void SetName(string name)
        {
            this.m_name = name;
        }
    }

    private class DuckState
    {
        public SoundDuckedCategoryDef m_duckedDef;
        public object m_trigger;
        public SoundCategory m_triggerCategory;
        public string m_tweenName;
        public float m_volume = 1f;

        public object GetTrigger()
        {
            return this.m_trigger;
        }

        public SoundCategory GetTriggerCategory()
        {
            return this.m_triggerCategory;
        }

        public bool IsTrigger(object trigger)
        {
            return (this.m_trigger == trigger);
        }

        public void SetTrigger(object trigger)
        {
            this.m_trigger = trigger;
            AudioSource source = trigger as AudioSource;
            if (source != null)
            {
                this.m_triggerCategory = SoundManager.Get().GetCategory(source);
            }
        }
    }

    public delegate void LoadedCallback(AudioSource source, object userData);

    public delegate void MusicTrackChangedCallback(AudioSource track, object userData);

    private class MusicTrackChangedListener : EventListener<SoundManager.MusicTrackChangedCallback>
    {
        public void Fire(AudioSource source)
        {
            base.m_callback(source, base.m_userData);
        }
    }

    private class SoundLoadedCallbackData
    {
        public SoundManager.LoadedCallback m_callback;
        public GameObject m_parentObject;
        public AudioSource m_templateSource;
        public long m_timestamp;
        public object m_userData;
        public float m_volume = 1f;
    }

    private class SourceExtension
    {
        public float m_codePitch = 1f;
        public float m_codeVolume = 1f;
        public float m_defPitch = 1f;
        public float m_defVolume = 1f;
        public int m_id;
        public bool m_paused;
        public AudioClip m_sourceClip;
        public float m_sourcePitch = 1f;
        public float m_sourceVolume = 1f;
    }

    private class Track
    {
        public string m_name;
        public float m_volume;
    }
}


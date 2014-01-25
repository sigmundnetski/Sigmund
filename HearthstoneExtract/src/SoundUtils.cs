using System;
using UnityEngine;

public class SoundUtils
{
    public static bool AddAudioSourceComponents(GameObject go)
    {
        bool flag = false;
        AudioSource component = go.GetComponent<AudioSource>();
        if (component == null)
        {
            component = go.AddComponent<AudioSource>();
            ChangeAudioSourceSettings(component, new AudioSourceSettings());
            flag = true;
        }
        if (component.playOnAwake)
        {
            component.playOnAwake = false;
            flag = true;
        }
        if (go.GetComponent<SoundDef>() == null)
        {
            go.AddComponent<SoundDef>();
            flag = true;
        }
        return flag;
    }

    public static bool AddAudioSourceComponents(GameObject go, AudioClip clip)
    {
        bool flag = false;
        AudioSource component = go.GetComponent<AudioSource>();
        if (component == null)
        {
            component = go.AddComponent<AudioSource>();
            ChangeAudioSourceSettings(component, new AudioSourceSettings());
            flag = true;
        }
        if ((clip != null) && (clip != component.clip))
        {
            component.clip = clip;
            flag = true;
        }
        if (component.playOnAwake)
        {
            component.playOnAwake = false;
            flag = true;
        }
        if (go.GetComponent<SoundDef>() == null)
        {
            go.AddComponent<SoundDef>();
            flag = true;
        }
        return flag;
    }

    public static bool ChangeAudioSourceSettings(AudioSource source, AudioSourceSettings settings)
    {
        bool flag = false;
        if (source.bypassEffects != settings.m_bypassEffects)
        {
            source.bypassEffects = settings.m_bypassEffects;
            flag = true;
        }
        if (source.loop != settings.m_loop)
        {
            source.loop = settings.m_loop;
            flag = true;
        }
        if (source.priority != settings.m_priority)
        {
            source.priority = settings.m_priority;
            flag = true;
        }
        if (!object.Equals(source.volume, settings.m_volume))
        {
            source.volume = settings.m_volume;
            flag = true;
        }
        if (!object.Equals(source.pitch, settings.m_pitch))
        {
            source.pitch = settings.m_pitch;
            flag = true;
        }
        if (source.rolloffMode != settings.m_rolloffMode)
        {
            source.rolloffMode = settings.m_rolloffMode;
            flag = true;
        }
        if (!object.Equals(source.minDistance, settings.m_minDistance))
        {
            source.minDistance = settings.m_minDistance;
            flag = true;
        }
        if (!object.Equals(source.maxDistance, settings.m_maxDistance))
        {
            source.maxDistance = settings.m_maxDistance;
            flag = true;
        }
        if (!object.Equals(source.panLevel, settings.m_panLevel))
        {
            source.panLevel = settings.m_panLevel;
            flag = true;
        }
        if (!object.Equals(source.spread, settings.m_spread))
        {
            source.spread = settings.m_spread;
            flag = true;
        }
        return flag;
    }

    public static void CopyAudioSource(AudioSource src, AudioSource dst)
    {
        dst.clip = src.clip;
        dst.bypassEffects = src.bypassEffects;
        dst.loop = src.loop;
        dst.priority = src.priority;
        dst.volume = src.volume;
        dst.pitch = src.pitch;
        dst.rolloffMode = src.rolloffMode;
        dst.minDistance = src.minDistance;
        dst.maxDistance = src.maxDistance;
        dst.panLevel = src.panLevel;
        SoundDef component = src.GetComponent<SoundDef>();
        if (component == null)
        {
            SoundDef def2 = dst.GetComponent<SoundDef>();
            if (def2 != null)
            {
                UnityEngine.Object.Destroy(def2);
            }
        }
        else
        {
            SoundDef def3 = dst.GetComponent<SoundDef>();
            if (def3 == null)
            {
                def3 = dst.gameObject.AddComponent<SoundDef>();
            }
            CopySoundDef(component, def3);
        }
    }

    public static void CopyDuckedCategoryDef(SoundDuckedCategoryDef src, SoundDuckedCategoryDef dst)
    {
        dst.m_Category = src.m_Category;
        dst.m_Volume = src.m_Volume;
        dst.m_BeginSec = src.m_BeginSec;
        dst.m_BeginEaseType = src.m_BeginEaseType;
        dst.m_RestoreSec = src.m_RestoreSec;
        dst.m_RestoreEaseType = src.m_RestoreEaseType;
    }

    public static void CopySoundDef(SoundDef src, SoundDef dst)
    {
        dst.m_Category = src.m_Category;
        dst.m_RandomClips = null;
        if (src.m_RandomClips != null)
        {
            for (int i = 0; i < src.m_RandomClips.Count; i++)
            {
                dst.m_RandomClips.Add(src.m_RandomClips[i]);
            }
        }
        dst.m_RandomPitchMin = src.m_RandomPitchMin;
        dst.m_RandomPitchMax = src.m_RandomPitchMax;
        dst.m_RandomVolumeMin = src.m_RandomVolumeMin;
        dst.m_RandomVolumeMax = src.m_RandomVolumeMax;
        dst.m_IgnoreDucking = src.m_IgnoreDucking;
    }

    public static Option GetCategoryEnabledOption(SoundCategory cat)
    {
        Option option;
        SoundDataTables.s_categoryEnabledOptionMap.TryGetValue(cat, out option);
        return option;
    }

    public static float GetCategoryVolume(SoundCategory cat)
    {
        Option categoryVolumeOption = GetCategoryVolumeOption(cat);
        return Options.Get().GetFloat(categoryVolumeOption);
    }

    public static Option GetCategoryVolumeOption(SoundCategory cat)
    {
        Option option;
        SoundDataTables.s_categoryVolumeOptionMap.TryGetValue(cat, out option);
        return option;
    }

    public static SoundDef GetDefFromSource(AudioSource source)
    {
        SoundDef component = source.GetComponent<SoundDef>();
        if (component == null)
        {
            object[] args = new object[] { source };
            Log.Sound.ScreenPrint("SoundUtils.GetDefFromSource() - source={0} has no def. adding new def.", args);
            component = source.gameObject.AddComponent<SoundDef>();
        }
        return component;
    }

    public static AudioClip GetRandomClipFromDef(SoundDef def)
    {
        if (def == null)
        {
            return null;
        }
        if (def.m_RandomClips == null)
        {
            return null;
        }
        if (def.m_RandomClips.Count == 0)
        {
            return null;
        }
        float max = 0f;
        foreach (RandomAudioClip clip in def.m_RandomClips)
        {
            max += clip.m_Weight;
        }
        float num2 = UnityEngine.Random.Range(0f, max);
        float num3 = 0f;
        int num4 = def.m_RandomClips.Count - 1;
        for (int i = 0; i < num4; i++)
        {
            RandomAudioClip clip2 = def.m_RandomClips[i];
            num3 += clip2.m_Weight;
            if (num2 <= num3)
            {
                return clip2.m_Clip;
            }
        }
        return def.m_RandomClips[num4].m_Clip;
    }

    public static float GetRandomPitchFromDef(SoundDef def)
    {
        if (def == null)
        {
            return 1f;
        }
        return UnityEngine.Random.Range(def.m_RandomPitchMin, def.m_RandomPitchMax);
    }

    public static float GetRandomVolumeFromDef(SoundDef def)
    {
        if (def == null)
        {
            return 1f;
        }
        return UnityEngine.Random.Range(def.m_RandomVolumeMin, def.m_RandomVolumeMax);
    }

    public static bool IsCategoryAudible(SoundCategory cat)
    {
        if (GetCategoryVolume(cat) <= float.Epsilon)
        {
            return false;
        }
        return IsCategoryEnabled(cat);
    }

    public static bool IsCategoryEnabled(SoundCategory cat)
    {
        Option categoryEnabledOption = GetCategoryEnabledOption(cat);
        return Options.Get().GetBool(categoryEnabledOption);
    }

    public static bool IsFxAudible()
    {
        return IsCategoryAudible(SoundCategory.FX);
    }

    public static bool IsFxEnabled()
    {
        return IsCategoryEnabled(SoundCategory.FX);
    }

    public static bool IsMusicAudible()
    {
        return IsCategoryAudible(SoundCategory.MUSIC);
    }

    public static bool IsMusicEnabled()
    {
        return IsCategoryEnabled(SoundCategory.MUSIC);
    }

    public static bool IsVoiceAudible()
    {
        return IsCategoryAudible(SoundCategory.VO);
    }

    public static bool IsVoiceEnabled()
    {
        return IsCategoryEnabled(SoundCategory.VO);
    }
}


using System;
using UnityEngine;

public class AudioSourceSettings
{
    public const bool DEFAULT_BYPASS_EFFECTS = false;
    public const bool DEFAULT_LOOP = false;
    public const float DEFAULT_MAX_DISTANCE = 500f;
    public const float DEFAULT_MIN_DISTANCE = 100f;
    public const float DEFAULT_PAN_LEVEL = 1f;
    public const float DEFAULT_PITCH = 1f;
    public const int DEFAULT_PRIORITY = 0x80;
    public const AudioRolloffMode DEFAULT_ROLLOFF_MODE = AudioRolloffMode.Linear;
    public const float DEFAULT_SPREAD = 0f;
    public const float DEFAULT_VOLUME = 1f;
    public bool m_bypassEffects;
    public bool m_loop;
    public float m_maxDistance;
    public float m_minDistance;
    public float m_panLevel;
    public float m_pitch;
    public int m_priority;
    public AudioRolloffMode m_rolloffMode;
    public float m_spread;
    public float m_volume;
    public const float MAX_PITCH = 3f;
    public const int MAX_PRIORITY = 0x100;
    public const float MAX_SPREAD = 360f;
    public const float MIN_PITCH = -3f;
    public const int MIN_PRIORITY = 0;
    public const float MIN_SPREAD = 0f;

    public AudioSourceSettings()
    {
        this.LoadDefaults();
    }

    public void LoadDefaults()
    {
        this.m_bypassEffects = false;
        this.m_loop = false;
        this.m_priority = 0x80;
        this.m_volume = 1f;
        this.m_pitch = 1f;
        this.m_rolloffMode = AudioRolloffMode.Linear;
        this.m_minDistance = 100f;
        this.m_maxDistance = 500f;
        this.m_panLevel = 1f;
        this.m_spread = 0f;
    }
}


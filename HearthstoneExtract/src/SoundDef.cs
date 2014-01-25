using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundDef : MonoBehaviour
{
    public SoundCategory m_Category = SoundCategory.FX;
    public bool m_IgnoreDucking;
    public List<RandomAudioClip> m_RandomClips;
    public float m_RandomPitchMax = 1f;
    public float m_RandomPitchMin = 1f;
    public float m_RandomVolumeMax = 1f;
    public float m_RandomVolumeMin = 1f;
}


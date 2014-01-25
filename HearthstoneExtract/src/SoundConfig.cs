using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundConfig : MonoBehaviour
{
    public List<SoundDuckingDef> m_DuckingDefs;
    public List<SoundPlaybackLimitDef> m_PlaybackLimitDefs;
    public AudioSource m_PlayClipTemplate;
    public float m_SecondsBetweenMusicTracks = 10f;
}


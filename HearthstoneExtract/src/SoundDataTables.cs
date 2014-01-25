using System;
using System.Collections.Generic;

public class SoundDataTables
{
    public static readonly Dictionary<SoundCategory, Option> s_categoryEnabledOptionMap;
    public static readonly Dictionary<SoundCategory, Option> s_categoryVolumeOptionMap;

    static SoundDataTables()
    {
        Dictionary<SoundCategory, Option> dictionary = new Dictionary<SoundCategory, Option>();
        dictionary.Add(SoundCategory.FX, Option.SOUND);
        dictionary.Add(SoundCategory.MUSIC, Option.MUSIC);
        dictionary.Add(SoundCategory.VO, Option.SOUND);
        dictionary.Add(SoundCategory.SPECIAL_VO, Option.SOUND);
        dictionary.Add(SoundCategory.SPECIAL_CARD, Option.SOUND);
        dictionary.Add(SoundCategory.AMBIENCE, Option.SOUND);
        s_categoryEnabledOptionMap = dictionary;
        dictionary = new Dictionary<SoundCategory, Option>();
        dictionary.Add(SoundCategory.FX, Option.SOUND_VOLUME);
        dictionary.Add(SoundCategory.MUSIC, Option.MUSIC_VOLUME);
        dictionary.Add(SoundCategory.VO, Option.SOUND_VOLUME);
        dictionary.Add(SoundCategory.SPECIAL_VO, Option.SOUND_VOLUME);
        dictionary.Add(SoundCategory.SPECIAL_CARD, Option.SOUND_VOLUME);
        dictionary.Add(SoundCategory.AMBIENCE, Option.SOUND_VOLUME);
        s_categoryVolumeOptionMap = dictionary;
    }
}


using System;
using System.Collections.Generic;

public class OptionDataTables
{
    public static readonly Dictionary<Option, object> s_defaultsMap;
    public static readonly Dictionary<Option, System.Type> s_typeMap;

    static OptionDataTables()
    {
        Dictionary<Option, System.Type> dictionary = new Dictionary<Option, System.Type>();
        dictionary.Add(Option.SOUND, typeof(bool));
        dictionary.Add(Option.MUSIC, typeof(bool));
        dictionary.Add(Option.CURSOR, typeof(bool));
        dictionary.Add(Option.HUD, typeof(bool));
        dictionary.Add(Option.STREAMING, typeof(bool));
        dictionary.Add(Option.SOUND_VOLUME, typeof(float));
        dictionary.Add(Option.MUSIC_VOLUME, typeof(float));
        dictionary.Add(Option.GFX_WIDTH, typeof(int));
        dictionary.Add(Option.GFX_HEIGHT, typeof(int));
        dictionary.Add(Option.GFX_FULLSCREEN, typeof(bool));
        dictionary.Add(Option.HAS_SEEN_CINEMATIC, typeof(bool));
        dictionary.Add(Option.GFX_QUALITY, typeof(int));
        dictionary.Add(Option.FAKE_PACK_OPENING, typeof(bool));
        dictionary.Add(Option.FAKE_PACK_COUNT, typeof(int));
        dictionary.Add(Option.PAGE_MOUSE_OVERS, typeof(int));
        dictionary.Add(Option.COVER_MOUSE_OVERS, typeof(int));
        dictionary.Add(Option.DECK_PICKER_MODE, typeof(int));
        dictionary.Add(Option.AI_MODE, typeof(int));
        dictionary.Add(Option.TIP_PRACTICE_PROGRESS, typeof(int));
        dictionary.Add(Option.TIP_PLAY_PROGRESS, typeof(int));
        dictionary.Add(Option.TIP_FORGE_PROGRESS, typeof(int));
        s_typeMap = dictionary;
        Dictionary<Option, object> dictionary2 = new Dictionary<Option, object>();
        dictionary2.Add(Option.SOUND, true);
        dictionary2.Add(Option.MUSIC, true);
        dictionary2.Add(Option.CURSOR, true);
        dictionary2.Add(Option.HUD, true);
        dictionary2.Add(Option.STREAMING, true);
        dictionary2.Add(Option.SOUND_VOLUME, 1f);
        dictionary2.Add(Option.MUSIC_VOLUME, 0.5f);
        dictionary2.Add(Option.GFX_QUALITY, 1);
        s_defaultsMap = dictionary2;
    }
}


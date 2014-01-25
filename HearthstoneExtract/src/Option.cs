using System;
using System.ComponentModel;

public enum Option
{
    [Description("aimode")]
    AI_MODE = 0x12,
    [Description("covermouseovers")]
    COVER_MOUSE_OVERS = 0x10,
    [Description("cursor")]
    CURSOR = 3,
    [Description("deckpickermode")]
    DECK_PICKER_MODE = 0x11,
    [Description("hasUnlockedCrafting")]
    DEPRECATED_HAS_UNLOCKED_CRAFTING = 0x38,
    [Description("hasUnlockedForge")]
    DEPRECATED_HAS_UNLOCKED_FORGE = 0x37,
    [Description("fakepackcount")]
    FAKE_PACK_COUNT = 14,
    [Description("fakepackopening")]
    FAKE_PACK_OPENING = 13,
    [Description("graphicsfullscreen")]
    GFX_FULLSCREEN = 10,
    [Description("graphicsheight")]
    GFX_HEIGHT = 9,
    [Description("graphicsquality")]
    GFX_QUALITY = 12,
    [Description("graphicswidth")]
    GFX_WIDTH = 8,
    [Description("hasAddedCardsToDeck")]
    HAS_ADDED_CARDS_TO_DECK = 0x36,
    [Description("hasBeenNudgedToCM")]
    HAS_BEEN_NUDGED_TO_CM = 0x35,
    [Description("hasBeenNudgedToPlay")]
    HAS_BEEN_NUDGED_TO_PLAY = 0x34,
    [Description("hasclickedtournament")]
    HAS_CLICKED_TOURNAMENT = 0x16,
    [Description("hasClickedUnrankedPlay")]
    HAS_CLICKED_UNRANKED_PLAY = 0x33,
    [Description("hasCrafted")]
    HAS_CRAFTED = 0x3e,
    [Description("hasDisenchanted")]
    HAS_DISENCHANTED = 0x3b,
    [Description("firstdeckcomplete")]
    HAS_FINISHED_A_DECK = 0x1f,
    [Description("hasopenedbooster")]
    HAS_OPENED_BOOSTER = 0x17,
    [Description("hasPlayedExpertAI")]
    HAS_PLAYED_EXPERT_AI = 0x3a,
    [Description("hasSeenAllBasicClassCardsComplete")]
    HAS_SEEN_ALL_BASIC_CLASS_CARDS_COMPLETE = 50,
    [Description("hasseencinematic")]
    HAS_SEEN_CINEMATIC = 11,
    [Description("hasseencollectionmanager")]
    HAS_SEEN_COLLECTIONMANAGER = 0x19,
    [Description("hasSeenCraftingInstruction")]
    HAS_SEEN_CRAFTING_INSTRUCTION = 0x3d,
    [Description("hasSeenCustomDeckPicker")]
    HAS_SEEN_CUSTOM_DECK_PICKER = 0x31,
    [Description("hasseendeckhelper")]
    HAS_SEEN_DECK_HELPER = 0x2e,
    [Description("hasSeenExpertAI")]
    HAS_SEEN_EXPERT_AI = 0x2b,
    [Description("hasSeenExpertAIUnlock")]
    HAS_SEEN_EXPERT_AI_UNLOCK = 0x2c,
    [Description("hasseenforge")]
    HAS_SEEN_FORGE = 0x21,
    [Description("hasseenforge1win")]
    HAS_SEEN_FORGE_1WIN = 0x26,
    [Description("hasseenforge2loss")]
    HAS_SEEN_FORGE_2LOSS = 40,
    [Description("hasseenforge5win")]
    HAS_SEEN_FORGE_5WIN = 0x27,
    [Description("hasseenforgecardchoice")]
    HAS_SEEN_FORGE_CARD_CHOICE = 0x23,
    [Description("hasseenforgecardchoice2")]
    HAS_SEEN_FORGE_CARD_CHOICE2 = 0x24,
    [Description("hasseenforgeherochoice")]
    HAS_SEEN_FORGE_HERO_CHOICE = 0x22,
    [Description("hasseenforgeplaymode")]
    HAS_SEEN_FORGE_PLAY_MODE = 0x25,
    [Description("hasseenforgeretire")]
    HAS_SEEN_FORGE_RETIRE = 0x29,
    [Description("firstHubVisitPastTutorial")]
    HAS_SEEN_HUB = 0x1d,
    [Description("hasseenmulligan")]
    HAS_SEEN_MULLIGAN = 0x2a,
    [Description("firstnewmedalearned")]
    HAS_SEEN_NEW_MEDAL = 30,
    [Description("hasSeenPackOpening")]
    HAS_SEEN_PACK_OPENING = 0x2f,
    [Description("hasSeenPracticeMode")]
    HAS_SEEN_PRACTICE_MODE = 0x30,
    [Description("hasseenpracticetray")]
    HAS_SEEN_PRACTICE_TRAY = 0x1c,
    [Description("hasSeenShowAllCardsReminder")]
    HAS_SEEN_SHOW_ALL_CARDS_REMINDER = 60,
    [Description("hasseentournament")]
    HAS_SEEN_TOURNAMENT = 0x18,
    [Description("clickedshowcardsidontown")]
    HAS_SEEN_UNOWNED_CARDS = 0x20,
    [Description("hud")]
    HUD = 4,
    [Description("inRankedPlayMode")]
    IN_RANKED_PLAY_MODE = 0x3f,
    INVALID = 0,
    [Description("justfinishedtutorial")]
    JUST_FINISHED_TUTORIAL = 0x1a,
    [Description("music")]
    MUSIC = 2,
    [Description("musicvolume")]
    MUSIC_VOLUME = 7,
    [Description("pagemouseovers")]
    PAGE_MOUSE_OVERS = 15,
    [Description("showadvancedcollectionmanager")]
    SHOW_ADVANCED_COLLECTIONMANAGER = 0x1b,
    [Description("sound")]
    SOUND = 1,
    [Description("soundvolume")]
    SOUND_VOLUME = 6,
    [Description("streaming")]
    STREAMING = 5,
    [Description("tipCraftingUnlocked")]
    TIP_CRAFTING_UNLOCKED = 0x39,
    [Description("forgetipprogress")]
    TIP_FORGE_PROGRESS = 0x15,
    [Description("playtipprogress")]
    TIP_PLAY_PROGRESS = 20,
    [Description("practicetipporgress")]
    TIP_PRACTICE_PROGRESS = 0x13,
    [Description("zzunused")]
    ZZUNUSED = 0x2d
}


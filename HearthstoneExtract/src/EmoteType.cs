using System;
using System.ComponentModel;

public enum EmoteType
{
    [Description("CONCEDE")]
    CONCEDE = 7,
    [Description("ERROR FULL MINIONS")]
    ERROR_FULL_MINIONS = 0x16,
    [Description("ERROR GENERIC")]
    ERROR_GENERIC = 0x1b,
    [Description("ERROR HAND FULL")]
    ERROR_HAND_FULL = 0x15,
    [Description("ERROR I ATTACKED")]
    ERROR_I_ATTACKED = 0x13,
    [Description("ERROR JUST PLAYED")]
    ERROR_JUST_PLAYED = 20,
    [Description("ERROR MINION ATTACKED")]
    ERROR_MINION_ATTACKED = 0x12,
    [Description("ERROR NEED MANA")]
    ERROR_NEED_MANA = 0x11,
    [Description("ERROR NEED WEAPON")]
    ERROR_NEED_WEAPON = 0x10,
    [Description("ERROR PLAY")]
    ERROR_PLAY = 0x18,
    [Description("ERROR STEALTH")]
    ERROR_STEALTH = 0x17,
    [Description("ERROR TARGET")]
    ERROR_TARGET = 0x19,
    [Description("ERROR TAUNT")]
    ERROR_TAUNT = 0x1a,
    [Description("GOOD GAME")]
    GOOD_GAME = 13,
    [Description("GREETINGS")]
    GREETINGS = 1,
    INVALID = 0,
    [Description("LOW CARDS")]
    LOW_CARDS = 14,
    [Description("NO CARDS")]
    NO_CARDS = 15,
    [Description("OOPS")]
    OOPS = 3,
    [Description("PICKED")]
    PICKED = 0x1c,
    [Description("SORRY")]
    SORRY = 6,
    [Description("START")]
    START = 8,
    [Description("THANKS")]
    THANKS = 5,
    [Description("THINK1")]
    THINK1 = 10,
    [Description("THINK2")]
    THINK2 = 11,
    [Description("THINK3")]
    THINK3 = 12,
    [Description("THREATEN")]
    THREATEN = 4,
    [Description("TIMER")]
    TIMER = 9,
    [Description("WELL PLAYED")]
    WELL_PLAYED = 2
}


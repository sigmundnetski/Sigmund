using System;
using System.ComponentModel;

public enum SpellStateType
{
    [Description("Action")]
    ACTION = 3,
    [Description("Birth")]
    BIRTH = 1,
    [Description("Cancel")]
    CANCEL = 4,
    [Description("Death")]
    DEATH = 5,
    [Description("Idle")]
    IDLE = 2,
    [Description("None")]
    NONE = 0
}


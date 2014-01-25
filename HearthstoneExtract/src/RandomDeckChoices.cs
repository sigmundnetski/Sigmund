using System;
using System.Collections.Generic;

public class RandomDeckChoices
{
    public List<RDMDeckEntry> choices = new List<RDMDeckEntry>();
    private static readonly string DEFAULT_DISPLAY_STRING = "default";
    public string displayString = DEFAULT_DISPLAY_STRING;

    public void Clear()
    {
        this.displayString = DEFAULT_DISPLAY_STRING;
        this.choices.Clear();
    }

    public void DebugPrintChoices()
    {
        foreach (RDMDeckEntry entry in this.choices)
        {
            Log.Ben.Print(string.Format("Choice: {0} (flair {1})", entry.EntityDef.GetDebugName(), entry.Flair));
        }
    }
}


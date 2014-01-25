using System;

public class ManaFilterTab : PegUIElement
{
    public static readonly int ALL_TAB_IDX = -1;
    public UberText m_costText;
    public ManaCrystal m_crystal;
    private FilterState m_filterState;
    private int m_manaID;
    public UberText m_otherText;
    public static readonly int SEVEN_PLUS_TAB_IDX = 7;

    protected override void Awake()
    {
        this.m_crystal.MarkAsNotInGame();
        base.Awake();
    }

    public int GetManaID()
    {
        return this.m_manaID;
    }

    public void NotifyMousedOut()
    {
        if (this.m_filterState != FilterState.ON)
        {
            this.m_crystal.state = ManaCrystal.State.READY;
        }
    }

    public void NotifyMousedOver()
    {
        if (this.m_filterState != FilterState.ON)
        {
            this.m_crystal.state = ManaCrystal.State.PROPOSED;
        }
    }

    public void SetFilterState(FilterState state)
    {
        this.m_filterState = state;
        switch (this.m_filterState)
        {
            case FilterState.ON:
                this.m_crystal.state = ManaCrystal.State.PROPOSED;
                break;

            case FilterState.OFF:
                this.m_crystal.state = ManaCrystal.State.READY;
                break;

            case FilterState.DISABLED:
                this.m_crystal.state = ManaCrystal.State.USED;
                break;
        }
    }

    public void SetManaID(int manaID)
    {
        this.m_manaID = manaID;
        this.UpdateManaText();
    }

    public static bool ShouldUseDynamicFilter(int manaID)
    {
        return ((manaID == ALL_TAB_IDX) || (manaID == SEVEN_PLUS_TAB_IDX));
    }

    private void UpdateManaText()
    {
        string str = string.Empty;
        string str2 = string.Empty;
        if (this.m_manaID == ALL_TAB_IDX)
        {
            str2 = GameStrings.Get("GLUE_COLLECTION_ALL");
        }
        else
        {
            str = this.m_manaID.ToString();
            if (this.m_manaID == SEVEN_PLUS_TAB_IDX)
            {
                str2 = GameStrings.Get("GLUE_COLLECTION_PLUS");
            }
        }
        if (this.m_costText != null)
        {
            this.m_costText.Text = str;
        }
        if (this.m_otherText != null)
        {
            this.m_otherText.Text = str2;
        }
    }

    public enum FilterState
    {
        ON,
        OFF,
        DISABLED
    }
}


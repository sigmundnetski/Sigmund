using System;
using System.Collections.Generic;
using UnityEngine;

public class ManaFilterTabManager : MonoBehaviour
{
    private int m_currentFilterValue = ManaFilterTab.ALL_TAB_IDX;
    public ManaFilterTab m_dynamicManaFilterPrefab;
    public ManaFilterTab m_singleManaFilterPrefab;
    private List<ManaFilterTab> m_tabs = new List<ManaFilterTab>();
    private bool m_tabsActive;

    public void ActivateTabs(bool active)
    {
        this.m_tabsActive = active;
        this.UpdateFilterStates();
    }

    private void AddTab(ManaFilterTab tab)
    {
        tab.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnTabPressed));
        tab.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnTabMousedOver));
        tab.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.OnTabMousedOut));
        tab.SetFilterState(ManaFilterTab.FilterState.DISABLED);
        if (UniversalInputManager.IsTouchDevice != null)
        {
            tab.SetReceiveReleaseWithoutMouseDown(true);
            tab.SetReceiveOverWithMouseDown(true);
        }
        this.m_tabs.Add(tab);
    }

    public void ClearTabs()
    {
        foreach (ManaFilterTab tab in this.m_tabs)
        {
            tab.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnTabPressed));
        }
        this.m_tabs.Clear();
    }

    public List<ManaFilterTab> GetTabs()
    {
        return this.m_tabs;
    }

    private void OnTabMousedOut(UIEvent e)
    {
        if (this.m_tabsActive)
        {
            ((ManaFilterTab) e.GetElement()).NotifyMousedOut();
        }
    }

    private void OnTabMousedOver(UIEvent e)
    {
        if (this.m_tabsActive)
        {
            ((ManaFilterTab) e.GetElement()).NotifyMousedOver();
        }
    }

    private void OnTabPressed(UIEvent e)
    {
        if (this.m_tabsActive)
        {
            ManaFilterTab element = (ManaFilterTab) e.GetElement();
            if (element.GetManaID() != this.m_currentFilterValue)
            {
                this.UpdateCurrentFilterValue(element.GetManaID());
                if (element.GetManaID() == ManaFilterTab.ALL_TAB_IDX)
                {
                    Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CM_MANA_FILTER_OFF);
                }
                else
                {
                    Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CM_MANA_FILTER_CLICKED);
                }
            }
        }
    }

    public void SetUpTabs()
    {
        Vector3 position = base.transform.position;
        for (int i = ManaFilterTab.ALL_TAB_IDX; i <= ManaFilterTab.SEVEN_PLUS_TAB_IDX; i++)
        {
            bool flag = ManaFilterTab.ShouldUseDynamicFilter(i);
            ManaFilterTab tab = !flag ? ((ManaFilterTab) UnityEngine.Object.Instantiate(this.m_singleManaFilterPrefab)) : ((ManaFilterTab) UnityEngine.Object.Instantiate(this.m_dynamicManaFilterPrefab));
            tab.transform.parent = base.transform;
            tab.transform.localScale = new Vector3(0.0035f, 0.0035f, 0.0035f);
            tab.SetManaID(i);
            float x = tab.GetComponent<BoxCollider>().bounds.size.x;
            float num4 = !flag ? (x / 2f) : 0f;
            position.x += num4;
            tab.transform.position = position;
            this.AddTab(tab);
            position.x += !flag ? num4 : x;
        }
    }

    private void UpdateCurrentFilterValue(int filterValue)
    {
        if (filterValue != this.m_currentFilterValue)
        {
            SoundManager.Get().LoadAndPlay("mana_crystal_refresh");
            CollectionManagerDisplay.Get().FilterByManaCost(filterValue);
        }
        this.m_currentFilterValue = filterValue;
        this.UpdateFilterStates();
    }

    private void UpdateFilterStates()
    {
        foreach (ManaFilterTab tab in this.m_tabs)
        {
            ManaFilterTab.FilterState dISABLED = ManaFilterTab.FilterState.DISABLED;
            if (this.m_tabsActive)
            {
                dISABLED = (tab.GetManaID() != this.m_currentFilterValue) ? ManaFilterTab.FilterState.OFF : ManaFilterTab.FilterState.ON;
            }
            tab.SetFilterState(dISABLED);
        }
    }
}


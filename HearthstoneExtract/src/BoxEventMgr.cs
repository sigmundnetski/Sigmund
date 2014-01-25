using System;
using System.Collections.Generic;
using UnityEngine;

public class BoxEventMgr : MonoBehaviour
{
    public BoxEventInfo m_EventInfo;
    private Dictionary<BoxEventType, Spell> m_eventMap = new Dictionary<BoxEventType, Spell>();

    private void Awake()
    {
        this.m_eventMap.Add(BoxEventType.STARTUP_HUB, this.m_EventInfo.m_StartupHub);
        this.m_eventMap.Add(BoxEventType.STARTUP_TUTORIAL, this.m_EventInfo.m_StartupTutorial);
        this.m_eventMap.Add(BoxEventType.TUTORIAL_PLAY, this.m_EventInfo.m_TutorialPlay);
        this.m_eventMap.Add(BoxEventType.DISK_LOADING, this.m_EventInfo.m_DiskLoading);
        this.m_eventMap.Add(BoxEventType.DISK_MAIN_MENU, this.m_EventInfo.m_DiskMainMenu);
        this.m_eventMap.Add(BoxEventType.DOORS_CLOSE, this.m_EventInfo.m_DoorsClose);
        this.m_eventMap.Add(BoxEventType.DOORS_OPEN, this.m_EventInfo.m_DoorsOpen);
        this.m_eventMap.Add(BoxEventType.DRAWER_OPEN, this.m_EventInfo.m_DrawerOpen);
        this.m_eventMap.Add(BoxEventType.DRAWER_CLOSE, this.m_EventInfo.m_DrawerClose);
        this.m_eventMap.Add(BoxEventType.SHADOW_FADE_IN, this.m_EventInfo.m_ShadowFadeIn);
        this.m_eventMap.Add(BoxEventType.SHADOW_FADE_OUT, this.m_EventInfo.m_ShadowFadeOut);
    }

    public Spell GetEventSpell(BoxEventType eventType)
    {
        Spell spell = null;
        this.m_eventMap.TryGetValue(eventType, out spell);
        return spell;
    }
}


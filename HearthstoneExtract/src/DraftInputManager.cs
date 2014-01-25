using System;
using System.Collections.Generic;
using UnityEngine;

public class DraftInputManager : MonoBehaviour
{
    private Scrollbar m_scrollBar;
    private static DraftInputManager s_instance;

    private void Awake()
    {
        s_instance = this;
    }

    public static DraftInputManager Get()
    {
        return s_instance;
    }

    private void HandleDraftHotkeys()
    {
        if (DraftDisplay.Get() != null)
        {
            List<DraftCardVisual> cardVisuals = DraftDisplay.Get().GetCardVisuals();
            if ((cardVisuals != null) && (cardVisuals.Count != 0))
            {
                int num = -1;
                if (Input.GetKeyUp(KeyCode.Alpha1))
                {
                    num = 0;
                }
                else if (Input.GetKeyUp(KeyCode.Alpha2))
                {
                    num = 1;
                }
                else if (Input.GetKeyUp(KeyCode.Alpha3))
                {
                    num = 2;
                }
                if ((num != -1) && (cardVisuals.Count >= (num + 1)))
                {
                    DraftCardVisual visual = cardVisuals[num];
                    if (visual != null)
                    {
                        visual.ChooseThisCard();
                    }
                }
            }
        }
    }

    public void SetScrollbar(Scrollbar scrollbar)
    {
        this.m_scrollBar = scrollbar;
    }

    public void Unload()
    {
    }

    private void Update()
    {
        this.HandleDraftHotkeys();
        this.UpdateScrollbarDrag();
    }

    private void UpdateScrollbarDrag()
    {
        if ((this.m_scrollBar != null) && Input.GetMouseButtonUp(0))
        {
            this.m_scrollBar.m_thumb.StopDragging();
            this.m_scrollBar = null;
        }
    }
}


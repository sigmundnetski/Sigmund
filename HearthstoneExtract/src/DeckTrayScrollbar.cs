using System;
using System.Collections;
using UnityEngine;

public class DeckTrayScrollbar : Scrollbar
{
    public BoxCollider m_deckContentsScrollWindow;
    private float m_deckContentsScrollWindowHeight;
    public BoxCollider m_deckListScrollWindow;
    private float m_deckListScrollWindowHeight;
    private bool m_forceDisableInput;

    private void Activate()
    {
        if (!base.m_isActive)
        {
            base.m_isActive = true;
            object[] args = new object[] { "rotation", Vector3.zero, "islocal", true, "time", 0.5f, "name", "rotation" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(base.gameObject, "rotation");
            iTween.RotateTo(base.gameObject, hashtable);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.m_deckListScrollWindowHeight = this.m_deckListScrollWindow.size.z;
        this.m_deckListScrollWindow.enabled = false;
        this.m_deckContentsScrollWindowHeight = this.m_deckContentsScrollWindow.size.z;
        this.m_deckContentsScrollWindow.enabled = false;
    }

    private void Deactivate()
    {
        if (base.m_isActive)
        {
            base.m_isActive = false;
            object[] args = new object[] { "rotation", new Vector3(0f, 0f, 180f), "islocal", true, "time", 0.5f, "name", "rotation" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(base.gameObject, "rotation");
            iTween.RotateTo(base.gameObject, hashtable);
        }
    }

    public void DisableInputUntilInit()
    {
        this.m_forceDisableInput = true;
    }

    protected override void GetBoundsOfChildren(GameObject go)
    {
        TraySection[] componentsInChildren = go.GetComponentsInChildren<TraySection>();
        DeckTrayDeckTileVisual[] visualArray = go.GetComponentsInChildren<DeckTrayDeckTileVisual>();
        bool flag = false;
        if (componentsInChildren != null)
        {
            foreach (TraySection section in componentsInChildren)
            {
                if (section.IsOpen())
                {
                    Bounds doorBounds = section.GetDoorBounds();
                    if (!flag)
                    {
                        this.m_childrenBounds.SetMinMax(doorBounds.min, doorBounds.max);
                        flag = true;
                    }
                    else
                    {
                        Vector3 max = Vector3.Max(doorBounds.max, this.m_childrenBounds.max);
                        Vector3 min = Vector3.Min(doorBounds.min, this.m_childrenBounds.min);
                        this.m_childrenBounds.SetMinMax(min, max);
                    }
                }
            }
        }
        if (visualArray != null)
        {
            foreach (DeckTrayDeckTileVisual visual in visualArray)
            {
                Bounds bounds = visual.GetBounds();
                if (!flag)
                {
                    this.m_childrenBounds.SetMinMax(bounds.min, bounds.max);
                    flag = true;
                }
                else
                {
                    Vector3 vector3 = Vector3.Max(bounds.max, this.m_childrenBounds.max);
                    Vector3 vector4 = Vector3.Min(bounds.min, this.m_childrenBounds.min);
                    this.m_childrenBounds.SetMinMax(vector4, vector3);
                }
            }
        }
        NormalButton componentInChildren = go.GetComponentInChildren<NormalButton>();
        if ((componentInChildren != null) && componentInChildren.gameObject.activeInHierarchy)
        {
            Bounds bounds3 = componentInChildren.collider.bounds;
            Vector3 vector5 = Vector3.Max(bounds3.max, this.m_childrenBounds.max);
            Vector3 vector6 = Vector3.Min(bounds3.min, this.m_childrenBounds.min);
            this.m_childrenBounds.SetMinMax(vector6, vector5);
        }
    }

    public override void Hide()
    {
        this.Deactivate();
        base.ShowButtonsAndThumb(false);
    }

    public void Init(GameObject scrollArea, bool isDeckContentsView)
    {
        float scrollWindowHeight = !isDeckContentsView ? this.m_deckListScrollWindowHeight : this.m_deckContentsScrollWindowHeight;
        base.OverrideScrollWindowHeight(scrollWindowHeight);
        base.m_scrollArea = scrollArea;
        base.Init();
        this.m_forceDisableInput = false;
    }

    protected override bool InputIsOver()
    {
        if (this.m_forceDisableInput)
        {
            return false;
        }
        return (((CollectionDeckTray.Get() != null) && CollectionDeckTray.Get().MouseIsOver()) || (((DraftDeckTray.Get() != null) && DraftDeckTray.Get().MouseIsOver()) || base.InputIsOver()));
    }

    public override void Show()
    {
        this.Activate();
        base.ShowButtonsAndThumb(true);
    }
}


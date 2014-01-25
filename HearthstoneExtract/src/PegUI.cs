using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PegUI : MonoBehaviour
{
    private const float DOUBLECLICK_COUNT_DISABLED = -1f;
    private const float DOUBLECLICK_TOLERANCE = 0.7f;
    private PegUIElement m_currentElement;
    private List<PegUICustomBehavior> m_customBehaviors = new List<PegUICustomBehavior>();
    private Vector3 m_lastClickPosition;
    private float m_lastClickTimer;
    private PegUIElement m_mouseDownElement;
    private PegUIElement m_prevElement;
    private DelSwipeListener m_swipeListener;
    private Camera m_UICam;
    private const float MOUSEDOWN_COUNT_DISABLED = -1f;
    public Camera orthographicUICam;
    public static PegUI s_instance;
    public static readonly LayerMask UI_OVERLAY_BIT_MASK = ((((((GameLayer.SystemDialog.LayerBit() | GameLayer.HighPriorityUI.LayerBit()) | GameLayer.BattleNetDialog.LayerBit()) | GameLayer.BattleNetChat.LayerBit()) | GameLayer.BattleNetFriendList.LayerBit()) | GameLayer.BattleNet.LayerBit()) | GameLayer.UniversalUI.LayerBit());
    public static readonly int[] UI_OVERLAY_BIT_ORDER = new int[] { GameLayer.SystemDialog.LayerBit(), GameLayer.HighPriorityUI.LayerBit(), GameLayer.BattleNetDialog.LayerBit(), GameLayer.BattleNetChat.LayerBit(), GameLayer.BattleNetFriendList.LayerBit(), GameLayer.BattleNet.LayerBit(), GameLayer.UniversalUI.LayerBit() };

    private void Awake()
    {
        s_instance = this;
        this.m_lastClickPosition = Vector3.zero;
        UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
    }

    public void CancelSwipeDetection(DelSwipeListener listener)
    {
        if (listener == this.m_swipeListener)
        {
            this.m_swipeListener = null;
        }
    }

    public void EnableSwipeDetection(Rect swipeRect, DelSwipeListener listener)
    {
        this.m_swipeListener = listener;
    }

    public PegUIElement FindHitElement()
    {
        RaycastHit hit;
        for (int i = 0; i < UI_OVERLAY_BIT_ORDER.Length; i++)
        {
            LayerMask layerMask = UI_OVERLAY_BIT_ORDER[i];
            if (UniversalInputManager.Get().GetInputHitInfo(layerMask, out hit))
            {
                return hit.transform.GetComponent<PegUIElement>();
            }
        }
        if (UniversalInputManager.Get().GetInputHitInfo(this.m_UICam, this.m_UICam.cullingMask, out hit))
        {
            return hit.transform.GetComponent<PegUIElement>();
        }
        return null;
    }

    public static PegUI Get()
    {
        return s_instance;
    }

    public PegUIElement GetMousedOverElement()
    {
        return this.m_currentElement;
    }

    public PegUIElement GetPrevMousedOverElement()
    {
        return this.m_prevElement;
    }

    private void MouseInputUpdate()
    {
        if (this.m_UICam != null)
        {
            foreach (PegUICustomBehavior behavior in this.m_customBehaviors)
            {
                if (behavior.UpdateUI())
                {
                    return;
                }
            }
            if (this.m_lastClickTimer != -1f)
            {
                this.m_lastClickTimer += UnityEngine.Time.deltaTime;
            }
            PegUIElement element = this.FindHitElement();
            this.m_prevElement = this.m_currentElement;
            if ((element != null) && element.IsEnabled())
            {
                this.m_currentElement = element;
            }
            else
            {
                this.m_currentElement = null;
            }
            if ((this.m_prevElement != null) && (this.m_currentElement != this.m_prevElement))
            {
                PegCursor.Get().SetMode(PegCursor.Mode.UP);
                this.m_prevElement.TriggerOut();
                this.m_lastClickTimer = -1f;
            }
            if (this.m_currentElement == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    PegCursor.Get().SetMode(PegCursor.Mode.DOWN);
                }
                else if (!Input.GetMouseButton(0))
                {
                    PegCursor.Get().SetMode(PegCursor.Mode.UP);
                }
                if ((this.m_mouseDownElement != null) && Input.GetMouseButtonUp(0))
                {
                    this.m_mouseDownElement.TriggerReleaseAll(false);
                    this.m_mouseDownElement = null;
                }
            }
            else if ((!this.UpdateMouseLeftClick() && !this.UpdateMouseLeftHold()) && !this.UpdateMouseRightClick())
            {
                this.UpdateMouseOver();
            }
        }
    }

    private void OnMouseOnOrOffScreen(bool onScreen)
    {
        if (!onScreen)
        {
            this.m_lastClickPosition = Vector3.zero;
            this.m_currentElement = null;
        }
    }

    public void RegisterCustomBehavior(PegUICustomBehavior behavior)
    {
        this.m_customBehaviors.Add(behavior);
    }

    public void SetInputCamera(Camera cam)
    {
        this.m_UICam = cam;
        if (this.m_UICam == null)
        {
            Debug.Log("UICam is null!");
        }
    }

    private void Start()
    {
        UniversalInputManager.Get().RegisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
    }

    public void UnregisterCustomBehavior(PegUICustomBehavior behavior)
    {
        this.m_customBehaviors.Remove(behavior);
    }

    private void Update()
    {
        this.MouseInputUpdate();
    }

    private bool UpdateMouseLeftClick()
    {
        bool flag = false;
        if (Input.GetMouseButtonDown(0))
        {
            flag = true;
            if (this.m_currentElement.GetCursorDown() != PegCursor.Mode.NONE)
            {
                PegCursor.Get().SetMode(this.m_currentElement.GetCursorDown());
            }
            else
            {
                PegCursor.Get().SetMode(PegCursor.Mode.DOWN);
            }
            if ((UniversalInputManager.IsTouchDevice != null) && this.m_currentElement.GetReceiveOverWithMouseDown())
            {
                this.m_currentElement.TriggerOver();
            }
            this.m_currentElement.TriggerPress();
            this.m_lastClickPosition = Input.mousePosition;
            this.m_mouseDownElement = this.m_currentElement;
        }
        if (Input.GetMouseButtonUp(0))
        {
            flag = true;
            if (((this.m_lastClickTimer > 0f) && (this.m_lastClickTimer <= 0.7f)) && this.m_currentElement.GetDoubleClickEnabled())
            {
                this.m_currentElement.TriggerDoubleClick();
                this.m_lastClickTimer = -1f;
            }
            else
            {
                if ((this.m_mouseDownElement == this.m_currentElement) || this.m_currentElement.GetReceiveReleaseWithoutMouseDown())
                {
                    this.m_currentElement.TriggerRelease();
                }
                if (this.m_mouseDownElement != null)
                {
                    this.m_lastClickTimer = 0f;
                    this.m_mouseDownElement.TriggerReleaseAll(this.m_currentElement == this.m_mouseDownElement);
                    this.m_mouseDownElement = null;
                }
            }
            if (this.m_currentElement.GetCursorOver() != PegCursor.Mode.NONE)
            {
                PegCursor.Get().SetMode(this.m_currentElement.GetCursorOver());
            }
            else
            {
                PegCursor.Get().SetMode(PegCursor.Mode.OVER);
            }
            this.m_lastClickPosition = Vector3.zero;
        }
        return flag;
    }

    private bool UpdateMouseLeftHold()
    {
        if (!Input.GetMouseButton(0))
        {
            return false;
        }
        if ((this.m_lastClickPosition != Vector3.zero) && (Vector3.Distance(this.m_lastClickPosition, Input.mousePosition) > this.m_currentElement.GetDragTolerance()))
        {
            this.m_currentElement.TriggerHold();
        }
        else if (this.m_currentElement.GetReceiveOverWithMouseDown() && (this.m_currentElement != this.m_prevElement))
        {
            if (this.m_currentElement.GetCursorOver() != PegCursor.Mode.NONE)
            {
                PegCursor.Get().SetMode(this.m_currentElement.GetCursorOver());
            }
            else
            {
                PegCursor.Get().SetMode(PegCursor.Mode.OVER);
            }
            this.m_currentElement.TriggerOver();
        }
        return true;
    }

    private void UpdateMouseOver()
    {
        if (this.m_currentElement != this.m_prevElement)
        {
            if (this.m_currentElement.GetCursorOver() != PegCursor.Mode.NONE)
            {
                PegCursor.Get().SetMode(this.m_currentElement.GetCursorOver());
            }
            else
            {
                PegCursor.Get().SetMode(PegCursor.Mode.OVER);
            }
            this.m_currentElement.TriggerOver();
        }
    }

    private bool UpdateMouseRightClick()
    {
        bool flag = false;
        if (Input.GetMouseButtonDown(1))
        {
            flag = true;
            this.m_currentElement.TriggerRightClick();
        }
        return flag;
    }

    public delegate void DelSwipeListener(PegUI.SWIPE_DIRECTION direction);

    public enum Layer
    {
        MANUAL,
        RELATIVE_TO_PARENT,
        BACKGROUND,
        HUD,
        DIALOG
    }

    public enum SWIPE_DIRECTION
    {
        RIGHT,
        LEFT
    }
}


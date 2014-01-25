using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScrollbarControl : MonoBehaviour
{
    public Collider m_DragCollider;
    private bool m_dragging;
    private FinishHandler m_finishHandler;
    public Transform m_LeftBone;
    public PegUIElement m_PressElement;
    private float m_prevThumbUnitPos;
    public Transform m_RightBone;
    public GameObject m_Thumb;
    private float m_thumbUnitPos;
    private UpdateHandler m_updateHandler;

    private void Awake()
    {
        this.m_PressElement.AddEventListener(UIEventType.PRESS, new UIEvent.Handler(this.OnPressElementPress));
        this.m_PressElement.AddEventListener(UIEventType.RELEASEALL, new UIEvent.Handler(this.OnPressElementReleaseAll));
        this.m_DragCollider.enabled = false;
    }

    private void FireFinishEvent()
    {
        if (this.m_finishHandler != null)
        {
            this.m_finishHandler();
        }
    }

    private void FireUpdateEvent()
    {
        if (this.m_updateHandler != null)
        {
            this.m_updateHandler(this.GetValue());
        }
    }

    public FinishHandler GetFinishHandler()
    {
        return this.m_finishHandler;
    }

    public UpdateHandler GetUpdateHandler()
    {
        return this.m_updateHandler;
    }

    public float GetValue()
    {
        return this.m_thumbUnitPos;
    }

    private void HandleOutOfBounds()
    {
        this.UpdateThumb();
        this.HandleThumbUpdate();
        this.HandleRelease();
        this.FireFinishEvent();
    }

    private void HandlePress()
    {
        this.m_dragging = true;
        UniversalInputManager.Get().RegisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
        this.m_PressElement.AddEventListener(UIEventType.RELEASEALL, new UIEvent.Handler(this.OnPressElementReleaseAll));
        this.m_PressElement.collider.enabled = false;
        this.m_DragCollider.enabled = true;
    }

    private void HandleRelease()
    {
        this.m_DragCollider.enabled = false;
        this.m_PressElement.collider.enabled = true;
        this.m_PressElement.RemoveEventListener(UIEventType.RELEASEALL, new UIEvent.Handler(this.OnPressElementReleaseAll));
        UniversalInputManager.Get().UnregisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
        this.m_dragging = false;
    }

    private void HandleThumbUpdate()
    {
        float prevThumbUnitPos = this.m_prevThumbUnitPos;
        this.m_prevThumbUnitPos = this.m_thumbUnitPos;
        if (!object.Equals(this.m_thumbUnitPos, prevThumbUnitPos))
        {
            this.FireUpdateEvent();
        }
    }

    private void OnDestroy()
    {
        UniversalInputManager.Get().UnregisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
    }

    private void OnMouseOnOrOffScreen(bool onScreen)
    {
        if (!onScreen)
        {
            this.HandleOutOfBounds();
        }
    }

    private void OnPressElementPress(UIEvent e)
    {
        this.HandlePress();
    }

    private void OnPressElementReleaseAll(UIEvent e)
    {
        this.HandleRelease();
        this.FireFinishEvent();
    }

    public void SetFinishHandler(FinishHandler handler)
    {
        this.m_finishHandler = handler;
    }

    public void SetUpdateHandler(UpdateHandler handler)
    {
        this.m_updateHandler = handler;
    }

    public void SetValue(float val)
    {
        this.m_thumbUnitPos = Mathf.Clamp01(val);
        this.m_prevThumbUnitPos = this.m_thumbUnitPos;
        this.UpdateThumb();
    }

    private void Update()
    {
        this.UpdateDrag();
    }

    private void UpdateDrag()
    {
        if (this.m_dragging)
        {
            RaycastHit hit;
            if (UniversalInputManager.Get().GetInputHitInfo(((int) 1) << this.m_DragCollider.gameObject.layer, out hit) && (hit.collider == this.m_DragCollider))
            {
                float x = this.m_LeftBone.position.x;
                float num3 = this.m_RightBone.position.x - x;
                this.m_thumbUnitPos = Mathf.Clamp01((hit.point.x - x) / num3);
                this.UpdateThumb();
                this.HandleThumbUpdate();
            }
            else
            {
                this.m_thumbUnitPos = this.m_prevThumbUnitPos;
                this.HandleOutOfBounds();
            }
        }
    }

    private void UpdateThumb()
    {
        this.m_Thumb.transform.position = Vector3.Lerp(this.m_LeftBone.position, this.m_RightBone.position, this.m_thumbUnitPos);
    }

    public delegate void FinishHandler();

    public delegate void UpdateHandler(float val);
}


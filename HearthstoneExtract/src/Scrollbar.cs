using System;
using UnityEngine;

public class Scrollbar : MonoBehaviour
{
    protected Bounds m_childrenBounds;
    public PegUIElement m_downButton;
    protected bool m_isActive = true;
    protected bool m_isDragging;
    public PegUIElement m_leftButton;
    public PegUIElement m_rightButton;
    public GameObject m_scrollArea;
    protected Vector3 m_scrollAreaEndPos;
    protected Vector3 m_scrollAreaStartPos;
    protected float m_scrollValue;
    protected bool m_scrollVertically = true;
    public BoxCollider m_scrollWindow;
    protected float m_scrollWindowHeight;
    public Vector3 m_sliderEndLocalPos;
    public Vector3 m_sliderStartLocalPos;
    protected float m_stepSize;
    public ScrollBarThumb m_thumb;
    protected Vector3 m_thumbPosition;
    public GameObject m_track;
    public PegUIElement m_upButton;

    protected virtual void Awake()
    {
        if ((this.m_upButton != null) && (this.m_downButton != null))
        {
            this.m_scrollVertically = true;
            this.m_upButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.UpButtonPress));
            this.m_downButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.DownButtonPress));
        }
        else if ((this.m_leftButton != null) && (this.m_downButton != null))
        {
            this.m_scrollVertically = false;
            this.m_leftButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.LeftButtonPress));
            this.m_rightButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.RightButtonPress));
        }
        this.m_scrollWindowHeight = this.m_scrollWindow.size.z;
        this.m_scrollWindow.enabled = false;
    }

    private void ClampScrollValue()
    {
        this.m_scrollValue = Mathf.Clamp(this.m_scrollValue, 0f, 1f);
    }

    private void DownButtonPress(UIEvent e)
    {
        this.ScrollDown();
    }

    protected virtual void GetBoundsOfChildren(GameObject go)
    {
        this.m_childrenBounds = new Bounds(Vector3.zero, Vector3.zero);
        UnityEngine.Renderer[] componentsInChildren = go.GetComponentsInChildren<UnityEngine.Renderer>();
        if (componentsInChildren != null)
        {
            foreach (UnityEngine.Renderer renderer in componentsInChildren)
            {
                Bounds bounds = renderer.bounds;
                Vector3 max = Vector3.Max(bounds.max, this.m_childrenBounds.max);
                Vector3 min = Vector3.Min(bounds.min, this.m_childrenBounds.min);
                this.m_childrenBounds.SetMinMax(min, max);
            }
        }
    }

    public virtual void Hide()
    {
        this.m_isActive = false;
        this.ShowButtonsAndThumb(false);
        base.gameObject.SetActive(false);
    }

    public void Init()
    {
        this.m_scrollValue = 0f;
        this.m_stepSize = 1f;
        this.m_thumb.transform.localPosition = this.m_sliderStartLocalPos;
        this.m_scrollAreaStartPos = this.m_scrollArea.transform.position;
        this.UpdateScrollAreaBounds();
    }

    protected virtual bool InputIsOver()
    {
        return UniversalInputManager.Get().InputIsOver(base.gameObject);
    }

    private void LeftButtonPress(UIEvent e)
    {
    }

    protected void OverrideScrollWindowHeight(float scrollWindowHeight)
    {
        this.m_scrollWindowHeight = scrollWindowHeight;
    }

    private void RightButtonPress(UIEvent e)
    {
    }

    private void ScrollDown()
    {
        this.ScrollDown(this.m_stepSize);
    }

    private void ScrollDown(float amount)
    {
        this.m_scrollValue += amount;
        this.ClampScrollValue();
        this.UpdateThumbPosition();
        this.UpdateScrollAreaPosition(true);
    }

    private void ScrollUp()
    {
        this.ScrollUp(this.m_stepSize);
    }

    private void ScrollUp(float amount)
    {
        this.m_scrollValue -= amount;
        this.ClampScrollValue();
        this.UpdateThumbPosition();
        this.UpdateScrollAreaPosition(true);
    }

    public virtual void Show()
    {
        this.m_isActive = true;
        this.ShowButtonsAndThumb(true);
        base.gameObject.SetActive(true);
    }

    protected void ShowButtonsAndThumb(bool show)
    {
        if (this.m_upButton != null)
        {
            this.m_upButton.gameObject.SetActive(show);
        }
        if (this.m_downButton != null)
        {
            this.m_downButton.gameObject.SetActive(show);
        }
        if (this.m_leftButton != null)
        {
            this.m_leftButton.gameObject.SetActive(show);
        }
        if (this.m_rightButton != null)
        {
            this.m_rightButton.gameObject.SetActive(show);
        }
        if (this.m_thumb != null)
        {
            this.m_thumb.gameObject.SetActive(show);
        }
    }

    private void UpButtonPress(UIEvent e)
    {
        this.ScrollUp();
    }

    private void Update()
    {
        if (this.m_isActive && this.m_scrollVertically)
        {
            if (this.InputIsOver())
            {
                if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    this.ScrollDown();
                }
                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    this.ScrollUp();
                }
            }
            if (this.m_thumb.IsDragging())
            {
                Vector3 vector;
                Vector3 min = this.m_track.GetComponent<BoxCollider>().bounds.min;
                if (UniversalInputManager.Get().GetInputPointOnPlane(GameLayer.GeneralUI, min, out vector))
                {
                    vector = base.transform.InverseTransformPoint(vector);
                    if (vector.z < this.m_sliderStartLocalPos.z)
                    {
                        TransformUtil.SetLocalPosZ(this.m_thumb.gameObject, this.m_sliderStartLocalPos.z);
                    }
                    else if (vector.z > this.m_sliderEndLocalPos.z)
                    {
                        TransformUtil.SetLocalPosZ(this.m_thumb.gameObject, this.m_sliderEndLocalPos.z);
                    }
                    else
                    {
                        TransformUtil.SetLocalPosZ(this.m_thumb.gameObject, vector.z);
                    }
                    this.m_scrollValue = (vector.z - this.m_sliderStartLocalPos.z) / (this.m_sliderEndLocalPos.z - this.m_sliderStartLocalPos.z);
                    this.ClampScrollValue();
                    this.UpdateScrollAreaPosition(false);
                }
            }
        }
    }

    public void UpdateScrollAreaBounds()
    {
        this.GetBoundsOfChildren(this.m_scrollArea);
        float num2 = this.m_childrenBounds.size.z - this.m_scrollWindowHeight;
        if (num2 <= 0f)
        {
            this.m_scrollValue = 0f;
            this.Hide();
        }
        else
        {
            int num3 = (int) Mathf.Ceil(num2 / 5f);
            this.m_stepSize = 1f / ((float) num3);
            this.m_scrollAreaEndPos = this.m_scrollAreaStartPos;
            this.m_scrollAreaEndPos.z += num2;
            this.Show();
        }
        this.UpdateThumbPosition();
        this.UpdateScrollAreaPosition(false);
    }

    private void UpdateScrollAreaPosition(bool tween)
    {
        Vector3 vector = Vector3.Lerp(this.m_scrollAreaStartPos, this.m_scrollAreaEndPos, this.m_scrollValue);
        if (tween)
        {
            object[] args = new object[] { "position", vector, "time", 0.2f, "isLocal", false };
            iTween.MoveTo(this.m_scrollArea, iTween.Hash(args));
        }
        else
        {
            this.m_scrollArea.transform.position = vector;
        }
    }

    private void UpdateThumbPosition()
    {
        this.m_thumbPosition = Vector3.Lerp(this.m_sliderStartLocalPos, this.m_sliderEndLocalPos, this.m_scrollValue);
        this.m_thumb.transform.localPosition = this.m_thumbPosition;
    }
}


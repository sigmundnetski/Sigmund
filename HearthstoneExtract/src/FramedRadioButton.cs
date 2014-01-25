using System;
using UnityEngine;

public class FramedRadioButton : MonoBehaviour
{
    public GameObject m_frameEndLeft;
    public GameObject m_frameEndRight;
    public GameObject m_frameFill;
    public GameObject m_frameLeft;
    private float m_leftEdgeOffset;
    public RadioButton m_radioButton;
    public GameObject m_root;
    public UberText m_text;

    public Bounds GetBounds()
    {
        Bounds bounds = this.m_frameFill.renderer.bounds;
        this.IncludeBoundsOfGameObject(this.m_frameEndLeft, ref bounds);
        this.IncludeBoundsOfGameObject(this.m_frameEndRight, ref bounds);
        this.IncludeBoundsOfGameObject(this.m_frameLeft, ref bounds);
        return bounds;
    }

    public int GetButtonID()
    {
        return this.m_radioButton.GetButtonID();
    }

    public float GetLeftEdgeOffset()
    {
        return this.m_leftEdgeOffset;
    }

    public void Hide()
    {
        this.m_root.SetActive(false);
    }

    private void IncludeBoundsOfGameObject(GameObject go, ref Bounds bounds)
    {
        if (go.activeSelf)
        {
            Bounds bounds2 = go.renderer.bounds;
            Vector3 max = Vector3.Max(bounds2.max, bounds.max);
            Vector3 min = Vector3.Min(bounds2.min, bounds.min);
            bounds.SetMinMax(min, max);
        }
    }

    public virtual void Init(FrameType frameType, string text, int buttonID, object userData)
    {
        this.m_radioButton.SetButtonID(buttonID);
        this.m_radioButton.SetUserData(userData);
        this.m_text.Text = text;
        this.m_text.UpdateNow();
        this.m_frameFill.SetActive(true);
        bool flag = false;
        bool flag2 = false;
        switch (frameType)
        {
            case FrameType.SINGLE:
                flag = true;
                flag2 = true;
                break;

            case FrameType.MULTI_LEFT_END:
                flag = true;
                flag2 = false;
                break;

            case FrameType.MULTI_RIGHT_END:
                flag = false;
                flag2 = true;
                break;

            case FrameType.MULTI_MIDDLE:
                flag = false;
                flag2 = false;
                break;
        }
        this.m_frameEndLeft.SetActive(flag);
        this.m_frameLeft.SetActive(!flag);
        this.m_frameEndRight.SetActive(flag2);
        Transform transform = !flag ? this.m_frameLeft.transform : this.m_frameEndLeft.transform;
        this.m_leftEdgeOffset = transform.position.x - base.transform.position.x;
    }

    public void Show()
    {
        this.m_root.SetActive(true);
    }

    public enum FrameType
    {
        SINGLE,
        MULTI_LEFT_END,
        MULTI_RIGHT_END,
        MULTI_MIDDLE
    }
}


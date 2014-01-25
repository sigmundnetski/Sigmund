using System;
using UnityEngine;

[ExecuteInEditMode]
public class StandardPegButtonNew : PegUIElement
{
    private const float GRAY_FRAME_SCALE = 0.88f;
    private const float HIGHLIGHT_SCALE = 1.2f;
    public ThreeSliceElement m_border;
    public ThreeSliceElement m_button;
    public UberText m_buttonText;
    public float m_buttonWidth;
    public GameObject m_downBone;
    public bool m_ExecuteInEditMode;
    public HighlightState m_highlight;
    public GameObject m_upBone;

    public void Hide()
    {
        base.gameObject.SetActive(false);
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        this.m_button.transform.localPosition = this.m_upBone.transform.localPosition;
        if (this.m_highlight != null)
        {
            this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_OFF);
        }
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        this.m_button.transform.localPosition = this.m_downBone.transform.localPosition;
        if (this.m_highlight != null)
        {
            this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE);
        }
    }

    protected override void OnPress()
    {
        this.m_button.transform.localPosition = this.m_downBone.transform.localPosition;
    }

    protected override void OnRelease()
    {
        this.m_button.transform.localPosition = this.m_upBone.transform.localPosition;
        if (this.m_highlight != null)
        {
            this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_OFF);
        }
    }

    public void SetText(string t)
    {
        this.m_buttonText.Text = t;
    }

    public void SetWidth(float globalWidth)
    {
        this.m_button.SetWidth(globalWidth * 0.88f);
        this.m_border.SetWidth(globalWidth);
        Vector3 size = this.m_button.GetSize();
        Vector3 vector2 = TransformUtil.ComputeWorldScale(base.transform);
        Vector3 vector3 = new Vector3(size.x / vector2.x, size.z / vector2.z, size.y / vector2.y);
        base.GetComponent<BoxCollider>().size = vector3;
    }

    public void Show()
    {
        base.gameObject.SetActive(true);
    }
}


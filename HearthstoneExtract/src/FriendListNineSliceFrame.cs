using System;
using UnityEngine;

public class FriendListNineSliceFrame : NineSliceElement
{
    protected GameObject m_originalBottomRight;
    protected GameObject m_originalRight;
    protected GameObject m_originalTopRight;
    public GameObject m_ScrollBottomRight;
    protected bool m_scrolling;
    public GameObject m_ScrollRight;
    public GameObject m_ScrollTopRight;

    protected override void Awake()
    {
        base.Awake();
        this.InitScrolling();
        this.UpdateScrolling();
        base.SetSize(base.m_size);
    }

    public void EnableScrolling(bool enabled)
    {
        if (enabled != this.m_scrolling)
        {
            this.m_scrolling = enabled;
            this.UpdateScrolling();
            this.UpdateCollision();
        }
    }

    private void InitScrolling()
    {
        this.m_originalTopRight = base.m_topRight;
        this.m_originalRight = base.m_right;
        this.m_originalBottomRight = base.m_bottomRight;
        Vector3 size = base.m_left.GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 vector2 = base.m_right.GetComponent<MeshFilter>().mesh.bounds.size;
        this.m_initialSize.x = (size.x + this.m_initialMiddleSize.x) + vector2.x;
        this.m_size.x = this.m_initialSize.x;
    }

    public bool IsScrolling()
    {
        return this.m_scrolling;
    }

    public override void SetSize(float width, float height)
    {
        base.SetSize(width, height);
        this.UpdateCollision();
    }

    private void UpdateCollision()
    {
        Vector3 max;
        Vector3 min = base.m_bottomLeft.renderer.bounds.min;
        if (this.m_scrolling)
        {
            max = this.m_ScrollTopRight.renderer.bounds.max;
        }
        else
        {
            max = base.m_topRight.renderer.bounds.max;
        }
        Vector3 lhs = base.transform.InverseTransformPoint(min);
        Vector3 rhs = base.transform.InverseTransformPoint(max);
        Vector3 vector5 = Vector3.Min(lhs, rhs);
        Vector3 vector6 = Vector3.Max(lhs, rhs);
        BoxCollider component = base.GetComponent<BoxCollider>();
        component.center = (Vector3) (0.5f * (vector6 + vector5));
        component.size = vector6 - vector5;
    }

    private void UpdateScrolling()
    {
        if (this.m_scrolling)
        {
            this.m_originalTopRight.SetActive(false);
            this.m_originalRight.SetActive(false);
            this.m_originalBottomRight.SetActive(false);
            base.m_topRight = this.m_ScrollTopRight;
            base.m_right = this.m_ScrollRight;
            base.m_bottomRight = this.m_ScrollBottomRight;
        }
        else
        {
            this.m_ScrollTopRight.SetActive(false);
            this.m_ScrollRight.SetActive(false);
            this.m_ScrollBottomRight.SetActive(false);
            base.m_topRight = this.m_originalTopRight;
            base.m_right = this.m_originalRight;
            base.m_bottomRight = this.m_originalBottomRight;
        }
        base.m_topRight.SetActive(true);
        base.m_right.SetActive(true);
        base.m_bottomRight.SetActive(true);
    }
}


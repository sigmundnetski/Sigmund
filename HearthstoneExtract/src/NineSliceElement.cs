using System;
using UnityEngine;

public class NineSliceElement : MonoBehaviour
{
    public GameObject m_bottom;
    public GameObject m_bottomLeft;
    public GameObject m_bottomRight;
    protected Vector2 m_cornerSize;
    protected Vector2 m_initialMiddleSize;
    protected Vector2 m_initialSize;
    public GameObject m_left;
    public GameObject m_middle;
    public GameObject m_right;
    protected Vector2 m_size;
    public GameObject m_sizeQuad;
    public GameObject m_top;
    public GameObject m_topLeft;
    public GameObject m_topRight;

    protected virtual void Awake()
    {
        Vector3 size = this.m_sizeQuad.GetComponent<MeshFilter>().mesh.bounds.size;
        this.m_initialSize = new Vector2(size.x, size.z);
        Vector3 vector2 = this.m_middle.GetComponent<MeshFilter>().mesh.bounds.size;
        this.m_initialMiddleSize = new Vector2(vector2.x, vector2.z);
        Vector3 vector3 = this.m_topLeft.GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 vector4 = this.m_topRight.GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 vector5 = this.m_bottomLeft.GetComponent<MeshFilter>().mesh.bounds.size;
        this.m_cornerSize = new Vector2(vector3.x + vector4.x, vector3.z + vector5.z);
        this.m_size = this.m_initialSize;
    }

    public float GetHeight()
    {
        return this.m_size.y;
    }

    public float GetInitialHeight()
    {
        return this.m_initialSize.y;
    }

    public Vector2 GetInitialSize()
    {
        return this.m_initialSize;
    }

    public float GetInitialWidth()
    {
        return this.m_initialSize.x;
    }

    public Vector2 GetSize()
    {
        return this.m_size;
    }

    public float GetWidth()
    {
        return this.m_size.x;
    }

    public void SetHeight(float height)
    {
        this.SetSize(this.m_size.x, height);
    }

    public void SetSize(Vector2 size)
    {
        this.SetSize(size.x, size.y);
    }

    public virtual void SetSize(float width, float height)
    {
        this.m_size.x = width;
        this.m_size.y = height;
        Vector2 v = new Vector2(this.m_size.x / this.m_initialSize.x, this.m_size.y / this.m_initialSize.y);
        Vector2 vector2 = new Vector2(width - this.m_cornerSize.x, height - this.m_cornerSize.y);
        Vector2 vector3 = new Vector2(vector2.x / this.m_initialMiddleSize.x, vector2.y / this.m_initialMiddleSize.y);
        TransformUtil.SetLocalScaleXZ(this.m_sizeQuad, v);
        TransformUtil.SetLocalScaleX(this.m_top, vector3.x);
        TransformUtil.SetLocalScaleX(this.m_bottom, vector3.x);
        TransformUtil.SetLocalScaleZ(this.m_left, vector3.y);
        TransformUtil.SetLocalScaleXZ(this.m_middle, vector3);
        TransformUtil.SetLocalScaleZ(this.m_right, vector3.y);
        TransformUtil.SetPoint(this.m_topLeft, Anchor.TOP_LEFT, this.m_sizeQuad, Anchor.TOP_LEFT);
        TransformUtil.SetPoint(this.m_top, Anchor.LEFT, this.m_topLeft, Anchor.RIGHT);
        TransformUtil.SetPoint(this.m_topRight, Anchor.LEFT, this.m_top, Anchor.RIGHT);
        TransformUtil.SetPoint(this.m_left, Anchor.TOP_LEFT, this.m_topLeft, Anchor.BOTTOM_LEFT);
        TransformUtil.SetPoint(this.m_middle, Anchor.LEFT, this.m_left, Anchor.RIGHT);
        TransformUtil.SetPoint(this.m_right, Anchor.LEFT, this.m_middle, Anchor.RIGHT);
        TransformUtil.SetPoint(this.m_bottomLeft, Anchor.TOP_LEFT, this.m_left, Anchor.BOTTOM_LEFT);
        TransformUtil.SetPoint(this.m_bottom, Anchor.LEFT, this.m_bottomLeft, Anchor.RIGHT);
        TransformUtil.SetPoint(this.m_bottomRight, Anchor.LEFT, this.m_bottom, Anchor.RIGHT);
    }

    public void SetWidth(float width)
    {
        this.SetSize(width, this.m_size.y);
    }
}


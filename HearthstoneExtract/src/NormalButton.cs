using System;
using UnityEngine;

public class NormalButton : PegUIElement
{
    private int buttonID;
    public GameObject m_button;
    public TextMesh m_buttonText;
    public UberText m_buttonUberText;
    public GameObject m_mouseOverBone;
    private Vector3 m_originalButtonPosition;
    private float m_userOverYOffset = -0.05f;

    protected override void Awake()
    {
        this.SetOriginalButtonPosition();
    }

    public float GetBottom()
    {
        Bounds bounds = base.GetComponent<BoxCollider>().bounds;
        return (bounds.center.y - bounds.extents.y);
    }

    public int GetButtonID()
    {
        return this.buttonID;
    }

    public GameObject GetButtonTextGO()
    {
        if (this.m_buttonUberText == null)
        {
            return this.m_buttonText.gameObject;
        }
        return this.m_buttonUberText.gameObject;
    }

    public float GetLeft()
    {
        Bounds bounds = base.GetComponent<BoxCollider>().bounds;
        return (bounds.center.x - bounds.extents.x);
    }

    public float GetRight()
    {
        return base.GetComponent<BoxCollider>().bounds.max.x;
    }

    public float GetTextHeight()
    {
        if (this.m_buttonUberText == null)
        {
            return (this.m_buttonText.renderer.bounds.extents.y * 2f);
        }
        return this.m_buttonUberText.Height;
    }

    public float GetTextWidth()
    {
        if (this.m_buttonUberText == null)
        {
            return (this.m_buttonText.renderer.bounds.extents.x * 2f);
        }
        return this.m_buttonUberText.Width;
    }

    public float GetTop()
    {
        Bounds bounds = base.GetComponent<BoxCollider>().bounds;
        return (bounds.center.y + bounds.extents.y);
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        this.m_button.gameObject.transform.localPosition = this.m_originalButtonPosition;
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        if (this.m_mouseOverBone != null)
        {
            this.m_button.transform.position = this.m_mouseOverBone.transform.position;
        }
        else
        {
            TransformUtil.SetLocalPosY(this.m_button.gameObject, this.m_originalButtonPosition.y + this.m_userOverYOffset);
        }
    }

    public void SetButtonID(int newID)
    {
        this.buttonID = newID;
    }

    public void SetOriginalButtonPosition()
    {
        this.m_originalButtonPosition = this.m_button.transform.localPosition;
    }

    public void SetText(string t)
    {
        if (this.m_buttonUberText == null)
        {
            this.m_buttonText.text = t;
            TextUtils.HackAssignOutlineText(this.m_buttonText, t);
        }
        else
        {
            this.m_buttonUberText.Text = t;
        }
    }

    public void SetUserOverYOffset(float userOverYOffset)
    {
        this.m_userOverYOffset = userOverYOffset;
    }
}


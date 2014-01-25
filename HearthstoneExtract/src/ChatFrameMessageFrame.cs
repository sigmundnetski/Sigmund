using System;
using UnityEngine;

public class ChatFrameMessageFrame : MonoBehaviour
{
    public GameObject m_Background;
    private float m_initialBackgroundHeight;
    private float m_initialBackgroundLocalScaleZ;
    private float m_initialVerticalTextPadding;
    public UberText m_Text;

    private void Awake()
    {
        base.transform.parent = ChatMgr.Get().GetChatFrame().m_MessagesParent.transform;
        TransformUtil.Identity(base.transform);
        Bounds bounds = this.m_Background.collider.bounds;
        Bounds textWorldSpaceBounds = this.m_Text.GetTextWorldSpaceBounds();
        this.m_initialVerticalTextPadding = bounds.size.y - textWorldSpaceBounds.size.y;
        this.m_initialBackgroundHeight = bounds.size.y;
        this.m_initialBackgroundLocalScaleZ = this.m_Background.transform.localScale.z;
    }

    public Color GetColor()
    {
        return this.m_Text.TextColor;
    }

    public string GetMessage()
    {
        return this.m_Text.Text;
    }

    public void SetColor(Color color)
    {
        this.m_Text.TextColor = color;
    }

    public void SetMessage(string message)
    {
        this.m_Text.Text = message;
        this.UpdateText();
        this.UpdateBackground();
    }

    private void UpdateBackground()
    {
        float num = this.m_Text.GetTextWorldSpaceBounds().size.y + this.m_initialVerticalTextPadding;
        float initialBackgroundLocalScaleZ = this.m_initialBackgroundLocalScaleZ;
        if (num > this.m_initialBackgroundHeight)
        {
            initialBackgroundLocalScaleZ *= num / this.m_initialBackgroundHeight;
        }
        TransformUtil.SetLocalScaleZ(this.m_Background, initialBackgroundLocalScaleZ);
    }

    private void UpdateText()
    {
        this.m_Text.UpdateNow();
    }
}


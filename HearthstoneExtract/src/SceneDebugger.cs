using System;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class SceneDebugger : MonoBehaviour
{
    public float m_DefaultTimeScale = 1f;
    public Vector2 m_GUIPosition = new Vector2(0.01f, 0.065f);
    public Vector2 m_GUISize = new Vector2(175f, 30f);
    private bool m_hideMessages;
    public float m_MaxTimeScale = 4f;
    private StringBuilder m_messageBuilder;
    private QueueList<string> m_messages;
    private GUIStyle m_messageStyle;
    public float m_MinTimeScale = 0.01f;
    private const int MAX_MESSAGES = 60;
    private static SceneDebugger s_instance;

    public void AddMessage(string message)
    {
        if (this.AreMessagesAllowed())
        {
            this.InitMessagesIfNecessary();
            if (this.m_messages.Count >= 60)
            {
                this.m_messages.Dequeue();
            }
            this.m_messages.Enqueue(message);
        }
    }

    private bool AreMessagesAllowed()
    {
        if (!ApplicationMgr.IsInternal())
        {
            return false;
        }
        return true;
    }

    private void Awake()
    {
        s_instance = this;
    }

    public static SceneDebugger Get()
    {
        return s_instance;
    }

    private string GetMessageText()
    {
        this.m_messageBuilder = new StringBuilder();
        for (int i = 0; i < this.m_messages.Count; i++)
        {
            this.m_messageBuilder.AppendLine(this.m_messages[i]);
        }
        return this.m_messageBuilder.ToString();
    }

    private void InitMessagesIfNecessary()
    {
        if (this.m_messages == null)
        {
            this.m_messages = new QueueList<string>();
        }
    }

    private void InitMessageStyleIfNecessary()
    {
        if (this.m_messageStyle == null)
        {
            GUIStyle style = new GUIStyle("box") {
                alignment = TextAnchor.UpperLeft,
                wordWrap = true,
                clipping = TextClipping.Overflow,
                stretchWidth = true
            };
            this.m_messageStyle = style;
        }
    }

    [Conditional("UNITY_EDITOR")]
    private void LayoutCursorControls(ref Vector2 offset, Vector2 size)
    {
        if (Screen.showCursor)
        {
            if (GUI.Button(new Rect(offset.x, offset.y, size.x, size.y), "Force Hardware Cursor Off"))
            {
                Screen.showCursor = false;
            }
        }
        else if (GUI.Button(new Rect(offset.x, offset.y, size.x, size.y), "Force Hardware Cursor On"))
        {
            Screen.showCursor = true;
        }
        offset.y += 1.5f * size.y;
    }

    private void LayoutLeftScreenControls()
    {
        Vector2 gUISize = this.m_GUISize;
        Vector2 vector2 = new Vector2(Screen.width * this.m_GUIPosition.x, Screen.height * this.m_GUIPosition.y);
        Vector2 vector3 = new Vector2(vector2.x, vector2.y);
        Vector2 offset = new Vector2();
        offset = vector3;
        this.LayoutTimeControls(ref offset, gUISize);
        this.LayoutQualityControls(ref offset, gUISize);
        this.LayoutMessages(ref offset, gUISize);
    }

    private void LayoutMessages(ref Vector2 offset, Vector2 size)
    {
        if ((this.m_messages != null) && (this.m_messages.Count != 0))
        {
            this.InitMessageStyleIfNecessary();
            if (this.m_hideMessages)
            {
                if (!GUI.Button(new Rect(offset.x, offset.y, size.x, size.y), "Show Messages"))
                {
                    return;
                }
                this.m_hideMessages = false;
            }
            else if (GUI.Button(new Rect(offset.x, offset.y, size.x, size.y), "Hide Messages"))
            {
                this.m_hideMessages = true;
                return;
            }
            if (GUI.Button(new Rect(size.x + offset.x, offset.y, size.x, size.y), "Clear Messages"))
            {
                this.m_messages.Clear();
            }
            else
            {
                offset.y += size.y;
                string messageText = this.GetMessageText();
                float height = Screen.height - offset.y;
                GUI.Box(new Rect(offset.x, offset.y, (float) Screen.width, height), messageText, this.m_messageStyle);
                offset.y += height;
            }
        }
    }

    private void LayoutQualityControls(ref Vector2 offset, Vector2 size)
    {
        if (ApplicationMgr.IsInternal())
        {
            float width = size.x / 3f;
            if (GUI.Button(new Rect(offset.x, offset.y, width, size.y), "Low"))
            {
                GraphicsManager.Get().RenderQualityLevel = GraphicsQuality.Low;
            }
            if (GUI.Button(new Rect(offset.x + width, offset.y, width, size.y), "Medium"))
            {
                GraphicsManager.Get().RenderQualityLevel = GraphicsQuality.Medium;
            }
            if (GUI.Button(new Rect(offset.x + (width * 2f), offset.y, width, size.y), "High"))
            {
                GraphicsManager.Get().RenderQualityLevel = GraphicsQuality.High;
            }
            offset.y += 1.5f * size.y;
        }
    }

    private void LayoutTimeControls(ref Vector2 offset, Vector2 size)
    {
        if (ApplicationMgr.IsInternal())
        {
            GUI.Box(new Rect(offset.x, offset.y, size.x, size.y), string.Format("Time Scale: {0}", UnityEngine.Time.timeScale));
            offset.y += 1f * size.y;
            UnityEngine.Time.timeScale = GUI.HorizontalSlider(new Rect(offset.x, offset.y, size.x, size.y), UnityEngine.Time.timeScale, this.m_MinTimeScale, this.m_MaxTimeScale);
            offset.y += 1f * size.y;
            if (GUI.Button(new Rect(offset.x, offset.y, size.x, size.y), "Reset Time Scale"))
            {
                UnityEngine.Time.timeScale = 1f;
            }
            offset.y += 1.5f * size.y;
        }
    }

    private void OnGUI()
    {
        if (Options.Get().GetBool(Option.HUD))
        {
            this.LayoutLeftScreenControls();
        }
    }
}


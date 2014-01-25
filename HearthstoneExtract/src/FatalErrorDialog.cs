using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class FatalErrorDialog : MonoBehaviour
{
    private const float ButtonHeight = 31f;
    private const float ButtonWidth = 100f;
    private const float DialogHeight = 347f;
    private const float DialogPadding = 20f;
    private const float DialogWidth = 600f;
    private GUIStyle m_dialogStyle;
    private string m_text;

    private void Awake()
    {
        this.BuildText();
        FatalErrorMgr.Get().AddMessageListener(new FatalErrorMgr.MessageCallback(this.OnFatalErrorMessage));
    }

    private void BuildText()
    {
        List<FatalErrorMessage> messages = FatalErrorMgr.Get().GetMessages();
        if (messages.Count == 0)
        {
            this.m_text = string.Empty;
        }
        else
        {
            List<string> list2 = new List<string>();
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < messages.Count; i++)
            {
                List<string> list3;
                FatalErrorMessage message = messages[i];
                string header = message.m_header;
                string body = message.m_body;
                if (!dictionary.TryGetValue(header, out list3))
                {
                    list2.Add(header);
                    list3 = new List<string> {
                        body
                    };
                    dictionary.Add(header, list3);
                }
                else if (!list3.Contains(body))
                {
                    list3.Add(body);
                }
            }
            StringBuilder builder = new StringBuilder();
            for (int j = 0; j < list2.Count; j++)
            {
                string str3 = list2[j];
                builder.Append(str3);
                builder.Append("\n\n");
                List<string> list4 = dictionary[str3];
                for (int k = 0; k < list4.Count; k++)
                {
                    string str4 = list4[k];
                    builder.Append(str4);
                    builder.Append("\n");
                }
                builder.Append("\n");
            }
            builder.Remove(builder.Length - 2, 2);
            this.m_text = builder.ToString();
        }
    }

    private void InitGUIStyles()
    {
        if (this.m_dialogStyle == null)
        {
            Log.Mike.Print("FatalErrorDialog.InitGUIStyles()");
            GUIStyle style = new GUIStyle("box") {
                clipping = TextClipping.Overflow,
                stretchHeight = true,
                stretchWidth = true,
                wordWrap = true,
                fontSize = 0x10
            };
            this.m_dialogStyle = style;
        }
    }

    private void OnFatalErrorMessage(FatalErrorMessage message, object userData)
    {
        this.BuildText();
    }

    private void OnGUI()
    {
        this.InitGUIStyles();
        GUI.Box(this.DialogRect, string.Empty, this.m_dialogStyle);
        GUI.Box(this.DialogRect, this.m_text, this.m_dialogStyle);
        if (GUI.Button(this.ButtonRect, GameStrings.Get("GLOBAL_EXIT")))
        {
            Log.Mike.Print("FatalErrorDialog.OnGUI() - calling FatalErrorMgr.Get().NotifyExitPressed()");
            FatalErrorMgr.Get().NotifyExitPressed();
            Log.Mike.Print("FatalErrorDialog.OnGUI() - called FatalErrorMgr.Get().NotifyExitPressed()");
        }
    }

    private float ButtonLeft
    {
        get
        {
            return ((Screen.width - 100f) / 2f);
        }
    }

    private Rect ButtonRect
    {
        get
        {
            return new Rect(this.ButtonLeft, this.ButtonTop, 100f, 31f);
        }
    }

    private float ButtonTop
    {
        get
        {
            return (((this.DialogTop + 347f) - 20f) - 31f);
        }
    }

    private float DialogLeft
    {
        get
        {
            return ((Screen.width - 600f) / 2f);
        }
    }

    private Rect DialogRect
    {
        get
        {
            return new Rect(this.DialogLeft, this.DialogTop, 600f, 347f);
        }
    }

    private float DialogTop
    {
        get
        {
            return ((Screen.height - 347f) / 2f);
        }
    }
}


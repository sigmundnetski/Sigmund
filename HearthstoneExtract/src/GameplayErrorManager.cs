using System;
using UnityEngine;

public class GameplayErrorManager : MonoBehaviour
{
    private float m_displaySecsLeft;
    private GUIStyle m_errorDisplayStyle;
    public GameplayErrorCloud m_errorMessagePrefab;
    private string m_message;
    private static GameplayErrorManager s_instance;
    private static GameplayErrorCloud s_messageInstance;

    private void Awake()
    {
        s_instance = this;
        s_messageInstance = (GameplayErrorCloud) UnityEngine.Object.Instantiate(this.m_errorMessagePrefab);
    }

    public void DisplayMessage(string message)
    {
        this.m_message = message;
        this.m_displaySecsLeft = message.Length * 0.1f;
        s_messageInstance.transform.localPosition = new Vector3(-7.9f, 9.98f, -5.17f);
        s_messageInstance.ShowMessage(this.m_message, this.m_displaySecsLeft);
        SoundManager.Get().LoadAndPlay("QuestLog");
    }

    public static GameplayErrorManager Get()
    {
        return s_instance;
    }

    private void Start()
    {
        this.m_message = string.Empty;
        this.m_errorDisplayStyle = new GUIStyle();
        this.m_errorDisplayStyle.fontSize = 0x18;
        this.m_errorDisplayStyle.fontStyle = FontStyle.Bold;
        this.m_errorDisplayStyle.alignment = TextAnchor.UpperCenter;
    }
}


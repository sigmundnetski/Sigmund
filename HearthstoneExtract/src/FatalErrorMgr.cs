using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class FatalErrorMgr
{
    private List<MessageListener> m_messageListeners = new List<MessageListener>();
    private List<FatalErrorMessage> m_messages = new List<FatalErrorMessage>();
    private string m_text;
    private static FatalErrorMgr s_instance;

    public void Add(FatalErrorMessage message)
    {
        if (LoadingScreen.Get() != null)
        {
            LoadingScreen.Get().EnableTransition(false);
        }
        SceneMgr.Get().SetNextMode(SceneMgr.Mode.FATAL_ERROR);
        this.m_messages.Add(message);
        this.FireMessageListeners(message);
    }

    public bool AddMessageListener(MessageCallback callback)
    {
        return this.AddMessageListener(callback, null);
    }

    public bool AddMessageListener(MessageCallback callback, object userData)
    {
        MessageListener item = new MessageListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_messageListeners.Contains(item))
        {
            return false;
        }
        this.m_messageListeners.Add(item);
        return true;
    }

    public bool AddUnique(FatalErrorMessage message)
    {
        if (!string.IsNullOrEmpty(message.m_id))
        {
            foreach (FatalErrorMessage message2 in this.m_messages)
            {
                if (message2.m_id == message.m_id)
                {
                    return false;
                }
            }
        }
        this.Add(message);
        return true;
    }

    protected void FireMessageListeners(FatalErrorMessage message)
    {
        MessageListener[] listenerArray = this.m_messageListeners.ToArray();
        for (int i = 0; i < listenerArray.Length; i++)
        {
            listenerArray[i].Fire(message);
        }
    }

    public static FatalErrorMgr Get()
    {
        if (s_instance == null)
        {
            s_instance = new FatalErrorMgr();
        }
        return s_instance;
    }

    public List<FatalErrorMessage> GetMessages()
    {
        return this.m_messages;
    }

    public bool HasError()
    {
        return (this.m_messages.Count > 0);
    }

    public void NotifyExitPressed()
    {
        Log.Mike.Print("FatalErrorDialog.NotifyExitPressed() - BEGIN");
        this.SendAcknowledgements();
        Log.Mike.Print("FatalErrorDialog.NotifyExitPressed() - calling ApplicationMgr.Get().Exit()");
        ApplicationMgr.Get().Exit();
        Log.Mike.Print("FatalErrorDialog.NotifyExitPressed() - END");
    }

    public bool RemoveMessageListener(MessageCallback callback)
    {
        return this.RemoveMessageListener(callback, null);
    }

    public bool RemoveMessageListener(MessageCallback callback, object userData)
    {
        MessageListener item = new MessageListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_messageListeners.Remove(item);
    }

    private void SendAcknowledgements()
    {
        foreach (FatalErrorMessage message in this.m_messages.ToArray())
        {
            if (message.m_ackCallback != null)
            {
                message.m_ackCallback(message.m_ackUserData);
            }
        }
    }

    public delegate void MessageCallback(FatalErrorMessage message, object userData);

    protected class MessageListener : EventListener<FatalErrorMgr.MessageCallback>
    {
        public void Fire(FatalErrorMessage message)
        {
            base.m_callback(message, base.m_userData);
        }
    }
}


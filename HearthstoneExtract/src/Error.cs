using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class Error
{
    public static void AddDevFatal(string header, string message, params object[] messageArgs)
    {
        string str = string.Format(message, messageArgs);
        if (!ApplicationMgr.IsInternal())
        {
            Debug.LogError(string.Format("Error.AddDevFatal() - header={0} message={1}", header, str));
        }
        else
        {
            ErrorParams parms = new ErrorParams {
                m_header = header,
                m_message = str
            };
            AddFatal(parms);
        }
    }

    public static void AddDevWarning(string header, string message, params object[] messageArgs)
    {
        string str = string.Format(message, messageArgs);
        if (!ApplicationMgr.IsInternal())
        {
            Debug.LogWarning(string.Format("Error.AddDevWarning() - header={0} message={1}", header, str));
        }
        else
        {
            ErrorParams parms = new ErrorParams {
                m_header = header,
                m_message = str
            };
            AddWarning(parms);
        }
    }

    public static void AddFatal(ErrorParams parms)
    {
        Debug.LogError(string.Format("Error.AddFatal() - header={0} message={1}", parms.m_header, parms.m_message));
        parms.m_type = ErrorType.FATAL;
        FatalErrorMessage message = new FatalErrorMessage {
            m_id = parms.m_header + parms.m_message,
            m_header = parms.m_header,
            m_body = parms.m_message,
            m_ackCallback = parms.m_ackCallback,
            m_ackUserData = parms.m_ackUserData
        };
        FatalErrorMgr.Get().Add(message);
    }

    public static void AddFatal(string header, string message)
    {
        ErrorParams parms = new ErrorParams {
            m_header = header,
            m_message = message
        };
        AddFatal(parms);
    }

    public static void AddFatalLoc(string headerKey, string messageKey, params object[] messageArgs)
    {
        ErrorParams parms = new ErrorParams {
            m_header = GameStrings.Get(headerKey),
            m_message = GameStrings.Format(messageKey, messageArgs)
        };
        AddFatal(parms);
    }

    public static void AddWarning(ErrorParams parms)
    {
        if (DialogManager.Get() == null)
        {
            AddFatal(parms);
        }
        else
        {
            Debug.LogWarning(string.Format("Error.AddWarning() - header={0} message={1}", parms.m_header, parms.m_message));
            parms.m_type = ErrorType.WARNING;
            AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
                m_id = parms.m_header + parms.m_message,
                m_headerText = parms.m_header,
                m_text = parms.m_message,
                m_responseCallback = new AlertPopup.ResponseCallback(Error.OnPopupResponse),
                m_responseUserData = parms,
                m_showAlertIcon = true
            };
            DialogManager.Get().ShowPopup(info);
        }
    }

    public static void AddWarning(string header, string message, params object[] messageArgs)
    {
        ErrorParams parms = new ErrorParams {
            m_header = header,
            m_message = string.Format(message, messageArgs)
        };
        AddWarning(parms);
    }

    public static void AddWarningLoc(string headerKey, string messageKey, params object[] messageArgs)
    {
        ErrorParams parms = new ErrorParams {
            m_header = GameStrings.Get(headerKey),
            m_message = string.Format(GameStrings.Get(messageKey), messageArgs)
        };
        AddWarning(parms);
    }

    private static void OnPopupResponse(AlertPopup.Response response, object userData)
    {
        ErrorParams params = (ErrorParams) userData;
        if (params.m_ackCallback != null)
        {
            params.m_ackCallback(params.m_ackUserData);
        }
    }

    public delegate void AcknowledgeCallback(object userData);
}


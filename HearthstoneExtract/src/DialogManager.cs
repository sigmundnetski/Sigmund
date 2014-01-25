using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private DialogBase m_currentDialog;
    private Queue<DialogRequest> m_dialogRequests = new Queue<DialogRequest>();
    private int m_pendingAssetLoads;
    private bool m_suppressed;
    private static DialogManager s_instance;

    public void AddToQueue(DialogRequest request)
    {
        if (!this.IsSuppressed())
        {
            this.m_dialogRequests.Enqueue(request);
            this.UpdateQueue();
        }
    }

    private void Awake()
    {
        s_instance = this;
        if (SceneMgr.Get() != null)
        {
            this.m_suppressed = SceneMgr.Get().IsModeRequested(SceneMgr.Mode.FATAL_ERROR);
        }
    }

    private void DestroyPopupAssetsIfPossible()
    {
        if (this.m_pendingAssetLoads <= 0)
        {
            AssetCache.ClearGameObject("MedalPopup");
            AssetCache.ClearGameObject("AlertPopup");
        }
    }

    public static DialogManager Get()
    {
        return s_instance;
    }

    public bool IsSuppressed()
    {
        return this.m_suppressed;
    }

    private void LoadAlertPopup()
    {
        this.m_pendingAssetLoads++;
        AssetLoader.Get().LoadGameObject("AlertPopup", new AssetLoader.GameObjectCallback(this.OnPopupLoaded), null, true, null);
    }

    private void LoadMedalPopup()
    {
        this.m_pendingAssetLoads++;
        AssetLoader.Get().LoadGameObject("MedalPopup", new AssetLoader.GameObjectCallback(this.OnPopupLoaded), null, true, null);
    }

    private void LoadPopupFromRequest(DialogRequest request)
    {
        if (request.m_type == typeof(AlertPopup))
        {
            this.LoadAlertPopup();
        }
        else if (request.m_type == typeof(MedalPopup))
        {
            this.LoadMedalPopup();
        }
        else
        {
            Debug.LogError(string.Format("DialogManager.LoadPopup() - unhandled dialog type {0}", request.m_type));
        }
    }

    private void OnCurrentDialogHidden(DialogBase dialog, object userData)
    {
        if (dialog == this.m_currentDialog)
        {
            UnityEngine.Object.Destroy(this.m_currentDialog.gameObject);
            this.m_currentDialog = null;
            this.UpdateQueue();
        }
    }

    private void OnPopupLoaded(string name, GameObject go, object callbackData)
    {
        this.m_pendingAssetLoads--;
        if (this.IsSuppressed())
        {
            UnityEngine.Object.DestroyImmediate(go);
            this.DestroyPopupAssetsIfPossible();
        }
        else
        {
            DialogRequest request = this.m_dialogRequests.Dequeue();
            DialogBase component = go.GetComponent<DialogBase>();
            if (component == null)
            {
                Debug.LogError(string.Format("DialogManager.OnPopupLoaded() - game object {0} has no {1} component", go, request.m_type));
                this.UpdateQueue();
            }
            else
            {
                go.transform.parent = BaseUI.Get().transform;
                this.ProcessRequest(request, component);
            }
        }
    }

    private void ProcessAlertRequest(DialogRequest request, AlertPopup alertPopup)
    {
        AlertPopup.PopupInfo info = (AlertPopup.PopupInfo) request.m_info;
        alertPopup.SetInfo(info);
        alertPopup.Show();
    }

    private void ProcessMedalRequest(DialogRequest request, MedalPopup medalPopup)
    {
        NetCache.ProfileNoticeMedal info = (NetCache.ProfileNoticeMedal) request.m_info;
        medalPopup.SetNoticeID(info.NoticeID);
        medalPopup.SetMedalRank(info.Medal);
        medalPopup.Show();
    }

    private void ProcessRequest(DialogRequest request, DialogBase dialog)
    {
        if ((request.m_callback != null) && !request.m_callback(dialog, request.m_userData))
        {
            this.UpdateQueue();
        }
        else
        {
            this.m_currentDialog = dialog;
            this.m_currentDialog.AddHideListener(new DialogBase.HideCallback(this.OnCurrentDialogHidden));
            if (request.m_type == typeof(AlertPopup))
            {
                this.ProcessAlertRequest(request, (AlertPopup) dialog);
            }
            else if (request.m_type == typeof(MedalPopup))
            {
                this.ProcessMedalRequest(request, (MedalPopup) dialog);
            }
        }
    }

    public void ShowMessageOfTheDay(string message)
    {
        AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
            m_text = message
        };
        this.ShowPopup(info);
    }

    public void ShowPopup(AlertPopup.PopupInfo info)
    {
        this.ShowPopup(info, null, null);
    }

    public void ShowPopup(AlertPopup.PopupInfo info, DialogProcessCallback callback)
    {
        this.ShowPopup(info, callback, null);
    }

    public void ShowPopup(AlertPopup.PopupInfo info, DialogProcessCallback callback, object userData)
    {
        if (!this.IsSuppressed())
        {
            DialogRequest request = new DialogRequest {
                m_type = typeof(AlertPopup),
                m_info = info,
                m_callback = callback,
                m_userData = userData
            };
            this.AddToQueue(request);
        }
    }

    public void ShowProfileNotices(List<NetCache.ProfileNotice> profileNotices)
    {
        if (!this.IsSuppressed())
        {
            foreach (NetCache.ProfileNotice notice in profileNotices)
            {
                if (notice.Type == NetCache.ProfileNotice.NoticeType.GAINED_MEDAL)
                {
                    DialogRequest request = new DialogRequest {
                        m_type = typeof(MedalPopup),
                        m_info = notice
                    };
                    this.AddToQueue(request);
                    break;
                }
            }
        }
    }

    public bool ShowUniquePopup(AlertPopup.PopupInfo info)
    {
        return this.ShowUniquePopup(info, null, null);
    }

    public bool ShowUniquePopup(AlertPopup.PopupInfo info, DialogProcessCallback callback)
    {
        return this.ShowUniquePopup(info, callback, null);
    }

    public bool ShowUniquePopup(AlertPopup.PopupInfo info, DialogProcessCallback callback, object userData)
    {
        if (!string.IsNullOrEmpty(info.m_id))
        {
            foreach (DialogRequest request in this.m_dialogRequests)
            {
                if (request.m_type == typeof(AlertPopup))
                {
                    AlertPopup.PopupInfo info2 = (AlertPopup.PopupInfo) request.m_info;
                    if (info2.m_id == info.m_id)
                    {
                        return false;
                    }
                }
            }
        }
        this.ShowPopup(info, callback, userData);
        return true;
    }

    public void Suppress(bool enable)
    {
        if (this.m_suppressed != enable)
        {
            this.m_suppressed = enable;
            if (enable)
            {
                if (this.m_currentDialog != null)
                {
                    UnityEngine.Object.DestroyImmediate(this.m_currentDialog.gameObject);
                    this.m_currentDialog = null;
                }
                this.m_dialogRequests.Clear();
                this.DestroyPopupAssetsIfPossible();
            }
        }
    }

    public void UpdateQueue()
    {
        if (!this.IsSuppressed() && (this.m_currentDialog == null))
        {
            if (this.m_dialogRequests.Count == 0)
            {
                this.DestroyPopupAssetsIfPossible();
            }
            else
            {
                DialogRequest request = this.m_dialogRequests.Peek();
                this.LoadPopupFromRequest(request);
            }
        }
    }

    public delegate bool DialogProcessCallback(DialogBase dialog, object userData);

    public class DialogRequest
    {
        public DialogManager.DialogProcessCallback m_callback;
        public object m_info;
        public System.Type m_type;
        public object m_userData;
    }
}


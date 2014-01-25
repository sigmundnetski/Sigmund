using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    public BnetBar m_BnetBar;
    public Camera m_BnetCamera;
    public Camera m_BnetDialogCamera;
    public BaseUIBones m_Bones;
    public BaseUIPrefabs m_Prefabs;
    private static BaseUI s_instance;

    private void Awake()
    {
        s_instance = this;
        ChatMgr mgr = (ChatMgr) UnityEngine.Object.Instantiate(this.m_Prefabs.m_ChatMgrPrefab);
        mgr.transform.parent = base.transform;
        this.m_BnetCamera.GetComponent<ScreenResizeDetector>().AddSizeChangedListener(new ScreenResizeDetector.SizeChangedCallback(this.OnScreenSizeChanged));
        Network.Get().AddBnetErrorListener(BnetFeature.Friends, new Network.BnetErrorCallback(this.OnBnetError));
    }

    public static BaseUI Get()
    {
        return s_instance;
    }

    public Transform GetAddFriendBone()
    {
        return this.m_Bones.m_AddFriend;
    }

    public Camera GetBnetCamera()
    {
        return this.m_BnetCamera;
    }

    public Camera GetBnetDialogCamera()
    {
        return this.m_BnetDialogCamera;
    }

    public Transform GetGameMenuBone()
    {
        return this.m_Bones.m_GameMenu;
    }

    public Transform GetOptionsMenuBone()
    {
        return this.m_Bones.m_OptionsMenu;
    }

    public Transform GetQuickChatBone()
    {
        return this.m_Bones.m_QuickChat;
    }

    public bool HandleKeyboardInput()
    {
        if ((this.m_BnetBar == null) || !this.m_BnetBar.HandleKeyboardInput())
        {
            if (!Input.GetKeyDown(KeyCode.Print) && !Input.GetKeyDown(KeyCode.F13))
            {
                return false;
            }
            string str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/";
            object[] objArray1 = new object[] { DateTime.Now.Month, ".", DateTime.Now.Day, ".", DateTime.Now.Year, ".", DateTime.Now.Hour.ToString("00"), ".", DateTime.Now.Minute.ToString("00"), ".", DateTime.Now.Second.ToString("00") };
            string str2 = string.Concat(objArray1);
            string str3 = "Hearthstone_Screenshot_" + str2 + ".png";
            for (int i = 1; System.IO.File.Exists(str + str3); i++)
            {
                object[] objArray2 = new object[] { "Hearthstone_Screenshot_", str2, "_", i, ".png" };
                str3 = string.Concat(objArray2);
            }
            UIStatus.Get().HideIfScreenshotMessage();
            Application.CaptureScreenshot(str + str3);
            base.StartCoroutine(this.NotifyOfScreenshotComplete());
            UnityEngine.Debug.Log("Screenshot! " + str + str3);
        }
        return true;
    }

    [DebuggerHidden]
    private IEnumerator NotifyOfScreenshotComplete()
    {
        return new <NotifyOfScreenshotComplete>c__Iterator108();
    }

    private bool OnBnetError(BnetErrorInfo info, object userData)
    {
        BnetFeature feature = info.GetFeature();
        BnetFeatureEvent featureEvent = info.GetFeatureEvent();
        if ((feature == BnetFeature.Friends) && (featureEvent == BnetFeatureEvent.Friends_OnSendInvitation))
        {
            string str;
            switch (info.GetError())
            {
                case BnetError.OK:
                    str = GameStrings.Get("GLOBAL_ADDFRIEND_SENT_CONFIRMATION");
                    UIStatus.Get().AddInfo(str);
                    return true;

                case BnetError.FRIENDS_FRIENDSHIP_ALREADY_EXISTS:
                    str = GameStrings.Get("GLOBAL_ADDFRIEND_ERROR_ALREADY_FRIEND");
                    UIStatus.Get().AddError(str);
                    return true;
            }
        }
        return false;
    }

    private void OnGUI()
    {
        if (Options.Get().GetBool(Option.HUD) && ApplicationMgr.IsInternal())
        {
            GUI.Label(new Rect(10f, Screen.height - 20f, 600f, 20f), Version.FullReport);
        }
    }

    public void OnLoggedIn()
    {
        this.m_BnetBar.OnLoggedIn();
    }

    private void OnScreenSizeChanged(object userData)
    {
        this.UpdateLayout();
    }

    private void Start()
    {
        this.UpdateLayout();
    }

    private void UpdateLayout()
    {
        this.m_BnetBar.UpdateLayout();
        if (FriendListFrame.Get() != null)
        {
            FriendListFrame.Get().UpdateLayout();
        }
        if (ChatMgr.Get() != null)
        {
            ChatMgr.Get().UpdateLayout();
        }
    }

    [CompilerGenerated]
    private sealed class <NotifyOfScreenshotComplete>c__Iterator108 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.$current = null;
                    this.$PC = 1;
                    return true;

                case 1:
                    UIStatus.Get().AddInfo(GameStrings.Get("GLOBAL_SCREENSHOT_COMPLETE"), true);
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }
}


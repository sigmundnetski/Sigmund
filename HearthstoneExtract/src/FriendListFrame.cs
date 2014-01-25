using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class FriendListFrame : MonoBehaviour
{
    public FriendListThreeSliceButton m_AddFriendButton;
    private AddFriendFrame m_addFriendFrame;
    public FriendListNineSliceFrame m_Background;
    public FriendListFrameBones m_Bones;
    private Vector3 m_cameraBottomScrollPos;
    private Vector3 m_cameraTopScrollPos;
    public FriendListUIElement m_CloseButton;
    public FriendListFrameConstants m_Constants;
    private List<FriendListCurrentGameFrame> m_currentGameFrames = new List<FriendListCurrentGameFrame>();
    private FriendListItemHeader m_currentGameHeader;
    public GameObject m_CurrentGamesBackground;
    private List<FriendListFriendFrame> m_friendFrames = new List<FriendListFriendFrame>();
    private FriendListItemHeader m_friendHeader;
    private float m_initialRequestsBackgroundHeight;
    public Camera m_ItemsCamera;
    public GameObject m_ItemsParent;
    private float m_maxListItemsHeight;
    private float m_minListItemsHeight;
    public FriendListGameIcon m_MyGameIcon;
    public UberText m_MyNameText;
    public UberText m_MyNumberText;
    public FriendListFrameOffsets m_Offsets;
    public FriendListFramePrefabs m_Prefabs;
    public FriendListThreeSliceButton m_RemoveFriendButton;
    private AlertPopup m_removeFriendPopup;
    private List<FriendListRequestFrame> m_requestFrames = new List<FriendListRequestFrame>();
    private FriendListItemHeader m_requestHeader;
    public GameObject m_RequestsBackground;
    private bool m_scrollActive;
    public PegUIElement m_ScrollBar;
    private bool m_scrollEnabled;
    public PegUIElement m_ScrollPlane;
    private float m_scrollPrevUnitPos;
    public GameObject m_ScrollThumb;
    private float m_scrollUnitPos;
    private FriendListUIElement m_selectedElement;
    private float m_testHeight;
    private bool m_useTestHeight;
    private static FriendListFrame s_instance;

    private void ApplyLayoutOffsets<T>(Component header, List<T> frames) where T: MonoBehaviour
    {
        float z = this.m_Bones.m_ItemsTop.position.z;
        Vector3 vector = new Vector3(header.transform.position.x, header.transform.position.y, z);
        header.transform.position = vector + this.m_Offsets.m_HeaderOffset;
        foreach (T local in frames)
        {
            Vector3 vector2 = new Vector3(local.transform.position.x, local.transform.position.y, z);
            local.transform.position = vector2 + this.m_Offsets.m_ItemOffset;
        }
    }

    [Conditional("FRIENDLIST_DEBUG")]
    private void AssignCurrentGameFrameNames()
    {
        for (int i = 0; i < this.m_currentGameFrames.Count; i++)
        {
            this.m_currentGameFrames[i].name = string.Format("CurrentGameFrame {0}", i);
        }
    }

    [Conditional("FRIENDLIST_DEBUG")]
    private void AssignFriendFrameNames()
    {
        for (int i = 0; i < this.m_friendFrames.Count; i++)
        {
            this.m_friendFrames[i].name = string.Format("FriendFrame {0}", i);
        }
    }

    [Conditional("FRIENDLIST_DEBUG")]
    private void AssignRequestFrameNames()
    {
        for (int i = 0; i < this.m_requestFrames.Count; i++)
        {
            this.m_requestFrames[i].name = string.Format("RequestFrame {0}", i);
        }
    }

    private void Awake()
    {
        s_instance = this;
        CheatMgr.Get().RegisterCheatHandler("friendlistheight", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_friendlistheight));
        this.InitButtons();
        this.InitHeaders();
        this.InitItemBackgrounds();
        this.InitScrolling();
        this.m_testHeight = this.m_maxListItemsHeight;
        this.RegisterFriendEvents();
        this.RegisterUIEvents();
        SceneMgr.Get().RegisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
    }

    private void Close()
    {
        this.CloseAddFriendFrame();
        UnityEngine.Object.Destroy(base.gameObject);
    }

    private void CloseAddFriendFrame()
    {
        if (this.m_addFriendFrame != null)
        {
            this.m_addFriendFrame.Close();
            this.m_addFriendFrame = null;
        }
    }

    private void CountOnlineFriends(out int onlineCount, out int totalCount)
    {
        onlineCount = 0;
        totalCount = 0;
        foreach (FriendListFriendFrame frame in this.m_friendFrames)
        {
            if (frame.GetFriend().IsOnline())
            {
                onlineCount++;
            }
            totalCount++;
        }
    }

    private void CreateCurrentGameFrame(BnetPlayer friend)
    {
        FriendListCurrentGameFrame item = (FriendListCurrentGameFrame) UnityEngine.Object.Instantiate(this.m_Prefabs.m_CurrentGameFrame);
        this.m_currentGameFrames.Add(item);
        item.transform.parent = this.m_ItemsParent.transform;
        TransformUtil.Identity(item.transform);
        item.SetFriend(friend);
        item.GetComponent<FriendListUIElement>().AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnBaseFriendFrameReleased));
    }

    private void CreateFriendFrame(BnetPlayer friend)
    {
        FriendListFriendFrame item = (FriendListFriendFrame) UnityEngine.Object.Instantiate(this.m_Prefabs.m_FriendFrame);
        this.m_friendFrames.Add(item);
        item.transform.parent = this.m_ItemsParent.transform;
        TransformUtil.Identity(item.transform);
        item.SetFriend(friend);
        item.GetComponent<FriendListUIElement>().AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnBaseFriendFrameReleased));
    }

    private FriendListItemHeader CreateHeader()
    {
        FriendListItemHeader header = (FriendListItemHeader) UnityEngine.Object.Instantiate(this.m_Prefabs.m_Header);
        header.transform.parent = this.m_ItemsParent.transform;
        TransformUtil.Identity(header.transform);
        return header;
    }

    private void CreateRequestFrame(BnetInvitation invite)
    {
        FriendListRequestFrame item = (FriendListRequestFrame) UnityEngine.Object.Instantiate(this.m_Prefabs.m_RequestFrame);
        this.m_requestFrames.Add(item);
        item.transform.parent = this.m_ItemsParent.transform;
        TransformUtil.Identity(item.transform);
        item.SetInvite(invite);
    }

    [Conditional("FRIENDLIST_DEBUG_LAYOUT")]
    private void DebugLayoutLog(string format, params object[] formatArgs)
    {
        UnityEngine.Debug.Log(string.Format(format, formatArgs));
    }

    private bool DestroyCurrentGameFrame(BnetPlayer friend)
    {
        int index = this.FindCurrentGameFrameIndex(friend);
        if (index < 0)
        {
            return false;
        }
        this.DestroyCurrentGameFrame(index);
        return true;
    }

    private void DestroyCurrentGameFrame(int index)
    {
        FriendListCurrentGameFrame frame = this.m_currentGameFrames[index];
        UnityEngine.Object.Destroy(frame.gameObject);
        this.m_currentGameFrames.RemoveAt(index);
    }

    private bool DestroyFriendFrame(BnetPlayer friend)
    {
        int index = this.FindFriendFrameIndex(friend);
        if (index < 0)
        {
            return false;
        }
        this.DestroyFriendFrame(index);
        return true;
    }

    private void DestroyFriendFrame(int index)
    {
        FriendListFriendFrame frame = this.m_friendFrames[index];
        UnityEngine.Object.Destroy(frame.gameObject);
        this.m_friendFrames.RemoveAt(index);
    }

    private bool DestroyRequestFrame(BnetInvitation invite)
    {
        int index = this.FindRequestFrameIndex(invite);
        if (index < 0)
        {
            return false;
        }
        this.DestroyRequestFrame(index);
        return true;
    }

    private void DestroyRequestFrame(int index)
    {
        FriendListRequestFrame frame = this.m_requestFrames[index];
        UnityEngine.Object.Destroy(frame.gameObject);
        this.m_requestFrames.RemoveAt(index);
    }

    private float DetermineScrolling()
    {
        float testHeight = this.PreComputeListItemsHeight();
        if (this.m_useTestHeight)
        {
            testHeight = this.m_testHeight;
        }
        this.m_scrollEnabled = testHeight > this.m_maxListItemsHeight;
        return testHeight;
    }

    private FriendListBaseFriendFrame FindBaseFriendFrame(BnetPlayer friend)
    {
        if (friend != null)
        {
            FriendListFriendFrame frame = this.FindFriendFrame(friend);
            if (frame != null)
            {
                return frame;
            }
            FriendListCurrentGameFrame frame2 = this.FindCurrentGameFrame(friend);
            if (frame2 != null)
            {
                return frame2;
            }
        }
        return null;
    }

    private FriendListCurrentGameFrame FindCurrentGameFrame(BnetPlayer friend)
    {
        <FindCurrentGameFrame>c__AnonStorey121 storey = new <FindCurrentGameFrame>c__AnonStorey121 {
            friend = friend
        };
        return this.m_currentGameFrames.Find(new Predicate<FriendListCurrentGameFrame>(storey.<>m__E));
    }

    private int FindCurrentGameFrameIndex(BnetPlayer friend)
    {
        <FindCurrentGameFrameIndex>c__AnonStorey120 storey = new <FindCurrentGameFrameIndex>c__AnonStorey120 {
            friend = friend
        };
        return this.m_currentGameFrames.FindIndex(new Predicate<FriendListCurrentGameFrame>(storey.<>m__D));
    }

    private FriendListFriendFrame FindFriendFrame(BnetPlayer friend)
    {
        <FindFriendFrame>c__AnonStorey11F storeyf = new <FindFriendFrame>c__AnonStorey11F {
            friend = friend
        };
        return this.m_friendFrames.Find(new Predicate<FriendListFriendFrame>(storeyf.<>m__C));
    }

    private int FindFriendFrameIndex(BnetPlayer friend)
    {
        <FindFriendFrameIndex>c__AnonStorey11E storeye = new <FindFriendFrameIndex>c__AnonStorey11E {
            friend = friend
        };
        return this.m_friendFrames.FindIndex(new Predicate<FriendListFriendFrame>(storeye.<>m__B));
    }

    private FriendListRequestFrame FindRequestFrame(BnetInvitation invite)
    {
        <FindRequestFrame>c__AnonStorey123 storey = new <FindRequestFrame>c__AnonStorey123 {
            invite = invite
        };
        return this.m_requestFrames.Find(new Predicate<FriendListRequestFrame>(storey.<>m__10));
    }

    private int FindRequestFrameIndex(BnetInvitation invite)
    {
        <FindRequestFrameIndex>c__AnonStorey122 storey = new <FindRequestFrameIndex>c__AnonStorey122 {
            invite = invite
        };
        return this.m_requestFrames.FindIndex(new Predicate<FriendListRequestFrame>(storey.<>m__F));
    }

    private void FixupScrolling(bool wasScrollEnabled, Component bottomComponent)
    {
        float t = (this.m_Background.GetHeight() - this.m_Constants.m_BackgroundHeightMin) / (this.m_Background.GetInitialHeight() - this.m_Constants.m_BackgroundHeightMin);
        this.m_ItemsCamera.orthographicSize = Mathf.Lerp(this.m_Constants.m_CameraSizeMin, this.m_Constants.m_CameraSizeMax, t);
        this.m_cameraTopScrollPos = Vector3.Lerp(this.m_Bones.m_ItemsCameraMinHeight.position, this.m_Bones.m_ItemsCameraMaxHeight.position, t);
        if (this.m_scrollEnabled)
        {
            Bounds boundsOfChildren = TransformUtil.GetBoundsOfChildren(bottomComponent);
            float num2 = boundsOfChildren.center.y - boundsOfChildren.extents.y;
            Vector3 cameraTopScrollPos = this.m_cameraTopScrollPos;
            float y = cameraTopScrollPos.y;
            float num4 = this.m_Bones.m_ItemsTop.position.y - y;
            this.m_cameraBottomScrollPos.x = cameraTopScrollPos.x;
            this.m_cameraBottomScrollPos.y = num2 + num4;
            this.m_cameraBottomScrollPos.z = cameraTopScrollPos.z;
            if (!wasScrollEnabled)
            {
                this.m_scrollUnitPos = 0f;
                this.m_scrollPrevUnitPos = 0f;
            }
            else
            {
                float num5 = this.m_ItemsCamera.transform.position.y;
                if (num5 < this.m_cameraBottomScrollPos.y)
                {
                    this.m_scrollUnitPos = 1f;
                    this.m_scrollPrevUnitPos = 1f;
                }
                else
                {
                    this.m_scrollUnitPos = (num5 - y) / (this.m_cameraBottomScrollPos.y - y);
                }
            }
        }
    }

    private int FriendFrameSortCompare(FriendListFriendFrame frame1, FriendListFriendFrame frame2)
    {
        BnetPlayer friend = frame1.GetFriend();
        BnetPlayer player2 = frame2.GetFriend();
        if (friend.IsOnline() && !player2.IsOnline())
        {
            return -1;
        }
        if (!friend.IsOnline() && player2.IsOnline())
        {
            return 1;
        }
        string uniqueName = FriendUtils.GetUniqueName(friend);
        string strB = FriendUtils.GetUniqueName(player2);
        return string.Compare(uniqueName, strB, true);
    }

    public static FriendListFrame Get()
    {
        return s_instance;
    }

    public bool HandleKeyboardInput()
    {
        if (FatalErrorMgr.Get().HasError())
        {
            return false;
        }
        if (!Input.GetKeyUp(KeyCode.Escape))
        {
            return false;
        }
        UnityEngine.Object.Destroy(base.gameObject);
        return true;
    }

    private void InitBackground()
    {
        this.m_Background.SetHeight(this.m_Background.GetInitialHeight());
        Vector3 vector = this.m_Bones.m_ItemsTop.position - this.m_Bones.m_ItemsBottom.position;
        this.m_maxListItemsHeight = Mathf.Abs(vector.y);
        this.m_Background.SetHeight(this.m_Constants.m_BackgroundHeightMin);
        vector = this.m_Bones.m_ItemsTop.position - this.m_Bones.m_ItemsBottom.position;
        this.m_minListItemsHeight = Mathf.Abs(vector.y);
    }

    private void InitButtons()
    {
        this.m_AddFriendButton.SetText(GameStrings.Get("GLOBAL_FRIENDLIST_ADD_FRIEND_BUTTON"));
        this.m_RemoveFriendButton.SetText(GameStrings.Get("GLOBAL_FRIENDLIST_REMOVE_FRIEND_BUTTON"));
    }

    private void InitHeaders()
    {
        this.m_requestHeader = this.CreateHeader();
        this.m_friendHeader = this.CreateHeader();
    }

    private void InitItemBackgrounds()
    {
        this.m_initialRequestsBackgroundHeight = this.m_RequestsBackground.renderer.bounds.size.y;
        this.m_CurrentGamesBackground.SetActive(false);
    }

    private void InitItems()
    {
        BnetFriendMgr mgr = BnetFriendMgr.Get();
        this.UpdateRequests(mgr.GetReceivedInvites(), null);
        this.UpdateAllFriends(mgr.GetFriends(), null);
        this.UpdateAllHeaders();
        this.UpdateSelectedElement();
    }

    private void InitScrolling()
    {
        this.m_ScrollBar.AddEventListener(UIEventType.PRESS, new UIEvent.Handler(this.OnScrollBarPress));
        this.m_ScrollBar.AddEventListener(UIEventType.RELEASEALL, new UIEvent.Handler(this.OnScrollBarReleaseAll));
        this.m_ScrollPlane.SetEnabled(false);
        this.m_ScrollPlane.collider.enabled = false;
        Bounds farClipBounds = CameraUtils.GetFarClipBounds(CameraUtils.FindFirstByLayer(this.m_ScrollPlane.gameObject.layer));
        BoxCollider collider = (BoxCollider) this.m_ScrollPlane.collider;
        collider.size = new Vector3(collider.size.x, collider.size.y, farClipBounds.size.y);
    }

    private void Layout()
    {
        bool scrollEnabled = this.m_scrollEnabled;
        this.PreLayoutListItems();
        Component bottomComponent = this.LayoutListItems();
        this.FixupScrolling(scrollEnabled, bottomComponent);
        this.PostLayoutListItems();
        this.UpdateItemsCamera();
    }

    private void LayoutBackground(float listItemsHeight)
    {
        if (this.m_scrollEnabled)
        {
            this.m_Background.EnableScrolling(true);
            this.m_Background.SetHeight(this.m_Background.GetInitialHeight());
        }
        else
        {
            this.m_Background.EnableScrolling(false);
            float t = (listItemsHeight - this.m_minListItemsHeight) / (this.m_maxListItemsHeight - this.m_minListItemsHeight);
            float height = Mathf.Lerp(this.m_Constants.m_BackgroundHeightMin, this.m_Background.GetInitialHeight(), t);
            this.m_Background.SetHeight(height);
        }
        TransformUtil.SetPoint((Component) this.m_Background, Anchor.BOTTOM_LEFT, (Component) BnetBarFriendButton.Get(), Anchor.TOP_LEFT, this.m_Offsets.m_BackgroundOffset);
    }

    private Component LayoutListItems()
    {
        Component prevComponent = this.LayoutSection<FriendListRequestFrame>(this.m_requestHeader, this.m_Bones.m_ItemsTop, this.m_requestFrames, this.m_RequestsBackground, this.m_initialRequestsBackgroundHeight);
        prevComponent = this.LayoutSection<FriendListFriendFrame>(this.m_friendHeader, prevComponent, this.m_friendFrames, null, 0f);
        this.ApplyLayoutOffsets<FriendListRequestFrame>(this.m_requestHeader, this.m_requestFrames);
        this.ApplyLayoutOffsets<FriendListFriendFrame>(this.m_friendHeader, this.m_friendFrames);
        return prevComponent;
    }

    private Component LayoutSection<T>(Component header, Component prevComponent, List<T> frames, GameObject background, float initialBackgroundHeight) where T: MonoBehaviour
    {
        TransformUtil.SetPoint(header, Anchor.TOP, prevComponent, Anchor.BOTTOM);
        prevComponent = header;
        float num = 0f;
        if (background != null)
        {
            Bounds boundsOfChildren = TransformUtil.GetBoundsOfChildren(prevComponent);
            num = boundsOfChildren.center.y + boundsOfChildren.extents.y;
        }
        if (frames.Count > 0)
        {
            T src = frames[0];
            TransformUtil.SetPoint(src, Anchor.TOP, prevComponent, Anchor.BOTTOM, true);
            prevComponent = src;
            for (int i = 1; i < frames.Count; i++)
            {
                src = frames[i];
                TransformUtil.SetPoint(src, Anchor.TOP, prevComponent, Anchor.BOTTOM, this.m_Offsets.m_ItemPadding, true);
                prevComponent = src;
            }
        }
        if (background != null)
        {
            Bounds bounds2 = TransformUtil.GetBoundsOfChildren(prevComponent);
            float num3 = bounds2.center.y - bounds2.extents.y;
            float num4 = num - num3;
            float z = num4 / initialBackgroundHeight;
            TransformUtil.SetLocalScaleZ(background, z);
            float y = (num3 + num) * 0.5f;
            Vector3 vector = new Vector3(this.m_Bones.m_ItemsTop.position.x, y, background.transform.position.z);
            background.transform.position = vector;
        }
        return prevComponent;
    }

    private void OnAddFriendButtonReleased(UIEvent e)
    {
        if (this.m_addFriendFrame != null)
        {
            Error.AddDevFatal("Friend List Error", "FriendListFrame.OnAddFriendButtonPressed() - There is already an active AddFriendFrame, but a second one was requested.", new object[0]);
        }
        else
        {
            this.m_addFriendFrame = (AddFriendFrame) UnityEngine.Object.Instantiate(this.m_Prefabs.m_AddFriendFrame);
            this.m_addFriendFrame.SetFriendList(this);
        }
    }

    public void OnAddFriendFrameClosed()
    {
        this.CloseAddFriendFrame();
    }

    private void OnBaseFriendFrameReleased(UIEvent e)
    {
        FriendListUIElement element = (FriendListUIElement) e.GetElement();
        if (this.m_selectedElement != null)
        {
            this.m_selectedElement.SetSelected(false);
        }
        this.m_selectedElement = element;
        element.SetSelected(true);
        BnetPlayer friend = element.GetComponent<FriendListBaseFriendFrame>().GetFriend();
        BnetFriendMgr.Get().SetSelectedFriend(friend);
        ChatMgr.Get().OnFriendListFriendSelected(friend);
    }

    private void OnCloseButtonReleased(UIEvent e)
    {
        this.Close();
    }

    private void OnDestroy()
    {
        s_instance = null;
        this.StopScrolling();
        SceneMgr.Get().UnregisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
        this.UnregisterFriendEvents();
        if (this.m_addFriendFrame != null)
        {
            UnityEngine.Object.Destroy(this.m_addFriendFrame.gameObject);
            this.m_addFriendFrame = null;
        }
        ChatMgr.Get().OnFriendListClosed();
        CheatMgr.Get().UnregisterCheatHandler("friendlistheight", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_friendlistheight));
    }

    private void OnFriendChallengeChanged(FriendChallengeEvent challengeEvent, BnetPlayer player, object userData)
    {
        if (player == BnetPresenceMgr.Get().GetMyPlayer())
        {
            this.UpdateFriendItems();
        }
        else
        {
            FriendListBaseFriendFrame frame = this.FindBaseFriendFrame(player);
            if (frame != null)
            {
                frame.UpdateFriend();
            }
        }
    }

    private void OnFriendsChanged(BnetFriendChangelist changelist, object userData)
    {
        this.UpdateRequests(changelist.GetAddedReceivedInvites(), changelist.GetRemovedReceivedInvites());
        this.UpdateAllFriends(changelist.GetAddedFriends(), changelist.GetRemovedFriends());
        this.UpdateAllHeaders();
        this.UpdateSelectedElement();
        this.Layout();
    }

    private void OnMouseOnOrOffScreen(bool onScreen)
    {
        if (!onScreen)
        {
            this.ResetScrolling();
        }
    }

    private void OnPlayersChanged(BnetPlayerChangelist changelist, object userData)
    {
        BnetPlayer myPlayer = BnetPresenceMgr.Get().GetMyPlayer();
        bool flag = false;
        bool flag2 = false;
        foreach (BnetPlayerChange change in changelist.GetChanges())
        {
            BnetPlayer oldPlayer = change.GetOldPlayer();
            BnetPlayer newPlayer = change.GetNewPlayer();
            if (newPlayer == myPlayer)
            {
                this.UpdateMyself();
                BnetGameAccount hearthstoneGameAccount = newPlayer.GetHearthstoneGameAccount();
                if (oldPlayer == null)
                {
                    flag2 = hearthstoneGameAccount.CanBeInvitedToGame();
                }
                else
                {
                    flag2 = oldPlayer.GetHearthstoneGameAccount().CanBeInvitedToGame() != hearthstoneGameAccount.CanBeInvitedToGame();
                }
                continue;
            }
            if ((oldPlayer == null) || (oldPlayer.IsOnline() != newPlayer.IsOnline()))
            {
                flag = true;
            }
            long persistentGameId = newPlayer.GetPersistentGameId();
            int index = this.FindFriendFrameIndex(newPlayer);
            if (index >= 0)
            {
                if (persistentGameId != 0)
                {
                    this.DestroyFriendFrame(index);
                    this.CreateCurrentGameFrame(newPlayer);
                    this.UpdateCurrentGamesHeader();
                    this.UpdateFriendsHeader();
                    flag = true;
                }
                else
                {
                    this.UpdateFriendFrame(index);
                }
                continue;
            }
            index = this.FindCurrentGameFrameIndex(newPlayer);
            if (index >= 0)
            {
                if (persistentGameId == 0)
                {
                    this.DestroyCurrentGameFrame(index);
                    this.CreateFriendFrame(newPlayer);
                    this.UpdateCurrentGamesHeader();
                    this.UpdateFriendsHeader();
                    flag = true;
                }
                else
                {
                    this.UpdateCurrentGameFrame(index);
                }
            }
        }
        if (flag2)
        {
            this.UpdateItems();
        }
        if (flag)
        {
            this.SortFriendFrames();
            this.UpdateAllHeaders();
            this.Layout();
        }
    }

    private bool OnProcessCheat_friendlistheight(string func, string[] args, string rawArgs)
    {
        if (args.Length == 0)
        {
            return false;
        }
        if (!float.TryParse(args[0], out this.m_testHeight))
        {
            return false;
        }
        this.m_useTestHeight = true;
        this.Layout();
        return true;
    }

    private void OnRemoveFriendButtonReleased(UIEvent e)
    {
        if (this.m_selectedElement != null)
        {
            BnetPlayer selectedFriend = BnetFriendMgr.Get().GetSelectedFriend();
            string uniqueName = FriendUtils.GetUniqueName(selectedFriend);
            AlertPopup.PopupInfo info = new AlertPopup.PopupInfo();
            object[] args = new object[] { uniqueName };
            info.m_text = GameStrings.Format("GLOBAL_FRIENDLIST_REMOVE_FRIEND_ALERT_MESSAGE", args);
            info.m_showAlertIcon = true;
            info.m_responseDisplay = AlertPopup.ResponseDisplay.CONFIRM_CANCEL;
            info.m_responseCallback = new AlertPopup.ResponseCallback(this.OnRemoveFriendPopupResponse);
            DialogManager.Get().ShowPopup(info, new DialogManager.DialogProcessCallback(this.OnRemoveFriendDialogShown), selectedFriend);
        }
    }

    private bool OnRemoveFriendDialogShown(DialogBase dialog, object userData)
    {
        BnetPlayer player = (BnetPlayer) userData;
        if (!BnetFriendMgr.Get().IsFriend(player))
        {
            return false;
        }
        this.m_removeFriendPopup = (AlertPopup) dialog;
        return true;
    }

    private void OnRemoveFriendPopupResponse(AlertPopup.Response response, object userData)
    {
        if (response == AlertPopup.Response.CONFIRM)
        {
            BnetFriendMgr.Get().RemoveFriend(BnetFriendMgr.Get().GetSelectedFriend());
        }
        this.m_removeFriendPopup = null;
    }

    private void OnSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
        if (mode == SceneMgr.Mode.FATAL_ERROR)
        {
            this.Close();
        }
    }

    private void OnScrollBarPress(UIEvent e)
    {
        this.StartScrolling();
    }

    private void OnScrollBarReleaseAll(UIEvent e)
    {
        this.StopScrolling();
    }

    private void PostLayoutListItems()
    {
        if (this.m_scrollEnabled)
        {
            this.m_CloseButton.transform.position = this.m_Bones.m_CloseButtonScroll.position;
            this.m_RemoveFriendButton.transform.position = this.m_Bones.m_RemoveFriendButtonScroll.position;
            this.m_ScrollBar.gameObject.SetActive(true);
            this.m_ScrollThumb.SetActive(true);
            this.UpdateScrollThumbPos();
            if (this.m_scrollActive && (this.m_scrollPrevUnitPos > this.m_scrollUnitPos))
            {
                this.m_scrollPrevUnitPos = this.m_scrollUnitPos;
            }
        }
        else
        {
            this.m_CloseButton.transform.position = this.m_Bones.m_CloseButton.position;
            this.m_RemoveFriendButton.transform.position = this.m_Bones.m_RemoveFriendButton.position;
            this.m_ScrollBar.gameObject.SetActive(false);
            this.m_ScrollThumb.SetActive(false);
            this.StopScrolling();
            this.m_scrollUnitPos = 0f;
            this.m_ItemsCamera.transform.position = this.m_cameraTopScrollPos;
        }
    }

    private float PreComputeListItemsHeight()
    {
        float num = 0f;
        num += this.PreComputeSectionHeight<FriendListRequestFrame>(this.m_requestHeader, this.m_requestFrames);
        return (num + this.PreComputeSectionHeight<FriendListFriendFrame>(this.m_friendHeader, this.m_friendFrames));
    }

    private float PreComputeSectionHeight<T>(Component header, List<T> frames) where T: MonoBehaviour
    {
        float num = 0f;
        Bounds boundsOfChildren = TransformUtil.GetBoundsOfChildren(header);
        num += boundsOfChildren.size.y;
        if (frames.Count > 0)
        {
            T c = frames[0];
            float y = TransformUtil.GetBoundsOfChildren(c, true).size.y;
            float num3 = y + Mathf.Abs(this.m_Offsets.m_ItemPadding.y);
            float num4 = y + (num3 * (frames.Count - 1));
            num += num4;
        }
        return num;
    }

    private void PreLayoutListItems()
    {
        base.transform.parent = PegUI.Get().transform;
        float listItemsHeight = this.DetermineScrolling();
        this.LayoutBackground(listItemsHeight);
        base.transform.position = this.m_Background.transform.position;
        this.m_Background.transform.localPosition = Vector3.zero;
        this.m_MyGameIcon.transform.position = this.m_Bones.m_MyGameIcon.position;
        this.m_MyNameText.transform.position = this.m_Bones.m_MyName.position;
        TransformUtil.SetPoint(this.m_MyNumberText.gameObject, Anchor.LEFT, this.m_MyNameText.gameObject, Anchor.RIGHT, this.m_Offsets.m_MyNumberPadding);
        this.m_AddFriendButton.transform.position = this.m_Bones.m_AddButton.position;
    }

    private void RegisterFriendEvents()
    {
        BnetFriendMgr.Get().AddChangeListener(new BnetFriendMgr.ChangeCallback(this.OnFriendsChanged));
        BnetPresenceMgr.Get().AddPlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
        FriendChallengeMgr.Get().AddChangedListener(new FriendChallengeMgr.ChangedCallback(this.OnFriendChallengeChanged));
    }

    private void RegisterUIEvents()
    {
        this.m_CloseButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnCloseButtonReleased));
        this.m_AddFriendButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnAddFriendButtonReleased));
        this.m_RemoveFriendButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnRemoveFriendButtonReleased));
    }

    private void ResetScrolling()
    {
        this.m_scrollUnitPos = this.m_scrollPrevUnitPos;
        this.StopScrolling();
    }

    private void SortFriendFrames()
    {
        this.m_friendFrames.Sort(new Comparison<FriendListFriendFrame>(this.FriendFrameSortCompare));
    }

    private void Start()
    {
        this.InitBackground();
        this.UpdateMyself();
        this.InitItems();
        this.Layout();
        ChatMgr.Get().OnFriendListOpened();
    }

    private void StartScrolling()
    {
        UniversalInputManager.Get().RegisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
        SceneUtils.EnableColliders(this.m_ItemsParent, false);
        this.m_ScrollPlane.SetEnabled(true);
        this.m_ScrollPlane.collider.enabled = true;
        this.m_ScrollBar.gameObject.SetActive(false);
        this.m_scrollPrevUnitPos = this.m_scrollUnitPos;
        this.m_scrollActive = true;
    }

    private void StopScrolling()
    {
        this.m_ScrollPlane.SetEnabled(false);
        this.m_ScrollPlane.collider.enabled = false;
        if (this.m_scrollEnabled)
        {
            this.m_ScrollBar.gameObject.SetActive(true);
        }
        this.m_scrollActive = false;
        SceneUtils.EnableColliders(this.m_ItemsParent, true);
        UniversalInputManager.Get().UnregisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
    }

    private void UnregisterFriendEvents()
    {
        BnetFriendMgr.Get().RemoveChangeListener(new BnetFriendMgr.ChangeCallback(this.OnFriendsChanged));
        BnetPresenceMgr.Get().RemovePlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
        FriendChallengeMgr.Get().RemoveChangedListener(new FriendChallengeMgr.ChangedCallback(this.OnFriendChallengeChanged));
    }

    private void Update()
    {
        this.UpdateScrollInput();
    }

    private void UpdateAllFriends(List<BnetPlayer> addedList, List<BnetPlayer> removedList)
    {
        if ((removedList != null) || (addedList != null))
        {
            if (removedList != null)
            {
                foreach (BnetPlayer player in removedList)
                {
                    if (!this.DestroyFriendFrame(player) && this.DestroyCurrentGameFrame(player))
                    {
                    }
                }
            }
            this.UpdateFriendItems();
            if (addedList != null)
            {
                foreach (BnetPlayer player2 in addedList)
                {
                    if (player2.GetPersistentGameId() == 0)
                    {
                        this.CreateFriendFrame(player2);
                    }
                    else
                    {
                        this.CreateCurrentGameFrame(player2);
                    }
                }
            }
            this.SortFriendFrames();
        }
    }

    private void UpdateAllHeaders()
    {
        this.UpdateRequestsHeader();
        this.UpdateCurrentGamesHeader();
        this.UpdateFriendsHeader();
    }

    private bool UpdateCurrentGameFrame(BnetPlayer friend)
    {
        int index = this.FindCurrentGameFrameIndex(friend);
        if (index < 0)
        {
            return false;
        }
        this.UpdateCurrentGameFrame(index);
        return true;
    }

    private void UpdateCurrentGameFrame(int index)
    {
        this.m_currentGameFrames[index].UpdateFriend();
    }

    private void UpdateCurrentGamesHeader()
    {
    }

    private bool UpdateFriendFrame(BnetPlayer friend)
    {
        int index = this.FindFriendFrameIndex(friend);
        if (index < 0)
        {
            return false;
        }
        this.UpdateFriendFrame(index);
        return true;
    }

    private void UpdateFriendFrame(int index)
    {
        this.m_friendFrames[index].UpdateFriend();
    }

    private void UpdateFriendItems()
    {
        foreach (FriendListCurrentGameFrame frame in this.m_currentGameFrames)
        {
            frame.UpdateFriend();
        }
        foreach (FriendListFriendFrame frame2 in this.m_friendFrames)
        {
            frame2.UpdateFriend();
        }
    }

    private void UpdateFriendsHeader()
    {
        int num;
        int num2;
        this.CountOnlineFriends(out num, out num2);
        string text = null;
        if (num == 0)
        {
            text = GameStrings.Get("GLOBAL_FRIENDLIST_FRIENDS_HEADER_NO_ONLINE");
        }
        else if (num == num2)
        {
            object[] args = new object[] { num };
            text = GameStrings.Format("GLOBAL_FRIENDLIST_FRIENDS_HEADER_ALL_ONLINE", args);
        }
        else
        {
            object[] objArray2 = new object[] { num, num2 };
            text = GameStrings.Format("GLOBAL_FRIENDLIST_FRIENDS_HEADER", objArray2);
        }
        this.m_friendHeader.SetText(text);
    }

    private void UpdateItems()
    {
        foreach (FriendListRequestFrame frame in this.m_requestFrames)
        {
            frame.UpdateInvite();
        }
        this.UpdateFriendItems();
    }

    private void UpdateItemsCamera()
    {
        Camera bnetCamera = BaseUI.Get().GetBnetCamera();
        Vector3 vector = bnetCamera.WorldToViewportPoint(this.m_Bones.m_ItemsTopLeft.position);
        Vector3 vector2 = bnetCamera.WorldToViewportPoint(this.m_Bones.m_ItemsBottomRight.position);
        float width = vector2.x - vector.x;
        float height = vector.y - vector2.y;
        this.m_ItemsCamera.rect = new Rect(vector.x, vector2.y, width, height);
    }

    public void UpdateLayout()
    {
        this.Layout();
        if (this.m_addFriendFrame != null)
        {
            this.m_addFriendFrame.UpdateLayout();
        }
    }

    private void UpdateMyself()
    {
        BnetBattleTag battleTag = BnetPresenceMgr.Get().GetMyPlayer().GetBattleTag();
        this.m_MyGameIcon.SetProgramId(BnetProgramId.HEARTHSTONE);
        this.m_MyNameText.Text = battleTag.GetName();
        this.m_MyNumberText.Text = string.Format("#{0}", battleTag.GetNumber().ToString());
    }

    private void UpdateRequests(List<BnetInvitation> addedList, List<BnetInvitation> removedList)
    {
        if ((removedList != null) || (addedList != null))
        {
            if (removedList != null)
            {
                foreach (BnetInvitation invitation in removedList)
                {
                    this.DestroyRequestFrame(invitation);
                }
            }
            foreach (FriendListRequestFrame frame in this.m_requestFrames)
            {
                frame.UpdateInvite();
            }
            if (addedList != null)
            {
                foreach (BnetInvitation invitation2 in addedList)
                {
                    this.CreateRequestFrame(invitation2);
                }
            }
        }
    }

    private void UpdateRequestsHeader()
    {
        object[] args = new object[] { this.m_requestFrames.Count };
        string text = GameStrings.Format("GLOBAL_FRIENDLIST_REQUESTS_HEADER", args);
        this.m_requestHeader.SetText(text);
    }

    private void UpdateScrollCameraPos()
    {
        this.m_ItemsCamera.transform.position = Vector3.Lerp(this.m_cameraTopScrollPos, this.m_cameraBottomScrollPos, this.m_scrollUnitPos);
    }

    private void UpdateScrollInput()
    {
        if (!this.UpdateScrollInputWheel())
        {
            this.UpdateScrollInputDevicePos();
        }
    }

    private bool UpdateScrollInputDevicePos()
    {
        RaycastHit hit;
        if (!this.m_scrollActive)
        {
            return false;
        }
        Vector3 position = this.m_Bones.m_ScrollTop.transform.position;
        Vector3 vector2 = this.m_Bones.m_ScrollBottom.transform.position;
        if (UniversalInputManager.Get().GetInputHitInfo(((int) 1) << this.m_ScrollPlane.gameObject.layer, out hit))
        {
            float num = position.y - vector2.y;
            this.m_scrollUnitPos = Mathf.Clamp01(-(hit.point.y - position.y) / num);
        }
        else
        {
            this.m_scrollUnitPos = this.m_scrollPrevUnitPos;
        }
        this.UpdateScrollThumbPos();
        this.UpdateScrollCameraPos();
        return true;
    }

    private bool UpdateScrollInputWheel()
    {
        RaycastHit hit;
        if (!this.m_scrollEnabled)
        {
            return false;
        }
        float objA = 0f;
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            objA += 0.2f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            objA -= 0.2f;
        }
        if (object.Equals(objA, 0f))
        {
            return false;
        }
        if (!UniversalInputManager.Get().GetInputHitInfo(((int) 1) << this.m_Background.gameObject.layer, out hit) && !UniversalInputManager.Get().GetInputHitInfo(((int) 1) << this.m_ItemsParent.layer, out hit))
        {
            return false;
        }
        if (!SceneUtils.IsDescendantOf(hit.transform, this))
        {
            return false;
        }
        this.m_scrollUnitPos = Mathf.Clamp01(this.m_scrollUnitPos + objA);
        this.UpdateScrollPos();
        return true;
    }

    private void UpdateScrollPos()
    {
        this.UpdateScrollThumbPos();
        this.UpdateScrollCameraPos();
    }

    private void UpdateScrollThumbPos()
    {
        Vector3 position = this.m_Bones.m_ScrollTop.transform.position;
        Vector3 to = this.m_Bones.m_ScrollBottom.transform.position;
        this.m_ScrollThumb.transform.position = Vector3.Lerp(position, to, this.m_scrollUnitPos);
    }

    private void UpdateSelectedElement()
    {
        BnetPlayer selectedFriend = BnetFriendMgr.Get().GetSelectedFriend();
        FriendListBaseFriendFrame frame = this.FindBaseFriendFrame(selectedFriend);
        if (frame == null)
        {
            if (this.m_selectedElement != null)
            {
                this.m_selectedElement.SetSelected(false);
                this.m_selectedElement = null;
                if (this.m_removeFriendPopup != null)
                {
                    this.m_removeFriendPopup.Hide();
                    this.m_removeFriendPopup = null;
                }
            }
        }
        else
        {
            FriendListUIElement component = frame.GetComponent<FriendListUIElement>();
            if (this.m_selectedElement != component)
            {
                this.m_selectedElement = component;
                this.m_selectedElement.SetSelected(true);
            }
        }
    }

    [CompilerGenerated]
    private sealed class <FindCurrentGameFrame>c__AnonStorey121
    {
        internal BnetPlayer friend;

        internal bool <>m__E(FriendListCurrentGameFrame frame)
        {
            return (frame.GetFriend() == this.friend);
        }
    }

    [CompilerGenerated]
    private sealed class <FindCurrentGameFrameIndex>c__AnonStorey120
    {
        internal BnetPlayer friend;

        internal bool <>m__D(FriendListCurrentGameFrame frame)
        {
            return (frame.GetFriend() == this.friend);
        }
    }

    [CompilerGenerated]
    private sealed class <FindFriendFrame>c__AnonStorey11F
    {
        internal BnetPlayer friend;

        internal bool <>m__C(FriendListFriendFrame frame)
        {
            return (frame.GetFriend() == this.friend);
        }
    }

    [CompilerGenerated]
    private sealed class <FindFriendFrameIndex>c__AnonStorey11E
    {
        internal BnetPlayer friend;

        internal bool <>m__B(FriendListFriendFrame frame)
        {
            return (frame.GetFriend() == this.friend);
        }
    }

    [CompilerGenerated]
    private sealed class <FindRequestFrame>c__AnonStorey123
    {
        internal BnetInvitation invite;

        internal bool <>m__10(FriendListRequestFrame frame)
        {
            return (frame.GetInvite() == this.invite);
        }
    }

    [CompilerGenerated]
    private sealed class <FindRequestFrameIndex>c__AnonStorey122
    {
        internal BnetInvitation invite;

        internal bool <>m__F(FriendListRequestFrame frame)
        {
            return (frame.GetInvite() == this.invite);
        }
    }
}


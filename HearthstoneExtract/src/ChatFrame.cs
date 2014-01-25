using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChatFrame : MonoBehaviour
{
    private const int AUTO_SCROLL_VISIBLE_MESSAGE_COUNT = 2;
    public GameObject m_Background;
    public ChatFrameBones m_Bones;
    private float m_cameraTopToMessagesTopYOffset;
    public FriendListThreeSliceButton m_ChallengeButton;
    public FriendListUIElement m_CloseButton;
    public FriendListGameIcon m_GameIcon;
    private float m_maxMessagesHeight;
    private List<ChatFrameMessageFrame> m_messageFrames = new List<ChatFrameMessageFrame>();
    public GameObject m_MessagesBackground;
    public Camera m_MessagesCamera;
    public GameObject m_MessagesParent;
    public UberText m_NameText;
    public ChatFrameOffsets m_Offsets;
    public ChatFramePrefabs m_Prefabs;
    private BnetPlayer m_receiver;
    private bool m_scrollActive;
    public PegUIElement m_ScrollBar;
    private bool m_scrollEnabled;
    public PegUIElement m_ScrollPlane;
    private float m_scrollPrevUnitPos;
    public GameObject m_ScrollThumb;
    private float m_scrollUnitPos;
    public ChatFrameValues m_Values;
    private const int MAX_MESSAGE_FRAMES = 500;

    private void AddAndLayoutMyMessage(string message)
    {
        ChatFrameMessageFrame frame = this.AddMessage(this.m_Prefabs.m_MyMessage);
        frame.SetMessage(message);
        this.LayoutAddedMessage(frame);
    }

    private void AddAndLayoutOfflineMessage()
    {
        object[] args = new object[] { this.m_receiver.GetBestName() };
        string message = GameStrings.Format("GLOBAL_CHAT_RECEIVER_OFFLINE", args);
        this.AddAndLayoutSystemMessage(message, this.m_Values.m_ErrorMessageColor);
    }

    private void AddAndLayoutOnlineMessage()
    {
        object[] args = new object[] { this.m_receiver.GetBestName() };
        string message = GameStrings.Format("GLOBAL_CHAT_RECEIVER_ONLINE", args);
        this.AddAndLayoutSystemMessage(message, this.m_Values.m_InfoMessageColor);
    }

    private void AddAndLayoutSystemMessage(string message, Color color)
    {
        ChatFrameMessageFrame frame = this.AddMessage(this.m_Prefabs.m_SystemMessage);
        frame.SetMessage(message);
        frame.SetColor(color);
        this.LayoutAddedMessage(frame);
    }

    private void AddAndLayoutWhisperMessage(BnetWhisper whisper)
    {
        ChatFrameMessageFrame frame = this.AddWhisperMessage(whisper);
        this.LayoutAddedMessage(frame);
    }

    private ChatFrameMessageFrame AddMessage(ChatFrameMessageFrame prefab)
    {
        ChatFrameMessageFrame item = (ChatFrameMessageFrame) UnityEngine.Object.Instantiate(prefab);
        this.m_messageFrames.Add(item);
        return item;
    }

    private ChatFrameMessageFrame AddWhisperMessage(BnetWhisper whisper)
    {
        ChatFrameMessageFrame theirMessage;
        if (whisper.IsSpeaker(this.m_receiver))
        {
            theirMessage = this.m_Prefabs.m_TheirMessage;
        }
        else
        {
            theirMessage = this.m_Prefabs.m_MyMessage;
        }
        ChatFrameMessageFrame frame2 = this.AddMessage(theirMessage);
        frame2.SetMessage(whisper.GetMessage());
        return frame2;
    }

    [Conditional("CHATFRAME_DEBUG")]
    private void AssignMessageFrameNames()
    {
        for (int i = 0; i < this.m_messageFrames.Count; i++)
        {
            ChatFrameMessageFrame frame = this.m_messageFrames[i];
            frame.name = string.Format("MessageFrame {0} ({1})", i, frame.GetMessage());
        }
    }

    private void AutoScrollToBottom(int newMessageCount)
    {
        if (!this.m_scrollActive && this.m_scrollEnabled)
        {
            int num = this.m_messageFrames.Count - newMessageCount;
            int num2 = (num - 2) - 1;
            if (num2 >= 0)
            {
                int num3 = -1;
                for (int i = num2; i < num; i++)
                {
                    RaycastHit hit;
                    ChatFrameMessageFrame frame = this.m_messageFrames[i];
                    Vector3 screenPoint = this.m_MessagesCamera.WorldToScreenPoint(frame.transform.position);
                    screenPoint.z = this.m_MessagesCamera.nearClipPlane;
                    if (CameraUtils.Raycast(this.m_MessagesCamera, screenPoint, out hit) && SceneUtils.IsAncestorOf(frame.transform, hit.transform))
                    {
                        num3 = i;
                        break;
                    }
                }
                if (num3 >= 0)
                {
                    this.m_scrollUnitPos = 1f;
                    this.UpdateScrollPos();
                }
            }
        }
    }

    private void Awake()
    {
        this.InitializeUI();
        this.InitTransform();
        this.InitMetrics();
        this.InitBackground();
        this.InitScrolling();
        BnetWhisperMgr.Get().AddWhisperListener(new BnetWhisperMgr.WhisperCallback(this.OnWhisper));
        BnetPresenceMgr.Get().AddPlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
        BnetFriendMgr.Get().AddChangeListener(new BnetFriendMgr.ChangeCallback(this.OnFriendsChanged));
        FriendChallengeMgr.Get().AddChangedListener(new FriendChallengeMgr.ChangedCallback(this.OnFriendChallengeChanged));
        this.ShowInput();
    }

    private float ComputeMessagesHeight()
    {
        float num = 0f;
        if (this.m_messageFrames.Count > 0)
        {
            ChatFrameMessageFrame c = this.m_messageFrames[0];
            float y = TransformUtil.GetBoundsOfChildren(c, true).size.y;
            num += y;
            float num3 = Mathf.Abs(this.m_Offsets.m_MessagePadding.y);
            for (int i = 1; i < this.m_messageFrames.Count; i++)
            {
                c = this.m_messageFrames[i];
                y = TransformUtil.GetBoundsOfChildren(c, true).size.y + num3;
                num += y;
            }
        }
        return num;
    }

    private void DetermineScrolling()
    {
        float num = this.ComputeMessagesHeight();
        this.m_scrollEnabled = num > this.m_maxMessagesHeight;
    }

    private void FixupCameraBottomScrollPos()
    {
        Bounds boundsOfChildren = TransformUtil.GetBoundsOfChildren(this.GetBottomMessagesComponent());
        float num = boundsOfChildren.center.y - boundsOfChildren.extents.y;
        TransformUtil.SetPosY(this.m_Bones.m_MessagesCameraBottom, num + this.m_cameraTopToMessagesTopYOffset);
    }

    private void FixupScrolling(bool wasScrollEnabled)
    {
        if (this.m_scrollEnabled)
        {
            this.FixupCameraBottomScrollPos();
            this.FixupScrollPos(wasScrollEnabled);
            this.m_ScrollBar.gameObject.SetActive(true);
            this.m_ScrollThumb.SetActive(true);
            this.UpdateScrollThumbPos();
        }
        else
        {
            this.m_ScrollBar.gameObject.SetActive(false);
            this.m_ScrollThumb.SetActive(false);
            this.StopScrolling();
            this.m_scrollUnitPos = 0f;
        }
        this.UpdateScrollCameraPos();
    }

    private void FixupScrollPos(bool wasScrollEnabled)
    {
        if (!wasScrollEnabled)
        {
            this.m_scrollUnitPos = 0f;
            this.m_scrollPrevUnitPos = 0f;
        }
        else
        {
            float y = this.m_MessagesCamera.transform.position.y;
            if (y < this.m_Bones.m_MessagesCameraBottom.position.y)
            {
                this.m_scrollUnitPos = 1f;
                this.m_scrollPrevUnitPos = 1f;
            }
            else
            {
                Vector3 position = this.m_Bones.m_MessagesCameraTop.position;
                Vector3 vector2 = this.m_Bones.m_MessagesCameraBottom.position;
                this.m_scrollUnitPos = (y - position.y) / (vector2.y - position.y);
                if (this.m_scrollActive && (this.m_scrollPrevUnitPos > this.m_scrollUnitPos))
                {
                    this.m_scrollPrevUnitPos = this.m_scrollUnitPos;
                }
            }
        }
    }

    private Component GetBottomMessagesComponent()
    {
        if (this.m_messageFrames.Count == 0)
        {
            return this.m_Bones.m_MessagesTop;
        }
        return this.m_messageFrames[this.m_messageFrames.Count - 1];
    }

    public BnetPlayer GetReceiver()
    {
        return this.m_receiver;
    }

    private void InitBackground()
    {
        Bounds boundsOfChildren = TransformUtil.GetBoundsOfChildren(this.m_MessagesBackground);
        float x = boundsOfChildren.size.x;
        float y = boundsOfChildren.size.y;
        float num3 = this.m_MessagesBackground.transform.localScale.x;
        float z = this.m_MessagesBackground.transform.localScale.z;
        Vector3 vector = this.m_Bones.m_MessagesTopLeft.position - this.m_Bones.m_MessagesBottomRight.position;
        float num5 = (num3 * vector.x) / x;
        float num6 = (z * vector.y) / y;
        TransformUtil.SetLocalScaleXZ(this.m_MessagesBackground, num5, num6);
        TransformUtil.SetPoint(this.m_MessagesBackground, Anchor.TOP_LEFT, this.m_Bones.m_MessagesTopLeft, Anchor.BOTTOM_RIGHT);
    }

    private void InitializeUI()
    {
        this.m_ChallengeButton.SetText(GameStrings.Get("GLOBAL_CHAT_CHALLENGE"));
        this.m_ChallengeButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnChallengeButtonReleased));
        this.m_CloseButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnCloseButtonReleased));
    }

    private void InitMetrics()
    {
        this.m_maxMessagesHeight = this.m_Bones.m_MessagesTop.position.y - this.m_Bones.m_MessagesBottom.position.y;
        this.m_cameraTopToMessagesTopYOffset = this.m_Bones.m_MessagesTop.position.y - this.m_Bones.m_MessagesCameraTop.position.y;
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
        this.UpdateScrollCameraViewport();
    }

    private void InitTransform()
    {
        base.transform.parent = ChatMgr.Get().transform;
        this.UpdateLayout();
    }

    private void LayoutAddedMessage(ChatFrameMessageFrame frame)
    {
        int count = this.m_messageFrames.Count;
        if (count > 500)
        {
            UnityEngine.Object.Destroy(this.m_messageFrames[0].gameObject);
            this.m_messageFrames.RemoveAt(0);
            this.LayoutAllMessages();
        }
        else if (count == 1)
        {
            TransformUtil.SetPoint((Component) frame, Anchor.TOP_LEFT, (Component) this.m_Bones.m_MessagesTopLeft, Anchor.BOTTOM_LEFT);
        }
        else
        {
            TransformUtil.SetPoint(frame, Anchor.TOP_LEFT, this.m_messageFrames[count - 2], Anchor.BOTTOM_LEFT, this.m_Offsets.m_MessagePadding);
        }
        this.UpdateScrolling();
    }

    private void LayoutAllMessages()
    {
        ChatFrameMessageFrame frame = this.m_messageFrames[0];
        TransformUtil.SetPoint((Component) frame, Anchor.TOP_LEFT, (Component) this.m_Bones.m_MessagesTopLeft, Anchor.BOTTOM_LEFT);
        Component dst = frame;
        for (int i = 1; i < this.m_messageFrames.Count; i++)
        {
            ChatFrameMessageFrame src = this.m_messageFrames[i];
            TransformUtil.SetPoint(src, Anchor.TOP_LEFT, dst, Anchor.BOTTOM_LEFT, this.m_Offsets.m_MessagePadding);
            dst = src;
        }
    }

    private void OnChallengeButtonReleased(UIEvent e)
    {
        FriendChallengeMgr.Get().SendChallenge(this.m_receiver);
    }

    private void OnCloseButtonReleased(UIEvent e)
    {
        ChatMgr.Get().OnChatFrameClosed();
    }

    private void OnDestroy()
    {
        BnetWhisperMgr.Get().RemoveWhisperListener(new BnetWhisperMgr.WhisperCallback(this.OnWhisper));
        BnetPresenceMgr.Get().RemovePlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
        BnetFriendMgr.Get().RemoveChangeListener(new BnetFriendMgr.ChangeCallback(this.OnFriendsChanged));
        FriendChallengeMgr.Get().RemoveChangedListener(new FriendChallengeMgr.ChangedCallback(this.OnFriendChallengeChanged));
        UniversalInputManager.Get().CancelTextInputBox(base.gameObject);
    }

    private void OnFriendChallengeChanged(FriendChallengeEvent challengeEvent, BnetPlayer player, object userData)
    {
        if ((player == BnetPresenceMgr.Get().GetMyPlayer()) || (player == this.m_receiver))
        {
            this.UpdateChallenge();
        }
    }

    private void OnFriendsChanged(BnetFriendChangelist changelist, object userData)
    {
        List<BnetPlayer> removedFriends = changelist.GetRemovedFriends();
        if (removedFriends != null)
        {
            foreach (BnetPlayer player in removedFriends)
            {
                if (player == this.m_receiver)
                {
                    ChatMgr.Get().OnChatFrameClosed();
                    break;
                }
            }
        }
    }

    private void OnInputCanceled()
    {
        ChatMgr.Get().OnChatFrameClosed();
    }

    private void OnInputComplete(string input)
    {
        if (this.m_receiver.IsOnline())
        {
            BnetWhisperMgr.Get().SendWhisper(this.m_receiver, input);
        }
        else
        {
            this.AddAndLayoutMyMessage(input);
            this.AutoScrollToBottom(1);
        }
        ChatMgr.Get().AddRecentWhisperPlayer(this.m_receiver);
        this.ShowInput();
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
        BnetPlayerChange change = changelist.FindChange(this.m_receiver);
        if (change != null)
        {
            this.UpdateReceiver();
            BnetPlayer oldPlayer = change.GetOldPlayer();
            BnetPlayer newPlayer = change.GetNewPlayer();
            if ((oldPlayer == null) || (oldPlayer.IsOnline() != newPlayer.IsOnline()))
            {
                if (newPlayer.IsOnline())
                {
                    this.AddAndLayoutOnlineMessage();
                }
                else
                {
                    this.AddAndLayoutOfflineMessage();
                }
            }
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

    private void OnWhisper(BnetWhisper whisper, object userData)
    {
        if ((this.m_receiver != null) && whisper.IsSpeakerOrReceiver(this.m_receiver))
        {
            this.AddAndLayoutWhisperMessage(whisper);
            if (whisper.IsSpeaker(this.m_receiver))
            {
                this.AutoScrollToBottom(1);
            }
            else if (this.m_scrollEnabled && !this.m_scrollActive)
            {
                this.m_scrollUnitPos = 1f;
                this.UpdateScrollPos();
            }
        }
    }

    private void ResetScrolling()
    {
        this.m_scrollUnitPos = this.m_scrollPrevUnitPos;
        this.StopScrolling();
    }

    public void SetReceiver(BnetPlayer player)
    {
        if (this.m_receiver != player)
        {
            this.m_receiver = player;
            this.UpdateReceiver();
            this.UpdateMessages();
            if (!player.IsOnline())
            {
                this.AddAndLayoutOfflineMessage();
            }
            this.m_scrollUnitPos = 1f;
            this.UpdateScrollPos();
        }
    }

    private void ShowInput()
    {
        Rect rect = CameraUtils.CreateGUIViewportRect(BaseUI.Get().GetBnetCamera(), this.m_Bones.m_InputTopLeft, this.m_Bones.m_InputBottomRight);
        UniversalInputManager.Get().UseTextInputBox(base.gameObject, rect, null, new UniversalInputManager.InputCompletedCallback(this.OnInputComplete), new UniversalInputManager.InputCanceledCallback(this.OnInputCanceled), -1);
    }

    private void StartScrolling()
    {
        UniversalInputManager.Get().RegisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
        SceneUtils.EnableColliders(this.m_MessagesParent, false);
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
        SceneUtils.EnableColliders(this.m_MessagesParent, true);
        UniversalInputManager.Get().UnregisterMouseOnOrOffScreenListener(new UniversalInputManager.MouseOnOrOffScreenCallback(this.OnMouseOnOrOffScreen));
    }

    private void Update()
    {
        this.UpdateScrollInput();
    }

    private void UpdateChallenge()
    {
        if (FriendChallengeMgr.Get().CanChallenge(this.m_receiver))
        {
            this.m_ChallengeButton.gameObject.SetActive(true);
        }
        else
        {
            this.m_ChallengeButton.gameObject.SetActive(false);
        }
    }

    private void UpdateInputRect()
    {
        Rect rect = CameraUtils.CreateGUIViewportRect(BaseUI.Get().GetBnetCamera(), this.m_Bones.m_InputTopLeft, this.m_Bones.m_InputBottomRight);
        UniversalInputManager.Get().UpdateTextInputBoxRect(base.gameObject, rect);
    }

    public void UpdateLayout()
    {
        TransformUtil.SetPoint(this.m_Background, Anchor.BOTTOM_LEFT, FriendListFrame.Get().m_Background, Anchor.BOTTOM_RIGHT, this.m_Offsets.m_BackgroundOffset);
        base.transform.position = this.m_Background.transform.position;
        this.m_Background.transform.localPosition = Vector3.zero;
        this.UpdateScrollCameraViewport();
        this.UpdateInputRect();
    }

    private void UpdateMessages()
    {
        foreach (ChatFrameMessageFrame frame in this.m_messageFrames)
        {
            UnityEngine.Object.Destroy(frame.gameObject);
        }
        this.m_messageFrames.Clear();
        List<BnetWhisper> whispersWithPlayer = BnetWhisperMgr.Get().GetWhispersWithPlayer(this.m_receiver);
        if ((whispersWithPlayer != null) && (whispersWithPlayer.Count > 0))
        {
            int num = Mathf.Max(whispersWithPlayer.Count - 500, 0);
            BnetWhisper whisper = whispersWithPlayer[num];
            ChatFrameMessageFrame src = this.AddWhisperMessage(whisper);
            TransformUtil.SetPoint((Component) src, Anchor.TOP_LEFT, (Component) this.m_Bones.m_MessagesTopLeft, Anchor.BOTTOM_LEFT);
            Component dst = src;
            for (int i = num + 1; i < whispersWithPlayer.Count; i++)
            {
                whisper = whispersWithPlayer[i];
                src = this.AddWhisperMessage(whisper);
                TransformUtil.SetPoint(src, Anchor.TOP_LEFT, dst, Anchor.BOTTOM_LEFT, this.m_Offsets.m_MessagePadding);
                dst = src;
            }
        }
        this.UpdateScrolling();
    }

    private void UpdateReceiver()
    {
        string bestName = this.m_receiver.GetBestName();
        if (this.m_receiver.IsOnline())
        {
            BnetProgramId bestProgramId = this.m_receiver.GetBestProgramId();
            if (bestProgramId == null)
            {
                this.m_GameIcon.gameObject.SetActive(false);
            }
            else
            {
                this.m_GameIcon.gameObject.SetActive(true);
                this.m_GameIcon.SetProgramId(bestProgramId);
            }
            this.m_NameText.Text = string.Format("<color=#{0}>{1}</color>", "5ecaf0ff", bestName);
        }
        else
        {
            this.m_GameIcon.gameObject.SetActive(false);
            this.m_NameText.Text = string.Format("<color=#{0}>{1}</color>", "999999ff", bestName);
        }
        this.UpdateChallenge();
    }

    private void UpdateScrollCameraPos()
    {
        Vector3 position = this.m_Bones.m_MessagesCameraTop.position;
        Vector3 to = this.m_Bones.m_MessagesCameraBottom.position;
        this.m_MessagesCamera.transform.position = Vector3.Lerp(position, to, this.m_scrollUnitPos);
    }

    private void UpdateScrollCameraViewport()
    {
        Camera bnetCamera = BaseUI.Get().GetBnetCamera();
        Vector3 vector = bnetCamera.WorldToViewportPoint(this.m_Bones.m_MessagesTopLeft.position);
        Vector3 vector2 = bnetCamera.WorldToViewportPoint(this.m_Bones.m_MessagesBottomRight.position);
        float width = vector2.x - vector.x;
        float height = vector.y - vector2.y;
        this.m_MessagesCamera.rect = new Rect(vector.x, vector2.y, width, height);
    }

    private void UpdateScrolling()
    {
        bool scrollEnabled = this.m_scrollEnabled;
        this.DetermineScrolling();
        this.FixupScrolling(scrollEnabled);
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
        Vector3 position = this.m_Bones.m_ScrollBarTop.transform.position;
        Vector3 vector2 = this.m_Bones.m_ScrollBarBottom.transform.position;
        if (UniversalInputManager.Get().GetInputHitInfo(((int) 1) << this.m_ScrollPlane.gameObject.layer, out hit))
        {
            float num = position.y - vector2.y;
            this.m_scrollUnitPos = Mathf.Clamp01(-(hit.point.y - position.y) / num);
        }
        else
        {
            this.m_scrollUnitPos = this.m_scrollPrevUnitPos;
        }
        this.UpdateScrollPos();
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
        if (!UniversalInputManager.Get().GetInputHitInfo(((int) 1) << this.m_MessagesBackground.layer, out hit) && !UniversalInputManager.Get().GetInputHitInfo(((int) 1) << this.m_MessagesParent.layer, out hit))
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
        Vector3 position = this.m_Bones.m_ScrollBarTop.transform.position;
        Vector3 to = this.m_Bones.m_ScrollBarBottom.transform.position;
        this.m_ScrollThumb.transform.position = Vector3.Lerp(position, to, this.m_scrollUnitPos);
    }
}


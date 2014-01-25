using System;
using System.Collections.Generic;
using UnityEngine;

public class QuickChatFrame : MonoBehaviour
{
    public GameObject m_Background;
    public QuickChatFrameBones m_Bones;
    private float m_initialLastMessageShadowScaleZ;
    private float m_initialLastMessageTextHeight;
    private PegUIElement m_inputBlocker;
    public GameObject m_LastMessageShadow;
    public UberText m_LastMessageText;
    private BnetPlayer m_receiver;
    public UberText m_ReceiverNameText;
    public DropdownControl m_RecentPlayerDropdown;
    private List<BnetPlayer> m_recentPlayers = new List<BnetPlayer>();

    private void Awake()
    {
        this.InitRecentPlayers();
        if (!this.InitReceiver())
        {
            UnityEngine.Object.Destroy(base.gameObject);
        }
        else
        {
            this.InitTransform();
            this.InitInputBlocker();
            this.InitLastMessage();
            BnetWhisperMgr.Get().AddWhisperListener(new BnetWhisperMgr.WhisperCallback(this.OnWhisper));
            BnetPresenceMgr.Get().AddPlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
        }
    }

    private BnetWhisper FindLastWhisperFromReceiver()
    {
        List<BnetWhisper> whispersWithPlayer = BnetWhisperMgr.Get().GetWhispersWithPlayer(this.m_receiver);
        if (whispersWithPlayer != null)
        {
            for (int i = whispersWithPlayer.Count - 1; i >= 0; i--)
            {
                BnetWhisper whisper = whispersWithPlayer[i];
                if (whisper.IsSpeaker(this.m_receiver))
                {
                    return whisper;
                }
            }
        }
        return null;
    }

    public BnetPlayer GetReceiver()
    {
        return this.m_receiver;
    }

    private void InitInputBlocker()
    {
        GameObject obj2 = CameraUtils.CreateInputBlocker(CameraUtils.FindFirstByLayer(base.gameObject.layer));
        obj2.name = "QuickChatInputBlocker";
        obj2.transform.parent = base.transform;
        obj2.transform.position = this.m_Bones.m_InputBlocker.position;
        this.m_inputBlocker = obj2.AddComponent<PegUIElement>();
        this.m_inputBlocker.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnInputBlockerReleased));
    }

    private void InitLastMessage()
    {
        this.m_initialLastMessageTextHeight = this.m_LastMessageText.GetTextWorldSpaceBounds().size.y;
        this.m_initialLastMessageShadowScaleZ = this.m_LastMessageShadow.transform.localScale.z;
    }

    private bool InitReceiver()
    {
        this.m_receiver = null;
        if (this.m_recentPlayers.Count == 0)
        {
            string str;
            if (BnetFriendMgr.Get().GetOnlineFriendCount() == 0)
            {
                str = GameStrings.Get("GLOBAL_CHAT_NO_FRIENDS_ONLINE");
            }
            else
            {
                str = GameStrings.Get("GLOBAL_CHAT_NO_RECENT_CONVERSATIONS");
            }
            UIStatus.Get().AddError(str);
            return false;
        }
        this.m_receiver = this.m_recentPlayers[0];
        return true;
    }

    private void InitRecentPlayerDropdown()
    {
        this.m_RecentPlayerDropdown.setItemTextCallback(new DropdownControl.itemTextCallback(this.OnRecentPlayerDropdownText));
        this.m_RecentPlayerDropdown.setItemChosenCallback(new DropdownControl.itemChosenCallback(this.OnRecentPlayerDropdownItemChosen));
        this.UpdateRecentPlayerDropdown();
        this.m_RecentPlayerDropdown.setSelection(this.m_receiver);
    }

    private void InitRecentPlayers()
    {
        this.UpdateRecentPlayers();
    }

    private void InitTransform()
    {
        base.transform.parent = BaseUI.Get().transform;
        base.transform.position = BaseUI.Get().GetQuickChatBone().position;
    }

    private void OnDestroy()
    {
        BnetWhisperMgr.Get().RemoveWhisperListener(new BnetWhisperMgr.WhisperCallback(this.OnWhisper));
        BnetPresenceMgr.Get().RemovePlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
        UniversalInputManager.Get().CancelTextInputBox(base.gameObject);
    }

    private void OnInputBlockerReleased(UIEvent e)
    {
        UnityEngine.Object.Destroy(base.gameObject);
    }

    private void OnInputCanceled()
    {
        UnityEngine.Object.Destroy(base.gameObject);
    }

    private void OnInputComplete(string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            if (this.m_receiver.IsOnline())
            {
                BnetWhisperMgr.Get().SendWhisper(this.m_receiver, input);
            }
            else
            {
                object[] args = new object[] { this.m_receiver.GetBestName() };
                string message = GameStrings.Format("GLOBAL_CHAT_RECEIVER_OFFLINE", args);
                UIStatus.Get().AddError(message);
            }
            ChatMgr.Get().AddRecentWhisperPlayer(this.m_receiver);
        }
        UnityEngine.Object.Destroy(base.gameObject);
    }

    private void OnPlayersChanged(BnetPlayerChangelist changelist, object userData)
    {
        BnetPlayerChange change = changelist.FindChange(this.m_receiver);
        if (change != null)
        {
            BnetPlayer oldPlayer = change.GetOldPlayer();
            BnetPlayer newPlayer = change.GetNewPlayer();
            if ((oldPlayer == null) || (oldPlayer.IsOnline() != newPlayer.IsOnline()))
            {
                this.UpdateReceiver();
            }
        }
    }

    private void OnRecentPlayerDropdownItemChosen(object selection, object prevSelection)
    {
        BnetPlayer player = (BnetPlayer) selection;
        this.SetReceiver(player);
    }

    private string OnRecentPlayerDropdownText(object val)
    {
        BnetPlayer player = (BnetPlayer) val;
        return player.GetBestName();
    }

    private void OnWhisper(BnetWhisper whisper, object userData)
    {
        if ((this.m_receiver != null) && whisper.IsSpeaker(this.m_receiver))
        {
            this.UpdateLastMessage();
        }
    }

    public void SetReceiver(BnetPlayer player)
    {
        if (this.m_receiver != player)
        {
            this.m_receiver = player;
            this.UpdateLastMessage();
        }
    }

    private void ShowInput()
    {
        Rect rect = CameraUtils.CreateGUIViewportRect(BaseUI.Get().GetBnetCamera(), this.m_Bones.m_InputTopLeft, this.m_Bones.m_InputBottomRight);
        UniversalInputManager.Get().UseTextInputBox(base.gameObject, rect, null, new UniversalInputManager.InputCompletedCallback(this.OnInputComplete), new UniversalInputManager.InputCanceledCallback(this.OnInputCanceled), -1);
    }

    private void Start()
    {
        this.InitRecentPlayerDropdown();
        this.UpdateLastMessage();
        this.ShowInput();
    }

    private void UpdateLastMessage()
    {
        BnetWhisper whisper = this.FindLastWhisperFromReceiver();
        if (whisper == null)
        {
            this.m_ReceiverNameText.Text = string.Empty;
            this.m_LastMessageText.Text = string.Empty;
            this.m_LastMessageShadow.SetActive(false);
        }
        else
        {
            this.m_LastMessageText.Text = whisper.GetMessage();
            TransformUtil.SetPoint((Component) this.m_LastMessageText, Anchor.BOTTOM_LEFT, (Component) this.m_Bones.m_LastMessage, Anchor.TOP_LEFT);
            this.UpdateReceiver();
            Bounds textWorldSpaceBounds = this.m_LastMessageText.GetTextWorldSpaceBounds();
            Bounds bounds2 = this.m_ReceiverNameText.GetTextWorldSpaceBounds();
            float num = Mathf.Max(textWorldSpaceBounds.max.y, bounds2.max.y);
            float num2 = Mathf.Min(textWorldSpaceBounds.min.y, bounds2.min.y);
            float num3 = num - num2;
            this.m_LastMessageShadow.SetActive(true);
            float z = (num3 * this.m_initialLastMessageShadowScaleZ) / this.m_initialLastMessageTextHeight;
            TransformUtil.SetLocalScaleZ(this.m_LastMessageShadow, z);
        }
    }

    private void UpdateReceiver()
    {
        if (this.m_receiver.IsOnline())
        {
            this.m_ReceiverNameText.TextColor = GameColors.PLAYER_NAME_ONLINE;
        }
        else
        {
            this.m_ReceiverNameText.TextColor = GameColors.PLAYER_NAME_OFFLINE;
        }
        this.m_ReceiverNameText.Text = this.m_receiver.GetBestName();
        TransformUtil.SetPoint((Component) this.m_ReceiverNameText, Anchor.BOTTOM_LEFT, (Component) this.m_LastMessageText, Anchor.TOP_LEFT, new Vector3(0f, -30f, 0f));
    }

    private void UpdateRecentPlayerDropdown()
    {
        this.m_RecentPlayerDropdown.clearItems();
        for (int i = 0; i < this.m_recentPlayers.Count; i++)
        {
            this.m_RecentPlayerDropdown.addItem(this.m_recentPlayers[i]);
        }
    }

    private void UpdateRecentPlayers()
    {
        this.m_recentPlayers.Clear();
        List<BnetPlayer> recentWhisperPlayers = ChatMgr.Get().GetRecentWhisperPlayers();
        for (int i = 0; i < recentWhisperPlayers.Count; i++)
        {
            BnetPlayer item = recentWhisperPlayers[i];
            this.m_recentPlayers.Add(item);
        }
    }
}


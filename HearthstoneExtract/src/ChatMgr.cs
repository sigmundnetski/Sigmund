using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ChatMgr : MonoBehaviour
{
    private List<ChatBubbleFrame> m_chatBubbleFrames = new List<ChatBubbleFrame>();
    public ChatMgrBubbleInfo m_ChatBubbleInfo;
    private ChatFrame m_chatFrame;
    public ChatMgrPrefabs m_Prefabs;
    private QuickChatFrame m_quickChatFrame;
    private List<BnetPlayer> m_recentWhisperPlayers = new List<BnetPlayer>();
    public const int MAX_RECENT_WHISPER_RECEIVERS = 10;
    private static ChatMgr s_instance;

    public void AddLowPriorityRecentWhisperPlayer(BnetPlayer player)
    {
        if (!this.m_recentWhisperPlayers.Contains(player))
        {
            if (this.m_recentWhisperPlayers.Count == 10)
            {
                this.m_recentWhisperPlayers.RemoveAt(this.m_recentWhisperPlayers.Count - 1);
            }
            this.m_recentWhisperPlayers.Add(player);
        }
    }

    public void AddRecentWhisperPlayer(BnetPlayer player)
    {
        <AddRecentWhisperPlayer>c__AnonStorey11C storeyc = new <AddRecentWhisperPlayer>c__AnonStorey11C {
            player = player
        };
        int index = this.m_recentWhisperPlayers.FindIndex(new Predicate<BnetPlayer>(storeyc.<>m__9));
        if (index < 0)
        {
            if (this.m_recentWhisperPlayers.Count == 10)
            {
                this.m_recentWhisperPlayers.RemoveAt(this.m_recentWhisperPlayers.Count - 1);
            }
        }
        else
        {
            this.m_recentWhisperPlayers.RemoveAt(index);
        }
        this.m_recentWhisperPlayers.Insert(0, storeyc.player);
    }

    private void Awake()
    {
        s_instance = this;
        BnetWhisperMgr.Get().AddWhisperListener(new BnetWhisperMgr.WhisperCallback(this.OnWhisper));
        BnetFriendMgr.Get().AddChangeListener(new BnetFriendMgr.ChangeCallback(this.OnFriendsChanged));
        FatalErrorMgr.Get().AddMessageListener(new FatalErrorMgr.MessageCallback(this.OnFatalErrorMessage));
    }

    private void CloseChatFrame()
    {
        if (this.m_chatFrame != null)
        {
            UnityEngine.Object.Destroy(this.m_chatFrame.gameObject);
            this.m_chatFrame = null;
        }
    }

    private void CloseQuickChatFrame()
    {
        if (this.m_quickChatFrame != null)
        {
            UnityEngine.Object.Destroy(this.m_quickChatFrame.gameObject);
            this.m_quickChatFrame = null;
        }
    }

    public static ChatMgr Get()
    {
        return s_instance;
    }

    public ChatFrame GetChatFrame()
    {
        return this.m_chatFrame;
    }

    public List<BnetPlayer> GetRecentWhisperPlayers()
    {
        return this.m_recentWhisperPlayers;
    }

    public bool HandleKeyboardInput()
    {
        if (!FatalErrorMgr.Get().HasError())
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (this.m_quickChatFrame != null)
                {
                    this.CloseQuickChatFrame();
                    return true;
                }
                if (this.m_chatFrame != null)
                {
                    this.CloseChatFrame();
                    return true;
                }
                return false;
            }
            if (this.m_chatFrame == null)
            {
                if (!Input.GetKeyUp(KeyCode.Return) && !Input.GetKeyUp(KeyCode.KeypadEnter))
                {
                    return false;
                }
                if (this.m_quickChatFrame == null)
                {
                    this.m_quickChatFrame = (QuickChatFrame) UnityEngine.Object.Instantiate(this.m_Prefabs.m_QuickChatFrame);
                    return true;
                }
            }
        }
        return false;
    }

    private void MoveChatBubbles(ChatBubbleFrame newBubbleFrame)
    {
        TransformUtil.SetPoint((Component) newBubbleFrame, Anchor.BOTTOM_LEFT, (Component) this.m_ChatBubbleInfo.m_Parent, Anchor.TOP_LEFT, Vector3.zero);
        int count = this.m_chatBubbleFrames.Count;
        if (count != 1)
        {
            Vector3[] vectorArray = new Vector3[count - 1];
            Component dst = newBubbleFrame;
            for (int i = count - 2; i >= 0; i--)
            {
                ChatBubbleFrame src = this.m_chatBubbleFrames[i];
                vectorArray[i] = src.transform.position;
                TransformUtil.SetPoint(src, Anchor.BOTTOM_LEFT, dst, Anchor.TOP_LEFT, Vector3.zero);
                dst = src;
            }
            for (int j = count - 2; j >= 0; j--)
            {
                ChatBubbleFrame frame2 = this.m_chatBubbleFrames[j];
                object[] args = new object[] { "islocal", true, "position", frame2.transform.localPosition, "time", this.m_ChatBubbleInfo.m_MoveOverSec, "easeType", this.m_ChatBubbleInfo.m_MoveOverEaseType };
                Hashtable hashtable = iTween.Hash(args);
                frame2.transform.position = vectorArray[j];
                iTween.Stop(frame2.gameObject, "move");
                iTween.MoveTo(frame2.gameObject, hashtable);
            }
        }
    }

    private void OnChatBubbleFadeOutComplete(ChatBubbleFrame bubbleFrame)
    {
        UnityEngine.Object.Destroy(bubbleFrame.gameObject);
        this.m_chatBubbleFrames.Remove(bubbleFrame);
    }

    private void OnChatBubbleScaleInComplete(ChatBubbleFrame bubbleFrame)
    {
        object[] args = new object[] { "amount", 0f, "delay", this.m_ChatBubbleInfo.m_HoldSec, "time", this.m_ChatBubbleInfo.m_FadeOutSec, "easeType", this.m_ChatBubbleInfo.m_FadeOutEaseType, "oncomplete", "OnChatBubbleFadeOutComplete", "oncompleteparams", bubbleFrame, "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.FadeTo(bubbleFrame.gameObject, hashtable);
    }

    public void OnChatFrameClosed()
    {
        this.CloseChatFrame();
        this.UpdateChatBubbleParentLayout();
    }

    private void OnFatalErrorMessage(FatalErrorMessage message, object userData)
    {
        this.CloseQuickChatFrame();
    }

    public void OnFriendListClosed()
    {
        this.CloseChatFrame();
        this.UpdateChatBubbleParentLayout();
    }

    public void OnFriendListFriendSelected(BnetPlayer friend)
    {
        if (friend == null)
        {
            this.CloseChatFrame();
            this.UpdateChatBubbleParentLayout();
        }
        else
        {
            if (this.m_chatFrame == null)
            {
                this.m_chatFrame = (ChatFrame) UnityEngine.Object.Instantiate(this.m_Prefabs.m_ChatFrame);
                this.UpdateChatBubbleParentLayout();
            }
            this.m_chatFrame.SetReceiver(friend);
        }
    }

    public void OnFriendListOpened()
    {
        this.UpdateChatBubbleParentLayout();
    }

    private void OnFriendsChanged(BnetFriendChangelist changelist, object userData)
    {
        List<BnetPlayer> removedFriends = changelist.GetRemovedFriends();
        if (removedFriends != null)
        {
            <OnFriendsChanged>c__AnonStorey11D storeyd = new <OnFriendsChanged>c__AnonStorey11D();
            using (List<BnetPlayer>.Enumerator enumerator = removedFriends.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    storeyd.friend = enumerator.Current;
                    int index = this.m_recentWhisperPlayers.FindIndex(new Predicate<BnetPlayer>(storeyd.<>m__A));
                    if (index >= 0)
                    {
                        this.m_recentWhisperPlayers.RemoveAt(index);
                    }
                }
            }
        }
    }

    private void OnWhisper(BnetWhisper whisper, object userData)
    {
        BnetPlayer theirPlayer = whisper.GetTheirPlayer();
        this.AddRecentWhisperPlayer(theirPlayer);
        if ((this.m_chatFrame == null) || !whisper.IsSpeakerOrReceiver(this.m_chatFrame.GetReceiver()))
        {
            this.SpawnChatBubble(whisper);
        }
    }

    private void SpawnChatBubble(BnetWhisper whisper)
    {
        ChatBubbleFrame item = (ChatBubbleFrame) UnityEngine.Object.Instantiate(this.m_Prefabs.m_ChatBubbleFrame);
        this.m_chatBubbleFrames.Add(item);
        item.SetWhisper(whisper);
        item.transform.parent = this.m_ChatBubbleInfo.m_Parent.transform;
        object[] args = new object[] { "scale", item.m_VisualParent.transform.localScale, "time", this.m_ChatBubbleInfo.m_ScaleInSec, "easeType", this.m_ChatBubbleInfo.m_ScaleInEaseType, "oncomplete", "OnChatBubbleScaleInComplete", "oncompleteparams", item, "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        item.m_VisualParent.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
        iTween.ScaleTo(item.m_VisualParent, hashtable);
        this.MoveChatBubbles(item);
    }

    private void Start()
    {
        this.UpdateLayout();
    }

    private void UpdateChatBubbleLayout()
    {
        int count = this.m_chatBubbleFrames.Count;
        if (count != 0)
        {
            Component parent = this.m_ChatBubbleInfo.m_Parent;
            for (int i = count - 1; i >= 0; i--)
            {
                ChatBubbleFrame src = this.m_chatBubbleFrames[i];
                TransformUtil.SetPoint(src, Anchor.BOTTOM_LEFT, parent, Anchor.TOP_LEFT, Vector3.zero);
                parent = src;
            }
        }
    }

    private void UpdateChatBubbleParentLayout()
    {
        if (this.m_chatFrame != null)
        {
            TransformUtil.SetPoint((Component) this.m_ChatBubbleInfo.m_Parent, Anchor.BOTTOM_LEFT, (Component) this.m_chatFrame, Anchor.BOTTOM_RIGHT);
        }
        else if (FriendListFrame.Get() != null)
        {
            TransformUtil.SetPoint((Component) this.m_ChatBubbleInfo.m_Parent, Anchor.BOTTOM_LEFT, (Component) FriendListFrame.Get().m_Background, Anchor.BOTTOM_RIGHT);
        }
        else
        {
            TransformUtil.SetPoint((Component) this.m_ChatBubbleInfo.m_Parent, Anchor.BOTTOM_LEFT, (Component) BnetBarFriendButton.Get(), Anchor.TOP_LEFT);
        }
    }

    public void UpdateLayout()
    {
        if (this.m_chatFrame != null)
        {
            this.m_chatFrame.UpdateLayout();
        }
        this.UpdateChatBubbleParentLayout();
    }

    [CompilerGenerated]
    private sealed class <AddRecentWhisperPlayer>c__AnonStorey11C
    {
        internal BnetPlayer player;

        internal bool <>m__9(BnetPlayer currPlayer)
        {
            return (currPlayer == this.player);
        }
    }

    [CompilerGenerated]
    private sealed class <OnFriendsChanged>c__AnonStorey11D
    {
        internal BnetPlayer friend;

        internal bool <>m__A(BnetPlayer player)
        {
            return (this.friend == player);
        }
    }
}


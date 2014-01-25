using System;
using UnityEngine;

public class ChatBubbleFrame : MonoBehaviour
{
    public UberText m_MessageText;
    public GameObject m_MyBubble;
    public UberText m_SpeakerNameText;
    public GameObject m_TheirBubble;
    public GameObject m_VisualParent;
    private BnetWhisper m_whisper;

    private void Awake()
    {
        BnetPresenceMgr.Get().AddPlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
    }

    public BnetWhisper GetWhisper()
    {
        return this.m_whisper;
    }

    private void OnDestroy()
    {
        BnetPresenceMgr.Get().RemovePlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
    }

    private void OnPlayersChanged(BnetPlayerChangelist changelist, object userData)
    {
        BnetPlayerChange change = changelist.FindChange(this.m_whisper.GetTheirGameAccountId());
        if (change != null)
        {
            BnetPlayer oldPlayer = change.GetOldPlayer();
            BnetPlayer newPlayer = change.GetNewPlayer();
            if ((oldPlayer == null) || (oldPlayer.IsOnline() != newPlayer.IsOnline()))
            {
                this.UpdateWhisper();
            }
        }
    }

    public void SetWhisper(BnetWhisper whisper)
    {
        if (this.m_whisper != whisper)
        {
            this.m_whisper = whisper;
            this.UpdateWhisper();
        }
    }

    private void UpdateWhisper()
    {
        if (this.m_whisper != null)
        {
            BnetGameAccountId speakerId = this.m_whisper.GetSpeakerId();
            BnetPlayer player = BnetPresenceMgr.Get().GetPlayer(speakerId);
            if (speakerId == BnetPresenceMgr.Get().GetMyGameAccountId())
            {
                this.m_MyBubble.SetActive(true);
                this.m_TheirBubble.SetActive(false);
            }
            else
            {
                this.m_MyBubble.SetActive(false);
                this.m_TheirBubble.SetActive(true);
                if (player.IsOnline())
                {
                    this.m_SpeakerNameText.TextColor = GameColors.PLAYER_NAME_ONLINE;
                }
                else
                {
                    this.m_SpeakerNameText.TextColor = GameColors.PLAYER_NAME_OFFLINE;
                }
            }
            this.m_SpeakerNameText.Text = player.GetBestName();
            this.m_MessageText.Text = this.m_whisper.GetMessage();
        }
    }
}


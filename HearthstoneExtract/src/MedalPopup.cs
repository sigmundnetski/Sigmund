using System;
using UnityEngine;

public class MedalPopup : DialogBase
{
    public GameObject m_bg;
    public Vector3 m_bgOffset;
    public ThreeSliceElement m_buttonFrame;
    public Vector3 m_buttonFrameOffset;
    public float m_buttonFrameWidth = 0.1f;
    public UberText m_congratulationText;
    public Vector3 m_loadPosition;
    public TournamentMedal m_medal;
    public UberText m_medalEarnedText;
    private Medal m_medalRank;
    private long m_noticeID;
    public BeveledButton m_okayButton;
    public Vector3 m_okayButtonOffset;
    public float m_padding;
    public NineSlicePopup m_popup;
    public Vector2 m_popupDimensions;
    public float m_scaleValue;
    public Vector3 m_showPosition;
    private bool TESTING;

    protected override void Awake()
    {
        base.Awake();
        this.m_popup.HideHeader();
        if (!this.TESTING)
        {
            this.m_congratulationText.Text = GameStrings.Get("GLOBAL_MEDAL_REWARD_CONGRATULATIONS");
            this.m_medalEarnedText.Text = GameStrings.Get("GLOBAL_MEDAL_REWARD_DESCRIPTION");
            this.m_okayButton.SetText(GameStrings.Get("GLOBAL_OKAY"));
            this.m_okayButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OkayButtonRelease));
        }
    }

    private void OkayButtonRelease(UIEvent e)
    {
        Network.AckNotice(this.m_noticeID);
        this.Hide();
    }

    protected override void OnHideAnimFinished()
    {
        UniversalInputManager.Get().SetGameDialogActive(false);
        base.OnHideAnimFinished();
    }

    public void SetMedalRank(Medal medal)
    {
        this.m_medalRank = medal;
    }

    public void SetNoticeID(long id)
    {
        this.m_noticeID = id;
    }

    public override void Show()
    {
        base.Show();
        this.UpdatePopup();
        base.DoShowAnimation();
        UniversalInputManager.Get().SetGameDialogActive(true);
        this.m_medal.AnimateRank(this.m_medalRank, this.m_medalRank);
    }

    public void UpdatePopup()
    {
        this.m_popup.HideHeader();
        this.m_popup.SetSize(this.m_popupDimensions.x, this.m_popupDimensions.y);
        TransformUtil.SetPoint(this.m_buttonFrame.gameObject, Anchor.BOTTOM, this.m_popup.m_background.m_bottom, Anchor.TOP, this.m_buttonFrameOffset);
        TransformUtil.SetLocalPosY(this.m_buttonFrame.gameObject, 0.01f);
        TransformUtil.SetPoint(this.m_bg.gameObject, Anchor.TOP, this.m_popup.m_background.m_top, Anchor.TOP, this.m_bgOffset);
        this.m_okayButton.SetOriginalLocalPosition();
    }
}


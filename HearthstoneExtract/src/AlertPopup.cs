using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AlertPopup : DialogBase
{
    private const float BUTTON_FRAME_WIDTH = 80f;
    public GameObject m_alertIcon;
    public Vector3 m_alertIconOffset;
    public UberText m_alertText;
    public Vector3 m_alertTextOffset;
    public ThreeSliceElement m_buttonFrame;
    public Vector3 m_buttonFrameOffset;
    public ConfirmCancelBar m_confirmCancelBar;
    public Vector3 m_loadPosition;
    public Vector3 m_noAlertTextOffset;
    public BeveledButton m_okayButton;
    public Vector3 m_okayButtonOffset;
    public float m_padding;
    public NineSlicePopup m_popup;
    public Vector2 m_popupDimensions;
    private PopupInfo m_popupInfo;
    public Vector3 m_showPosition;
    private float m_textToPopupHeightScalar;

    protected override void Awake()
    {
        base.Awake();
        this.m_okayButton.SetText(GameStrings.Get("GLOBAL_OKAY"));
        this.m_okayButton.AddEventListener(UIEventType.PRESS, new UIEvent.Handler(this.OkayButtonPress));
        this.m_confirmCancelBar.m_ConfirmButton.SetText(GameStrings.Get("GLOBAL_CONFIRM"));
        this.m_confirmCancelBar.m_ConfirmButton.AddEventListener(UIEventType.PRESS, new UIEvent.Handler(this.ConfirmButtonPress));
        this.m_confirmCancelBar.m_CancelButton.SetText(GameStrings.Get("GLOBAL_CANCEL"));
        this.m_confirmCancelBar.m_CancelButton.AddEventListener(UIEventType.PRESS, new UIEvent.Handler(this.CancelButtonPress));
    }

    private void CancelButtonPress(UIEvent e)
    {
        if (this.m_popupInfo.m_responseCallback != null)
        {
            this.m_popupInfo.m_responseCallback(Response.CANCEL, this.m_popupInfo.m_responseUserData);
        }
        this.Hide();
    }

    private void ConfirmButtonPress(UIEvent e)
    {
        if (this.m_popupInfo.m_responseCallback != null)
        {
            this.m_popupInfo.m_responseCallback(Response.CONFIRM, this.m_popupInfo.m_responseUserData);
        }
        this.Hide();
    }

    private void InitInfo()
    {
        if (this.m_popupInfo == null)
        {
            this.m_popupInfo = new PopupInfo();
        }
        if (this.m_popupInfo.m_headerText == null)
        {
            this.m_popupInfo.m_headerText = GameStrings.Get("GLOBAL_DEFAULT_ALERT_HEADER");
        }
    }

    private void OkayButtonPress(UIEvent e)
    {
        if (this.m_popupInfo.m_responseCallback != null)
        {
            this.m_popupInfo.m_responseCallback(Response.OK, this.m_popupInfo.m_responseUserData);
        }
        this.Hide();
    }

    protected override void OnHideAnimFinished()
    {
        UniversalInputManager.Get().SetSystemDialogActive(false);
        base.OnHideAnimFinished();
    }

    public void SetInfo(PopupInfo info)
    {
        this.m_popupInfo = info;
    }

    private void SetText(string text)
    {
        this.m_alertText.Text = text;
        float num = this.m_alertText.GetTextBounds().size.y / this.m_alertText.transform.lossyScale.y;
        this.m_popupDimensions.y = (this.m_textToPopupHeightScalar * num) + this.m_padding;
    }

    public override void Show()
    {
        base.Show();
        this.InitInfo();
        this.SetText(this.m_popupInfo.m_text);
        if (!this.m_popupInfo.m_showAlertIcon)
        {
            this.m_alertIcon.SetActive(false);
            this.m_alertTextOffset = this.m_noAlertTextOffset;
        }
        if (this.m_popupInfo.m_width > 0f)
        {
            this.m_alertText.Width = this.m_popupInfo.m_width;
            this.m_popupDimensions.x = this.m_popupInfo.m_width;
        }
        this.UpdateLayout();
        if (string.IsNullOrEmpty(this.m_popupInfo.m_headerText))
        {
            this.m_popup.HideHeader();
        }
        else
        {
            this.m_popup.SetHeaderText(this.m_popupInfo.m_headerText);
        }
        if (!string.IsNullOrEmpty(this.m_popupInfo.m_confirmText))
        {
            this.m_confirmCancelBar.m_ConfirmButton.SetText(this.m_popupInfo.m_confirmText);
        }
        if (!string.IsNullOrEmpty(this.m_popupInfo.m_cancelText))
        {
            this.m_confirmCancelBar.m_CancelButton.SetText(this.m_popupInfo.m_cancelText);
        }
        base.DoShowAnimation();
        UniversalInputManager.Get().SetSystemDialogActive(true);
    }

    private void Start()
    {
        this.m_alertText.Text = GameStrings.Get("GLOBAL_OKAY");
        float num = this.m_alertText.GetTextBounds().size.y / this.m_alertText.transform.lossyScale.y;
        this.m_textToPopupHeightScalar = this.m_popup.m_background.GetInitialHeight() / num;
    }

    private void UpdateLayout()
    {
        this.m_popup.SetSize(this.m_popupDimensions.x, this.m_popupDimensions.y);
        TransformUtil.SetPoint(this.m_alertIcon, Anchor.TOP_LEFT, this.m_popup.m_background.m_topLeft, Anchor.BOTTOM_RIGHT, this.m_alertIconOffset);
        TransformUtil.SetPoint(this.m_alertText, Anchor.TOP_LEFT, this.m_popup.m_background.m_topLeft, Anchor.BOTTOM_RIGHT, this.m_alertTextOffset);
        if (this.m_popupInfo.m_responseDisplay == ResponseDisplay.OK)
        {
            this.m_confirmCancelBar.m_ConfirmButton.gameObject.SetActive(false);
            this.m_confirmCancelBar.m_ConfirmButton.SetEnabled(false);
            this.m_confirmCancelBar.m_CancelButton.gameObject.SetActive(false);
            this.m_confirmCancelBar.m_CancelButton.SetEnabled(false);
            this.m_buttonFrame.gameObject.SetActive(true);
            TransformUtil.SetPoint(this.m_buttonFrame, Anchor.BOTTOM, this.m_popup.m_background.m_bottom, Anchor.TOP, this.m_buttonFrameOffset);
            TransformUtil.SetLocalPosY(this.m_buttonFrame, 0.01f);
            this.m_okayButton.gameObject.SetActive(true);
            this.m_okayButton.SetEnabled(true);
            this.m_okayButton.SetOriginalLocalPosition();
        }
        else
        {
            if (this.m_popupInfo.m_responseDisplay == ResponseDisplay.CONFIRM)
            {
                this.m_confirmCancelBar.m_ConfirmButton.gameObject.SetActive(true);
                this.m_confirmCancelBar.m_ConfirmButton.SetEnabled(true);
                this.m_confirmCancelBar.m_ConfirmButton.transform.position = this.m_confirmCancelBar.m_CenterBone.transform.position;
                this.m_confirmCancelBar.m_CancelButton.gameObject.SetActive(false);
                this.m_confirmCancelBar.m_CancelButton.SetEnabled(false);
            }
            else if (this.m_popupInfo.m_responseDisplay == ResponseDisplay.CANCEL)
            {
                this.m_confirmCancelBar.m_ConfirmButton.gameObject.SetActive(false);
                this.m_confirmCancelBar.m_ConfirmButton.SetEnabled(false);
                this.m_confirmCancelBar.m_CancelButton.gameObject.SetActive(true);
                this.m_confirmCancelBar.m_CancelButton.SetEnabled(true);
                this.m_confirmCancelBar.m_CancelButton.transform.position = this.m_confirmCancelBar.m_CenterBone.transform.position;
            }
            else
            {
                this.m_confirmCancelBar.m_ConfirmButton.gameObject.SetActive(true);
                this.m_confirmCancelBar.m_ConfirmButton.SetEnabled(true);
                this.m_confirmCancelBar.m_ConfirmButton.transform.position = this.m_confirmCancelBar.m_LeftBone.transform.position;
                this.m_confirmCancelBar.m_CancelButton.gameObject.SetActive(true);
                this.m_confirmCancelBar.m_CancelButton.SetEnabled(true);
                this.m_confirmCancelBar.m_CancelButton.transform.position = this.m_confirmCancelBar.m_RightBone.transform.position;
            }
            this.m_confirmCancelBar.m_Bar.transform.position = this.m_popup.m_background.m_bottom.transform.position;
            TransformUtil.SetLocalPosX(this.m_confirmCancelBar.m_Bar, -0.07510047f);
            this.m_buttonFrame.gameObject.SetActive(false);
            this.m_okayButton.gameObject.SetActive(false);
            this.m_okayButton.SetEnabled(false);
        }
    }

    [Serializable]
    public class ConfirmCancelBar
    {
        public GameObject m_Bar;
        public Vector3 m_BarOffset;
        public NormalButton m_CancelButton;
        public Transform m_CenterBone;
        public NormalButton m_ConfirmButton;
        public Transform m_LeftBone;
        public Transform m_RightBone;
    }

    public class PopupInfo
    {
        public string m_cancelText;
        public string m_confirmText;
        public string m_headerText;
        public string m_id;
        public AlertPopup.ResponseCallback m_responseCallback;
        public AlertPopup.ResponseDisplay m_responseDisplay;
        public object m_responseUserData;
        public bool m_showAlertIcon = true;
        public string m_text;
        public float m_width;
    }

    public enum Response
    {
        OK,
        CONFIRM,
        CANCEL
    }

    public delegate void ResponseCallback(AlertPopup.Response response, object userData);

    public enum ResponseDisplay
    {
        OK,
        CONFIRM,
        CANCEL,
        CONFIRM_CANCEL
    }
}


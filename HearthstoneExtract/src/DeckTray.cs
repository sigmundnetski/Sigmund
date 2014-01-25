using System;
using UnityEngine;

public class DeckTray : MonoBehaviour
{
    public static readonly float DECK_SLOT_HEIGHT = 0.041f;
    public static readonly float DECK_TILE_SCALE = 0.01f;
    public GameObject m_cardContainer;
    public GameObject m_completeDeckHighlight;
    public UberText m_countLabelText;
    public UberText m_countText;
    public DeckBigCard m_deckBigCard;
    public CollectionDeckBoxVisual m_deckboxPrefab;
    public GameObject m_deckContainer;
    public GameObject m_deckContentsBackground;
    public GameObject m_deckContentsDeckBoxTrayBone;
    public GameObject m_deckContentsOffscreenBone;
    public GameObject m_deleteDeckPoof;
    public NormalButton m_doneButton;
    public GameObject m_inputBlocker;
    public TextMesh m_myDecksLabel;
    public CollectionNewDeckButton m_newDeckButton;
    public TraySection m_newDeckButtonSection;
    public DeckTrayScrollbar m_scrollbar;
    public GameObject m_topCardPositionBone;
    public TraySection m_trayBgMid;
    public GameObject m_trayBgTop;
    public GameObject m_trayFrame;
    private Vector3 m_trayFrameDeckContentsLocalPosition;
    private Vector3 m_trayFrameDeckListLocalPosition;

    public void AllowInput(bool allowed)
    {
        this.m_inputBlocker.SetActive(!allowed);
    }

    private void Awake()
    {
        this.m_doneButton.SetText(GameStrings.Get("GLOBAL_DONE"));
        this.m_doneButton.SetUserOverYOffset(-0.4f);
        this.m_trayFrameDeckListLocalPosition = this.m_trayFrame.transform.localPosition;
        this.m_trayFrameDeckContentsLocalPosition = this.m_trayFrameDeckListLocalPosition;
        this.m_trayFrameDeckContentsLocalPosition.y += 0.062f;
    }

    public void ClearCountLabels()
    {
        this.m_countLabelText.Text = string.Empty;
        this.m_countText.Text = string.Empty;
    }

    public DeckBigCard GetDeckBigCard()
    {
        return this.m_deckBigCard;
    }

    public bool MouseIsOver()
    {
        return UniversalInputManager.Get().InputIsOver(base.gameObject);
    }

    public void SetCardCount(int count)
    {
        string str = GameStrings.Get("GLUE_DECK_TRAY_CARD_COUNT_LABEL");
        object[] args = new object[] { count, 30 };
        string str2 = GameStrings.Format("GLUE_DECK_TRAY_COUNT", args);
        this.m_countLabelText.Text = str;
        this.m_countText.Text = str2;
    }

    public void SetDeckCount(int count)
    {
        string str = GameStrings.Get("GLUE_DECK_TRAY_DECK_COUNT_LABEL");
        object[] args = new object[] { count, CollectionManager.Get().GetMaxNumCustomDecks() };
        string str2 = GameStrings.Format("GLUE_DECK_TRAY_COUNT", args);
        this.m_countLabelText.Text = str;
        this.m_countText.Text = str2;
    }

    public void SetMyDecksLabelText(string text)
    {
        this.m_myDecksLabel.text = text;
        TextUtils.HackAssignOutlineText(this.m_myDecksLabel, this.m_myDecksLabel.text);
    }

    public void ShowCompleteDeckHighlight(bool show)
    {
        this.m_completeDeckHighlight.SetActive(show);
    }

    public void ShowDeckContentsBackground(bool show)
    {
        this.m_deckContentsBackground.SetActive(show);
    }

    private void Start()
    {
        this.ClearCountLabels();
        this.ShowCompleteDeckHighlight(false);
    }
}


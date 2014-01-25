using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class CollectionDeckTray : MonoBehaviour
{
    private const float CARD_MOVEMENT_TIME = 0.3f;
    private readonly string CLOSE_TRAY_DOORS_COROUTINE = "CloseTrayDoorsSequentially";
    private const float DECK_BUTTON_ROTATION_TIME = 0.1f;
    private readonly string DECK_DELETED_COROUTINE = "DeckDeletedCoroutine";
    private const float DECK_HELP_BUTTON_EMPTY_DECK_Y_LOCAL_POS = -0.01194457f;
    private readonly Vector3 DECK_HELP_BUTTON_LOCAL_POS = new Vector3(-0.0192137f, 0f, 0f);
    private readonly Vector3 DECK_HELP_BUTTON_LOCAL_SCALE = new Vector3(0.015f, 0.015f, 0.015f);
    private const float DECK_HELP_BUTTON_Y_TILE_OFFSET = -0.04915909f;
    private readonly Vector3 DECKBOX_LOCAL_EULER_ANGLES = new Vector3(90f, 180f, 0f);
    private const float DELETE_DECK_ANIM_TIME = 0.5f;
    private Vector3 m_cardContainerOriginalLocalPosition;
    private long m_currentlyViewingDeckID;
    private CollectionDeckBoxVisual m_deckboxBeingEdited;
    private List<CollectionDeckBoxVisual> m_deckBoxes;
    public NormalButton m_deckHelpButton;
    private CollectionDeckInfo m_deckInfoTooltip;
    public GameObject m_deckInfoTooltipBone;
    public GameObject m_deckNameBg;
    private List<CollectionDeckTileVisual> m_deckTiles = new List<CollectionDeckTileVisual>();
    private DeckTray m_deckTray;
    private Notification m_deckValidationPopup;
    public Transform m_inputBottomRight;
    public Transform m_inputTopLeft;
    private bool m_isShowingDeckContents;
    private int m_loadCardPrefabsRequestID;
    private int m_numCardPrefabsToLoad;
    private List<TraySection> m_traySections;
    private const int MAX_DECK_NAME_LENGTH = 0x18;
    private const int NUM_DECKBOXES_TO_DISPLAY = 11;
    private const int NUM_DECKBOXES_VISIBLE_IN_SCROLL_AREA = 9;
    private readonly string OPEN_TRAY_DOORS_COROUTINE = "OpenTrayDoorsSequentially";
    private readonly string POSITION_CONTENTS_VIEW_COROUTINE = "PositionForContentsView";
    private readonly string POSITION_LIST_VIEW_COROUTINE = "PositionForListView";
    private static CollectionDeckTray s_instance;
    private const float TIME_BETWEEN_TRAY_DOOR_ANIMS = 0.015f;
    private const float TO_CONTENTS_VIEW_ANIM_TIME = 0.15f;
    private const float TO_LIST_VIEW_ANIM_TIME = 0.2f;
    private const float TRAY_MATERIAL_Y_OFFSET = -0.0825f;

    public bool AddCard(string cardID, CardFlair cardFlair, CollectionDeckTileVisual deckTileToRemove)
    {
        SoundManager.Get().LoadAndPlay("collection_manager_place_card_in_deck", base.gameObject);
        CollectionDeck deck = this.GetDeck();
        int totalCardCount = deck.GetTotalCardCount();
        if (totalCardCount == 30)
        {
            if (deckTileToRemove == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("CollectionDeckTray.AddCard(): Cannot add card {0} (flair {1}) without removing one first.", cardID, cardFlair));
                return false;
            }
            string str = deckTileToRemove.GetCardID();
            CardFlair flair = deckTileToRemove.GetCardFlair();
            if (!deck.RemoveCard(str, flair.Premium))
            {
                object[] args = new object[] { cardID, cardFlair, str, flair };
                UnityEngine.Debug.LogWarning(string.Format("CollectionDeckTray.AddCard({0},{1}): Tried to remove card {2} with flair {3}, but it failed!", args));
                return false;
            }
        }
        if (!deck.AddCard(cardID, cardFlair.Premium))
        {
            UnityEngine.Debug.LogWarning(string.Format("CollectionDeckTray.AddCard({0},{1}): deck.AddCard failed!", cardID, cardFlair));
            return false;
        }
        totalCardCount++;
        if (totalCardCount == 30)
        {
            DeckHelper.Get().Hide();
        }
        this.m_deckInfoTooltip.UpdateManaCurve();
        this.UpdateCardList(false, cardID, cardFlair);
        this.UpdateDeckHighlight(deck);
        CollectionManagerDisplay.Get().UpdateCurrentPageCardLocks();
        if ((!Options.Get().GetBool(Option.HAS_ADDED_CARDS_TO_DECK, false) && (deck.GetTotalCardCount() >= 2)) && !DeckHelper.Get().IsActive())
        {
            NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_CM_PAGEFLIP_28"), "VO_INNKEEPER_CM_PAGEFLIP_28");
            Options.Get().SetBool(Option.HAS_ADDED_CARDS_TO_DECK, true);
        }
        return true;
    }

    private void AnimateCardListEntrance()
    {
        if (this.IsShowingDeckContents())
        {
            object[] args = new object[] { "position", this.m_deckTray.m_topCardPositionBone.transform.localPosition, "isLocal", true, "time", 0.3f, "easeType", iTween.EaseType.easeOutQuad, "oncomplete", "OnCardEntranceComplete", "oncompletetarget", base.gameObject, "name", "position" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(this.m_deckTray.m_cardContainer, "position");
            iTween.MoveTo(this.m_deckTray.m_cardContainer, hashtable);
        }
    }

    private void AnimateCardListExit(long previouslyViewedDeckID)
    {
        if (!this.IsShowingDeckContents())
        {
            this.ShowDeckHelpButtonIfNeeded();
            List<CollectionDeckSlot> slots = CollectionManager.Get().GetDeck(previouslyViewedDeckID).GetSlots();
            Vector3 cardContainerOriginalLocalPosition = this.m_cardContainerOriginalLocalPosition;
            cardContainerOriginalLocalPosition.y += DeckTray.DECK_SLOT_HEIGHT * (slots.Count + 2);
            object[] args = new object[] { "position", cardContainerOriginalLocalPosition, "isLocal", true, "time", 0.3f, "easeType", iTween.EaseType.easeInQuad, "oncomplete", "OnCardListExitComplete", "oncompletetarget", base.gameObject, "oncompleteparams", previouslyViewedDeckID, "name", "position" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(this.m_deckTray.m_cardContainer, "position");
            iTween.MoveTo(this.m_deckTray.m_cardContainer, hashtable);
        }
    }

    private void AnimateTransitionToDeckContentsView(long deckID)
    {
        if (this.IsShowingDeckContents())
        {
            this.CloseNewDeckTrayThenOtherTrays(deckID);
        }
    }

    private void AnimateTransitionToDeckListView(long previouslyViewedDeckID)
    {
        if (!this.IsShowingDeckContents())
        {
            this.AnimateCardListExit(previouslyViewedDeckID);
        }
    }

    private void AnimateTransitionToNewDeckContentsView(long newDeckID)
    {
        List<TrayAndDeckBoxCallbackData> list = new List<TrayAndDeckBoxCallbackData>();
        for (int i = this.m_traySections.Count - 1; i >= 0; i--)
        {
            TraySection section = this.m_traySections[i];
            if (section.IsOpen())
            {
                TrayAndDeckBoxCallbackData data3 = new TrayAndDeckBoxCallbackData {
                    m_traySection = section,
                    m_deckBox = this.m_deckBoxes[i]
                };
                TrayAndDeckBoxCallbackData item = data3;
                list.Add(item);
            }
        }
        CloseTraysSequentiallyData data4 = new CloseTraysSequentiallyData {
            m_traysToClose = list,
            m_deckIdToOpen = newDeckID,
            m_onTrayDoorsClosedCallback = new OnTrayDoorsClosed(this.OnTrayDoorsClosedForNewDeck)
        };
        CloseTraysSequentiallyData data2 = data4;
        base.StopCoroutine(this.CLOSE_TRAY_DOORS_COROUTINE);
        base.StartCoroutine(this.CLOSE_TRAY_DOORS_COROUTINE, data2);
    }

    private bool AssignNewDeckToBox(long newDeckID)
    {
        CollectionDeck deck = CollectionManager.Get().GetDeck(newDeckID);
        CollectionDeckBoxVisual visual = null;
        for (int i = 0; i < this.m_deckBoxes.Count; i++)
        {
            if (this.m_deckBoxes[i].GetDeckID() == -1L)
            {
                visual = this.m_deckBoxes[i];
                break;
            }
        }
        if (visual == null)
        {
            Log.Rachelle.Print(string.Format("CollectionDeckTray.AssignNewDeckToBox(): no deck box available for new deck {0} (ID {1})", deck.Name, deck.ID));
            return false;
        }
        visual.SetDeckName(deck.Name);
        visual.SetDeckID(deck.ID);
        visual.SetHeroCardID(deck.HeroCardID);
        visual.SetEnabled(true);
        return true;
    }

    [DebuggerHidden]
    private IEnumerator AutoAddCardsWithTiming(List<RDMDeckEntry> newCards)
    {
        return new <AutoAddCardsWithTiming>c__Iterator6 { newCards = newCards, <$>newCards = newCards, <>f__this = this };
    }

    private void Awake()
    {
        s_instance = this;
        if (base.gameObject.audio == null)
        {
            base.gameObject.AddComponent("AudioSource");
        }
        AssetLoader.Get().LoadGameObject("DeckTray", new AssetLoader.GameObjectCallback(this.OnDeckTrayLoaded));
        AssetLoader.Get().LoadActor("DeckInfo", new AssetLoader.GameObjectCallback(this.OnDeckInfoTooltipLoaded));
        this.m_deckHelpButton.SetText(GameStrings.Get("GLUE_COLLECTION_DECK_HELP_BUTTON"));
    }

    private void CloseAllTraysExceptLoadingDeck(long deckID)
    {
        if (this.IsShowingDeckContents())
        {
            List<TrayAndDeckBoxCallbackData> list = new List<TrayAndDeckBoxCallbackData>();
            for (int i = this.m_traySections.Count - 1; i >= 0; i--)
            {
                TraySection section = this.m_traySections[i];
                if (section.IsOpen())
                {
                    CollectionDeckBoxVisual visual = this.m_deckBoxes[i];
                    if (visual.GetDeckID() != deckID)
                    {
                        TrayAndDeckBoxCallbackData data3 = new TrayAndDeckBoxCallbackData {
                            m_traySection = section,
                            m_deckBox = visual
                        };
                        TrayAndDeckBoxCallbackData item = data3;
                        list.Add(item);
                    }
                }
            }
            CloseTraysSequentiallyData data4 = new CloseTraysSequentiallyData {
                m_traysToClose = list,
                m_deckIdToOpen = deckID,
                m_onTrayDoorsClosedCallback = new OnTrayDoorsClosed(this.ScaleUpDeckBoxThenPositionTray)
            };
            CloseTraysSequentiallyData data2 = data4;
            base.StopCoroutine(this.CLOSE_TRAY_DOORS_COROUTINE);
            base.StartCoroutine(this.CLOSE_TRAY_DOORS_COROUTINE, data2);
        }
    }

    private void CloseNewDeckTrayThenOtherTrays(long deckID)
    {
        if (this.IsShowingDeckContents())
        {
            if (!this.m_deckTray.m_newDeckButtonSection.IsOpen())
            {
                this.CloseAllTraysExceptLoadingDeck(deckID);
            }
            else
            {
                this.m_deckTray.m_newDeckButton.PlayPopDownAnimation(new CollectionNewDeckButton.DelOnAnimationFinished(this.OnNewDeckPoppedDown), deckID);
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator CloseTrayDoorsSequentially(CloseTraysSequentiallyData closeTraysSequentiallyData)
    {
        return new <CloseTrayDoorsSequentially>c__Iterator8 { closeTraysSequentiallyData = closeTraysSequentiallyData, <$>closeTraysSequentiallyData = closeTraysSequentiallyData, <>f__this = this };
    }

    private void CreateDeckBoxes()
    {
        for (int i = 0; i < 11; i++)
        {
            CollectionDeckBoxVisual item = (CollectionDeckBoxVisual) UnityEngine.Object.Instantiate(this.m_deckTray.m_deckboxPrefab);
            Transform transform = this.m_traySections[i].transform.FindChild("Deck_Locator").transform;
            item.transform.parent = transform;
            item.transform.localPosition = CollectionDeckBoxVisual.POPPED_DOWN_LOCAL_POS;
            item.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
            item.transform.localEulerAngles = this.DECKBOX_LOCAL_EULER_ANGLES;
            item.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.DeckBoxVisualOver));
            item.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.DeckBoxVisualOut));
            item.AddEventListener(UIEventType.PRESS, new UIEvent.Handler(this.DeckBoxVisualPress));
            item.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.DeckBoxVisualRelease));
            item.SetOriginalButtonPosition();
            item.HideBanner();
            if (UniversalInputManager.IsTouchDevice != null)
            {
                item.SetReceiveOverWithMouseDown(true);
            }
            item.SetEnabled(true);
            this.m_deckBoxes.Add(item);
        }
    }

    private void CreateDeckTraySections()
    {
        Transform transform = this.m_deckTray.m_newDeckButtonSection.transform;
        Vector3 localPosition = transform.localPosition;
        TraySection section = null;
        for (int i = 0; i < 11; i++)
        {
            TraySection item = (TraySection) UnityEngine.Object.Instantiate(this.m_deckTray.m_trayBgMid);
            item.transform.parent = this.m_deckTray.m_deckContainer.transform;
            item.transform.localScale = transform.localScale;
            item.transform.localEulerAngles = transform.localEulerAngles;
            if (i == 0)
            {
                item.transform.localPosition = localPosition;
            }
            else
            {
                TransformUtil.SetPoint(item.gameObject, Anchor.FRONT, section.gameObject, Anchor.BACK);
            }
            Material material = null;
            foreach (Material material2 in item.m_door.renderer.materials)
            {
                if (material2.name.Equals("DeckTray", StringComparison.OrdinalIgnoreCase) || material2.name.Equals("DeckTray (Instance)", StringComparison.OrdinalIgnoreCase))
                {
                    material = material2;
                    break;
                }
            }
            Vector2 vector2 = new Vector2(0f, -0.0825f * i);
            item.renderer.material.mainTextureOffset = vector2;
            if (material != null)
            {
                material.mainTextureOffset = vector2;
            }
            section = item;
            this.m_traySections.Add(item);
        }
        this.CreateDeckBoxes();
    }

    private void DeckBoxVisualOut(UIEvent e)
    {
        CollectionDeckBoxVisual element = (CollectionDeckBoxVisual) e.GetElement();
        if ((UniversalInputManager.IsTouchDevice == null) && !UniversalInputManager.Get().InputIsOver(element.m_deleteButton.gameObject))
        {
            element.ShowDeleteButton(false);
        }
        if (this.IsShowingDeckContents())
        {
            this.m_deckInfoTooltip.Hide();
        }
    }

    private void DeckBoxVisualOver(UIEvent e)
    {
        CollectionDeckBoxVisual element = (CollectionDeckBoxVisual) e.GetElement();
        if (this.IsShowingDeckContents())
        {
            this.m_deckInfoTooltip.Show();
        }
        else if (UniversalInputManager.IsTouchDevice == null)
        {
            element.ShowDeleteButton(true);
        }
    }

    private void DeckBoxVisualPress(UIEvent e)
    {
        CollectionDeckBoxVisual element = (CollectionDeckBoxVisual) e.GetElement();
        this.m_deckboxBeingEdited = element;
        if (this.IsShowingDeckContents())
        {
            if (UniversalInputManager.IsTouchDevice == null)
            {
                this.EnterDeckRenameMode();
            }
        }
        else
        {
            element.enabled = false;
            long deckID = element.GetDeckID();
            this.LoadDeck(deckID);
        }
    }

    private void DeckBoxVisualRelease(UIEvent e)
    {
        CollectionDeckBoxVisual element = (CollectionDeckBoxVisual) e.GetElement();
        element.enabled = true;
    }

    [DebuggerHidden]
    private IEnumerator DeckDeletedCoroutine(long deckID)
    {
        return new <DeckDeletedCoroutine>c__Iterator5 { deckID = deckID, <$>deckID = deckID, <>f__this = this };
    }

    private void DeckHelpButtonPress(UIEvent e)
    {
        if (DeckHelper.Get() == null)
        {
            UnityEngine.Debug.LogWarning("CollectionDeckTray.OnDeckHelpButtonPressed(): DeckHelper is null!");
        }
        else
        {
            DeckHelper.Get().Show();
        }
    }

    public void DeleteDeck(long deckID)
    {
        CollectionManager.Get().SendDeleteDeck(deckID);
    }

    private void DestroyDeckValidationPopUp()
    {
        if (this.m_deckValidationPopup != null)
        {
            NotificationManager.Get().DestroyNotification(this.m_deckValidationPopup, 0f);
            this.m_deckValidationPopup = null;
        }
    }

    private void DoneButtonPress(UIEvent e)
    {
        if (!this.IsShowingDeckContents())
        {
            foreach (CollectionDeckTileVisual visual in this.m_deckTiles)
            {
                visual.Hide();
            }
            CollectionManagerDisplay.Get().Exit();
        }
        else
        {
            DeckHelper.Get().Hide();
            CollectionDeckViolationDeckSize collectionDeckViolationDeckOverflow = CollectionDeckValidator.GetCollectionDeckViolationDeckOverflow(CollectionManager.Get().GetDeck(this.GetCurrentlyViewedDeckID()), false);
            if ((collectionDeckViolationDeckOverflow != null) && (collectionDeckViolationDeckOverflow.ViolationType == CollectionDeckViolationType.DECK_UNDERFLOW))
            {
                int num = 30 - collectionDeckViolationDeckOverflow.TotalCardCount;
                AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
                    m_headerText = GameStrings.Get("GLUE_COLLECTION_DECK_INVALID_POPUP_HEADER")
                };
                object[] args = new object[] { num };
                info.m_text = GameStrings.Format("GLUE_COLLECTION_DECK_INVALID_POPUP_MESSAGE", args);
                info.m_cancelText = GameStrings.Get("GLUE_COLLECTION_DECK_SAVE_ANYWAY");
                info.m_confirmText = GameStrings.Get("GLUE_COLLECTION_DECK_FINISH_FOR_ME");
                info.m_showAlertIcon = true;
                info.m_responseDisplay = AlertPopup.ResponseDisplay.CONFIRM_CANCEL;
                info.m_responseCallback = new AlertPopup.ResponseCallback(this.OnInvalidDeckPopupResponse);
                DialogManager.Get().ShowPopup(info);
            }
            else
            {
                this.SaveCurrentDeckAndEnterDeckListMode();
            }
        }
    }

    private void EnterDeckContentsMode(long deckID, bool isNewDeck)
    {
        if (!this.IsShowingDeckContents())
        {
            this.m_deckTray.AllowInput(false);
            this.m_isShowingDeckContents = true;
            this.StopAllDeckListCoroutines();
            this.m_deckTray.m_scrollbar.DisableInputUntilInit();
            this.m_deckTray.m_doneButton.SetText(GameStrings.Get("GLOBAL_DONE"));
            this.SetDeckID(deckID);
            CollectionDeck deck = CollectionManager.Get().GetDeck(deckID);
            if (isNewDeck)
            {
                if (!this.AssignNewDeckToBox(deckID))
                {
                    this.m_isShowingDeckContents = false;
                    this.m_deckboxBeingEdited = null;
                    this.m_deckTray.AllowInput(true);
                }
                else
                {
                    this.UpdateCardList(true);
                    this.AnimateTransitionToNewDeckContentsView(deckID);
                }
            }
            else
            {
                List<CollectionDeckSlot> slots = deck.GetSlots();
                this.LoadCardPrefabs(slots);
                this.AnimateTransitionToDeckContentsView(deckID);
            }
        }
    }

    public void EnterDeckListMode()
    {
        if (this.IsShowingDeckContents())
        {
            this.m_isShowingDeckContents = false;
            this.m_deckboxBeingEdited = null;
            this.StopAllDeckContentsCoroutines();
            this.m_deckTray.m_scrollbar.DisableInputUntilInit();
            this.m_deckTray.m_doneButton.SetText(GameStrings.Get("GLOBAL_BACK"));
            UniversalInputManager.Get().CancelTextInputBox(base.gameObject);
            if (DeckHelper.Get() != null)
            {
                DeckHelper.Get().Hide();
            }
            this.UpdateDeckCountDisplay();
            this.ShowCompleteDeckHighlight(false);
            long currentlyViewedDeckID = this.GetCurrentlyViewedDeckID();
            this.SetDeckID(-1L);
            if (CollectionManagerDisplay.Get() != null)
            {
                CollectionManagerDisplay.Get().OnDoneEditingDeck();
            }
            this.AnimateTransitionToDeckListView(currentlyViewedDeckID);
        }
    }

    private void EnterDeckRenameMode()
    {
        if (this.IsShowingDeckContents())
        {
            this.m_deckboxBeingEdited.HideDeckName();
            Rect rect = CameraUtils.CreateGUIViewportRect(Box.Get().GetCamera(), this.m_inputTopLeft, this.m_inputBottomRight);
            Font trueTypeFont = this.m_deckboxBeingEdited.GetDeckNameText().TrueTypeFont;
            UniversalInputManager.Get().UseTextInputBox(base.gameObject, rect, new UniversalInputManager.InputCompletedCallback(this.SetDeckName), 0x18, trueTypeFont);
        }
    }

    private void FinishMyDeckPress()
    {
        this.DestroyDeckValidationPopUp();
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_AUTO_COMPLETE_DECK_CLICKED);
        RDM_Deck currentDeck = RandomDeckMaker.ConvertCollectionDeckToRDMDeck(CollectionManager.Get().GetDeck(this.GetCurrentlyViewedDeckID()));
        int count = currentDeck.deckList.Count;
        List<RDMDeckEntry> deckList = RandomDeckMaker.FinishMyDeck(currentDeck).deckList;
        List<RDMDeckEntry> range = deckList.GetRange(count, deckList.Count - count);
        base.StartCoroutine(this.AutoAddCardsWithTiming(range));
    }

    public static CollectionDeckTray Get()
    {
        return s_instance;
    }

    public long GetCurrentlyViewedDeckID()
    {
        return this.m_currentlyViewingDeckID;
    }

    private CollectionDeck GetDeck()
    {
        return CollectionManager.Get().GetDeck(this.GetCurrentlyViewedDeckID());
    }

    public DeckBigCard GetDeckBigCard()
    {
        return this.m_deckTray.GetDeckBigCard();
    }

    private CollectionDeckTileVisual GetDeckTileVisual(int index)
    {
        if (index == this.m_deckTiles.Count)
        {
            CollectionDeckTileVisual item = new GameObject("DeckTileVisual" + index) { transform = { parent = this.m_deckTray.m_cardContainer.transform, localScale = new Vector3(DeckTray.DECK_TILE_SCALE, DeckTray.DECK_TILE_SCALE * 2f, DeckTray.DECK_TILE_SCALE) } }.AddComponent<CollectionDeckTileVisual>();
            this.m_deckTiles.Insert(index, item);
            return item;
        }
        return this.m_deckTiles[index];
    }

    public CollectionDeckTileVisual GetDeckTileVisual(string cardID)
    {
        foreach (CollectionDeckTileVisual visual in this.m_deckTiles)
        {
            if ((((visual != null) && (visual.GetActor() != null)) && (visual.GetActor().GetEntityDef() != null)) && (visual.GetActor().GetEntityDef().GetCardId() == cardID))
            {
                return visual;
            }
        }
        return null;
    }

    public Vector3 GetNewDeckButtonPosition()
    {
        Vector3 vector = new Vector3(0f, 0f, 0f);
        if (this.m_deckTray == null)
        {
            return vector;
        }
        if (this.m_deckTray.m_newDeckButton == null)
        {
            return vector;
        }
        return this.m_deckTray.m_newDeckButton.transform.position;
    }

    private bool GetTraySectionAndDeckBox(long deckID, out TraySection traySection, out CollectionDeckBoxVisual deckBox)
    {
        int index = -1;
        return this.GetTraySectionAndDeckBox(deckID, out traySection, out deckBox, out index);
    }

    private bool GetTraySectionAndDeckBox(long deckID, out TraySection traySection, out CollectionDeckBoxVisual deckBox, out int index)
    {
        traySection = null;
        deckBox = null;
        index = -1;
        for (int i = 0; i < this.m_deckBoxes.Count; i++)
        {
            if (this.m_deckBoxes[i].GetDeckID() == deckID)
            {
                deckBox = this.m_deckBoxes[i];
                traySection = this.m_traySections[i];
                index = i;
                return true;
            }
        }
        return false;
    }

    public bool HandleDeletedCardDeckUpdate(string cardID, CardFlair flair)
    {
        if (!this.IsShowingDeckContents())
        {
            return false;
        }
        this.m_deckInfoTooltip.UpdateManaCurve();
        this.UpdateCardList(false, cardID, flair);
        this.UpdateDeckHighlight(this.GetDeck());
        CollectionManagerDisplay.Get().UpdateCurrentPageCardLocks();
        return true;
    }

    private void InitDeckContentsComponents()
    {
        this.m_deckTray.m_doneButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.DoneButtonPress));
    }

    private void InitDeckListComponents()
    {
        this.m_deckBoxes = new List<CollectionDeckBoxVisual>();
        this.m_traySections = new List<TraySection>();
        this.CreateDeckTraySections();
        this.m_deckTray.m_newDeckButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.NewDeckButtonPress));
    }

    public bool IsLoaded()
    {
        return ((this.m_deckTray != null) && (this.m_deckInfoTooltip != null));
    }

    public bool IsShowingDeckContents()
    {
        return this.m_isShowingDeckContents;
    }

    private void LoadCardPrefabs(List<CollectionDeckSlot> deckSlots)
    {
        if (this.IsShowingDeckContents())
        {
            if (deckSlots.Count == 0)
            {
                this.UpdateCardList(true);
            }
            else
            {
                this.m_loadCardPrefabsRequestID++;
                this.m_numCardPrefabsToLoad = deckSlots.Count;
                for (int i = 0; i < deckSlots.Count; i++)
                {
                    CollectionDeckSlot slot = deckSlots[i];
                    if (slot.Count == 0)
                    {
                        Log.Rachelle.Print(string.Format("CollectionDeckTray.LoadCardPrefabs(): Slot {0} of deck is empty! Skipping...", i));
                    }
                    else
                    {
                        CollectionCardCache.Get().LoadCardDef(slot.CardID, new CollectionCardCache.LoadCardDefCallback(this.OnCardPrefabLoaded), this.m_loadCardPrefabsRequestID);
                    }
                }
            }
        }
    }

    private void LoadDeck(long deckID)
    {
        CollectionManagerDisplay.Get().RequestContentsToShowDeck(deckID);
    }

    public bool MouseIsOver()
    {
        if (!this.IsLoaded())
        {
            return false;
        }
        return this.m_deckTray.MouseIsOver();
    }

    private void NewDeckButtonPress(UIEvent e)
    {
        if (!this.IsShowingDeckContents())
        {
            this.m_deckTray.m_newDeckButton.PlayPopDownAnimation();
            CollectionManagerDisplay.Get().EnterSelectNewDeckHeroMode();
            AssetLoader.Get().LoadActor("HeroPicker", new AssetLoader.GameObjectCallback(this.OnHeroPickerLoaded));
            NotificationManager.Get().DestroyAllPopUps();
        }
    }

    private void OnCardEntranceComplete()
    {
        this.UpdateDeckHighlight(this.GetDeck());
        this.ShowDeckHelpButtonIfNeeded();
        this.m_deckTray.m_scrollbar.Init(this.m_deckTray.m_cardContainer, true);
        this.m_deckTray.AllowInput(true);
    }

    private void OnCardListExitComplete(long previouslyViewedDeckID)
    {
        if (!this.IsShowingDeckContents())
        {
            CollectionDeckBoxVisual visual;
            TraySection section;
            if (!this.GetTraySectionAndDeckBox(previouslyViewedDeckID, out section, out visual))
            {
                Log.Rachelle.Print(string.Format("CollectionDeckTray.PositionClosedDeckBoxThenPositionTray(): Could not find deck box for deck ID {0} -- cannot animate into deck list mode!", previouslyViewedDeckID));
            }
            else
            {
                base.StopCoroutine(this.POSITION_LIST_VIEW_COROUTINE);
                base.StartCoroutine(this.POSITION_LIST_VIEW_COROUTINE, visual);
            }
        }
    }

    private void OnCardPrefabLoaded(string cardID, CardDef cardDef, object callbackData)
    {
        int num = (int) callbackData;
        if (num == this.m_loadCardPrefabsRequestID)
        {
            this.m_numCardPrefabsToLoad--;
            if (this.m_numCardPrefabsToLoad == 0)
            {
                this.UpdateCardList(true);
            }
        }
    }

    public void OnCreateDeckFailed()
    {
        this.OnHeroPickerCanceled();
    }

    private void OnDeckBoxScaledUp(object callbackData)
    {
        if (this.IsShowingDeckContents())
        {
            CollectionDeckBoxVisual visual = callbackData as CollectionDeckBoxVisual;
            base.StopCoroutine(this.POSITION_CONTENTS_VIEW_COROUTINE);
            base.StartCoroutine(this.POSITION_CONTENTS_VIEW_COROUTINE, visual);
        }
    }

    public void OnDeckDeleted(long deckID)
    {
        base.StopCoroutine(this.DECK_DELETED_COROUTINE);
        base.StartCoroutine(this.DECK_DELETED_COROUTINE, deckID);
    }

    private void OnDeckHelperStateChanged(bool isActive)
    {
        this.ShowDeckHelpButtonIfNeeded();
    }

    private void OnDeckInfoTooltipLoaded(string actorName, GameObject gameObject, object callbackData)
    {
        if (gameObject == null)
        {
            UnityEngine.Debug.LogError("CollectionDeckTray.OnDeckInfoTooltipLoaded(): gameObject is null");
        }
        else
        {
            this.m_deckInfoTooltip = gameObject.GetComponent<CollectionDeckInfo>();
            if (this.m_deckInfoTooltip == null)
            {
                UnityEngine.Debug.LogError("CollectionDeckTray.OnDeckInfoTooltipLoaded(): gameObject does not contain CollectionDeckInfo component");
            }
            else
            {
                this.m_deckInfoTooltip.transform.parent = base.transform;
                this.m_deckInfoTooltip.transform.localScale = this.m_deckInfoTooltipBone.transform.localScale;
                this.m_deckInfoTooltip.transform.localPosition = this.m_deckInfoTooltipBone.transform.localPosition;
                this.m_deckInfoTooltip.Hide();
            }
        }
    }

    public void OnDeckListReady()
    {
        List<CollectionDeck> list = new List<CollectionDeck>(CollectionManager.Get().GetDecks().Values);
        for (int i = 0; i < list.Count; i++)
        {
            if (i == this.m_deckBoxes.Count)
            {
                break;
            }
            CollectionDeck deck = list[i];
            CollectionDeckBoxVisual visual = this.m_deckBoxes[i];
            visual.SetDeckName(deck.Name);
            visual.SetDeckID(deck.ID);
            visual.SetHeroCardID(deck.HeroCardID);
        }
        this.OpenAllTrayDoorsSequentially();
    }

    private void OnDeckPoppedDown(object callbackData)
    {
        if (this.IsShowingDeckContents())
        {
            TrayAndDeckBoxCallbackData data = callbackData as TrayAndDeckBoxCallbackData;
            if (data != null)
            {
                data.m_traySection.CloseDoor();
            }
        }
    }

    public void OnDeckRenamed(long deckID, string newName)
    {
        TraySection section;
        CollectionDeckBoxVisual visual;
        if (this.GetTraySectionAndDeckBox(deckID, out section, out visual) && !visual.m_deckName.Text.Equals(newName))
        {
            UnityEngine.Debug.LogWarning(string.Format("CollectionDeckTray.OnDeckRenamed(): The deck box name for deck ID {0} ({1}) does not match the name saved in the database ({2})! Overwriting deck box name...", deckID, visual.m_deckName.Text, newName));
            visual.SetDeckName(newName);
        }
    }

    private void OnDeckTrayLoaded(string actorName, GameObject gameObject, object callbackData)
    {
        if (gameObject == null)
        {
            UnityEngine.Debug.LogError("CollectionDeckTray.OnDeckTrayLoaded(): gameObject is null");
        }
        else
        {
            this.m_deckTray = gameObject.GetComponent<DeckTray>();
            if (this.m_deckTray == null)
            {
                UnityEngine.Debug.LogError("CollectionDeckTray.OnDeckTrayLoaded(): gameObject does not contain DeckTray component");
            }
            else
            {
                this.m_deckTray.transform.parent = base.transform;
                this.m_deckTray.transform.localPosition = Vector3.zero;
                this.m_deckTray.AllowInput(true);
                this.m_deckTray.m_scrollbar.Hide();
                this.m_deckTray.m_scrollbar.m_thumb.RegisterStartDraggingListener(new ScrollBarThumb.DelStartDraggingListener(CollectionInputMgr.Get().SetScrollbar));
                this.m_deckTray.ShowDeckContentsBackground(false);
                this.m_deckTray.m_deckContentsBackground.transform.position = this.m_deckTray.m_deckContentsOffscreenBone.transform.position;
                this.m_deckTray.SetMyDecksLabelText(GameStrings.Get("GLUE_COLLECTION_MY_DECKS"));
                this.m_deckTray.m_doneButton.SetText(GameStrings.Get("GLOBAL_BACK"));
                this.UpdateDeckCountDisplay();
                this.m_cardContainerOriginalLocalPosition = this.m_deckTray.m_cardContainer.transform.localPosition;
                this.m_deckHelpButton.transform.parent = this.m_deckTray.m_cardContainer.transform;
                this.m_deckHelpButton.transform.localScale = this.DECK_HELP_BUTTON_LOCAL_SCALE;
                this.m_deckHelpButton.transform.localPosition = this.DECK_HELP_BUTTON_LOCAL_POS;
                this.m_deckHelpButton.SetOriginalButtonPosition();
                this.ShowDeckHelpButtonIfNeeded();
                if (DeckHelper.Get() != null)
                {
                    DeckHelper.Get().RegisterStateChangedListener(new DeckHelper.DelStateChangedListener(this.OnDeckHelperStateChanged));
                }
                this.InitDeckContentsComponents();
                this.InitDeckListComponents();
            }
        }
    }

    public void OnHeroPickerCanceled()
    {
        this.m_deckTray.m_newDeckButton.PlayPopUpAnimation();
        CollectionManagerDisplay.Get().ExitSelectNewDeckHeroMode();
    }

    public void OnHeroPickerHeroSelected(TAG_CLASS heroClass, string heroCardID)
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CM_NEW_DECK_CREATED);
        CollectionManager.Get().SendCreateDeck(CollectionManager.Get().AutoGenerateDeckName(heroClass), heroCardID);
        CollectionManagerDisplay.Get().ExitSelectNewDeckHeroMode();
    }

    private void OnHeroPickerLoaded(string actorName, GameObject actorObject, object callbackData)
    {
    }

    private void OnInvalidDeckPopupResponse(AlertPopup.Response response, object userData)
    {
        if (response == AlertPopup.Response.CANCEL)
        {
            this.SaveCurrentDeckAndEnterDeckListMode();
        }
        else
        {
            this.FinishMyDeckPress();
        }
    }

    private void OnNewDeckBoxPoppedUp(object callbackData)
    {
        if (this.IsShowingDeckContents())
        {
            CollectionDeckBoxVisual visual = callbackData as CollectionDeckBoxVisual;
            visual.PlayScaleUpAnimation(new CollectionDeckBoxVisual.DelOnAnimationFinished(this.OnDeckBoxScaledUp), visual);
        }
    }

    private void OnNewDeckBoxRotated(CollectionDeckBoxVisual deckBox)
    {
        if (this.IsShowingDeckContents())
        {
            deckBox.PlayPopUpAnimation(new CollectionDeckBoxVisual.DelOnAnimationFinished(this.OnNewDeckBoxPoppedUp), deckBox);
        }
    }

    private void OnNewDeckButtonRotated(TrayAndDeckBoxCallbackData callbackData)
    {
        if (this.IsShowingDeckContents())
        {
            callbackData.m_deckBox.Show();
            object[] args = new object[] { "rotation", this.DECKBOX_LOCAL_EULER_ANGLES, "isLocal", true, "time", 0.1f, "easeType", iTween.EaseType.easeInCubic, "oncomplete", "OnNewDeckBoxRotated", "oncompletetarget", base.gameObject, "oncompleteparams", callbackData.m_deckBox, "name", "rotation" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(callbackData.m_deckBox.gameObject, "rotation");
            iTween.RotateTo(callbackData.m_deckBox.gameObject, hashtable);
            callbackData.m_traySection.Show();
            callbackData.m_traySection.OpenDoorImmediately();
            this.m_deckTray.m_newDeckButton.gameObject.SetActive(false);
            this.m_deckTray.m_newDeckButton.transform.localEulerAngles = Vector3.zero;
            this.m_deckTray.m_newDeckButtonSection.CloseDoorImmediately();
            this.PositionNewDeckTray();
            this.m_deckTray.m_newDeckButton.gameObject.SetActive(true);
        }
    }

    private void OnNewDeckPoppedDown(object callbackData)
    {
        if (this.IsShowingDeckContents())
        {
            this.m_deckTray.m_newDeckButtonSection.CloseDoor(new TraySection.DelOnDoorStateChangedCallback(this.OnNewDeckTrayDoorClosed), callbackData);
        }
    }

    private void OnNewDeckTrayDoorClosed(object callbackData)
    {
        if (this.IsShowingDeckContents())
        {
            long deckID = (long) callbackData;
            this.CloseAllTraysExceptLoadingDeck(deckID);
        }
    }

    private void OnNewDeckTrayDoorOpened(object callbackData)
    {
        if (!this.IsShowingDeckContents())
        {
            this.m_deckTray.m_newDeckButton.PlayPopUpAnimation();
        }
    }

    private void OnTrayDoorOpened(object callbackData)
    {
        if (!this.IsShowingDeckContents())
        {
            TrayAndDeckBoxCallbackData data = callbackData as TrayAndDeckBoxCallbackData;
            if (data != null)
            {
                data.m_deckBox.PlayPopUpAnimation();
            }
        }
    }

    private void OnTrayDoorsClosedForNewDeck(long newDeckID)
    {
        this.RotateNewDeckButton(newDeckID);
    }

    private void OpenAllTrayDoorsSequentially()
    {
        if (!this.IsShowingDeckContents())
        {
            List<TrayAndDeckBoxCallbackData> list = new List<TrayAndDeckBoxCallbackData>();
            int num = 0;
            while (num < this.m_deckBoxes.Count)
            {
                CollectionDeckBoxVisual visual = this.m_deckBoxes[num];
                if (visual.GetDeckID() == -1L)
                {
                    break;
                }
                TraySection section = this.m_traySections[num];
                if (!section.IsOpen())
                {
                    visual.Show();
                    section.Show();
                    TrayAndDeckBoxCallbackData data3 = new TrayAndDeckBoxCallbackData {
                        m_traySection = section,
                        m_deckBox = visual
                    };
                    TrayAndDeckBoxCallbackData item = data3;
                    list.Add(item);
                }
                num++;
            }
            for (int i = num; i < this.m_deckBoxes.Count; i++)
            {
                this.m_deckBoxes[i].Hide();
            }
            bool flag = this.PositionNewDeckTray();
            OpenTraysSequentiallyData data4 = new OpenTraysSequentiallyData {
                m_traysToOpen = list,
                m_openNewDeckTray = flag
            };
            OpenTraysSequentiallyData data2 = data4;
            base.StopCoroutine(this.OPEN_TRAY_DOORS_COROUTINE);
            base.StartCoroutine(this.OPEN_TRAY_DOORS_COROUTINE, data2);
        }
    }

    private void OpenNewDeckDoorIfPossible()
    {
        if (CollectionManager.Get().GetDecks().Count < CollectionManager.Get().GetMaxNumCustomDecks())
        {
            this.m_deckTray.m_newDeckButtonSection.OpenDoor(new TraySection.DelOnDoorStateChangedCallback(this.OnNewDeckTrayDoorOpened));
        }
    }

    [DebuggerHidden]
    private IEnumerator OpenTrayDoorsSequentially(OpenTraysSequentiallyData openTraysSequentiallyData)
    {
        return new <OpenTrayDoorsSequentially>c__Iterator9 { openTraysSequentiallyData = openTraysSequentiallyData, <$>openTraysSequentiallyData = openTraysSequentiallyData, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator PositionForContentsView(CollectionDeckBoxVisual deckBox)
    {
        return new <PositionForContentsView>c__Iterator7 { deckBox = deckBox, <$>deckBox = deckBox, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator PositionForListView(CollectionDeckBoxVisual previouslyViewedDeckBox)
    {
        return new <PositionForListView>c__IteratorA { previouslyViewedDeckBox = previouslyViewedDeckBox, <$>previouslyViewedDeckBox = previouslyViewedDeckBox, <>f__this = this };
    }

    private bool PositionNewDeckTray()
    {
        for (int i = 0; i < this.m_deckBoxes.Count; i++)
        {
            if (this.m_deckBoxes[i].GetDeckID() == -1L)
            {
                this.m_deckTray.m_newDeckButtonSection.transform.position = this.m_traySections[i].transform.position;
                this.m_traySections[i].Hide();
                return true;
            }
        }
        return false;
    }

    public void RemoveCard(string cardID, CardFlair flair)
    {
        this.GetDeck().RemoveCard(cardID, flair.Premium);
        this.HandleDeletedCardDeckUpdate(cardID, flair);
    }

    private void RotateNewDeckButton(long newDeckID)
    {
        CollectionDeckBoxVisual visual;
        TraySection section;
        if (this.IsShowingDeckContents() && this.GetTraySectionAndDeckBox(newDeckID, out section, out visual))
        {
            visual.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            TrayAndDeckBoxCallbackData data2 = new TrayAndDeckBoxCallbackData {
                m_deckBox = visual,
                m_traySection = section
            };
            TrayAndDeckBoxCallbackData data = data2;
            SoundManager.Get().LoadAndPlay("collection_manager_new_deck_edge_flips", base.gameObject);
            object[] args = new object[] { "rotation", new Vector3(270f, 0f, 0f), "isLocal", true, "time", 0.1f, "easeType", iTween.EaseType.easeInCubic, "oncomplete", "OnNewDeckButtonRotated", "oncompletetarget", base.gameObject, "oncompleteparams", data, "name", "rotation" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(this.m_deckTray.m_newDeckButton.gameObject, "rotation");
            iTween.RotateTo(this.m_deckTray.m_newDeckButton.gameObject, hashtable);
        }
    }

    private void SaveCurrentDeckAndEnterDeckListMode()
    {
        this.DestroyDeckValidationPopUp();
        CollectionManager.Get().GetDeck(this.GetCurrentlyViewedDeckID()).SendChanges();
        this.EnterDeckListMode();
    }

    private void ScaleUpDeckBoxThenPositionTray(long deckID)
    {
        CollectionDeckBoxVisual visual;
        TraySection section;
        if (this.GetTraySectionAndDeckBox(deckID, out section, out visual))
        {
            if (this.m_deckNameBg != null)
            {
                this.m_deckNameBg.transform.parent = visual.transform;
                this.m_deckNameBg.transform.localPosition = new Vector3(0.1268057f, -1.727297f, 0f);
                this.m_deckNameBg.transform.localScale = new Vector3(1.22f, 1f, 1.22f);
                this.m_deckNameBg.SetActive(true);
                object[] args = new object[] { "amount", 0.5f, "time", 0.25f, "easeType", iTween.EaseType.easeOutCubic };
                Hashtable hashtable = iTween.Hash(args);
                iTween.FadeTo(this.m_deckNameBg, hashtable);
            }
            visual.PlayScaleUpAnimation(new CollectionDeckBoxVisual.DelOnAnimationFinished(this.OnDeckBoxScaledUp), visual);
        }
    }

    private void SetDeckID(long deckID)
    {
        this.m_currentlyViewingDeckID = deckID;
    }

    private void SetDeckName(string newName)
    {
        if (!string.IsNullOrEmpty(newName))
        {
            TraySection section;
            CollectionDeckBoxVisual visual;
            this.GetDeck().Name = newName;
            if (this.GetTraySectionAndDeckBox(this.GetCurrentlyViewedDeckID(), out section, out visual))
            {
                visual.SetDeckName(newName);
            }
            this.m_deckboxBeingEdited.ShowDeckName();
        }
    }

    private void SetUpScrollbarForDeckList()
    {
        if (!this.IsShowingDeckContents())
        {
            this.m_deckTray.m_scrollbar.Init(this.m_deckTray.m_deckContainer, false);
        }
    }

    private void ShowCompleteDeckHighlight(bool show)
    {
        this.m_deckTray.ShowCompleteDeckHighlight(show);
        if (!Options.Get().GetBool(Option.HAS_FINISHED_A_DECK, false) && show)
        {
            NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_CM_DECK_FINISH_30"), "VO_INNKEEPER_CM_DECK_FINISH_30", 3f);
            Options.Get().SetBool(Option.HAS_FINISHED_A_DECK, true);
        }
    }

    public void ShowDeck(long deckID, bool isNewDeck)
    {
        this.m_deckInfoTooltip.SetDeckID(deckID);
        this.EnterDeckContentsMode(deckID, isNewDeck);
    }

    private void ShowDeckHelpButtonIfNeeded()
    {
        bool flag = false;
        if (!DeckHelper.Get().IsActive())
        {
            CollectionDeck deck = this.GetDeck();
            if ((deck != null) && (deck.GetTotalCardCount() < 30))
            {
                flag = true;
            }
        }
        this.m_deckHelpButton.gameObject.SetActive(flag);
        if (this.IsShowingDeckContents())
        {
            this.m_deckTray.m_scrollbar.UpdateScrollAreaBounds();
        }
    }

    private void Start()
    {
        this.m_deckHelpButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.DeckHelpButtonPress));
    }

    private void StopAllDeckContentsCoroutines()
    {
        base.StopCoroutine(this.POSITION_CONTENTS_VIEW_COROUTINE);
        base.StopCoroutine(this.CLOSE_TRAY_DOORS_COROUTINE);
    }

    private void StopAllDeckListCoroutines()
    {
        base.StopCoroutine(this.DECK_DELETED_COROUTINE);
        base.StopCoroutine(this.POSITION_LIST_VIEW_COROUTINE);
        base.StopCoroutine(this.OPEN_TRAY_DOORS_COROUTINE);
    }

    public void Unload()
    {
        this.m_deckTray.m_scrollbar.m_thumb.RemoveStartDraggingListener(new ScrollBarThumb.DelStartDraggingListener(CollectionInputMgr.Get().SetScrollbar));
    }

    private void UpdateCardList(bool goingToAnimateEntrance)
    {
        this.UpdateCardList(goingToAnimateEntrance, string.Empty, null);
    }

    private void UpdateCardList(bool goingToAnimateEntrance, string justChangedCardID, CardFlair justChangedCardFlair)
    {
        if (this.IsShowingDeckContents())
        {
            foreach (CollectionDeckTileVisual visual in this.m_deckTiles)
            {
                visual.MarkAsUnused();
            }
            List<CollectionDeckSlot> slots = CollectionManager.Get().GetDeck(this.GetCurrentlyViewedDeckID()).GetSlots();
            if (goingToAnimateEntrance)
            {
                Vector3 cardContainerOriginalLocalPosition = this.m_cardContainerOriginalLocalPosition;
                cardContainerOriginalLocalPosition.y += DeckTray.DECK_SLOT_HEIGHT * (slots.Count + 2);
                this.m_deckTray.m_cardContainer.transform.localPosition = cardContainerOriginalLocalPosition;
            }
            int count = 0;
            float y = 0f;
            for (int i = 0; i < slots.Count; i++)
            {
                CollectionDeckSlot s = slots[i];
                if (s.Count == 0)
                {
                    Log.Rachelle.Print(string.Format("CollectionDeckTray.UpdateCardList(): Slot {0} of deck is empty! Skipping...", i));
                }
                else
                {
                    count += s.Count;
                    CollectionDeckTileVisual deckTileVisual = this.GetDeckTileVisual(i);
                    y = -s.Index * DeckTray.DECK_SLOT_HEIGHT;
                    deckTileVisual.gameObject.transform.localPosition = new Vector3(0f, y, 0f);
                    deckTileVisual.MarkAsUsed();
                    deckTileVisual.Show();
                    deckTileVisual.SetSlot(s, justChangedCardID.Equals(s.CardID));
                }
            }
            foreach (CollectionDeckTileVisual visual3 in this.m_deckTiles)
            {
                if (!visual3.IsInUse())
                {
                    visual3.Hide();
                }
            }
            Vector3 vector2 = this.DECK_HELP_BUTTON_LOCAL_POS;
            vector2.y = (count != 0) ? (y + -0.04915909f) : -0.01194457f;
            this.m_deckHelpButton.transform.localPosition = vector2;
            this.m_deckHelpButton.SetUserOverYOffset(-0.7f);
            this.m_deckHelpButton.SetOriginalButtonPosition();
            this.m_deckTray.SetCardCount(count);
            if (!goingToAnimateEntrance)
            {
                this.ShowDeckHelpButtonIfNeeded();
                this.m_deckTray.m_scrollbar.UpdateScrollAreaBounds();
            }
        }
    }

    private void UpdateDeckCountDisplay()
    {
        this.m_deckTray.SetDeckCount(CollectionManager.Get().GetDecks().Count);
    }

    private void UpdateDeckHighlight(CollectionDeck deck)
    {
        this.ShowCompleteDeckHighlight(deck.GetTotalCardCount() == 30);
    }

    [CompilerGenerated]
    private sealed class <AutoAddCardsWithTiming>c__Iterator6 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<RDMDeckEntry> <$>newCards;
        internal CollectionDeckTray <>f__this;
        internal int <i>__0;
        internal RDMDeckEntry <newCard>__1;
        internal List<RDMDeckEntry> newCards;

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
                    this.<>f__this.m_deckTray.AllowInput(false);
                    this.<i>__0 = 0;
                    break;

                case 1:
                    this.<i>__0++;
                    break;

                default:
                    goto Label_00D5;
            }
            if (this.<i>__0 < this.newCards.Count)
            {
                this.<newCard>__1 = this.newCards[this.<i>__0];
                this.<>f__this.AddCard(this.<newCard>__1.EntityDef.GetCardId(), this.<newCard>__1.Flair, null);
                this.$current = new WaitForSeconds(0.2f);
                this.$PC = 1;
                return true;
            }
            this.<>f__this.m_deckTray.AllowInput(true);
            this.$PC = -1;
        Label_00D5:
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

    [CompilerGenerated]
    private sealed class <CloseTrayDoorsSequentially>c__Iterator8 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionDeckTray.CloseTraysSequentiallyData <$>closeTraysSequentiallyData;
        internal CollectionDeckTray <>f__this;
        internal int <i>__0;
        internal CollectionDeckTray.TrayAndDeckBoxCallbackData <trayAndDeckToClose>__1;
        internal CollectionDeckTray.CloseTraysSequentiallyData closeTraysSequentiallyData;

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
                    if (this.<>f__this.IsShowingDeckContents())
                    {
                        this.<i>__0 = 0;
                        while (this.<i>__0 < this.closeTraysSequentiallyData.m_traysToClose.Count)
                        {
                            this.<trayAndDeckToClose>__1 = this.closeTraysSequentiallyData.m_traysToClose[this.<i>__0];
                            this.<trayAndDeckToClose>__1.m_deckBox.PlayPopDownAnimation(new CollectionDeckBoxVisual.DelOnAnimationFinished(this.<>f__this.OnDeckPoppedDown), this.<trayAndDeckToClose>__1);
                            this.$current = new WaitForSeconds(0.015f);
                            this.$PC = 1;
                            return true;
                        Label_00A1:
                            this.<i>__0++;
                        }
                        if (this.closeTraysSequentiallyData.m_onTrayDoorsClosedCallback != null)
                        {
                            this.closeTraysSequentiallyData.m_onTrayDoorsClosedCallback(this.closeTraysSequentiallyData.m_deckIdToOpen);
                            this.$PC = -1;
                        }
                        break;
                    }
                    break;

                case 1:
                    goto Label_00A1;
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

    [CompilerGenerated]
    private sealed class <DeckDeletedCoroutine>c__Iterator5 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal long <$>deckID;
        internal CollectionDeckTray <>f__this;
        internal CollectionDeckBoxVisual <deckBox>__7;
        internal CollectionDeckBoxVisual <deletedDeckBox>__0;
        internal TraySection <deletedTraySection>__1;
        internal int <i>__6;
        internal int <index>__2;
        internal bool <newDeckTrayPositioned>__5;
        internal Hashtable <newTraySectionMoveArgs>__10;
        internal ParticleSystem <particleSystem>__3;
        internal Vector3 <prevTraySectionPosition>__4;
        internal TraySection <traySection>__8;
        internal Hashtable <traySectionMoveArgs>__11;
        internal Vector3 <traySectionPosition>__9;
        internal long deckID;

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
                    this.<>f__this.m_deckTray.AllowInput(false);
                    this.<>f__this.UpdateDeckCountDisplay();
                    this.<deletedDeckBox>__0 = null;
                    this.<deletedTraySection>__1 = null;
                    this.<index>__2 = -1;
                    if (this.<>f__this.GetTraySectionAndDeckBox(this.deckID, out this.<deletedTraySection>__1, out this.<deletedDeckBox>__0, out this.<index>__2))
                    {
                        SoundManager.Get().LoadAndPlay("collection_manager_delete_deck", this.<>f__this.gameObject);
                        this.<>f__this.m_deckTray.m_deleteDeckPoof.transform.position = this.<deletedDeckBox>__0.transform.position;
                        this.<particleSystem>__3 = this.<>f__this.m_deckTray.m_deleteDeckPoof.GetComponent<ParticleSystem>();
                        if (this.<particleSystem>__3 != null)
                        {
                            this.<particleSystem>__3.Play(true);
                        }
                        this.<>f__this.m_deckBoxes.RemoveAt(this.<index>__2);
                        this.<>f__this.m_traySections.RemoveAt(this.<index>__2);
                        this.<deletedDeckBox>__0.PlayPopDownAnimationImmediately();
                        this.<deletedDeckBox>__0.Hide();
                        this.<deletedDeckBox>__0.SetDeckName(string.Empty);
                        this.<deletedDeckBox>__0.SetDeckID(-1L);
                        this.<deletedTraySection>__1.CloseDoorImmediately();
                        this.<prevTraySectionPosition>__4 = this.<deletedTraySection>__1.transform.position;
                        this.<deletedTraySection>__1.transform.position = this.<>f__this.m_traySections[this.<>f__this.m_traySections.Count - 1].transform.position;
                        this.<newDeckTrayPositioned>__5 = false;
                        this.<i>__6 = this.<index>__2;
                        while (this.<i>__6 < this.<>f__this.m_traySections.Count)
                        {
                            this.<deckBox>__7 = this.<>f__this.m_deckBoxes[this.<i>__6];
                            this.<traySection>__8 = this.<>f__this.m_traySections[this.<i>__6];
                            this.<traySectionPosition>__9 = this.<traySection>__8.transform.position;
                            if (!this.<newDeckTrayPositioned>__5 && (this.<deckBox>__7.GetDeckID() == -1L))
                            {
                                this.<traySection>__8.Hide();
                                this.<traySection>__8.transform.position = this.<prevTraySectionPosition>__4;
                                object[] args = new object[] { "position", this.<prevTraySectionPosition>__4, "isLocal", false, "time", 0.5f, "easeType", iTween.EaseType.easeOutBounce, "oncomplete", "OpenNewDeckDoorIfPossible", "oncompletetarget", this.<>f__this.gameObject, "name", "position" };
                                this.<newTraySectionMoveArgs>__10 = iTween.Hash(args);
                                iTween.StopByName(this.<>f__this.m_deckTray.m_newDeckButtonSection.gameObject, "position");
                                iTween.MoveTo(this.<>f__this.m_deckTray.m_newDeckButtonSection.gameObject, this.<newTraySectionMoveArgs>__10);
                                this.<newDeckTrayPositioned>__5 = true;
                            }
                            else
                            {
                                this.<traySection>__8.Show();
                                object[] objArray2 = new object[] { "position", this.<prevTraySectionPosition>__4, "isLocal", false, "time", 0.5f, "easeType", iTween.EaseType.easeOutBounce, "name", "position" };
                                this.<traySectionMoveArgs>__11 = iTween.Hash(objArray2);
                                iTween.StopByName(this.<traySection>__8.gameObject, "position");
                                iTween.MoveTo(this.<traySection>__8.gameObject, this.<traySectionMoveArgs>__11);
                            }
                            this.<prevTraySectionPosition>__4 = this.<traySectionPosition>__9;
                            this.<i>__6++;
                        }
                        this.<>f__this.m_deckBoxes.Add(this.<deletedDeckBox>__0);
                        this.<>f__this.m_traySections.Add(this.<deletedTraySection>__1);
                        this.$current = new WaitForSeconds(1f);
                        this.$PC = 1;
                        return true;
                    }
                    Log.Rachelle.Print(string.Format("CollectionDeckTray.DeckDeletedCoroutine(): Couldn't find deckbox with id {0} to play deleted deck animation!", this.deckID));
                    this.<>f__this.m_deckTray.AllowInput(true);
                    break;

                case 1:
                    this.<>f__this.SetUpScrollbarForDeckList();
                    this.<>f__this.m_deckTray.AllowInput(true);
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

    [CompilerGenerated]
    private sealed class <OpenTrayDoorsSequentially>c__Iterator9 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionDeckTray.OpenTraysSequentiallyData <$>openTraysSequentiallyData;
        internal CollectionDeckTray <>f__this;
        internal int <i>__0;
        internal CollectionDeckTray.TrayAndDeckBoxCallbackData <trayAndDeckBox>__1;
        internal CollectionDeckTray.OpenTraysSequentiallyData openTraysSequentiallyData;

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
                    if (!this.<>f__this.IsShowingDeckContents())
                    {
                        this.<i>__0 = 0;
                        while (this.<i>__0 < this.openTraysSequentiallyData.m_traysToOpen.Count)
                        {
                            this.<trayAndDeckBox>__1 = this.openTraysSequentiallyData.m_traysToOpen[this.<i>__0];
                            this.<trayAndDeckBox>__1.m_deckBox.Show();
                            this.<trayAndDeckBox>__1.m_traySection.OpenDoor(new TraySection.DelOnDoorStateChangedCallback(this.<>f__this.OnTrayDoorOpened), this.<trayAndDeckBox>__1);
                            this.$current = new WaitForSeconds(0.015f);
                            this.$PC = 1;
                            return true;
                        Label_00B1:
                            this.<i>__0++;
                        }
                        if (this.openTraysSequentiallyData.m_openNewDeckTray)
                        {
                            this.<>f__this.OpenNewDeckDoorIfPossible();
                        }
                        this.<>f__this.SetUpScrollbarForDeckList();
                        this.$PC = -1;
                        break;
                    }
                    break;

                case 1:
                    goto Label_00B1;
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

    [CompilerGenerated]
    private sealed class <PositionForContentsView>c__Iterator7 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionDeckBoxVisual <$>deckBox;
        internal CollectionDeckTray <>f__this;
        internal Hashtable <deckBoxMoveArgs>__0;
        internal CollectionDeckBoxVisual deckBox;

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
                    if (this.<>f__this.IsShowingDeckContents())
                    {
                        SoundManager.Get().LoadAndPlay("collection_manager_new_deck_moves_up_tray", this.<>f__this.gameObject);
                        object[] args = new object[] { "position", this.<>f__this.m_deckTray.m_deckContentsDeckBoxTrayBone.transform.position, "isLocal", false, "time", 0.15f, "easeType", iTween.EaseType.linear, "name", "position" };
                        this.<deckBoxMoveArgs>__0 = iTween.Hash(args);
                        iTween.StopByName(this.deckBox.gameObject, "position");
                        iTween.MoveTo(this.deckBox.gameObject, this.<deckBoxMoveArgs>__0);
                        this.$current = new WaitForSeconds(0.15f);
                        this.$PC = 1;
                        goto Label_015D;
                    }
                    break;

                case 1:
                case 2:
                    if (this.<>f__this.m_numCardPrefabsToLoad > 0)
                    {
                        this.$current = null;
                        this.$PC = 2;
                        goto Label_015D;
                    }
                    this.<>f__this.AnimateCardListEntrance();
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_015D:
            return true;
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

    [CompilerGenerated]
    private sealed class <PositionForListView>c__IteratorA : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionDeckBoxVisual <$>previouslyViewedDeckBox;
        internal CollectionDeckTray <>f__this;
        internal Hashtable <args>__1;
        internal Hashtable <deckBoxMoveArgs>__2;
        internal Vector3 <deckBoxTargetLocalPos>__0;
        internal CollectionDeckBoxVisual previouslyViewedDeckBox;

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
                    if (!this.<>f__this.IsShowingDeckContents())
                    {
                        this.<deckBoxTargetLocalPos>__0 = this.previouslyViewedDeckBox.transform.localPosition;
                        this.<deckBoxTargetLocalPos>__0.z = CollectionDeckBoxVisual.POPPED_UP_LOCAL_Z;
                        if (this.<>f__this.m_deckNameBg != null)
                        {
                            object[] objArray1 = new object[] { "amount", 0f, "time", 0.25f, "easeType", iTween.EaseType.easeOutCubic };
                            this.<args>__1 = iTween.Hash(objArray1);
                            iTween.FadeTo(this.<>f__this.m_deckNameBg, this.<args>__1);
                        }
                        object[] args = new object[] { "position", this.<deckBoxTargetLocalPos>__0, "isLocal", true, "time", 0.2f, "easeType", iTween.EaseType.linear, "name", "position" };
                        this.<deckBoxMoveArgs>__2 = iTween.Hash(args);
                        iTween.StopByName(this.previouslyViewedDeckBox.gameObject, "position");
                        iTween.MoveTo(this.previouslyViewedDeckBox.gameObject, this.<deckBoxMoveArgs>__2);
                        this.$current = new WaitForSeconds(0.2f);
                        this.$PC = 1;
                        return true;
                    }
                    break;

                case 1:
                    this.previouslyViewedDeckBox.PlayScaleDownAnimation();
                    this.<>f__this.OpenAllTrayDoorsSequentially();
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

    private class CloseTraysSequentiallyData
    {
        public long m_deckIdToOpen;
        public CollectionDeckTray.OnTrayDoorsClosed m_onTrayDoorsClosedCallback;
        public List<CollectionDeckTray.TrayAndDeckBoxCallbackData> m_traysToClose;
    }

    private delegate void OnTrayDoorsClosed(long m_deckIdToOpen);

    private class OpenTraysSequentiallyData
    {
        public bool m_openNewDeckTray;
        public List<CollectionDeckTray.TrayAndDeckBoxCallbackData> m_traysToOpen;
    }

    private class TrayAndDeckBoxCallbackData
    {
        public CollectionDeckBoxVisual m_deckBox;
        public TraySection m_traySection;
    }
}


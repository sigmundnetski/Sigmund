using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class CollectionPageManager : MonoBehaviour
{
    private static readonly string ANIMATE_TABS_COROUTINE_NAME;
    private static readonly Vector3 ARROW_LOCAL_SCALE;
    private static readonly float ARROW_SCALE_TIME;
    private static readonly Vector3 CLASS_TAB_LOCAL_EULERS;
    private static readonly Vector3 CLASS_TAB_LOCAL_SCALE;
    private static TAG_CLASS[] CLASS_TAB_ORDER;
    private static Dictionary<TAG_CLASS, int> CLASS_TO_TAB_IDX;
    private static readonly Vector3 CURRENT_PAGE_LOCAL_POS;
    private static readonly float HIDDEN_TAB_LOCAL_Z_POS;
    private TAG_CLASS m_classConstraint;
    public GameObject m_classTabContainer;
    public CollectionClassTab m_classTabPrefab;
    private List<CollectionClassTab> m_classTabs = new List<CollectionClassTab>();
    private Dictionary<TAG_CLASS, bool> m_classTabVisibleMap = new Dictionary<TAG_CLASS, bool>();
    private CollectionClassTab m_currentClassTab;
    private bool m_currentPageIsPageA;
    private int m_currentPageNum;
    private bool m_delayShowingArrows;
    private float m_deselectedClassTabHalfWidth;
    private CollectionFilterSet m_filterSet = new CollectionFilterSet(true);
    private bool m_fullyLoaded;
    private bool m_initializedTabPositions;
    public MassDisenchant m_massDisenchant;
    public MassDisenchantTab m_massDisenchantTab;
    public CollectionPageDisplay m_pageA;
    public CollectionPageDisplay m_pageB;
    private GameObject m_pageLeftArrow;
    public GameObject m_pageLeftArrowBone;
    public PegUIElement m_pageLeftClickableRegion;
    private GameObject m_pageRightArrow;
    public GameObject m_pageRightArrowBone;
    public PegUIElement m_pageRightClickableRegion;
    public PageTurn m_pageTurn;
    private FilteredArtStack m_preSearchArtStackAnchor;
    private SortedCollection m_sortedCollection = new SortedCollection();
    private bool m_tabsAreAnimating;
    public float m_turnLeftPageSwapTiming;
    private static readonly int MASS_DISENCHANT_PAGE_NUM;
    private static readonly int MAX_MOUSE_OVERS;
    private static readonly Vector3 NEXT_PAGE_LOCAL_POS;
    private static readonly string PAGE_LEFT_COMPLETE_COROUTINE_NAME;
    private static readonly Vector3 PREV_PAGE_LOCAL_POS;
    public static readonly float SELECT_TAB_ANIM_TIME;
    private static readonly string SELECT_TAB_COROUTINE_NAME;
    private static readonly float SELECTED_CLASS_TAB_LOCAL_Y_POS;
    private static readonly Vector3 SELECTED_CLASS_TAB_SCALE;
    private static readonly string SHOW_ARROWS_COROUTINE_NAME;
    private static readonly float SPACE_BETWEEN_TABS;

    static CollectionPageManager()
    {
        TAG_CLASS[] tag_classArray1 = new TAG_CLASS[10];
        tag_classArray1[0] = TAG_CLASS.DRUID;
        tag_classArray1[1] = TAG_CLASS.HUNTER;
        tag_classArray1[2] = TAG_CLASS.MAGE;
        tag_classArray1[3] = TAG_CLASS.PALADIN;
        tag_classArray1[4] = TAG_CLASS.PRIEST;
        tag_classArray1[5] = TAG_CLASS.ROGUE;
        tag_classArray1[6] = TAG_CLASS.SHAMAN;
        tag_classArray1[7] = TAG_CLASS.WARLOCK;
        tag_classArray1[8] = TAG_CLASS.WARRIOR;
        CLASS_TAB_ORDER = tag_classArray1;
        SELECT_TAB_ANIM_TIME = 0.2f;
        ARROW_LOCAL_SCALE = new Vector3(2f, 2f, 2f);
        PREV_PAGE_LOCAL_POS = new Vector3(0f, 0.5f, 0f);
        CURRENT_PAGE_LOCAL_POS = new Vector3(0f, 0.25f, 0f);
        NEXT_PAGE_LOCAL_POS = Vector3.zero;
        CLASS_TAB_LOCAL_SCALE = new Vector3(0.44f, 0.44f, 0.44f);
        CLASS_TAB_LOCAL_EULERS = new Vector3(0f, 180f, 0f);
        SELECTED_CLASS_TAB_SCALE = new Vector3(0.66f, 0.66f, 0.66f);
        SELECTED_CLASS_TAB_LOCAL_Y_POS = 0.1259841f;
        HIDDEN_TAB_LOCAL_Z_POS = -0.42f;
        SPACE_BETWEEN_TABS = 0.15f;
        ARROW_SCALE_TIME = 0.6f;
        ANIMATE_TABS_COROUTINE_NAME = "AnimateTabs";
        SELECT_TAB_COROUTINE_NAME = "SelectTabWhenReady";
        SHOW_ARROWS_COROUTINE_NAME = "WaitThenShowArrows";
        PAGE_LEFT_COMPLETE_COROUTINE_NAME = "WaitThenCompletePageLeft";
        MAX_MOUSE_OVERS = 1;
        MASS_DISENCHANT_PAGE_NUM = 0x3e8;
        CLASS_TO_TAB_IDX = null;
    }

    private void ActivateArrows(bool leftArrowActive, bool rightArrowActive)
    {
        this.m_pageLeftClickableRegion.enabled = leftArrowActive;
        this.m_pageLeftClickableRegion.SetEnabled(leftArrowActive);
        this.m_pageRightClickableRegion.enabled = rightArrowActive;
        this.m_pageRightClickableRegion.SetEnabled(rightArrowActive);
        this.ShowArrow(this.m_pageLeftArrow, leftArrowActive);
        this.ShowArrow(this.m_pageRightArrow, rightArrowActive);
    }

    public void AddClassFilter(TAG_CLASS shownClass)
    {
        this.AddClassFilter(shownClass, null, null);
    }

    public void AddClassFilter(TAG_CLASS shownClass, DelOnPageTransitionComplete callback, object callbackData)
    {
        this.m_classConstraint = shownClass;
        List<object> values = new List<object> {
            (int) this.m_classConstraint,
            0
        };
        this.m_filterSet.AddGameFilter(GAME_TAG.CLASS, values, CollectionFilterFunc.EQUAL);
        this.UpdateSortedCollectionFromFilterSet();
        this.JumpToCollectionClassPage(shownClass, callback, callbackData);
    }

    private void AddGameFilter(GAME_TAG key, object val, CollectionFilterFunc func)
    {
        this.m_filterSet.AddGameFilter(key, val, func);
        this.UpdateSortedCollectionFromFilterSet();
    }

    [DebuggerHidden]
    private IEnumerator AnimateTabs()
    {
        return new <AnimateTabs>c__Iterator13 { <>f__this = this };
    }

    private void AssembleEmptyPageUI(CollectionPageDisplay page, bool displayNoMatchesText)
    {
        page.SetClass(null);
        page.ShowNoMatchesFound(displayNoMatchesText);
        this.DeselectCurrentClassTab();
        page.SetPageCountText(GameStrings.Get("GLUE_COLLECTION_EMPTY_PAGE"));
        this.ActivateArrows(false, false);
    }

    private void AssemblePage(TransitionReadyCallbackData transitionReadyCallbackData, List<FilteredArtStack> artStacksToDisplay, TAG_CLASS pageClass)
    {
        CollectionPageDisplay assembledPage = transitionReadyCallbackData.m_assembledPage;
        bool flag = MASS_DISENCHANT_PAGE_NUM == this.m_currentPageNum;
        if (flag)
        {
            this.m_massDisenchant.Show();
            assembledPage.ActivatePageCountText(false);
        }
        else
        {
            this.m_massDisenchant.Hide();
            assembledPage.ActivatePageCountText(true);
        }
        if (artStacksToDisplay.Count == 0)
        {
            this.AssembleEmptyPageUI(assembledPage, !flag);
        }
        else
        {
            FilteredArtStack stack = artStacksToDisplay[0];
            if (this.m_filterSet.IsTextFilterEmpty())
            {
                this.m_preSearchArtStackAnchor = stack.Clone();
            }
            EntityDef entityDef = DefLoader.Get().GetEntityDef(stack.CardID);
            assembledPage.SetClass(new TAG_CLASS?(entityDef.GetClass()));
            assembledPage.SetPageCountText(string.Format(GameStrings.Get("GLUE_COLLECTION_PAGE_NUM"), this.m_currentPageNum));
            assembledPage.ShowNoMatchesFound(false);
            int totalNumPages = this.m_sortedCollection.GetTotalNumPages();
            this.ActivateArrows(this.m_currentPageNum > 1, this.m_currentPageNum < totalNumPages);
        }
        PageAssembledCallbackData data2 = new PageAssembledCallbackData {
            m_callback = new DelPageAssembledCallback(this.TransitionPage),
            m_callbackData = transitionReadyCallbackData
        };
        PageAssembledCallbackData callbackData = data2;
        CollectionManagerDisplay.Get().CollectionPageContentsChanged(artStacksToDisplay, new CollectionManagerDisplay.CollectionActorsReadyCallback(assembledPage.PositionCollectionCards), callbackData);
    }

    private void Awake()
    {
        if (CLASS_TO_TAB_IDX == null)
        {
            CLASS_TO_TAB_IDX = new Dictionary<TAG_CLASS, int>();
            for (int i = 0; i < CLASS_TAB_ORDER.Length; i++)
            {
                CLASS_TO_TAB_IDX.Add(CLASS_TAB_ORDER[i], i);
            }
        }
        this.UpdateSortedCollectionFromFilterSet();
        this.m_massDisenchant.Hide();
        this.m_massDisenchantTab.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnMassDisenchantTabPressed));
        this.m_pageLeftClickableRegion.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnOverPageLeft));
        this.m_pageLeftClickableRegion.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnPageLeftPressed));
        this.m_pageLeftClickableRegion.SetCursorOver(PegCursor.Mode.LEFTARROW);
        this.m_pageLeftClickableRegion.SetCursorDown(PegCursor.Mode.LEFTARROW);
        this.m_pageRightClickableRegion.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnOverPageRight));
        this.m_pageRightClickableRegion.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnPageRightPressed));
        this.m_pageRightClickableRegion.SetCursorOver(PegCursor.Mode.RIGHTARROW);
        this.m_pageRightClickableRegion.SetCursorDown(PegCursor.Mode.RIGHTARROW);
    }

    public void ChangeSearchTextFilter(string newSearchText)
    {
        this.ChangeSearchTextFilter(newSearchText, null, null);
    }

    public void ChangeSearchTextFilter(string newSearchText, DelOnPageTransitionComplete callback, object callbackData)
    {
        this.m_filterSet.SetTextFilterValue(newSearchText);
        this.UpdateSortedCollectionFromFilterSet();
        this.TransitionPageWhenReady(PageTransitionType.NONE, false, callback, callbackData);
    }

    private void DeselectCurrentClassTab()
    {
        if (this.m_currentClassTab != null)
        {
            this.m_currentClassTab.SetSelected(false);
            Vector3 localPosition = this.m_currentClassTab.transform.localPosition;
            localPosition.y = 0f;
            this.m_currentClassTab.transform.localPosition = localPosition;
            iTween.StopByName(this.m_currentClassTab.gameObject, "scale");
            this.m_currentClassTab.transform.localScale = CLASS_TAB_LOCAL_SCALE;
            this.m_currentClassTab = null;
        }
    }

    private void DestroyArrow(GameObject arrow)
    {
        UnityEngine.Object.Destroy(arrow);
    }

    public void FilterByManaCost(int cost)
    {
        this.FilterByManaCost(cost, null, null);
    }

    public void FilterByManaCost(int cost, DelOnPageTransitionComplete callback, object callbackData)
    {
        this.m_filterSet.RemoveAllGameFiltersByTag(GAME_TAG.COST);
        if (cost != ManaFilterTab.ALL_TAB_IDX)
        {
            CollectionFilterFunc func = (cost != ManaFilterTab.SEVEN_PLUS_TAB_IDX) ? CollectionFilterFunc.EQUAL : CollectionFilterFunc.GREATER_EQUAL;
            this.AddGameFilter(GAME_TAG.COST, cost, func);
        }
        this.UpdateSortedCollectionFromFilterSet();
        this.TransitionPageWhenReady(PageTransitionType.NONE, false, callback, callbackData);
    }

    private void FlipToPage(int newCollectionPage, DelOnPageTransitionComplete callback, object callbackData)
    {
        int num = newCollectionPage - this.m_currentPageNum;
        bool flag = num < 0;
        if (Math.Abs(num) != 1)
        {
            this.m_currentPageNum = newCollectionPage;
            this.TransitionPageWhenReady(!flag ? PageTransitionType.MANY_PAGE_RIGHT : PageTransitionType.MANY_PAGE_LEFT, true, callback, callbackData);
        }
        else if (flag)
        {
            this.PageLeft(callback, callbackData);
        }
        else
        {
            this.PageRight(callback, callbackData);
        }
    }

    private CollectionPageDisplay GetAlternatePage()
    {
        return (!this.m_currentPageIsPageA ? this.m_pageA : this.m_pageB);
    }

    public CollectionCardVisual GetCardVisual(string cardID, CardFlair cardFlair)
    {
        return this.GetCurrentPage().GetCardVisual(cardID, cardFlair);
    }

    private CollectionPageDisplay GetCurrentPage()
    {
        return (!this.m_currentPageIsPageA ? this.m_pageB : this.m_pageA);
    }

    public Vector3 GetMassDisenchantTabLocation()
    {
        return this.m_massDisenchantTab.transform.position;
    }

    public bool HaveCardsToMassDisenchant()
    {
        return (this.m_massDisenchant.GetTotalAmount() > 0);
    }

    private void HideThenDestroyArrow(GameObject arrow)
    {
        if (arrow != null)
        {
            object[] args = new object[] { "scale", Vector3.zero, "time", 0.3f, "oncomplete", "DestroyArrow", "oncompletetarget", base.gameObject, "oncompleteparams", arrow, "name", "scale" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(arrow, "scale");
            iTween.ScaleTo(arrow, hashtable);
        }
    }

    public bool IsFullyLoaded()
    {
        return this.m_fullyLoaded;
    }

    public bool IsMassDisenchantTabVisible()
    {
        return this.m_massDisenchantTab.IsVisible();
    }

    private void JumpToCollectionClassPage(TAG_CLASS pageClass)
    {
        this.JumpToCollectionClassPage(pageClass, null, null);
    }

    private void JumpToCollectionClassPage(TAG_CLASS pageClass, DelOnPageTransitionComplete callback, object callbackData)
    {
        int num;
        this.m_sortedCollection.GetPageContentsForClass(pageClass, 1, true, out num);
        this.FlipToPage(num, callback, callbackData);
    }

    public void JumpToPageWithCard(string cardID, CardFlair flair)
    {
        this.JumpToPageWithCard(cardID, flair, null, null);
    }

    public void JumpToPageWithCard(string cardID, CardFlair flair, DelOnPageTransitionComplete callback, object callbackData)
    {
        TAG_CLASS tag_class;
        int num;
        if ((this.m_sortedCollection.GetPageContentsForCard(cardID, flair, out tag_class, out num).Count != 0) && (this.m_currentPageNum != num))
        {
            this.FlipToPage(num, callback, callbackData);
        }
    }

    private void LoadPagingArrows()
    {
        if ((this.m_pageLeftArrow == null) || (this.m_pageRightArrow == null))
        {
            AssetLoader.Get().LoadGameObject("PagingArrow", new AssetLoader.GameObjectCallback(this.OnPagingArrowLoaded));
        }
    }

    public void NotifyOfCollectionChanged()
    {
        this.UpdateMassDisenchant();
    }

    public void OnBookClosing()
    {
        this.DeselectCurrentClassTab();
        this.ActivateArrows(false, false);
    }

    public void OnBookOpening()
    {
        base.StopCoroutine(SHOW_ARROWS_COROUTINE_NAME);
        base.StartCoroutine(SHOW_ARROWS_COROUTINE_NAME);
        this.TransitionPageWhenReady(PageTransitionType.NONE, true, null, null);
    }

    private void OnClassTabPressed(UIEvent e)
    {
        CollectionClassTab element = e.GetElement() as CollectionClassTab;
        if (element != null)
        {
            TAG_CLASS pageClass = element.GetClass();
            this.JumpToCollectionClassPage(pageClass);
        }
    }

    public void OnCollectionLoaded()
    {
        this.ShowOnlyCardsIOwn();
    }

    public void OnDoneEditingDeck()
    {
        this.RemoveAllClassFilters();
        this.UpdateMassDisenchantTabVisibility();
    }

    private void OnMassDisenchantTabPressed(UIEvent e)
    {
        this.m_currentPageNum = MASS_DISENCHANT_PAGE_NUM;
        this.TransitionPageWhenReady(PageTransitionType.MANY_PAGE_RIGHT, true, null, null);
    }

    private void OnOverPageLeft(UIEvent e)
    {
        this.RegisterMouseOverProgress();
    }

    private void OnOverPageRight(UIEvent e)
    {
        this.RegisterMouseOverProgress();
    }

    private void OnPageLeftPressed(UIEvent e)
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CM_PAGE_TURNED);
        SoundManager.Get().LoadAndPlay("collection_manager_book_page_flip_back");
        this.PageLeft(null, null);
    }

    private void OnPageRightPressed(UIEvent e)
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CM_PAGE_TURNED);
        SoundManager.Get().LoadAndPlay("collection_manager_book_page_flip_forward");
        this.PageRight(null, null);
    }

    private void OnPageTurnComplete(object callbackData)
    {
        TransitionReadyCallbackData data = callbackData as TransitionReadyCallbackData;
        CollectionPageDisplay assembledPage = data.m_assembledPage;
        CollectionPageDisplay otherPage = data.m_otherPage;
        switch (data.m_transitionType)
        {
            case PageTransitionType.SINGLE_PAGE_LEFT:
                this.PositionCurrentPage(assembledPage);
                this.PositionNextPage(otherPage);
                break;
        }
        otherPage.DisableCardInput();
        assembledPage.EnableCardInput();
        if (data.m_callback != null)
        {
            data.m_callback(data.m_callbackData);
        }
    }

    private void OnPagingArrowLoaded(string name, GameObject go, object callbackData)
    {
        if (go != null)
        {
            if (this.m_pageLeftArrow == null)
            {
                this.m_pageLeftArrow = go;
                this.m_pageLeftArrow.transform.parent = base.transform;
                this.m_pageLeftArrow.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                this.m_pageLeftArrow.transform.position = this.m_pageLeftArrowBone.transform.position;
                this.m_pageLeftArrow.transform.localScale = Vector3.zero;
                bool enabled = this.m_pageLeftClickableRegion.enabled;
                this.ShowArrow(this.m_pageLeftArrow, enabled);
            }
            if (this.m_pageRightArrow == null)
            {
                this.m_pageRightArrow = (GameObject) UnityEngine.Object.Instantiate(this.m_pageLeftArrow);
                this.m_pageRightArrow.transform.parent = base.transform;
                this.m_pageRightArrow.transform.localEulerAngles = Vector3.zero;
                this.m_pageRightArrow.transform.position = this.m_pageRightArrowBone.transform.position;
                this.m_pageRightArrow.transform.localScale = Vector3.zero;
                bool show = this.m_pageRightClickableRegion.enabled;
                this.ShowArrow(this.m_pageRightArrow, show);
            }
        }
    }

    private void PageLeft(DelOnPageTransitionComplete callback, object callbackData)
    {
        this.m_currentPageNum--;
        this.TransitionPageWhenReady(PageTransitionType.SINGLE_PAGE_LEFT, true, callback, callbackData);
    }

    private void PageRight(DelOnPageTransitionComplete callback, object callbackData)
    {
        this.m_currentPageNum++;
        this.TransitionPageWhenReady(PageTransitionType.SINGLE_PAGE_RIGHT, true, callback, callbackData);
    }

    private void PermanentlyDestroyArrows()
    {
        this.HideThenDestroyArrow(this.m_pageLeftArrow);
        this.m_pageLeftArrow = null;
        this.HideThenDestroyArrow(this.m_pageRightArrow);
        this.m_pageRightArrow = null;
    }

    private void PositionClassTabs(bool animate)
    {
        Vector3 position = this.m_classTabContainer.transform.position;
        for (int i = 0; i < CLASS_TAB_ORDER.Length; i++)
        {
            Vector3 localPosition;
            CollectionClassTab tab = this.m_classTabs[i];
            TAG_CLASS tabClass = tab.GetClass();
            if (this.ShouldShowTab(tabClass))
            {
                tab.SetTargetVisibility(true);
                position.x += SPACE_BETWEEN_TABS;
                position.x += this.m_deselectedClassTabHalfWidth;
                localPosition = this.m_classTabContainer.transform.InverseTransformPoint(position);
                if (tab == this.m_currentClassTab)
                {
                    localPosition.y = SELECTED_CLASS_TAB_LOCAL_Y_POS;
                }
                position.x += this.m_deselectedClassTabHalfWidth;
            }
            else
            {
                tab.SetTargetVisibility(false);
                localPosition = tab.transform.localPosition;
                localPosition.z = HIDDEN_TAB_LOCAL_Z_POS;
            }
            if (animate)
            {
                tab.SetTargetLocalPosition(localPosition);
            }
            else
            {
                tab.SetIsVisible(tab.ShouldBeVisible());
                tab.transform.localPosition = localPosition;
            }
        }
        if (animate)
        {
            base.StopCoroutine(ANIMATE_TABS_COROUTINE_NAME);
            base.StartCoroutine(ANIMATE_TABS_COROUTINE_NAME);
        }
    }

    private void PositionCurrentPage(CollectionPageDisplay page)
    {
        page.transform.localPosition = CURRENT_PAGE_LOCAL_POS;
    }

    private void PositionNextPage(CollectionPageDisplay page)
    {
        page.transform.localPosition = NEXT_PAGE_LOCAL_POS;
    }

    private void PositionPreviousPage(CollectionPageDisplay page)
    {
        page.transform.localPosition = PREV_PAGE_LOCAL_POS;
    }

    public void RefreshCurrentPageContents()
    {
        this.RefreshCurrentPageContents(null, null);
    }

    public void RefreshCurrentPageContents(DelOnPageTransitionComplete callback, object callbackData)
    {
        this.UpdateSortedCollectionFromFilterSet();
        this.TransitionPageWhenReady(PageTransitionType.NONE, true, callback, callbackData);
    }

    private void RegisterMouseOverProgress()
    {
        int @int = Options.Get().GetInt(Option.PAGE_MOUSE_OVERS);
        int val = @int + 1;
        if (@int < MAX_MOUSE_OVERS)
        {
            Options.Get().SetInt(Option.PAGE_MOUSE_OVERS, val);
        }
        if (val >= MAX_MOUSE_OVERS)
        {
            this.PermanentlyDestroyArrows();
        }
    }

    private void RemoveAllClassFilters()
    {
        this.RemoveAllClassFilters(null, null);
    }

    private void RemoveAllClassFilters(DelOnPageTransitionComplete callback, object callbackData)
    {
        this.m_classConstraint = TAG_CLASS.NONE;
        this.m_filterSet.RemoveAllGameFiltersByTag(GAME_TAG.CLASS);
        this.UpdateSortedCollectionFromFilterSet();
        this.TransitionPageWhenReady(PageTransitionType.NONE, false, callback, callbackData);
    }

    public void RemoveSearchTextFilter()
    {
        this.RemoveSearchTextFilter(null, null);
    }

    public void RemoveSearchTextFilter(DelOnPageTransitionComplete callback, object callbackData)
    {
        if (!this.m_filterSet.IsTextFilterEmpty())
        {
            this.m_filterSet.RemoveTextFilter();
            this.UpdateSortedCollectionFromFilterSet();
            this.TransitionPageWhenReady(PageTransitionType.NONE, false, callback, callbackData);
        }
    }

    [DebuggerHidden]
    private IEnumerator SelectTabWhenReady(CollectionClassTab tab)
    {
        return new <SelectTabWhenReady>c__Iterator14 { tab = tab, <$>tab = tab, <>f__this = this };
    }

    private void SetCurrentClassTab(TAG_CLASS? tabClass)
    {
        <SetCurrentClassTab>c__AnonStorey131 storey = new <SetCurrentClassTab>c__AnonStorey131 {
            tabClass = tabClass
        };
        if (storey.tabClass.HasValue)
        {
            CollectionClassTab tab = this.m_classTabs.Find(new Predicate<CollectionClassTab>(storey.<>m__21));
            if ((tab != null) && (tab != this.m_currentClassTab))
            {
                this.DeselectCurrentClassTab();
                this.m_currentClassTab = tab;
                base.StopCoroutine(SELECT_TAB_COROUTINE_NAME);
                base.StartCoroutine(SELECT_TAB_COROUTINE_NAME, this.m_currentClassTab);
            }
        }
    }

    private void SetUpClassTabs()
    {
        for (int i = 0; i < CLASS_TAB_ORDER.Length; i++)
        {
            TAG_CLASS classTag = CLASS_TAB_ORDER[i];
            CollectionClassTab item = (CollectionClassTab) UnityEngine.Object.Instantiate(this.m_classTabPrefab);
            item.Init(classTag);
            item.transform.parent = this.m_classTabContainer.transform;
            item.transform.localScale = CLASS_TAB_LOCAL_SCALE;
            item.transform.localEulerAngles = CLASS_TAB_LOCAL_EULERS;
            item.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnClassTabPressed));
            this.m_classTabs.Add(item);
            this.m_classTabVisibleMap[classTag] = true;
            if (i <= 0)
            {
                this.m_deselectedClassTabHalfWidth = item.GetComponent<BoxCollider>().bounds.extents.x;
            }
        }
        this.PositionClassTabs(false);
        this.m_initializedTabPositions = true;
    }

    private bool ShouldShowTab(TAG_CLASS tabClass)
    {
        if (!this.m_initializedTabPositions)
        {
            return true;
        }
        bool flag = this.m_sortedCollection.GetNumPagesForClass(tabClass) > 0;
        if ((this.m_classConstraint != TAG_CLASS.NONE) && ((tabClass != this.m_classConstraint) && (tabClass != TAG_CLASS.NONE)))
        {
            return false;
        }
        return flag;
    }

    private void ShowArrow(GameObject arrow, bool show)
    {
        if ((arrow != null) && !this.m_delayShowingArrows)
        {
            Vector3 vector = !show ? Vector3.zero : ARROW_LOCAL_SCALE;
            iTween.EaseType type = !show ? iTween.EaseType.linear : iTween.EaseType.easeOutElastic;
            object[] args = new object[] { "scale", vector, "time", ARROW_SCALE_TIME, "easetype", type, "name", "scale" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(arrow, "scale");
            iTween.ScaleTo(arrow, hashtable);
        }
    }

    public void ShowCardsNotOwned(bool includePremiums)
    {
        this.ShowCardsNotOwned(includePremiums, null, null);
    }

    public void ShowCardsNotOwned(bool includePremiums, DelOnPageTransitionComplete callback, object callbackData)
    {
        List<CardFlair> flairTypes = new List<CardFlair> {
            new CardFlair(0)
        };
        if (includePremiums)
        {
            flairTypes.Add(new CardFlair(CardFlair.PremiumType.FOIL));
        }
        this.m_filterSet.IncludeCardsNotOwned(flairTypes);
        this.UpdateSortedCollectionFromFilterSet();
        this.TransitionPageWhenReady(PageTransitionType.NONE, false, callback, callbackData);
    }

    public void ShowOnlyCardsIOwn()
    {
        this.ShowOnlyCardsIOwn(null, null);
    }

    public void ShowOnlyCardsIOwn(DelOnPageTransitionComplete callback, object callbackData)
    {
        this.m_filterSet.IncludeCardsNotOwned(new List<CardFlair>());
        this.UpdateSortedCollectionFromFilterSet();
        this.TransitionPageWhenReady(PageTransitionType.NONE, false, callback, callbackData);
    }

    private void Start()
    {
        this.SetUpClassTabs();
        CollectionPageDisplay alternatePage = this.GetAlternatePage();
        CollectionPageDisplay currentPage = this.GetCurrentPage();
        this.AssembleEmptyPageUI(alternatePage, false);
        this.AssembleEmptyPageUI(currentPage, false);
        this.PositionNextPage(alternatePage);
        this.PositionCurrentPage(currentPage);
        this.UpdateMassDisenchant();
        this.m_fullyLoaded = true;
    }

    private void SwapCurrentAndAltPages()
    {
        this.m_currentPageIsPageA = !this.m_currentPageIsPageA;
    }

    private void TransitionPage(object callbackData)
    {
        TransitionReadyCallbackData data = callbackData as TransitionReadyCallbackData;
        CollectionPageDisplay assembledPage = data.m_assembledPage;
        CollectionPageDisplay otherPage = data.m_otherPage;
        switch (data.m_transitionType)
        {
            case PageTransitionType.NONE:
            case PageTransitionType.MANY_PAGE_RIGHT:
            case PageTransitionType.MANY_PAGE_LEFT:
                this.PositionNextPage(otherPage);
                this.PositionCurrentPage(assembledPage);
                this.OnPageTurnComplete(data);
                break;

            case PageTransitionType.SINGLE_PAGE_RIGHT:
                this.m_pageTurn.TurnRight(otherPage.gameObject, assembledPage.gameObject, new PageTurn.DelOnPageTurnComplete(this.OnPageTurnComplete), data);
                this.PositionCurrentPage(assembledPage);
                this.PositionNextPage(otherPage);
                break;

            case PageTransitionType.SINGLE_PAGE_LEFT:
                this.m_pageTurn.TurnLeft(assembledPage.gameObject, otherPage.gameObject, new PageTurn.DelOnPageTurnComplete(this.OnPageTurnComplete), data);
                base.StopCoroutine(PAGE_LEFT_COMPLETE_COROUTINE_NAME);
                base.StartCoroutine(PAGE_LEFT_COMPLETE_COROUTINE_NAME, data);
                break;
        }
        this.UpdateVisibleClassTabs();
        if (MASS_DISENCHANT_PAGE_NUM == this.m_currentPageNum)
        {
            this.DeselectCurrentClassTab();
            this.m_massDisenchantTab.Select();
        }
        else
        {
            TAG_CLASS? tabClass = null;
            if (this.m_preSearchArtStackAnchor != null)
            {
                tabClass = new TAG_CLASS?(DefLoader.Get().GetEntityDef(this.m_preSearchArtStackAnchor.CardID).GetClass());
            }
            this.SetCurrentClassTab(tabClass);
            this.m_massDisenchantTab.Deselect();
        }
    }

    private void TransitionPageWhenReady(PageTransitionType transitionType, bool useCurrentPageNum, DelOnPageTransitionComplete callback, object callbackData)
    {
        TAG_CLASS tag_class;
        List<FilteredArtStack> pageContents;
        this.SwapCurrentAndAltPages();
        if (useCurrentPageNum)
        {
            pageContents = this.m_sortedCollection.GetPageContents(this.m_currentPageNum, out tag_class);
        }
        else if (this.m_preSearchArtStackAnchor == null)
        {
            this.m_currentPageNum = 1;
            pageContents = this.m_sortedCollection.GetPageContents(this.m_currentPageNum, out tag_class);
        }
        else
        {
            int num;
            pageContents = this.m_sortedCollection.GetPageContentsForCard(this.m_preSearchArtStackAnchor.CardID, this.m_preSearchArtStackAnchor.Flair, out tag_class, out num);
            if (pageContents.Count == 0)
            {
                pageContents = this.m_sortedCollection.GetPageContentsForClass(DefLoader.Get().GetEntityDef(this.m_preSearchArtStackAnchor.CardID).GetClass(), 1, true, out num);
            }
            this.m_currentPageNum = num;
        }
        if ((MASS_DISENCHANT_PAGE_NUM != this.m_currentPageNum) && (pageContents.Count == 0))
        {
            TAG_CLASS tag_class2;
            int num2;
            pageContents = this.m_sortedCollection.GetFirstNonEmptyPage(out tag_class2, out num2);
            if (pageContents.Count > 0)
            {
                tag_class = tag_class2;
                this.m_currentPageNum = num2;
            }
        }
        TransitionReadyCallbackData data2 = new TransitionReadyCallbackData {
            m_assembledPage = this.GetCurrentPage(),
            m_otherPage = this.GetAlternatePage(),
            m_transitionType = transitionType,
            m_callback = callback,
            m_callbackData = callbackData
        };
        TransitionReadyCallbackData transitionReadyCallbackData = data2;
        this.AssemblePage(transitionReadyCallbackData, pageContents, tag_class);
    }

    public void UpdateClassTabNewCardCounts()
    {
        foreach (CollectionClassTab tab in this.m_classTabs)
        {
            TAG_CLASS cardClass = tab.GetClass();
            int numNewCardsForClass = this.m_sortedCollection.GetNumNewCardsForClass(cardClass);
            tab.UpdateNewCardCount(numNewCardsForClass);
        }
    }

    public void UpdateCurrentPageCardLocks()
    {
        this.GetCurrentPage().UpdateCurrentPageCardLocks();
    }

    private void UpdateMassDisenchant()
    {
        this.m_massDisenchant.UpdateContents(CollectionManager.Get().GetMassDisenchantArtStacks());
        int totalAmount = this.m_massDisenchant.GetTotalAmount();
        this.m_massDisenchantTab.SetAmount(totalAmount);
        this.UpdateMassDisenchantTabVisibility();
    }

    public void UpdateMassDisenchantTabVisibility()
    {
        if ((this.m_massDisenchant.GetTotalAmount() > 0) && !CollectionDeckTray.Get().IsShowingDeckContents())
        {
            this.m_massDisenchantTab.Show();
        }
        else
        {
            this.m_massDisenchantTab.Hide();
        }
    }

    public void UpdateNumMouseOvers()
    {
        if (Options.Get().GetInt(Option.PAGE_MOUSE_OVERS) < MAX_MOUSE_OVERS)
        {
            this.LoadPagingArrows();
        }
        else
        {
            this.PermanentlyDestroyArrows();
        }
    }

    private void UpdateSortedCollectionFromFilterSet()
    {
        this.m_sortedCollection.UpdateFromResults(this.m_filterSet.GenerateList());
        this.UpdateClassTabNewCardCounts();
    }

    private void UpdateVisibleClassTabs()
    {
        bool flag = false;
        foreach (CollectionClassTab tab in this.m_classTabs)
        {
            TAG_CLASS tabClass = tab.GetClass();
            bool flag2 = this.m_classTabVisibleMap[tabClass];
            this.m_classTabVisibleMap[tabClass] = this.ShouldShowTab(tabClass);
            if (flag2 != this.m_classTabVisibleMap[tabClass])
            {
                flag = true;
            }
        }
        if (flag)
        {
            this.PositionClassTabs(true);
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitThenCompletePageLeft(object callbackData)
    {
        return new <WaitThenCompletePageLeft>c__Iterator15 { callbackData = callbackData, <$>callbackData = callbackData, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitThenShowArrows()
    {
        return new <WaitThenShowArrows>c__Iterator16 { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <AnimateTabs>c__Iterator13 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<CollectionClassTab>.Enumerator <$s_170>__3;
        internal List<CollectionClassTab>.Enumerator <$s_171>__5;
        internal List<CollectionClassTab>.Enumerator <$s_172>__7;
        internal List<CollectionClassTab>.Enumerator <$s_173>__9;
        internal CollectionPageManager <>f__this;
        internal CollectionClassTab <tab>__10;
        internal CollectionClassTab <tab>__4;
        internal CollectionClassTab <tab>__6;
        internal CollectionClassTab <tab>__8;
        internal List<CollectionClassTab> <tabsToHide>__0;
        internal List<CollectionClassTab> <tabsToMove>__2;
        internal List<CollectionClassTab> <tabsToShow>__1;

        [DebuggerHidden]
        public void Dispose()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 1:
                    try
                    {
                    }
                    finally
                    {
                        this.<$s_171>__5.Dispose();
                    }
                    break;
            }
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            bool flag = false;
            switch (num)
            {
                case 0:
                    this.<tabsToHide>__0 = new List<CollectionClassTab>();
                    this.<tabsToShow>__1 = new List<CollectionClassTab>();
                    this.<tabsToMove>__2 = new List<CollectionClassTab>();
                    this.<$s_170>__3 = this.<>f__this.m_classTabs.GetEnumerator();
                    try
                    {
                        while (this.<$s_170>__3.MoveNext())
                        {
                            this.<tab>__4 = this.<$s_170>__3.Current;
                            if (this.<tab>__4.IsVisible() || this.<tab>__4.ShouldBeVisible())
                            {
                                if (this.<tab>__4.IsVisible() && this.<tab>__4.ShouldBeVisible())
                                {
                                    this.<tabsToMove>__2.Add(this.<tab>__4);
                                }
                                else if (this.<tab>__4.IsVisible() && !this.<tab>__4.ShouldBeVisible())
                                {
                                    this.<tabsToHide>__0.Add(this.<tab>__4);
                                }
                                else
                                {
                                    this.<tabsToShow>__1.Add(this.<tab>__4);
                                }
                                this.<tab>__4.SetIsVisible(this.<tab>__4.ShouldBeVisible());
                            }
                        }
                    }
                    finally
                    {
                        this.<$s_170>__3.Dispose();
                    }
                    this.<>f__this.m_tabsAreAnimating = true;
                    if (this.<tabsToHide>__0.Count <= 0)
                    {
                        goto Label_0222;
                    }
                    this.<$s_171>__5 = this.<tabsToHide>__0.GetEnumerator();
                    num = 0xfffffffd;
                    break;

                case 1:
                    break;

                case 2:
                    goto Label_0222;

                case 3:
                    goto Label_02AD;

                case 4:
                    goto Label_0339;

                default:
                    goto Label_034C;
            }
            try
            {
                switch (num)
                {
                    case 1:
                        this.<tab>__6.AnimateToTargetPosition(0.1f, iTween.EaseType.easeOutQuad);
                        break;
                }
                while (this.<$s_171>__5.MoveNext())
                {
                    this.<tab>__6 = this.<$s_171>__5.Current;
                    this.$current = new WaitForSeconds(0.03f);
                    this.$PC = 1;
                    flag = true;
                    goto Label_034E;
                }
            }
            finally
            {
                if (!flag)
                {
                }
                this.<$s_171>__5.Dispose();
            }
            this.$current = new WaitForSeconds(0.1f);
            this.$PC = 2;
            goto Label_034E;
        Label_0222:
            if (this.<tabsToMove>__2.Count > 0)
            {
                this.<$s_172>__7 = this.<tabsToMove>__2.GetEnumerator();
                try
                {
                    while (this.<$s_172>__7.MoveNext())
                    {
                        this.<tab>__8 = this.<$s_172>__7.Current;
                        this.<tab>__8.AnimateToTargetPosition(0.25f, iTween.EaseType.easeOutQuad);
                    }
                }
                finally
                {
                    this.<$s_172>__7.Dispose();
                }
                this.$current = new WaitForSeconds(0.25f);
                this.$PC = 3;
                goto Label_034E;
            }
        Label_02AD:
            if (this.<tabsToShow>__1.Count > 0)
            {
                this.<$s_173>__9 = this.<tabsToShow>__1.GetEnumerator();
                try
                {
                    while (this.<$s_173>__9.MoveNext())
                    {
                        this.<tab>__10 = this.<$s_173>__9.Current;
                        this.<tab>__10.AnimateToTargetPosition(0.4f, iTween.EaseType.easeOutBounce);
                    }
                }
                finally
                {
                    this.<$s_173>__9.Dispose();
                }
                this.$current = new WaitForSeconds(0.4f);
                this.$PC = 4;
                goto Label_034E;
            }
        Label_0339:
            this.<>f__this.m_tabsAreAnimating = false;
            this.$PC = -1;
        Label_034C:
            return false;
        Label_034E:
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
    private sealed class <SelectTabWhenReady>c__Iterator14 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionClassTab <$>tab;
        internal CollectionPageManager <>f__this;
        internal Vector3 <newClassTabPos>__0;
        internal Hashtable <scaleArgs>__1;
        internal CollectionClassTab tab;

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
                case 1:
                    if (this.<>f__this.m_tabsAreAnimating)
                    {
                        this.$current = 0;
                        this.$PC = 1;
                        return true;
                    }
                    if (this.<>f__this.m_currentClassTab == this.tab)
                    {
                        this.tab.SetSelected(true);
                        this.<newClassTabPos>__0 = this.tab.transform.localPosition;
                        this.<newClassTabPos>__0.y = CollectionPageManager.SELECTED_CLASS_TAB_LOCAL_Y_POS;
                        this.tab.transform.localPosition = this.<newClassTabPos>__0;
                        object[] args = new object[] { "scale", CollectionPageManager.SELECTED_CLASS_TAB_SCALE, "time", CollectionPageManager.SELECT_TAB_ANIM_TIME, "name", "scale" };
                        this.<scaleArgs>__1 = iTween.Hash(args);
                        iTween.ScaleTo(this.tab.gameObject, this.<scaleArgs>__1);
                        this.$PC = -1;
                    }
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
    private sealed class <SetCurrentClassTab>c__AnonStorey131
    {
        internal TAG_CLASS? tabClass;

        internal bool <>m__21(CollectionClassTab obj)
        {
            return (obj.GetClass() == ((TAG_CLASS) this.tabClass.Value));
        }
    }

    [CompilerGenerated]
    private sealed class <WaitThenCompletePageLeft>c__Iterator15 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal object <$>callbackData;
        internal CollectionPageManager <>f__this;
        internal float <flipTimePercent>__0;
        internal float <waitTime>__1;
        internal object callbackData;

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
                    this.<flipTimePercent>__0 = Mathf.Clamp(this.<>f__this.m_turnLeftPageSwapTiming, 0f, 1f);
                    this.<waitTime>__1 = this.<>f__this.m_pageTurn.GetLeftTurnAnimTime() * this.<flipTimePercent>__0;
                    this.$current = new WaitForSeconds(this.<waitTime>__1);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.OnPageTurnComplete(this.callbackData);
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
    private sealed class <WaitThenShowArrows>c__Iterator16 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionPageManager <>f__this;
        internal bool <showLeftArrow>__0;
        internal bool <showRightArrow>__1;

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
                    if ((this.<>f__this.m_pageLeftArrow != null) || (this.<>f__this.m_pageRightArrow != null))
                    {
                        this.<>f__this.m_delayShowingArrows = true;
                        this.$current = new WaitForSeconds(1f);
                        this.$PC = 1;
                        return true;
                    }
                    break;

                case 1:
                    this.<>f__this.m_delayShowingArrows = false;
                    this.<showLeftArrow>__0 = this.<>f__this.m_pageLeftClickableRegion.enabled;
                    this.<>f__this.ShowArrow(this.<>f__this.m_pageLeftArrow, this.<showLeftArrow>__0);
                    this.<showRightArrow>__1 = this.<>f__this.m_pageRightClickableRegion.enabled;
                    this.<>f__this.ShowArrow(this.<>f__this.m_pageRightArrow, this.<showRightArrow>__1);
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

    public delegate void DelOnPageTransitionComplete(object callbackData);

    public delegate void DelPageAssembledCallback(object callbackData);

    public class PageAssembledCallbackData
    {
        public CollectionPageManager.DelPageAssembledCallback m_callback;
        public object m_callbackData;
    }

    private enum PageTransitionType
    {
        NONE,
        SINGLE_PAGE_RIGHT,
        SINGLE_PAGE_LEFT,
        MANY_PAGE_RIGHT,
        MANY_PAGE_LEFT
    }

    private class SortedCollection
    {
        private List<FilteredArtStack>[] m_currentResultsByClass = new List<FilteredArtStack>[CollectionPageManager.CLASS_TAB_ORDER.Length];

        public SortedCollection()
        {
            for (int i = 0; i < this.m_currentResultsByClass.Length; i++)
            {
                this.m_currentResultsByClass[i] = new List<FilteredArtStack>();
            }
        }

        public List<FilteredArtStack> GetFirstNonEmptyPage(out TAG_CLASS pageClass, out int collectionPage)
        {
            collectionPage = 0;
            pageClass = TAG_CLASS.NONE;
            List<FilteredArtStack> list = new List<FilteredArtStack>();
            for (int i = 0; i < CollectionPageManager.CLASS_TAB_ORDER.Length; i++)
            {
                pageClass = CollectionPageManager.CLASS_TAB_ORDER[i];
                if (this.GetNumPagesForClass(CollectionPageManager.CLASS_TAB_ORDER[i]) != 0)
                {
                    return this.GetPageContentsForClass(pageClass, 1, true, out collectionPage);
                }
            }
            return list;
        }

        public int GetNumNewCardsForClass(TAG_CLASS cardClass)
        {
            int num = 0;
            int index = CollectionPageManager.CLASS_TO_TAB_IDX[cardClass];
            List<FilteredArtStack> list = this.m_currentResultsByClass[index];
            CollectionManagerDisplay display = CollectionManagerDisplay.Get();
            foreach (FilteredArtStack stack in list)
            {
                if (display.ShouldShowNewCardGlow(stack.CardID, stack.Flair))
                {
                    num++;
                }
            }
            return num;
        }

        public int GetNumPagesForClass(TAG_CLASS cardClass)
        {
            int index = CollectionPageManager.CLASS_TO_TAB_IDX[cardClass];
            return (int) Mathf.Ceil(((float) this.m_currentResultsByClass[index].Count) / ((float) CollectionPageDisplay.GetMaxNumCards()));
        }

        public List<FilteredArtStack> GetPageContents(int page, out TAG_CLASS pageClass)
        {
            pageClass = TAG_CLASS.NONE;
            List<FilteredArtStack> list = new List<FilteredArtStack>();
            if ((page >= 0) && (page <= this.GetTotalNumPages()))
            {
                int num = 0;
                for (int i = 0; i < CollectionPageManager.CLASS_TAB_ORDER.Length; i++)
                {
                    int num3 = num;
                    TAG_CLASS cardClass = CollectionPageManager.CLASS_TAB_ORDER[i];
                    num += this.GetNumPagesForClass(cardClass);
                    if (page <= num)
                    {
                        int num5;
                        pageClass = cardClass;
                        int pageWithinClass = page - num3;
                        return this.GetPageContentsForClass(cardClass, pageWithinClass, false, out num5);
                    }
                }
            }
            return list;
        }

        public List<FilteredArtStack> GetPageContentsForCard(string cardID, CardFlair flair, out TAG_CLASS pageClass, out int collectionPage)
        {
            <GetPageContentsForCard>c__AnonStorey132 storey = new <GetPageContentsForCard>c__AnonStorey132 {
                cardID = cardID,
                flair = flair
            };
            pageClass = DefLoader.Get().GetEntityDef(storey.cardID).GetClass();
            collectionPage = 0;
            int index = CollectionPageManager.CLASS_TO_TAB_IDX[pageClass];
            int num2 = this.m_currentResultsByClass[index].FindIndex(new Predicate<FilteredArtStack>(storey.<>m__22));
            if (num2 < 0)
            {
                return new List<FilteredArtStack>();
            }
            int maxNumCards = CollectionPageDisplay.GetMaxNumCards();
            int pageWithinClass = Mathf.CeilToInt(((float) (num2 + 1)) / ((float) maxNumCards));
            return this.GetPageContentsForClass(pageClass, pageWithinClass, true, out collectionPage);
        }

        public List<FilteredArtStack> GetPageContentsForClass(TAG_CLASS pageClass, int pageWithinClass, bool calculateCollectionPage, out int collectionPage)
        {
            List<FilteredArtStack> range = new List<FilteredArtStack>();
            collectionPage = 0;
            if ((pageWithinClass > 0) && (pageWithinClass <= this.GetNumPagesForClass(pageClass)))
            {
                int maxNumCards = CollectionPageDisplay.GetMaxNumCards();
                int index = CollectionPageManager.CLASS_TO_TAB_IDX[pageClass];
                int num3 = (pageWithinClass - 1) * maxNumCards;
                int count = Math.Min(this.m_currentResultsByClass[index].Count - num3, maxNumCards);
                range = this.m_currentResultsByClass[index].GetRange(num3, count);
                if (!calculateCollectionPage)
                {
                    return range;
                }
                for (int i = 0; i < CollectionPageManager.CLASS_TAB_ORDER.Length; i++)
                {
                    TAG_CLASS cardClass = CollectionPageManager.CLASS_TAB_ORDER[i];
                    if (cardClass == pageClass)
                    {
                        break;
                    }
                    collectionPage += this.GetNumPagesForClass(cardClass);
                }
                collectionPage += pageWithinClass;
            }
            return range;
        }

        public int GetTotalNumPages()
        {
            int num = 0;
            foreach (TAG_CLASS tag_class in CollectionPageManager.CLASS_TAB_ORDER)
            {
                num += this.GetNumPagesForClass(tag_class);
            }
            return num;
        }

        public void UpdateFromResults(List<FilteredArtStack> results)
        {
            for (int i = 0; i < this.m_currentResultsByClass.Length; i++)
            {
                this.m_currentResultsByClass[i].Clear();
            }
            results.Sort();
            for (int j = 0; j < results.Count; j++)
            {
                FilteredArtStack item = results[j];
                EntityDef entityDef = DefLoader.Get().GetEntityDef(item.CardID);
                if (entityDef == null)
                {
                    Log.Rachelle.Print("SortedCollection.UpdateFromResults(): null entity def!!!");
                }
                else
                {
                    TAG_CLASS key = entityDef.GetClass();
                    if (!CollectionPageManager.CLASS_TO_TAB_IDX.ContainsKey(key))
                    {
                        Log.Rachelle.Print(string.Format("CLASS_TO_TAB_IDX does not contain key {0}", key));
                    }
                    int index = CollectionPageManager.CLASS_TO_TAB_IDX[key];
                    this.m_currentResultsByClass[index].Add(item);
                }
            }
        }

        [CompilerGenerated]
        private sealed class <GetPageContentsForCard>c__AnonStorey132
        {
            internal string cardID;
            internal CardFlair flair;

            internal bool <>m__22(FilteredArtStack obj)
            {
                return (obj.CardID.Equals(this.cardID) && obj.Flair.Equals(this.flair));
            }
        }
    }

    private class TransitionReadyCallbackData
    {
        public CollectionPageDisplay m_assembledPage;
        public CollectionPageManager.DelOnPageTransitionComplete m_callback;
        public object m_callbackData;
        public CollectionPageDisplay m_otherPage;
        public CollectionPageManager.PageTransitionType m_transitionType;
    }
}


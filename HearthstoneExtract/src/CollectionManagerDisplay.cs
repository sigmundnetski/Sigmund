using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionManagerDisplay : MonoBehaviour
{
    private readonly Vector3 ACTIVE_SEARCH_LOCAL_SCALE = new Vector3(2.5f, 2.5f, 2.5f);
    private readonly float HIDE_OBJECTS_ANIM_TIME = 0.5f;
    public GameObject m_activeSearchBone;
    private CollectionActorPool m_actorPool = new CollectionActorPool();
    private Dictionary<NetCache.CardDefinition, Actor> m_actorsToDisplay = new Dictionary<NetCache.CardDefinition, Actor>();
    public Material m_cardNotOwnedMeshMaterial;
    private List<Achievement> m_completeAchievesToDisplay = new List<Achievement>();
    public CollectionCoverDisplay m_cover;
    private List<Actor> m_currActorList;
    private List<CollectionDeckBoxVisual> m_deckBoxes;
    private Notification m_deckHelpPopup;
    private int m_displayRequestID;
    private List<NetCache.CardDefinition> m_failedToLoadActors = new List<NetCache.CardDefinition>();
    public Material m_foilCardNotOwnedMeshMaterial;
    private Vector3 m_inactiveSearchLocalPos;
    private Vector3 m_inactiveSearchLocalSize;
    private Notification m_innkeeperLClickReminder;
    public PegUIElement m_inputBlocker;
    private List<Actor> m_lastActorList;
    private Dictionary<TAG_CLASS, Texture> m_loadedClassTextures = new Dictionary<TAG_CLASS, Texture>();
    public ManaFilterTabManager m_manaTabManager;
    private Notification m_massDisenchantHelpPopup;
    public CollectionCardLock m_maxDeckCopiesLockPrefab;
    private bool m_netCacheReady;
    public CollectionCardLock m_noMoreInstancesLockPrefab;
    private List<Actor> m_obsoleteActors;
    private PackOpening m_packOpening;
    public CollectionPageManager m_pageManager;
    private Dictionary<TAG_CLASS, TextureRequests> m_requestedClassTextures = new Dictionary<TAG_CLASS, TextureRequests>();
    public CollectionSearch m_search;
    private bool m_selectingNewDeckHero;
    private bool m_showAdvancedCM;
    private Notification m_showAllCardsPopup;
    public ShowAllCardsTab m_showAllCardsTab;
    private Vector3 m_showAllCardsTabOrigPos;
    private long m_showDeckContentsRequest;
    private bool m_unloading;
    private bool m_waitingForPackOpeningAsset;
    private bool m_waitingForPackOpeningNetData = true;
    private bool m_waitingToShowPackOpening;
    private static CollectionManagerDisplay s_instance;
    private readonly float SEARCH_ANIM_TIME = 0.1f;
    private readonly Vector3 TUTORIAL_CRAFT_DECK_SCALE = new Vector3(6f, 6f, 6f);

    private void AnimateCardsNotOwnedTab(bool show)
    {
        Vector3 showAllCardsTabOrigPos = this.m_showAllCardsTabOrigPos;
        if (show)
        {
            showAllCardsTabOrigPos.z += -3.13717f;
        }
        object[] args = new object[] { "position", showAllCardsTabOrigPos, "time", this.HIDE_OBJECTS_ANIM_TIME, "easeType", iTween.EaseType.easeOutQuad, "name", "position" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_showAllCardsTab.gameObject, "position");
        iTween.MoveTo(this.m_showAllCardsTab.gameObject, hashtable);
    }

    private void Awake()
    {
        s_instance = this;
        CheatMgr.Get().RegisterCheatHandler("help", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_help));
        this.m_showAllCardsTabOrigPos = this.m_showAllCardsTab.transform.position;
        this.m_inactiveSearchLocalPos = this.m_search.transform.localPosition;
        this.m_inactiveSearchLocalSize = this.m_search.transform.localScale;
        this.m_waitingForPackOpeningNetData = true;
        NetCache.Get().RegisterScreenPackOpening(new NetCache.NetCacheCallback(this.OnPackOpeningNetCacheReady), new NetCache.ErrorCallback(NetCache.DefaultErrorHandler));
        this.m_actorPool.Initialize();
        this.LoadAllClassTextures();
        this.EnableInput(true);
        if (CollectionManager.Get().IsWaitingToShowPackOpening())
        {
            this.ShowPackOpeningWhenReady();
        }
        base.StartCoroutine(this.InitCollectionWhenReady());
    }

    private void CheckAndFinishDisplayList(DisplayCallbackData displayCallbackData)
    {
        if (displayCallbackData.m_requestID != this.m_displayRequestID)
        {
            Log.Rachelle.Print("CollectionManagerDisplay.CheckAndFinishDisplayList(): bailing early; outdated request ID.");
        }
        else
        {
            List<Actor> actorList = new List<Actor>();
            for (int i = 0; i < displayCallbackData.m_requestedCardDefinitions.Count; i++)
            {
                NetCache.CardDefinition key = displayCallbackData.m_requestedCardDefinitions[i];
                if (this.m_actorsToDisplay.ContainsKey(key))
                {
                    if (this.m_actorsToDisplay[key] == null)
                    {
                        return;
                    }
                    actorList.Add(this.m_actorsToDisplay[key]);
                }
                else if (!this.m_failedToLoadActors.Contains(key))
                {
                    return;
                }
            }
            this.UpdateCurrentActorList(actorList);
            displayCallbackData.m_callback(actorList, displayCallbackData.m_callbackData);
        }
    }

    public void CollectionPageContentsChanged(List<FilteredArtStack> artStacksToDisplay, CollectionActorsReadyCallback callback, object callbackData)
    {
        this.SetDisplayList(artStacksToDisplay, callback, callbackData);
    }

    private void DoBookClosingAnimations()
    {
        this.m_cover.Close();
        this.AnimateCardsNotOwnedTab(false);
        this.m_manaTabManager.ActivateTabs(false);
    }

    private void DoBookOpeningAnimations()
    {
        this.m_cover.Open(new CollectionCoverDisplay.DelOnOpened(this.OnCoverOpened));
        this.AnimateCardsNotOwnedTab(true);
        this.m_manaTabManager.ActivateTabs(true);
    }

    private void DoEnterCollectionManagerEvents()
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_COLLECTION_MANAGER);
        if (CollectionManager.Get().HasVisitedCollection())
        {
            this.EnableInput(true);
            this.OpenBookImmediately();
        }
        else
        {
            CollectionManager.Get().SetHasVisitedCollection(true);
            this.EnableInput(false);
            base.StartCoroutine(this.OpenBookWhenReady());
        }
    }

    private void EnableInput(bool enable)
    {
        this.m_inputBlocker.gameObject.SetActive(!enable);
    }

    private void EnterSearchMode(UIEvent e)
    {
        this.EnableInput(false);
        object[] args = new object[] { "position", this.m_activeSearchBone.transform.position, "isLocal", false, "time", this.SEARCH_ANIM_TIME, "easetype", iTween.EaseType.linear, "name", "searchPos", "oncomplete", "OnSearchActivated", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_search.gameObject, "searchPos");
        iTween.MoveTo(this.m_search.gameObject, hashtable);
        object[] objArray2 = new object[] { "scale", this.ACTIVE_SEARCH_LOCAL_SCALE, "isLocal", true, "time", this.SEARCH_ANIM_TIME, "easetype", iTween.EaseType.easeInOutCubic, "name", "searchScale" };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.StopByName(this.m_search.gameObject, "searchScale");
        iTween.ScaleTo(this.m_search.gameObject, hashtable2);
    }

    public void EnterSelectNewDeckHeroMode()
    {
        this.EnableInput(false);
        this.m_selectingNewDeckHero = true;
    }

    public void Exit()
    {
        this.EnableInput(false);
        NotificationManager.Get().DestroyNotification(this.m_deckHelpPopup, 0f);
        SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
    }

    private void ExitSearchMode(string searchText)
    {
        this.EnableInput(true);
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CM_CARDS_SEARCHED);
        this.m_pageManager.ChangeSearchTextFilter(searchText);
        object[] args = new object[] { "scale", this.m_inactiveSearchLocalSize, "isLocal", true, "time", this.SEARCH_ANIM_TIME, "easetype", iTween.EaseType.easeInOutCubic, "name", "searchScale" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_search.gameObject, "searchScale");
        iTween.ScaleTo(this.m_search.gameObject, hashtable);
        object[] objArray2 = new object[] { "position", this.m_inactiveSearchLocalPos, "isLocal", true, "time", this.SEARCH_ANIM_TIME, "easetype", iTween.EaseType.linear, "name", "searchPos", "oncomplete", "OnSearchDeactivated", "oncompletetarget", base.gameObject };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.StopByName(this.m_search.gameObject, "searchPos");
        iTween.MoveTo(this.m_search.gameObject, hashtable2);
    }

    public void ExitSelectNewDeckHeroMode()
    {
        this.EnableInput(true);
        this.m_selectingNewDeckHero = false;
    }

    public void FilterByManaCost(int cost)
    {
        this.m_pageManager.FilterByManaCost(cost);
    }

    public void FinishDeckTileMove(CollectionDeckTileVisual tile)
    {
        tile.Show();
        tile.GetActor().GetSpell(SpellType.SUMMON_IN).ActivateState(SpellStateType.BIRTH);
        tile.GetMovingActor().Hide();
        UnityEngine.Object.Destroy(tile.GetMovingActor().gameObject);
    }

    public static CollectionManagerDisplay Get()
    {
        return s_instance;
    }

    public Material GetCardNotOwnedMeshMaterial()
    {
        return this.m_cardNotOwnedMeshMaterial;
    }

    public void GetClassTexture(TAG_CLASS classTag, DelTextureLoaded callback, object callbackData)
    {
        if (this.m_loadedClassTextures.ContainsKey(classTag))
        {
            callback(classTag, this.m_loadedClassTextures[classTag], callbackData);
        }
        else
        {
            TextureRequests requests;
            if (this.m_requestedClassTextures.ContainsKey(classTag))
            {
                requests = this.m_requestedClassTextures[classTag];
            }
            else
            {
                requests = new TextureRequests();
                this.m_requestedClassTextures[classTag] = requests;
            }
            TextureRequests.Request item = new TextureRequests.Request {
                m_callback = callback,
                m_callbackData = callbackData
            };
            requests.m_requests.Add(item);
        }
    }

    public static string GetClassTextureName(TAG_CLASS classTag)
    {
        switch (classTag)
        {
            case TAG_CLASS.DEATHKNIGHT:
                return "DeathKnight";

            case TAG_CLASS.DRUID:
                return "Druid";

            case TAG_CLASS.HUNTER:
                return "Hunter";

            case TAG_CLASS.MAGE:
                return "Mage";

            case TAG_CLASS.PALADIN:
                return "Paladin";

            case TAG_CLASS.PRIEST:
                return "Priest";

            case TAG_CLASS.ROGUE:
                return "Rogue";

            case TAG_CLASS.SHAMAN:
                return "Shaman";

            case TAG_CLASS.WARLOCK:
                return "Warlock";

            case TAG_CLASS.WARRIOR:
                return "Warrior";
        }
        return string.Empty;
    }

    private TAG_CLASS GetDeckHeroClass(long deckID)
    {
        CollectionDeck deck = CollectionManager.Get().GetDeck(deckID);
        if (deck == null)
        {
            Log.Derek.Print(string.Format("CollectionManagerDisplay no deck with ID {0}!", deckID));
            return TAG_CLASS.NONE;
        }
        EntityDef entityDef = DefLoader.Get().GetEntityDef(deck.HeroCardID);
        if (entityDef == null)
        {
            Log.Derek.Print(string.Format("CollectionManagerDisplay: CollectionManager doesn't have an entity def for {0}!", deck.HeroCardID));
            return TAG_CLASS.NONE;
        }
        return entityDef.GetClass();
    }

    public Material GetFoilCardNotOwnedMeshMaterial()
    {
        return this.m_foilCardNotOwnedMeshMaterial;
    }

    public CollectionCardLock GetMaxDeckCopiesLockPrefab()
    {
        return this.m_maxDeckCopiesLockPrefab;
    }

    public CollectionCardLock GetNoMoreInstancesLockPrefab()
    {
        return this.m_noMoreInstancesLockPrefab;
    }

    public RDM_Deck GetRDMDeck()
    {
        CollectionDeck deck = CollectionManager.Get().GetDeck(CollectionDeckTray.Get().GetCurrentlyViewedDeckID());
        RDM_Deck deck2 = new RDM_Deck(DefLoader.Get().GetEntityDef(deck.HeroCardID));
        foreach (CollectionDeckSlot slot in deck.GetSlots())
        {
            for (int i = 0; i < slot.Count; i++)
            {
                RDMDeckEntry item = new RDMDeckEntry(DefLoader.Get().GetEntityDef(slot.CardID), new CardFlair(slot.Premium));
                deck2.deckList.Add(item);
            }
        }
        return deck2;
    }

    public void GoToPageWithCard(string cardID, CardFlair flair)
    {
        this.m_pageManager.JumpToPageWithCard(cardID, flair);
    }

    public void HideAllTips()
    {
        this.HideShowCardsPopup();
        if (this.m_innkeeperLClickReminder != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.m_innkeeperLClickReminder);
        }
        if (this.m_massDisenchantHelpPopup != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.m_massDisenchantHelpPopup);
        }
    }

    private void HideShowCardsPopup()
    {
        if (this.m_showAllCardsPopup != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.m_showAllCardsPopup);
        }
    }

    [DebuggerHidden]
    private IEnumerator InitCollectionWhenReady()
    {
        return new <InitCollectionWhenReady>c__IteratorC { <>f__this = this };
    }

    private void InputBlockerPress(UIEvent e)
    {
        if (this.m_search.IsActive())
        {
            this.m_search.Deactivate();
        }
    }

    public bool IsShowAllCardsChecked()
    {
        return this.m_showAllCardsTab.IsShowAllChecked();
    }

    public bool IsShowingPackOpening()
    {
        if (this.m_packOpening == null)
        {
            return false;
        }
        return this.m_packOpening.IsShown();
    }

    private bool LoadActorsForCardDefinition(NetCache.CardDefinition cardDefinition, DisplayCallbackData displayCallbackData)
    {
        if (this.m_actorsToDisplay.Count == CollectionPageDisplay.GetMaxNumCards())
        {
            return false;
        }
        EntityDef entityDef = DefLoader.Get().GetEntityDef(cardDefinition.Name);
        AcquireActorCallbackData data2 = new AcquireActorCallbackData {
            m_cardDefinition = cardDefinition,
            m_displayCallbackData = displayCallbackData
        };
        AcquireActorCallbackData callbackData = data2;
        this.m_actorsToDisplay.Add(cardDefinition, null);
        return this.m_actorPool.AcquireActor(entityDef, new CardFlair(cardDefinition.Premium), new CollectionActorPool.AcquireActorCallback(this.OnActorAcquired), callbackData);
    }

    private void LoadAllClassTextures()
    {
        IEnumerator enumerator = Enum.GetValues(typeof(TAG_CLASS)).GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                TAG_CLASS current = (TAG_CLASS) ((int) enumerator.Current);
                AssetLoader.Get().LoadTexture(GetClassTextureName(current), new AssetLoader.ObjectCallback(this.OnClassTextureLoaded), current);
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    public void LoadCard(string cardID, CollectionCardCache.LoadCardDefCallback callback, object callbackData)
    {
        CollectionCardCache.Get().LoadCardDef(cardID, callback, callbackData);
    }

    private void LoadDisplayCards(DisplayCallbackData displayCallbackData)
    {
        if (!this.m_unloading && (displayCallbackData.m_requestID == this.m_displayRequestID))
        {
            foreach (NetCache.CardDefinition definition in displayCallbackData.m_requestedCardDefinitions)
            {
                if (!this.LoadActorsForCardDefinition(definition, displayCallbackData))
                {
                    UnityEngine.Debug.LogError(string.Format("LoadActorsForCardDefinition() failed to load actor for {0}", definition));
                    this.m_failedToLoadActors.Add(definition);
                }
            }
        }
    }

    private bool NewDeckButtonAvailable()
    {
        return !this.m_selectingNewDeckHero;
    }

    [DebuggerHidden]
    private IEnumerator NotifySceneLoadedWhenReady()
    {
        return new <NotifySceneLoadedWhenReady>c__IteratorB { <>f__this = this };
    }

    private void OnActorAcquired(Actor actor, object callbackData)
    {
        if (!this.m_unloading)
        {
            AcquireActorCallbackData data = callbackData as AcquireActorCallbackData;
            if (data.m_displayCallbackData.m_requestID != this.m_displayRequestID)
            {
                this.ReleaseActor(actor);
            }
            else if (actor == null)
            {
                this.m_failedToLoadActors.Add(data.m_cardDefinition);
            }
            else
            {
                LoadCardCallbackData data3 = new LoadCardCallbackData {
                    m_cardDefinition = data.m_cardDefinition,
                    m_actor = actor,
                    m_displayCallbackData = data.m_displayCallbackData
                };
                LoadCardCallbackData data2 = data3;
                string cardId = actor.GetEntityDef().GetCardId();
                this.LoadCard(cardId, new CollectionCardCache.LoadCardDefCallback(this.OnCardDefLoaded), data2);
            }
        }
    }

    private void OnCardDefLoaded(string cardID, CardDef cardDef, object callbackData)
    {
        if (!this.m_unloading)
        {
            LoadCardCallbackData data = callbackData as LoadCardCallbackData;
            if (data.m_displayCallbackData.m_requestID != this.m_displayRequestID)
            {
                this.ReleaseActor(data.m_actor);
            }
            else
            {
                Actor actor = data.m_actor;
                actor.SetCardDef(cardDef);
                actor.UpdateAllComponents();
                this.m_actorsToDisplay[data.m_cardDefinition] = actor;
                this.CheckAndFinishDisplayList(data.m_displayCallbackData);
            }
        }
    }

    private void OnCardRewardInserted(string cardID, CardFlair flair)
    {
        this.m_pageManager.RefreshCurrentPageContents();
    }

    private void OnClassTextureLoaded(string assetName, UnityEngine.Object asset, object callbackData)
    {
        if (asset == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("CollectionManagerDisplay.OnClassTextureLoaded(): asset for {0} is null!", assetName));
        }
        else
        {
            TAG_CLASS key = (TAG_CLASS) ((int) callbackData);
            Texture classTexture = asset as Texture;
            if (classTexture == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("CollectionManagerDisplay.OnClassTextureLoaded(): classTexture for {0} is null (asset is not a texture)!", assetName));
            }
            else if (this.m_loadedClassTextures.ContainsKey(key))
            {
                UnityEngine.Debug.LogWarning(string.Format("CollectionManagerDisplay.OnClassTextureLoaded(): classTexture for {0} ({1}) has already been loaded!", key, assetName));
            }
            else
            {
                this.m_loadedClassTextures[key] = classTexture;
                if (this.m_requestedClassTextures.ContainsKey(key))
                {
                    TextureRequests requests = this.m_requestedClassTextures[key];
                    this.m_requestedClassTextures.Remove(key);
                    foreach (TextureRequests.Request request in requests.m_requests)
                    {
                        request.m_callback(key, classTexture, request.m_callbackData);
                    }
                }
            }
        }
    }

    private void OnCollectionAchievesCompleted(List<Achievement> achievements)
    {
        this.m_completeAchievesToDisplay.AddRange(achievements);
        this.ShowCompleteAchieve();
    }

    private void OnCollectionChanged()
    {
        this.m_pageManager.NotifyOfCollectionChanged();
    }

    private void OnCollectionLoaded()
    {
        this.m_pageManager.OnCollectionLoaded();
    }

    private void OnCoverOpened()
    {
        this.EnableInput(true);
    }

    private void OnDeckContents(long deckID)
    {
        if (deckID == this.m_showDeckContentsRequest)
        {
            this.m_showDeckContentsRequest = 0L;
            this.ShowDeck(deckID, false);
        }
    }

    private void OnDeckCreated(long deckID)
    {
        this.ShowDeck(deckID, true);
    }

    public void OnDoneEditingDeck()
    {
        this.m_pageManager.OnDoneEditingDeck();
    }

    private void OnNetCacheReady()
    {
        if (!CollectionManager.Get().IsWaitingToShowPackOpening() && !NetCache.Get().GetNetObject<NetCache.NetCacheFeatures>().Collection.Manager)
        {
            if (!SceneMgr.Get().IsModeRequested(SceneMgr.Mode.HUB))
            {
                SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
                Error.AddWarningLoc("GLOBAL_FEATURE_DISABLED_TITLE", "GLOBAL_FEATURE_DISABLED_MESSAGE_COLLECTION", new object[0]);
            }
        }
        else
        {
            this.m_pageManager.UpdateNumMouseOvers();
            this.m_netCacheReady = true;
        }
    }

    private void OnNewCardSeen(string cardID, CardFlair flair)
    {
        this.m_pageManager.UpdateClassTabNewCardCounts();
    }

    public void OnPackOpeningHidden()
    {
        UnityEngine.Object.Destroy(this.m_packOpening.gameObject);
        this.m_packOpening = null;
        BnetBar.Get().m_currencyFrame.RefreshContents();
    }

    public void OnPackOpeningHideRequested()
    {
        if (!NetCache.Get().GetNetObject<NetCache.NetCacheFeatures>().Collection.Manager)
        {
            SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
            Error.AddWarningLoc("GLOBAL_FEATURE_DISABLED_TITLE", "GLOBAL_FEATURE_DISABLED_MESSAGE_COLLECTION", new object[0]);
        }
        else
        {
            this.m_waitingForPackOpeningNetData = true;
            NetCache.Get().ReloadNetObject<NetCache.NetCacheBoosters>();
            Box.Get().ChangeLightState(BoxLightStateType.COLLECTION);
            this.m_pageManager.RefreshCurrentPageContents();
            CollectionManager.Get().RegisterAchievesCompletedListener(new CollectionManager.DelOnAchievesCompleted(this.OnCollectionAchievesCompleted));
            this.DoEnterCollectionManagerEvents();
        }
    }

    private void OnPackOpeningLoaded(string name, GameObject screen, object userData)
    {
        this.m_waitingForPackOpeningAsset = false;
        if (screen == null)
        {
            UnityEngine.Debug.LogError(string.Format("CollectionManagerDisplay.OnPackOpeningLoaded() - failed to load {0}", name));
            this.EnableInput(true);
        }
        else
        {
            this.m_packOpening = screen.GetComponent<PackOpening>();
            if (this.m_packOpening == null)
            {
                UnityEngine.Debug.LogError(string.Format("CollectionManagerDisplay.OnPackOpeningLoaded() - {0} did not have a {1} component", name, typeof(PackOpening)));
                this.EnableInput(true);
            }
            else if (this.m_waitingToShowPackOpening)
            {
                this.ShowPackOpeningWhenReady();
            }
        }
    }

    private void OnPackOpeningNetCacheReady()
    {
        this.m_waitingForPackOpeningNetData = false;
        if (this.m_waitingToShowPackOpening)
        {
            this.ShowPackOpeningWhenReady();
        }
    }

    private void OnPageMouseOversChanged(Option option, object prevValue, bool existed, object userData)
    {
        this.m_pageManager.UpdateNumMouseOvers();
    }

    private bool OnProcessCheat_help(string func, string[] args, string rawArgs)
    {
        RandomDeckChoices choices = RandomDeckMaker.GetChoices(this.GetRDMDeck(), 3);
        if (choices != null)
        {
            RDMDeckEntry entry = choices.choices[0];
            CollectionDeckTray.Get().AddCard(entry.EntityDef.GetCardId(), entry.Flair, null);
            UnityEngine.Debug.Log(choices.displayString);
        }
        return true;
    }

    private void OnSearchActivated()
    {
        this.EnableInput(false);
        this.m_search.Activate();
    }

    private void OnSearchCleared()
    {
        this.m_pageManager.ChangeSearchTextFilter(string.Empty);
    }

    private void OnSearchDeactivated()
    {
        this.EnableInput(true);
    }

    private void OnShowAdvancedCMChanged(Option option, object prevValue, bool existed, object userData)
    {
        this.ShowAdvancedCollectionManager(Options.Get().GetBool(Option.SHOW_ADVANCED_COLLECTIONMANAGER, false));
    }

    private void OpenBookImmediately()
    {
        this.SetBookToOpen();
        base.StartCoroutine(this.ShowCollectionTipsIfNeeded());
    }

    [DebuggerHidden]
    private IEnumerator OpenBookWhenReady()
    {
        return new <OpenBookWhenReady>c__IteratorE { <>f__this = this };
    }

    private void ReleaseActor(Actor actor)
    {
        actor.SetCardDef(null);
        actor.SetActorState(ActorStateType.CARD_IDLE);
        actor.Hide();
        this.m_actorPool.ReleaseActor(actor);
    }

    private void ReleaseObsoleteActors()
    {
        if (this.m_obsoleteActors != null)
        {
            foreach (Actor actor in this.m_obsoleteActors)
            {
                this.ReleaseActor(actor);
            }
        }
    }

    public void RequestContentsToShowDeck(long deckID)
    {
        this.m_showDeckContentsRequest = deckID;
        CollectionManager.Get().RequestDeckContents(this.m_showDeckContentsRequest);
    }

    private void RequestPackOpeningAsset()
    {
        this.m_waitingForPackOpeningAsset = true;
        AssetLoader.Get().LoadUIScreen("PackOpening", new AssetLoader.GameObjectCallback(this.OnPackOpeningLoaded));
    }

    private void SetBookToOpen()
    {
        this.m_cover.SetOpenState();
        this.AnimateCardsNotOwnedTab(true);
        this.m_manaTabManager.ActivateTabs(true);
    }

    private void SetDisplayList(List<FilteredArtStack> artStacksToDisplay, CollectionActorsReadyCallback callback, object callbackData)
    {
        if (this.m_displayRequestID == 0x7fffffff)
        {
            this.m_displayRequestID = 0;
        }
        else
        {
            this.m_displayRequestID++;
        }
        this.m_actorsToDisplay.Clear();
        this.m_failedToLoadActors.Clear();
        bool flag = false;
        if (artStacksToDisplay == null)
        {
            Log.Rachelle.Print("artStacksToDisplay is null!");
            flag = true;
        }
        else if (artStacksToDisplay.Count == 0)
        {
            Log.Rachelle.Print("artStacksToDisplay has a count of 0!");
            flag = true;
        }
        if (flag)
        {
            List<Actor> actorList = new List<Actor>();
            this.UpdateCurrentActorList(actorList);
            callback(actorList, callbackData);
        }
        else
        {
            DisplayCallbackData data2 = new DisplayCallbackData {
                m_requestID = this.m_displayRequestID,
                m_callback = callback,
                m_callbackData = callbackData
            };
            DisplayCallbackData displayCallbackData = data2;
            foreach (FilteredArtStack stack in artStacksToDisplay)
            {
                displayCallbackData.m_requestedCardDefinitions.Add(stack.GetCardDefinition());
            }
            if (CollectionManager.Get().CanDisplayCards())
            {
                this.LoadDisplayCards(displayCallbackData);
            }
            else
            {
                base.StartCoroutine(this.WaitThenLoadDisplayCards(displayCallbackData));
            }
        }
    }

    public bool ShouldShowNewCardGlow(string cardID, CardFlair cardFlair)
    {
        CollectionCardStack.ArtStack collectionArtStack = CollectionManager.Get().GetCollectionArtStack(cardID, cardFlair);
        if (collectionArtStack.Count == 0)
        {
            return false;
        }
        if (collectionArtStack.NumSeen == collectionArtStack.Count)
        {
            return false;
        }
        int num = !DefLoader.Get().GetEntityDef(cardID).IsElite() ? 2 : 1;
        return (collectionArtStack.NumSeen < num);
    }

    private void ShowAdvancedCollectionManager(bool show)
    {
        this.m_showAllCardsTab.gameObject.SetActive(show);
        this.m_search.m_root.SetActive(show);
        this.m_manaTabManager.gameObject.SetActive(show);
        if (show)
        {
            this.m_manaTabManager.SetUpTabs();
        }
    }

    [DebuggerHidden]
    private IEnumerator ShowCollectionTipsIfNeeded()
    {
        return new <ShowCollectionTipsIfNeeded>c__IteratorF { <>f__this = this };
    }

    private void ShowCompleteAchieve()
    {
        if (this.m_completeAchievesToDisplay.Count != 0)
        {
            Achievement quest = this.m_completeAchievesToDisplay[0];
            this.m_completeAchievesToDisplay.RemoveAt(0);
            QuestToast.ShowQuestToast(new QuestToast.DelOnCloseQuestToast(this.ShowCompleteAchieve), quest);
        }
    }

    private void ShowCraftingTipIfNeeded()
    {
        if (!Options.Get().GetBool(Option.TIP_CRAFTING_UNLOCKED, false))
        {
            NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_DISENCHANT_31"), "VO_INNKEEPER_DISENCHANT_31");
            Options.Get().SetBool(Option.TIP_CRAFTING_UNLOCKED, true);
        }
    }

    private void ShowDeck(long deckID, bool isNewDeck)
    {
        CollectionDeckTray.Get().ShowDeck(deckID, isNewDeck);
        TAG_CLASS deckHeroClass = this.GetDeckHeroClass(deckID);
        this.m_pageManager.AddClassFilter(deckHeroClass);
        this.m_pageManager.UpdateMassDisenchantTabVisibility();
    }

    public void ShowInnkeeeprLClickHelp()
    {
        if (!CollectionDeckTray.Get().IsShowingDeckContents())
        {
            this.m_innkeeperLClickReminder = NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_CM_LCLICK"), string.Empty, 3f);
        }
    }

    public void ShowOnlyCardsIOwn()
    {
        Get().m_pageManager.ShowOnlyCardsIOwn();
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CM_SHOW_CARDS_I_DONT_OWN_TURNED_OFF);
    }

    private void ShowPackOpening()
    {
        this.m_waitingToShowPackOpening = false;
        if (!Options.Get().GetBool(Option.HAS_SEEN_PACK_OPENING, false))
        {
            NetCache.NetCacheBoosters netObject = NetCache.Get().GetNetObject<NetCache.NetCacheBoosters>();
            if ((netObject != null) && (netObject.GetTotalNumBoosters() > 0))
            {
                Options.Get().SetBool(Option.HAS_SEEN_PACK_OPENING, true);
            }
        }
        CollectionManager.Get().EnableWaitingToShowPackOpening(false);
        Box.Get().ChangeLightState(BoxLightStateType.PACK_OPENING);
        this.m_packOpening.Show();
    }

    private bool ShowPackOpeningWhenReady()
    {
        this.m_waitingToShowPackOpening = true;
        if (this.m_waitingForPackOpeningNetData)
        {
            return false;
        }
        if (this.m_waitingForPackOpeningAsset)
        {
            return false;
        }
        if (this.m_packOpening == null)
        {
            this.RequestPackOpeningAsset();
            return false;
        }
        this.EnableInput(false);
        this.ShowPackOpening();
        return true;
    }

    public void ShowPremiumCardsNotOwned(bool show)
    {
        Get().m_pageManager.ShowCardsNotOwned(show);
        if (show)
        {
            Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CM_SHOW_PREMIUMS_NOT_OWNED);
        }
        else
        {
            Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CM_HIDE_PREMIUMS_NOT_OWNED);
        }
    }

    public void ShowStandardCardsNotOwned()
    {
        this.HideShowCardsPopup();
        if (!Options.Get().GetBool(Option.HAS_SEEN_SHOW_ALL_CARDS_REMINDER))
        {
            string str;
            Vector3 position = this.m_showAllCardsTab.transform.position;
            Vector3 vector2 = new Vector3(position.x + 7.5f, position.y, position.z + 3f);
            if (UniversalInputManager.IsTouchDevice != null)
            {
                str = GameStrings.Get("GLUE_COLLECTION_TUTORIAL07_TOUCH");
            }
            else
            {
                str = GameStrings.Get("GLUE_COLLECTION_TUTORIAL07");
            }
            this.m_showAllCardsPopup = NotificationManager.Get().CreatePopupText(vector2, this.TUTORIAL_CRAFT_DECK_SCALE, str);
            this.m_showAllCardsPopup.PulseReminderEveryXSeconds(3f);
            NotificationManager.Get().DestroyNotification(this.m_showAllCardsPopup, 7f);
            Options.Get().SetBool(Option.HAS_SEEN_SHOW_ALL_CARDS_REMINDER, true);
        }
        Get().m_pageManager.ShowCardsNotOwned(false);
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_CM_SHOW_CARDS_I_DONT_OWN_TURNED_ON);
    }

    [DebuggerHidden]
    private IEnumerator ShowTipForMassDisenchantIfNeeded()
    {
        return new <ShowTipForMassDisenchantIfNeeded>c__Iterator11 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator ShowTipForShowAllCardsIfNeeded()
    {
        return new <ShowTipForShowAllCardsIfNeeded>c__Iterator10 { <>f__this = this };
    }

    private void Start()
    {
        NetCache.Get().RegisterScreenCollectionManager(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        CollectionManager.Get().RegisterCollectionNetHandlers();
        CollectionManager.Get().RegisterCollectionLoadedListener(new CollectionManager.DelOnCollectionLoaded(this.OnCollectionLoaded));
        CollectionManager.Get().RegisterCollectionChangedListener(new CollectionManager.DelOnCollectionChanged(this.OnCollectionChanged));
        CollectionManager.Get().RegisterDeckCreatedListener(new CollectionManager.DelOnDeckCreated(this.OnDeckCreated));
        CollectionManager.Get().RegisterDeckContentsListener(new CollectionManager.DelOnDeckContents(this.OnDeckContents));
        CollectionManager.Get().RegisterNewCardSeenListener(new CollectionManager.DelOnNewCardSeen(this.OnNewCardSeen));
        CollectionManager.Get().RegisterCardRewardInsertedListener(new CollectionManager.DelOnCardRewardInserted(this.OnCardRewardInserted));
        this.m_inputBlocker.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.InputBlockerPress));
        this.m_search.m_background.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.EnterSearchMode));
        this.m_search.RegisterDeactivatedListener(new CollectionSearch.DeactivatedListener(this.ExitSearchMode));
        this.m_search.RegisterSearchClearedListener(new CollectionSearch.SearchClearedListener(this.OnSearchCleared));
        Options.Get().RegisterChangedListener(Option.PAGE_MOUSE_OVERS, new Options.ChangedCallback(this.OnPageMouseOversChanged));
        this.m_showAdvancedCM = Options.Get().GetBool(Option.SHOW_ADVANCED_COLLECTIONMANAGER, false);
        this.ShowAdvancedCollectionManager(this.m_showAdvancedCM);
        if (!this.m_showAdvancedCM)
        {
            Options.Get().RegisterChangedListener(Option.SHOW_ADVANCED_COLLECTIONMANAGER, new Options.ChangedCallback(this.OnShowAdvancedCMChanged));
        }
        if (!CollectionManager.Get().IsWaitingToShowPackOpening())
        {
            CollectionManager.Get().RegisterAchievesCompletedListener(new CollectionManager.DelOnAchievesCompleted(this.OnCollectionAchievesCompleted));
            this.DoEnterCollectionManagerEvents();
            Box.Get().ChangeLightState(BoxLightStateType.COLLECTION);
        }
        SoundManager.Get().NukePlaylistsAndStopPlayingCurrentTracks();
        SoundManager.Get().AddNewMusicTrack("CollectionManager_music_1");
        SoundManager.Get().AddNewMusicTrack("CollectionManager_music_2");
        SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_light");
        base.StartCoroutine(this.NotifySceneLoadedWhenReady());
    }

    public void Unload()
    {
        this.m_unloading = true;
        this.m_waitingToShowPackOpening = false;
        DefLoader.Get().ClearCardDefs();
        CollectionCardCache.Get().Unload();
        this.m_actorPool.Unload();
        this.UnloadAllClassTextures();
        this.m_manaTabManager.ClearTabs();
        CollectionDeckTray.Get().Unload();
        CollectionInputMgr.Get().Unload();
        CollectionManager.Get().RemoveCollectionLoadedListener(new CollectionManager.DelOnCollectionLoaded(this.OnCollectionLoaded));
        CollectionManager.Get().RemoveCollectionChangedListener(new CollectionManager.DelOnCollectionChanged(this.OnCollectionChanged));
        CollectionManager.Get().RemoveDeckCreatedListener(new CollectionManager.DelOnDeckCreated(this.OnDeckCreated));
        CollectionManager.Get().RemoveDeckContentsListener(new CollectionManager.DelOnDeckContents(this.OnDeckContents));
        CollectionManager.Get().RemoveNewCardSeenListener(new CollectionManager.DelOnNewCardSeen(this.OnNewCardSeen));
        CollectionManager.Get().RemoveCardRewardInsertedListener(new CollectionManager.DelOnCardRewardInserted(this.OnCardRewardInserted));
        CollectionManager.Get().RemoveAchievesCompletedListener(new CollectionManager.DelOnAchievesCompleted(this.OnCollectionAchievesCompleted));
        CollectionManager.Get().RemoveCollectionNetHandlers();
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnPackOpeningNetCacheReady));
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        CheatMgr.Get().UnregisterCheatHandler("help", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_help));
        Options.Get().UnregisterChangedListener(Option.PAGE_MOUSE_OVERS, new Options.ChangedCallback(this.OnPageMouseOversChanged));
        Options.Get().UnregisterChangedListener(Option.SHOW_ADVANCED_COLLECTIONMANAGER, new Options.ChangedCallback(this.OnShowAdvancedCMChanged));
        this.m_unloading = false;
    }

    private void UnloadAllClassTextures()
    {
        if (this.m_loadedClassTextures.Count != 0)
        {
            List<string> names = new List<string>();
            foreach (TAG_CLASS tag_class in this.m_loadedClassTextures.Keys)
            {
                names.Add(GetClassTextureName(tag_class));
            }
            AssetCache.ClearTextures(names);
            this.m_loadedClassTextures.Clear();
        }
    }

    private void Update()
    {
        Network.Get().ProcessNetwork();
    }

    private void UpdateCurrentActorList(List<Actor> actorList)
    {
        this.m_obsoleteActors = this.m_lastActorList;
        this.m_lastActorList = this.m_currActorList;
        this.m_currActorList = actorList;
        this.ReleaseObsoleteActors();
    }

    public void UpdateCurrentPageCardLocks()
    {
        this.m_pageManager.UpdateCurrentPageCardLocks();
    }

    [DebuggerHidden]
    private IEnumerator WaitThenLoadDisplayCards(DisplayCallbackData displayCallbackData)
    {
        return new <WaitThenLoadDisplayCards>c__IteratorD { displayCallbackData = displayCallbackData, <$>displayCallbackData = displayCallbackData, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <InitCollectionWhenReady>c__IteratorC : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionManagerDisplay <>f__this;

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
                    if (!CollectionManager.Get().CanDisplayCards())
                    {
                        this.$current = 0;
                        this.$PC = 1;
                        goto Label_0097;
                    }
                    break;

                case 2:
                    break;

                default:
                    goto Label_0095;
            }
            while (!this.<>f__this.m_pageManager.IsFullyLoaded())
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_0097;
            }
            this.<>f__this.m_pageManager.OnCollectionLoaded();
            this.$PC = -1;
        Label_0095:
            return false;
        Label_0097:
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
    private sealed class <NotifySceneLoadedWhenReady>c__IteratorB : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionManagerDisplay <>f__this;

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
                    if (!CollectionManager.Get().CanDisplayCards())
                    {
                        this.$current = 0;
                        this.$PC = 1;
                        goto Label_0145;
                    }
                    break;

                case 2:
                    break;

                case 3:
                    goto Label_00A6;

                case 4:
                    goto Label_00D2;

                case 5:
                    goto Label_00FF;

                default:
                    goto Label_0143;
            }
            while (CollectionManager.Get().IsWaitingToShowPackOpening())
            {
                this.$current = 0;
                this.$PC = 2;
                goto Label_0145;
            }
        Label_00A6:
            while (!CollectionDeckTray.Get().IsLoaded())
            {
                this.$current = 0;
                this.$PC = 3;
                goto Label_0145;
            }
        Label_00D2:
            while (!this.<>f__this.m_netCacheReady)
            {
                this.$current = 0;
                this.$PC = 4;
                goto Label_0145;
            }
        Label_00FF:
            while ((CraftingManager.Get() == null) || !CraftingManager.Get().AreGhostActorsLoaded())
            {
                this.$current = 0;
                this.$PC = 5;
                goto Label_0145;
            }
            CollectionDeckTray.Get().OnDeckListReady();
            CollectionDeckTray.Get().EnterDeckListMode();
            SceneMgr.Get().NotifySceneLoaded();
            this.$PC = -1;
        Label_0143:
            return false;
        Label_0145:
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
    private sealed class <OpenBookWhenReady>c__IteratorE : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionManagerDisplay <>f__this;

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
                    if (CollectionManager.Get().IsWaitingForBoxTransition())
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<>f__this.m_pageManager.OnBookOpening();
                    this.<>f__this.DoBookOpeningAnimations();
                    this.<>f__this.StartCoroutine(this.<>f__this.ShowCollectionTipsIfNeeded());
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
    private sealed class <ShowCollectionTipsIfNeeded>c__IteratorF : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionManagerDisplay <>f__this;
        internal Vector3 <newDeckSpot>__0;
        internal Vector3 <popupSpot>__1;

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
                    this.<>f__this.StartCoroutine(this.<>f__this.ShowTipForMassDisenchantIfNeeded());
                    this.<>f__this.StartCoroutine(this.<>f__this.ShowTipForShowAllCardsIfNeeded());
                    if (!Options.Get().GetBool(Option.HAS_SEEN_COLLECTIONMANAGER, false))
                    {
                        Options.Get().SetBool(Option.HAS_SEEN_COLLECTIONMANAGER, true);
                        this.$current = new WaitForSeconds(1f);
                        this.$PC = 1;
                        return true;
                    }
                    break;

                case 1:
                    if (this.<>f__this.NewDeckButtonAvailable())
                    {
                        this.<newDeckSpot>__0 = CollectionDeckTray.Get().GetNewDeckButtonPosition();
                        this.<popupSpot>__1 = new Vector3(this.<newDeckSpot>__0.x - 17f, this.<newDeckSpot>__0.y, this.<newDeckSpot>__0.z);
                        this.<>f__this.m_deckHelpPopup = NotificationManager.Get().CreatePopupText(this.<popupSpot>__1, this.<>f__this.TUTORIAL_CRAFT_DECK_SCALE, GameStrings.Get("GLUE_COLLECTION_TUTORIAL01"));
                        this.<>f__this.m_deckHelpPopup.ShowPopUpArrow(Notification.PopUpArrowDirection.Right);
                        this.<>f__this.m_deckHelpPopup.PulseReminderEveryXSeconds(3f);
                        NotificationManager.Get().DestroyNotification(this.<>f__this.m_deckHelpPopup, 7f);
                        NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("TUTORIAL_INNKEEPER_01"), "VO_ANNOUNCER_CM_MAKE_DECK_51");
                        this.$PC = -1;
                        break;
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
    private sealed class <ShowTipForMassDisenchantIfNeeded>c__Iterator11 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionManagerDisplay <>f__this;
        internal Vector3 <popupSpot>__1;
        internal Vector3 <tabPosition>__0;

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
                    if (!Options.Get().GetBool(Option.HAS_DISENCHANTED))
                    {
                        break;
                    }
                    goto Label_017D;

                case 1:
                    break;

                case 2:
                    if (this.<>f__this.m_pageManager.IsMassDisenchantTabVisible())
                    {
                        this.<>f__this.ShowCraftingTipIfNeeded();
                        if (this.<>f__this.m_pageManager.HaveCardsToMassDisenchant())
                        {
                            this.<tabPosition>__0 = this.<>f__this.m_pageManager.GetMassDisenchantTabLocation();
                            this.<popupSpot>__1 = new Vector3(this.<tabPosition>__0.x, this.<tabPosition>__0.y, this.<tabPosition>__0.z - 9f);
                            this.<>f__this.m_massDisenchantHelpPopup = NotificationManager.Get().CreatePopupText(this.<popupSpot>__1, this.<>f__this.TUTORIAL_CRAFT_DECK_SCALE, GameStrings.Get("GLUE_COLLECTION_TUTORIAL03"));
                            this.<>f__this.m_massDisenchantHelpPopup.ShowPopUpArrow(Notification.PopUpArrowDirection.Up);
                            this.<>f__this.m_massDisenchantHelpPopup.PulseReminderEveryXSeconds(3f);
                            NotificationManager.Get().DestroyNotification(this.<>f__this.m_massDisenchantHelpPopup, 7f);
                        }
                        this.$PC = -1;
                    }
                    goto Label_017D;

                default:
                    goto Label_017D;
            }
            while (!this.<>f__this.m_pageManager.IsFullyLoaded())
            {
                this.$current = null;
                this.$PC = 1;
                goto Label_017F;
            }
            this.$current = new WaitForSeconds(1f);
            this.$PC = 2;
            goto Label_017F;
        Label_017D:
            return false;
        Label_017F:
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
    private sealed class <ShowTipForShowAllCardsIfNeeded>c__Iterator10 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionManagerDisplay <>f__this;
        internal Vector3 <popupSpot>__1;
        internal Vector3 <tabPosition>__0;

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
                    if (!Options.Get().GetBool(Option.HAS_SEEN_SHOW_ALL_CARDS_REMINDER))
                    {
                        if (NetCache.Get().GetNetObject<NetCache.NetCacheArcaneDustBalance>().Balance >= 40L)
                        {
                            this.$current = new WaitForSeconds(1f);
                            this.$PC = 1;
                            return true;
                        }
                        break;
                    }
                    break;

                case 1:
                    this.<tabPosition>__0 = this.<>f__this.m_showAllCardsTab.transform.position;
                    this.<popupSpot>__1 = new Vector3(this.<tabPosition>__0.x - 6.4f, this.<tabPosition>__0.y, this.<tabPosition>__0.z + 8f);
                    this.<>f__this.m_showAllCardsPopup = NotificationManager.Get().CreatePopupText(this.<popupSpot>__1, this.<>f__this.TUTORIAL_CRAFT_DECK_SCALE, GameStrings.Get("GLUE_COLLECTION_TUTORIAL04"));
                    this.<>f__this.m_showAllCardsPopup.ShowPopUpArrow(Notification.PopUpArrowDirection.Down);
                    this.<>f__this.m_showAllCardsPopup.PulseReminderEveryXSeconds(3f);
                    NotificationManager.Get().DestroyNotification(this.<>f__this.m_showAllCardsPopup, 7f);
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
    private sealed class <WaitThenLoadDisplayCards>c__IteratorD : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CollectionManagerDisplay.DisplayCallbackData <$>displayCallbackData;
        internal CollectionManagerDisplay <>f__this;
        internal CollectionManager <collectionMgr>__0;
        internal CollectionManagerDisplay.DisplayCallbackData displayCallbackData;

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
                    this.<collectionMgr>__0 = CollectionManager.Get();
                    break;

                case 1:
                    break;

                default:
                    goto Label_006C;
            }
            if (!this.<collectionMgr>__0.CanDisplayCards())
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<>f__this.LoadDisplayCards(this.displayCallbackData);
            this.$PC = -1;
        Label_006C:
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

    private class AcquireActorCallbackData
    {
        public NetCache.CardDefinition m_cardDefinition;
        public CollectionManagerDisplay.DisplayCallbackData m_displayCallbackData;
    }

    public delegate void CollectionActorsReadyCallback(List<Actor> actors, object callbackData);

    public delegate void DelTextureLoaded(TAG_CLASS classTag, Texture classTexture, object callbackData);

    private class DisplayCallbackData
    {
        public CollectionManagerDisplay.CollectionActorsReadyCallback m_callback;
        public object m_callbackData;
        public List<NetCache.CardDefinition> m_requestedCardDefinitions = new List<NetCache.CardDefinition>();
        public int m_requestID = 0;
    }

    private class LoadCardCallbackData
    {
        public Actor m_actor;
        public NetCache.CardDefinition m_cardDefinition;
        public CollectionManagerDisplay.DisplayCallbackData m_displayCallbackData;
    }

    private class TextureRequests
    {
        public List<Request> m_requests = new List<Request>();

        public class Request
        {
            public CollectionManagerDisplay.DelTextureLoaded m_callback;
            public object m_callbackData;
        }
    }
}


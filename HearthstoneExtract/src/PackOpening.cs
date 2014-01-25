using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PackOpening : MonoBehaviour
{
    public NormalButton m_BackButton;
    private PackOpeningDirector m_director;
    public PackOpeningDirector m_DirectorPrefab;
    private UnopenedPack m_draggedPack;
    public GameObject m_DragPlane;
    public TextMesh m_HeaderText;
    public Spell m_HideSpell;
    private Notification m_hintArrow;
    public GameObject m_InputBlocker;
    private bool m_loadingUnopenedPack;
    public PackOpeningPackTrayInfo m_PackTrayInfo;
    private bool m_showAnimEnabled = true;
    private bool m_shown;
    private bool m_shownComplete;
    public Spell m_ShowSpell;
    public PackOpeningSocket m_Socket;
    public PackOpeningSocketTrayInfo m_SocketTrayInfo;
    public StoreButton m_storeButton;
    private UnopenedPack m_unopenedPack;
    private static readonly Vector3 STORE_POS = new Vector3(-14.48474f, 44.85855f, 4.580483f);
    private static readonly Vector3 STORE_SCALE = new Vector3(32f, 32f, 32f);

    private void Awake()
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_VISIT_PACK_OPEN_SCREEN);
        this.m_showAnimEnabled = !CollectionManager.Get().IsWaitingToShowPackOpening();
        this.InitializeTransform();
        this.InitializeNet();
        this.InitializeUI();
        this.m_storeButton.SetStorePosAndScale(STORE_POS, STORE_SCALE);
    }

    public static PackOpeningRarity ConvertRarityTag(TAG_RARITY tag)
    {
        switch (tag)
        {
            case TAG_RARITY.COMMON:
                return PackOpeningRarity.COMMON;

            case TAG_RARITY.FREE:
                return PackOpeningRarity.COMMON;

            case TAG_RARITY.RARE:
                return PackOpeningRarity.RARE;

            case TAG_RARITY.EPIC:
                return PackOpeningRarity.EPIC;

            case TAG_RARITY.LEGENDARY:
                return PackOpeningRarity.LEGENDARY;
        }
        return PackOpeningRarity.NONE;
    }

    private void CreateDirector()
    {
        GameObject gameObject = this.m_DirectorPrefab.gameObject;
        GameObject obj3 = (GameObject) UnityEngine.Object.Instantiate(gameObject);
        this.m_director = obj3.GetComponent<PackOpeningDirector>();
        obj3.transform.parent = base.transform;
        obj3.transform.position = Camera.main.transform.TransformPoint(new Vector3(0f, 0f, -500f));
        base.StartCoroutine(this.WaitThenInitDirectorTransform(obj3.transform, gameObject.transform));
    }

    private void CreateDraggedPack(UnopenedPack creatorPack)
    {
        RaycastHit hit;
        this.m_draggedPack = creatorPack.AcquireDraggedPack();
        this.m_draggedPack.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnDraggedPackRelease));
        Vector3 position = this.m_draggedPack.transform.position;
        if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.DragPlane.LayerBit(), out hit))
        {
            position = hit.point;
            float f = Vector3.Dot(Camera.main.transform.forward, Vector3.up);
            float num2 = -f / Mathf.Abs(f);
            Bounds bounds = this.m_draggedPack.collider.bounds;
            position.y += (num2 * bounds.extents.y) * this.m_draggedPack.transform.lossyScale.y;
        }
        this.m_draggedPack.transform.position = position;
    }

    [Conditional("UNITY_EDITOR")]
    private void DebugDropPack()
    {
        PegCursor.Get().SetMode(PegCursor.Mode.STOPDRAG);
        this.m_Socket.OnPackReleased(this.m_draggedPack);
        this.m_director.OnPackReleased(this.m_draggedPack);
        this.OpenBooster(this.m_draggedPack);
        this.HideHint();
        this.DestroyDraggedPack();
        this.UpdateUIEvents();
        this.m_DragPlane.SetActive(false);
    }

    private void DestroyDraggedPack()
    {
        this.m_draggedPack.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnDraggedPackRelease));
        this.m_draggedPack.GetCreatorPack().ReleaseDraggedPack();
        this.m_draggedPack = null;
    }

    private void DestroyHint()
    {
        if (this.m_hintArrow != null)
        {
            UnityEngine.Object.Destroy(this.m_hintArrow.gameObject);
            this.m_hintArrow = null;
        }
    }

    private void DropPack()
    {
        PegCursor.Get().SetMode(PegCursor.Mode.STOPDRAG);
        bool flag = this.m_Socket.OnPackReleased(this.m_draggedPack);
        this.m_director.OnPackReleased(this.m_draggedPack);
        if (flag)
        {
            this.OpenBooster(this.m_draggedPack);
            this.HideHint();
        }
        else
        {
            this.PutBackBooster();
            this.DestroyHint();
        }
        this.DestroyDraggedPack();
        this.UpdateUIEvents();
        this.m_DragPlane.SetActive(false);
    }

    public void EnableShowAnim(bool enable)
    {
        this.m_showAnimEnabled = enable;
    }

    private void FixArrowScale(Transform parent)
    {
        Transform transform = this.m_hintArrow.transform.parent;
        this.m_hintArrow.transform.parent = parent;
        this.m_hintArrow.transform.localScale = Vector3.one;
        this.m_hintArrow.transform.parent = transform;
    }

    public static int GetFakePackCount()
    {
        if (!ApplicationMgr.IsInternal())
        {
            return 0;
        }
        return Options.Get().GetInt(Option.FAKE_PACK_COUNT);
    }

    public void Hide()
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            if (CollectionManagerDisplay.Get() != null)
            {
                CollectionManagerDisplay.Get().OnPackOpeningHideRequested();
            }
            this.DestroyHint();
            this.m_storeButton.Unload();
            this.HideImpl();
        }
    }

    private void HideHint()
    {
        if (this.m_hintArrow != null)
        {
            Options.Get().SetBool(Option.HAS_OPENED_BOOSTER, true);
            UnityEngine.Object.Destroy(this.m_hintArrow.gameObject);
            this.m_hintArrow = null;
        }
    }

    private void HideImpl()
    {
        this.m_HideSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnHideSpellFinished));
        this.m_HideSpell.Activate();
    }

    private void HoldPack()
    {
        PegCursor.Get().SetMode(PegCursor.Mode.DRAG);
        this.m_DragPlane.SetActive(true);
        this.CreateDraggedPack(this.m_unopenedPack);
        this.PickUpBooster();
        this.m_unopenedPack.StopAlert();
        this.m_Socket.OnPackHeld();
        this.m_director.OnPackHeld();
        this.ShowHintOnSlot();
        this.UpdateUIEvents();
    }

    private void InitializeNet()
    {
        NetCache.Get().RegisterScreenPackOpening(new NetCache.NetCacheCallback(this.OnNetDataReceived), new NetCache.ErrorCallback(NetCache.DefaultErrorHandler));
        Network.Get().RegisterNetHandler(Network.PacketID.OPENED_BOOSTER, new Network.NetHandler(this.OnBoosterOpened));
    }

    private void InitializeTransform()
    {
        if (this.m_showAnimEnabled)
        {
            this.m_SocketTrayInfo.m_RootObject.transform.position = this.m_SocketTrayInfo.m_AnimInfo.m_HiddenBone.position;
            this.m_PackTrayInfo.m_RootObject.transform.position = this.m_PackTrayInfo.m_AnimInfo.m_HiddenBone.position;
        }
        else
        {
            this.m_SocketTrayInfo.m_RootObject.transform.position = this.m_SocketTrayInfo.m_AnimInfo.m_ShownBone.position;
            this.m_PackTrayInfo.m_RootObject.transform.position = this.m_PackTrayInfo.m_AnimInfo.m_ShownBone.position;
        }
    }

    private void InitializeUI()
    {
        this.m_HeaderText.text = GameStrings.Get("GLUE_PACK_OPENING_HEADER");
        this.m_BackButton.SetText(GameStrings.Get("GLOBAL_BACK"));
        this.m_DragPlane.SetActive(false);
        this.m_InputBlocker.SetActive(false);
    }

    public static bool IsFakePackOpeningEnabled()
    {
        if (!ApplicationMgr.IsInternal())
        {
            return false;
        }
        return Options.Get().GetBool(Option.FAKE_PACK_OPENING);
    }

    public bool IsShowAnimEnabled()
    {
        return this.m_showAnimEnabled;
    }

    public bool IsShown()
    {
        return this.m_shown;
    }

    private void LayoutPacks()
    {
        Vector3 localPosition = this.m_PackTrayInfo.m_TopBone.localPosition;
        Vector3 vector2 = this.m_PackTrayInfo.m_BottomBone.localPosition;
        Vector3 vector3 = (Vector3) (0.5f * (vector2 + localPosition));
        this.m_unopenedPack.transform.parent = this.m_PackTrayInfo.m_RootObject.transform;
        this.m_unopenedPack.transform.localPosition = vector3;
    }

    private void OnBackButtonPressed(UIEvent e)
    {
        this.Hide();
    }

    private void OnBoosterOpened()
    {
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_BOOSTER_OPENED);
        List<NetCache.BoosterCard> cards = Network.OpenedBooster();
        this.m_director.OnBoosterOpened(cards);
    }

    private void OnDestroy()
    {
        if (this.m_draggedPack != null)
        {
            PegCursor.Get().SetMode(PegCursor.Mode.STOPDRAG);
        }
        this.ShutdownNet();
    }

    private void OnDirectorFinished(object userData)
    {
        if (this.m_unopenedPack.GetBoosterStack().Count == 0)
        {
            this.Hide();
        }
        else
        {
            this.m_InputBlocker.SetActive(false);
            this.CreateDirector();
        }
    }

    private void OnDraggedPackRelease(UIEvent e)
    {
        this.DropPack();
    }

    [DebuggerHidden]
    private IEnumerator OnFakeBoosterOpened()
    {
        return new <OnFakeBoosterOpened>c__Iterator93 { <>f__this = this };
    }

    private void OnHideSpellFinished(Spell spell, object userData)
    {
        this.m_InputBlocker.SetActive(false);
        this.UnregisterUIEvents();
        if (CollectionManagerDisplay.Get() != null)
        {
            CollectionManagerDisplay.Get().OnPackOpeningHidden();
        }
    }

    private void OnNetDataReceived()
    {
        this.UpdatePacks();
        if ((this.m_shown && !this.m_ShowSpell.IsActive()) && !this.m_shownComplete)
        {
            this.ShowImpl();
        }
    }

    private void OnShowSpellFinished(Spell spell, object userData)
    {
        this.m_shownComplete = true;
        this.UpdateUIEvents();
        if (this.m_unopenedPack != null)
        {
            this.m_unopenedPack.AddEventListener(UIEventType.RELEASEALL, new UIEvent.Handler(this.OnUnopenedPackReleaseAll));
            this.m_unopenedPack.PlayAlert();
            this.ShowHintOnUnopenedPack();
        }
    }

    private void OnUnopenedPackHold(UIEvent e)
    {
        this.HoldPack();
    }

    private void OnUnopenedPackLoaded(string name, GameObject go, object userData)
    {
        this.m_loadingUnopenedPack = false;
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("PackOpening.OnUnopenedPackLoaded() - FAILED to load {0}", name));
        }
        else
        {
            UnopenedPack component = go.GetComponent<UnopenedPack>();
            if (component == null)
            {
                UnityEngine.Debug.LogError(string.Format("PackOpening.OnUnopenedPackLoaded() - asset {0} did not have a {1} script on it", name, typeof(UnopenedPack)));
            }
            else
            {
                this.m_unopenedPack = component;
                NetCache.BoosterStack boosterStack = userData as NetCache.BoosterStack;
                this.UpdatePack(component, boosterStack);
                this.LayoutPacks();
                if (this.m_shownComplete)
                {
                    this.m_unopenedPack.AddEventListener(UIEventType.RELEASEALL, new UIEvent.Handler(this.OnUnopenedPackReleaseAll));
                    this.m_unopenedPack.PlayAlert();
                    this.ShowHintOnUnopenedPack();
                    this.UpdateUIEvents();
                }
            }
        }
    }

    private void OnUnopenedPackReleaseAll(UIEvent e)
    {
        if (this.m_draggedPack == null)
        {
            UIReleaseAllEvent event2 = (UIReleaseAllEvent) e;
            if (event2.GetMouseIsOver())
            {
                this.HoldPack();
            }
        }
        else
        {
            this.DropPack();
        }
    }

    private void OpenBooster(UnopenedPack pack)
    {
        if (!IsFakePackOpeningEnabled())
        {
            Network.OpenBooster(pack.GetBoosterStack().Type);
        }
        this.m_InputBlocker.SetActive(true);
        this.m_director.AddFinishedListener(new PackOpeningDirector.FinishedCallback(this.OnDirectorFinished));
        this.m_director.Play();
        if (IsFakePackOpeningEnabled())
        {
            base.StartCoroutine(this.OnFakeBoosterOpened());
        }
    }

    [DebuggerHidden]
    private IEnumerator OpenNextPackWhenReady()
    {
        return new <OpenNextPackWhenReady>c__Iterator94 { <>f__this = this };
    }

    private void PickUpBooster()
    {
        UnopenedPack creatorPack = this.m_draggedPack.GetCreatorPack();
        creatorPack.RemoveBooster();
        NetCache.BoosterStack boosterStack = new NetCache.BoosterStack {
            Type = creatorPack.GetBoosterStack().Type,
            Count = 1
        };
        this.m_draggedPack.SetBoosterStack(boosterStack);
    }

    private void PutBackBooster()
    {
        UnopenedPack creatorPack = this.m_draggedPack.GetCreatorPack();
        this.m_draggedPack.RemoveBooster();
        creatorPack.AddBooster();
    }

    public void Show()
    {
        if (!this.m_shown)
        {
            this.m_shown = true;
            this.m_shownComplete = false;
            this.CreateDirector();
            SoundManager.Get().NukeAmbienceAndStopPlayingCurrentTrack();
            SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_light");
            NetCache.Get().ReloadNetObject<NetCache.NetCacheBoosters>();
            BnetBar.Get().m_currencyFrame.RefreshContents();
        }
    }

    private void ShowHintOnSlot()
    {
        if (!Options.Get().GetBool(Option.HAS_OPENED_BOOSTER, false))
        {
            if (this.m_hintArrow == null)
            {
                this.m_hintArrow = NotificationManager.Get().CreateBouncingArrow(false);
                this.FixArrowScale(this.m_draggedPack.transform);
            }
            Bounds bounds = this.m_hintArrow.bounceObject.renderer.bounds;
            Vector3 position = this.m_SocketTrayInfo.m_HintBone.position;
            position.z += bounds.extents.z;
            this.m_hintArrow.transform.position = position;
        }
    }

    private void ShowHintOnUnopenedPack()
    {
        if (!Options.Get().GetBool(Option.HAS_OPENED_BOOSTER, false))
        {
            if (this.m_hintArrow == null)
            {
                this.m_hintArrow = NotificationManager.Get().CreateBouncingArrow(false);
                this.FixArrowScale(this.m_unopenedPack.transform);
            }
            Bounds bounds = this.m_unopenedPack.collider.bounds;
            Bounds bounds2 = this.m_hintArrow.bounceObject.renderer.bounds;
            Vector3 center = bounds.center;
            center.z += bounds.extents.z + bounds2.extents.z;
            this.m_hintArrow.transform.position = center;
        }
    }

    private void ShowImpl()
    {
        if (this.m_showAnimEnabled)
        {
            this.m_ShowSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnShowSpellFinished));
            this.m_ShowSpell.Activate();
        }
        else
        {
            this.OnShowSpellFinished(null, null);
        }
    }

    private void ShutdownNet()
    {
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnNetDataReceived));
        Network.Get().RemoveNetHandler(Network.PacketID.OPENED_BOOSTER);
    }

    private void UnregisterUIEvents()
    {
        this.m_BackButton.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnBackButtonPressed));
        this.m_storeButton.SetEnabled(false);
        if (this.m_unopenedPack != null)
        {
            this.m_unopenedPack.RemoveEventListener(UIEventType.HOLD, new UIEvent.Handler(this.OnUnopenedPackHold));
        }
    }

    private void Update()
    {
        this.UpdateDraggedPack();
    }

    private void UpdateDraggedPack()
    {
        if (this.m_draggedPack != null)
        {
            RaycastHit hit;
            Vector3 position = this.m_draggedPack.transform.position;
            if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.DragPlane.LayerBit(), out hit))
            {
                position.x = hit.point.x;
                position.z = hit.point.z;
                this.m_draggedPack.transform.position = position;
            }
        }
    }

    private void UpdatePack(UnopenedPack pack, NetCache.BoosterStack boosterStack)
    {
        pack.SetBoosterStack(boosterStack);
    }

    public void UpdatePacks()
    {
        NetCache.BoosterStack boosterStack = null;
        NetCache.NetCacheBoosters netObject = NetCache.Get().GetNetObject<NetCache.NetCacheBoosters>();
        if (netObject == null)
        {
            UnityEngine.Debug.LogError(string.Format("PackOpening.UpdatePacks() - boosters are null", new object[0]));
        }
        else
        {
            boosterStack = netObject.GetBoosterStack(BoosterType.EXPERT);
        }
        if (this.m_unopenedPack != null)
        {
            if (boosterStack == null)
            {
                UnityEngine.Object.Destroy(this.m_unopenedPack.gameObject);
                this.m_unopenedPack = null;
            }
            else
            {
                this.UpdatePack(this.m_unopenedPack, boosterStack);
                this.LayoutPacks();
            }
        }
        else if ((boosterStack != null) && !this.m_loadingUnopenedPack)
        {
            this.m_loadingUnopenedPack = true;
            AssetLoader.Get().LoadActor("UnopenedPack", new AssetLoader.GameObjectCallback(this.OnUnopenedPackLoaded), boosterStack);
        }
    }

    private void UpdateUIEvents()
    {
        if (!this.m_shown)
        {
            this.UnregisterUIEvents();
        }
        else if (this.m_draggedPack != null)
        {
            this.UnregisterUIEvents();
        }
        else
        {
            this.m_BackButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnBackButtonPressed));
            this.m_storeButton.SetEnabled(true);
            if (this.m_unopenedPack != null)
            {
                this.m_unopenedPack.AddEventListener(UIEventType.HOLD, new UIEvent.Handler(this.OnUnopenedPackHold));
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitThenInitDirectorTransform(Transform instanceTransform, Transform prefabTransform)
    {
        return new <WaitThenInitDirectorTransform>c__Iterator92 { instanceTransform = instanceTransform, prefabTransform = prefabTransform, <$>instanceTransform = instanceTransform, <$>prefabTransform = prefabTransform };
    }

    [CompilerGenerated]
    private sealed class <OnFakeBoosterOpened>c__Iterator93 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal PackOpening <>f__this;
        internal NetCache.BoosterCard <boosterCard>__2;
        internal List<NetCache.BoosterCard> <cards>__1;
        internal float <fakeNetDelay>__0;

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
                    this.<fakeNetDelay>__0 = UnityEngine.Random.Range((float) 0f, (float) 1f);
                    this.$current = new WaitForSeconds(this.<fakeNetDelay>__0);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<cards>__1 = new List<NetCache.BoosterCard>();
                    this.<boosterCard>__2 = new NetCache.BoosterCard();
                    this.<boosterCard>__2.Def.Name = "CS1_042";
                    this.<boosterCard>__2.Def.Premium = CardFlair.PremiumType.STANDARD;
                    this.<cards>__1.Add(this.<boosterCard>__2);
                    this.<boosterCard>__2 = new NetCache.BoosterCard();
                    this.<boosterCard>__2.Def.Name = "CS1_129";
                    this.<boosterCard>__2.Def.Premium = CardFlair.PremiumType.STANDARD;
                    this.<cards>__1.Add(this.<boosterCard>__2);
                    this.<boosterCard>__2 = new NetCache.BoosterCard();
                    this.<boosterCard>__2.Def.Name = "EX1_136";
                    this.<boosterCard>__2.Def.Premium = CardFlair.PremiumType.STANDARD;
                    this.<cards>__1.Add(this.<boosterCard>__2);
                    this.<boosterCard>__2 = new NetCache.BoosterCard();
                    this.<boosterCard>__2.Def.Name = "EX1_105";
                    this.<boosterCard>__2.Def.Premium = CardFlair.PremiumType.STANDARD;
                    this.<cards>__1.Add(this.<boosterCard>__2);
                    this.<boosterCard>__2 = new NetCache.BoosterCard();
                    this.<boosterCard>__2.Def.Name = "EX1_350";
                    this.<boosterCard>__2.Def.Premium = CardFlair.PremiumType.STANDARD;
                    this.<cards>__1.Add(this.<boosterCard>__2);
                    this.<>f__this.m_director.OnBoosterOpened(this.<cards>__1);
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
    private sealed class <OpenNextPackWhenReady>c__Iterator94 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal PackOpening <>f__this;
        internal float <waitTime>__0;

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
                    this.<waitTime>__0 = 0f;
                    if (this.<>f__this.m_director.IsPlaying())
                    {
                        this.<waitTime>__0 = 1f;
                    }
                    break;

                case 1:
                    break;

                case 2:
                    this.<>f__this.HoldPack();
                    this.$PC = -1;
                    goto Label_00AC;

                default:
                    goto Label_00AC;
            }
            if (this.<>f__this.m_director.IsPlaying())
            {
                this.$current = null;
                this.$PC = 1;
            }
            else
            {
                this.$current = new WaitForSeconds(this.<waitTime>__0);
                this.$PC = 2;
            }
            return true;
        Label_00AC:
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
    private sealed class <WaitThenInitDirectorTransform>c__Iterator92 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Transform <$>instanceTransform;
        internal Transform <$>prefabTransform;
        internal Transform instanceTransform;
        internal Transform prefabTransform;

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
                    this.$current = new WaitForEndOfFrame();
                    this.$PC = 1;
                    return true;

                case 1:
                    TransformUtil.CopyLocal((Component) this.instanceTransform, (Component) this.prefabTransform);
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
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MulliganManager : MonoBehaviour
{
    private const float ANIMATION_TIME_DEAL_CARD = 1.5f;
    public AnimationClip cardAnimatesFromBoardToDeck;
    public AnimationClip cardAnimatesFromDeckToBoard;
    public AnimationClip cardAnimatesFromTableToSky;
    private Vector3 coinLocation;
    private GameObject coinObject;
    public GameObject coinPrefab;
    private GameObject coinTossText;
    private bool enemyPlayerHasReplacementCards;
    private bool[] handCardMulliganStates = new bool[] { true, true, true, true };
    private ZoneHand handZone;
    public GameObject heroLabelPrefab;
    public AnimationClip hisheroAnimatesToPosition;
    private Actor hisHeroCardActor;
    private GameObject hisWeldEffect;
    private Notification innkeeperMulliganDialog;
    private bool introComplete;
    private bool localPlayerHasReplacementCards;
    private bool localPlayerWins;
    private MulliganTimer m_mulliganTimer;
    private List<Card> m_startingCards;
    private List<Card> m_startingOppCards;
    private List<GameObject> m_UIbuttons;
    private bool m_waitingForUserInput;
    private NormalButton mulliganButton;
    private GameObject mulliganChooseBanner;
    public GameObject mulliganChooseBannerPrefab;
    public GameObject mulliganKeepLabelPrefab;
    public bool mulliganMode;
    public GameObject mulliganReplaceLabelPrefab;
    public GameObject mulliganTimerPrefab;
    public GameObject mulliganXlabelPrefab;
    public AnimationClip myheroAnimatesToPosition;
    private Actor myHeroCardActor;
    private GameObject myWeldEffect;
    private int numCardsPitched;
    private ZoneDeck oppDeck;
    private ZoneHand oppHandZone;
    private bool runTurnStartManagerWhenFinished;
    private static MulliganManager s_instance;
    public AnimationClip shuffleDeck;
    private bool skipMulligan;
    private GameObject startingHandZone;
    private AudioSource versusVO;
    public GameObject vs_prefab;
    private GameObject vsTextObject;
    public GameObject weldPrefab;
    private GameObject[] xObjects;
    private ZoneDeck yourDeck;

    [DebuggerHidden]
    private IEnumerator AnimateCoinTossText()
    {
        return new <AnimateCoinTossText>c__Iterator54 { <>f__this = this };
    }

    public void AutomaticContinueMulligan()
    {
        if (this.WaitingForLocalMulliganInput())
        {
            if (this.mulliganButton != null)
            {
                this.mulliganButton.SetEnabled(false);
            }
            this.DestroyMulliganTimer();
            this.BeginDealNewCards();
        }
    }

    private void Awake()
    {
        s_instance = this;
        this.xObjects = new GameObject[4];
        AssetLoader.Get().LoadSound("VO_ANNOUNCER_VERSUS_21", new AssetLoader.GameObjectCallback(this.OnVersusVOLoaded));
    }

    public void BeginDealNewCards()
    {
        base.StartCoroutine(this.RemoveOldCardsAnimation());
    }

    private void BeginDealNewCards(UIEvent e)
    {
        ((NormalButton) e.GetElement()).SetEnabled(false);
        this.BeginDealNewCards();
    }

    public void BeginMulligan()
    {
        if (!this.mulliganMode)
        {
            this.mulliganMode = true;
            GameState.Get().MulliganManagerActivate(true);
            base.StartCoroutine(this.ContinueMulliganWhenBoardLoads());
        }
    }

    private void BeginMulliganCountdown(float endTimeStamp)
    {
        if (this.m_waitingForUserInput)
        {
            GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(this.mulliganTimerPrefab);
            this.m_mulliganTimer = obj2.GetComponent<MulliganTimer>();
            if (this.m_mulliganTimer == null)
            {
                UnityEngine.Object.Destroy(obj2);
            }
            if (!this.m_waitingForUserInput)
            {
                this.DestroyMulliganTimer();
            }
            this.m_mulliganTimer.SetRemainingTime(endTimeStamp);
        }
    }

    private void CoinTossTextCallback(string actorName, GameObject actorObject, object callbackData)
    {
        string str;
        this.coinTossText = actorObject;
        RenderUtils.SetAlpha(actorObject, 1f);
        actorObject.transform.position = this.coinLocation + new Vector3(0f, 0f, -1f);
        actorObject.transform.eulerAngles = new Vector3(90f, 0f, 0f);
        UberText componentInChildren = actorObject.transform.GetComponentInChildren<UberText>();
        if (this.localPlayerWins)
        {
            str = GameStrings.Get("GAMEPLAY_COIN_TOSS_WON");
        }
        else
        {
            str = GameStrings.Get("GAMEPLAY_COIN_TOSS_LOST");
        }
        componentInChildren.Text = str;
        GameState.Get().GetGameEntity().NotifyOfCoinFlipResult();
        Gameplay.Get().StartCoroutine(this.AnimateCoinTossText());
    }

    [DebuggerHidden]
    private IEnumerator ContinueMulliganWhenBoardLoads()
    {
        return new <ContinueMulliganWhenBoardLoads>c__Iterator50 { <>f__this = this };
    }

    private GameObject CreateNewUILabelAtCardPosition(GameObject prefab, int cardPosition)
    {
        GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(prefab);
        obj2.transform.position = new Vector3(this.m_startingCards[cardPosition].transform.position.x, this.m_startingCards[cardPosition].transform.position.y + 0.3f, this.m_startingCards[cardPosition].transform.position.z - (this.startingHandZone.collider.bounds.size.z / 2.6f));
        return obj2;
    }

    [DebuggerHidden]
    private IEnumerator DealStartingCards()
    {
        return new <DealStartingCards>c__Iterator52 { <>f__this = this };
    }

    private void DestroyButton(UnityEngine.Object buttonToDestroy)
    {
        UnityEngine.Object.Destroy(buttonToDestroy);
    }

    private void DestroyChooseBanner()
    {
        if (this.mulliganChooseBanner != null)
        {
            UnityEngine.Object.Destroy(this.mulliganChooseBanner);
        }
    }

    private void DestroyMulliganTimer()
    {
        if (this.m_mulliganTimer != null)
        {
            this.m_mulliganTimer.SelfDestruct();
            this.m_mulliganTimer = null;
        }
    }

    private void DestroyXobjects()
    {
        if (this.xObjects != null)
        {
            for (int i = 0; i < this.xObjects.Length; i++)
            {
                UnityEngine.Object.Destroy(this.xObjects[i]);
            }
            this.xObjects = null;
        }
    }

    [DebuggerHidden]
    private IEnumerator EnableHandCollidersAfterCardsAreDealt()
    {
        return new <EnableHandCollidersAfterCardsAreDealt>c__Iterator58 { <>f__this = this };
    }

    public void EndMulligan()
    {
        this.m_waitingForUserInput = false;
        if (this.m_UIbuttons != null)
        {
            for (int i = 0; i < this.m_UIbuttons.Count; i++)
            {
                UnityEngine.Object.Destroy(this.m_UIbuttons[i]);
            }
        }
        if (this.mulliganButton != null)
        {
            UnityEngine.Object.Destroy(this.mulliganButton.gameObject);
        }
        this.DestroyXobjects();
        this.DestroyChooseBanner();
        if (this.coinObject != null)
        {
            UnityEngine.Object.Destroy(this.coinObject);
        }
        if (this.vsTextObject != null)
        {
            UnityEngine.Object.Destroy(this.vsTextObject);
        }
        if (this.coinTossText != null)
        {
            SceneUtils.Destroy(this.coinTossText);
        }
        this.myHeroCardActor.transform.localPosition = new Vector3(0f, 0f, 0f);
        this.hisHeroCardActor.transform.localPosition = new Vector3(0f, 0f, 0f);
        this.myHeroCardActor.TurnOnCollider();
        this.hisHeroCardActor.TurnOnCollider();
        this.FadeOutMulliganMusicAndStartGameplayMusic();
        this.myHeroCardActor.GetHealthObject().Show();
        this.hisHeroCardActor.GetHealthObject().Show();
        foreach (Card card in this.handZone.GetCards())
        {
            card.GetActor().TurnOnCollider();
            card.GetActor().ToggleForceIdle(false);
        }
        if (!this.localPlayerHasReplacementCards)
        {
            base.StartCoroutine(this.EnableHandCollidersAfterCardsAreDealt());
        }
        Board.Get().FindCollider("DragPlane").enabled = true;
        this.mulliganMode = false;
        GameState.Get().MulliganManagerActivate(false);
        Board.Get().RaiseTheLights();
        this.FadeHeroPowerIn(GameState.Get().GetLocalPlayer().GetHeroPowerCard());
        this.FadeHeroPowerIn(GameState.Get().GetRemotePlayer().GetHeroPowerCard());
        this.handZone.SetDoNotUpdateLayout(false);
        this.handZone.UpdateLayout();
        if ((this.m_startingOppCards != null) && (this.m_startingOppCards.Count > 0))
        {
            this.m_startingOppCards[this.m_startingOppCards.Count - 1].SetDoNotSort(false);
        }
        this.oppHandZone.SetDoNotUpdateLayout(false);
        this.oppHandZone.UpdateLayout();
        GameState.Get().SetMulliganPacketBlocker(false);
        InputManager.Get().NotifyMulliganEnded();
        EndTurnButton.Get().NotifyOfMulliganEnd();
        GameState.Get().GetGameEntity().NotifyOfMulliganEnded();
        if (this.runTurnStartManagerWhenFinished)
        {
            base.StartCoroutine(this.WaitForBoardAnimToCompleteThenStartTurn());
        }
        else
        {
            UnityEngine.Object.Destroy(this);
        }
    }

    private void FadeHeroPowerIn(Card heroPowerCard)
    {
        if (heroPowerCard != null)
        {
            Actor actor = heroPowerCard.GetActor();
            actor.GetMeshRenderer().animation.Play("HeroPower_FadeIn");
            actor.animation.Play("HeroPower_ManaFadeOn");
            actor.TurnOnCollider();
            actor.GetCostTextObject().SetActive(true);
        }
    }

    private void FadeOutMulliganMusicAndStartGameplayMusic()
    {
        SoundManager.Get().NukeMusicAndAmbiencePlaylists();
        SoundManager.Get().StopCurrentMusicTrack();
        SoundManager.Get().AddNewMusicTrack("Bad Reputation");
        SoundManager.Get().AddNewMusicTrack("Duel");
        SoundManager.Get().AddNewMusicTrack("Better Hand");
        SoundManager.Get().AddNewMusicTrack("Don't Let Your Guard Down");
        SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_medium");
    }

    public static MulliganManager Get()
    {
        return s_instance;
    }

    public NormalButton GetMulliganButton()
    {
        return this.mulliganButton;
    }

    private void GetStartingLists()
    {
        this.m_startingCards = new List<Card>();
        List<Card> cards = this.handZone.GetCards();
        for (int i = 0; i < cards.Count; i++)
        {
            this.m_startingCards.Add(cards[i]);
        }
        this.m_startingOppCards = new List<Card>();
        List<Card> list2 = this.oppHandZone.GetCards();
        for (int j = 0; j < list2.Count; j++)
        {
            this.m_startingOppCards.Add(list2[j]);
        }
    }

    public void NotifyOfTurnBegun()
    {
        this.runTurnStartManagerWhenFinished = true;
    }

    private void OnMulliganButtonLoaded(string name, GameObject go, object userData)
    {
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("MulliganManager.OnMulliganButtonLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            this.mulliganButton = go.GetComponent<NormalButton>();
            if (this.mulliganButton == null)
            {
                UnityEngine.Debug.LogError(string.Format("MulliganManager.OnMulliganButtonLoaded() - ERROR \"{0}\" has no {1} component", name, typeof(NormalButton)));
            }
            else
            {
                this.mulliganButton.SetText(GameStrings.Get("GLOBAL_CONFIRM"));
            }
        }
    }

    private void OnMulliganTimerUpdate(int turn, float secondsRemaining, float endTimestamp, object userData)
    {
        if (secondsRemaining > float.Epsilon)
        {
            this.BeginMulliganCountdown(endTimestamp);
        }
        else
        {
            GameState.Get().UnregisterMulliganTimerUpdateListener(new GameState.MulliganTimerUpdateCallback(this.OnMulliganTimerUpdate));
            this.AutomaticContinueMulligan();
        }
    }

    private void OnVersusVOLoaded(string name, GameObject go, object userData)
    {
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("MulliganManager.OnVersusVOLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            this.versusVO = go.audio;
            if (this.versusVO == null)
            {
                UnityEngine.Debug.LogError(string.Format("MulliganManager.OnVersusVOLoaded() - ERROR \"{0}\" has no {1} component", name, typeof(AudioSource)));
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator PlayStartingTaunts()
    {
        return new <PlayStartingTaunts>c__Iterator51();
    }

    [DebuggerHidden]
    private IEnumerator RemoveOldCardsAnimation()
    {
        return new <RemoveOldCardsAnimation>c__Iterator55 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator RemoveUIButtons()
    {
        return new <RemoveUIButtons>c__Iterator57 { <>f__this = this };
    }

    private void ReSortHandAfterMulligan()
    {
        int num = 0;
        for (int i = 0; i < this.m_startingCards.Count; i++)
        {
            if (this.handCardMulliganStates[i])
            {
                num++;
            }
        }
        for (int j = 0; j < this.m_startingCards.Count; j++)
        {
            if (this.handCardMulliganStates[j])
            {
                Card card = this.handZone.GetCards()[this.m_startingCards.Count - num];
                this.handZone.RemoveCard(card);
                this.handZone.InsertCard(j, card);
                num--;
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator SampleAnimFrame(Animation animToUse, string animName, float startSec)
    {
        return new <SampleAnimFrame>c__Iterator5B { animToUse = animToUse, animName = animName, startSec = startSec, <$>animToUse = animToUse, <$>animName = animName, <$>startSec = startSec };
    }

    public void ServerHasDealtReplacementCards(bool local)
    {
        if (local)
        {
            this.localPlayerHasReplacementCards = true;
            if (GameState.Get().IsLocalPlayerTurn())
            {
                TurnStartManager.Get().BeginListeningForTurnEvents();
            }
        }
        else
        {
            this.enemyPlayerHasReplacementCards = true;
        }
    }

    [DebuggerHidden]
    private IEnumerator ShrinkStartingHandBanner(GameObject banner)
    {
        return new <ShrinkStartingHandBanner>c__Iterator5C { banner = banner, <$>banner = banner };
    }

    private void ShuffleDeck()
    {
        SoundManager.Get().LoadAndPlay("FX_MulliganCoin09_DeckShuffle", this.yourDeck.gameObject);
        Animation component = this.yourDeck.gameObject.GetComponent<Animation>();
        if (component == null)
        {
            component = this.yourDeck.gameObject.AddComponent<Animation>();
        }
        component.AddClip(this.shuffleDeck, "shuffleDeckAnim");
        component.Play("shuffleDeckAnim");
        component = this.oppDeck.gameObject.GetComponent<Animation>();
        if (component == null)
        {
            component = this.oppDeck.gameObject.AddComponent<Animation>();
        }
        component.AddClip(this.shuffleDeck, "shuffleDeckAnim");
        component.Play("shuffleDeckAnim");
    }

    public void SkipCardChoosing()
    {
        this.skipMulligan = true;
    }

    public void SkipMulligan()
    {
        base.StartCoroutine(this.SkipMulliganWhenIntroComplete());
    }

    [DebuggerHidden]
    private IEnumerator SkipMulliganWhenIntroComplete()
    {
        return new <SkipMulliganWhenIntroComplete>c__Iterator59 { <>f__this = this };
    }

    private void SlideCard(GameObject topCard)
    {
        object[] args = new object[] { "position", new Vector3(topCard.transform.position.x - 0.5f, topCard.transform.position.y, topCard.transform.position.z), "time", 0.5f, "easetype", iTween.EaseType.linear };
        iTween.MoveTo(topCard, iTween.Hash(args));
    }

    private void Start()
    {
        base.StartCoroutine(this.WaitForBoardThenLoadButton());
        base.StartCoroutine(this.WaitForHeroesAndStartAnimations());
        GameState.Get().RegisterMulliganTimerUpdateListener(new GameState.MulliganTimerUpdateCallback(this.OnMulliganTimerUpdate));
    }

    public void ToggleHoldState(Card toggleCard)
    {
        for (int i = 0; i < this.m_startingCards.Count; i++)
        {
            if (this.m_startingCards[i] == toggleCard)
            {
                this.ToggleHoldState(i);
                return;
            }
        }
    }

    public void ToggleHoldState(int cardNumber)
    {
        if ((cardNumber < this.m_startingCards.Count) && InputManager.Get().DoNetworkResponse(this.m_startingCards[cardNumber].GetEntity()))
        {
            this.handCardMulliganStates[cardNumber] = !this.handCardMulliganStates[cardNumber];
            if (!this.handCardMulliganStates[cardNumber])
            {
                SoundManager.Get().LoadAndPlay("GM_ChatWarning");
                if (this.xObjects[cardNumber] != null)
                {
                    UnityEngine.Object.Destroy(this.xObjects[cardNumber]);
                }
                UnityEngine.Object.Destroy(this.m_UIbuttons[cardNumber]);
            }
            else
            {
                SoundManager.Get().LoadAndPlay("HeroDropItem1");
                if (this.xObjects[cardNumber] != null)
                {
                    UnityEngine.Object.Destroy(this.xObjects[cardNumber]);
                }
                this.xObjects[cardNumber] = (GameObject) UnityEngine.Object.Instantiate(this.mulliganXlabelPrefab, this.m_startingCards[cardNumber].transform.position, this.m_startingCards[cardNumber].transform.rotation);
                this.m_UIbuttons[cardNumber] = this.CreateNewUILabelAtCardPosition(this.mulliganReplaceLabelPrefab, cardNumber);
            }
        }
    }

    private void ToggleHoldState(UIEvent e)
    {
        this.ToggleHoldState(((NormalButton) e.GetElement()).GetButtonID());
    }

    [DebuggerHidden]
    private IEnumerator WaitAFrameBeforeSendingEventToMulliganButton()
    {
        return new <WaitAFrameBeforeSendingEventToMulliganButton>c__Iterator53 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitForBoardAnimToCompleteThenStartTurn()
    {
        return new <WaitForBoardAnimToCompleteThenStartTurn>c__Iterator5A { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitForBoardThenLoadButton()
    {
        return new <WaitForBoardThenLoadButton>c__Iterator4E { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitForHeroesAndStartAnimations()
    {
        return new <WaitForHeroesAndStartAnimations>c__Iterator4F { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitForOpponentToFinishMulligan()
    {
        return new <WaitForOpponentToFinishMulligan>c__Iterator56 { <>f__this = this };
    }

    private bool WaitingForLocalMulliganInput()
    {
        return (((TAG_MULLIGAN) GameState.Get().GetLocalPlayer().GetTag<TAG_MULLIGAN>(GAME_TAG.MULLIGAN_STATE)) == TAG_MULLIGAN.INPUT);
    }

    [CompilerGenerated]
    private sealed class <AnimateCoinTossText>c__Iterator54 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MulliganManager <>f__this;

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
                    this.$current = new WaitForSeconds(1.8f);
                    this.$PC = 1;
                    goto Label_016E;

                case 1:
                    if (this.<>f__this.coinTossText != null)
                    {
                        iTween.FadeTo(this.<>f__this.coinTossText, 1f, 0.25f);
                        iTween.MoveTo(this.<>f__this.coinTossText, this.<>f__this.coinTossText.transform.position + new Vector3(0f, 0.5f, 0f), 2f);
                        this.$current = new WaitForSeconds(1.9f);
                        this.$PC = 2;
                        goto Label_016E;
                    }
                    break;

                case 2:
                case 3:
                    if (MissionMgr.Get().IsBusy())
                    {
                        this.$current = null;
                        this.$PC = 3;
                    }
                    else
                    {
                        if (this.<>f__this.coinTossText == null)
                        {
                            break;
                        }
                        iTween.FadeTo(this.<>f__this.coinTossText, 0f, 1f);
                        this.$current = new WaitForSeconds(0.1f);
                        this.$PC = 4;
                    }
                    goto Label_016E;

                case 4:
                    SceneUtils.Destroy(this.<>f__this.coinTossText);
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_016E:
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
    private sealed class <ContinueMulliganWhenBoardLoads>c__Iterator50 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<Zone>.Enumerator <$s_272>__1;
        internal MulliganManager <>f__this;
        internal Collider <dragPlane>__3;
        internal Zone <zone>__2;
        internal List<Zone> <zones>__0;

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
                    if (ZoneMgr.Get() == null)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<>f__this.startingHandZone = Board.Get().FindBone("StartingHandZone").gameObject;
                    this.<zones>__0 = ZoneMgr.Get().GetZones();
                    this.<$s_272>__1 = this.<zones>__0.GetEnumerator();
                    try
                    {
                        while (this.<$s_272>__1.MoveNext())
                        {
                            this.<zone>__2 = this.<$s_272>__1.Current;
                            if (this.<zone>__2 is ZoneHand)
                            {
                                if (this.<zone>__2.m_Side == Player.Side.FRIENDLY)
                                {
                                    this.<>f__this.handZone = (ZoneHand) this.<zone>__2;
                                }
                                else
                                {
                                    this.<>f__this.oppHandZone = (ZoneHand) this.<zone>__2;
                                }
                            }
                            if (this.<zone>__2 is ZoneDeck)
                            {
                                if (this.<zone>__2.m_Side == Player.Side.FRIENDLY)
                                {
                                    this.<>f__this.yourDeck = (ZoneDeck) this.<zone>__2;
                                }
                                else
                                {
                                    this.<>f__this.oppDeck = (ZoneDeck) this.<zone>__2;
                                }
                            }
                        }
                    }
                    finally
                    {
                        this.<$s_272>__1.Dispose();
                    }
                    this.<dragPlane>__3 = Board.Get().FindCollider("DragPlane");
                    this.<dragPlane>__3.enabled = false;
                    this.<>f__this.StartCoroutine(this.<>f__this.DealStartingCards());
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
    private sealed class <DealStartingCards>c__Iterator52 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<Card>.Enumerator <$s_273>__0;
        internal List<Card>.Enumerator <$s_274>__18;
        internal MulliganManager <>f__this;
        internal Card <card>__1;
        internal Transform <coinSpawnLocation>__15;
        internal Vector3[] <drawPath>__12;
        internal Vector3[] <drawPath>__16;
        internal int <i>__11;
        internal int <i>__17;
        internal int <i>__20;
        internal float <leftSideOfZone>__6;
        internal Vector3 <mulliganChooseBannerPosition>__13;
        internal int <numCardsToDeal>__9;
        internal float <rightSideOfZone>__7;
        internal float <spaceForEachCard>__3;
        internal float <spaceForEachCardPre4th>__4;
        internal float <spacingToUse>__5;
        internal Card <startCard>__19;
        internal Vector3 <startingScale>__14;
        internal float <timingBonus>__8;
        internal GameObject <topCard>__2;
        internal float <xOffset>__10;

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
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 1;
                    goto Label_0FD2;

                case 1:
                case 2:
                    if (!this.<>f__this.introComplete)
                    {
                        this.$current = null;
                        this.$PC = 2;
                        goto Label_0FD2;
                    }
                    break;

                case 3:
                    break;

                case 4:
                    SoundManager.Get().LoadAndPlay("FX_GameStart09_CardsOntoTable", this.<topCard>__2);
                    this.<xOffset>__10 += this.<spacingToUse>__5;
                    this.$current = new WaitForSeconds(0.05f + this.<timingBonus>__8);
                    this.$PC = 5;
                    goto Label_0FD2;

                case 5:
                    goto Label_05F0;

                case 6:
                    this.<coinSpawnLocation>__15 = Board.Get().FindBone("MulliganCoinPosition");
                    this.<>f__this.coinObject = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.coinPrefab, this.<coinSpawnLocation>__15.position, this.<coinSpawnLocation>__15.rotation);
                    this.<>f__this.coinObject.GetComponent<CoinEffect>().DoAnim(this.<>f__this.localPlayerWins);
                    SoundManager.Get().LoadAndPlay("FX_MulliganCoin03_CoinFlip", this.<>f__this.coinObject);
                    this.<>f__this.coinLocation = this.<coinSpawnLocation>__15.position;
                    AssetLoader.Get().LoadActor("MulliganResultText", new AssetLoader.GameObjectCallback(this.<>f__this.CoinTossTextCallback));
                    this.$current = new WaitForSeconds(2f);
                    this.$PC = 7;
                    goto Label_0FD2;

                case 7:
                {
                    if (this.<>f__this.localPlayerWins)
                    {
                        this.<>f__this.m_startingOppCards[this.<>f__this.m_startingOppCards.Count - 1].SetDoNotSort(false);
                        this.<>f__this.oppHandZone.UpdateLayout();
                        goto Label_0A8D;
                    }
                    this.<topCard>__2 = this.<>f__this.m_startingCards[this.<>f__this.m_startingCards.Count - 1].gameObject;
                    this.<drawPath>__16 = new Vector3[] { this.<topCard>__2.transform.position, new Vector3(this.<topCard>__2.transform.position.x, this.<topCard>__2.transform.position.y + 3.6f, this.<topCard>__2.transform.position.z), new Vector3(this.<leftSideOfZone>__6 + this.<xOffset>__10, this.<>f__this.handZone.transform.position.y, this.<>f__this.startingHandZone.transform.position.z - 0.3f) };
                    object[] args = new object[] { "path", this.<drawPath>__16, "time", 1.5f, "easetype", iTween.EaseType.easeInSineOutExpo };
                    iTween.MoveTo(this.<topCard>__2, iTween.Hash(args));
                    iTween.ScaleTo(this.<topCard>__2, new Vector3(1.1f, 1.1f, 1.1f), 1.5f);
                    object[] objArray4 = new object[] { "rotation", new Vector3(0f, 0f, 0f), "time", 1.5f, "delay", 0.1875f };
                    iTween.RotateTo(this.<topCard>__2, iTween.Hash(objArray4));
                    this.$current = new WaitForSeconds(0.04f);
                    this.$PC = 8;
                    goto Label_0FD2;
                }
                case 8:
                    SoundManager.Get().LoadAndPlay("FX_GameStart20_CardDealSingle", this.<topCard>__2);
                    goto Label_0A8D;

                case 9:
                case 10:
                    while (MissionMgr.Get().IsBusy())
                    {
                        this.$current = null;
                        this.$PC = 10;
                        goto Label_0FD2;
                    }
                    if (this.<>f__this.localPlayerWins)
                    {
                        this.<xOffset>__10 = 0f;
                        this.<i>__17 = this.<>f__this.m_startingCards.Count - 1;
                        while (this.<i>__17 >= 0)
                        {
                            this.<topCard>__2 = this.<>f__this.m_startingCards[this.<i>__17].gameObject;
                            iTween.Stop(this.<topCard>__2);
                            object[] objArray5 = new object[] { "position", new Vector3(((this.<rightSideOfZone>__7 - this.<spaceForEachCard>__3) - this.<xOffset>__10) + (this.<spaceForEachCard>__3 / 2f), this.<>f__this.handZone.transform.position.y, this.<>f__this.startingHandZone.transform.position.z - 0.3f), "time", 0.9333333f, "easetype", iTween.EaseType.easeInOutCubic };
                            iTween.MoveTo(this.<topCard>__2, iTween.Hash(objArray5));
                            this.<xOffset>__10 += this.<spaceForEachCard>__3;
                            this.<i>__17--;
                        }
                    }
                    this.$current = new WaitForSeconds(0.6f);
                    this.$PC = 11;
                    goto Label_0FD2;

                case 11:
                    if (!this.<>f__this.skipMulligan)
                    {
                        this.<$s_274>__18 = this.<>f__this.m_startingCards.GetEnumerator();
                        try
                        {
                            while (this.<$s_274>__18.MoveNext())
                            {
                                this.<startCard>__19 = this.<$s_274>__18.Current;
                                this.<startCard>__19.GetActor().TurnOnCollider();
                            }
                        }
                        finally
                        {
                            this.<$s_274>__18.Dispose();
                        }
                        this.<>f__this.mulliganChooseBanner = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.mulliganChooseBannerPrefab, Board.Get().FindBone("MulliganChooseBannerPosition").position, new Quaternion(0f, 0f, 0f, 0f));
                        this.<>f__this.mulliganChooseBanner.GetComponent<Banner>().SetText(GameStrings.Get("GAMEPLAY_BANNER_STARTING_HAND"), GameStrings.Get("GAMEPLAY_BANNER_SUBTITLE"));
                        this.<>f__this.m_UIbuttons = new List<GameObject>();
                        this.<i>__20 = 0;
                        while (this.<i>__20 < this.<>f__this.m_startingCards.Count)
                        {
                            this.<>f__this.handCardMulliganStates[this.<i>__20] = !this.<>f__this.handCardMulliganStates[this.<i>__20];
                            InputManager.Get().DoNetworkResponse(this.<>f__this.m_startingCards[this.<i>__20].GetEntity());
                            this.<>f__this.m_UIbuttons.Add(null);
                            this.<i>__20++;
                        }
                        goto Label_0E05;
                    }
                    this.$current = new WaitForSeconds(2f);
                    this.$PC = 12;
                    goto Label_0FD2;

                case 12:
                    this.<>f__this.EndMulligan();
                    goto Label_0FD0;

                case 13:
                    goto Label_0E05;

                case 14:
                    goto Label_0F9D;

                default:
                    goto Label_0FD0;
            }
            while (ZoneMgr.Get().HasActiveServerChange())
            {
                this.$current = null;
                this.$PC = 3;
                goto Label_0FD2;
            }
            if (GameState.Get().GetGameEntity().ShouldDoOpeningTaunts())
            {
                this.<>f__this.StartCoroutine(this.<>f__this.PlayStartingTaunts());
            }
            this.<>f__this.GetStartingLists();
            this.<$s_273>__0 = this.<>f__this.m_startingCards.GetEnumerator();
            try
            {
                while (this.<$s_273>__0.MoveNext())
                {
                    this.<card>__1 = this.<$s_273>__0.Current;
                    this.<card>__1.GetActor().SetActorState(ActorStateType.CARD_IDLE);
                    this.<card>__1.GetActor().TurnOffCollider();
                    this.<card>__1.GetActor().GetMeshRenderer().gameObject.layer = 8;
                }
            }
            finally
            {
                this.<$s_273>__0.Dispose();
            }
            this.<topCard>__2 = null;
            this.<spaceForEachCard>__3 = this.<>f__this.startingHandZone.collider.bounds.size.x / ((float) this.<>f__this.m_startingCards.Count);
            this.<spaceForEachCardPre4th>__4 = this.<>f__this.startingHandZone.collider.bounds.size.x / ((float) (this.<>f__this.m_startingCards.Count + 1));
            this.<spacingToUse>__5 = this.<spaceForEachCardPre4th>__4;
            this.<leftSideOfZone>__6 = this.<>f__this.startingHandZone.transform.position.x - (this.<>f__this.startingHandZone.collider.bounds.size.x / 2f);
            this.<rightSideOfZone>__7 = this.<>f__this.startingHandZone.transform.position.x + (this.<>f__this.startingHandZone.collider.bounds.size.x / 2f);
            this.<timingBonus>__8 = 0.1f;
            this.<>f__this.localPlayerWins = GameState.Get().GetLocalPlayer().GetTag(GAME_TAG.FIRST_PLAYER) == 1;
            this.<numCardsToDeal>__9 = this.<>f__this.m_startingCards.Count;
            if (!this.<>f__this.localPlayerWins)
            {
                this.<numCardsToDeal>__9--;
                this.<spacingToUse>__5 = this.<spaceForEachCard>__3;
            }
            else
            {
                this.<>f__this.m_startingOppCards[this.<>f__this.m_startingOppCards.Count - 1].SetDoNotSort(true);
            }
            this.<>f__this.oppHandZone.SetDoNotUpdateLayout(false);
            this.<>f__this.oppHandZone.UpdateLayout();
            this.<xOffset>__10 = this.<spacingToUse>__5 / 2f;
            this.<i>__11 = 0;
            while (this.<i>__11 < this.<numCardsToDeal>__9)
            {
                this.<topCard>__2 = this.<>f__this.m_startingCards[this.<i>__11].gameObject;
                iTween.Stop(this.<topCard>__2);
                this.<drawPath>__12 = new Vector3[] { this.<topCard>__2.transform.position, new Vector3(this.<topCard>__2.transform.position.x, this.<topCard>__2.transform.position.y + 3.6f, this.<topCard>__2.transform.position.z), new Vector3(this.<leftSideOfZone>__6 + this.<xOffset>__10, this.<>f__this.handZone.transform.position.y, this.<>f__this.startingHandZone.transform.position.z - 0.3f) };
                object[] objArray1 = new object[] { "path", this.<drawPath>__12, "time", 1.5f, "easetype", iTween.EaseType.easeInSineOutExpo };
                iTween.MoveTo(this.<topCard>__2, iTween.Hash(objArray1));
                iTween.ScaleTo(this.<topCard>__2, new Vector3(1.1f, 1.1f, 1.1f), 1.5f);
                object[] objArray2 = new object[] { "rotation", new Vector3(0f, 0f, 0f), "time", 1.5f, "delay", 0.09375f };
                iTween.RotateTo(this.<topCard>__2, iTween.Hash(objArray2));
                this.$current = new WaitForSeconds(0.04f);
                this.$PC = 4;
                goto Label_0FD2;
            Label_05F0:
                this.<timingBonus>__8 = 0f;
                this.<i>__11++;
            }
            if (this.<>f__this.skipMulligan)
            {
                this.<>f__this.mulliganChooseBanner = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.mulliganChooseBannerPrefab);
                this.<>f__this.mulliganChooseBanner.GetComponent<Banner>().SetText(GameStrings.Get("GAMEPLAY_BANNER_STARTING_HAND"));
                this.<mulliganChooseBannerPosition>__13 = Board.Get().FindBone("MulliganChooseBannerPosition").position;
                this.<>f__this.mulliganChooseBanner.transform.position = this.<mulliganChooseBannerPosition>__13;
                this.<startingScale>__14 = this.<>f__this.mulliganChooseBanner.transform.localScale;
                this.<>f__this.mulliganChooseBanner.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
                iTween.ScaleTo(this.<>f__this.mulliganChooseBanner, this.<startingScale>__14, 0.5f);
                this.<>f__this.StartCoroutine(this.<>f__this.ShrinkStartingHandBanner(this.<>f__this.mulliganChooseBanner));
            }
            this.$current = new WaitForSeconds(1.1f);
            this.$PC = 6;
            goto Label_0FD2;
        Label_0A8D:
            this.$current = new WaitForSeconds(1.75f);
            this.$PC = 9;
            goto Label_0FD2;
        Label_0E05:
            while (this.<>f__this.mulliganButton == null)
            {
                this.$current = null;
                this.$PC = 13;
                goto Label_0FD2;
            }
            this.<>f__this.mulliganButton.transform.position = new Vector3(this.<>f__this.startingHandZone.transform.position.x, this.<>f__this.handZone.transform.position.y, this.<>f__this.myHeroCardActor.transform.position.z);
            this.<>f__this.mulliganButton.transform.localEulerAngles = new Vector3(90f, 90f, 90f);
            this.<>f__this.mulliganButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.<>f__this.BeginDealNewCards));
            this.<>f__this.StartCoroutine(this.<>f__this.WaitAFrameBeforeSendingEventToMulliganButton());
            if (!Options.Get().GetBool(Option.HAS_SEEN_MULLIGAN, false))
            {
                this.<>f__this.innkeeperMulliganDialog = NotificationManager.Get().CreateInnkeeperQuote(new Vector3(569f, -792f, 0f), GameStrings.Get("VO_ANNOUNCER_MULLIGAN_44"), "VO_ANNOUNCER_MULLIGAN_44");
                Options.Get().SetBool(Option.HAS_SEEN_MULLIGAN, true);
                this.<>f__this.mulliganButton.collider.enabled = false;
            }
            SoundManager.Get().NukeAmbienceAndStopPlayingCurrentTrack();
            SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_medium");
            this.<>f__this.m_waitingForUserInput = true;
        Label_0F9D:
            while (this.<>f__this.innkeeperMulliganDialog != null)
            {
                this.$current = null;
                this.$PC = 14;
                goto Label_0FD2;
            }
            this.<>f__this.mulliganButton.collider.enabled = true;
            this.$PC = -1;
        Label_0FD0:
            return false;
        Label_0FD2:
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
    private sealed class <EnableHandCollidersAfterCardsAreDealt>c__Iterator58 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<Card>.Enumerator <$s_278>__0;
        internal MulliganManager <>f__this;
        internal Card <card>__1;

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
                    if (!this.<>f__this.localPlayerHasReplacementCards)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<$s_278>__0 = this.<>f__this.handZone.GetCards().GetEnumerator();
                    try
                    {
                        while (this.<$s_278>__0.MoveNext())
                        {
                            this.<card>__1 = this.<$s_278>__0.Current;
                            this.<card>__1.GetActor().TurnOnCollider();
                        }
                    }
                    finally
                    {
                        this.<$s_278>__0.Dispose();
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
    private sealed class <PlayStartingTaunts>c__Iterator51 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal AudioSource <audioSource>__2;
        internal Spell <emote>__1;
        internal EmoteType <emoteToPlay>__4;
        internal Card <heroCard>__0;
        internal Card <myHeroCard>__3;

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
                    this.<heroCard>__0 = GameState.Get().GetRemotePlayer().GetHeroCard();
                    GameState.Get().GetGameEntity().FadeInHeroActor(this.<heroCard>__0.GetActor());
                    this.<emote>__1 = this.<heroCard>__0.GetEmoteSpell(EmoteType.START);
                    this.<heroCard>__0.PlayEmote(EmoteType.START);
                    this.<audioSource>__2 = this.<emote>__1.GetFirstSpellState(1).m_AudioSources[0].m_AudioSource;
                    break;

                case 1:
                    break;

                case 2:
                    goto Label_019F;

                default:
                    goto Label_01D0;
            }
            if (this.<audioSource>__2.isPlaying)
            {
                this.$current = null;
                this.$PC = 1;
                goto Label_01D2;
            }
            GameState.Get().GetGameEntity().FadeOutHeroActor(this.<heroCard>__0.GetActor());
            this.<myHeroCard>__3 = GameState.Get().GetLocalPlayer().GetHeroCard();
            GameState.Get().GetGameEntity().FadeInHeroActor(this.<myHeroCard>__3.GetActor());
            this.<emoteToPlay>__4 = EmoteType.START;
            if (this.<myHeroCard>__3.GetEntity().GetCardId() == this.<heroCard>__0.GetEntity().GetCardId())
            {
                this.<emoteToPlay>__4 = EmoteType.THREATEN;
            }
            this.<emote>__1 = this.<myHeroCard>__3.GetEmoteSpell(this.<emoteToPlay>__4);
            this.<myHeroCard>__3.PlayEmote(this.<emoteToPlay>__4);
            this.<audioSource>__2 = this.<emote>__1.GetFirstSpellState(1).m_AudioSources[0].m_AudioSource;
        Label_019F:
            while (this.<audioSource>__2.isPlaying)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_01D2;
            }
            GameState.Get().GetGameEntity().FadeOutHeroActor(this.<myHeroCard>__3.GetActor());
            this.$PC = -1;
        Label_01D0:
            return false;
        Label_01D2:
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
    private sealed class <RemoveOldCardsAnimation>c__Iterator55 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<Card>.Enumerator <$s_275>__1;
        internal List<Card>.Enumerator <$s_276>__8;
        internal MulliganManager <>f__this;
        internal string <animName>__17;
        internal Card <card>__2;
        internal Card <card>__9;
        internal Animation <cardAnim>__16;
        internal Animation <cardAnim>__7;
        internal GameObject <cardObject>__5;
        internal Vector3[] <drawPath>__15;
        internal Vector3[] <drawPath>__6;
        internal int <i>__13;
        internal int <i>__4;
        internal float <leftSideOfZone>__11;
        internal Vector3 <mulliganedCardsPosition>__0;
        internal float <spaceForEachCard>__10;
        internal float <TO_DECK_ANIMATION_TIME>__3;
        internal GameObject <topCard>__14;
        internal float <xOffset>__12;

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
                    this.<>f__this.m_waitingForUserInput = false;
                    this.<>f__this.DestroyMulliganTimer();
                    SoundManager.Get().LoadAndPlay("FX_GameStart28_CardDismissWoosh2_v2");
                    this.<mulliganedCardsPosition>__0 = Board.Get().FindBone("MulliganedCardsPosition").position;
                    this.<>f__this.DestroyXobjects();
                    this.<>f__this.DestroyChooseBanner();
                    Gameplay.Get().RemoveClassNames();
                    this.<$s_275>__1 = this.<>f__this.m_startingCards.GetEnumerator();
                    try
                    {
                        while (this.<$s_275>__1.MoveNext())
                        {
                            this.<card>__2 = this.<$s_275>__1.Current;
                            this.<card>__2.GetActor().SetActorState(ActorStateType.CARD_IDLE);
                            this.<card>__2.GetActor().ToggleForceIdle(true);
                            this.<card>__2.GetActor().TurnOffCollider();
                        }
                    }
                    finally
                    {
                        this.<$s_275>__1.Dispose();
                    }
                    Gameplay.Get().StartCoroutine(this.<>f__this.RemoveUIButtons());
                    this.<TO_DECK_ANIMATION_TIME>__3 = 1.5f;
                    this.<i>__4 = 0;
                    while (this.<i>__4 < this.<>f__this.m_startingCards.Count)
                    {
                        if (this.<>f__this.handCardMulliganStates[this.<i>__4])
                        {
                            this.<cardObject>__5 = this.<>f__this.m_startingCards[this.<i>__4].gameObject;
                            this.<drawPath>__6 = new Vector3[] { this.<cardObject>__5.transform.position, new Vector3(this.<cardObject>__5.transform.position.x + 2f, this.<cardObject>__5.transform.position.y - 1.7f, this.<cardObject>__5.transform.position.z), new Vector3(this.<mulliganedCardsPosition>__0.x, this.<mulliganedCardsPosition>__0.y, this.<mulliganedCardsPosition>__0.z), this.<>f__this.yourDeck.transform.position };
                            object[] args = new object[] { "path", this.<drawPath>__6, "time", this.<TO_DECK_ANIMATION_TIME>__3, "easetype", iTween.EaseType.easeOutCubic };
                            iTween.MoveTo(this.<cardObject>__5, iTween.Hash(args));
                            this.<cardAnim>__7 = this.<cardObject>__5.GetComponent<Animation>();
                            if (this.<cardAnim>__7 == null)
                            {
                                this.<cardAnim>__7 = this.<cardObject>__5.AddComponent<Animation>();
                            }
                            this.<cardAnim>__7.AddClip(this.<>f__this.cardAnimatesFromBoardToDeck, "putCardBack");
                            this.<cardAnim>__7.Play("putCardBack");
                            this.<>f__this.numCardsPitched++;
                            this.$current = new WaitForSeconds(0.5f);
                            this.$PC = 1;
                            goto Label_0911;
                        }
                    Label_034A:
                        this.<i>__4++;
                    }
                    UnityEngine.Object.Destroy(this.<>f__this.coinObject);
                    InputManager.Get().DoEndTurnButton();
                    break;

                case 1:
                    goto Label_034A;

                case 2:
                    break;

                case 3:
                    goto Label_0816;

                case 4:
                    this.<>f__this.ShuffleDeck();
                    this.$current = new WaitForSeconds(1.5f);
                    this.$PC = 5;
                    goto Label_0911;

                case 5:
                    if (!this.<>f__this.enemyPlayerHasReplacementCards)
                    {
                        this.<>f__this.StartCoroutine(this.<>f__this.WaitForOpponentToFinishMulligan());
                    }
                    else
                    {
                        this.<>f__this.EndMulligan();
                    }
                    this.$PC = -1;
                    goto Label_090F;

                default:
                    goto Label_090F;
            }
            while (!this.<>f__this.localPlayerHasReplacementCards)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_0911;
            }
            this.<>f__this.ReSortHandAfterMulligan();
            this.<$s_276>__8 = this.<>f__this.handZone.GetCards().GetEnumerator();
            try
            {
                while (this.<$s_276>__8.MoveNext())
                {
                    this.<card>__9 = this.<$s_276>__8.Current;
                    this.<card>__9.GetActor().SetActorState(ActorStateType.CARD_IDLE);
                    this.<card>__9.GetActor().ToggleForceIdle(true);
                }
            }
            finally
            {
                this.<$s_276>__8.Dispose();
            }
            this.<spaceForEachCard>__10 = this.<>f__this.startingHandZone.collider.bounds.size.x / ((float) this.<>f__this.m_startingCards.Count);
            this.<leftSideOfZone>__11 = this.<>f__this.startingHandZone.transform.position.x - (this.<>f__this.startingHandZone.collider.bounds.size.x / 2f);
            this.<xOffset>__12 = 0f;
            this.<i>__13 = 0;
            while (this.<i>__13 < this.<>f__this.m_startingCards.Count)
            {
                if (!this.<>f__this.handCardMulliganStates[this.<i>__13])
                {
                    goto Label_0852;
                }
                this.<topCard>__14 = this.<>f__this.handZone.GetCards()[this.<i>__13].gameObject;
                iTween.Stop(this.<topCard>__14);
                object[] objArray2 = new object[] { "position", new Vector3(((this.<leftSideOfZone>__11 + this.<spaceForEachCard>__10) + this.<xOffset>__12) - (this.<spaceForEachCard>__10 / 2f), this.<>f__this.handZone.collider.bounds.center.y, this.<>f__this.startingHandZone.transform.position.z), "time", 3f };
                iTween.MoveTo(this.<topCard>__14, iTween.Hash(objArray2));
                this.<drawPath>__15 = new Vector3[4];
                this.<drawPath>__15[0] = this.<topCard>__14.transform.position;
                this.<drawPath>__15[1] = new Vector3(this.<mulliganedCardsPosition>__0.x, this.<mulliganedCardsPosition>__0.y, this.<mulliganedCardsPosition>__0.z);
                this.<drawPath>__15[3] = new Vector3(((this.<leftSideOfZone>__11 + this.<spaceForEachCard>__10) + this.<xOffset>__12) - (this.<spaceForEachCard>__10 / 2f), this.<>f__this.handZone.collider.bounds.center.y, this.<>f__this.startingHandZone.transform.position.z - 0.3f);
                this.<drawPath>__15[2] = new Vector3(this.<drawPath>__15[3].x + 2f, this.<drawPath>__15[3].y - 1.7f, this.<drawPath>__15[3].z);
                object[] objArray3 = new object[] { "path", this.<drawPath>__15, "time", this.<TO_DECK_ANIMATION_TIME>__3, "easetype", iTween.EaseType.easeInCubic };
                iTween.MoveTo(this.<topCard>__14, iTween.Hash(objArray3));
                this.<cardAnim>__16 = this.<topCard>__14.GetComponent<Animation>();
                if (this.<cardAnim>__16 == null)
                {
                    this.<cardAnim>__16 = this.<topCard>__14.AddComponent<Animation>();
                }
                this.<animName>__17 = "putCardBack";
                this.<cardAnim>__16.AddClip(this.<>f__this.cardAnimatesFromBoardToDeck, this.<animName>__17);
                this.<cardAnim>__16[this.<animName>__17].normalizedTime = 1f;
                this.<cardAnim>__16[this.<animName>__17].speed = -1f;
                this.<cardAnim>__16.Play(this.<animName>__17);
                this.$current = new WaitForSeconds(0.5f);
                this.$PC = 3;
                goto Label_0911;
            Label_0816:
                if (this.<topCard>__14.audio == null)
                {
                    this.<topCard>__14.AddComponent("AudioSource");
                }
                SoundManager.Get().LoadAndPlay("FX_GameStart30_CardReplaceSingle", this.<topCard>__14);
            Label_0852:
                this.<xOffset>__12 += this.<spaceForEachCard>__10;
                this.<i>__13++;
            }
            this.$current = new WaitForSeconds(1f);
            this.$PC = 4;
            goto Label_0911;
        Label_090F:
            return false;
        Label_0911:
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
    private sealed class <RemoveUIButtons>c__Iterator57 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MulliganManager <>f__this;
        internal int <i>__0;

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
                    if (this.<>f__this.mulliganButton != null)
                    {
                        this.<>f__this.mulliganButton.m_button.GetComponent<PlayMakerFSM>().SendEvent("Death");
                    }
                    this.<i>__0 = 0;
                    while (this.<i>__0 < this.<>f__this.m_UIbuttons.Count)
                    {
                        if (this.<>f__this.m_UIbuttons[this.<i>__0] != null)
                        {
                            object[] args = new object[] { "rotation", new Vector3(0f, 0f, 0f), "time", 0.5f, "easetype", iTween.EaseType.easeInExpo };
                            iTween.RotateTo(this.<>f__this.m_UIbuttons[this.<i>__0], iTween.Hash(args));
                            object[] objArray2 = new object[] { "scale", new Vector3(0.001f, 0.001f, 0.001f), "time", 0.5f, "easetype", iTween.EaseType.easeInExpo, "oncomplete", "DestroyButton", "oncompletetarget", this.<>f__this.gameObject, "oncompleteparams", this.<>f__this.m_UIbuttons[this.<i>__0] };
                            iTween.ScaleTo(this.<>f__this.m_UIbuttons[this.<i>__0], iTween.Hash(objArray2));
                            this.$current = new WaitForSeconds(0.05f);
                            this.$PC = 1;
                            goto Label_0249;
                        }
                    Label_01D0:
                        this.<i>__0++;
                    }
                    this.$current = new WaitForSeconds(3.5f);
                    this.$PC = 2;
                    goto Label_0249;

                case 1:
                    goto Label_01D0;

                case 2:
                    if (this.<>f__this.mulliganButton != null)
                    {
                        UnityEngine.Object.Destroy(this.<>f__this.mulliganButton.gameObject);
                    }
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_0249:
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
    private sealed class <SampleAnimFrame>c__Iterator5B : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal string <$>animName;
        internal Animation <$>animToUse;
        internal float <$>startSec;
        internal AnimationState <state>__0;
        internal string animName;
        internal Animation animToUse;
        internal float startSec;

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
                    this.<state>__0 = this.animToUse[this.animName];
                    this.<state>__0.enabled = true;
                    this.<state>__0.time = this.startSec;
                    this.animToUse.Play(this.animName);
                    this.$current = new WaitForSeconds(0f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<state>__0.enabled = false;
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
    private sealed class <ShrinkStartingHandBanner>c__Iterator5C : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GameObject <$>banner;
        internal GameObject banner;

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
                    this.$current = new WaitForSeconds(4f);
                    this.$PC = 1;
                    goto Label_0095;

                case 1:
                    iTween.ScaleTo(this.banner, new Vector3(0f, 0f, 0f), 0.5f);
                    this.$current = new WaitForSeconds(0.5f);
                    this.$PC = 2;
                    goto Label_0095;

                case 2:
                    UnityEngine.Object.Destroy(this.banner);
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_0095:
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
    private sealed class <SkipMulliganWhenIntroComplete>c__Iterator59 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MulliganManager <>f__this;
        internal Collider <dragPlane>__0;
        internal ZoneHand <handZone>__1;
        internal ZoneHand <oppHandZone>__2;

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
                    this.<>f__this.m_waitingForUserInput = false;
                    break;

                case 1:
                    break;

                default:
                    goto Label_022F;
            }
            if (!this.<>f__this.introComplete)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            if (this.<>f__this.coinObject != null)
            {
                UnityEngine.Object.Destroy(this.<>f__this.coinObject);
            }
            if (this.<>f__this.vsTextObject != null)
            {
                UnityEngine.Object.Destroy(this.<>f__this.vsTextObject);
            }
            if (this.<>f__this.coinTossText != null)
            {
                SceneUtils.Destroy(this.<>f__this.coinTossText);
            }
            this.<>f__this.myHeroCardActor.TurnOnCollider();
            this.<>f__this.hisHeroCardActor.TurnOnCollider();
            this.<>f__this.FadeOutMulliganMusicAndStartGameplayMusic();
            this.<>f__this.myHeroCardActor.GetHealthObject().Show();
            this.<>f__this.hisHeroCardActor.GetHealthObject().Show();
            this.<dragPlane>__0 = Board.Get().FindCollider("DragPlane");
            this.<dragPlane>__0.enabled = true;
            this.<>f__this.FadeHeroPowerIn(GameState.Get().GetLocalPlayer().GetHeroPowerCard());
            this.<>f__this.FadeHeroPowerIn(GameState.Get().GetRemotePlayer().GetHeroPowerCard());
            GameState.Get().MulliganManagerActivate(false);
            this.<handZone>__1 = ZoneMgr.Get().FindZoneOfType<ZoneHand>(TAG_ZONE.HAND, Player.Side.FRIENDLY);
            this.<oppHandZone>__2 = ZoneMgr.Get().FindZoneOfType<ZoneHand>(TAG_ZONE.HAND, Player.Side.OPPOSING);
            this.<handZone>__1.SetDoNotUpdateLayout(false);
            this.<handZone>__1.UpdateLayout();
            this.<oppHandZone>__2.SetDoNotUpdateLayout(false);
            this.<oppHandZone>__2.UpdateLayout();
            InputManager.Get().NotifyMulliganEnded();
            EndTurnButton.Get().NotifyOfMulliganEnd();
            GameState.Get().GetGameEntity().NotifyOfMulliganEnded();
            if (this.<>f__this.runTurnStartManagerWhenFinished)
            {
                this.<>f__this.StartCoroutine(this.<>f__this.WaitForBoardAnimToCompleteThenStartTurn());
            }
            else
            {
                UnityEngine.Object.Destroy(this.<>f__this);
            }
            this.$PC = -1;
        Label_022F:
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
    private sealed class <WaitAFrameBeforeSendingEventToMulliganButton>c__Iterator53 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MulliganManager <>f__this;

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
                    this.$current = null;
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.mulliganButton.m_button.GetComponent<PlayMakerFSM>().SendEvent("Birth");
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
    private sealed class <WaitForBoardAnimToCompleteThenStartTurn>c__Iterator5A : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MulliganManager <>f__this;

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
                    this.$current = new WaitForSeconds(1.5f);
                    this.$PC = 1;
                    return true;

                case 1:
                    TurnStartManager.Get().BeginPlayingTurnEvents();
                    UnityEngine.Object.Destroy(this.<>f__this);
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
    private sealed class <WaitForBoardThenLoadButton>c__Iterator4E : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MulliganManager <>f__this;

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
                    if (BoardStandardGame.Get() == null)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    AssetLoader.Get().LoadActor("MulliganButton", new AssetLoader.GameObjectCallback(this.<>f__this.OnMulliganButtonLoaded));
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
    private sealed class <WaitForHeroesAndStartAnimations>c__Iterator4F : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MulliganManager <>f__this;
        internal Animation <cardAnim>__12;
        internal Card <heroCard>__1;
        internal Card <heroCard>__2;
        internal GameObject <heroLabelCopy>__11;
        internal GameObject <hisHero>__8;
        internal Material <hisHeroFrameMat>__6;
        internal HeroLabel <hisheroLabel>__10;
        internal AudioSource <hisHeroLine>__15;
        internal Material <hisHeroMat>__5;
        internal Hashtable <hisLightBlendArgs>__19;
        internal GameObject <myHero>__7;
        internal Material <myHeroFrameMat>__4;
        internal HeroLabel <myheroLabel>__9;
        internal AudioSource <myHeroLine>__14;
        internal Material <myHeroMat>__3;
        internal Hashtable <myLightBlendArgs>__17;
        internal Action<object> <OnHisLightBlendUpdate>__18;
        internal Action<object> <OnMyLightBlendUpdate>__16;
        internal Animation <oppCardAnim>__13;
        internal Player <player>__0;

        internal void <>m__2E(object amount)
        {
            this.<myHeroMat>__3.SetFloat("_LightingBlend", (float) amount);
            this.<myHeroFrameMat>__4.SetFloat("_LightingBlend", (float) amount);
        }

        internal void <>m__2F(object amount)
        {
            this.<hisHeroMat>__5.SetFloat("_LightingBlend", (float) amount);
            this.<hisHeroFrameMat>__6.SetFloat("_LightingBlend", (float) amount);
        }

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
                    if ((this.<>f__this.myHeroCardActor == null) || (this.<>f__this.hisHeroCardActor == null))
                    {
                        this.<player>__0 = GameState.Get().GetLocalPlayer();
                        if (this.<player>__0 != null)
                        {
                            this.<heroCard>__1 = this.<player>__0.GetHeroCard();
                            if (this.<heroCard>__1 != null)
                            {
                                this.<>f__this.myHeroCardActor = this.<heroCard>__1.GetActor();
                            }
                        }
                        this.<player>__0 = GameState.Get().GetRemotePlayer();
                        if (this.<player>__0 != null)
                        {
                            this.<heroCard>__2 = this.<player>__0.GetHeroCard();
                            if (this.<heroCard>__2 != null)
                            {
                                this.<>f__this.hisHeroCardActor = this.<heroCard>__2.GetActor();
                            }
                        }
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_0C3E;
                    }
                    break;

                case 2:
                    break;

                case 3:
                    goto Label_018D;

                case 4:
                    this.<myHero>__7 = this.<>f__this.myHeroCardActor.gameObject;
                    this.<hisHero>__8 = this.<>f__this.hisHeroCardActor.gameObject;
                    this.<>f__this.myHeroCardActor.GetHealthObject().Hide();
                    this.<>f__this.hisHeroCardActor.GetHealthObject().Hide();
                    this.<>f__this.vsTextObject = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.vs_prefab);
                    this.<>f__this.vsTextObject.transform.position = Board.Get().FindBone("VS_Position").position;
                    this.<myheroLabel>__9 = null;
                    this.<hisheroLabel>__10 = null;
                    if (!MissionMgr.Get().IsTutorial())
                    {
                        this.<heroLabelCopy>__11 = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.heroLabelPrefab);
                        this.<myheroLabel>__9 = this.<heroLabelCopy>__11.GetComponent<HeroLabel>();
                        this.<myheroLabel>__9.transform.parent = this.<>f__this.myHeroCardActor.GetMeshRenderer().transform;
                        this.<myheroLabel>__9.transform.localPosition = new Vector3(0f, 0f, 0f);
                        this.<myheroLabel>__9.UpdateText(this.<>f__this.myHeroCardActor.GetEntity().GetName(), GameStrings.GetClassName(this.<>f__this.myHeroCardActor.GetEntity().GetClass()).ToUpper());
                        this.<heroLabelCopy>__11 = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.heroLabelPrefab);
                        this.<hisheroLabel>__10 = this.<heroLabelCopy>__11.GetComponent<HeroLabel>();
                        this.<hisheroLabel>__10.transform.parent = this.<>f__this.hisHeroCardActor.GetMeshRenderer().transform;
                        this.<hisheroLabel>__10.transform.localPosition = new Vector3(0f, 0f, 0f);
                        this.<hisheroLabel>__10.UpdateText(this.<>f__this.hisHeroCardActor.GetEntity().GetName(), GameStrings.GetClassName(this.<>f__this.hisHeroCardActor.GetEntity().GetClass()).ToUpper());
                    }
                    goto Label_0604;

                case 5:
                    goto Label_0604;

                case 6:
                    goto Label_0769;

                case 7:
                    SoundManager.Get().PlayPreloaded(this.<>f__this.versusVO);
                    goto Label_07C7;

                case 8:
                    goto Label_07C7;

                case 9:
                    this.<hisHeroLine>__15 = this.<>f__this.hisHeroCardActor.GetCard().GetAnnouncerLine();
                    SoundManager.Get().Play(this.<hisHeroLine>__15);
                    goto Label_0843;

                case 10:
                    goto Label_0843;

                case 11:
                    goto Label_08BC;

                case 12:
                    this.<>f__this.vsTextObject.animation.Play();
                    this.$current = new WaitForSeconds(0.32f);
                    this.$PC = 13;
                    goto Label_0C3E;

                case 13:
                    this.<>f__this.myWeldEffect = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.weldPrefab);
                    this.<>f__this.myWeldEffect.transform.position = this.<myHero>__7.transform.position;
                    this.<>f__this.myWeldEffect.GetComponent<HeroWeld>().DoAnim();
                    this.<>f__this.hisWeldEffect = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.weldPrefab);
                    this.<>f__this.hisWeldEffect.transform.position = this.<hisHero>__8.transform.position;
                    this.<>f__this.myWeldEffect.GetComponent<HeroWeld>().DoAnim();
                    this.$current = new WaitForSeconds(0.05f);
                    this.$PC = 14;
                    goto Label_0C3E;

                case 14:
                {
                    object[] args = new object[] { "time", 0.6f, "amount", new Vector3(0.03f, 0.01f, 0.03f) };
                    iTween.ShakePosition(Camera.main.gameObject, iTween.Hash(args));
                    this.<OnMyLightBlendUpdate>__16 = new Action<object>(this.<>m__2E);
                    this.<OnMyLightBlendUpdate>__16(0f);
                    object[] objArray2 = new object[] { "time", 1f, "from", 0f, "to", 1f, "delay", 2f, "onupdate", this.<OnMyLightBlendUpdate>__16, "onupdatetarget", this.<>f__this.gameObject };
                    this.<myLightBlendArgs>__17 = iTween.Hash(objArray2);
                    iTween.ValueTo(this.<>f__this.gameObject, this.<myLightBlendArgs>__17);
                    this.<OnHisLightBlendUpdate>__18 = new Action<object>(this.<>m__2F);
                    this.<OnHisLightBlendUpdate>__18(0f);
                    object[] objArray3 = new object[] { "time", 1f, "from", 0f, "to", 1f, "delay", 2f, "onupdate", this.<OnHisLightBlendUpdate>__18, "onupdatetarget", this.<>f__this.gameObject };
                    this.<hisLightBlendArgs>__19 = iTween.Hash(objArray3);
                    iTween.ValueTo(this.<>f__this.gameObject, this.<hisLightBlendArgs>__19);
                    this.<>f__this.introComplete = true;
                    GameState.Get().GetGameEntity().NotifyOfHeroesFinishedAnimatingInMulligan();
                    this.$PC = -1;
                    goto Label_0C3C;
                }
                default:
                    goto Label_0C3C;
            }
            while ((GameState.Get() == null) || GameState.Get().GetGameEntity().IsPreloadingAssets())
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_0C3E;
            }
        Label_018D:
            while (this.<>f__this.versusVO == null)
            {
                this.$current = null;
                this.$PC = 3;
                goto Label_0C3E;
            }
            this.<myHeroMat>__3 = this.<>f__this.myHeroCardActor.m_portraitMesh.renderer.materials[this.<>f__this.myHeroCardActor.m_portraitMatIdx];
            this.<myHeroFrameMat>__4 = this.<>f__this.myHeroCardActor.m_portraitMesh.renderer.materials[this.<>f__this.myHeroCardActor.m_portraitFrameMatIdx];
            if ((this.<myHeroMat>__3 != null) && this.<myHeroMat>__3.HasProperty("_LightingBlend"))
            {
                this.<myHeroMat>__3.SetFloat("_LightingBlend", 0f);
            }
            if ((this.<myHeroFrameMat>__4 != null) && this.<myHeroFrameMat>__4.HasProperty("_LightingBlend"))
            {
                this.<myHeroFrameMat>__4.SetFloat("_LightingBlend", 0f);
            }
            this.<hisHeroMat>__5 = this.<>f__this.hisHeroCardActor.m_portraitMesh.renderer.materials[this.<>f__this.hisHeroCardActor.m_portraitMatIdx];
            this.<hisHeroFrameMat>__6 = this.<>f__this.hisHeroCardActor.m_portraitMesh.renderer.materials[this.<>f__this.hisHeroCardActor.m_portraitFrameMatIdx];
            if ((this.<hisHeroMat>__5 != null) && this.<hisHeroMat>__5.HasProperty("_LightingBlend"))
            {
                this.<hisHeroMat>__5.SetFloat("_LightingBlend", 0f);
            }
            if ((this.<hisHeroFrameMat>__6 != null) && this.<hisHeroFrameMat>__6.HasProperty("_LightingBlend"))
            {
                this.<hisHeroFrameMat>__6.SetFloat("_LightingBlend", 0f);
            }
            this.<>f__this.myHeroCardActor.TurnOffCollider();
            this.<>f__this.hisHeroCardActor.TurnOffCollider();
            if (GameState.Get().GetGameEntity().ShouldDoAlternateMulliganIntro())
            {
                this.<>f__this.introComplete = true;
                goto Label_0C3C;
            }
            SceneMgr.Get().NotifySceneLoaded();
            this.$current = new WaitForSeconds(LoadingScreen.Get().m_FadeInSec);
            this.$PC = 4;
            goto Label_0C3E;
        Label_0604:
            if (LoadingScreen.Get().IsPreviousSceneActive())
            {
                this.$current = 0;
                this.$PC = 5;
                goto Label_0C3E;
            }
            SoundManager.Get().NukeAmbienceAndStopPlayingCurrentTrack();
            SoundManager.Get().AddNewMusicTrack("Mulligan");
            SoundManager.Get().AddNewAmbienceTrack("tavern_wallah loop_heavy");
            this.<cardAnim>__12 = this.<myHero>__7.GetComponent<Animation>();
            if (this.<cardAnim>__12 == null)
            {
                this.<cardAnim>__12 = this.<myHero>__7.AddComponent<Animation>();
            }
            this.<cardAnim>__12.AddClip(this.<>f__this.hisheroAnimatesToPosition, "hisHeroAnimateToPosition");
            this.<>f__this.StartCoroutine(this.<>f__this.SampleAnimFrame(this.<cardAnim>__12, "hisHeroAnimateToPosition", 0f));
            this.<oppCardAnim>__13 = this.<hisHero>__8.GetComponent<Animation>();
            if (this.<oppCardAnim>__13 == null)
            {
                this.<oppCardAnim>__13 = this.<hisHero>__8.AddComponent<Animation>();
            }
            this.<oppCardAnim>__13.AddClip(this.<>f__this.myheroAnimatesToPosition, "myHeroAnimateToPosition");
            this.<>f__this.StartCoroutine(this.<>f__this.SampleAnimFrame(this.<oppCardAnim>__13, "myHeroAnimateToPosition", 0f));
            this.<myHeroLine>__14 = this.<>f__this.myHeroCardActor.GetCard().GetAnnouncerLine();
            SoundManager.Get().Play(this.<myHeroLine>__14);
        Label_0769:
            while (SoundManager.Get().IsActive(this.<myHeroLine>__14))
            {
                this.$current = null;
                this.$PC = 6;
                goto Label_0C3E;
            }
            this.$current = new WaitForSeconds(0.05f);
            this.$PC = 7;
            goto Label_0C3E;
        Label_07C7:
            while (SoundManager.Get().IsActive(this.<>f__this.versusVO))
            {
                this.$current = null;
                this.$PC = 8;
                goto Label_0C3E;
            }
            this.$current = new WaitForSeconds(0.05f);
            this.$PC = 9;
            goto Label_0C3E;
        Label_0843:
            while (SoundManager.Get().IsActive(this.<hisHeroLine>__15))
            {
                this.$current = null;
                this.$PC = 10;
                goto Label_0C3E;
            }
            if (!MissionMgr.Get().IsTutorial())
            {
                this.<myheroLabel>__9.transform.parent = null;
                this.<hisheroLabel>__10.transform.parent = null;
                this.<myheroLabel>__9.FadeOut();
                this.<hisheroLabel>__10.FadeOut();
                this.$current = new WaitForSeconds(0.5f);
                this.$PC = 11;
                goto Label_0C3E;
            }
        Label_08BC:
            this.<cardAnim>__12["hisHeroAnimateToPosition"].enabled = true;
            this.<oppCardAnim>__13["myHeroAnimateToPosition"].enabled = true;
            SoundManager.Get().LoadAndPlay("FX_MulliganCoin01_HeroCoinDrop", this.<>f__this.hisHeroCardActor.GetCard().gameObject);
            this.$current = new WaitForSeconds(0.1f);
            this.$PC = 12;
            goto Label_0C3E;
        Label_0C3C:
            return false;
        Label_0C3E:
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
    private sealed class <WaitForOpponentToFinishMulligan>c__Iterator56 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MulliganManager <>f__this;
        internal Vector3 <mulliganBannerPosition>__0;

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
                    this.<>f__this.DestroyChooseBanner();
                    this.<mulliganBannerPosition>__0 = Board.Get().FindBone("MulliganChooseBannerPosition").position;
                    this.<>f__this.mulliganChooseBanner = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.mulliganChooseBannerPrefab, new Vector3(this.<mulliganBannerPosition>__0.x, this.<>f__this.handZone.transform.position.y, this.<>f__this.myHeroCardActor.transform.position.z + 0.4f), new Quaternion(0f, 0f, 0f, 0f));
                    this.<>f__this.mulliganChooseBanner.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    iTween.ScaleTo(this.<>f__this.mulliganChooseBanner, new Vector3(1.4f, 1.4f, 1.4f), 0.4f);
                    this.<>f__this.mulliganChooseBanner.GetComponent<Banner>().SetText(GameStrings.Get("GAMEPLAY_BANNER_WAITING"));
                    this.<>f__this.mulliganChooseBanner.GetComponent<Banner>().MoveGlowForBottomPlacement();
                    break;

                case 1:
                    break;

                default:
                    goto Label_019E;
            }
            if (!this.<>f__this.enemyPlayerHasReplacementCards && !GameState.Get().IsGameOver())
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<>f__this.EndMulligan();
            this.$PC = -1;
        Label_019E:
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


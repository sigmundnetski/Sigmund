using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TurnStartManager : MonoBehaviour
{
    private List<Entity> m_cardsToDraw;
    private List<Entity> m_cardsToUntap;
    private List<FatigueSpellController> m_fatigueSpellsToProcess;
    private TurnStartIndicator m_turnStartInstance;
    public TurnStartIndicator m_turnStartPrefab;
    private int manaCrystalsFilled;
    private int manaCrystalsGained;
    private static TurnStartManager s_instance;
    private bool twoScoopsDisplayed;

    private void Awake()
    {
        s_instance = this;
        this.m_turnStartInstance = (TurnStartIndicator) UnityEngine.Object.Instantiate(this.m_turnStartPrefab);
        this.m_turnStartInstance.transform.parent = base.transform;
    }

    public void BeginListeningForTurnEvents()
    {
        this.m_cardsToDraw = new List<Entity>();
        this.m_cardsToUntap = new List<Entity>();
        this.manaCrystalsGained = 0;
        this.manaCrystalsFilled = 0;
        this.twoScoopsDisplayed = false;
        GameState.Get().ToggleTurnStartManager(true);
    }

    public void BeginPlayingTurnEvents()
    {
        base.StartCoroutine(this.RunTurnEventsWithTiming());
    }

    private void DisplayTwoScoops()
    {
        if (!this.twoScoopsDisplayed)
        {
            this.twoScoopsDisplayed = true;
            this.m_turnStartInstance.SetReminderText(GameState.Get().GetGameEntity().GetTurnStartReminderText());
            this.m_turnStartInstance.Show();
            SoundManager.Get().LoadAndPlay("ALERT_YourTurn_0v2");
        }
    }

    private void DoAllUntapping()
    {
        List<Entity> list = new List<Entity>();
        foreach (Entity entity in this.m_cardsToUntap)
        {
            list.Add(entity);
        }
        this.m_cardsToUntap.Clear();
        foreach (Entity entity2 in list)
        {
            entity2.GetCard().DoVisualUntap(false);
        }
    }

    public static TurnStartManager Get()
    {
        return s_instance;
    }

    public int GetNumCardsToDraw()
    {
        return this.m_cardsToDraw.Count;
    }

    public bool IsThisCardDrawAlreadyHandledByTurnStartManager(Card card)
    {
        return ((((this.m_cardsToDraw != null) && (card != null)) && (card.GetEntity() != null)) && this.m_cardsToDraw.Contains(card.GetEntity()));
    }

    public void NotifyOfCardDrawn(Entity drawnEntity)
    {
        this.m_cardsToDraw.Add(drawnEntity);
    }

    public void NotifyOfFatigueEvent(FatigueSpellController fatigueSpellController)
    {
        this.m_fatigueSpellsToProcess.Add(fatigueSpellController);
        this.BeginPlayingTurnEvents();
    }

    public void NotifyOfManaCrystalFilled(int amount)
    {
        this.manaCrystalsFilled += amount;
    }

    public void NotifyOfManaCrystalGained(int amount)
    {
        this.manaCrystalsGained += amount;
    }

    public void NotifyOfTriggerVisual()
    {
        this.DisplayTwoScoops();
    }

    public void NotifyOfUntap(Entity untapEntity)
    {
        this.m_cardsToUntap.Add(untapEntity);
    }

    [DebuggerHidden]
    private IEnumerator RunTurnEventsWithTiming()
    {
        return new <RunTurnEventsWithTiming>c__Iterator62 { <>f__this = this };
    }

    private void Start()
    {
        this.m_cardsToDraw = new List<Entity>();
        this.m_cardsToUntap = new List<Entity>();
        this.m_fatigueSpellsToProcess = new List<FatigueSpellController>();
    }

    private void StopListeningForTurnEvents()
    {
        GameState.Get().ToggleTurnStartManager(false);
    }

    [CompilerGenerated]
    private sealed class <RunTurnEventsWithTiming>c__Iterator62 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<Entity>.Enumerator <$s_308>__2;
        internal List<Entity>.Enumerator <$s_309>__4;
        internal List<FatigueSpellController>.Enumerator <$s_310>__7;
        internal TurnStartManager <>f__this;
        internal Card <card>__6;
        internal List<Entity> <cardsToDraw>__1;
        internal Entity <entity>__3;
        internal Entity <entity>__5;
        internal FatigueSpellController <fatigueSpellController>__8;
        internal Player <localPlayer>__0;

        [DebuggerHidden]
        public void Dispose()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 3:
                    try
                    {
                    }
                    finally
                    {
                        this.<$s_309>__4.Dispose();
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
                    if (GameState.Get().IsTurnStartManagerActive())
                    {
                        this.<>f__this.StopListeningForTurnEvents();
                        if (MissionMgr.Get().IsPlayingAI())
                        {
                            this.$current = new WaitForSeconds(1f);
                            this.$PC = 1;
                            goto Label_031D;
                        }
                        break;
                    }
                    goto Label_031B;

                case 1:
                    break;

                case 2:
                    this.<cardsToDraw>__1 = new List<Entity>();
                    this.<$s_308>__2 = this.<>f__this.m_cardsToDraw.GetEnumerator();
                    try
                    {
                        while (this.<$s_308>__2.MoveNext())
                        {
                            this.<entity>__3 = this.<$s_308>__2.Current;
                            this.<cardsToDraw>__1.Add(this.<entity>__3);
                        }
                    }
                    finally
                    {
                        this.<$s_308>__2.Dispose();
                    }
                    this.<>f__this.m_cardsToDraw.Clear();
                    this.<localPlayer>__0.GetHandZone().UpdateLayout();
                    this.<$s_309>__4 = this.<cardsToDraw>__1.GetEnumerator();
                    num = 0xfffffffd;
                    goto Label_0195;

                case 3:
                    goto Label_0195;

                case 4:
                    this.<$s_310>__7 = this.<>f__this.m_fatigueSpellsToProcess.GetEnumerator();
                    try
                    {
                        while (this.<$s_310>__7.MoveNext())
                        {
                            this.<fatigueSpellController>__8 = this.<$s_310>__7.Current;
                            this.<fatigueSpellController>__8.DoPowerTaskList();
                        }
                    }
                    finally
                    {
                        this.<$s_310>__7.Dispose();
                    }
                    this.<>f__this.m_fatigueSpellsToProcess.Clear();
                    if (GameState.Get().IsLocalPlayerTurn())
                    {
                        GameState.Get().GetGameEntity().NotifyOfStartOfTurnEventsFinished();
                        EndTurnButton.Get().SetStateToYourTurn();
                        if (!GameState.Get().IsInTargetMode() && !GameState.Get().IsInSubOptionMode())
                        {
                            GameState.Get().EnterMainOptionMode();
                        }
                        TurnTimer.Get().OnTurnStartManagerFinished();
                    }
                    this.$PC = -1;
                    goto Label_031B;

                default:
                    goto Label_031B;
            }
            this.<>f__this.DisplayTwoScoops();
            this.<localPlayer>__0 = GameState.Get().GetLocalPlayer();
            this.<localPlayer>__0.ReadyManaCrystal(this.<>f__this.manaCrystalsFilled);
            this.<localPlayer>__0.AddManaCrystal(this.<>f__this.manaCrystalsGained, true);
            this.<localPlayer>__0.UpdateManaCounter();
            this.<>f__this.DoAllUntapping();
            this.$current = new WaitForSeconds(1f);
            this.$PC = 2;
            goto Label_031D;
        Label_0195:
            try
            {
                switch (num)
                {
                    case 3:
                        goto Label_01E2;
                }
                while (this.<$s_309>__4.MoveNext())
                {
                    this.<entity>__5 = this.<$s_309>__4.Current;
                    this.<card>__6 = this.<entity>__5.GetCard();
                Label_01E2:
                    while (this.<card>__6.GetActorName() == "Card_Hidden")
                    {
                        this.$current = null;
                        this.$PC = 3;
                        flag = true;
                        goto Label_031D;
                    }
                    this.<card>__6.DoCardDrawAnimation();
                }
            }
            finally
            {
                if (!flag)
                {
                }
                this.<$s_309>__4.Dispose();
            }
            this.$current = new WaitForSeconds(1f);
            this.$PC = 4;
            goto Label_031D;
        Label_031B:
            return false;
        Label_031D:
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
}


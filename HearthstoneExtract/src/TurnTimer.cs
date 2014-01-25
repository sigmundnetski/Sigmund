using System;
using System.Collections;
using UnityEngine;

public class TurnTimer : MonoBehaviour
{
    private float m_countdownEndTimestamp;
    private float m_countdownTimeoutSec;
    private uint m_currentMatValAnimId;
    private uint m_currentMoveAnimId;
    private bool m_currentTimerBelongsToLocalPlayer;
    public float m_DebugTimeout = 30f;
    public float m_DebugTimeoutStart = 20f;
    public float m_FuseMatValFinish = -1.5f;
    public string m_FuseMatValName = "_Xamount";
    public float m_FuseMatValStart = 0.42f;
    public GameObject m_FuseShadowObject;
    public GameObject m_FuseWickObject;
    public Transform m_SparksFinishBone;
    public GameObject m_SparksObject;
    public Transform m_SparksStartBone;
    private Spell m_spell;
    private TurnTimerState m_state;
    private bool m_waitingForTurnStartManagerFinish;
    private static TurnTimer s_instance;

    private void Awake()
    {
        s_instance = this;
        this.m_spell = base.GetComponent<Spell>();
        this.m_spell.AddStateStartedCallback(new Spell.StateStartedCallback(this.OnSpellStateStarted));
        if (GameState.Get() != null)
        {
            GameState.Get().RegisterTurnTimerUpdateListener(new GameState.TurnTimerUpdateCallback(this.OnTurnTimerUpdate));
        }
    }

    private void ChangeSpellState(TurnTimerState timerState)
    {
        SpellStateType stateType = this.TranslateTimerStateToSpellState(timerState);
        this.m_spell.ActivateState(stateType);
    }

    private void ChangeState(TurnTimerState state)
    {
        this.ChangeSpellState(state);
    }

    private void ChangeState_Countdown()
    {
        this.m_state = TurnTimerState.COUNTDOWN;
        this.m_countdownTimeoutSec = this.ComputeCountdownRemainingSec();
        this.RestartCountdownAnims(this.m_countdownTimeoutSec);
    }

    private void ChangeState_Kill()
    {
        this.m_state = TurnTimerState.KILL;
        this.m_countdownEndTimestamp = 0f;
        this.StopCountdownAnims();
        this.UpdateCountdownAnims(0f);
    }

    private void ChangeState_Start()
    {
        this.m_state = TurnTimerState.START;
        if (EndTurnButton.Get() != null)
        {
            EndTurnButton.Get().NotifyOfTurnTimerStart();
        }
        if (GameState.Get() != null)
        {
            GameState.Get().GetCurrentPlayer().GetHeroCard().PlayEmote(EmoteType.TIMER);
            this.m_currentTimerBelongsToLocalPlayer = GameState.Get().IsLocalPlayerTurn();
        }
    }

    private void ChangeState_Timeout()
    {
        this.m_state = TurnTimerState.TIMEOUT;
        this.m_countdownEndTimestamp = 0f;
        if (EndTurnButton.Get() != null)
        {
            EndTurnButton.Get().NotifyOfTurnTimerEnded(this.m_currentTimerBelongsToLocalPlayer);
        }
        this.StopCountdownAnims();
        this.UpdateCountdownAnims(0f);
    }

    private void ChangeStateImpl(TurnTimerState state)
    {
        if (state == TurnTimerState.START)
        {
            this.ChangeState_Start();
        }
        else if (state == TurnTimerState.COUNTDOWN)
        {
            this.ChangeState_Countdown();
        }
        else if (state == TurnTimerState.TIMEOUT)
        {
            this.ChangeState_Timeout();
        }
        else if (state == TurnTimerState.KILL)
        {
            this.ChangeState_Kill();
        }
    }

    private float ComputeCountdownProgress(float countdownRemainingSec)
    {
        if (countdownRemainingSec <= float.Epsilon)
        {
            return 0f;
        }
        return (countdownRemainingSec / this.m_countdownTimeoutSec);
    }

    private float ComputeCountdownRemainingSec()
    {
        float num = this.m_countdownEndTimestamp - UnityEngine.Time.realtimeSinceStartup;
        if (num < 0f)
        {
            return 0f;
        }
        return num;
    }

    private string GenerateMatValAnimName()
    {
        return string.Format("FuseMatVal{0}", this.m_currentMatValAnimId);
    }

    private string GenerateMoveAnimName()
    {
        return string.Format("SparksMove{0}", this.m_currentMoveAnimId);
    }

    public static TurnTimer Get()
    {
        return s_instance;
    }

    public bool HasCountdownTimeout()
    {
        return (this.m_countdownTimeoutSec > float.Epsilon);
    }

    public void OnEndTurnRequested()
    {
        if (this.HasCountdownTimeout())
        {
            this.ChangeState(TurnTimerState.KILL);
        }
    }

    private void OnSpellStateStarted(Spell spell, SpellStateType prevStateType, object userData)
    {
        SpellStateType activeState = spell.GetActiveState();
        TurnTimerState state = this.TranslateSpellStateToTimerState(activeState);
        this.ChangeStateImpl(state);
    }

    public void OnTurnChanged()
    {
        if ((this.m_state == TurnTimerState.COUNTDOWN) || (this.m_state == TurnTimerState.START))
        {
            this.ChangeState(TurnTimerState.KILL);
        }
        this.UpdateCountdownTimeout();
    }

    public void OnTurnStartManagerFinished()
    {
        if (this.HasCountdownTimeout())
        {
            if (this.m_waitingForTurnStartManagerFinish)
            {
                this.ChangeState(TurnTimerState.START);
            }
            this.m_waitingForTurnStartManagerFinish = false;
        }
    }

    public void OnTurnTimedOut()
    {
        if (this.HasCountdownTimeout())
        {
            this.ChangeState(TurnTimerState.TIMEOUT);
        }
    }

    private void OnTurnTimerUpdate(int turn, float secondsRemaining, float endTimestamp, object userData)
    {
        this.m_countdownEndTimestamp = endTimestamp;
        if (secondsRemaining <= float.Epsilon)
        {
            this.OnTurnTimedOut();
        }
        else if (this.m_state == TurnTimerState.COUNTDOWN)
        {
            this.RestartCountdownAnims(secondsRemaining);
        }
        else if (GameState.Get().IsTurnStartManagerActive())
        {
            this.m_waitingForTurnStartManagerFinish = true;
        }
        else
        {
            this.ChangeState(TurnTimerState.START);
        }
    }

    private void OnUpdateFuseMatVal(float val)
    {
        this.m_FuseWickObject.renderer.material.SetFloat(this.m_FuseMatValName, val);
        this.m_FuseShadowObject.renderer.material.SetFloat(this.m_FuseMatValName, val);
    }

    private void RestartCountdownAnims(float countdownRemainingSec)
    {
        this.StopCountdownAnims();
        float startingMatVal = this.UpdateCountdownAnims(countdownRemainingSec);
        this.StartCountdownAnims(startingMatVal, countdownRemainingSec);
    }

    private bool ShouldUpdateCountdownRemaining()
    {
        return (this.m_state == TurnTimerState.COUNTDOWN);
    }

    private void StartCountdownAnims(float startingMatVal, float countdownRemainingSec)
    {
        this.m_currentMoveAnimId++;
        this.m_currentMatValAnimId++;
        object[] args = new object[] { "name", this.GenerateMoveAnimName(), "time", countdownRemainingSec, "position", this.m_SparksFinishBone.position, "ignoretimescale", true, "easetype", iTween.EaseType.linear };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(this.m_SparksObject, hashtable);
        object[] objArray2 = new object[] { "name", this.GenerateMatValAnimName(), "time", countdownRemainingSec, "from", startingMatVal, "to", this.m_FuseMatValFinish, "ignoretimescale", true, "easetype", iTween.EaseType.linear, "onupdate", "OnUpdateFuseMatVal", "onupdatetarget", base.gameObject };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.ValueTo(this.m_FuseWickObject, hashtable2);
    }

    private void StopCountdownAnims()
    {
        iTween.StopByName(this.m_SparksObject, this.GenerateMoveAnimName());
        iTween.StopByName(this.m_FuseWickObject, this.GenerateMatValAnimName());
    }

    private TurnTimerState TranslateSpellStateToTimerState(SpellStateType spellState)
    {
        if (spellState == SpellStateType.BIRTH)
        {
            return TurnTimerState.START;
        }
        if (spellState == SpellStateType.IDLE)
        {
            return TurnTimerState.COUNTDOWN;
        }
        if (spellState == SpellStateType.DEATH)
        {
            return TurnTimerState.TIMEOUT;
        }
        if (spellState == SpellStateType.CANCEL)
        {
            return TurnTimerState.KILL;
        }
        return TurnTimerState.NONE;
    }

    private SpellStateType TranslateTimerStateToSpellState(TurnTimerState timerState)
    {
        if (timerState == TurnTimerState.START)
        {
            return SpellStateType.BIRTH;
        }
        if (timerState == TurnTimerState.COUNTDOWN)
        {
            return SpellStateType.IDLE;
        }
        if (timerState == TurnTimerState.TIMEOUT)
        {
            return SpellStateType.DEATH;
        }
        if (timerState == TurnTimerState.KILL)
        {
            return SpellStateType.CANCEL;
        }
        return SpellStateType.NONE;
    }

    private float UpdateCountdownAnims(float countdownRemainingSec)
    {
        float t = this.ComputeCountdownProgress(countdownRemainingSec);
        this.m_SparksObject.transform.position = Vector3.Lerp(this.m_SparksFinishBone.position, this.m_SparksStartBone.position, t);
        float num2 = Mathf.Lerp(this.m_FuseMatValFinish, this.m_FuseMatValStart, t);
        this.m_FuseWickObject.renderer.material.SetFloat(this.m_FuseMatValName, num2);
        this.m_FuseShadowObject.renderer.material.SetFloat(this.m_FuseMatValName, num2);
        return num2;
    }

    private void UpdateCountdownTimeout()
    {
        this.m_countdownTimeoutSec = 0f;
        if (GameState.Get() != null)
        {
            Player currentPlayer = GameState.Get().GetCurrentPlayer();
            if ((currentPlayer != null) && currentPlayer.HasTag(GAME_TAG.TIMEOUT))
            {
                int tag = currentPlayer.GetTag(GAME_TAG.TIMEOUT);
                this.m_countdownTimeoutSec = tag;
            }
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    public TextMesh bottomTextMesh;
    private bool depressed;
    private bool inputBlocked;
    private ActorStateMgr m_actorStateMgr;
    private bool m_mousedOver;
    private bool playedNMPsoundThisTurn;
    private static EndTurnButton s_instance;
    public TextMesh topTextMesh;

    private void Awake()
    {
        s_instance = this;
        this.m_actorStateMgr = base.transform.FindChild("ActorStateMgr").gameObject.GetComponent<ActorStateMgr>();
        if (GameState.Get() != null)
        {
            GameState.Get().RegisterOptionsReceivedListener(new GameState.OptionsReceivedCallback(this.OnOptionsReceived));
        }
        this.topTextMesh.text = GameStrings.Get("GAMEPLAY_END_TURN");
        this.bottomTextMesh.text = string.Empty;
        base.collider.enabled = false;
    }

    private bool CheckOptionsPacketSizeAndChangeButtonState()
    {
        Network.Options optionsPacket = GameState.Get().GetOptionsPacket();
        if (((optionsPacket != null) && (optionsPacket.List != null)) && (optionsPacket.List.Count == 1))
        {
            this.SetStateToNoMorePlays();
            return true;
        }
        return false;
    }

    public static EndTurnButton Get()
    {
        return s_instance;
    }

    public GameObject GetButtonContainer()
    {
        return base.transform.FindChild("ButtonContainer").gameObject;
    }

    public void HandleMouseOut()
    {
        this.m_mousedOver = false;
        if (!this.inputBlocked)
        {
            if (this.depressed)
            {
                this.PlayButtonUpAnimation();
            }
            this.UpdateState(false);
        }
    }

    public void HandleMouseOver()
    {
        this.m_mousedOver = true;
        if (!this.inputBlocked)
        {
            this.UpdateState(true);
        }
    }

    public bool IsInNMPState()
    {
        return ((this.m_actorStateMgr.GetActiveStateType() == ActorStateType.ENDTURN_NO_MORE_PLAYS) || (this.m_actorStateMgr.GetActiveStateType() == ActorStateType.ENDTURN_NO_MORE_PLAYS_MOUSE_OVER));
    }

    public bool IsInWaitingState()
    {
        ActorStateType activeStateType = this.m_actorStateMgr.GetActiveStateType();
        switch (activeStateType)
        {
            case ActorStateType.ENDTURN_WAITING:
                return true;

            case ActorStateType.ENDTURN_NMP_2_WAITING:
                return true;

            case ActorStateType.ENDTURN_WAITING_TIMER:
                return true;
        }
        return ((activeStateType == ActorStateType.ENDTURN_YOUR_TURN_TIMER) && !GameState.Get().IsLocalPlayerTurn());
    }

    public void NotifyOfMulliganEnd()
    {
        this.bottomTextMesh.text = GameStrings.Get("GAMEPLAY_ENEMY_TURN");
        base.collider.enabled = true;
    }

    public void NotifyOfTurnChange()
    {
        this.playedNMPsoundThisTurn = false;
    }

    public void NotifyOfTurnTimerEnded(bool localPlayerTurnTimer)
    {
        if (localPlayerTurnTimer)
        {
            this.SetButtonState(ActorStateType.ENDTURN_WAITING_TIMER);
            this.inputBlocked = true;
            base.StartCoroutine(this.WaitUntilAnimationIsCompleteAndThenUnblockInput());
        }
    }

    public void NotifyOfTurnTimerStart()
    {
        if (!this.inputBlocked && !this.m_mousedOver)
        {
            this.SetButtonState(ActorStateType.ENDTURN_YOUR_TURN_TIMER);
        }
    }

    private void OnOptionsReceived(object userData)
    {
        this.CheckOptionsPacketSizeAndChangeButtonState();
    }

    public void PlayButtonUpAnimation()
    {
        if ((!this.inputBlocked && !this.IsInWaitingState()) && this.depressed)
        {
            this.depressed = false;
            this.GetButtonContainer().animation.Play("ENDTURN_PRESSED_UP");
            SoundManager.Get().LoadAndPlay("FX_EndTurn_Up");
        }
    }

    [DebuggerHidden]
    private IEnumerator PlayEndTurnSound()
    {
        return new <PlayEndTurnSound>c__Iterator37 { <>f__this = this };
    }

    public void PlayPushDownAnimation()
    {
        if ((!this.inputBlocked && !this.IsInWaitingState()) && !this.depressed)
        {
            this.depressed = true;
            this.GetButtonContainer().animation.Play("ENDTURN_PRESSED_DOWN");
            SoundManager.Get().LoadAndPlay("FX_EndTurn_Down");
        }
    }

    private void SetButtonState(ActorStateType stateType)
    {
        if (this.m_actorStateMgr == null)
        {
            UnityEngine.Debug.Log("End Turn Button Actor State Manager is missing!");
        }
        else if ((this.m_actorStateMgr.GetActiveStateType() != stateType) && !this.inputBlocked)
        {
            this.m_actorStateMgr.ChangeState(stateType);
            if (stateType == ActorStateType.ENDTURN_YOUR_TURN)
            {
                this.inputBlocked = true;
                base.StartCoroutine(this.WaitUntilAnimationIsCompleteAndThenUnblockInput());
            }
        }
    }

    public void SetStateToNoMorePlays()
    {
        if (this.m_actorStateMgr != null)
        {
            switch (this.m_actorStateMgr.GetActiveStateType())
            {
                case ActorStateType.ENDTURN_NMP_MOUSE_OVER_2_NMP:
                case ActorStateType.ENDTURN_NO_MORE_PLAYS:
                    return;

                case ActorStateType.ENDTURN_NO_MORE_PLAYS_MOUSE_OVER:
                    this.SetButtonState(ActorStateType.ENDTURN_NMP_MOUSE_OVER_2_NMP);
                    break;

                case ActorStateType.ENDTURN_WAITING:
                case ActorStateType.ENDTURN_WAITING_TIMER:
                    this.SetButtonState(ActorStateType.ENDTURN_WAITING_2_NMP);
                    break;

                default:
                    this.SetButtonState(ActorStateType.ENDTURN_NO_MORE_PLAYS);
                    break;
            }
            if (!this.playedNMPsoundThisTurn)
            {
                this.playedNMPsoundThisTurn = true;
                base.StartCoroutine(this.PlayEndTurnSound());
            }
        }
    }

    public void SetStateToWaiting()
    {
        if ((this.m_actorStateMgr != null) && !this.IsInWaitingState())
        {
            switch (this.m_actorStateMgr.GetActiveStateType())
            {
                case ActorStateType.ENDTURN_NO_MORE_PLAYS_MOUSE_OVER:
                case ActorStateType.ENDTURN_NO_MORE_PLAYS:
                    this.SetButtonState(ActorStateType.ENDTURN_NMP_2_WAITING);
                    break;

                default:
                    this.SetButtonState(ActorStateType.ENDTURN_WAITING);
                    break;
            }
            PegCursor.Get().SetMode(PegCursor.Mode.WAITING);
        }
    }

    public void SetStateToYourTurn()
    {
        if (((this.m_actorStateMgr != null) && ((this.m_actorStateMgr.GetActiveStateType() != ActorStateType.ENDTURN_YOUR_TURN) && (this.m_actorStateMgr.GetActiveStateType() != ActorStateType.ENDTURN_YT_MOUSE_OVER_2_YT))) && !GameState.Get().IsTurnStartManagerActive())
        {
            if (this.m_actorStateMgr.GetActiveStateType() == ActorStateType.ENDTURN_YOUR_TURN_MOUSE_OVER)
            {
                this.SetButtonState(ActorStateType.ENDTURN_YT_MOUSE_OVER_2_YT);
            }
            else
            {
                this.SetButtonState(ActorStateType.ENDTURN_YOUR_TURN);
            }
            PegCursor.Get().SetMode(PegCursor.Mode.STOPWAITING);
        }
    }

    private void Start()
    {
        base.StartCoroutine(this.WaitAFrameAndThenChangeState());
    }

    private void UpdateState(bool mousedOver)
    {
        if (!GameState.Get().IsLocalPlayerTurn())
        {
            this.SetStateToWaiting();
        }
        else if (!this.IsInWaitingState())
        {
            if (this.CheckOptionsPacketSizeAndChangeButtonState())
            {
                if (mousedOver)
                {
                    this.SetButtonState(ActorStateType.ENDTURN_NO_MORE_PLAYS_MOUSE_OVER);
                }
            }
            else if (mousedOver)
            {
                this.SetButtonState(ActorStateType.ENDTURN_YOUR_TURN_MOUSE_OVER);
            }
            else
            {
                this.SetStateToYourTurn();
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitAFrameAndThenChangeState()
    {
        return new <WaitAFrameAndThenChangeState>c__Iterator35 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitUntilAnimationIsCompleteAndThenUnblockInput()
    {
        return new <WaitUntilAnimationIsCompleteAndThenUnblockInput>c__Iterator36 { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <PlayEndTurnSound>c__Iterator37 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal EndTurnButton <>f__this;

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
                    if (this.<>f__this.IsInNMPState())
                    {
                        SoundManager.Get().LoadAndPlay("PeasantBuildingComplete1", this.<>f__this.gameObject);
                    }
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
    private sealed class <WaitAFrameAndThenChangeState>c__Iterator35 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal EndTurnButton <>f__this;

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
                    this.<>f__this.m_actorStateMgr.ForceActiveStateTypeWithoutChangingVisual(ActorStateType.ENDTURN_WAITING);
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
    private sealed class <WaitUntilAnimationIsCompleteAndThenUnblockInput>c__Iterator36 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal EndTurnButton <>f__this;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_actorStateMgr.GetMaximumAnimationTimeOfActiveStates());
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.inputBlocked = false;
                    this.<>f__this.CheckOptionsPacketSizeAndChangeButtonState();
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


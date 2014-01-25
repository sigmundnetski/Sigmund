using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class ActorAttackSpell : Spell
{
    private bool m_waitingToAct = true;

    protected override void OnAction(SpellStateType prevStateType)
    {
        base.StartCoroutine(this.WaitThenDoAction(prevStateType));
    }

    protected override void OnBirth(SpellStateType prevStateType)
    {
        this.m_waitingToAct = true;
        base.OnBirth(prevStateType);
    }

    protected override void Start()
    {
        base.Start();
    }

    private void StopWaitingToAct()
    {
        this.m_waitingToAct = false;
    }

    [DebuggerHidden]
    protected IEnumerator WaitThenDoAction(SpellStateType prevStateType)
    {
        return new <WaitThenDoAction>c__IteratorAA { prevStateType = prevStateType, <$>prevStateType = prevStateType, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenDoAction>c__IteratorAA : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SpellStateType <$>prevStateType;
        internal ActorAttackSpell <>f__this;
        internal SpellStateType prevStateType;

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
                    if (this.<>f__this.m_waitingToAct)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<>f__this.OnAction(this.prevStateType);
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


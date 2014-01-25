namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Tells the game that a Spell is finished, allowing the game to progress.")]
    public class SpellFinishAction : SpellAction
    {
        public FsmFloat m_Delay = 0f;
        public FsmOwnerDefault m_SpellObject;

        [DebuggerHidden]
        private IEnumerator DelaySpellFinished()
        {
            return new <DelaySpellFinished>c__IteratorBF { <>f__this = this };
        }

        protected override GameObject GetSpellOwner()
        {
            return base.Fsm.GetOwnerDefaultTarget(this.m_SpellObject);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (base.m_spell == null)
            {
                UnityEngine.Debug.LogError(string.Format("{0}.OnEnter() - FAILED to find Spell component on Owner \"{1}\"", this, base.Owner));
            }
            else
            {
                if (this.m_Delay.Value > 0f)
                {
                    base.m_spell.StartCoroutine(this.DelaySpellFinished());
                }
                else
                {
                    base.m_spell.OnSpellFinished();
                }
                base.Finish();
            }
        }

        [CompilerGenerated]
        private sealed class <DelaySpellFinished>c__IteratorBF : IDisposable, IEnumerator, IEnumerator<object>
        {
            internal object $current;
            internal int $PC;
            internal SpellFinishAction <>f__this;

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
                        this.$current = new WaitForSeconds(this.<>f__this.m_Delay.Value);
                        this.$PC = 1;
                        return true;

                    case 1:
                        this.<>f__this.m_spell.OnSpellFinished();
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
}


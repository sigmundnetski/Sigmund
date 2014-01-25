namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("INTERNAL USE ONLY. Do not put this on your FSMs.")]
    public abstract class SpellAction : FsmStateAction
    {
        protected Spell m_spell;

        protected SpellAction()
        {
        }

        public Spell GetSpell()
        {
            if (this.m_spell == null)
            {
                GameObject spellOwner = this.GetSpellOwner();
                if (spellOwner != null)
                {
                    this.m_spell = SceneUtils.FindComponentInThisOrParents<Spell>(spellOwner);
                }
            }
            return this.m_spell;
        }

        protected abstract GameObject GetSpellOwner();
        public override void OnEnter()
        {
            this.GetSpell();
            if (this.m_spell == null)
            {
                Debug.LogError(string.Format("{0}.OnEnter() - FAILED to find Spell component on Owner \"{1}\"", this, base.Owner));
            }
        }

        public override void Reset()
        {
        }
    }
}


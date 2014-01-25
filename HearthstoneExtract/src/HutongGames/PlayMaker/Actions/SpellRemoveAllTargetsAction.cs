namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Removes all targets from a Spell.")]
    public class SpellRemoveAllTargetsAction : SpellAction
    {
        public FsmOwnerDefault m_SpellObject;

        protected override GameObject GetSpellOwner()
        {
            return base.Fsm.GetOwnerDefaultTarget(this.m_SpellObject);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (base.m_spell != null)
            {
                base.m_spell.RemoveAllTargets();
                base.Finish();
            }
        }
    }
}


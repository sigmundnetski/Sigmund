namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Sets the source for a Spell.")]
    public class SpellSetSourceAction : SpellAction
    {
        public FsmGameObject m_SourceObject;
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
                GameObject go = this.m_SourceObject.Value;
                base.m_spell.SetSource(go);
                base.Finish();
            }
        }
    }
}


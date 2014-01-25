namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("[DEBUG] Setup a Spell to go from a source to a target."), ActionCategory("Pegasus Debug")]
    public class SpellSourceTargetDebugAction : SpellAction
    {
        public FsmGameObject m_SourceObject;
        public FsmGameObject m_SpellObject;
        public FsmGameObject m_TargetObject;

        protected override GameObject GetSpellOwner()
        {
            return this.m_SpellObject.Value;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (base.m_spell != null)
            {
                base.m_spell.RemoveAllTargets();
                base.m_spell.SetSource(this.m_SourceObject.Value);
                if (this.m_TargetObject.Value != null)
                {
                    base.m_spell.AddTarget(this.m_TargetObject.Value);
                }
                base.Finish();
            }
        }
    }
}


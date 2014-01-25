namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Adds a target to a Spell.")]
    public class SpellAddTargetAction : SpellAction
    {
        public FsmBool m_AllowDuplicates;
        public FsmOwnerDefault m_SpellObject;
        public FsmGameObject m_TargetObject;

        protected override GameObject GetSpellOwner()
        {
            return base.Fsm.GetOwnerDefaultTarget(this.m_SpellObject);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (base.m_spell != null)
            {
                GameObject go = this.m_TargetObject.Value;
                if (go != null)
                {
                    if (!base.m_spell.IsTarget(go) || this.m_AllowDuplicates.Value)
                    {
                        base.m_spell.AddTarget(go);
                    }
                    base.Finish();
                }
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.m_AllowDuplicates = 0;
        }
    }
}


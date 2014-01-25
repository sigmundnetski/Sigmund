namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Removes a target from a Spell.")]
    public class SpellRemoveTargetAction : SpellAction
    {
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
                    base.m_spell.RemoveTarget(go);
                    base.Finish();
                }
            }
        }
    }
}


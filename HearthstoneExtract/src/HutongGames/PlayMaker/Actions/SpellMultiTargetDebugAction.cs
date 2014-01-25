namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus Debug"), Tooltip("[DEBUG] Setup a Spell to affect multiple targets.")]
    public class SpellMultiTargetDebugAction : SpellAction
    {
        public FsmGameObject m_SourceObject;
        public FsmGameObject m_SpellObject;
        public FsmGameObject[] m_TargetObjects;

        protected override GameObject GetSpellOwner()
        {
            return this.m_SpellObject.Value;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (base.m_spell != null)
            {
                base.m_spell.SetSource(this.m_SourceObject.Value);
                base.m_spell.RemoveAllTargets();
                for (int i = 0; i < this.m_TargetObjects.Length; i++)
                {
                    FsmGameObject obj2 = this.m_TargetObjects[i];
                    if ((obj2.Value != null) && !base.m_spell.IsTarget(obj2.Value))
                    {
                        base.m_spell.AddTarget(obj2.Value);
                    }
                }
                base.Finish();
            }
        }
    }
}


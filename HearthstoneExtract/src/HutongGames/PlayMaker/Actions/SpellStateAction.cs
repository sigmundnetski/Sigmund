namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Handles communication between a Spell and the SpellStates in an FSM."), ActionCategory("Pegasus")]
    public class SpellStateAction : SpellAction
    {
        public FsmOwnerDefault m_SpellObject;
        private SpellStateType m_spellStateType;
        private bool m_stateDirty = true;
        private bool m_stateInvalid;

        private void DiscoverSpellStateType()
        {
            if (this.m_stateDirty)
            {
                string name = base.State.Name;
                foreach (FsmTransition transition in base.Fsm.GlobalTransitions)
                {
                    if (name.Equals(transition.ToState))
                    {
                        this.m_spellStateType = EnumUtils.GetEnum<SpellStateType>(transition.EventName);
                        this.m_stateDirty = false;
                        return;
                    }
                }
                this.m_stateInvalid = true;
            }
        }

        protected override GameObject GetSpellOwner()
        {
            return base.Fsm.GetOwnerDefaultTarget(this.m_SpellObject);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (base.m_spell != null)
            {
                this.DiscoverSpellStateType();
                if (!this.m_stateInvalid)
                {
                    base.m_spell.OnFsmStateStarted(base.State, this.m_spellStateType);
                    base.Finish();
                }
            }
        }
    }
}


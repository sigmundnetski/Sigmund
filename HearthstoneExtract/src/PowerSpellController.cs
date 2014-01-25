using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerSpellController : SpellController
{
    private bool ActivateBattlecrySpell(Entity entity, Card card)
    {
        if (!entity.HasBattlecry())
        {
            return false;
        }
        Spell actorBattlecrySpell = this.GetActorBattlecrySpell(card);
        if (actorBattlecrySpell == null)
        {
            return false;
        }
        base.StartCoroutine(this.WaitThenActivateBattlecrySpell(entity, card, actorBattlecrySpell));
        return true;
    }

    private bool ActivatePowerSpell(Entity entity, Card card)
    {
        Spell powerSpell = this.DeterminePowerSpell(entity, card);
        if ((powerSpell == null) || !powerSpell.HasUsableState(SpellStateType.ACTION))
        {
            return false;
        }
        if ((powerSpell.GetPowerTaskList() != base.m_taskList) && !this.InitPowerSpell(card, powerSpell))
        {
            return false;
        }
        powerSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnPowerSpellFinished));
        powerSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnPowerSpellStateFinished));
        powerSpell.ActivateState(SpellStateType.ACTION);
        return true;
    }

    protected override bool AddPowerSourceAndTargets(PowerTaskList taskList)
    {
        Entity sourceEntity = taskList.GetSourceEntity();
        if (sourceEntity == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("{0}.AddPowerSourceAndTargets() - FAILED to get source entity from task list {1}", this, taskList.GetId()));
            return false;
        }
        Card card = sourceEntity.GetCard();
        if (card == null)
        {
            return false;
        }
        Spell powerSpell = this.DeterminePowerSpell(sourceEntity, card);
        if (sourceEntity.IsMinion())
        {
            if (powerSpell != null)
            {
                if (!this.InitPowerSpell(card, powerSpell))
                {
                    return false;
                }
            }
            else if (this.GetActorBattlecrySpell(card) == null)
            {
                return false;
            }
        }
        else if ((powerSpell != null) && !this.InitPowerSpell(card, powerSpell))
        {
            return false;
        }
        base.SetSource(card);
        return true;
    }

    private Spell DeterminePowerSpell(Entity entity, Card card)
    {
        int index = base.m_taskList.GetSourceAction().Index;
        if (index >= 0)
        {
            return card.GetSubOptionSpell(index);
        }
        if (!entity.IsMinion() && !entity.IsWeapon())
        {
            return card.GetPlaySpell();
        }
        return card.GetBattlecrySpell();
    }

    private Spell GetActorBattlecrySpell(Card card)
    {
        Spell actorSpell = card.GetActorSpell(SpellType.BATTLECRY);
        if (actorSpell == null)
        {
            return null;
        }
        if (!actorSpell.HasUsableState(SpellStateType.ACTION))
        {
            return null;
        }
        return actorSpell;
    }

    private bool InitPowerSpell(Card card, Spell powerSpell)
    {
        if (!powerSpell.AttachPowerTaskList(base.m_taskList))
        {
            string message = string.Format("{0}.AddTargetsToPowerSpell() - FAILED to attach task list to spell {1} for Card {2}", this, powerSpell, card);
            Log.Power.Print(message);
            return false;
        }
        return true;
    }

    private void OnPowerSpellFinished(Spell powerSpell, object userData)
    {
        base.OnFinishedTaskList();
    }

    private void OnPowerSpellStateFinished(Spell powerSpell, SpellStateType prevStateType, object userData)
    {
        if (powerSpell.GetActiveState() == SpellStateType.NONE)
        {
            base.OnFinished();
        }
    }

    protected override void OnProcessTaskList()
    {
        Card source = base.GetSource();
        Entity entity = source.GetEntity();
        if (!this.ActivateBattlecrySpell(entity, source) && !this.ActivatePowerSpell(entity, source))
        {
            base.OnProcessTaskList();
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitThenActivateBattlecrySpell(Entity entity, Card card, Spell battlecrySpell)
    {
        return new <WaitThenActivateBattlecrySpell>c__IteratorB1 { battlecrySpell = battlecrySpell, entity = entity, card = card, <$>battlecrySpell = battlecrySpell, <$>entity = entity, <$>card = card, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenActivateBattlecrySpell>c__IteratorB1 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Spell <$>battlecrySpell;
        internal Card <$>card;
        internal Entity <$>entity;
        internal PowerSpellController <>f__this;
        internal Spell battlecrySpell;
        internal Card card;
        internal Entity entity;

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
                    this.$current = new WaitForSeconds(0.2f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.battlecrySpell.ActivateState(SpellStateType.ACTION);
                    if (!this.<>f__this.ActivatePowerSpell(this.entity, this.card))
                    {
                        this.<>f__this.OnProcessTaskList();
                    }
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


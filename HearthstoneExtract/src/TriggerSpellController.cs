using System;
using UnityEngine;

public class TriggerSpellController : SpellController
{
    private bool ActivateActorTriggerSpell(Entity sourceEntity, Card sourceCard)
    {
        Spell actorTriggerSpell = this.GetActorTriggerSpell(sourceEntity, sourceCard);
        if (actorTriggerSpell == null)
        {
            return false;
        }
        actorTriggerSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnActorTriggerSpellStateFinished));
        actorTriggerSpell.ActivateState(SpellStateType.ACTION);
        return true;
    }

    private bool ActivateInitialSpell()
    {
        Card source = base.GetSource();
        Entity sourceEntity = source.GetEntity();
        return (this.ActivateActorTriggerSpell(sourceEntity, source) || this.ActivateTriggerSpell(source));
    }

    private bool ActivateTriggerSpell(Card sourceCard)
    {
        Spell triggerSpell = this.GetTriggerSpell(sourceCard);
        if (triggerSpell == null)
        {
            return false;
        }
        if ((triggerSpell.GetPowerTaskList() != base.m_taskList) && !this.InitTriggerSpell(sourceCard, triggerSpell))
        {
            return false;
        }
        triggerSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnTriggerSpellFinished));
        triggerSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnTriggerSpellStateFinished));
        triggerSpell.ActivateState(SpellStateType.ACTION);
        if (triggerSpell.GetActiveState() == SpellStateType.NONE)
        {
            return false;
        }
        return true;
    }

    protected override bool AddPowerSourceAndTargets(PowerTaskList taskList)
    {
        Entity sourceEntity = taskList.GetSourceEntity();
        if (sourceEntity == null)
        {
            Debug.LogWarning(string.Format("{0}.AddPowerSourceAndTargets() - FAILED to get source entity from task list {1}", this, taskList.GetId()));
            return false;
        }
        Card card = sourceEntity.GetCard();
        if (card == null)
        {
            return false;
        }
        Spell triggerSpell = this.GetTriggerSpell(card);
        if (((triggerSpell == null) || !this.InitTriggerSpell(card, triggerSpell)) && (this.GetActorTriggerSpell(sourceEntity, card) == null))
        {
            return false;
        }
        base.SetSource(card);
        return true;
    }

    private Spell GetActorTriggerSpell(Entity sourceEntity, Card sourceCard)
    {
        if (!sourceEntity.HasTriggerVisual())
        {
            return null;
        }
        Spell actorSpell = sourceCard.GetActorSpell(SpellType.TRIGGER);
        if (actorSpell == null)
        {
            return null;
        }
        return actorSpell;
    }

    private Spell GetTriggerSpell(Card card)
    {
        Network.HistActionStart sourceAction = base.m_taskList.GetSourceAction();
        return card.GetTriggerSpell(sourceAction.Index);
    }

    private bool InitTriggerSpell(Card sourceCard, Spell spell)
    {
        if (!spell.AttachPowerTaskList(base.m_taskList))
        {
            Log.Power.Print(string.Format("{0}.InitTriggerSpell() - FAILED to add targets to spell for {1}", this, sourceCard));
            return false;
        }
        return true;
    }

    private void OnActorTriggerSpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (prevStateType == SpellStateType.ACTION)
        {
            spell.RemoveStateFinishedCallback(new Spell.StateFinishedCallback(this.OnActorTriggerSpellStateFinished));
            if (!this.ActivateTriggerSpell(base.GetSource()))
            {
                base.OnProcessTaskList();
            }
        }
    }

    protected override void OnProcessTaskList()
    {
        if (!this.ActivateInitialSpell())
        {
            base.OnProcessTaskList();
        }
        else if (GameState.Get().IsTurnStartManagerActive())
        {
            TurnStartManager.Get().NotifyOfTriggerVisual();
        }
    }

    private void OnTriggerSpellFinished(Spell spell, object userData)
    {
        base.OnFinishedTaskList();
    }

    private void OnTriggerSpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            base.OnFinished();
        }
    }
}


using System;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpellController : SpellController
{
    private void AddDeadEntitiesToTargetList(PowerTaskList taskList)
    {
        List<PowerTask> list = base.m_taskList.GetTaskList();
        for (int i = 0; i < list.Count; i++)
        {
            Network.PowerHistory power = list[i].GetPower();
            if (power.Type == Network.PowerHistory.PowType.TAG_CHANGE)
            {
                Network.HistTagChange tagChange = power as Network.HistTagChange;
                if (PowerTaskList.IsDeathTagChange(tagChange))
                {
                    Entity entity = GameState.Get().GetEntity(tagChange.Entity);
                    if (entity == null)
                    {
                        Debug.LogWarning(string.Format("{0}.AddPowerSourceAndTargets() - WARNING entity with id {1} does not exist", this, tagChange.Entity));
                    }
                    else if (this.ShouldKeepEntity(entity))
                    {
                        Card card = entity.GetCard();
                        base.AddTarget(card);
                    }
                }
            }
        }
    }

    protected override bool AddPowerSourceAndTargets(PowerTaskList taskList)
    {
        this.AddDeadEntitiesToTargetList(taskList);
        if (base.m_targets.Count == 0)
        {
            return false;
        }
        if (base.m_targets.Count == 2)
        {
            Card item = base.m_targets[0];
            Card card2 = base.m_targets[1];
            Entity attacker = item.GetEntity();
            Entity entity = card2.GetEntity();
            if (this.WereEntitiesInCombat(attacker, entity))
            {
                base.m_targets.Remove(item);
            }
            else if (this.WereEntitiesInCombat(entity, attacker))
            {
                base.m_targets.Remove(card2);
            }
        }
        return true;
    }

    protected override void OnProcessTaskList()
    {
        Spell deathSpell = ((base.m_targets.Count != 1) ? base.m_targets[UnityEngine.Random.Range(0, base.m_targets.Count - 1)] : base.m_targets[0]).GetDeathSpell();
        if (deathSpell != null)
        {
            deathSpell.Deactivate();
            deathSpell.Activate();
        }
        base.OnProcessTaskList();
    }

    private bool ShouldKeepEntity(Entity entity)
    {
        return entity.IsCharacter();
    }

    private bool WereEntitiesInCombat(Entity attacker, Entity defender)
    {
        if (!attacker.HasTag(GAME_TAG.ATTACKING))
        {
            return false;
        }
        if (!defender.HasTag(GAME_TAG.DEFENDING))
        {
            return false;
        }
        if (defender.GetTag(GAME_TAG.LAST_AFFECTED_BY) != attacker.GetEntityId())
        {
            return false;
        }
        return true;
    }
}


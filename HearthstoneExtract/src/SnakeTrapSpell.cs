using System;
using UnityEngine;

public class SnakeTrapSpell : SuperSpell
{
    protected override Card GetTargetCardFromPowerTask(PowerTask task)
    {
        Network.PowerHistory power = task.GetPower();
        if (power.Type != Network.PowerHistory.PowType.FULL_ENTITY)
        {
            return null;
        }
        Network.HistFullEntity entity = power as Network.HistFullEntity;
        Network.Entity entity2 = entity.Entity;
        Entity entity3 = GameState.Get().GetEntity(entity2.ID);
        if (entity3 == null)
        {
            Debug.LogWarning(string.Format("{0}.GetTargetCardFromPowerTask() - WARNING trying to target entity with id {1} but there is no entity with that id", this, entity2.ID));
            return null;
        }
        return entity3.GetCard();
    }
}


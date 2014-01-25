using System;
using UnityEngine;

public class SpellAreaEffect : Spell
{
    public Spell m_ImpactSpellPrefab;

    public override bool AddPowerTargets()
    {
        if (!base.CanAddPowerTargets())
        {
            return false;
        }
        if (!base.AddMultiplePowerTargets())
        {
            return false;
        }
        return (base.GetTargets().Count > 0);
    }

    protected override void OnDeath(SpellStateType prevStateType)
    {
        base.OnDeath(prevStateType);
        if (this.m_ImpactSpellPrefab != null)
        {
            for (int i = 0; i < base.m_targets.Count; i++)
            {
                this.SpawnImpactSpell(base.m_targets[i]);
            }
        }
    }

    private void OnImpactSpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            UnityEngine.Object.Destroy(spell.gameObject);
        }
    }

    private void SpawnImpactSpell(GameObject targetObject)
    {
        Spell component = ((GameObject) UnityEngine.Object.Instantiate(this.m_ImpactSpellPrefab.gameObject, targetObject.transform.position, Quaternion.identity)).GetComponent<Spell>();
        component.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnImpactSpellStateFinished));
        component.Activate();
    }
}


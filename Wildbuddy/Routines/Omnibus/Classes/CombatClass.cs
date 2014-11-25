using System;
using System.Linq;
using System.Threading.Tasks;

using Buddy.Wildstar.BotCommon;
using Buddy.Wildstar.Game;

using Omnibus.Helpers;

namespace Omnibus.Classes
{
	public abstract class CombatClass
	{
		private AbilityPriority _Combat;
		private AbilityPriority _Heal;
		private AbilityPriority _Pull;
		private float? _PullRange;
		private AbilityPriority _Rest;

		public float PullRange
		{
			get
			{
				// Note: Take the "lowest" range available
				return (_PullRange ?? (_PullRange = Math.Max(SpellManager.AvailableSpells.Min(spell => spell.TargetMaxRange) - 3f, 4f))).Value;
			}
		}

		public AbilityPriority Heal { get { return _Heal ?? (_Heal = CreateHeal()); } }

		public AbilityPriority Pull { get { return _Pull ?? (_Pull = CreatePull()); } }

		public AbilityPriority Rest { get { return _Rest ?? (_Rest = CreateRest()); } }

		public AbilityPriority Combat { get { return _Combat ?? (_Combat = CreateCombat()); } }

		public void Rebuild()
		{
			_Heal = null;
			_Pull = null;
			_Rest = null;
			_Combat = null;
		}

		public abstract AbilityPriority CreateHeal();
		public abstract AbilityPriority CreateCombat();
		public abstract AbilityPriority CreateRest();
        
		public virtual AbilityPriority CreatePull()
		{
			return CreateCombat();
		}

		public virtual async Task CombatTask()
		{
			if (InstanceManager.Target == null)
			{
				return;
			}

			//if (GameManager.LocalPlayer.IsMoving)
				//Navigator.Stop();

            Tuple<SpellManager.SpellInformation, CastAction> currentBestAbility = Combat.GetHighestPriorityTuple(InstanceManager.Target);


			if (currentBestAbility != null && currentBestAbility.Item1.CanCast) // sanity check on CanCast
			{

                // move within range of spell 
                if (InstanceManager.Target.Distance > currentBestAbility.Item1.TargetMaxRange && Omnibus.WindowSettings.EnableMovement)
                {
                    if (await CommonBehaviors.MoveWithin(InstanceManager.Target.Position, currentBestAbility.Item1.TargetMaxRange, true) == CommonBehaviors.BehaviorResult.CombatStop) // move unless combat stops
                        return; // stop combat
                }

				Omnibus.Logger.Debug(string.Format("[COMBAT] FaceCast [Name {0}, SpellBarIndex {1}]",
					currentBestAbility.Item1.Name,
					currentBestAbility.Item1.SpellBarIndex));
				// NOTE: this needs to change. Since abilities need different casting methods.
				// ChargeAndRelease requires at least N charges before firing it off
				// ChanneledArea or something needs to be cast -> cast again at the location [2+ frames]

				// TODO: Add a "continuous face" into SpellCastBeahviors.CastSimple
				if (Omnibus.WindowSettings.EnableMovement)
					InstanceManager.Target.Face();

				//await SpellCastBehaviors.CastSimple(currentBestAbility, () => InstanceManager.Target, true);
                await currentBestAbility.Item2(InstanceManager.Target); 
			}
		}

		public virtual async Task HealTask()
		{
			// This is never null......
			if (InstanceManager.HealTarget == null)
			{
				return;
			}

            Tuple<SpellManager.SpellInformation, CastAction> currentBestAbility = Heal.GetHighestPriorityTuple(InstanceManager.HealTarget);
			if (currentBestAbility != null && currentBestAbility.Item1.CanCast) // sanity check on CanCast
			{
				Omnibus.Logger.Debug(string.Format("[HEAL] FaceCast [Name {0}, SpellBarIndex {1}]",
                    currentBestAbility.Item1.Name,
					currentBestAbility.Item1.SpellBarIndex));
				// NOTE: this needs to change. Since abilities need different casting methods.
				// ChargeAndRelease requires at least N charges before firing it off
				// ChanneledArea or something needs to be cast -> cast again at the location [2+ frames]


				// TODO: Add a "continuous face" into SpellCastBeahviors.CastSimple
				if (Omnibus.WindowSettings.EnableMovement)
					InstanceManager.HealTarget.Face();

				//await SpellCastBehaviors.CastSimple(currentBestAbility, () => InstanceManager.HealTarget, true);
                await currentBestAbility.Item2(InstanceManager.Target); 
			}
		}

		protected bool IsSpellProcReady(string spellName)
		{
			var spell = SpellManager.GetSpell(spellName);
			if (spell != null)
				return spell.CanCast && spell.IsSpellReady;
			return false;
		}

		protected SpellManager.SpellInformation GetSpell(string spellName)
		{
			return SpellManager.GetSpell(spellName);
		}

		protected bool CanCast(string spellName)
		{
			SpellManager.SpellInformation spell = SpellManager.GetSpell(spellName);
			return spell != null && spell.CanCast;
		}
	}
}
using System.Linq;

using Buddy.Wildstar.Game;

using Omnibus.Helpers;
using Omnibus.Settings;

namespace Omnibus.Classes.Routines
{
	public class Engineer : CombatClass
	{
		public Engineer()
		{
			Omnibus.WindowSettings = new EngineerSettings();
		}

		private EngineerSettings Settings { get { return (Omnibus.WindowSettings as EngineerSettings); } }

		public override AbilityPriority CreateHeal()
		{
			return new AbilityPriority();
		}

		public override AbilityPriority CreateCombat()
		{
			var result = new AbilityPriority();

			//result.Add("Hyper Wave", r => r.ThreatListGuids.Contains(GameManager.LocalPlayer.Guid));
			//result.Add("Particle Ejector", r => r.ThreatListGuids.Contains(GameManager.LocalPlayer.Guid));

			result.Add("Shatter Impairment", r => GameManager.LocalPlayer.HasCleansableCC());

			// Interrupt
			result.Add("Obstruct Vision", r => r.IsCasting);
			result.Add("Code Red", r => r.IsCasting);
			result.Add("Diminisherbot", r => r.IsCasting);
			result.Add("Zap", r => r.IsCasting);
			result.Add("Urgent Withdrawal", r => r.IsCasting);
			result.Add("Bruiserbot", r => (r.IsCasting) || r.GetSurrounding().Count() >= Settings.BruiserbotSurroundAmount);
			result.Add("Repairbot", r => InstanceManager.Party.Average(s => s.ShieldPercent) <= Settings.RepairbotSPercent);

			result.Add("Recursive Matrix", r => GameManager.LocalPlayer.GetSurrounding(20).Count() >= Settings.RecursiveMatrixSurroundAmount);

			// Buff management
			result.Add("Bio Shell", r => !r.HasBuff("Expose"));
			result.Add("Unstable Anomaly", r => !r.HasBuff("Wound"));
			result.Add("Unsteady Miasma", r => !r.HasBuff("Blunder"));
			result.Add("Personal Defense Unit", r => !GameManager.LocalPlayer.HasBuff("Defense"));

			// Proc / Cast when up 

			// IsSpellReady is used for procs!
			result.Add("Quick Burst", r => IsSpellProcReady("Quick Burst"));
			result.Add("Artillerybot", r => IsSpellProcReady("Artillerybot"));
			result.Add("Feedback", r => IsSpellProcReady("Feedback"));
			result.Add("Thresher", r => IsSpellProcReady("Thresher"));

			// Spender
			result.Add("Electrocute", r => GameManager.LocalPlayer.InnateResourcePercent >= Settings.ElectrocuteIPercent);
			result.Add("Mortar Strike", r => GameManager.LocalPlayer.InnateResourcePercent >= Settings.MortarStrikeIPercent);
			result.Add("Bolt Caster", r => GameManager.LocalPlayer.InnateResourcePercent >= Settings.BoltCasterIPercent);

			// Builders 
			result.Add("Disruptive Module", r => GameManager.LocalPlayer.InnateResourcePercent < Settings.DisruptiveModuleIPercent && InstanceManager.Party.Average(s => s.ShieldPercent) <= Settings.DisruptiveModuleSPercent);
			result.Add("Flak Cannon", r => GameManager.LocalPlayer.InnateResourcePercent <= Settings.FlakCannonIPercent);
			result.Add("Ricochet", r => !r.HasBuff("Exhaust") && GameManager.LocalPlayer.InnateResourcePercent <= Settings.RicochetIPercent);
			result.Add("Target Acquisition", r => GameManager.LocalPlayer.InnateResourcePercent <= Settings.TargetAquisitionIPercent);
			result.Add("Shock Pulse", r => GameManager.LocalPlayer.InnateResourcePercent <= Settings.ShockPulseIPercent);
			result.Add("Volatile Injection", r => GameManager.LocalPlayer.InnateResourcePercent <= Settings.VolatileInjectionIPercent);
			result.Add("Energy Auger", r => GameManager.LocalPlayer.InnateResourcePercent <= Settings.EnergyAugerIPercent);
			result.Add("Pulse Blast", r => GameManager.LocalPlayer.InnateResourcePercent <= Settings.PulseBlastIPercent);

			return result;
		}

		public override AbilityPriority CreateRest()
		{
			return new AbilityPriority();
		}
	}
}
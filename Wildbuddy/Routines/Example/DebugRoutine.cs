using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Buddy.Wildstar.BotCommon;
using Buddy.Wildstar.Engine;
using Buddy.Wildstar.Game;

namespace Buddy.DebugRoutine
{
	public class DebugRoutine : CombatRoutineBase, 
		IUIButtonProvider // Tell the UI that we have a button handler we want to deal with
	{
		private const string PullAbility = "Shred";
		private List<string> AbilityPriority = new List<string>
		{
			"Energize",
			"Fissure",
			"Shred",
		};

		#region Overrides of CombatRoutineBase

		/// <summary>
		///     The name of this authored object.
		/// </summary>
		public override string Name { get { return "Debug Routine"; } }

		/// <summary>
		///     The author of this object.
		/// </summary>
		public override string Author { get { return "Apoc"; } }

		/// <summary>
		///     The version of this object implementation.
		/// </summary>
		public override string Version { get { return "1.0.0.0"; } }

		public override async Task Combat()
		{
			// For now, this is all we need to do :)
			foreach (var ability in AbilityPriority)
			{
				if (CanCast(ability))
				{
					Cast(ability);
					return;
				}
			}
		}

		#region Overrides of CombatRoutineBase

		public override async Task Pull(object preferredTarget)
		{
			if(CanCast(PullAbility))
				Cast(PullAbility);
		}

		#endregion

		#endregion

		private bool CanCast(string spell)
		{
			var sp = SpellManager.AvailableSpells.FirstOrDefault(s => s.Name == spell);
			if (sp != null)
			{
				return sp.CooldownTimeRemaining.TotalMilliseconds == 0 && sp.IsSpellReady && sp.InnateCostsMet;
			}
			return false;
		}

		private void Cast(string spell)
		{
			var sp = SpellManager.AvailableSpells.FirstOrDefault(s => s.Name == spell);
			if (sp != null)
			{
				sp.Cast();
			}
		}

		public string ButtonText
		{
			get
			{
				// ButtonText is currently not used for routines. You may provide a string however for future usages.
				return "Example Settings";
			}
		}

		public void OnButtonClicked(object sender)
		{
			// Show settings window here...
		}
	}
}
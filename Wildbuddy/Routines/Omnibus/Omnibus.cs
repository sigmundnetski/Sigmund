//!CompilerOption:AddRef:clipper_library.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Buddy.Common;
using Buddy.Common.Math;
using Buddy.Wildstar.BotCommon;
using Buddy.Wildstar.Engine;
using Buddy.Wildstar.Game;
using Buddy.Wildstar.Game.Actors;

using log4net;

using Omnibus.Classes;
using Omnibus.Classes.Routines;
using Omnibus.Dodge;
using Omnibus.Helpers;
using Omnibus.Settings;

namespace Omnibus
{
	public class Omnibus : CombatRoutineBase, IUIButtonProvider
	{
		public static ILog Logger = LogManager.GetLogger(typeof(Omnibus));
		public static OmnibusSettings WindowSettings = OmnibusSettings.Instance;

		private CombatClass _Routine;
		private Form _configForm;

		public CombatClass Routine { get { return _Routine ?? (_Routine = GetClass()); } }

		#region IUIButtonProvider Members

		public string ButtonText { get { return "Omnibus"; } }

		#endregion

		#region Override IUIButtonProvider 
 
		public void OnButtonClicked(object sender)
		{
			if (_configForm == null || _configForm.IsDisposed || _configForm.Disposing)
			{
				_configForm = new SettingsForm();
                // update pull range on first load 
                WindowSettings.PullRange = Routine.PullRange; 
			}

			Logger.Notice(string.Format("Instanced {0}", Routine));

			foreach (SpellManager.SpellInformation s in SpellManager.AvailableSpells)
			{
				Logger.Debug(string.Format("{0} {1} {2} {3}", s.Name, s.IsValid, s.SpellBarIndex, s.CastTime));
			}

			_configForm.ShowDialog();
		}

		#endregion

		#region Override CombatRoutineBase

		public override string Author { get { return "LastCoder"; } }

		public override string Name { get { return "Omnibus"; } }

		public override string Version { get { return "1.0.3.9"; } }

		public override async Task Combat()
		{
			await Evade();

			if (InstanceManager.Target == null)
			{
				Logger.Debug("Combat target is null... nothing to do right now?");
				return;
			}

			if (!Evading.IsEvading && !GameManager.LocalPlayer.IsDead && !GameManager.LocalPlayer.IsMoving)
			{
				await Routine.CombatTask();
			}
		}

		public override async Task Heal()
		{
			if (InstanceManager.HealTarget == null)
			{
				return;
			}

			if (!Evading.IsEvading && !GameManager.LocalPlayer.IsDead && !GameManager.LocalPlayer.IsMoving)
			{
				await Routine.HealTask();
			}
		}

		public override async Task Rest()
		{
			SpellManager.SpellInformation restAbility = Routine.Rest.ToValidAbilityList(GameManager.LocalPlayer).FirstOrDefault();
			if (restAbility != null)
			{
				await SpellCastBehaviors.CastSimple(restAbility);
			}
		}

		public override async Task Pull(object target)
		{
			var pullTarget = (target as Actor);
			if (pullTarget == null)
			{
				return;
			}

			Targeting.PullTarget = pullTarget;

			if (pullTarget.Distance > Routine.PullRange)
			{
				Logger.Debug(string.Format("[MoveWithin] {0} -> {1} (Distance {2})", GameManager.ControlledUnit.Position, pullTarget.Position, pullTarget.Distance));

				// Stop within pull range, also stop early if we happen to body pull something.
				if (await CommonBehaviors.MoveWithin(pullTarget.Position, Routine.PullRange, true, true) == CommonBehaviors.BehaviorResult.CombatStop)
				{
					// Return only if we body pulled. Chances are, we pulled something we don't actually want.
					return;
				}
				// NOTE: Do not "return" after moving within range.
				//return; 
			}

			SpellManager.SpellInformation pullAbility = Routine.Pull.ToValidAbilityList(pullTarget).FirstOrDefault();

			if (pullAbility == null)
			{
				throw new Exception("Could not find a usable pull ability. Is pull not implemented for this class?");
			}

			Logger.Debug(string.Format("[PULL] FaceCast [Name {0}, SpellBarIndex {1}]", pullAbility.Name, pullAbility.SpellBarIndex));

			if (WindowSettings.EnableMovement)
			{
				pullTarget.Face();
			}

			await SpellCastBehaviors.CastSimple(pullAbility, () => pullTarget, true);
		}

		#endregion

		public async Task Evade()
		{
			// Don't evade if we weren't told to
			if (!WindowSettings.EnableEvade)
			{
				return;
			}

			if (!GameManager.ControlledUnit.Position.IsInDanger())
			{
				Logger.Debug("IsSafe: " + GameManager.ControlledUnit.Position);
				Evading.IsEvading = false;

				return;
			}

			List<Vector3> points = Evading.GetSafePoints();

			if (points.Count > 0)
			{
				Vector3 closest = GameManager.ControlledUnit.Position.Closest(points);

				Logger.Debug("Found safe points...");

				Logger.Debug("Evade to: " + closest);
				Evading.IsEvading = true;
				await CommonBehaviors.MoveTo(closest);
			}
		}

		/// <summary>
		///     Invoke the combat routine instance through name
		/// </summary>
		/// <returns>Created instance</returns>
		private CombatClass GetClass()
		{
			switch (GameManager.LocalPlayer.Class)
			{
				case Class.Warrior:
					return new Warrior();
				case Class.Engineer:
					return new Engineer();
				case Class.ESPer:
					return new ESPer();
				case Class.Medic:
					return new Medic();
				case Class.Stalker:
					return new Stalker();
				case Class.Spellslinger:
					return new Spellslinger();
				default:
					Logger.Critical("Class " + GameManager.LocalPlayer.Class + " is not supported.");
					return null;
			}
		}
	}
}
using System.Linq;

using Buddy.Wildstar.Game;
using Buddy.Wildstar.Game.Actors;

using Omnibus.Helpers;
using Omnibus.Settings;
using Buddy.Wildstar.BotCommon;

namespace Omnibus.Classes.Routines
{
	public class Spellslinger : CombatClass
	{
		public Spellslinger()
		{
			Omnibus.WindowSettings = new SpellslingerSettings();
		}

		private SpellslingerSettings Settings { get { return (Omnibus.WindowSettings as SpellslingerSettings); } }
		
		public override AbilityPriority CreateHeal()
		{
			var result = new AbilityPriority();

			result.Add("Runic Healing", r => GameManager.LocalPlayer.Mana >= 40 && r.HealthPercent < Settings.RunicHealingHPPercent);
			result.Add("Runes of Protection", r => GameManager.LocalPlayer.Mana >= 34 && InstanceManager.Party.Average(s => s.ShieldPercent) < Settings.RunesOfProtectionSPPercent);
			result.Add("Vitality Burst", r => GameManager.LocalPlayer.Mana >= 12 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.VitalityBurstHPPercent);
			result.Add("Astral Infusion", r => GameManager.LocalPlayer.Mana >= 52 && GameManager.LocalPlayer.HealthPercent < Settings.AstralInfusionHPPercent);
			result.Add("Healing Salve", r => GameManager.LocalPlayer.Mana >= 20 && !GameManager.LocalPlayer.HasBuff("Healing Salve"));
			result.Add("Dual Fire", r => GameManager.LocalPlayer.Mana >= 16 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.DualFireHPPercent);
			result.Add("Healing Torrent", r => GameManager.LocalPlayer.Mana >= 31 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.HealingTorrentHPPercent);
			result.Add("Voidspring", r => GameManager.LocalPlayer.Mana >= 27 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.VoidSpringHPPercent);
			result.Add("Regenerative Pulse", r => GameManager.LocalPlayer.Mana >= 33 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.RegenerativePulseHPPercent);
			result.Add("Sustain", r => GameManager.LocalPlayer.Mana >= 30 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.SustainHPPercent);

			return result;
		}

		public override AbilityPriority CreateCombat()
		{
			var result = new AbilityPriority();

            // Spell interrupting
			result.Add("Gate", r => r.IsCasting && GameManager.LocalPlayer.InnateResource <= 1);
			result.Add("Flash Freeze", r => r.IsCasting);
			result.Add("Chill", r => r.IsCasting);
			result.Add("Arcane Shock", r => r.IsCasting);
            #region Spatial Shift
            result.Add("Spatial Shift", r =>
				{
					if (r != null)
					{
						Actor Target = r;

						return Target.IsCasting && (GameManager.LocalPlayer.InnateResource == 1 || GameManager.LocalPlayer.InnateResource >= 2 && (CanCast("Gate") || CanCast("Arcane Shock")));
					}
					return false;
				});
            #endregion 
            // Cleansing 
            result.Add("Void Slip", r => GameManager.LocalPlayer.HasCleansableCC());
			result.Add("Purify", r => GameManager.LocalPlayer.Mana >= 15 && GameManager.LocalPlayer.HealthPercent < Settings.PurifyHPPercent && GameManager.LocalPlayer.Buffs.Count(s => s.IsHarmful) >= 1);

            // Buff application
            result.Add("Void Pact", r => !GameManager.LocalPlayer.HasBuff("Empower"));
            result.Add("Phase Shift", r => !GameManager.LocalPlayer.HasBuff("Defense"));

            // Special
            result.Add("Gather Focus", r => GameManager.LocalPlayer.Mana < 100);
            result.Add("Affinity", r => InstanceManager.LowestHealth.HealthPercent < Settings.AffinityHPPercent);

            // Builder & spenders 
			#region Spell surge

            // Build reliant Spell Surge
            result.Add("Ignite",
                r =>
                {
                    if (r != null)
                    {
                        Actor Target = r;
                        var Ignite = GetSpell("Ignite");
                        return Ignite != null && Ignite.CanCast && (Ignite.Ability.TierIndex <= 8 && !Target.HasBuff("Ignite") || Ignite.Ability.TierIndex == 8);
                    }

                    return false;
                }, async cast =>
                {
                    await SpellCastBehaviors.CastSimple("Spell Surge");
                    await SpellCastBehaviors.CastSimple("Ignite"); 

                    return await SpellCastBehaviors.CastSimple("Spell Surge");
                });
			result.Add("Quick Draw",
				r =>
				{
					if (r != null)
					{
						Actor Target = r;
						var QuickDraw = GetSpell("Quick Draw");
						return QuickDraw != null && QuickDraw.CanCast && Target.HealthPercent < 30 && GameManager.LocalPlayer.Mana >= 50;
					}

					return false;
				}, 
                async cast =>
                {
                    await SpellCastBehaviors.CastSimple("Spell Surge");
                    await SpellCastBehaviors.CastSimple("Quick Draw"); 

                    return await SpellCastBehaviors.CastSimple("Spell Surge");
                });
			result.Add("Flame Burst",
				r =>
				{
					if (r != null)
					{
						Actor Target = r;
						var FlameBurst = GetSpell("Flame Burst");
						return FlameBurst != null && FlameBurst.CanCast && (FlameBurst.Ability.TierIndex == 8 && Target.HasBuff("Ignite") || FlameBurst.Ability.TierIndex < 8);
					}

					return false;
				}, 
                async cast =>
                {
                    await SpellCastBehaviors.CastSimple("Spell Surge");
                    await SpellCastBehaviors.CastSimple("Flame Burst"); 

                    return await SpellCastBehaviors.CastSimple("Spell Surge");
                });
			result.Add("Assassinate",
				r =>
				{
					if (r != null)
					{
						Actor Target = r;
						var Assassinate = GetSpell("Assassinate");
						return Assassinate != null && Assassinate.CanCast && (Target.HealthPercent >= 30 && GameManager.LocalPlayer.Mana > 25 || Target.HealthPercent < 30);
					}

					return false;
				}, 
                async cast =>
                {
                    await SpellCastBehaviors.CastSimple("Spell Surge");
                    await SpellCastBehaviors.CastSimple("Assassinate"); 

                    return await SpellCastBehaviors.CastSimple("Spell Surge");
                });

            // "Spam" Spell Surge 
            result.Add("Wild Barrage", r => true, async cast =>
            {
                await SpellCastBehaviors.CastSimple("Spell Surge");
                await SpellCastBehaviors.CastSimple("Wild Barrage");

                return await SpellCastBehaviors.CastSimple("Spell Surge");
            });
            result.Add("Rapid Fire", r => true, async cast =>
            {
                await SpellCastBehaviors.CastSimple("Spell Surge");
                await SpellCastBehaviors.CastSimple("Rapid Fire");

                return await SpellCastBehaviors.CastSimple("Spell Surge");
            });
            result.Add("True Shot", r => true, async cast =>
            {
                await SpellCastBehaviors.CastSimple("Spell Surge");
                await SpellCastBehaviors.CastSimple("True Shot");

                return await SpellCastBehaviors.CastSimple("Spell Surge");
            });
            result.Add("Arcane Missiles", r => !r.HasBuff("Expose"), async cast =>
            {
                await SpellCastBehaviors.CastSimple("Spell Surge");
                await SpellCastBehaviors.CastSimple("Arcane Missiles");

                return await SpellCastBehaviors.CastSimple("Spell Surge");
            });
            result.Add("Charged Shot", r => true, async cast =>
            {
                await SpellCastBehaviors.CastSimple("Spell Surge");
                await SpellCastBehaviors.CastSimple("Charged Shot");

                return await SpellCastBehaviors.CastSimple("Spell Surge");
            });
			#endregion

			return result;
		}

		public override AbilityPriority CreateRest()
		{
			return new AbilityPriority();
		}

	}
}
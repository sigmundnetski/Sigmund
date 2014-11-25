using Buddy.Wildstar.Game;
using Buddy.Wildstar.Game.Actors;
using Omnibus.Helpers;
using Omnibus.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibus.Classes.Routines
{
    public class Stalker : CombatClass
    {

        public Stalker()
        {
            Omnibus.WindowSettings = new StalkerSettings();
        }

        private StalkerSettings Settings
        {
            get
            {
                return (Omnibus.WindowSettings as StalkerSettings);
            }
        }

        public override AbilityPriority CreatePull()
        {
            return base.CreatePull();
        }

        public override AbilityPriority CreateHeal()
        {
            return new AbilityPriority();
        }

        public override AbilityPriority CreateCombat()
        {
            var result = new AbilityPriority();

            // Spell interrupt
            result.Add("Stagger", r => r.IsCasting);
            result.Add("False Retreat", r => r.IsCasting);
            result.Add("Pounce", r => r.IsCasting);
            result.Add("Tether Mine", r => r.IsCasting);
            result.Add("Collapse", r => r.IsCasting);

            // Buff application
            result.Add("Phlebotomize", r => GameManager.LocalPlayer.SuitPower >= 15 && !r.HasBuff("Wound"));
            result.Add("Reaver", r => !r.HasCC(CCStateType.Taunt));
            result.Add("Bloodthirst", r => !GameManager.LocalPlayer.HasBuff("Lifesteal"));
            result.Add("Preperation", r => !GameManager.LocalPlayer.HasBuff("Empower") && !GameManager.LocalPlayer.HasBuff("Defense"));
            result.Add("Decimate", r => !r.HasBuff("Weaken"));
            #region Concussive Kicks
            result.Add("Concussive Kicks", r =>
            {
                var punish = GetSpell("Punish");

                if (punish != null && punish.CooldownTimeRemaining.TotalMilliseconds < 2000)
                    return false;

                return !GameManager.LocalPlayer.HasBuff("Concussive Kicks - Cooldown") || GameManager.LocalPlayer.HasBuff("Concussive Kicks - Cooldown") && GameManager.LocalPlayer.SuitPower >= 15;
            });
            #endregion 

            // Cast when-up
            //result.Add("Tactical Retreat", r => true); REMOVED 
            result.Add("Whiplash", r => true);
            result.Add("Razor Storm", r => true);
            result.Add("Stim Drone", r => true);
                        
            // Spenders
            result.Add("Neutralize", r => GameManager.LocalPlayer.SuitPower >= 15 && !GameManager.LocalPlayer.HasBuff("Neutralize"));
            result.Add("Punish", r => GameManager.LocalPlayer.SuitPower < 35 && !GameManager.LocalPlayer.HasBuff("Punish"));
            #region Shred
            result.Add("Shred", r =>
            {
                var impale = GetSpell("Impale");

                if (impale != null && impale.Ability.TierIndex >= 8)
                    return GameManager.LocalPlayer.SuitPower < 30;

                return GameManager.LocalPlayer.SuitPower <= 35;
            });
            #endregion
            #region Impale
            result.Add("Impale", r =>
            {
                var impale = GetSpell("Impale");

                if (impale != null && impale.Ability.TierIndex >= 8)
                    return GameManager.LocalPlayer.SuitPower >= 30;

                return GameManager.LocalPlayer.SuitPower >= 35;
            });
            #endregion
            result.Add("Clone", r => GameManager.LocalPlayer.SuitPower >= 25);
            result.Add("Analyze Weakness", r => GameManager.LocalPlayer.SuitPower >= 15);
            result.Add("Ruin", r => GameManager.LocalPlayer.SuitPower >= 10);
            result.Add("Cripple", r => GameManager.LocalPlayer.SuitPower >= 5 && GameManager.LocalPlayer.SuitPower >= 3);
            result.Add("Nano Field", r => GameManager.LocalPlayer.SuitPower >= 20);
            result.Add("Razor Disk", r => GameManager.LocalPlayer.SuitPower >= 20);
            result.Add("Nano Virus", r => GameManager.LocalPlayer.SuitPower >= 10);
            result.Add("Amplification Spike", r => GameManager.LocalPlayer.SuitPower >= 25);
            result.Add("Frenzy", r => GameManager.LocalPlayer.SuitPower >= 30);
            result.Add("Nano Dart", r => GameManager.LocalPlayer.SuitPower >= 10);

            // Builders
            result.Add("Steadfast", r => GameManager.LocalPlayer.SuitPower < 100 && !GameManager.LocalPlayer.HasBuff("Defense"));

            return result;
        }

        public override AbilityPriority CreateRest()
        {
            return new AbilityPriority();
        }
    }
}

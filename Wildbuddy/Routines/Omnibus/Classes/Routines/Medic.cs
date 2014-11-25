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
    public class Medic : CombatClass
    {

        public Medic()
        {
            Omnibus.WindowSettings = new MedicSettings();
        }

        private MedicSettings Settings
        {
            get
            {
                return (Omnibus.WindowSettings as MedicSettings);
            }
        }

        public override AbilityPriority CreatePull()
        {
            return base.CreatePull();
        }

        public override AbilityPriority CreateHeal()
        {
            var result = new AbilityPriority();

            result.Add("Emission", r => GameManager.LocalPlayer.InnateResource < 2);
            result.Add("Crisis Wave", r => GameManager.LocalPlayer.InnateResource >= 2 && GameManager.LocalPlayer.Mana >= 35 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.CrisisWaveHPPercent);
            result.Add("Dual Shock", r => GameManager.LocalPlayer.Mana >= 35 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.DualShockHPPercent);
            result.Add("Mending Probes", r => GameManager.LocalPlayer.Mana >= 18 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.MendingProbesHPPercent);
            result.Add("Triage", r => GameManager.LocalPlayer.Mana >= 20 && InstanceManager.Party.OrderBy(s => s.HealthPercent).FirstOrDefault().HealthPercent < Settings.TriageHPPercent && InstanceManager.Party.OrderBy(s => s.ShieldPercent).FirstOrDefault().ShieldPercent < Settings.TriageSPPercent);
            result.Add("Flash", r => GameManager.LocalPlayer.Mana >= 28 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.FlashHPPercent);
            result.Add("Barrier", r => GameManager.LocalPlayer.Mana >= 86 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.BarrierHPPercent && InstanceManager.Party.Average(s => s.ShieldPercent) < Settings.BarrierSPPercent);
            result.Add("Rejuvenator", r => GameManager.LocalPlayer.Mana >= 30 && InstanceManager.Party.Average(s => s.HealthPercent) < Settings.RejuvenatorHPPercent);
            result.Add("Shield Surge", r => GameManager.LocalPlayer.Mana >= 41 && GameManager.LocalPlayer.InnateResource >= 2 && InstanceManager.Party.Average(s => s.ShieldPercent) < Settings.ShieldSurgeSPPercent);
            result.Add("Extricate", r => GameManager.LocalPlayer.Mana >= 46 && GameManager.LocalPlayer.HealthPercent < Settings.ExtricateHPPercent);
            result.Add("Field Probes", r => GameManager.LocalPlayer.HasBuff("Beacon") && InstanceManager.Party.Average(s => s.HealthPercent) < 50);

            return result;
        }

        public override AbilityPriority CreateCombat()
        {
            var result = new AbilityPriority();

            // Spell interrupting
            result.Add("Magnetic Lockdown", r => r.IsCasting);
            result.Add("Paralytic Surge", r => r.IsCasting);
            
            // Cleansing
            result.Add("Dematerialize", r => r.Buffs.Count(s => s.IsBeneficial) > 1);
            result.Add("Calm", r => GameManager.LocalPlayer.HasCleansableCC());
            result.Add("Antidote", r => GameManager.LocalPlayer.Mana > 24 && GameManager.LocalPlayer.HealthPercent < 50 && GameManager.LocalPlayer.Buffs.Count(s => s.IsHarmful) > 1);

            // Buff application
            result.Add("Fissure", r => !r.HasBuff("Expose"));
            result.Add("Protection Probes", r => !GameManager.LocalPlayer.HasBuff("Defense"));
            result.Add("Empowering Probes", r => !GameManager.LocalPlayer.HasBuff("Empower"));
                     
            // Cast when-up / health percentage 
            result.Add("Collider", r => r.HealthPercent < 30);
            result.Add("Nullifier", r => true);
            result.Add("Devastator Probes", r => true);
            result.Add("Annihilation", r => true);
            result.Add("Urgency", r => true);
            result.Add("Restrictor", r => true);

            // Spenders
            result.Add("Gamma Rays", r => GameManager.LocalPlayer.InnateResource >= 2);
            result.Add("Quantum Cascade", r => GameManager.LocalPlayer.InnateResource >= 2);
                       
            // Chargers
            result.Add("Discharge", r => GameManager.LocalPlayer.InnateResource < 2);
            result.Add("Atomize", r => GameManager.LocalPlayer.InnateResource < 2);
            result.Add("Recharge", r => GameManager.LocalPlayer.Mana < 80);

            return result;
        }

        public override AbilityPriority CreateRest()
        {
            return new AbilityPriority(); 
        }
    }
}

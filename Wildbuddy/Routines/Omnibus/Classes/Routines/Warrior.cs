using Buddy.Wildstar.Game;
using Buddy.Wildstar.Game.Actors;
using Omnibus.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibus.Classes.Routines
{
    public class Warrior : CombatClass
    {
        public override AbilityPriority CreateHeal()
        {
            var result = new AbilityPriority();

            return result; 
        }

        public override AbilityPriority CreatePull()
        {
            return base.CreatePull();
        }

        public override AbilityPriority CreateCombat()
        {
            var result = new AbilityPriority();

            // Spell Interrupt
            result.Add("Kick", r => r.IsCasting);

            // CC handle & break
            result.Add("Flash Bang", r => r.HasCC(CCStateType.Blind));
            result.Add("Tether Bolt", r => GameManager.LocalPlayer.HasCC(CCStateType.Tether));
            result.Add("Unstoppable Force", r => GameManager.LocalPlayer.HasCleansableCC());
            result.Add("Leap", r => r.Distance > 10 || GameManager.LocalPlayer.HasCleansableCC());
            result.Add("Savage Strikes", r => GameManager.LocalPlayer.HasCC(CCStateType.Knockback));

            // Shield handle 
            result.Add("Shield Burst", r => GameManager.LocalPlayer.ShieldPercent == 0); 

            // Buff application
            result.Add("Polarity Field", r => !r.HasBuff("Exhaust") && r.GetSurrounding().Count() > 1);
            result.Add("Augmented Blade", r => !r.HasBuff("Wound"));
            result.Add("Smackdown", r => r.HasBuff("Expose"));
            result.Add("Sentinel", r => !GameManager.LocalPlayer.HasBuff("Guard"));

            // Cast when-up
            result.Add("Power Link", r => true);
            result.Add("Defense Grid", r => true);
            result.Add("Emergency Reserves", r => true);

            // TANK?
            result.Add("Plasma Blast", r => r.CurrentTarget != null && r.CurrentTarget.Guid != GameManager.LocalPlayer.Guid);
            result.Add("Atomic Surge", r => InstanceManager.IsTank && r.CurrentTarget != null && r.CurrentTarget.Guid != GameManager.LocalPlayer.Guid);
            result.Add("Bum Rush", r => InstanceManager.IsTank || GameManager.LocalPlayer.HealthPercent < 70);
            result.Add("Tremor", r => r.GetSurrounding().Count() > 1);

            // Spenders
            result.Add("Rampage", r => GameManager.LocalPlayer.InnateResourcePercent >= 90);
            result.Add("Whirlwind", r => GameManager.LocalPlayer.InnateResourcePercent >= 90); 
            result.Add("Expulsion", r => GameManager.LocalPlayer.Buffs.Where(b => b.IsHarmful).Count() >= 1);
            result.Add("Bolstering Strike", r => GameManager.LocalPlayer.InnateResource > 250 && InstanceManager.Party.Average(s => s.HealthPercent) < 50); 
            result.Add("Jolt", r => GameManager.LocalPlayer.InnateResource > 90 && GameManager.LocalPlayer.InnateResourcePercent >= 90); 
            result.Add("Plasma Wall", r => GameManager.LocalPlayer.InnateResource > 90 && GameManager.LocalPlayer.InnateResourcePercent >= 90);
            result.Add("Ripsaw", r => r.GetSurrounding().Count() > 1);
            
            // Builders
            result.Add("Menacing Strike", r => GameManager.LocalPlayer.InnateResourcePercent < 90 && GameManager.LocalPlayer.HealthPercent < 70); 
            result.Add("Breaching Strikes", r => GameManager.LocalPlayer.InnateResourcePercent < 90 && GameManager.LocalPlayer.InnateResourcePercent < 90); 
            result.Add("Relentless Strikes", r => GameManager.LocalPlayer.InnateResourcePercent < 90); 

            return result; 
        }

        public override AbilityPriority CreateRest()
        {
            return new AbilityPriority(); 
        }
    }
}

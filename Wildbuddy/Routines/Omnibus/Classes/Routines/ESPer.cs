using Buddy.Wildstar.BotCommon;
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
    public class ESPer : CombatClass
    {

        public ESPer()
        {
            Omnibus.WindowSettings = new EsperSettings(); 
        }

        private EsperSettings Settings
        {
            get
            {
                return (Omnibus.WindowSettings as EsperSettings); 
            }
        }

        public override AbilityPriority CreatePull()
        {
            return base.CreatePull();
        }

        public override AbilityPriority CreateHeal()
        {
            var result = new AbilityPriority();
            
            // High Priority / Buff Management 
            result.Add("Phantasmal Armor", r => (InstanceManager.Tank != null ? InstanceManager.Tank.HealthPercent : GameManager.LocalPlayer.HealthPercent) < Settings.PhantasmalArmorHP);
            result.Add("Catharsis", r => GameManager.LocalPlayer.HealthPercent < Settings.CatharsisHP && InstanceManager.CleanseTarget.Buffs.Count > Settings.CatharsisBuff, async cast =>
            {
                var Target = InstanceManager.CleanseTarget;

                if (Omnibus.WindowSettings.EnableMovement)
                    Target.Face();

                return await SpellCastBehaviors.CastSimple("Catharsis", () => Target, awaitCastFinished: true); 
            });

            // Medium Priority / Psi Point Specific 
            result.Add("Mental Boon", r => GameManager.LocalPlayer.InnateResource == 5 && GameManager.LocalPlayer.HealthPercent < Settings.MentalBoonHP);
            result.Add("Reverie", r => InstanceManager.AveragePartyHealth < Settings.ReverieHP && GameManager.LocalPlayer.InnateResource == 5);
            result.Add("Mending Banner", r => InstanceManager.AveragePartyHealth < Settings.MendingBannerHP && GameManager.LocalPlayer.InnateResource == 5);
           
            // Medium Low Priority / Health Percentage 
            result.Add("Projected Spirit", r => InstanceManager.AveragePartyHealth > Settings.ProjectedSpiritHP);

            // Low Priority / Psi Point Builders 
            result.Add("Meditate", r => GameManager.LocalPlayer.InnateResource < 5 && GameManager.LocalPlayer.HealthPercent <= Settings.MeditateHP);
            result.Add("Pyrokinetic Flame", r => InstanceManager.AveragePartyHealth < Settings.PyrokineticFlameHP && GameManager.LocalPlayer.InnateResource < 5);
            result.Add("Warden", r => GameManager.LocalPlayer.InnateResource < 5 && (GameManager.LocalPlayer.HealthPercent < Settings.WardenHP || InstanceManager.AveragePartyHealth < Settings.WardenAllyHP)); 
            result.Add("Mirage", r => GameManager.LocalPlayer.InnateResource < 5 && GameManager.LocalPlayer.HealthPercent < Settings.MirageHP);
            result.Add("Soothe", r => GameManager.LocalPlayer.InnateResource < 5 && GameManager.LocalPlayer.HealthPercent < Settings.SootheHP); 
            result.Add("Bolster", r => GameManager.LocalPlayer.InnateResource < 5 && GameManager.LocalPlayer.HealthPercent < Settings.BolsterHP); 
            result.Add("Mind Over Body", r => GameManager.LocalPlayer.InnateResource < 5 && GameManager.LocalPlayer.HealthPercent < Settings.MindOverBodyHP); 

            return result; 
        }

        public override AbilityPriority CreateCombat()
        {
            var result = new AbilityPriority();

            // High Priority / Buff Management
            result.Add("Haunt", r => !r.HasBuff("Haunt"));
            result.Add("Fade Out", r => GameManager.LocalPlayer.HasCleansableCC());

            // Medium Priority / Psi Point Specific
            result.Add("Reap", r => GameManager.LocalPlayer.InnateResource == 5); 
            result.Add("Mind Burst", r => GameManager.LocalPlayer.InnateResource == 5);
            result.Add("Telekinetic Storm", r => GameManager.LocalPlayer.InnateResource == 5);
            result.Add("Spectral Form", r => GameManager.LocalPlayer.InnateResource >= 4);

            // Medium Low Priority / Cast Once (summon) 
            result.Add("Spectral Swarm", r => true);
            result.Add("Geist", r => true);

            // Low Priority / Interrupt
            result.Add("Shockwave", r => r.IsCasting); 
            result.Add("Restraint", r => r.IsCasting); 
            result.Add("Crush", r => r.IsCasting);
            result.Add("Incapacitate", r => r.IsCasting); 

            // Spam Priority / Psi Point builders 
            result.Add("Psychic Frenzy", r => GameManager.LocalPlayer.InnateResource < 5);
            result.Add("Illusionary Blades", r => GameManager.LocalPlayer.InnateResource < 5); 
            result.Add("Blade Dance", r => GameManager.LocalPlayer.InnateResource < 5); 
            result.Add("Telekinetic Strike", r => GameManager.LocalPlayer.InnateResource < 5);
            result.Add("Concentrated Blade", r => GameManager.LocalPlayer.InnateResource < 5);

            return result; 
        }

        public override AbilityPriority CreateRest()
        {
            return new AbilityPriority(); 
        }
    }

 }

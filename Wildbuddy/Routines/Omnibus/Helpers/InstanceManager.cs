using Buddy.Wildstar.Engine;
using Buddy.Wildstar.Game;
using Buddy.Wildstar.Game.Actors;
using Omnibus.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibus.Helpers
{
    public static class InstanceManager
    {
        private static readonly Class[] CLASS_HEAL = new Class[] { Class.ESPer, Class.Medic, Class.Spellslinger };
        private static readonly Class[] CLASS_TANK = new Class[] { Class.Engineer, Class.Stalker, Class.Warrior };
        
        public static bool IsTank
        {
            get { return GameManager.LocalPlayer.Class.IsOneOf(CLASS_TANK) && Omnibus.WindowSettings.EnableTank; }
        }

        public static bool IsHealer
        {
            get { return GameManager.LocalPlayer.Class.IsOneOf(CLASS_HEAL) && Omnibus.WindowSettings.EnableHeal; }
        }

        public static Actor HealTarget 
        {
            get
            {
                return GameManager.LocalPlayer.IsInGroup ? Party.OrderBy(unit => unit != null ? unit.HealthPercent : 101).FirstOrDefault() : GameManager.LocalPlayer; 
            }
        }

        public static Actor Tank
        {
            get
            {
                return IsTank ? GameManager.LocalPlayer : Party.FirstOrDefault(unit => unit.Class.IsOneOf(CLASS_TANK)) == null ? GameManager.LocalPlayer : Party.FirstOrDefault(unit => unit.Class.IsOneOf(CLASS_TANK)); 
            }
        }

        public static Actor Healer
        {
            get
            {
                return IsHealer ? GameManager.LocalPlayer : Party.FirstOrDefault(unit => unit.Class.IsOneOf(CLASS_HEAL)) == null ? GameManager.LocalPlayer : Party.FirstOrDefault(unit => unit.Class.IsOneOf(CLASS_HEAL)); 
            }
        }

        public static Actor CleanseTarget
        {
            get
            {
                return Party.OrderByDescending(u => u != null ? u.Buffs.Where(b => b.IsHarmful).Count() : 0).FirstOrDefault();
            }
        }

        public static Actor LowestHealth
        {
            get
            {
                return Party.OrderBy(s => s.HealthPercent).FirstOrDefault();
            }
        }

        public static float AveragePartyHealth
        {
            get
            {
                return Party.Average(s => s.HealthPercent);
            }
        }

        public static Actor Target
        {
            get
            {
                return Targeting.Target; 
            }
        }

        public static List<Actor> Party
        {
            get
            {
				// I'm gonna shoot him...

				if(!GameManager.LocalPlayer.IsInGroup)
					return new List<Actor> { GameManager.LocalPlayer };

	            var groupId = GameManager.LocalPlayer.CurrentGroupId;

	            return GameManager.Actors.Values.Where(a => a.CurrentGroupId == groupId).ToList();
            }
        }
    }
}

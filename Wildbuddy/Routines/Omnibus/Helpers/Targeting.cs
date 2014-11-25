using Buddy.Wildstar.Game;
using Buddy.Wildstar.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibus.Helpers
{
    public static class Targeting
    {
		public static Actor PullTarget { get; set; }

        public static Actor Target
        {
            get
            {
				// Try to use the pull target for the main target, if one has been passed.
	            if (PullTarget != null && PullTarget.IsValid)
		            return PullTarget;

                return Sorted.FirstOrDefault(u => u != null && u.IsValid); 
            }
        }

        public static List<Actor> Sorted
        {
            get
            {
				return ActorsInCombatWithMe.OrderByDescending(u => u.Weigh()).ToList(); 
            }
        }

	    public static List<Actor> ActorsInCombatWithMe
	    {
		    get
		    {
			    var lp = GameManager.LocalPlayer;
			    var cu = GameManager.ControlledUnit;
			    return GameManager.Actors.Values.Where(actor =>
			    {
				    if (actor == null || !actor.IsValid)
					    return false;

				    // Actor isn't in combat, so we don't want to worry about them.
				    if (!actor.IsInCombat)
					    return false;

				    // Don't include friendly targets. Maybe?
				    if (actor.Disposition == Disposition.Friendly)
					    return false;

					// They're actively targeting us, so we're obviously in combat with them.
				    if (actor.CurrentTargetGuid == lp.Guid || actor.CurrentTargetGuid == cu.Guid)
					    return true;

					// Tagged by us explicitly
				    if (actor.TaggedByLocalPlayer)
					    return true;

					// Tagged by our group
				    if (actor.TaggedByLocalPlayerGroup)
					    return true;

				    return false;
			    }).ToList();
		    }
	    } 

        public static List<Actor> AggressiveActors
        {
            get
            {
	            return
		            GameManager.Actors.Values.Where(
			            u =>
			            {
				            if (u == null)
					            return false;
				            if (!u.IsValid)
					            return false;
				            if (!u.IsInCombat)
					            return false;

							// Friendly is higher than neutral. Hostile(0), Neutral(1), Friendly(2), Unknowns(3+)
				            if (u.Disposition > Disposition.Neutral)
					            return false;

							// If it's not tagged at all (There are special flags checked)
							// Then we shouldn't include this actor.
				            if (!u.IsTagged)
					            return false;

							// Is it tagged by me?
				            if (u.TaggedByGuid == GameManager.LocalPlayer.Guid)
					            return true;

							// Tagged by the group?
				            if (GameManager.LocalPlayer.CurrentGroupId != 0 && u.TaggedByGroupId == GameManager.LocalPlayer.CurrentGroupId)
					            return true;

							// If the actor is actively targeting us, include it. It may not be tagged by us, but we still need to worry about it.
				            if (u.CurrentTarget != null && u.CurrentTarget == GameManager.LocalPlayer)
					            return true;

							// Not something we want to worry about.
				            return false;
			            })
			            .ToList();
            }
        }

        public static double Weigh(this Actor unit)
        {
            double result = 0;

            result += (int) (unit.MaxHealth - unit.Health) * 2; 
            result += unit.InterruptArmor * 2;

            result -= unit.Distance * 1.5; 
            result -= (int)(unit.AbsorptionMax - unit.Absorption) * 1.5; 

            return result; 
        }
    }
}
